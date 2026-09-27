Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_PortMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
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
 

        Dim pCountryMaster As New CountryMaster

        lstCountry.DataSource = CountryMaster.ReturnCountryMasterList()
        lstCountry.DataTextField = "CountryName"
        lstCountry.DataValueField = "CountryId"
        lstCountry.DataBind()
        lstCountry.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstCountry.SelectedValue = 0


    End Sub

    Sub LoadTreeViewData()
        Dim pPortMaster As New PortMaster
        pPortMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As PortMaster In PortMaster.ReturnPortMasterList(pPortMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.PortId, obj.PortName)
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
        If textPortCode.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textPortCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textPortCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textPortName)
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
        If textPortCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPortCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPortCode)
            Return rtnBool
            Exit Function
        End If
        If textPortName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPortName.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPortName)
            Return rtnBool
            Exit Function
        End If
        If lstCountry.selectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCountry.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstCountry)
            Return rtnBool
            Exit Function
        End If
        If textAddress.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblAddress.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textAddress)
            Return rtnBool
            Exit Function
        End If
        If textCustomRefImport.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomRefImport.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomRefImport)
            Return rtnBool
            Exit Function
        End If
        If textCustomRefExport.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomRefExport.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomRefExport)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pPortMaster As PortMaster = ReturnObject()
        If hdnPortId.Value <> Nothing Then
            PortMaster.Update(pPortMaster)
        Else
            PortMaster.Insert(pPortMaster)
        End If
        If pPortMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pPortMaster.Errormsg)
            Functions.ControlFocus(textPortCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pPortMaster.PortName, pPortMaster.PortId, hdnPortId.Value)
        hdnPortId.Value = pPortMaster.PortId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As PortMaster
        Dim p As New PortMaster
        If hdnPortId.Value <> "" AndAlso hdnPortId.Value > 0 Then
            p.PortId = hdnPortId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.PortCode = textPortCode.Text
        p.PortName = textPortName.Text
        p.Address = textAddress.Text
        p.CountryId = lstCountry.SelectedValue
        p.ImpCustRef = textCustomRefImport.Text
        p.ExpCustRef = textCustomRefExport.Text
        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New PortMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.PortId = pCodevalue.Value
        PortMaster.ReturnPortMaster(p)
        hdnPortId.Value = p.PortId
        textPortCode.Text = p.PortCode
        textPortName.Text = p.PortName
        lstCountry.SelectedValue = p.CountryId
        textAddress.Text = p.Address
        textCustomRefImport.Text = p.ImpCustRef
        textCustomRefExport.Text = p.ExpCustRef
    End Sub
End Class
