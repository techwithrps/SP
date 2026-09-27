Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_AllPartyAccount
    Inherits System.Web.UI.Page
    Dim rows As Integer = 5
    Dim count As Integer = 0
    Dim addrows As Integer = 2
    Dim glLine As ArrayList
    Dim glIsoCode As ArrayList
    Private PageSize As Integer = 10

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            manageUserControls(True)
            ButtonControlSetup(True)
            btnAdd.Visible = True
            manageUserControls(False)
            ButtonControlSetup(False)
            btnNewRows.Visible = True
            tblCont.Visible = False
            btnNewRows.Visible = False
            btnSearch.Visible = True
            repBookingContDeatils.Visible = True
            'Dim pFCJ As New AllPartyAccount
            'fillRepeator(AllPartyAccount.ReturnAllPartyAccountList(pFCJ))
            'manageUserControls(True)
            btnEdit.Visible = True
            'repBookingContDeatils.Visible = True
            '            'Me.GetCustomersPageWise(1)
            '            ' Dim con As OleDbConnection
            '            Dim strConnectionString, cmd1, cmd2, cmd3, cmd4, cmd5 As String
            '            Dim ada As New OleDbDataAdapter
            '            Dim con As OleDbConnection
            '            Dim pageds As New PagedDataSource()
            '            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            '            cmd1 = "SELECT TRACK_ID, DECODE(SHIPPER_NAME,NULL,(SELECT CUSTOMER_NAME FROM CUSTOMER_MASTER CM WHERE CM.CUSTOMER_ID=GR.CUSTOMER_ID),SHIPPER_NAME)SHIPPER_NAME," _
            '               & " DECODE(CONSINGEE_NAME,NULL,(SELECT COMPANY_NAME FROM COMPANY_MASTER CM WHERE CM.COMPANY_ID=GR.COMPANY_ID),CONSINGEE_NAME)CONSINGEE_NAME, " _
            '& " NOTIFY_PARTY, LOT, HEALTH_CERTIFICATE_NO, TO_CHAR(HEALTH_CERTIFICATE_DATE,'DD/MM/YYYY HH24:MI') AS HEALTH_CERTIFICATE_DATE, SELF_EXCISE, " _
            '               & " PARTY_INV_NO, TO_CHAR(PARTY_INV_DATE,'DD/MM/YYYY HH24:MI') AS PARTY_INV_DATE,  SB_NO, TO_CHAR(SB_DATE,'DD/MM/YYYY HH24:MI') AS SB_DATE, " _
            '               & " TO_CHAR(CUSTOMS_HANDOVER_DATE,'DD/MM/YYYY HH24:MI') AS CUSTOMS_HANDOVER_DATE, " _
            '               & " TO_CHAR(LINE_HANDOVER_DATE,'DD/MM/YYYY HH24:MI') AS LINE_HANDOVER_DATE,SB_RECEIVED,CARTONS, NET_WT, GROSS_WT, " _
            '               & " TARE_WT,VGM_WT,VGM_SUBMITTED,SHIPMENT_TYPE,FOB_VALUE_INR, EX_RATE, FOB_VALUE_USD,CNF_USD,UNITS, " _
            '               & " APA.CONT_NO, APA.CONT_SIZE,APA.CONT_TYPE, TO_CHAR(ICD_GATE_OUT,'DD/MM/YYYY HH24:MI') AS ICD_GATE_OUT, " _
            '               & " TO_CHAR(ICD_GATE_IN,'DD/MM/YYYY HH24:MI') AS ICD_GATE_IN, PORT,COUNTRY,REGION,LINE, " _
            '               & " CHA, PDA_ACCOUNT, BOOKING_NO, BL_NO,FOLLOW_UP,BL_REMARKS, SOB, TO_CHAR(SAILED,'DD/MM/YYYY HH24:MI') AS SAILED," _
            '               & " BL_STATUS, LINE_INVOICE,REQUIRED_GST, SPECIAL_COMMENTS,LINER_INV_NO,TO_CHAR(LINER_INV_DATE,'DD/MM/YYYY HH24:MI') AS LINER_INV_DATE, " _
            '               & " TO_CHAR(LINER_DUE_DATE,'DD/MM/YYYY HH24:MI') AS LINER_DUE_DATE, AGEING, BASE_FRT_USD,OTHER_CHARGES_USD, " _
            '               & " TOTAL_FRT_USD,FRT_EX_RATE,FRT_GST,AMOUNT_INR, LINE_THC, PORT_THC,ORIGIN_THC,RAILFREIGHT, " _
            '               & " DOC_CHARGES,MISC_CHARGES, IGST, CGST, SGST,  LINE_CHEQUE_NO,  TO_CHAR(LINE_CHEQUE_DATE,'DD/MM/YYYY HH24:MI') AS LINE_CHEQUE_DATE, " _
            '               & " LINE_CHEQUE_AMOUNT, PAYMENT_REMARKS, OBL_STATUS, TO_CHAR(OBL_ISSUE_DATE,'DD/MM/YYYY HH24:MI') AS OBL_ISSUE_DATE, " _
            '               & " TRAIN_NO, TO_CHAR(TRAIN_OUT_DATE,'DD/MM/YYYY HH24:MI') AS TRAIN_OUT_DATE, TO_CHAR(PORT_ARRIVAL,'DD/MM/YYYY HH24:MI') AS PORT_ARRIVAL, " _
            '               & " NO_OF_DAYS, OBL_ISSUE_NO, TO_CHAR(REQUIRED_ETD,'DD/MM/YYYY HH24:MI') AS REQUIRED_ETD,  REQUIRED_VESSEL, " _
            '               & " TO_CHAR(CURRENT_ETD,'DD/MM/YYYY HH24:MI') AS CURRENT_ETD, CURRENT_VESSEL,SAILED_SOB, " _
            '               & " TO_CHAR(CURRENT_ETA,'DD/MM/YYYY HH24:MI') AS CURRENT_ETA,TRANSIT_TIME, SHIPMENT_STATUS, SURRENDER_INV_NO, " _
            '               & " SURRENDER_INV_AMOUNT,SURRENDER_INV_PAYMENT,SURRENDER_INV_STATUS,APA.CREATED_BY, " _
            '               & " TO_CHAR(APA.CREATED_ON,'DD/MM/YYYY HH24:MI') AS CREATED_ON, APA.MTY_CONT_ID  FROM ALL_PARTY_ACCOUNT APA, FLEET_GR_MAPPING GR " _
            '               & " where APA.GR_ID = GR.GR_ID and track_id is not null"
            '            con = New OleDbConnection(strConnectionString)
            '            con.Open()
            '            ada = New OleDbDataAdapter(cmd1, con)
            '            Dim ds As New DataSet("Customer")
            '            ada.Fill(ds, "t1")



            '            pageds.DataSource = ds.Tables("t1").DefaultView
            '            pageds.AllowPaging = True
            '            pageds.PageSize = 4
            '            Dim curpage As Integer

            '            If Not IsNothing(Request.QueryString("Page")) Then
            '                curpage = Convert.ToInt32(Request.QueryString("Page"))
            '            Else
            '                curpage = 1
            '            End If

            '            pageds.CurrentPageIndex = curpage - 1
            '            lblCurrpage.Text = "Page: " + curpage.ToString()

            '            If Not pageds.IsFirstPage Then
            '                lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + CStr(curpage - 1)
            '            End If

            '            If Not pageds.IsLastPage Then
            '                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath +  "?Page=" + CStr(curpage + 1)
            '            End If
            '            Dim pFCJ As New AllPartyAccount

            '            fillRepeator(AllPartyAccount.ReturnAllPartyAccountList(pFCJ))
            '            repBookingContDeatils.DataSource = pageds
            '            repBookingContDeatils.DataBind()
        End If
    End Sub


    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - arr.Count - 1
                Dim p As New AllPartyAccount
                p.Line = 0
               
                arr.Add(p)
            Next
        End If
        repBookingContDeatils.DataSource = arr
        repBookingContDeatils.DataBind()

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


    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        btnAdd.Visible = False
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        'btnEditContDetail.Visible = pVisible
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

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim isContNo As Integer = 0

        If repBookingContDeatils.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textContNo, textCont1 As TextBox
            Dim lstContSize, lstContType As DropDownList
            For Each rep1 In repBookingContDeatils.Items
                textContNo = rep1.FindControl("textContNo")
                lstContSize = rep1.FindControl("lstSize")
                lstContType = rep1.FindControl("lstType")

                If textContNo.Text.Trim <> Nothing Then


                End If

                For Each rep2 In repBookingContDeatils.Items
                    textCont1 = rep2.FindControl("textContNo")
                    If textCont1.Text <> Nothing Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            isContNo += 1
                            'If textContNo.Text = textCont1.Text Then
                            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBcdContNo.Text & " is Duplicate.")
                            '    rtnBool = False
                            '    Functions.ControlFocus(textContNo)
                            '    Return rtnBool
                            '    Exit Function
                            'End If
                        End If

                    End If
                Next
            Next
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtAllPartyAccount As ExtAllPartyAccount = ReturnObject()
        ExtAllPartyAccount.InsertUpdateAllPartyAccount(pExtAllPartyAccount)

        If pExtAllPartyAccount.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtAllPartyAccount.Errormsg)
            ' Functions.ControlFocus(lstDocType)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
        btnNewRows.Visible = False
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

    Private Function ReturnObject() As ExtAllPartyAccount
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContDtlsList = New ArrayList

        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then

                Try
                    pExtAllPartyAccount.TrackId = CType(rep.FindControl("hdnTrackId"), HiddenField).Value
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ShipperName = CType(rep.FindControl("textShipperName"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ConsingeeName = CType(rep.FindControl("textConsingeeName"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.NotifyParty = CType(rep.FindControl("textNotifyParty"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Lot = CType(rep.FindControl("textLot"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Lot = CType(rep.FindControl("textLot"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.HealthCertificateNo = CType(rep.FindControl("textHealthCertificateNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.HealthCertificateDate = CType(rep.FindControl("textHealthCertificateDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.HealthCertificateDate = CType(rep.FindControl("textHealthCertificateDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SelfExcise = CType(rep.FindControl("textSelfExcise"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PartyInvNo = CType(rep.FindControl("textPartyInvoiceNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PartyInvDate = CType(rep.FindControl("textPartyInvDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SbNo = CType(rep.FindControl("textSbNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SbDate = CType(rep.FindControl("textSbDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CustomsHandoverDate = CType(rep.FindControl("textCustomsHandoverDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineHandoverDate = CType(rep.FindControl("textLineHandoverDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SbReceived = CType(rep.FindControl("textSbReceived"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Cartons = CType(rep.FindControl("textCartons"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.NetWt = CType(rep.FindControl("textNetWt"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.GrossWt = CType(rep.FindControl("textGrossWt"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.TareWt = CType(rep.FindControl("textTareWt"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.VgmWt = CType(rep.FindControl("textVgmWt"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.VgmSubmitted = CType(rep.FindControl("textVgmSubmitted"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ShipmentType = CType(rep.FindControl("textShipmentType"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.FobValueInr = CType(rep.FindControl("textFobValueInr"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ExRate = CType(rep.FindControl("textExRate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.FobValueUsd = CType(rep.FindControl("textFobValueUsd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CnfUsd = CType(rep.FindControl("textCnfUsd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Units = CType(rep.FindControl("textUnits"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ContNo = CType(rep.FindControl("textContNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ContSize = CType(rep.FindControl("textContSize"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ContType = CType(rep.FindControl("textContType"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.IcdGateOut = CType(rep.FindControl("textIcdGateOut"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.IcdGateIn = CType(rep.FindControl("textIcdGateIn"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Port = CType(rep.FindControl("textPort"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Country = CType(rep.FindControl("textCountry"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Region = CType(rep.FindControl("textRegion"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Line = CType(rep.FindControl("textLine"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Cha = CType(rep.FindControl("textCha"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PdaAccount = CType(rep.FindControl("textPdaAccount"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.BookingNo = CType(rep.FindControl("textBookingNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.BlNo = CType(rep.FindControl("textBlno"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.FollowUp = CType(rep.FindControl("textFollowUp"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.BlRemarks = CType(rep.FindControl("textBlRemarks"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Sob = CType(rep.FindControl("textSob"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Sailed = CType(rep.FindControl("textSailed"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.BlStatus = CType(rep.FindControl("textBlStatus"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineInvoice = CType(rep.FindControl("textLineInvoice"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.RequiredGst = CType(rep.FindControl("textRequiredGst"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SpecialComments = CType(rep.FindControl("textSpecialComments"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LinerInvNo = CType(rep.FindControl("textLinerInvNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LinerInvDate = CType(rep.FindControl("textLinerInvDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LinerDueDate = CType(rep.FindControl("textLinerDueDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Ageing = CType(rep.FindControl("textAgeing"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.BaseFrtUsd = CType(rep.FindControl("textBaseFrtUsd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.OtherChargesUsd = CType(rep.FindControl("textOtherChargesUsd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.TotalFrtUsd = CType(rep.FindControl("textTotalFrtUsd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.FrtExRate = CType(rep.FindControl("textFrtExRate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.FrtGst = CType(rep.FindControl("textFrtGst"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.AmountInr = CType(rep.FindControl("textAmountInr"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineThc = CType(rep.FindControl("textLineThc"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PortThc = CType(rep.FindControl("textPortThc"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.OriginThc = CType(rep.FindControl("textOriginThc"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Railfreight = CType(rep.FindControl("textRailfreight"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.DocCharges = CType(rep.FindControl("textDocCharges"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.MiscCharges = CType(rep.FindControl("textMiscCharges"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Igst = CType(rep.FindControl("textIgst"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Cgst = CType(rep.FindControl("textCgst"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.Sgst = CType(rep.FindControl("textSgst"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineChequeNo = CType(rep.FindControl("textLineChequeNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineChequeDate = CType(rep.FindControl("textLineChequeDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.LineChequeAmount = CType(rep.FindControl("textLineChequeAmount"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PaymentRemarks = CType(rep.FindControl("textPaymentRemarks"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.OblStatus = CType(rep.FindControl("textOblStatus"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.OblIssueDate = CType(rep.FindControl("textOblIssueDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.TrainNo = CType(rep.FindControl("textTrainNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.TrainOutDate = CType(rep.FindControl("textTrainOutDate"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.PortArrival = CType(rep.FindControl("textPortArrival"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.NoOfDays = CType(rep.FindControl("textNoOfDays"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.OblIssueNo = CType(rep.FindControl("textOblIssueNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.RequiredEtd = CType(rep.FindControl("textRequiredEtd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.RequiredVessel = CType(rep.FindControl("textRequiredVessel"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CurrentEtd = CType(rep.FindControl("textCurrentEtd"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CurrentVessel = CType(rep.FindControl("textCurrentVessel"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SailedSob = CType(rep.FindControl("textSailedSob"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CurrentEta = CType(rep.FindControl("textCurrentEta"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.TransitTime = CType(rep.FindControl("textTransitTime"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.ShipmentStatus = CType(rep.FindControl("textShipmentStatus"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SurrenderInvNo = CType(rep.FindControl("textSurrenderInvNo"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SurrenderInvAmount = CType(rep.FindControl("textSurrenderInvAmount"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SurrenderInvPayment = CType(rep.FindControl("textSurrenderInvPayment"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.SurrenderInvStatus = CType(rep.FindControl("textSurrenderInvStatus"), TextBox).Text
                Catch ex As Exception
                End Try

                Try
                    pExtAllPartyAccount.CreatedBy = CType(rep.FindControl("textCreatedBy"), TextBox).Text
                Catch ex As Exception
                End Try
                pExtAllPartyAccount.ContDtlsList.Add(pExtAllPartyAccount)
            End If
        Next
        Return pExtAllPartyAccount
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(False)
        ButtonControlSetup(False)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("hdnTrackId"), HiddenField).Value > 0 Then
                '    CType(rep.FindControl("chkSelect"), CheckBox).Enabled = False
                '    CType(rep.FindControl("textShipperName"), TextBox).Enabled = False
                '    CType(rep.FindControl("textConsingeeName"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLot"), TextBox).Enabled = False
                '    CType(rep.FindControl("textHealthCertificateNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textHealthCertificateDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSelfExcise"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTareWt"), TextBox).Enabled = False
                '    CType(rep.FindControl("textPartyInvDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSbNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSbDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCustomsHandoverDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineHandoverDate"), TextBox).Enabled = False
                '    ' CType(rep.FindControl("textSbReceived"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCartons"), TextBox).Enabled = False
                '    CType(rep.FindControl("textNetWt"), TextBox).Enabled = False
                '    CType(rep.FindControl("textGrossWt"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTareWt1"), TextBox).Enabled = False
                '    CType(rep.FindControl("textVgmWt"), TextBox).Enabled = False
                '    CType(rep.FindControl("textVgmSubmitted"), TextBox).Enabled = False
                '    CType(rep.FindControl("textShipmentType"), TextBox).Enabled = False
                '    CType(rep.FindControl("textFobValueInr"), TextBox).Enabled = False
                '    CType(rep.FindControl("textExRate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textFobValueUsd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCnfUsd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textUnits"), TextBox).Enabled = False
                '    CType(rep.FindControl("textContNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textContSize"), TextBox).Enabled = False
                '    CType(rep.FindControl("textContType"), TextBox).Enabled = False
                '    CType(rep.FindControl("textIcdGateOut"), TextBox).Enabled = False
                '    CType(rep.FindControl("textIcdGateIn"), TextBox).Enabled = False
                '    CType(rep.FindControl("textPort"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCountry"), TextBox).Enabled = False
                '    CType(rep.FindControl("textRegion"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLine"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCha"), TextBox).Enabled = False
                '    CType(rep.FindControl("textBookingNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textBlno"), TextBox).Enabled = False
                '    CType(rep.FindControl("textFollowUp"), TextBox).Enabled = False
                '    CType(rep.FindControl("textBlRemarks"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSOB"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSailed"), TextBox).Enabled = False
                '    CType(rep.FindControl("textBlStatus"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineInvoice"), TextBox).Enabled = False
                '    CType(rep.FindControl("textRequiredGst"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSpecialComments"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLinerInvNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLinerInvDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLinerDueDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textAgeing"), TextBox).Enabled = False
                '    CType(rep.FindControl("textBaseFrtUsd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textOtherChargesUsd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTotalFrtUsd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textFrtExRate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textFrtGst"), TextBox).Enabled = False
                '    CType(rep.FindControl("textAmountInr"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineThc"), TextBox).Enabled = False
                '    CType(rep.FindControl("textPortThc"), TextBox).Enabled = False
                '    CType(rep.FindControl("textOriginThc"), TextBox).Enabled = False
                '    CType(rep.FindControl("textRailfreight"), TextBox).Enabled = False
                '    CType(rep.FindControl("textDocCharges"), TextBox).Enabled = False
                '    CType(rep.FindControl("textMiscCharges"), TextBox).Enabled = False
                '    CType(rep.FindControl("textIgst"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCgst"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSgst"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineChequeNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineChequeDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textLineChequeAmount"), TextBox).Enabled = False
                '    CType(rep.FindControl("textPaymentRemarks"), TextBox).Enabled = False
                '    CType(rep.FindControl("textOblStatus"), TextBox).Enabled = False
                '    CType(rep.FindControl("textOblIssueDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTrainNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTrainOutDate"), TextBox).Enabled = False
                '    CType(rep.FindControl("textPortArrival"), TextBox).Enabled = False
                '    CType(rep.FindControl("textNoOfDays"), TextBox).Enabled = False
                '    CType(rep.FindControl("textOblIssueNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textRequiredEtd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textRequiredVessel"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCurrentEtd"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCurrentVessel"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSailedSob"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCurrentEta"), TextBox).Enabled = False
                '    CType(rep.FindControl("textTransitTime"), TextBox).Enabled = False
                '    CType(rep.FindControl("textShipmentStatus"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSurrenderInvNo"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSurrenderInvAmount"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSurrenderInvPayment"), TextBox).Enabled = False
                '    CType(rep.FindControl("textSurrenderInvStatus"), TextBox).Enabled = False
                '    CType(rep.FindControl("textCreatedBy"), TextBox).Enabled = False
                'Else
                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
                CType(rep.FindControl("textShipperName"), TextBox).Enabled = True
                CType(rep.FindControl("textConsingeeName"), TextBox).Enabled = True
                CType(rep.FindControl("textLot"), TextBox).Enabled = True
                CType(rep.FindControl("textContNo"), TextBox).Enabled = True
                CType(rep.FindControl("textHealthCertificateNo"), TextBox).Enabled = True
                CType(rep.FindControl("textHealthCertificateDate"), TextBox).Enabled = True
                CType(rep.FindControl("textSelfExcise"), TextBox).Enabled = True
                CType(rep.FindControl("textTareWt"), TextBox).Enabled = True
                CType(rep.FindControl("textPartyInvDate"), TextBox).Enabled = True
                CType(rep.FindControl("textSbNo"), TextBox).Enabled = True
                CType(rep.FindControl("textSbDate"), TextBox).Enabled = True
                CType(rep.FindControl("textCustomsHandoverDate"), TextBox).Enabled = True
                CType(rep.FindControl("textLineHandoverDate"), TextBox).Enabled = True
                CType(rep.FindControl("textSbReceived"), TextBox).Enabled = True
                CType(rep.FindControl("textCartons"), TextBox).Enabled = True
                CType(rep.FindControl("textNetWt"), TextBox).Enabled = True
                CType(rep.FindControl("textGrossWt"), TextBox).Enabled = True
                CType(rep.FindControl("textTareWt1"), TextBox).Enabled = True
                CType(rep.FindControl("textVgmWt"), TextBox).Enabled = True
                CType(rep.FindControl("textVgmSubmitted"), TextBox).Enabled = True
                CType(rep.FindControl("textShipmentType"), TextBox).Enabled = True
                CType(rep.FindControl("textFobValueInr"), TextBox).Enabled = True
                CType(rep.FindControl("textExRate"), TextBox).Enabled = True
                CType(rep.FindControl("textFobValueUsd"), TextBox).Enabled = True
                CType(rep.FindControl("textCnfUsd"), TextBox).Enabled = True
                CType(rep.FindControl("textUnits"), TextBox).Enabled = True
                CType(rep.FindControl("textContNo"), TextBox).Enabled = True
                CType(rep.FindControl("textContSize"), TextBox).Enabled = True
                CType(rep.FindControl("textContType"), TextBox).Enabled = True
                CType(rep.FindControl("textIcdGateOut"), TextBox).Enabled = True
                CType(rep.FindControl("textIcdGateIn"), TextBox).Enabled = True
                CType(rep.FindControl("textPort"), TextBox).Enabled = True
                CType(rep.FindControl("textCountry"), TextBox).Enabled = True
                CType(rep.FindControl("textRegion"), TextBox).Enabled = True
                CType(rep.FindControl("textLine"), TextBox).Enabled = True
                CType(rep.FindControl("textCha"), TextBox).Enabled = True
                CType(rep.FindControl("textBookingNo"), TextBox).Enabled = True
                CType(rep.FindControl("textBlno"), TextBox).Enabled = True
                CType(rep.FindControl("textFollowUp"), TextBox).Enabled = True
                CType(rep.FindControl("textBlRemarks"), TextBox).Enabled = True
                CType(rep.FindControl("textSOB"), TextBox).Enabled = True
                CType(rep.FindControl("textSailed"), TextBox).Enabled = True
                CType(rep.FindControl("textBlStatus"), TextBox).Enabled = True
                CType(rep.FindControl("textLineInvoice"), TextBox).Enabled = True
                CType(rep.FindControl("textRequiredGst"), TextBox).Enabled = True
                CType(rep.FindControl("textSpecialComments"), TextBox).Enabled = True
                CType(rep.FindControl("textLinerInvNo"), TextBox).Enabled = True
                CType(rep.FindControl("textLinerInvDate"), TextBox).Enabled = True
                CType(rep.FindControl("textLinerDueDate"), TextBox).Enabled = True
                CType(rep.FindControl("textAgeing"), TextBox).Enabled = True
                CType(rep.FindControl("textBaseFrtUsd"), TextBox).Enabled = True
                CType(rep.FindControl("textOtherChargesUsd"), TextBox).Enabled = True
                CType(rep.FindControl("textTotalFrtUsd"), TextBox).Enabled = True
                CType(rep.FindControl("textFrtExRate"), TextBox).Enabled = True
                CType(rep.FindControl("textFrtGst"), TextBox).Enabled = True
                CType(rep.FindControl("textAmountInr"), TextBox).Enabled = True
                CType(rep.FindControl("textLineThc"), TextBox).Enabled = True
                CType(rep.FindControl("textPortThc"), TextBox).Enabled = True
                CType(rep.FindControl("textOriginThc"), TextBox).Enabled = True
                CType(rep.FindControl("textRailfreight"), TextBox).Enabled = True
                CType(rep.FindControl("textDocCharges"), TextBox).Enabled = True
                CType(rep.FindControl("textMiscCharges"), TextBox).Enabled = True
                CType(rep.FindControl("textIgst"), TextBox).Enabled = True
                CType(rep.FindControl("textCgst"), TextBox).Enabled = True
                CType(rep.FindControl("textSgst"), TextBox).Enabled = True
                CType(rep.FindControl("textLineChequeNo"), TextBox).Enabled = True
                CType(rep.FindControl("textLineChequeDate"), TextBox).Enabled = True
                CType(rep.FindControl("textLineChequeAmount"), TextBox).Enabled = True
                CType(rep.FindControl("textPaymentRemarks"), TextBox).Enabled = True
                CType(rep.FindControl("textOblStatus"), TextBox).Enabled = True
                CType(rep.FindControl("textOblIssueDate"), TextBox).Enabled = True
                CType(rep.FindControl("textTrainNo"), TextBox).Enabled = True
                CType(rep.FindControl("textTrainOutDate"), TextBox).Enabled = True
                CType(rep.FindControl("textPortArrival"), TextBox).Enabled = True
                CType(rep.FindControl("textNoOfDays"), TextBox).Enabled = True
                CType(rep.FindControl("textOblIssueNo"), TextBox).Enabled = True
                CType(rep.FindControl("textRequiredEtd"), TextBox).Enabled = True
                CType(rep.FindControl("textRequiredVessel"), TextBox).Enabled = True
                CType(rep.FindControl("textCurrentEtd"), TextBox).Enabled = True
                CType(rep.FindControl("textCurrentVessel"), TextBox).Enabled = True
                CType(rep.FindControl("textSailedSob"), TextBox).Enabled = True
                CType(rep.FindControl("textCurrentEta"), TextBox).Enabled = True
                CType(rep.FindControl("textTransitTime"), TextBox).Enabled = True
                CType(rep.FindControl("textShipmentStatus"), TextBox).Enabled = True
                CType(rep.FindControl("textSurrenderInvNo"), TextBox).Enabled = True
                CType(rep.FindControl("textSurrenderInvAmount"), TextBox).Enabled = True
                CType(rep.FindControl("textSurrenderInvPayment"), TextBox).Enabled = True
                CType(rep.FindControl("textSurrenderInvStatus"), TextBox).Enabled = True
                CType(rep.FindControl("textCreatedBy"), TextBox).Enabled = True
            End If
        Next
        btnSave.Visible = True
        btnCancel.Visible = True
        btnEdit.Visible = False
        btnExit.Visible = False
        btnDelete.Visible = True

        Dim pAllPartyAccount As New AllPartyAccount
        fillRepeator(AllPartyAccount.ReturnAllPartyAccountList(pAllPartyAccount))
        'manageUserControls(True)
        btnSearch.Visible = False
        btnEdit.Visible = True
        tblCont.Visible = True
    End Sub

    'Protected Sub rcRepDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repBookingContDeatils.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        If repBookingContDeatils.Items.Count > 0 Then
    '            Dim rep1, rep2 As RepeaterItem
    '            Dim texBookingNo As TextBox
    '            For Each rep1 In repBookingContDeatils.Items
    '                texBookingNo = rep1.FindControl("BookingNo")

    '                If texBookingNo.Text.Trim <> Nothing Then

    '                    Dim texBookingNo1 As TextBox
    '                    For Each rep2 In repBookingContDeatils.Items
    '                        texBookingNo1 = rep2.FindControl("BookingNo")
    '                        If texBookingNo.Text <> "" AndAlso texBookingNo1.Text <> "" Then
    '                            If rep1.ItemIndex <> rep2.ItemIndex Then
    '                                If texBookingNo.Text = texBookingNo1.Text Then
    '                                    texBookingNo1.BackColor = Drawing.Color.Black
    '                                End If
    '                            End If
    '                        End If
    '                    Next

    '                End If
    '            Next
    '        End If
    '    End If
    'End Sub

    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtContNo As TextBox = sender
            Dim index1 As Integer = Integer.Parse(txtContNo.ClientID.Substring("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length, txtContNo.ClientID.IndexOf("_textContNo") - "ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length))
            Dim rep As RepeaterItem
            rep = repBookingContDeatils.Items(index1 - 1)
            If txtContNo.Text <> "" Then
                Dim p As New FleetContJoDtls
                p.TerminalId = Session.Item("LoginTerminal")
                p.ContNo = txtContNo.Text
                FleetContJoDtls.ReturnFleetContJoDtls(p)
                If p.MtyContId <> Nothing Then
                    If p.GrId <> Nothing Then
                        Dim pgr As New FleetGrMapping
                        pgr.TerminalId = p.TerminalId
                        pgr.GrId = p.GrId
                        FleetGrMapping.ReturnFleetGrMapping(pgr)
                        If pgr.CloseDate = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & CType(rep.FindControl("textContNo"), TextBox).Text & "")
                            Functions.ControlFocus(txtContNo)
                            Exit Sub
                        End If
                    End If
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container already exists for GR or Gr is already generated for   " & CType(rep.FindControl("textContNo"), TextBox).Text & "")
                    Functions.ControlFocus(txtContNo)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
