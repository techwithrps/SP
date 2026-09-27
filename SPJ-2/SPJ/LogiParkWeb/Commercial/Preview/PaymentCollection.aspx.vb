Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Xml
Imports System.Data

Partial Class Commercial_PaymentCollection
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 2
    Dim INVROWS As Integer = 2
    Dim dblBillAmountTotal As Double = 0
    Dim dblToPayAmountTotal As Double = 0

    Dim dblPaymentAmountTotal As Double = 0
    Dim dblRecBalanceAmount As Double = 0
    Dim dblBalanceAmountTotal As Double = 0
    Dim dblWaiverAmountTotal As Double = 0
    Dim dblPaidAmountTotal As Double = 0

    Dim lngTerminalId As Long
    Dim lngInvoiceNo As Long
    Dim lngBillingPartyId As Long
    Dim strPaymentMode As String
    Dim lngLineItemId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            searchPendingPayment()
        End If
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
        reppaymentDetails.DataSource = arr
        reppaymentDetails.DataBind()



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
        textWaiverAmountotal.Text = Math.Round(dblWaiverAmountTotal, 2)
        textBillAmountTotal.Text = Math.Round(dblBillAmountTotal, 2)
        textToPayAmountTotal.Text = Math.Round(dblToPayAmountTotal, 2)
        textBalanceAmountTotal.Text = Math.Round(dblBalanceAmountTotal, 2)
        textPaidAmountTotal.Text = Math.Round(dblPaidAmountTotal, 2)
    End Sub
    'Sub manageRepatorReceipt(ByVal pEnabel As Boolean)
    '    For Each rep As RepeaterItem In repPaymentDetails.Items
    '        CType(rep.FindControl("lstPaymentMode"), DropDownList).Enabled = True
    '        CType(rep.FindControl("lstBankName"), DropDownList).Enabled = False
    '        CType(rep.FindControl("textChequeDate"), TextBox).Enabled = False
    '        CType(rep.FindControl("textBranch"), TextBox).Enabled = False
    '        CType(rep.FindControl("textReconcilationDate"), TextBox).Enabled = False
    '        CType(rep.FindControl("textChequeNo"), TextBox).Enabled = False
    '        CType(rep.FindControl("textPaymentAmount"), TextBox).Enabled = pEnabel
    '    Next
    'End Sub
    Sub manageRepatorReceipt(ByVal pEnabel As Boolean)
        For Each rep As RepeaterItem In repPaymentDetails.Items
            CType(rep.FindControl("lstPaymentMode"), DropDownList).Enabled = True
            CType(rep.FindControl("lstBankName"), DropDownList).Enabled = True
            CType(rep.FindControl("textChequeDate"), TextBox).Enabled = True
            CType(rep.FindControl("textBranch"), TextBox).Enabled = True
            CType(rep.FindControl("textReconcilationDate"), TextBox).Enabled = True
            CType(rep.FindControl("textChequeNo"), TextBox).Enabled = True
            CType(rep.FindControl("textPaymentAmount"), TextBox).Enabled = pEnabel
        Next
    End Sub

    Sub manageRepatorInvoice(ByVal pEnabel As Boolean)
        For Each rep As RepeaterItem In repInvoiceDetails.Items
            CType(rep.FindControl("textInvoiceRefNo"), TextBox).Enabled = False
            CType(rep.FindControl("textInvoiceDate"), TextBox).Enabled = False
            CType(rep.FindControl("textBookingRefNo"), TextBox).Enabled = False
            CType(rep.FindControl("textBookingDate"), TextBox).Enabled = False
            CType(rep.FindControl("textInvoiceMode"), TextBox).Enabled = False
            CType(rep.FindControl("textBillAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textToPayAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textWaiverAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textBalanceAmount"), TextBox).Enabled = False
            CType(rep.FindControl("textPaidAmount"), TextBox).Enabled = False
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True

        Next
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvMain.Controls)
        ButtonControlSetup(True)
        fillRepeatorPayment(New ArrayList)
        manageUserControls(True)
        manageRepatorReceipt(False)
        lstPaymentType.Enabled = True
        lstCustomer.Enabled = True
        lstCustomer.SelectedValue = 0
        btnDisplay.Visible = True
        btnSearchDisplay.Visible = False
        Functions.ControlFocus(lstPaymentType)
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        searchPendingPayment()
    End Sub

    Sub searchPendingPayment()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
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
                arr = FinanceDetails.ReturnInvoiceListByCustomer(p, lstPaymentType.SelectedValue)
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

        ButtonControlSetup(False)
        manageControls()
        textReceiptdate.Enabled = False
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

    Protected Sub repInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value <> "0" _
            AndAlso CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value > 0 Then
                Dim p As New ExtImpInvoice
                p.TerminalId = Session.Item("LoginTerminal")
                p.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                ExtImpInvoice.ReturnInvoiceWithItemDetails(p)
                CType(e.Item.FindControl("textInvoiceRefNo"), TextBox).Text = p.InvoiceRefNo
                CType(e.Item.FindControl("textInvoiceDate"), TextBox).Text = p.InvoiceDate
                CType(e.Item.FindControl("textInvoiceMode"), TextBox).Text = IIf(p.PaymentMode = "C", "Cash", "Credit")
                CType(e.Item.FindControl("hdnBookingNo"), HiddenField).Value = p.LineItemId
                CType(e.Item.FindControl("hdnTaxExemptionPerc"), HiddenField).Value = p.TaxExemptionPerc
                Dim pImpInvoiceItems As New ImpInvoiceItems
                pImpInvoiceItems.TerminalId = Session.Item("LoginTerminal")
                pImpInvoiceItems.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                ImpInvoiceItems.ReturnImpInvoiceItemsWaiver(pImpInvoiceItems)
                CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text = pImpInvoiceItems.WeiverAprAmt
              lngInvoiceno = Request.QueryString("InvoiceNo")
                Dim pFleetContJo As New FleetContJo
                pFleetContJo.TerminalId = Session.Item("LoginTerminal")
                pFleetContJo.ContJoId = p.LineItemId

                FleetContJo.ReturnFleetContJo(pFleetContJo)
                CType(e.Item.FindControl("textBookingRefNo"), TextBox).Text = pFleetContJo.ContJoNo
                CType(e.Item.FindControl("textBookingDate"), TextBox).Text = pFleetContJo.CreatedOn


                Dim pf As New FinanceDetails
                pf.InvoiceNo = p.InvoiceNo
                pf.TerminalId = Session.Item("LoginTerminal")
                FinanceDetails.ReturnToPayAmountByInvoiceNo(pf)
                CType(e.Item.FindControl("textToPayAmount"), TextBox).Text = Math.Round(pf.CrAmount, 2)

                Dim pFD As New FinanceDetails
                pFD.TerminalId = p.TerminalId
                pFD.InvoiceNo = p.InvoiceNo
                FinanceDetails.ReturnFinanceDetailsSumByInvoiceNo(pFD)

                CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text = Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text) - pFD.CrAmount
                CType(e.Item.FindControl("hdnBalanceAmount"), HiddenField).Value = CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text
                dblBillAmountTotal += Double.Parse(CType(e.Item.FindControl("textBillAmount"), TextBox).Text)
                dblToPayAmountTotal += Double.Parse(CType(e.Item.FindControl("textToPayAmount"), TextBox).Text)
                dblBalanceAmountTotal += Double.Parse(CType(e.Item.FindControl("textBalanceAmount"), TextBox).Text)
                dblPaidAmountTotal += Double.Parse(CType(e.Item.FindControl("textPaidAmount"), TextBox).Text)
                dblWaiverAmountTotal += Double.Parse(CType(e.Item.FindControl("textWaiverAmount"), TextBox).Text)
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

        Dim textPaymentAmount As Double = CType(repPaymentDetails.Items(0).FindControl("textPaymentAmount"), TextBox).Text
        textTotalAmount.Text = textPaymentAmount

        Dim textRecBalanceAmount As TextBox = repPaymentDetails.Items(0).FindControl("textRecBalanceAmount")
        If lstPaymentType.SelectedValue = "I" Then
            textRecBalanceAmount.Text = Double.Parse(textPreviousBalance.Text) + Double.Parse(textPaymentAmount)
        End If

        For Each rep As RepeaterItem In repInvoiceDetails.Items
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

            If Double.Parse(textPaidAmount.Text) > Double.Parse(textRecBalanceAmount.Text) And Double.Parse(textPaidAmount.Text) > 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Not Sufficent Balance")
                Functions.ControlFocus(textRecBalanceAmount)
                rtnBool = False
            End If
            If Double.Parse(textPaidAmount.Text) > Double.Parse(hdnBalanceAmount.Value) And Double.Parse(textPaidAmount.Text) > 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Paid Amount should not be more than Invoice Balance Amount")
                Functions.ControlFocus(textPaidAmount)
                rtnBool = False
            End If
            'If textInvoiceMode.Text = "Cash" And Double.Parse(textPaidAmount.Text) <> Double.Parse(hdnBalanceAmount.Value) And Double.Parse(textPaidAmount.Text) > 0 Then
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
        Next
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtInvoiceReceipt As ExtInvoiceReceipt = ReturnObject()
        If pExtInvoiceReceipt.PaymentDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Enter Payment Details")
            'Functions.ControlFocus(repPayment)
            Return
        End If
        If pExtInvoiceReceipt.FinanceDetailsList.Count <= 0 And lstPaymentType.SelectedValue <> "A" Then
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
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
    End Sub

    Function ReturnObject() As ExtInvoiceReceipt
        Dim p As New ExtInvoiceReceipt
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
        p.PaymentDetailsList = New ArrayList
        p.FinanceDetailsList = New ArrayList

        For Each r As RepeaterItem In repPaymentDetails.Items
            If CType(r.FindControl("textPaymentAmount"), TextBox).Text <> Nothing AndAlso CType(r.FindControl("textPaymentAmount"), TextBox).Text > 0 Then

                Dim pPD As New PaymentDetails
                pPD.Amount = CType(r.FindControl("textPaymentAmount"), TextBox).Text
                pPD.ReceiptMode = CType(r.FindControl("lstPaymentMode"), DropDownList).SelectedValue
                Try
                    pPD.ChequeNo = CType(r.FindControl("textChequeNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pPD.ReconcilationDate = CType(r.FindControl("textReconcilationDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pPD.Branch = CType(r.FindControl("textBranch"), TextBox).Text
                Catch ex As Exception
                End Try

                pPD.ChequeDate = CType(r.FindControl("textChequeDate"), TextBox).Text
                pPD.BankId = CType(r.FindControl("lstBankName"), DropDownList).SelectedValue
                pPD.TerminalId = Session.Item("LoginTerminal")
                p.PaymentDetailsList.Add(pPD)
            End If
        Next

        Dim dblTempPrevBal As Double = 0
        If textPreviousBalance.Text.Trim = Nothing Then
            textPreviousBalance.Text = 0
        Else
            dblTempPrevBal = Double.Parse(textPreviousBalance.Text)
        End If

        Dim lngCount As Integer = 0
        If lstPaymentType.SelectedValue <> "A" Then
            For Each i As RepeaterItem In repInvoiceDetails.Items
                Dim tempCrAmount As Double = 0
                If CType(i.FindControl("textPaidAmount"), TextBox).Text <> Nothing AndAlso CType(i.FindControl("textPaidAmount"), TextBox).Text > 0 Then
                    If dblTempPrevBal = 0 Then

                        If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then
                            tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text))
                            tempCrAmount = tempCrAmount
                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.CrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.TrnType = "R"
                            pFD.TrnValue = 3
                            pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            p.FinanceDetailsList.Add(pFD)

                            Dim pFD1 As New FinanceDetails
                            pFD1.CustomerId = lstCustomer.SelectedValue
                            pFD1.CrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD1.TrnType = "R"
                            pFD1.TrnValue = 2
                            pFD1.TerminalId = Session.Item("LoginTerminal")
                            p.FinanceDetailsList.Add(pFD1)
                        Else
                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            tempCrAmount = tempCrAmount
                            Dim pFD As New FinanceDetails
                            pFD.CustomerId = lstCustomer.SelectedValue
                            pFD.CrAmount = tempCrAmount
                            pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                            pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                            pFD.TrnType = "R"
                            pFD.TerminalId = Session.Item("LoginTerminal")
                            pFD.TrnValue = 2
                            p.FinanceDetailsList.Add(pFD)
                        End If

                    ElseIf dblTempPrevBal > 0 Then

                        If dblTempPrevBal < Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then

                            tempCrAmount = dblTempPrevBal

                            Dim dblTemp As Double = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) - dblTempPrevBal
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then

                                tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                tempCrAmount = tempCrAmount

                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TrnValue = 3
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.CrAmount = dblTempPrevBal
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "R"
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                pFD1.TrnValue = 2
                                p.FinanceDetailsList.Add(pFD1)

                                If dblTemp > 0 Then

                                    tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTemp)
                                    tempCrAmount = tempCrAmount

                                    Dim temp As New FinanceDetails
                                    temp.CustomerId = lstCustomer.SelectedValue
                                    temp.CrAmount = tempCrAmount
                                    temp.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp.TrnType = "R"
                                    temp.TrnValue = 3
                                    temp.TerminalId = Session.Item("LoginTerminal")
                                    p.FinanceDetailsList.Add(temp)

                                    Dim temp1 As New FinanceDetails
                                    temp1.CustomerId = lstCustomer.SelectedValue
                                    temp1.CrAmount = dblTemp
                                    temp1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    temp1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    temp1.TrnType = "R"
                                    temp1.TrnValue = 2
                                    temp1.TerminalId = Session.Item("LoginTerminal")
                                    p.FinanceDetailsList.Add(temp1)

                                End If
                                dblTempPrevBal = 0
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = dblTempPrevBal
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 2
                                p.FinanceDetailsList.Add(pFD)

                                If dblTemp > 0 Then
                                    Dim pFD1 As New FinanceDetails
                                    pFD1.CustomerId = lstCustomer.SelectedValue
                                    pFD1.CrAmount = dblTemp
                                    pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                    pFD1.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                    pFD1.TrnType = "R"
                                    pFD1.TerminalId = Session.Item("LoginTerminal")
                                    pFD1.TrnValue = 2
                                    p.FinanceDetailsList.Add(pFD1)
                                End If
                                dblTempPrevBal = 0
                            End If

                        ElseIf dblTempPrevBal >= Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text) Then

                            tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                            If Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) <> Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) Then

                                tempCrAmount = ((Double.Parse(CType(i.FindControl("textBillAmount"), TextBox).Text) - Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text)) / Double.Parse(CType(i.FindControl("textToPayAmount"), TextBox).Text) * dblTempPrevBal)
                                tempCrAmount = tempCrAmount

                                Dim pFD As New FinanceDetails
                                pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "TDS ADJUSTMENT FOR  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TrnValue = 3
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                p.FinanceDetailsList.Add(pFD)

                                Dim pFD1 As New FinanceDetails
                                pFD1.CustomerId = lstCustomer.SelectedValue
                                pFD1.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD1.CrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                pFD1.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD1.Remarks = "Bill Payment of Invoice No " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD1.TrnType = "R"
                                pFD1.TrnValue = 2
                                pFD1.TerminalId = Session.Item("LoginTerminal")
                                p.FinanceDetailsList.Add(pFD1)
                            Else
                                tempCrAmount = Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                                tempCrAmount = tempCrAmount
                                Dim pFD As New FinanceDetails
                                pFD.ReceiptNo = hdnPreviousReceiptNo.Value
                                pFD.CustomerId = lstCustomer.SelectedValue
                                pFD.CrAmount = tempCrAmount
                                pFD.InvoiceNo = CType(i.FindControl("hdnInvoiceNo"), HiddenField).Value
                                pFD.Remarks = "Bill Payment of Invoice No  " & CType(i.FindControl("textInvoiceRefNo"), TextBox).Text
                                pFD.TrnType = "R"
                                pFD.TerminalId = Session.Item("LoginTerminal")
                                pFD.TrnValue = 2
                                p.FinanceDetailsList.Add(pFD)
                            End If
                            dblTempPrevBal = dblTempPrevBal - Double.Parse(CType(i.FindControl("textPaidAmount"), TextBox).Text)
                        End If

                    End If
                End If
            Next
        ElseIf lstPaymentType.SelectedValue = "A" Then

            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textTotalAmount.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "A"
            pFD.TrnValue = 2
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.Remarks = "Advance Payment PDA "

            p.FinanceDetailsList.Add(pFD)
        End If

        If Double.Parse(textRecBalanceAmountTotal.Text) > 0 And lstPaymentType.SelectedValue <> "A" Then
            Dim pFD As New FinanceDetails
            pFD.CustomerId = lstCustomer.SelectedValue
            pFD.CrAmount = Double.Parse(textRecBalanceAmountTotal.Text)
            pFD.InvoiceNo = 0
            pFD.TrnType = "R"
            pFD.TerminalId = Session.Item("LoginTerminal")
            pFD.TrnValue = 2
            pFD.Remarks = "Advance Amount in Invoice Payment"

            p.FinanceDetailsList.Add(pFD)
        End If

        Return p
    End Function

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
        textTotalAmount.Text = CType(repPaymentDetails.Items(0).FindControl("textPaymentAmount"), TextBox).Text
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

End Class
