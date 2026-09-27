Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports System.Net.Mail
Partial Class Reports_CustomerLedger
    Inherits System.Web.UI.Page
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim intCounter As Long = 0
    Dim receipt As Long = 0
    Dim TotalDr As Double = 0.0
    Dim TotalCr As Double = 0.0
    Dim TotalAdj As Double = 0.0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0

    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TotalDr += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DR"))
            TotalCr += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CR"))
            TotalAdj += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_CR"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 4
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(1).Text = Math.Round(TotalDr, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(TotalCr, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(TotalAdj, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Text = ""
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            'e.Row.Cells(14).Visible = False
            'e.Row.Cells(15).Visible = False
            Total()
        End If
        'Dim A As Double = 0.0
        'If TotalCr > TotalDr Then
        '    A = TotalCr - TotalDr
        '    lblTotalbalanceAmt.Text = NumberToWord.AmtInWord(Math.Round(A, 2))
        '    lblTotalbalanceAmt.Text &= " Cr."
        'Else
        '    A = TotalDr - TotalCr
        '    lblTotalbalanceAmt.Text = NumberToWord.AmtInWord(Math.Round(A, 2))
        '    lblTotalbalanceAmt.Text &= " Dr."
        'End If

    End Sub
    Sub Total()
        Dim index As Integer = gvInvoiceReport.Rows.Count
        Dim row As New GridViewRow(1, 0, DataControlRowType.Footer, DataControlRowState.Normal)
        Dim cell As New TableCell()
        cell.Text = "Balance Amount"
        cell.Font.Bold = True
        cell.HorizontalAlign = HorizontalAlign.Right
        row.Cells.Add(cell)
        gvInvoiceReport.Controls(0).Controls.Add(row)
        cell.ColumnSpan = 4
        Dim cell2 As New TableCell()
        Try
            If TotalCr > TotalDr Then
                cell2.Text = Math.Round(TotalCr - TotalDr, 2)
            Else
                cell2.Text = Math.Round(TotalDr - TotalCr, 2)
            End If
        Catch ex As Exception
            cell2.Text = 0
        End Try

        ' cell2.Text = Math.Round(TotalCr - TotalDr, 2)
        cell2.HorizontalAlign = HorizontalAlign.Right
        cell2.Font.Bold = True
        row.Cells.Add(cell2)

    End Sub

    Sub ListControlDataBind()
        Dim pCU As New ExtCustomerMaster
        lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterList(pCU)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Add(New ListItem("ALL", "0"))
        lstCustomerName.SelectedValue = 0
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
        If lstCustomerName.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select a Customer")
            Functions.ControlFocus(lstCustomerName)
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

        Dim strpParms As String = ""
        strpParms &= Session.Item("CompanyId")
        strpParms &= "," & lstCustomerName.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUSTOMER_LEDGER_PUR", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        End If
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True
    End Sub
    Protected Sub OnClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Dim strpParms As String = ""
        strpParms = lnk.CommandArgument
        HdnReceiptNO.Value = lnk.CommandArgument
        LblReceiptno.Text = lnk.CommandArgument
        'strpParms = lstCustomerName.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_DETAILS_PUR", strpParms)
        gridviewVehicleDtls.DataSource = dbr
        gridviewVehicleDtls.DataBind()
        gridviewVehicleDtls.Visible = True
        'Dim message As String = lnk.Text
        Dim message As String = lstCustomerName.SelectedItem.Text

        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "');", True)

        BtnCancelDetails.Enabled = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '  ListControlDataBind()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("Home.aspx")
    End Sub
    Sub SaveContDetails(ByVal sender As Object, ByVal e As System.EventArgs)
        If TextRemark.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please enter remark or reason for cancel the payment.")
            Functions.ControlFocus(TextRemark)
            Return
        End If
        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "'WHERE RECEIPT_NO=" & Convert.ToInt32(receipt), con)
        cmd.ExecuteNonQuery()
        'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "', CR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(receipt), con)
        'cmd.ExecuteNonQuery()
        'Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(HdnReceiptNO.Value), con)
        'cmd1.ExecuteNonQuery()
        'Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET PAYMENT_STATUS='P' WHERE INVOICE_NO IN (SELECT INVOICE_NO FROM FINCANCE_DETAILS WHERE RECEIPT_NO=" & Convert.ToInt32(HdnReceiptNO.Value) & ")", con)
        'cmd2.ExecuteNonQuery()
        con.Close()
    End Sub
    'Protected Sub BtnCancelDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelDetails.Click
    '    con = New OleDbConnection(cs)
    '    con.Open()
    '    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET CR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(HdnReceiptNO.Value), con)
    '    cmd.ExecuteNonQuery()
    '    Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(HdnReceiptNO.Value), con)
    '    cmd1.ExecuteNonQuery()
    '    Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET PAYMENT_STATUS='P' WHERE INVOICE_NO IN (SELECT INVOICE_NO FROM FINCANCE_DETAILS WHERE RECEIPT_NO=" & Convert.ToInt32(HdnReceiptNO.Value) & ")", con)
    '    cmd2.ExecuteNonQuery()
    '    con.Close()
    'End Sub
    'Protected Sub BtnCancelDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelDetails.Click
    '    'If LblUpdateRemark.Text = "" Then
    '    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please enter remark or reason for cancel the payment.")
    '    '    Functions.ControlFocus(TextRemark)
    '    '    Return
    '    'End If
    '    con = New OleDbConnection(cs)
    '    con.Open()
    '    'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "' WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
    '    'cmd.ExecuteNonQuery()

    '    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET DR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
    '    cmd.ExecuteNonQuery()
    '    Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE PD_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
    '    cmd1.ExecuteNonQuery()
    '    Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING SET PAYMENT_STATUS='P' WHERE COST_ID IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
    '    cmd2.ExecuteNonQuery()
    '    con.Close()
    'End Sub
    Protected Sub AspPopupExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AspPopupExcel.Click
        myGridViews(myN) = gridviewVehicleDtls
        ' myN += 1
        CreateWorkBook(myGridViews, "Payment Details", 80)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Response.Redirect("~/Commercial/Preview/InvoiceIssueGst.aspx?ReceiptNo=" & LblReceiptno.Text)
    End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Try
    '        Dim strComa = ","
    '        Dim strFileName As String = "CustomerLedgerReport.csv"
    '        Dim attachment As String = "attachment; filename=" & strFileName
    '        Dim strb As New StringBuilder()
    '        Response.Clear()
    '        Response.ClearHeaders()
    '        Response.ClearContent()
    '        Response.AddHeader("content-disposition", attachment)
    '        Response.ContentType = "text/csv"
    '        Response.AddHeader("Pragma", "public")
    '        strb.Append(lblScreenTitle.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)
    '        strb.Append("As On Date :- " & Today.Day & "/" & Today.Month & "/" & Today.Year & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)
    '        Dim strContHeader As String = Nothing
    '        Dim strSummaryHeader As String = Nothing
    '        strContHeader = "Sr." & strComa & "Customer Name" & strComa & "Customer Type" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Payment Mode" & strComa & "Instrument No" & strComa & _
    '             "Instrument Date" & strComa & "Receipt No" & strComa & "CR Amount(INR)" & strComa & "DR Amount(INR)" & strComa & "Remarks"
    '        strb.Append(strContHeader & vbCrLf)

    '        If gvInvoiceReport.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvInvoiceReport.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                        strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ") & strComa)
    '                    Else
    '                        strb.Append(" " & strComa)
    '                    End If
    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If

    '        Response.Write(strb.ToString)
    '        Response.Flush()
    '        Response.End()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Dim rowSBCrAmount As Double = 0.0
    Dim rowSBDrAmount As Double = 0.0

    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    intCounter = intCounter + 1
        '    e.Row.Cells(0).Text = intCounter
        '    rowSBCrAmount = rowSBCrAmount + Convert.ToDouble(e.Row.Cells(9).Text)
        '    rowSBDrAmount = rowSBDrAmount + Convert.ToDouble(e.Row.Cells(10).Text)
        'ElseIf e.Row.RowType = DataControlRowType.Footer Then
        '    e.Row.Cells(0).ColumnSpan = 9
        '    e.Row.Cells(0).Text = "Total"
        '    e.Row.Cells(0).Font.Bold = True
        '    e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

        '    e.Row.Cells(1).Text = Math.Round(rowSBCrAmount, 2)
        '    e.Row.Cells(1).Font.Bold = True
        '    e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

        '    e.Row.Cells(2).Text = Math.Round(rowSBDrAmount, 2)
        '    e.Row.Cells(2).Font.Bold = True
        '    e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
        '    e.Row.Cells(3).Text = "Balance:" & Math.Round((rowSBDrAmount - rowSBCrAmount), 2)
        '    e.Row.Cells(3).Font.Bold = True
        '    e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
        '    'e.Row.Cells(3).Visible = False
        '    e.Row.Cells(4).Visible = False
        '    e.Row.Cells(5).Visible = False
        '    e.Row.Cells(6).Visible = False
        '    e.Row.Cells(7).Visible = False
        '    e.Row.Cells(8).Visible = False
        '    e.Row.Cells(9).Visible = False
        '    e.Row.Cells(10).Visible = False
        '    e.Row.Cells(11).Visible = False
        'End If
        'Dim bal As Double = rowSBDrAmount - rowSBCrAmount
        'lblTotalbalanceAmt.Text = "Total In Words :     " & NumberToWord.AmtInWord(bal)
    End Sub
    Protected Sub gvBookingSummary_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(3).Text = "Opening Balance" Then
                e.Row.Font.Bold = True
                'e.Row.BackColor = Drawing.Color.Yellow
            End If
            If e.Row.Cells(3).Text = "Closing Balance" Then
                'e.Row.BackColor = Drawing.Color.GreenYellow
                e.Row.Font.Bold = True
            End If
        End If
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvInvoiceReport
        ' myN += 1
        CreateWorkBook(myGridViews, "PUCHASE CUSTOMER LEDGER", 80)

    End Sub
    Public Shared Sub CreateWorkBook(ByVal cList As Object, ByVal wbName As String, ByVal CellWidth As Integer)
        Dim attachment As String = "attachment; filename=""" & wbName & ".xls"""
        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.AddHeader("content-disposition", attachment)
        HttpContext.Current.Response.ContentType = "application/ms-excel"
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
        sw.WriteLine("<?xml version=""1.0""?>")
        sw.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
        sw.WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
        sw.WriteLine("xmlns:o=""urn:schemas-microsoft-com:office:office""")
        sw.WriteLine("xmlns:x=""urn:schemas-microsoft-com:office:excel""")
        sw.WriteLine("xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
        sw.WriteLine("xmlns:html=""http://www.w3.org/TR/REC-html40"">")
        sw.WriteLine("<DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">")
        sw.WriteLine("<LastAuthor>Try Not Catch</LastAuthor>")
        sw.WriteLine("<Created>2010-05-15T19:14:19Z</Created>")
        sw.WriteLine("<Version>11.9999</Version>")
        sw.WriteLine("</DocumentProperties>")
        sw.WriteLine("<ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">")
        sw.WriteLine("<WindowHeight>9210</WindowHeight>")
        sw.WriteLine("<WindowWidth>19035</WindowWidth>")
        sw.WriteLine("<WindowTopX>0</WindowTopX>")
        sw.WriteLine("<WindowTopY>90</WindowTopY>")
        sw.WriteLine("<ProtectStructure>False</ProtectStructure>")
        sw.WriteLine("<ProtectWindows>False</ProtectWindows>")
        sw.WriteLine("</ExcelWorkbook>")
        sw.WriteLine("<Styles>")
        sw.WriteLine("<Style ss:ID=""Default"" ss:Name=""Normal"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom""/>")
        sw.WriteLine("<Borders/>")
        sw.WriteLine("<Font/>")
        sw.WriteLine("<Interior/>")
        sw.WriteLine("<NumberFormat/>")
        sw.WriteLine("<Protection/>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s22"">")
        sw.WriteLine("<Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("<Font ss:Bold=""1""/>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s23"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s24"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("<Font ss:Color=""#FFFFFF""/>")
        sw.WriteLine("<Interior ss:Color=""#191970"" ss:Pattern=""Solid""/>") 'set header colour here
        sw.WriteLine("</Style>")
        sw.WriteLine("</Styles>")
        For Each gView As GridView In cList
            'Try
            '    If gView.ID.ToString = "gvsummary" Then
            '        CreateWorkSheet("Summary", sw, gView, CellWidth)
            '    ElseIf gView.ID.ToString = "gvExport" Then
            '        'gView.ID =
            '        CreateWorkSheet("20", sw, gView, CellWidth)
            '    ElseIf gView.ID.ToString = "gvDomestic" Then
            '        CreateWorkSheet("B/I 20", sw, gView, CellWidth)
            '        ' gView.ID = "B/I 20"
            '    ElseIf gView.ID.ToString = "gvImport" Then
            '        CreateWorkSheet("40", sw, gView, CellWidth)
            '        ' gView.ID = "40"
            '    ElseIf gView.ID.ToString = "GVI40" Then
            '        'gView.ID = "B/I 40"
            '        CreateWorkSheet("B/I 40", sw, gView, CellWidth)
            '    End If


            'Catch ex As Exception
            'End Try
            CreateWorkSheet(gView.ID.ToString, sw, gView, CellWidth)
        Next
        sw.WriteLine("</Workbook>")
        HttpContext.Current.Response.Write(sw.ToString())
        HttpContext.Current.Response.End()
    End Sub
    Private Shared Sub CreateWorkSheet(ByVal wsName As String, ByVal sw As System.IO.StringWriter, ByVal gv As GridView, ByVal cellwidth As Integer)
        If IsNothing(gv.HeaderRow) = False Then
            If wsName = "gvInvoiceReport" Then
                wsName = "Outstanding"
            Else
                wsName = "Payment Details"
                'ElseIf wsName = "GVPVT" Then
                '    wsName = "PVT"
                'ElseIf wsName = "gvsummary" Then
                '    wsName = "Summary"
                'ElseIf wsName = "gvDomestic" Then
                '    wsName = "Idel20"
                'ElseIf wsName = "gvImport" Then
                '    wsName = "40"
                'ElseIf wsName = "GVI40" Then
                '    wsName = "Idel40"
            End If

            sw.WriteLine("<Worksheet ss:Name=""" & wsName & """>")
            Dim cCount As Integer = gv.HeaderRow.Cells.Count
            Dim rCount As Long = gv.Rows.Count + 1
            sw.WriteLine("<Table ss:ExpandedColumnCount=""" & cCount & """ ss:ExpandedRowCount=""" & rCount & """ x:FullColumns=""1""")
            sw.WriteLine("x:FullRows=""1"">")
            For i As Integer = (cCount - cCount) To (cCount - 1)
                sw.WriteLine("<Column ss:AutoFitWidth=""1"" ss:Width=""" & cellwidth & """/>")
            Next

            GridRowIterate(gv, sw)
            sw.WriteLine("</Table>")
            sw.WriteLine("<WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")

            sw.WriteLine("<Selected/>")
            sw.WriteLine("<DoNotDisplayGridlines/>")

            sw.WriteLine("<ProtectObjects>False</ProtectObjects>")
            sw.WriteLine("<ProtectScenarios>False</ProtectScenarios>")

            sw.WriteLine("</WorksheetOptions>")
            sw.WriteLine("</Worksheet>")
        End If
    End Sub
    Private Shared Sub GridRowIterate(ByVal gv As GridView, ByVal sw As System.IO.StringWriter)
        sw.WriteLine("<Row>")

        For Each tc As TableCell In gv.HeaderRow.Cells
            Dim tcText As String = tc.Text

            Dim tcWidth As String = gv.Width.Value
            Dim dType As String = "String"

            If IsNumeric(tcText) = True Then

                dType = "Number"

            End If
            sw.WriteLine("<Cell ss:StyleID=""s24""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

        Next
        sw.WriteLine("</Row>")

        For Each gr As GridViewRow In gv.Rows
            sw.WriteLine("<Row>")

            For Each gc As TableCell In gr.Cells
                Dim gcText As String = gc.Text
                Dim dType As String = "String"

                If IsNumeric(gcText) = True Then

                    dType = "Number"
                    gcText = CDbl(gcText)

                End If
                sw.WriteLine("<Cell ss:StyleID=""s23""><Data ss:Type=""" & dType & """>" & gcText & "</Data></Cell>")

            Next
            sw.WriteLine("</Row>")
        Next

    End Sub
    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        lstCustomerName.Items.Clear()
        If lstPurchaseType.SelectedValue = "L" Or lstPurchaseType.SelectedValue = "C" Then
            Dim pTerminalMaster As New CustomerMaster
            lstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
            lstCustomerName.DataTextField = "CustomerName"
            lstCustomerName.DataValueField = "CustomerId"
            lstCustomerName.DataBind()
            lstCustomerName.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomerName.SelectedValue = 0

        ElseIf lstPurchaseType.SelectedValue = "M" Or lstPurchaseType.SelectedValue = "S" Or lstPurchaseType.SelectedValue = "T"  Then
            Dim pVendorMaster As New VendorMaster
            lstCustomerName.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
            lstCustomerName.DataTextField = "VendorName"
            lstCustomerName.DataValueField = "VendorId"
            lstCustomerName.DataBind()
            lstCustomerName.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomerName.SelectedValue = 0
        End If
    End Sub


    Protected Sub BtnCancelDetails_Click(sender As Object, e As System.EventArgs) Handles BtnCancelDetails.Click
        con = New OleDbConnection(cs)
        con.Open()
        'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "' WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        'cmd.ExecuteNonQuery()

        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET DR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        cmd.ExecuteNonQuery()
        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE PD_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING SET PAYMENT_STATUS='P' WHERE COST_ID IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
        cmd2.ExecuteNonQuery()
      '  con.Close()
  Dim cmd3 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING_NEW SET PAYMENT_STATUS='P' WHERE LINER_INV_NO in (SELECT LINER_INV_NO FROM COST_BOOKING_NEW WHERE COST_ID  IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & "))", con)
        cmd3.ExecuteNonQuery()
        con.Close()
    End Sub



    Protected Sub btnMail_Click(sender As Object, e As System.EventArgs) Handles btnMail.Click
        Dim strReceiptRefNo As String = ""
        Dim strTempReceiptRefNo As String = ""
        Dim FileToDelete As String = "C:\software\JSB\PaymentIssue\Required\"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        Dim pInvoiceReceipt As New InvoiceReceipt
        pInvoiceReceipt.TerminalId = Session.Item("LoginTerminal")
        pInvoiceReceipt.ReceiptNo = LblReceiptno.Text
        InvoiceReceipt.ReturnInvoiceReceiptByNo(pInvoiceReceipt)
        strReceiptRefNo = pInvoiceReceipt.ReceiptRefNo
        strReceiptRefNo = strReceiptRefNo.Replace("/", "-")

        HtmlToPdf("http://115.124.127.54/JSB/(S(jb4qvvzkwz2j0wexaoafezh4))/Commercial/Preview/InvoiceIssueGst.aspx?ReceiptNo=" & LblReceiptno.Text, "C:\\Software\JSB\PaymentIssue\Required\" & strReceiptRefNo & ".pdf")
        strTempReceiptRefNo = "C:\software\JSB\PaymentIssue\Required\" & strReceiptRefNo & ".pdf"


        If strReceiptRefNo <> "" Then

            Dim xMailSetup As String = ""
            Dim con As New OleDbConnection
            Dim strConnectionString As String = ""
            Dim confirmMail As New StringBuilder
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
            xMailSetup &= "Please find the attachment of Payment Advice against below purchase invoice no."
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"

            confirmMail.AppendLine("<table style='width: 100%; border-width:0px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")
            confirmMail.Append("<tr>")
            confirmMail.Append("<td>")
            confirmMail.AppendLine("<table style='width: 925px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
            confirmMail.Append("<tr style='font-family: calibri; background-color:#191970; color:white;'>")
            confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid; border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='7'>")
            confirmMail.Append("<b>Payment Advice Details</b>")
            confirmMail.Append(" </th>")
            confirmMail.Append(" </tr>")
            confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;'>")
            confirmMail.Append("<td  style='width: 25px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>S.No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Invoice No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Invoice Date</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Invoice Amount</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Dr Amount</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>TDS Amount</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td  style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Issue Amount</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append(" </tr>")

            Dim strConnectionString3, cmd3 As String
            Dim con3 As OleDbConnection
            Dim ada3 As New OleDbDataAdapter
            strConnectionString3 = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            con3 = New OleDbConnection(strConnectionString3)
            con3.Open()
            Dim dt As New DataTable()

            cmd3 = " SELECT DISTINCT CB.LINER_INV_NO INVOICE_NO, TO_CHAR(CB.LINER_INV_DATE, 'DD/MM/YYYY') INVOICE_DATE, " &
     " (SELECT ROUND(NVL(SUM(TOTAL),0),2) INVOICE_AMOUNT " &
    " FROM COST_BOOKING_DTLS WHERE COST_ID=CB.COST_ID) INVOICE_AMOUNT, 0 BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE, 0 SGST_RATE, 0 CGST_AMOUNT, 0 IGST_AMOUNT,0 SGST_AMOUNT ,    " &
     " (SELECT ROUND(NVL(SUM(TDS_AMOUNT),0),2) TDS_AMOUNT FROM COST_BOOKING_DTLS WHERE COST_ID=CB.COST_ID) TDS, round(NVL(SUM(FD.DR_AMOUNT),0),2) TA, " &
     " (SELECT ROUND(NVL(SUM(DR_TAX+DR_AMOUNT),0),2) FROM DR_ITEM_DETAILS DID WHERE DID.COST_ID=CB.COST_ID) DR_AMT " &
     " FROM PAYMENT_DETAILS PD, FINANCE_DETAILS FD, COST_BOOKING CB WHERE  PD.RECEIPT_NO=" & LblReceiptno.Text & "     " &
      "  AND CB.COST_ID=FD.INVOICE_NO  AND FD.CUSTOMER_ID=CB.BILLING_PARTY  AND FD.TRN_TYPE='P' AND PD.RECEIPT_NO=FD.RECEIPT_NO  AND TRN_VALUE=12  " &
    " GROUP BY CB.LINER_INV_NO, CB.LINER_INV_DATE, COST_ID  " &
    " UNION " &
      " SELECT 'On Account' INVOICE_NO, TO_CHAR(PD.CHEQUE_DATE, 'DD/MM/YYYY') INVOICE_DATE, 0 INVOICE_AMOUNT ,  0  BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE , 0 SGST_RATE ,0 CGST_AMOUNT,0 IGST_AMOUNT,0 SGST_AMOUNT,0 TDS, " &
      " ROUND(NVL(SUM(FD.DR_AMOUNT),0),2) TA, 0  DR_AMT  FROM FINANCE_DETAILS FD INNER JOIN PAYMENT_DETAILS PD ON FD.RECEIPT_NO=PD.RECEIPT_NO " &
     " WHERE FD.RECEIPT_NO=" & LblReceiptno.Text & "  AND FD.TRN_TYPE='T' AND FD.FNC_TYPE='P'  GROUP BY PD.CHEQUE_DATE " &
            " UNION " &
    " SELECT  'Opening Balance' INVOICE_NO,(SELECT  MAX(TO_CHAR(CHEQUE_DATE, 'DD/MM/YYYY')) FROM PAYMENT_DETAILS    " &
    " WHERE RECEIPT_NO=FD.INVOICE_NO AND PD_TYPE='P') INVOICE_DATE,  " &
     " (SELECT NVL(SUM(CR_AMOUNT),0)  FROM FINANCE_DETAILS  WHERE RECEIPT_NO=FD.INVOICE_NO AND FNC_TYPE='P' AND TRN_TYPE='V') INVOICE_AMOUNT,  " &
    " 0  BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE , 0 SGST_RATE ,0 CGST_AMOUNT,0 IGST_AMOUNT,0 SGST_AMOUNT,0 TDS,     " &
     "   ROUND(NVL(SUM(FD.DR_AMOUNT),0),2) TA, 0  DR_AMT  FROM FINANCE_DETAILS FD INNER JOIN PAYMENT_DETAILS PD ON FD.RECEIPT_NO=PD.RECEIPT_NO   " &
    " WHERE FD.TRN_TYPE='P' AND TRN_VALUE=12 AND FNC_TYPE='P' AND FD.REMARKS LIKE '%OPENING BALANCE'  " &
    " AND FD.RECEIPT_NO=" & LblReceiptno.Text & " " &
    " GROUP BY FD.RECEIPT_NO, FD.INVOICE_NO "


            dt = New DataTable()
            ada3 = New OleDbDataAdapter(cmd3, con3)
            ada3.Fill(dt)
            Dim j As Integer = 0
            Dim TotalInvoiceAmount As Double = 0
            Dim TotalDrAmt As Double = 0
            Dim TotalTDS As Double = 0
            Dim TotalIssueAmt As Double = 0
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    j = j + 1
                    confirmMail.Append("<tr style='font-family: calibri; color: #00008B;'>")
                    confirmMail.Append("<td style='width: 25px; font-size: 10pt; height: 5px'>")
                    confirmMail.Append(j)
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
                    confirmMail.Append(dt.Rows(i)("INVOICE_NO"))
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
                    confirmMail.Append(dt.Rows(i)("INVOICE_DATE"))
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px' >")
                    confirmMail.Append(dt.Rows(i)("INVOICE_AMOUNT"))
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px' >")
                    confirmMail.Append(dt.Rows(i)("DR_AMT"))
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px' >")
                    confirmMail.Append(dt.Rows(i)("TDS"))
                    confirmMail.Append(" </td>")
                    confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px' >")
                    confirmMail.Append(dt.Rows(i)("TA"))
                    confirmMail.Append(" </td>")
                    TotalInvoiceAmount = TotalInvoiceAmount + Convert.ToDouble(dt.Rows(i)("INVOICE_AMOUNT"))
                    TotalDrAmt = TotalDrAmt + Convert.ToDouble(dt.Rows(i)("DR_AMT"))
                    TotalTDS = TotalTDS + Convert.ToDouble(dt.Rows(i)("TDS"))
                    TotalIssueAmt = TotalIssueAmt + Convert.ToDouble(dt.Rows(i)("TA"))
                    confirmMail.Append(" </tr>")
                Next
            End If
            confirmMail.Append("<tr style='font-family: calibri; color: #00008B;'>")
            confirmMail.Append("<td colspan='3' align='right' style='width: 325px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("Total")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(Math.Round(TotalInvoiceAmount, 2))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(Math.Round(TotalDrAmt, 2))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(Math.Round(TotalTDS, 2))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td align='right' style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(Math.Round(TotalIssueAmt, 2))
            confirmMail.Append(" </td>")
            confirmMail.Append("</tr>")
            confirmMail.Append("</table>")
            xMailSetup &= confirmMail.ToString
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"
            xMailSetup &= "Thanks & Regards " & "<br>"
            xMailSetup &= " JSB ACCOUNTS TEAM "

            Dim pStr As String = ""
            Dim SUBJECT As String = "Payment Advice attachment of  Voucher No " & strReceiptRefNo
            pStr = Functions.sendMailToCcBccWithAttachmentExcel("vrohit248@gmail.com", strTempReceiptRefNo, "vrohit248@gmail.com", "rohit@elogisol.in,rohit@elogisol.in,vrohit248@gmail.com,vrohit248@gmail.com", "rohit@elogisol.in,lalit@elogisol.in,amit.singh@elogisol.in,amit.kumar@elogisol.in", SUBJECT, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "01!@", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            If pStr = Nothing Then
                lblErrorMessage.Text = "Mail Sent "
            Else
                lblErrorMessage.Text = "Mail Sent fail "
            End If
        End If

    End Sub

    

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

    End Sub

End Class

