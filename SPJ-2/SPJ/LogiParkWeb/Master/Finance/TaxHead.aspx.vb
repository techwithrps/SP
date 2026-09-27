Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Public Class Finance_TaxHead
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
        Dim pTaxHeadMasetr As New TaxHeadMaster
        pTaxHeadMasetr.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As TaxHeadMaster In TaxHeadMaster.ReturnTaxHeadMasterList(pTaxHeadMasetr)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.TaxHeadId, obj.TaxHeadName)
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
        If textTaxHeadName.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textTaxHeadName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textTaxHeadName.Enabled = Not pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textTaxHeadName)
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
        If textTaxHeadName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTaxHeadName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTaxHeadName)
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
        Dim pTaxHeadMaster As TaxHeadMaster = ReturnObject()
        If hdnTaxHeadID.Value <> Nothing Then
            TaxHeadMaster.Update(pTaxHeadMaster)
        Else
            TaxHeadMaster.Insert(pTaxHeadMaster)
        End If

        If pTaxHeadMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pTaxHeadMaster.Errormsg)
            Functions.ControlFocus(textTaxHeadName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pTaxHeadMaster.TaxHeadName, pTaxHeadMaster.TaxHeadId, hdnTaxHeadID.Value)
        hdnTaxHeadID.Value = pTaxHeadMaster.TaxHeadId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As TaxHeadMaster
        Dim p As New TaxHeadMaster
        If hdnTaxHeadID.Value <> "" AndAlso hdnTaxHeadID.Value > 0 Then
            p.TaxHeadId = hdnTaxHeadID.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.TaxHeadName = textTaxHeadName.Text
        p.MapCode = textMapCode.Text
        p.CreatedBy = Session.Item("LoginUser")

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New TaxHeadMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.TaxHeadId = pCodevalue.Value
        TaxHeadMaster.ReturnTaxHeadMaster(p)
        hdnTaxHeadID.Value = p.TaxHeadId
        textTaxHeadName.Text = p.TaxHeadName
        textMapCode.Text = p.MapCode
    End Sub
End Class
