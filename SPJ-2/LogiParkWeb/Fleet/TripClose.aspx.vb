Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_TripClose
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6
    Dim glCommodityMaster As New ExtCommodityMaster

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        Permission(p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            ButtonControlSetup(True)
            lstVehicleNo.Enabled = True
            btnAddVehicle.Visible = True
            'Dim lngContId As Integer = Request.QueryString("CONT_ID")
            'Dim strContNo As String = Request.QueryString("CONT_NO")
            'If lngContId > 0 Then
            '    nevigateddata(lngContId, strContNo)
            '    lstContNo.SelectedValue = lngContId
            'End If
        End If
        textFind.Enabled = True
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
            Session.Item("Search") = row(9).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT CUSTOMER_NAME,CUSTOMER_ID FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='L'"
            cmd2 = "SELECT DISTINCT TERMINAL_NAME,TERMINAL_ID FROM TERMINAL_MASTER"
            cmd1 = "SELECT DISTINCT GP.VEHICLE_NO,GP.GR_NO FROM FLEET_VEHICLE_STATUS FV,FLEET_GR_MAPPING GP,FLEET_CONT_JO_DTLS FCD WHERE GP.GR_ID=FV.GR_ID   AND FCD.MTY_CONT_ID=GP.MTY_CONT_ID  " &
" AND GP.CLOSE_DATE IS NULL AND FACTORY_IN_DATE IS NOT NULL AND FACTORY_OUT_DATE IS NOT NULL  " &
 " AND ICD_IN_DATE IS NOT NULL  " &
            "UNION SELECT DISTINCT GP.VEHICLE_NO,GP.GR_NO FROM FLEET_VEHICLE_STATUS FV, FLEET_CONT_JO_DTLS FCD,  " &
 " FLEET_GR_MAPPING GP WHERE GP.GR_ID=FV.GR_ID  " &
 " AND FCD.MTY_CONT_ID=GP.MTY_CONT_ID  " &
 " AND GP.CLOSE_DATE IS NULL AND FACTORY_IN_DATE IS NOT NULL AND FACTORY_OUT_DATE IS NOT NULL  " &
  " AND FCD.BUFFER_DATE IS NOT NULL " &
                        "UNION SELECT DISTINCT GP.VEHICLE_NO,GP.GR_NO FROM FLEET_VEHICLE_STATUS FV, FLEET_CONT_JO_DTLS FCD,  " &
 " FLEET_GR_MAPPING GP WHERE GP.GR_ID=FV.GR_ID  " &
 " AND FCD.MTY_CONT_ID=GP.MTY_CONT_ID  " &
 " AND GP.CLOSE_DATE IS NULL AND FACTORY_IN_DATE IS NOT NULL AND FACTORY_OUT_DATE IS NOT NULL  " &
  " AND FCD.EMPTYGATE_IN_DATE IS NOT NULL"

            '  cmd1 = "SELECT DISTINCT GP.VEHICLE_NO,GP.GR_NO FROM FLEET_VEHICLE_STATUS FV,FLEET_GR_MAPPING GP WHERE GP.GR_ID=FV.GR_ID AND GP.CLOSE_DATE IS NULL AND FV.FACTORY_IN IS NOT NULL "

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "VEHICLE_NO"
            lstVehicleNo.DataValueField = "GR_NO"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
            'Dim pExtLocationMaster As New TerminalLocationMaster
            'pExtLocationMaster.TerminalId = hdnFromTerminalId.Value
            'lstLocationName.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
            'lstLocationName.DataTextField = "LocationName"
            'lstLocationName.DataValueField = "LocationId"
            'lstLocationName.DataBind()
            'lstLocationName.Items.Insert(0, (New ListItem("---Select---", 0)))
            'lstLocationName.SelectedValue = 0


            'ada = New OleDbDataAdapter(cmd2, con)
            'Dim ds1 As New DataSet("CONTAINER")
            'ada.Fill(ds1)
            'LstCfs.DataSource = ds1.Tables(0)
            'LstCfs.DataTextField = "TERMINAL_NAME"
            'LstCfs.DataValueField = "TERMINAL_ID"
            'LstCfs.DataBind()
            'LstCfs.Items.Insert(0, (New ListItem("---Select---", "0")))
            'ds1.Clear()
            'con.Close()
            'ada = New OleDbDataAdapter(cmd3, con)
            'Dim ds2 As New DataSet("CONTAINER")
            'ada.Fill(ds2)
            'lstLine.DataSource = ds2.Tables(0)
            'lstLine.DataTextField = "CUSTOMER_NAME"
            'lstLine.DataValueField = "CUSTOMER_ID"
            'lstLine.DataBind()
            'lstLine.Items.Insert(0, (New ListItem("---Select---", "0")))
            'ds2.Clear()
            'con.Close()
            For Hr As Integer = 0 To 23
                lstCloseDateHH.Items.Add(New ListItem(Format(Hr, "00"), Format(Hr, "00")))
            Next
            For Min As Integer = 0 To 59
                lstCloseDateMM.Items.Add(New ListItem(Format(Min, "00"), Format(Min, "00")))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareLocation(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strConnectionString, cmd2 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Dim lst As DropDownList = sender
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd2 = "SELECT LOCATION_ID, LOCATION_NAME FROM LOCATION_MASTER WHERE TERMINAL_ID = " & hdnFromTerminalId.Value
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd2, con)
            Dim ds2 As New DataSet("LOCATION")
            ada.Fill(ds2)

            lst.Items.Clear()
            lst.Items.Insert(0, New ListItem("---Select---", "0"))
            For i = 0 To ds2.Tables(0).Rows.Count - 1
                lst.Items.Add(New ListItem(ds2.Tables(0).Rows(i)("LOCATION_NAME"), ds2.Tables(0).Rows(i)("LOCATION_ID")))
            Next
        Catch ex As Exception
            Dim str As String = ex.Message
            lst.Items.Clear()
            lst.Items.Insert(0, New ListItem("---Select---", "0"))
        End Try
        con.Close()
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        btnAdd.Visible = False
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If
        If Session.Item("Edit") <> "Y" Then

        End If

        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        'btnAddBookingNo.Visible = False
        'btnSearchbookingNo.Visible = True
        ' btnSearchJoNo.Visible = True
        'textJobOrderNo.Enabled = True
        'textBookingNo.Enabled = True
        'Functions.ControlFocus(textBookingNo)

    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstVehicleNo.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVehicleNO.Text)
            Functions.ControlFocus(lstVehicleNo)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textClosAmt.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblCLosingAmount.Text)
            Functions.ControlFocus(textClosAmt)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textCloseDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblTripCloseDate.Text)
            Functions.ControlFocus(textCloseDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Dim dtCloseDate As String = Nothing
        Dim dtGRDate As String = Nothing


        Try

            Dim dtGRDate1 As DateTime = Nothing

            Dim dtCloseDate1 As DateTime = Nothing
            dtCloseDate1 = Functions.todate_ddmmyyyy(textCloseDate.Text, "/")
            dtGRDate1 = Functions.todate_ddmmyyyy(textGrDate.Text, "/")
            If dtCloseDate1 <> Nothing Then
                dtGRDate = Date.Parse(dtGRDate1)
                dtCloseDate = Date.Parse(dtCloseDate1)
                If dtGRDate <> Nothing AndAlso dtCloseDate <> Nothing Then
                    If datecheck(dtGRDate, dtCloseDate) = False Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "GR Date should be less than Close Date")
                        rtnBool = False
                        Return rtnBool
                        Exit Function
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

        Return rtnBool
    End Function
    Function datecheck(ByVal OnDate As DateTime, ByVal OffDate As DateTime) As Boolean
        Dim rtn As Boolean = True

        Dim longhow As Int32
        longhow = DateTime.Compare(OnDate, OffDate)
        If longhow > 0 Then

            rtn = False
        End If

        Return rtn



    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetGrMapping As FleetGrMapping = ReturnObject()
        FleetGrMapping.Update(pFleetGrMapping)
        If pFleetGrMapping.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetGrMapping.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAdd.Visible = True
        'btnAddBookingNo.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    Functions.clearControls(Me.dvControl.Controls)
    '    manageUserControls(True)
    '    ButtonControlSetup(True)
    '    textBookingNo.Enabled = True
    '    btnSearchJoNo.Visible = False
    '    btnSearchbookingNo.Visible = False
    '    btnAddBookingNo.Visible = True
    '    Functions.ControlFocus(textBookingNo)
    'End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Private Function ReturnObject() As FleetGrMapping
        Dim pGrMapping As New FleetGrMapping
        pGrMapping.GrId = hdnGrId.Value
        pGrMapping.TerminalId = Session.Item("LoginTerminal")
        pGrMapping.GrNo = textGrNo.Text
        pGrMapping.GrDate = textGrDate.Text
        pGrMapping.ContNo = textContNo.Text
        pGrMapping.CustomerId = hdnCustomerId.Value
        pGrMapping.DriverId = hdnDriverId.Value
        pGrMapping.Advance = Convert.ToInt32(textAdvanceTotal.Text)
        pGrMapping.VehicleNo = lstVehicleNo.SelectedItem.Text
        pGrMapping.TransporterId = hdnTransporterId.Value
        pGrMapping.OilAdvance = lstAdvance.SelectedValue
        ' pGrMapping.FactoryLocation = textLocation.Text
        pGrMapping.CreatedBy = Session.Item("LoginUser")
        pGrMapping.TripType = hdnTripType.Value
        pGrMapping.ClosingAmt = textClosAmt.Text
        pGrMapping.CHAId = lstToLocation.SelectedValue
        ' pGrMapping.LineId = lstLine.SelectedValue
        pGrMapping.CloseDate = textCloseDate.Text & "  " & lstCloseDateHH.SelectedValue & ":" & lstCloseDateMM.SelectedValue
        pGrMapping.Remark = textRemark.Text
        Return (pGrMapping)
    End Function
    Sub prepareControls(ByVal pFleetGrMapping As FleetGrMapping)
        hdnGrId.Value = pFleetGrMapping.GrId
        textGrNo.Text = pFleetGrMapping.GrNo
        textGrDate.Text = pFleetGrMapping.GrDate
        Dim pVendorMaster As New VendorMaster
        pVendorMaster.TerminalId = Session.Item("LoginTerminal")
        pVendorMaster.VendorId = pFleetGrMapping.TransporterId
        Dim pFleetContdtls As New FleetContJo
        pFleetContdtls.TerminalId = Session.Item("LoginTerminal")
        pFleetContdtls.ContJoId = pFleetGrMapping.ContJoId
        FleetContJo.ReturnFleetContJoMode(pFleetContdtls)

        Dim pExtCustomerMaster As New ExtCustomerMaster
        pExtCustomerMaster.CustomerId = pFleetContdtls.ConsigneeId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textShipper.Text = pExtCustomerMaster.CustomerName

        Dim pTerminalMaster As New TerminalMaster
        pTerminalMaster.TerminalId = pFleetContdtls.MtyPickup
        TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
        textFromLocation.Text = pTerminalMaster.TerminalName
        hdnFromTerminalId.Value = pFleetContdtls.TerminalId

        Dim pExtLocationMaster As New TerminalLocationMaster
        pExtLocationMaster.TerminalId = hdnFromTerminalId.Value
        lstToLocation.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
        lstToLocation.DataTextField = "LocationName"
        lstToLocation.DataValueField = "LocationId"
        lstToLocation.DataBind()
        lstToLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
        '   lstToLocation.SelectedValue = 0

        Dim pLocationMaster As New TerminalLocationMaster
        pLocationMaster.TerminalId = pFleetContdtls.TerminalId
        pLocationMaster.LocationId = pFleetContdtls.FromLocation
        TerminalLocationMaster.ReturnTerminalLocationByLocationId(pLocationMaster)
        Try
            lstToLocation.Text = pLocationMaster.LocationId
        Catch ex As Exception

        End Try

        ' pLocationMaster.LocationName = lstToLocation.SelectedValue
        Dim pTerminalMaster1 As New TerminalMaster
        pTerminalMaster1.TerminalId = pFleetContdtls.ToLocationId
        TerminalMaster.ReturnTerminalMaster(pTerminalMaster1)
        textHandover.Text = pTerminalMaster1.TerminalName


        If pFleetGrMapping.TransporterId <> 0 Then
            VendorMaster.ReturnVendorMaster(pVendorMaster)
            textTransportar.Text = pVendorMaster.VendorName
        Else
            textTransportar.Text = "Self"
        End If
        If pFleetGrMapping.CloseDate <> Nothing Then
            textCloseDate.Text = Functions.todate_ddmmyyyyhh24mi(pFleetGrMapping.CloseDate).Item(0)
            lstCloseDateHH.SelectedItem.Text = Functions.todate_ddmmyyyyhh24mi(pFleetGrMapping.CloseDate).Item(1)
            lstCloseDateMM.SelectedItem.Text = Functions.todate_ddmmyyyyhh24mi(pFleetGrMapping.CloseDate).Item(2)
        End If
        hdnCustomerId.Value = pFleetGrMapping.CustomerId
        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerId = pFleetGrMapping.CustomerId
        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
        textCustomer.Text = pCustomerMaster.CustomerName
        textContNo.Text = pFleetGrMapping.ContNo
        textAdvance.Text = pFleetGrMapping.Advance
        textOilAdvance.Text = pFleetGrMapping.OilAdvance
        hdnDriverId.Value = pFleetGrMapping.DriverId

        Dim pVehicle As New FleetEquipmentMaster
        pVehicle.TerminalId = pFleetGrMapping.TerminalId
        pVehicle.EquipmentNo = pFleetGrMapping.VehicleNo
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pVehicle)

        textVehicleSize.Text = pVehicle.EquipmentType

        Dim pFleetDriverMaster As New FleetDriverMaster
        pFleetDriverMaster.TerminalId = Session.Item("LoginTerminal")
        pFleetDriverMaster.DriverId = pFleetGrMapping.DriverId
        FleetDriverMaster.ReturnFleetDriverMaster(pFleetDriverMaster)
        textDriver.Text = pFleetDriverMaster.DriverName
        textContactNo.Text = pFleetDriverMaster.ContactNo
        If pFleetDriverMaster.CreatedBy = "" Then
            textBalance.Text = "0"
        Else

            textBalance.Text = pFleetDriverMaster.CreatedBy

        End If

        textLicenseValidity.Text = pFleetDriverMaster.DlRenewableDate
        If pFleetGrMapping.TripType = "I" Then
            textTripType.Text = "Import"
        Else
            textTripType.Text = "Export"
        End If
        Try
            textAdvanceTotal.Text = Convert.ToInt32(textAdvance.Text) + Convert.ToInt32(textOilAdvance.Text) + Convert.ToInt32(textBalance.Text)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        lstVehicleNo.Enabled = True
    End Sub

    Protected Sub textClosAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textClosAmt.TextChanged
        If Convert.ToInt64(textAdvance.Text) + Convert.ToInt64(textOilAdvance.Text) > Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.Enabled = True
        ElseIf Convert.ToInt64(textAdvance.Text) + Convert.ToInt64(textOilAdvance.Text) + Convert.ToInt64(textBalance.Text) = Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.SelectedValue = 3
        End If

    End Sub
    Protected Sub btnAddVehicle_Click(sender As Object, e As EventArgs) Handles btnAddVehicle.Click
        If lstVehicleNo.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVehicleNO.Text)
            Functions.ControlFocus(lstVehicleNo)
            Exit Sub
        End If
        Dim pFleetGrMapping As New FleetGrMapping
        pFleetGrMapping.TerminalId = Session.Item("LoginTerminal")
        pFleetGrMapping.GrNo = lstVehicleNo.SelectedValue
        FleetGrMapping.ReturnFleetGrMappingByGrNo(pFleetGrMapping)
        prepareControls(pFleetGrMapping)
        ButtonControlSetup(False)
        textClosAmt.Enabled = True
        textCloseDate.Enabled = True
        textRemark.Enabled = True
        lstCloseDateHH.Enabled = True
        lstCloseDateMM.Enabled = True
        lstToLocation.Enabled = True
        'LstCfs.Enabled = True
        'lstLine.Enabled = True
    End Sub
End Class
