Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Imports Newtonsoft.Json.Linq

Partial Class Fleet_GrMapping
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim count As Integer = 0
    Dim lngContJoId As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        hdnCount.Value = 0
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            ButtonControlSetup(True)
            Dim lngGrId As Integer = Request.QueryString("GRID")
            lngContJoId = Request.QueryString("CONTJOID")
            If lngGrId > 0 Then
                ListControlDataBindVehicle()
                Searchdata(lngGrId)
                hdnGrId.Value = lngGrId
                btnAdd.Visible = True
                btnPrint.Visible = True
                btnEdit.Visible = True
                btnEdit.Enabled = True
            End If
        End If
        textGrDate.Enabled = True
        ddchkContainer.Enabled = True
        textFind.Enabled = True
        textFindDriver.Enabled = True
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If textGrNo.Text.Trim <> Nothing Then
            '  If Session.Item("CompanyId") = "1" Then
            Response.Redirect("PRINT/GRPrint.aspx?GRNo=" & textGrNo.Text)

        End If
    End Sub


    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
        If ds2 Is Nothing Then
            Return
        End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT MTY_CONT_ID,(FCJD.CONT_NO || '-' || FCJ.CONT_JO_NO) CONT_NO FROM FLEET_CONT_JO_DTLS FCJD,FLEET_CONT_JO FCJ WHERE NVL(FCJD.GR_ID,0) =0 AND  FCJ.TRANSPORTER_ID NOT IN(109) AND FCJ.CONT_JO_ID=FCJD.CONT_JO_ID AND FCJ.TERMINAL_ID=" & Session.Item("LoginTerminal") & " AND FCJ.TRIP_TYPE NOT IN ('I','O')  AND FCJD.CANCEL_STATUS IS NULL ORDER BY FCJ.CONT_JO_ID ASC"
            'cmd1 = "SELECT MTY_CONT_ID,(FCJD.CONT_NO || '-' || FCJ.CONT_JO_NO) CONT_NO FROM FLEET_CONT_JO_DTLS FCJD,FLEET_CONT_JO FCJ WHERE NVL(FCJD.GR_ID,0) =0 AND FCJ.CONT_JO_ID=FCJD.CONT_JO_ID AND FCJ.TERMINAL_ID=" & Session.Item("LoginTerminal") & " AND FCJD.CANCEL_STATUS IS NULL ORDER BY FCJ.CONT_JO_ID ASC"
            cmd2 = "SELECT VM.VENDOR_ID,VENDOR_NAME FROM VENDOR_MASTER VM,VENDOR_TYPE_DETAILS VD WHERE VD.VENDOR_ID=VM.VENDOR_ID AND VD.VENDER_TYPE_CODE='P' "
            cmd3 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER ORDER BY PORT_NAME"
            cmd4 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER ORDER BY PORT_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            ddchkContainer.DataSource = ds.Tables(0)
            ddchkContainer.DataTextField = "CONT_NO"
            ddchkContainer.DataValueField = "MTY_CONT_ID"
            ddchkContainer.DataBind()
            ds.Clear()
            ddchkContainer.Enabled = True
            ada = New OleDbDataAdapter(cmd2, con)

            Dim ds2 As New DataSet("VENDOR")
            ada.Fill(ds2)
            lstVendorPetrol.DataSource = ds2.Tables(0)
            lstVendorPetrol.DataTextField = "VENDOR_NAME"
            lstVendorPetrol.DataValueField = "VENDOR_ID"
            lstVendorPetrol.DataBind()
            lstVendorPetrol.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

        Catch ex As Exception
        End Try
    End Sub

    Sub ListControlDataBindVehicle()
        Dim strConnectionString, cmd1, cmd2 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM  FLEET_EQUIPMENT_MASTER WHERE EQUIPMENT_TYPE IN ('T20','T40') AND STATUS IN ('Y','B','O') AND COMPANY_ID= " & Session.Item("CompanyId") & "  ORDER BY EQUIPMENT_NO ASC"
            cmd2 = "SELECT DRIVER_NAME,DRIVER_ID FROM FLEET_DRIVER_MASTER WHERE ACTIVE_FLAGE='Y' ORDER BY DRIVER_NAME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "EQUIPMENT_NO"
            lstVehicleNo.DataValueField = "EQUIPMENT_ID"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            ada = New OleDbDataAdapter(cmd2, con)
            ada.Fill(ds)
            lstDriver.DataSource = ds.Tables(0)
            lstDriver.DataTextField = "DRIVER_NAME"
            lstDriver.DataValueField = "DRIVER_ID"
            lstDriver.DataBind()
            lstDriver.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Sub ListControlDataBindDriver()
        Dim strConnectionString, cmd2 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")

            cmd2 = "SELECT DRIVER_NAME,DRIVER_ID FROM FLEET_DRIVER_MASTER WHERE ACTIVE_FLAGE='Y'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim ds As New DataSet("CONTAINER")
            ada = New OleDbDataAdapter(cmd2, con)
            ada.Fill(ds)
            lstDriver.DataSource = ds.Tables(0)
            lstDriver.DataTextField = "DRIVER_NAME"
            lstDriver.DataValueField = "DRIVER_ID"
            lstDriver.DataBind()
            lstDriver.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
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
        'lstContNo.Enabled = False
        Response.Redirect("FleetVehicleSearch.aspx")
    End Sub
    Sub Searchdata(ByVal pGRId As Long)
        Dim pGr As New FleetGrMapping
        pGr.TerminalId = Session.Item("LoginTerminal")
        pGr.GrId = pGRId
        FleetGrMapping.ReturnFleetGrMapping(pGr)
        lstVehicleNo.SelectedItem.Text = pGr.VehicleNo

        Try
            hdnVehicleNo.Value = pGr.VehicleNo
        Catch ex As Exception

        End Try
        lstDriver.SelectedValue = pGr.DriverId
        hdnGrId.Value = pGr.GrId
        textCGr.Text = pGr.CGR
        textGrDate.Text = pGr.GrDate
        textGrNo.Text = pGr.GrNo

        Dim pfcj As New FleetContJoDtls
        pfcj.TerminalId = Session.Item("LoginTerminal")
        pfcj.MtyContId = pGr.MtyContId
        FleetContJoDtls.ReturnFleetContJoDtls(pfcj)

        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = pfcj.ContJoId

        FleetContJo.ReturnFleetContJo(pFleetContJo)
        Dim pLocation As New TerminalLocationMaster
        pLocation.TerminalId = Session.Item("LoginTerminal")
        pLocation.LocationId = pFleetContJo.FromLocation
        TerminalLocationMaster.ReturnTerminalLocationByLocationId(pLocation)
        textToLocation.Text = pLocation.LocationName

        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pFleetContJo.ToLocationId
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        textLocation.Text = pTerminal.TerminalName

        Dim pTerminalMaster As New TerminalMaster
        pTerminalMaster.TerminalId = pFleetContJo.MtyPickup
        TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
        textFromLocation.Text = pTerminalMaster.TerminalName

        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        textConsignee.Text = pConsignee.CustomerName
        lstVendorPetrol.SelectedValue = pGr.PetrolVendor
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.CustomerId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        textCustomer.Text = pConsignee.CustomerName
        textJoNo.Text = pFleetContJo.ContJoNo
        textJoDate.Text = pFleetContJo.CreatedOn

        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.LineId
        CustomerMaster.ReturnCustomerMaster(pConsignee)


        If pFleetContJo.JoType = "C" Then
            ' textContNo.Text = pfcj.ContNo
            textContSize.Text = pfcj.ContSize
            textType.Text = pfcj.ContType
        ElseIf pFleetContJo.JoType = "V" Then
            lstVehicleNo.SelectedItem.Text = pfcj.ContNo
            textType.Text = pfcj.ContType
        End If
        If pFleetContJo.TripType = "E" Then
            textTripType.Text = "Export"
        ElseIf pFleetContJo.TripType = "I" Then
            textTripType.Text = "Import"
        ElseIf pFleetContJo.TripType = "D" Then
            textTripType.Text = "Domestic"
        End If
        hdnTripType.Value = pFleetContJo.TripType
        textSlipNo.Text = pGr.SlipNo
        'textContNo.Visible = True
        'lstContNo.Visible = False
        If pFleetContJo.TransporterId = 0 Then
            textTransportar.Text = "Self"
        Else

            Dim pVendor As New VendorMaster
            pVendor.TerminalId = Session.Item("LoginTerminal")
            pVendor.VendorId = pFleetContJo.TransporterId
            VendorMaster.ReturnVendorMaster(pVendor)
            textTransportar.Text = pVendor.VendorName
        End If
        textAdvance.Text = pGr.Advance
        textOilAdvance.Text = pGr.OilAdvance

        textTotal.Text = Double.Parse(pGr.Advance) + Double.Parse(pGr.OilAdvance)
        Dim pDriverMaster As New FleetDriverMaster
        pDriverMaster.TerminalId = Session.Item("LoginTerminal")
        pDriverMaster.DriverId = lstDriver.SelectedValue
        FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
        textContactNo.Text = pDriverMaster.MobileNo
        textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        manageUserControls(True)
        ' btnEdit.Visible = True
        btnCancellation.Visible = True
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstDriver.SelectedItem.Text = "---Select---" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblDriver.Text)
            Functions.ControlFocus(lstDriver)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstVehicleNo.SelectedItem.Text = "---Select---" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVehiclNo.Text)
            Functions.ControlFocus(lstVehicleNo)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If textGrDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Gr Date.")
            Functions.ControlFocus(textGrDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstDriver.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblDriver.Text)
            Functions.ControlFocus(lstDriver)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Dim pequp As New FleetEquipmentMaster
        pequp.TerminalId = 4
        pequp.EquipmentId = lstVehicleNo.SelectedValue
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pequp)
        If pequp.Status = "N" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Vehicle Already Mapped for another GR")
            Functions.ControlFocus(textTotal)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        Dim COntID As List(Of [String]) = New List(Of String)()

        Dim COntNo As List(Of [String]) = New List(Of String)()
        For Each item As System.Web.UI.WebControls.ListItem In ddchkContainer.Items

            If item.Selected Then
                Dim p As New FleetContJoDtls
                p.TerminalId = Session.Item("LoginTerminal")
                p.MtyContId = item.Value
                FleetContJoDtls.ReturnFleetContJoDtls(p)
                Dim GR As New FleetGrMapping
                GR.TerminalId = 4
                GR.ContNo = item.Text
                FleetGrMapping.ReturnFleetGrPrint(GR)
                If GR.CloseDate = "" And p.GrId > "0" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & item.Text & "")
                    Functions.ControlFocus(textTotal)
                    rtnBool = False
                    Return rtnBool
                    Exit Function

                End If
            End If
        Next
        Return rtnBool
    End Function
    Protected Sub btnsaveJo_Click(sender As Object, e As EventArgs) Handles btnsavejo.Click
        hdnStatus.Value = "Y"
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim strConnectionString, cmd, Cmd2, CMD6, CMD7 As String
        Dim con As OleDbConnection
        Dim pFleetGrMapping As FleetGrMapping = ReturnObject()
        If ViewState("err") = 1 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & ViewState("item") & "")
            Functions.ControlFocus(textSlipNo)

            Return
        End If
        If hdnGrId.Value > 0 Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                CMD7 = " UPDATE FLEET_EQUIPMENT_MASTER SET STATUS= 'Y'  WHERE  EQUIPMENT_NO= '" & hdnVehicleNo.Value & "'"

                CMD6 = " UPDATE FLEET_EQUIPMENT_MASTER Set STATUS= " & "'" & "N" & "'" & "  WHERE  EQUIPMENT_ID=  " & lstVehicleNo.SelectedValue
                Cmd2 = " UPDATE FLEET_GR_MAPPING SET VEHICLE_NO= '" & lstVehicleNo.SelectedItem.Text & "',DRIVER_ID=" & lstDriver.SelectedValue & ",UPDATED_ON=SYSDATE,UPDATED_BY='" & Session.Item("LoginUser") & "' WHERE  GR_ID=" & hdnGrId.Value
                cmd = " UPDATE FLEET_VEHICLE_STATUS SET VEHICLE_NO= '" & lstVehicleNo.SelectedItem.Text & "',VEHICLE_ID=" & lstVehicleNo.SelectedValue & " WHERE  GR_ID=" & hdnGrId.Value
                ' Cmd1 = " UPDATE FLEET_CONT_JO SET  GR_ID= " & pFleetGrMapping.GrId & "WHERE CONT_JO_ID=" & 'lstContNo.SelectedValue
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd8 As New OleDbCommand(CMD6, con)
                cmd8.ExecuteNonQuery()

                Dim cmd9 As New OleDbCommand(CMD7, con)
                cmd9.ExecuteNonQuery()

                Dim cmd5 As New OleDbCommand(cmd, con)
                cmd5.ExecuteNonQuery()

                Dim cmd4 As New OleDbCommand(Cmd2, con)
                cmd4.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        Else
            FleetGrMapping.InsertUpdateFleetGrMapping(pFleetGrMapping)
        End If
        'FleetGrMapping.InsertUpdateFleetGrMapping(pFleetGrMapping)
        If pFleetGrMapping.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetGrMapping.Errormsg)
            'Functions.ControlFocus(lstCHA)
            Return
        End If

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd = " UPDATE FLEET_EQUIPMENT_MASTER SET STATUS= " & "'" & "N" & "'" & "  WHERE  EQUIPMENT_ID=  " & lstVehicleNo.SelectedValue
            Cmd2 = " UPDATE FLEET_GR_MAPPING SET REF_GR_ID= (SELECT MIN(GR_ID) FROM FLEET_GR_MAPPING GP WHERE VEHICLE_NO= '" & lstVehicleNo.SelectedItem.Text & "'  AND CLOSE_STATUS IS NULL ) WHERE  GR_NO=" & pFleetGrMapping.GrNo
            ' Cmd1 = " UPDATE FLEET_CONT_JO SET  GR_ID= " & pFleetGrMapping.GrId & "WHERE CONT_JO_ID=" & 'lstContNo.SelectedValue
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd3 As New OleDbCommand(cmd, con)
            cmd3.ExecuteNonQuery()

            ' Dim cmd4 As New OleDbCommand(Cmd1, con)
            ' cmd4.ExecuteNonQuery()
            If hdnCountGr.Value = 2 Then
                Dim cmd5 As New OleDbCommand(Cmd2, con)
                cmd5.ExecuteNonQuery()
            End If

        Catch ex As Exception
        End Try

        hdnGrId.Value = pFleetGrMapping.GrId
        textGrNo.Text = pFleetGrMapping.GrNo
        Try
            textTotal.Text = Convert.ToInt32(textAdvance.Text) + Convert.ToInt32(textOilAdvance.Text)
        Catch ex As Exception

        End Try

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
        btnPrint.Visible = True
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
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Private Function ReturnObject() As FleetGrMapping

        Dim pGr As New FleetGrMapping

        Dim COntID As List(Of [String]) = New List(Of String)()

        Dim COntNo As List(Of [String]) = New List(Of String)()
        pGr.FleetGRList = New ArrayList


        For Each item As System.Web.UI.WebControls.ListItem In ddchkContainer.Items

            If item.Selected Then

                Dim pGrMapping As New FleetGrMapping
                COntID.Add(item.Value)
                COntNo.Add(item.Text)
                pGrMapping.TerminalId = Session.Item("LoginTerminal")
                pGrMapping.CompanyId = Session.Item("CompanyId")
                pGrMapping.MtyContId = item.Value
                pGrMapping.ContNo = item.Text
                pGrMapping.ContSize = textContSize.Text
                pGrMapping.ContType = textType.Text
                pGrMapping.CustomerId = hdnCustomerId.Value
                pGrMapping.Advance = textAdvance.Text
                pGrMapping.VehicleNo = lstVehicleNo.SelectedItem.Text
                pGrMapping.TransporterId = hdnTransporterId.Value


                Try
                    pGrMapping.GrDate = textGrDate.Text

                Catch ex As Exception

                End Try

                Try
                    pGrMapping.CGR = textCGr.Text
                Catch ex As Exception
                End Try
                Try
                    pGrMapping.OilAdvance = textOilAdvance.Text
                Catch ex As Exception
                End Try

                Try
                    pGrMapping.DriverId = lstDriver.SelectedValue
                Catch ex As Exception
                End Try
                pGrMapping.FactoryLocation = textLocation.Text
                pGrMapping.FromLocation = textFromLocation.Text
                pGrMapping.ToLocation = textToLocation.Text
                pGrMapping.CreatedBy = Session.Item("LoginUser")
                pGrMapping.TripType = hdnTripType.Value
                Try
                    pGrMapping.GrId = hdnGrId.Value
                Catch ex As Exception

                End Try
                Try
                    pGrMapping.OtherAmt = textOthers.Text
                Catch ex As Exception

                End Try
                pGrMapping.PetrolVendor = lstVendorPetrol.SelectedValue
                pGrMapping.OtherReason = lstAdvance.SelectedValue
                pGrMapping.CHAId = hdnJoId.Value
                pGrMapping.SlipNo = textSlipNo.Text
                pGrMapping.GrRemark = textRemarks.Text
                pGr.FleetGRList.Add(pGrMapping)
            End If
        Next
        Return pGr
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        ListControlDataBind()
        hdnCountGr.Value = 0
        btnPrint.Visible = False
    End Sub
    Protected Sub lstVehicleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVehicleNo.SelectedIndexChanged
        Try
            ListControlDataBindDriver()
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.VehicleId = lstVehicleNo.SelectedValue
            pDriverMaster.VehicleNo = lstVehicleNo.SelectedItem.Text
            FleetDriverMaster.ReturnFleetDriverMasterByVehicle(pDriverMaster)
            lstDriver.SelectedValue = pDriverMaster.DriverId
            textContactNo.Text = pDriverMaster.MobileNo
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
            Dim pFE As New FleetEquipmentMaster
            pFE.TerminalId = Session.Item("LoginTerminal")
            pFE.EquipmentId = lstVehicleNo.SelectedValue
            FleetEquipmentMaster.ReturnFleetEquipmentMaster(pFE)
            Dim pFleetContJo As New FleetContJo
            pFleetContJo.TerminalId = Session.Item("LoginTerminal")
            pFleetContJo.ContJoId = hdnJoId.Value
            FleetContJo.ReturnFleetContJo(pFleetContJo)
            Dim pLocation As New LocationMaster
            pLocation.TerminalId = Session.Item("LoginTerminal")
            pLocation.LocationId = pFleetContJo.FromLocation
            pLocation.HandoverLocation = pFleetContJo.ToLocationId
            pLocation.CustomerId = pFleetContJo.BillTo
            pLocation.VehicleType = pFE.EquipmentType
            LocationMaster.ReturnLocationMasterByHandover(pLocation)
            Dim pVendor As New VendorMaster
            pVendor.TerminalId = Session.Item("LoginTerminal")
            pVendor.VendorId = lstVendorPetrol.SelectedValue
            VendorMaster.ReturnVendorMaster(pVendor)
            If HdnContSize.Value = 20 Then
                HdnOil.Value = pLocation.Oil20
                textOilAdvance.Text = (Convert.ToDouble(pLocation.Oil20) * pVendor.Rate)
                textAdvance.Text = Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.AdvanceRs) + pLocation.Toll
                textTotal.Text = (Convert.ToDouble(pLocation.Oil20) * pVendor.Rate) + Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.AdvanceRs) + pLocation.Toll
            Else
                textTotal.Text = (Convert.ToDouble(pLocation.Oil40) * pVendor.Rate) + Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.OilAdvance) + pLocation.Toll
                textOilAdvance.Text = Convert.ToDouble(pLocation.Oil40) * pVendor.Rate
                textAdvance.Text = Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.OilAdvance) + pLocation.Toll
                HdnOil.Value = pLocation.Oil40
            End If
            If hdnCountGr.Value = 2 Then
                textOilAdvance.Text = Convert.ToDouble(pLocation.Double20Oil) * Convert.ToDouble(pVendor.Rate)
                textAdvance.Text = Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.DoubleTwenty) + pLocation.Toll
                hdnAdvance.Value = (Convert.ToDouble(pLocation.Double20Oil) * Convert.ToDouble(pVendor.Rate)) + Convert.ToDouble(pLocation.ALAdvance) + Convert.ToDouble(pLocation.DoubleTwenty) + pLocation.Toll
                textTotal.Text = hdnAdvance.Value
                HdnOil.Value = pLocation.Double20Oil
            ElseIf hdnCountGr.Value > 2 Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Maximum Two Container is Allowed.")
                Return
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub lstDriver_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDriver.SelectedIndexChanged
        Try
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.DriverId = lstDriver.SelectedValue
            FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
            textContactNo.Text = pDriverMaster.MobileNo
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lstVendorPetrol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendorPetrol.SelectedIndexChanged
        Try
            Dim pVendorMaster As New VendorMaster
            pVendorMaster.TerminalId = Session.Item("LoginTerminal")
            pVendorMaster.VendorId = lstVendorPetrol.SelectedValue
            VendorMaster.ReturnVendorMaster(pVendorMaster)
            ' textOilAdvance.Text = ""
            textOilAdvance.Text = (HdnOil.Value * Convert.ToDouble(pVendorMaster.Rate))
            textTotal.Text = Convert.ToDouble(textOilAdvance.Text) + Convert.ToDouble(textAdvance.Text)
            'textContactNo.Text = pDriverMaster.MobileNo

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnEdit.Visible = True
        Dim pfvS As New FleetContJoDtls
        pfvS.TerminalId = Session.Item("LoginTerminal")
        pfvS.GrId = hdnGrId.Value
        FleetContJoDtls.ReturnFleetContJoDtlsByGR(pfvS)
        If pfvS.IcdInDate = "" Then
            btnEdit.Visible = True
            Manage()
            ButtonControlSetup(False)
            btnEdit.Visible = False
            btnPrint.Visible = False
            Functions.ControlFocus(lstVehicleNo)
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Already Gate In so edit not allowed")
            Return
            Exit Sub
        End If
        'End If
    End Sub
    Sub Manage()
        lstVehicleNo.Enabled = True
        lstDriver.Enabled = True
        textOilAdvance.Enabled = True
        textAdvance.Enabled = True
        textOthers.Enabled = True
        lstAdvance.Enabled = True
    End Sub
    Protected Sub btnCancellation_Click(sender As Object, e As EventArgs) Handles btnCancellation.Click
        Dim pfvS As New FleetVehicleStatus
        pfvS.TerminalId = Session.Item("LoginTerminal")
        pfvS.GrNo = textGrNo.Text
        FleetVehicleStatus.ReturnFleetVehicleStatus(pfvS)
        If pfvS.IcdOut <> "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Vehicle gate out,edit not allowed")
            Return
            Exit Sub
        Else
            chkGrChecked.Enabled = True
            If chkGrChecked.Checked = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Gr Cancel Check Box")
                Functions.ControlFocus(chkGrChecked)
                Return
            End If

            Dim strConnectionString, cmd, cmd1, cmd2 As String
            Dim con As OleDbConnection
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = " UPDATE FLEET_GR_MAPPING SET CANCEL_STATUS='Y',CANCEL_ON=SYSDATE,CANCEL_BY='" & Session.Item("LoginUser") & "' WHERE GR_NO=  " & textGrNo.Text
                cmd1 = " DELETE FROM FLEET_VEHICLE_STATUS  WHERE  GR_NO=  " & textGrNo.Text
                cmd2 = "UPDATE FLEET_CONT_JO_DTLS  SET  GR_ID = 0 WHERE CONT_JO_ID=" & lngContJoId

                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd3 As New OleDbCommand(cmd, con)
                cmd3.ExecuteNonQuery()
                Dim cmd4 As New OleDbCommand(cmd1, con)
                cmd4.ExecuteNonQuery()
                Dim cmd5 As New OleDbCommand(cmd2, con)
                cmd5.ExecuteNonQuery()

            Catch ex As Exception
            End Try
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Cancelled Successfully.")
            ButtonControlSetup(True)
            btnEdit.Visible = False
            btnPrint.Visible = False
        End If
        btnAdd.Visible = True
        btnCancel.Visible = False
    End Sub

    Protected Sub ddchkContainer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        hdnCount.Value = hdnCount.Value + 1
        If hdnCount.Value = 1 Then
            'hdnCount.Value = hdnCount.Value + 1
            For Each item As System.Web.UI.WebControls.ListItem In ddchkContainer.Items
                If item.Selected = True Then
                    hdnCountGr.Value = hdnCountGr.Value + 1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
                    textOilAdvance.Text = 0


                    Dim p As New FleetContJoDtls
                    p.TerminalId = Session.Item("LoginTerminal")
                    p.MtyContId = item.Value
                    FleetContJoDtls.ReturnFleetContJoDtls(p)
                    textContSize.Text = p.ContSize
                    textType.Text = p.ContType
                    textWeight.Text = p.Weight


                    Dim pFleetContJo As New FleetContJo
                    pFleetContJo.TerminalId = Session.Item("LoginTerminal")
                    pFleetContJo.ContJoId = p.ContJoId
                    FleetContJo.ReturnFleetContJo(pFleetContJo)
                    textJoNo.Text = pFleetContJo.ContJoNo
                    hdnJoId.Value = p.ContJoId
                    Dim pConsignee As New CustomerMaster
                    pConsignee.TerminalId = Session.Item("LoginTerminal")
                    pConsignee.CustomerId = pFleetContJo.ConsigneeId
                    CustomerMaster.ReturnCustomerMaster(pConsignee)
                    textConsignee.Text = pConsignee.CustomerName

                    pConsignee.TerminalId = Session.Item("LoginTerminal")
                    pConsignee.CustomerId = pFleetContJo.CustomerId
                    CustomerMaster.ReturnCustomerMaster(pConsignee)
                    textCustomer.Text = pConsignee.CustomerName
                    hdnJoId.Value = pFleetContJo.ContJoId

                    pConsignee.TerminalId = Session.Item("LoginTerminal")
                    pConsignee.CustomerId = pFleetContJo.LineId
                    CustomerMaster.ReturnCustomerMaster(pConsignee)

                    hdnTransporterId.Value = pFleetContJo.TransporterId
                    hdnCustomerId.Value = pFleetContJo.CustomerId
                    hdnLocationId.Value = pFleetContJo.FromLocation
                    hdnTripType.Value = pFleetContJo.TripType
                    If pFleetContJo.TransporterId = 0 Then
                        textTransportar.Text = "Self"
                    Else

                        Dim pVendor As New VendorMaster
                        pVendor.TerminalId = Session.Item("LoginTerminal")
                        pVendor.VendorId = pFleetContJo.TransporterId
                        VendorMaster.ReturnVendorMaster(pVendor)
                        textTransportar.Text = pVendor.VendorName
                    End If
                    If pFleetContJo.TripType = "E" Then
                        textTripType.Text = "Export"
                    ElseIf pFleetContJo.TripType = "I" Then
                        textTripType.Text = "Import"
                    ElseIf pFleetContJo.TripType = "D" Then
                        textTripType.Text = "Domestic"
                    End If

                    Dim pCompanyMaster As New CompanyMaster
                    CompanyMaster.ReturnCompanyMasterSearch(pCompanyMaster)
                    Dim PlocationMaster As New TerminalLocationMaster
                    PlocationMaster.TerminalId = Session.Item("LoginTerminal")
                    PlocationMaster.LocationId = pFleetContJo.FromLocation
                    TerminalLocationMaster.ReturnTerminalLocationByLocationId(PlocationMaster)

                    Dim pLocation As New LocationMaster
                    pLocation.TerminalId = Session.Item("LoginTerminal")
                    pLocation.LocationId = pFleetContJo.FromLocation
                    pLocation.HandoverLocation = pFleetContJo.ToLocationId
                    pLocation.CustomerId = pFleetContJo.BillTo
                    LocationMaster.ReturnLocationMasterByHandover(pLocation)
                    textToLocation.Text = PlocationMaster.LocationName
                    HdnContSize.Value = p.ContSize
                    Dim pTerminal As New TerminalMaster
                    pTerminal.TerminalId = pFleetContJo.ToLocationId
                    TerminalMaster.ReturnTerminalMaster(pTerminal)
                    textLocation.Text = pTerminal.TerminalName

                    Dim pTerminalMaster As New TerminalMaster
                    pTerminalMaster.TerminalId = pFleetContJo.MtyPickup
                    TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
                    textFromLocation.Text = pTerminalMaster.TerminalName

                    Manage()


                    If pFleetContJo.JoType = "V" Then
                        ListControlDataBindVehicle()
                        lstVehicleNo.SelectedValue = p.VehicleId

                        lstVehicleNo.Enabled = False
                        Dim pDriverMaster As New FleetDriverMaster
                        pDriverMaster.TerminalId = Session.Item("LoginTerminal")
                        pDriverMaster.VehicleNo = item.Text
                        FleetDriverMaster.ReturnFleetDriverMasterByVehicle(pDriverMaster)
                        If pDriverMaster.DriverId > 0 Then
                            lstDriver.SelectedValue = pDriverMaster.DriverId
                            textContactNo.Text = pDriverMaster.MobileNo
                            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
                        Else
                            ListControlDataBindDriver()
                            lstDriver.Enabled = True
                        End If
                    End If

                    textJoDate.Text = pFleetContJo.CreatedOn

                    ListControlDataBindVehicle()
                    lstVendorPetrol.Enabled = True
                    textSlipNo.Enabled = True
                    textRemarks.Enabled = True
                    chkGrChecked.Enabled = False
                    chkGrChecked.Checked = False
                    ButtonControlSetup(False)
                End If
            Next
        End If
        textCGr.Enabled = True
    End Sub

End Class
