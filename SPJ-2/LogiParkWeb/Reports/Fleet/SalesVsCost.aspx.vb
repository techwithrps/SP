Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Fleet_SalesVsCost
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvInvoiceReport.DataSource = Nothing
            gvInvoiceReport.DataBind()
            tblReport.Visible = False
            lblScreenTitle.Text = Session.Item("Title")
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
        strpParms = "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        'strpParms &= ",'" & lstDocumentType.SelectedValue & "'"
        ' strpParms &= ",'" & lstInvoiceStatus.SelectedValue & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SALES_COST_REPORT", strpParms)
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

    Dim dblInvoiceAmount As Double = 0
    Dim dblTotalInvoiceAmount As Double = 0
    Dim dblbaseCostAmount As Double = 0
    Dim dblTotalbaseCostAmount As Double = 0
    Dim dblMargin As Double = 0
    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            If e.Row.Cells(5).Text = "" Then
            Else
                Try
                    dblInvoiceAmount = dblInvoiceAmount + Convert.ToDouble(e.Row.Cells(5).Text)
                Catch ex As Exception
                    dblInvoiceAmount += 0.0
                End Try
            End If

            ' Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SGST_AMOUNT"))
            'If Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_INV_AMOUNT")) = "" Then
            'Else

            Try
                dblTotalInvoiceAmount = dblTotalInvoiceAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_INV_AMOUNT"))
            Catch ex As Exception
                dblTotalInvoiceAmount += 0.0
            End Try
            'End If


            If e.Row.Cells(7).Text = "" Then
            Else
                Try
                    dblbaseCostAmount = dblbaseCostAmount + Convert.ToDouble(e.Row.Cells(7).Text)
                Catch ex As Exception
                    dblbaseCostAmount += 0.0
                End Try
            End If

            'If e.Row.Cells(8).Text = "" Then
            'Else
            '    Try
            '        dblTotalbaseCostAmount = dblTotalbaseCostAmount + Convert.ToDouble(e.Row.Cells(8).Text)
            '    Catch ex As Exception
            '        dblTotalbaseCostAmount += 0.0
            '    End Try

            'End If

            'If Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_COST_AMOUNT")) = "" Then
            'Else

            Try
                dblTotalbaseCostAmount = dblTotalbaseCostAmount + Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_COST_AMOUNT"))
            Catch ex As Exception
                dblTotalbaseCostAmount += 0.0
            End Try
            'End If

            If e.Row.Cells(9).Text = "" Then
            Else
                Try
                    dblMargin = dblMargin + Convert.ToDouble(e.Row.Cells(9).Text)
                Catch ex As Exception
                    dblMargin += 0.0
                End Try
            End If




        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 5
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(0).Font.Size = 10

            e.Row.Cells(1).Text = Format(Math.Round(dblInvoiceAmount, 2), "0.00")
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(1).Font.Size = 10
            e.Row.Cells(2).Text = Format(Math.Round(dblTotalInvoiceAmount, 2), "0.00")
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Font.Size = 10
            e.Row.Cells(3).Text = Format(Math.Round(dblbaseCostAmount, 2), "0.00")
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(3).Font.Size = 10
            e.Row.Cells(4).Text = Format(Math.Round(dblTotalbaseCostAmount, 2), "0.00")
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Font.Size = 10
            e.Row.Cells(5).Text = Format(Math.Round(dblMargin, 2), "0.00")
            e.Row.Cells(5).Font.Bold = True
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Font.Size = 10
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            'TextTotal.Text = e.Row.Cells(5).Text + Total
            'Total = TextTotal.Text
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Sales Vs Cost Report.csv"
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
            strContHeader = "Sr" & strComa & "Customer Name" & strComa & "Line" & strComa & _
                          "Port" & strComa & "Bl No" & strComa & "Base Invoice Amount" & strComa & "Total Invoice Amount" & strComa & "Base Cost Amount" & strComa & "Total Cost Amount" & strComa & "Margin"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If c <> 8 And c <> 6 Then


                            If r.Cells(c).Text.Trim.ToString <> Nothing Then
                                strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                            Else
                                strb.Append(" " & strComa)
                            End If
                        End If
                        If c = 6 Then
                            Dim dblTotalInvAmt As Double = 0
                            dblTotalInvAmt = Convert.ToDouble(CType(r.Cells(6).FindControl("lnkTIA"), LinkButton).Text)
                           
                            strb.Append(dblTotalInvAmt & strComa)
                        End If
                        If c = 8 Then
                            Dim dblTotalCostAmt As Double = 0
                            dblTotalCostAmt = Convert.ToDouble(CType(r.Cells(6).FindControl("lnkTCA"), LinkButton).Text)

                            strb.Append(dblTotalCostAmt & strComa)
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


    'Protected Sub gvService_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
    '    gvInvoiceReport.DataSource = Nothing
    '    gvInvoiceReport.DataBind()
    '    Dim ServiceName As String = Nothing
    '    Dim serviceId As Long = 0
    '    Dim currentRowIndex As Integer = Convert.ToInt32(e.CommandArgument)
    '    ' serviceId = Convert.ToString(CType(gvService.Rows(currentRowIndex).Cells(0).FindControl("SERVICE_NAME"), bou).Text)
    '    Try
    '        'ServiceName = gvService.Rows(currentRowIndex).Cells(1).Text

    '        Dim lbtn As LinkButton = TryCast(gvInvoiceReport.Rows(currentRowIndex).Cells(1).Controls(0), LinkButton)

    '        ServiceName = lbtn.Text
    '    Catch ex As Exception

    '    End Try

    '    ' ServiceName = gvService.Rows(currentRowIndex).Cells(2).Text.Trim()
    '    Dim strFromDate As String = ""
    '    Dim strToDate As String = ""
    '    Try
    '        Dim arrFromDate As String() = textFromDate.Text.Trim().Split("/".ToCharArray())
    '        strFromDate = arrFromDate(2) & "-" & arrFromDate(1) & "-" & arrFromDate(0)
    '        Dim arrToDate As String() = textToDate.Text.Trim().Split("/".ToCharArray())
    '        strToDate = arrToDate(2) & "-" & arrToDate(1) & "-" & arrToDate(0)

    '    Catch ex As Exception

    '    End Try
    '    Dim strConnString1 As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
    '    Dim con1 As New OleDbConnection(strConnString1)
    '    Dim cmd1 As New OleDbCommand()
    '    cmd1.CommandType = CommandType.StoredProcedure
    '    cmd1.CommandText = "USP_REPORT_MNG_INVOICE_SERVICE_DETAILS"
    '    cmd1.Parameters.AddWithValue("@p_TERMINAL_ID", Session.Item("LoginTerminal"))
    '    cmd1.Parameters.AddWithValue("@p_FROM_DATE", strFromDate)
    '    cmd1.Parameters.AddWithValue("@p_FROM_DATE", strToDate)
    '    cmd1.Parameters.AddWithValue("@p_Bill_to", lstCustomerName.SelectedValue)
    '    cmd1.Parameters.AddWithValue("@p_SERVICE_NAME", ServiceName)
    '    cmd1.Connection = con1
    '    Try
    '        con1.Open()
    '        gvServiceDetails.EmptyDataText = "No Records Found"
    '        gvServiceDetails.DataSource = cmd1.ExecuteReader()
    '        gvServiceDetails.DataBind()
    '        If gvServiceDetails.Rows.Count > 0 Then
    '            gvServiceDetails.Visible = True
    '            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
    '        End If

    '        'If d20f Or d40f > 0 Then
    '        '    txtDetail20.Text = d20f

    '        '    lblDetailTotal.Text = "Total"
    '        'Else
    '        '    txtDetail20.Visible = False

    '        '    lblDetailTotal.Visible = False
    '        'End If
    '        'tblreport1.Visible = True
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        con1.Close()
    '        con1.Dispose()
    '    End Try

    'End Sub

    Protected Sub OnClickHandlerTotalInvoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        '  Dim strpParms As String = ""
        '  strpParms = lnk.CommandArgument
        'HdnReceiptNO.Value = lnk.CommandArgument
        'LblReceiptno.Text = lnk.CommandArgument
        'strpParms = lstCustomerName.SelectedValue

        Dim strpParms As String = ""
        strpParms = "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lnk.CommandArgument & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SALES_COST_REPORT_TAT", strpParms)
        gridviewVehicleDtls.DataSource = dbr
        gridviewVehicleDtls.DataBind()
        gridviewVehicleDtls.Visible = True

        If gridviewVehicleDtls.Rows.Count > 0 Then
            gridviewVehicleDtls.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
        End If

    End Sub


    Protected Sub OnClickHandlerTotalCost(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        '  Dim strpParms As String = ""
        '  strpParms = lnk.CommandArgument
        'HdnReceiptNO.Value = lnk.CommandArgument
        'LblReceiptno.Text = lnk.CommandArgument
        'strpParms = lstCustomerName.SelectedValue

        Dim strpParms As String = ""
        strpParms = "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lnk.CommandArgument & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SALES_COST_REPORT_TCA", strpParms)
        gridviewVehicleDtls.DataSource = dbr
        gridviewVehicleDtls.DataBind()
        gridviewVehicleDtls.Visible = True

        If gridviewVehicleDtls.Rows.Count > 0 Then
            gridviewVehicleDtls.Visible = True
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
        End If
    End Sub


End Class
