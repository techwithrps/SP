Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Vendor_VendorContract
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 9
    Dim glUom As New ArrayList
    Dim glIsoCode As New ArrayList
    Dim glService As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        Dim pp As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, pp)
        If Not IsPostBack Then
            
            Dim lngRateId As Integer = Request.QueryString("ContractId")
            ListControlDataBind()
            fillRepeator(New ArrayList)
            If lngRateId > 0 Then
                Dim p As New ExtVendorContract
                p.TerminalId = Session.Item("LoginTerminal")
                p.ContractId = lngRateId
                ExtVendorContract.ReturnVendorContractById(p)
                prepareControlData(p)
            End If
            ButtonControlSetup(True)
            manageUserControls(True)
            btnAddRow.Visible = False
            btnDeleteRow.Visible = False
            If hdnContractId.Value <> Nothing AndAlso hdnContractId.Value <> "0" Then
                textEffectiveTo.Enabled = True
                Functions.ControlFocus(textEffectiveTo)
                btnUpdate.Visible = True
            End If
        End If
        btnUpdate.Visible = False
    End Sub

    

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnExit.Visible = pVisible
        btnListAll.Visible = pVisible
        If hdnContractId.Value.Trim <> Nothing AndAlso hdnContractId.Value <> "0" Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
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

    Sub ListControlDataBind()
        Dim pTerminalMaster As New TerminalMaster
        lstTerminalName.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstTerminalName.DataTextField = "TerminalCode"
        lstTerminalName.DataValueField = "TerminalId"
        lstTerminalName.DataBind()
        lstTerminalName.Items.Add(New ListItem("----Select----", "0"))
        lstTerminalName.SelectedValue = 0

        Dim pVendorType As New VendorType
        pVendorType.TerminalId = Session.Item("LoginTerminal")
        lstVendorType.DataSource = VendorType.ReturnVendorTypeList(pVendorType)
        lstVendorType.DataTextField = "VendorTypeName"
        lstVendorType.DataValueField = "VendorTypeCode"
        lstVendorType.DataBind()
        lstVendorType.Items.Add(New ListItem("----Select----", "0"))
        lstVendorType.SelectedValue = 0

        Dim pVendorMaster As New VendorMaster
        pVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendor.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
        lstVendor.DataTextField = "VendorName"
        lstVendor.DataValueField = "VendorId"
        lstVendor.DataBind()
        lstVendor.Items.Add(New ListItem("----Select----", "0"))
        lstVendor.SelectedValue = 0
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub manageUserControlsRepeater(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvdetails.Controls)
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New VendorContractDetails
                p.ContType = "A"
                p.DocType = "A"
                p.ContSize = "A"
                p.ContStatus = "A"
                p.ImoCode = "A"
                arr.Add(p)
            Next
        End If
        repRateDetails.DataSource = arr
        repRateDetails.DataBind()
    End Sub

    Protected Sub prepareUom(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For Each ic As UomMaster In glUom
                lst.Items.Add(New ListItem(ic.UomName, ic.UomId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("ALL", "0"))
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
            lst.Items.Add(New ListItem("ALL", "A"))
            For Each ic As IsoCode In glIsoCode
                lst.Items.Add(New ListItem(ic.ContType, ic.ContType))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareDataRepControlsList()
        Dim p As New UomMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glUom = UomMaster.ReturnUomMasterList(p)

        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        glService = ServiceMaster.ReturnServiceMasterList(pService)
        Dim pIso As New IsoCode
        glIsoCode = IsoCode.ReturnIsoCodeListOfContType(pIso)
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(False)
        ButtonControlSetup(False)
        Functions.ControlFocus(lstTerminalName)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(True)
        btnUpdate.Visible = False
        btnAddRow.Visible = False
        btnDeleteRow.Visible = False
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        manageUserControlsRepeater(False)
        ButtonControlSetup(False)
        textEffectiveTo.Enabled = True
        btnEdit.Visible = False
        btnAddRow.Visible = True
        btnUpdate.Visible = False
        btnDeleteRow.Visible = True
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub prepareControlData(ByVal pExtVendorContract As ExtVendorContract)
        hdnContractId.Value = pExtVendorContract.ContractId
        lstTerminalName.SelectedValue = pExtVendorContract.TerminalId
        lstVendorType.SelectedValue = pExtVendorContract.VendorTypeCode
        lstVendor.SelectedValue = pExtVendorContract.VendorId
        textContractCode.Text = pExtVendorContract.ContractCode
        textEffectiveFrom.Text = pExtVendorContract.EffectiveFrom
        textEffectiveTo.Text = pExtVendorContract.EffectiveTo
        fillRepeator(pExtVendorContract.VendorContractDetailsList)
    End Sub

    Protected Sub lstVendorType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendorType.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pVendorMaster As New ExtVendorMaster
        pVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendor.DataSource = ExtVendorMaster.ReturnVendorMasterListTypeCode(pVendorMaster, lstVendorType.SelectedValue)
        lstVendor.DataTextField = "VendorName"
        lstVendor.DataValueField = "VendorId"
        lstVendor.DataBind()
        If lstVendorType.SelectedValue = "" Then
            lstVendor.Enabled = False
            lstVendor.SelectedValue = 0
        Else
            lstVendor.Enabled = True
        End If
        Functions.ControlFocus(lstVendor)
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If textContractCode.Text.Trim = Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Contract Code")
            rtnBool = False
            Functions.ControlFocus(textContractCode)
            Return rtnBool
            Exit Function
        End If
        If textEffectiveFrom.Text.Trim = Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Effective From Date")
            rtnBool = False
            Functions.ControlFocus(textEffectiveFrom)
            Return rtnBool
            Exit Function
        End If
        If textEffectiveTo.Text.Trim = Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Effective To Date")
            rtnBool = False
            Functions.ControlFocus(textEffectiveTo)
            Return rtnBool
            Exit Function
        End If

        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing
        Try
            dtFrom = Functions.todate_ddmmyyyy(textEffectiveFrom.Text, "/")
        Catch ex As Exception
        End Try
        Try
            dtTo = Functions.todate_ddmmyyyy(textEffectiveTo.Text, "/")
        Catch ex As Exception

        End Try
        If dtTo < dtFrom Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Effective To Date should be greater than Effective From Date")
            rtnBool = False
            Functions.ControlFocus(textEffectiveTo)
            Return rtnBool
            Exit Function
        End If
        If dtTo < Today.Date Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Effective To Date should be greater than Today")
            rtnBool = False
            Functions.ControlFocus(textEffectiveTo)
            Return rtnBool
            Exit Function
        End If
        For Each rep As RepeaterItem In repRateDetails.Items
            'Dim hdnContractId As HiddenField = CType(rep.FindControl("hdnContractId"), HiddenField)
            Dim lstUmoId As DropDownList = CType(rep.FindControl("lstUomId"), DropDownList)
            Dim lstServiceId As DropDownList = CType(rep.FindControl("lstServiceId"), DropDownList)
            Dim lstDocId As DropDownList = CType(rep.FindControl("lstDocId"), DropDownList)
            Dim lstContSize As DropDownList = CType(rep.FindControl("lstContSize"), DropDownList)
            Dim lstContStatus As DropDownList = CType(rep.FindControl("lstContStatus"), DropDownList)
            Dim lstCargoType As DropDownList = CType(rep.FindControl("lstCargoType"), DropDownList)
            Dim lstImoCode As DropDownList = CType(rep.FindControl("lstImoId"), DropDownList)
            Dim textFromRange As TextBox = CType(rep.FindControl("textFromRange"), TextBox)
            Dim textToRange As TextBox = CType(rep.FindControl("textToRange"), TextBox)
            Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)
            Dim lstVendor As DropDownList = CType(rep.FindControl("lstVendor"), DropDownList)
            If textRate.Text.ToString.Trim = String.Empty Then
                textRate.Text = 0
            End If
            If textRate.Text > 0 Then
                Try
                    If Double.Parse(textFromRange.Text.Trim) < 0 Or textFromRange.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Positive Value")
                        Functions.ControlFocus(textFromRange)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                    If Double.Parse(textToRange.Text.Trim) < 0 Or textToRange.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Positive Value")
                        Functions.ControlFocus(textToRange)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If Double.Parse(textToRange.Text.Trim) <= Double.Parse(textFromRange.Text.Trim) And Double.Parse(textToRange.Text.Trim) <> 0 And Double.Parse(textFromRange.Text.Trim) <> 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Range Should be less than To Range.")
                        Functions.ControlFocus(textToRange)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Double.Parse(textRate.Text) < 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Positive Value.")
                        Functions.ControlFocus(textRate)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                Catch ex As Exception
                End Try
                For Each rep2 As RepeaterItem In repRateDetails.Items
                    Dim lstUmoId2 As DropDownList = CType(rep2.FindControl("lstUomId"), DropDownList)
                    Dim lstServiceId2 As DropDownList = CType(rep2.FindControl("lstServiceId"), DropDownList)
                    Dim lstDocId2 As DropDownList = CType(rep2.FindControl("lstDocId"), DropDownList)
                    Dim lstContSize2 As DropDownList = CType(rep2.FindControl("lstContSize"), DropDownList)
                    Dim lstContStatus2 As DropDownList = CType(rep2.FindControl("lstContStatus"), DropDownList)
                    Dim lstCargoType2 As DropDownList = CType(rep2.FindControl("lstCargoType"), DropDownList)
                    Dim lstImoCode2 As DropDownList = CType(rep2.FindControl("lstImoId"), DropDownList)
                    Dim textFromRange2 As TextBox = CType(rep2.FindControl("textFromRange"), TextBox)
                    Dim textToRange2 As TextBox = CType(rep2.FindControl("textToRange"), TextBox)
                    Dim textRate2 As TextBox = CType(rep2.FindControl("textRate"), TextBox)
                    Dim lstVendor2 As DropDownList = CType(rep2.FindControl("lstVendor"), DropDownList)
                    If rep.ItemIndex <> rep2.ItemIndex Then
                        Try
                            textRate2.Text = Double.Parse(textRate2.Text)
                        Catch ex As Exception
                            textRate2.Text = 0
                        End Try
                        If textRate2.Text > 0 Then
                            If Double.Parse(textFromRange2.Text.Trim) < 0 Or textFromRange2.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Positive Value")
                                Functions.ControlFocus(textFromRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If Double.Parse(textToRange2.Text.Trim) < 0 Or textToRange2.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Positive Value")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If lstUmoId.SelectedValue = lstUmoId2.SelectedValue And _
                            lstServiceId.SelectedValue = lstServiceId2.SelectedValue And _
                            lstDocId.SelectedValue = lstDocId2.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                            lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                            lstImoCode.SelectedValue = lstImoCode2.SelectedValue And _
                            Double.Parse(textFromRange.Text.Trim) >= Double.Parse(textFromRange2.Text.Trim) And _
                            Double.Parse(textFromRange.Text.Trim) < Double.Parse(textToRange2.Text.Trim) And _
                             Double.Parse(textToRange.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Range Already Exists.")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If lstUmoId.SelectedValue = lstUmoId2.SelectedValue And _
                          lstServiceId.SelectedValue = lstServiceId2.SelectedValue And _
                          lstDocId.SelectedValue = lstDocId2.SelectedValue And _
                          lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                          lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                          lstImoCode.SelectedValue = lstImoCode2.SelectedValue And _
                          Double.Parse(textToRange.Text.Trim) > Double.Parse(textFromRange2.Text.Trim) And _
                            Double.Parse(textToRange.Text.Trim) < Double.Parse(textToRange2.Text.Trim) And _
                           Double.Parse(textToRange2.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Range Already Exists.")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If
                            If lstUmoId.SelectedValue = lstUmoId2.SelectedValue And _
                          lstServiceId.SelectedValue = lstServiceId2.SelectedValue And _
                          lstDocId.SelectedValue = lstDocId2.SelectedValue And _
                          lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                          lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                          lstImoCode.SelectedValue = lstImoCode2.SelectedValue And _
                            Double.Parse(textFromRange.Text.Trim) <= Double.Parse(textFromRange2.Text.Trim) And _
                            Double.Parse(textFromRange.Text.Trim) >= Double.Parse(textToRange2.Text.Trim) And _
                             Double.Parse(textToRange2.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Range Already Exists.")
                                Functions.ControlFocus(textToRange2)
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
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtVendorContract As ExtVendorContract = ReturnObject()
        If pExtVendorContract.VendorContractDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor Details")
            Return
        End If
        ExtVendorContract.InsertUpdateTransaction(pExtVendorContract)

        If pExtVendorContract.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtVendorContract.Errormsg)
            Return
        End If

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnContractId.Value = pExtVendorContract.ContractId
        Dim pVendorContract As New ExtVendorContract
        pVendorContract.TerminalId = pExtVendorContract.TerminalId
        pVendorContract.ContractId = hdnContractId.Value
        ExtVendorContract.ReturnVendorContractById(pVendorContract)
        fillRepeator(pVendorContract.VendorContractDetailsList)
        ButtonControlSetup(True)
        manageUserControls(True)
        btnAddRow.Visible = False
        btnUpdate.Visible = False
        btnDeleteRow.Visible = False
    End Sub

    Function ReturnObject() As ExtVendorContract
        Dim pExtVendorContract As New ExtVendorContract
        If hdnContractId.Value <> Nothing AndAlso hdnContractId.Value > 0 Then
            pExtVendorContract.ContractId = hdnContractId.Value
        End If
        pExtVendorContract.TerminalId = lstTerminalName.SelectedValue
        pExtVendorContract.VendorTypeCode = lstVendorType.SelectedValue
        pExtVendorContract.VendorId = lstVendor.SelectedValue
        pExtVendorContract.ContractCode = textContractCode.Text
        pExtVendorContract.ApprovalFlage = "N"
        pExtVendorContract.EffectiveFrom = textEffectiveFrom.Text
        pExtVendorContract.EffectiveTo = textEffectiveTo.Text
        pExtVendorContract.CreatedBy = Session.Item("LoginUser")

        pExtVendorContract.VendorContractDetailsList = New ArrayList
        For Each rep As RepeaterItem In repRateDetails.Items
            If CType(rep.FindControl("textRate"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textRate"), TextBox).Text > 0 Then
                Dim p As New VendorContractDetails
                p.TerminalId = lstTerminalName.SelectedValue
                Try
                    p.ContractId = CType(rep.FindControl("hdnContractId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.ContractRefId = CType(rep.FindControl("hdnContractRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.UomId = CType(rep.FindControl("lstUomId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ApprovalFlag = "N"
                Catch ex As Exception
                End Try
                Try
                    p.ServiceId = CType(rep.FindControl("lstServiceId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.DocType = CType(rep.FindControl("lstDocId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContType = CType(rep.FindControl("lstContType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ImoCode = CType(rep.FindControl("lstImoId"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.FromRange = CType(rep.FindControl("textFromRange"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ToRange = CType(rep.FindControl("textToRange"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.Rate = CType(rep.FindControl("textRate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.FromDate = CType(rep.FindControl("textrFromDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ToDate = CType(rep.FindControl("textrFromDate"), TextBox).Text
                Catch ex As Exception
                End Try
                pExtVendorContract.VendorContractDetailsList.Add(p)
            End If
        Next
        Return pExtVendorContract
    End Function

    Protected Sub btnListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListAll.Click
        Response.Redirect("VendorContractListAll.aspx")
    End Sub

    Protected Sub btnAddRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
        manageRepetorControlAddRow(True)
    End Sub

    Sub manageRepetorControlAddRow(ByRef pEnable As Boolean)
        Dim pTSC As New ExtVendorContract
        pTSC.VendorContractDetailsList = New ArrayList
        For Each rep As RepeaterItem In repRateDetails.Items
            Dim pVendorContractDetails As New VendorContractDetails
            pVendorContractDetails.ContractRefId = CType(rep.FindControl("hdnContractRefId"), HiddenField).Value
            pVendorContractDetails.TerminalId = CType(rep.FindControl("hdnTerminalId"), HiddenField).Value
            pVendorContractDetails.ContractId = CType(rep.FindControl("hdnContractId"), HiddenField).Value
            pVendorContractDetails.FromDate = CType(rep.FindControl("textrToDate"), TextBox).Text
            pVendorContractDetails.ToDate = CType(rep.FindControl("textrFromDate"), TextBox).Text
            pVendorContractDetails.UomId = CType(rep.FindControl("lstUomId"), DropDownList).SelectedValue
            pVendorContractDetails.ServiceId = CType(rep.FindControl("lstServiceId"), DropDownList).SelectedValue
            pVendorContractDetails.DocType = CType(rep.FindControl("lstDocId"), DropDownList).SelectedValue
            pVendorContractDetails.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
            pVendorContractDetails.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
            pVendorContractDetails.ContType = CType(rep.FindControl("lstContType"), DropDownList).SelectedValue
            pVendorContractDetails.ImoCode = CType(rep.FindControl("lstImoId"), DropDownList).SelectedValue
            pVendorContractDetails.FromRange = CType(rep.FindControl("textFromRange"), TextBox).Text
            pVendorContractDetails.ToRange = CType(rep.FindControl("textToRange"), TextBox).Text
            pVendorContractDetails.Rate = CType(rep.FindControl("textRate"), TextBox).Text
            pTSC.VendorContractDetailsList.Add(pVendorContractDetails)
        Next
        Dim i As Integer = 0
        While i < 10
            Dim x As New VendorContractDetails
            x.ContType = "A"
            x.DocType = "A"
            x.ContSize = "A"
            x.ContStatus = "A"
            x.ImoCode = "A"
            pTSC.VendorContractDetailsList.Add(x)
            i += 1
        End While
        fillRepeator(pTSC.VendorContractDetailsList)
    End Sub

    Protected Sub btnDeleteRow_Click(sender As Object, e As System.EventArgs) Handles btnDeleteRow.Click
        manageRepetorControlDeleteRow(True)
    End Sub

    Sub manageRepetorControlDeleteRow(ByRef pEnable As Boolean)
        Dim pTSC As New ExtVendorContract
        pTSC.VendorContractDetailsList = New ArrayList
        For Each rep As RepeaterItem In repRateDetails.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = False AndAlso CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then
                Dim pVendorContractDetails As New VendorContractDetails
                pVendorContractDetails.ContractRefId = CType(rep.FindControl("hdnContractRefId"), HiddenField).Value
                pVendorContractDetails.TerminalId = CType(rep.FindControl("hdnTerminalId"), HiddenField).Value
                pVendorContractDetails.ContractId = CType(rep.FindControl("hdnContractId"), HiddenField).Value
                pVendorContractDetails.FromDate = CType(rep.FindControl("textrToDate"), TextBox).Text
                pVendorContractDetails.ToDate = CType(rep.FindControl("textrFromDate"), TextBox).Text
                pVendorContractDetails.UomId = CType(rep.FindControl("lstUomId"), DropDownList).SelectedValue
                pVendorContractDetails.ServiceId = CType(rep.FindControl("lstServiceId"), DropDownList).SelectedValue
                pVendorContractDetails.DocType = CType(rep.FindControl("lstDocId"), DropDownList).SelectedValue
                pVendorContractDetails.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
                pVendorContractDetails.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
                pVendorContractDetails.ContType = CType(rep.FindControl("lstContType"), DropDownList).SelectedValue
                pVendorContractDetails.ImoCode = CType(rep.FindControl("lstImoId"), DropDownList).SelectedValue
                pVendorContractDetails.FromRange = CType(rep.FindControl("textFromRange"), TextBox).Text
                pVendorContractDetails.ToRange = CType(rep.FindControl("textToRange"), TextBox).Text
                pVendorContractDetails.Rate = CType(rep.FindControl("textRate"), TextBox).Text
                pTSC.VendorContractDetailsList.Add(pVendorContractDetails)
            End If
        Next
        Dim i As Integer = 0
        While i < 10
            Dim x As New VendorContractDetails
            x.ContType = "A"
            x.DocType = "A"
            x.ContSize = "A"
            x.ContStatus = "A"
            x.ImoCode = "A"
            pTSC.VendorContractDetailsList.Add(x)
            i += 1
        End While
        fillRepeator(pTSC.VendorContractDetailsList)
    End Sub
End Class
