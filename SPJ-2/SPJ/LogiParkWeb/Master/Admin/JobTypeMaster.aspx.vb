Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_JobTypeMaster
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
        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")

        lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pService)
        lstService.DataTextField = "ServiceName"
        lstService.DataValueField = "ServiceId"
        lstService.DataBind()
        lstService.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstService.SelectedValue = 0

    End Sub

    Sub LoadTreeViewData()
        Dim pJobType As New JobOrderType
        pJobType.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As JobOrderType In JobOrderType.ReturnJobOrderTypeList(pJobType)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.JoTypeId, obj.JoTypeName)
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
        Functions.ControlFocus(lstDocumentType)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(False)
        tvTreeview.Enabled = False
        textJobOrderName.Enabled = True
        lstService.Enabled = True
        Functions.ControlFocus(textJobOrderName)
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
        If textJobOrderName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblJobOrderName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textJobOrderName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool

    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pJobType As JobOrderType = ReturnObject()
        If hdnJobOrderId.Value <> Nothing Then
            JobOrderType.Update(pJobType)
        Else
            JobOrderType.Insert(pJobType)
        End If

        If pJobType.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pJobType.Errormsg)
            Functions.ControlFocus(textJobOrderName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pJobType.JoTypeCode, pJobType.JoTypeId, hdnJobOrderId.Value)
        hdnJobOrderId.Value = pJobType.JoTypeId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeview.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As JobOrderType
        Dim p As New JobOrderType
        Try
            p.JoTypeId = hdnJobOrderId.Value
        Catch ex As Exception

        End Try
        p.TerminalId = Session.Item("LoginTerminal")
        p.JoTypeCode = textJobOrderCode.Text
        p.JoTypeName = textJobOrderName.Text
        p.DocId = lstDocumentType.SelectedValue
        p.ServiceId = lstService.SelectedValue
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New JobOrderType
        p.TerminalId = Session.Item("LoginTerminal")
        p.JoTypeId = pCodevalue.Value
        JobOrderType.ReturnJobOrderType(p)
        textJobOrderCode.Text = p.JoTypeCode
        hdnJobOrderId.Value = p.JoTypeId
        textJobOrderName.Text = p.JoTypeName
        If lstService.SelectedValue = 0 Then
        Else
            lstService.SelectedValue = p.ServiceId
        End If

        Try
            lstDocumentType.SelectedValue = p.DocId
        Catch ex As Exception

        End Try

    End Sub
   
End Class
