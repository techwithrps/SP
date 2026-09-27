Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_DebitNoteMapping
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvPaymentDetail.DataSource = Nothing
            gvPaymentDetail.DataBind()
            tblReport.Visible = False
            ' ListcontrolDataBind()
            lblScreenTitle.Text = Session.Item("Title")
            ddchkContainer.Enabled = False
        End If
    End Sub
    Protected Sub ddchkContainer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        hdnReceiptNo.Value = 0
        For Each item As System.Web.UI.WebControls.ListItem In ddchkContainer.Items
            If item.Selected = True Then
                hdnReceiptNo.Value &= ","
                hdnReceiptNo.Value &= item.Value
            End If
        Next
        hdnReceiptNo.Value = hdnReceiptNo.Value
    End Sub


    Sub ListControlDataBind()
        Dim pTerminalMaster As New CustomerMaster
        lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
        lstCustomer.SelectedValue = 0
    End Sub
    

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvPaymentDetail.DataSource = Nothing
        gvPaymentDetail.DataBind()
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
        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Purchase Type")
            Functions.ControlFocus(lstPurchaseType)
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strpParms As String = ""
        strpParms &= Session.Item("CompanyId")
        strpParms &= ",'" & hdnReceiptNo.Value & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DEBIT_MAPPING", strpParms)
        gvPaymentDetail.DataSource = dbr
        gvPaymentDetail.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()



    End Sub
    Dim CrAmt As Double = 0
    Dim CrTaxAmt As Double = 0
    Dim CrTotalAmt As Double = 0

    'Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        intCounter = intCounter + 1
    '        e.Row.Cells(0).Text = intCounter
    '        CrAmt = CrAmt + Convert.ToDouble(e.Row.Cells(5).Text)
    '        CrTaxAmt = CrTaxAmt + Convert.ToDouble(e.Row.Cells(6).Text)
    '        CrTotalAmt = CrTotalAmt + Convert.ToDouble(e.Row.Cells(7).Text)
    '    ElseIf e.Row.RowType = DataControlRowType.Footer Then
    '        e.Row.Cells(0).ColumnSpan = 5
    '        e.Row.Cells(0).Text = "Total"
    '        e.Row.Cells(0).Font.Bold = True
    '        e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(1).Text = Math.Round(CrAmt, 2)
    '        e.Row.Cells(1).Font.Bold = True
    '        e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(2).Text = Math.Round(CrTaxAmt, 2)
    '        e.Row.Cells(2).Font.Bold = True
    '        e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(3).Text = Math.Round(CrTotalAmt, 2)
    '        e.Row.Cells(3).Font.Bold = True
    '        e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(4).Visible = True
    '        e.Row.Cells(5).Visible = False
    '        e.Row.Cells(6).Visible = False
    '        e.Row.Cells(7).Visible = False
    '        e.Row.Cells(8).Visible = False
    '        e.Row.Cells(9).Visible = False
    '        e.Row.Cells(10).Visible = False

    '    End If
    'End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Debit Note Mapping.csv"
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
            strContHeader = "Sr No." & strComa & "Sale Payment Status" & strComa & "BL No." & strComa & _
                          "Invoice No." & strComa & "Invoice Date" & strComa & "Invoice Amount" & strComa & "Dr Amount" & strComa & "TDS Amount" & strComa & "Dr Note" & strComa & "Issue Amount"
            strb.Append(strContHeader & vbCrLf)

            If gvPaymentDetail.Rows.Count > 0 Then
                Dim sr As Integer = 0
                For Each r As GridViewRow In gvPaymentDetail.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        sr = sr + 1
                        If c = 0 Then
                            strb.Append(sr & strComa)
                        End If
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                        Else
                            strb.Append(" " & strComa)
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
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub



    Protected Sub OnClickHandlerStatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Response.Redirect("~/Commercial/DeditNote.aspx?CrNo=" & lnk.Text)
    End Sub
    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        lstCustomer.Items.Clear()
        If lstPurchaseType.SelectedValue = "L" Or lstPurchaseType.SelectedValue = "C" Then
            Dim pTerminalMaster As New ExtCustomerMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAll(pTerminalMaster)
            lstCustomer.DataTextField = "CustomerName"
            lstCustomer.DataValueField = "CustomerId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0

        ElseIf lstPurchaseType.SelectedValue = "M" Or lstPurchaseType.SelectedValue = "S" Then
            Dim pVendorMaster As New VendorMaster
            lstCustomer.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
            lstCustomer.DataTextField = "VendorName"
            lstCustomer.DataValueField = "VendorId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        End If
    End Sub


    Protected Sub btnGO_Click(sender As Object, e As System.EventArgs) Handles btnGO.Click
        Try
            Dim strConnectionString As String = ""
            Dim CMD1 As String = ""
            Dim con As OleDbConnection
            Dim ada As OleDbDataAdapter
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD1 = "SELECT distinct IR.RECEIPT_NO, IR.RECEIPT_REF_NO FROM INVOICE_RECEIPT IR LEFT JOIN FINANCE_DETAILS FD ON IR.RECEIPT_NO=FD.RECEIPT_NO WHERE FD.FNC_TYPE='P' AND  TRN_TYPE='D'" &
     " AND (IR.CUSTOMER_ID= " & lstCustomer.SelectedValue & " OR IR.CUSTOMER_ID IN (SELECT CUSTOMER_ID FROM CUSTOMER_MASTER WHERE CUSTOMER_GROUP_ID=" & lstCustomer.SelectedValue & "))"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            ddchkContainer.DataSource = ds.Tables(0)
            ddchkContainer.DataTextField = "RECEIPT_REF_NO"
            ddchkContainer.DataValueField = "RECEIPT_NO"
            ddchkContainer.DataBind()
            ds.Clear()
            ddchkContainer.Enabled = True
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Dim totalAdvanceAmt As Double = 0.0
    Dim totalTaxableAmt As Double = 0.0
    Dim TotalBasicAmt As Double = 0.0
    Dim CGST_Rate As Double = 0.0
    Dim CGSTAmount As Double = 0.0
    Dim SGST_Rate As Double = 0.0
    Dim SGSTAmount As Double = 0.0
    Dim IGST_Rate As Double = 0.0
    Dim IGSTAmount As Double = 0.0
    Dim UTGST_Rate As Double = 0.0
    Dim UTGSTAmount As Double = 0.0
    Dim CESS_Rate As Double = 0.0
    Dim CESSAmount As Double = 0.0
    Dim totalCGST As Double = 0.0
    Dim totalSGST As Double = 0.0
    Dim totalIGST As Double = 0.0
    Dim totalUTGST As Double = 0.0
    Dim totalCESS As Double = 0.0
    Dim totalTaxAmount As Double = 0.0
    Dim totalDrAmount As Double = 0.0
    Dim grandTotal As Double = 0.0
    Dim totalTDS As Double = 0.0
    Dim totalInvAmt As Double = 0.0
    Dim totalRevAmt As Double = 0.0
    Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                totalInvAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "INVOICE_AMOUNT"))
            Catch ex As Exception
                totalInvAmt += 0.0
            End Try

            Try
                totalRevAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TA"))
            Catch ex As Exception
                totalRevAmt += 0.0
            End Try
            Try
                totalDrAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DR_AMT"))
            Catch ex As Exception
                totalDrAmount += 0.0
            End Try
            Try
                totalTDS += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDS"))
            Catch ex As Exception
                totalTDS += 0.0
            End Try

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 5
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(1).Text = Format(Math.Round(totalInvAmt, 2), "0.00")
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(2).Text = Format(Math.Round(totalDrAmount, 2), "0.00")
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(3).Text = Format(Math.Round(totalTDS, 2), "0.00")
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(4).Text = Format(Math.Round(totalRevAmt, 2), "0.00")
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
        End If
    End Sub

    Protected Sub btnPDF_Click(sender As Object, e As System.EventArgs) Handles btnPDF.Click
        If hdnReceiptNo.Value <> Nothing Then
            Response.Redirect("~/Commercial/Preview/InvoiceIssueGSTMapping.aspx?ReceiptNo=" & hdnReceiptNo.Value)
        End If
    End Sub
End Class
