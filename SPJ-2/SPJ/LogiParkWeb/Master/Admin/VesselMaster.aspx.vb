Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_VesselMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeview.Enabled = True
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
        Dim pVesselMaster As New VesselMaster
        pVesselMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As VesselMaster In VesselMaster.ReturnVesselMasterList(pVesselMaster)
                Functions.treeViewNodeSetup(tvTreeview, "0", obj.VesselId, obj.VesselName)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeview.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeview.SelectedNode.ValuePath
            tvTreeview.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeview.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvTreeview.Nodes.Count > 0 Then
            tvTreeview.Nodes(0).Selected = True
            prepareControls(tvTreeview.Nodes(0))
        End If
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textVesselCode.Text.Trim <> Nothing Then
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
        tvTreeview.Enabled = False
        Functions.ControlFocus(textVesselCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textVesselCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeview.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textVesselName)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeview.SelectedNode Is Nothing Then
            prepareControls(tvTreeview.SelectedNode)
        End If
        manageUserControls(True)
        tvTreeview.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeview.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeview.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textVesselCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblVesselCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textVesselCode)
            Return rtnBool
            Exit Function
        End If
        If textVesselName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, textVesselName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textVesselName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool

    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pVesselMaster As VesselMaster = ReturnObject()
        If hdnVesselId.Value <> Nothing AndAlso hdnVesselId.Value > 0 Then
            VesselMaster.Update(pVesselMaster)
        Else
            VesselMaster.Insert(pVesselMaster)
        End If

        If pVesselMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pVesselMaster.Errormsg)
            Functions.ControlFocus(textVesselCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeview, pVesselMaster.VesselName, pVesselMaster.VesselId, hdnVesselId.Value)
        hdnVesselId.Value = pVesselMaster.VesselId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeview.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As VesselMaster
        Dim p As New VesselMaster
        Try
            p.VesselId = hdnVesselId.Value
        Catch ex As Exception
        End Try
        p.TerminalId = Session.Item("LoginTerminal")
        p.VesselCode = textVesselCode.Text
        p.VesselName = textVesselName.Text
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New VesselMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.VesselId = pCodevalue.Value
        VesselMaster.ReturnVesselMasterByID(p)
        textVesselCode.Text = p.VesselCode
        hdnVesselId.Value = p.VesselId
        textVesselName.Text = p.VesselName
    End Sub

End Class
