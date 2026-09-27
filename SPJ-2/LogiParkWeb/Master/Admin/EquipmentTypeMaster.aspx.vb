Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports LogiParkLib.DBConnection
Partial Class Master_EquipmentTypeMaster
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'ListControlDataBind()
            manageUserControls(True)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            btnAdd.Visible = True
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

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textEquipmenyName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEquipmenyName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEquipmenyName)
            Return rtnBool
            Exit Function
        End If
        If TextEquipmentCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEquipmentCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(TextEquipmentCode)
            Return rtnBool
            Exit Function
        End If

        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pEquipmentType As EquipmentType = ReturnObject()
        If hdnTaxHeadID.Value <> Nothing Then
            EquipmentType.Update(pEquipmentType)
        Else
            EquipmentType.Insert(pEquipmentType)
        End If
        If pEquipmentType.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pEquipmentType.Errormsg)
            Functions.ControlFocus(textEquipmenyName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")

        'Functions.addOrModifyLeaf(tvTreeView, pTireMaster.TireNo, pTireMaster.TireId, hdnTyreId.Value)
        'hdnTyreId.Value = pTireMaster.TireId
        ButtonControlSetup(True)
        manageUserControls(True)
        ' tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If textTireNo.Text.Trim <> Nothing Then
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
    Private Function ReturnObject() As EquipmentType
        Dim pEquipmentType As New EquipmentType
        pEquipmentType.TerminalId = Session.Item("LoginTerminal")
        pEquipmentType.EquipmentTypeCode = TextEquipmentCode.Text.Trim
        pEquipmentType.EquipmentTypeName = textEquipmenyName.Text.Trim
        Return pEquipmentType
    End Function
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New EquipmentType
        p.TerminalId = Session.Item("LoginTerminal")
        p.EquipmentTypeCode = pCodevalue.Value
        EquipmentType.ReturnEquipmentTypeCode(p)
        TextEquipmentCode.Text = p.EquipmentTypeCode
        textEquipmenyName.Text = p.EquipmentTypeName
    End Sub
    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnEdit.Visible = True

    End Sub
    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        ' tvTreeView.Enabled = False
        Functions.ControlFocus(TextEquipmentCode)
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        'tvTreeView.Enabled = False
        'manageControls(False)
        Functions.ControlFocus(TextEquipmentCode)
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'If Not tvTreeView.SelectedNode Is Nothing Then
        '    prepareControls(tvTreeView.SelectedNode)
        'End If
        manageUserControls(True)
        'tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub
    Sub LoadTreeViewData()
        Dim pEquipmentType As New EquipmentType
        pEquipmentType.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As EquipmentType In EquipmentType.ReturnEquipmentTypeList(pEquipmentType)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.EquipmentTypeCode, obj.EquipmentTypeName)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
