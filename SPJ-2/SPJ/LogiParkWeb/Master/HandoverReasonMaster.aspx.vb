Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_BankMaster
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            SaveViewState()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)

        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pBankMaster As New BankMaster
        pBankMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As BankMaster In BankMaster.ReturnBankMasterList(pBankMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.BankId, obj.BankName)
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
        If textBankCode.Text.Trim <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
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
        Functions.ControlFocus(textBankCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textBankCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textBankName)
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
        If textBankCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBankCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textBankCode)
            Return rtnBool
            Exit Function
        End If
        If textBankName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBankName.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textBankName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pBankMaster As BankMaster = ReturnObject()
        If hdnBankId.Value <> Nothing Then
            BankMaster.Update(pBankMaster)
        Else
            BankMaster.Insert(pBankMaster)
        End If

        If pBankMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pBankMaster.Errormsg)
            Functions.ControlFocus(textBankCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pBankMaster.BankName, pBankMaster.BankId, hdnBankId.Value)
        hdnBankId.Value = pBankMaster.BankId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As BankMaster
        Dim p As New BankMaster
        If hdnBankId.Value <> "" AndAlso hdnBankId.Value > 0 Then
            p.BankId = hdnBankId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.BankCode = textBankCode.Text
        p.BankName = textBankName.Text
        p.BankAddress = textBankAddress.Text
        p.IfscCode = textIfscCode.Text
        p.SwiftCode = textSwift.Text
        p.AccountNo = textAccountNo.Text
        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New BankMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.BankId = pCodevalue.Value
        BankMaster.ReturnBankMaster(p)
        hdnBankId.Value = p.BankId
        textBankCode.Text = p.BankCode
        textSwift.Text = p.SwiftCode
        textBankName.Text = p.BankName
        textAccountNo.Text = p.AccountNo
        textBankAddress.Text = p.BankAddress
        textIfscCode.Text = p.IfscCode
    End Sub
End Class
