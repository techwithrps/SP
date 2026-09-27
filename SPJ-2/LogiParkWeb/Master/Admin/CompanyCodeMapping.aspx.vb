Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_CompanyCodeMapping
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            manageUserControls(True)
            manageControls(True)
            ButtonControlSetup(False)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textCompanyName.Text.Trim <> Nothing Then
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

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - 1
                Dim p As New DivisionMaster
                arr.Add(p)
            Next
        End If
        repCompanyMapping.DataSource = arr
        repCompanyMapping.DataBind()
    End Sub

    Sub ListControlDataBind()
        Dim pCompanyMaster As New CompanyMaster
        CompanyMaster.ReturnCompanyMasterSearch(pCompanyMaster)
        textCompanyName.Text = pCompanyMaster.CompanyName
        hdnCompanyCode.Value = pCompanyMaster.CompanyCode
        Dim pDivisionMaster As New DivisionMaster
        pDivisionMaster.TerminalId = Session.Item("LoginTerminal")
        fillRepeator(DivisionMaster.ReturnDivisionMasterList(pDivisionMaster))
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(True)
        ListControlDataBind()
        manageControls(True)
        Functions.ControlFocus(textCompanyName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        For Each rep As RepeaterItem In repCompanyMapping.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
        Next
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(False)
        manageControls(True)
        Functions.ControlFocus(textCompanyName)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ListControlDataBind()
        manageUserControls(True)
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True

        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtCompanyCodeMapping As ExtCompanyCodeMapping = ReturnObject()
        If pExtCompanyCodeMapping.CompanyCodeMappingList.Count <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Division Name")
            Return
        End If

        ExtCompanyCodeMapping.InsertUpdateCompanyCodeMapping(pExtCompanyCodeMapping)

        If pExtCompanyCodeMapping.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtCompanyCodeMapping.Errormsg)
            Functions.ControlFocus(textCompanyName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnMappingId.Value = pExtCompanyCodeMapping.MappingId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ExtCompanyCodeMapping
        Dim pExtCompanyCodeMapping As New ExtCompanyCodeMapping
        pExtCompanyCodeMapping.CompanyCodeMappingList = New ArrayList
        For Each rep As RepeaterItem In repCompanyMapping.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True AndAlso CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True _
               AndAlso CType(rep.FindControl("textDivisionName"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textDivisionName"), TextBox).Text <> "" Then
                Dim p As New ExtCompanyCodeMapping
                'If hdnMappingId.Value <> "" AndAlso hdnMappingId.Value > 0 Then
                '    pExtCompanyCodeMapping.MappingId = hdnMappingId.Value
                'End If
                p.TerminalId = Session.Item("LoginTerminal")
                p.CompanyCode = hdnCompanyCode.Value
                p.CreatedBy = Session.Item("LoginUser")
                p.UpdatedBy = Session.Item("LoginUser")
                p.DivisionId = CType(rep.FindControl("hdnDivisionId"), HiddenField).Value
                pExtCompanyCodeMapping.CompanyCodeMappingList.Add(p)
            End If
        Next
        Return pExtCompanyCodeMapping
    End Function

    Protected Sub repCompanyMapping_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repCompanyMapping.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            If CType(e.Item.FindControl("hdnDivisionId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("textDivisionName"), TextBox).Text <> "" Then
                'Dim p As New ExpCartingJo
                'p.TerminalId = pExtCommodityMaster.TerminalId
                'p.CartingJoId = CType(e.Item.FindControl("hdnCartingJoId"), HiddenField).Value
                'ExtExpCartingJo.ReturnExpCartingJoByCartingJoId_CartingJoNo(p)
                'CType(e.Item.FindControl("textJONo"), TextBox).Text = p.CartingJoNo
                'CType(e.Item.FindControl("textJODate"), TextBox).Text = p.CartingJoDate
                'CType(e.Item.FindControl("textJoValidity"), TextBox).Text = p.CartingJoValidity
                'CType(e.Item.FindControl("chkSelect"), CheckBox).Enabled = False
                CType(e.Item.FindControl("chkSelect"), CheckBox).Checked = True
            Else
                CType(e.Item.FindControl("chkSelect"), CheckBox).Enabled = False
            End If
        End If

    End Sub

End Class
