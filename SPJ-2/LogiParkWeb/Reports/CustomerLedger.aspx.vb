Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
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
            e.Row.Cells(8).Visible = False
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
                cell2.Text = Math.Round(TotalAdj - TotalDr, 2)
            Else
                cell2.Text = Math.Round(TotalDr - TotalAdj, 2)
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
		strpParms &= lstCompany.SelectedValue
		strpParms &= "," & lstCustomerName.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
		strpParms &= ",'" & textToDate.Text & "'"


		Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUSTOMER_LEDGER", strpParms)
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
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_DETAILS", strpParms)
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
			ListControlDataBind()
			textFromDate.Text = "01/04/2018"
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
    Protected Sub btnsaveJo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelDetails.Click
        'If LblUpdateRemark.Text = "" Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please enter remark or reason for cancel the payment.")
        '    Functions.ControlFocus(TextRemark)
        '    Return
        'End If
        con = New OleDbConnection(cs)
        con.Open()
        'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "' WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        'cmd.ExecuteNonQuery()

        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET CR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        cmd.ExecuteNonQuery()
        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET PAYMENT_STATUS='P' WHERE INVOICE_NO IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
        cmd2.ExecuteNonQuery()
        con.Close()
    End Sub
    Protected Sub AspPopupExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AspPopupExcel.Click
        myGridViews(myN) = gridviewVehicleDtls
        ' myN += 1
        CreateWorkBook(myGridViews, "Payment Details", 80)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Response.Redirect("~/Commercial/Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & LblReceiptno.Text)
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
        CreateWorkBook(myGridViews, "CUSTOMER LEDGER", 80)

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

End Class

