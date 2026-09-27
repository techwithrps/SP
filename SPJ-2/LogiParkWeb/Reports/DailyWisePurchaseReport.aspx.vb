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
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strpParms As String = ""
        strpParms &= Session.Item("CompanyId")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
        strpParms &= "," & lstCustomer.SelectedValue & ""


        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PURCHASE_REPORT_DY", strpParms)
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
    Dim TaxAmt As Double = 0
    Dim BaseRate As Double = 0
    Dim BillAmt As Double = 0
    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TaxAmt = TaxAmt + Convert.ToDouble(e.Row.Cells(6).Text)
            BaseRate = BaseRate + Convert.ToDouble(e.Row.Cells(5).Text)
            BillAmt = BillAmt + Convert.ToDouble(e.Row.Cells(7).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 5
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right



            e.Row.Cells(1).Text = Math.Round(BaseRate, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(TaxAmt, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(BillAmt, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Purchase Report.csv"
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
            strContHeader = "Sr No." & strComa & "Customer Name" & strComa & "Invoice No" & strComa & _
                          "Invoice Date" & strComa & "Bl No" & strComa & "Taxable Amount" & strComa & "Tax Amount" & strComa & "Bill Amount" & strComa & "Created By" & strComa & "Created On"
            strb.Append(strContHeader & vbCrLf)

            If gvInvoiceReport.Rows.Count > 0 Then
                For Each r As GridViewRow In gvInvoiceReport.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If c <> 2 Then


                            If r.Cells(c).Text.Trim.ToString <> Nothing Then
                                strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
                            Else
                                strb.Append(" " & strComa)
                            End If
                        Else
                            Dim InvoiceNo As String = 0
                            InvoiceNo = Convert.ToString(CType(r.Cells(2).FindControl("lnkInvoice"), LinkButton).Text)

                            strb.Append(InvoiceNo & strComa)
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

    Protected Sub OnClickHandlerStatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Response.Redirect("~/Commercial/CostBookingNew.aspx?CostId=" & lnk.Text)
    End Sub
End Class
