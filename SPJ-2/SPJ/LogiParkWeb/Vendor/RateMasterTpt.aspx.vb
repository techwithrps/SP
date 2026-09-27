Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class AdministratorUI_RateMasterTpt
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim arrLocationId As ArrayList
    Dim arrLocationName As ArrayList
    Dim arrCommodityId As ArrayList
    Dim arrCommodityName As ArrayList
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareLocationData()
        prepareCommodityData()
        '    prepareTerminalData()
        If Not IsPostBack Then
            MenuItemHelper.Permission(Me.Page, Request.AppRelativeCurrentExecutionFilePath)
            Dim lngRateId As Integer = Request.QueryString("RATEID")
            ListControlDataBind()
            'ROWS = 1
            fillRepeator(New ArrayList)
            '   lstServiceName.SelectedValue = 54
            '  lstCustomerName.SelectedValue = 0
            If lngRateId > 0 Then
                Dim p As New ExtRateTptVendor
                p.RateTptId = lngRateId
                p.TerminalId = Session.Item("LoginTerminal")
                ExtRateTptVendor.ReturnRateTptVendorDetails(p)
                prepareControlData(p)
            End If
            ButtonControlSetup(True)
            manageUserControlsSummary(True)
            manageUserControlsDetails(True)
            btnAddRow.Visible = False
            btnDeleteRow.Visible = False
            lstServiceName.Enabled = False
        End If
    End Sub

    

    Sub prepareControlData(ByVal p As ExtRateTptVendor)
        hdnRateId.Value = p.RateTptId
        textRateCode.Text = p.RateCode
        lstServiceName.SelectedValue = p.ServiceId
        lstCustomerName.SelectedValue = p.VendorId

        lstBillingCondition.SelectedValue = p.BillingCondition
        If p.VendorId > 0 Then
            Dim pCum As New VendorMaster
            pCum.VendorId = p.VendorId
            VendorMaster.ReturnVendorMaster(pCum)
            lstCustomerName.Items.Add(New ListItem(pCum.VendorName, pCum.VendorId))
        End If
        lstCustomerName.SelectedValue = p.VendorId
        lstServiceName.SelectedValue = p.ServiceId
        prepareLocationData()
        fillRepeator(p.RateTptDetails)
    End Sub

    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pExtRateTptVendor As New ExtRateTptVendor

        Try
            For Each obj As ExtRateTptVendor In ExtRateTptVendor.ReturnRateTptVendorList(pExtRateTptVendor)
                Dim p As New VendorMaster
                p.VendorId = obj.VendorId
                VendorMaster.ReturnVendorMaster(p)
                Dim strServiceDisp As String = Nothing
                If obj.VendorId <= 0 Then
                    strServiceDisp = obj.RateCode
                Else
                    strServiceDisp = obj.RateCode & " - " & p.VendorCode
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnExit.Visible = pVisible
        btnSearch.Visible = False
        btnListAll.Visible = pVisible
        If hdnRateId.Value.Trim <> Nothing AndAlso hdnRateId.Value <> "0" Then
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
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Protected Sub prepareCommodity(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To arrCommodityId.Count - 1
                lst.Items.Add(New ListItem(arrCommodityName(i), arrCommodityId(i)))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareCommodityData()
        Try
            arrCommodityId = New ArrayList
            arrCommodityName = New ArrayList
            Dim pCommodityMaster As New CommodityMaster
            pCommodityMaster.TerminalId = Session.Item("LoginTerminal")
            For Each obj As CommodityMaster In CommodityMaster.ReturnCommodityMasterList(pCommodityMaster)
                arrCommodityId.Add(obj.CommodityId)
                arrCommodityName.Add(obj.CommodityName)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To arrTerminalId.Count - 1
                lst.Items.Add(New ListItem(arrTerminalName(i), arrTerminalId(i)))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareTerminalData()
        Try
            arrTerminalId = New ArrayList
            arrTerminalName = New ArrayList
            Dim pTerminalMaster As New TerminalMaster
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                arrTerminalId.Add(obj.TerminalId)
                arrTerminalName.Add(obj.TerminalCode)
            Next
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControlsDetails(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvDetails.Controls)
    End Sub

    Sub manageUserControlsSummary(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvCustomer.Controls)
    End Sub

    Sub ListControlDataBind()

        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstCustomerName.DataSource = ExtVendorMaster.ReturnVendorMasterListAll(pExtVendorMaster)
        lstCustomerName.DataTextField = "VendorName"
        lstCustomerName.DataValueField = "VendorId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Add(New ListItem("---Select---", "0"))

        Dim pCostServiceMaster As New ServiceMaster
        pCostServiceMaster.TerminalId = Session.Item("LoginTerminal")
        lstServiceName.DataSource = ServiceMaster.ReturnServiceMasterList(pCostServiceMaster)
        lstServiceName.DataTextField = "ServiceName"
        lstServiceName.DataValueField = "ServiceId"
        lstServiceName.DataBind()
        lstServiceName.Items.Add(New ListItem("---Select---", "0"))
        lstServiceName.SelectedValue = 54

    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New RateTptVendorDetails

                p.ImoCode = ""
                arr.Add(p)
            Next
        End If
        repRateDeatils.DataSource = arr
        repRateDeatils.DataBind()
    End Sub

    Sub prepareControlsService(ByVal pCodevalue As TreeNode)
        Dim pExtRateTptVendor As New ExtRateTptVendor
        pExtRateTptVendor.RateTptId = pCodevalue.Value
        ExtRateTptVendor.ReturnRateTptVendorById(pExtRateTptVendor)
        hdnRateId.Value = pExtRateTptVendor.RateTptId
        lstCustomerName.SelectedValue = pExtRateTptVendor.VendorId
        textRateCode.Text = pExtRateTptVendor.RateCode
        fillRepeator(pExtRateTptVendor.RateTptDetails)
    End Sub

    Protected Sub prepareLocation(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            prepareLocationData()
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To arrLocationId.Count - 1
                lst.Items.Add(New ListItem(arrLocationName(i), arrLocationId(i)))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareLocationData()
        Try
            arrLocationId = New ArrayList
            arrLocationName = New ArrayList
            Dim pTL As New LocationMaster
            pTL.TerminalId = Session.Item("LoginTerminal")
            'If LoginTerminal = Nothing Then
            '    pTL.TerminalId = 0
            'Else
            '    pTL.TerminalId = LoginTerminal
            'End If

            For Each obj As LocationMaster In LocationMaster.ReturnLocationMasterList(pTL)
                arrLocationId.Add(obj.LocationRefId)
                arrLocationName.Add(obj.LocationName)

            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub manageRepetorControl(ByRef pEnable As Boolean)
        For Each rep As RepeaterItem In repRateDeatils.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            CType(rep.FindControl("textFromDate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textToDate"), TextBox).Enabled = pEnable
            CType(rep.FindControl("lstDocumentType"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstFromLocation"), DropDownList).Enabled = pEnable
            '            CType(rep.FindControl("lstToLocation"), DropDownList).Enabled = pEnable

            CType(rep.FindControl("lstStuffDestuff"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstTrailorSize"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstContPerTrailor"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstContSize"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstContStatus"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstCargoType"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("lstCommodityID"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("textFromRange"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textToRange"), TextBox).Enabled = pEnable
            CType(rep.FindControl("textRate"), TextBox).Enabled = pEnable
        Next
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvMain.Controls)
        manageUserControlsSummary(False)
        manageUserControlsDetails(False)
        ButtonControlSetup(False)
        manageRepetorControl(True)
        Functions.ControlFocus(textRateCode)
        '    lstServiceName.SelectedValue = 54
        lstServiceName.Enabled = True
        lstCustomerName.SelectedValue = 0
        manageRep()
        btnAddRow.Visible = True
    End Sub

    
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvMain.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControlsSummary(True)
        manageUserControlsDetails(True)
        ButtonControlSetup(True)

        btnAddRow.Visible = False
        btnDeleteRow.Visible = False
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If textRateCode.Text.Trim = Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Rate Code")

            Functions.ControlFocus(textRateCode)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstCustomerName.SelectedValue = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor")
            rtnBool = False
            Functions.ControlFocus(lstCustomerName)
            Return rtnBool
            Exit Function
        End If
        If lstServiceName.SelectedValue = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Service")
            rtnBool = False
            Functions.ControlFocus(lstServiceName)
            Return rtnBool
            Exit Function
        End If

        'Dim dtFrom As Date = Nothing
        'Dim dtTo As Date = Nothing
        'Try
        '    dtFrom = Functions.todate_ddmmyyyy(textEffectiveFrom.Text, "/")
        'Catch ex As Exception
        'End Try
        'Try
        '    dtTo = Functions.todate_ddmmyyyy(textEffectiveTo.Text, "/")
        'Catch ex As Exception

        'End Try
        'If dtTo <= dtFrom Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Effective To Date should be gratter than Effective From Date")
        '    rtnBool = False
        '    Functions.ControlFocus(textEffectiveTo)
        '    Exit Function
        'End If

        'If dtTo < Today.Date Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Effective To Date should not be Less Than Today")
        '    rtnBool = False
        '    Functions.ControlFocus(textEffectiveTo)
        '    Exit Function
        'End If

        For Each rep As RepeaterItem In repRateDeatils.Items
            Dim HdnRateRefId As HiddenField = CType(rep.FindControl("hdnRateRefId"), HiddenField)
            Dim textFromDate As TextBox = CType(rep.FindControl("textFromDate"), TextBox)
            Dim textToDate As TextBox = CType(rep.FindControl("textToDate"), TextBox)
            Dim lstDocumentType As DropDownList = CType(rep.FindControl("lstDocumentType"), DropDownList)
            '  Dim lstHandoverAt As DropDownList = CType(rep.FindControl("lstHandoverAt"), DropDownList)
            Dim lstFromLocation As DropDownList = CType(rep.FindControl("lstFromLocation"), DropDownList)
            Dim lstToLocation As DropDownList = CType(rep.FindControl("lstToLocation"), DropDownList)
            Dim lstStuffDestuff As DropDownList = CType(rep.FindControl("lstStuffDestuff"), DropDownList)
            Dim lstTrailorSize As DropDownList = CType(rep.FindControl("lstTrailorSize"), DropDownList)
            Dim lstContPerTrailor As DropDownList = CType(rep.FindControl("lstContPerTrailor"), DropDownList)
            Dim lstContSize As DropDownList = CType(rep.FindControl("lstContSize"), DropDownList)
            Dim lstContStatus As DropDownList = CType(rep.FindControl("lstContStatus"), DropDownList)
            Dim lstCargoType As DropDownList = CType(rep.FindControl("lstCargoType"), DropDownList)
            Dim lstCommodityId As DropDownList = CType(rep.FindControl("lstCommodityID"), DropDownList)
            Dim textFromRange As TextBox = CType(rep.FindControl("textFromRange"), TextBox)
            Dim textToRange As TextBox = CType(rep.FindControl("textToRange"), TextBox)
            Dim textRate As TextBox = CType(rep.FindControl("textRate"), TextBox)

            If textRate.Text.ToString.Trim = String.Empty Then
                textRate.Text = 0
            End If
            If textRate.Text > 0 Then
                Try
                    If Double.Parse(textFromRange.Text.Trim) < 0 Or textFromRange.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                        Functions.ControlFocus(textFromRange)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                    If Double.Parse(textToRange.Text.Trim) < 0 Or textToRange.Text.Trim = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                        Functions.ControlFocus(textToRange)
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If

                    If Double.Parse(textToRange.Text.Trim) <= Double.Parse(textFromRange.Text.Trim) And Double.Parse(textToRange.Text.Trim) <> 0 And Double.Parse(textFromRange.Text.Trim) <> 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Range should be less than To Range.")
                        Functions.ControlFocus(textToRange)
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

                For Each rep2 As RepeaterItem In repRateDeatils.Items
                    Dim HdnRateRefId2 As HiddenField = CType(rep2.FindControl("hdnRateRefId"), HiddenField)
                    Dim textFromDate2 As TextBox = CType(rep2.FindControl("textFromDate"), TextBox)
                    Dim textToDate2 As TextBox = CType(rep2.FindControl("textToDate"), TextBox)
                    Dim lstDocumentType2 As DropDownList = CType(rep2.FindControl("lstDocumentType"), DropDownList)
                    '     Dim lstHandoverAt2 As DropDownList = CType(rep2.FindControl("lstHandoverAt"), DropDownList)
                    Dim lstFromLocation2 As DropDownList = CType(rep2.FindControl("lstFromLocation"), DropDownList)
                    Dim lstToLocation2 As DropDownList = CType(rep2.FindControl("lstToLocation"), DropDownList)
                    Dim lstStuffDestuff2 As DropDownList = CType(rep2.FindControl("lstStuffDestuff"), DropDownList)
                    Dim lstTrailorSize2 As DropDownList = CType(rep.FindControl("lstTrailorSize"), DropDownList)
                    Dim lstContPerTrailor2 As DropDownList = CType(rep.FindControl("lstContPerTrailor"), DropDownList)
                    Dim lstContSize2 As DropDownList = CType(rep2.FindControl("lstContSize"), DropDownList)
                    Dim lstContStatus2 As DropDownList = CType(rep2.FindControl("lstContStatus"), DropDownList)
                    Dim lstCargoType2 As DropDownList = CType(rep2.FindControl("lstCargoType"), DropDownList)
                    Dim lstCommodityId2 As DropDownList = CType(rep2.FindControl("lstCommodityID"), DropDownList)
                    Dim textFromRange2 As TextBox = CType(rep2.FindControl("textFromRange"), TextBox)
                    Dim textToRange2 As TextBox = CType(rep2.FindControl("textToRange"), TextBox)
                    Dim textRate2 As TextBox = CType(rep2.FindControl("textRate"), TextBox)

                    If rep.ItemIndex <> rep2.ItemIndex Then
                        Try
                            textRate2.Text = Double.Parse(textRate2.Text)
                        Catch ex As Exception
                            textRate2.Text = 0
                        End Try

                        If textRate2.Text > 0 Then
                            If Double.Parse(textFromRange2.Text.Trim) < 0 Or textFromRange2.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                                Functions.ControlFocus(textFromRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If Double.Parse(textToRange2.Text.Trim) < 0 Or textToRange2.Text.Trim = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter positive value")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstDocumentType.SelectedValue = lstDocumentType2.SelectedValue And _
                            lstStuffDestuff.SelectedValue = lstStuffDestuff2.SelectedValue And _
                            lstFromLocation.SelectedValue = lstFromLocation2.SelectedValue And _
                            lstToLocation.SelectedValue = lstToLocation2.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                            lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                            lstCargoType.SelectedValue = lstCargoType2.SelectedValue And _
                            lstCommodityId.SelectedValue = lstCommodityId2.SelectedValue And _
                            Double.Parse(textFromRange.Text.Trim) >= Double.Parse(textFromRange2.Text.Trim) And _
                            Double.Parse(textFromRange.Text.Trim) < Double.Parse(textToRange2.Text.Trim) And _
                             Double.Parse(textToRange.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstDocumentType.SelectedValue = lstDocumentType2.SelectedValue And _
                            lstStuffDestuff.SelectedValue = lstStuffDestuff2.SelectedValue And _
                            lstFromLocation.SelectedValue = lstFromLocation2.SelectedValue And _
                            lstToLocation.SelectedValue = lstToLocation2.SelectedValue And _
                            lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                          lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                          lstCargoType.SelectedValue = lstCargoType2.SelectedValue And _
                          lstCommodityId.SelectedValue = lstCommodityId2.SelectedValue And _
                          Double.Parse(textToRange.Text.Trim) > Double.Parse(textFromRange2.Text.Trim) And _
                            Double.Parse(textToRange.Text.Trim) < Double.Parse(textToRange2.Text.Trim) And _
                           Double.Parse(textToRange2.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
                                Functions.ControlFocus(textToRange2)
                                rtnBool = False
                                Return rtnBool
                                Exit Function
                            End If

                            If lstDocumentType.SelectedValue = lstDocumentType2.SelectedValue And _
                            lstStuffDestuff.SelectedValue = lstStuffDestuff2.SelectedValue And _
                             lstFromLocation.SelectedValue = lstFromLocation2.SelectedValue And _
                            lstToLocation.SelectedValue = lstToLocation2.SelectedValue And _
                             lstContSize.SelectedValue = lstContSize2.SelectedValue And _
                             lstContStatus.SelectedValue = lstContStatus2.SelectedValue And _
                             lstCargoType.SelectedValue = lstCargoType2.SelectedValue And _
                             lstCommodityId.SelectedValue = lstCommodityId2.SelectedValue And _
                               Double.Parse(textFromRange.Text.Trim) <= Double.Parse(textFromRange2.Text.Trim) And _
                               Double.Parse(textFromRange.Text.Trim) >= Double.Parse(textToRange2.Text.Trim) And _
                                Double.Parse(textToRange2.Text.Trim) <> 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Slab already exists.")
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
        Dim pExtRateTptVendor As ExtRateTptVendor = ReturnObject()
        ExtRateTptVendor.InsertUpdateTransaction(pExtRateTptVendor)

        If pExtRateTptVendor.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtRateTptVendor.Errormsg)
            Return
        End If

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnRateId.Value = pExtRateTptVendor.RateTptId
        Dim p As New ExtRateTptVendor
        p.RateTptId = hdnRateId.Value
        ExtRateTptVendor.ReturnRateTptVendorWithDetailsById(p)
        'fillRepeator(p.RateTptDetails)
        Dim strMsg As String = Nothing
        strMsg = SendMail(p)
        If strMsg <> Nothing Then
            'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, strMsg)
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        End If

        ButtonControlSetup(True)
        manageUserControlsSummary(True)
        manageUserControlsDetails(True)
        btnAddRow.Visible = False
        btnDeleteRow.Visible = False
    End Sub
    Protected Sub btnAddRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddRow.Click
        Dim p As New ExtRateTptVendor
        p.RateTptDetails = New ArrayList

        For Each rep As RepeaterItem In repRateDeatils.Items
            Dim pRD As New ExtRateTptVendorDetails
            Try
                pRD.RateTptRefId = CType(rep.FindControl("hdnRateRefId"), HiddenField).Value
            Catch ex As Exception

            End Try

            pRD.FromDate = CType(rep.FindControl("textFromDate"), TextBox).Text
            pRD.ToDate = CType(rep.FindControl("textToDate"), TextBox).Text
            pRD.DocId = CType(rep.FindControl("lstDocumentType"), DropDownList).SelectedValue
            ' pRD.TerminalId = CType(rep.FindControl("lstHandoverAt"), DropDownList).SelectedValue
            pRD.FromLocation = CType(rep.FindControl("lstFromLocation"), DropDownList).SelectedValue
            pRD.ToLocation = CType(rep.FindControl("lstToLocation"), DropDownList).SelectedValue
            pRD.StuffDestuff = CType(rep.FindControl("lstStuffDestuff"), DropDownList).SelectedValue
            pRD.TrailorSize = CType(rep.FindControl("lstTrailorSize"), DropDownList).SelectedValue
            pRD.ContPerTrailor = CType(rep.FindControl("lstContPerTrailor"), DropDownList).SelectedValue
            pRD.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
            pRD.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
            pRD.ContType = CType(rep.FindControl("lstCargoType"), DropDownList).SelectedValue()
            pRD.CommodityId = CType(rep.FindControl("lstCommodityID"), DropDownList).SelectedValue
            Try
                pRD.FromRange = CType(rep.FindControl("textFromRange"), TextBox).Text
            Catch ex As Exception

            End Try
            Try
                pRD.ToRange = CType(rep.FindControl("textToRange"), TextBox).Text
            Catch ex As Exception

            End Try
            Try
                pRD.Rate = CType(rep.FindControl("textRate"), TextBox).Text
            Catch ex As Exception

            End Try


            p.RateTptDetails.Add(pRD)

        Next
        Dim i As Integer = 0
        While i < 10

            Dim x As New RateTptVendorDetails
            p.RateTptDetails.Add(x)
            i += 1
        End While
        fillRepeator(p.RateTptDetails)

    End Sub

    'Function SendMail(ByVal pRateMaster As ExtRateTpt) As String
    '    Dim pStr As String = ""
    '    Dim pMailConfig As New MailConfig
    '    MailConfig.ReturnMailConfig(pMailConfig)

    '    Dim xMailSetup As New MailSetup
    '    xMailSetup.MenuId = Session.Item("MenuId")
    '    MailSetup.ReturnMailSetup(xMailSetup)

    '    Dim pUser As New ExtUserMaster
    '    pUser.UserId = Session.Item("LoginUser")
    '    ExtUserMaster.ReturnUserMaster(pUser)

    '    Dim pCustomerMaster As New CustomerMaster
    '    pCustomerMaster.CustomerId = pRateMaster.CustomerId
    '    CustomerMaster.ReturnCustomerMaster(pCustomerMaster)

    '    Dim strBodyMail As String = "Dear Sir <br/>"
    '    strBodyMail &= "Greeting <br/>"
    '    If pRateMaster.RateType = "P" Then
    '        strBodyMail &= "New/Modified Rate for Public Tariff are added. <br/> Please Verify and Approve.<br/><br/>"
    '    Else

    '        strBodyMail &= "New/Modified Rate for Customer """ & pCustomerMaster.CustomerName & """ are added for Teriff Code """ & pRateMaster.RateCode & """"
    '        strBodyMail &= "<br/> Please Verify and Approve.<br/><br/>"
    '    End If

    '    pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pUser.UserName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, strBodyMail, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

    '    Return pStr
    'End Function

    'Change By Dhirendra K. Singh
    Function SendMail(ByVal pExtRateTptVendor As ExtRateTptVendor) As String
        Dim pStr As String = ""
        'Dim pMailConfig As New MailConfig
        'MailConfig.ReturnMailConfig(pMailConfig)

        'Dim xMailSetup As New MailSetup
        'xMailSetup.MenuId = Session.Item("MenuId")
        'xMailSetup.TerminalId = 0
        'MailSetup.ReturnMailSetup(xMailSetup)

        'Dim pUser As New ExtUserMaster
        'pUser.UserId = Session.Item("LoginUser")
        'ExtUserMaster.ReturnUserMaster(pUser)

        'Dim pVendorMaster As New VendorMaster
        'pVendorMaster.VendorId = pExtRateTptVendor.VendorId
        'VendorMaster.ReturnVendorMaster(pVendorMaster)

        'xMailSetup.MailBody &= "<br/>"
        'xMailSetup.MailBody &= " " & "<br/>"
        'xMailSetup.MailBody &= "Rate Code :- " & textRateCode.Text & "<br/>"
        ''xMailSetup.MailBody &= "Rate Type :- " & lstRateType.SelectedItem.Text & "<br/>"
        'xMailSetup.MailBody &= "Service Name :- " & lstServiceName.SelectedItem.Text & "<br/>"
        'xMailSetup.MailBody &= "Billing Condition :- " & lstBillingCondition.SelectedItem.Text & "<br/>"
        ''xMailSetup.MailBody &= "Terminal :- " & lstTerminal.SelectedItem.Text & "<br/>"
        ''xMailSetup.MailBody &= "Effective From :- " & textEffectiveFrom.Text & "<br/>"
        ''xMailSetup.MailBody &= "Effective To :- " & textEffectiveTo.Text & "<br/>"

        'If lstCustomerName.SelectedValue <> 0 Then
        '    xMailSetup.MailBody &= "Vendor Name :- " & lstCustomerName.SelectedItem.Text & "<br/>"
        'End If

        'xMailSetup.MailBody &= " " & "<br/>"
        'xMailSetup.MailBody &= " " & "<br/>"

        'xMailSetup.MailBody &= " Thanks & Regards " & "<br/>"
        'Dim p As New CompanyMaster
        'CompanyMaster.ReturnCompanyMaster(p)
        'xMailSetup.MailBody &= p.CompanyName & "<br/>"

        'pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromId, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        ''Dim strBodyMail As String = "Dear Sir <br/>"
        ''strBodyMail &= "Greeting <br/>"
        ''If pRateMaster.RateType = "P" Then
        ''    strBodyMail &= "New/Modified Rate for Public Tariff are added. <br/> Please Verify and Approve.<br/><br/>"
        ''Else

        ''    strBodyMail &= "New/Modified Rate for Customer """ & pCustomerMaster.CustomerName & """ are added for Teriff Code """ & pRateMaster.RateCode & """"
        ''    strBodyMail &= "<br/> Please Verify and Approve.<br/><br/>"
        ''End If

        ''pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pUser.UserName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, strBodyMail, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function

    Function ReturnObject() As ExtRateTptVendor
        Dim pExtRateTptVendor As New ExtRateTptVendor
        If hdnRateId.Value <> Nothing AndAlso hdnRateId.Value > 0 Then
            pExtRateTptVendor.RateTptId = hdnRateId.Value
        End If
        pExtRateTptVendor.ServiceId = lstServiceName.SelectedValue
        pExtRateTptVendor.TerminalId = Session.Item("LoginTerminal")
        pExtRateTptVendor.VendorId = lstCustomerName.SelectedValue
        pExtRateTptVendor.RateCode = textRateCode.Text
        pExtRateTptVendor.CreatedBy = Session.Item("LoginUser")
        pExtRateTptVendor.BillingCondition = lstBillingCondition.SelectedValue
        pExtRateTptVendor.RateTptDetails = New ArrayList

        For Each rep As RepeaterItem In repRateDeatils.Items
            If CType(rep.FindControl("textRate"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textRate"), TextBox).Text > 0 Then
                Dim p As New ExtRateTptVendorDetails
                Try
                    p.RateTptRefId = CType(rep.FindControl("hdnRateRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    p.FromDate = CType(rep.FindControl("textFromDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.ToDate = CType(rep.FindControl("textToDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    p.DocId = CType(rep.FindControl("lstDocumentType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.TerminalId = Session.Item("LoginTerminal")
                Catch ex As Exception
                End Try
                Try
                    p.FromLocation = CType(rep.FindControl("lstFromLocation"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try

                Try
                    p.ToLocation = CType(rep.FindControl("lstToLocation"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.StuffDestuff = CType(rep.FindControl("lstStuffDestuff"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.TrailorSize = CType(rep.FindControl("lstTrailorSize"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContPerTrailor = CType(rep.FindControl("lstContPerTrailor"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.ContType = CType(rep.FindControl("lstCargoType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.CommodityId = CType(rep.FindControl("lstCommodityID"), DropDownList).SelectedValue
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
                pExtRateTptVendor.RateTptDetails.Add(p)
            End If
        Next

        Return pExtRateTptVendor
    End Function

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControlsSummary(True)
        manageUserControlsDetails(False)
        ButtonControlSetup(False)
        manageRepetorControl(True)
        btnEdit.Visible = False
        btnAddRow.Visible = True
        btnDeleteRow.Visible = True
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub btnListAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListAll.Click
        Response.Redirect("RateMasterVendorListAll.aspx")
    End Sub

    'Protected Sub lstCustomerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomerType.SelectedIndexChanged
    '    Dim pCustomer As New ExtCustomerMaster

    '    ' lstCustomerName.Items.Clear()

    '    lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAllByCustomerTypeCode(pCustomer, lstCustomerType.SelectedValue.ToString)
    '    lstCustomerName.DataTextField = "CustomerName"
    '    lstCustomerName.DataValueField = "CustomerId"
    '    lstCustomerName.DataBind()
    '    lstCustomerName.Items.Add(New ListItem("----Select----", "0"))
    '    If lstCustomerType.SelectedValue = "" Then
    '        lstCustomerName.Enabled = False
    '        lstCustomerName.SelectedValue = 0
    '    Else
    '        lstCustomerName.Enabled = True
    '        lstCustomerName.SelectedValue = 0
    '    End If
    '    manageRep()
    'End Sub

    Sub manageRep()
        For Each e As RepeaterItem In repRateDeatils.Items
            CType(e.FindControl("textFromDate"), TextBox).Enabled = True
            CType(e.FindControl("textToDate"), TextBox).Enabled = True
            CType(e.FindControl("lstDocumentType"), DropDownList).Enabled = True

            CType(e.FindControl("lstFromLocation"), DropDownList).Enabled = True
            CType(e.FindControl("lstToLocation"), DropDownList).Enabled = True
            CType(e.FindControl("lstStuffDestuff"), DropDownList).Enabled = True
            CType(e.FindControl("lstTrailorSize"), DropDownList).Enabled = True
            CType(e.FindControl("lstContPerTrailor"), DropDownList).Enabled = True
            CType(e.FindControl("lstContStatus"), DropDownList).Enabled = True
            CType(e.FindControl("lstContSize"), DropDownList).Enabled = True
            CType(e.FindControl("lstCargoType"), DropDownList).Enabled = True
            CType(e.FindControl("lstCommodityID"), DropDownList).Enabled = True
            CType(e.FindControl("textFromRange"), TextBox).Enabled = True
            CType(e.FindControl("textToRange"), TextBox).Enabled = True
            CType(e.FindControl("textRate"), TextBox).Enabled = True
        Next
    End Sub

    'Protected Sub lstServiceName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstServiceName.SelectedIndexChanged
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    If lstRateType.SelectedValue = "C" And lstCustomerType.SelectedValue = "" Then
    '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Custoumer Type")
    '        Functions.ControlFocus(lstCustomerType)
    '        Return
    '    End If
    '    If lstRateType.SelectedValue = "C" And lstCustomerName.SelectedValue = 0 Then
    '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Custoumer Name")
    '        Functions.ControlFocus(lstCustomerName)
    '        Return
    '    End If

    '    Dim p As New ExtRateTptVendor

    '    p.ServiceId = lstServiceName.SelectedValue
    '    p.BillingCondition = lstBillingCondition.SelectedValue
    '    p.TerminalId = lstTerminal.SelectedValue
    '    ExtRateTptVendor.ReturnRateTptByServiceIdWithCurrentDate(p)
    '    If p.RateTptId <= 0 Then
    '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Public Tariff not fount")
    '        Functions.ControlFocus(lstServiceName)
    '    End If

    '    ExtRateTptVendor.ReturnRateTptVendorWithDetailsById(p)
    '    Dim arr As New ArrayList
    '    If p.RateTptDetails.Count = 0 Then
    '        fillRepeator(New ArrayList)
    '        manageRep()
    '        Return
    '    Else
    '        For Each r As RateTptDetails In p.RateTptDetails
    '            r.RateTptRefId = 0
    '            arr.Add(r)
    '        Next
    '    End If
    '    fillRepeator(arr)
    '    manageRep()

    'End Sub

    'Protected Sub lstTerminal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstTerminal.SelectedIndexChanged
    '    Dim p As New ExtRateTptVendor
    '    p.RateTptDetails = New ArrayList

    '    For Each rep As RepeaterItem In repRateDeatils.Items
    '        Dim pRD As New ExtRateTptVendorDetails

    '        'pRD.TerminalId = CType(rep.FindControl("lstHandoverAt"), DropDownList).SelectedValue
    '        lstTerminal.SelectedValue = CType(rep.FindControl("lstHandoverAt"), DropDownList).SelectedValue
    '        'pRD.DocId = CType(rep.FindControl("lstDocumentType"), DropDownList).SelectedValue
    '        pRD.FromLocation = 0
    '        'pRD.ContSize = CType(rep.FindControl("lstContSize"), DropDownList).SelectedValue
    '        'pRD.ContStatus = CType(rep.FindControl("lstContStatus"), DropDownList).SelectedValue
    '        'pRD.ContType = CType(rep.FindControl("lstCargoType"), DropDownList).SelectedValue()
    '        'pRD.CommodityId = CType(rep.FindControl("lstCommodityID"), DropDownList).SelectedValue
    '        'Try
    '        '    pRD.FromRange = CType(rep.FindControl("textFromRange"), TextBox).Text
    '        'Catch ex As Exception
    '        'End Try
    '        'Try
    '        '    pRD.ToRange = CType(rep.FindControl("textToRange"), TextBox).Text
    '        'Catch ex As Exception
    '        'End Try
    '        'Try
    '        '    pRD.Rate = CType(rep.FindControl("textRate"), TextBox).Text
    '        'Catch ex As Exception
    '        'End Try
    '        p.RateTptDetails.Add(pRD)
    '    Next
    '    fillRepeator(p.RateTptDetails)
    '    manageRep()
    'End Sub
End Class
