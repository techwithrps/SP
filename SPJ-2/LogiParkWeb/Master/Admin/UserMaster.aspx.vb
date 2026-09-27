Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_UserMaster
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            LoadTreeViewData()
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(textUserId)
        End If
    End Sub

    Sub LoadTreeViewData()
        Dim pUm As New ExtUserMaster
        Try
            For Each obj As UserMaster In ExtUserMaster.ReturnUserMasterList(pUm)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.UserId, obj.UserId)
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

    Sub prepareControls(ByVal PCode As TreeNode)
        Dim p As New ExtUserMaster
        p.UserId = PCode.Value
        p.UserName = textUserName.Text
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserId(p)

        hdnUserId.Value = p.UserId
        textUserId.Text = p.UserId
        textUserName.Text = p.UserName
        textEmailId.Text = p.EmailId
        textRestrictedIP.Text = p.RestrictedIp
        textPassexpirydays.Text = p.PasswordExpiry
        textMAC.Text = p.MACAddress

        hdnPassword.Value = p.Password
        If Not String.IsNullOrEmpty(p.Password) Then
            textPassword.Text = "********"
        Else
            textPassword.Text = String.Empty
        End If
        Try
            lstDepartment.SelectedValue = p.DepartmentId
        Catch ex As Exception

        End Try
        Try
            lstDesignation.SelectedValue = p.DesignationId
        Catch ex As Exception

        End Try
        Try
            lstUserType.SelectedValue = p.UserType
        Catch ex As Exception

        End Try

        If p.UserStatus = "Y" Then
            chkUserStatus.Checked = True
        Else
            chkUserStatus.Checked = False
        End If

        fillRepeatorRole(p.RoleList)
        fillRepeatorTerminal(p.TerminalList)
        fillRepeatorCompany(p.CompanyList)
        fillRepeatorUser(p.UserList)
    End Sub

    Private Sub fillRepeatorRole(ByVal arr As ArrayList)
        'If arr.Count < ROWS Then
        '    For i As Integer = 0 To ROWS - 1
        '        Dim p As New UserJobs
        '        arr.Add(p)
        '    Next
        'End If
        repRole.DataSource = arr
        repRole.DataBind()
    End Sub

    Private Sub fillRepeatorTerminal(ByVal arr As ArrayList)
        'If arr.Count < ROWS Then
        '    For i As Integer = 0 To ROWS - 1
        '        Dim p As New UserTerminal
        '        arr.Add(p)
        '    Next
        'End If
        repTerminal.DataSource = arr
        repTerminal.DataBind()
    End Sub
    Private Sub fillRepeatorCompany(ByVal arr As ArrayList)
        'If arr.Count < rows Then
        '    For i As Integer = 0 To rows - 1
        '        Dim p As New UserCompany
        '        arr.Add(p)
        '    Next
        'End If
        repCompany.DataSource = arr
        repCompany.DataBind()
    End Sub
    Private Sub fillRepeatorUser(ByVal arr As ArrayList)
        'If arr.Count < rows Then
        '    For i As Integer = 0 To rows - 1
        '        Dim p As New UsersMapping
        '        arr.Add(p)
        '    Next
        'End If
        repUser.DataSource = arr
        repUser.DataBind()
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
        btnExit.Visible = pVisible
        If hdnUserId.Value.Trim <> Nothing AndAlso hdnUserId.Value <> "0" Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then
            ' btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub


    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If textUserId.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the user id")
            rtnBool = False
            Functions.ControlFocus(textUserId)
            Exit Function
        End If
        If textPassword.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the password")
            rtnBool = False
            Functions.ControlFocus(textPassword)
            Exit Function
        End If
        If textUserName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the user name.")
            rtnBool = False
            Functions.ControlFocus(textUserName)
            Exit Function
        End If

        Dim intCount As Long = 0
        For Each rep As RepeaterItem In repRole.Items
            If CType(rep.FindControl("chkRole"), CheckBox).Checked = True Then
                intCount += 1
            End If
        Next
        If intCount <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select One Role")
            rtnBool = False
            Functions.ControlFocus(textUserName)
            Exit Function
        End If
        If intCount > 1 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Only One Role Should be Selected.")
            rtnBool = False
            Functions.ControlFocus(textUserName)
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtUserMaster As ExtUserMaster = ReturnObject()
        If pExtUserMaster.RoleList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No role are selected for user")
            Return
            Exit Sub
        End If
        If pExtUserMaster.TerminalList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Branch are selected for user")
            Return
            Exit Sub
        End If
        If pExtUserMaster.CompanyList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Company are selected for user")
            Return
            Exit Sub
        End If
        ExtUserMaster.InsertUpdateUserMaster(pExtUserMaster)
        If pExtUserMaster.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtUserMaster.Errormsg)
            Return
        End If
        hdnUserId.Value = pExtUserMaster.UserId
        Functions.addOrModifyLeaf(tvTreeView, pExtUserMaster.UserId, pExtUserMaster.UserId, hdnUserId.Value)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
    End Sub

    Function ReturnObject() As ExtUserMaster
        Dim pExtUserMaster As New ExtUserMaster
        If hdnUserId.Value.Trim <> Nothing Then
            pExtUserMaster.UserId = hdnUserId.Value
        Else
            pExtUserMaster.UserId = textUserId.Text.Trim
        End If
        pExtUserMaster.UserName = textUserName.Text
        If String.IsNullOrEmpty(hdnPassword.Value) Then
            pExtUserMaster.Password = textPassword.Text
        End If
        If textPassword.Text <> "********" AndAlso Not String.IsNullOrEmpty(hdnPassword.Value) Then
            pExtUserMaster.Password = textPassword.Text
        End If
        If textPassword.Text = "********" AndAlso Not String.IsNullOrEmpty(hdnPassword.Value) Then
            pExtUserMaster.Password = hdnPassword.Value
        End If


        'If pExtUserMaster.Password = Nothing Then
        '    pExtUserMaster.Password = textPassword.Text
        'Else
        '    pExtUserMaster.Password = hdnPassword.Value
        'End If


        'pExtUserMaster.Password = textPassword.Text
        pExtUserMaster.EmailId = textEmailId.Text
        pExtUserMaster.DepartmentId = lstDepartment.SelectedValue
        pExtUserMaster.DesignationId = lstDesignation.SelectedValue
        pExtUserMaster.UserType = lstUserType.SelectedValue
        pExtUserMaster.RestrictedIp = textRestrictedIP.Text
        Try
            pExtUserMaster.MACAddress = textMAC.Text
        Catch ex As Exception

        End Try
        If textPassexpirydays.Text = "" Then
            pExtUserMaster.PasswordExpiry = 0

        Else

            pExtUserMaster.PasswordExpiry = textPassexpirydays.Text

        End If

        If chkUserStatus.Checked Then
            pExtUserMaster.UserStatus = "Y"
        Else
            pExtUserMaster.UserStatus = ""
        End If

        pExtUserMaster.TerminalList = New ArrayList
        pExtUserMaster.RoleList = New ArrayList
        pExtUserMaster.CompanyList = New ArrayList
        pExtUserMaster.UserList = New ArrayList
        For Each rep As RepeaterItem In repUser.Items
            If CType(rep.FindControl("chkUsers"), CheckBox).Checked = True Then
                Dim x As New UsersMapping
                Try
                    x.UserId = hdnUserId.Value
                Catch ex As Exception
                End Try

                Try
                    x.MappedUser = CType(rep.FindControl("hdnMapUserId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    x.CompanyId = Session.Item("CompanyId")
                Catch ex As Exception
                End Try
                pExtUserMaster.UserList.Add(x)
            End If
        Next
        For Each rep As RepeaterItem In repCompany.Items
            If CType(rep.FindControl("chkCompany"), CheckBox).Checked = True Then
                Dim x As New UserCompany
                Try
                    x.UserId = hdnUserId.Value
                Catch ex As Exception
                End Try

                Try
                    x.CompanyId = CType(rep.FindControl("hdnCompanyId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pExtUserMaster.CompanyList.Add(x)
            End If
        Next

        For Each rep As RepeaterItem In repTerminal.Items
            If CType(rep.FindControl("chkTerminal"), CheckBox).Checked = True Then
                Dim x As New UserTerminal
                Try
                    x.UserId = hdnUserId.Value
                Catch ex As Exception
                End Try

                Try
                    x.TerminalId = CType(rep.FindControl("hdnTerminalId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pExtUserMaster.TerminalList.Add(x)
            End If
        Next

        For Each rep As RepeaterItem In repRole.Items
            If CType(rep.FindControl("chkRole"), CheckBox).Checked = True Then
                Dim x As New UserJobs
                Try
                    x.UserId = hdnUserId.Value
                Catch ex As Exception
                End Try

                Try
                    x.JobId = CType(rep.FindControl("hdnJobId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pExtUserMaster.RoleList.Add(x)
            End If
        Next
        Return pExtUserMaster
    End Function

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textUserName.Enabled = pEnable
        textPassword.Enabled = pEnable
        lstDepartment.Enabled = pEnable
        lstDesignation.Enabled = pEnable
        textEmailId.Enabled = pEnable
        lstUserType.Enabled = pEnable
        textRestrictedIP.Enabled = pEnable
        textPassexpirydays.Enabled = pEnable
        chkTerminal.Enabled = pEnable
        chkUserStatus.Enabled = pEnable
        textMAC.Enabled = pEnable
        textUserId.Enabled = False
    End Sub

    Sub manageRepetorControl(ByRef pEnable As Boolean)
        For Each rep As RepeaterItem In repRole.Items
            CType(rep.FindControl("chkRole"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textJobName"), Label).Enabled = False
        Next

        For Each rep As RepeaterItem In repTerminal.Items
            CType(rep.FindControl("chkTerminal"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textTerminalName"), Label).Enabled = False
        Next
        For Each rep As RepeaterItem In repCompany.Items
            CType(rep.FindControl("chkCompany"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textCompanyName"), Label).Enabled = False
        Next
        For Each rep As RepeaterItem In repUser.Items
            CType(rep.FindControl("chkUsers"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textUser"), Label).Enabled = False
        Next
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        manageRepetorControl(False)
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(False)
        manageControls(True)
        manageRepetorControl(True)
        tvTreeView.Enabled = False
        btnEdit.Visible = False
        If Not String.IsNullOrEmpty(hdnPassword.Value) Then
            textPassword.Text = "********"
        End If
    End Sub

    Protected Sub repRole_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRole.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnUserId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnUserId"), HiddenField).Value <> "0" Then
                CType(e.Item.FindControl("chkRole"), CheckBox).Checked = True
            End If
            Dim x As New ExtJobMaster

            x.JobId = CType(e.Item.FindControl("hdnJobid"), HiddenField).Value
            ExtJobMaster.ReturnJobMaster(x)
            CType(e.Item.FindControl("textJobName"), Label).Text = x.JobName
        End If
    End Sub

    Protected Sub repTerminal_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repTerminal.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnUserId"), HiddenField).Value <> Nothing Then
                CType(e.Item.FindControl("chkTerminal"), CheckBox).Checked = True
            End If
            Dim x As New TerminalMaster

            x.TerminalId = CType(e.Item.FindControl("hdnTerminalId"), HiddenField).Value
            TerminalMaster.ReturnTerminalMaster(x)
            CType(e.Item.FindControl("textTerminalName"), Label).Text = x.TerminalName
        End If
    End Sub
    Protected Sub repCompany_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repCompany.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnCompnayUserId"), HiddenField).Value <> Nothing Then
                CType(e.Item.FindControl("chkCompany"), CheckBox).Checked = True
            End If
            Dim x As New CompanyMaster
            x.CompanyId = CType(e.Item.FindControl("hdnCompanyId"), HiddenField).Value
            CompanyMaster.ReturnCompanyMasterbyId(x)
            CType(e.Item.FindControl("textCompanyName"), Label).Text = x.CompanyName
        End If
    End Sub
    Protected Sub repUser_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repUser.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnMappUser"), HiddenField).Value <> Nothing Then
                CType(e.Item.FindControl("chkUsers"), CheckBox).Checked = True
            End If
            Dim x As New UserMaster

            x.UserId = CType(e.Item.FindControl("hdnMapUserId"), HiddenField).Value
            UserMaster.ReturnUserMaster(x)
            CType(e.Item.FindControl("textUser"), Label).Text = x.UserName

        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvControl.Controls)
        tvTreeView.Enabled = False

        Dim p As New ExtUserMaster
        p.UserId = ""
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserId(p)

        fillRepeatorRole(p.RoleList)
        fillRepeatorTerminal(p.TerminalList)
        fillRepeatorCompany(p.CompanyList)
        fillRepeatorUser(p.UserList)
        ButtonControlSetup(False)
        Functions.ControlFocus(textUserId)
        'textPassword.TextMode = TextBoxMode.Password
    End Sub

    Protected Sub tvService_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
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

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub
End Class
