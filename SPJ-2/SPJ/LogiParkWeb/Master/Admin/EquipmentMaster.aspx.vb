Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_EquipmentMaster
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Public glEquipmentType As New ExtEquipmentType

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            fillRepeatorContainers(New ArrayList)
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If textEquipmentCode.Text.Trim <> Nothing Then
        '    btnEdit.Visible = True
        'Else
        '    btnEdit.Visible = False
        'End If
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

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        'textEquipmentCode.Enabled = pEnable
    End Sub

    Sub ListControlDataBind()
        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendor.DataSource = ExtVendorMaster.ReturnVendorMasterList(pExtVendorMaster)
        lstVendor.DataTextField = "VendorName"
        lstVendor.DataValueField = "VendorId"
        lstVendor.DataBind()
        lstVendor.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstVendor.SelectedValue = 0
    End Sub

    Sub LoadTreeViewData()
        Dim pExtEquipmentMaster As New ExtEquipmentMaster
        pExtEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As EquipmentMaster In ExtEquipmentMaster.ReturnEquipmentMasterList(pExtEquipmentMaster)
                Dim pExtVendorMaster As New ExtVendorMaster
                pExtVendorMaster.TerminalId = obj.TerminalId
                pExtVendorMaster.VendorId = obj.VendorId
                ExtVendorMaster.ReturnVendorMaster(pExtVendorMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", pExtVendorMaster.VendorId, pExtVendorMaster.VendorName)
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

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Sub fillRepeatorContainers(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New EquipmentDetails
                p.EquipmentTypeCode = "0"
                arr.Add(p)
            Next
        End If
        rpEquipment.DataSource = arr
        rpEquipment.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        hdnMode.Value = "ADD"
        Functions.ControlFocus(lstVendor)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        hdnMode.Value = "EDIT"
        manageRepControls(False)
        Functions.ControlFocus(lstVendor)
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

    Protected Sub prepareDataRepControlsList()
        Dim p As New ExtEquipmentType
        p.TerminalId = Session.Item("LoginTerminal")
        glEquipmentType.EquipmentTypeList = EquipmentType.ReturnEquipmentTypeList(p)
    End Sub

    Protected Sub prepareEquipmentType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", "0"))
            For Each CT As EquipmentType In glEquipmentType.EquipmentTypeList
                lst.Items.Add(New ListItem(CT.EquipmentTypeName, CT.EquipmentTypeCode))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub manageRepControls(ByVal pEnable As Boolean)
        lstVendor.Enabled = pEnable
        For Each rep As RepeaterItem In rpEquipment.Items
            If CType(rep.FindControl("hdnEquipmentId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnEquipmentId"), HiddenField).Value = "0" Then
                CType(rep.FindControl("lstEquipmentType"), DropDownList).Enabled = pEnable
                CType(rep.FindControl("textEquipmentNo"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textCapacity"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textCapacity"), TextBox).Text = ""
                CType(rep.FindControl("textValidFromDate"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textValidToDate"), TextBox).Enabled = pEnable
            End If
        Next
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstVendor.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor.")
            rtnBool = False
            Functions.ControlFocus(lstVendor)
            Return rtnBool
            Exit Function
        End If
        Dim isEquipmentNo As Integer = 0
        Dim isEquipmentType As Integer = 0
        If rpEquipment.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textEquipmentNo, textEquipmentNo1, textCapacity, textValidFromDate, textValidToDate As TextBox
            Dim lstEquipmentType As DropDownList
            Dim hdnEquipmentId As HiddenField
            For Each rep1 In rpEquipment.Items
                textEquipmentNo = rep1.FindControl("textEquipmentNo")
                textCapacity = rep1.FindControl("textCapacity")
                textValidFromDate = rep1.FindControl("textValidFromDate")
                textValidToDate = rep1.FindControl("textValidToDate")
                lstEquipmentType = rep1.FindControl("lstEquipmentType")
                hdnEquipmentId = rep1.FindControl("hdnEquipmentId")
                If textEquipmentNo.Text.Trim <> Nothing Then
                    If lstEquipmentType.SelectedValue = "0" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Equipment Type is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(lstEquipmentType)
                        Return rtnBool
                        Exit Function
                    End If
                    If textCapacity.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Capacity is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textCapacity)
                        Return rtnBool
                        Exit Function
                    End If
                    If textValidFromDate.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Valid From Date is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textValidFromDate)
                        Return rtnBool
                        Exit Function
                    End If
                    If textValidToDate.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Valid To Date is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textValidToDate)
                        Return rtnBool
                        Exit Function
                    End If
                    'If Date.Par("textValidFromDate.Text").ToString("dd/MM/yyyy") >= Date.Parse("textValidToDate.Text").ToString("dd/MM/yyyy") Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Valid From Date is greater than Valid To Date.")
                    '    rtnBool = False
                    '    Functions.ControlFocus(textValidToDate)
                    '    Exit Function
                    'End If
                End If
                For Each rep2 In rpEquipment.Items
                    textEquipmentNo1 = rep2.FindControl("textEquipmentNo")
                    If textEquipmentNo1.Text <> Nothing Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            isEquipmentNo += 1
                            If textEquipmentNo.Text = textEquipmentNo1.Text Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblrEquipmentNo.Text & " is Duplicate.")
                                rtnBool = False
                                Functions.ControlFocus(textEquipmentNo)
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                    End If
                Next
                Dim pEquipmentDetails As New EquipmentDetails
                pEquipmentDetails.TerminalId = Session.Item("LoginTerminal")
                For Each pED As EquipmentDetails In EquipmentDetails.ReturnEquipmentList(pEquipmentDetails)
                    If pED.EquipmentNo = textEquipmentNo.Text AndAlso pED.EquipmentId.ToString <> hdnEquipmentId.Value AndAlso pED.ValidTo >= Now.Date.ToString("dd/MM/yyyy") Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Equipment No is Allready Exist")
                        rtnBool = False
                        Functions.ControlFocus(textEquipmentNo)
                        Return rtnBool
                        Exit Function
                    End If
                Next
            Next
        End If
        If isEquipmentNo <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter  Equipment Type Details")
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtEquipmentMaster As ExtEquipmentMaster = ReturnObject()
        If pExtEquipmentMaster.EquipmentTypeDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Equipment Details.")
            Return
            Exit Sub
        End If
        If hdnMode.Value = "ADD" Then
            Dim pEquipmentMaster As New ExtEquipmentMaster
            pEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
            pEquipmentMaster.VendorId = lstVendor.SelectedValue
            ExtEquipmentMaster.ReturnEquipmentMasterByVendorId(pEquipmentMaster)
            If pEquipmentMaster.EquipRefId <= 0 Then

                ExtEquipmentMaster.InsertUpdateTransaction(pExtEquipmentMaster)
                If pExtEquipmentMaster.Errormsg <> Nothing Then
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtEquipmentMaster.Errormsg)
                    Functions.ControlFocus(lstVendor)
                    Return
                End If
                Dim pExtVendorMaster As New ExtVendorMaster
                pExtVendorMaster.TerminalId = pEquipmentMaster.TerminalId
                pExtVendorMaster.VendorId = pEquipmentMaster.VendorId
                ExtVendorMaster.ReturnVendorMaster(pExtVendorMaster)
                Functions.addOrModifyLeaf(tvTreeView, pExtVendorMaster.VendorName, pExtVendorMaster.VendorId, hdnEquipRefId.Value)
            Else
                pExtEquipmentMaster.EquipRefId = pEquipmentMaster.EquipRefId
                ExtEquipmentMaster.InsertUpdateTransactionEquipmentDetails(pExtEquipmentMaster)
            End If
        End If
        If hdnMode.Value = "EDIT" Then
            ExtEquipmentMaster.InsertUpdateTransaction(pExtEquipmentMaster)
        End If
        If pExtEquipmentMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtEquipmentMaster.Errormsg)
            Functions.ControlFocus(lstVendor)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnEquipRefId.Value = pExtEquipmentMaster.EquipRefId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ExtEquipmentMaster
        Dim pExtEquipmentMaster As New ExtEquipmentMaster
        If hdnEquipRefId.Value <> "" AndAlso hdnEquipRefId.Value > 0 Then
            pExtEquipmentMaster.EquipRefId = hdnEquipRefId.Value
        End If
        pExtEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        pExtEquipmentMaster.VendorId = lstVendor.SelectedValue
        pExtEquipmentMaster.CreatedBy = Session.Item("LoginUser")
        pExtEquipmentMaster.EquipmentTypeDetailsList = New ArrayList
        For Each rep As RepeaterItem In rpEquipment.Items
            If CType(rep.FindControl("textEquipmentNo"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textEquipmentNo"), TextBox).Text <> "" Then
                Dim pEquipmentDetails As New EquipmentDetails
                pEquipmentDetails.TerminalId = Session.Item("LoginTerminal")
                Try
                    pEquipmentDetails.EquipRefId = CType(rep.FindControl("hdnRepEquipRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pEquipmentDetails.EquipmentId = CType(rep.FindControl("hdnEquipmentId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pEquipmentDetails.EquipmentTypeCode = CType(rep.FindControl("lstEquipmentType"), DropDownList).SelectedValue
                pEquipmentDetails.EquipmentNo = CType(rep.FindControl("textEquipmentNo"), TextBox).Text
                pEquipmentDetails.Capacity = CType(rep.FindControl("textCapacity"), TextBox).Text
                pEquipmentDetails.ValidFrom = CType(rep.FindControl("textValidFromDate"), TextBox).Text
                pEquipmentDetails.ValidTo = CType(rep.FindControl("textValidToDate"), TextBox).Text
                pEquipmentDetails.CreatedBy = Session.Item("LoginUser")
                pExtEquipmentMaster.EquipmentTypeDetailsList.Add(pEquipmentDetails)
            End If
        Next
        Return pExtEquipmentMaster
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pExtEquipmentMaster As New ExtEquipmentMaster
        pExtEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        pExtEquipmentMaster.VendorId = pCodevalue.Value
        ExtEquipmentMaster.ReturnEquipmentMasterDetailsById(pExtEquipmentMaster)
        hdnEquipRefId.Value = pExtEquipmentMaster.EquipRefId
        lstVendor.SelectedValue = pExtEquipmentMaster.VendorId
        fillRepeatorContainers(pExtEquipmentMaster.EquipmentTypeDetailsList)
    End Sub
End Class


