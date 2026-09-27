Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Setup_EmailConfigurations
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            manageUserControls(True)
            LoadTreeViewData()
            ListControlDataBind()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(textToEmailId)
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
            Session.Item("MenuId") = row(0).ToString
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
    Sub ListControlDataBind()

    End Sub

    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pdiv As New MailSetup
        pdiv.MenuId = pCodevalue.Value
        pdiv.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetupByMenuId(pdiv)
        hdnMenuId.Value = pdiv.MenuId
        textToEmailId.Text = pdiv.ToMailIds
        textCcEmailId.Text = pdiv.CcIds
        textBCcEmailId.Text = pdiv.BccIds
        textSubject.Text = pdiv.Subject
        textBody.Text = pdiv.MailBody
        textSignature.Text = pdiv.Signature

        Dim x As New MenuItemMaster
        x.MenuId = hdnMenuId.Value
        MenuItemMaster.ReturnMenuItemMaster(x)
        textTitle.Text = x.Title


    End Sub
    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pMenuItemMaster As New MenuItemMaster
        Try
            For Each obj As MenuItemMaster In MenuItemMaster.ReturnMenuItemMasterAllListEmailConfig(pMenuItemMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.MenuId, obj.Title)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnMenuId.Value.Trim <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible
        If Session.Item("Add") <> "Y" Then
            'btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        textTitle.Enabled = False
        Functions.ControlFocus(textToEmailId)
        'textServiceID.Enabled = False
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
    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnEdit)
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
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        'If textToEmailId.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textToEmailId)
        '    Exit Function
        'End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pMailSetup As MailSetup = ReturnObject()
        MailSetup.Insert(pMailSetup)
        If pMailSetup.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pMailSetup.Errormsg)
            Functions.ControlFocus(textToEmailId)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
    End Sub
    Private Function ReturnObject() As MailSetup
        Dim p As New MailSetup
        If hdnMenuId.Value <> Nothing AndAlso hdnMenuId.Value > 0 Then
            p.MenuId = hdnMenuId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.ToMailIds = textToEmailId.Text
        p.CcIds = textCcEmailId.Text
        p.BccIds = textBCcEmailId.Text
        p.Subject = textSubject.Text
        p.MailBody = textBody.Text
        p.Signature = textSignature.Text

        Return p
    End Function
End Class
