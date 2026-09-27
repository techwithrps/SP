Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO
Partial Class Fleet_apa1
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
            TextGrno.Enabled = True
            btnSearchGr.Visible = True
            btnSearchGr.Enabled = True
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
        Dim strConnectionString, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID=100 ORDER BY PORT_NAME"
            cmd4 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID <> 100 ORDER BY PORT_NAME"
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

            Dim pExtTerminalMaster As New TerminalMaster

            lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            lstCFS.DataTextField = "TerminalName"
            lstCFS.DataValueField = "TerminalId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstCFS.SelectedValue = 0

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

    Sub fillControlWithData(ByVal PCodeValue As Integer)
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.MtyContId = PCodeValue
        ' LoadTreeViewData(pFleetContJoDtls)
        FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
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
        TextGrno.Text = pFleetContJoDtls.ContNo
        Dim P As New FleetGrMapping
        P.GrId = pFleetContJoDtls.GrId
        FleetGrMapping.ReturnFleetGrMapping(P)
        Dim PGR As New FleetVehicleStatus
        PGR.TerminalId = 1
        PGR.GrNo = P.GrNo
        FleetVehicleStatus.ReturnFleetVehicleStatus(PGR)
        TextIcdIn.Text = PGR.IcdIn
        textOutDaTe.Text = PGR.IcdOut
        TextFInDate.Text = PGR.FactoryIn
        TextFOutDate.Text = PGR.FactoryOut
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = pFleetContJoDtls.MtyContId
        AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        textCustomHandoverDate.Text = pAllPartyAccount.CustomsHandoverDate
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
        LstFOD.SelectedItem.Text = pAllPartyAccount.Port
        textShipper.Text = pAllPartyAccount.ShipperName
        textShippingLine.Text = pAllPartyAccount.Line
        textFactoryLocation.Text = pAllPartyAccount.FactoryLocation
        textConsignee.Text = pAllPartyAccount.ConsingeeName
        TextBlNO.Text = pAllPartyAccount.BlNo
        TextPInvNo.Text = pAllPartyAccount.PartyInvNo
        TextPDate.Text = pAllPartyAccount.PartyInvDate
        textLinerInvNo.Text = pAllPartyAccount.LinerInvNo
        textLinerInvDate.Text = pAllPartyAccount.LinerInvDate
        TextExRate.Text = pAllPartyAccount.ExRate

        textSbNo.Text = pAllPartyAccount.SbNo
        textSbDate.Text = pAllPartyAccount.SbDate
        lstSbReceived.SelectedItem.Text = pAllPartyAccount.SbReceived
        textCartons.Text = pAllPartyAccount.Cartons
        textNetWeight.Text = pAllPartyAccount.NetWt
        textGrossWeigh.Text = pAllPartyAccount.GrossWt
        Try
            lstBLStatus.SelectedValue = pAllPartyAccount.BLStatusId
            lstPol.SelectedValue = pAllPartyAccount.POLId
            lstCFS.SelectedValue = pAllPartyAccount.CFSId
            lstTelexStatus.SelectedValue = pAllPartyAccount.TelexStatus
        Catch ex As Exception
        End Try
        textBookingNo.Text = pAllPartyAccount.BookingNo
        textHealthCertNo.Text = pAllPartyAccount.HealthCertificateNo
        textContainerLot.Text = pAllPartyAccount.Lot
        textRailOutDate.Text = pAllPartyAccount.TrainOutDate
        textPortGateInDate.Text = pAllPartyAccount.PortArrival
        textVesselName.Text = pAllPartyAccount.CurrentVessel
        textEtd.Text = pAllPartyAccount.CurrentEtd
        textSailStatus.Text = pAllPartyAccount.Sailed
        textEta.Text = pAllPartyAccount.CurrentEta
        textTransitTime.Text = pAllPartyAccount.TransitTime
        textShipmentStatus.Text = pAllPartyAccount.ShipmentStatus

        textShipper.Enabled = True
        textConsignee.Enabled = True
        lstPol.Enabled = True
        TextBlNO.Enabled = True
        TextPInvNo.Enabled = True
        TextPDate.Enabled = True
        TextExRate.Enabled = True
        LstFOD.Enabled = True
        TextIcdIn.Enabled = True
        textOutDaTe.Enabled = True
        TextFInDate.Enabled = True
        TextFOutDate.Enabled = True
        TextHandOverDate.Enabled = True
        textLinerInvNo.Enabled = True
        textLinerInvDate.Enabled = True
        lstCFS.Enabled = True
        textSbNo.Enabled = True
        textSbDate.Enabled = True
        textCustomHandoverDate.Enabled = True
        lstSbReceived.Enabled = True
        textCartons.Enabled = True
        textNetWeight.Enabled = True
        textGrossWeigh.Enabled = True
        lstBLStatus.Enabled = True
        textBookingNo.Enabled = True
        textHealthCertNo.Enabled = True
        textRailOutDate.Enabled = True
        textPortGateInDate.Enabled = True
        textVesselName.Enabled = True
        textEtd.Enabled = True
        textSailStatus.Enabled = True
        textEta.Enabled = True
        textTransitTime.Enabled = True
        textShipmentStatus.Enabled = True
        lstTelexStatus.Enabled = True
        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearchGr.Click
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.ContNo = TextGrno.Text

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        GridViewAllPartyPart3.DataSource = Nothing
        GridViewAllPartyPart3.DataBind()

        Dim party As New AllPartyAccount

        party.ContNo = TextGrno.Text
        Dim arr As ArrayList
        arr = AllPartyAccount.ReturnAPA1(party)
        GridViewAllPartyPart3.DataSource = arr
        GridViewAllPartyPart3.DataBind()
        If arr.Count > 0 Then
            'tblReport.Visible = True
        Else
            'tblReport.Visible = True
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
    End Sub

    Protected Sub GridViewAllPartyPart3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewAllPartyPart3.RowCommand
        If e.CommandName.Equals("part4") Then
            Dim MtyContId As Integer = e.CommandArgument
            fillControlWithData(MtyContId)
        End If
    End Sub

    Protected Sub GridViewAllPartyPart1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewAllPartyPart3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' intCounter = intCounter + 1
            'Dim lblblsrn As Label = GridViewAllPartyPart1.FindControl("lblsrn")
            Dim lblblsrn As Label = DirectCast(e.Row.FindControl("lblsrn"), Label)
            'e.Row.Cells(1).Text = intCounter
            ' lblblsrn.Text = intCounter.ToString()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET REQUIRED_VESSEL='" & textVesselName.Text & "', TRANSIT_TIME=NVL('" & textTransitTime.Text.Trim & "','0'), " _
                & " SAILED=TO_DATE('" & textSailStatus.Text & "','DD/MM/YYYY HH24:MI'),CURRENT_ETA=TO_DATE('" & textEta.Text & "','DD/MM/YYYY HH24:MI'), " _
                & " CURRENT_ETD=TO_DATE('" & textEtd.Text & "','DD/MM/YYYY HH24:MI'),PORT_ARRIVAL=TO_DATE('" & textPortGateInDate.Text & "','DD/MM/YYYY HH24:MI')," _
                & " TRAIN_OUT_DATE=TO_DATE('" & textRailOutDate.Text & "','DD/MM/YYYY HH24:MI'),SHIPPER_NAME='" & textShipper.Text & "'," _
                & " CONSINGEE_NAME='" & textConsignee.Text & "',BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID='" & lstBLStatus.SelectedValue & "'," _
                & " POL='" & lstPol.SelectedItem.Text & "', POL_ID='" & lstPol.SelectedValue & "', TELEX_STATUS='" & lstTelexStatus.SelectedValue & "', " _
                & " BOOKING_NO='" & textBookingNo.Text & "',HEALTH_CERTIFICATE_NO='" & textHealthCertNo.Text & "',SB_RECEIVED='" & lstSbReceived.SelectedItem.Text & "', " _
                & " CARTONS='" & textCartons.Text & "',NET_WT='" & textNetWeight.Text & "',GROSS_WT='" & textGrossWeigh.Text & "',CFS='" & lstCFS.SelectedItem.Text & "',CFS_ID='" & lstCFS.SelectedValue & "', " _
                & " CUSTOMS_HANDOVER_DATE=TO_DATE('" & textCustomHandoverDate.Text & "','DD/MM/YYYY HH24:MI'), LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI')," _
                & " PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "','')," _
                & " PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''),LINER_INV_NO=NVL('" & textLinerInvNo.Text.Trim & "',''), " _
                & " LINER_INV_DATE=NVL(TO_DATE('" & textLinerInvDate.Text & "','DD/MM/YYYY HH24:MI'),''),SB_NO=NVL('" & textSbNo.Text.Trim & "',''), " _
                & " SB_DATE=NVL(TO_DATE('" & textSbDate.Text & "','DD/MM/YYYY HH24:MI'),''),EX_RATE=NVL('" & TextExRate.Text.Trim & "','0') WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(cmd1, con)
            cmd5.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Dim party As New AllPartyAccount

        party.ContNo = TextGrno.Text
        Dim arr As ArrayList
        arr = AllPartyAccount.ReturnAPA1(party)
        GridViewAllPartyPart3.DataSource = arr
        GridViewAllPartyPart3.DataBind()
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
End Class
