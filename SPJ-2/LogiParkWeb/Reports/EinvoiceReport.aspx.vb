Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_EinvoiceReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Sub ListControlDataBind()

    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvInvoiceListAll.DataSource = Nothing
        gvInvoiceListAll.DataBind()
        tblReport.Visible = False
        If textFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date.")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date.")
            Functions.ControlFocus(textToDate)
            Return
        End If

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstDocType.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("EINVOICE_PKG.SP_EINVOICE_REPORT", strpParms)
        gvInvoiceListAll.DataSource = dbr
        gvInvoiceListAll.DataBind()
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True

    End Sub
    Dim totalAmount As Double
    Protected Sub gvInvoiceListAll_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceListAll.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
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
            Dim strFileName As String = "E-InvoiceReport.csv"
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

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Sr.No" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Status" & strComa & _
                          "E-Invoice Date" & strComa & "IRN" & strComa & "Error Msg"

            strb.Append(strContHeader & vbCrLf)
            If gvInvoiceListAll.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceListAll.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        Dim Invoice = DirectCast(r.FindControl("hdnInvoiceRefNo"), HiddenField)
                        If c = 1 Then
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
    Protected Sub gvInvoiceReport_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Dim pServiceType As String = Nothing
        Dim pInvoiceNo As String = Nothing
        Dim currentRowIndex As Integer = Convert.ToInt32(e.CommandArgument)

        pServiceType = CType(gvInvoiceListAll.Rows(currentRowIndex).Cells(6).FindControl("hdnServiceType"), HiddenField).Value
        pInvoiceNo = CType(gvInvoiceListAll.Rows(currentRowIndex).Cells(6).FindControl("hdnInvoiceNo"), HiddenField).Value


        'If pDocType = "I" And pServiceType = "W" Then
        '    Response.Redirect("~/Reports/Imports/Print/GstOtherCFSPrint2.aspx?InvoiceNo=" & pInvoiceNo)
        'ElseIf pDocType = "I" And pServiceType <> "W" Then
        '    Response.Redirect("~/Reports/Imports/Print/GstImportInvoice2.aspx?InvoiceNo=" & pInvoiceNo & "&DocType=" & "I")
        'ElseIf pDocType = "E" Then
        '    Response.Redirect("~/Reports/Imports/Print/GstExportInvoice2.aspx?InvoiceNo=" & pInvoiceNo & "&DocType=" & "E")
        'ElseIf pDocType = "D" Then
        '    Response.Redirect("~/Reports/Imports/Print/GstOtherCFSPrint2.aspx?InvoiceNo=" & pInvoiceNo)
        'ElseIf pServiceType = "M" Then
        '    Response.Redirect("~/Commercial/Preview/manualInvPrint3.aspx?InvoiceNo=" & pInvoiceNo)
        'End If
        Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pInvoiceNo)
    End Sub
End Class

