Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_TerminalMaster
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 10
    Sub ListControlDataBind()
        Try
            Dim pUserTerminal As New UserTerminal
            pUserTerminal.UserId = Session.Item("LoginUser")
            LstTerminalGroup.DataSource = UserTerminal.ReturnUserTerminalListAssigned(pUserTerminal)
            LstTerminalGroup.DataTextField = "UserId"
            LstTerminalGroup.DataValueField = "TerminalId"
            LstTerminalGroup.DataBind()
            LstTerminalGroup.Items.Insert(0, (New ListItem("---Select---", "0")))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            LoadTreeViewData()
            fillRepeator(New ArrayList)
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            btnAdd.Visible = True
            btnEdit.Visible = True
            btnSave.Visible = True
        End If
        btnAdd.Visible = True
            btnEdit.Visible = True
            btnSave.Visible = True
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pTerminalMaster As New TerminalMaster
        Try
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.TerminalId, obj.TerminalName)

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
    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New TerminalLocationMaster
                arr.Add(p)
            Next

        End If
        repLocation.DataSource = arr
        repLocation.DataBind()
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textTerminalCode.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textTerminalCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textTerminalCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textTerminalName)
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
        If textTerminalCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTerminalCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTerminalCode)
            Return rtnBool
            Exit Function
        End If
        If textTerminalName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTerminalName.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTerminalName)
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
        If lstCountry.SelectedValue.Trim = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCountry.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstCountry)
            Return rtnBool
            Exit Function
        End If
        If textServiceTaxNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblServiceTaxNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textServiceTaxNo)
            Return rtnBool
            Exit Function
        End If
       
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pTerminalMaster As TerminalMaster = ReturnObject()
       
        TerminalMaster.InsertUpdateTerminalMaster(pTerminalMaster)

        If pTerminalMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pTerminalMaster.Errormsg)
            Functions.ControlFocus(textTerminalCode)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pTerminalMaster.TerminalName, pTerminalMaster.TerminalId, hdnTerminalId.Value)
        hdnTerminalId.Value = pTerminalMaster.TerminalId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub

    Private Function ReturnObject() As TerminalMaster
        Dim p As New TerminalMaster
        If hdnTerminalId.Value <> "" AndAlso hdnTerminalId.Value > 0 Then
            p.TerminalId = hdnTerminalId.Value
        End If
        'p.TerminalId = Session.Item("LoginTerminal")
        p.TerminalCode = textTerminalCode.Text
        p.TerminalName = textTerminalName.Text
        p.Address = textAddress.Text
        p.Country = lstCountry.SelectedValue
        p.ContactPerson = textContactPerson.Text
        p.EmailId = textEmailId.Text
        p.ContactNo = textContactNo.Text
        p.ServiceTaxNo = textServiceTaxNo.Text
        p.GroupTerminal = LstTerminalGroup.SelectedValue
        If textExportCartingRate.Text.Trim <> Nothing Then
            p.CartingRate = Double.Parse(textExportCartingRate.Text)
        Else
            p.CartingRate = 0
        End If
        If textExportCartingMinWt.Text.Trim <> Nothing Then
            p.MinimumCartingWt = Double.Parse(textExportCartingMinWt.Text)
        Else
            p.MinimumCartingWt = 0
        End If

        p.CreatedBy = Session.Item("LoginUser")
        p.TerminalLocationList = New ArrayList
        For Each rep As RepeaterItem In repLocation.Items
            If CType(rep.FindControl("textLocation"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textLocation"), TextBox).Text <> "" Then
                Dim pTerminalLocation As New TerminalLocationMaster
                Try
                    pTerminalLocation.LocationId = CType(rep.FindControl("hdnLocationId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pTerminalLocation.LocationName = CType(rep.FindControl("textLocation"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pTerminalLocation.Distance = CType(rep.FindControl("textDistance"), TextBox).Text
                Catch ex As Exception
                End Try
                pTerminalLocation.CreatedBy = Session.Item("LoginUser")
                p.TerminalLocationList.Add(pTerminalLocation)
            End If
        Next
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New TerminalMaster
        'p.TerminalId = Session.Item("LoginTerminal")
        p.TerminalId = pCodevalue.Value
        TerminalMaster.ReturnTerminalMaster(p)
        hdnTerminalId.Value = p.TerminalId
        textTerminalCode.Text = p.TerminalCode
        textTerminalName.Text = p.TerminalName
        textAddress.Text = p.Address
        Try
            lstCountry.SelectedValue = p.Country
        Catch ex As Exception

        End Try
        Try
            LstTerminalGroup.SelectedValue = p.GroupTerminal
        Catch ex As Exception

        End Try
        textContactPerson.Text = p.ContactPerson
        textEmailId.Text = p.EmailId
        textContactNo.Text = p.ContactNo
        textServiceTaxNo.Text = p.ServiceTaxNo

        textExportCartingRate.Text = p.CartingRate
        textExportCartingMinWt.Text = p.MinimumCartingWt
        Dim pTLMaster As New TerminalLocationMaster
        pTLMaster.TerminalId = p.TerminalId
        Dim arr As New ArrayList
        arr = TerminalLocationMaster.ReturnTerminalLocationMasterList(pTLMaster)
        If arr.Count >= ROWS Then
            ROWS = (arr.Count + 5)
        End If
        fillRepeator(arr)
    End Sub
End Class
