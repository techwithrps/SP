Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_ETDUpdate
    Inherits System.Web.UI.Page
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
        ButtonControlSetup(True)
        Functions.ControlFocus(TextGrno)
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

    Sub ListControlDataBind()
        Dim strConnectionString, cmd3, cmd4, cmd5, cmd6, cmd7 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT PORT_ID, PORT_NAME FROM PORT_MASTER WHERE COUNTRY_ID=19 AND GATEWAY_PORT='Y' ORDER BY PORT_NAME"
            cmd4 = "SELECT DISTINCT PORT_ID,  (PORT_NAME||'-'||COUNTRY_NAME) PORT_NAME FROM PORT_MASTER PM, COUNTRY_MASTER CT WHERE PM.COUNTRY_ID=CT.COUNTRY_ID ORDER BY PORT_NAME"
            cmd5 = "SELECT DISTINCT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='L'  ORDER BY CUSTOMER_NAME"
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
                pFleetContJo.ContJoNo = textjoNo.Text
                FleetContJo.ReturnFleetContJo(pFleetContJo)
                Try
                    lstline.SelectedValue = pFleetContJo.LineId
                    hdnShippingLine.Value = pFleetContJo.LineId
                Catch ex As Exception
                End Try

                lstcfs.SelectedValue = pFleetContJo.ToLocationId
                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.CustomerId = pFleetContJo.ConsigneeId
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                Dim pAllPartyAccount As New AllPartyAccount
                pAllPartyAccount.MtyContId = obj.MtyContId
                AllPartyAccount.ReturnMtyContId(pAllPartyAccount)
                Functions.treeViewNodeSetup(tvContainers, "0", obj.MtyContId, obj.ContNo & " | SB-" & pAllPartyAccount.SbNo & " | Handover-" & pAllPartyAccount.LineHandoverDate & " | GR-" & obj.SealNo & " | " & "Consignee-" & pCustomerMaster.CustomerName)
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
        hdnJobId.Value = pFleetContJoDtls.ContJoId


        ' pFleetContJoDtls.ContJoId = hdngrId.Value

        Dim pfleet As New FleetContJo
        pfleet.ContJoId = hdnJobId.Value
        FleetContJo.ReturnFleetContJo(pfleet)

        hdnMtyContId.Value = pFleetContJoDtls.MtyContId
        hdngrId.Value = pFleetContJoDtls.GrId
        Dim P As New FleetGrMapping
        P.GrId = pFleetContJoDtls.GrId
        FleetGrMapping.ReturnFleetGrMapping(P)
        If P.CHAId = 0 Then
            hdnHandoverCFS.Value = 0
        Else
            hdnHandoverCFS.Value = 1
        End If
        TextIcdIn.Text = pFleetContJoDtls.IcdInDate
        textOutDaTe.Text = pFleetContJoDtls.IcdOutDate
        textEmptyGateinDate.Text = pFleetContJoDtls.EmptyGateInDate

        '  lstline.SelectedValue = pfleet.LineId
        ' hdnShippingLine.Value = pfleet.LineId
        lstDocType.SelectedValue = pFleetContJoDtls.TripType
        'Dim PGR As New FleetVehicleStatus
        'PGR.TerminalId = 1
        'PGR.GrNo = P.GrNo
        'FleetVehicleStatus.ReturnFleetVehicleStatus(PGR)
        'Dim str As String
        'Dim strArr() As String
        'Dim count As Integer
        'str = pFleetContJoDtls.ContNo
        'strArr = str.Split("-")
        'For count = 0 To strArr.Length - 1
        '    If count = 0 Then
        '    Else
        '        textjoNo.Text = (strArr(count))
        '    End If
        'Next

        textjoNo.Text = pfleet.ContJoNo
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = pFleetContJoDtls.MtyContId
        pAllPartyAccount = AllPartyAccount.ReturnMtyContId(pAllPartyAccount)

        If pAllPartyAccount.LineHandoverDate = "" Then
            hdnLineHandoverDate.Value = 0
        Else
            hdnLineHandoverDate.Value = 1
        End If

        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        'textCustom.Text = pAllPartyAccount.CustomsHandoverDate
        Try
            LstConsignor.SelectedValue = pAllPartyAccount.NoOfDays
            hdnConsignor.Value = pAllPartyAccount.NoOfDays
            ' lstcfs.SelectedValue = pAllPartyAccount.CFS
        Catch ex As Exception
            LstConsignor.SelectedValue = 0
        End Try
        Dim pContJO As New FleetContJo
        pContJO.ContJoNo = textjoNo.Text
        FleetContJo.ReturnFleetContJo(pContJO)
        Dim aCustomer As New CustomerMaster
        aCustomer.CustomerId = pContJO.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(aCustomer)
        LstConsignor.SelectedItem.Text = aCustomer.CustomerName


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


        TextBlNO.Text = pAllPartyAccount.BlNo
        If pAllPartyAccount.PartyInvNo = "" Then
            hdnPartyInvoiceNo.Value = 0
        Else
            hdnPartyInvoiceNo.Value = 1
        End If


        TextPInvNo.Text = pAllPartyAccount.PartyInvNo
        TextPDate.Text = pAllPartyAccount.PartyInvDate
        TextBookingNO.Text = pAllPartyAccount.BookingNo
        textVoyage.Text = pAllPartyAccount.Voyage
        TextBookingDate.Text = pAllPartyAccount.BookingDate
        textShippingBill.Text = pAllPartyAccount.SbNo
        textShippingDate.Text = pAllPartyAccount.SbDate
        TextConsigneeName.Text = pAllPartyAccount.ConsingeeName
        If pAllPartyAccount.LineHandoverDate = "" Then
            hdnLineHandoverDate.Value = 0
        Else
            hdnLineHandoverDate.Value = 1
        End If

        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        textDischargeDate.Text = pAllPartyAccount.DischargeDate
        textGateoutDate.Text = pAllPartyAccount.GateoutDate
        textEmptyGateinDate.Text = pAllPartyAccount.EmptyGateInDate
        ' textCustom.Text = pAllPartyAccount.CustomsHandoverDate
        textETD.Text = pAllPartyAccount.RequiredEtd
        textPortArrival.Text = pAllPartyAccount.PortArrival
        textRailout.Text = pAllPartyAccount.TrainOutDate
        textTrainNo.Text = pAllPartyAccount.TrainNo
        TextPacket.Text = pAllPartyAccount.Cartons
        textGrossWt.Text = pAllPartyAccount.GrossWt
        'Try
        '    LstRemark.SelectedValue = pAllPartyAccount.HoldRemarkId
        'Catch ex As Exception
        '    LstRemark.SelectedValue = 0
        'End Try
        Try
            lslPackageType.SelectedValue = pAllPartyAccount.PackageTypeId
        Catch ex As Exception
            lslPackageType.SelectedValue = 0
        End Try
        Try
            LstConsignor.SelectedValue = pAllPartyAccount.NoOfDays
            hdnConsignor.Value = pAllPartyAccount.NoOfDays
            ' lstcfs.SelectedValue = pAllPartyAccount.CFS
        Catch ex As Exception
            LstConsignor.SelectedValue = 0
        End Try
        Try
            lstPol.SelectedValue = pAllPartyAccount.POLId
        Catch ex As Exception
            lstPol.SelectedValue = 0
        End Try
        Try
            LstFOD.SelectedValue = pAllPartyAccount.PODId
            hdnFPOD.Value = pAllPartyAccount.PODId
        Catch ex As Exception
            LstFOD.SelectedValue = 0
        End Try


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
        textETD.Text = pAllPartyAccount.RequiredEtd
        textPortArrival.Text = pAllPartyAccount.PortArrival
        textRailout.Text = pAllPartyAccount.TrainOutDate
        textTrainNo.Text = pAllPartyAccount.TrainNo
        textShippingBill.Text = pAllPartyAccount.SbNo
        textShippingDate.Text = pAllPartyAccount.SbDate
        TextConsigneeName.Text = pAllPartyAccount.ConsingeeName

        If Session.Item("LoginUser") = "Suresh Rajput" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "ADMIN" Then
            TextGrno.Enabled = False
            LstConsignor.Enabled = False
            TextPInvNo.Enabled = False
            TextPDate.Enabled = False
            textShippingBill.Enabled = False
            textShippingDate.Enabled = False
            textETD.Enabled = True
            textGrossWt.Enabled = True
            TextPacket.Enabled = True
            TextIcdIn.Enabled = True
            TextHandOverDate.Enabled = True
            lslPackageType.Enabled = True
            TextConsigneeName.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If
        If Session.Item("LoginUser") = "Gaurav Singh" Then
            TextConsigneeName.Enabled = True
            textETD.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If

        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Then
            textDischargeDate.Enabled = True
            textGateoutDate.Enabled = True
            TextHandOverDate.Enabled = True
            textEmptyGateinDate.Enabled = True
            textPortArrival.Enabled = True
            textVoyage.Enabled = True
            textTrainNo.Enabled = True
            textRailout.Enabled = True
            lstcfs.Enabled = True
            lstline.Enabled = True
            LstFOD.Enabled = True
            lstPol.Enabled = True
            TextIcdIn.Enabled = True
            TextBlNO.Enabled = True
            textShippingBill.Enabled = True
            TextConsigneeName.Enabled = True
            LstConsignor.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If
        'If Session.Item("LoginUser") = "BEENA ASWAL" Or Session.Item("LoginUser") = "PUSHPENDRA" Or Session.Item("LoginUser") = "REENA" Or Session.Item("LoginUser") = "raj" Or Session.Item("LoginUser") = "TANAJI" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "ANAMIKA" Or Session.Item("LoginUser") = "SHASHI" Or Session.Item("LoginUser") = "RIYA" Then
        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchGr.Click
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.ContNo = TextGrno.Text
        LoadTreeViewData(pFleetContJoDtls)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim strConnectionString, cmd, CMD2, cmd1, cmd10, CMD51, cmdFleetContJo As String
        '   Dim strConnectionString, CMD2, cmd1 As String
        Dim con As OleDbConnection
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.LineItemId = hdnJobId.Value
        pImpInvoice.CompanyId = Session.Item("CompanyId")
        pImpInvoice = ImpInvoice.ReturnImpInvoiceContJoId(pImpInvoice)
        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "superuser" AndAlso Session.Item("LoginUser") <> "Gaurav Singh" Then
            If Session.Item("CompanyId") = 2 And pImpInvoice.ServiceType <> "T" Then
                If pImpInvoice.EinvoiceStatus = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Einvoice  Alreday Entered Against Selected Container No , So edit not allow ")
                    Return
                End If
                ' End If
                'Else
                '    ' If Session.Item("LoginUser") <> "Akshay" Then
                '    If pImpInvoice.PrintStatus = "Y" Then
                '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice  Alreday Approved Against Selected Container No , So edit not allow ")
                '        Return
                '    End If
            End If
        End If
        If Not String.IsNullOrEmpty(TextHandOverDate.Text) Then
            If GetDateTime(TextHandOverDate.Text.Trim()) > DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Handover Date can not be more than current date")
                Functions.ControlFocus(TextHandOverDate)
                Return
            End If
        End If

        If Not String.IsNullOrEmpty(TextHandOverDate.Text) Then
            If GetDateTime(TextHandOverDate.Text.Trim()) < GetDateTime(TextIcdIn.Text.Trim()) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Line Handover Date not be less than ICD Gate In Date.")
                Functions.ControlFocus(TextHandOverDate)
                Functions.ControlFocus(TextHandOverDate)
                Return
            End If
        End If

        Try
            If Not String.IsNullOrEmpty(textPortArrival.Text) Then
                If GetDateTime(textPortArrival.Text.Trim()) < GetDateTime(textRailout.Text.Trim()) Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Port Arrival Date not be less than Railout Date.")
                    Functions.ControlFocus(textPortArrival)
                    Return
                    Functions.ControlFocus(textPortArrival)
                    Return
                End If
            End If
        Catch ex As Exception
        End Try

        If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
            If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD In Date is blank")
                Functions.ControlFocus(TextIcdIn)
                Return
            End If
        End If
        Try
            If Not String.IsNullOrEmpty(textRailout.Text) Then
                If GetDateTime(textRailout.Text.Trim()) >= DateTime.Now Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                    Functions.ControlFocus(textRailout)
                    Functions.ControlFocus(textRailout)
                    Return
                End If
            End If
        Catch ex As Exception
        End Try

        If Not String.IsNullOrEmpty(TextIcdIn.Text) Then
            If GetDateTime(TextIcdIn.Text.Trim()) > DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD In Date can not be more than current date")
                Functions.ControlFocus(TextIcdIn)
                Return
            End If
        End If

        If Not String.IsNullOrEmpty(TextHandOverDate.Text.Trim) Then
            If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD IN Date is blank")
                Functions.ControlFocus(TextIcdIn)
                Return
            End If
        End If

        If Not String.IsNullOrEmpty(TextIcdIn.Text) Then
            If GetDateTime(TextIcdIn.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(TextIcdIn)
                Return
                Functions.ControlFocus(TextIcdIn)
            End If
        End If
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmdFleetContJo = " UPDATE FLEET_CONT_JO SET LINE_ID=" & lstline.SelectedValue & ",  CONSIGNEE_ID = DECODE(" & LstConsignor.SelectedValue & ",0,CONSIGNEE_ID," & LstConsignor.SelectedValue & ") WHERE CONT_JO_NO ='" & textjoNo.Text & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd111 As New OleDbCommand(cmdFleetContJo, con)
            cmd111.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd10 = " UPDATE FLEET_CONT_JO_DTLS SET FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & ", LINE_ID=" & lstline.SelectedValue & "  WHERE MTY_CONT_ID= " & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd11 As New OleDbCommand(cmd10, con)
            cmd11.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD51 = " UPDATE FLEET_CONT_JO SET TRIP_TYPE='" & lstDocType.SelectedValue & "',  LINE_ID=DECODE(" & lstline.SelectedValue & ",0,LINE_ID," & lstline.SelectedValue & "), TO_LOCATION_ID=" & lstcfs.SelectedValue & " WHERE CONT_JO_NO='" & textjoNo.Text.Trim & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd55 As New OleDbCommand(CMD51, con)
            cmd55.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        ' Try
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET VOYAGE=NVL('" & textVoyage.Text.Trim & "',''), BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'), CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ",PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0), CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "', CARTONS='" & TextPacket.Text & "',PACKAGE_TYPE='" & lslPackageType.SelectedItem.Text & "', GROSS_WT='" & textGrossWt.Text & "', PACKAGE_TYPE_ID='" & lslPackageType.SelectedValue & "',  REQUIRED_ETD=TO_DATE('" & textETD.Text & "','DD/MM/YYYY'),TRAIN_NO=NVL('" & textTrainNo.Text.Trim & "',''),TRAIN_OUT_DATE=TO_DATE('" & textRailout.Text & "','DD/MM/YYYY'),PORT_ARRIVAL=TO_DATE('" & textPortArrival.Text & "','DD/MM/YYYY'), " _
         & " DISCHARGE_DATE=TO_DATE('" & textDischargeDate.Text & "','DD/MM/YYYY'),GATE_OUT_DATE=NVL(TO_DATE('" & textGateoutDate.Text & "','DD/MM/YYYY'),''),EMPTY_GATE_IN_DATE=NVL(TO_DATE('" & textEmptyGateinDate.Text & "','DD/MM/YYYY'),''),LINE_HANDOVER_DATE=NVL(TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'),'') WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim cmd5 As New OleDbCommand(cmd1, con)
        cmd5.ExecuteNonQuery()
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD2 = " Insert into ETD_UPDATE (D_TRACK_ID, CONT_NO, MTY_CONT_ID, REQUIRED_ETD,TRAIN_NO, RAILOUT_DATE,PORT_ARRIVAL_DATE,DISCHARGE_DATE,GATE_OUT_DATE,EMPTY_GATE_IN_DATE, LINE_HANDOVER_DATE, SPJ_CONSIGNOR_ID, SPJ_PARTY_CONSIGNOR,CONSINGEE_NAME, CREATED_BY, CREATED_ON) " _
                     & " VALUES (D_TRACK_ID.NEXTVAL,'" & TextGrno.Text.Trim & "','" & hdnMtyContId.Value & "',NVL(TO_DATE('" & textETD.Text.Trim & "','DD/MM/YYYY'),''),'" & textTrainNo.Text.Trim & "',NVL(TO_DATE('" & textRailout.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & textPortArrival.Text.Trim & "','DD/MM/YYYY'),''), NVL(TO_DATE('" & textDischargeDate.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & textGateoutDate.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & textEmptyGateinDate.Text.Trim & "','DD/MM/YYYY'),'')," _
                     & " NVL(TO_DATE('" & TextHandOverDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),'')," _
                      & LstConsignor.SelectedValue & ",'" & LstConsignor.SelectedItem.Text & "','" & TextConsigneeName.Text & "','" & Session.Item("LoginUser") & "',sysdate) "
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd66 As New OleDbCommand(CMD2, con)
            cmd66.ExecuteNonQuery()
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