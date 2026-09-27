Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.Net.WebClient
Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects
Partial Class AdministratorUI_InvoiceTallyInterface
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim ROW As Integer = 5
    Dim count As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            Permission(p)
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= ",'" & Session.Item("CompanyId") & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PENDING_TALLY_INVOICES", strpParms)
            repIndentDetails.DataSource = dbr
            repIndentDetails.DataBind()
            ButtonControlSetup(False)
        End If
    End Sub
    Sub Permission(ByVal P As String)
        Dim PMI As New MenuItemMaster
        PMI.Url = P
        MenuItemMaster.ReturnMenuItemMasterByURL(PMI)
        Session.Item("Title") = PMI.Title
        Dim pJMI As New JobMenuItems
        pJMI.JobId = Session.Item("JobId")
        pJMI.MenuId = PMI.MenuId
        JobMenuItems.ReturnJobMenuItems(pJMI)

        Session.Item("Add") = pJMI.AddPermit
        Session.Item("Edit") = pJMI.EditPermit
        Session.Item("Search") = pJMI.SearchPermit
        Session.Item("Delete") = pJMI.DeletePermit
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub


    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Sub ledger()
    End Sub
    Private Function SalesVoucher(ByVal x As String) As String
        If count = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Plese Select Details.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        End If
        ButtonControlSetup(True)
        Return x
    End Function
    Protected Sub OnClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Dim strpParms As String = ""
        strpParms = lnk.CommandArgument
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_TALLY_SERVICE_WISE_CHARGE", strpParms)
        gridviewcontDtls.DataSource = dbr
        gridviewcontDtls.DataBind()
        gridviewcontDtls.Visible = True
        Dim message As String = lnk.Text
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim totalCalculatedAmount As Double = 0
        For Each rc As RepeaterItem In repIndentDetails.Items
            Dim Status As String = ""
            If CType(rc.FindControl("chkIndent"), CheckBox).Checked = True Then
                totalCalculatedAmount = 0
                Dim pLedgerName As String = ""
                Dim pInvoiceDate As String = ""
                Dim pBillNo As String = ""
                Dim pNarr As String = ""
                Dim pTaxName As String = ""
                Dim pAddress As String = ""
                Dim pPartygstin As String = ""
                Dim pPlaceOfSupply As String = ""
                Dim pCountryName As String = ""
                Dim pCity As String = ""
                Dim pSupp As String = ""

                Dim billAmountOnPage = Convert.ToDouble(CType(rc.FindControl("textBillAmount"), TextBox).Text.Trim())

                pInvoiceDate = CType(rc.FindControl("textInvoiceDate"), TextBox).Text
                pBillNo = CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                pLedgerName = CType(rc.FindControl("textTallyCustomerName"), TextBox).Text
                'pTotalAmount = Convert.ToDouble(CType(rc.FindControl("textBillAmount"), TextBox).Text.Trim())
                'chkTaxAmount = CType(rc.FindControl("textTaxAmount"), TextBox).Text
                Dim Pinv As New ImpInvoice
                Pinv.TerminalId = Session.Item("LoginTerminal")
                Pinv.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                ImpInvoice.ReturnImpInvoiceByInvoiceNo(Pinv)
                Dim pImpInvoice As New ImpInvoice
                pImpInvoice.InvoiceNo = Pinv.InvoiceNo

                If Pinv.ServiceType = "F" Then
                    ImpInvoice.ReturnImpInvoiceTallyNarationByFreightInvoiceNo(pImpInvoice)
                ElseIf Pinv.ServiceType = "S" Then
                    ImpInvoice.ReturnImpInvoiceTallyNarationByFreightInvoiceNo(pImpInvoice)
                Else
                    ImpInvoice.ReturnImpInvoiceTallyNarationByInvoiceNo(pImpInvoice)
                End If
                pNarr = pImpInvoice.CreatedBy
                Dim pTDSAmount As String = ""
                Dim pTDSPer As Integer = 0

                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
                pCustomerMaster.CustomerId = Pinv.BillTo
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                pAddress = pCustomerMaster.Address
                pPartygstin = pCustomerMaster.GSTN
                pAddress = pAddress.Replace("&", "&amp;")

                Dim pStateCode As New StateCodeMaster
                pStateCode.StateCode = pCustomerMaster.StateCode
                StateCodeMaster.ReturnStateByCode(pStateCode)
                pPlaceOfSupply = pStateCode.StateName
                pCity = pCustomerMaster.City

                Dim pCountryMaster As New CountryMaster
                pCountryMaster.CountryId = pCustomerMaster.CountryId
                CountryMaster.ReturnCountryMasterById(pCountryMaster)
                pCountryName = pCountryMaster.CountryName

                Dim pSuppInvoice As New ImpInvoice
                pSuppInvoice.InvoiceNo = Pinv.InvoiceNo
                ImpInvoice.ReturnImpInvoiceTallySuppByInvoiceNo(pSuppInvoice)
                pSupp = pSuppInvoice.InvoiceNote

                Try
                    pTDSAmount = CType(rc.FindControl("txtTDSAmount"), TextBox).Text
                    pTDSPer = CType(rc.FindControl("hdnTDSPer"), HiddenField).Value
                Catch ex As Exception
                    pTDSAmount = 0
                    pTDSPer = 0
                End Try

                'Dim invAmt As Long = Convert.ToInt64(pTotalAmount)
                'Dim diff As Double = pTotalAmount - invAmt
                'Dim roundOff As Double = 0.0
                'roundOff = Math.Round(diff, 2)

                If Pinv.InvoiceType <> "Y" Then
                    Dim x As String = ""
                    x = "<ENVELOPE>"
                    x = x + "<HEADER>"
                    x = x + "<VERSION>1</VERSION>"
                    x = x + "<TALLYREQUEST>Import</TALLYREQUEST>"
                    x = x + "<TYPE>Data</TYPE>"
                    x = x + "<REQUESTDESC>"
                    x = x + "<STATICVARIABLES>"
                    'If Session.Item("CompanyId") = "2" Then
                    '    x = x + "<SVCURRENTCOMPANY>SPJ Cargo Pvt. Ltd.Demo</SVCURRENTCOMPANY> "
                    'ElseIf Session.Item("CompanyId") = "1" Then
                    '    x = x + "<SVCURRENTCOMPANY>SPJ Cargo Pvt. Ltd.Demo</SVCURRENTCOMPANY> "
                    'ElseIf Session.Item("CompanyId") = "4" Then
                    '    x = x + "<SVCURRENTCOMPANY>SPJ Cargo Pvt. Ltd.Demo</SVCURRENTCOMPANY> "
                    'End If

                    If Session.Item("CompanyId") = "2" Then
                        x = x + "<SVCURRENTCOMPANY> SPJ Cargo Pvt. Ltd.(2023-24)</SVCURRENTCOMPANY> "
                    ElseIf Session.Item("CompanyId") = "1" Then
                        x = x + "<SVCURRENTCOMPANY> S.J. Cargo Movers(2022-23)</SVCURRENTCOMPANY> "
                    ElseIf Session.Item("CompanyId") = "4" Then
                        x = x + "<SVCURRENTCOMPANY> SPJ Cargo Pvt. Ltd.(2022-23)</SVCURRENTCOMPANY> "
                    End If
                    x = x + "</STATICVARIABLES>"
                    x = x + "</REQUESTDESC>"
                    x = x + "<ID>Vouchers</ID>"
                    x = x + "</HEADER>"
                    x = x + "<BODY>"
                    x = x + "<DESC></DESC>"
                    x = x + "<DATA>"
                    x = x + "<TALLYMESSAGE>"
                    x = x + "<VOUCHER>"
                    x = x + "<DATE>" + pInvoiceDate + " </DATE>"
                    x = x + "<NARRATION>" + pNarr + "</NARRATION>"
                    x = x + "<ISINVOICE>Yes</ISINVOICE>"
                    x = x + "<VOUCHERTYPENAME>Tax Invoice</VOUCHERTYPENAME>"
                    x = x + "<REFERENCE>" + pBillNo + " </REFERENCE>"
                    x = x + "<VOUCHERNUMBER>" + pBillNo + "</VOUCHERNUMBER>"
                    x = x + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>"
                    x = x + "<PERSISTEDVIEW>Accounting Voucher View</PERSISTEDVIEW>"
                    x = x + "<VCHGSTCLASS/>"
                    x = x + "<PARTYLEDGERNAME>" & pLedgerName & " </PARTYLEDGERNAME>"
                    x = x + "<LEDGERENTRIES.LIST>"
                    x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                    x = x + " <LEDGERFROMITEM>No</LEDGERFROMITEM> "
                    x = x + "<LEDGERNAME>" + pLedgerName + "</LEDGERNAME>"
                    'x = x + "<AMOUNT>-" + invAmt.ToString + "</AMOUNT>"
                    x = x + "<AMOUNT>-HARIOM</AMOUNT>"
                    x = x + " <BILLALLOCATIONS.LIST>"
                    x = x + " <NAME>" + pBillNo + " </NAME>"
                    x = x + " <BILLTYPE>New Ref</BILLTYPE>"
                    'x = x + "  <AMOUNT>-" + invAmt.ToString + "</AMOUNT>"
                    x = x + "  <AMOUNT>-HARIOM</AMOUNT>"
                    x = x + " </BILLALLOCATIONS.LIST>"
                    x = x + "<ADDRESS.LIST>"
                    x = x + "<ADDRESS>" + pAddress + "</ADDRESS>"
                    x = x + " </ADDRESS.LIST>"
                    x = x + "<PARTYGSTIN>" + pPartygstin + "</PARTYGSTIN>"
                    x = x + "<PLACEOFSUPPLY> " + pPlaceOfSupply + " </PLACEOFSUPPLY>"
                    x = x + "<STATENAME> " + pPlaceOfSupply + " </STATENAME>"
                    x = x + "<COUNTRYOFRESIDENCE> " + pCountryName + " </COUNTRYOFRESIDENCE>"
                    x = x + "<Z_SALESMAN> " + pSupp + " </Z_SALESMAN>"
                    x = x + "</LEDGERENTRIES.LIST>"
                    Dim pInvoiceItem As New ImpInvoiceItems
                    pInvoiceItem.TerminalId = Session.Item("LoginTerminal")
                    pInvoiceItem.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                    For Each p As ImpInvoiceItems In ImpInvoiceItems.ReturnImpInvoiceItemsListByTally(pInvoiceItem)
                        Dim pServiceName As String = ""
                        Dim pAmount As Double = 0.0
                        pServiceName = p.ContNo
                        pAmount = p.BillRate
                        'Dim intCounter As Double = 0
                        'intCounter = p.BillQnty
                        x = x + "<LEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                        x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>" + pAmount.ToString() + "</AMOUNT>"
                        x = x + "<TAXOBJECTALLOCATIONS.LIST>"
                        x = x + "  <CATEGORY>Cargo Handling Services</CATEGORY> "
                        x = x + " <TAXTYPE>Service Tax</TAXTYPE>"
                        x = x + " <PARTYLEDGER>" & pLedgerName & "</PARTYLEDGER>"
                        x = x + "<METHODTYPE>As User Defined Value</METHODTYPE>"
                        x = x + "<NATUREOFSERVICE>Taxable</NATUREOFSERVICE>"
                        x = x + "<REFTYPE>New Ref</REFTYPE>"
                        x = x + "<SUBCATEGORYALLOCATION.LIST>"
                        x = x + " <SUBCATEGORY>Bill Value</SUBCATEGORY> "
                        x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                        x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                        x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                        x = x + "<VCHENTRYMODE>Accounting Invoice</VCHENTRYMODE>"
                        x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                        x = x + " <ASSESSABLEAMOUNT>" & p.BillAmount & "</ASSESSABLEAMOUNT> "
                        x = x + " <REALISEDASSESSABLEAMOUNT>" & p.BillAmount & "</REALISEDASSESSABLEAMOUNT> "

                        x = x + " </SUBCATEGORYALLOCATION.LIST>"

                        x = x + "<SUBCATEGORYALLOCATION.LIST>"
                        x = x + " <SUBCATEGORY>Service Amount</SUBCATEGORY> "
                        x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                        x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                        x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                        x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                        x = x + " <ASSESSABLEAMOUNT>" & p.BillAmount & "</ASSESSABLEAMOUNT> "
                        x = x + " <REALISEDASSESSABLEAMOUNT>" & p.BillAmount & "</REALISEDASSESSABLEAMOUNT> "
                        x = x + " </SUBCATEGORYALLOCATION.LIST>"
                        x = x + "<SUBCATEGORYALLOCATION.LIST>"
                        x = x + " <SUBCATEGORY>Abatement</SUBCATEGORY> "
                        x = x + "<DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                        x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                        x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                        x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                        x = x + "</SUBCATEGORYALLOCATION.LIST>"
                        x = x + "<SUBCATEGORYALLOCATION.LIST>"
                        x = x + "<SUBCATEGORY>Expenses</SUBCATEGORY> "
                        x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                        x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                        x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                        x = x + "<SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                        x = x + "</SUBCATEGORYALLOCATION.LIST>"
                        totalCalculatedAmount += pAmount
                        Dim pserviceTax As Integer = 0
                        Dim pInvoiceTax2 As New ImpInvoiceTax
                        pInvoiceTax2.TerminalId = Session.Item("LoginTerminal")
                        pInvoiceTax2.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                        pInvoiceTax2.ServiceId = p.ServiceId
                        For Each p2 As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListService(pInvoiceTax2)

                            Dim px2 As New TaxHeadMaster
                            px2.TerminalId = 6
                            px2.TaxHeadId = p2.TaxHeadId
                            TaxHeadMaster.ReturnTaxHeadMaster(px2)

                            pServiceName = px2.MapCode
                            pAmount = p2.TaxAmt
                            x = x + " <SUBCATEGORYALLOCATION.LIST>"
                            If p2.TaxPerc > 0 Then
                                If p2.TaxHeadId = 5 Then
                                    pTaxName = "IGST Payble GST@"
                                    pTaxName &= p2.TaxPerc
                                    pTaxName &= "%"
                                    x = x + "<SUBCATEGORY>Output Service Tax</SUBCATEGORY> "
                                    x = x + "  <DUTYLEDGER>" & pTaxName & "</DUTYLEDGER> "
                                    x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                                    x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                                    x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"
                                    x = x + "<TAXRATE>" & p2.TaxPerc & "</TAXRATE>"
                                    x = x + " <ASSESSABLEAMOUNT> " & p.BillRate & "</ASSESSABLEAMOUNT> "
                                    x = x + " <REALISEDASSESSABLEAMOUNT>" & p.BillRate & "</REALISEDASSESSABLEAMOUNT> "
                                    pserviceTax = pAmount
                                    x = x + "<TAX>" & pAmount & "</TAX>"
                                    totalCalculatedAmount += p2.TaxAmt
                                ElseIf p2.TaxHeadId = 6 Then
                                    pTaxName = "CGST Payble GST@"
                                    pTaxName &= p2.TaxPerc
                                    pTaxName &= "%"
                                    x = x + "<SUBCATEGORY>OutputEducationCess</SUBCATEGORY>"
                                    x = x + "  <DUTYLEDGER>" & pTaxName & "</DUTYLEDGER> "
                                    x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                                    x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                                    x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"
                                    x = x + "<TAXRATE>" & p2.TaxPerc & "</TAXRATE>"
                                    x = x + " <ASSESSABLEAMOUNT>" & pserviceTax & "</ASSESSABLEAMOUNT> "
                                    x = x + " <REALISEDASSESSABLEAMOUNT>" & pserviceTax & "</REALISEDASSESSABLEAMOUNT> "
                                    x = x + "<TAX>" & p2.TaxAmt & "</TAX>"
                                    totalCalculatedAmount += p2.TaxAmt
                                ElseIf p2.TaxHeadId = 7 Then
                                    pTaxName = "SGST Payble GST@"
                                    pTaxName &= p2.TaxPerc
                                    pTaxName &= "%"
                                    x = x + "<SUBCATEGORY>OutputSecondaryEducationCess</SUBCATEGORY> "
                                    x = x + "  <DUTYLEDGER>" & pTaxName & "</DUTYLEDGER> "
                                    x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                                    x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                                    x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"
                                    x = x + "<TAXRATE>" & p2.TaxPerc & "</TAXRATE>"
                                    x = x + " <ASSESSABLEAMOUNT>" & pserviceTax & "</ASSESSABLEAMOUNT> "
                                    x = x + " <REALISEDASSESSABLEAMOUNT>" & pserviceTax & "</REALISEDASSESSABLEAMOUNT> "
                                    x = x + "<TAX>" & p2.TaxAmt & "</TAX>"
                                    totalCalculatedAmount += p2.TaxAmt
                                End If
                            End If
                            x = x + " </SUBCATEGORYALLOCATION.LIST>"
                        Next
                        x = x + " </TAXOBJECTALLOCATIONS.LIST>"
                        x = x + "<TDSEXPENSEALLOCATIONS.LIST /> "
                        x = x + "<VATSTATUTORYDETAILS.LIST /> "
                        x = x + "<COSTTRACKALLOCATIONS.LIST /> "
                        x = x + "</LEDGERENTRIES.LIST>"
                    Next
                    Dim pInvoiceTax As New ImpInvoiceTax
                    pInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pInvoiceTax.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value

                    For Each p As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListTally(pInvoiceTax)
                        Dim pServiceName As String = ""
                        Dim pAmount As Double = 0
                        Dim px As New TaxHeadMaster
                        px.TerminalId = 6
                        px.TaxHeadId = p.TaxHeadId
                        TaxHeadMaster.ReturnTaxHeadMaster(px)

                        If px.MapCode = 101 Then
                            pServiceName = "CGST OUTPUT"

                            pAmount = p.TaxAmt
                            'chkTaxAmount = chkTaxAmount - p.TaxAmt

                        ElseIf px.MapCode = 102 Then
                            pServiceName = "SGST OUTPUT"

                            pAmount = p.TaxAmt
                            'chkTaxAmount = chkTaxAmount - p.TaxAmt
                            'If chkTaxAmount >0 Then
                            '    pAmount = pAmount + chkTaxAmount
                            'End If
                        Else
                            pServiceName = "IGST OUTPUT"
                            pAmount = p.TaxAmt
                            'chkTaxAmount = chkTaxAmount - p.TaxAmt
                            'If chkTaxAmount > 0 Then
                            '    pAmount = pAmount + chkTaxAmount
                            'End If
                        End If
                        x = x + "<LEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                        'x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                        'x = x + "<AMOUNT>-" + n.ToString() + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                        x = x + "<AMOUNT>" + pAmount.ToString() + "</AMOUNT>"
                        totalCalculatedAmount += p.TaxAmt

                        x = x + "</LEDGERENTRIES.LIST>"
                    Next
                    Dim pTDSServiceName As String = ""
                    If pTDSPer = 1 Then
                        pTDSServiceName = "TDS RECEIVABLE (As PER PARTY)"

                        x = x + "<LEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pTDSServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>-" + pTDSAmount + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pTDSServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "

                        x = x + "<AMOUNT>-" + pTDSAmount + "</AMOUNT>"

                        x = x + "</ALLLEDGERENTRIES.LIST>"
                    End If

                    If pTDSPer = 2 Then
                        pTDSServiceName = "TDS RECEIVABLE (As PER PARTY)"
                        x = x + "<LEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pTDSServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>-" + pTDSAmount + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pTDSServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "
                        x = x + "<AMOUNT>-" + pTDSAmount + "</AMOUNT>"
                        x = x + "</LEDGERENTRIES.LIST>"
                    End If
                    'If invAmt > pTotalAmount Then
                    '    x = x + "<LEDGERENTRIES.LIST>"
                    '    x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                    '    x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                    '    x = x + "<AMOUNT>+" + roundOff.ToString + "</AMOUNT>"
                    '    x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                    '    x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                    '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    '    x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "
                    '    x = x + "<AMOUNT>+" + roundOff.ToString + "</AMOUNT>"
                    '    x = x + "</LEDGERENTRIES.LIST>"
                    'Else
                    '    x = x + "<LEDGERENTRIES.LIST>"
                    '    x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                    '    x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                    '    x = x + "<AMOUNT>-" + roundOff.ToString + "</AMOUNT>"
                    '    x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                    '    x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                    '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    '    x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "
                    '    x = x + "<AMOUNT>-" + roundOff.ToString + "</AMOUNT>"
                    '    x = x + "</LEDGERENTRIES.LIST>"
                    'End If


                    If Math.Abs(billAmountOnPage - totalCalculatedAmount) <= 0.1 Then

                        Dim fp As Double = 0
                        If billAmountOnPage > totalCalculatedAmount Then
                            billAmountOnPage = totalCalculatedAmount
                            fp = Math.Round(billAmountOnPage Mod 1, 2)
                        End If

                        Dim arrNumber = totalCalculatedAmount.ToString().Split(CType(".", Char))
                        Dim integralPart As Long = 0
                        If arrNumber.Length = 2 Then
                            integralPart = Long.Parse(arrNumber(0))
                        Else
                            integralPart = Long.Parse(arrNumber(0))
                        End If

                        If Math.Abs(fp - 0) < 0.00001 Then
                            fp = Math.Round(totalCalculatedAmount Mod 1, 2)
                        End If

                        If fp >= 0.5 Then
                            integralPart += 1
                        End If

                        If fp >= 0.5 Then

                            x = x + "<LEDGERENTRIES.LIST>"
                            x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                            x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                            x = x + "<AMOUNT>+" + Math.Round((1 - fp), 2).ToString() + "</AMOUNT>"
                            x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                            x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                            x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                            x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                            x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                            x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "
                            x = x + "<AMOUNT>+" + Math.Round((1 - fp), 2).ToString() + "</AMOUNT>"
                            x = x + "</LEDGERENTRIES.LIST>"
                        Else
                            x = x + "<LEDGERENTRIES.LIST>"
                            x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                            x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                            x = x + "<AMOUNT>-" + fp.ToString() + "</AMOUNT>"
                            x = x + "<LEDGERNAME>ROUND OFF</LEDGERNAME>"
                            x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                            x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                            x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                            x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                            x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE> "
                            x = x + "<AMOUNT>-" + fp.ToString() + "</AMOUNT>"
                            x = x + "</LEDGERENTRIES.LIST>"
                        End If




                        x = x + "</VOUCHER>"
                        x = x + "</TALLYMESSAGE>"
                        x = x + "</DATA>"
                        x = x + "</BODY>"
                        x = x + "</ENVELOPE>"

                        '     If Math.Abs(billAmountOnPage - totalCalculatedAmount, 2) <= 0.05 Then
                        x = x.Replace("HARIOM", integralPart.ToString())
                    Else
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors,
                                                     lblErrorMessage,
                                                     "Amount Not matches, difference greater than 10 paise.")
                        Return
                    End If

                    File.WriteAllText(Me.Server.MapPath("~/tallypost.xml"), x)

                    Dim request As WebRequest = WebRequest.Create("http://103.107.92.210:9000")
                    'If Session.Item("CompanyId") = "2" Then
                    '    Dim request As WebRequest = WebRequest.Create("http://103.107.92.210:9000")
                    'Else
                    '    Dim request As WebRequest = WebRequest.Create("http://103.107.92.210:9999")

                    DirectCast(request, HttpWebRequest).UserAgent = ".NET Framework Example Client"
                    request.Method = "POST"
                    Dim POSTDATA As String = x
                    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(POSTDATA)
                    request.ContentType = "application/x-www-form-urlencoded"
                    request.ContentLength = byteArray.Length
                    Dim dataStream As Stream = request.GetRequestStream()
                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()
                    Dim response As WebResponse = request.GetResponse()
                    Dim Respo As String = (DirectCast(response, HttpWebResponse).StatusDescription).ToString()
                    dataStream = response.GetResponseStream()
                    Dim reader As New StreamReader(dataStream)
                    'Dim responseFromTallyServer As String = reader.ReadToEnd().ToString()

                    Dim responseFromTallyServer As String = reader.ReadToEnd().ToString()
                    Dim ResponseFromtally As String = responseFromTallyServer.ToString()
                    Dim TallyResponseDataSet As New DataSet()
                    TallyResponseDataSet.ReadXml(New StringReader(responseFromTallyServer))
                    Status = ExtractString(responseFromTallyServer, "<LINERERROR>", "</LINEERROR>")
                    reader.Close()
                    dataStream.Close()
                    response.Close()
                    byteArray = Nothing
                    response = Nothing
                    responseFromTallyServer = Nothing
                    Respo = Nothing
                    dataStream = Nothing
                    '  End If
                    'reader.Close()
                    If Status = "" Then
                        Dim Invoice_Id As Integer = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                        count = count + 1
                        Dim strConnectionString, cmd2 As String
                        Dim con As OleDbConnection
                        Try
                            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                            cmd2 = "UPDATE IMP_INVOICE SET TALLY_STATUS= 'Y', TALLY_CREATED_ON=SYSDATE  WHERE  INVOICE_NO=  " & Invoice_Id
                            con = New OleDbConnection(strConnectionString)
                            con.Open()
                            Dim cmd5 As New OleDbCommand(cmd2, con)
                            cmd5.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
                    Else
                        Status &= CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, Status)
                        Try
                            Dim strpParms1 As String = ""
                            strpParms1 &= Session.Item("LoginTerminal")
                            strpParms1 &= ",'" & Session.Item("CompanyId") & "'"
                            Dim dbr1 As OleDb.OleDbDataReader
                            Dim db1 As New DBConnect
                            dbr1 = db1.StoredProcedureReadDB("SELECT_PKG.SP_PENDING_TALLY_INVOICES", strpParms1)
                            repIndentDetails.DataSource = dbr1
                            repIndentDetails.DataBind()
                        Catch ex As Exception

                        End Try
                        Return
                    End If
                Else
                    Status &= CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Already post into tally")
                    Return
                End If

            End If
        Next

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PENDING_TALLY_INVOICES", strpParms)
        repIndentDetails.DataSource = dbr
        repIndentDetails.DataBind()


    End Sub
    Private Function ExtractString(ByVal s As String, ByVal start As String, ByVal [end] As String) As String
        ' You should check for errors in real-world code, omitted for brevity

        Dim startIndex As Integer = s.IndexOf(start) + start.Length
        Dim endIndex As Integer = s.IndexOf([end], startIndex)
        Try

            Return s.Substring(100, endIndex - 100)

        Catch ex As Exception

        End Try
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Private Sub repIndentDetails_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles repIndentDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim specialChar = CType(e.Item.FindControl("TextSpcChar"), TextBox).Text.Trim
            If specialChar = "Y" Then
                CType(e.Item.FindControl("chkIndent"), CheckBox).Checked = False
                CType(e.Item.FindControl("chkIndent"), CheckBox).Enabled = False
            End If

            If specialChar = "N" Then
                ' CType(e.Item.FindControl("chkIndent"), CheckBox).Checked = True
                CType(e.Item.FindControl("chkIndent"), CheckBox).Enabled = True
            End If
        End If

    End Sub
End Class

