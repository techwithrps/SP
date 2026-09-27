Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_AddDetention1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            ' ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        TextGrno.Enabled = True
        btnSearchGr.Visible = True
        btnSearchGr.Enabled = True
        ButtonControlSetup(True)
        Functions.ControlFocus(TextGrno)
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd3, cmd4, cmd5, cmd6, cmd7 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID=100 ORDER BY PORT_NAME"
            cmd4 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID <> 100 ORDER BY PORT_NAME"
            cmd5 = "SELECT DISTINCT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='L' ORDER BY CUSTOMER_NAME"
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
        Catch ex As Exception

        End Try

    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
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
                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.CustomerId = pFleetContJo.ConsigneeId
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                Dim pAllPartyAccount As New AllPartyAccount
                pAllPartyAccount.MtyContId = obj.MtyContId
                AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
                Functions.treeViewNodeSetup(tvContainers, "0", obj.MtyContId, obj.ContNo & " | SB-" & pAllPartyAccount.SbNo & " | Handover-" & obj.DOValidity & " | GR-" & obj.AgentSeal & " | " & "Consignee-" & pCustomerMaster.CustomerName)
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
        hdnMtyContId.Value = PCodeValue.Value
        If pFleetContJoDtls.MtyContId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container not booked yet.")
            Return
        End If
        If pFleetContJoDtls.GrId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Gr not Generated.")
            Return
        End If
        hdnMtyContId.Value = pFleetContJoDtls.MtyContId
        hdngrId.Value = pFleetContJoDtls.GrId
        Dim P As New FleetGrMapping
        P.GrId = pFleetContJoDtls.GrId
        FleetGrMapping.ReturnFleetGrMapping(P)
        lstcfs.SelectedValue = P.CHAId
        lstline.SelectedValue = P.LineId
        Dim PGR As New FleetVehicleStatus
        PGR.TerminalId = 1
        PGR.GrNo = P.GrNo
        FleetVehicleStatus.ReturnFleetVehicleStatus(PGR)
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
        TextIcdIn.Text = PGR.IcdIn
        textOutDaTe.Text = PGR.IcdOut
        TextFInDate.Text = PGR.FactoryIn
        TextFOutDate.Text = PGR.FactoryOut
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = pFleetContJoDtls.MtyContId
        pAllPartyAccount = AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        Try
            LstConsignor.SelectedValue = pAllPartyAccount.NoOfDays
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

        Try
            lstPol.SelectedValue = P.POL
        Catch ex As Exception
            lstPol.SelectedValue = 0
        End Try
        Try
            LstFOD.SelectedValue = P.FPOD
        Catch ex As Exception
            LstFOD.SelectedValue = 1
        End Try
        'LstFOD.SelectedValue = P.FPOD
        Try
            lstConsignmentType.SelectedItem.Text = pAllPartyAccount.ConsignmentType
        Catch ex As Exception
        End Try
        lststatus.SelectedValue = pAllPartyAccount.ShipmentStatus
        TextBlNO.Text = pAllPartyAccount.BlNo
        TextPInvNo.Text = pAllPartyAccount.PartyInvNo
        TextPDate.Text = pAllPartyAccount.PartyInvDate
        TextBookingNO.Text = pAllPartyAccount.BookingNo
        LstBillTo.SelectedValue = P.ConsignmentType
        'TextExRate.Text = pAllPartyAccount.ExRate
        If Session.Item("LoginUser") = "PUSHPENDRA" Or Session.Item("LoginUser") = "BEENA ASWAL" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "AKASH" Or Session.Item("LoginUser") = "ANAMIKA" Then
            TextGrno.Enabled = True
        Else
            TextGrno.Enabled = False
        End If
        If Session.Item("LoginUser") = "KARKI" Or Session.Item("LoginUser") = "ROHIT" Or Session.Item("LoginUser") = "BEENA ASWAL" Or Session.Item("LoginUser") = "AKASH" Or Session.Item("LoginUser") = "anuj" Or Session.Item("LoginUser") = "ANAMIKA" Or Session.Item("LoginUser") = "REENA" Or Session.Item("LoginUser") = "raj" Then
            TextIcdIn.Enabled = True
            textOutDaTe.Enabled = True
            TextFInDate.Enabled = True
            TextFOutDate.Enabled = True
            lstcfs.Enabled = True
            lstline.Enabled = True
        Else
            TextIcdIn.Enabled = False
            textOutDaTe.Enabled = False
            TextFInDate.Enabled = False
            TextFOutDate.Enabled = False
            lstcfs.Enabled = False
            lstline.Enabled = False
        End If

        If Session.Item("LoginUser") = "KARKI" Or Session.Item("LoginUser") = "ROHIT" Or Session.Item("LoginUser") = "superuser" Then
            LstConsignor.Enabled = True
        End If
        If Session.Item("LoginUser") = "BEENA ASWAL" Or Session.Item("LoginUser") = "REENA" Or Session.Item("LoginUser") = "raj" Or Session.Item("LoginUser") = "SHASHI" Or Session.Item("LoginUser") = "SUMIT" Or Session.Item("LoginUser") = "ROHIT" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "ANAMIKA" Then
            TextHandOverDate.Enabled = True
            TextBlNO.Enabled = True
            TextBookingNO.Enabled = True
            TextPInvNo.Enabled = True
            TextPDate.Enabled = True
            lstConsignmentType.Enabled = True
            LstConsignor.Enabled = True
        ElseIf Session.Item("LoginUser") = "MUKESH" Then
            TextBlNO.Enabled = True
        Else
            TextHandOverDate.Enabled = False
            TextBlNO.Enabled = False
            TextBookingNO.Enabled = False
            TextPInvNo.Enabled = False
            TextPDate.Enabled = False
        End If
        lstPol.Enabled = True
        If Session.Item("LoginUser") = "RIYA" Then
            LstConsignor.Enabled = True
            lststatus.Enabled = True
            TextBookingNO.Enabled = True
            TextPInvNo.Enabled = True
        Else
            'LstConsignor.Enabled = False
            lststatus.Enabled = False
        End If
        If Session.Item("LoginUser") = "VIKAS" Or Session.Item("LoginUser") = "SHASHI" Then
            LstRemark.Enabled = True
            TextPInvNo.Enabled = True

        End If
        'TextBlNO.Enabled = True
        'TextPInvNo.Enabled = True
        'TextPDate.Enabled = True
        'TextBookingNO.Enabled = True
        'TextExRate.Enabled = True
        LstBillTo.Enabled = True
        LstFOD.Enabled = True
        'TextHandOverDate.Enabled = True
        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchGr.Click
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.ContNo = TextGrno.Text
        LoadTreeViewData(pFleetContJoDtls)
        'FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
        'If pFleetContJoDtls.MtyContId = 0 Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container not booked yet.")
        '    Return
        'End If
        'If pFleetContJoDtls.GrId = 0 Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Gr not Generated.")
        '    Return
        'End If
        'hdnMtyContId.Value = pFleetContJoDtls.MtyContId
        'hdngrId.Value = pFleetContJoDtls.GrId
        'Dim P As New FleetGrMapping
        'P.GrId = pFleetContJoDtls.GrId
        'FleetGrMapping.ReturnFleetGrMapping(P)
        'Dim PGR As New FleetVehicleStatus
        'PGR.TerminalId = 1
        'PGR.GrNo = P.GrNo
        'FleetVehicleStatus.ReturnFleetVehicleStatus(PGR)
        'TextIcdIn.Text = PGR.IcdIn
        'textOutDaTe.Text = PGR.IcdOut
        'TextFInDate.Text = PGR.FactoryIn
        'TextFOutDate.Text = PGR.FactoryOut
        'Dim pAllPartyAccount As New AllPartyAccount
        'pAllPartyAccount.ContNo = TextGrno.Text
        'pAllPartyAccount = AllPartyAccount.ReturnAllPartyAccountPart2(pAllPartyAccount)
        'TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        'Try
        '    lstPol.SelectedValue = P.POL
        'Catch ex As Exception
        'lstPol.SelectedValue = 0
        ' End Try
        ' Try
        '    LstFOD.SelectedValue = P.FPOD
        'Catch ex As Exception
        'LstFOD.SelectedValue = 1
        ' End Try
        ' 'LstFOD.SelectedValue = P.FPOD
        'lstConsignmentType.SelectedValue = P.ConsignmentType
        'TextBlNO.Text = pAllPartyAccount.BlNo
        'TextPInvNo.Text = pAllPartyAccount.PartyInvNo
        'TextPDate.Text = pAllPartyAccount.PartyInvDate
        'TextExRate.Text = pAllPartyAccount.ExRate
        'lstPol.Enabled = True
        'lstConsignmentType.Enabled = True
        'TextBlNO.Enabled = True
        'TextPInvNo.Enabled = True
        'TextPDate.Enabled = True
        'TextExRate.Enabled = True
        'LstFOD.Enabled = True
        'TextIcdIn.Enabled = True
        'textOutDaTe.Enabled = True
        'TextFInDate.Enabled = True
        'TextFOutDate.Enabled = True
        'TextHandOverDate.Enabled = True
        'btnSave.Visible = True
        'btnSave.Enabled = True
        'ListControlDataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strConnectionString, cmd, CMD2, cmd1, cmd10, CMD51, CMD101, cmdFleetContJo As String
        Dim con As OleDbConnection
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd = " UPDATE FLEET_VEHICLE_STATUS SET CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "', ICD_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'), FACTORY_OUT= TO_DATE('" & TextFOutDate.Text & "','DD/MM/YYYY HH24:MI'),FACTORY_IN=  TO_DATE('" & TextFInDate.Text & "','DD/MM/YYYY HH24:MI'),ICD_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI') WHERE  GR_ID= " & hdngrId.Value & ""
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
            cmdFleetContJo = " UPDATE FLEET_CONT_JO SET CONSIGNEE_ID = DECODE(" & LstConsignor.SelectedValue & ",0,CONSIGNEE_ID," & LstConsignor.SelectedValue & ") WHERE CONT_JO_NO ='" & textjoNo.Text & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd111 As New OleDbCommand(cmdFleetContJo, con)
            cmd111.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd10 = " UPDATE FLEET_CONT_JO_DTLS SET CONT_NO='" & TextGrno.Text.Trim & "',LINE_ID=DECODE(" & lstline.SelectedValue & ",0,LINE_ID," & lstline.SelectedValue & ") WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd11 As New OleDbCommand(cmd10, con)
            cmd11.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD2 = " UPDATE FLEET_GR_MAPPING SET CONSIGNMENT_TYPE=" & LstBillTo.SelectedValue & ",FACTORY_LOCATION=DECODE(" & lstcfs.SelectedValue & ",0,FACTORY_LOCATION,'" & lstcfs.SelectedItem.Text & "'),CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "',LINE_ID=" & lstline.SelectedValue & ",CHA_ID=" & lstcfs.SelectedValue & ", FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & " WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd4 As New OleDbCommand(CMD2, con)
            cmd4.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "', BILLING_PARTY=" & LstBillTo.SelectedValue & ",SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "',POL_ID=" & lstPol.SelectedValue & ", LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY'),PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "'   WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(cmd1, con)
            cmd5.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD51 = " UPDATE FLEET_CONT_JO SET TO_LOCATION_ID=" & lstcfs.SelectedValue & " WHERE CONT_JO_NO='" & textjoNo.Text.Trim & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd55 As New OleDbCommand(CMD51, con)
            cmd55.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD101 = " Insert into MAINTENANCE (D_TRACK_ID, CONT_NO, MTY_CONT_ID, ICD_OUT, FACTORY_IN,FACTORY_OUT, ICD_IN, HANDOVER_DATE, PARTY_INV_NO, PARTY_INV_DATE,BL_NO, BOOKING_NO, CFS_ID, CFS, LINE_ID, " _
                     & " LINE, POL_ID, POL, FPOD_ID, FPOD, BILL_TO_ID, BILL_TO, SHIPEMENT_STATUS, CONSIGNMENT_TYPE, ALL_PARTY_CONSIGNOR_ID, ALL_PARTY_CONSIGNOR, CREATED_BY, CREATED_ON, REMARK_ID) " _
                     & " VALUES (D_TRACK_ID.NEXTVAL,'" & TextGrno.Text.Trim & "','" & hdnMtyContId.Value & "',NVL(TO_DATE('" & textOutDaTe.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextFInDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextFOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TextIcdIn.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextHandOverDate.Text.Trim & "','DD/MM/YYYY'),''),'" & TextPInvNo.Text.Trim & "',NVL(TO_DATE('" & TextPDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextBlNO.Text.Trim & "','" & TextBookingNO.Text.Trim & "', " _
                     & " " & lstcfs.SelectedValue & ",'" & lstcfs.SelectedItem.Text & "'," & lstline.SelectedValue & ",'" & lstline.SelectedItem.Text & "'," & lstPol.SelectedValue & ",'" & lstPol.SelectedItem.Text & "', " _
                     & " " & LstFOD.SelectedValue & ",'" & LstFOD.SelectedItem.Text & "'," & LstBillTo.SelectedValue & ",'" & LstBillTo.SelectedItem.Text & "','" & lststatus.SelectedItem.Text & "', " _
                     & " '" & lstConsignmentType.SelectedItem.Text & "'," & LstConsignor.SelectedValue & ",'" & LstConsignor.SelectedItem.Text & "','" & Session.Item("LoginUser") & "',sysdate, '" & LstRemark.SelectedValue & "') "
            ''Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
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