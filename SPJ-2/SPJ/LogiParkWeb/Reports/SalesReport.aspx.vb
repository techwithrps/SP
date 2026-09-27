Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports System.Net.Mail
Imports OfficeOpenXml
Imports OfficeOpenXml.Table
Imports OfficeOpenXml.Style
Partial Class Reports_SalesReport
    Inherits System.Web.UI.Page
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim intCounter As Long = 0
    Dim receipt As Long = 0
    Dim TotalAmt As Double = 0.0
    Dim Rate As Double = 0.0
    Dim TaxAmt As Double = 0.0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Private Shared Function AddAutoIncrementColumn() As DataTable
        Dim myDataColumn As New DataColumn()
        myDataColumn.AllowDBNull = False
        myDataColumn.AutoIncrement = True
        myDataColumn.AutoIncrementSeed = 1
        myDataColumn.AutoIncrementStep = 1
        myDataColumn.ColumnName = "Sr. No"
        myDataColumn.DataType = System.Type.[GetType]("System.Int32")
        myDataColumn.Unique = True
        'Create a new datatable
        Dim mydt As New DataTable()
        'Add this AutoIncrement Column to a new datatable
        mydt.Columns.Add(myDataColumn)
        Return mydt
    End Function
    Public Shared Function SetColumnsOrder(ByVal table As DataTable, ByVal ParamArray columnNames As [String]()) As DataTable
        Dim columnIndex As Integer = 0
        For Each columnName As String In columnNames
            table.Columns(columnName).SetOrdinal(columnIndex)
            columnIndex += 1
        Next
        Return table
    End Function
    Private Shared Function AlterColumnNameDPI(ByVal tbl As DataTable) As DataTable
        tbl = SetColumnsOrder(tbl, {"Sr. No", "CUSTOMER_NAME", "PARTY_INV_NO", "LINE", "PORT", "INVOICE_REF_NO", "INVOICE_DATE", "RATE", "TAX_AMT", "TOTAL", "SOB", "BL_STATUS", "ISSUE_DATE", "PAYMENT_STATUS", "AGEING"})
        tbl.Columns(1).ColumnName = "Customer Name"
        tbl.Columns(2).ColumnName = "Party Invoice NO"
        tbl.Columns(3).ColumnName = "Line"
        tbl.Columns(4).ColumnName = "Port"
        tbl.Columns(5).ColumnName = "Inovice No"
        tbl.Columns(6).ColumnName = "Invoice Date"
        tbl.Columns(7).ColumnName = "Rate"
        tbl.Columns(8).ColumnName = "Tax Amount"
        tbl.Columns(9).ColumnName = "Total"
        tbl.Columns(10).ColumnName = "SOB"
        tbl.Columns(11).ColumnName = "BL Status"
        tbl.Columns(12).ColumnName = "Issue Date"
        tbl.Columns(13).ColumnName = "Payment Status"
        tbl.Columns(14).ColumnName = "Age"
        Return tbl
    End Function
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            Rate += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RATE"))
            TaxAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TAX_AMT"))
            TotalAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 7
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(1).Text = Math.Round(Rate, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(TaxAmt, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(TotalAmt, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(2).Visible = False
            'e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            'e.Row.Cells(15).Visible = False
        End If
    End Sub
    Sub ListControlDataBind()
        Dim pCU As New ExtCustomerMaster
        lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterList(pCU)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Add(New ListItem("ALL", "0"))
        lstCustomerName.SelectedValue = 0
        Dim pCompanyMaster As New CompanyMaster
        lstCompany.DataSource = CompanyMaster.ReturnCompanyMasterList(pCompanyMaster)
        lstCompany.DataTextField = "CompanyName"
        lstCompany.DataValueField = "CompanyId"
        lstCompany.DataBind()
        lstCompany.Items.Add(New ListItem("---Select---", "0"))
        lstCompany.SelectedValue = 0
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter from date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter to date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        Dim dFrm, dTo As Date
        dFrm = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        dTo = Functions.todate_ddmmyyyy(textToDate.Text, "/")
        If Date.Parse(dFrm) > Date.Parse(dTo) Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date Should not be less than From Date")
            Functions.ControlFocus(textToDate)
            Return
        End If
        lblReportDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        'Dim strpParms As String = ""
        'strpParms &= "'" & textFromDate.Text & "'"
        'strpParms &= ",'" & textToDate.Text & "'"
        'strpParms &= "," & lstCustomerName.SelectedValue
        'strpParms &= "," & lstCompany.SelectedValue & ",'" & lstPaymentStatus.SelectedValue & "','" & LstServiceType.SelectedValue & "'"
        'Dim dbr As OleDb.OleDbDataReader
        'Dim db As New DBConnect
        'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SALES_REPORT", strpParms)
        'gvInvoiceReport.DataSource = dbr
        'gvInvoiceReport.DataBind()
        'If dbr.HasRows = False Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        'End If
        'dbr.Close()
        'db.CloseDB()
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        Dim ds As New DataSet
        Dim dt As DataTable
        ds.DataSetName = "DataForExcel"
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strpParms As String = ""
        strpParms &= "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstCustomerName.SelectedValue
        strpParms &= "," & lstCompany.SelectedValue & ",'" & lstPaymentStatus.SelectedValue & "','" & LstServiceType.SelectedValue & "'"
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SALES_REPORT", strpParms)
        dt = New DataTable()
        dt = AddAutoIncrementColumn()
        dt.Load(dbr)
        gvInvoiceReport.DataSource = dt
        gvInvoiceReport.DataBind()
        dt = AlterColumnNameDPI(dt)
        ds.Tables.Add(dt)
        ds.Tables(0).TableName = "Outstanding Details"
        dbr.Close()
        db.CloseDB()
        HdnCustomerId.Value = lstCustomerName.SelectedValue
        tblReport.Visible = True
        ViewState("EXCEL") = ds
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
        End If
    End Sub
    Protected Sub OnClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Dim strpParms As String = ""
        strpParms = lnk.CommandArgument
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_SERVICE_WISE_CHARGE", strpParms)
        gridviewcontDtls.DataSource = dbr
        gridviewcontDtls.DataBind()
        gridviewcontDtls.Visible = True
        Dim message As String = lnk.Text
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("Home.aspx")
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
            strContHeader = "Sr" & strComa & "Customer Name" & strComa & "Party Invoice No" & strComa & "Line" & strComa & "Port" & strComa & "Invoice No." & strComa & "Invoice Date" & strComa & _
                          "Rate" & strComa & "Tax Amount" & strComa & "Total" & strComa & "SOB" & strComa & "BL Status" & strComa & "BL Issue Date" & strComa & "Payment Status" & strComa & "Age"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        Dim Invoice = DirectCast(r.FindControl("hdnInvoiceRefNo"), HiddenField)
                        If c = 5 Then
                            strb.Append((Invoice.Value).Replace(",", "").Replace("&", " and ") & strComa)
                        Else
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
            strb.Append(Space(4) & vbCrLf)
            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BtnSend_Click(sender As Object, e As System.EventArgs) Handles BtnSend.Click
        sendmail()
    End Sub
    Sub sendmail()
        Dim FileToDelete As String
        FileToDelete = Server.MapPath("~/OutStanding.xlsx")
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        Dim ds As New DataSet
        ds = ViewState("EXCEL")
        Dim newFile As New FileInfo(Server.MapPath("~/OutStanding.xlsx"))
        Dim excelPackage = New ExcelPackage(newFile)
        Dim excelWorksheet As ExcelWorksheet
        For Each item As DataTable In ds.Tables
            excelWorksheet = excelPackage.Workbook.Worksheets.Add(item.TableName)
            excelWorksheet.Cells("A1").Value = item.TableName
            excelWorksheet.Cells("A1").Style.Font.Bold = True
            excelWorksheet.Cells("A2").LoadFromDataTable(item, True)
        Next

        excelPackage.Save()
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
        xMailSetup = " Dear Sir,"
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Please find enclosed statement mentioning the details of the  shipment for which payment is requested."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Kindly check and arrange to release the payment at your earlist."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Thanks & Regards " & "<br>"
        xMailSetup &= " JSB ACCOUNTS TEAM "
        Dim pcus As New CustomerMaster
        pcus.CustomerId = HdnCustomerId.Value
        CustomerMaster.ReturnCustomerMaster(pcus)
        Dim tomail As String = ""
        Try
            tomail = "vrohit248@gmail.com"
            'tomail = pcus.EmailCommercial
        Catch ex As Exception
            tomail = "vrohit248@gmail.com"
        End Try
        Dim pStr As String = ""
        Dim SUBJECT As String = "Payment Request - Freight Outstanding -" & pcus.CustomerName & " - dated -" & Now.Date
        pStr = sendMailToCcBccWithAttachmentExcel("vrohit248@gmail.com", FileToDelete, tomail, "vrohit248@gmail.com,vrohit248@gmail.com", "amit.kumar@elogisol.in", SUBJECT, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "01!@INjsb18", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
        If pStr = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent")
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent fail")
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
            Dim ms As New IO.MemoryStream
            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port

            Try
                sm.EnableSsl = True
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                sm.Send(objMM)
                sm = Nothing
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
    'Public Sub ExportGridViewToExcel(ByVal gvOSdry As GridView)
    '    Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
    '    Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
    '    Dim worksheetDryCont As Microsoft.Office.Interop.Excel._Worksheet = Nothing
    '    Dim count As Integer = workbook.Worksheets.Count
    '    Dim r As Excel.Range
    '    worksheetDryCont = workbook.Sheets(1)
    '    worksheetDryCont.Name = "Outstanding Sheet"
    '    r = CType(worksheetDryCont.Columns("B:B"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("C:C"), Excel.Range)
    '    r.ColumnWidth = 15
    '    r = CType(worksheetDryCont.Columns("D:D"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("E:E"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("F:F"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("G:G"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("H:H"), Excel.Range)
    '    r.ColumnWidth = 25
    '    r = CType(worksheetDryCont.Columns("I:I"), Excel.Range)
    '    r.ColumnWidth = 22
    '    r = CType(worksheetDryCont.Columns("J:J"), Excel.Range)
    '    r.ColumnWidth = 25
    '    r = CType(worksheetDryCont.Columns("K:K"), Excel.Range)
    '    r.ColumnWidth = 25
    '    r = CType(worksheetDryCont.Columns("L:L"), Excel.Range)
    '    r.ColumnWidth = 10
    '    r = CType(worksheetDryCont.Columns("M:M"), Excel.Range)
    '    r.ColumnWidth = 15
    '    r = CType(worksheetDryCont.Columns("N:N"), Excel.Range)
    '    r.ColumnWidth = 25
    '    Dim filelocation As String
    '    filelocation = Server.MapPath("~/OutStanding.xls")

    '    For i As Integer = 0 To gvOSdry.Rows.Count - 1
    '        For j As Integer = 0 To gvOSdry.Columns.Count - 1
    '            If (i + 1) = 1 AndAlso j = 1 Then
    '                worksheetDryCont.Cells(i + 1, 1) = "Outstanding Sheet"
    '            End If
    '            If i + 1 = 2 Then
    '                worksheetDryCont.Cells(i + 1, 1) = "Sr."
    '                worksheetDryCont.Cells(i + 1, 2) = "Customer Name"
    '                worksheetDryCont.Cells(i + 1, 3) = "Party Invoice No"
    '                worksheetDryCont.Cells(i + 1, 4) = "Line"
    '                worksheetDryCont.Cells(i + 1, 5) = "Port"
    '                worksheetDryCont.Cells(i + 1, 6) = "Invoice No"
    '                worksheetDryCont.Cells(i + 1, 7) = "Invoice Date"
    '                worksheetDryCont.Cells(i + 1, 8) = "Base Amount"
    '                worksheetDryCont.Cells(i + 1, 9) = "Tax Amount"
    '                worksheetDryCont.Cells(i + 1, 10) = "Total"
    '                worksheetDryCont.Cells(i + 1, 11) = "SOB"
    '                worksheetDryCont.Cells(i + 1, 12) = "Bl Status"
    '                worksheetDryCont.Cells(i + 1, 13) = "Issue Date"
    '                worksheetDryCont.Cells(i + 1, 14) = "Payment Status"
    '                worksheetDryCont.Cells(i + 1, 15) = "Age"
    '            End If
    '            If gvOSdry.Rows(i).Cells(j).Text = "&nbsp;" Then
    '                worksheetDryCont.Cells(i + 3, j + 1) = ""
    '            Else
    '                worksheetDryCont.Cells(i + 3, j + 1) = gvOSdry.Rows(i).Cells(j).Text
    '            End If
    '        Next
    '    Next
    '    workbook.SaveAs(filelocation, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
    '            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
    '    workbook.Close(True, Type.Missing, Type.Missing)
    '    app.Quit()
    'End Sub
End Class
