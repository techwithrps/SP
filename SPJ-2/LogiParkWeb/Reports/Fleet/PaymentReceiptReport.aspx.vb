Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Fleet_PaymentReceiptReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvInvoiceReport.DataSource = Nothing
            gvInvoiceReport.DataBind()
            tblReport.Visible = False
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
        End If
    End Sub

    

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
        tblReport.Visible = False
        If txtFromDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(txtFromDate)
            Return
        End If
        If txtToDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(txtToDate)
            Return
        End If

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strpParms As String = ""
        strpParms = lstCustomerName.SelectedValue & ""
        strpParms &= "," & lstReceiverBank.SelectedValue & ""
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & LstreceiptType.SelectedValue & "'"
        '   strpParms &= "," & lstCustomerName.SelectedValue & ""
        ' strpParms &= ",'" & lstInvoiceStatus.SelectedValue & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_RECEIPT_REPORT", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Dim dblConsAmt As Double = 0
    Dim dblCargoAmt As Double = 0
    Dim dblMUMAmt As Double = 0
    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            dblConsAmt = dblConsAmt + Convert.ToDouble(e.Row.Cells(7).Text)
            dblCargoAmt = dblCargoAmt + Convert.ToDouble(e.Row.Cells(8).Text)
            dblMUMAmt = dblMUMAmt + Convert.ToDouble(e.Row.Cells(9).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).ColumnSpan = "7"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(1).Text = Math.Round(dblConsAmt, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(dblCargoAmt, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(dblMUMAmt, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvInvoiceReport
        ' myN += 1
        CreateWorkBook(myGridViews, "Payment Receipt Report", 80)

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
                wsName = "Payment Receipt Report"
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
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Sub ListControlDataBind()
        Dim pCU As New ExtCustomerMaster
        lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterList(pCU)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Add(New ListItem("ALL", "0"))
        lstCustomerName.SelectedValue = 0

        Dim pBank As New BankMaster
        lstReceiverBank.DataSource = BankMaster.ReturnBankMasterList(pBank)
        lstReceiverBank.DataTextField = "BankName"
        lstReceiverBank.DataValueField = "BankId"
        lstReceiverBank.DataBind()
        lstReceiverBank.Items.Add(New ListItem("ALL", "0"))
        lstReceiverBank.SelectedValue = 0

    End Sub
    Protected Sub AspPopupExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AspPopupExcel.Click
        myGridViews(myN) = gridviewVehicleDtls
        ' myN += 1
        CreateWorkBook(myGridViews, "Payment Details", 80)
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If LstreceiptType.SelectedValue = "I" Then
            Response.Redirect("~/Commercial/Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & LblReceiptno.Text)
        ElseIf LstreceiptType.SelectedValue = "P" Then
            Response.Redirect("~/Commercial/Preview/InvoiceIssueGst.aspx?ReceiptNo=" & LblReceiptno.Text)
        End If
    End Sub
    Protected Sub btnsaveJo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelDetails.Click
        'If LblUpdateRemark.Text = "" Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please enter remark or reason for cancel the payment.")
        '    Functions.ControlFocus(TextRemark)
        '    Return
        'End If
        con = New OleDbConnection(cs)

        'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET UPDATE_REMARK='" & TextRemark.Text.Trim & "' WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        'cmd.ExecuteNonQuery()
        If LstreceiptType.SelectedValue = "I" Then
            con.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET CR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
            cmd.ExecuteNonQuery()
            Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
            cmd1.ExecuteNonQuery()
            Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET PAYMENT_STATUS='P' WHERE INVOICE_NO IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
            cmd2.ExecuteNonQuery()
            con.Close()
        ElseIf LstreceiptType.SelectedValue = "P" Then
            con.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("UPDATE FINANCE_DETAILS SET DR_AMOUNT=0,UPDATED_BY='" & Session.Item("LoginUser") & "', UPDATED_ON=SYSDATE WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
            cmd.ExecuteNonQuery()
            Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE WHERE PD_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
            cmd1.ExecuteNonQuery()
            Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING SET PAYMENT_STATUS='P' WHERE COST_ID IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
            cmd2.ExecuteNonQuery()
  	    Dim cmd3 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING_NEW SET PAYMENT_STATUS='P' WHERE COST_ID IN (SELECT INVOICE_NO FROM FINANCE_DETAILS WHERE FNC_TYPE='P' AND RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text) & ")", con)
            cmd3.ExecuteNonQuery()
            con.Close()
        End If

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
        If LstreceiptType.SelectedValue = "I" Then
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_DETAILS", strpParms)
        ElseIf LstreceiptType.SelectedValue = "P" Then
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_DETAILS_PUR", strpParms)
        End If
        gridviewVehicleDtls.DataSource = dbr
        gridviewVehicleDtls.DataBind()
        gridviewVehicleDtls.Visible = True
        'Dim message As String = lnk.Text
        Dim message As String = lstCustomerName.SelectedItem.Text

        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "');", True)

        BtnCancelDetails.Enabled = True
    End Sub

    Protected Sub BtnUpdate_Click(sender As Object, e As System.EventArgs) Handles BtnUpdate.Click
        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE PAYMENT_DETAILS SET CHEQUE_NO='" & TextBox1.Text.Trim & "' WHERE RECEIPT_NO=" & Convert.ToInt32(LblReceiptno.Text), con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
