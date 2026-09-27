Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Data.DataSet

Partial Class Master_Admin_RoleCreation
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            LoadTreeViewData()
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(textRoleName)
            manageRepControls(False)
            btnEdit.Visible = True
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pExtJobMaster As New ExtJobMaster
        Try
            For Each obj As JobMaster In ExtJobMaster.ReturnJobMasterList(pExtJobMaster)
                Functions.treeViewNodeSetup(tvService, "0", obj.JobId, obj.JobName)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Overrides Function SaveViewState() As Object
        If Not tvService.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvService.SelectedNode.ValuePath
            tvService.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvService.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub
    Private Sub selectFirstNode()
        If tvService.Nodes.Count > 0 Then
            tvService.Nodes(0).Selected = True
            prepareControls(tvService.Nodes(0))
        End If
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr Is Nothing Then
            Return
        End If
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - 1
                Dim p As New JobMenuItems
                arr.Add(p)
            Next
        End If
        repRoleMaster.DataSource = arr
        repRoleMaster.DataBind()
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnRoleId.Value.Trim <> Nothing Then
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
        tvService.Enabled = False
        Dim p As New ExtJobMaster
        p.JobId = 0
        ExtJobMaster.ReturnJobMenuDetailsByJobId(p)
        fillRepeator(p.JobMenuItemsList)
        Functions.ControlFocus(textRoleName)
    End Sub
    Sub manageControls(ByRef pEnable As Boolean)
        chkBcdSelect.Enabled = pEnable
        chkBcdSelect.Checked = True
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        manageControls(True)
        manageRepControls(True)
        tvService.Enabled = False
        btnEdit.Visible = False
        'textRoleName.Enabled = False
        'Functions.ControlFocus(textRoleName)
    End Sub
    Sub manageRepControls(ByVal pEnable As Boolean)
        For Each rep As RepeaterItem In repRoleMaster.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("chkAdd"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("chkEdit"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("chkSearch"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textMenuId"), Label).Enabled = False
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        If Not tvService.SelectedNode Is Nothing Then
            prepareControls(tvService.SelectedNode)
        End If
        manageRepControls(False)
        tvService.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub tvService_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvService.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvService.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textRoleName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Role Name")
            rtnBool = False
            Functions.ControlFocus(textRoleName)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtJobMaster As ExtJobMaster = ReturnObject()

        If pExtJobMaster.JobMenuItemsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Menus are not selected.")
            Return
            Exit Sub
        End If
        ExtJobMaster.InsertUpdateJobMenuItems(pExtJobMaster)
        If pExtJobMaster.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtJobMaster.Errormsg)
            Return
        End If
        hdnRoleId.Value = pExtJobMaster.JobId
        Functions.addOrModifyLeaf(tvService, pExtJobMaster.JobName, pExtJobMaster.JobId, hdnRoleId.Value)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        tvService.Enabled = True
        MenuItemHelper.WriteMenuXml(Me.Page, lblErrorMessage)
        'Try
        '    Dim strConnectionString, cmd As String
        '    Dim con As OleDbConnection
        '    Dim ada As New OleDbDataAdapter
        '    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        '    cmd = ("SELECT DISTINCT MIM.MENU_ID, MIM.PARENT_ID, MIM.MODULE_ID, MIM.URL, MIM.TITLE, MIM.DESCRIPTION, JMI.JOB_ID, JMI.ADD_PERMIT, JMI.EDIT_PERMIT," _
        '           & " JMI.DELETE_PERMIT, JMI.SEARCH_PERMIT FROM MENU_ITEM_MASTER MIM, JOB_MENU_ITEMS JMI " _
        '           & " WHERE MIM.MENU_ID=JMI.MENU_ID ORDER BY MENU_ID")
        '    con = New OleDbConnection(strConnectionString)
        '    con.Open()
        '    ada = New OleDbDataAdapter(cmd, con)
        '    Dim ds As New Data.DataSet()
        '    ada.Fill(ds)
        '    con.Dispose()
        '    con.Close()
        '    Session.Item("MenuXml") = ds
        '    ds.WriteXml(Server.MapPath("~/MenuXml.xml"))

        'Catch ex As Exception
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, ex.Message)
        'End Try
        'ds.WriteXml(Server.MapPath("~\C:\software\JSB\eLOGiFleet\\MenuXml.xml"))
    End Sub
    Private Function ReturnObject() As ExtJobMaster
        Dim p As New ExtJobMaster
        If hdnRoleId.Value <> Nothing Then
            p.JobId = hdnRoleId.Value
        End If
        p.JobName = textRoleName.Text.Trim()

        p.JobMenuItemsList = New ArrayList

        For Each rep As RepeaterItem In repRoleMaster.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then
                Dim x As New JobMenuItems
                Try
                    x.JobId = hdnRoleId.Value
                Catch ex As Exception
                End Try

                Try
                    x.MenuId = CType(rep.FindControl("hdnMenuId"), HiddenField).Value
                Catch ex As Exception
                End Try
                If CType(rep.FindControl("chkAdd"), CheckBox).Checked = True Then
                    x.AddPermit = "Y"
                Else
                    x.AddPermit = "N"
                End If
                If CType(rep.FindControl("chkEdit"), CheckBox).Checked = True Then
                    x.EditPermit = "Y"
                Else
                    x.EditPermit = "N"
                End If
                If CType(rep.FindControl("chkSearch"), CheckBox).Checked = True Then
                    x.SearchPermit = "Y"
                Else
                    x.SearchPermit = "N"
                End If
                x.DeletePermit = "N"
                p.JobMenuItemsList.Add(x)
            End If
        Next

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ExtJobMaster
        p.JobId = pCodevalue.Value
        ExtJobMaster.ReturnJobMenuDetailsByJobId(p)

        hdnRoleId.Value = p.JobId
        textRoleName.Text = p.JobName
        fillRepeator(p.JobMenuItemsList)
    End Sub
    Protected Sub repRoleMaster_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRoleMaster.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnJobId"), HiddenField).Value > 0 Then
                CType(e.Item.FindControl("chkSelect"), CheckBox).Checked = True
            End If
            Dim x As New MenuItemMaster

            x.MenuId = CType(e.Item.FindControl("hdnMenuId"), HiddenField).Value
            MenuItemMaster.ReturnMenuItemMaster(x)
            CType(e.Item.FindControl("textMenuId"), Label).Text = x.Description
            CType(e.Item.FindControl("hdnParentId"), HiddenField).Value = x.ParentId

        End If
    End Sub
End Class
