Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_VendorMaster
    Inherits System.Web.UI.Page
    Dim rows As Integer = 7
    Dim arrTdsCode As ArrayList
    Dim arrTdsName As ArrayList
    Public glVendorType As New ExtVendorType

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        prepareTdsData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            fillRepeator(New ArrayList)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(textVendorName)
        End If
    End Sub

    Sub prepareTdsData()
        Try
            arrTdsCode = New ArrayList
            arrTdsName = New ArrayList
            Dim pTdsMaster As New TdsMaster

            For Each obj As TdsMaster In TdsMaster.ReturnTdsMasterList(pTdsMaster)
                arrTdsCode.Add(obj.TdsCode)
                arrTdsName.Add(obj.TdsDescription)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub prepareTds(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", ""))
            For i As Integer = 0 To arrTdsCode.Count - 1
                lst.Items.Add(New ListItem(arrTdsName(i), arrTdsCode(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub ListControlDataBind()
        Dim pBankMaster As New BankMaster
        pBankMaster.TerminalId = Session.Item("LoginTerminal")

        lstBankName.DataSource = BankMaster.ReturnBankMasterList(pBankMaster)
        lstBankName.DataTextField = "BankName"
        lstBankName.DataValueField = "BankCode"
        lstBankName.DataBind()
        lstBankName.Items.Insert(0, (New ListItem("----Select----", "0")))
        Dim pCountry As New CountryMaster
        lstCountry.DataSource = CountryMaster.ReturnCountryMasterList()
        lstCountry.DataTextField = "CountryName"
        lstCountry.DataValueField = "CountryId"
        lstCountry.DataBind()
        lstCountry.Items.Insert(0, (New ListItem("----Select----", "0")))


        Dim pStateCodeMaster As New StateCodeMaster
        lstState.DataSource = StateCodeMaster.ReturnStateList(pStateCodeMaster)
        lstState.DataTextField = "StateName"
        lstState.DataValueField = "StateCode"
        lstState.DataBind()
        lstState.Items.Add(New ListItem("----Select----", "0"))
        lstState.SelectedValue = "0"
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As VendorMaster In ExtVendorMaster.ReturnVendorMasterListAll(pExtVendorMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.VendorCode, obj.VendorName)
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

    Protected Sub prepareDataRepControlsList()
        Dim p As New ExtVendorType
        p.TerminalId = Session.Item("LoginTerminal")
        glVendorType.VendeorTypeList = VendorType.ReturnVendorTypeList(p)
    End Sub

    Protected Sub prepareVendorType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each CT As VendorType In glVendorType.VendeorTypeList
                lst.Items.Add(New ListItem(CT.VendorTypeName, CT.VendorTypeCode))
            Next
        Catch ex As Exception
        End Try
    End Sub

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
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New VendorTypeDetails
                p.VenderTypeCode = "0"
                arr.Add(p)
            Next
        End If
        RepVendor.DataSource = arr
        RepVendor.DataBind()
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textVendorCode.Text.Trim <> Nothing Then
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
        manageControls(False)
        Functions.ControlFocus(textVendorName)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textVendorCode.Enabled = False
        'textCreditLimit.Enabled = pEnable
        'textCreditPeriod.Enabled = pEnable

    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        manageRepControls(True)
        Functions.ControlFocus(textVendorName)
    End Sub

    Sub manageRepControls(ByVal pEnable As Boolean)
        For Each rep As RepeaterItem In RepVendor.Items
            If CType(rep.FindControl("hdnVendorKeyId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnVendorKeyId"), HiddenField).Value > 0 Then
                CType(rep.FindControl("lstVendorType"), DropDownList).Enabled = False
            End If
        Next
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
        If textVendorName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblVendorName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textVendorName)
            Return rtnBool
            Exit Function
        End If

        If textAddress.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblAddress.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textAddress)
            Return rtnBool
            Exit Function
        End If
        If textZipCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblZipCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textZipCode)
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

    

        Dim isVendorType As Integer = 0
        If RepVendor.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim lstVendorType, lstVendorType1 As DropDownList
            Dim chkImport, chkExport, chkDomestic As CheckBox

            For Each rep1 In RepVendor.Items
                lstVendorType = rep1.FindControl("lstVendorType")
                chkImport = rep1.FindControl("chkImport")
                chkExport = rep1.FindControl("chkExport")
                chkDomestic = rep1.FindControl("chkDomestic")
                If lstVendorType.SelectedValue > "0" Then
                If chkImport.Checked = False AndAlso chkExport.Checked = False AndAlso chkDomestic.Checked = False  Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Customer should be allowed either Import, Export, Domestic or All.")
                    rtnBool = False
                    Functions.ControlFocus(chkImport)
                    Return rtnBool
                    Exit Function
                End If
                 End If
                For Each rep2 In RepVendor.Items
                    lstVendorType1 = rep2.FindControl("lstVendorType")
                    If lstVendorType1.SelectedValue <> "0" Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            isVendorType += 1
                            If lstVendorType.SelectedValue = lstVendorType1.SelectedValue Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblVendorType.Text & " is Duplicate.")
                                rtnBool = False
                                Functions.ControlFocus(lstVendorType)
                                Return rtnBool
                                Exit Function
                            End If
                        End If

                    End If
                Next
            Next
        End If
        If isVendorType <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The vendor Type Details")
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
        Dim pExtVendorMaster As ExtVendorMaster = ReturnObject()
        ExtVendorMaster.InsertUpdateTransaction(pExtVendorMaster)

        If pExtVendorMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtVendorMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pExtVendorMaster.VendorName, pExtVendorMaster.VendorId, hdnVendorId.Value)
        hdnVendorId.Value = pExtVendorMaster.VendorId
        textVendorCode.Text = pExtVendorMaster.VendorCode
        'ExtVendorMaster.ReturnvMasterDetailsById(pExtVendorMaster)
        fillRepeator(pExtVendorMaster.VendorTypeDetailsList)
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ExtVendorMaster
        Dim p As New ExtVendorMaster
        If hdnVendorId.Value <> "" AndAlso hdnVendorId.Value > 0 Then
            p.VendorId = hdnVendorId.Value
        End If
        p.VendorCode = textVendorCode.Text
        p.VendorName = textVendorName.Text
        p.Address = textAddress.Text
        ' p.City = textCity.Text
        p.PinCode = textZipCode.Text
        'p.State = textState.Text
        p.Country = lstCountry.SelectedValue
        p.EmailId1 = textEmailId1.Text
        p.EmailId2 = textEmailId2.Text
        p.ContactNo = textContactNo.Text
        p.MobileNo = textMobileNumber.Text
        p.Fax = textFax.Text
        p.PaymentTerms = lstPaymentTerms.SelectedValue
        p.Pan = textPanNo.Text
        p.Tan = textTanNo.Text
        p.ServiceTaxReg = textServiceTaxRegNo.Text
        p.BankName = lstBankName.SelectedValue
        p.AcMapCode = textAccountMapCode.Text
        p.AccountNo = textAccountNo.Text
        p.CreatedBy = Session.Item("LoginUser")
        p.TerminalId = Session.Item("LoginTerminal")
        p.IFSC = textIfsc.Text
        p.BankBranch = textBankBranch.Text
        p.ContactPerson = textContactPerson.Text
        p.State = lstState.SelectedValue
        p.TallyVendorName = txtTallyVendor.Text
        p.GSTIN = txtGSTIN.Text
        p.VendorTypeDetailsList = New ArrayList
        For Each rep As RepeaterItem In RepVendor.Items
            If CType(rep.FindControl("lstVendorType"), DropDownList).SelectedValue <> "0" Then
                Dim pDet As New VendorTypeDetails
                pDet.TerminalId = Session.Item("LoginTerminal")

                Try
                    pDet.VendorId = hdnVendorId.Value
                Catch ex As Exception

                End Try
                Try
                    pDet.VendorKeyId = CType(rep.FindControl("hdnVendorKeyId"), HiddenField).Value
                Catch ex As Exception

                End Try
                pDet.VenderTypeCode = CType(rep.FindControl("lstVendorType"), DropDownList).SelectedValue
                pDet.TdsCode = CType(rep.FindControl("lstTds"), DropDownList).SelectedValue


                If CType(rep.FindControl("chkImport"), CheckBox).Checked Then
                    pDet.Import = "Y"
                End If
                If CType(rep.FindControl("chkExport"), CheckBox).Checked Then
                    pDet.Export = "Y"
                End If
                If CType(rep.FindControl("chkDomestic"), CheckBox).Checked Then
                    pDet.Domestic = "Y"
                End If
                If CType(rep.FindControl("chkStatus"), CheckBox).Checked Then
                    pDet.Status = "Y"
                End If
                Try
                    p.Rate = TextRate.Text.Trim()
                Catch ex As Exception

                End Try
                p.VendorTypeDetailsList.Add(pDet)
            End If
        Next

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ExtVendorMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.VendorId = pCodevalue.Value
        VendorMaster.ReturnVendorMaster(p)
        hdnVendorId.Value = p.VendorCode
        textVendorCode.Text = p.VendorCode
        textVendorName.Text = p.VendorName
        textAddress.Text = p.Address
        'textCity.Text = p.City
        textZipCode.Text = p.PinCode
		'textState.Text = p.State
		Try
			lstCountry.SelectedValue = p.Country
		Catch ex As Exception
		End Try

		textEmailId1.Text = p.EmailId1
        textEmailId2.Text = p.EmailId2
        textContactNo.Text = p.ContactNo
        textMobileNumber.Text = p.MobileNo
        textFax.Text = p.Fax
        lstPaymentTerms.SelectedValue = p.PaymentTerms
        textPanNo.Text = p.Pan
        textContactPerson.Text = p.ContactPerson
        textTanNo.Text = p.Tan
        textServiceTaxRegNo.Text = p.ServiceTaxReg
        lstBankName.SelectedValue = p.BankName
        textAccountMapCode.Text = p.AcMapCode
        textAccountNo.Text = p.AccountNo
        textIfsc.Text = p.IFSC
        textBankBranch.Text = p.BankBranch
		TextRate.Text = p.Rate
		Try
			lstState.SelectedValue = p.State
		Catch ex As Exception
		End Try

		txtGSTIN.Text = p.GSTIN
        txtTallyVendor.Text = p.TallyVendorName
        Dim pvd As New VendorTypeDetails
        pvd.TerminalId = Session.Item("LoginTerminal")
        pvd.VendorId = p.VendorId

        fillRepeator(VendorTypeDetails.ReturnVendorTypeDetailsList(pvd))
    End Sub
End Class
