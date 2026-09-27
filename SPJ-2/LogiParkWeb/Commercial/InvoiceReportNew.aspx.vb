Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Imports_InvoiceReportNew
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
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstServiceType.SelectedValue & "'"
        'strpParms &= ",'" & lstDocumentType.SelectedValue & "'"
        ' strpParms &= ",'" & lstInvoiceStatus.SelectedValue & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVOICE_REPORT_NEW", strpParms)
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

    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TextTotal.Text = e.Row.Cells(12).Text + Total
            Total = TextTotal.Text
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Invoice Report New.csv"
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
            strContHeader = "Sr" & strComa & "Customer Name" & strComa & "Shipper Inv No." & strComa & "BL No" & strComa & "Handover Date" & strComa & "SOB Date" & strComa & "POD" & strComa & "Invoice No" & strComa &
                          "Invoice Date" & strComa & "Service Type" & strComa & "Ex Rate" & strComa & "Amount" & strComa & "IGST" & strComa & "CGST" & strComa & "SGST" & strComa & "Total"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        Dim Invoice = DirectCast(r.FindControl("hdnInvoiceRefNo"), HiddenField)
                        If c = 7 Then
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
            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub OnClickHandlerStatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        '  Response.Redirect("~/Commercial/CreditNote.aspx?CrNo=" & lnk.Text)
        Dim pCrNote As New ImpInvoice
        pCrNote.InvoiceRefNo = lnk.Text
        ImpInvoice.ReturnImpInvoiceByInvoiceRefNo(pCrNote)

        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerId = pCrNote.BillTo
        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)

        If pCustomerMaster.StateCode = "0" Then
            Response.Redirect("~/Commercial/Preview/ExportInvoicePrintB2B.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
        End If

        If pCrNote.InvoiceNo > 170537 Then
            If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId)
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "E" Then
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "V" Then
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "O" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "I" Then
                Response.Redirect("~/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "D" Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "P" Then
                Response.Redirect("~/Commercial/Preview/ImportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "T" Then
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "F" And pCrNote.TerminalId = 51 Then
                Response.Redirect("~/Commercial/Preview/RexportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "X" Then
                Response.Redirect("~/Commercial/Preview/RexportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            Else
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintNew.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            End If
        Else
            If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId)
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "O" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "I" Then
                Response.Redirect("~/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "D" Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "P" Then
                Response.Redirect("~/Commercial/Preview/ImportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "T" Then
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "F" And pCrNote.TerminalId = 51 Then
                Response.Redirect("~/Commercial/Preview/RexportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "X" Then
                Response.Redirect("~/Commercial/Preview/RexportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            Else
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            End If
        End If
    End Sub


    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvInvoiceReport)
    End Sub
End Class
