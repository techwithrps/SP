Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Xml
Imports System.Data
Imports LogiParkLib.DBConnection
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports System.Diagnostics
Imports System.Net.Mail

Partial Class Commercial_PaymentIssue
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 1
    Dim INVROWS As Integer = 1
    Dim dblBillAmountTotal As Double = 0
    Dim dblToPayAmountTotal As Double = 0
    Dim dblPaymentAmountTotal As Double = 0
    Dim dblRecBalanceAmount As Double = 0
    Dim dblBalanceAmountTotal As Double = 0
    Dim dblWaiverAmountTotal As Double = 0
    Dim dblPaidAmountTotal As Double = 0
    Dim dblbaseAmounttotal As Double = 0.0
    Dim dbltdsamt As Double = 0
    Dim dblcrtotal As Double = 0
    Dim lngTerminalId As Long
    Dim lngInvoiceNo As Long
    Dim lngBillingPartyId As Long
    Dim strPaymentMode As String
    Dim lngLineItemId As Long
    Dim ArrBankId As ArrayList
    Dim arrBankName As ArrayList
    Dim dblWAmt As Double = 0
    Dim dblDrAmt As Double = 0
    Dim strinvno As String = ""
    Dim MainStrInvNo As String = ""
    Dim TempStrInvNo As String = ""
    <WebMethod()> _
    Public Shared Function GetItemsDetails(ByVal Item As String, ByVal PrvCrNo As String, ByVal prvcrAmt As String, ByVal BalAmt As String, ByVal HdnCRAmt As String) As String
        Dim returnValue As String = ""
        Dim pCrNO, pBalAmt, totalCr, totalbal, totalCrAmt, pCrAmt, HdnCRAmt1, pTotalBal As Long
        Dim strConnectionString, CMD3 As String
        Dim con As OleDbConnection
        Dim ada As OleDbDataReader
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        CMD3 = "SELECT ROUND(NVL(BAL_AMT,(DR_AMOUNT + DR_TAX))) CR FROM DR_NOTE WHERE DR_REF_NO='" & Item.Trim & "'"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandText = CMD3
        ada = cmd.ExecuteReader
        ada.Read()
        Try
            pTotalBal = ada.GetValue(0)
        Catch ex As Exception
        End Try
        Try
            pBalAmt = Convert.ToInt64(BalAmt)
        Catch ex As Exception
            pBalAmt = BalAmt
        End Try
        Try
            HdnCRAmt1 = Convert.ToInt64(HdnCRAmt)
        Catch ex As Exception
            HdnCRAmt1 = HdnCRAmt
        End Try

        'pBalAmt = Double.Parse(totalRCV)
        Dim pCrNote As New DrNote
        pCrNote.DrRefNo = Item.Trim
        DrNote.ReturnCreaditNotebyCrRefNo(pCrNote)
        Dim pInvoice As New CostBooking
        pInvoice.CostID = pCrNote.CostId
        CostBooking.ReturnPurchaseDetailsByCostId(pInvoice)
        If prvcrAmt <> "" Then
            pCrAmt = Convert.ToInt64(prvcrAmt)
        Else
            pCrAmt = 0
        End If
        'Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        'If PrvCrNo <> "" Then
        '    pCrNO = Convert.ToInt64(PrvCrNo)
        '    con = New OleDbConnection(strConnectionString)
        '    con.Open()
        '    Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE DR_NOTE SET BAL_AMT=NVL(BAL_AMT,(DR_AMOUNT + DR_TAX)) + " & pCrAmt & " WHERE DR_ID= " & pCrNO, con)
        '    cmd1.ExecuteNonQuery()
        '    con.Close()
        'Else
        '    pCrNO = 0
        'End If

        'totalCr = Double.Parse(pCrNote.DrTax) + Double.Parse(pCrNote.DrAmt)
        totalCr = Double.Parse(pCrNote.InvoiceAmt)
        If pTotalBal >= HdnCRAmt1 Then
            totalbal = 0
            totalCrAmt = pBalAmt
        Else
            totalbal = HdnCRAmt1 - pTotalBal
            totalCrAmt = pTotalBal
        End If
        'con = New OleDbConnection(strConnectionString)
        'con.Open()
        'Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE DR_NOTE SET BAL_AMT=NVL(BAL_AMT,(DR_AMOUNT + DR_TAX)) - " & totalCrAmt & " WHERE DR_ID= " & pCrNote.DrId, con)
        'cmd2.ExecuteNonQuery()
        'con.Close()
        returnValue = pCrNote.DrAmt & "," & pInvoice.BillingParty & "," & pCrNote.DrRefNo & "," & pCrNote.DrId & "," & pCrNote.DrTax & "," & totalbal & "," & totalCrAmt
        Return returnValue.Trim
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        'btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            manageUserControls(True)
            ' ListControlDataBind()
            fillRepeatorInvoice(New ArrayList)
            fillRepeatorPayment(New ArrayList)
            LoadTreeViewData()
            manageUserControls(True)
            ButtonControlSetup(True)
            prepareBankData()
            lngTerminalId = Request.QueryString("TerminalId")
            If Request.QueryString("InvoiceNo") > 0 Then
                lngInvoiceNo = Request.QueryString("InvoiceNo")
            End If
            lngInvoiceNo = Request.QueryString("InvoiceNo")
            lngBillingPartyId = Request.QueryString("BillingPartyId")
            strPaymentMode = Request.QueryString("PaymentMode")
            lngLineItemId = Request.QueryString("LineItemId")
            lstCustomer.SelectedValue = lngBillingPartyId
            lstPaymentType.SelectedValue = "P"
            CType(repPaymentDetails.Items(0).FindControl("textRecBalanceAmount"), TextBox).Text = 0
            lstPurchaseType.Enabled = True
            textFromDate.Enabled = True
            textToDate.Enabled = True
            ' searchPendingPayment()
        End If
    End Sub
    Protected Sub prepareBank(ByVal sender As Object, ByVal e As System.EventArgs)
        prepareBankData()
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To ArrBankId.Count - 1
                lst.Items.Add(New ListItem(arrBankName(i), ArrBankId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub prepareBankData()
        Try
            ArrBankId = New ArrayList
            arrBankName = New ArrayList
            Dim pBankMaster As New BankMaster
            For Each obj As BankMaster In BankMaster.ReturnBankMasterList(pBankMaster)
                ArrBankId.Add(obj.BankId)
                arrBankName.Add(obj.BankName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    

    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()

    End Sub
    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnReceiptNo.Value.Trim <> Nothing AndAlso hdnReceiptNo.Value <> "0" Then
            btnPrint.Visible = True
        Else
            btnPrint.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            'btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvMain.Controls)
    End Sub

    Sub ListControlDataBind(ByVal Type As String)
        If Type = "L" Or Type = "C" Then
            lstCustomer.Items.Clear()
            Dim pExtCustomerMaster As New ExtCustomerMaster
            pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAll(pExtCustomerMaster)
            lstCustomer.DataTextField = "CustomerName"
            lstCustomer.DataValueField = "CustomerId"
            lstCustomer.DataBind()
            lstCustomer.Items.Add(New ListItem("-- Select --  ", "0"))
        Else
            lstCustomer.Items.Clear()
            Dim pVendorMaster As New VendorMaster
            lstCustomer.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
            lstCustomer.DataTextField = "VendorName"
            lstCustomer.DataValueField = "VendorId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        End If


    End Sub

    Private Sub fillRepeatorPayment(ByVal arr As ArrayList)
        If arr.Count = Nothing Then
            If arr.Count < ROWS Then
                For i As Integer = 0 To ROWS - 1
                    Dim p As New PaymentDetails
                    p.BankId = "0"
                    p.ReceiptMode = "C"
                    p.Amount = "0"
                    arr.Add(p)
                Next
            End If
        End If
        repPaymentDetails.DataSource = arr
        repPaymentDetails.DataBind()
    End Sub
    Private Sub fillRepeatorInvoice(ByVal arr As ArrayList)
        If arr.Count = Nothing Then
            If arr.Count < INVROWS Then
                For i As Integer = 0 To INVROWS - 1
                    Dim p As New FinanceDetails

                    arr.Add(p)
                Next
            End If
        End If
        repInvoiceDetails.DataSource = arr
        repInvoiceDetails.DataBind()
        textWaiverAmountotal.Text = dblWaiverAmountTotal
        textBillAmountTotal.Text = dblBillAmountTotal
        textToPayAmountTotal.Text = dblToPayAmountTotal
        textBalanceAmountTotal.Text = dblBalanceAmountTotal
        textPaidAmountTotal.Text = dblPaidAmountTotal
        textBaseAmountTotal.Text = dblbaseAmounttotal
        TextTdsTotal.Text = dbltdsamt
        TextCrTotal.Text = dblcrtotal
    End Sub
    Sub manageRepatorReceipt(ByVal pEnabel As Boolean)
        For Each rep As RepeaterItem In repPaymentDetails.Items
            CType(rep.FindControl("lstPaymentMode"), DropDownList).Enabled = True
            CType(rep.FindControl("lstBankName"), DropDownList).Enabled = False
            CType(rep.FindControl("lstReceiverBank"), DropDownList).Enabled = False
            CType(rep.FindControl("textChequeDate"), TextBox).Enabled = False
            CType(rep.FindControl("textChequeNo"), TextBox).Enabled = False
            CType(rep.FindControl("textPaymentAmount"), TextBox).Enabled = pEnabel
        Next
    End Sub
    Sub manageRepatorInvoice(ByVal pEnabel As Boolean)
        For Each rep As RepeaterItem In repInvoiceDetails.Items
            CType(rep.FindControl("textInvoiceRefNo"), TextBox).Enabled = False
            CType(rep.FindControl("textInvoiceDate"), TextBox).Enabled = False
            'CType(rep.FindControl("textBookingRefNo"), TextBox).Enabled = False
            'CType(rep.FindControl("textBookingDate"), TextBox).Enabled = False
            '  CType(rep.FindControl("textPartyInvNo"), TextBox).Enabled = False
            CType(rep.FindControl("textInvoiceMode"), TextBox).Enabled = False
            CType(rep.FindControl("textBillAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textToPayAmount"), TextBox).Enabled = pEnabel
            CType(rep.FindControl("textWaiverAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textBalanceAmount"), TextBox).Enabled = pEnabel
            CType(rep.FindControl("textPaidAmount"), TextBox).Enabled = pEnabel
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnabel
            CType(rep.FindControl("textPaidAmount"), TextBox).Enabled = pEnabel
            CType(rep.FindControl("textBalanceAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textToPayAmount"), TextBox).Enabled = False
            CType(rep.FindControl("TextCrAmt"), TextBox).Enabled = False
            CType(rep.FindControl("TextTdsAmt"), TextBox).Enabled = False
            CType(rep.FindControl("TextBaseAmount"), TextBox).Enabled = False
        Next
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        btnSave.Attributes.Add("onclick", "this.disabled=false;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvMain.Controls)
        ButtonControlSetup(True)
        'ROWS = 1
        fillRepeatorInvoice(New ArrayList)
        fillRepeatorPayment(New ArrayList)
        manageUserControls(True)
        manageRepatorReceipt(False)
        lstPaymentType.Enabled = True
        lstCustomer.Enabled = True
        lstCustomer.SelectedValue = 0
        btnDisplay.Visible = True
        btnSearchDisplay.Visible = False
        '   lstService.Enabled = True
        textTotalAmount.Text = 0
        textRecBalanceAmountTotal.Text = 0
        Functions.ControlFocus(lstPurchaseType)
        lstPurchaseType.Enabled = True
        btnSave.Enabled = True
        textFromDate.Enabled = True
        textToDate.Enabled = True
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        searchPendingPayment()
    End Sub
    Sub searchPendingPayment()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Please Select Purchase Type")
            Functions.ControlFocus(lstPurchaseType)
            Return
        End If
        If lstCustomer.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Please Select Customer")
            Functions.ControlFocus(lstCustomer)
            Return
        End If

        If lstPurchaseType.SelectedValue = "L" Then
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            pCustomerMaster.CustomerId = lstCustomer.SelectedValue

            CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
            Dim pState As New StateCodeMaster
            pState.StateCode = pCustomerMaster.StateCode
            StateCodeMaster.ReturnStateByCode(pState)
            textStateName.Text = pState.StateName
            hdnStateCode.Value = pState.StateCode
        Else
            Dim pVendorMaster As New VendorMaster
            pVendorMaster.TerminalId = Session.Item("LoginTerminal")
            pVendorMaster.VendorId = lstCustomer.SelectedValue

            VendorMaster.ReturnVendorMaster(pVendorMaster)
            Dim pState As New StateCodeMaster
            pState.StateCode = pVendorMaster.State
            StateCodeMaster.ReturnStateByCode(pState)
            textStateName.Text = pState.StateName
            hdnStateCode.Value = pState.StateCode
        End If
        If textStateName.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "State Code Not Mapped")
            Functions.ControlFocus(textStateName)
            Return
        End If

        If lstPaymentType.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Select Payment Type")
            Functions.ControlFocus(lstPaymentType)
            Return
        End If
        If lstPaymentType.SelectedValue = "P" Then
            Dim p As New FinanceDetails

            Dim arr As ArrayList

            p.TerminalId = Session.Item("CompanyId")
            p.CustomerType = lstPurchaseType.SelectedValue
            p.CustomerId = lstCustomer.SelectedValue
            p.Remarks = textFromDate.Text.Trim
            p.CreatedOn = textToDate.Text.Trim
            arr = FinanceDetails.ReturnPurchaseInvoiceListByCustomerAndType(p, lstPaymentType.SelectedValue)
            btnSave.Visible = True
            'Dim arr As ArrayList = FinanceDetails.ReturnInvoiceListByCustomer(p, lstPaymentType.SelectedValue)
            If arr.Count <= 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "No Invoice for Collection")
                Functions.ControlFocus(lstCustomer)
                Return
            End If
            FinanceDetails.ReturnPreviousIssueBalanceByCustomer(p)
            If p.ReceiptNo > 0 Then
                Dim pRec As New InvoiceReceipt
                pRec.ReceiptNo = p.ReceiptNo
                InvoiceReceipt.ReturnInvoiceReceiptByNo(pRec)
                hdnPreviousReceiptNo.Value = pRec.ReceiptNo
                textPreviousReceiptNo.Text = pRec.ReceiptRefNo
                textPreviousBalance.Text = p.DrAmount
            Else
                hdnPreviousReceiptNo.Value = 0
                textPreviousBalance.Text = 0
            End If

            textRecBalanceAmountTotal.Text = textPreviousBalance.Text
            CType(repPaymentDetails.Items(0).FindControl("textRecBalanceAmount"), TextBox).Text = textPreviousBalance.Text
            CType(repPaymentDetails.Items(0).FindControl("HdnTotalPayment"), HiddenField).Value = textPreviousBalance.Text

            fillRepeatorInvoice(arr)
            manageRepatorInvoice(True)
            manageRepatorReceipt(True)
            repInvoiceDetails.Items(0).Focus()
        Else
            fillRepeatorInvoice(New ArrayList)
            manageRepatorInvoice(False)
            manageRepatorReceipt(True)
            repPaymentDetails.Items(0).Focus()
        End If
        Dim strpParms As String = ""
        ' strpParms = lnk.CommandArgument
        strpParms = lstCustomer.SelectedValue
        strpParms &= "," & Session.Item("CompanyId")
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_ISSUE", strpParms)
        gvOnAccountDtls.DataSource = dbr
        gvOnAccountDtls.DataBind()
        gvOnAccountDtls.Visible = True
        ButtonControlSetup(False)
        manageControls()
        textReceiptdate.Enabled = True
        textReceiptNo.Enabled = False
        btnDisplay.Visible = False
        btnSearchDisplay.Visible = False
        TxtRemarks.Enabled = True
        If lstPurchaseType.SelectedValue = "E" Then

            Dim tblService As New DataTable()
            Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
                Using cmd = New OleDbCommand("SELECT SERVICE_ID ,SERVICE_NAME FROM SERVICE_MASTER WHERE SERVICE_TYPE_CODE='F'", con)
                    Using da = New OleDbDataAdapter(cmd)
                        cmd.CommandType = CommandType.Text
                        da.Fill(tblService)
                    End Using
                End Using
            End Using

            ViewState("tblService") = tblService
            Try
                lstService.Items.Clear()
                lstService.Items.Add(New ListItem("---ALL---", "0"))
                For i As Integer = 0 To tblService.Rows.Count
                    lstService.Items.Add(New ListItem(tblService.Rows(i).Item("SERVICE_NAME"), tblService.Rows(i).Item("SERVICE_ID")))
                Next
            Catch ex As Exception
            End Try

            lblService.Visible = True
            lstService.Visible = True
            lstService.Enabled = True
        Else
            lblService.Visible = False
            lstService.Visible = False
        End If
    End Sub
    Sub manageControls()
        lstCustomer.Enabled = False
        lstPaymentType.Enabled = False
        textReceiptdate.Enabled = False
        textReceiptNo.Enabled = False
    End Sub
    Protected Sub repInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> "0" _
            AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value > 0 Then

                Dim p As New CostBooking

                p.CostID = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                CostBooking.ReturnPurchaseDetailsByCostId(p)
                CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = p.LinerInvoiceNo
                CType(e.Item.FindControl("textInvoiceDate"), TextBox).Text = p.LinerInvoiceDate
                CType(e.Item.FindControl("textInvoiceMode"), TextBox).Text = "Dedit"
                CType(e.Item.FindControl("hdnTaxExemptionPerc"), HiddenField).Value = 0

                CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text = 0
                Dim pf As New FinanceDetails
                pf.InvoiceNo = p.CostID
                FinanceDetails.ReturnToPayAmountByPurchaseInvoiceNo(pf)
                CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = pf.CrAmount

                Dim pFD As New FinanceDetails
                '     pFD.TerminalId = p.TerminalId
                pFD.InvoiceNo = p.CostID
                FinanceDetails.ReturnFinanceDetailsPurchaseSumByInvoiceNo(pFD)
                Dim tda As Long = 0
                If CType(e.Item.FindControl("HdnTrnType"), HiddenField).Value = "V" Then
                    CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = "OPENING BALANCE"
                End If
                'CType(e.Item.FindControl("TextTdsAmt"), TextBox).Text = pf.DrAmount
                'CType(e.Item.FindControl("HdnTdsAmt"), HiddenField).Value = pf.DrAmount
                'CType(e.Item.FindControl("HdnTdsAmt1"), HiddenField).Value = pf.DrAmount
                Dim ToPayAmount As Double = 0.0
                CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = Math.Round(Double.Parse(CType(e.Item.FindControl("textBillAmount"), TextBox).Text) - tda - Double.Parse(CType(e.Item.FindControl("TextCrAmt"), TextBox).Text), 2)
                CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text = Math.Round(Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text) - pFD.DrAmount, 2)
                ToPayAmount = Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text)
                CType(e.Item.FindControl("HdnRcvAmt"), HiddenField).Value = Math.Round(Double.Parse(CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text) + pFD.DrAmount + tda, 2)
                ToPayAmount = Double.Parse(CType(e.Item.FindControl("HdnRcvAmt"), HiddenField).Value)

                Try
                    dblBillAmountTotal += Double.Parse(CType(e.Item.FindControl("textBillAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblToPayAmountTotal += Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                dblBalanceAmountTotal += Double.Parse(CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text)

                '' change by lalit 
                CType(e.Item.FindControl("textPaidAmount"), TextBox).Text = Double.Parse(CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text)
                CType(e.Item.FindControl("txtRoundOff"), TextBox).Text = 0
                CType(e.Item.FindControl("hdnRoundOffStatus"), HiddenField).Value = "N"


                '   dblPaidAmountTotal += Double.Parse(CType(e.Item.FindControl("textPaidAmount"), TextBox).Text)
                Try
                    dblWaiverAmountTotal += Double.Parse(CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dbltdsamt += Double.Parse(CType(e.Item.FindControl("TextTdsAmt"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblDrAmt += Double.Parse(CType(e.Item.FindControl("TextCrAmt"), TextBox).Text)
                Catch ex As Exception
                End Try

                Try
                    dblbaseAmounttotal += Double.Parse(CType(e.Item.FindControl("TextBaseAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Dim DebitNoteAmt As Double = 0
                DebitNoteAmt = Double.Parse(CType(e.Item.FindControl("TextCrAmt"), TextBox).Text)
                If DebitNoteAmt <> 0 Then
                    Dim costId As Integer = 0
                    costId = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                    Dim pDebitNote As New DrNote
                    pDebitNote.CostId = costId

                    DrNote.ReturnCreaditNotebyCostid(pDebitNote)
                    CType(e.Item.FindControl("HdnDrNo"), HiddenField).Value = pDebitNote.DrId
                    CType(e.Item.FindControl("TextDrNo"), TextBox).Text = pDebitNote.DrRefNo
                    CType(e.Item.FindControl("txtDrAmt"), TextBox).Text = Double.Parse(CType(e.Item.FindControl("TextCrAmt"), TextBox).Text)
                    CType(e.Item.FindControl("hdnDrAmt1"), HiddenField).Value = Double.Parse(CType(e.Item.FindControl("TextCrAmt"), TextBox).Text)
                End If
            End If
        End If
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim textPaymentAmount As Double = 0.0
        Dim dbltotalAmout As Double = 0
        Dim dbltotalPaidAmout As Double = 0
        Try
            dbltotalAmout = textTotalAmount.Text
        Catch ex As Exception
            dbltotalAmout = 0
        End Try
        Try
            dbltotalPaidAmout = textPaidAmountTotal.Text
        Catch ex As Exception
            dbltotalAmout = 0
        End Try
        Dim dblTempPrevBal As Double = 0
        Try
            If hdnPreviousBalance.Value = Nothing Then
                hdnPreviousBalance.Value = 0
            Else
                dblTempPrevBal = Double.Parse(hdnPreviousBalance.Value)
            End If
        Catch ex As Exception
            dblTempPrevBal = 0
        End Try
        Dim receipt As Integer = 0
        Try
            receipt = hdnReceiptNo.Value
        Catch ex As Exception
            receipt = 0
        End Try
        'If dbltotalAmout <> dbltotalPaidAmout And lstPaymentType.SelectedValue = "P" And receipt = 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Paid Amount should  be equal to payment Amount")
        '    Functions.ControlFocus(textTotalAmount)
        '    rtnBool = False
        'End If
        If receipt <> 0 And dblTempPrevBal < dbltotalPaidAmout Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "On Account Balance Amount is less then Paid Amount")

            Try
                textPreviousBalance.Text = hdnPreviousBalance.Value
            Catch ex As Exception
                textPreviousBalance.Text = 0
            End Try

            Functions.ControlFocus(textPreviousBalance)
            rtnBool = False
        End If
        If lstPaymentType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Payment Type")
            Functions.ControlFocus(lstPaymentType)
            rtnBool = False
        End If
        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Purchase Type")
            Functions.ControlFocus(lstPaymentType)
            rtnBool = False
        End If
        If textReceiptdate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Payment Date.")
            Functions.ControlFocus(textReceiptdate)
            rtnBool = False
        End If
        If lstPurchaseType.SelectedValue = "E" And lstService.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Service")
            Functions.ControlFocus(lstService)
            rtnBool = False
        End If
        Return rtnBool
    End Function
    'Function ValidationCheck() As Boolean
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    Dim rtnBool As Boolean = True

    '    If textToPayAmountTotal.Text.Trim = Nothing Then
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Payment Details.")
    '        Functions.ControlFocus(lstCustomer)
    '        rtnBool = False
    '    End If

    '    Dim textPaymentAmount As Double = CType(repPaymentDetails.Items(0).FindControl("textPaymentAmount"), TextBox).Text
    '    textTotalAmount.Text = textPaymentAmount

    '    Dim textRecBalanceAmount As TextBox = repPaymentDetails.Items(0).FindControl("textRecBalanceAmount")
    '    If lstPaymentType.SelectedValue = "I" Then
    '        textRecBalanceAmount.Text = Double.Parse(textPreviousBalance.Text) + Double.Parse(textPaymentAmount)
    '    End If

    '    For Each rep As RepeaterItem In repInvoiceDetails.Items
    '        Dim textInvoiceMode As TextBox = rep.FindControl("textInvoiceMode")
    '        Dim textBalanceAmount As TextBox = rep.FindControl("textBalanceAmount")
    '        Dim hdnBalanceAmount As HiddenField = rep.FindControl("hdnBalanceAmount")
    '        Dim textToPayAmount As TextBox = rep.FindControl("textToPayAmount")
    '        Dim textPaidAmount As TextBox = rep.FindControl("textPaidAmount")

    '        If hdnBalanceAmount.Value = Nothing Then
    '            hdnBalanceAmount.Value = 0
    '        End If

    '        If textRecBalanceAmount.Text.Trim = Nothing Then
    '            textRecBalanceAmount.Text = 0
    '        End If
    '        If textPaidAmount.Text.Trim = Nothing Then
    '            textPaidAmount.Text = 0
    '        End If
    '        If textBalanceAmount.Text.Trim = Nothing Then
    '            textBalanceAmount.Text = 0
    '        End If
    '        If textToPayAmount.Text.Trim = Nothing Then
    '            textToPayAmount.Text = 0
    '        End If

    '        If Double.Parse(textPaidAmount.Text) > Double.Parse(textRecBalanceAmount.Text) And Double.Parse(textPaidAmount.Text) > 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Not Sufficent Balance")
    '            Functions.ControlFocus(textRecBalanceAmount)
    '            rtnBool = False
    '        End If
    '        If Double.Parse(textPaidAmount.Text) > Double.Parse(hdnBalanceAmount.Value) And Double.Parse(textPaidAmount.Text) > 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Paid Amount should not be more than Invoice Balance Amount")
    '            Functions.ControlFocus(textPaidAmount)
    '            rtnBool = False
    '        End If
    '        If textInvoiceMode.Text = "Cash" And Double.Parse(textPaidAmount.Text) <> Double.Parse(hdnBalanceAmount.Value) And Double.Parse(textPaidAmount.Text) > 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "For Cash Invoice, Invoice Paid Amount should be equal to Invoice Balance Amount ")
    '            Functions.ControlFocus(textPaidAmount)
    '            rtnBool = False
    '        End If

    '        textBalanceAmount.Text = Double.Parse(hdnBalanceAmount.Value) - Double.Parse(textPaidAmount.Text)

    '        dblPaidAmountTotal += Double.Parse(textPaidAmount.Text)
    '        textPaidAmountTotal.Text = dblPaidAmountTotal

    '        dblBalanceAmountTotal += Double.Parse(textBalanceAmount.Text)
    '        textBalanceAmountTotal.Text = dblBalanceAmountTotal

    '        textRecBalanceAmount.Text = Double.Parse(textRecBalanceAmount.Text) - Double.Parse(textPaidAmount.Text)
    '        textRecBalanceAmountTotal.Text = textRecBalanceAmount.Text
    '    Next
    '    Return rtnBool
    'End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtInvoiceReceipt As ExtInvoiceReceipt = ReturnObject()
        Dim receipt As Integer = 0
        Try
            receipt = hdnReceiptNo.Value
        Catch ex As Exception
            receipt = 0
        End Try

        If pExtInvoiceReceipt.PaymentDetailsList.Count <= 0 And receipt = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Payment Details")
            'Functions.ControlFocus(repPayment)
            Return
        End If
        If pExtInvoiceReceipt.FinanceDetailsList.Count <= 0 And lstPaymentType.SelectedValue = "P" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Invoice Details")
            'Functions.ControlFocus(repPayment)
            Return
        End If

        ExtInvoiceReceipt.PurchasePaymentInsertTransaction(pExtInvoiceReceipt)

        If pExtInvoiceReceipt.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, pExtInvoiceReceipt.Errormsg)
            Functions.ControlFocus(btnSave)
            Return
        End If
        Dim dblNewReceiptNo As Double = 0
        Try
            dblNewReceiptNo = hdnReceiptNo.Value
        Catch ex As Exception
            dblNewReceiptNo = 0
        End Try
        If dblNewReceiptNo > 0 Then
            textReceiptdate.Text = hdnPreviousDate.Value
            textReceiptNo.Text = hdnPreviousReceiptRefNo.Value
        Else
            textReceiptdate.Text = pExtInvoiceReceipt.ReceiptDate
            textReceiptNo.Text = pExtInvoiceReceipt.ReceiptRefNo
            hdnReceiptNo.Value = pExtInvoiceReceipt.ReceiptNo
        End If

        ButtonControlSetup(True)
        manageUserControls(True)
        manageRepatorInvoice(False)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        btnSave.Enabled = False
        'sendmail()
    End Sub
    Sub sendmail()
        Dim FileToDelete As String = "D:\software\JSB\Payment\Issue\"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        Dim pInvoice As New InvoiceReceipt
        pInvoice.TerminalId = Session.Item("LoginTerminal")
        pInvoice.ReceiptNo = hdnReceiptNo.Value
        InvoiceReceipt.ReturnInvoiceReceiptByNo(pInvoice)
        strinvno = pInvoice.ReceiptRefNo
        strinvno = strinvno.Replace("/", "-")
        'HtmlToPdf(" http://localhost:15987/LogiParkWeb/(S(uadlqxwx25n4e52y444nat1y))/Commercial/Preview/InvoiceIssueGST.aspx?ReceiptNo=" & hdnReceiptNo.Value, "C:\\Software\JSB\Payment\Issue\" & strinvno & ".pdf")
        HtmlToPdf("http://115.124.127.54/JSB/(S(sbgtygixqzxuonofc5aoocu4))/Commercial/Preview/InvoiceIssueGST.aspx?ReceiptNo=" & hdnReceiptNo.Value, "D:\\Software\JSB\Payment\Issue\" & strinvno & ".pdf")
        'Response.Redirect("Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & hdnReceiptNo.Value)
        'Response.Redirect("Preview/InvoiceIssueGST.aspx?ReceiptNo=" & hdnReceiptNo.Value)
        TempStrInvNo = "D:\software\JSB\Payment\Issue\" & strinvno & ".pdf"
        Dim xMailSetup As String = ""
        Dim con As New OleDbConnection
        Dim strConnectionString As String = ""
        strConnectionString = "Provider=MSDAORA;Data Source=115.124.127.54;Persist Security Info=True;Password=spj;User ID=spj"
        con = New OleDbConnection(strConnectionString)
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        Dim ada1 As OleDbDataAdapter = New OleDbDataAdapter
        Dim CMD1 As String = ""
        Dim pPaymeme As New PaymentDetails
        pPaymeme.ReceiptNo = hdnReceiptNo.Value
        PaymentDetails.ReturnPaymentDetailsByReceiptNo(pPaymeme)
        Dim adamailconfig As OleDbDataAdapter
        Dim cmdmailconfig As String
        cmdmailconfig = "SELECT FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=1"
        adamailconfig = New OleDbDataAdapter(cmdmailconfig, con)
        Dim dsmailconfig As New DataSet
        adamailconfig.Fill(dsmailconfig)
        Dim adamailsetup As OleDbDataAdapter
        Dim cmdmailsetup As String
        cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=31.1 AND TERMINAL_ID=1"
        adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
        Dim dsmailsetup As New DataSet
        adamailsetup.Fill(dsmailsetup)
        Dim confirmMail As New StringBuilder
        confirmMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        'confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
        'confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='10'  >")
        'confirmMail.Append("<b>Daily Booked Report</b>")
        'confirmMail.Append(" </th>")
        'confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>SR.</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>BL No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice Amount</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>DR Amount</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>TDS</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 60px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Issue Amount</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")
        Dim ada2 As OleDbDataAdapter = New OleDbDataAdapter
        Dim cmd As OleDbCommand = con.CreateCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        Dim procName As String = ""
        Dim procParam As String = ""
        procParam = hdnReceiptNo.Value
        procName = "SELECT_PKG.SP_PAYMENT_ISS_PRI"
        'Dim procParam As String = ds.Tables(0).Rows(J)("TERMINAL_NAME").ToString
        cmd.CommandText = procName & "(" & procParam & ")"
        ada2.SelectCommand = cmd
        Dim dsOSDRY As New DataSet
        ada2.Fill(dsOSDRY)
        Dim SR As Long = 0
        For i = 0 To dsOSDRY.Tables(0).Rows.Count - 1
            SR = SR + 1
            confirmMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
            confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(SR)
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("BL_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_DATE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_AMOUNT"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("DR_AMT"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 60px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("TDS"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("TA"))
            confirmMail.Append(" </td>")
            confirmMail.Append(" </tr>")
        Next
        confirmMail.Append("</table>")
        confirmMail.Append("<table>")
        confirmMail.Append("<tr>")
        confirmMail.Append("<td>")
        confirmMail.Append("</td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("</table>")
        xMailSetup = " Dear Sir,"
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Please find enclosed payment advice confirmation of Cheque/UTR No. " & pPaymeme.ChequeNo & "  of amount " & pPaymeme.Amount & " dated: " & pPaymeme.ChequeDate & " against your invoices mentioned in the attachment."
        xMailSetup &= "<br/>"
        xMailSetup &= "kindly adjust the payment accordingly."
        xMailSetup &= "<br/>"
        xMailSetup &= "Below is the short summary."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= confirmMail.ToString
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Thanks & Regards " & "<br>"
        xMailSetup &= " JSB ACCOUNTS TEAM "
        Dim Pcus As New CustomerMaster
        Pcus.CustomerId = pInvoice.CustomerId
        CustomerMaster.ReturnCustomerMaster(Pcus)
        Dim tomail As String = ""
        If Pcus.CustomerName = "" Then
            Dim pVendorMaster As New VendorMaster
            pVendorMaster.VendorId = pInvoice.CustomerId
            VendorMaster.ReturnVendorMaster(pVendorMaster)
            Pcus.CustomerName = pVendorMaster.VendorName
            Try
                ' tomail = "vrohit248@gmail.com"
                tomail = pVendorMaster.EmailId2
            Catch ex As Exception
                tomail = "vrohit248@gmail.com"
            End Try
        Else
            Try
                ' tomail = "vrohit248@gmail.com"zzz
                tomail = Pcus.EmailCommercial
            Catch ex As Exception
                tomail = "vrohit248@gmail.com"
            End Try
        End If

        Dim pStr As String = ""
        Dim SUBJECT As String = "Payment Advice - " & Pcus.CustomerName & " - " & textReceiptNo.Text.Trim & " - Cheque/UTR:- " & pPaymeme.ChequeNo & " - Rs." & pPaymeme.Amount & " - Date " & pPaymeme.ChequeDate & "."
        pStr = sendMailToCcBccWithAttachmentExcel("vrohit248@gmail.com", TempStrInvNo, tomail, "vrohit248@gmail.com,vrohit248@gmail.com,rohit@elogisol.in", "lalit@elogisol.in,rohit@elogisol.in", SUBJECT, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "01!", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
        If pStr = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent")
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent fail")
        End If
    End Sub
    Public Shared Function sendMailToCcBccWithAttachmentExcel(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String

        Dim AttachmentCount As Integer = 0
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0

            ''Added By Amit
            Dim unique As Boolean = True
            If toMailIds <> Nothing Then
                Dim arrTo As String() = toMailIds.Split(",")
                For i = 0 To arrTo.Length - 1
                    If arrTo(i) <> "" Then
                        For j As Integer = i + 1 To arrTo.Length - 1
                            If arrTo(j) <> "" Then
                                If arrTo(i) = arrTo(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrTo(i) <> "" Then
                        If unique Then
                            objMM.To.Add(arrTo(i))
                        Else
                            unique = True
                        End If
                    End If
                Next
            End If
            If CCIds.Length > 0 Then
                objMM.CC.Add(CCIds)
                ' objMM.Attachments.Add("D:\New.text")
                Dim arrFileName As String() = fromName.Split(",")

                For i = 0 To arrFileName.Length - 1
                    If arrFileName(i) <> "" Then
                        For j As Integer = i + 1 To arrFileName.Length - 1
                            If arrFileName(j) <> "" Then
                                If arrFileName(i) = arrFileName(j) Then
                                    unique = False
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                    If arrFileName(i) <> "" Then
                        If unique Then
                            Try

                                objMM.Attachments.Add(New Attachment(arrFileName(i)))
                                AttachmentCount = AttachmentCount + 1
                            Catch ex As Exception

                            End Try
                        Else
                            unique = True
                        End If
                    End If
                Next

            End If
            If BccIds.Length > 0 Then
                objMM.Bcc.Add(BccIds)
            End If
            'objMM.CC.Add(CCIds)
            'objMM.Bcc.Add(BccIds)

            objMM.Subject = subject
            objMM.From = New MailAddress(fromMailId)
            objMM.Body = body
            objMM.IsBodyHtml = True


            '            objMM.BodyEncoding = Encoding.Default
            '            objMM.Priority = MailPriority.Normal
            Dim ms As New IO.MemoryStream

            Dim sm As SmtpClient = New SmtpClient(smtpServer)
            sm.Host = smtpServer
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            sm.Port = port

            Try
                sm.EnableSsl = True
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                If AttachmentCount > 0 Then
                    sm.Send(objMM)
                    sm = Nothing
                End If
            Catch ex As Exception
                sm.EnableSsl = False
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                sm.Send(objMM)
                sm = Nothing
            End Try

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function
    Private Sub HtmlToPdf(ByVal website As String, ByVal destinationFile As String)
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
        startInfo.UseShellExecute = False
        startInfo.RedirectStandardOutput = True
        startInfo.RedirectStandardInput = True
        startInfo.RedirectStandardError = True
        startInfo.CreateNoWindow = True
        startInfo.FileName = "C:\Program Files\wkhtmltopdf\bin\wkhtmltopdf.exe"
        startInfo.Arguments = website & " " & destinationFile
        Dim myProcess As Process = Process.Start(startInfo)
        myProcess.WaitForExit()
        myProcess.Close()
        Response.Clear()

        'Response.AddHeader("content-disposition", "attachment;filename=" & strinvno & ".pdf")
        'Response.ContentType = "application/pdf"
        'Response.WriteFile(destinationFile)
        'Response.[End]()
    End Sub
    Function ReturnObject() As ExtInvoiceReceipt
        Dim p As New ExtInvoiceReceipt
        Dim DrCr As String = ""
        Try
            p.ReceiptNo = hdnReceiptNo.Value
        Catch ex As Exception
        End Try
        p.ReceiptRefNo = textReceiptNo.Text
        p.ReceiptDate = textReceiptdate.Text
        p.CustomerId = lstCustomer.SelectedValue
        p.CreatedBy = Session.Item("LoginUser")
        p.ReceiptType = lstPaymentType.SelectedValue
        p.TerminalId = Session.Item("CompanyId")
        p.IRType = "P"
        If lstPurchaseType.SelectedValue = "C" Or lstPurchaseType.SelectedValue = "L" Then
            p.CustomerType = "C"
        Else
            p.CustomerType = "V"
        End If

        p.CreatedOn = textReceiptdate.Text.Trim
        p.PaymentDetailsList = New ArrayList
        p.FinanceDetailsList = New ArrayList
        Dim receipt As Long = 0
        Try
            receipt = hdnReceiptNo.Value
        Catch ex As Exception
            receipt = 0
        End Try
        p.Remarks = TxtRemarks.Text
        If receipt <= 0 Then
            For Each r As RepeaterItem In repPaymentDetails.Items
                If CType(r.FindControl("textPaymentAmount"), TextBox).Text <> Nothing AndAlso CType(r.FindControl("textPaymentAmount"), TextBox).Text > 0 Then
                    DrCr = CType(r.FindControl("lstDrCr"), DropDownList).SelectedValue
                    Dim pPD As New PaymentDetails
                    pPD.Amount = CType(r.FindControl("textPaymentAmount"), TextBox).Text
                    pPD.ReceiptMode = CType(r.FindControl("lstPaymentMode"), DropDownList).SelectedValue
                    Try
                        pPD.ChequeNo = CType(r.FindControl("textChequeNo"), TextBox).Text
                    Catch ex As Exception
                    End Try
                    pPD.ChequeDate = CType(r.FindControl("textChequeDate"), TextBox).Text
                    pPD.BankId = CType(r.FindControl("lstBankName"), DropDownList).SelectedValue
                    pPD.ReceiverBankId = CType(r.FindControl("lstReceiverBank"), DropDownList).SelectedValue
                    pPD.TerminalId = Session.Item("LoginTerminal")
                    ' pPD.ServiceId = lstService.SelectedValue
                    pPD.StateCode = hdnStateCode.Value
                    pPD.PDType = "P"
                    If lstPurchaseType.SelectedValue = "E" Then
                        pPD.ServiceId = lstService.SelectedValue
                    End If
                    p.PaymentDetailsList.Add(pPD)
                Else
                    DrCr = "D"
                    Dim pPD As New PaymentDetails
                    pPD.Amount = 0
                    pPD.ReceiptMode = "N"
                    Try
                        pPD.ChequeNo = "DEBIT NOTE"
                    Catch ex As Exception
                    End Try
                    ' pPD.ChequeDate = CType(r.FindControl("textChequeDate"), TextBox).Text
                    pPD.BankId = 0
                    pPD.ReceiverBankId = 0
                    Try
                        pPD.TerminalId = Session.Item("LoginTerminal")
                    Catch ex As Exception
                        pPD.TerminalId = 4
                    End Try
                    pPD.StateCode = hdnStateCode.Value
                    pPD.PDType = "P"
                    p.PaymentDetailsList.Add(pPD)
                End If
            Next
        End If


        Dim dblTempPrevBal As Double = 0
        If textPreviousBalance.Text.Trim = Nothing Then
            textPreviousBalance.Text = 0
        Else
            dblTempPrevBal = Double.Parse(textPreviousBalance.Text)
        End If

        Dim lngCount As Integer = 0
        If lstPaymentType.SelectedValue = "P" Then
            For Each i As RepeaterItem In repInvoiceDetails.Items
                Dim tempCrAmount As Double = 0
                'If CType(i.FindControl("textPaidAmount"), TextBox).Text <> Nothing AndAlso CType(i.FindControl("textPaidAmount"), TextBox).Text > 0 AndAlso (CType(i.FindControl("CheckBox2"), CheckBox).Checked = True Or CType(i.FindControl("chkSelect"), CheckBox).Checked = True) Then
                If (CType(i.FindControl("CheckBox2"), CheckBox).Checked = True Or CType(i.FindControl("chkSelect"), CheckBox).Checked = True) Then
                    If dblTempPrevBal = 0 Then

                        If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then
                            Try
                                tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                            Catch ex As Exception
                                tempCrAmount = 0
                            End Try

                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.DrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.TrnType = "R"
                            pFD.TrnValue = 13
                            pFD.FNCType = "P"
                            If receipt >= 0 Then
                                pFD.ReceiptNo = receipt
                            End If
                            pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            pFD.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD)

                            Dim pFD1 As New FinanceDetails
                            pFD1.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD.CustomerId = lstCustomer.SelectedValue
                            pFD1.DrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD1.TrnType = "P"
                            pFD1.FNCType = "P"
                            pFD1.TrnValue = 12
                            If receipt >= 0 Then
                                pFD1.ReceiptNo = receipt
                            End If
                            pFD1.TerminalId = Session.Item("LoginTerminal")
                            pFD1.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD1)



                            Dim pFD2 As New FinanceDetails
                            pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD2.CustomerId = lstCustomer.SelectedValue
                            Try
                                pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                            Catch ex As Exception
                                pFD2.DrAmount = 0
                            End Try

                            If pFD2.DrAmount <> 0 Then
                                pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD2.TrnType = "z"
                                pFD2.FNCType = "P"
                                pFD2.TrnValue = 17
                                pFD2.TerminalId = Session.Item("LoginTerminal")
                                pFD2.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD2)
                            End If
                            Dim pFD3 As New FinanceDetails
                            pFD3.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD2.CustomerId = lstCustomer.SelectedValue
                            Try
                                pFD3.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                            Catch ex As Exception
                                pFD3.DrAmount = 0
                            End Try
                            If pFD3.DrAmount <> 0 Then
                                pFD3.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD3.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD3.TrnType = "D"
                                pFD3.FNCType = "P"
                                pFD3.TrnValue = 18
                                pFD3.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                pFD3.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD3)
                            End If
                        Else
                            ' If CType(i.FindControl("HdnTrnType"), HiddenField).Value <> "B" Then
                            Try
                                tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                            Catch ex As Exception
                                tempCrAmount = 0
                            End Try

                            Dim pFDTDS As New FinanceDetails
                            pFDTDS.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD.CustomerId = lstCustomer.SelectedValue
                            pFDTDS.DrAmount = tempCrAmount
                            pFDTDS.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFDTDS.TrnType = "R"
                            pFDTDS.TrnValue = 13
                            pFDTDS.FNCType = "P"
                            If receipt >= 0 Then
                                pFDTDS.ReceiptNo = receipt
                            End If
                            pFDTDS.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFDTDS.TerminalId = Session.Item("LoginTerminal")
                            pFDTDS.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFDTDS)
                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            tempCrAmount = tempCrAmount
                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.DrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TrnType = "P"
                            pFD.FNCType = "P"
                            If receipt >= 0 Then
                                pFD.ReceiptNo = receipt
                            End If
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            pFD.TrnValue = 12
                            pFD.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD)

                            Dim pFD2 As New FinanceDetails
                            pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD2.CustomerId = lstCustomer.SelectedValue
                            Try
                                pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                            Catch ex As Exception
                                pFD2.DrAmount = 0
                            End Try

                            If pFD2.DrAmount <> 0 Then
                                pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD2.TrnType = "z"
                                pFD2.FNCType = "P"
                                pFD2.TrnValue = 17
                                pFD2.TerminalId = Session.Item("LoginTerminal")
                                pFD2.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD2)
                            End If
                            Dim pFDdR As New FinanceDetails
                            pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                            ' pFD2.CustomerId = lstCustomer.SelectedValue
                            Try
                                pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                            Catch ex As Exception
                                pFDdR.DrAmount = 0
                            End Try
                            If pFDdR.DrAmount <> 0 Then
                                pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFDdR.TrnType = "D"
                                pFDdR.FNCType = "P"
                                pFDdR.TrnValue = 18
                                pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                pFDdR.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFDdR)
                            End If
                        End If

                    ElseIf dblTempPrevBal > 0 Then
                        If dblTempPrevBal < Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then
                            tempCrAmount = dblTempPrevBal
                            Dim dblTemp As Double = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) - dblTempPrevBal
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then
                                Try
                                    tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                Catch ex As Exception
                                    tempCrAmount = 0
                                End Try
                                'tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.DrAmount = tempCrAmount
                                pFD.FNCType = "P"
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TrnType = "R"
                                pFD.TrnValue = 13
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD1.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.DrAmount = dblTempPrevBal
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "P"
                                pFD1.FNCType = "P"
                                If receipt >= 0 Then
                                    pFD1.ReceiptNo = receipt
                                End If
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                pFD1.TrnValue = 12
                                pFD1.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD1)

                                Dim pFD2 As New FinanceDetails
                                pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD2.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                Catch ex As Exception
                                    pFD2.DrAmount = 0
                                End Try

                                If pFD2.DrAmount <> 0 Then
                                    pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD2.TrnType = "z"
                                    pFD2.FNCType = "P"
                                    pFD2.TrnValue = 17
                                    pFD2.TerminalId = Session.Item("LoginTerminal")
                                    pFD2.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD2)
                                    Dim pFDdR As New FinanceDetails
                                    pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD2.CustomerId = lstCustomer.SelectedValue
                                    Try
                                        pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                                    Catch ex As Exception
                                        pFDdR.DrAmount = 0
                                    End Try
                                    If pFDdR.DrAmount <> 0 Then
                                        pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                        pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                        pFDdR.TrnType = "D"
                                        pFDdR.FNCType = "P"
                                        pFDdR.TrnValue = 18
                                        pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                        pFDdR.CompanyId = Session.Item("CompanyId")
                                        p.FinanceDetailsList.Add(pFDdR)
                                    End If
                                End If
                                If dblTemp > 0 Then
                                    Try
                                        tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                    Catch ex As Exception
                                        tempCrAmount = 0
                                    End Try
                                    'tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTemp)
                                    tempCrAmount = tempCrAmount
                                    Dim temp As New FinanceDetails
                                    temp.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD.CustomerId = lstCustomer.SelectedValue
                                    temp.DrAmount = tempCrAmount
                                    temp.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp.TrnType = "R"
                                    temp.TrnValue = 13
                                    temp.FNCType = "P"
                                    If receipt >= 0 Then
                                        pFD.ReceiptNo = receipt
                                    End If
                                    temp.TerminalId = Session.Item("LoginTerminal")
                                    pFD.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(temp)

                                    Dim temp1 As New FinanceDetails
                                    temp1.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD.CustomerId = lstCustomer.SelectedValue
                                    temp1.DrAmount = dblTemp
                                    temp1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp1.TrnType = "P"
                                    temp1.FNCType = "P"
                                    temp1.TrnValue = 12
                                    If receipt >= 0 Then
                                        temp1.ReceiptNo = receipt
                                    End If
                                    temp1.TerminalId = Session.Item("LoginTerminal")
                                    temp1.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(temp1)



                                    Dim pFD3 As New FinanceDetails
                                    pFD3.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD.CustomerId = lstCustomer.SelectedValue
                                    Try
                                        pFD3.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                    Catch ex As Exception
                                        pFD3.DrAmount = 0
                                    End Try

                                    If pFD3.DrAmount <> 0 Then
                                        pFD3.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                        pFD3.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                        pFD3.TrnType = "z"
                                        pFD3.FNCType = "P"
                                        pFD3.TrnValue = 17
                                        pFD3.TerminalId = Session.Item("LoginTerminal")
                                        pFD3.CompanyId = Session.Item("CompanyId")
                                        p.FinanceDetailsList.Add(pFD3)
                                    End If
                                    Dim pFDdR As New FinanceDetails
                                    pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD2.CustomerId = lstCustomer.SelectedValue
                                    Try
                                        pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                                    Catch ex As Exception
                                        pFDdR.DrAmount = 0
                                    End Try
                                    If pFDdR.DrAmount <> 0 Then
                                        pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                        pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                        pFDdR.TrnType = "D"
                                        pFDdR.FNCType = "P"
                                        pFDdR.TrnValue = 18
                                        pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                        pFDdR.CompanyId = Session.Item("CompanyId")
                                        p.FinanceDetailsList.Add(pFDdR)
                                    End If
                                End If
                                dblTempPrevBal = 0
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.DrAmount = dblTempPrevBal
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "P"
                                pFD.FNCType = "P"
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 12
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)



                                Dim pFD2 As New FinanceDetails
                                pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                Catch ex As Exception
                                    pFD2.DrAmount = 0
                                End Try

                                If pFD2.DrAmount <> 0 Then
                                    pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD2.TrnType = "z"
                                    pFD2.FNCType = "P"
                                    pFD2.TrnValue = 17
                                    pFD2.TerminalId = Session.Item("LoginTerminal")
                                    pFD2.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD2)
                                End If
                                If dblTemp > 0 Then
                                    Dim pFD1 As New FinanceDetails
                                    pFD1.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD.CustomerId = lstCustomer.SelectedValue
                                    pFD1.DrAmount = dblTemp
                                    pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD1.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD1.TrnType = "P"
                                    pFD1.FNCType = "P"
                                    pFD1.TerminalId = Session.Item("LoginTerminal")
                                    pFD1.TrnValue = 12
                                    If receipt >= 0 Then
                                        pFD1.ReceiptNo = receipt
                                    End If
                                    pFD1.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD1)




                                    Dim pFD3 As New FinanceDetails
                                    pFD3.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD.CustomerId = lstCustomer.SelectedValue
                                    Try
                                        pFD3.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                    Catch ex As Exception
                                        pFD3.DrAmount = 0
                                    End Try

                                    If pFD3.DrAmount <> 0 Then
                                        pFD3.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                        pFD3.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                        pFD3.TrnType = "z"
                                        pFD3.FNCType = "P"
                                        pFD3.TrnValue = 17
                                        pFD3.TerminalId = Session.Item("LoginTerminal")
                                        pFD3.CompanyId = Session.Item("CompanyId")
                                        p.FinanceDetailsList.Add(pFD3)
                                    End If
                                    Dim pFDdR As New FinanceDetails
                                    pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                    ' pFD2.CustomerId = lstCustomer.SelectedValue
                                    Try
                                        pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                                    Catch ex As Exception
                                        pFDdR.DrAmount = 0
                                    End Try
                                    If pFDdR.DrAmount <> 0 Then
                                        pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                        pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                        pFDdR.TrnType = "D"
                                        pFDdR.FNCType = "P"
                                        pFDdR.TrnValue = 18
                                        pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                        pFDdR.CompanyId = Session.Item("CompanyId")
                                        p.FinanceDetailsList.Add(pFDdR)
                                    End If
                                End If
                                dblTempPrevBal = 0
                            End If

                        ElseIf dblTempPrevBal >= Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then

                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then

                                ' tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                Try
                                    tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                Catch ex As Exception
                                    tempCrAmount = 0
                                End Try
                                tempCrAmount = tempCrAmount

                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.DrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TrnValue = 13
                                pFD.FNCType = "P"
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD1.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.DrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "P"
                                pFD1.TrnValue = 12
                                pFD.FNCType = "P"
                                If receipt >= 0 Then
                                    pFD1.ReceiptNo = receipt
                                End If
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                pFD1.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD1)



                                Dim pFD2 As New FinanceDetails
                                pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                Catch ex As Exception
                                    pFD2.DrAmount = 0
                                End Try

                                If pFD2.DrAmount <> 0 Then
                                    pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD2.TrnType = "z"
                                    pFD2.FNCType = "P"
                                    pFD2.TrnValue = 17
                                    pFD2.TerminalId = Session.Item("LoginTerminal")
                                    pFD2.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD2)
                                End If
                                Dim pFDdR As New FinanceDetails
                                pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD2.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                                Catch ex As Exception
                                    pFDdR.DrAmount = 0
                                End Try
                                If pFDdR.DrAmount <> 0 Then
                                    pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFDdR.TrnType = "D"
                                    pFDdR.FNCType = "P"
                                    pFDdR.TrnValue = 18
                                    pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                    pFDdR.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFDdR)
                                End If
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.DrAmount = tempCrAmount
                                pFD.FNCType = "P"
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "P"
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 12
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)





                                Dim pFD2 As New FinanceDetails
                                pFD2.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFD2.DrAmount = Double.Parse(CType(i.FindControl("txtRoundOff"), TextBox).Text)
                                Catch ex As Exception
                                    pFD2.DrAmount = 0
                                End Try

                                If pFD2.DrAmount <> 0 Then
                                    pFD2.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD2.Remarks = "Round of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD2.TrnType = "z"
                                    pFD2.FNCType = "P"
                                    pFD2.TrnValue = 17
                                    pFD2.TerminalId = Session.Item("LoginTerminal")
                                    pFD2.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD2)
                                End If
                                Dim pFDdR As New FinanceDetails
                                pFDdR.CustomerId = CType(i.FindControl("HdnCustomerId"), HiddenField).Value
                                ' pFD2.CustomerId = lstCustomer.SelectedValue
                                Try
                                    pFDdR.DrAmount = Double.Parse(CType(i.FindControl("txtDrAmt"), TextBox).Text)
                                Catch ex As Exception
                                    pFDdR.DrAmount = 0
                                End Try
                                If pFDdR.DrAmount <> 0 Then
                                    pFDdR.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFDdR.Remarks = "DEBIT NOTE " & CType(i.FindControl("TextDrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFDdR.TrnType = "D"
                                    pFDdR.FNCType = "P"
                                    pFDdR.TrnValue = 18
                                    pFDdR.TerminalId = CType(i.FindControl("HdnDrNo"), HiddenField).Value
                                    pFDdR.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFDdR)
                                End If
                            End If
                            dblTempPrevBal = dblTempPrevBal - Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                        End If

                    End If
                End If
            Next
        ElseIf lstPaymentType.SelectedValue = "T" Then
            Dim pFDO As New FinanceDetails
            pFDO.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFDO.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFDO.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFDO.InvoiceNo = 0
            pFDO.TrnType = "T"
            pFDO.TrnValue = 14
            pFDO.FNCType = "P"
            pFDO.TerminalId = Session.Item("LoginTerminal")
            pFDO.Remarks = "On Account Payment "
            pFDO.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFDO)
        ElseIf lstPaymentType.SelectedValue = "S" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "S"
            pFD.TrnValue = 15
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.Remarks = "Advance Payment PDA "
            pFD.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFD)
        ElseIf lstPaymentType.SelectedValue = "V" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFD.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFD.InvoiceNo = 0
            pFD.TrnType = "V"
            pFD.TrnValue = 16
            pFD.FNCType = "P"
            If lstPurchaseType.SelectedValue = "L" Or lstPurchaseType.SelectedValue = "C" Then
                pFD.CustomerType = "C"
            Else
                pFD.CustomerType = "V"
            End If
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.Remarks = "Opening Balace "
            pFD.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFD)
        End If

        Dim dbltest As Long = textRecBalanceAmountTotal.Text
        Dim ModeOfPayment As String = ""
        Try
            ModeOfPayment = HdnpaymentMode.Value
        Catch ex As Exception
            ModeOfPayment = "I"
        End Try
        If Math.Round(dbltest, 0) > 0 And ModeOfPayment = "I" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textRecBalanceAmountTotal.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "R"
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.TrnValue = 2
            pFD.Remarks = "Advance Amount in Invoice Payment"
            pFD.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFD)
        End If

        Return p
    End Function
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If hdnReceiptNo.Value <> "" AndAlso hdnReceiptNo.Value <> Nothing Then
            ' Response.Redirect("Preview/ImportInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
            Response.Redirect("Preview/InvoiceIssueGST.aspx?ReceiptNo=" & hdnReceiptNo.Value)

        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvMain.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'If Not tvService.SelectedNode Is Nothing Then
        '    prepareControlsService(tvService.SelectedNode)
        'End If
        manageUserControls(True)
        ButtonControlSetup(True)
        btnDisplay.Visible = False
        btnSearchDisplay.Visible = False

        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnSearchDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textReceiptNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " Enter The Receipt No")
            Functions.ControlFocus(textReceiptNo)
            Return
        End If

        Dim p As New ExtInvoiceReceipt
        p.TerminalId = Session.Item("LoginTerminal")
        p.ReceiptRefNo = textReceiptNo.Text.Trim
        ExtInvoiceReceipt.ReturnInvoiceReceiptByRefNo(p)
        If p.ReceiptNo <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Receipt No")
            Functions.ControlFocus(textReceiptNo)
            Return
        End If

        ExtInvoiceReceipt.ReturnPaymentDetailsByReceiptNo(p)

        hdnReceiptNo.Value = p.ReceiptNo
        textReceiptNo.Text = p.ReceiptRefNo
        textReceiptdate.Text = p.ReceiptDate
        lstPaymentType.SelectedValue = p.ReceiptType
        Try
            lstCustomer.SelectedValue = p.CustomerId
        Catch ex As Exception

        End Try

        If p.ReceiptType = "A" Then
            fillRepeatorInvoice(New ArrayList)
        Else
            Dim arrList As New ArrayList
            For Each f As FinanceDetails In p.FinanceDetailsList
                If f.InvoiceNo = 0 Then
                    CType(repPaymentDetails.Items(0).FindControl("textRecBalanceAmount"), TextBox).Text = f.CrAmount
                    textRecBalanceAmountTotal.Text = f.CrAmount
                Else
                    arrList.Add(f)
                End If
            Next

            fillRepeatorInvoice(arrList)
        End If

        fillRepeatorPayment(p.PaymentDetailsList)
        Try
            textTotalAmount.Text = CType(repPaymentDetails.Items(0).FindControl("textPaymentAmount"), TextBox).Text
        Catch ex As Exception
            textTotalAmount.Text = CType(repPaymentDetails.Items(0).FindControl("HdnTotalPayment"), HiddenField).Value
        End Try

        ButtonControlSetup(True)
        manageUserControls(True)
        btnSearchDisplay.Visible = False
        btnDisplay.Visible = False
        Functions.ControlFocus(btnPrint)

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvMain.Controls)
        ButtonControlSetup(True)
        manageUserControls(False)
        manageRepatorReceipt(False)
        lstPaymentType.Enabled = False
        lstCustomer.Enabled = False
        textReceiptNo.Enabled = True
        btnDisplay.Visible = False
        btnSearchDisplay.Visible = True
        Functions.ControlFocus(textReceiptNo)
    End Sub

    Protected Sub repPaymentDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repPaymentDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textPaymentAmount"), TextBox).Text <> Nothing AndAlso CType(e.Item.FindControl("textPaymentAmount"), TextBox).Text <> Nothing Then
            End If
        End If

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Sub chkamt(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As CheckBox = sender
            'Dim hdnCont As Integer = 0
            'Dim txtQnty As Double = 0
            Dim txtRateI As Double = 0
            Dim dblamt As Double = 0
            Dim balamt As Double = 0
            Dim balamt2 As Double = 0
            'Dim dblbillamount As Double = 0
            'Dim txtTaxable As Double = 0
            'Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl".Length, txtRate.ClientID.IndexOf("_chkSelect") - "ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            Dim rep1 As RepeaterItem
            rep1 = repPaymentDetails.Items(0)
            txtRateI = CType(rep1.FindControl("HdnTotalPayment"), HiddenField).Value
            balamt = CType(rep1.FindControl("textRecBalanceAmount"), TextBox).Text

            rep = repInvoiceDetails.Items(index1 - 1)
            If txtRate.Checked = True Then
                dblamt += CType(rep.FindControl("textToPayAmount"), TextBox).Text
                If balamt >= dblamt Then
                    CType(rep.FindControl("textPaidAmount"), TextBox).Text = dblamt
                    'CType(rep.FindControl("textBalanceAmount"), TextBox).Text = 0
                    balamt = balamt - Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text)
                    CType(rep1.FindControl("textRecBalanceAmount"), TextBox).Text = Math.Round(balamt, 0)
                    'CType(rep.FindControl("TextCrAmt"), TextBox).Text = Math.Round(Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text), 0)
                    CType(rep.FindControl("textBalanceAmount"), TextBox).Text = Math.Round((Double.Parse(CType(rep.FindControl("textBalanceAmount"), TextBox).Text) - Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text)), 0)
                    btnSave.Visible = True
                Else
                    CType(rep.FindControl("textPaidAmount"), TextBox).Text = Math.Round(balamt, 0)
                    balamt2 = Double.Parse(CType(rep.FindControl("textBalanceAmount"), TextBox).Text) - balamt
                    CType(rep.FindControl("textBalanceAmount"), TextBox).Text = Math.Round(dblamt, 0)
                    balamt = balamt - Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text)
                    CType(rep1.FindControl("textRecBalanceAmount"), TextBox).Text = Math.Round(balamt, 0)
                    'CType(rep.FindControl("TextCrAmt"), TextBox).Text = Math.Round(Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text), 0)
                    CType(rep.FindControl("textBalanceAmount"), TextBox).Text = Math.Round((Double.Parse(CType(rep.FindControl("textBalanceAmount"), TextBox).Text) - Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text)), 0)
                    ' CType(rep.FindControl("textBalanceAmount"), TextBox).Text = Math.Round(dblamt, 0)
                    'lblErrorMessage.Text = "Entered amount is less than invoice amount"
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Entered amount is less than invoice amount")
                    'btnSave.Visible = False
                End If

                ' CType(rep.FindControl("textChequeDate"), TextBox).Enabled = True
                ' CType(rep.FindControl("lstBankName"), DropDownList).Enabled = True
                ' CType(rep.FindControl("textRecBalanceAmount"), TextBox).Enabled = True
            End If
            If txtRate.Checked = False Then
                Dim paid As Long = Double.Parse(CType(rep.FindControl("textPaidAmount"), TextBox).Text)
                Dim bal As Long = Double.Parse(CType(rep.FindControl("textBalanceAmount"), TextBox).Text)
                CType(rep.FindControl("textPaidAmount"), TextBox).Text = 0
                CType(rep1.FindControl("textRecBalanceAmount"), TextBox).Text = balamt + paid
                CType(rep.FindControl("textBalanceAmount"), TextBox).Text = bal + paid
                If Double.Parse(CType(rep1.FindControl("textRecBalanceAmount"), TextBox).Text) > 0 Then
                    btnSave.Visible = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub chkBalAmt(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As TextBox = sender
            'Dim hdnCont As Integer = 0
            'Dim txtQnty As Double = 0
            'Dim dblbillamount As Double = 0
            'Dim txtTaxable As Double = 0
            'Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl".Length, txtRate.ClientID.IndexOf("_textPaymentAmount") - "ctl00_ContentPlaceHolder1_repPaymentDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = repPaymentDetails.Items(index1 - 1)
            CType(rep.FindControl("textRecBalanceAmount"), TextBox).Text = CType(rep.FindControl("textPaymentAmount"), TextBox).Text
            textRecBalanceAmountTotal.Text = Double.Parse(CType(rep.FindControl("textRecBalanceAmount"), TextBox).Text)
        Catch ex As Exception
        End Try
    End Sub
    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As DropDownList = sender
            'Dim hdnCont As Integer = 0
            'Dim txtQnty As Double = 0
            'Dim txtRateI As Double = 0
            'Dim txtTaxable As Double = 0
            'Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl".Length, txtRate.ClientID.IndexOf("_lstPaymentMode") - "ctl00_ContentPlaceHolder1_repPaymentDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = repPaymentDetails.Items(index1 - 1)
            If txtRate.Text = "H" Then
                CType(rep.FindControl("textChequeNo"), TextBox).Enabled = True
                CType(rep.FindControl("textChequeDate"), TextBox).Enabled = True
                CType(rep.FindControl("lstBankName"), DropDownList).Enabled = True
                CType(rep.FindControl("lstReceiverBank"), DropDownList).Enabled = True
                CType(rep.FindControl("textRecBalanceAmount"), TextBox).Enabled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lstPaymentType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstPaymentType.SelectedIndexChanged
        If lstPaymentType.SelectedValue = "I" Then
            ' lstService.Enabled = False
            'lstService.SelectedValue = 0
        Else
            ' lstService.Enabled = True
        End If

    End Sub
    Sub chktds(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As TextBox = sender
            Dim hdnCont As Integer = 0
            Dim txtQnty As Double = 0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl".Length, txtRate.ClientID.IndexOf("_TextTdsAmt") - "ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = repInvoiceDetails.Items(index1 - 1)
            If txtRate.Text <> "" Then
                CType(rep.FindControl("textToPayAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(rep.FindControl("TextTdsAmt"), TextBox).Text) - Double.Parse(CType(rep.FindControl("TextCrAmt"), TextBox).Text)
                CType(rep.FindControl("textBalanceAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(rep.FindControl("TextTdsAmt"), TextBox).Text) - Double.Parse(CType(rep.FindControl("TextCrAmt"), TextBox).Text)
            End If
        Catch ex As Exception
        End Try
        manageControls()
    End Sub

    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        ListControlDataBind(lstPurchaseType.SelectedValue)
        lstPaymentType.Enabled = True
        lstCustomer.Enabled = True
        btnDisplay.Visible = True
    End Sub

    Protected Sub BtnSendMail_Click(sender As Object, e As System.EventArgs) Handles BtnSendMail.Click
        sendmail()
    End Sub
End Class


