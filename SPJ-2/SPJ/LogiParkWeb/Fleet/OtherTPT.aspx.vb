Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_OtherTPT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            '   btnEdit.Visible = False
            btnSave.Visible = False
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
        'btnEdit.Visible = False
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
            cmd5 = "SELECT DISTINCT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='L'  AND ELOGISOL_FLAG='Y' ORDER BY CUSTOMER_NAME"
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

        Catch ex As Exception

        End Try

    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        'btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        ' btnEdit.Visible = pVisible
        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
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
        Try
            lstSize.SelectedValue = pFleetContJoDtls.ContSize
            lstType.SelectedValue = pFleetContJoDtls.ContType
        Catch ex As Exception
        End Try
        textLineSealNo.Text = pFleetContJoDtls.SealNo
        textCustomSeal.Text = pFleetContJoDtls.AgentSeal
        hdnMtyContId.Value = PCodeValue.Value
        hdnJobId.Value = pFleetContJoDtls.ContJoId


        ' pFleetContJoDtls.ContJoId = hdngrId.Value

        Dim pfleet As New FleetContJo
        pfleet.ContJoId = hdnJobId.Value
        FleetContJo.ReturnFleetContJo(pfleet)
        If pFleetContJoDtls.MtyContId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container not booked yet.")
            Return
        End If
        If pfleet.TransporterId <> 109 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Containers not booked For Shipper Accounts.")
            Return
        End If
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
        textAllotmentDate.Text = pFleetContJoDtls.AllotMentDate
        textEmptyGateInDate.Text = pFleetContJoDtls.EmptyGateInDate

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
        textSob.Text = pAllPartyAccount.Sailed
        Try
            LstRemark.SelectedValue = pAllPartyAccount.HoldRemarkId
        Catch ex As Exception
            LstRemark.SelectedValue = 0
        End Try
        Try
            LstConsignor.SelectedValue = pAllPartyAccount.NoOfDays
            hdnConsignor.Value = pAllPartyAccount.NoOfDays
            ' lstcfs.SelectedValue = pAllPartyAccount.CFS
        Catch ex As Exception
            LstConsignor.SelectedValue = 0
        End Try

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
        textShippingBill.Text = pAllPartyAccount.SbNo
        textShippingDate.Text = pAllPartyAccount.SbDate
        TextConsigneeName.Text = pAllPartyAccount.ConsingeeName

        Dim user As Long = 0
        If Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Lokesh Kumar" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Pathak" Or Session.Item("LoginUser") = "superuser" Then
            user = 1
        End If
        If user <> 1 Then
            If hdnLineHandoverDate.Value = 1 Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container Already Handover, Edit Not Allowed.")
                Return
            End If
        End If
        If Session.Item("LoginUser") = "Suresh Rajput" Or Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Lokesh Kumar" Or Session.Item("LoginUser") = "Gaurav Singh" Or Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Pathak" Or Session.Item("LoginUser") = "superuser" Then
            ' TextGrno.Enabled = True
            LstConsignor.Enabled = True
            TextConsigneeName.Enabled = True
            TextPInvNo.Enabled = True
            TextPDate.Enabled = True
            textShippingBill.Enabled = True
            textShippingDate.Enabled = True
            lstBlMethod.Enabled = True
            lstBLStatus.Enabled = True

            textSob.Enabled = True
        End If
        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Then
            TextGrno.Enabled = True
            lstFreeType.Enabled = True
        Else
            TextGrno.Enabled = False
        End If
        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "ADMIN" Then
            lstPol.Enabled = True
            textAllotmentDate.Enabled = True
            lstSize.Enabled = True
            lstType.Enabled = True

        End If
        If Session.Item("LoginUser") = "Akshay" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "Gaurav Singh" Then
            lstPol.Enabled = True
        End If

        If Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Nitin Saini" Or Session.Item("LoginUser") = "Akshay" Then
            TextIcdIn.Enabled = True
            textOutDaTe.Enabled = True
            textAllotmentDate.Enabled = True
            TextBookingNO.Enabled = True
            TextBookingDate.Enabled = True
            btnSave.Visible = True
            btnSave.Enabled = True
        End If


        'TextExRate.Text = pAllPartyAccount.ExRate
        'If Session.Item("LoginUser") = "PUSHPENDRA" Or Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "superuser" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "raj" Or Session.Item("LoginUser") = "ANAMIKA" Or Session.Item("LoginUser") = "RIYA" Then
        '    TextGrno.Enabled = True
        'Else
        '    TextGrno.Enabled = False
        'End If
        'If Session.Item("LoginUser") = "Shanu Thakur" Or Session.Item("LoginUser") = "Robin Singh" Or Session.Item("LoginUser") = "Harendra Singh" Or Session.Item("LoginUser") = "Sanjay Kumar" Or Session.Item("LoginUser") = "Devraj Singh" Or Session.Item("LoginUser") = "anuj" Or Session.Item("LoginUser") = "Anil Chaudhary" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "superuser" Then
        '    TextIcdIn.Enabled = True
        '    textOutDaTe.Enabled = True
        '    lstcfs.Enabled = True
        '    lstline.Enabled = True
        '    lstDocType.Enabled = True

        'Else
        '    TextIcdIn.Enabled = False
        '    textOutDaTe.Enabled = False
        '    lstcfs.Enabled = False
        '    lstline.Enabled = False
        'End If

        'If Session.Item("LoginUser") = "KARKI" Or Session.Item("LoginUser") = "RIYA" Or Session.Item("LoginUser") = "superuser" Then
        '    LstConsignor.Enabled = True
        'End If
        'If Session.Item("LoginUser") = "BEENA ASWAL" Or Session.Item("LoginUser") = "PUSHPENDRA" Or Session.Item("LoginUser") = "REENA" Or Session.Item("LoginUser") = "raj" Or Session.Item("LoginUser") = "TANAJI" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "ANAMIKA" Or Session.Item("LoginUser") = "SHASHI" Or Session.Item("LoginUser") = "RIYA" Then
        TextIcdIn.Enabled = True
        textAllotmentDate.Enabled = True
        textOutDaTe.Enabled = True
        TextHandOverDate.Enabled = True
        TextBlNO.Enabled = True
        lstcfs.Enabled = True
        lstline.Enabled = True
        textLineSealNo.Enabled = True
        textCustomSeal.Enabled = True
        lstConsignmentType.Enabled = True
        LstConsignor.Enabled = True
        lstDocType.Enabled = True
        TextHandOverDate.Enabled = True
        'textCustom.Enabled = True
        'TextBookingNO.Enabled = True
        'TextBookingDate.Enabled = True
        LstRemark.Enabled = True
        textEmptyGateInDate.Enabled = True

        '  ElseIf Session.Item("LoginUser") = "MUKESH" Then
        TextBlNO.Enabled = True
        ' Else
        'TextHandOverDate.Enabled = False
        'TextBlNO.Enabled = False
        'TextBookingNO.Enabled = False
        'TextPInvNo.Enabled = False
        'TextPDate.Enabled = False
        'End If
        'lstPol.Enabled = True
        'If Session.Item("LoginUser") = "RIYA" Or Session.Item("LoginUser") = "raj" Then
        '    LstConsignor.Enabled = True
        '    lststatus.Enabled = True
        '    TextBookingNO.Enabled = True
        '    TextPInvNo.Enabled = True
        '    TextBlNO.Enabled = True
        '    lstcfs.Enabled = True
        '    lstline.Enabled = True
        '    TextPDate.Enabled = False
        'Else
        '    'LstConsignor.Enabled = False
        '    lststatus.Enabled = False
        'End If
        'If Session.Item("LoginUser") = "ROHIT" Or Session.Item("LoginUser") = "RIYA" Or Session.Item("LoginUser") = "RAVINDRA" Then
        '    lstcfs.Enabled = True
        '    lstline.Enabled = True
        '    TextHandOverDate.Enabled = True
        '    TextBlNO.Enabled = True
        '    TextBookingNO.Enabled = True
        '    TextPInvNo.Enabled = True
        '    TextPDate.Enabled = True

        'End If
        'TextBlNO.Enabled = True
        'TextPInvNo.Enabled = True
        'TextPDate.Enabled = True
        'TextBookingNO.Enabled = True
        'TextExRate.Enabled = True
        LstFOD.Enabled = True
        'TextHandOverDate.Enabled = True
        'btnSave.Visible = True
        'btnSave.Enabled = True
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
        pImpInvoice.LineItemId = hdnJobId.Value
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

        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "superuser" Then
            If Session.Item("CompanyId") = 2 Or Session.Item("CompanyId") = 1 Then
                If pImpInvoice.EinvoiceStatus = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Einvoice  Alreday Entered Against Selected Container No , So edit not allow ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
            End If
        Else
            If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "superuser" Then
                If pImpInvoice.PrintStatus = "Y" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice  Alreday Approved Against Selected Container No , So edit not allow ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
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
        End If

        'If Not String.IsNullOrEmpty(textCustom.Text) Then
        '    If GetDateTime(textCustom.Text.Trim()) >= DateTime.Now Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
        '        Functions.ControlFocus(textCustom)
        '        rtnBool = False
        '        Functions.ControlFocus(textCustom)
        '        Return rtnBool
        '        Exit Function
        '    End If
        'End If
        If Not String.IsNullOrEmpty(textEmptyGateInDate.Text) Then
            If GetDateTime(textEmptyGateInDate.Text.Trim()) >= DateTime.Now Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                Functions.ControlFocus(textEmptyGateInDate)
                rtnBool = False
                Functions.ControlFocus(textEmptyGateInDate)
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

        'If Not String.IsNullOrEmpty(TextIcdIn.Text) Then
        '    If GetDateTime(TextIcdIn.Text.Trim()) < GetDateTime(textOutDaTe.Text.Trim()) Then
        '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the ICD In Date not be less than ICD Out Date.")
        '        Functions.ControlFocus(TextIcdIn)
        '        rtnBool = False
        '        Functions.ControlFocus(TextIcdIn)
        '        Return rtnBool
        '        Exit Function
        '    End If
        'End If



        If Session.Item("LoginUser") <> "ADMIN" AndAlso Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
            If String.IsNullOrEmpty(textOutDaTe.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD Out Date is blank ")
                rtnBool = False
                Functions.ControlFocus(textOutDaTe)
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
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Handover Date is blank")
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
            If String.IsNullOrEmpty(TextIcdIn.Text.Trim) Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "ICD IN Date is blank")
                Functions.ControlFocus(TextIcdIn)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If

        'If Session.Item("LoginTerminal") <> 7 Then
        '    If Session.Item("LoginTerminal") <> 29 Then
        '        If Not String.IsNullOrEmpty(textCustom.Text.Trim) Then
        '            If String.IsNullOrEmpty(textShippingBill.Text.Trim) Or String.IsNullOrEmpty(textShippingDate.Text.Trim) Or String.IsNullOrEmpty(TextPDate.Text.Trim) OrElse String.IsNullOrEmpty(TextPInvNo.Text.Trim) Then
        '                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
        '                rtnBool = False
        '                Return rtnBool
        '                Exit Function
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
        'If lstDocType.SelectedItem.Value = "E" Then
        '    If Not String.IsNullOrEmpty(textCustom.Text) Then
        '        If pAllPartyAccount.BookingNo = Nothing Or pAllPartyAccount.BookingDate Is Nothing Or pAllPartyAccount.RequiredVessel Is Nothing Or pAllPartyAccount.POL Is Nothing Then
        '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Documentation Page not updated ")
        '            rtnBool = False
        '            Return rtnBool
        '            Exit Function
        '        End If
        '    End If
        'End If
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
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID='" & lstBLStatus.SelectedValue & "', CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', BL_METHOD='" & lstBlMethod.SelectedItem.Text & "',BL_METHOD_ID='" & lstBlMethod.SelectedValue & "', SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),  TRIP_TYPE='" & lstDocType.SelectedValue & "', BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "',BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ",LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', ICD_GATE_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),ICD_GATE_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI'), HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "' WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            'cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "',BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ",LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), CUSTOMS_HANDOVER_DATE=TO_DATE('" & textCustom.Text & "','DD/MM/YYYY'), PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', ICD_GATE_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),ICD_GATE_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI'), HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "' WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd5 As New OleDbCommand(cmd1, con)
            cmd5.ExecuteNonQuery()
        Catch ex As Exception
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmdFleetContJo = " UPDATE FLEET_CONT_JO SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', CONSIGNEE_ID = DECODE(" & LstConsignor.SelectedValue & ",0,CONSIGNEE_ID," & LstConsignor.SelectedValue & ") WHERE CONT_JO_NO ='" & textjoNo.Text & "'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd111 As New OleDbCommand(cmdFleetContJo, con)
            cmd111.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd10 = " UPDATE FLEET_CONT_JO_DTLS SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', CONT_NO='" & TextGrno.Text.Trim & "', TRIP_TYPE='" & lstDocType.SelectedValue & "', SEAL_NO='" & textLineSealNo.Text.Trim & "', AGENT_SEAL='" & textCustomSeal.Text.Trim & "', FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & ", LINE_ID=" & lstline.SelectedValue & ",ICD_OUT_DATE=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),EMPTYGATE_IN_DATE=TO_DATE('" & textEmptyGateInDate.Text & "','DD/MM/YYYY HH24:MI'),ALLOTMENT_DATE=TO_DATE('" & textAllotmentDate.Text & "','DD/MM/YYYY HH24:MI'),ICD_IN_DATE=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI') WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd11 As New OleDbCommand(cmd10, con)
            cmd11.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
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
            cmd = " UPDATE FLEET_VEHICLE_STATUS SET CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "', TRIP_TYPE='" & lstDocType.SelectedValue & "', ICD_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),ICD_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI') WHERE  GR_ID= " & hdngrId.Value & ""
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
            CMD2 = " UPDATE FLEET_GR_MAPPING SET CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', TRIP_TYPE='" & lstDocType.SelectedValue & "',FACTORY_LOCATION=DECODE(" & lstcfs.SelectedValue & ",0,FACTORY_LOCATION,'" & lstcfs.SelectedItem.Text & "'),CONT_NO='" & TextGrno.Text.Trim & "-" & textjoNo.Text.Trim & "',LINE_ID=" & lstline.SelectedValue & ",CHA_ID=" & lstcfs.SelectedValue & ", FPOD=" & LstFOD.SelectedValue & ",POL=" & lstPol.SelectedValue & " WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd4 As New OleDbCommand(CMD2, con)
            cmd4.ExecuteNonQuery()
        Catch ex As Exception
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID='" & lstBLStatus.SelectedValue & "', CONT_SIZE='" & lstSize.SelectedItem.Text & "',CONT_TYPE='" & lstType.SelectedItem.Text & "', BL_METHOD='" & lstBlMethod.SelectedItem.Text & "',BL_METHOD_ID='" & lstBlMethod.SelectedValue & "', SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),  TRIP_TYPE='" & lstDocType.SelectedValue & "', BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "',BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ",LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY HH24:MI'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', ICD_GATE_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),ICD_GATE_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI'),HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "' WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            'cmd1 = " UPDATE ALL_PARTY_ACCOUNT SET SB_NO=DECODE('" & textShippingBill.Text.Trim & "','',SB_NO,'" & textShippingBill.Text.Trim & "'),BOOKING_DATE=TO_DATE('" & TextBookingDate.Text & "','DD/MM/YYYY'),SB_DATE=TO_DATE('" & textShippingDate.Text & "','DD/MM/YYYY'),CONSIGNOR_ID=" & LstConsignor.SelectedValue & ",CONSIGNOR_NAME='" & LstConsignor.SelectedItem.Text & "',SHIPMENT_STATUS=NVL(" & lststatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lststatus.SelectedItem.Text & "',''),CONSINGEE_NAME='" & TextConsigneeName.Text.Trim & "',BOOKING_NO=DECODE('" & TextBookingNO.Text.Trim & "','',BOOKING_NO,'" & TextBookingNO.Text.Trim & "'),CONT_NO='" & TextGrno.Text.Trim & "',CFS_ID=" & lstcfs.SelectedValue & ",CFS=DECODE(" & lstcfs.SelectedValue & ",0,CFS,'" & lstcfs.SelectedItem.Text & "'), LINE=DECODE(" & lstline.SelectedValue & ",0,LINE,'" & lstline.SelectedItem.Text & "'), POL='" & lstPol.SelectedItem.Text & "', POL_ID=" & lstPol.SelectedValue & ",LINE_HANDOVER_DATE=TO_DATE('" & TextHandOverDate.Text & "','DD/MM/YYYY'), SAILED=TO_DATE('" & textSob.Text & "','DD/MM/YYYY'), CUSTOMS_HANDOVER_DATE=TO_DATE('" & textCustom.Text & "','DD/MM/YYYY'), PORT=NVL('" & LstFOD.SelectedItem.Text & "',''),POD_ID=NVL(" & LstFOD.SelectedValue & ",0),BL_NO=NVL('" & TextBlNO.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPInvNo.Text.Trim & "',''),PARTY_INV_DATE=NVL(TO_DATE('" & TextPDate.Text & "','DD/MM/YYYY HH24:MI'),''), CONSIGNMENT_TYPE= '" & lstConsignmentType.SelectedItem.Text & "', CONSIGNMENT_TYPE_ID= '" & lstConsignmentType.SelectedValue & "', ICD_GATE_OUT=TO_DATE('" & textOutDaTe.Text & "','DD/MM/YYYY HH24:MI'),ICD_GATE_IN=TO_DATE('" & TextIcdIn.Text & "','DD/MM/YYYY HH24:MI'),HOLD_REMARK_ID= '" & LstRemark.SelectedValue & "', HOLD_REMARK= '" & LstRemark.SelectedItem.Text & "' WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
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
            'lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD101 = " Insert into SHIPPER_MAINTENANCE (SHIPPER_TRACK_ID, COMPANY_ID, TERMINAL_ID, CONT_NO,CONT_SIZE,CONT_TYPE, MTY_CONT_ID,ALLOTMENT_DATE, ICD_OUT_DATE,ICD_IN_DATE,EMPTYGATE_IN_DATE, LINE_HANDOVER_DATE, PARTY_INV_NO, PARTY_INV_DATE,SB_NO, SB_DATE,BL_NO, BOOKING_NO,BOOKING_DATE, CFS_ID, CFS, LINE_ID, " _
                     & " LINE, POL_ID, POL, POD_ID, PORT,CONSINGEE_NAME,CONSIGNMENT_TYPE, SHIPPER_ID, SHIPPER_NAME, CREATED_BY, CREATED_ON,LINE_SEAL,CUSTOM_SEAL,REMARK_ID,BL_METHOD,BL_METHOD_ID) " _
                     & " VALUES (SHIPPER_TRACK_ID.NEXTVAL," & Session.Item("CompanyId") & ",  " & Session.Item("LoginTerminal") & ",'" & TextGrno.Text.Trim & "','" & lstSize.SelectedItem.Text & "','" & lstType.SelectedItem.Text & "','" & hdnMtyContId.Value & "',NVL(TO_DATE('" & textAllotmentDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textOutDaTe.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextIcdIn.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & textEmptyGateInDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''), " _
                     & " NVL(TO_DATE('" & TextHandOverDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextPInvNo.Text.Trim & "',NVL(TO_DATE('" & TextPDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & textShippingBill.Text.Trim & "',NVL(TO_DATE('" & textShippingDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & TextBlNO.Text.Trim & "','" & TextBookingNO.Text.Trim & "',NVL(TO_DATE('" & TextBookingDate.Text.Trim & "','DD/MM/YYYY'),''), " _
                     & " " & lstcfs.SelectedValue & ",'" & lstcfs.SelectedItem.Text & "'," & lstline.SelectedValue & ",'" & lstline.SelectedItem.Text & "'," & lstPol.SelectedValue & ",'" & lstPol.SelectedItem.Text & "', " _
                     & " " & LstFOD.SelectedValue & ",'" & LstFOD.SelectedItem.Text & "','" & TextConsigneeName.Text & "'," _
                     & " '" & lstConsignmentType.SelectedItem.Text & "'," & LstConsignor.SelectedValue & ",'" & LstConsignor.SelectedItem.Text & "','" & Session.Item("LoginUser") & "',sysdate, '" & textLineSealNo.Text.Trim & "','" & textCustomSeal.Text.Trim & "', '" & LstRemark.SelectedValue & "','" & lstBlMethod.SelectedItem.Text & "','" & lstBlMethod.SelectedValue & "') "
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd99 As New OleDbCommand(CMD101, con)
            cmd99.ExecuteNonQuery()
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