Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data.OleDb
Imports System.Net.WebClient

Partial Class AdministratorUI_PaymentIssueTallyInterface
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim ROW As Integer = 5
    Dim count As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            Dim strpParms As String = ""
            strpParms &= Session.Item("CompanyId")
            ' strpParms = 1
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PEN_PAY_ISSUE_FOR_TALLY", strpParms)
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


    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            ' btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Sub ledger()


    End Sub
    Private Function SalesVoucher(ByVal x As String) As String

        ' Dim pNarration As String = text.Text

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
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PEN_PAY_DTLS_BY_RCPNOC", strpParms)
        gridviewcontDtls.DataSource = dbr
        gridviewcontDtls.DataBind()
        gridviewcontDtls.Visible = True
        Dim message As String = lnk.Text
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        For Each rc As RepeaterItem In repIndentDetails.Items
            Dim Status As String = ""
            If CType(rc.FindControl("chkIndent"), CheckBox).Checked = True Then
                Dim pLedgerName As String = ""
                Dim pChequeNo As String = ""
                Dim pChequeDate As String = ""
                Dim pNote As String = ""
                Dim pInviceNo As String = ""
                Dim pTotalAmount As String = ""
                Dim pBillNo As String = ""
                Dim pNarr As String = ""
                Dim pBank As String = ""
                Dim pTaxName As String = ""
                Dim pCheckTotalAmount As Double = 0
                Dim pCheckTaxAmount As Double = 0
                Dim pBalTaxAmount As Double = 0
                Dim chkTaxAmount As Double = 0
                Dim pInvoiceDate As String = ""
                pChequeDate = CType(rc.FindControl("txtVoucherDate"), TextBox).Text
                pChequeNo = CType(rc.FindControl("txtVoucherNo"), TextBox).Text
                pLedgerName = CType(rc.FindControl("textTallyCustomerName"), TextBox).Text
                pTotalAmount = CType(rc.FindControl("txtPaidAmount"), TextBox).Text
                chkTaxAmount = 0
                pNote = CType(rc.FindControl("hdnRemarks"), HiddenField).Value
                pBank = CType(rc.FindControl("hdnBankName"), HiddenField).Value
                pInviceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                Dim x As String = ""
                x = "<ENVELOPE>"
                x = x + "<HEADER>"
                x = x + "<VERSION>1</VERSION>"
                x = x + "<TALLYREQUEST>Import</TALLYREQUEST>"
                x = x + "<TYPE>Data</TYPE>"
                x = x + "<REQUESTDESC>"
                x = x + "<STATICVARIABLES>"
                If Session.Item("CompanyId") = "2" Then
                    x = x + "<SVCURRENTCOMPANY>JSB CARGO MOVERS PVT.LTD.</SVCURRENTCOMPANY> "
                ElseIf Session.Item("CompanyId") = "1" Then
                    x = x + "<SVCURRENTCOMPANY>JSB CONSULTANTS</SVCURRENTCOMPANY> "
                ElseIf Session.Item("CompanyId") = "4" Then
                    x = x + "<SVCURRENTCOMPANY>JSB CONSULTANTS MUMBAI</SVCURRENTCOMPANY> "
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
                'x = x + "< OBJVIEW>Invoice Voucher View <OBJVIEW>"
                x = x + "<DATE>" + pChequeDate + " </DATE>"

                'x = x + "<DATE> 30/08/2018</DATE>"
                x = x + "<NARRATION>" + pNote + "</NARRATION>"
                x = x + "<VOUCHERTYPENAME>Payment</VOUCHERTYPENAME>"
                x = x + "<VOUCHERNUMBER>" + pChequeNo + "</VOUCHERNUMBER>"
                x = x + "<REFERENCE>" + pChequeNo + " </REFERENCE>"
                x = x + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>"
                x = x + "<PERSISTEDVIEW>Accounting Voucher View</PERSISTEDVIEW>"
                x = x + "<VCHGSTCLASS/>"

                ' COMMENT BY LALIT
                ' x = x + "<PARTYLEDGERNAME>" & pLedgerName & " </PARTYLEDGERNAME>"


                Dim procNameCust As String = ""
                Dim procParamCust As String = ""
                Dim conCust As New OleDbConnection
                Dim strConnectionString As String = ""
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                conCust.ConnectionString = strConnectionString
                Dim adaCust As OleDbDataAdapter = New OleDbDataAdapter
                Dim cmdCust As OleDbCommand = conCust.CreateCommand
                cmdCust.Connection = conCust
                cmdCust.CommandType = CommandType.StoredProcedure
                procParamCust &= "" & pInviceNo & ""
                procNameCust = "SELECT_PKG.SP_PEN_CUST_DTLS_BY_RCPNO"
                cmdCust.CommandText = procNameCust & "(" & procParamCust & ")"
                adaCust.SelectCommand = cmdCust
                Dim dsCust As New DataSet
                adaCust.Fill(dsCust)
                If dsCust.Tables(0).Rows.Count > 0 Then
                    For J = 0 To dsCust.Tables(0).Rows.Count - 1
                        x = x + "<ALLLEDGERENTRIES.LIST>"
                        x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                        x = x + " <LEDGERFROMITEM>NO</LEDGERFROMITEM> "
                        x = x + "<LEDGERNAME>" + dsCust.Tables(0).Rows(J)("CUSTOMER_NAME") + "</LEDGERNAME>"
                        x = x + "<AMOUNT>-" & dsCust.Tables(0).Rows(J)("DR_AMOUNT") & "</AMOUNT>"
                        'x = x + " <BILLALLOCATIONS.LIST>"
                        'x = x + " <NAME>" + pChequeNo + " </NAME>"
                        'x = x + " <BILLTYPE>New Ref</BILLTYPE>"
                        'x = x + "  <AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                        'x = x + " </BILLALLOCATIONS.LIST>"
                        ' x = x + "</ALLLEDGERENTRIES.LIST>"

                        x = x + "<SERVICETAXDETAILS.LIST>       </SERVICETAXDETAILS.LIST>"
                        x = x + "<BANKALLOCATIONS.LIST></BANKALLOCATIONS.LIST>"
                        Dim procName As String = ""
                        Dim procParam As String = ""
                        Dim con As New OleDbConnection
                      con.ConnectionString = strConnectionString
                        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
                        Dim cmd As OleDbCommand = con.CreateCommand
                        cmd.Connection = con
                        cmd.CommandType = CommandType.StoredProcedure
                        procParam &= "" & pInviceNo & "," & dsCust.Tables(0).Rows(J)("CUSTOMER_ID") & " "
                        procName = "SELECT_PKG.SP_PEN_PAY_DTLS_BY_RCPNO"
                        cmd.CommandText = procName & "(" & procParam & ")"
                        ada.SelectCommand = cmd
                        Dim ds As New DataSet
                        ada.Fill(ds)
                        If ds.Tables(0).Rows.Count > 0 Then
                            For i = 0 To ds.Tables(0).Rows.Count - 1

                                Dim pInvoice As New CostBookingDtls
                                pInvoice.Total = ds.Tables(0).Rows(i)("DR_AMOUNT")
                                If ds.Tables(0).Rows(i)("INVOICE_NO") = "On Account" Then
                                    x = x + " <BILLALLOCATIONS.LIST>"
                                    x = x + " <NAME>" + ds.Tables(0).Rows(i)("INVOICE_NO") + " </NAME>"
                                    x = x + " <BILLTYPE>On Account</BILLTYPE>"
                                    If pInvoice.Total > 0 Then
                                        x = x + "  <AMOUNT>" & pInvoice.Total & "</AMOUNT>"
                                    Else
                                        x = x + "  <AMOUNT>-" & pInvoice.Total & "</AMOUNT>"
                                    End If

                                    x = x + " </BILLALLOCATIONS.LIST>"
                                Else
                                    x = x + " <BILLALLOCATIONS.LIST>"
                                    x = x + " <NAME>" + ds.Tables(0).Rows(i)("INVOICE_NO") + " </NAME>"
                                    x = x + " <BILLTYPE>Agst Ref</BILLTYPE>"
                                    x = x + "  <AMOUNT>-" & pInvoice.Total & "</AMOUNT>"
                                    x = x + " </BILLALLOCATIONS.LIST>"
                                End If
                            Next

                        End If
                        x = x + "</ALLLEDGERENTRIES.LIST>"

                    Next
                End If
                x = x + "<ALLLEDGERENTRIES.LIST>"
                x = x + " <LEDGERNAME>" + pBank + "</LEDGERNAME>"
                x = x + "<GSTCLASS/>"
                x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                x = x + "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>"
                x = x + " <ISPARTYLEDGER>Yes</ISPARTYLEDGER>"
                x = x + "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>"
                x = x + " <ISCAPVATTAXALTERED>No</ISCAPVATTAXALTERED>"
                x = x + "<ISCAPVATNOTCLAIMED>No</ISCAPVATNOTCLAIMED>"
                x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                x = x + "<SERVICETAXDETAILS.LIST></SERVICETAXDETAILS.LIST>"
                x = x + "<BANKALLOCATIONS.LIST>"
                x = x + "<DATE>" + pChequeDate + "</DATE>"
                x = x + "  <INSTRUMENTDATE>" + pChequeDate + "</INSTRUMENTDATE>"
                x = x + "  <BANKERSDATE>" + pChequeDate + "</BANKERSDATE>"

                x = x + " <TRANSACTIONTYPE>Cheque</TRANSACTIONTYPE>"
                x = x + "   <PAYMENTFAVOURING> " + pLedgerName + "</PAYMENTFAVOURING>"
                x = x + " <CHEQUECROSSCOMMENT>A/c Payee</CHEQUECROSSCOMMENT>"
                x = x + "   <INSTRUMENTNUMBER>" + pChequeNo + "</INSTRUMENTNUMBER>"

                x = x + "    <BANKPARTYNAME> " + pLedgerName + "</BANKPARTYNAME>"
                x = x + "    <ISCONNECTEDPAYMENT>No</ISCONNECTEDPAYMENT>"
                x = x + "    <ISSPLIT>No</ISSPLIT>"
                x = x + "    <ISCONTRACTUSED>No</ISCONTRACTUSED>"
                x = x + "    <ISACCEPTEDWITHWARNING>No</ISACCEPTEDWITHWARNING>"
                x = x + "    <ISTRANSFORCED>No</ISTRANSFORCED>"
                x = x + "    <AMOUNT>" + pTotalAmount + "</AMOUNT>"
                x = x + "     <CONTRACTDETAILS.LIST>        </CONTRACTDETAILS.LIST>"
                x = x + "     <BANKSTATUSINFO.LIST>        </BANKSTATUSINFO.LIST>"
                x = x + "     </BANKALLOCATIONS.LIST>"
                x = x + "     <BILLALLOCATIONS.LIST>       </BILLALLOCATIONS.LIST>"
                x = x + "     <INTERESTCOLLECTION.LIST>       </INTERESTCOLLECTION.LIST>"
                x = x + "   <OLDAUDITENTRIES.LIST>       </OLDAUDITENTRIES.LIST>"
                x = x + "    <ACCOUNTAUDITENTRIES.LIST>       </ACCOUNTAUDITENTRIES.LIST>"
                x = x + "</ALLLEDGERENTRIES.LIST>"


                'Dim pCrItemDetails As New DrItemDetails
                'pCrItemDetails.DrId = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                'Dim CgstAmount As Double = 0
                'Dim sgstAmount As Double = 0
                'Dim IgstAmount As Double = 0
                'Dim cgstRate As Double = 0
                'Dim sgstRate As Double = 0
                'Dim igstRate As Double = 0
                'For Each p As DrItemDetails In DrItemDetails.ReturnDebitServiceTallyListByDRId(pCrItemDetails)
                '    Dim pServiceName As String = ""
                '    Dim pAmount As String = ""
                '    Dim Pimpcontid As Double = 0
                '    Dim pservice As Double = 0
                '    pServiceName = p.DrOn
                '    pAmount = p.DrAmt
                '    Dim intCounter As Double = 0
                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                '    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "<ISPARTYLEDGER>No</ISPARTYLEDGER>"
                '    x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE>"

                '    x = x + "<AMOUNT>" + pAmount + "</AMOUNT>"
                '    x = x + "<TAXOBJECTALLOCATIONS.LIST>"
                '    x = x + "  <CATEGORY>Cargo Handling Services</CATEGORY> "
                '    x = x + " <TAXTYPE>Service Tax</TAXTYPE>"
                '    x = x + " <PARTYLEDGER>" & pLedgerName & "</PARTYLEDGER>"
                '    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE>"
                '    x = x + "<NATUREOFSERVICE>Taxable</NATUREOFSERVICE>"
                '    x = x + "<REFTYPE>Agst Ref</REFTYPE>"

                '    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + " <SUBCATEGORY>Bill Value</SUBCATEGORY> "
                '    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                '    '' x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                '    'x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                '    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                '    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                '    'x = x + " <ASSESSABLEAMOUNT>" & p.CrAmt + p.CrTax & "</ASSESSABLEAMOUNT> "
                '    'x = x + " <REALISEDASSESSABLEAMOUNT>" & p.CrAmt + p.CrTax & "</REALISEDASSESSABLEAMOUNT> "

                '    'x = x + " </SUBCATEGORYALLOCATION.LIST>"

                '    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + " <SUBCATEGORY>Service Amount</SUBCATEGORY> "
                '    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                '    'x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                '    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                '    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                '    'x = x + " <ASSESSABLEAMOUNT>+" & p.CrAmt + p.CrTax & "</ASSESSABLEAMOUNT> "
                '    'x = x + " <REALISEDASSESSABLEAMOUNT>+" & p.CrAmt + p.CrTax & "</REALISEDASSESSABLEAMOUNT> "
                '    'x = x + " </SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + " <SUBCATEGORY>Abatement</SUBCATEGORY> "
                '    'x = x + "<DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                '    'x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                '    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                '    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                '    'x = x + "</SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                '    'x = x + "<SUBCATEGORY>Expenses</SUBCATEGORY> "
                '    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                '    'x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                '    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                '    'x = x + "<SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                '    'x = x + "</SUBCATEGORYALLOCATION.LIST>"
                '    x = x + " </TAXOBJECTALLOCATIONS.LIST>"
                '    x = x + "<TDSEXPENSEALLOCATIONS.LIST /> "
                '    x = x + "<VATSTATUTORYDETAILS.LIST /> "
                '    x = x + "<COSTTRACKALLOCATIONS.LIST /> "
                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                '    CgstAmount = CgstAmount + p.CGST
                '    sgstAmount = sgstAmount + p.SGST
                '    IgstAmount = IgstAmount + p.IGST

                '    cgstRate = cgstRate + p.CGSTRate
                '    sgstRate = sgstRate + p.SGSTRate
                '    igstRate = igstRate + p.IGSTRate
                'Next


                'If cgstRate <> 0 Then
                '    Dim pamount As String = 0
                '    Dim PServiceName As String
                '    PServiceName = "CGST INPUT"

                '    pamount = CgstAmount
                '    ' chkTaxAmount = chkTaxAmount - p.CGSTAmount
                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                '    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                '    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                '    x = x + "<AMOUNT>" + pamount + "</AMOUNT>"

                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                'End If
                'If sgstRate <> 0 Then

                '    Dim pamount1 As String = 0
                '    Dim PServiceName1 As String

                '    PServiceName1 = "SGST INPUT"

                '    pamount1 = sgstAmount

                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + PServiceName1 + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                '    x = x + "<LEDGERNAME>" + PServiceName1 + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                '    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                '    x = x + "<AMOUNT>" + pamount1 + "</AMOUNT>"

                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                'End If
                'If igstRate <> 0 Then
                '    Dim pamount As String = 0
                '    Dim PServiceName As String

                '    PServiceName = "IGST INPUT"

                '    pamount = IgstAmount
                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                '    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                '    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                '    x = x + "<AMOUNT>" + pamount + "</AMOUNT>"

                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                'End If
                ''  End If


                x = x + "</VOUCHER>"
                x = x + "</TALLYMESSAGE>"
                x = x + "</DATA>"
                x = x + "</BODY>"
                x = x + "</ENVELOPE>"
                Dim request As WebRequest = WebRequest.Create("http://103.107.92.210:9000")
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


                'reader.Close()



                If Status = "" Then
                    Dim Invoice_Id As Integer = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                    count = count + 1
                    Dim strConnectionString1, cmd2 As String
                    Dim con1 As OleDbConnection
                    Try
                        strConnectionString1 = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = "UPDATE INVOICE_RECEIPT SET TALLY_STATUS= 'Y', TALLY_POSTED_STATUS=SYSDATE  WHERE  RECEIPT_NO=  " & Invoice_Id
                        con1 = New OleDbConnection(strConnectionString)
                        con1.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con1)
                        cmd5.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
                Else
                    Status &= CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, Status)
                    Try
                        Dim strpParms1 As String = ""
                        strpParms1 &= Session.Item("CompanyId")
                        'strpParms1 = 1
                        Dim dbr1 As OleDb.OleDbDataReader
                        Dim db1 As New DBConnect
                        dbr1 = db1.StoredProcedureReadDB("SELECT_PKG.SP_PEN_PAY_ISSUE_FOR_TALLY", strpParms1)
                        repIndentDetails.DataSource = dbr1
                        repIndentDetails.DataBind()
                    Catch ex As Exception

                    End Try
                    Return
                End If

            End If

        Next

        Dim strpParms As String = ""
        strpParms &= Session.Item("CompanyId")
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PEN_PAY_ISSUE_FOR_TALLY", strpParms)
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
End Class

