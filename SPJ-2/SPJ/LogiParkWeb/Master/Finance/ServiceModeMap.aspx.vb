Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Public Class Finance_ServiceModeMap
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDateBind()
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnEdit)
        End If
    End Sub
   
    

    Sub ListControlDateBind()
        Dim pServiceMode As New ServiceMode
        pServiceMode.TerminalId = Session.Item("LoginTerminal")
        lstServiceMode.DataSource = ServiceMode.ReturnServiceModeList(pServiceMode)
        lstServiceMode.DataTextField = "ModeName"
        lstServiceMode.DataValueField = "ModeId"
        lstServiceMode.DataBind()
        lstServiceMode.Items.Insert(0, (New ListItem("----Select----", "0")))
        lstServiceMode.Enabled = True
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New ServiceMaster
                ' p.TaxHeadId = "0"
                arr.Add(p)
            Next
        End If
        repService.DataSource = arr
        repService.DataBind()
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pExtServiceType As New ServiceType
        pExtServiceType.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ServiceType In ServiceType.ReturnServiceTypeList(pExtServiceType)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ServiceTypeCode, obj.ServiceTypeName)
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
            tvTreeView.Nodes(2).Selected = True
            Dim p As New ServiceMaster
            p.TerminalId = Session.Item("LoginTerminal")
            p.ServiceTypeCode = tvTreeView.SelectedValue
            lstServiceMode.SelectedValue = "2"
            hdnServiceMode.Value = tvTreeView.SelectedValue
            fillRepeator(ServiceMaster.ReturnServiceMasterListByType(p))
            textServiceType.Text = tvTreeView.SelectedNode.Text

            ButtonControlSetup(False)
        End If
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnEdit.Visible = pVisible

        btnExit.Visible = pVisible
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        
        If Session.Item("Add") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageUserControls(False)
        textServiceType.Enabled = False
        Functions.ControlFocus(lstServiceMode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        lstServiceMode.Enabled = Not pEnable
        For Each r As RepeaterItem In repService.Items
            If CType(r.FindControl("hdnModeId"), HiddenField).Value > 0 Then
                CType(r.FindControl("chkSelect"), CheckBox).Enabled = False
            Else
                CType(r.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            End If
        Next
    End Sub

  
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            'prepareControls(tvTreeView.SelectedNode)
            selectFirstNode()
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
        SaveViewState()
        manageUserControls(True)
        prepareControls(tvTreeView.SelectedNode)
        tvTreeView.Enabled = False
        lstServiceMode.Enabled = True
        Functions.ControlFocus(lstServiceMode)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstServiceMode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblServiceMode.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstServiceMode)
            Return rtnBool
            Exit Function
        End If
        
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ValidationCheck() = False Then
            Return
        End If
        Dim pServiceMode As ServiceMode = ReturnObject()


        If pServiceMode.ServiceModeMapList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " Select Service.")
            repService.Items(0).Focus()
            Exit Sub
        End If

        ServiceMode.InsertUpdateDetails(pServiceMode)

        If pServiceMode.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pServiceMode.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnEdit)
    End Sub

    Private Function ReturnObject() As ServiceMode
        Dim p As New ServiceMode
        p.TerminalId = Session.Item("LoginTerminal")
        p.ModeId = lstServiceMode.SelectedValue
        p.ModeCode = lstServiceMode.SelectedValue
        p.ServiceModeMapList = New ArrayList
        For Each rep As RepeaterItem In repService.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True AndAlso CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True _
            AndAlso CType(rep.FindControl("hdnServiceId"), HiddenField).Value > 0 Then
                Dim pdet As New ServiceModeMap
                pdet.TerminalId = Session.Item("LoginTerminal")
                Try
                    pdet.ModeId = lstServiceMode.SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pdet.ServiceId = CType(rep.FindControl("hdnServiceId"), HiddenField).Value
                Catch ex As Exception
                End Try
                'Try
                '    pdet.ServiceTypeCode = CType(rep.FindControl("hdnServiceMode"), HiddenField).Value
                'Catch ex As Exception
                'End Try
                Try
                    If pdet.ModeId = "1" Then
                        pdet.ServiceMode = "A"
                    ElseIf pdet.ModeId = "2" Then
                        pdet.ServiceMode = "F"
                    ElseIf pdet.ModeId = "3" Then
                        pdet.ServiceMode = "T"
                    ElseIf pdet.ModeId = "4" Then
                        pdet.ServiceMode = "C"
                    ElseIf pdet.ModeId = "5" Then
                        pdet.ServiceMode = "M"
                    End If
                Catch ex As Exception
                End Try
                p.ServiceModeMapList.Add(pdet)
            End If
        Next

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        hdnServiceMode.Value = pCodevalue.Value
        lstServiceMode.Enabled = True
        textServiceType.Text = tvTreeView.SelectedNode.Text
        Functions.ControlFocus(lstServiceMode)
    End Sub


    Protected Sub lstServiceMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstServiceMode.SelectedIndexChanged
        If lstServiceMode.SelectedValue <> "0" Then
            Dim p As New ServiceMaster
            p.TerminalId = Session.Item("LoginTerminal")
            p.ServiceTypeCode = tvTreeView.SelectedValue
            fillRepeator(ServiceMaster.ReturnServiceMasterListByType(p))
            ButtonControlSetup(False)
        End If
    End Sub

    Protected Sub repService_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repService.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value <> "0" Then
                Dim p As New ServiceModeMap
                p.TerminalId = Session.Item("LoginTerminal")
                p.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value

                ' p.ServiceTypeCode = CType(e.Item.FindControl("hdnServiceMode"), HiddenField).Value
             
                p.ModeId = lstServiceMode.SelectedValue
                ServiceModeMap.ReturnServiceModeMap(p)
                CType(e.Item.FindControl("textServiceName"), TextBox).Enabled = False
                If p.ServiceTypeCode <> "" AndAlso p.ServiceTypeCode <> Nothing Then
                    CType(e.Item.FindControl("chkSelect"), CheckBox).Checked = True
                    CType(e.Item.FindControl("chkSelect"), CheckBox).Enabled = True
                End If
            End If
        End If
    End Sub
End Class