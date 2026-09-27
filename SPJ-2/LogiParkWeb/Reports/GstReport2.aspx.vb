Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_GstReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim intCounter1 As Long = 0

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

        gvb2cs.DataSource = Nothing
        gvb2cs.DataBind()

        gvService.DataSource = Nothing
        gvService.DataBind()

        tblReport.Visible = False
        If txtFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(txtFromDate)
            Return
        End If
        If txtToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(txtToDate)
            Return
        End If

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")


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
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
       

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("GST_Report_Pkg.SP_REPORT_GST2B2B_REPORT", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        End If

        'dbr = db.StoredProcedureReadDB("USP_REPORT_GSTB2CS_REPORT", strpParms)
        'gvb2cs.DataSource = dbr
        'gvb2cs.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'End If

        'dbr = db.StoredProcedureReadDB("USP_REPORT_GSTB2CL_REPORT", strpParms)
        'gvb2cl.DataSource = dbr
        'gvb2cl.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'End If

        'dbr = db.StoredProcedureReadDB("GST_Report_Pkg.SP_REPORT_GSTSUMMARY_REPORT", strpParms)
        'gvSummary.DataSource = dbr
        'gvSummary.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'End If

        'dbr = db.StoredProcedureReadDB("GST_Report_Pkg.SP_REPORT_HSN_REPORT", strpParms)
        'gvService.DataSource = dbr
        'gvService.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'End If

        dbr = db.StoredProcedureReadDB("GST_Report_Pkg.SP_REPORT_GST2CRN_REPORT", strpParms)
        gvCredit.DataSource = dbr
        gvCredit.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        End If

        dbr.Close()
        db.CloseDB()
    End Sub

    'Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        intCounter = intCounter + 1
    '        e.Row.Cells(0).Text = intCounter

    '    End If
    'End Sub

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Try
    '        Dim strComa = ","
    '        Dim strFileName As String = "GSTReturn.csv"
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

    '        strb.Append(lblReport.Text & " : ")
    '        strb.Append(lblReportDate.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)

    '        Dim strContHeader As String = Nothing
    '        Dim strContHeader1 As String = Nothing
    '        Dim strContHeader2 As String = Nothing
    '        Dim strSummaryHeader As String = Nothing
    '        strContHeader = "Sr." & strComa & "GSTIN/UIN of Recipient" & strComa & "Invoice Number" & strComa &
    '                      "Invoice Date" & strComa & "Invoice Value" & strComa & "Place Of Supply" & strComa & "Reverse Charge" & strComa &
    '                      "Invoice Type" & strComa & "E-Commerce GSTIN" & strComa & "Rate" & strComa & "Taxable Value" & strComa & "Cess Amount"
    '        strb.Append(strContHeader & vbCrLf)

    '        If gvInvoiceReport.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvInvoiceReport.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1

    '                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
    '                        Else
    '                            strb.Append(" " & strComa)
    '                    End If
    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If
    '        strb.Append(Space(4) & vbCrLf)
    '        strb.Append("Table-2" & vbCrLf)

    '        strContHeader1 = "Taxable Value" & strComa & "Rate of Tax" & strComa & "IGST" & strComa &
    '                      "CGST" & strComa & "SGST"
    '        strb.Append(strContHeader1 & vbCrLf)

    '        If gvb2cs.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvb2cs.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    ' Dim Invoice = DirectCast(r.FindControl("HdnserviceName"), HiddenField)

    '                    If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                        strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
    '                    Else
    '                        strb.Append(" " & strComa)
    '                    End If

    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If

    '        strb.Append(Space(4) & vbCrLf)
    '        strb.Append("Table-3" & vbCrLf)

    '        strContHeader2 = "HSN" & strComa & "Service Name" & strComa & "TEU" & strComa & "Base Amount" & strComa &
    '                      "CGST" & strComa & "SGST" & strComa & "IGST" & strComa & "GST Amount" & strComa & "Bill Amount"
    '        strb.Append(strContHeader2 & vbCrLf)

    '        If gvService.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvService.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    ' Dim Invoice = DirectCast(r.FindControl("HdnserviceName"), HiddenField)

    '                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
    '                        Else
    '                            strb.Append(" " & strComa)
    '                        End If

    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If
    '        strb.Append(Space(4) & vbCrLf)
    '        Response.Write(strb.ToString)
    '        Response.Flush()
    '        Response.End()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub gvInvoiceReport_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Dim pInvoiceNo As String = Nothing
        Dim pDocType As String = Nothing
        Dim currentRowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        pInvoiceNo = CType(gvInvoiceReport.Rows(currentRowIndex).Cells(10).FindControl("hdnInvoiceNo"), HiddenField).Value
        pDocType = CType(gvInvoiceReport.Rows(currentRowIndex).Cells(10).FindControl("hdnDocType"), HiddenField).Value
    End Sub

    Protected Sub btnb2b_Click(sender As Object, e As EventArgs) Handles btnb2b.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "b2b.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Vendor GSTIN" & strComa & "Vendor Name" & strComa & "Invoice Number" & strComa &
                         "Invoice Date" & strComa & "Place of Supply" & strComa & "No of Item" & strComa & "Rate" & strComa &
                         "Invoice Value" & strComa & "CGST" & strComa & "SGST" & strComa & "IGST" & strComa & "Cess Amount" & strComa & "Total Value" & strComa & "ITC Eligibility" & strComa & "CGST Eligible" & strComa & "SGST Eligible" & strComa & "IGST Eligible"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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

    Protected Sub btnhsn_Click(sender As Object, e As EventArgs) Handles btnhsn.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "hsn.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")


            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "HSN" & strComa & "Description" & strComa & "UQC" & strComa & "Total Quantity" & strComa & "Total Value" & strComa &
                          "Taxable Value" & strComa & "Integrated Tax Amount" & strComa & "Central Tax Amount" & strComa & "State/UT Tax Amount" & strComa & "Cess Amount"
            strb.Append(strContHeader & vbCrLf)

            If gvService.Rows.Count > 0 Then
                For Each r As GridViewRow In gvService.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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

    Protected Sub btnb2cs_Click(sender As Object, e As EventArgs) Handles btnb2cs.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "b2cs.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Type" & strComa & "Place Of Supply" & strComa & "Rate" & strComa & "Taxable Value" & strComa & "Cess Amount" & strComa & "E-Commerce GSTIN"
            strb.Append(strContHeader & vbCrLf)

            If gvb2cs.Rows.Count > 0 Then
                For Each r As GridViewRow In gvb2cs.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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
    Protected Sub btnb2cl_Click(sender As Object, e As EventArgs) Handles btnb2cl.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "b2cl.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Invoice Number" & strComa & "Invoice Date" & strComa & "Invoice Value" & strComa & "Place Of Supply" & strComa & "Rate" & strComa & "Taxable Value" & strComa & "Cess Amount" & strComa & "E-Commerce GSTIN"
            strb.Append(strContHeader & vbCrLf)

            If gvb2cl.Rows.Count > 0 Then
                For Each r As GridViewRow In gvb2cl.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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
    Protected Sub btndoc_Click(sender As Object, e As EventArgs) Handles btndoc.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "doc.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Nature of Document" & strComa & "Doc Type" & strComa & "Sr. No. From" & strComa & "Sr. No. To" & strComa & "Total Number" & strComa & "Cancelled"
            strb.Append(strContHeader & vbCrLf)

            If gvSummary.Rows.Count > 0 Then
                For Each r As GridViewRow In gvSummary.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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

    Protected Sub btnCreditExcel_Click(sender As Object, e As System.EventArgs) Handles btnCreditExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Credit Note.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing

            strContHeader = "Vendor GSTIN" & strComa & "Vendor Name" & strComa & "Note/Refund Voucher Number" & strComa & "Note/Refund Voucher date" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Document Type" & strComa & "Reason for Issuing" & strComa & "No of Item" & strComa & "Taxable Value" & strComa & "CGST Amount" & strComa & "SGST Amount" & strComa & "IGST Amount" & strComa & "Cess Amount" & strComa & "Note/Refund Voucher Value" & strComa & "Supply Type" & strComa & "Pre GST" & strComa & "CGST Eligible" & strComa & "SGST Eligible" & strComa & "IGST Eligible"

            strb.Append(strContHeader & vbCrLf)

            If gvCredit.Rows.Count > 0 Then
                For Each r As GridViewRow In gvCredit.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

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

    'Protected Sub gvCredit_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCredit.RowDataBound
    '    'If e.Row.RowType = DataControlRowType.DataRow Then
    '    '    intCounter = intCounter + 1
    '    '    e.Row.Cells(0).Text = intCounter
    '    'End If
    'End Sub
End Class
