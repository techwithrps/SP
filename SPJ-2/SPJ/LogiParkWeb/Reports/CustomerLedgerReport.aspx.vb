Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_CustomerLedgerReport
    Inherits System.Web.UI.Page

    Sub ListControlDataBind()
        Dim pCU As New ExtCustomerMaster
        lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterList(pCU)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Add(New ListItem("ALL", "0"))
        lstCustomerName.SelectedValue = 0
    End Sub

    Dim intCounter As Long = 0
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

        Dim strpParms As String = ""
        strpParms &= lstCustomerName.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
   
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUSTOMER_LEDGER_REPORT", strpParms)
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
        ' strpParms = lnk.CommandArgument
        strpParms = lstCustomerName.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_MAP", strpParms)
        gridviewVehicleDtls.DataSource = dbr
        gridviewVehicleDtls.DataBind()
        gridviewVehicleDtls.Visible = True
        'Dim message As String = lnk.Text
        Dim message As String = lstCustomerName.SelectedItem.Text
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" + message + "');", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("Home.aspx")
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "CustomerLedgerReport.csv"
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
            strb.Append("As On Date :- " & Today.Day & "/" & Today.Month & "/" & Today.Year & vbCrLf)
            strb.Append(Space(4) & vbCrLf)
            strb.Append(Space(4) & vbCrLf)
            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Sr." & strComa & "Customer Name" & strComa & "Customer Type" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Payment Mode" & strComa & "Instrument No" & strComa & _
                 "Instrument Date" & strComa & "Receipt No" & strComa & "CR Amount(INR)" & strComa & "DR Amount(INR)" & strComa & "Remarks"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ") & strComa)
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

    Dim rowSBCrAmount As Double = 0.0
    Dim rowSBDrAmount As Double = 0.0
   
    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            rowSBCrAmount = rowSBCrAmount + Convert.ToDouble(e.Row.Cells(9).Text)
            rowSBDrAmount = rowSBDrAmount + Convert.ToDouble(e.Row.Cells(10).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 9
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(1).Text = Math.Round(rowSBCrAmount, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(2).Text = Math.Round(rowSBDrAmount, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = "Balance:" & Math.Round((rowSBDrAmount - rowSBCrAmount), 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
        End If
        Dim bal As Double = rowSBDrAmount - rowSBCrAmount
        lblTotalbalanceAmt.Text = "Total In Words :     " & NumberToWord.AmtInWord(bal)
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
End Class
