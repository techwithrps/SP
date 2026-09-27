Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Partial Class Master_Admin_CustomerMails
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            ListControlDataBind()
            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub
    Sub ListControlDataBind()
        Dim pCustomerMaster As New CustomerMaster
        LstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
        LstCustomerName.DataTextField = "CustomerName"
        LstCustomerName.DataValueField = "CustomerId"
        LstCustomerName.DataBind()
        LstCustomerName.Items.Insert(0, (New ListItem("---Select---", 0)))
        LstCustomerName.SelectedValue = 0
        Dim pMailSetup As New MailSetup
        lstMailtype.DataSource = MailSetup.ReturnMailSetupList(pMailSetup)
        lstMailtype.DataTextField = "Subject"
        lstMailtype.DataValueField = "MenuId"
        lstMailtype.DataBind()
        lstMailtype.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstMailtype.SelectedValue = 0
    End Sub
    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            'Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pCustomerMails As New CustomerMails
        'pTaxHeadMasetr.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As CustomerMails In CustomerMails.ReturnCustomerMailsList(pCustomerMails)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.CustomerMailId, obj.CustoMername)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If LstCustomerName.SelectedValue <> 0 Then
        '    btnEdit.Visible = True
        'Else
        '    btnEdit.Visible = False
        'End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        Functions.ControlFocus(LstCustomerName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        LstCustomerName.Enabled = Not pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(LstCustomerName)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        manageUserControls(True)
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If LstCustomerName.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTaxHeadName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(LstCustomerName)
            Return rtnBool
            Exit Function
        End If
        If lstMailtype.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblMapCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstMailtype)
            Return rtnBool
            Exit Function
        End If
        'If textMapCode.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblMapCode.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textMapCode)
        '    Exit Function
        'End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pCustomerMails As CustomerMails = ReturnObject()
        If hdnmenuid.Value <> Nothing Then
            CustomerMails.Update(pCustomerMails)
        Else
            CustomerMails.Insert(pCustomerMails)
        End If

        If pCustomerMails.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCustomerMails.Errormsg)
            Functions.ControlFocus(LstCustomerName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pCustomerMails.CustoMername, pCustomerMails.CustomerMailId, hdnmenuid.Value)
        hdnmenuid.Value = pCustomerMails.CustomerMailId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As CustomerMails
        Dim p As New CustomerMails
        If hdnmenuid.Value <> "" AndAlso hdnmenuid.Value > 0 Then
            p.CustomerMailId = hdnmenuid.Value
        End If
        p.CustomerId = LstCustomerName.SelectedValue
        p.CustoMername = LstCustomerName.SelectedItem.Text
        p.MenuId = lstMailtype.SelectedValue
        p.EmailId = textmailId.Text.Trim
        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New CustomerMails
        p.CustomerMailId = pCodevalue.Value
        CustomerMails.ReturnCustomersmails(p)
        hdnmenuid.Value = p.CustomerMailId
        LstCustomerName.SelectedValue = p.CustomerId
        lstMailtype.SelectedValue = p.MenuId
        textmailId.Text = p.EmailId
    End Sub
End Class

