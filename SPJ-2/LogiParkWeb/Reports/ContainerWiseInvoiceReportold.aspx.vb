Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Imports_ContainerWiseInvoiceReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvinvoicePending.DataSource = Nothing
            gvinvoicePending.DataBind()
            tblReport.Visible = False

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
        End If

    End Sub

    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
        If ds2 Is Nothing Then
            Return
        End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        If dv.ToTable.Rows.Count > 0 Then
            For Each row As DataRow In dv.ToTable.Rows
                Session.Item("Add") = row(7).ToString
                Session.Item("Edit") = row(8).ToString
                Session.Item("Delete") = row(9).ToString
                Session.Item("Search") = row(10).ToString
                Session.Item("Title") = row(4).ToString
            Next
        Else
            Response.Redirect("~/Restriction.aspx")
        End If

    End Sub


    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,  UPPER(CUSTOMER_NAME ||'-'||CUSTOMER_TYPE_NAME) CUSTOMER_NAME FROM CUSTOMER_MASTER CM, CUSTOMER_TYPE CT WHERE CUSTOMER_TYPE=CT.CUSTOMER_TYPE_CODE AND NVL(STATUS,'N') = 'Y'  ORDER BY CUSTOMER_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            lstCustomer.DataSource = ds.Tables(0)
            lstCustomer.DataTextField = "CUSTOMER_NAME"
            lstCustomer.DataValueField = "CUSTOMER_ID"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", "0")))
            ds.Clear()
            '    Dim pCustomerMaster As New CustomerMaster
            'lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
            'lstCustomer.DataTextField = "CustomerName"
            'lstCustomer.DataValueField = "CustomerId"
            'lstCustomer.DataBind()
            'lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            'lstCustomer.SelectedValue = 0
            Dim pServiceMaster As New ServiceMaster
            pServiceMaster.TerminalId = Session.Item("LoginTerminal")
            lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pServiceMaster)
            lstService.DataTextField = "ServiceName"
            lstService.DataValueField = "ServiceId"
            lstService.DataBind()
            lstService.Items.Insert(0, (New ListItem("---All---", 0)))
            lstService.SelectedValue = 0
            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        gvinvoicePending.DataSource = Nothing
        gvinvoicePending.DataBind()
        If textFromDate.Text = "" AndAlso textToDate.Text = "" AndAlso textContNo.Text = "" AndAlso textBlNo1.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date ,To Date Or   Container No,BL NO")
            Return
        End If
        If textFromDate.Text <> "" AndAlso textToDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Return
        End If
        If textToDate.Text <> "" AndAlso textFromDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        tblReport.Visible = False
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & textContNo.Text & "'"
        strpParms &= ",'" & textBlNo1.Text & "'"
        strpParms &= ",'" & lstDocType.SelectedValue & "'"
        strpParms &= "," & lstCustomer.SelectedValue & ""
        strpParms &= ",'" & lstService.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CONTAINER_INVOICE_REPORT", strpParms)
        gvinvoicePending.DataSource = dbr
        gvinvoicePending.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Record not found")
            lblErrorMessage.Enabled = True
            lblErrorMessage.Visible = True
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvCartingJoPending_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvinvoicePending.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strFileName As String = "Container Wise Invoice.csv"
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

            strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
            strb.Append("Container Wise Invoice Report" & vbCrLf)
            strb.Append(Space(4) & vbCrLf)


            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = "Sr No" & strComa & "Container No" & strComa & "Size" & strComa & "Customer" & strComa & "Party Inv No" & strComa & "Line" & strComa & "BL No" & strComa & "ICD Out Date" & strComa & "ICD In Date" & strComa & "CFS" & strComa & "POL" & strComa & "Handover Date" & strComa & "SOB" & strComa & "POD" & strComa &
                "Document Type" & strComa & "Service Name" & strComa & "Invoice No" & strComa & "Invoice Date" & strComa & "Amount" & strComa & "Tax Amount" & strComa & "Total" & strComa & "Remarks"
            strb.Append(strContHeader & vbCrLf)

            If gvinvoicePending.Rows.Count > 0 Then
                For Each r As GridViewRow In gvinvoicePending.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        Dim Invoice = DirectCast(r.FindControl("hdnInvoiceRefNo"), HiddenField)
                        If c = 19 Then
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
        If pCrNote.InvoiceNo <> 0 Then
            ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId)
            If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId)
                Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "R" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            ElseIf pCrNote.ServiceType = "O" Then
                Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
            Else
                Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)

            End If
        End If
    End Sub

    Sub checkPrint(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lnk As LinkButton = CType(sender, LinkButton)
            Dim pCrNote As New ImpInvoice
            pCrNote.InvoiceRefNo = lnk.Text
            ImpInvoice.ReturnImpInvoiceByInvoiceRefNo(pCrNote)
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

		  '=========== ADDED BY ARJUN NEGI ON 08/07/2025 for usd invoice print ============
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            pCustomerMaster.CustomerId = pCrNote.BillTo
            CustomerMaster.ReturnCustomerMaster(pCustomerMaster)

            If pCustomerMaster.StateCode = "0" Then
                Dim URL1 As String = "/SPJ/Commercial/Preview/ExportInvoicePrintB2B.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                Dim s1 As String = "window.open('" & URL1 + "', 'popup_window', 'width=800,height=800,left=100,top=100,resizable=yes');"
                ClientScript.RegisterStartupScript(Me.GetType(), "script", s1, True)
                Return
            End If
            '=========================end on 08/07/2025 for usd invoice print==============
            'Dim btnPrint As LinkButton = sender
            'Dim namingCont = CType(btnPrint.NamingContainer, RepeaterItem)
            'Dim url As String = "ReceiptPrint.aspx?receiptNo=" & CType(namingCont.FindControl("hdnReceiptNo"), HiddenField).Value
            Dim url As String = ""

            If pCrNote.InvoiceNo <> 0 Then
                If pCrNote.InvoiceNo >= 170537 Then
                    If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                        url = "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo

                        'Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                        url = "/SPJ/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "R" Then
                        url = "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "O" Then
                        url = "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "I" Then
                        url = "/SPJ/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "E" Then
                        url = "/SPJ/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "V" Then
                        url = "/SPJ/Commercial/Preview/ExportInvoicePrintLineDetention.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "T" Then
                        url = "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    Else
                        url = "/SPJ/Commercial/Preview/ExportInvoicePrintNew.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    End If

                Else
                    If pCrNote.InvoiceNo <> 0 And pCrNote.CompanyId = 1 AndAlso pCrNote.ServiceType = "T" Then
                        url = "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo

                        'Response.Redirect("~/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "R" AndAlso pCrNote.CompanyId = 1 Then
                        url = "/SPJ/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "R" Then
                        url = "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    ElseIf pCrNote.ServiceType = "O" Then
                        url = "/SPJ/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "I" Then
                        url = "/SPJ/Commercial/Preview/ImportPrintInvoice.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                    ElseIf pCrNote.ServiceType = "T" Then
                        url = "/SPJ/Commercial/Preview/SJInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/SSRInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    Else
                        url = "/SPJ/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo
                        'Response.Redirect("~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo=" & pCrNote.InvoiceNo)
                    End If

                End If
            End If
            Dim s As String = "window.open('" & url + "', 'popup_window', 'width=800,height=800,left=100,top=100,resizable=yes');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
        Catch ex As Exception
        End Try
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
                Response.Redirect("~/Commercial/Preview/SJCrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            ElseIf Session.Item("CompanyId") = 1 Then
                Response.Redirect("~/Commercial/Preview/SJCrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            Else
                Response.Redirect("~/Commercial/Preview/CrPrintNew.aspx?InvoiceNo=" & pCreditNote.CrId)
            End If
        End If
    End Sub


    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvinvoicePending)
    End Sub

End Class
