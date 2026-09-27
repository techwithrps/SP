Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class CustomerProfileEntry
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
            ListControlDataBind()
            ButtonControlSetup(True)
            Functions.ControlFocus(textCustomerName)
        End If
    End Sub

    

    ''' <summary>
    ''' Select The First Node Of The Tree View
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pCustomerProfile As New CustomerProfile

        pCustomerProfile.ProfileId = pCodevalue.Value
        pCustomerProfile.TerminalId = Session.Item("LoginTerminal")
        CustomerProfile.ReturnCustomerProfile(pCustomerProfile)
        If pCustomerProfile.ProfileId > 0 Then
            hdnProfileId.Value = pCustomerProfile.ProfileId
        End If
        textCustomerName.Text = pCustomerProfile.CustomerName
        lstCompanyType.SelectedValue = pCustomerProfile.CompanyType
        textBusiness.Text = pCustomerProfile.Business
        textTurnOver.Text = pCustomerProfile.TurnOver
        textCompanyAge.Text = pCustomerProfile.CompanyAge
        lstTransportMode.SelectedValue = pCustomerProfile.TransportMode
        textTransportCost.Text = pCustomerProfile.TransportCost
        'textNetWorth.Text = pCustomerProfile.NetWorth
        textEstReveune.Text = pCustomerProfile.EstRevenue
        textContactPerson.Text = pCustomerProfile.ContactPerson
        textContactNo.Text = pCustomerProfile.ContactNumber
        textEmailId.Text = pCustomerProfile.EmailId
        textAddress.Text = pCustomerProfile.Address
        textRemarks.Text = pCustomerProfile.Remarks
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pCustomerProfile As New CustomerProfile
        pCustomerProfile.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As CustomerProfile In CustomerProfile.ReturnCustomerProfileList(pCustomerProfile)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.ProfileId, obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
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
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnProfileId.Value.Trim <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = False
        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            'btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()
        'Dim pTerminalOwner As New TerminalOwner
        'lstRakeOwner.DataSource = TerminalOwner.ReturnTerminalOwnerList(pTerminalOwner)
        'lstRakeOwner.DataTextField = "OwnerName"
        'lstRakeOwner.DataValueField = "OwnerId"
        'lstRakeOwner.DataBind()

        'Dim p As New TerminalOperator
        'lstOperator.DataSource = TerminalOperator.ReturnTerminalOperatorList(p)
        'lstOperator.DataTextField = "OperatorName"
        'lstOperator.DataValueField = "OperatorId"
        'lstOperator.DataBind()

        'Dim pTerminalType As New TerminalType
        'lstBaseDepo.DataSource = TerminalType.ReturnTerminalTypeList(pTerminalType)
        'lstBaseDepo.DataTextField = "TypeName"
        'lstBaseDepo.DataValueField = "TypeId"
        'lstBaseDepo.DataBind()
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textCustomerName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomerName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomerName)
            Return rtnBool
            Exit Function
        End If
        If textBusiness.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBusiness.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textBusiness)
            Return rtnBool
            Exit Function
        End If
        If textTurnOver.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTurnOver.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTurnOver)
            Return rtnBool
            Exit Function
        End If
        If textCompanyAge.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCompanyAge.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCompanyAge)
            Return rtnBool
            Exit Function
        End If
        If textEstReveune.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEstReveune.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEstReveune)
            Return rtnBool
            Exit Function
        End If
        If textContactPerson.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContactPerson.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContactPerson)
            Return rtnBool
            Exit Function
        End If
        If textContactNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContactNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContactNo)
            Return rtnBool
            Exit Function
        End If
        If textEmailId.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEmailId.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEmailId)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pCustomerProfile As CustomerProfile = ReturnObject()
        If pCustomerProfile.ProfileId > 0 Then
            CustomerProfile.Update(pCustomerProfile)
        Else
            CustomerProfile.Insert(pCustomerProfile)
        End If
        If pCustomerProfile.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCustomerProfile.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnProfileId.Value = pCustomerProfile.ProfileId

        Dim strMsg As String = Nothing
        strMsg = SendMail(pCustomerProfile)
        If strMsg <> Nothing Then
            'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, strMsg)
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        End If

        tvTreeView.Nodes.Clear()
        LoadTreeViewData()
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
    End Sub

    Function SendMail(ByVal pCustomerProfile As CustomerProfile) As String
        Dim pStr As String = ""
        'Dim pMailConfig As New MailConfig
        'MailConfig.ReturnMailConfig(pMailConfig)

        'Dim xMailSetup As New MailSetup
        'xMailSetup.MenuId = Session.Item("MenuId")
        'xMailSetup.TerminalId = 0
        'MailSetup.ReturnMailSetup(xMailSetup)

        ''    xMailSetup.ToMailIds &= "," & pCustomerProfile.EmailId

        'xMailSetup.MailBody &= "<br/>"
        'xMailSetup.MailBody &= " " & "<br/>"
        'xMailSetup.MailBody &= " Profile Id :- " & pCustomerProfile.ProfileId & "<br/>"
        'xMailSetup.MailBody &= " Profile Name :- " & pCustomerProfile.CustomerName & "<br/>"
        'xMailSetup.MailBody &= " Address :- " & pCustomerProfile.Address & "<br/>"
        'xMailSetup.MailBody &= " Business :- " & pCustomerProfile.Business & "<br/>"
        'xMailSetup.MailBody &= " Turn Over :- " & pCustomerProfile.TurnOver & "Cr." & "<br/>"
        'xMailSetup.MailBody &= " Projected Volume :- " & pCustomerProfile.NetWorth & "<br/>"
        'xMailSetup.MailBody &= " Projected Revenue :- " & pCustomerProfile.EstRevenue & "<br/>"
        'xMailSetup.MailBody &= " Contact Person :- " & pCustomerProfile.ContactPerson & "<br/>"
        'xMailSetup.MailBody &= " Contact No :- " & pCustomerProfile.ContactNumber & "<br/>"
        'xMailSetup.MailBody &= " Email Id :- " & pCustomerProfile.EmailId & "<br/>"

        'xMailSetup.MailBody &= " " & "<br/>"
        'xMailSetup.MailBody &= " " & "<br/>"


        'xMailSetup.MailBody &= " Thanks & Regards " & "<br/>"
        'Dim p As New CompanyMaster
        'CompanyMaster.ReturnCompanyMaster(p)
        'xMailSetup.MailBody &= p.CompanyName & "<br/>"


        'pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvControl.Controls)
        tvTreeView.Enabled = False
        Functions.ControlFocus(textCustomerName)
    End Sub

    Private Function ReturnObject() As CustomerProfile
        Dim pCustomerProfile As New CustomerProfile
        If hdnProfileId.Value.Trim <> Nothing Then
            pCustomerProfile.ProfileId = hdnProfileId.Value
        End If
        pCustomerProfile.TerminalId = Session.Item("LoginTerminal")
        pCustomerProfile.CustomerName = textCustomerName.Text
        pCustomerProfile.CompanyType = lstCompanyType.SelectedValue
        pCustomerProfile.Business = textBusiness.Text
        pCustomerProfile.TurnOver = textTurnOver.Text
        pCustomerProfile.CompanyAge = textCompanyAge.Text
        pCustomerProfile.TransportMode = lstTransportMode.SelectedValue
        If textTransportCost.Text = "" Then
            pCustomerProfile.TransportCost = 0
        Else
            pCustomerProfile.TransportCost = textTransportCost.Text
        End If

        'pCustomerProfile.NetWorth = textNetWorth.Text
        If textEstReveune.Text = "" Then
            pCustomerProfile.EstRevenue = 0
        Else
            pCustomerProfile.EstRevenue = textEstReveune.Text
        End If

        pCustomerProfile.ContactPerson = textContactPerson.Text
        pCustomerProfile.ContactNumber = textContactNo.Text
        pCustomerProfile.EmailId = textEmailId.Text
        pCustomerProfile.Address = textAddress.Text
        pCustomerProfile.Remarks = textRemarks.Text
        pCustomerProfile.CreatedBy = Session.Item("LoginUser")
        Try

        Catch ex As Exception
        End Try
        Return pCustomerProfile
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        selectFirstNode()
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        Functions.ControlFocus(textCustomerName)
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
End Class
