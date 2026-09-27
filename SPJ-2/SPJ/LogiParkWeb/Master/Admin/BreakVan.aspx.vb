Imports LogiParkLib.LogiParkObjects
Imports System.Data.OleDb
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_BreakVan
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            manageUserControls(True)
            ListControlDataBind()
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(textBreakVanNo)
        End If
    End Sub

    

    ''' <summary>
    ''' Select The First Node Of The Tree View
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        ListControlDataBind()
        Dim pBreakVanMaster As New BreakVanMaster
        pBreakVanMaster.BVId = pCodevalue.Value
        BreakVanMaster.ReturnBreakVanMaster(pBreakVanMaster)
        If pBreakVanMaster.BVNo <> Nothing Then
            hdnBreakVanId.Value = pBreakVanMaster.BVId
        End If
        textBreakVanNo.Text = pBreakVanMaster.BVNo
        lstOwner.SelectedValue = pBreakVanMaster.BVOwner
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pBreakVanMaster As New BreakVanMaster
        Try
            For Each obj As BreakVanMaster In BreakVanMaster.ReturnBreakVanMasterList(pBreakVanMaster)
                ' Functions.treeViewNodeSetup(tvTreeView, "0", obj.WagonId, obj.WagonNumber)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.BVId, obj.BVNo)
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnBreakVanId.Value.Trim <> Nothing Then
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

        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()
        Dim pTerminalOwner As New TerminalOwner
        lstOwner.DataSource = TerminalOwner.ReturnTerminalOwnerList(pTerminalOwner)
        lstOwner.DataTextField = "OwnerName"
        lstOwner.DataValueField = "OwnerId"
        lstOwner.DataBind()
        lstOwner.Items.Add(New ListItem("---Select---", "0"))
        'lstOwner.SelectedValue = 0
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If textBreakVanNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBreakVanNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textBreakVanNo)
            Return rtnBool
            Exit Function
        End If
        If lstOwner.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBreakVanOwner.Text & " not selected.")
            rtnBool = False
            Functions.ControlFocus(lstOwner)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pBreakVanMaster As BreakVanMaster = ReturnObject()

        If pBreakVanMaster.BVId > 0 Then
            BreakVanMaster.Update(pBreakVanMaster)
        Else
            BreakVanMaster.Insert(pBreakVanMaster)
        End If

        If pBreakVanMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pBreakVanMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pBreakVanMaster.BVNo, pBreakVanMaster.BVId, hdnBreakVanId.Value)
        hdnBreakVanId.Value = pBreakVanMaster.BVId
        Dim x As New TreeNode
        x.Value = hdnBreakVanId.Value
        prepareControls(x)
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvControl.Controls)
        tvTreeView.Enabled = False
        'lstRakeID.Enabled = False
        Functions.ControlFocus(textBreakVanNo)
    End Sub

    Private Function ReturnObject() As BreakVanMaster
        Dim pbreakVanMaster As New BreakVanMaster
        If hdnBreakVanId.Value.Trim <> Nothing Then
            pbreakVanMaster.BVId = hdnBreakVanId.Value
        End If
        pbreakVanMaster.BVNo = textBreakVanNo.Text
        pbreakVanMaster.BVOwner = lstOwner.SelectedValue
        pbreakVanMaster.CreatedBy = Session.Item("LoginUser")
        Return pbreakVanMaster
    End Function
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        selectFirstNode()
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        lstOwner.Enabled = True
        Functions.ControlFocus(lstOwner)

    End Sub
    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ''Save Selected Path in viewstate
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            ''Expand all noed of treeview
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function
    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
End Class
