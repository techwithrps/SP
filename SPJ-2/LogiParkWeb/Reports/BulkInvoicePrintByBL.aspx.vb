Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Diagnostics
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Configuration
Imports System.Linq
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection

Partial Class Reports_Imports_BulkInvoicePrintByBL
    Inherits System.Web.UI.Page

    Private Class ResultRow
        Public Property BLNo As String
        Public Property InvoiceRefNo As String
        Public Property InvoiceNo As String
        Public Property Status As String
        Public Property FilePath As String
    End Class

    Private Const SESSION_KEY_LAST_BATCH As String = "BulkInvoicePrintByBL_LastBatchFiles"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' A batch of invoices can take a while to render/convert - give the
        ' request more room than the default ~110 seconds.
        Server.ScriptTimeout = 1200
        If Not IsPostBack Then
            lblMessage.Text = ""
        End If
    End Sub

    Protected Sub btnProcess_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lblMessage.ForeColor = Drawing.Color.Black
        lblMessage.Text = ""
        gvResults.DataSource = Nothing
        gvResults.DataBind()
        Session(SESSION_KEY_LAST_BATCH) = Nothing

        If Not fuCsv.HasFile Then
            ShowError("Please choose a CSV file first.")
            Return
        End If
        If Not fuCsv.FileName.ToLower().EndsWith(".csv") Then
            ShowError("Please upload a .csv file.")
            Return
        End If

        Dim blList As List(Of String) = ReadBLNumbersFromCsv(fuCsv.FileContent)
        If blList.Count = 0 Then
            ShowError("No B/L numbers were found in the uploaded file.")
            Return
        End If

        Dim outputFolder As String = ConfigurationManager.AppSettings("InvoicePdfOutputFolder")
        If String.IsNullOrEmpty(outputFolder) Then outputFolder = "D:\Invoices\"
        If Not outputFolder.EndsWith("\") Then outputFolder &= "\"
        Try
            Directory.CreateDirectory(outputFolder)
        Catch ex As Exception
            ShowError("Cannot create/access output folder '" & outputFolder & "': " & ex.Message)
            Return
        End Try

        Dim companyId As Integer = 0
        Integer.TryParse(Convert.ToString(Session.Item("CompanyId")), companyId)

        ' Built once and reused for every request this batch makes (page HTML,
        ' stylesheets, images) so every fetch is authenticated as you.
        Dim cookies As CookieContainer = BuildCookieContainer()

        Dim results As New List(Of ResultRow)
        Dim savedFiles As New List(Of String)

        For Each bl As String In blList
            Dim invoiceRows As DataTable = Nothing
            Try
                invoiceRows = GetInvoicesByBLNo(companyId, bl)
            Catch ex As Exception
                results.Add(New ResultRow With {.BLNo = bl, .InvoiceRefNo = "", .InvoiceNo = "", .Status = "DB error: " & ex.Message, .FilePath = ""})
                Continue For
            End Try

            If invoiceRows Is Nothing OrElse invoiceRows.Rows.Count = 0 Then
                results.Add(New ResultRow With {.BLNo = bl, .InvoiceRefNo = "", .InvoiceNo = "", .Status = "No invoice found", .FilePath = ""})
                Continue For
            End If

            Dim processedInvoiceNos As New HashSet(Of String)
            For Each row As DataRow In invoiceRows.Rows
                Dim invoiceNo As String = Convert.ToString(row("INVOICE_NO"))
                If processedInvoiceNos.Contains(invoiceNo) Then Continue For
                processedInvoiceNos.Add(invoiceNo)

                Dim invoiceRefNo As String = Convert.ToString(row("INVOICE_REF_NO"))
                Dim serviceType As String = Convert.ToString(row("SERVICE_TYPE"))
                Dim rowCompanyId As Integer = 0
                Integer.TryParse(Convert.ToString(row("COMPANY_ID")), rowCompanyId)
                Dim billTo As Integer = 0
                Integer.TryParse(Convert.ToString(row("BILL_TO")), billTo)

                Dim result As New ResultRow With {.BLNo = bl, .InvoiceRefNo = invoiceRefNo, .InvoiceNo = invoiceNo}
                Try
                    Dim relativeUrl As String = BuildInvoicePrintUrl(invoiceNo, serviceType, rowCompanyId, billTo)
                    Dim absoluteUrl As String = Request.Url.GetLeftPart(UriPartial.Authority) & relativeUrl

                    Dim fileNameSafe As String = SanitizeFileName(bl & "_" & invoiceNo) & ".pdf"
                    Dim pdfPath As String = outputFolder & fileNameSafe

                    SaveInvoiceAsPdf(absoluteUrl, pdfPath, cookies)

                    result.Status = "Saved"
                    result.FilePath = pdfPath
                    savedFiles.Add(pdfPath)
                Catch ex As Exception
                    result.Status = "Failed: " & ex.Message
                    result.FilePath = ""
                End Try
                results.Add(result)
            Next
        Next

        gvResults.DataSource = results
        gvResults.DataBind()

        Dim savedCount As Integer = results.Where(Function(r) r.Status = "Saved").Count()
        lblMessage.Text = String.Format("Processed {0} B/L number(s), {1} invoice(s) attempted, {2} saved.",
                                         blList.Count, results.Count, savedCount)

        If savedFiles.Count > 0 Then
            Session(SESSION_KEY_LAST_BATCH) = savedFiles
            btnDownloadZip.Visible = True
        Else
            btnDownloadZip.Visible = False
        End If
    End Sub

    ' Zips up the PDFs from the last successful run and streams the zip
    ' straight to the browser as a download - so it ends up on the user's
    ' own machine, not just in D:\Invoices\ on the server.
    Protected Sub btnDownloadZip_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim savedFiles As List(Of String) = TryCast(Session(SESSION_KEY_LAST_BATCH), List(Of String))
        If savedFiles Is Nothing OrElse savedFiles.Count = 0 Then
            ShowError("Nothing to download yet - process a CSV first.")
            Return
        End If

        Dim zipPath As String = Path.Combine(Path.GetTempPath(), "InvoiceBatch_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".zip")
        Using zip As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Create)
            For Each f As String In savedFiles
                If File.Exists(f) Then
                    zip.CreateEntryFromFile(f, Path.GetFileName(f))
                End If
            Next
        End Using

        Response.Clear()
        Response.ContentType = "application/zip"
        Response.AddHeader("Content-Disposition", "attachment; filename=Invoices_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".zip")
        Response.TransmitFile(zipPath)
        Response.Flush()
        Response.End()
    End Sub

    Private Sub ShowError(ByVal msg As String)
        lblMessage.ForeColor = Drawing.Color.Red
        lblMessage.Text = msg
    End Sub

    ' Reads a single-column CSV (header optional) of B/L numbers, de-duplicated.
    Private Function ReadBLNumbersFromCsv(ByVal fileStream As Stream) As List(Of String)
        Dim list As New List(Of String)
        Using sr As New StreamReader(fileStream)
            Dim isFirstLine As Boolean = True
            Do While Not sr.EndOfStream
                Dim line As String = sr.ReadLine()
                If line Is Nothing Then Continue Do
                line = line.Trim()
                If line = "" Then Continue Do

                If isFirstLine Then
                    isFirstLine = False
                    Dim headerCheck As String = line.Trim(New Char() {""""c}).Trim().ToUpper()
                    If headerCheck.Contains("B/L") OrElse headerCheck = "BL NO" OrElse headerCheck = "BLNO" Then
                        Continue Do
                    End If
                End If

                Dim value As String = line.Split(","c)(0).Trim().Trim(New Char() {""""c}).Trim()
                If value <> "" AndAlso Not list.Contains(value) Then
                    list.Add(value)
                End If
            Loop
        End Using
        Return list
    End Function

    Private Function GetInvoicesByBLNo(ByVal companyId As Integer, ByVal blNo As String) As DataTable
        Dim strpParms As String = ""
        strpParms &= companyId
        strpParms &= ",'" & blNo.Replace("'", "''") & "'"

        Dim db As New DBConnect
        Dim dbr As OleDbDataReader = Nothing
        Dim dt As New DataTable
        Try
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVOICE_BY_BLNO", strpParms)
            dt.Load(dbr)
        Finally
            If dbr IsNot Nothing AndAlso Not dbr.IsClosed Then dbr.Close()
            db.CloseDB()
        End Try
        Return dt
    End Function

    ' Mirrors the routing rules already used in checkPrint() in
    ' ContainerWiseInvoiceReport.aspx.vb, including the B2B override.
    Private Function BuildInvoicePrintUrl(ByVal invoiceNo As String, ByVal serviceType As String,
                                           ByVal companyId As Integer, ByVal billTo As Integer) As String
        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerId = billTo
        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)

        If pCustomerMaster.StateCode = "0" Then
            Return "/SPJ/Commercial/Preview/ExportInvoicePrintB2B.aspx?InvoiceNo=" & invoiceNo
        End If

        Dim invNo As Long = 0
        Long.TryParse(invoiceNo, invNo)

        If invNo >= 170537 Then
            If invNo <> 0 AndAlso companyId = 1 AndAlso serviceType = "T" Then
                Return "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "R" AndAlso companyId = 1 Then
                Return "/SPJ/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "R" Then
                Return "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "O" Then
                Return "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "I" Then
                Return "/SPJ/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "E" Then
                Return "/SPJ/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "V" Then
                Return "/SPJ/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "T" Then
                Return "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            Else
                Return "/SPJ/Commercial/Preview/ExportInvoicePrintNew.aspx?InvoiceNo=" & invoiceNo
            End If
        Else
            If invNo <> 0 AndAlso companyId = 1 AndAlso serviceType = "T" Then
                Return "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "R" AndAlso companyId = 1 Then
                Return "/SPJ/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "R" Then
                Return "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "O" Then
                Return "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "I" Then
                Return "/SPJ/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & invoiceNo
            ElseIf serviceType = "T" Then
                Return "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            Else
                Return "/SPJ/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & invoiceNo
            End If
        End If
    End Function

    Private Function SanitizeFileName(ByVal name As String) As String
        Dim invalid As Char() = Path.GetInvalidFileNameChars()
        Dim sb As New StringBuilder(name)
        For Each c As Char In invalid
            sb.Replace(c, "_"c)
        Next
        Return sb.ToString()
    End Function

    ' Downloads the print page HTML, then rewrites it into a fully
    ' self-contained file - every <link rel="stylesheet"> is inlined as
    ' <style>, every <img> is inlined as a base64 data: URI - both fetched
    ' with YOUR session cookie server-side. That means the headless browser
    ' that renders the PDF never has to make an authenticated request of its
    ' own, so nothing silently fails or comes back blank.
    Private Sub SaveInvoiceAsPdf(ByVal pageUrl As String, ByVal pdfPath As String, ByVal cookies As CookieContainer)
        Dim html As String = DownloadString(pageUrl, cookies)
        html = MakeHtmlSelfContained(html, New Uri(pageUrl), cookies)

        Dim tempFolder As String = Path.Combine(Path.GetTempPath(), "InvoicePdfTemp")
        Directory.CreateDirectory(tempFolder)
        Dim tempHtmlPath As String = Path.Combine(tempFolder, Guid.NewGuid().ToString() & ".html")
        File.WriteAllText(tempHtmlPath, html, Encoding.UTF8)

        Try
            Dim browserExe As String = GetHeadlessBrowserPath()
            Dim psi As New ProcessStartInfo()
            psi.FileName = browserExe
            ' "=old" headless mode is required here: in the newer default
            ' headless mode, --print-to-pdf-no-header is silently ignored and
            ' the browser's own date/URL/page-number header-footer shows up
            ' on every page.
            psi.Arguments = "--headless=old --disable-gpu --print-to-pdf-no-header --print-to-pdf=""" & pdfPath & """ """ &
                             New Uri(tempHtmlPath).AbsoluteUri & """"
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True

            Using proc As Process = Process.Start(psi)
                If Not proc.WaitForExit(30000) Then
                    proc.Kill()
                    Throw New Exception("Timed out converting invoice to PDF.")
                End If
            End Using

            If Not File.Exists(pdfPath) Then
                Throw New Exception("PDF file was not created by the browser.")
            End If
        Finally
            Try
                File.Delete(tempHtmlPath)
            Catch
            End Try
        End Try
    End Sub

    Private Function BuildCookieContainer() As CookieContainer
        Dim cc As New CookieContainer()
        For Each cookieName As String In Request.Cookies.AllKeys
            Dim c As HttpCookie = Request.Cookies(cookieName)
            cc.Add(New Uri(Request.Url.GetLeftPart(UriPartial.Authority)), New Cookie(c.Name, c.Value))
        Next
        Return cc
    End Function

    Private Function DownloadString(ByVal url As String, ByVal cookies As CookieContainer) As String
        Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        req.Method = "GET"
        req.CookieContainer = cookies
        Using resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(resp.GetResponseStream(), Encoding.UTF8)
                Return reader.ReadToEnd()
            End Using
        End Using
    End Function

    Private Function DownloadBytes(ByVal url As String, ByVal cookies As CookieContainer) As Byte()
        Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        req.Method = "GET"
        req.CookieContainer = cookies
        Using resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Using ms As New MemoryStream()
                resp.GetResponseStream().CopyTo(ms)
                Return ms.ToArray()
            End Using
        End Using
    End Function

    Private Function MakeHtmlSelfContained(ByVal html As String, ByVal baseUri As Uri, ByVal cookies As CookieContainer) As String
        html = Regex.Replace(html, "<link[^>]+rel=[""']stylesheet[""'][^>]*>",
            Function(m) InlineStylesheet(m.Value, baseUri, cookies), RegexOptions.IgnoreCase)

        html = Regex.Replace(html, "(<img[^>]+src=[""'])([^""']+)([""'])",
            Function(m) InlineImage(m, baseUri, cookies), RegexOptions.IgnoreCase)

        Return html
    End Function

    Private Function InlineStylesheet(ByVal tag As String, ByVal baseUri As Uri, ByVal cookies As CookieContainer) As String
        Dim hrefMatch As Match = Regex.Match(tag, "href=[""']([^""']+)[""']", RegexOptions.IgnoreCase)
        If Not hrefMatch.Success Then Return tag
        Try
            Dim absoluteUrl As String = New Uri(baseUri, hrefMatch.Groups(1).Value).AbsoluteUri
            Dim css As String = DownloadString(absoluteUrl, cookies)
            Return "<style>" & css & "</style>"
        Catch
            ' Could not fetch it - leave the original tag rather than fail the whole invoice
            Return tag
        End Try
    End Function

    Private Function InlineImage(ByVal m As Match, ByVal baseUri As Uri, ByVal cookies As CookieContainer) As String
        Dim srcValue As String = m.Groups(2).Value
        If srcValue.StartsWith("data:", StringComparison.OrdinalIgnoreCase) Then Return m.Value
        Try
            Dim absoluteUrl As String = New Uri(baseUri, srcValue).AbsoluteUri
            Dim bytes As Byte() = DownloadBytes(absoluteUrl, cookies)
            Dim mime As String = GetMimeType(absoluteUrl)
            Dim b64 As String = Convert.ToBase64String(bytes)
            Return m.Groups(1).Value & "data:" & mime & ";base64," & b64 & m.Groups(3).Value
        Catch
            Return m.Value
        End Try
    End Function

    Private Function GetMimeType(ByVal url As String) As String
        Dim ext As String = Path.GetExtension(New Uri(url).AbsolutePath).ToLower()
        Select Case ext
            Case ".png" : Return "image/png"
            Case ".jpg", ".jpeg" : Return "image/jpeg"
            Case ".gif" : Return "image/gif"
            Case ".svg" : Return "image/svg+xml"
            Case ".bmp" : Return "image/bmp"
            Case Else : Return "application/octet-stream"
        End Select
    End Function

    Private Function GetHeadlessBrowserPath() As String
        Dim configured As String = ConfigurationManager.AppSettings("HeadlessBrowserPath")
        If Not String.IsNullOrEmpty(configured) AndAlso File.Exists(configured) Then
            Return configured
        End If

        Dim candidates As String() = {
            "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            "C:\Program Files\Microsoft\Edge\Application\msedge.exe",
            "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
            "C:\Program Files\Google\Chrome\Application\chrome.exe"
        }
        For Each candidatePath As String In candidates
            If File.Exists(candidatePath) Then Return candidatePath
        Next

        Throw New Exception("Could not find msedge.exe or chrome.exe on this server. Add key 'HeadlessBrowserPath' in web.config pointing to the browser .exe.")
    End Function

End Class
