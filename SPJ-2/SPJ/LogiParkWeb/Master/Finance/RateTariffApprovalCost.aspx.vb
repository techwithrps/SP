Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Finance_RateTariffApprovalCost
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim addrows As Integer = 5
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim glPortMaster As New ExtPortMaster
    Dim glPol As New ExtPortMaster
    Dim glCustomerMaster As New ExtCustomerMaster
    Dim glServiceMode As New ArrayList
    Dim glTerminalMaster As New ArrayList
    Dim glTolocation As New ArrayList
    Dim glIsoCode As New ArrayList
    Dim glPolMaster As New ExtPortMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            tvServices.Enabled = False
            Dim lngRateId As Integer = Request.QueryString("RATEID")
            If lngRateId > 0 Then
                Dim pRT As New ExtCostRatemaster
                pRT.TerminalId = Session.Item("LoginTerminal")
                pRT.RateId = lngRateId
                ExtCostRatemaster.ReturnCostRateMasterWithDetailsTrn(pRT)
                prepareControls(pRT)
                manageUserControls(True)
                manageControls(True)
                btnAdd.Visible = True
                btnSave.Visible = True
            End If
        End If
    End Sub
    Sub LoadTreeViewData()
        tvServices.Nodes.Clear()
        Dim pExtCostRateMaster As New ExtCostRatemaster
        pExtCostRateMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As CostRateMaster In ExtCostRatemaster.ReturnCostRateMasterListByterminalId(pExtCostRateMaster)
                Dim p As New ServiceMaster
                p.TerminalId = obj.TerminalId
                p.ServiceId = obj.ServiceId
                ServiceMaster.ReturnServiceMasterByServiceId(p)
                Dim str As String = p.ServiceName & " (" & obj.FromDate & "-" & obj.ToDate & ")"
                If obj.CustomerId > 0 Then
                    Dim pcu As New ExtCustomerMaster
                    pcu.CustomerId = obj.CustomerId
                    pcu.TerminalId = obj.TerminalId
                    ExtCustomerMaster.ReturnCustomerMaster(pcu)
                    str &= " -" & pcu.CustomerCode
                End If
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
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible


        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New CostRateDetails
                p.ContType = "ALL"
                'Change here
                p.CargoType = 0
                arr.Add(p)
            Next
        End If
        repRateDetailsCost.DataSource = arr
        repRateDetailsCost.DataBind()
    End Sub

    Sub ListControlDataBind()
        Dim pTaxGroup As New TaxGroup
        pTaxGroup.TerminalId = Session.Item("LoginTerminal")
        lstTaxGroup.DataSource = TaxGroup.ReturnTaxGroupList(pTaxGroup)
        lstTaxGroup.DataTextField = "TaxGroupCode"
        lstTaxGroup.DataValueField = "TaxGroupId"
        lstTaxGroup.DataBind()
        lstTaxGroup.Items.Insert(0, (New ListItem("----Select----", "0")))

        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pService)
        lstService.DataTextField = "ServiceName"
        lstService.DataValueField = "ServiceId"
        lstService.DataBind()
        lstService.Items.Insert(0, (New ListItem("----Select----", "0")))

        Dim pCusType As New CustomerType
        pCusType.TerminalId = Session.Item("LoginTerminal")
        lstCustomerType.DataSource = CustomerType.ReturnCustomerTypeList(pCusType)
        lstCustomerType.DataTextField = "CustomerTypeName"
        lstCustomerType.DataValueField = "CustomerTypeCode"
        lstCustomerType.DataBind()
        lstCustomerType.Items.Insert(0, (New ListItem("----Public----", "")))
        lstCustomerType.SelectedValue = ""

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
        glPortMaster.PortList = ExtPortMaster.ReturnPortMasterList1(pPort)

        Dim pPol As New ExtPortMaster
        pPol.TerminalId = Session.Item("LoginTerminal")
        glPolMaster.PortList = ExtPortMaster.ReturnPortMasterIndiaGateway(pPol)

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
    End Sub
    Protected Sub prepareCreatedBy(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "ALL"))
            For Each i As RateMaster In rm()
                lst.Items.Add(New ListItem(i.RateId, i.RateId))
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
    Protected Sub preparePol(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
            For Each PL As PortMaster In glPolMaster.PortList
                lst.Items.Add(New ListItem(PL.PortName, PL.PortId))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub prepareControls(ByVal pExtRate As ExtCostRatemaster)
        hdnRateId.Value = pExtRate.RateId
        textValidFromDate.Text = pExtRate.FromDate
        textValidToDate.Text = pExtRate.ToDate
        lstCustomerType.SelectedValue = pExtRate.CustomerType
        lstCustomer.SelectedValue = pExtRate.CustomerId
        lstService.SelectedValue = pExtRate.ServiceId
        textRemarks.Text = pExtRate.Remarks
        If pExtRate.ApprovalFlage = "Y" Then
            chkApproval.Checked = True
        End If
        If pExtRate.ApprovalFlage = "Y" Then
            chkDisApproval.Checked = True
        End If

        rows = pExtRate.CostRateDetailsList.Count
        fillRepeator(pExtRate.CostRateDetailsList)
        SetRangeText(lstService.SelectedValue)
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

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvServices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvServices.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'prepareControls(tvServices.SelectedNode)
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

    Protected Overrides Function SaveViewState() As Object
        If Not tvServices.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvServices.SelectedNode.ValuePath
            tvServices.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If chkDisApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Approved Status")
            Functions.ControlFocus(chkDisApproval)
            Return
        End If
        Dim pCostRateMaster As ExtCostRatemaster = ReturnObject()
        ExtCostRatemaster.Update(pCostRateMaster)

        If pCostRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCostRateMaster.Errormsg)
            Return
        End If
        manageUserControls(True)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Rate Not Approved")
        btnAdd.Visible = False
        btnSave.Visible = False
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
        If lstCustomerType.SelectedValue <> "" And lstCustomer.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The Customer.")
            rtnBool = False
            Functions.ControlFocus(lstCustomer)
            Return rtnBool
            Exit Function
        End If
        If lstService.SelectedValue <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The Service.")
            rtnBool = False
            Functions.ControlFocus(lstService)
            Return rtnBool
            Exit Function
        End If
        If chkApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Approved Ststus")
            rtnBool = False
            Functions.ControlFocus(chkApproval)
            Return rtnBool
            Exit Function
        End If
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
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should be gratter than From Date")
            rtnBool = False
            Functions.ControlFocus(textValidFromDate)
            Return rtnBool
            Exit Function
        End If

        If dtTo < Today.Date Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should not be Less Than Today")
            rtnBool = False
            Functions.ControlFocus(textValidToDate)
            Return rtnBool
            Exit Function
        End If

        For Each rep As RepeaterItem In repRateDetailsCost.Items

            Dim hdnRateKeyId As HiddenField = CType(rep.FindControl("hdnRateKeyId"), HiddenField)
            Dim lstContSize As DropDownList = CType(rep.FindControl("lstContSize"), DropDownList)
            Dim lstContType As DropDownList = CType(rep.FindControl("lstContType"), DropDownList)
            Dim lstContStatus As DropDownList = CType(rep.FindControl("lstContStatus"), DropDownList)
            Dim lstCargotype As DropDownList = CType(rep.FindControl("lstCargoType"), DropDownList)
            Dim lstCommodity As DropDownList = CType(rep.FindControl("lstCommodity"), DropDownList)
            Dim lsthandingmode As DropDownList = CType(rep.FindControl("lstHandlingMode"), DropDownList)
            Dim lstPol As DropDownList = CType(rep.FindControl("lstPol"), DropDownList)
            Dim textFromRang As TextBox = CType(rep.FindControl("textFromRange"), TextBox)
            Dim textTorang As TextBox = CType(rep.FindControl("textToRange"), TextBox)
            Dim textBaseRate As TextBox = CType(rep.FindControl("textBaseRate"), TextBox)
            Dim lstDocType As DropDownList = CType(rep.FindControl("lstDocType"), DropDownList)
            Dim lstPortId As DropDownList = CType(rep.FindControl("lstPortId"), DropDownList)
            Dim lstLineId As DropDownList = CType(rep.FindControl("lstLineId"), DropDownList)
            Dim LstDetMethod As DropDownList = CType(rep.FindControl("LstDetMethod"), DropDownList)
            If textFromRang.Text.ToString.Trim = String.Empty Then
                textFromRang.Text = 0
            End If
            If textTorang.Text.ToString.Trim = String.Empty Then
                textTorang.Text = 0
            End If

            If textBaseRate.Text.ToString.Trim = String.Empty Then
                textBaseRate.Text = 0
            End If

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

                    If Double.Parse(textTorang.Text.Trim) <= Double.Parse(textFromRang.Text.Trim) And Double.Parse(textTorang.Text.Trim) <> 0 And Double.Parse(textFromRang.Text.Trim) <> 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Weight should be less than To Weight.")
                        Functions.ControlFocus(textTorang)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Double.Parse(textBaseRate.Text) < 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value.")
                        Functions.ControlFocus(textBaseRate)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try

                For Each rep1 As RepeaterItem In repRateDetailsCost.Items

                    Dim hdnRateKeyId1 As HiddenField = CType(rep1.FindControl("hdnRateKeyId"), HiddenField)
                    Dim lstContSize1 As DropDownList = CType(rep1.FindControl("lstContSize"), DropDownList)
                    Dim lstContType1 As DropDownList = CType(rep1.FindControl("lstContType"), DropDownList)
                    Dim lstContStatus1 As DropDownList = CType(rep1.FindControl("lstContStatus"), DropDownList)
                    Dim lstCargotype1 As DropDownList = CType(rep1.FindControl("lstCargoType"), DropDownList)
                    Dim lstCommodity1 As DropDownList = CType(rep1.FindControl("lstCommodity"), DropDownList)
                    Dim lsthandingmode1 As DropDownList = CType(rep1.FindControl("lstHandlingMode"), DropDownList)
                    Dim lstPol1 As DropDownList = CType(rep1.FindControl("lstPol"), DropDownList)
                    Dim textFromRang1 As TextBox = CType(rep1.FindControl("textFromRange"), TextBox)
                    Dim textTorang1 As TextBox = CType(rep1.FindControl("textToRange"), TextBox)
                    Dim textBaseRate1 As TextBox = CType(rep1.FindControl("textBaseRate"), TextBox)
                    Dim lstDocType1 As DropDownList = CType(rep1.FindControl("lstDocType"), DropDownList)
                    Dim lstPortId1 As DropDownList = CType(rep1.FindControl("lstPortId"), DropDownList)
                    Dim lstLineId1 As DropDownList = CType(rep1.FindControl("lstLineId"), DropDownList)
                    Dim LstDetMethod1 As DropDownList = CType(rep1.FindControl("LstDetMethod"), DropDownList)
                    If rep.ItemIndex <> rep1.ItemIndex Then

                        If textFromRang1.Text.ToString.Trim = String.Empty Then
                            textFromRang1.Text = 0
                        End If
                        If textTorang1.Text.ToString.Trim = String.Empty Then
                            textTorang1.Text = 0
                        End If

                        If textBaseRate1.Text.ToString.Trim = String.Empty Then
                            textBaseRate1.Text = 0
                        End If

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

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And
                            lstContType.SelectedValue = lstContType1.SelectedValue And
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And
                            lstPol.SelectedValue = lstPol1.SelectedValue And
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And
                            Double.Parse(textFromRang.Text.Trim) = Double.Parse(textFromRang1.Text.Trim) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And
                            lstContType.SelectedValue = lstContType1.SelectedValue And
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And
                            lstPol.SelectedValue = lstPol1.SelectedValue And
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And
                            Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textFromRang1.Text.Trim) And
                            Double.Parse(textFromRang.Text.Trim) < Double.Parse(textFromRang1.Text.Trim) And
                             Double.Parse(textTorang.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And
                            lstContType.SelectedValue = lstContType1.SelectedValue And
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And
                            lstPol.SelectedValue = lstPol1.SelectedValue And
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And
                          Double.Parse(textTorang.Text.Trim) > Double.Parse(textFromRang1.Text.Trim) And
                            Double.Parse(textTorang.Text.Trim) < Double.Parse(textTorang1.Text.Trim) And
                           Double.Parse(textTorang1.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And
                             lstCommodity.SelectedValue = lstCommodity1.SelectedValue And
                             lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And
                             lstContSize.SelectedValue = lstContSize1.SelectedValue And
                             lstContType.SelectedValue = lstContType1.SelectedValue And
                             lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                             lstDocType.SelectedValue = lstDocType1.SelectedValue And
                             lstPol.SelectedValue = lstPol1.SelectedValue And
                              LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And
                             lstPortId.SelectedValue = lstPortId1.SelectedValue And
                             Double.Parse(textFromRang.Text.Trim) <= Double.Parse(textFromRang1.Text.Trim) And
                             Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textTorang1.Text.Trim) And
                              Double.Parse(textTorang1.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                        End If
                    End If
                Next
            End If
        Next
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If ValidationCheck() = False Then
        '    Return
        'End If
        If chkApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Approved Status")
            Functions.ControlFocus(chkApproval)
            Return
        End If
        Dim pCostRateMaster As ExtCostRatemaster = ReturnObject()
        ExtCostRatemaster.Update(pCostRateMaster)

        If pCostRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCostRateMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Approved Successfully.")
        manageUserControls(True)
        btnAdd.Visible = False
        btnSave.Visible = False

    End Sub

    Function ReturnObject() As ExtCostRatemaster
        Dim pRM As New ExtCostRatemaster
        Try
            pRM.RateId = hdnRateId.Value
        Catch ex As Exception
        End Try
        pRM.CreatedBy = Session.Item("LoginUser")
        pRM.TerminalId = Session.Item("LoginTerminal")
        pRM.FromDate = textValidFromDate.Text
        pRM.ToDate = textValidToDate.Text
        pRM.CustomerType = lstCustomerType.SelectedValue
        If lstCustomerType.SelectedValue = "" Then
            pRM.CustomerId = 0
        Else
            pRM.CustomerId = lstCustomer.SelectedValue
        End If

        pRM.ServiceId = lstService.SelectedValue
        pRM.Remarks = textRemarks.Text
        If chkApproval.Checked Then
            pRM.ApprovalFlage = "Y"
        Else
            pRM.ApprovalFlage = "N"
        End If
        pRM.CostRateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetailsCost.Items
            If (CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value > 0) Or (CType(rc.FindControl("textToRange"), TextBox).Text <> Nothing AndAlso Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text) > 0) Then
                Dim p As New CostRateDetails
                p.TerminalId = Session.Item("LoginTerminal")
                Try
                    p.PortId = CType(rc.FindControl("lstPortId"), DropDownList).SelectedValue
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
                Try
                    p.Rate = Double.Parse(CType(rc.FindControl("textBaseRate"), TextBox).Text)
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

                pRM.CostRateDetailsList.Add(p)
            End If

        Next

        Return pRM
    End Function


    Sub manageControls(ByVal pEnable As Boolean)

        chkApproval.Enabled = pEnable
        chkDisApproval.Enabled = pEnable

    End Sub
    Sub manageRep()
        For Each e As RepeaterItem In repRateDetailsCost.Items
            Dim dblDiscount = 0, dblBaseRate As Double = 0
            Dim strDiscType As String = ""
            Try
                dblBaseRate = CType(e.FindControl("textBaseRate"), TextBox).Text
            Catch ex As Exception
            End Try
            strDiscType = lstCustomerType.SelectedValue

            If lstCustomerType.SelectedValue = Nothing Then
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                CType(e.FindControl("lstCommodity"), DropDownList).Enabled = True
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
                CType(e.FindControl("lstPortId"), DropDownList).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
                CType(e.FindControl("lstPol"), DropDownList).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True
            Else
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                CType(e.FindControl("lstCommodity"), DropDownList).Enabled = True
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("lstPol"), DropDownList).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstHandlingMode"), DropDownList).Enabled = True
                CType(e.FindControl("lstPortId"), DropDownList).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
            End If

        Next
    End Sub
    Protected Sub btnNewRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewRows.Click
        Dim pRM As New ExtCostRatemaster
        pRM.CostRateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetailsCost.Items

            Dim p As New CostRateDetails
            p.TerminalId = Session.Item("LoginTerminal")
            Try
                p.PortId = CType(rc.FindControl("lstPortId"), DropDownList).SelectedValue
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
            Try
                p.Rate = Double.Parse(CType(rc.FindControl("textBaseRate"), TextBox).Text)
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

            pRM.CostRateDetailsList.Add(p)

        Next

        Dim i As Integer = 0
        While i < addrows
            Dim pRD As New RateDetails
            pRD.ContType = "ALL"
            pRD.CargoType = 0
            pRM.CostRateDetailsList.Add(pRD)

            i += 1
        End While

        fillRepeator(pRM.CostRateDetailsList)
        manageRep()
    End Sub
    Sub SetRangeText(ByVal pServiceId As Long)
        Dim p As New ServiceMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.ServiceId = pServiceId
        ServiceMaster.ReturnServiceMasterByServiceId(p)

        If p.UomId = 100 Then
            lblFromRange.Text = "Range From (Days)"
            lblToRange.Text = "Range To (Days)" & "<span class='mandatory'> *</span>"
        ElseIf p.UomId = 102 Then
            lblFromRange.Text = "Range From (Hrs)"
            lblToRange.Text = "Range To (Hrs)" & "<span class='mandatory'> *</span>"
        ElseIf p.UomId = 103 Then
            lblFromRange.Text = "Range From (Kgs)"
            lblToRange.Text = "Range To (Kgs)" & "<span class='mandatory'> *</span>"
        ElseIf p.UomId = 104 Then
            lblFromRange.Text = "Range From (%)"
            lblToRange.Text = "Range To (%)" & "<span class='mandatory'> *</span>"
        ElseIf p.UomId = 105 Then
            lblFromRange.Text = "Range From (Days)"
            lblToRange.Text = "Range To (Days)" & "<span class='mandatory'> *</span>"
        ElseIf p.UomId = 101 Then
            lblFromRange.Text = "Range From "
            lblToRange.Text = "Range To " & "<span class='mandatory'> *</span>"
        End If


    End Sub
    Protected Sub lstService_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstService.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        SetRangeText(lstService.SelectedValue)
        If lstCustomerType.SelectedValue <> Nothing Then



            Dim p As New ExtCostRatemaster
            p.TerminalId = Session.Item("LoginTerminal")
            p.FromDate = Today.Day & "/" & Today.Month & "/" & Today.Year
            p.ToDate = Today.Day & "/" & Today.Month & "/" & Today.Year
            p.ServiceId = lstService.SelectedValue
            ExtCostRatemaster.ReturnCostMasterByServiceIdWithCurrentDate(p)
            If p.RateId <= 0 Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Public tariff not fount")
                Functions.ControlFocus(lstService)

            End If

            ExtCostRatemaster.ReturnCostRateMasterWithDetailsTrn(p)
            textValidFromDate.Text = p.FromDate
            textValidToDate.Text = p.ToDate
            Dim arr As New ArrayList
            If p.CostRateDetailsList.Count = 0 Then
                fillRepeator(New ArrayList)
                manageRep()
                Return
            Else
                For Each r As RateDetails In p.CostRateDetailsList
                    r.RateKeyId = 0
                    arr.Add(r)
                Next
            End If
            fillRepeator(arr)
            manageRep()
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
            rep = repRateDetailsCost.Items(index1 - 1)
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
    Protected Sub repRateDetailsCost_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRateDetailsCost.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            '    If lstCustomerType.SelectedValue <> Nothing Then
            '        CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = False
            '        CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = False
            '    Else
            '        CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = True
            '        CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = True
            '    End If
            '    CType(e.Item.FindControl("textRate"), TextBox).Enabled = False
        End If

    End Sub

    Private Function rm() As Object
        Throw New NotImplementedException
    End Function


End Class
