Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Drawing
Imports System.Xml
Imports System.IO
Partial Class Master_Finance_CostTariff
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10S
    Dim addrows As Integer = 5
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim glPortMaster As New ExtPortMaster
    Dim glCustomerMaster As New ExtCustomerMaster
    Dim glIsoCode As New ArrayList
    Dim glServiceMode As New ArrayList
    Dim glTerminalMaster As New ArrayList
    Dim glTolocation As New ArrayList
    Dim glPolMaster As New ExtPortMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        Permission(p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            tvServices.Enabled = True
            btnGo.Enabled = True
            lstCustomerName.Enabled = True
            ' LoadTreeViewData()
            fillRepeator(New ArrayList)
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub
    Sub Permission(ByVal P As String)
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("~/MenuXml.xml"), New XmlReaderSettings())
        Dim ds2 As New DataSet
        ds2.ReadXml(xmlFile)
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub
    Sub LoadTreeViewData()
        tvServices.Nodes.Clear()
        Dim pExtRateMaster As New ExtCostRatemaster
        pExtRateMaster.TerminalId = Session.Item("LoginTerminal")
        pExtRateMaster.CustomerId = lstCustomerName.SelectedValue
        Try
            For Each obj As CostRateMaster In ExtCostRatemaster.ReturnCostRateMasterListByCustomerId(pExtRateMaster)
                Dim p As New ServiceMaster
                ' p.TerminalId = obj.TerminalId
                p.ServiceId = obj.ServiceId
                ServiceMaster.ReturnServiceMasterByServiceId(p)
                Dim str As String = ""
                If obj.CustomerType = "V" Then
                    Dim pVendorMaster As New VendorMaster
                    pVendorMaster.TerminalId = obj.TerminalId
                    pVendorMaster.VendorId = obj.CustomerId
                    VendorMaster.ReturnVendorMaster(pVendorMaster)
                    str = pVendorMaster.VendorName
                    str &= "-" & p.ServiceName
                ElseIf obj.CustomerType = "L" Then
                    Dim pcu As New ExtCustomerMaster
                    pcu.CustomerId = obj.CustomerId
                    pcu.TerminalId = obj.TerminalId
                    ExtCustomerMaster.ReturnCustomerMaster(pcu)
                    str = pcu.CustomerName
                    str &= "-" & p.ServiceName
                End If

                If obj.CustomerType = "C" Then
                    Dim pcu As New ExtCustomerMaster
                    pcu.CustomerId = obj.CustomerId
                    pcu.TerminalId = obj.TerminalId
                    ExtCustomerMaster.ReturnCustomerMaster(pcu)
                    str = pcu.CustomerName
                    str &= "-" & p.ServiceName
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
                Dim p As New CostRateDetails
                p.ContStatus = "0"
                p.ContType = "ALL"
                p.HandlingMode = "0"
                p.CargoType = "0"
                p.DocType = "0"
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
        lstService.DataSource = ServiceMaster.ReturnServiceMasterListNew(pService)
        lstService.DataTextField = "ServiceName"
        lstService.DataValueField = "ServiceId"
        lstService.DataBind()
        lstService.Items.Insert(0, (New ListItem("----Select----", "0")))

        'Dim pCusType As New CustomerType
        'pCusType.TerminalId = Session.Item("LoginTerminal")
        'lstCustomerType.DataSource = CustomerType.ReturnCustomerTypeList(pCusType)
        'lstCustomerType.DataTextField = "CustomerTypeName"
        'lstCustomerType.DataValueField = "CustomerTypeCode"
        'lstCustomerType.DataBind()
        'lstCustomerType.Items.Insert(0, (New ListItem("----Public----", "")))
        'lstCustomerType.SelectedValue = ""
        Dim pcustomermaster As New CustomerMaster
        pcustomermaster.CustomerType = "0"
        lstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterCostList(pcustomermaster)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Insert(0, (New ListItem("----Public----", "0")))
        Dim pCustomer As New ExtCustomerMaster
        pCustomer.CustomerType = "0"
        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterCostList(pCustomer)
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
        pPort.TerminalId = Session.Item("LoginTerminal")
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
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pExtCostRate As New ExtCostRatemaster
        pExtCostRate.RateId = pCodevalue.Value
        pExtCostRate.TerminalId = Session.Item("LoginTerminal")
        ExtCostRatemaster.ReturnCostRateMasterWithDetailsTrn(pExtCostRate)

        hdnRateId.Value = pExtCostRate.RateId
        textValidFromDate.Text = pExtCostRate.FromDate
        textValidToDate.Text = pExtCostRate.ToDate
        lstCustomerType.SelectedValue = pExtCostRate.CustomerType
        lstCustomer.SelectedValue = pExtCostRate.CustomerId
        lstService.SelectedValue = pExtCostRate.ServiceId
        'lstCustomerName.SelectedValue = pExtRate
        textRemarks.Text = pExtCostRate.Remarks
        If pExtCostRate.ApprovalFlage = "Y" Then
            chkApproval.Checked = True
        End If
        fillRepeator(pExtCostRate.CostRateDetailsList)
        SetRangeText(lstService.SelectedValue)
    End Sub

    Protected Sub lstCustomerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomerType.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pCustomer As New ExtCustomerMaster
        pCustomer.CustomerType = lstCustomerType.SelectedValue
        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterCostList(pCustomer)
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
        btnDownload.Visible = True
        tvServices.Enabled = False
        lstTaxGroup.Enabled = True
        lstService.SelectedValue = 0
        lstCustomerType.SelectedValue = "0"
        lstCustomer.SelectedValue = 0
        manageRep()
        If lstCustomerType.SelectedValue = "0" Then
            lstCustomer.Enabled = False
        End If
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
        If lstService.SelectedValue <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select The Service.")
            rtnBool = False
            Functions.ControlFocus(lstService)
            Return rtnBool
            Exit Function
        End If

        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing
        Try
            dtFrom = StingToDate(textValidFromDate.Text)
        Catch ex As Exception
        End Try
        Try
            dtTo = StingToDate(textValidToDate.Text)
        Catch ex As Exception

        End Try
        'If dtTo.Date <= dtFrom.Date Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should be greater than From Date")
        '    rtnBool = False
        '    Functions.ControlFocus(textValidFromDate)
        '    Return rtnBool
        '    Exit Function
        'End If

        'If dtTo.Date <= DateTime.Now.Date Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date should not be less than Today")
        '    rtnBool = False
        '    Functions.ControlFocus(textValidToDate)
        '    Return rtnBool
        '    Exit Function
        'End If

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

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And _
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            lstContType.SelectedValue = lstContType1.SelectedValue And _
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            lstPol.SelectedValue = lstPol1.SelectedValue And _
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And _
                            Double.Parse(textFromRang.Text.Trim) = Double.Parse(textFromRang1.Text.Trim) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And _
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            lstContType.SelectedValue = lstContType1.SelectedValue And _
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            lstPol.SelectedValue = lstPol1.SelectedValue And _
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And _
                            Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textFromRang1.Text.Trim) And _
                            Double.Parse(textFromRang.Text.Trim) < Double.Parse(textFromRang1.Text.Trim) And _
                             Double.Parse(textTorang.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                            lstCommodity.SelectedValue = lstCommodity1.SelectedValue And _
                            lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                            lstContType.SelectedValue = lstContType1.SelectedValue And _
                            lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                            lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                            lstPol.SelectedValue = lstPol1.SelectedValue And _
                             LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And _
                            lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                          Double.Parse(textTorang.Text.Trim) > Double.Parse(textFromRang1.Text.Trim) And _
                            Double.Parse(textTorang.Text.Trim) < Double.Parse(textTorang1.Text.Trim) And _
                           Double.Parse(textTorang1.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstCargotype.SelectedValue = lstCargotype1.SelectedValue And _
                             lstCommodity.SelectedValue = lstCommodity1.SelectedValue And _
                             lsthandingmode.SelectedValue = lsthandingmode1.SelectedValue And _
                             lstContSize.SelectedValue = lstContSize1.SelectedValue And _
                             lstContType.SelectedValue = lstContType1.SelectedValue And _
                             lstContStatus.SelectedValue = lstContStatus1.SelectedValue And _
                             lstDocType.SelectedValue = lstDocType1.SelectedValue And _
                             lstPol.SelectedValue = lstPol1.SelectedValue And _
                              LstDetMethod.SelectedValue = LstDetMethod1.SelectedValue And _
                             lstPortId.SelectedValue = lstPortId1.SelectedValue And _
                             Double.Parse(textFromRang.Text.Trim) <= Double.Parse(textFromRang1.Text.Trim) And _
                             Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textTorang1.Text.Trim) And _
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

    Private Shared Function StingToDate(strDate As String) As DateTime
        Dim array = strDate.Split(CType("/",Char))
        If array.Length.Equals(1) Then
            array = strDate.Split(CType("-",Char))
        End If

        Dim cYear = CType(array.Last(), Integer)
        Dim cDt = CType(array.first(), Integer)
        Dim cMo = CType(array(1), Integer)
        Return New DateTime(cYear,cMo,cDt)
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pRateMaster As ExtCostRatemaster = ReturnObject()
        ExtCostRatemaster.InsertUpdateCostRateMasterWithDetailsTrn(pRateMaster)

        If pRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRateMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        LoadTreeViewData()

        hdnRateId.Value = pRateMaster.RateId
        Dim P As New CostRateDetails
        P.RateId = hdnRateId.Value
        P.TerminalId = pRateMaster.TerminalId
        fillRepeator(CostRateDetails.ReturnCostRateDetailsListByRateId(P))
        ButtonControlSetup(True)
        manageUserControls(True)
        tvServices.Enabled = True
        btnNewRows.Visible = False
        btnDeleteRows.Visible = False
        Functions.ControlFocus(btnAdd)
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
        pRM.TaxGroupId = lstTaxGroup.SelectedValue
        pRM.ServiceId = lstService.SelectedValue
        pRM.Remarks = textRemarks.Text
        If chkApproval.Checked Then
            pRM.ApprovalFlage = "Y"
        End If
        If FileRateAggrement.PostedFile.FileName <> "" Then
            Try
                pRM.AggrementDoc = Path.GetFileName(FileRateAggrement.PostedFile.FileName)
                FileRateAggrement.PostedFile.SaveAs(Server.MapPath("~/Document/RATE-AGR/") + pRM.AggrementDoc)
            Catch ex As Exception
            End Try
        End If
        pRM.CostRateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items
            If (CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value > 0) Or (CType(rc.FindControl("textToRange"), TextBox).Text <> Nothing AndAlso Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text) > 0) Then
                Dim p As New CostRateDetails
                p.TerminalId = Session.Item("LoginTerminal")
                Try
                    p.PortId = CType(rc.FindControl("lstPortId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                'Try
                '    p.LineId = CType(rc.FindControl("lstLineId"), DropDownList).SelectedValue
                'Catch ex As Exception
                'End Try
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
                Try
                    p.Rate = Double.Parse(CType(rc.FindControl("textBaseRate"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    p.HandlingMode = CType(rc.FindControl("lstHandlingMode"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.LineId = CType(rc.FindControl("LstDetMethod"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.DiscountType = CType(rc.FindControl("lstRateMethod"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.TransitTime = CType(rc.FindControl("textTransitTimeDays"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.PodFreeDays = CType(rc.FindControl("textFreeDays"), TextBox).Text
                Catch ex As Exception
                End Try
                pRM.CostRateDetailsList.Add(p)
            End If

        Next

        Return pRM
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
        'textValidToDate.Enabled = pEnable
        lstCustomerType.Enabled = pEnable
        lstCustomer.Enabled = pEnable
        lstService.Enabled = pEnable
        lstTaxGroup.Enabled = pEnable
        chkApproval.Enabled = pEnable
        manageRep()
    End Sub
    Sub manageRep()
        For Each e As RepeaterItem In repRateDetails.Items
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
        Dim pRM As New ExtRateMaster
        pRM.RateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items

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
                Dim P As New TerminalMaster
                P.TerminalId = hdnValue
                lstToLocation.Items.Add(New ListItem("ALL", "0"))
                For Each LST As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(P)
                    lstToLocation.Items.Add(New ListItem(LST.TerminalName, LST.TerminalId))
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

    Protected Sub linkDownload_Click(sender As Object, e As EventArgs) Handles linkDownload.Click
        Dim filePath As String = Server.MapPath("~/Format/CostDetailsFormat.csv")
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath))
        Response.WriteFile(filePath)
        Response.End()
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If fuFileLocation.HasFile Then
            Dim fn As String = Path.GetFileName(fuFileLocation.PostedFile.FileName)
            Dim SaveLocation As String = Convert.ToString(Server.MapPath("Format/")) + fn
            fuFileLocation.PostedFile.SaveAs(SaveLocation)
            Dim filepath As String = Server.MapPath(Convert.ToString("Format/") & fn)
            Dim strFileType As String = Path.GetExtension(filepath.ToLower())
            If strFileType.Trim() <> ".csv" Then
                lblErrorMessage.Text = "Only *.csv file type are allowed."
                lblErrorMessage.ForeColor = Color.Red
                Return
            End If
            Dim sSourceConstr As String = [String].Empty
            If strFileType.Trim() = ".csv" Then
                Dim tb As DataTable = ReadCsvFile(filepath, True)
                Dim index As Integer = 1
                If tb.Rows.Count > 0 Then
                    For Each row As DataRow In tb.Rows

                        If index = 1 Then
                            Dim uploadedTerminalName As String = row("TerminalName").ToString().Trim()
                            Dim objTerminalMaster As TerminalMaster
                            Try
                                objTerminalMaster = CType(glTerminalMaster.ToArray().First(CType(Function(t As TerminalMaster) t.TerminalName.Trim().Equals(uploadedTerminalName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), TerminalMaster)
                                hdnUploadedTerminalId.Value = objTerminalMaster.TerminalId.ToString()
                            Catch ex As Exception
                                hdnUploadedTerminalId.Value = 0
                            End Try

                            If hdnUploadedTerminalId.Value <> Session.Item("LoginTerminal").ToString() Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "You are uploaded a other terminal rate, which is not allowed.")
                                Return
                            End If
                            textValidFromDate.Text = DateTime.Now.Day.ToString("D2") & "/" & DateTime.Now.Month.ToString("D2") & "/" & DateTime.Now.Year.ToString("D4")
                            textValidToDate.Text = DateTime.Now.Day.ToString("D2") & "/" & DateTime.Now.Month.ToString("D2") & "/" & DateTime.Now.Year.ToString("D4")

                            Dim customerType As String = row("CustomerType").ToString().Trim()
                            lstCustomerType.SelectedValue = customerType

                            Dim customerName As String = row("CustomerName").ToString().Trim()
                            If customerName = "----Public----" Then
                                row("CustomerName") = "0"
                            End If
                            Dim pCustomer As New ExtCustomerMaster With {
                                .TerminalId = CType(Session.Item("LoginTerminal"), Long)
                            }
                            Dim customersByType = ExtCustomerMaster.ReturnCustomerMasterListAllByCustomertypeCode(pCustomer, lstCustomerType.SelectedValue)
                            Dim objCustomerMaster As CustomerMaster = CType(customersByType.ToArray().First(CType(Function(c As CustomerMaster) c.CustomerName.Trim().Equals(customerName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), CustomerMaster)
                            lstCustomer.SelectedValue = objCustomerMaster.CustomerId.ToString()

                            Dim serviceName As String = row("ServiceName").ToString().Trim()
                            If serviceName = "----Select----" Then
                                row("ServiceName") = "0"
                            End If

                            Dim pService As New ServiceMaster With {
                                .TerminalId = CType(Session.Item("LoginTerminal"), Long)
                            }
                            Dim glService = ServiceMaster.ReturnServiceMasterList(pService)
                            Dim objServiceMaster As ServiceMaster = CType(glService.ToArray().First(CType(Function(s As ServiceMaster) s.ServiceName.Trim().Equals(serviceName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), ServiceMaster)
                            lstService.SelectedValue = objServiceMaster.ServiceId.ToString()

                            Dim remarks As String = row("Remarks").ToString().Trim()
                            textRemarks.Text = remarks
                        End If

                        If row("DocType") = "ALL" Then
                            row("DocType") = 0
                        End If

                        Dim portName As String = row("Port").ToString().Trim()
                        Dim pPortMaster As PortMaster
                        Try
                            pPortMaster = CType(glPortMaster.PortList.ToArray().
                                First(CType(Function(t As PortMaster) t.PortName.Equals(portName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), PortMaster)
                            row("Port") = pPortMaster.PortId
                        Catch ex As Exception
                            row("Port") = 0
                        End Try

                        If row("Port") = "ALL" Then
                            row("Port") = 0
                        End If

                        Dim pickupTerminal As String = row("PickupTerminal").ToString().Trim()
                        Dim pTerminalMasterPickupLoc As TerminalMaster
                        Try
                            pTerminalMasterPickupLoc = CType(glTerminalMaster.ToArray().First(CType(Function(t As TerminalMaster) t.TerminalName.Equals(pickupTerminal, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), TerminalMaster)
                            row("PickupTerminal") = pTerminalMasterPickupLoc.TerminalId
                        Catch ex As Exception
                            row("PickupTerminal") = 0
                        End Try

                        If row("PickupTerminal") = "ALL" Then
                            row("PickupTerminal") = 0
                        End If


                        Dim dropLocation As String = row("DropLocation").ToString().Trim()
                        Dim pTerminalMasterDropLoc As TerminalMaster
                        Try
                            pTerminalMasterDropLoc = CType(glTerminalMaster.ToArray().First(CType(Function(t As TerminalMaster) t.TerminalName.Equals(dropLocation, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), TerminalMaster)
                            row("DropLocation") = pTerminalMasterDropLoc.TerminalId
                        Catch ex As Exception
                            row("DropLocation") = 0
                        End Try

                        If row("DropLocation") = "ALL" Then
                            row("DropLocation") = 0
                        End If

                        Dim polName As String = row("POL").ToString().Trim()
                        Dim polPort As PortMaster
                        Try
                            polPort = CType(glPolMaster.PortList.ToArray().First(CType(Function(p As PortMaster) p.PortName.Equals(polName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), PortMaster)
                            row("POL") = polPort.PortId
                        Catch ex As Exception
                            row("POL") = 0
                        End Try

                        If row("POL") = "ALL" Then
                            row("POL") = 0
                        End If

                        
                        Dim commodityName As String = row("Commodity").ToString().Trim()
                        Dim pCommodityMaster As CommodityMaster
                        Try
                            pCommodityMaster = CType(glCommodityMaster.CommodityList.ToArray().First(CType(Function(c As CommodityMaster) c.CommodityName.Equals(commodityName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), CommodityMaster)
                            row("Commodity") = pCommodityMaster.CommodityId
                        Catch ex As Exception
                            row("Commodity") = 0
                        End Try

                        If row("Commodity") = "ALL" Then
                            row("Commodity") = 0
                        End If

                        If row("ContStatus") = "ALL" Then
                            row("ContStatus") = "0"
                        End If

                        Dim detMethod As String = row("DetMethod").ToString().Trim()
                        If String.IsNullOrWhiteSpace(detMethod) Or detMethod.Equals("ALL", StringComparison.OrdinalIgnoreCase) Then
                            row("DetMethod") = "0"
                        End If

                        If detMethod.Equals("Port To Port", StringComparison.OrdinalIgnoreCase) Then
                            row("DetMethod") = "1"
                        End If

                        If detMethod.Equals("Port To Terminal", StringComparison.OrdinalIgnoreCase) Then
                            row("DetMethod") = "2"
                        End If

                        If detMethod.Equals("Terminal To Terminal", StringComparison.OrdinalIgnoreCase) Then
                            row("DetMethod") = "3"
                        End If

                        If detMethod.Equals("Terminal To Port", StringComparison.OrdinalIgnoreCase) Then
                            row("DetMethod") = "4"
                        End If


                        Dim rateMethod As String = row("RateMethod").ToString().Trim()
                        If String.IsNullOrWhiteSpace(detMethod) Then
                            row("RateMethod") = ""
                        End If

                        If rateMethod.Equals("ALL", StringComparison.OrdinalIgnoreCase) Then
                            row("RateMethod") = "A"
                        End If

                        If rateMethod.Equals("SOB", StringComparison.OrdinalIgnoreCase) Then
                            row("RateMethod") = "S"
                        End If

                        If rateMethod.Equals("Handover", StringComparison.OrdinalIgnoreCase) Then
                            row("RateMethod") = "H"
                        End If

                        If rateMethod.Equals("Pickup", StringComparison.OrdinalIgnoreCase) Then
                            row("RateMethod") = "P"
                        End If
                        index += 1
                    Next
                End If

                tb.Columns("Port").ColumnName = "PortId"

                tb.Columns("FromRange").ColumnName = "FromRang"
                tb.Columns("ToRange").ColumnName = "ToRang"

                tb.Columns("TTDays").ColumnName = "TransitTime"
                tb.Columns("PODFreeDays").ColumnName = "PodFreeDays"
                tb.Columns("RateMethod").ColumnName = "DiscountType"

                tb.Columns("PickupTerminal").ColumnName = "HandlingMode"
                tb.Columns("DropLocation").ColumnName = "CargoType"

                tb.Columns("POL").ColumnName = "Pol"

                tb.Columns("Commodity").ColumnName = "CommodityId"
                tb.Columns("DetMethod").ColumnName = "LineId"

                Dim newColumn As New DataColumn("RateKeyId", GetType(String))
                newColumn.DefaultValue = "0"
                tb.Columns.Add(newColumn)
                repRateDetails.DataSource = tb
                repRateDetails.DataBind()
                Dim completePath As String = Server.MapPath("Format/" + fn)
                If File.Exists(completePath) Then
                    File.Delete(completePath)
                End If
            End If

            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Uploaded Successfully.")

        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please select a file.")
        End If
    End Sub

    Friend Function ReadCsvFile(ByVal fileName As String, ByVal firstRowIsHeader As Boolean) As DataTable
        Dim dtCsv As DataTable = New DataTable()
        Dim Headers As List(Of String) = New List(Of String)()
        Try
            Dim Fulltext As String
            Using sr As StreamReader = New StreamReader(fileName)
                While Not sr.EndOfStream
                    Fulltext = sr.ReadToEnd().Trim()
                    Dim totalRowsInCsvFile As String() = Fulltext.Split(CType(vbLf, Char))
                    For i As Integer = 0 To totalRowsInCsvFile.Length - 1
                        Dim rowValues As String() = totalRowsInCsvFile(i).Trim().Split(","c)
                        If True Then
                            If i = 0 Then
                                Dim j = 1
                                For Each data As String In rowValues
                                    Dim columnName = If(firstRowIsHeader, data.Trim(), "Field" & Math.Min(System.Threading.Interlocked.Increment(j), j - 1))
                                    Headers.Add(columnName.ToLower())
                                    dtCsv.Columns.Add(columnName)
                                Next
                            Else
                                Dim dr As DataRow = dtCsv.NewRow()
                                For k As Integer = 0 To rowValues.Count() - 1
                                    dr(k) = rowValues(k).Trim()
                                Next
                                dtCsv.Rows.Add(dr)
                            End If
                        End If
                    Next
                End While
		sr.Close()
            End Using

        Catch
        End Try

        Return dtCsv
    End Function

End Class
