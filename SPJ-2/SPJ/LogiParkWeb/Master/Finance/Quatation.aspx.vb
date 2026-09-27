Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports LogiParkLib.DBConnection

Partial Class Master_Finance_Quatation
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim addrows As Integer = 5
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim glPortMaster As New ExtPortMaster
    Dim glCustomerMaster As New ExtCustomerMaster
    Dim glIsoCode As New ArrayList
    Dim glServiceMode As New ArrayList
    Dim glTerminalMaster As New ArrayList
    Dim glTolocation As New ArrayList
    Dim glService As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            tvServices.Enabled = True
            btnGo.Enabled = True
            lstCustomerName.Enabled = True
            ' LoadTreeViewData()
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub LoadTreeViewData()
        tvServices.Nodes.Clear()
        Dim pExtRateMaster As New ExtRateMaster
        pExtRateMaster.TerminalId = Session.Item("LoginTerminal")
        pExtRateMaster.CustomerId = lstCustomerName.SelectedValue
        Try
            For Each obj As RateMaster In ExtRateMaster.ReturnRateMasterListByCustomerId(pExtRateMaster)
                'For Each obj As RateMaster In ExtRateMaster.ReturnRateMasterListByterminalId(pExtRateMaster)
                Dim p As New ServiceMaster
                ' p.TerminalId = obj.TerminalId
                p.ServiceId = obj.ServiceId
                ServiceMaster.ReturnServiceMasterByServiceId(p)
                Dim pcu As New ExtCustomerMaster
                pcu.CustomerId = obj.CustomerId
                pcu.TerminalId = obj.TerminalId
                ExtCustomerMaster.ReturnCustomerMaster(pcu)
                Dim str As String = pcu.CustomerName
                str &= "-" & p.ServiceName
                Functions.treeViewNodeSetup(tvServices, "0", obj.RateId, str)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        btnGo.Visible = pVisible
        If hdnRateId.Value.Trim <> Nothing Then
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
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New QuatationDtls
                p.ContStatus = "0"
                p.ContType = "ALL"
                p.HandlingMode = "0"
                p.CargoType = "0"
                p.DocType = "0"
                'p.ServiceId = "0"
                arr.Add(p)
            Next
        End If
        repRateDetails.DataSource = arr
        repRateDetails.DataBind()
    End Sub
    Sub ListControlDataBind()
        'Dim pTaxGroup As New TaxGroup
        'pTaxGroup.TerminalId = Session.Item("LoginTerminal")
        'lstTaxGroup.DataSource = TaxGroup.ReturnTaxGroupList(pTaxGroup)
        'lstTaxGroup.DataTextField = "TaxGroupCode"
        'lstTaxGroup.DataValueField = "TaxGroupId"
        'lstTaxGroup.DataBind()
        'lstTaxGroup.Items.Insert(0, (New ListItem("----Select----", "0")))
        'Dim pService As New ServiceMaster
        'pService.TerminalId = Session.Item("LoginTerminal")
        'lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pService)
        'lstService.DataTextField = "ServiceName"
        'lstService.DataValueField = "ServiceId"
        'lstService.DataBind()
        'lstService.Items.Insert(0, (New ListItem("----Select----", "0")))
        Dim pCusType As New CustomerType
        pCusType.TerminalId = Session.Item("LoginTerminal")
        lstCustomerType.DataSource = CustomerType.ReturnCustomerTypeList(pCusType)
        lstCustomerType.DataTextField = "CustomerTypeName"
        lstCustomerType.DataValueField = "CustomerTypeCode"
        lstCustomerType.DataBind()
        lstCustomerType.Items.Insert(0, (New ListItem("----Public----", "")))
        lstCustomerType.SelectedValue = ""
        Dim pcustomermaster As New CustomerMaster
        pcustomermaster.TerminalId = Session.Item("LoginTerminal")
        lstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterList(pcustomermaster)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Insert(0, (New ListItem("----Public----", "0")))
        Dim pCustomer As New ExtCustomerMaster
        pCustomer.TerminalId = Session.Item("LoginTerminal")
        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAll(pCustomer)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Insert(0, (New ListItem("----Public----", "0")))
    End Sub
    Protected Sub prepareDataRepControlsList()

        Dim pPort As New ExtPortMaster
        pPort.TerminalId = Session.Item("LoginTerminal")
        glPortMaster.PortList = ExtPortMaster.ReturnPortMasterList(pPort)

        Dim p As New ExtCommodityMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glCommodityMaster.CommodityList = ExtCommodityMaster.ReturnCommodityMasterList(p)

        Dim pLine As New ExtCustomerMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glCustomerMaster.CustomerTypeDetailsList = ExtCustomerMaster.ReturnCustomerMasterListAllLine(pLine)

        Dim pIso As New IsoCode
        glIsoCode = IsoCode.ReturnIsoCodeListOfContType(pIso)

        Dim pServiceMode As New ServiceMode
        pServiceMode.TerminalId = Session.Item("LoginTerminal")
        glServiceMode = ServiceMode.ReturnServiceModeList(pServiceMode)

        Dim pTerminal As New TerminalMaster
        glTerminalMaster = TerminalMaster.ReturnTerminalMasterList(pTerminal)

        Dim pLocationMaster As New TerminalLocationMaster
        glTolocation = TerminalLocationMaster.ReturnTerminalLocationMasterAll(pLocationMaster)
        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        glService = ServiceMaster.ReturnServiceMasterList(pService)
    End Sub
    Protected Sub preService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("SELECT", "0"))
            For Each ic As ServiceMaster In glService
                lst.Items.Add(New ListItem(ic.ServiceName, ic.ServiceId))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareContType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "ALL"))
            For Each ic As IsoCode In glIsoCode
                lst.Items.Add(New ListItem(ic.ContType, ic.ContType))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareToLocation(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
            For Each ic As TerminalLocationMaster In glTolocation
                lst.Items.Add(New ListItem(ic.LocationName, ic.LocationId))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareHandlingMode(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()

            lst.Items.Add(New ListItem("ALL", "0"))
            For Each ic As ServiceMode In glServiceMode
                lst.Items.Add(New ListItem(ic.ModeName, ic.ModeCode))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()

            lst.Items.Add(New ListItem("ALL", "0"))
            For Each ic As TerminalMaster In glTerminalMaster
                lst.Items.Add(New ListItem(ic.TerminalName, ic.TerminalId))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareCommodity(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
            For Each CM As CommodityMaster In glCommodityMaster.CommodityList
                lst.Items.Add(New ListItem(CM.CommodityName, CM.CommodityId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareLine(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
            For Each CM As CustomerMaster In glCustomerMaster.CustomerTypeDetailsList
                lst.Items.Add(New ListItem(CM.CustomerName, CM.CustomerId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub preparePort(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
            For Each PL As PortMaster In glPortMaster.PortList
                lst.Items.Add(New ListItem(PL.PortName, PL.PortId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pExtRate As New ExtQuatation
        pExtRate.RateId = pCodevalue.Value
        pExtRate.TerminalId = Session.Item("LoginTerminal")
        ExtQuatation.ReturnQuatationWithDetailsTrn(pExtRate)

        hdnRateId.Value = pExtRate.RateId
        textValidFromDate.Text = pExtRate.FromDate
        textValidToDate.Text = pExtRate.ToDate
        lstCustomerType.SelectedValue = pExtRate.CustomerType
        lstCustomer.SelectedValue = pExtRate.CustomerId
        'lstService.SelectedValue = pExtRate.ServiceId
        'lstCustomerName.SelectedValue = pExtRate
        textRemarks.Text = pExtRate.Remarks
        If pExtRate.ApprovalFlage = "Y" Then
            chkApproval.Checked = True
        End If
        fillRepeator(pExtRate.QuatationDetailsList)
        'SetRangeText(lstService.SelectedValue)
    End Sub

    Protected Sub lstCustomerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomerType.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pCustomer As New ExtCustomerMaster
        pCustomer.TerminalId = Session.Item("LoginTerminal")

        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAllByCustomertypeCode(pCustomer, lstCustomerType.SelectedValue)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Insert(0, (New ListItem("----Public----", "0")))
        If lstCustomerType.SelectedValue = "" Then
            lstCustomer.Enabled = False
            lstCustomer.SelectedValue = 0
        Else
            lstCustomer.Enabled = True
            lstCustomer.SelectedValue = 0
        End If
        manageRep()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ListControlDataBind()
        If Not tvServices.SelectedNode Is Nothing Then
            prepareControls(tvServices.SelectedNode)
        End If
        manageUserControls(True)
        btnNewRows.Visible = False
        btnDeleteRows.Visible = False
        tvServices.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvServices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvServices.SelectedNodeChanged
        ListControlDataBind()

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvServices.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvServices.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvServices.Nodes.Count > 0 Then
            tvServices.Nodes(0).Selected = True
            prepareControls(tvServices.Nodes(0))
        End If
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvServices.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvServices.SelectedNode.ValuePath
            tvServices.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)

        tvServices.Enabled = False
        'lstTaxGroup.Enabled = True
        'lstService.SelectedValue = 0
        lstCustomerType.SelectedValue = ""
        lstCustomer.SelectedValue = 0
        manageRep()
        If lstCustomerType.SelectedValue = "" Then
            lstCustomer.Enabled = False
        End If
        fillRepeator(New ArrayList)
        btnNewRows.Visible = True
        btnDeleteRows.Visible = True
        Functions.ControlFocus(textValidFromDate)
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textValidFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Date is Blank.")
            rtnBool = False
            Functions.ControlFocus(textValidFromDate)
            Return rtnBool
            Exit Function
        End If
        If textValidToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date is Blank.")
            rtnBool = False
            Functions.ControlFocus(textValidToDate)
            Return rtnBool
            Exit Function
        End If
        'If lstCustomerType.SelectedValue <> "" And lstCustomer.SelectedValue = 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The Customer.")
        '    rtnBool = False
        '    Functions.ControlFocus(lstCustomer)
        '    Return rtnBool
        '    Exit Function
        'End If
        'If lstService.SelectedValue <= 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The Service.")
        '    rtnBool = False
        '    Functions.ControlFocus(lstService)
        '    Return rtnBool
        '    Exit Function
        'End If

        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing
        Try
            dtFrom = Functions.todate_ddmmyyyy(textValidFromDate.Text, "/")
        Catch ex As Exception
        End Try
        Try
            dtTo = Functions.todate_ddmmyyyy(textValidToDate.Text, "/")
        Catch ex As Exception

        End Try
        If dtTo <= dtFrom Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should be greater than From Date")
            rtnBool = False
            Functions.ControlFocus(textValidFromDate)
            Return rtnBool
            Exit Function
        End If

        If dtTo < Today.Date Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should not be less than Today")
            rtnBool = False
            Functions.ControlFocus(textValidToDate)
            Return rtnBool
            Exit Function
        End If

        For Each rep As RepeaterItem In repRateDetails.Items

            Dim hdnRateKeyId As HiddenField = CType(rep.FindControl("hdnRateKeyId"), HiddenField)
            Dim lstContSize As DropDownList = CType(rep.FindControl("lstContSize"), DropDownList)
            Dim LstService As DropDownList = CType(rep.FindControl("LstService"), DropDownList)
            Dim lstContType As DropDownList = CType(rep.FindControl("lstContType"), DropDownList)
            Dim lstContStatus As DropDownList = CType(rep.FindControl("lstContStatus"), DropDownList)
            Dim lstCargotype As DropDownList = CType(rep.FindControl("lstCargoType"), DropDownList)
            Dim lstCommodity As DropDownList = CType(rep.FindControl("lstCommodity"), DropDownList)
            Dim lsthandingmode As DropDownList = CType(rep.FindControl("lstHandlingMode"), DropDownList)
            Dim lstPol As DropDownList = CType(rep.FindControl("lstPol"), DropDownList)
            Dim textFromRang As TextBox = CType(rep.FindControl("textFromRange"), TextBox)
            Dim textTorang As TextBox = CType(rep.FindControl("textToRange"), TextBox)
            'Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
            Dim textBaseRate As TextBox = CType(rep.FindControl("textBaseRate"), TextBox)
            ' Dim textDiscount As TextBox = CType(rep.FindControl("textDiscount"), TextBox)
            ' Dim lstDiscountType As DropDownList = CType(rep.FindControl("lstDiscountType"), DropDownList)
            Dim lstDocType As DropDownList = CType(rep.FindControl("lstDocType"), DropDownList)
            Dim lstPortId As DropDownList = CType(rep.FindControl("lstPortId"), DropDownList)
            Dim lstLineId As DropDownList = CType(rep.FindControl("lstLineId"), DropDownList)
            If textFromRang.Text.ToString.Trim = String.Empty Then
                textFromRang.Text = 0
            End If
            If textTorang.Text.ToString.Trim = String.Empty Then
                textTorang.Text = 0
            End If
            'If textRate.Text.ToString.Trim = String.Empty Then
            '    textRate.Text = 0
            'End If
            If textBaseRate.Text.ToString.Trim = String.Empty Then
                textBaseRate.Text = 0
            End If
            'If textDiscount.Text.ToString.Trim = String.Empty Then
            '    textDiscount.Text = 0
            'End If

            If textTorang.Text > 0 Then
                Try
                    If Double.Parse(textFromRang.Text.Trim) < 0 Or textFromRang.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                        Functions.ControlFocus(textFromRang)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                    If Double.Parse(textTorang.Text.Trim) < 0 Or textTorang.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                        Functions.ControlFocus(textTorang)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                    'If Double.Parse(textDiscount.Text.Trim) < 0 Or textDiscount.Text.Trim = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                    '    Functions.ControlFocus(textDiscount)
                    '    rtnBool = False
                    '    Return rtnBool
                    '    Exit Function
                    'End If

                    If Double.Parse(textTorang.Text.Trim) <= Double.Parse(textFromRang.Text.Trim) And Double.Parse(textTorang.Text.Trim) <> 0 And Double.Parse(textFromRang.Text.Trim) <> 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Weight should be less than To Weight.")
                        Functions.ControlFocus(textTorang)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try

                'Try
                '    If Double.Parse(textRate.Text) < 0 Then
                '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value.")
                '        Functions.ControlFocus(textRate)
                '        rtnBool = False
                '        Return rtnBool
                '        Exit Function
                '    End If
                'Catch ex As Exception
                'End Try

                For Each rep1 As RepeaterItem In repRateDetails.Items

                    Dim hdnRateKeyId1 As HiddenField = CType(rep1.FindControl("hdnRateKeyId"), HiddenField)
                    Dim LstService1 As DropDownList = CType(rep.FindControl("LstService"), DropDownList)
                    Dim lstContSize1 As DropDownList = CType(rep1.FindControl("lstContSize"), DropDownList)
                    Dim lstContType1 As DropDownList = CType(rep1.FindControl("lstContType"), DropDownList)
                    Dim lstContStatus1 As DropDownList = CType(rep1.FindControl("lstContStatus"), DropDownList)
                    Dim lstCargotype1 As DropDownList = CType(rep1.FindControl("lstCargoType"), DropDownList)
                    Dim lstCommodity1 As DropDownList = CType(rep1.FindControl("lstCommodity"), DropDownList)
                    Dim lsthandingmode1 As DropDownList = CType(rep1.FindControl("lstHandlingMode"), DropDownList)
                    Dim lstPol1 As DropDownList = CType(rep1.FindControl("lstPol"), DropDownList)
                    Dim textFromRang1 As TextBox = CType(rep1.FindControl("textFromRange"), TextBox)
                    Dim textTorang1 As TextBox = CType(rep1.FindControl("textToRange"), TextBox)
                    'Dim textRate1 As TextBox = CType(rep1.FindControl("textRate"), TextBox)
                    Dim textBaseRate1 As TextBox = CType(rep1.FindControl("textBaseRate"), TextBox)
                    'Dim textDiscount1 As TextBox = CType(rep1.FindControl("textDiscount"), TextBox)
                    'Dim lstDiscountType1 As DropDownList = CType(rep1.FindControl("lstDiscountType"), DropDownList)
                    Dim lstDocType1 As DropDownList = CType(rep1.FindControl("lstDocType"), DropDownList)
                    Dim lstPortId1 As DropDownList = CType(rep1.FindControl("lstPortId"), DropDownList)
                    Dim lstLineId1 As DropDownList = CType(rep1.FindControl("lstLineId"), DropDownList)

                    If rep.ItemIndex <> rep1.ItemIndex Then

                        If textFromRang1.Text.ToString.Trim = String.Empty Then
                            textFromRang1.Text = 0
                        End If
                        If textTorang1.Text.ToString.Trim = String.Empty Then
                            textTorang1.Text = 0
                        End If
                        'If textRate1.Text.ToString.Trim = String.Empty Then
                        '    textRate1.Text = 0
                        'End If
                        If textBaseRate1.Text.ToString.Trim = String.Empty Then
                            textBaseRate1.Text = 0
                        End If
                        'If textDiscount1.Text.ToString.Trim = String.Empty Then
                        '    textDiscount1.Text = 0
                        'End If

                        If Double.Parse(textTorang1.Text.Trim) > 0 Then
                            If Double.Parse(textFromRang1.Text.Trim) < 0 Or textFromRang1.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                                Functions.ControlFocus(textFromRang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If Double.Parse(textTorang1.Text.Trim) < 0 Or textTorang1.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                                Functions.ControlFocus(textTorang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            'If Double.Parse(textDiscount1.Text.Trim) < 0 Or textDiscount1.Text.Trim = "" Then
                            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                            '    Functions.ControlFocus(textDiscount1)
                            '    rtnBool = False
                            '    Return rtnBool
                            '    Exit Function
                            'End If

                            'If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            'lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            'lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            'lstContType.SelectedValue = lstContType1.SelectedValue And _
                            'lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            'lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            'lstPol.SelectedValue = lstPol1.SelectedValue And _
                            'lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                            'lstLineId.SelectedValue = lstLineId1.SelectedValue And _
                            'LstService.SelectedValue = LstService1.SelectedValue And _
                            'Double.Parse(textFromRang.Text.Trim) = Double.Parse(textFromRang1.Text.Trim) Then
                            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                            '    Functions.ControlFocus(textTorang)
                            '    rtnBool = False
                            '    Return rtnBool
                            '    Exit Function
                            'End If

                            '                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            '                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            '                            lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            '                            lstContType.SelectedValue = lstContType1.SelectedValue And _
                            '                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            '                            lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            '                            lstPol.SelectedValue = lstPol1.SelectedValue And _
                            '                            lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                            '                            lstLineId.SelectedValue = lstLineId1.SelectedValue And _
                            'LstService.SelectedValue = LstService1.SelectedValue And _
                            '                            Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textFromRang1.Text.Trim) And _
                            '                            Double.Parse(textFromRang.Text.Trim) < Double.Parse(textFromRang1.Text.Trim) And _
                            '                             Double.Parse(textTorang.Text.Trim) <> 0 Then
                            '                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                            '                                Functions.ControlFocus(textTorang)
                            '                                rtnBool = False
                            '                                Return rtnBool
                            '                                Exit Function
                            '                            End If

                            '                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            '                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            '                            lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            '                            lstContType.SelectedValue = lstContType1.SelectedValue And _
                            '                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            '                            lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            '                            lstPol.SelectedValue = lstPol1.SelectedValue And _
                            '                            lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                            '                            lstLineId.SelectedValue = lstLineId1.SelectedValue And _
                            '                            LstService.SelectedValue = LstService1.SelectedValue And _
                            '                          Double.Parse(textTorang.Text.Trim) > Double.Parse(textFromRang1.Text.Trim) And _
                            '                            Double.Parse(textTorang.Text.Trim) < Double.Parse(textTorang1.Text.Trim) And _
                            '                           Double.Parse(textTorang1.Text.Trim) <> 0 Then
                            '                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                            '                                Functions.ControlFocus(textTorang1)
                            '                                rtnBool = False
                            '                                Return rtnBool
                            '                                Exit Function
                            '                            End If

                            '                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            '                             lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            '                             lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            '                             lstContType.SelectedValue = lstContType1.SelectedValue And _
                            '                             lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            '                             lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            '                             lstPol.SelectedValue = lstPol1.SelectedValue And _
                            '                             lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                            '                             lstLineId.SelectedValue = lstLineId1.SelectedValue And _
                            '                             LstService.SelectedValue = LstService1.SelectedValue And _
                            '                             Double.Parse(textFromRang.Text.Trim) <= Double.Parse(textFromRang1.Text.Trim) And _
                            '                             Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textTorang1.Text.Trim) And _
                            '                              Double.Parse(textTorang1.Text.Trim) <> 0 Then
                            '                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                            '                                Functions.ControlFocus(textTorang1)
                            '                                rtnBool = False
                            '                                Return rtnBool
                            '                                Exit Function
                            '                            End If

                        End If
                    End If
                Next
            End If
        Next
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pQuatation As ExtQuatation = ReturnObject()
        ExtQuatation.InsertUpdateQuatationWithDetailsTrn(pQuatation)
        If pQuatation.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pQuatation.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        LoadTreeViewData()

        hdnRateId.Value = pQuatation.RateId
        Dim P As New QuatationDtls
        P.RateId = hdnRateId.Value
        P.TerminalId = pQuatation.TerminalId
        fillRepeator(QuatationDtls.ReturnQuatationDtlsListByRateId(P))
        ButtonControlSetup(True)
        manageUserControls(True)
        tvServices.Enabled = True
        btnNewRows.Visible = False
        btnDeleteRows.Visible = False
        btnsend.Visible = True
        BtnsendTpt.Visible = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ReturnObject() As ExtQuatation
        Dim pQ As New ExtQuatation
        Try
            pQ.RateId = hdnRateId.Value
        Catch ex As Exception
        End Try
        pQ.CreatedBy = Session.Item("LoginUser")
        pQ.TerminalId = Session.Item("LoginTerminal")
        pQ.FromDate = textValidFromDate.Text
        pQ.ToDate = textValidToDate.Text
        pQ.CustomerType = lstCustomerType.SelectedValue
        If lstCustomerType.SelectedValue = "" Then
            pQ.CustomerId = 0
        Else
            pQ.CustomerId = lstCustomer.SelectedValue
        End If
        'pRM.TaxGroupId = lstTaxGroup.SelectedValue
        'pRM.ServiceId = lstService.SelectedValue
        pQ.Remarks = textRemarks.Text
        If chkApproval.Checked Then
            pQ.ApprovalFlage = "Y"
        End If
        If FileRateAggrement.PostedFile.FileName <> "" Then
            Try
                pQ.AggrementDoc = Path.GetFileName(FileRateAggrement.PostedFile.FileName)
                FileRateAggrement.PostedFile.SaveAs(Server.MapPath("~/Document/RATE-AGR/") + pQ.AggrementDoc)
            Catch ex As Exception
            End Try
        End If
        pQ.QuatationDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items
            If (CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value > 0) Or (CType(rc.FindControl("textToRange"), TextBox).Text <> Nothing AndAlso Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text) > 0) Then
                Dim p As New QuatationDtls
                p.TerminalId = Session.Item("LoginTerminal")
                Try
                    p.PortId = CType(rc.FindControl("lstPortId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.LineId = CType(rc.FindControl("lstLineId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.RateKeyId = CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.CargoType = CType(rc.FindControl("lstCargoType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContSize = CType(rc.FindControl("lstContSize"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContType = CType(rc.FindControl("lstContType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContStatus = CType(rc.FindControl("lstContStatus"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.DocType = CType(rc.FindControl("lstDocType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.CommodityId = CType(rc.FindControl("lstCommodity"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.Pol = CType(rc.FindControl("lstPol"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.FromRang = Integer.Parse(CType(rc.FindControl("textFromRange"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.ToRang = Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.BaseRate = Double.Parse(CType(rc.FindControl("textBaseRate"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.Currency = CType(rc.FindControl("lstCurrency"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                'Try
                '    p.DiscountType = CType(rc.FindControl("lstDiscountType"), DropDownList).SelectedValue
                'Catch ex As Exception
                'End Try
                'Try
                '    p.Discount = Double.Parse(CType(rc.FindControl("textDiscount"), TextBox).Text)
                'Catch ex As Exception
                'End Try
                'Try
                '    p.Rate = Double.Parse(CType(rc.FindControl("textRate"), TextBox).Text)
                'Catch ex As Exception
                'End Try
                Try
                    p.HandlingMode = CType(rc.FindControl("lstHandlingMode"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ServiceId = CType(rc.FindControl("LstService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                pQ.QuatationDetailsList.Add(p)
            End If

        Next

        Return pQ
    End Function

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvServices.Enabled = False
        manageControls(False)
        btnNewRows.Visible = True
        btnDeleteRows.Visible = True
        Functions.ControlFocus(textRemarks)
    End Sub
    Sub manageControls(ByVal pEnable As Boolean)
        textValidFromDate.Enabled = pEnable
        lstCustomerType.Enabled = pEnable
        lstCustomer.Enabled = pEnable
        chkApproval.Enabled = pEnable
        manageRep()
    End Sub
    Sub manageRep()
        For Each e As RepeaterItem In repRateDetails.Items
            Dim dblDiscount = 0, dblBaseRate As Double = 0
            Dim strDiscType As String = ""
            'Try
            '    dblDiscount = CType(e.FindControl("textDiscount"), TextBox).Text
            'Catch ex As Exception
            'End Try
            Try
                dblBaseRate = CType(e.FindControl("textBaseRate"), TextBox).Text
            Catch ex As Exception
            End Try
            strDiscType = lstCustomerType.SelectedValue
            'If CType(e.FindControl("lstDiscountType"), DropDownList).SelectedValue = Nothing Then
            '    CType(e.FindControl("textDiscount"), TextBox).Enabled = False
            'End If
            If lstCustomerType.SelectedValue = Nothing Then
                ' CType(e.FindControl("lstDiscountType"), DropDownList).Enabled = False
                'CType(e.FindControl("textDiscount"), TextBox).Enabled = False
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                'CType(e.FindControl("lstCommodity"), DropDownList).Enabled = True
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
                CType(e.FindControl("lstPortId"), DropDownList).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
                CType(e.FindControl("lstPol"), DropDownList).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True


            Else
                'CType(e.FindControl("lstDiscountType"), DropDownList).Enabled = True
                'CType(e.FindControl("textDiscount"), TextBox).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                'CType(e.FindControl("lstCommodity"), DropDownList).Enabled = True
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("lstPol"), DropDownList).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstHandlingMode"), DropDownList).Enabled = True
                CType(e.FindControl("lstPortId"), DropDownList).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
                'If CType(e.FindControl("lstDiscountType"), DropDownList).SelectedValue = Nothing Then
                '    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate
                '    CType(e.FindControl("textDiscount"), TextBox).Text = 0
                '    CType(e.FindControl("textDiscount"), TextBox).Enabled = True
                'ElseIf strDiscType = "P" Then
                '    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - ((dblBaseRate * dblDiscount) / 100)
                'ElseIf strDiscType = "I" Then
                '    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - dblDiscount
                'End If
            End If
            'CType(e.FindControl("textRate"), TextBox).Enabled = False
        Next
    End Sub
    Protected Sub btnNewRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewRows.Click
        Dim pRM As New ExtRateMaster
        pRM.RateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items

            Dim p As New RateDetails
            p.TerminalId = Session.Item("LoginTerminal")
            Try
                p.PortId = CType(rc.FindControl("lstPortId"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.LineId = CType(rc.FindControl("lstLineId"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try

            Try
                p.RateKeyId = CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value
            Catch ex As Exception
            End Try

            Try
                p.ContSize = CType(rc.FindControl("lstContSize"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.ContType = CType(rc.FindControl("lstContType"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try

            Try
                p.Pol = CType(rc.FindControl("lstPol"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.FromRang = Integer.Parse(CType(rc.FindControl("textFromRange"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                p.BaseRate = Integer.Parse(CType(rc.FindControl("textBaseRate"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                p.Currency = CType(rc.FindControl("lstCurrency"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.ToRang = Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text)
            Catch ex As Exception
            End Try
            'Try
            '    p.Rate = Double.Parse(CType(rc.FindControl("textRate"), TextBox).Text)
            'Catch ex As Exception
            'End Try
            Try
                p.Rate = Double.Parse(CType(rc.FindControl("SurCharge"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                p.ContStatus = CType(rc.FindControl("lstContStatus"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.DocType = CType(rc.FindControl("lstDocType"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.HandlingMode = CType(rc.FindControl("lstHandlingMode"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try

            pRM.RateDetailsList.Add(p)

        Next

        Dim i As Integer = 0
        While i < addrows
            Dim pRD As New RateDetails
            pRD.Pol = 0
            pRD.HandlingMode = "0"
            pRD.ContStatus = "0"
            pRD.DocType = "0"
            pRD.ContType = "ALL"
            pRD.CargoType = "0"
            pRM.RateDetailsList.Add(pRD)
            i += 1
        End While
        fillRepeator(pRM.RateDetailsList)
        manageRep()
    End Sub
    Sub SetRangeText(ByVal pServiceId As Long)
        Dim p As New ServiceMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.ServiceId = pServiceId
        ServiceMaster.ReturnServiceMasterByServiceId(p)

        'If p.UomId = 100 Then
        '    lblFromRange.Text = "Range From (Days)"
        '    lblToRange.Text = "Range To (Days)" & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 102 Then
        '    lblFromRange.Text = "Range From (Hrs)"
        '    lblToRange.Text = "Range To (Hrs)" & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 103 Then
        '    lblFromRange.Text = "Range From (Kgs)"
        '    lblToRange.Text = "Range To (Kgs)" & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 104 Then
        '    lblFromRange.Text = "Range From (%)"
        '    lblToRange.Text = "Range To (%)" & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 105 Then
        '    lblFromRange.Text = "Range From (Days)"
        '    lblToRange.Text = "Range To (Days)" & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 101 Then
        '    lblFromRange.Text = "Range From "
        '    lblToRange.Text = "Range To " & "<span class='mandatory'> *</span>"
        'ElseIf p.UomId = 106 Then
        '    lblFromRange.Text = "Range From (Per Ton)"
        '    lblToRange.Text = "Range To (Per Ton)" & "<span class='mandatory'> *</span>"
        'End If


    End Sub

    'Protected Sub lstService_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstService.SelectedIndexChanged

    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    SetRangeText(lstService.SelectedValue)
    '    If lstCustomerType.SelectedValue <> Nothing Then

    '        Dim p As New ExtRateMaster
    '        p.TerminalId = Session.Item("LoginTerminal")
    '        p.FromDate = Today.Day & "/" & Today.Month & "/" & Today.Year
    '        p.ToDate = Today.Day & "/" & Today.Month & "/" & Today.Year
    '        p.ServiceId = lstService.SelectedValue
    '        ExtRateMaster.ReturnRateMasterByServiceIdWithCurrentDate(p)
    '        If p.RateId <= 0 Then
    '            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Public tariff not fount")
    '            Functions.ControlFocus(lstService)

    '        End If
    '        Dim arr As New ArrayList
    '        For Each r As RateDetails In p.RateDetailsList
    '            r.RateKeyId = 0
    '            arr.Add(r)
    '        Next
    '        fillRepeator(arr)

    '        manageRep()

    '    End If
    '    btnNewRows.Visible = True
    '    btnDeleteRows.Visible = True
    'End Sub
    Protected Sub repRateDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRateDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            'If lstCustomerType.SelectedValue <> Nothing Then
            '    CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = False
            '    CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = False
            'Else
            '    CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = True
            '    CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = True
            'End If
            'CType(e.Item.FindControl("textRate"), TextBox).Enabled = False
        End If

    End Sub
    Protected Sub FillLocation(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim lstFromLocation As DropDownList = sender
            Dim hdnValue As Integer = 0
            Dim lstToLocation As DropDownList
            Dim index1 As Integer = Integer.Parse(lstFromLocation.ClientID.Substring("ctl00_ContentPlaceHolder1_repRateDetails_ctl".Length, lstFromLocation.ClientID.IndexOf("_lstHandlingMode") - "ctl00_ContentPlaceHolder1_repRateDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = repRateDetails.Items(index1 - 1)
            If lstFromLocation.SelectedValue <> "" Then
                hdnValue = lstFromLocation.SelectedValue
                lstToLocation = CType(rep.FindControl("lstCargoType"), DropDownList)
                lstToLocation.Items.Clear()
                Dim P As New TerminalLocationMaster
                P.TerminalId = hdnValue
                lstToLocation.Items.Add(New ListItem("ALL", "0"))
                For Each LST As TerminalLocationMaster In TerminalLocationMaster.ReturnTerminalLocationMasterList(P)
                    lstToLocation.Items.Add(New ListItem(LST.LocationName, LST.LocationId))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'Dim pRatemaster As New RateMaster
        'pRatemaster.TerminalId = 1
        'pRatemaster.CustomerId = lstCustomerName.SelectedValue
        'RateMaster.ReturnRateMasterListByCustomerId(pRatemaster)
        'lstCustomerName.SelectedValue = pRatemaster.CustomerId

        LoadTreeViewData()

    End Sub
    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsend.Click
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = 1
        MailConfig.ReturnMailConfig(pMailConfig)
        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = Session.Item("MenuId")
        'Session.Item("MenuId")
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetup(xMailSetup)
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= "<br/>"
        Dim confirmMail As New StringBuilder
        xMailSetup.MailBody = ""
        confirmMail.AppendLine("<table style='width: 350px; border-style:Solid; border-width:1px; position: static; height: 100%; width: 100%' cellpadding='0' cellspacing='0'>")
        confirmMail.Append("<tr style='font-family: calibri; color: #4B6B94;'>")
        confirmMail.Append("<th style='align: center; font-size: 15px; border-style: solid;border-right:None;  border-top-color: #000000;border-left:None;   border-width: 0.1px; height: 21px' colspan='10'>")
        confirmMail.Append("<b>Quatation </b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #C0C0C0;'>")
        confirmMail.Append("<td style='width: 200px; border-style: solid; border-top-color: #000000; border-width: 0.1px;font-size: 10pt;  height: 10px' align='left' >")
        confirmMail.Append("<b>Service</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 5px' align='center'  >")
        confirmMail.Append("<b>Port</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Line</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Size</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Status</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Doc Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Handover</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Rate</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Currency</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")

        For Each rc As RepeaterItem In repRateDetails.Items
            If CType(rc.FindControl("LstService"), DropDownList).SelectedValue <> 0 Then
                confirmMail.Append("<tr style='font-family: calibri;'>")
                confirmMail.Append("<td style='width: 200px; border-style: solid; border-top-color: #000000;border-left:None; border-right:None; border-width: 0.1px; height: 5px'>")
                confirmMail.Append(CType(rc.FindControl("LstService"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstPortId"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstLineId"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContSize"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContType"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContStatus"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstDocType"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstPol"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("textFromRange"), TextBox).Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstCurrency"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append(" </tr>")

            End If
        Next
        confirmMail.Append("</table>")
        'confirmMail.AppendLine("<table style='width: 350px; border-style:Solid; border-width:1px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")

        'confirmMail.Append("</table>")
        xMailSetup.MailBody = "Dear Customer, "
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "Please see below the quatation which is valid from " & textValidFromDate.Text.Trim & " To " & textValidToDate.Text.Trim & "."
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= confirmMail.ToString
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "<b>Thanks & Regards </b>" & "<br>"
        'xMailSetup.Subject = "Booking confirmation"
        Dim p As New CompanyMaster
        p.CompanyId = Session.Item("LoginCompany")
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"
        pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, "amit.kumar@elogisol.in,amit.singh@elogisol.in,lalit@elogisol.in", "vrohit248@gmail.com", "vrohit248@gmail.com", xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        'pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        If pStr <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sending failed.")
        Else
            lblErrorMessage.Visible = True
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sent Successfully.")
        End If
    End Sub

    Protected Sub BtnsendTpt_Click(sender As Object, e As System.EventArgs) Handles BtnsendTpt.Click
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = 1
        MailConfig.ReturnMailConfig(pMailConfig)
        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = Session.Item("MenuId")
        'Session.Item("MenuId")
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetup(xMailSetup)
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= "<br/>"
        Dim confirmMail As New StringBuilder
        xMailSetup.MailBody = ""
        confirmMail.AppendLine("<table style='width: 350px; border-style:Solid; border-width:1px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")
        confirmMail.Append("<tr style='font-family: calibri; color: #4B6B94;'>")
        confirmMail.Append("<th style='align: center; font-size: 15px; border-style: solid;border-right:None;  border-top-color: #000000;border-left:None;   border-width: 0.1px; height: 21px' colspan='14'>")
        confirmMail.Append("<b>Rate </b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #C0C0C0;'>")
        confirmMail.Append("<td style='width: 200px; border-style: solid; border-top-color: #000000; border-width: 0.1px;font-size: 10pt;  height: 10px' align='left' >")
        confirmMail.Append("<b>Service</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 5px' align='center'  >")
        confirmMail.Append("<b>Port</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Line</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Size</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Status</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Doc Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>From</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>To</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Handover</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>From Range</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>To Range</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Rate</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;  border-width: 0.1px; font-size: 10pt; height: 10px' align='center'>")
        confirmMail.Append("<b>Currency</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")

        For Each rc As RepeaterItem In repRateDetails.Items
            If CType(rc.FindControl("LstService"), DropDownList).SelectedValue <> 0 Then
                confirmMail.Append("<tr style='font-family: calibri;'>")
                confirmMail.Append("<td style='width: 200px; border-style: solid; border-top-color: #000000;border-left:None; border-right:None; border-width: 0.1px; height: 5px'>")
                confirmMail.Append(CType(rc.FindControl("LstService"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstPortId"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstLineId"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContSize"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 40px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContType"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000;border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstContStatus"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstDocType"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstHandlingMode"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstCargoType"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 80px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstPol"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("textFromRange"), TextBox).Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("textToRange"), TextBox).Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 50px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("textBaseRate"), TextBox).Text)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 60px; border-style: solid; border-top-color: #000000; border-right:None; border-width: 0.1px; height: 5px' align='center'>")
                confirmMail.Append(CType(rc.FindControl("lstCurrency"), DropDownList).SelectedItem.Text)
                confirmMail.Append(" </td>")
                confirmMail.Append(" </tr>")

            End If
        Next
        confirmMail.Append("</table>")
        'confirmMail.AppendLine("<table style='width: 350px; border-style:Solid; border-width:1px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")

        'confirmMail.Append("</table>")
        xMailSetup.MailBody = "Dear Customer, "
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "Please see below for the quatation:"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= confirmMail.ToString
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "<b>Thanks & Regards </b>" & "<br>"
        'xMailSetup.Subject = "Booking confirmation"
        Dim p As New CompanyMaster
        p.CompanyId = Session.Item("LoginCompany")
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"
        pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, "amit.kumar@elogisol.in,amit.singh@elogisol.in,lalit@elogisol.in", "vrohit248@gmail.com", "vrohit248@gmail.com", xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        'pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        If pStr <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sending failed.")
        Else
            lblErrorMessage.Visible = True
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sent Successfully.")
        End If
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pExtUploadFile As ExtUploadFile = prepareObjectFroUploadData()
        ExtUploadFile.UploadFileDataIGM(pExtUploadFile)
        If pExtUploadFile.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtUploadFile.Errormsg)
            Return
        End If
        Dim pQuatationDtls As New QuatationDtls
        pQuatationDtls.TerminalId = pExtUploadFile.FileId
        Try
            hdnFileId.Value = pExtUploadFile.FileId
        Catch ex As Exception
            hdnFileId.Value = 0
        End Try
        pQuatationDtls.CreatedBy = Session.Item("LoginUser")
        QuatationDtls.UploadQuatationDtls(pQuatationDtls)
        If pQuatationDtls.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pQuatationDtls.Errormsg)
            Return
        End If

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = hdnFileId.Value
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_QUOTATION_DTLS_BY_ID", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
        repRateDetails.DataSource = dbr
        repRateDetails.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'Else
        '    tblReport.Visible = False
        If dbr.HasRows Then

        Else

            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        'End If
        dbr.Close()
        db.CloseDB()
        linkDownload.Visible = False
        'btnDownload.Visible = True
        btnUpload.Visible = False
    End Sub
    Private Function prepareObjectFroUploadData() As ExtUploadFile
        Dim pUploadData As New ExtUploadFile
        pUploadData.CreatedBy = Session.Item("LoginUser")
        pUploadData.TerminalId = Session.Item("LoginTerminal")
        pUploadData.FileName = fuFileLocation.FileName
        pUploadData.UploadFileDataList = New ArrayList
        Try
            Dim fileobj As HttpPostedFile = fuFileLocation.PostedFile
            Dim objStreamReader As System.IO.StreamReader
            Dim strLine As String = ""
            Dim index As Long = 1
            If fileobj IsNot Nothing Then
                objStreamReader = New System.IO.StreamReader(fileobj.InputStream)
                strLine = objStreamReader.ReadLine
                Do While Not strLine Is Nothing
                    Dim p As New UploadFileData
                    p.FileData = strLine
                    p.RecordId = index
                    p.TerminalId = Session.Item("LoginTerminal")
                    pUploadData.UploadFileDataList.Add(p)
                    index += 1
                    strLine = objStreamReader.ReadLine
                Loop
            End If
        Catch ex As Exception
        End Try
        Return pUploadData
    End Function

    Protected Sub linkDownload_Click(sender As Object, e As System.EventArgs) Handles linkDownload.Click
        Dim filePath As String = Server.MapPath("~/Format/Quotation.csv")
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath))
        Response.WriteFile(filePath)
        Response.End()
    End Sub
End Class

