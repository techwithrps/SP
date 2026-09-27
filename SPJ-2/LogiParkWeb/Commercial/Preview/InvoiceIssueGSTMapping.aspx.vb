Imports System.Data
Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection

Partial Class Commercial_Preview_InvoiceReceiptGST
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim lngImpContId As Integer = 0
    Dim dblAmount As Double
    Dim dblTaxAmount As Double
    Dim dblTotalAmount As Double
    Dim dblWeaverAmt As Double
    Dim lngReceiptNo As Long
    Dim dblServiceTax As Double
    Dim dblEducTax As Double
    Dim dblHEduTax As Double
    Dim strType As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strReceiptNo As String = ""
        strReceiptNo = Request.QueryString("ReceiptNo")

        Try
            Dim strConnstring As String = ""
            Dim cmd9 As String = ""
            Dim con9 As OleDbConnection
            Dim ada9 As OleDbDataAdapter
            strConnstring = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd9 = "SELECT MIN(RECEIPT_NO) RECEIPT_NO FROM INVOICE_RECEIPT WHERE RECEIPT_NO IN (SELECT REGEXP_SUBSTR('" & strReceiptNo & "','[^,]+', 1, LEVEL) FROM DUAL CONNECT BY REGEXP_SUBSTR('" & strReceiptNo & "', '[^,]+', 1, LEVEL) IS NOT NULL)"
            con9 = New OleDbConnection(strConnstring)
            con9.Open()
            ada9 = New OleDbDataAdapter(cmd9, con9)
            Dim ds As New DataSet("CONTAINER")
            ada9.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                lngReceiptNo = ds.Tables(0).Rows(0)("RECEIPT_NO")
            End If
            ds.Clear()
            con9.Close()
        Catch ex As Exception
        End Try
        Dim lngTerminal As Long = Session.Item("LoginTerminal")

        Dim lngCompanyId As Long = 0
        Dim pInvoiceReceipt As New InvoiceReceipt
        pInvoiceReceipt.TerminalId = lngTerminal
        pInvoiceReceipt.ReceiptNo = lngReceiptNo
        InvoiceReceipt.ReturnInvoiceReceiptByNo(pInvoiceReceipt)
        textVoucherNo.Text = pInvoiceReceipt.ReceiptRefNo
        textVoucherDate.Text = pInvoiceReceipt.ReceiptDate
        TxtNote.Text = pInvoiceReceipt.Remarks
        If lngReceiptNo > 3916 Then
            lngCompanyId = pInvoiceReceipt.TerminalId
        Else
            lngCompanyId = Session.Item("CompanyId")
        End If
        Dim pCompanyMaster As New CompanyMaster
        pCompanyMaster.CompanyId = lngCompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pCompanyMaster)
        lblCDtls.Text = pCompanyMaster.CompanyName
        lblpangst.Text = pCompanyMaster.PanNo
        lblGSTIN.Text = pCompanyMaster.Remarks
        lblCmAdress.Text = pCompanyMaster.Address
        Dim pPaymentDetails As New PaymentDetails
        pPaymentDetails.TerminalId = Session.Item("LoginTerminal")
        pPaymentDetails.ReceiptNo = lngReceiptNo
        PaymentDetails.ReturnPaymentDetails(pPaymentDetails)
        'textInclusiveTaxAmount.Text = pPaymentDetails.Amount



        Dim pPPaymentDetails As New PaymentDetails
        pPPaymentDetails.TerminalId = Session.Item("LoginTerminal")
        pPPaymentDetails.ReceiptNo = lngReceiptNo
        PaymentDetails.ReturnPaymentDetailsByReceiptNo(pPPaymentDetails)
        If pPPaymentDetails.ReceiptMode = "C" Then
            txtPaymentMode.Text = "Cash"
        ElseIf pPPaymentDetails.ReceiptMode = "H" Then
            txtPaymentMode.Text = "Cheque"
        ElseIf pPPaymentDetails.ReceiptMode = "D" Then
            txtPaymentMode.Text = "DD"
        ElseIf pPPaymentDetails.ReceiptMode = "R" Then
            txtPaymentMode.Text = "RTGS"
        ElseIf pPPaymentDetails.ReceiptMode = "A" Then
            txtPaymentMode.Text = "Advance"
        ElseIf pPPaymentDetails.ReceiptMode = "O" Then
            txtPaymentMode.Text = "On Account"
        ElseIf pPPaymentDetails.ReceiptMode = "N" Then
            txtPaymentMode.Text = "NEFT"
        ElseIf pPPaymentDetails.ReceiptMode = "B" Then
            txtPaymentMode.Text = "Opening Balance"
        End If

        Dim pBankMaster As New BankMaster
        pBankMaster.TerminalId = Session.Item("LoginTerminal")
        pBankMaster.BankId = pPPaymentDetails.ReceiverBankId
        BankMaster.ReturnBankMaster(pBankMaster)
        txtReceiverBank.Text = pBankMaster.BankName

        txtChequeNo.Text = pPPaymentDetails.ChequeNo
        txtInstrumentDate.Text = pPPaymentDetails.ChequeDate
        txtReceivedAmount.Text = pPPaymentDetails.Amount
        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        pService.ServiceId = pPaymentDetails.ServiceId
        ServiceMaster.ReturnServiceMasterByServiceId(pService)
        ' textService.Text = pService.ServiceName
        '''''''''''''''Created by Rahman'''''''''''''''''''
        Dim pCustomerWithType As New ExtCustomerMaster
        pCustomerWithType.TerminalId = Session.Item("LoginTerminal")
        pCustomerWithType.CustomerId = pInvoiceReceipt.CustomerId

        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pCustomerWithType)
        textCustomerName.Text = pCustomerWithType.CustomerName
        'textConsigneeName.Text = pCustomerWithType.CustomerName
        textAddress.Text = pCustomerWithType.Address
        TextSScode.Text = pCustomerWithType.StateCode
        'TextCStateCode.Text = pCustomerWithType.State
        TextSGstInNo.Text = pCustomerWithType.GSTN
        'textConsigneeAddress.Text = pCustomerWithType.Address
        'textConsigneeStateCode.Text = pCustomerWithType.StateCode
        'TextCStateCode.Text = pCustomerWithType.State
        'textConsigneeGSTN.Text = pCustomerWithType.GSTN
        Dim pStateMaster As New StateCodeMaster
        pStateMaster.TerminalId = Session.Item("LoginTerminal")
        pStateMaster.StateCode = TextSScode.Text
        StateCodeMaster.ReturnStateByCode(pStateMaster)
        TextSState.Text = pStateMaster.StateName
        'textConsigneeState.Text = pStateMaster.StateName
        'Dim pCustomerTypeDetails As New ExtCustomerTypeDetails
        'pCustomerTypeDetails.CustomerId = pInvoiceReceipt.CustomerId
        'pCustomerTypeDetails.CustomerTypeCode = "I"
        'ExtCustomerTypeDetails.ReturnCustomerTypeDetailsByIdType(pCustomerTypeDetails)
        '---------------------------------Consignee------------------------------

        Dim pStateMaster1 As New StateCodeMaster
        pStateMaster1.TerminalId = Session.Item("LoginTerminal")
        pStateMaster1.StateCode = TextSScode.Text
        StateCodeMaster.ReturnStateByCode(pStateMaster1)
        'TextCState.Text = pStateMaster.StateName

        'Dim pCustomerTypeDetails1 As New ExtCustomerTypeDetails
        'pCustomerTypeDetails1.CustomerId = pInvoiceReceipt.CustomerId
        'pCustomerTypeDetails1.CustomerTypeCode = "I"
        'ExtCustomerTypeDetails.ReturnCustomerTypeDetailsByIdType(pCustomerTypeDetails1)
        'TextCGsst.Text = pCustomerTypeDetails.GSTN




        strType = "Print"

        If pInvoiceReceipt.ReceiptRefNo.Length = 0 Then
            'ImpInvoice.ReturnCancelInvoice(pImpInvoice)
            Me.myBody.Attributes.Add("style", "background:url(WaterMark.jpg);")
        End If
        textVoucherNo.Text = pInvoiceReceipt.ReceiptRefNo
        textVoucherDate.Text = pInvoiceReceipt.ReceiptDate

        Dim strpParms As String = ""
        strpParms &= Session.Item("CompanyId")
        strpParms &= ",'" & strReceiptNo & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DEBIT_MAPPING", strpParms)
        gvPaymentDetail.DataSource = dbr
        gvPaymentDetail.DataBind()
      
        dbr.Close()
        db.CloseDB()

        '  Dim strConnectionString, cmd1 As String
        '  Dim con As OleDbConnection
        '  Dim ada As New OleDbDataAdapter
        '  strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        '  con = New OleDbConnection(strConnectionString)
        '  con.Open()
        '  Dim dt As New DataTable()

        '  cmd1 = " SELECT DISTINCT (SELECT  RTRIM (xmlagg (xmlelement (e, PARTY_INV_NO || ', ')).extract ('//text()'), ', ')  FROM ALL_PARTY_ACCOUNT WHERE BL_NO=CB.BL_NO) PARTY_INV_NO,CB.BL_NO, CB.LINER_INV_NO INVOICE_NO, TO_CHAR(CB.LINER_INV_DATE, 'DD/MM/YYYY') INVOICE_DATE,  " &
        '  " '' || (SELECT ROUND(NVL(SUM(TOTAL),0),2) INVOICE_AMOUNT   " &
        ' " FROM COST_BOOKING_DTLS WHERE COST_ID=CB.COST_ID) INVOICE_AMOUNT, 0 BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE, 0 SGST_RATE, 0 CGST_AMOUNT, 0 IGST_AMOUNT,0 SGST_AMOUNT ,  " &
        '  " (SELECT ROUND(NVL(SUM(TDS_AMOUNT),0),2) TDS_AMOUNT FROM COST_BOOKING_DTLS WHERE COST_ID=CB.COST_ID) TDS,'' || round(NVL(SUM(FD.DR_AMOUNT),0),2) TA,  " &
        '  " (SELECT ROUND(NVL(SUM(DR_TAX+DR_AMOUNT),0),2) FROM DR_ITEM_DETAILS DID WHERE DID.COST_ID=CB.COST_ID) DR_AMT,(SELECT DISTINCT  DECODE(MAX(PAYMENT_STATUS),'','PENDING','P', 'PARTIAL','PAID') FROM IMP_INVOICE I,ALL_PARTY_ACCOUNT AL WHERE AL.BL_NO=CB.BL_NO AND AL.CONT_JO_ID=I.LINE_ITEM_ID AND I.CANCLE_FLAGE IS NULL AND SERVICE_TYPE IN ('F','A') )S  " &
        '  " FROM PAYMENT_DETAILS PD, FINANCE_DETAILS FD, COST_BOOKING CB WHERE  PD.RECEIPT_NO=  " & lngReceiptNo & "        " &
        '   "  AND CB.COST_ID=FD.INVOICE_NO  AND FD.TRN_TYPE='P'  AND PD.RECEIPT_NO=FD.RECEIPT_NO  AND TRN_VALUE=12   " &
        ' " GROUP BY CB.LINER_INV_NO, CB.LINER_INV_DATE, COST_ID, CB.BL_NO " &
        ' " UNION " &
        ' " SELECT DISTINCT (SELECT  RTRIM (xmlagg (xmlelement (e, PARTY_INV_NO || ', ')).extract ('//text()'), ', ')  FROM ALL_PARTY_ACCOUNT WHERE BL_NO=CB.BL_NO) PARTY_INV_NO,CB.BL_NO, CB.LINER_INV_NO INVOICE_NO, TO_CHAR(CB.LINER_INV_DATE, 'DD/MM/YYYY') INVOICE_DATE,  " &
        '  " '' || (SELECT ROUND(NVL(SUM(TOTAL),0),2) INVOICE_AMOUNT   " &
        ' " FROM COST_BOOKING_DTLS_NEW WHERE COST_ID IN (SELECT COST_ID FROM COST_BOOKING_NEW WHERE LINER_INV_NO=CB.LINER_INV_NO)) INVOICE_AMOUNT, 0 BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE, 0 SGST_RATE, 0 CGST_AMOUNT, 0 IGST_AMOUNT,0 SGST_AMOUNT ,  " &
        '  " (SELECT ROUND(NVL(SUM(TDS_AMOUNT),0),2) TDS_AMOUNT FROM COST_BOOKING_DTLS_NEW WHERE COST_ID IN (SELECT COST_ID FROM COST_BOOKING_NEW WHERE LINER_INV_NO=CB.LINER_INV_NO)) TDS,'' || round(NVL(SUM(FD.DR_AMOUNT),0),2) TA,  " &
        '  " (SELECT ROUND(NVL(SUM(DR_TAX+DR_AMOUNT),0),2) FROM DR_ITEM_DETAILS DID WHERE DID.COST_ID=CB.COST_ID) DR_AMT,(SELECT DISTINCT  DECODE(MAX(PAYMENT_STATUS),'','PENDING','P', 'PARTIAL','PAID') FROM IMP_INVOICE I,ALL_PARTY_ACCOUNT AL WHERE AL.BL_NO=CB.BL_NO AND AL.CONT_JO_ID=I.LINE_ITEM_ID AND I.CANCLE_FLAGE IS NULL AND SERVICE_TYPE IN ('F','A') )S  " &
        '  " FROM PAYMENT_DETAILS PD, FINANCE_DETAILS FD, COST_BOOKING_NEW CB WHERE  PD.RECEIPT_NO=  " & lngReceiptNo & "        " &
        '   "  AND CB.COST_ID=FD.INVOICE_NO  AND FD.TRN_TYPE='P'  AND PD.RECEIPT_NO=FD.RECEIPT_NO  AND TRN_VALUE=12   " &
        ' " GROUP BY CB.LINER_INV_NO, CB.LINER_INV_DATE, COST_ID, CB.BL_NO " &
        '" UNION " &
        '  " SELECT '' PARTY_INV_NO, '' BL_NO, 'On Account' INVOICE_NO, TO_CHAR(PD.CHEQUE_DATE, 'DD/MM/YYYY') INVOICE_DATE,'' || 0 INVOICE_AMOUNT ,  0  BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE , 0 SGST_RATE ,0 CGST_AMOUNT,0 IGST_AMOUNT,0 SGST_AMOUNT,0 TDS, " &
        '  " '' || ROUND(NVL(SUM(FD.DR_AMOUNT),0),2) TA, 0  DR_AMT,'' S  FROM FINANCE_DETAILS FD INNER JOIN PAYMENT_DETAILS PD ON FD.RECEIPT_NO=PD.RECEIPT_NO " &
        ' " WHERE FD.RECEIPT_NO=" & lngReceiptNo & "  AND FD.TRN_TYPE='T' AND FD.FNC_TYPE='P'  GROUP BY PD.CHEQUE_DATE " &
        '  " UNION " &
        '" SELECT '' PARTY_INV_NO, '' BL_NO, 'Opening Balance' INVOICE_NO,(SELECT  MAX(TO_CHAR(CHEQUE_DATE, 'DD/MM/YYYY')) FROM PAYMENT_DETAILS    " &
        '" WHERE RECEIPT_NO=FD.INVOICE_NO AND PD_TYPE='P') INVOICE_DATE,  " &
        ' " '' || (SELECT NVL(SUM(CR_AMOUNT),0)  FROM FINANCE_DETAILS  WHERE RECEIPT_NO=FD.INVOICE_NO AND FNC_TYPE='P' AND TRN_TYPE='V') INVOICE_AMOUNT,  " &
        '" 0  BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE , 0 SGST_RATE ,0 CGST_AMOUNT,0 IGST_AMOUNT,0 SGST_AMOUNT,0 TDS,     " &
        ' "  '' ||  ROUND(NVL(SUM(FD.DR_AMOUNT),0),2) TA, 0  DR_AMT,'' S  FROM FINANCE_DETAILS FD INNER JOIN PAYMENT_DETAILS PD ON FD.RECEIPT_NO=PD.RECEIPT_NO   " &
        '" WHERE FD.TRN_TYPE='P' AND TRN_VALUE=12 AND FNC_TYPE='P' AND FD.REMARKS LIKE '%OPENING BALANCE'  " &
        '" AND FD.RECEIPT_NO=" & lngReceiptNo & " " &
        '" GROUP BY FD.RECEIPT_NO, FD.INVOICE_NO " &
        '" UNION " &
        '" SELECT '' PARTY_INV_NO, 'Credit Note' BL_NO, CR.DR_REF_NO,TO_CHAR(CR.DR_DATE,'DD/MM/YYYY')CR_DATE,'-' || SUM(FD.DR_AMOUNT) INVOICE_AMOUNT, " &
        '"  0  BASIC_AMOUNT, 0 CGST_RATE, 0 IGST_RATE , 0 SGST_RATE ,0 CGST_AMOUNT,0 IGST_AMOUNT,0 SGST_AMOUNT, " &
        '"  0 TDS,'' || 0 TA,0 DR_AMT,'' S  " &
        '" FROM FINANCE_DETAILS FD,DR_NOTE CR  WHERE CR.DR_ID = FD.TERMINAL_ID AND FD.RECEIPT_NO= " & lngReceiptNo & "  " &
        '"  GROUP BY CR.DR_REF_NO,CR.DR_DATE,FD.DR_AMOUNT,FD.CR_AMOUNT"


        'dt = New DataTable()
        'ada = New OleDbDataAdapter(cmd1, con)
        'ada.Fill(dt)
        'gvPaymentDetail.DataSource = dt
        'gvPaymentDetail.DataBind()
        textInWords.Text = NumberToWord.AmtInWord(Math.Round(totalRevAmt, 0))
        'textInclusiveTaxAmount.Text = grandTotal
    End Sub

    Dim totalAdvanceAmt As Double = 0.0
    Dim totalTaxableAmt As Double = 0.0
    Dim TotalBasicAmt As Double = 0.0
    Dim CGST_Rate As Double = 0.0
    Dim CGSTAmount As Double = 0.0
    Dim SGST_Rate As Double = 0.0
    Dim SGSTAmount As Double = 0.0
    Dim IGST_Rate As Double = 0.0
    Dim IGSTAmount As Double = 0.0
    Dim UTGST_Rate As Double = 0.0
    Dim UTGSTAmount As Double = 0.0
    Dim CESS_Rate As Double = 0.0
    Dim CESSAmount As Double = 0.0
    Dim totalCGST As Double = 0.0
    Dim totalSGST As Double = 0.0
    Dim totalIGST As Double = 0.0
    Dim totalUTGST As Double = 0.0
    Dim totalCESS As Double = 0.0
    Dim totalTaxAmount As Double = 0.0
    Dim totalDrAmount As Double = 0.0
    Dim grandTotal As Double = 0.0
    Dim totalTDS As Double = 0.0
    Dim totalInvAmt As Double = 0.0
    Dim totalRevAmt As Double = 0.0
    Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                totalInvAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "INVOICE_AMOUNT"))
            Catch ex As Exception
                totalInvAmt += 0.0
            End Try

            Try
                totalRevAmt += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TA"))
            Catch ex As Exception
                totalRevAmt += 0.0
            End Try
            Try
                totalDrAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DR_AMT"))
            Catch ex As Exception
                totalDrAmount += 0.0
            End Try
            Try
                totalTDS += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TDS"))
            Catch ex As Exception
                totalTDS += 0.0
            End Try

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).ColumnSpan = 5
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(1).Text = Format(Math.Round(totalInvAmt, 2), "0.00")
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(2).Text = Format(Math.Round(totalDrAmount, 2), "0.00")
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(3).Text = Format(Math.Round(totalTDS, 2), "0.00")
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(4).Text = Format(Math.Round(totalRevAmt, 2), "0.00")
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
        End If
    End Sub
End Class
