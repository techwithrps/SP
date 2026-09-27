Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Imports_GSTInvoiceReport
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
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        'strpParms &= ",'" & lstDocumentType.SelectedValue & "'"
       ' strpParms &= ",'" & lstInvoiceStatus.SelectedValue & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_GST_INVOICE_REPORT", strpParms)
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
            ' TextTotal.Text = e.Row.Cells(9).Text + Total
            'Total = TextTotal.Text
        End If
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvInvoiceReport)
    End Sub
    Protected Sub OnClickHandlerStatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        '  Response.Redirect("~/Commercial/CreditNote.aspx?CrNo=" & lnk.Text)
        Dim pCrNote As New ImpInvoice
        pCrNote.InvoiceRefNo = lnk.Text
        ImpInvoice.ReturnImpInvoiceByInvoiceRefNo(pCrNote)
        If pCrNote.InvoiceNo >= 170537 Then
            If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId)
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "D" Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "O" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "I" Then
                Response.Redirect("~/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "E" Then
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "V" Then
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo)

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
            ElseIf pCrNote.ServiceType = "D" Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "O" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "E" Then
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "I" Then
                Response.Redirect("~/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            Else
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            End If
        End If
    End Sub
    Protected Sub OnClickHandlerStatusCR(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Dim pCreditNote As New CrNote
        pCreditNote.CrRefNo = lnk.Text
        CrNote.ReturnCreaditNotebyCrRefNo(pCreditNote)
        If pCreditNote.CrId <> 0 Then
            If pCreditNote.CrId <> 0 And pCreditNote.ServiceType = "O" Then
                Response.Redirect("Preview/CrPrintNewRebate.aspx?InvoiceNo=" & pCreditNote.CrId)
            ElseIf pCreditNote.ServiceType = "R" Then
                Response.Redirect("~/Commercial/Preview/CrPrintNewRebate.aspx?InvoiceNo=" & pCreditNote.CrId)
            ElseIf pCreditNote.ServiceType = "D" Then
                Response.Redirect("~/Commercial/Preview/CrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            ElseIf Session.Item("CompanyId") = 1 Then
                Response.Redirect("~/Commercial/Preview/SJCrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            Else
                Response.Redirect("~/Commercial/Preview/CrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            End If
        End If
    End Sub
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
