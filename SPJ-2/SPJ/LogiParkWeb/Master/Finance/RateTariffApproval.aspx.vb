Imports CommonSendingMailLibary
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports System.Xml

Partial Class Master_Finance_RateTariffApproval
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim addrows As Integer = 5
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim glPortMaster As New ExtPortMaster
    Dim glPol As New ExtPortMaster
    Dim glCustomerMaster As New ExtCustomerMaster
    Dim glIsoCode As New ArrayList
    Dim glServiceMode As New ArrayList
    Dim glTerminalMaster As New ArrayList
    Dim glTolocation As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            ' tvServices.Enabled = False
            Dim lngRateId As Integer = Request.QueryString("RATEID")
            If lngRateId > 0 Then
                Dim pRT As New ExtRateMaster
                pRT.RateId = lngRateId
                pRT.TerminalId = Session.Item("LoginTerminal")
                pRT.CompanyId = Session.Item("CompanyId")
                ExtRateMaster.ReturnRateMasterWithDetailsTrn(pRT)
                prepareControls(pRT)
                manageUserControls(True)
                manageControls(True)
                btnAdd.Visible = True
                btnSave.Visible = True
            End If
        End If
    End Sub



    Sub LoadTreeViewData()
        ' tvServices.Nodes.Clear()
        Dim pExtRateMaster As New ExtRateMaster
        pExtRateMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As RateMaster In ExtRateMaster.ReturnRateMasterListByterminalId(pExtRateMaster)
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
                ' Functions.treeViewNodeSetup(tvServices, "0", obj.RateId, str)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        ' btnAdd.Visible = pVisible
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnAdd.Visible = Not pVisible


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
                Dim p As New RateDetails
                p.ContStatus = "0"
                p.ContType = "ALL"
                p.HandlingMode = "0"
                p.ContSize = "0"
                p.CargoType = "0"
                p.DocType = "0"
                p.ContSize = "0"
                p.IsEnable = "Y"
                arr.Add(p)
            Next
        End If
        repRateDetails.DataSource = arr
        repRateDetails.DataBind()
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
        glPortMaster.PortList = ExtPortMaster.ReturnPortMasterList(pPort)

        Dim pPol As New ExtPortMaster
        pPol.TerminalId = Session.Item("LoginTerminal")
        glPol.PortList = ExtPortMaster.ReturnPortMasterIndiaGateway(pPol)

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
            For Each PL1 As PortMaster In glPol.PortList
                lst.Items.Add(New ListItem(PL1.PortName, PL1.PortId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareControls(ByVal pExtRate As ExtRateMaster)
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
        rows = pExtRate.RateDetailsList.Count
        fillRepeator(pExtRate.RateDetailsList)
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

    'Protected Sub tvServices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvServices.SelectedNodeChanged
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    'prepareControls(tvServices.SelectedNode)
    '    SaveViewState()
    '    manageUserControls(True)
    '    Functions.ControlFocus(btnAdd)
    'End Sub
    'Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
    '    If Not ViewState.Item("SelectedNodePath") Is Nothing Then
    '        Dim node As TreeNode = tvServices.FindNode(ViewState.Item("SelectedNodePath"))
    '        If Not node Is Nothing Then
    '            node.Select()
    '        End If
    '    End If
    'End Sub

    'Protected Overrides Function SaveViewState() As Object
    '    If Not tvServices.SelectedNode Is Nothing Then
    '        ViewState.Item("SelectedNodePath") = tvServices.SelectedNode.ValuePath
    '        tvServices.ExpandAll()
    '    End If
    '    Return MyBase.SaveViewState
    'End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        If chkDisApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select DisApproved Status")
            Functions.ControlFocus(chkApproval)
            Return
        End If
        Dim pRateMaster As ExtRateMaster = ReturnObject()
        ExtRateMaster.Update(pRateMaster)

        If pRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRateMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "DisApproved Successfully.")
        manageUserControls(True)
        btnAdd.Visible = False
        btnSave.Visible = False
    End Sub
    Function ValidatedApproval() As Boolean
        Dim rtnBool As Boolean = True
        If chkApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Approved Status")
            rtnBool = False
            Functions.ControlFocus(chkApproval)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
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
        For Each rep As RepeaterItem In repRateDetails.Items

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
            Dim lstRateType As DropDownList = CType(rep.FindControl("lstRateType"), DropDownList)
            Dim lstDiscountType As DropDownList = CType(rep.FindControl("lstDiscountType"), DropDownList)
            Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
            Dim textBaseRate As TextBox = CType(rep.FindControl("textBaseRate"), TextBox)
            Dim textDiscount As TextBox = CType(rep.FindControl("textDiscount"), TextBox)
            Dim lstDocType As DropDownList = CType(rep.FindControl("lstDocType"), DropDownList)
            Dim lstPortId As DropDownList = CType(rep.FindControl("lstPortId"), DropDownList)
            Dim lstPolId As DropDownList = CType(rep.FindControl("lstPolId"), DropDownList)

            Dim lstLineId As DropDownList = CType(rep.FindControl("lstLineId"), DropDownList)
            If textFromRang.Text.ToString.Trim = String.Empty Then
                textFromRang.Text = 0
            End If
            If textTorang.Text.ToString.Trim = String.Empty Then
                textTorang.Text = 0
            End If
            If textRate.Text.ToString.Trim = String.Empty Then
                textRate.Text = 0
            End If
            If textBaseRate.Text.ToString.Trim = String.Empty Then
                textBaseRate.Text = 0
            End If
            If textDiscount.Text.ToString.Trim = String.Empty Then
                textDiscount.Text = 0
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
                    If Double.Parse(textDiscount.Text.Trim) < 0 Or textDiscount.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                        Functions.ControlFocus(textDiscount)
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
                    If Double.Parse(textRate.Text) < 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value.")
                        Functions.ControlFocus(textRate)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try

                For Each rep1 As RepeaterItem In repRateDetails.Items

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
                    Dim lstRateType1 As DropDownList = CType(rep1.FindControl("lstRateType"), DropDownList)
                    Dim textRate1 As TextBox = CType(rep1.FindControl("textRate"), TextBox)
                    Dim textBaseRate1 As TextBox = CType(rep1.FindControl("textBaseRate"), TextBox)
                    Dim textDiscount1 As TextBox = CType(rep1.FindControl("textDiscount"), TextBox)
                    Dim lstDiscountType1 As DropDownList = CType(rep1.FindControl("lstDiscountType"), DropDownList)
                    Dim lstDocType1 As DropDownList = CType(rep1.FindControl("lstDocType"), DropDownList)
                    Dim lstPortId1 As DropDownList = CType(rep1.FindControl("lstPortId"), DropDownList)
                    Dim lstPolId1 As DropDownList = CType(rep1.FindControl("lstPolId"), DropDownList)
                    Dim lstLineId1 As DropDownList = CType(rep1.FindControl("lstLineId"), DropDownList)

                    If rep.ItemIndex <> rep1.ItemIndex Then

                        If textFromRang1.Text.ToString.Trim = String.Empty Then
                            textFromRang1.Text = 0
                        End If
                        If textTorang1.Text.ToString.Trim = String.Empty Then
                            textTorang1.Text = 0
                        End If
                        If lstRateType1.SelectedItem.Text.ToString.Trim = String.Empty Then
                            lstRateType1.Text = 0
                        End If
                        If textRate1.Text.ToString.Trim = String.Empty Then
                            textRate1.Text = 0
                        End If
                        If textBaseRate1.Text.ToString.Trim = String.Empty Then
                            textBaseRate1.Text = 0
                        End If
                        If textDiscount1.Text.ToString.Trim = String.Empty Then
                            textDiscount1.Text = 0
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
                            If Double.Parse(textDiscount1.Text.Trim) < 0 Or textDiscount1.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                                Functions.ControlFocus(textDiscount1)
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
                            lstPolId.SelectedValue = lstPolId1.SelectedValue And
                            lstLineId.SelectedValue = lstLineId1.SelectedValue And
                            lstRateType.SelectedValue = lstRateType1.SelectedValue And
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
                            lstPolId.SelectedValue = lstPolId1.SelectedValue And
                            lstLineId.SelectedValue = lstLineId1.SelectedValue And
                              lstRateType.SelectedValue = lstRateType1.SelectedValue And
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
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And
                             lstPolId.SelectedValue = lstPolId1.SelectedValue And
                            lstLineId.SelectedValue = lstLineId1.SelectedValue And
                              lstRateType.SelectedValue = lstRateType1.SelectedValue And
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
                             lstPortId.SelectedValue = lstPortId1.SelectedValue And
                              lstPolId.SelectedValue = lstPolId1.SelectedValue And
                             lstLineId.SelectedValue = lstLineId1.SelectedValue And
                               lstRateType.SelectedValue = lstRateType1.SelectedValue And
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
        If ValidatedApproval() = False Then
            Return
        End If
        If chkApproval.Checked = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Approved Status")
            Functions.ControlFocus(chkApproval)
            Return
        End If
        Dim pRateMaster As ExtRateMaster = ReturnObject()
        ExtRateMaster.UpdateApprove(pRateMaster)

        If pRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRateMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Approved Successfully.")
        If String.IsNullOrEmpty(SendMail()) Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully and mail sent.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully and mail sending failure.")
        End If
        manageUserControls(True)
        btnAdd.Visible = False
        btnSave.Visible = False

    End Sub

    Function ReturnObject() As ExtRateMaster
        Dim pRM As New ExtRateMaster
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
        End If
        If chkDisApproval.Checked Then
            pRM.ApprovalFlage = "N"
        End If
        pRM.ApprovedBy = Session.Item("LoginUser")
        pRM.RateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items
            If (CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value > 0) Or (CType(rc.FindControl("textToRange"), TextBox).Text <> Nothing AndAlso Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text) > 0) Then
                Dim p As New RateDetails
                p.TerminalId = Session.Item("LoginTerminal")
                Try
                    p.PolId = CType(rc.FindControl("lstPolId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
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
                    p.RateType = CType(rc.FindControl("lstRateType"), DropDownList).SelectedValue
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
                Try
                    p.DiscountType = CType(rc.FindControl("lstDiscountType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.Discount = Double.Parse(CType(rc.FindControl("textDiscount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.Rate = Double.Parse(CType(rc.FindControl("textRate"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.HandlingMode = CType(rc.FindControl("lstHandlingMode"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try

                pRM.RateDetailsList.Add(p)
            End If

        Next

        Return pRM
    End Function

    Function ReturnObjectDisapprove() As ExtRateMaster
        Dim pRM As New ExtRateMaster
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
        End If
        Return pRM
    End Function


    Sub manageControls(ByVal pEnable As Boolean)

        chkApproval.Enabled = pEnable
        chkDisApproval.Enabled = pEnable

    End Sub
    Sub manageRep()
        For Each e As RepeaterItem In repRateDetails.Items
            Dim dblDiscount = 0, dblBaseRate As Double = 0
            Dim strDiscType As String = ""
            Try
                dblDiscount = CType(e.FindControl("textDiscount"), TextBox).Text
            Catch ex As Exception
            End Try
            Try
                dblBaseRate = CType(e.FindControl("textBaseRate"), TextBox).Text
            Catch ex As Exception
            End Try
            strDiscType = lstCustomerType.SelectedValue
            If CType(e.FindControl("lstDiscountType"), DropDownList).SelectedValue = Nothing Then
                CType(e.FindControl("textDiscount"), TextBox).Enabled = False
            End If
            If lstCustomerType.SelectedValue = Nothing Then
                CType(e.FindControl("lstDiscountType"), DropDownList).Enabled = False
                CType(e.FindControl("textDiscount"), TextBox).Enabled = False
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                CType(e.FindControl("lstCommodity"), DropDownList).Enabled = True
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True

            Else
                CType(e.FindControl("lstDiscountType"), DropDownList).Enabled = True
                CType(e.FindControl("textDiscount"), TextBox).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = False
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = False
                CType(e.FindControl("lstContType"), DropDownList).Enabled = False
                CType(e.FindControl("lstCommodity"), DropDownList).Enabled = False
                CType(e.FindControl("lstCargoType"), DropDownList).Enabled = False
                CType(e.FindControl("textFromRange"), TextBox).Enabled = False
                CType(e.FindControl("textToRange"), TextBox).Enabled = False
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = False
                If CType(e.FindControl("lstDiscountType"), DropDownList).SelectedValue = Nothing Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate
                    CType(e.FindControl("textDiscount"), TextBox).Text = 0
                    CType(e.FindControl("textDiscount"), TextBox).Enabled = False
                ElseIf strDiscType = "P" Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - ((dblBaseRate * dblDiscount) / 100)
                ElseIf strDiscType = "I" Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - dblDiscount
                End If

            End If

            CType(e.FindControl("textRate"), TextBox).Enabled = False
        Next
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
        'End If


    End Sub
    Protected Sub lstService_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstService.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        SetRangeText(lstService.SelectedValue)
        If lstCustomerType.SelectedValue <> Nothing Then



            Dim p As New ExtRateMaster
            p.TerminalId = Session.Item("LoginTerminal")
            p.CompanyId = Session.Item("CompanyId")
            p.FromDate = Today.Day & "/" & Today.Month & "/" & Today.Year
            p.ToDate = Today.Day & "/" & Today.Month & "/" & Today.Year
            p.ServiceId = lstService.SelectedValue
            ExtRateMaster.ReturnRateMasterByServiceIdWithCurrentDate(p)
            If p.RateId <= 0 Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Public tariff not fount")
                Functions.ControlFocus(lstService)

            End If

            ExtRateMaster.ReturnRateMasterWithDetailsTrn(p)
            textValidFromDate.Text = p.FromDate
            textValidToDate.Text = p.ToDate
            Dim arr As New ArrayList
            If p.RateDetailsList.Count = 0 Then
                fillRepeator(New ArrayList)
                manageRep()
                Return
            Else
                For Each r As RateDetails In p.RateDetailsList
                    r.RateKeyId = 0
                    arr.Add(r)
                Next
            End If
            fillRepeator(arr)
            manageRep()
        End If
    End Sub

    Protected Sub repRateDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRateDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If lstCustomerType.SelectedValue <> Nothing Then
                CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = False
                CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = False
            Else
                CType(e.Item.FindControl("lstDiscountType"), DropDownList).Enabled = True
                CType(e.Item.FindControl("textDiscount"), TextBox).Enabled = True
            End If
            CType(e.Item.FindControl("textRate"), TextBox).Enabled = False
        End If

    End Sub

    Private Function rm() As Object
        Throw New NotImplementedException
    End Function
    ''' <summary>
    ''' Added 12/10/2023
    ''' </summary>
    ''' <returns></returns>
    Function SendMail() As String
        Dim statusMail As New StringBuilder
        Dim con1 As New OleDbConnection
        Dim strConnectionString1 As String = ""
        Dim xMailSetupFt As String = ""
        strConnectionString1 = "Provider=MSDAORA;Data Source=SPJLIVE;Persist Security Info=True;Password=SPjlive_961618#;User ID=SPJLIVE"
        con1 = New OleDbConnection(strConnectionString1)
        Dim ada1 As OleDbDataAdapter = New OleDbDataAdapter
        statusMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        statusMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
        statusMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='10'  >")
        statusMail.Append("<b>Follwing Rate is Approved...</b>")
        statusMail.Append("</th>")
        statusMail.Append("</tr>")
        statusMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        statusMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Customer Type</b>")
        statusMail.Append("</td>")
        statusMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Customer</b>")
        statusMail.Append("</td>")
        statusMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Rate Id</b>")
        statusMail.Append("</td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Valid From Date</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Valid To Date</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Service</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Tax Group</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Remarks</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Approved By</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Approved On</b>")
        statusMail.Append(" </td>")
        statusMail.Append("</tr>")
        Try
            Dim ada2 As OleDbDataAdapter = New OleDbDataAdapter
            Dim cmd As OleDbCommand = con1.CreateCommand
            cmd.Connection = con1
            cmd.CommandType = CommandType.StoredProcedure
            Dim procName As String = ""
            Dim procParam As String = ""
            procParam &= "," & hdnRateId.Value
            procName = "AUTO_MAIL.SP_RATE_MASTER_APPROVAL"
            cmd.CommandText = procName & "(" & procParam & ")"
            ada2.SelectCommand = cmd
            Dim ds As New DataSet
            ada2.Fill(ds)
            Dim SR As Long = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                statusMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("CUSTOMER_TYPE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("CUSTOMER_NAME"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("RATE_ID"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("FROM_DATE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("TO_DATE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("SERVICE_NAME"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("TAX_GROUPP"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("REMARKS"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("APPROVED_BY"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                statusMail.Append(ds.Tables(0).Rows(i)("APPROVED_ON"))
                statusMail.Append(" </td>")
            Next
            statusMail.Append(" </table>")
            xMailSetupFt &= "<font color='#00008B'>Dear All,"
            xMailSetupFt &= "<br/>"
            xMailSetupFt &= "<br/>"
            xMailSetupFt &= "<font color='#00008B'>Please find here below the list of approved rates: "
            xMailSetupFt &= "<br/>"
            xMailSetupFt &= "<br/>"
            xMailSetupFt &= statusMail.ToString
            xMailSetupFt &= "<br/>"
            xMailSetupFt &= (<![CDATA[<font color='#00008B'>Thanks & Regards
                            <br></font><br><b><font color='Red'>SPJ CARGO PVT. LTD.
                            </b></font><font color='#00008B'><br>Regd. Office : D-9/3, 
                            Okhla Industrial Area Phase-1 New Delhi-110020 <br> 
                            Tel: +91 - 11-41062143-2147<br> </font>]]>.Value())
            xMailSetupFt &= ("<br/>")
            xMailSetupFt &= ("<br/>")
            xMailSetupFt &= ("<br/>")
            xMailSetupFt &= ("<font color='#00008B'>**********This is system generated auto mail. For any query please get in touch with Mr Akshay Saxena (+91-9205280272)**********")

            Dim strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim con As New OleDbConnection(strConnectionString)
            con.Open()
            Dim strCmd As String
            strCmd = "SELECT TO_CHAR(SYSDATE,'DD/MM/YYYY')MAIL_DATE , TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=492 AND TERMINAL_ID=1"
            Dim ada As New OleDbDataAdapter(strCmd, strConnectionString)
            Dim dtMailSetupNew As New DataSet()
            ada.Fill(dtMailSetupNew)
            Dim strTOMailID As String = ""
            Try
                strTOMailID = dtMailSetupNew.Tables(0).Rows(0)("TO_MAIL_IDS")
            Catch
                strTOMailID = ""
            End Try
            Dim strToID As String = ""
            Try
                strToID = dtMailSetupNew.Tables(0).Rows(0)("TO_MAIL_IDS")
            Catch
                strToID = ""
            End Try
            Dim strCCID As String = ""
            Try
                strCCID = dtMailSetupNew.Tables(0).Rows(0)("CC_IDS")
            Catch
                strCCID = ""
            End Try
            Dim strBccID As String = ""
            Try
                strBccID = dtMailSetupNew.Tables(0).Rows(0)("BCC_IDS")
            Catch
                strBccID = ""
            End Try
            Dim strCmdNew As String
            strCmdNew = "SELECT  FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=1"
            ada = New OleDbDataAdapter(strCmdNew, strConnectionString)
            Dim dtMailConfig As New DataTable()
            ada.Fill(dtMailConfig)
            con.Close()
            con1.Close()
            Dim statusStr = MailSender.SendMailToCcBccIDWithOrWithoutAttachment(
                dtMailConfig.Rows(0)("FROM_ID").ToString(),
                dtMailConfig.Rows(0)("FROM_NAME").ToString(),
                strToID,
                strCCID,
                strBccID,
                strBccID,
                xMailSetupFt.ToString(),
                dtMailConfig.Rows(0)("SMTP_SERVER").ToString(),
                dtMailConfig.Rows(0)("PASSWORD").ToString(),
                dtMailConfig.Rows(0)("PORT_NO").ToString())
            Return statusStr
        Catch ex As Exception
        End Try
    End Function

End Class
