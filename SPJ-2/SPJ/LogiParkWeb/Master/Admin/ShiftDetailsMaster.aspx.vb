Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_ShiftDetailsMaster
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
        Dim pShiftDetailsMaster As New ShiftDetailsMaster
        pShiftDetailsMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ShiftDetailsMaster In ShiftDetailsMaster.ReturnShiftDetailsMasterList(pShiftDetailsMaster)
                Dim strp As String
                strp = obj.ShiftNo & " (" & obj.StartHrs & ":" & obj.StartMin & " - " & obj.EndHrs & ":" & obj.EndMin & ")"
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ShiftId, strp)
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
        If textShiftNo.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textShiftNo)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textShiftNo.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textStartHour)
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
        If textShiftNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblShiftNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textShiftNo)
            Return rtnBool
            Exit Function
        End If
        If textStartHour.Text.Trim = Nothing AndAlso textStartMinuts.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblStartTime.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textStartHour)
            Return rtnBool
            Exit Function
        End If
        If textEndHour.Text.Trim = Nothing AndAlso textEndMinuts.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEndTime.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEndHour)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pShiftDetailsMaster As ShiftDetailsMaster = ReturnObject()
        If hdnShiftId.Value <> Nothing Then
            ShiftDetailsMaster.Update(pShiftDetailsMaster)
        Else
            ShiftDetailsMaster.Insert(pShiftDetailsMaster)
        End If

        If pShiftDetailsMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pShiftDetailsMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Dim strp As String
        strp = pShiftDetailsMaster.ShiftNo & " (" & pShiftDetailsMaster.StartHrs & ":" & pShiftDetailsMaster.StartMin & " - " & pShiftDetailsMaster.EndHrs & ":" & pShiftDetailsMaster.EndMin & ")"
        Functions.addOrModifyLeaf(tvTreeView, strp, pShiftDetailsMaster.ShiftId, hdnShiftId.Value)
        hdnShiftId.Value = pShiftDetailsMaster.ShiftId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As ShiftDetailsMaster
        Dim p As New ShiftDetailsMaster
        If hdnShiftId.Value <> "" AndAlso hdnShiftId.Value > 0 Then
            p.ShiftId = hdnShiftId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.ShiftNo = textShiftNo.Text
        p.StartHrs = textStartHour.Text
        p.StartMin = textStartMinuts.Text
        p.EndHrs = textEndHour.Text
        p.EndMin = textEndMinuts.Text
        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ShiftDetailsMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.ShiftId = pCodevalue.Value
        ShiftDetailsMaster.ReturnShiftDetailsMaster(p)
        hdnShiftId.Value = p.ShiftId
        textShiftNo.Text = p.ShiftNo
        textStartHour.Text = p.StartHrs
        textStartMinuts.Text = p.StartMin
        textEndHour.Text = p.EndHrs
        textEndMinuts.Text = p.EndMin
    End Sub
End Class
