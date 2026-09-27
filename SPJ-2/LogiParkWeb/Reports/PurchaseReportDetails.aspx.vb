Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Imports_InvoiceReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim intCounter1 As Long = 0
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
        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Purchase Type")
            Functions.ControlFocus(lstPurchaseType)
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")

        lblReportService.Visible = True
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strpParms As String = ""
        strpParms &= 0
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstCustomer.SelectedValue & ""


        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PURCHASE_DTLS_REPORT", strpParms)
            gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PURCHASE_SRS_DTLS", strpParms)
        gvService.DataSource = dbr
        gvService.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
     

        
    End Sub
    Dim TaxAmt As Double = 0
    Dim TaxableAmt As Double = 0
    Dim cgstAmt As Double = 0
    Dim sgstAmt As Double = 0
    Dim igstAmt As Double = 0
    Dim BaseRate As Double = 0
    Dim tdsAmt As Double = 0
    Dim BillAmt As Double = 0
    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TaxableAmt = TaxableAmt + Convert.ToDouble(e.Row.Cells(8).Text)
            TaxAmt = TaxAmt + Convert.ToDouble(e.Row.Cells(9).Text)
            cgstAmt = cgstAmt + Convert.ToDouble(e.Row.Cells(11).Text)
            sgstAmt = sgstAmt + Convert.ToDouble(e.Row.Cells(13).Text)
            igstAmt = igstAmt + Convert.ToDouble(e.Row.Cells(15).Text)
            tdsAmt = tdsAmt + Convert.ToDouble(e.Row.Cells(16).Text)
            BillAmt = BillAmt + Convert.ToDouble(e.Row.Cells(17).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 8
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(1).Text = Math.Round(TaxableAmt, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(TaxAmt, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = ""
            e.Row.Cells(4).Text = Math.Round(cgstAmt, 2)
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = ""
            e.Row.Cells(6).Text = Math.Round(sgstAmt, 2)
            e.Row.Cells(6).Font.Bold = True
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(7).Text = ""
            e.Row.Cells(8).Text = Math.Round(igstAmt, 2)
            e.Row.Cells(8).Font.Bold = True
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(9).Text = Math.Round(tdsAmt, 2)
            e.Row.Cells(9).Font.Bold = True
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(10).Text = Math.Round(BillAmt, 2)
            e.Row.Cells(10).Font.Bold = True
            e.Row.Cells(10).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(2).Font.Bold = True
            'e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(3).Text = Math.Round(BillAmt, 2)
            'e.Row.Cells(3).Font.Bold = True
            'e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            'e.Row.Cells(4).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False
            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Purchase Customer-Service Wise Details  Report.csv"
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
            strContHeader = "Sr No." & strComa & "Customer Name" & strComa & "Company Name" & strComa & "Purchase Type" & strComa & "BL No" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Service Name" & strComa & "Taxable Amount" & strComa & "Ex. Rate" & strComa & "Qnty" & strComa & _
                          "Tax Amount" & strComa & "CGST Rate" & strComa & "CGST Amount" & strComa & "SGST Rate" & strComa & "SGST Amount" & strComa & "IGST Rate" & strComa & "IGST Amount" & strComa & "TDS Amount" & strComa & "Bill Amount"
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
            strb.Append(Space(4) & vbCrLf)
            strb.Append(Space(4) & vbCrLf)



            Dim strb1 As New StringBuilder()
            strb1.Append(lblReportService.Text & " : ")
            strb1.Append(lblReportDate.Text & vbCrLf)
            strb1.Append(Space(4) & vbCrLf)

            Dim strContHeader1 As String = Nothing
            Dim strSummaryHeader1 As String = Nothing
            strContHeader1 = "Sr No." & strComa & "Customer Name" & strComa & "Company Name" & strComa & "Service Name" & strComa & "Taxable Amount" & strComa & _
                          "Tax Amount" & strComa & "CGST Amount" & strComa & "SGST Amount" & strComa & "IGST Amount" & strComa & "TDS Amount" & strComa & "Bill Amount"
            strb1.Append(strContHeader1 & vbCrLf)

            If gvService.Rows.Count > 0 Then
                For Each r As GridViewRow In gvService.Rows
                    For c As Integer = 0 To r.Cells.Count - 1

                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb1.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                        Else
                            strb1.Append(" " & strComa)
                        End If

                    Next
                    strb1.Append(vbCrLf)
                Next
            End If
            Response.Write(strb1.ToString)
            strb1.Append(Space(4) & vbCrLf)
            strb1.Append(Space(4) & vbCrLf)

            Response.Flush()
            Response.End()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        lstCustomer.Items.Clear()
        If lstPurchaseType.SelectedValue = "L" Or lstPurchaseType.SelectedValue = "C" Then
            Dim pTerminalMaster As New CustomerMaster
            lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pTerminalMaster)
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


    Protected Sub gvService_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvService.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter1 = intCounter1 + 1
            e.Row.Cells(0).Text = intCounter1
            TaxableAmt = TaxableAmt + Convert.ToDouble(e.Row.Cells(4).Text)
            TaxAmt = TaxAmt + Convert.ToDouble(e.Row.Cells(5).Text)
            cgstAmt = cgstAmt + Convert.ToDouble(e.Row.Cells(6).Text)
            sgstAmt = sgstAmt + Convert.ToDouble(e.Row.Cells(7).Text)
            igstAmt = igstAmt + Convert.ToDouble(e.Row.Cells(8).Text)
            tdsAmt = tdsAmt + Convert.ToDouble(e.Row.Cells(9).Text)
            BillAmt = BillAmt + Convert.ToDouble(e.Row.Cells(10).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 4
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(1).Text = Math.Round(TaxableAmt, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(TaxAmt, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(cgstAmt, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Text = Math.Round(sgstAmt, 2)
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = Math.Round(igstAmt, 2)
            e.Row.Cells(5).Font.Bold = True
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = Math.Round(tdsAmt, 2)
            e.Row.Cells(6).Font.Bold = True
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(7).Text = Math.Round(BillAmt, 2)
            e.Row.Cells(7).Font.Bold = True
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
             End If
    End Sub
End Class
