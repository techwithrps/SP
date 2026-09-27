Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Globalization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Xml
Imports System.IO
Imports AjaxControlToolkit
Imports System.Web.DynamicData
Imports CommonSendingMailLibary

Partial Class Master_Finance_RateTariffNew
    Inherits System.Web.UI.Page
    ReadOnly rows As Integer = 10
    ReadOnly addrows As Integer = 5

    ReadOnly StrAll As String = "ALL"
    Dim glCustomertype As New ArrayList
    ' Shared listCustomerType As New List(Of CustomerType)
    Dim glIsoCode As New ArrayList
    Dim glServiceMode As New ArrayList
    Shared listPort As New List(Of PortMaster)
    Shared listPol As New List(Of PortMaster)
    Shared listCommodity As New List(Of CommodityMaster)
    Shared listLine As New List(Of CustomerMaster)
    Shared listTerminal As New List(Of TerminalMaster)
    Shared listToLocation As New List(Of TerminalLocationMaster)
    Shared listCustomer As New List(Of CustomerMaster)


    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetLine(prefixText As String, count As Integer) As List(Of String)
        Dim filteredCustomers = listLine.
                Where(Function(item) item.CustomerName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim customers = (From filteredCustomer In filteredCustomers Select AutoCompleteExtender.CreateAutoCompleteItem(filteredCustomer.CustomerName, filteredCustomer.CustomerId.ToString())).ToList()
        customers.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return customers
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetNPol(prefixText As String, count As Integer) As List(Of String)
        Dim filteredTerminals = listTerminal.
                Where(Function(item) item.TerminalName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim terminal = (From filteredTerminal In filteredTerminals Select AutoCompleteExtender.CreateAutoCompleteItem(filteredTerminal.TerminalName, CType(filteredTerminal.TerminalId, String))).ToList()
        terminal.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return terminal
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetPol(prefixText As String, count As Integer) As List(Of String)
        Dim filteredPols = listPol.
                Where(Function(item) item.PortName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim Pols = (From filteredPol In filteredPols Select AutoCompleteExtender.CreateAutoCompleteItem(filteredPol.PortName, CType(filteredPol.PortId, String))).ToList()
        Pols.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return Pols
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetPort(prefixText As String, count As Integer) As List(Of String)
        Dim filteredPorts = listPort.
                Where(Function(item) item.PortName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim Ports = (From filteredPort In filteredPorts Select AutoCompleteExtender.CreateAutoCompleteItem(filteredPort.PortName, CType(filteredPort.PortId, String))).ToList()
        Ports.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return Ports
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetLocation(prefixText As String, count As Integer, ByVal contextKey As String) As List(Of String)
        Dim filteredLocations = listToLocation.
                Where(Function(item) item.LocationName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase) AndAlso item.TerminalId.Equals(CType(contextKey, Long))).ToList()
        Dim locations = (From filteredLocation In filteredLocations Select AutoCompleteExtender.CreateAutoCompleteItem(filteredLocation.LocationName, CType(filteredLocation.LocationId, String))).ToList()
        locations.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return locations
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetHandlingMode(prefixText As String, count As Integer) As List(Of String)
        Dim filteredTerminals = listTerminal.
                Where(Function(item) item.TerminalName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim terminal = (From filteredTerminal In filteredTerminals Select AutoCompleteExtender.CreateAutoCompleteItem(filteredTerminal.TerminalName, CType(filteredTerminal.TerminalId, String))).ToList()
        terminal.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return terminal
    End Function

    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetCommodity(prefixText As String, count As Integer) As List(Of String)
        Dim filteredCommodities = listCommodity.
                Where(Function(item) item.CommodityName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim commodities = (From filteredCommodity In filteredCommodities Select AutoCompleteExtender.CreateAutoCompleteItem(filteredCommodity.CommodityName, CType(filteredCommodity.CommodityId, String))).ToList()
        commodities.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return commodities
    End Function

    '<ScriptMethod>
    '<WebMethod>
    'Public Shared Function GetCustomerType(prefixText As String, count As Integer) As List(Of String)
    '    Dim filteredCustomerTypes = listCustomerType.
    '            Where(Function(item) item.CustomerTypeName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
    '    Dim customerTypes = (From filteredCustomerType In filteredCustomerTypes Select AutoCompleteExtender.CreateAutoCompleteItem(filteredCustomerType.CustomerTypeName, CType(filteredCustomerType.TerminalId, String))).ToList()
    '    customerTypes.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
    '    Return customerTypes
    'End Function


    <ScriptMethod>
    <WebMethod>
    Public Shared Function GetCha(prefixText As String, count As Integer) As List(Of String)
        Dim filteredCustomers = listCustomer.
                Where(Function(item) item.CustomerName.StartsWith(prefixText, StringComparison.OrdinalIgnoreCase)).ToList()
        Dim customers = (From filteredCustomer In filteredCustomers Select AutoCompleteExtender.CreateAutoCompleteItem(filteredCustomer.CustomerName, CType(filteredCustomer.CustomerId, String))).ToList()
        customers.Insert(0, AutoCompleteExtender.CreateAutoCompleteItem("ALL", "0"))
        Return customers
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            NewPrepareDataRepControlsList()
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
        pExtRateMaster.CompanyId = Session.Item("CompanyId")
        pExtRateMaster.CustomerId = lstCustomerName.SelectedValue
        Try
            For Each obj As RateMaster In ExtRateMaster.ReturnRateMasterListByCustomerId(pExtRateMaster)
                Dim p As New ServiceMaster
                p.ServiceId = obj.ServiceId
                ServiceMaster.ReturnServiceMasterByServiceId(p)
                Dim pcu As New ExtCustomerMaster
                pcu.CustomerId = obj.CustomerId
                pcu.TerminalId = obj.TerminalId
                ExtCustomerMaster.ReturnCustomerMaster(pcu)
                Dim str As String = pcu.CustomerCode
                str &= "-" & p.ServiceName & "-" & obj.RateId & " - From Date " & obj.FromDate & " - To Date " & obj.ToDate
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
        lstService.DataSource = ServiceMaster.ReturnServiceMasterListNew(pService)
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
        Dim pIso As New IsoCode
        glIsoCode = IsoCode.ReturnIsoCodeListOfContType(pIso)

        Dim pServiceMode As New ServiceMode
        pServiceMode.TerminalId = Session.Item("LoginTerminal")
        glServiceMode = ServiceMode.ReturnServiceModeList(pServiceMode)

        Dim pCustomerType As New CustomerType
        pCustomerType.TerminalId = Session.Item("LoginTerminal")
        glCustomertype = CustomerType.ReturnCustomerTypeList(pCustomerType)

    End Sub

    Protected Sub NewPrepareDataRepControlsList()
        Dim pLine As New CustomerMaster()
        listLine = CustomerMaster.ReturnCustomerMasterListAllLine(pLine).Cast(Of CustomerMaster).ToList()

        Dim pCommodity As New CommodityMaster()
        'With {
        '        .TerminalId = CType(Session.Item("LoginTerminal"), Integer)
        '        }
        listCommodity = CommodityMaster.ReturnCommodityMasterList(pCommodity).Cast(Of CommodityMaster).ToList()

        Dim pPol As New PortMaster()

        listPol = PortMaster.ReturnPortMasterIndiaGateway(pPol).Cast(Of PortMaster).ToList()

        Dim pPort As New PortMaster()

        listPort = PortMaster.ReturnPortMasterList1(pPort).Cast(Of PortMaster).ToList()

        Dim pCha As New CustomerMaster()

        listCustomer = CustomerMaster.ReturnCustomerMasterList(pCha).Cast(Of CustomerMaster).ToList()

        Dim pTerminalMaster As New TerminalMaster()

        listTerminal = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster).Cast(Of TerminalMaster).ToList()

        Dim pLocation As New TerminalLocationMaster
        listToLocation = TerminalLocationMaster.ReturnTerminalLocationMasterAll(pLocation).Cast(Of TerminalLocationMaster).ToList()

        'Dim pCustomerType As New CustomerType 
        'listCustomerType = CustomerType.ReturnCustomerTypeList(pCustomerType).Cast(Of CustomerType).ToList()

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
    'Protected Sub prepareHandlingMode(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim lst As DropDownList = sender
    '        lst.Items.Clear()

    '        lst.Items.Add(New ListItem("ALL", "0"))
    '        For Each ic As ServiceMode In glServiceMode
    '            lst.Items.Add(New ListItem(ic.ModeName, ic.ModeCode))
    '        Next

    '    Catch ex As Exception
    '    End Try
    'End Sub
    Protected Sub prepareCustomerType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", ""))
            For Each ic As CustomerType In glCustomertype
                lst.Items.Add(New ListItem(ic.CustomerTypeName, ic.CustomerTypeCode))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pExtRate As New ExtRateMaster
        pExtRate.RateId = pCodevalue.Value
        pExtRate.TerminalId = Session.Item("LoginTerminal")
        pExtRate.CompanyId = Session.Item("CompanyId")
        ExtRateMaster.ReturnRateMasterWithDetailsTrn(pExtRate)

        hdnRateId.Value = pExtRate.RateId
        textRateId.Text = pCodevalue.Value
        hdnServiceId.Value = pExtRate.ServiceId
        hdnApprovalFlag.Value = pExtRate.ApprovalFlage
        textValidFromDate.Text = pExtRate.FromDate
        textValidToDate.Text = pExtRate.ToDate
        lstCustomerType.SelectedValue = pExtRate.CustomerType
        lstCustomer.SelectedValue = pExtRate.CustomerId
        lstService.SelectedValue = pExtRate.ServiceId
        'lstCustomerName.SelectedValue = pExtRate
        textRemarks.Text = pExtRate.Remarks
        If pExtRate.ApprovalFlage = "Y" Then
            chkApproval.Checked = True
        End If
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

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ListControlDataBind()
        If Not tvServices.SelectedNode Is Nothing Then
            prepareControls(tvServices.SelectedNode)
        End If
        manageUserControls(True)
        btnNewRows.Visible = False
        'btnDeleteRows.Visible = False
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
        btnDownload.Enabled = True
        btnDownload.Visible = True
        btnDownload.Visible = True
        tvServices.Enabled = False
        lstTaxGroup.Enabled = True
        lstService.SelectedValue = 0
        lstCustomerType.SelectedValue = ""
        lstCustomer.SelectedValue = 0

        If lstCustomerType.SelectedValue = "" Then
            lstCustomer.Enabled = False
        End If
        'To add "ALL" in Repeator after clicking ADD
        repRateDetails.DataSource = Nothing
        repRateDetails.DataBind()

        fillRepeator(New ArrayList)
        manageRep()
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
            dtFrom = Functions.todate_ddmmyyyy(textValidFromDate.Text, "/")
        Catch ex As Exception
        End Try
        Try
            dtTo = Functions.todate_ddmmyyyy(textValidToDate.Text, "/")
        Catch ex As Exception

        End Try

        For Each rep As RepeaterItem In repRateDetails.Items

            Dim hdnRateKeyId As HiddenField = CType(rep.FindControl("hdnRateKeyId"), HiddenField)
            Dim lstContSize As DropDownList = CType(rep.FindControl("lstContSize"), DropDownList)
            Dim lstContType As DropDownList = CType(rep.FindControl("lstContType"), DropDownList)
            Dim lstContStatus As DropDownList = CType(rep.FindControl("lstContStatus"), DropDownList)
            Dim hdnCargoTypeId As HiddenField = CType(rep.FindControl("hdnCargoTypeId"), HiddenField)
            Dim hdnCommodityId As HiddenField = CType(rep.FindControl("hdnCommodityId"), HiddenField)
            Dim hdnHandlingModeId As HiddenField = CType(rep.FindControl("hdnHandlingModeId"), HiddenField)
            Dim hdnPol As HiddenField = CType(rep.FindControl("hdnPol"), HiddenField)
            Dim textFromRang As TextBox = CType(rep.FindControl("textFromRange"), TextBox)
            Dim textTorang As TextBox = CType(rep.FindControl("textToRange"), TextBox)
            Dim lstRateType As DropDownList = CType(rep.FindControl("lstRateType"), DropDownList)
            Dim lstEnable As DropDownList = CType(rep.FindControl("lstEnable"), DropDownList)
            Dim lstDiscountType As DropDownList = CType(rep.FindControl("lstDiscountType"), DropDownList)
            Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
            Dim lstCurrency As DropDownList = CType(rep.FindControl("lstCurrency"), DropDownList)
            Dim textBaseRate As TextBox = CType(rep.FindControl("textBaseRate"), TextBox)
            Dim textDiscount As TextBox = CType(rep.FindControl("textDiscount"), TextBox)
            Dim lstDocType As DropDownList = CType(rep.FindControl("lstDocType"), DropDownList)
            Dim hdnPortId As HiddenField = CType(rep.FindControl("hdnPortId"), HiddenField)
            Dim hdnPolId As HiddenField = CType(rep.FindControl("hdnPolId"), HiddenField)
            Dim LstCustomerType As DropDownList = CType(rep.FindControl("LstCustomerType"), DropDownList)
            Dim hdnChaId As HiddenField = CType(rep.FindControl("hdnChaId"), HiddenField)
            Dim hdnLineId As HiddenField = CType(rep.FindControl("hdnLineId"), HiddenField)
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
                    Dim hdnCargoTypeId1 As HiddenField = CType(rep1.FindControl("hdnCargoTypeId"), HiddenField)
                    Dim hdnCommodityId1 As HiddenField = CType(rep1.FindControl("hdnCommodityId"), HiddenField)
                    Dim hdnHandlingModeId1 As HiddenField = CType(rep1.FindControl("hdnHandlingModeId"), HiddenField)
                    Dim hdnPol1 As HiddenField = CType(rep1.FindControl("hdnPol"), HiddenField)
                    Dim textFromRang1 As TextBox = CType(rep1.FindControl("textFromRange"), TextBox)
                    Dim textTorang1 As TextBox = CType(rep1.FindControl("textToRange"), TextBox)
                    Dim lstRateType1 As DropDownList = CType(rep1.FindControl("lstRateType"), DropDownList)
                    Dim lstEnable1 As DropDownList = CType(rep1.FindControl("lstEnable"), DropDownList)
                    Dim textRate1 As TextBox = CType(rep1.FindControl("textRate"), TextBox)
                    Dim lstCurrency1 As DropDownList = CType(rep1.FindControl("lstCurrency"), DropDownList)
                    Dim textBaseRate1 As TextBox = CType(rep1.FindControl("textBaseRate"), TextBox)
                    Dim textDiscount1 As TextBox = CType(rep1.FindControl("textDiscount"), TextBox)
                    Dim lstDiscountType1 As DropDownList = CType(rep1.FindControl("lstDiscountType"), DropDownList)
                    Dim lstDocType1 As DropDownList = CType(rep1.FindControl("lstDocType"), DropDownList)
                    Dim hdnPortId1 As HiddenField = CType(rep1.FindControl("hdnPortId"), HiddenField)
                    Dim hdnPolId1 As HiddenField = CType(rep1.FindControl("hdnPolId"), HiddenField)
                    Dim hdnLineId1 As HiddenField = CType(rep1.FindControl("hdnLineId"), HiddenField)
                    Dim LstCustomerType1 As DropDownList = CType(rep1.FindControl("LstCustomerType"), DropDownList)
                    Dim hdnChaId1 As HiddenField = CType(rep1.FindControl("hdnChaId"), HiddenField)


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
                            If hdnCargoTypeId.Value = hdnCargoTypeId1.Value And
                                hdnHandlingModeId.Value = hdnHandlingModeId1.Value And
                                lstContSize.SelectedValue = lstContSize1.SelectedValue And
                                lstContType.SelectedValue = lstContType1.SelectedValue And
                                lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                                lstDocType.SelectedValue = lstDocType1.SelectedValue And
                                hdnPol.Value = hdnPol1.Value And
                                hdnCommodityId.Value = hdnCommodityId1.Value And
                                hdnPortId.Value = hdnPortId1.Value And
                                hdnPolId.Value = hdnPolId1.Value And
                                hdnLineId.Value = hdnLineId1.Value And
                                lstRateType.SelectedValue = lstRateType1.SelectedValue And
                                textBaseRate.Text = textBaseRate1.Text And
                                textRate.Text = textRate1.Text And
                                lstCurrency.SelectedValue = lstCurrency1.SelectedValue And
                                lstEnable.SelectedValue = lstEnable1.SelectedValue And
                                lstDiscountType.SelectedValue = lstDiscountType1.SelectedValue And
                                textDiscount.Text = textDiscount1.Text And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                hdnChaId.Value = hdnChaId1.Value And
                                Double.Parse(textFromRang.Text.Trim) = Double.Parse(textFromRang1.Text.Trim) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If hdnCargoTypeId.Value = hdnCargoTypeId1.Value And
                                hdnHandlingModeId.Value = hdnHandlingModeId1.Value And
                                lstContSize.SelectedValue = lstContSize1.SelectedValue And
                                lstContType.SelectedValue = lstContType1.SelectedValue And
                                lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                                lstDocType.SelectedValue = lstDocType1.SelectedValue And
                                hdnPol.Value = hdnPol1.Value And
                                hdnCommodityId.Value = hdnCommodityId1.Value And
                                hdnPortId.Value = hdnPortId1.Value And
                                hdnPolId.Value = hdnPolId1.Value And
                                hdnLineId.Value = hdnLineId1.Value And
                                lstRateType.SelectedValue = lstRateType1.SelectedValue And
                                textBaseRate.Text = textBaseRate1.Text And
                                textRate.Text = textRate1.Text And
                                lstCurrency.SelectedValue = lstCurrency1.SelectedValue And
                                lstEnable.SelectedValue = lstEnable1.SelectedValue And
                                lstDiscountType.SelectedValue = lstDiscountType1.SelectedValue And
                                textDiscount.Text = textDiscount1.Text And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                hdnChaId.Value = hdnChaId1.Value And
                                Double.Parse(textFromRang.Text.Trim) >= Double.Parse(textFromRang1.Text.Trim) And
                                Double.Parse(textFromRang.Text.Trim) < Double.Parse(textFromRang1.Text.Trim) And
                                Double.Parse(textTorang.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If hdnCargoTypeId.Value = hdnCargoTypeId1.Value And
                                hdnHandlingModeId.Value = hdnHandlingModeId1.Value And
                                lstContSize.SelectedValue = lstContSize1.SelectedValue And
                                lstContType.SelectedValue = lstContType1.SelectedValue And
                                lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                                lstDocType.SelectedValue = lstDocType1.SelectedValue And
                                hdnPol.Value = hdnPol1.Value And
                               hdnCommodityId.Value = hdnCommodityId1.Value And
                                hdnPortId.Value = hdnPortId1.Value And
                                hdnPolId.Value = hdnPolId1.Value And
                                hdnLineId.Value = hdnLineId1.Value And
                                lstRateType.SelectedValue = lstRateType1.SelectedValue And
                                textBaseRate.Text = textBaseRate1.Text And
                                textRate.Text = textRate1.Text And
                                lstCurrency.SelectedValue = lstCurrency1.SelectedValue And
                                lstEnable.SelectedValue = lstEnable1.SelectedValue And
                                lstDiscountType.SelectedValue = lstDiscountType1.SelectedValue And
                                textDiscount.Text = textDiscount1.Text And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                hdnChaId.Value = hdnChaId1.Value And
                                Double.Parse(textTorang.Text.Trim) > Double.Parse(textFromRang1.Text.Trim) And
                                Double.Parse(textTorang.Text.Trim) < Double.Parse(textTorang1.Text.Trim) And
                                Double.Parse(textTorang1.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textTorang1)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If hdnCargoTypeId.Value = hdnCargoTypeId1.Value And
                                hdnHandlingModeId.Value = hdnHandlingModeId1.Value And
                                lstContSize.SelectedValue = lstContSize1.SelectedValue And
                                lstContType.SelectedValue = lstContType1.SelectedValue And
                                lstContStatus.SelectedValue = lstContStatus1.SelectedValue And
                                lstDocType.SelectedValue = lstDocType1.SelectedValue And
                                hdnPol.Value = hdnPol1.Value And
                               hdnCommodityId.Value = hdnCommodityId1.Value And
                                hdnPortId.Value = hdnPortId1.Value And
                                hdnPolId.Value = hdnPolId1.Value And
                                hdnLineId.Value = hdnLineId1.Value And
                                lstRateType.SelectedValue = lstRateType1.SelectedValue And
                                textBaseRate.Text = textBaseRate1.Text And
                                textRate.Text = textRate1.Text And
                                lstCurrency.SelectedValue = lstCurrency1.SelectedValue And
                                lstEnable.SelectedValue = lstEnable1.SelectedValue And
                                lstDiscountType.SelectedValue = lstDiscountType1.SelectedValue And
                                textDiscount.Text = textDiscount1.Text And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                LstCustomerType.SelectedValue = LstCustomerType1.SelectedValue And
                                hdnChaId.Value = hdnChaId1.Value And
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
        SaveNewRate()
    End Sub
    Private Sub SaveNewRate()
        If ValidationCheck() = False Then
            Return
        End If
        Dim pRateMaster As ExtRateMaster = ReturnObject()
        Try
            If Session.Item("LoginUser") <> "Ashish Devrani" AndAlso Session.Item("LoginUser") <> "Ajit Singh" AndAlso Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Sonali Jadav" AndAlso Session.Item("LoginUser") <> "Rishi" AndAlso Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Prabjot Saini" Then
                If hdnServiceId.Value = 4 AndAlso hdnApprovalFlag.Value = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Rate already approved,so Edit not Allow. ")
                    Return
                    btnSave.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
        ExtRateMaster.InsertUpdateRateMasterWithDetailsTrn(pRateMaster)
        If pRateMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRateMaster.Errormsg)
            Return
        End If

        LoadTreeViewData()
        hdnRateId.Value = pRateMaster.RateId
        textRateId.Text = pRateMaster.RateId
        If String.IsNullOrEmpty(SendMail()) Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully and mail sent.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully and mail sending failure.")
        End If
        Dim P As New RateDetails
        P.RateId = hdnRateId.Value
        P.TerminalId = pRateMaster.TerminalId
        fillRepeator(RateDetails.ReturnRateDetailsListByRateId(P))
        ButtonControlSetup(True)
        manageUserControls(True)
        tvServices.Enabled = True
        btnNewRows.Visible = False
        'btnDeleteRows.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub
    Function SendMail() As String
        Dim statusMail As New StringBuilder
        Dim con1 As New OleDbConnection
        Dim strConnectionString1 As String = ""
        strConnectionString1 = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        ' strConnectionString1 = "Provider=MSDAORA;Data Source=SPJLIVE;Persist Security Info=True;Password=SPjlive_961619#;User ID=SPJLIVE"
        con1 = New OleDbConnection(strConnectionString1)
        Dim ada1 As OleDbDataAdapter = New OleDbDataAdapter
        statusMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        statusMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
        statusMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='10'  >")
        statusMail.Append("<b>Follwing Rate is Updated...</b>")
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
        statusMail.Append("<b>Updated By</b>")
        statusMail.Append(" </td>")
        statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        statusMail.Append("<b>Updated On</b>")
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
            procName = "AUTO_MAIL.SP_RATE_MASTER"
            cmd.CommandText = procName & "(" & procParam & ")"
            ada2.SelectCommand = cmd
            Dim ds As New DataSet
            ada2.Fill(ds)
            Dim SR As Long = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                statusMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                'statusMail.Append(lstCustomerType.SelectedItem.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("CUSTOMER_TYPE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                ' statusMail.Append(lstCustomer.SelectedItem.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("CUSTOMER_NAME"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                ' statusMail.Append(lstCustomer.SelectedItem.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("RATE_ID"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                ' statusMail.Append(textValidFromDate.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("FROM_DATE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                'statusMail.Append(textValidToDate.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("TO_DATE"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                ' statusMail.Append(lstService.SelectedItem.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("SERVICE_NAME"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                'statusMail.Append(lstTaxGroup.SelectedItem.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("TAX_GROUPP"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                'statusMail.Append(textRemarks.Text)
                statusMail.Append(ds.Tables(0).Rows(i)("REMARKS"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                '  statusMail.Append(hdnUpdatedBy.Value)
                statusMail.Append(ds.Tables(0).Rows(i)("UPDATED_BY"))
                statusMail.Append(" </td>")
                statusMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                '  statusMail.Append(hdnupdatedon.Value)
                statusMail.Append(ds.Tables(0).Rows(i)("UPDATED_ON"))
                statusMail.Append(" </td>")
            Next

            statusMail.Append(<![CDATA[<font color='#00008B'>Thanks & Regards
                            <br></font><br><b><font color='Red'>SPJ CARGO PVT. LTD.
                            </b></font><font color='#00008B'><br>Regd. Office : D-9/3, 
                            Okhla Industrial Area Phase-1 New Delhi-110020 <br> 
                            Tel: +91 - 11-41062143-2147<br> </font>]]>.Value())
            statusMail.Append("<br/>")
            statusMail.Append("<br/>")
            statusMail.Append("<br/>")
            statusMail.Append("<font color='#00008B'>**********This is system generated auto mail. For any query please get in touch with Mr Akshay Saxena (+91-9205280272)**********")

            Dim strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim con As New OleDbConnection(strConnectionString)
            con.Open()
            Dim strCmd As String
            strCmd = <![CDATA[SELECT TO_CHAR(SYSDATE,'DD/MM/YYYY')MAIL_DATE , TO_MAIL_IDS,CC_IDS,
         BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=485 AND TERMINAL_ID=1]]>.Value()
            ' Take a data adapter to fethch the data from database
            Dim ada As New OleDbDataAdapter(strCmd, strConnectionString)
            ' create a new data table instance to fill the data of mail configratutaion 
            Dim dtMailSetup As New DataTable()
            ada.Fill(dtMailSetup)

            strCmd = "SELECT  FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=5"
            ada = New OleDbDataAdapter(strCmd, strConnectionString)
            Dim dtMailConfig As New DataTable()
            ada.Fill(dtMailConfig)
            con.Close()
            con1.Close()
            Dim statusStr = MailSender.SendMailToCcBccIDWithOrWithoutAttachment(
                dtMailConfig.Rows(0)("FROM_ID").ToString(),
                dtMailConfig.Rows(0)("FROM_NAME").ToString(),
                dtMailSetup.Rows(0)("TO_MAIL_IDS").ToString(),
                dtMailSetup.Rows(0)("CC_IDS").ToString(),
                dtMailSetup.Rows(0)("BCC_IDS").ToString(),
                dtMailSetup.Rows(0)("SUBJECT").ToString(),
                statusMail.ToString(),
                dtMailConfig.Rows(0)("SMTP_SERVER").ToString(),
                dtMailConfig.Rows(0)("PASSWORD").ToString(),
                dtMailConfig.Rows(0)("PORT_NO").ToString())
            Return statusStr
        Catch ex As Exception
        End Try
    End Function

    Function ReturnObject() As ExtRateMaster
        Dim pRM As New ExtRateMaster
        Try
            pRM.RateId = hdnRateId.Value
            pRM.ServiceId = hdnServiceId.Value
            pRM.ApprovalFlage = hdnApprovalFlag.Value
        Catch ex As Exception
        End Try
        pRM.CreatedBy = Session.Item("LoginUser")
        pRM.TerminalId = Session.Item("LoginTerminal")
        pRM.UpdatedBy = Session.Item("LoginUser")
        pRM.CompanyId = Session.Item("CompanyId")
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
        pRM.RateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items
            If (CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value <> Nothing AndAlso CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value > 0) Or (CType(rc.FindControl("textToRange"), TextBox).Text <> Nothing AndAlso Integer.Parse(CType(rc.FindControl("textToRange"), TextBox).Text) > 0) Then
                Dim p As New RateDetails
                p.TerminalId = Session.Item("LoginTerminal")
                Try
                    p.PolId = CType(CType(rc.FindControl("hdnPolId"), HiddenField).Value, Long)
                Catch ex As Exception
                End Try
                Try
                    p.PortId = CType(CType(rc.FindControl("hdnPortId"), HiddenField).Value, Long)
                Catch ex As Exception
                End Try
                Try
                    p.LineId = CType(CType(rc.FindControl("hdnLineId"), HiddenField).Value, Long)
                Catch ex As Exception
                End Try
                Try
                    p.RateKeyId = CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    ' p.CargoType = CType(rc.FindControl("textCargoType"), TextBox).Text
                    p.CargoType = CType(rc.FindControl("hdnCargoTypeId"), HiddenField).Value
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
                    p.CommodityId = CType(CType(rc.FindControl("hdnCommodityId"), HiddenField).Value, Long)
                Catch ex As Exception
                End Try
                Try
                    p.CusType = CType(rc.FindControl("LstCustomerType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try

                Try
                    p.Pol = CType(CType(rc.FindControl("hdnPol"), HiddenField).Value, Long)
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
                    p.IsEnable = CType(rc.FindControl("lstEnable"), DropDownList).SelectedValue
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
                    p.HandlingMode = CType(rc.FindControl("hdnHandlingModeId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.CusType = CType(rc.FindControl("LstCustomerType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ChaId = CType(CType(rc.FindControl("hdnChaId"), HiddenField).Value, Long)
                Catch ex As Exception
                End Try

                pRM.RateDetailsList.Add(p)
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
        'btnDeleteRows.Visible = True
        Functions.ControlFocus(textRemarks)
    End Sub
    Sub manageControls(ByVal pEnable As Boolean)
        lstCustomerType.Enabled = pEnable
        lstCustomer.Enabled = pEnable
        lstService.Enabled = pEnable
        lstTaxGroup.Enabled = pEnable
        'chkApproval.Enabled = pEnable
        manageRep()
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
                CType(e.FindControl("textCommodity"), TextBox).Enabled = True
                CType(e.FindControl("textCargoType"), TextBox).Enabled = True
                CType(e.FindControl("textPol"), TextBox).Enabled = True
                CType(e.FindControl("textPort"), TextBox).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
                CType(e.FindControl("lstEnable"), DropDownList).Enabled = True
                CType(e.FindControl("lstRateType"), DropDownList).Enabled = True
                CType(e.FindControl("textNPol"), TextBox).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True
                CType(e.FindControl("LstCustomerType"), DropDownList).Enabled = True
                CType(e.FindControl("textCha"), TextBox).Enabled = True


            Else
                CType(e.FindControl("lstDiscountType"), DropDownList).Enabled = True
                CType(e.FindControl("textDiscount"), TextBox).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
                CType(e.FindControl("lstContType"), DropDownList).Enabled = True
                CType(e.FindControl("textCommodity"), TextBox).Enabled = True
                CType(e.FindControl("textCargoType"), TextBox).Enabled = True
                CType(e.FindControl("textFromRange"), TextBox).Enabled = True
                CType(e.FindControl("textPol"), TextBox).Enabled = True
                CType(e.FindControl("textNPol"), TextBox).Enabled = True
                CType(e.FindControl("textToRange"), TextBox).Enabled = True
                CType(e.FindControl("lstRateType"), DropDownList).Enabled = True
                CType(e.FindControl("textBaseRate"), TextBox).Enabled = True
                CType(e.FindControl("textHandlingMode"), TextBox).Enabled = True
                CType(e.FindControl("textPort"), TextBox).Enabled = True
                CType(e.FindControl("lstCurrency"), DropDownList).Enabled = True
                CType(e.FindControl("lstEnable"), DropDownList).Enabled = True
                CType(e.FindControl("LstCustomerType"), DropDownList).Enabled = True
                CType(e.FindControl("textCha"), TextBox).Enabled = True
                If CType(e.FindControl("lstDiscountType"), DropDownList).SelectedValue = Nothing Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate
                    CType(e.FindControl("textDiscount"), TextBox).Text = 0
                    CType(e.FindControl("textDiscount"), TextBox).Enabled = True
                ElseIf strDiscType = "P" Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - ((dblBaseRate * dblDiscount) / 100)
                ElseIf strDiscType = "I" Then
                    CType(e.FindControl("textRate"), TextBox).Text = dblBaseRate - dblDiscount
                End If
            End If
            CType(e.FindControl("textRate"), TextBox).Enabled = False
        Next
    End Sub
    Protected Sub btnNewRows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewRows.Click
        Dim pRM As New ExtRateMaster
        pRM.RateDetailsList = New ArrayList

        For Each rc As RepeaterItem In repRateDetails.Items

            Dim p As New RateDetails
            p.TerminalId = Session.Item("LoginTerminal")
            Try
                p.PolId = CType(CType(rc.FindControl("hdnPolId"), HiddenField).Value, Long)
            Catch ex As Exception
            End Try
            Try
                p.PortId = CType(CType(rc.FindControl("hdnPortId"), HiddenField).Value, Long)
            Catch ex As Exception
            End Try
            Try
                p.LineId = CType(CType(rc.FindControl("hdnLineId"), HiddenField).Value, Long)
            Catch ex As Exception
            End Try

            Try
                p.RateKeyId = CType(rc.FindControl("hdnRateKeyId"), HiddenField).Value
            Catch ex As Exception
            End Try
            Try
                p.CargoType = CType(rc.FindControl("hdnCargoTypeId"), HiddenField).Value
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
                p.CommodityId = CType(CType(rc.FindControl("hdnCommodityId"), HiddenField).Value, Long)
            Catch ex As Exception
            End Try
            Try
                p.Pol = CType(CType(rc.FindControl("hdnPol"), HiddenField).Value, Long)
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
                p.IsEnable = CType(rc.FindControl("lstEnable"), DropDownList).SelectedValue
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
                p.Rate = Double.Parse(CType(rc.FindControl("textRate"), TextBox).Text)
            Catch ex As Exception
            End Try
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
                p.HandlingMode = CType(rc.FindControl("hdnHandlingModeId"), HiddenField).Value
            Catch ex As Exception
            End Try
            Try
                p.CusType = CType(rc.FindControl("LstCustomerType"), DropDownList).SelectedValue
            Catch ex As Exception
            End Try
            Try
                p.ChaId = CType(CType(rc.FindControl("hdnChaId"), HiddenField).Value, Long)
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
            pRD.ContSize = "0"
            pRD.ContType = "ALL"
            pRD.IsEnable = "Y"
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

            Dim textLine = CType(e.Item.FindControl("textLine"), TextBox)
            Dim hdnLineId = CType(e.Item.FindControl("hdnLineId"), HiddenField)
            Dim objLine = listLine.FirstOrDefault(Function(item) item.CustomerId.Equals(CType(hdnLineId.Value, Integer)))
            If Not (objLine Is Nothing) Then
                textLine.Text = objLine.CustomerName
            Else
                textLine.Text = StrAll
            End If

            Dim textCommodity = CType(e.Item.FindControl("textCommodity"), TextBox)
            Dim hdnCommodityId = CType(e.Item.FindControl("hdnCommodityId"), HiddenField)
            Dim objCommodity = listCommodity.FirstOrDefault(Function(item) item.CommodityId.Equals(CType(hdnCommodityId.Value, Integer)))
            If Not (objCommodity Is Nothing) Then
                textCommodity.Text = objCommodity.CommodityName
            Else
                textCommodity.Text = StrAll
            End If

            Dim textPol = CType(e.Item.FindControl("textPol"), TextBox)
            Dim hdnPolId = CType(e.Item.FindControl("hdnPolId"), HiddenField)
            Dim objPol = listPort.FirstOrDefault(Function(item) item.PortId.Equals(CType(hdnPolId.Value, Integer)))
            If Not (objPol Is Nothing) Then
                textPol.Text = objPol.PortName
            Else
                textPol.Text = StrAll
            End If

            Dim textPort = CType(e.Item.FindControl("textPort"), TextBox)
            Dim hdnPortId = CType(e.Item.FindControl("hdnPortId"), HiddenField)
            Dim objPort = listPort.FirstOrDefault(Function(item) item.PortId.Equals(CType(hdnPortId.Value, Integer)))
            If Not (objPort Is Nothing) Then
                textPort.Text = objPort.PortName
            Else
                textPort.Text = StrAll
            End If

            Dim textCha = CType(e.Item.FindControl("textCha"), TextBox)
            Dim hdnChaId = CType(e.Item.FindControl("hdnChaId"), HiddenField)
            Dim objCustomer = listCustomer.FirstOrDefault(Function(item) item.CustomerId.Equals(CType(hdnChaId.Value, Integer)))
            If Not (objCustomer Is Nothing) Then
                textCha.Text = objCustomer.CustomerName
            Else
                textCha.Text = StrAll
            End If

            Dim textNPol = CType(e.Item.FindControl("textNPol"), TextBox)
            Dim hdnPol = CType(e.Item.FindControl("hdnPol"), HiddenField)
            Dim objNPol = listTerminal.FirstOrDefault(Function(item) item.TerminalId.Equals(CType(hdnPol.Value, Integer)))
            If Not (objNPol Is Nothing) Then
                textNPol.Text = objNPol.TerminalName
            Else
                textNPol.Text = StrAll
            End If

            Dim textHandlingMode = CType(e.Item.FindControl("textHandlingMode"), TextBox)
            Dim hdnHandlingModeId = CType(e.Item.FindControl("hdnHandlingModeId"), HiddenField)
            Dim objHandlingMode = listTerminal.FirstOrDefault(Function(item) item.TerminalId.Equals(CType(hdnHandlingModeId.Value, Integer)))
            If Not (objHandlingMode Is Nothing) Then
                textHandlingMode.Text = objHandlingMode.TerminalName
            Else
                textHandlingMode.Text = StrAll
            End If
            Try
                Dim textCargoType = CType(e.Item.FindControl("textCargoType"), TextBox)
                Dim hdnCargoTypeId = CType(e.Item.FindControl("hdnCargoTypeId"), HiddenField)
                Dim objLocation = listToLocation.FirstOrDefault(Function(item) item.LocationId.Equals(CType(hdnCargoTypeId.Value, Integer)))
                If Not (objLocation Is Nothing) Then
                    textCargoType.Text = objLocation.LocationName
                Else
                    textCargoType.Text = StrAll
                End If
            Catch ex As Exception
            End Try

        End If

    End Sub
    Protected Sub FillCustomer(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim lstFromLocation As DropDownList = sender
            Dim hdnValue As Integer = 0
            Dim lstCha As DropDownList
            Dim index1 As Integer = Integer.Parse(lstFromLocation.ClientID.Substring("ctl00_ContentPlaceHolder1_repRateDetails_ctl".Length, lstFromLocation.ClientID.IndexOf("_LstCustomerType") - "ctl00_ContentPlaceHolder1_repRateDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = repRateDetails.Items(index1 - 1)
            If lstFromLocation.SelectedValue <> "" Then
                lstCha = CType(rep.FindControl("lstCha"), DropDownList)
                Dim pCustomer As New ExtCustomerMaster
                pCustomer.TerminalId = Session.Item("LoginTerminal")
                lstCha.Items.Clear()
                lstCha.Items.Add(New ListItem("ALL", "0"))
                For Each LST As CustomerMaster In ExtCustomerMaster.ReturnCustomerMasterListAllByCustomertypeCode(pCustomer, lstFromLocation.SelectedValue)
                    lstCha.Items.Add(New ListItem(LST.CustomerName, LST.CustomerId))
                    lstCha.Enabled = True
                Next

            End If
        Catch ex As Exception
        End Try
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

        LoadTreeViewData()

    End Sub

    Private Sub linkDownload_Click(sender As Object, e As EventArgs) Handles linkDownload.Click
        Dim filePath As String = Server.MapPath("~/Format/RateDetails.csv")
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
                lblErrorMessage.Text = "Only *.csv filetype are allowed."
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
                                objTerminalMaster = listTerminal.First(CType(Function(t As TerminalMaster) t.TerminalName.Trim().Equals(uploadedTerminalName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                                hdnUploadedTerminalId.Value = objTerminalMaster.TerminalId.ToString()
                            Catch ex As Exception
                                hdnUploadedTerminalId.Value = 0
                            End Try

                            If hdnUploadedTerminalId.Value <> Session.Item("LoginTerminal").ToString() Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "You are uploaded a other terminal rate, which is not allowed.")
                                Return
                            End If
                            textValidFromDate.Text = row("FromDate").ToString().Trim()
                            textValidToDate.Text = row("ToDate").ToString().Trim()

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
                            Dim glService = ServiceMaster.ReturnServiceMasterListNew(pService)
                            Dim objServiceMaster As ServiceMaster = CType(glService.ToArray().First(CType(Function(s As ServiceMaster) s.ServiceName.Trim().Equals(serviceName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean))), ServiceMaster)
                            lstService.SelectedValue = objServiceMaster.ServiceId.ToString()

                            Dim remarks As String = row("Remarks").ToString().Trim()
                            textRemarks.Text = remarks
                        End If

                        Dim lineName As String = row("LineName").ToString().Trim()
                        Dim pCustomerMaster As CustomerMaster
                        Try
                            pCustomerMaster = listLine.First(CType(Function(c As CustomerMaster) c.CustomerName.Trim().Equals(lineName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("LineName") = pCustomerMaster.CustomerId
                        Catch ex As Exception
                            row("LineName") = 0
                        End Try

                        If row("DocType") = "ALL" Then
                            row("DocType") = 0
                        End If

                        Dim fromLocation As String = row("FromLocation").ToString().Trim()
                        Dim pTerminalMasterFromLoc As TerminalMaster
                        Try
                            pTerminalMasterFromLoc = listTerminal.First(CType(Function(t As TerminalMaster) t.TerminalName.Equals(fromLocation, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("FromLocation") = pTerminalMasterFromLoc.TerminalId
                        Catch ex As Exception
                            row("FromLocation") = 0
                        End Try

                        If row("FromLocation") = "ALL" Then
                            row("FromLocation") = 0
                        End If

                        Dim toLocation As String = row("ToLocation").ToString().Trim()

                        Dim pTerminalLocMasterToLoc As TerminalLocationMaster
                        Try
                            pTerminalLocMasterToLoc = listToLocation.First(CType(Function(t As TerminalLocationMaster) t.LocationName.Equals(toLocation, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("ToLocation") = pTerminalLocMasterToLoc.LocationId
                        Catch ex As Exception
                            row("ToLocation") = 0
                        End Try
                        If row("ToLocation") = "ALL" Then
                            row("ToLocation") = 0
                        End If

                        Dim handoverLocation As String = row("HandoverLocation").ToString().Trim()
                        Dim pol As TerminalMaster
                        Try
                            pol = listTerminal.First(CType(Function(t As TerminalMaster) t.TerminalName.Equals(handoverLocation, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("HandoverLocation") = pol.TerminalId
                        Catch ex As Exception
                            row("HandoverLocation") = 0
                        End Try

                        If row("HandoverLocation") = "ALL" Then
                            row("HandoverLocation") = 0
                        End If

                        Dim polName As String = row("POL").ToString().Trim()
                        Dim polPort As PortMaster
                        Try
                            polPort = listPol.First(CType(Function(p As PortMaster) p.PortName.Equals(polName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("POL") = polPort.PortId
                        Catch ex As Exception
                            row("POL") = 0
                        End Try

                        If row("POL") = "ALL" Then
                            row("POL") = 0
                        End If

                        Dim podName As String = row("POD").ToString().Trim()
                        Dim podPort As PortMaster
                        Try
                            podPort = listPort.First(CType(Function(p As PortMaster) p.PortName.Equals(podName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("POD") = podPort.PortId
                        Catch ex As Exception
                            row("POD") = 0
                        End Try

                        If row("POD") = "ALL" Then
                            row("POD") = 0
                        End If

                        Dim commodityName As String = row("Commodity").ToString().Trim()
                        Dim pCommodityMaster As CommodityMaster
                        Try
                            pCommodityMaster = listCommodity.First(CType(Function(c As CommodityMaster) c.CommodityName.Equals(commodityName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("Commodity") = pCommodityMaster.CommodityId
                        Catch ex As Exception
                            row("Commodity") = 0
                        End Try

                        If row("Commodity") = "ALL" Then
                            row("Commodity") = 0
                        End If

                        Dim custName As String = row("CustomerNameTable").ToString().Trim()
                        Dim pCustomerMasterRep As CustomerMaster

                        Try
                            pCustomerMasterRep = listCustomer.First(CType(Function(c As CustomerMaster) c.CustomerName.Equals(custName, StringComparison.OrdinalIgnoreCase), Func(Of Object, Boolean)))
                            row("CustomerNameTable") = pCustomerMasterRep.CustomerId
                        Catch ex As Exception
                            row("CustomerNameTable") = 0
                        End Try

                        If row("CustomerNameTable") = "ALL" Then
                            row("CustomerNameTable") = 0
                        End If


                        Dim rateType As String = row("RateMethod").ToString().Trim()
                        If rateType = "ALL" Then
                            row("RateMethod") = "A"
                        End If
                        If rateType = "ALLOTMENT" Then
                            row("RateMethod") = "L"
                        End If

                        If rateType = "Handover" Then
                            row("RateMethod") = "H"
                        End If
                        If rateType = "SOB" Then
                            row("RateMethod") = "S"
                        End If

                        Dim Enable As String = row("Enable/Disable").ToString().Trim()
                        If Enable = "ENABLE" Then
                            row("Enable/Disable") = "Y"
                        End If
                        If rateType = "DISABLE" Then
                            row("Enable/Disable") = "N"
                        End If
                        Dim discountType As String = row("DiscountType").ToString().Trim()
                        If discountType = "None" Then
                            row("DiscountType") = ""
                        End If

                        If row("LineName") = "ALL" Then
                            row("LineName") = "0"
                        End If
                        index += 1
                    Next
                End If
                tb.Columns("ServiceName").ColumnName = "Serviceid"
                tb.Columns("CustomerName").ColumnName = "CustomerId"
                tb.Columns("LineName").ColumnName = "lineId"
                tb.Columns("FromRange").ColumnName = "FromRang"
                tb.Columns("ToRange").ColumnName = "ToRang"
                tb.Columns("FromLocation").ColumnName = "HandlingMode"
                tb.Columns("ToLocation").ColumnName = "CargoType"
                tb.Columns("HandoverLocation").ColumnName = "Pol"
                tb.Columns("POL").ColumnName = "PolId"
                tb.Columns("POD").ColumnName = "PortId"
                tb.Columns("Commodity").ColumnName = "CommodityId"
                tb.Columns("RateMethod").ColumnName = "RateType"
                tb.Columns("Enable/Disable").ColumnName = "IsEnable"
                tb.Columns("CustomerNameTable").ColumnName = "CHAID"
                tb.Columns("CustomerTypeTable").ColumnName = "CusType"
                Dim newColumn As New DataColumn("RateKeyId", GetType(String))
                newColumn.DefaultValue = "0"
                tb.Columns.Add(newColumn)
                repRateDetails.DataSource = tb
                repRateDetails.DataBind()
                Dim completePath As String = Server.MapPath("Format/" + fn)
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
            End Using

        Catch
        End Try

        Return dtCsv
    End Function
End Class
