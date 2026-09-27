Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Finance_UOMMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pUomMasetr As New UomMaster
        pUomMasetr.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As UomMaster In UomMaster.ReturnUomMasterList(pUomMasetr)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.UomId, obj.UomName)
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
        If textUOMName.Text.Trim <> Nothing Then
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
        textUOMCode.Enabled = False
        Functions.ControlFocus(textUOMName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textUOMName.Enabled = Not pEnable

    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        textUOMCode.Enabled = False
        Functions.ControlFocus(textUOMName)
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
        textUOMCode.Enabled = False
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
        'If textUOMCode.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, textUOMCode.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textUOMCode)
        '    Exit Function
        'End If
        If textUOMName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblUOMName.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textUOMName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pUomMaster As UomMaster = ReturnObject()
        If hdnUOMId.Value <> Nothing Then
            UomMaster.Update(pUomMaster)
        Else
            UomMaster.Insert(pUomMaster)
        End If

        If pUomMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pUomMaster.Errormsg)
            Functions.ControlFocus(textUOMName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pUomMaster.UomName, pUomMaster.UomId, hdnUOMId.Value)
        hdnUOMId.Value = pUomMaster.UomId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
        textUOMCode.Enabled = False
    End Sub

    Private Function ReturnObject() As UomMaster
        Dim p As New UomMaster
        If hdnUOMId.Value <> "" AndAlso hdnUOMId.Value > 0 Then
            p.UomId = hdnUOMId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        'p.UomId = textUOMCode.Text
        p.UomName = textUOMName.Text
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New UomMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.UomId = pCodevalue.Value
        UomMaster.ReturnUomMaster(p)
        hdnUOMId.Value = p.UomId
        textUOMCode.Text = p.UomId
        textUOMName.Text = p.UomName
    End Sub
End Class
