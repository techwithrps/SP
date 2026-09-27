Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Public Class Master_Admin_ItemGroup
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
            btnAdd.Visible = True
            btnEdit.Visible = True
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


    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pItemGroupMaster As New ItemGroupMaster
        pItemGroupMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ItemGroupMaster In ItemGroupMaster.ReturnItemGroupMasterList(pItemGroupMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ItemGroupId, obj.ItemGroupName)
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
        If textItemGroupName.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textItemGroupName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textItemGroupName.Enabled = Not pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textItemGroupName)
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
        If textItemGroupName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTaxHeadName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textItemGroupName)
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
        Dim pItemGroupMaster As ItemGroupMaster = ReturnObject()
        If hdnTaxHeadID.Value <> Nothing Then
            ItemGroupMaster.Update(pItemGroupMaster)
        Else
            ItemGroupMaster.Insert(pItemGroupMaster)
        End If

        If pItemGroupMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pItemGroupMaster.Errormsg)
            Functions.ControlFocus(textItemGroupName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pItemGroupMaster.ItemGroupName, pItemGroupMaster.ItemGroupId, hdnTaxHeadID.Value)
        hdnTaxHeadID.Value = pItemGroupMaster.ItemGroupId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ItemGroupMaster
        Dim p As New ItemGroupMaster
        If hdnTaxHeadID.Value <> "" AndAlso hdnTaxHeadID.Value > 0 Then
            p.ItemGroupId = hdnTaxHeadID.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.ItemGroupName = textItemGroupName.Text
        p.MapCode = textMapCode.Text
        p.CreatedBy = Session.Item("LoginUser")

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ItemGroupMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.ItemGroupId = pCodevalue.Value
        ItemGroupMaster.ReturnItemMaster(p)
        hdnTaxHeadID.Value = p.ItemGroupId
        textItemGroupName.Text = p.ItemGroupName
        textMapCode.Text = p.MapCode
    End Sub
End Class
