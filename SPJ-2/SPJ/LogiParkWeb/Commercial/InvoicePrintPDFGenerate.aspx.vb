Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports System.Net.Mail

Partial Class Commercial_InvoicePrintPDFGenerate
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Dim strinvno As String = ""
    Dim MainStrInvNo As String = ""
    Dim TempStrInvNo As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvInvoiceDetails.DataSource = Nothing
            gvInvoiceDetails.DataBind()
            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            ListControlDataBind()
        End If
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            Dim pCustomerMaster As New CustomerMaster
            lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
            lstCustomer.DataTextField = "CustomerName"
            lstCustomer.DataValueField = "CustomerId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0


            Dim pCompanyMaster As New CompanyMaster
            lstCompany.DataSource = CompanyMaster.ReturnCompanyMasterList(pCompanyMaster)
            lstCompany.DataTextField = "CompanyName"
            lstCompany.DataValueField = "CompanyId"
            lstCompany.DataBind()
            lstCompany.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCompany.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Sub Permission(ByVal P As String)
        Dim PMI As New MenuItemMaster
        PMI.Url = P
        MenuItemMaster.ReturnMenuItemMasterByURL(PMI)
        Session.Item("Title") = PMI.Title
        Dim pJMI As New JobMenuItems
        pJMI.JobId = Session.Item("JobId")
        pJMI.MenuId = PMI.MenuId
        JobMenuItems.ReturnJobMenuItems(pJMI)

        Session.Item("Add") = pJMI.AddPermit
        Session.Item("Edit") = pJMI.EditPermit
        Session.Item("Search") = pJMI.SearchPermit
        Session.Item("Delete") = pJMI.DeletePermit
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvInvoiceDetails.DataSource = Nothing
        gvInvoiceDetails.DataBind()
        tblReport.Visible = False

        If textFromDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstCustomer.SelectedValue & ""
        strpParms &= "," & lstCompany.SelectedValue & ""
        strpParms &= ",'" & txtFromRange.Text & "'"
        strpParms &= ",'" & txtToRange.Text & "'"
        strpParms &= ",'" & lstServiceType.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INVOICE_PRINT_PDF", strpParms)
        gvInvoiceDetails.DataSource = dbr
        gvInvoiceDetails.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub gvInvoiceDetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
        End If
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Invoice Report.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            strb.Append(lblScreenTitle.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            strb.Append(lblReport.Text & " : ")
            strb.Append(lblReportDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = "Sr No" & strComa & "Invoice Ref No" & strComa & "Invoice Date" & strComa & _
                          "Booking No" & strComa & "Booking Date" & strComa & "Amount" & strComa & "Tax Amount" & strComa & "Total Amount" & strComa & "Customer" & strComa & "Service Type"
            strb.Append(strContHeader & vbCrLf)
            Dim i As Integer = 0
            If gvInvoiceDetails.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceDetails.Rows
                    i = i + 1
                    For c As Integer = 0 To r.Cells.Count - 1

                        Dim Invoice = DirectCast(r.FindControl("hdnInvoiceRefNo"), HiddenField)
                        If c = 0 Then
                            strb.Append(i & strComa)

                        ElseIf c = 2 Then
                            strb.Append((Invoice.Value).Replace(",", "").Replace("&", " and ") & strComa)

                        ElseIf c <> 0 And c <> 1 And c <> 2 Then
                            If r.Cells(c).Text.Trim.ToString <> Nothing Then
                                strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                            Else
                                strb.Append(" " & strComa)
                            End If
                        End If
                    Next
                    strb.Append(vbCrLf)
                Next
            End If
            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception
        End Try
    End Sub
    'Public Shared Sub CreateWorkBook(ByVal cList As Object, ByVal wbName As String, ByVal CellWidth As Integer)
    '    Dim attachment As String = "attachment; filename=""" & wbName & ".xls"""
    '    HttpContext.Current.Response.ClearContent()
    '    HttpContext.Current.Response.AddHeader("content-disposition", attachment)
    '    HttpContext.Current.Response.ContentType = "application/ms-excel"
    '    Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
    '    sw.WriteLine("<?xml version=""1.0""?>")
    '    sw.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
    '    sw.WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
    '    sw.WriteLine("xmlns:o=""urn:schemas-microsoft-com:office:office""")
    '    sw.WriteLine("xmlns:x=""urn:schemas-microsoft-com:office:excel""")
    '    sw.WriteLine("xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
    '    sw.WriteLine("xmlns:html=""http://www.w3.org/TR/REC-html40"">")
    '    sw.WriteLine("<DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">")
    '    sw.WriteLine("<LastAuthor>Try Not Catch</LastAuthor>")
    '    sw.WriteLine("<Created>2010-05-15T19:14:19Z</Created>")
    '    sw.WriteLine("<Version>11.9999</Version>")
    '    sw.WriteLine("</DocumentProperties>")
    '    sw.WriteLine("<ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">")
    '    sw.WriteLine("<WindowHeight>9210</WindowHeight>")
    '    sw.WriteLine("<WindowWidth>19035</WindowWidth>")
    '    sw.WriteLine("<WindowTopX>0</WindowTopX>")
    '    sw.WriteLine("<WindowTopY>90</WindowTopY>")
    '    sw.WriteLine("<ProtectStructure>False</ProtectStructure>")
    '    sw.WriteLine("<ProtectWindows>False</ProtectWindows>")
    '    sw.WriteLine("</ExcelWorkbook>")
    '    sw.WriteLine("<Styles>")
    '    sw.WriteLine("<Style ss:ID=""Default"" ss:Name=""Normal"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom""/>")
    '    sw.WriteLine("<Borders/>")
    '    sw.WriteLine("<Font/>")
    '    sw.WriteLine("<Interior/>")
    '    sw.WriteLine("<NumberFormat/>")
    '    sw.WriteLine("<Protection/>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s22"">")
    '    sw.WriteLine("<Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("<Font ss:Bold=""1""/>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s23"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s24"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("<Font ss:Color=""#FFFFFF""/>")
    '    sw.WriteLine("<Interior ss:Color=""#191970"" ss:Pattern=""Solid""/>") 'set header colour here
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("</Styles>")
    '    For Each gView As GridView In cList
    '        'Try
    '        '    If gView.ID.ToString = "gvsummary" Then
    '        '        CreateWorkSheet("Summary", sw, gView, CellWidth)
    '        '    ElseIf gView.ID.ToString = "gvExport" Then
    '        '        'gView.ID =
    '        '        CreateWorkSheet("20", sw, gView, CellWidth)
    '        '    ElseIf gView.ID.ToString = "gvDomestic" Then
    '        '        CreateWorkSheet("B/I 20", sw, gView, CellWidth)
    '        '        ' gView.ID = "B/I 20"
    '        '    ElseIf gView.ID.ToString = "gvImport" Then
    '        '        CreateWorkSheet("40", sw, gView, CellWidth)
    '        '        ' gView.ID = "40"
    '        '    ElseIf gView.ID.ToString = "GVI40" Then
    '        '        'gView.ID = "B/I 40"
    '        '        CreateWorkSheet("B/I 40", sw, gView, CellWidth)
    '        '    End If


    '        'Catch ex As Exception
    '        'End Try
    '        CreateWorkSheet(gView.ID.ToString, sw, gView, CellWidth)
    '    Next
    '    sw.WriteLine("</Workbook>")
    '    HttpContext.Current.Response.Write(sw.ToString())
    '    HttpContext.Current.Response.End()
    'End Sub
    'Private Shared Sub CreateWorkSheet(ByVal wsName As String, ByVal sw As System.IO.StringWriter, ByVal gv As GridView, ByVal cellwidth As Integer)
    '    If IsNothing(gv.HeaderRow) = False Then
    '        If wsName = "gvtripPendencyList" Then
    '            wsName = "SOB Pending"
    '            'ElseIf wsName = "GVPVT" Then
    '            '    wsName = "PVT"
    '            'ElseIf wsName = "gvsummary" Then
    '            '    wsName = "Summary"
    '            'ElseIf wsName = "gvDomestic" Then
    '            '    wsName = "Idel20"
    '            'ElseIf wsName = "gvImport" Then
    '            '    wsName = "40"
    '            'ElseIf wsName = "GVI40" Then
    '            '    wsName = "Idel40"
    '        End If

    '        sw.WriteLine("<Worksheet ss:Name=""" & wsName & """>")
    '        Dim cCount As Integer = gv.HeaderRow.Cells.Count
    '        Dim rCount As Long = gv.Rows.Count + 1
    '        sw.WriteLine("<Table ss:ExpandedColumnCount=""" & cCount & """ ss:ExpandedRowCount=""" & rCount & """ x:FullColumns=""1""")
    '        sw.WriteLine("x:FullRows=""1"">")
    '        For i As Integer = (cCount - cCount) To (cCount - 1)
    '            sw.WriteLine("<Column ss:AutoFitWidth=""1"" ss:Width=""" & cellwidth & """/>")
    '        Next

    '        GridRowIterate(gv, sw)
    '        sw.WriteLine("</Table>")
    '        sw.WriteLine("<WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")

    '        sw.WriteLine("<Selected/>")
    '        sw.WriteLine("<DoNotDisplayGridlines/>")

    '        sw.WriteLine("<ProtectObjects>False</ProtectObjects>")
    '        sw.WriteLine("<ProtectScenarios>False</ProtectScenarios>")

    '        sw.WriteLine("</WorksheetOptions>")
    '        sw.WriteLine("</Worksheet>")
    '    End If
    'End Sub
    'Private Shared Sub GridRowIterate(ByVal gv As GridView, ByVal sw As System.IO.StringWriter)
    '    sw.WriteLine("<Row>")

    '    For Each tc As TableCell In gv.HeaderRow.Cells
    'Dim tcText As String = tc.Text

    'Dim tcWidth As String = gv.Width.Value
    'Dim dType As String = "String"

    '        If IsNumeric(tcText) = True Then

    '            dType = "Number"

    '        End If
    '        sw.WriteLine("<Cell ss:StyleID=""s24""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

    '    Next
    '    sw.WriteLine("</Row>")

    '    For Each gr As GridViewRow In gv.Rows
    '        sw.WriteLine("<Row>")

    '        For Each gc As TableCell In gr.Cells
    'Dim gcText As String = GC.Text
    'Dim dType As String = "String"

    '            If IsNumeric(gcText) = True Then

    '                dType = "Number"
    '                gcText = CDbl(gcText)

    '            End If
    '            sw.WriteLine("<Cell ss:StyleID=""s23""><Data ss:Type=""" & dType & """>" & gcText & "</Data></Cell>")

    '        Next
    '        sw.WriteLine("</Row>")
    '    Next

    'End Sub



    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvInvoiceDetails.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                End If
            Next
        End If

    End Sub

    Protected Sub btnPDF_Click(sender As Object, e As System.EventArgs) Handles btnPDF.Click
        Dim FileToDelete As String = "D:\software\JSB\Invoice\Required\"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        For Each row As GridViewRow In gvInvoiceDetails.Rows

            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnInvoiceNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnInvoiceNo"), HiddenField)
                    Dim pInvoice As New ImpInvoice
                    pInvoice.TerminalId = Session.Item("LoginTerminal")
                    pInvoice.InvoiceNo = hdnInvoiceNo.Value
                    ImpInvoice.ReturnImpInvoiceByInvoiceNo(pInvoice)
                    strinvno = pInvoice.InvoiceRefNo
                    strinvno = strinvno.Replace("/", "-")
                    HtmlToPdf("http://115.124.127.54/JSB/(S(jb4qvvzkwz2j0wexaoafezh4))/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value, "D:\\Software\JSB\Invoice\Required\" & strinvno & ".pdf")
                    TempStrInvNo = "D:\software\JSB\Invoice\Required\" & strinvno & ".pdf"
                    If MainStrInvNo = "" Then
                        MainStrInvNo = TempStrInvNo
                    Else
                        MainStrInvNo = MainStrInvNo & "," & TempStrInvNo
                    End If
                    TempStrInvNo = ""
                End If
            End If

        Next



        If MainStrInvNo <> "" Then

            Dim xMailSetup As String = ""
            Dim con As New OleDbConnection
            Dim strConnectionString As String = ""
            strConnectionString = "Provider=MSDAORA;Data Source=115.124.127.54;Persist Security Info=True;Password=spj;User ID=spj"
            con = New OleDbConnection(strConnectionString)
            Dim ada As OleDbDataAdapter = New OleDbDataAdapter
            Dim ada1 As OleDbDataAdapter = New OleDbDataAdapter
            Dim CMD1 As String = ""
            Dim adamailconfig As OleDbDataAdapter
            Dim cmdmailconfig As String
            cmdmailconfig = "SELECT FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=1"
            adamailconfig = New OleDbDataAdapter(cmdmailconfig, con)
            Dim dsmailconfig As New DataSet
            adamailconfig.Fill(dsmailconfig)
            Dim adamailsetup As OleDbDataAdapter
            Dim cmdmailsetup As String
            cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=31.1 AND TERMINAL_ID=1"
            adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
            Dim dsmailsetup As New DataSet
            adamailsetup.Fill(dsmailsetup)
            xMailSetup = " Dear User,"
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"
            xMailSetup &= "Please find the attachment of Invoices Which you request for PDF."
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"

            xMailSetup &= "Thanks & Regards " & "<br>"
            xMailSetup &= " JSB ACCOUNTS TEAM "

            Dim pStr As String = ""
            Dim SUBJECT As String = "Requested Invoices Attached"
            pStr = sendMailToCcBccWithAttachmentExcel("vrohit248@gmail.com", MainStrInvNo, "vrohit248@gmail.com", "rohit@elogisol.in,rohit@elogisol.in,vrohit248@gmail.com,vrohit248@gmail.com,vrohit248@gmail.com", "rohit@elogisol.in,lalit@elogisol.in", SUBJECT, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "01!@IN18", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            If pStr = Nothing Then
                Label1.Text = "Mail Sent "
            Else
                Label1.Text = "Mail Sent fail "
            End If
        End If

    End Sub

    Public Shared Function sendMailToCcBccWithAttachmentExcel(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String

        Dim AttachmentCount As Integer = 0
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If CCIds.Length > 0 Then
                objMM.CC.Add(CCIds)
                ' objMM.Attachments.Add("D:\New.text")
                Dim arrFileName As String() = fromName.Split(",")

                For i = 0 To arrFileName.Length - 1
                    If arrFileName(i) <> "" Then
                        For j As Integer = i + 1 To arrFileName.Length - 1
                            If arrFileName(j) <> "" Then
                                If arrFileName(i) = arrFileName(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrFileName(i) <> "" Then
                        If unique Then
                            Try

                                objMM.Attachments.Add(New Attachment(arrFileName(i)))
                                AttachmentCount = AttachmentCount + 1
                            Catch ex As Exception

                            End Try
                        Else
                            unique = True
                        End If
                    End If
                Next

            End If
            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port

            Try
                sm.EnableSsl = True
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                If AttachmentCount > 0 Then
                    sm.Send(objMM)
                    sm = Nothing
                End If
            Catch ex As Exception
                sm.EnableSsl = False
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                sm.Send(objMM)
                sm = Nothing
            End Try

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Private Sub HtmlToPdf(ByVal website As String, ByVal destinationFile As String)
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
        startInfo.UseShellExecute = False
        startInfo.RedirectStandardOutput = True
        startInfo.RedirectStandardInput = True
        startInfo.RedirectStandardError = True
        startInfo.CreateNoWindow = True
        startInfo.FileName = "C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe"
        startInfo.Arguments = website & " " & destinationFile
        Dim myProcess As Process = Process.Start(startInfo)
        myProcess.WaitForExit()
        myProcess.Close()
        Response.Clear()

        'Response.AddHeader("content-disposition", "attachment;filename=" & strinvno & ".pdf")
        'Response.ContentType = "application/pdf"
        'Response.WriteFile(destinationFile)
        'Response.[End]()
    End Sub

End Class
