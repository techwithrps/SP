Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Fleet_ItemMaster
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
        Dim pItemMaster As New ItemMaster
        pItemMaster.TerminalId = 1
        Try
            For Each obj As ItemMaster In ItemMaster.ReturnItemMasterList(pItemMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ItemId, obj.ItemName)
            Next
        Catch ex As Exception
        End Try
        Dim pItemGroup As New ItemGroupMaster
        pItemGroup.TerminalId = Session.Item("LoginTerminal")
        lstItemGroup.DataSource = ItemGroupMaster.ReturnItemGroupMasterList(pItemGroup)
        lstItemGroup.DataTextField = "ItemGroupName"
        lstItemGroup.DataValueField = "ItemGroupId"
        lstItemGroup.DataBind()
        lstItemGroup.Items.Insert(0, (New ListItem("---Select---", "0")))
        lstItemGroup.SelectedValue = 0
       
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
        If textPackageCode.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textPackageCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textPackageCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textPackageName)
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
        If textPackageCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPackageCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPackageCode)
            Return rtnBool
            Exit Function
        End If
        If lstItemGroup.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblItemGroup.Text & " is Blank.")
            rtnBool = False
            Return rtnBool
            Functions.ControlFocus(lstItemGroup)
            Exit Function
        End If
        If textPackageName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPackageName.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPackageName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pItemMaster As ItemMaster = ReturnObject()
        If hdnPackageId.Value <> Nothing Then
            ItemMaster.Update(pItemMaster)
        Else
            ItemMaster.Insert(pItemMaster)
        End If

        If pItemMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pItemMaster.Errormsg)
            Functions.ControlFocus(textPackageCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pItemMaster.ItemName, pItemMaster.ItemId, hdnPackageId.Value)
        hdnPackageId.Value = pItemMaster.ItemId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As ItemMaster
        Dim p As New ItemMaster
        If hdnPackageId.Value <> "" AndAlso hdnPackageId.Value > 0 Then
            p.ItemId = hdnPackageId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.ItemCode = textPackageCode.Text
        p.ItemName = textPackageName.Text
		p.CreatedBy = Session.Item("LoginUser")
		p.ItemCost = textItemCost.Text
        p.ItemCostValidity = textItemCostValidity.Text
        p.ItemGroup = lstItemGroup.SelectedValue
     

		Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ItemMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.ItemId = pCodevalue.Value
        ItemMaster.ReturnItemMaster(p)
        hdnPackageId.Value = p.ItemId
        textPackageCode.Text = p.ItemCode
		textPackageName.Text = p.ItemName
		textItemCost.Text = p.ItemCost
        textItemCostValidity.Text = p.ItemCostValidity
        lstItemGroup.SelectedValue = p.ItemGroup
	End Sub
End Class
