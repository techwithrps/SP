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

Partial Class Commercial_PaymentCollection
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
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim strinvno As String = ""
    Dim MainStrInvNo As String = ""
    Dim TempStrInvNo As String = ""
    'Private Property lstPaymentType As WebControl
    <System.Web.Script.Services.ScriptMethod(), _
System.Web.Services.WebMethod()> _
    Public Shared Function SearchCrNote(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim strConn As String = "Provider=MSDAORA.1;User ID=spj;Password=spj; Max Pool Size=100; Min Pool Size=5; Data Source=XE"
        Dim con As New OleDbConnection(strConn)
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("Name", prefixText)
        cmd.CommandText = "SELECT UPPER(CR_REF_NO)CR_REF_NO FROM CR_NOTE C WHERE STATUS IS NULL AND  CR_REF_NO LIKE '%" & prefixText & "%'"
        cmd.Connection = con
        con.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As OleDbDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("CR_REF_NO").ToString)
        End While
        con.Close()
        Return customers
    End Function
    <WebMethod()> _
    Public Shared Function GetItemsDetails(ByVal Item As String, ByVal PrvCrNo As String, ByVal prvcrAmt As String, ByVal BalAmt As String, ByVal TextTdsAmt As String, ByVal textBillAmount As String, ByVal HdnCRAmt As String, ByVal HdnTdsAmt As String) As String
        Dim returnValue As String = ""
        Dim pCrNO, pBalAmt, totalCr, totalbal, totalCrAmt, pCrAmt, tds, HdnCRAmt1, totalRCV, hdnTdsAmt1 As Long
        'pBalAmt = Convert.ToInt64(BalAmt)
        tds = Convert.ToInt64(TextTdsAmt)
        'billamount = Convert.ToInt64(textBillAmount)
        HdnCRAmt1 = Convert.ToInt64(HdnCRAmt)
        hdnTdsAmt1 = Convert.ToInt64(HdnTdsAmt)
        totalRCV = Double.Parse(HdnCRAmt1) + Double.Parse(HdnTdsAmt)
        pBalAmt = Double.Parse(totalRCV) - Double.Parse(tds)
        Dim pCrNote As New CrNote
        pCrNote.CrRefNo = Item.Trim
        CrNote.ReturnCreaditNotebyCrRefNo(pCrNote)
        Dim pInvoice As New ImpInvoice
        pInvoice.InvoiceNo = pCrNote.InvoiceID
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pInvoice)
        If prvcrAmt <> "" Then
            pCrAmt = Convert.ToInt64(prvcrAmt)
        Else
            pCrAmt = 0
        End If
        Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection
        If PrvCrNo <> "" Then
            pCrNO = Convert.ToInt64(PrvCrNo)
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE CR_NOTE SET BAL_AMT=NVL(BAL_AMT,(CR_AMOUNT + CR_TAX)) + " & pCrAmt & " WHERE CR_ID= " & pCrNO, con)
            cmd1.ExecuteNonQuery()
            con.Close()
        Else
            pCrNO = 0
        End If

        totalCr = Double.Parse(pCrNote.CrTax) + Double.Parse(pCrNote.CrAmt)
        If totalCr >= pBalAmt Then
            totalbal = 0
            totalCrAmt = pBalAmt
        Else
            totalbal = pBalAmt - totalCr
            totalCrAmt = totalCr
        End If
        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE CR_NOTE SET BAL_AMT=NVL(BAL_AMT,(CR_AMOUNT + CR_TAX)) - " & totalCrAmt & " WHERE CR_ID= " & pCrNote.CrId, con)
        cmd.ExecuteNonQuery()
        con.Close()

        returnValue = pCrNote.CrAmt & "," & pInvoice.BillTo & "," & pCrNote.CrRefNo & "," & pCrNote.CrId & "," & pCrNote.CrTax & "," & totalbal & "," & totalCrAmt
        Return returnValue.Trim
    End Function
    <WebMethod()> _
    Public Shared Function UpDateCrAmt(ByVal CrNo As String, ByVal PrvAmt As String, ByVal CurAmt As String) As String
        Dim returnValue As String = ""
        Dim CrId, pAmt, Camt As Long
        CrId = Convert.ToInt64(CrNo)
        pAmt = Convert.ToInt64(PrvAmt)
        Camt = Convert.ToInt64(CurAmt)
        Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection
        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE CR_NOTE SET BAL_AMT=NVL(BAL_AMT,(CR_AMOUNT + CR_TAX)) + " & pAmt & " -  " & Camt & " WHERE CR_ID= " & CrId, con)
        cmd.ExecuteNonQuery()
        con.Close()
        returnValue = 0
        Return returnValue.Trim
    End Function
    'Sub Page_Error(Sender As Object, e As EventArgs)
    '    Dim objErr As Exception = Server.GetLastError().GetBaseException()
    '    Dim err As String = "<b>Error Caught in Page_Error event</b><hr><br>" & _
    '      "<br><b>Error in: </b>" & Request.Url.ToString() & _
    '      "<br><b>Error Message: </b>" & objErr.Message.ToString() & _
    '      "<br><b>Stack Trace:</b><br>" & _
    '      objErr.StackTrace.ToString()
    '    Response.Write(err.ToString())
    '    Server.ClearError()
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            manageUserControls(True)
            ListControlDataBind()
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
            lstPaymentType.SelectedValue = "I"
            CType(repPaymentDetails.Items(0).FindControl("textRecBalanceAmount"), TextBox).Text = 0
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

    Sub ListControlDataBind()
        Dim pExtCustomerMaster As New ExtCustomerMaster
        pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAll(pExtCustomerMaster)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Add(New ListItem("-- Select --  ", "0"))

        Dim pServiceMaster As New ServiceMaster
        pServiceMaster.TerminalId = Session.Item("LoginTerminal")
        lstService.DataSource = ServiceMaster.ReturnServiceMasterList(pServiceMaster)
        lstService.DataTextField = "ServiceName"
        lstService.DataValueField = "ServiceId"
        lstService.DataBind()
        lstService.Items.Add(New ListItem("-- Select --  ", "0"))
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
            CType(rep.FindControl("textPartyInvNo"), TextBox).Enabled = False
            CType(rep.FindControl("textInvoiceMode"), TextBox).Enabled = False
            CType(rep.FindControl("textBillAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textToPayAmount"), TextBox).Enabled = True
            CType(rep.FindControl("textWaiverAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textBalanceAmount"), TextBox).Enabled = True
            CType(rep.FindControl("textPaidAmount"), TextBox).Enabled = True
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True

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
        lstService.Enabled = True
        textTotalAmount.Text = 0
        textRecBalanceAmountTotal.Text = 0
        TxtRemarks.Enabled = True
        Functions.ControlFocus(lstPaymentType)
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        searchPendingPayment()
    End Sub
    Sub searchPendingPayment()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerId = lstCustomer.SelectedValue
        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)

        Dim pState As New StateCodeMaster
        pState.StateCode = pCustomerMaster.StateCode
        StateCodeMaster.ReturnStateByCode(pState)
        textStateName.Text = pState.StateName
        hdnStateCode.Value = pState.StateCode
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
        If lstCustomer.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Select Customer")
            Functions.ControlFocus(lstCustomer)
            Return
        End If
        If lstPaymentType.SelectedValue = "I" Then
            Dim p As New FinanceDetails
            p.TerminalId = Session.Item("LoginTerminal")
            p.CustomerId = lstCustomer.SelectedValue
            '''''''''''Changed By : Amit on dated 21/08/2012''''''''''''''''''''''''''''
            '''''''''''Invoice Payment redirected from invoige screen'''''''''''''''''''
            p.InvoiceNo = lngInvoiceNo
            Dim arr As ArrayList
            If lngInvoiceNo > 0 Then
                p.TerminalId = lngTerminalId
                arr = FinanceDetails.ReturnInvoiceListByCustomerInvoice(p, lstPaymentType.SelectedValue)
            Else
                p.TerminalId = Session.Item("CompanyId")
                arr = FinanceDetails.ReturnInvoiceListByCustomer(p, lstPaymentType.SelectedValue)
                btnSave.Visible = True
            End If
            'Dim arr As ArrayList = FinanceDetails.ReturnInvoiceListByCustomer(p, lstPaymentType.SelectedValue)
            If arr.Count <= 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "No Invoice for Collection")
                Functions.ControlFocus(lstCustomer)
                Return
            End If
            FinanceDetails.ReturnPreviousReceiptBalanceByCustomer(p)
            If p.ReceiptNo > 0 Then
                Dim pRec As New InvoiceReceipt
                pRec.ReceiptNo = p.ReceiptNo
                InvoiceReceipt.ReturnInvoiceReceiptByNo(pRec)
                hdnPreviousReceiptNo.Value = pRec.ReceiptNo
                textPreviousReceiptNo.Text = pRec.ReceiptRefNo
                textPreviousBalance.Text = p.CrAmount
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
        Dim dbr, DBR1 As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PAYMENT_COLLECTION", strpParms)
        gvOnAccountDtls.DataSource = dbr
        gvOnAccountDtls.DataBind()
        gvOnAccountDtls.Visible = True
        DBR1 = db.StoredProcedureReadDB("REPORT_PKG.SP_CREDIT_COLLECTION", strpParms)
        GvPendingCrNOte.DataSource = DBR1
        GvPendingCrNOte.DataBind()
        GvPendingCrNOte.Visible = True
        ButtonControlSetup(False)
        manageControls()
        textReceiptdate.Enabled = True
        textReceiptNo.Enabled = False
        btnDisplay.Visible = False
        btnSearchDisplay.Visible = False
    End Sub
    Sub manageControls()
        lstCustomer.Enabled = False
        lstPaymentType.Enabled = False
        textReceiptdate.Enabled = False
        textReceiptNo.Enabled = False
    End Sub
    Sub repInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> "0" _
            AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value > 0 Then
                'If CType(e.Item.FindControl("HdnTrnType"), HiddenField).Value = "B" Then
                'CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = "Opening Amount"
                'Dim pf As New FinanceDetails
                'pf.ReceiptNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                'pf.TerminalId = Session.Item("LoginTerminal")
                'FinanceDetails.ReturnFinanceDetailsByReceiptNo(pf)
                'CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = pf.CrAmount

                'Else
                Dim p As New ExtImpInvoice
                p.TerminalId = Session.Item("LoginTerminal")
                p.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                ExtImpInvoice.ReturnImpInvoiceByInvoiceNo(p)
                CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = p.InvoiceRefNo
                CType(e.Item.FindControl("textInvoiceDate"), TextBox).Text = p.InvoiceDate
                CType(e.Item.FindControl("textInvoiceMode"), TextBox).Text = IIf(p.PaymentMode = "C", "Cash", "Credit")
                'CType(e.Item.FindControl("hdnBookingNo"), HiddenField).Value = p.LineItemId
                CType(e.Item.FindControl("hdnTaxExemptionPerc"), HiddenField).Value = p.TaxExemptionPerc
                'Dim pImpInvoiceItems As New ImpInvoiceItems
                'pImpInvoiceItems.TerminalId = Session.Item("LoginTerminal")
                'pImpInvoiceItems.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                'ImpInvoiceItems.ReturnImpInvoiceItemsWaiver(pImpInvoiceItems)
                CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text = 0


                lngInvoiceNo = Request.QueryString("InvoiceNo")
                Dim pFleetContJo As New AllPartyAccount
                pFleetContJo.ContJoId = p.LineItemId
                AllPartyAccount.ReturnAllPartyAccountByContJoId(pFleetContJo)
                CType(e.Item.FindControl("textPartyInvNo"), TextBox).Text = pFleetContJo.PartyInvNo

                Dim pf As New FinanceDetails
                pf.InvoiceNo = p.InvoiceNo
                pf.TerminalId = Session.Item("LoginTerminal")
                FinanceDetails.ReturnToPayAmountByInvoiceNo(pf)
                CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = pf.CrAmount

                Dim pFD As New FinanceDetails
                pFD.TerminalId = p.TerminalId
                pFD.InvoiceNo = p.InvoiceNo
                FinanceDetails.ReturnFinanceDetailsSumByInvoiceNo(pFD)
                Dim tda As Long = 0
                If CType(e.Item.FindControl("HdnTrnType"), HiddenField).Value = "B" Then
                    CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = "OPENING BALANCE"
                End If
                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
                pCustomerMaster.CustomerId = lstCustomer.SelectedValue
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                If CType(e.Item.FindControl("HdnTrnType"), HiddenField).Value = "N" Then
                    If p.CompanyId = 1 Then
                        If pCustomerMaster.TDS = "Y" Then
                            tda = Double.Parse(CType(e.Item.FindControl("TextBaseAmount"), TextBox).Text) * 1 / 100
                        Else
                            tda = 0
                        End If
                    ElseIf p.CompanyId = 4 Then
                        If pCustomerMaster.TDS = "Y" Then
                            tda = Double.Parse(CType(e.Item.FindControl("TextBaseAmount"), TextBox).Text) * 1 / 100
                        Else
                            tda = 0
                        End If
                    ElseIf p.CompanyId = 2 Then
                        If pCustomerMaster.TDS = "Y" Then
                            tda = Double.Parse(CType(e.Item.FindControl("TextBaseAmount"), TextBox).Text) * 2 / 100
                        Else
                            tda = 0
                        End If
                    End If
                End If

                CType(e.Item.FindControl("TextTdsAmt"), TextBox).Text = tda
                CType(e.Item.FindControl("HdnTdsAmt"), HiddenField).Value = tda
                CType(e.Item.FindControl("HdnTdsAmt1"), HiddenField).Value = tda
                Dim ToPayAmount As Double = 0.0
                CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = Double.Parse(CType(e.Item.FindControl("textBillAmount"), TextBox).Text) - pFD.CrAmount - tda
                ToPayAmount = Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text)
                CType(e.Item.FindControl("HdnRcvAmt"), HiddenField).Value = Double.Parse(CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text) + pFD.CrAmount + tda
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
                dblPaidAmountTotal += Double.Parse(CType(e.Item.FindControl("textPaidAmount"), TextBox).Text)
                Try
                    dblWaiverAmountTotal += Double.Parse(CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dbltdsamt += Double.Parse(CType(e.Item.FindControl("TextTdsAmt"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    dblbaseAmounttotal += Double.Parse(CType(e.Item.FindControl("TextBaseAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True

        If textToPayAmountTotal.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Payment Details.")
            Functions.ControlFocus(lstCustomer)
            rtnBool = False
        End If
        If textReceiptdate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Payment Date.")
            Functions.ControlFocus(textReceiptdate)
            rtnBool = False
        End If
        Dim textPaymentAmount As Double = 0.0
        Try
            Try
                textPaymentAmount = CType(repPaymentDetails.Items(0).FindControl("hdnPaymentAmount"), HiddenField).Value
                textTotalAmount.Text = textPaymentAmount
            Catch ex As Exception
                textPaymentAmount = CType(repPaymentDetails.Items(0).FindControl("textPaymentAmount"), TextBox).Text
                textTotalAmount.Text = textPaymentAmount
            End Try
        Catch ex As Exception
            textTotalAmount.Text = 0
        End Try


        Dim textRecBalanceAmount As TextBox = repPaymentDetails.Items(0).FindControl("textRecBalanceAmount")
        If lstPaymentType.SelectedValue = "I" Then
            textRecBalanceAmount.Text = Double.Parse(textPreviousBalance.Text) + Double.Parse(textPaymentAmount)
        End If
        Dim lstPaymentMode As DropDownList = repPaymentDetails.Items(0).FindControl("lstPaymentMode")
        Dim textChequeNo As TextBox = repPaymentDetails.Items(0).FindControl("textChequeNo")
        Dim textChequeDate As TextBox = repPaymentDetails.Items(0).FindControl("textChequeDate")
        If lstPaymentMode.SelectedValue = "R" Then
            If textChequeDate.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Cheque Date.")
                Functions.ControlFocus(textChequeDate)
                rtnBool = False
            End If
            If textChequeNo.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Cheque no.")
                Functions.ControlFocus(textChequeNo)
                rtnBool = False
            End If
        End If
        For Each rep As RepeaterItem In repInvoiceDetails.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then


                Dim textInvoiceMode As TextBox = rep.FindControl("textInvoiceMode")
                Dim textBalanceAmount As TextBox = rep.FindControl("textBalanceAmount")
                Dim hdnBalanceAmount As HiddenField = rep.FindControl("hdnBalanceAmount")
                Dim textToPayAmount As TextBox = rep.FindControl("textToPayAmount")
                Dim textPaidAmount As TextBox = rep.FindControl("textPaidAmount")

                If hdnBalanceAmount.Value = Nothing Then
                    hdnBalanceAmount.Value = 0
                End If

                If textRecBalanceAmount.Text.Trim = Nothing Then
                    textRecBalanceAmount.Text = 0
                End If
                If textPaidAmount.Text.Trim = Nothing Then
                    textPaidAmount.Text = 0
                End If
                If textBalanceAmount.Text.Trim = Nothing Then
                    textBalanceAmount.Text = 0
                End If
                If textToPayAmount.Text.Trim = Nothing Then
                    textToPayAmount.Text = 0
                End If

                'If Double.Parse(textPaidAmount.Text) > Double.Parse(textRecBalanceAmount.Text) And Double.Parse(textPaidAmount.Text) > 0 Then
                '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Not Sufficent Balance")
                '    Functions.ControlFocus(textRecBalanceAmount)
                '    rtnBool = False
                'End If
                'If Double.Parse(textPaidAmount.Text) > Double.Parse(textToPayAmount.Text) And Double.Parse(textPaidAmount.Text) > 0 Then
                '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Paid Amount should not be more than Invoice Balance Amount")
                '    Functions.ControlFocus(textPaidAmount)
                '    rtnBool = False
                'End If
                'If textInvoiceMode.Text = "Cash" And Double.Parse(textPaidAmount.Text) <> Double.Parse(textToPayAmount.Text) And Double.Parse(textPaidAmount.Text) > 0 Then
                '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "For Cash Invoice, Invoice Paid Amount should be equal to Invoice Balance Amount ")
                '    Functions.ControlFocus(textPaidAmount)
                '    rtnBool = False
                'End If

                textBalanceAmount.Text = Double.Parse(hdnBalanceAmount.Value) - Double.Parse(textPaidAmount.Text)

                dblPaidAmountTotal += Double.Parse(textPaidAmount.Text)
                textPaidAmountTotal.Text = dblPaidAmountTotal

                dblBalanceAmountTotal += Double.Parse(textBalanceAmount.Text)
                textBalanceAmountTotal.Text = dblBalanceAmountTotal

                textRecBalanceAmount.Text = Double.Parse(textRecBalanceAmount.Text) - Double.Parse(textPaidAmount.Text)
                textRecBalanceAmountTotal.Text = textRecBalanceAmount.Text
            End If
        Next

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
        Dim pExtInvoiceReceipt As ExtInvoiceReceipt = ReturnObject1()
        'If pExtInvoiceReceipt.PaymentDetailsList.Count <= 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Enter Payment Details")
        '    'Functions.ControlFocus(repPayment)
        '    Return
        'End If
        If pExtInvoiceReceipt.FinanceDetailsList.Count <= 0 And lstPaymentType.SelectedValue = "I" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Enter Invoice Details")
            'Functions.ControlFocus(repPayment)
            Return
        End If

        ExtInvoiceReceipt.InsertTransaction(pExtInvoiceReceipt)

        If pExtInvoiceReceipt.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, pExtInvoiceReceipt.Errormsg)
            Functions.ControlFocus(btnSave)
            Return
        End If

        textReceiptdate.Text = pExtInvoiceReceipt.ReceiptDate
        textReceiptNo.Text = pExtInvoiceReceipt.ReceiptRefNo
        hdnReceiptNo.Value = pExtInvoiceReceipt.ReceiptNo
        ButtonControlSetup(True)
        manageUserControls(True)
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmd As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET PAYMENT_STATUS='Y' WHERE INVOICE_NO IN (SELECT INVOICE_NO FROM (SELECT INVOICE_NO, SUM (CR) CR,SUM(DR_AMT) DR FROM " &
                                     " (SELECT ROUND(SUM(CR_AMOUNT))CR,INVOICE_NO,0 DR_AMT FROM FINANCE_DETAILS WHERE FNC_TYPE IS NULL AND TRN_TYPE='R' GROUP BY INVOICE_NO " &
                                     "  UNION " &
                                     " SELECT 0 CR,INVOICE_NO, ROUND(SUM(BILL_AMOUNT))DR FROM IMP_INVOICE_ITEMS III  GROUP BY INVOICE_NO)GROUP BY INVOICE_NO) WHERE CR + 2 >= DR)", con)
            'nvert.ToInt32(ddlCFS.SelectedValue) & ",BOOKING_NO = '" & txtBL_NO.Text & "',POL_ID = " & ddlPOL.SelectedValue & ",POL='" & ddlPOL.SelectedItem.Text & "',TRAIN_NO='" & txtTrainNo.Text.Trim & "',TRAIN_OUT_DATE=TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY'),REQUIRED_ETD=TO_DATE('" & txtETD.Text & "','DD/MM/YYYY'),REQUIRED_VESSEL='" & txtREQUIRED_VESSEL.Text & "',CURRENT_ETD=TO_DATE('" & txtETD.Text & "','DD/MM/YYYY'),CURRENT_VESSEL='" & txtREQUIRED_VESSEL.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        'sendmail()
    End Sub
    Sub sendmail()
        Dim FileToDelete As String = "D:\software\JSB\Payment\Received\"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
        Dim pInvoice As New InvoiceReceipt
        pInvoice.TerminalId = Session.Item("LoginTerminal")
        pInvoice.ReceiptNo = hdnReceiptNo.Value
        InvoiceReceipt.ReturnInvoiceReceiptByNo(pInvoice)
        strinvno = pInvoice.ReceiptRefNo
        strinvno = strinvno.Replace("\", "-")

        'HtmlToPdf(" http://localhost:15987/LogiParkWeb/(S(uadlqxwx25n4e52y444nat1y))/Commercial/Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & hdnReceiptNo.Value, "C:\\Software\JSB\Payment\Received\" & strinvno & ".pdf")
        HtmlToPdf("http://115.124.127.54/JSB/(S(sbgtygixqzxuonofc5aoocu4))/Commercial/Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & hdnReceiptNo.Value, "D:\\Software\JSB\Payment\Received\" & strinvno & ".pdf")
        'Response.Redirect("Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & hdnReceiptNo.Value)
        TempStrInvNo = "D:\software\JSB\Payment\Received\" & strinvno & ".pdf"
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
        xMailSetup = " Dear Sir,"
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Please find enclosed payment receipt confirmation of Cheque/UTR No. " & pPaymeme.ChequeNo & "  of amount " & pPaymeme.Amount & " dated: " & pPaymeme.ChequeDate & " against our invoices mentioned in the attachment."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "Kindly adjust the payment accordingly."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"

        xMailSetup &= "Thanks & Regards " & "<br>"
        xMailSetup &= " SPJ ACCOUNTS TEAM "
        Dim pcus As New CustomerMaster
        pcus.CustomerId = lstCustomer.SelectedValue
        CustomerMaster.ReturnCustomerMaster(pcus)
        Dim tomail As String = ""
        Try
            'tomail = "vrohit248@gmail.com"
            tomail = pcus.EmailCommercial
        Catch ex As Exception
            tomail = "vrohit248@gmail.com"
        End Try
        Dim pStr As String = ""
        Dim SUBJECT As String = "Payment Receipt Confirmation - " & lstCustomer.SelectedItem.Text & " - Receipt No - " & textReceiptNo.Text & "- UTR:- " & pPaymeme.ChequeNo & " - Rs." & pPaymeme.Amount & " - Date " & pPaymeme.ChequeDate & "."
        pStr = sendMailToCcBccWithAttachmentExcel("vrohit248@gmail.com", TempStrInvNo, tomail, "vrohit248@gmail.com,vrohit248@gmail.com,rohit@elogisol.in", "lalit@elogisol.in", SUBJECT, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "01!", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
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
        p.TerminalId = Session.Item("LoginTerminal")
        p.CreatedOn = textReceiptdate.Text
        p.PaymentDetailsList = New ArrayList
        p.FinanceDetailsList = New ArrayList
        Dim receipt As Long = 0
        Try
            receipt = hdnReceiptNo.Value
        Catch ex As Exception
            receipt = 0
        End Try

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
                    pPD.ServiceId = lstService.SelectedValue
                    pPD.StateCode = hdnStateCode.Value
                    p.PaymentDetailsList.Add(pPD)
                Else
                    DrCr = "D"
                    Dim pPD As New PaymentDetails
                    pPD.Amount = 0
                    pPD.ReceiptMode = "N"
                    Try
                        pPD.ChequeNo = "CREDIT NOTE"
                    Catch ex As Exception
                    End Try
                    ' pPD.ChequeDate = CType(r.FindControl("textChequeDate"), TextBox).Text
                    pPD.BankId = 0
                    pPD.ReceiverBankId = 0
                    pPD.TerminalId = Session.Item("LoginTerminal")
                    pPD.ServiceId = lstService.SelectedValue
                    pPD.StateCode = hdnStateCode.Value
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
        If lstPaymentType.SelectedValue = "I" Then
            For Each i As RepeaterItem In repInvoiceDetails.Items
                Dim tempCrAmount As Double = 0
                If CType(i.FindControl("textPaidAmount"), TextBox).Text <> Nothing AndAlso CType(i.FindControl("textPaidAmount"), TextBox).Text > 0 Then
                    If dblTempPrevBal = 0 Then

                        If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then
                            'tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text))
                            Try
                                tempCrAmount = Double.Parse(CType(i.FindControl("TextTdsAmt"), TextBox).Text)
                            Catch ex As Exception
                                tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                            End Try

                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                            'pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.CrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.TrnType = "R"
                            pFD.TrnValue = 3
                            If receipt >= 0 Then
                                pFD.ReceiptNo = receipt
                            End If
                            pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            pFD.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD)

                            Dim pFD1 As New FinanceDetails
                            pFD1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                            'pFD.CustomerId = lstCustomer.SelectedValue
                            pFD1.CrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD1.TrnType = "R"
                            pFD1.TrnValue = 2
                            If receipt >= 0 Then
                                pFD1.ReceiptNo = receipt
                            End If
                            pFD1.TerminalId = Session.Item("LoginTerminal")
                            pFD1.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD1)
                            Dim pFdCr As New FinanceDetails
                            pFdCr.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                            'pFD.CustomerId = lstCustomer.SelectedValue
                            pFdCr.CrAmount = Double.Parse(CType(i.FindControl("TextCrAmt"), TextBox).Text)
                            pFdCr.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFdCr.Remarks = "CREDIT NOTE " & CType(i.FindControl("TextCrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFdCr.TrnType = "R"
                            pFdCr.TrnValue = 4
                            If receipt >= 0 Then
                                pFdCr.ReceiptNo = receipt
                            End If
                            pFdCr.TerminalId = Session.Item("LoginTerminal")
                            pFdCr.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFdCr)
                        Else
                            ' If CType(i.FindControl("HdnTrnType"), HiddenField).Value <> "B" Then
                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            tempCrAmount = tempCrAmount
                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                            'pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.CrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TrnType = "R"
                            If receipt >= 0 Then
                                pFD.ReceiptNo = receipt
                            End If
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            pFD.TrnValue = 2
                            pFD.CompanyId = Session.Item("CompanyId")
                            p.FinanceDetailsList.Add(pFD)
                            'End If
                            'If CType(i.FindControl("HdnTrnType"), HiddenField).Value = "B" Then
                            '    tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            '    tempCrAmount = tempCrAmount
                            '    Dim pFD As New FinanceDetails
                            '    pFD.CustomerId = lstCustomer.SelectedValue
                            '    pFD.CrAmount = tempCrAmount
                            '    pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            '    If receipt >= 0 Then
                            '        pFD.ReceiptNo = receipt
                            '    End If
                            '    ' pFD.ReceiptNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            '    pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            '    pFD.TrnType = "B"
                            '    pFD.TerminalId = Session.Item("LoginTerminal")
                            '    pFD.TrnValue = 2
                            '    pFD.CompanyId = Session.Item("CompanyId")
                            '    p.FinanceDetailsList.Add(pFD)
                            'End If
                        End If

                    ElseIf dblTempPrevBal > 0 Then
                        If dblTempPrevBal < Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then
                            tempCrAmount = dblTempPrevBal
                            Dim dblTemp As Double = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) - dblTempPrevBal
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then
                                Try
                                    tempCrAmount = Double.Parse(CType(i.FindControl("TextTdsAmt"), TextBox).Text)
                                Catch ex As Exception
                                    tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                End Try
                                'tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TrnType = "R"
                                pFD.TrnValue = 3
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD1.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.CrAmount = dblTempPrevBal
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "R"
                                If receipt >= 0 Then
                                    pFD1.ReceiptNo = receipt
                                End If
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                pFD1.TrnValue = 2
                                pFD1.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD1)

                                If dblTemp > 0 Then
                                    Try
                                        tempCrAmount = Double.Parse(CType(i.FindControl("TextTdsAmt"), TextBox).Text)
                                    Catch ex As Exception
                                        tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                    End Try
                                    'tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTemp)
                                    tempCrAmount = tempCrAmount
                                    Dim temp As New FinanceDetails
                                    temp.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                    'pFD.CustomerId = lstCustomer.SelectedValue
                                    temp.CrAmount = tempCrAmount
                                    temp.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp.TrnType = "R"
                                    temp.TrnValue = 3
                                    If receipt >= 0 Then
                                        pFD.ReceiptNo = receipt
                                    End If
                                    temp.TerminalId = Session.Item("LoginTerminal")
                                    pFD.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(temp)

                                    Dim temp1 As New FinanceDetails
                                    temp1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                    'temp1.CustomerId = lstCustomer.SelectedValue
                                    temp1.CrAmount = dblTemp
                                    temp1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp1.TrnType = "R"
                                    temp1.TrnValue = 2
                                    If receipt >= 0 Then
                                        temp1.ReceiptNo = receipt
                                    End If
                                    temp1.TerminalId = Session.Item("LoginTerminal")
                                    temp1.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(temp1)

                                End If
                                dblTempPrevBal = 0
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = dblTempPrevBal
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 2
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)

                                If dblTemp > 0 Then
                                    Dim pFD1 As New FinanceDetails
                                    pFD1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                    'pFD1.CustomerId = lstCustomer.SelectedValue
                                    pFD1.CrAmount = dblTemp
                                    pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD1.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD1.TrnType = "R"
                                    pFD1.TerminalId = Session.Item("LoginTerminal")
                                    pFD1.TrnValue = 2
                                    If receipt >= 0 Then
                                        pFD1.ReceiptNo = receipt
                                    End If
                                    pFD1.CompanyId = Session.Item("CompanyId")
                                    p.FinanceDetailsList.Add(pFD1)
                                End If
                                dblTempPrevBal = 0
                            End If

                        ElseIf dblTempPrevBal >= Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then

                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then

                                ' tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                Try
                                    tempCrAmount = Double.Parse(CType(i.FindControl("TextTdsAmt"), TextBox).Text)
                                Catch ex As Exception
                                    tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                                End Try
                                tempCrAmount = tempCrAmount

                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TrnValue = 3
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.CrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "R"
                                pFD1.TrnValue = 2
                                If receipt >= 0 Then
                                    pFD1.ReceiptNo = receipt
                                End If
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                pFD1.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD1)
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                                'pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                If receipt >= 0 Then
                                    pFD.ReceiptNo = receipt
                                End If
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 2
                                pFD.CompanyId = Session.Item("CompanyId")
                                p.FinanceDetailsList.Add(pFD)
                            End If
                            dblTempPrevBal = dblTempPrevBal - Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                        End If

                    End If
                End If
            Next
        ElseIf lstPaymentType.SelectedValue = "O" Then
            Dim pFDO As New FinanceDetails
            pFDO.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFDO.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFDO.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFDO.InvoiceNo = 0
            pFDO.TrnType = "O"
            pFDO.TrnValue = 9
            pFDO.TerminalId = Session.Item("LoginTerminal")
            pFDO.Remarks = "On Account Payment "
            pFDO.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFDO)
        ElseIf lstPaymentType.SelectedValue = "A" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "A"
            pFD.TrnValue = 2
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.Remarks = "Advance Payment PDA "
            pFD.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFD)
        ElseIf lstPaymentType.SelectedValue = "B" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFD.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFD.InvoiceNo = 0
            pFD.TrnType = "B"
            pFD.TrnValue = 11
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
        ' lstPaymentType.SelectedValue = "I"
        'If Math.Round(dbltest, 0) > 0 And ModeOfPayment = "I" Then
        If Math.Round(dbltest, 0) > 0 And lstPaymentType.SelectedValue = "I" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textRecBalanceAmountTotal.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "O"
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.TrnValue = 9
            pFD.Remarks = "Advance Amount in Invoice Payment"
            pFD.CompanyId = Session.Item("CompanyId")
            p.FinanceDetailsList.Add(pFD)
        End If

        Return p
    End Function
    Function ReturnObject1() As ExtInvoiceReceipt
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
        p.TerminalId = Session.Item("CompanyId")
        p.ReceiptType = lstPaymentType.SelectedValue

        p.CreatedOn = textReceiptdate.Text
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
                    Try
                        pPD.BankId = CType(r.FindControl("lstBankName"), DropDownList).SelectedValue
                    Catch ex As Exception
                    End Try
                    Try
                        pPD.ReceiverBankId = CType(r.FindControl("lstReceiverBank"), DropDownList).SelectedValue
                    Catch ex As Exception
                    End Try
                    pPD.TerminalId = Session.Item("LoginTerminal")
                    pPD.ServiceId = lstService.SelectedValue
                    pPD.StateCode = hdnStateCode.Value
                    p.PaymentDetailsList.Add(pPD)
                Else
                    DrCr = "C"
                    Dim pPD As New PaymentDetails
                    pPD.Amount = 0
                    pPD.ReceiptMode = "N"
                    Try
                        pPD.ChequeNo = "CREDIT NOTE"
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

                    pPD.ServiceId = lstService.SelectedValue
                    pPD.StateCode = hdnStateCode.Value
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
        If lstPaymentType.SelectedValue = "I" Then
            For Each i As RepeaterItem In repInvoiceDetails.Items
                Dim tempCrAmount As Double = 0
                Dim CrNoteAmount As Double = 0
                Try
                    CrNoteAmount = Double.Parse(CType(i.FindControl("TextCrAmt"), TextBox).Text)
                Catch ex As Exception
                    CrNoteAmount = Double.Parse(CType(i.FindControl("hdnCrAmt1"), HiddenField).Value)
                End Try
                Try
                    tempCrAmount = Double.Parse(CType(i.FindControl("TextTdsAmt"), TextBox).Text)
                Catch ex As Exception
                    tempCrAmount = Double.Parse(CType(i.FindControl("HdnTdsAmt1"), HiddenField).Value)
                End Try
                Dim paid As Double = 0
                Try
                    paid = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) + tempCrAmount + CrNoteAmount
                Catch ex As Exception
                    paid = Double.Parse(CType(i.FindControl("hdnPaidAmt"), HiddenField).Value) + tempCrAmount + CrNoteAmount
                End Try

                Dim diff As Double = Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) + Double.Parse(CType(i.FindControl("HdnTdsAmt"), HiddenField).Value) - paid


                If CType(i.FindControl("chkSelect"), CheckBox).Checked = True Then
                    Dim pFD As New FinanceDetails
                    pFD.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                    'pFD.CustomerId = lstCustomer.SelectedValue
                    pFD.CrAmount = tempCrAmount
                    pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                    pFD.TrnType = "R"
                    pFD.TrnValue = 3
                    If receipt >= 0 Then
                        pFD.ReceiptNo = receipt
                    End If
                    pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text & " ADJUSTED BY " & Session.Item("LoginUser")
                    pFD.TerminalId = 0
                    pFD.CompanyId = Session.Item("CompanyId")
                    If diff > 0 Then
                        pFD.CreatedOn = "P"
                    Else
                        pFD.CreatedOn = "Y"
                    End If
                    p.FinanceDetailsList.Add(pFD)

                    Dim pFD1 As New FinanceDetails
                    pFD1.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                    'pFD.CustomerId = lstCustomer.SelectedValue
                    Try
                        pFD1.CrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                    Catch ex As Exception
                        pFD1.CrAmount = 0
                    End Try

                    pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                    pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text & " ADJUSTED BY " & Session.Item("LoginUser")
                    pFD1.TrnType = "R"
                    pFD1.TrnValue = 2
                    If receipt >= 0 Then
                        pFD1.ReceiptNo = receipt
                    End If
                    pFD1.TerminalId = 0
                    pFD1.CompanyId = Session.Item("CompanyId")
                    'pFD1.CreatedOn = "Y"
                    If diff > 0 Then
                        pFD1.CreatedOn = "P"
                    Else
                        pFD1.CreatedOn = "Y"
                    End If
                    p.FinanceDetailsList.Add(pFD1)
                    If CrNoteAmount > 0 Then
                        Dim pFdCr As New FinanceDetails
                        pFdCr.CustomerId = CType(i.FindControl("hdnCustomerID"), HiddenField).Value
                        'pFD.CustomerId = lstCustomer.SelectedValue
                        ' Try
                        ' pFdCr.CrAmount = Double.Parse(CType(i.FindControl("TextCrAmt"), TextBox).Text)
                        ' Catch ex As Exception
                        pFdCr.CrAmount = CrNoteAmount
                        ' End Try

                        pFdCr.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                        pFdCr.Remarks = "CREDIT NOTE " & CType(i.FindControl("TextCrNo"), TextBox).Text & " Adjustment Against Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text & " ADJUSTED BY " & Session.Item("LoginUser")
                        pFdCr.TrnType = "N"
                        pFdCr.TrnValue = 4
                        If receipt >= 0 Then
                            pFdCr.ReceiptNo = receipt
                        End If
                        pFdCr.TerminalId = CType(i.FindControl("HdnCrNo"), HiddenField).Value
                        pFdCr.CompanyId = Session.Item("CompanyId")
                        If diff > 0 Then
                            pFdCr.CreatedOn = "P"
                        Else
                            pFdCr.CreatedOn = "Y"
                        End If
                        p.FinanceDetailsList.Add(pFdCr)
                    End If
                End If
            Next
        ElseIf lstPaymentType.SelectedValue = "O" Then
            Dim pFDO As New FinanceDetails
            pFDO.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFDO.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFDO.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFDO.InvoiceNo = 0
            pFDO.TrnType = "O"
            pFDO.TrnValue = 9
            pFDO.Remarks = "On Account Payment adjusted by " & Session.Item("LoginUser")
            Try
                pFDO.TerminalId = Session.Item("LoginTerminal")
                pFDO.CompanyId = Session.Item("CompanyId")
            Catch ex As Exception
                pFDO.TerminalId = 4
                pFDO.CompanyId = 0
            End Try
            p.FinanceDetailsList.Add(pFDO)
        ElseIf lstPaymentType.SelectedValue = "A" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "A"
            pFD.TrnValue = 2
            pFD.Remarks = "Advance Payment PDA adjusted by " & Session.Item("LoginUser")
            Try
                pFD.TerminalId = Session.Item("LoginTerminal")
                pFD.CompanyId = Session.Item("CompanyId")
            Catch ex As Exception
                pFD.TerminalId = 4
                pFD.CompanyId = 0
            End Try
            p.FinanceDetailsList.Add(pFD)
        ElseIf lstPaymentType.SelectedValue = "B" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            If DrCr = "D" Then
                pFD.DrAmount = Double.Parse(textTotalAmount.Text)
            Else
                pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            End If
            pFD.InvoiceNo = 0
            pFD.TrnType = "B"
            pFD.TrnValue = 11
            Try
                pFD.TerminalId = Session.Item("LoginTerminal")
                pFD.CompanyId = Session.Item("CompanyId")
            Catch ex As Exception
                pFD.TerminalId = 4
                pFD.CompanyId = 0
            End Try
            pFD.Remarks = "Opening Balace adjusted by " & Session.Item("LoginUser")
            p.FinanceDetailsList.Add(pFD)
        End If

        Dim dbltest As Long = textRecBalanceAmountTotal.Text
        Dim ModeOfPayment As String = ""
        Try
            ModeOfPayment = HdnpaymentMode.Value
        Catch ex As Exception
            ModeOfPayment = "I"
        End Try
        ' lstPaymentType.SelectedValue = "I"
        'If Math.Round(dbltest, 0) > 0 And ModeOfPayment = "I" Then
        If Math.Round(dbltest, 0) > 0 And lstPaymentType.SelectedValue = "I" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textRecBalanceAmountTotal.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "O"
            If receipt >= 0 Then
                pFD.ReceiptNo = receipt
            End If
            Try
                pFD.TerminalId = Session.Item("LoginTerminal")
                pFD.CompanyId = Session.Item("CompanyId")
            Catch ex As Exception
                pFD.TerminalId = 4
                pFD.CompanyId = 0
            End Try

            pFD.TrnValue = 9
            pFD.Remarks = "Advance Amount in Invoice Payment adjusted by " & Session.Item("LoginUser")

            p.FinanceDetailsList.Add(pFD)
        End If

        Return p
    End Function
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If hdnReceiptNo.Value <> "" AndAlso hdnReceiptNo.Value <> Nothing Then
            ' Response.Redirect("Preview/ImportInvoicePrint.aspx?InvoiceNo=" & hdnInvoiceNo.Value)
            'If lstPaymentType.SelectedValue = "I" Then
            Response.Redirect("Preview/InvoiceReceiptGst.aspx?ReceiptNo=" & hdnReceiptNo.Value)
            'Else
            '   Response.Redirect("Preview/GstPaymentReceipt.aspx?ReceiptNo=" & hdnReceiptNo.Value)
            'End If

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
        lstCustomer.SelectedValue = p.CustomerId
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
            lstService.Enabled = False
            lstService.SelectedValue = 0
        Else
            lstService.Enabled = True
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

    Protected Sub BtnSendMail_Click(sender As Object, e As System.EventArgs) Handles BtnSendMail.Click
        sendmail()
    End Sub
End Class


