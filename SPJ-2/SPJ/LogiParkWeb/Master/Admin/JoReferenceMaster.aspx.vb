Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_JoReferenceMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
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
    Sub ListControlDataBind()
        Dim pModule As New ModuleMaster

        lstModuleId.DataSource = ModuleMaster.ReturnModuleMasterList(pModule)
        lstModuleId.DataTextField = "ModuleName"
        lstModuleId.DataValueField = "ModuleId"
        lstModuleId.DataBind()
        lstModuleId.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstModuleId.SelectedValue = 0

    End Sub

    Sub LoadTreeViewData()
        Dim pJobRef As New JoReferences
        pJobRef.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As JoReferences In JoReferences.ReturnJoReferencesList(pJobRef)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.RefKeyId, obj.JoCode)
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
    Sub manageControls(ByRef pEnable As Boolean)
        textJobOrderCode.Enabled = pEnable
        textJODescription.Enabled = pEnable
        textReferenceStart.Enabled = pEnable
        textReferenceLength.Enabled = pEnable
        textReferenceEnd.Enabled = pEnable
        lstModuleId.Enabled = pEnable
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textJobOrderCode.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textJobOrderCode)
    End Sub

  

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        manageControls(False)
        tvTreeView.Enabled = False
        textJobOrderCode.Enabled = False
        Functions.ControlFocus(textJODescription)
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

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeview.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textJobOrderCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblJobOrderCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textJobOrderCode)
            Return rtnBool
            Exit Function
        End If
        If textJODescription.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblJODescription.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textJODescription)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool

    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pJobRef As JoReferences = ReturnObject()
        If hdnReferenceKeyId.Value <> Nothing Then
            JoReferences.Update(pJobRef)
            'Else
            '    JoReferences.Insert(pJobRef)
        End If

        If pJobRef.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pJobRef.Errormsg)
            Functions.ControlFocus(textJobOrderCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pJobRef.JoCode, pJobRef.RefKeyId, hdnReferenceKeyId.Value)
        hdnJobOrderId.Value = pJobRef.RefKeyId
        hdnReferenceKeyId.Value = pJobRef.RefKeyId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeview.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As JoReferences
        Dim p As New JoReferences
        Try
            p.RefKeyId = hdnReferenceKeyId.Value
            p.JoId = hdnJobOrderId.Value
        Catch ex As Exception

        End Try
        p.TerminalId = Session.Item("LoginTerminal")
        p.JoCode = textJobOrderCode.Text
        p.JoDescription = textJODescription.Text
        p.RefLength = textReferenceLength.Text
        p.RefEnd = textReferenceEnd.Text
        p.RefNo = textReferenceNumber.Text
        p.ModuleId = lstModuleId.SelectedValue
        p.RefStart = textReferenceStart.Text
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New JoReferences
        p.TerminalId = Session.Item("LoginTerminal")
        p.RefKeyId = pCodevalue.Value
        JoReferences.ReturnJoReferences(p)
        textJobOrderCode.Text = p.JoCode
        hdnJobOrderId.Value = p.JoId
        hdnReferenceKeyId.Value = p.RefKeyId
        textJODescription.Text = p.JoDescription
        textReferenceStart.Text = p.RefStart
        textReferenceEnd.Text = p.RefEnd
        textReferenceNumber.Text = p.RefNo
        lstModuleId.SelectedValue = p.ModuleId
        textReferenceLength.Text = p.RefLength
    End Sub
End Class
