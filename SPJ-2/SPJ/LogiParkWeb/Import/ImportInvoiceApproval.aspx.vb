Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data.OleDb
Imports System.Net.WebClient

Partial Class Import_ImportInvoiceApproval
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim ROW As Integer = 5
    Dim count As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            'DeleteVoucher()
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= ",'" & Session.Item("CompanyId") & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVOICE_APP_IMP", strpParms)
            repIndentDetails.DataSource = dbr
            repIndentDetails.DataBind()

            ButtonControlSetup(False)
        End If
    End Sub
    Sub Permission(ByVal P As String)
        Dim PMI As New MenuItemMaster
        PMI.Url = P
        MenuItemMaster.ReturnMenuItemMasterByURL(PMI)
        Session.Item("Title") = PMI.Title
        Dim pJMI As New JobMenuItems
        pJMI.JobId = Session.Item("JobId")
        pJMI.MenuId = PMI.MenuId
        JobMenuItems.ReturnJobMenuItems(pJMI)

        Session.Item("Add") = pJMI.AddPermit
        Session.Item("Edit") = pJMI.EditPermit
        Session.Item("Search") = pJMI.SearchPermit
        Session.Item("Delete") = pJMI.DeletePermit
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub



    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            ' btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Sub ledger()


    End Sub
    Private Function SalesVoucher(ByVal x As String) As String

        ' Dim pNarration As String = text.Text

        If count = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Plese Select Details.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        End If
        ButtonControlSetup(True)
        Return x
    End Function
    Protected Sub Approve(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, Button)).NamingContainer, RepeaterItem)
        Dim btn = CType(item.FindControl("btnApprove"), Button)
        Dim btnInvoice = CType(item.FindControl("hdnInvoiceId"), HiddenField).Value
        Dim invRefNo = btn.Text
        Dim InvoiceNo = btnInvoice.Trim
        'If btnInvoice.Trim > 0 Then
        '    ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/ExportInvoicePrint.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

        '    Dim lnk As LinkButton = CType(sender, LinkButton)
        '    '  Response.Redirect("~/Commercial/CreditNote.aspx?CrNo=" & lnk.Text)

        Dim pInvoice As New ImpInvoice
        pInvoice.InvoiceRefNo = btn.Text
        ImpInvoice.ReturnImpInvoiceByInvoiceRefNo(pInvoice)
        If pInvoice.InvoiceNo <> 0 And pInvoice.CompanyId = 1 AndAlso pInvoice.ServiceType = "T" Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SJInvoicePrint.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pInvoice.ServiceType = "R" AndAlso pInvoice.CompanyId = 1 Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SJSSRInvoicePrint.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pInvoice.ServiceType = "R" Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SSRInvoicePrint.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pInvoice.ServiceType = "X" Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/RexportPrintInvoice.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pInvoice.ServiceType = "F" And pInvoice.TerminalId = 51 Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/RexportPrintInvoice.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf pInvoice.ServiceType = "I" Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/ImportPrintInvoice.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/ExportInvoicePrint.aspx?InvoiceNo=" & btnInvoice.Trim & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        For Each rc As RepeaterItem In repIndentDetails.Items
            Dim Status As String = ""
            If CType(rc.FindControl("chkIndent"), CheckBox).Checked = True Then

                Dim Pinv As New ImpInvoice
                Pinv.TerminalId = Session.Item("LoginTerminal")
                Pinv.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                ImpInvoice.ReturnImpInvoiceByInvoiceNo(Pinv)

                Dim pImpInvoice As New ImpInvoice
                pImpInvoice.InvoiceNo = Pinv.InvoiceNo
                ImpInvoice.ReturnImpInvoiceTallyNarationByInvoiceNo(pImpInvoice)
                Dim Invoice_Id As Integer = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                count = count + 1
                Dim strConnectionString, cmd2 As String
                Dim con As OleDbConnection
                Try
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd2 = "UPDATE IMP_INVOICE SET PRINT_STATUS='Y', APPROVAL_ON=SYSDATE,APPROVAL_BY='" & Session.Item("LoginUser") & "'  WHERE  INVOICE_NO=  " & Invoice_Id
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd5 As New OleDbCommand(cmd2, con)
                    cmd5.ExecuteNonQuery()
                Catch ex As Exception
                End Try
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Approved Successfully")
                '      lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, Status)

                '  Return

            End If
        Next
        Try
            Dim strpParms1 As String = ""
            strpParms1 &= Session.Item("LoginTerminal")
            strpParms1 &= ",'" & Session.Item("CompanyId") & "'"

            Dim dbr1 As OleDb.OleDbDataReader
            Dim db1 As New DBConnect
            dbr1 = db1.StoredProcedureReadDB("REPORT_PKG.SP_INVOICE_APPROVAL", strpParms1)
            repIndentDetails.DataSource = dbr1
            repIndentDetails.DataBind()
        Catch ex As Exception

        End Try

        'Dim strpParms As String = ""
        'strpParms &= Session.Item("LoginTerminal")
        'Dim dbr As OleDb.OleDbDataReader
        'Dim db As New DBConnect
        'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_INVOICE_APPROVAL", strpParms)
        'repIndentDetails.DataSource = dbr
        'repIndentDetails.DataBind()


    End Sub
    Private Function ExtractString(ByVal s As String, ByVal start As String, ByVal [end] As String) As String
        ' You should check for errors in real-world code, omitted for brevity

        Dim startIndex As Integer = s.IndexOf(start) + start.Length
        Dim endIndex As Integer = s.IndexOf([end], startIndex)
        Try

            Return s.Substring(100, endIndex - 100)

        Catch ex As Exception

        End Try
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class

