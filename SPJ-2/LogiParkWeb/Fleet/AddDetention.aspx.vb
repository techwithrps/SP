Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_AddDetention
    Inherits System.Web.UI.Page
    Public Sub New()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            ButtonControlSetup(True)
            btnEdit.Visible = False
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        TextGrno.Enabled = True
        btnSearchGr.Visible = True
        btnSearchGr.Enabled = True
        btnEdit.Visible = False
        tvContainers.Nodes.Clear()
        ButtonControlSetup(True)
        Functions.ControlFocus(TextGrno)
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd3, cmd4, cmd5, cmd6, cmd7 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID=19 AND GATEWAY_PORT='Y' ORDER BY PORT_NAME"
            cmd4 = "SELECT DISTINCT PORT_ID,  (PORT_NAME||'-'||COUNTRY_NAME) PORT_NAME FROM PORT_MASTER PM, COUNTRY_MASTER CT WHERE PM.COUNTRY_ID=CT.COUNTRY_ID ORDER BY PORT_NAME"
            cmd5 = "SELECT DISTINCT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='L' AND ELOGISOL_FLAG='Y' ORDER BY CUSTOMER_NAME"
            cmd6 = "SELECT DISTINCT TERMINAL_ID,TERMINAL_NAME FROM TERMINAL_MASTER ORDER BY TERMINAL_NAME"
            cmd7 = "SELECT DISTINCT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='E' ORDER BY CUSTOMER_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ' ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada = New OleDbDataAdapter(cmd3, con)
            Dim ds3 As New DataSet("PORT_MASTER")
            ada.Fill(ds3)
            lstPol.DataSource = ds3.Tables(0)
            lstPol.DataTextField = "PORT_NAME"
            lstPol.DataValueField = "PORT_ID"
            lstPol.DataBind()
            lstPol.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds3.Clear()
            con.Close()
            ada = New OleDbDataAdapter(cmd4, con)
            Dim ds4 As New DataSet("PORT_MASTER")
            ada.Fill(ds4)
            LstFOD.DataSource = ds4.Tables(0)
            LstFOD.DataTextField = "PORT_NAME"
            LstFOD.DataValueField = "PORT_ID"
            LstFOD.DataBind()
            LstFOD.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds4.Clear()
            con.Close()
            ada = New OleDbDataAdapter(cmd5, con)
            Dim ds5 As New DataSet("CUSTOMER_MASTER")
            ada.Fill(ds5)
            lstline.DataSource = ds5.Tables(0)
            lstline.DataTextField = "CUSTOMER_NAME"
            lstline.DataValueField = "CUSTOMER_ID"
            lstline.DataBind()
            lstline.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds5.Clear()
            con.Close()
            ada = New OleDbDataAdapter(cmd6, con)
            Dim ds6 As New DataSet("PORT_MASTER")
            ada.Fill(ds6)
            lstcfs.DataSource = ds6.Tables(0)
            lstcfs.DataTextField = "TERMINAL_NAME"
            lstcfs.DataValueField = "TERMINAL_ID"
            lstcfs.DataBind()
            lstcfs.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds6.Clear()
            ada = New OleDbDataAdapter(cmd7, con)
            Dim ds7 As New DataSet("CUSTOMER_MASTER")
            ada.Fill(ds7)
            LstConsignor.DataSource = ds7.Tables(0)
            LstConsignor.DataTextField = "CUSTOMER_NAME"
            LstConsignor.DataValueField = "CUSTOMER_ID"
            LstConsignor.DataBind()
            LstConsignor.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds7.Clear()
            con.Close()

            Dim pIso As New IsoCode
            lstType.DataSource = IsoCode.ReturnIsoCodeListOfContType(pIso)
            lstType.DataValueField = "ContType"
            lstType.DataTextField = "ContType"
            lstType.DataBind()
            lstType.Items.Insert(0, New ListItem("--Select--", ""))

            'Dim ds8 As New DataSet("TERMINAL_LOCATION_MASTER")
            'ada.Fill(ds8)
            'lstFactorylocation.DataSource = ds8.Tables(0)
            'lstFactorylocation.DataTextField = "LOCATION_NAME"
            'lstFactorylocation.DataValueField = "LOCATION_ID"
            'lstFactorylocation.DataBind()
            'lstFactorylocation.Items.Insert(0, (New ListItem("---Select---", "0")))
            'ds8.Clear()
            'con.Close()
        Catch ex As Exception

        End Try

    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnExit.Visible = pVisible
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        ' btnEdit.Visible = pVisible
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

    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
        If ds2 Is Nothing Then
            Return
        End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("MenuId") = row(0).ToString
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Sub LoadTreeViewData(ByVal pFleetContJoDtls As FleetContJoDtls)
        tvContainers.Nodes.Clear()
        Try
            For Each obj As FleetContJoDtls In FleetContJoDtls.ReturnFleetContJoDtlslCont(pFleetContJoDtls)
                FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)

                ' ImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                Dim pFleetContJo As New FleetContJo
                pFleetContJo.ContJoId = obj.ContJoId
                FleetContJo.ReturnFleetContJo(pFleetContJo)

                Try
                    'lstline.SelectedValue = pFleetContJo.LineId
                    hdnShippingLine.Value = pFleetContJo.LineId
                Catch ex As Exception
                End Try
                hdnJobNo.Value = pFleetContJo.ContJoNo
                hdngrId.Value = pFleetContJoDtls.GrId
                'lstcfs.SelectedValue = pFleetContJo.ToLocationId



                Dim PGR1 As New FleetGrMapping
                PGR1.GrId = hdngrId.Value
                '  FleetGrMapping.ReturnFleetGrMappingVehicle(PGR1)
                FleetGrMapping.ReturnFleetGrMapping(PGR1)

                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.CustomerId = pFleetContJo.ConsigneeId
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                Dim pAllPartyAccount As New AllPartyAccount
                pAllPartyAccount.MtyContId = obj.MtyContId
                AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
                Functions.treeViewNodeSetup(tvContainers, "0", obj.MtyContId, obj.ContNo & " | Vehicle No-" & PGR1.VehicleNo & " | SB-" & pAllPartyAccount.SbNo & " | Handover-" & pAllPartyAccount.LineHandoverDate & " | GR-" & obj.SealNo & " | " & "Consignee-" & pCustomerMaster.CustomerName)
            Next
        Catch ex As Exception
        End Try


    End Sub
    Protected Sub tvContainers_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvContainers.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        fillControlWithData(tvContainers.SelectedNode)
        ' SaveViewState()
        ' manageUserControls(True)
        'Functions.ControlFocus(btnAdd)

    End Sub
    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.MtyContId = PCodeValue.Value




        ' LoadTreeViewData(pFleetContJoDtls)
        FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
        Try
            lstSize.SelectedValue = pFleetContJoDtls.ContSize
            lstType.SelectedValue = pFleetContJoDtls.ContType
        Catch ex As Exception
        End Try
        textLineSealNo.Text = pFleetContJoDtls.SealNo
        textCustomSeal.Text = pFleetContJoDtls.AgentSeal
        hdnMtyContId.Value = PCodeValue.Value
        Try
            hdncontJoId.Value = pFleetContJoDtls.ContJoId
        Catch ex As Exception

        End Try
        If pFleetContJoDtls.MtyContId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container not booked yet.")
            Return
        End If
        If pFleetContJoDtls.GrId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container Booked For Shipper Transportation.")
            Return
        End If
        hdnMtyContId.Value = pFleetContJoDtls.MtyContId

        Try
            hdncontJoId.Value = pFleetContJoDtls.ContJoId
        Catch ex As Exception
        End Try
        hdngrId.Value = pFleetContJoDtls.GrId
        Dim P As New FleetGrMapping
        P.GrId = pFleetContJoDtls.GrId
        FleetGrMapping.ReturnFleetGrMapping(P)
        If P.CHAId = 0 Then
            hdnHandoverCFS.Value = 0
        Else
            hdnHandoverCFS.Value = 1
        End If
	Try
            lstline.SelectedValue = hdnShippingLine.Value
        Catch ex As Exception
        End Try
	Try
            'lstcfs.SelectedValue = P.CHAId '==COMMENTED BY ARJUN NEGI 
        Catch ex As Exception

        End Try
        'lstcfs.SelectedValue = P.CHAId
        'lstline.SelectedValue = P.LineId
        'hdnShippingLine.Value = P.LineId
        lstDocType.SelectedValue = pFleetContJoDtls.TripType
        Dim PGR As New FleetVehicleStatus
        PGR.TerminalId = 1
        PGR.GrNo = P.GrId
        FleetVehicleStatus.ReturnFleetVehicleGRId(PGR)
        Dim str As String
        Dim strArr() As String
        Dim count As Integer
        str = P.ContNo
        strArr = str.Split("-")
        For count = 0 To strArr.Length - 1
            If count = 0 Then
            Else
                textjoNo.Text = (strArr(count))
            End If
        Next
        TextIcdIn.Text = pFleetContJoDtls.IcdInDate
        textOutDaTe.Text = pFleetContJoDtls.IcdOutDate
        textVehicleGateOut.Text = pFleetContJoDtls.VehicleGateOutDate
        TextFInDate.Text = pFleetContJoDtls.FactoryInDate
        TextFOutDate.Text = pFleetContJoDtls.FactoryOutDate
        textAllotmentDate.Text = pFleetContJoDtls.AllotMentDate
        textBufferDate.Text = pFleetContJoDtls.BufferDate
        textBufferOutDate.Text = pFleetContJoDtls.BufferOutDate
        textEmptyGateInDate.Text = pFleetContJoDtls.EmptyGateInDate
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = pFleetContJoDtls.MtyContId
        pAllPartyAccount = AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
        If pAllPartyAccount.LineHandoverDate = "" Then
            hdnLineHandoverDate.Value = 0
        Else
            hdnLineHandoverDate.Value = 1
        End If

        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        Try
            lstcfs.SelectedValue = pAllPartyAccount.CFSId
        Catch ex As Exception

        End Try
        'textCustom.Text = pAllPartyAccount.CustomsHandoverDate
        Try
            LstConsignor.SelectedValue = pAllPartyAccount.NoOfDays
            hdnConsignor.Value = pAllPartyAccount.NoOfDays
        Catch ex As Exception
            LstConsignor.SelectedValue = 0
        End Try

        Try
            LstRemark.SelectedValue = pAllPartyAccount.HoldRemarkId
        Catch ex As Exception
            LstRemark.SelectedValue = 0
        End Try
        Dim pContJO As New FleetContJo
        pContJO.ContJoNo = textjoNo.Text
        FleetContJo.ReturnFleetContJo(pContJO)
        Dim aCustomer As New CustomerMaster
        aCustomer.CustomerId = pContJO.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(aCustomer)
        Try
            textConsigneeGR.Text = aCustomer.CustomerName
        Catch ex As Exception
        End Try

        Dim pExtLocationMaster As New TerminalLocationMaster
        pExtLocationMaster.TerminalId = pContJO.TerminalId
        lstFactorylocation.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
        lstFactorylocation.DataTextField = "LocationName"
        lstFactorylocation.DataValueField = "LocationId"
        lstFactorylocation.DataBind()
        lstFactorylocation.Items.Insert(0, (New ListItem("---Select---", 0)))


        Dim pTerminalLocationMaster As New TerminalLocationMaster
        pTerminalLocationMaster.TerminalId = pContJO.TerminalId
        pTerminalLocationMaster.LocationId = pContJO.FromLocation
        TerminalLocationMaster.ReturnTerminalLocationByLocationId(pTerminalLocationMaster)
        lstFactorylocation.Text = pTerminalLocationMaster.LocationId
        ' pTerminalLocationMaster.LocationName = lstFactorylocation.SelectedValue
        ' lstFactorylocation.SelectedItem.Text = pTerminalLocationMaster.LocationName



        Try
            lstPol.SelectedValue = pAllPartyAccount.POLId
        Catch ex As Exception
            lstPol.SelectedValue = 0
        End Try
        Try
            LstFOD.SelectedValue = pAllPartyAccount.PODId
            hdnFPOD.Value = pAllPartyAccount.PODId
        Catch ex As Exception
            LstFOD.SelectedValue = 1
        End Try

        Try
            lstConsignmentType.SelectedItem.Text = pAllPartyAccount.ConsignmentType
        Catch ex As Exception
        End Try
        lststatus.SelectedValue = pAllPartyAccount.ShipmentStatus

        TextBlNO.Text = pAllPartyAccount.BlNo
        If pAllPartyAccount.PartyInvNo = "" Then
            hdnPartyInvoiceNo.Value = 0
        Else
            hdnPartyInvoiceNo.Value = 1
        End If
        TextPInvNo.Text = pAllPartyAccount.PartyInvNo
        TextPDate.Text = pAllPartyAccount.PartyInvDate
        TextBookingNO.Text = pAllPartyAccount.BookingNo
        TextBookingDate.Text = pAllPartyAccount.BookingDate
        textSob.Text = pAllPartyAccount.Sailed
        TextConsigneeName.Text = pAllPartyAccount.ConsingeeName
        textShippingBill.Text = pAllPartyAccount.SbNo
        textShippingDate.Text = pAllPartyAccount.SbDate
        'LstBillTo.SelectedValue = P.ConsignmentType
        Try
            lstBlMethod.SelectedValue = pAllPartyAccount.BLMethodId
        Catch ex As Exception
            lstBlMethod.SelectedValue = 0
        End Try
        Try
            lstBLStatus.SelectedValue = pAllPartyAccount.BLStatusId
        Catch ex As Exception
            lstBLStatus.SelectedValue = 0
        End Try
        Dim user As Long = 0
        If Session.Item("LoginUser") = "Suresh Rajput" Or Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "Deepak Kandpal" Or Session.Item("LoginUser") = "Pavnesh" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Lokesh Kumar" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Pathak" Or Session.Item("LoginUser") = "superuser" Then
            user = 1
        End If
        If user <> 1 Then
            If hdnLineHandoverDate.Value = 1 Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container Already Handover, Edit Not Allowed.")
                Return
            End If
        End If
        If Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "Nitin Saini" Then
            lstPol.Enabled = True
        End If

        If Session.Item("LoginUser") = "Deepak Kandpal" Or Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "ADMIN" Then
            TextIcdIn.Enabled = True
            textOutDaTe.Enabled = True
            textVehicleGateOut.Enabled = True
            TextFInDate.Enabled = True
            TextFOutDate.Enabled = True
            textAllotmentDate.Enabled = True
            textBufferDate.Enabled = True
            textBufferOutDate.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If

        If Session.Item("LoginUser") = "Harendra Singh" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Lokesh Kumar" Or Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Pathak" Then
            ' TextGrno.Enabled = True
            LstConsignor.Enabled = True
            TextConsigneeName.Enabled = True
            textSob.Enabled = True
            TextPInvNo.Enabled = True
            TextPDate.Enabled = True
            textShippingBill.Enabled = True
            textShippingDate.Enabled = True

        End If

        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Then
            TextGrno.Enabled = True
            lstSize.Enabled = True
            lstType.Enabled = True
            lstFreeType.Enabled = True
        Else
            TextGrno.Enabled = False
        End If

        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Then
            TextGrno.Enabled = True
            lstFreeType.Enabled = True
        Else
            TextGrno.Enabled = False
        End If
        TextIcdIn.Enabled = True
        textOutDaTe.Enabled = True
        'textVehicleGateOut.Enabled = True
        TextFInDate.Enabled = True
        TextFOutDate.Enabled = True
        textAllotmentDate.Enabled = True
        textBufferDate.Enabled = True
        TextHandOverDate.Enabled = True
        'textCustom.Enabled = True
        lstcfs.Enabled = True
        lstline.Enabled = True
        lstDocType.Enabled = True
        textCustomSeal.Enabled = True
        textLineSealNo.Enabled = True
        textBufferOutDate.Enabled = True
        'TextBookingDate.Enabled = True
        lstBlMethod.Enabled = True
        lstBLStatus.Enabled = True
        LstFOD.Enabled = True
        'lstPol.Enabled = True
        TextBlNO.Enabled = True
        'TextBookingNO.Enabled = True
        LstRemark.Enabled = True
        textEmptyGateInDate.Enabled = True
        'If Session.Item("CompanyId") = 1 Then
        '    TextIcdIn.Enabled = True
        '    textOutDaTe.Enabled = True
        '    TextFInDate.Enabled = True
        '    TextFOutDate.Enabled = True
        '    textAllotmentDate.Enabled = True
        '    textBufferDate.Enabled = True
        '    btnSave.Visible = True
        '    btnSave.Enabled = True
        'End If

        If Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "Harendra Singh" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Then
            TextIcdIn.Enabled = True
            textOutDaTe.Enabled = True
            TextFInDate.Enabled = True
            TextFOutDate.Enabled = True
            textAllotmentDate.Enabled = True
            textBufferDate.Enabled = True
            TextBookingNO.Enabled = True
            TextBookingDate.Enabled = True
            lstFactorylocation.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If
        If Session.Item("LoginUser") = "Pavnesh" Then
            lstFactorylocation.Enabled = True
            TextFInDate.Enabled = True
            TextFOutDate.Enabled = True
            'LstConsignor.Enabled = True
            'TextFInDate.Enabled = True
            'TextFOutDate.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If
        'btnSave.Visible = False
        'btnSave.Enabled = False
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchGr.Click
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.ContNo = TextGrno.Text
        LoadTreeViewData(pFleetContJoDtls)
    End Sub

    Function GetDateTime(strDate As String) As DateTime
        Dim strday, strtime, arrdate, Day, Month, Year, arrtime, Hour, Minute, FinalDate

        Dim parry = strDate.Split(" ")
        If parry.Length = 2 Then
            strday = parry(0)
            strtime = parry(1)

            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            arrtime = strtime.Split(":")
            Hour = arrtime(0)
            Minute = arrtime(1)
        ElseIf parry.Length = 1 Then
            strday = parry(0)
            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            Hour = 0
            Minute = 0
        End If
        FinalDate = New DateTime(Year, Month, Day, Hour, Minute, 0)
        Return FinalDate
    End Function
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim isContNo As Integer = 0
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = hdnMtyContId.Value
        pAllPartyAccount = AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.LineItemId = hdncontJoId.Value
        pImpInvoice.CompanyId = Session.Item("CompanyId")
        pImpInvoice = ImpInvoice.ReturnImpInvoiceContJoId(pImpInvoice)

        If lstSize.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Container Size " & lstSize.Text)
            Functions.ControlFocus(lstSize)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstType.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Container Type " & lstType.Text)
            Functions.ControlFocus(lstType)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "superuser" AndAlso Session.Item("LoginUser") <> "Pavnesh" Then
            If Session.Item("CompanyId") = 2 Or Session.Item("CompanyId") = 1 Then
                If pImpInvoice.EinvoiceStatus = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Einvoice  Alreday Entered Against Selected Container No , So edit not allow ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
            End If
        Else
            If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "superuser" AndAlso Session.Item("LoginUser") <> "Pavnesh" Then
                If pImpInvoice.PrintStatus = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice  Alreday Approved Against Selected Container No , So edit not allow ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
            End If
        End If
        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
            If String.IsNullOrEmpty(textOutDaTe.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD Out Date is blank ")
                rtnBool = False
                Functions.ControlFocus(textOutDaTe)
                Return rtnBool
                Exit Function
            End If
        End If

        If textAllotmentDate.Text <> Nothing AndAlso textAllotmentDate.Text <> "" Then
            If GetDateTime(textAllotmentDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textAllotmentDate)
                rtnBool = False
                Functions.ControlFocus(textAllotmentDate)
                Return rtnBool
                Exit Function
            End If
        End If
        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
            If Not String.IsNullOrEmpty(textOutDaTe.Text) Then
                If GetDateTime(textOutDaTe.Text.Trim()) >= DateTime.Now Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                    Functions.ControlFocus(textOutDaTe)
                    rtnBool = False
                    Functions.ControlFocus(textOutDaTe)
                    Return rtnBool
                    Exit Function
                End If
            End If
        End If
        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
            If Not String.IsNullOrEmpty(textOutDaTe.Text) Then
                If GetDateTime(textOutDaTe.Text.Trim()) < GetDateTime(textAllotmentDate.Text.Trim()) Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD Out Date is greater than to the Allotment Date.")
                    Functions.ControlFocus(textOutDaTe)
                    rtnBool = False
                    Functions.ControlFocus(textOutDaTe)
                    Return rtnBool
                    Exit Function
                End If
            End If
        End If
        '''''''''
        'This check is added by Amit K Singh on 15/07/2021
        '''''''''
        If Not String.IsNullOrEmpty(TextFInDate.Text) Then
            If GetDateTime(TextFInDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextFInDate)
                rtnBool = False
                Functions.ControlFocus(TextFInDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(textVehicleGateOut.Text) Then
            If GetDateTime(textVehicleGateOut.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textVehicleGateOut)
                rtnBool = False
                Functions.ControlFocus(textVehicleGateOut)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextFInDate.Text) Then
            If GetDateTime(TextFInDate.Text.Trim()) < GetDateTime(textOutDaTe.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory In Date is greater than ICD Out Date.")
                Functions.ControlFocus(TextFInDate)
                rtnBool = False
                Functions.ControlFocus(TextFInDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextFOutDate.Text) Then
            If GetDateTime(TextFOutDate.Text) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextFOutDate)
                rtnBool = False
                Functions.ControlFocus(TextFOutDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextFOutDate.Text) Then
            If GetDateTime(TextFOutDate.Text.Trim()) < GetDateTime(TextFInDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Factory Out Date is greater than Factory In Date.")
                Functions.ControlFocus(TextFOutDate)
                rtnBool = False
                Functions.ControlFocus(TextFOutDate)
                Return rtnBool
                Exit Function
            End If
        End If
        If textBufferDate.Text <> Nothing AndAlso textBufferDate.Text <> "" Then
            If GetDateTime(textBufferDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textBufferDate)
                rtnBool = False
                Functions.ControlFocus(textBufferDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If textBufferDate.Text <> Nothing AndAlso textBufferDate.Text <> "" Then
            If GetDateTime(textBufferDate.Text.Trim()) < GetDateTime(TextFOutDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer In Date should be greater than Factory Out Date.")
                Functions.ControlFocus(textBufferDate)
                rtnBool = False
                Functions.ControlFocus(textBufferDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If textBufferOutDate.Text <> Nothing AndAlso textBufferOutDate.Text <> "" Then
            If GetDateTime(textBufferOutDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textBufferOutDate)
                rtnBool = False
                Functions.ControlFocus(textBufferOutDate)
                Return rtnBool
                Exit Function
            End If
        End If

        ' If Not String.IsNullOrEmpty(textBufferOutDate.Text) Then
        If Not String.IsNullOrEmpty(textBufferOutDate.Text) AndAlso textBufferOutDate.Text <> "" AndAlso textBufferOutDate.Text <> Nothing Then
            If GetDateTime(textBufferOutDate.Text.Trim()) < GetDateTime(textBufferDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Buffer Out Date is less than Buffer In Date.")
                Functions.ControlFocus(textBufferOutDate)
                rtnBool = False
                Functions.ControlFocus(textBufferOutDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextIcdIn.Text) Then
            If GetDateTime(TextIcdIn.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextIcdIn)
                rtnBool = False
                Functions.ControlFocus(TextIcdIn)
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextIcdIn.Text) AndAlso textBufferOutDate.Text <> "" AndAlso textBufferOutDate.Text <> Nothing Then
            If GetDateTime(TextIcdIn.Text.Trim()) < GetDateTime(textBufferOutDate.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date not be less than Buffer Out Date.")
                Functions.ControlFocus(TextIcdIn)
                rtnBool = False
                Functions.ControlFocus(TextIcdIn)
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextHandOverDate.Text) Then
            If GetDateTime(TextHandOverDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextHandOverDate)
                rtnBool = False
                Functions.ControlFocus(TextHandOverDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextHandOverDate.Text) Then
            If GetDateTime(TextHandOverDate.Text.Trim()) < GetDateTime(TextIcdIn.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Line Handover Date not be less than ICD Gate In Date.")
                Functions.ControlFocus(TextHandOverDate)
                rtnBool = False
                Functions.ControlFocus(TextHandOverDate)
                Return rtnBool
                Exit Function
            End If
        End If
        Try
            If Not String.IsNullOrEmpty(textSob.Text) Then
                If GetDateTime(textSob.Text.Trim()) < GetDateTime(TextHandOverDate.Text.Trim()) Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the SOB Date not be less than Handover Date.")
                    Functions.ControlFocus(textSob)
                    rtnBool = False
                    Functions.ControlFocus(textSob)
                    Return rtnBool
                    Exit Function
                End If
            End If
        Catch ex As Exception
        End Try


        'If Not String.IsNullOrEmpty(textOutDaTe.Text) Then
        '    If GetDateTime(textOutDaTe.Text.Trim()) < GetDateTime(TextIcdIn.Text.Trim()) Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date not be less than ICD Out Date.")
        '        Functions.ControlFocus(textOutDaTe)
        '        rtnBool = False
        '        Functions.ControlFocus(textOutDaTe)
        '        Return rtnBool
        '        Exit Function
        '    End If


        If Not String.IsNullOrEmpty(TextPDate.Text) Then
            If GetDateTime(TextPDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextPDate)
                rtnBool = False
                Functions.ControlFocus(TextPDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(textShippingDate.Text) Then
            If GetDateTime(textShippingDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textShippingDate)
                rtnBool = False
                Functions.ControlFocus(textShippingDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If Not String.IsNullOrEmpty(TextBookingDate.Text) Then
            If GetDateTime(TextBookingDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextBookingDate)
                rtnBool = False
                Functions.ControlFocus(TextBookingDate)
                Return rtnBool
                Exit Function
            End If
        End If

        If textEmptyGateInDate.Text <> Nothing AndAlso textEmptyGateInDate.Text <> "" Then
            '  If Not String.IsNullOrEmpty(textEmptyGateInDate.Text) AndAlso textEmptyGateInDate.Text <> Nothing Then
            If GetDateTime(textEmptyGateInDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textEmptyGateInDate)
                rtnBool = False
                Functions.ControlFocus(textEmptyGateInDate)
                Return rtnBool
                Exit Function
            End If
        End If


        If lstcfs.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblCFS.Text)
            Functions.ControlFocus(lstcfs)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstline.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblLine.Text)
            Functions.ControlFocus(lstline)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If Not String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
            If String.IsNullOrEmpty(TextFInDate.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory In Date is blank")
                Functions.ControlFocus(TextFInDate)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
            If String.IsNullOrEmpty(TextFOutDate.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Factory Out Date is blank")
                Functions.ControlFocus(TextFOutDate)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
            If String.IsNullOrEmpty(textBufferOutDate.Text.Trim) AndAlso Not String.IsNullOrEmpty(textBufferDate.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Buffer Out Date is blank")
                Functions.ControlFocus(textBufferOutDate)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
            If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD In Date is blank")
                Functions.ControlFocus(TextIcdIn)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If

        'If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
        '    If String.IsNullOrEmpty(textCustom.Text.Trim) Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Custom Handover Date is blank")
        '        Functions.ControlFocus(textCustom)
        '        rtnBool = False
        '        Return rtnBool
        '        Exit Function
        '    End If
        'End If

        'If String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Line Handover Date is blank")
        '    Functions.ControlFocus(TextHandOverDate)
        '    rtnBool = False
        '    Return rtnBool
        '    Exit Function
        'End If

        'If Not String.IsNullOrEmpty(textCustom.Text.Trim) Then
        '    If String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Line Handover Date is blank")
        '        Functions.ControlFocus(TextHandOverDate)
        '        rtnBool = False
        '        Return rtnBool
        '        Exit Function
        '    End If
        'End If

        If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
            If String.IsNullOrEmpty(textLineSealNo.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Line Seal is blank")
                Functions.ControlFocus(textLineSealNo)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
            If String.IsNullOrEmpty(textCustomSeal.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Custom Seal is blank")
                Functions.ControlFocus(textCustomSeal)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If

        'If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD In Date is blank")
        '    Functions.ControlFocus(TextIcdIn)
        '    rtnBool = False
        '    Return rtnBool
        '    Exit Function
        'End If

        'If Not String.IsNullOrEmpty(textCustom.Text.Trim) Then
        '    If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD In Date is blank")
        '        Functions.ControlFocus(TextIcdIn)
        '        rtnBool = False
        '        Return rtnBool
        '        Exit Function
        '    End If
        'End If
        'If lstDocType.SelectedValue = "E" Then
        '    If Session.Item("LoginTerminal") <> 7 Then
        '        If Session.Item("LoginTerminal") <> 29 Then
        '            If Not String.IsNullOrEmpty(textCustom.Text.Trim) Then
        '                If String.IsNullOrEmpty(textShippingBill.Text.Trim) Or String.IsNullOrEmpty(textShippingDate.Text.Trim) Or String.IsNullOrEmpty(TextPDate.Text.Trim) OrElse String.IsNullOrEmpty(TextPInvNo.Text.Trim) Then
        '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
        '                    rtnBool = False
        '                    Return rtnBool
        '                    Exit Function
        '                End If
        '            End If
        '        End If
        '    End If

        'End If

        If lstDocType.SelectedValue = "E" Then
            If Session.Item("LoginTerminal") <> 7 Then
                If Session.Item("LoginTerminal") <> 29 Then
                    If Not String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
                        If String.IsNullOrEmpty(textShippingBill.Text.Trim) Or String.IsNullOrEmpty(textShippingDate.Text.Trim) Or String.IsNullOrEmpty(TextPDate.Text.Trim) OrElse String.IsNullOrEmpty(TextPInvNo.Text.Trim) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If
        If lstDocType.SelectedItem.Value = "E" Then
            If Not String.IsNullOrEmpty(TextHandOverDate.Text) Then
                If pAllPartyAccount.BookingNo = Nothing Or pAllPartyAccount.BookingDate Is Nothing Or pAllPartyAccount.RequiredVessel Is Nothing Or pAllPartyAccount.CurrentEta Is Nothing Or pAllPartyAccount.POL Is Nothing Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Documentation Page not updated ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
            End If
        End If
        If lstDocType.SelectedItem.Value = "B" AndAlso textEmptyGateInDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Date is Mandatory for Back to Town case ")
            rtnBool = False
            textEmptyGateInDate.Focus()
            Return rtnBool
            Exit Function
        End If

        If lstDocType.SelectedItem.Value = "R" AndAlso textEmptyGateInDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Date is Mandatory for Reworking case ")
            rtnBool = False
            textEmptyGateInDate.Focus()
            Return rtnBool
            Exit Function
        End If

        If lstDocType.SelectedItem.Value = "M" AndAlso textEmptyGateInDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Empty Gate In Date is Mandatory for Empty Return case ")
            rtnBool = False
            textEmptyGateInDate.Focus()
            Return rtnBool
            Exit Function
        End If

        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim strConnectionString, cmd, CMD2, cmd1, cmd10, CMD51, CMD101, cmdFleetContJo, cmdMtyContainers, cmdMtyContainers1 As String
        Dim con As OleDbConnection
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            'cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "', BILLING_PARTY=" & LstBillTo.SelectedValue & ",SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "', CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ", LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), CUSTOMS_HANDOVER_DATE=TO_DATE('" & textCustom.Text & "','DD/MM/YYYY HH24:MI'), BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "'   WHERE GR_ID=" & hdngrId.Value & ""
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',  TRIP_TYPE='" & lstDocType.SelectedValue & "',BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID='" & lstBLStatus.SelectedValue & "', BL_METHOD='" & lstBlMethod.SelectedItem.Text & "',BL_METHOD_ID='" & lstBlMethod.SelectedValue & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "', CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ", LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "'   WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(cmd1, con)
            cmd5.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmdFleetContJo = " UPDATE FLEET_CONT_JO SET  CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', LINE_ID=" & lstline.SelectedValue & ", FROM_LOCATION=" & lstFactorylocation.SelectedValue & ", CONSIGNEE_ID = DECODE(" & LstConsignor.SelectedValue & ",0,CONSIGNEE_ID," & LstConsignor.SelectedValue & ") WHERE CONT_JO_NO ='" & textjoNo.Text & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd111 As New OleDbCommand(cmdFleetContJo, con)
            cmd111.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd10 = " UPDATE FLEET_CONT_JO_DTLS SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', CONT_NO='" & TextGrno.Text.Trim & "', TRIP_TYPE='" & lstDocType.SelectedValue & "',  SEAL_NO='" & textLineSealNo.Text.Trim & "', AGENT_SEAL='" & textCustomSeal.Text.Trim & "', FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & ", LINE_ID=" & lstline.SelectedValue & ",ICD_OUT_DATE=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'), FACTORY_OUT_DATE= TO_DATE('" & TextFOutDate.Text & "','DD/MM/YYYY HH24:MI'),ALLOTMENT_DATE= TO_DATE('" & textAllotmentDate.Text & "','DD/MM/YYYY HH24:MI'),BUFFER_DATE= TO_DATE('" & textBufferDate.Text & "','DD/MM/YYYY HH24:MI'),BUFFER_OUT_DATE= TO_DATE('" & textBufferOutDate.Text & "','DD/MM/YYYY HH24:MI'),FACTORY_IN_DATE=  TO_DATE('" & TextFInDate.Text & "','DD/MM/YYYY HH24:MI'),VEHICLE_GATE_OUT_DATE=  TO_DATE('" & textVehicleGateOut.Text & "','DD/MM/YYYY HH24:MI'), EMPTYGATE_IN_DATE=  TO_DATE('" & textEmptyGateInDate.Text & "','DD/MM/YYYY HH24:MI'),  ICD_IN_DATE=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI') WHERE GR_ID= " & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd11 As New OleDbCommand(cmd10, con)
            cmd11.ExecuteNonQuery()
        Catch ex As Exception
        End Try
		
		 '===ADDED BY ARJUN NEGI ON 21-02-2026================
        If Session.Item("LoginTerminal") = 40 Or Session.Item("LoginTerminal") = 53 Or Session.Item("LoginTerminal") = 54 Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd10 = "UPDATE ALL_PARTY_ACCOUNT SET PORT_ARRIVAL = TO_DATE('" & TextIcdIn.Text.Trim & "','DD/MM/YYYY HH24:MI:SS') WHERE GR_ID=" & hdngrId.Value & " AND CONT_NO = '" & TextGrno.Text.Trim & "'"
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd11 As New OleDbCommand(cmd10, con)
                cmd11.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If
        'End
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD2 = " UPDATE FLEET_GR_MAPPING SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', TRIP_TYPE='" & lstDocType.SelectedValue & "',FACTORY_LOCATION=DECODE(" & lstcfs.SelectedValue & ",0,FACTORY_LOCATION,'" & lstcfs.SelectedItem.Text & "'),CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "',LINE_ID=" & lstline.SelectedValue & ",CHA_ID=" & lstcfs.SelectedValue & ", FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & " WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd4 As New OleDbCommand(CMD2, con)
            cmd4.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        If hdnPartyInvoiceNo.Value = 0 AndAlso TextPInvNo.Text <> "" Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET INVOICE_NO_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdPartyInvoiceNo As New OleDbCommand(cmd, con)
                cmdPartyInvoiceNo.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If
        If hdnLineHandoverDate.Value = 0 AndAlso TextHandOverDate.Text <> "" Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET LINE_HANDOVER_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdLineHandoverDate As New OleDbCommand(cmd, con)
                cmdLineHandoverDate.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If
        If hdnHandoverCFS.Value = 0 AndAlso lstcfs.SelectedValue = 0 Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET HANDOVER_CFS_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdHandoverCFS As New OleDbCommand(cmd, con)
                cmdHandoverCFS.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If

        If hdnShippingLine.Value <> lstline.SelectedValue Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET LINE_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdLineUpdate As New OleDbCommand(cmd, con)
                cmdLineUpdate.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If

        If hdnFPOD.Value <> LstFOD.SelectedValue Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET FPOD_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdFPODUpdate As New OleDbCommand(cmd, con)
                cmdFPODUpdate.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If

        If hdnConsignor.Value <> LstConsignor.SelectedValue Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmd = "UPDATE VEHICLE_STATUS_UPDATE SET CONSIGNOR_UPDATE='" & Session.Item("LoginUser") & "' WHERE  GR_ID= " & hdngrId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmdConsignorUpdate As New OleDbCommand(cmd, con)
                cmdConsignorUpdate.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd = " UPDATE FLEET_VEHICLE_STATUS SET CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "', TRIP_TYPE='" & lstDocType.SelectedValue & "', ICD_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'), FACTORY_OUT= TO_DATE('" & TextFOutDate.Text & "','DD/MM/YYYY HH24:MI'),ALLOTMENT_DATE= TO_DATE('" & textAllotmentDate.Text & "','DD/MM/YYYY HH24:MI'),BUFFER_DATE= TO_DATE('" & textBufferDate.Text & "','DD/MM/YYYY HH24:MI'),FACTORY_IN=  TO_DATE('" & TextFInDate.Text & "','DD/MM/YYYY HH24:MI'),ICD_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI') WHERE  GR_ID= " & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd3 As New OleDbCommand(cmd, con)
            cmd3.ExecuteNonQuery()
            ' Dim cmd4 As New OleDbCommand(Cmd1, con)
            ' cmd4.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            ' cmdMtyContainers = " UPDATE MTY_CONT_JO_DTLS SET CONT_NO='" & TextGrno.Text.Trim & "'  WHERE  MTY_CONT_ID = (SELECT MAX(MTY_CONT_ID) FROM MTY_CONT_JO_DTLS WHERE CONT_NO='" & TextGrno.Text.Trim & "')"
            cmdMtyContainers = " UPDATE MTY_CONT_JO_DTLS SET CONT_NO='" & TextGrno.Text.Trim & "'  WHERE  MTY_CONT_ID = (SELECT MAX(MTY_CONT_ID) FROM MTY_CONT_JO_DTLS WHERE CONT_NO='" & TextGrno.Text.Trim & "')"

            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd112 As New OleDbCommand(cmdMtyContainers, con)
            cmd112.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        If Not String.IsNullOrEmpty(textEmptyGateInDate.Text) Or lstDocType.SelectedValue = "M" Or lstDocType.SelectedValue = "B" Or lstDocType.SelectedValue = "R" Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmdMtyContainers = " UPDATE MTY_CONT_JO_DTLS SET ALLOT_ID ='', ALLOT_STATUS ='' WHERE MTY_CONT_ID = (SELECT MAX(MTY_CONT_ID) FROM MTY_CONT_JO_DTLS WHERE CONT_NO='" & TextGrno.Text.Trim & "')"
                'cmdMtyContainers = " UPDATE MTY_CONT_JO_DTLS SET ALLOT_ID = " & hdnMtyContId.Value & ", ALLOT_STATUS ='Y' WHERE MTY_CONT_ID = (SELECT MAX(MTY_CONT_ID) FROM MTY_CONT_JO_DTLS WHERE CONT_NO='" & TextGrno.Text.Trim & "')"
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd112 As New OleDbCommand(cmdMtyContainers, con)
                cmd112.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If

        If lstFreeType.SelectedValue = 1 Then
            Try
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                cmdMtyContainers1 = " UPDATE MTY_CONT_JO_DTLS SET ALLOT_ID ='', ALLOT_STATUS ='' WHERE ALLOT_ID=" & hdnMtyContId.Value & ""
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd117 As New OleDbCommand(cmdMtyContainers1, con)
                cmd117.ExecuteNonQuery()
            Catch ex As Exception
            End Try
        End If


        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            'cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "', BILLING_PARTY=" & LstBillTo.SelectedValue & ",SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "', CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ", LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), CUSTOMS_HANDOVER_DATE=TO_DATE('" & textCustom.Text & "','DD/MM/YYYY HH24:MI'), BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "'   WHERE GR_ID=" & hdngrId.Value & ""
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID='" & lstBLStatus.SelectedValue & "', CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',  TRIP_TYPE='" & lstDocType.SelectedValue & "', BL_METHOD='" & lstBlMethod.SelectedItem.Text & "',BL_METHOD_ID='" & lstBlMethod.SelectedValue & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "', CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ", LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "'   WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(cmd1, con)
            cmd5.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD51 = " UPDATE FLEET_CONT_JO SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', TRIP_TYPE='" & lstDocType.SelectedValue & "',  LINE_ID=DECODE(" & lstline.SelectedValue & ",0,LINE_ID," & lstline.SelectedValue & "), TO_LOCATION_ID=" & lstcfs.SelectedValue & " WHERE CONT_JO_NO='" & textjoNo.Text.Trim & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd55 As New OleDbCommand(CMD51, con)
            cmd55.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD101 = " Insert into OWN_MAINTENANCE (OWN_TRACK_ID, COMPANY_ID, TERMINAL_ID, CONT_NO,CONT_SIZE,CONT_TYPE, MTY_CONT_ID,ALLOTMENT_DATE, ICD_OUT_DATE, FACTORY_IN_DATE,FACTORY_OUT_DATE,BUFFER_IN_DATE,BUFFER_OUT_DATE,ICD_IN_DATE,EMPTYGATE_IN_DATE, LINE_HANDOVER_DATE, PARTY_INV_NO, PARTY_INV_DATE,SB_NO, SB_DATE,BL_NO, BOOKING_NO,BOOKING_DATE, CFS_ID, CFS, LINE_ID, " _
                     & " LINE, POL_ID, POL, POD_ID, PORT,LOCATION_ID,CONSINGEE_NAME,CONSIGNMENT_TYPE, SHIPPER_ID, SHIPPER_NAME, CREATED_BY, CREATED_ON,LINE_SEAL,CUSTOM_SEAL,REMARK_ID,BL_METHOD,BL_METHOD_ID) " _
                     & " VALUES (OWN_TRACK_ID.NEXTVAL," & Session.Item("CompanyId") & ",  " & Session.Item("LoginTerminal") & ",'" & TextGrno.Text.Trim & "','" & lstSize.SelectedItem.Text & "','" & lstType.SelectedItem.Text & "','" & hdnMtyContId.Value & "',NVL(TO_DATE('" & textAllotmentDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textOutDaTe.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextFInDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextFOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textBufferDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textBufferOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextIcdIn.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textEmptyGateInDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextHandOverDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextPInvNo.Text.Trim & "',NVL(TO_DATE('" & TextPDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & textShippingBill.Text.Trim & "',NVL(TO_DATE('" & textShippingDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextBlNO.Text.Trim & "','" & TextBookingNO.Text.Trim & "',NVL(TO_DATE('" & TextBookingDate.Text.Trim & "','DD/MM/YYYY'),''), " _
                     & " " & lstcfs.SelectedValue & ",'" & lstcfs.SelectedItem.Text & "'," & lstline.SelectedValue & ",'" & lstline.SelectedItem.Text & "'," & lstPol.SelectedValue & ",'" & lstPol.SelectedItem.Text & "', " _
                     & " " & LstFOD.SelectedValue & ",'" & LstFOD.SelectedItem.Text & "'," & lstFactorylocation.SelectedValue & ",'" & TextConsigneeName.Text & "'," _
                     & " '" & lstConsignmentType.SelectedItem.Text & "'," & LstConsignor.SelectedValue & ",'" & LstConsignor.SelectedItem.Text & "','" & Session.Item("LoginUser") & "',sysdate, '" & textLineSealNo.Text.Trim & "','" & textCustomSeal.Text.Trim & "', '" & LstRemark.SelectedValue & "',  '" & lstBlMethod.SelectedItem.Text & "','" & lstBlMethod.SelectedValue & "') "
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(CMD101, con)
            cmd5.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
        End Try
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        'tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class