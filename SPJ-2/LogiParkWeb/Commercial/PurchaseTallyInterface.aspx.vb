Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data.OleDb
Imports System.Net.WebClient

Partial Class AdministratorUI_InvoiceTallyInterface
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
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PUR_PEN_TALLY_INVOICES", strpParms)
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
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PUR_TAL_SERVICE_WISE_CHARGE", strpParms)
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
                Dim pInvoiceDate As String = ""
                Dim pTotalAmount As String = ""
                Dim pBillNo As String = ""
                Dim pNarr As String = ""
                Dim pTaxName As String = ""
                Dim pCheckTotalAmount As Double = 0
                Dim pCheckTaxAmount As Double = 0
                Dim pBalTaxAmount As Double = 0
                Dim chkTaxAmount As Double = 0
                pInvoiceDate = CType(rc.FindControl("textInvoiceDate"), TextBox).Text
                pBillNo = CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                pLedgerName = CType(rc.FindControl("textTallyCustomerName"), TextBox).Text
                pTotalAmount = CType(rc.FindControl("textBillAmount"), TextBox).Text
                chkTaxAmount = 0
                chkTaxAmount = CType(rc.FindControl("textTaxAmount"), TextBox).Text
                Dim Pinv As New ImpInvoice
                Pinv.TerminalId = Session.Item("LoginTerminal")
                Pinv.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                ImpInvoice.ReturnImpInvoiceByInvoiceNo(Pinv)

                Dim pImpInvoice As New CostBooking
                pImpInvoice.CostID = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                pImpInvoice.BLNO = CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                CostBooking.ReturnPurchaseNaration(pImpInvoice)
                pNarr = pImpInvoice.CreatedBy


                Dim x As String = ""
                x = "<ENVELOPE>"
                x = x + "<HEADER>"
                x = x + "<VERSION>1</VERSION>"
                x = x + "<TALLYREQUEST>Import</TALLYREQUEST>"
                x = x + "<TYPE>Data</TYPE>"
                x = x + "<REQUESTDESC>"
                x = x + "<STATICVARIABLES>"
                'If Session.Item("CompanyId") = "2" Then
                '    x = x + "<SVCURRENTCOMPANY>JSB CARGO MOVERS PVT.LTD.</SVCURRENTCOMPANY> "
                'ElseIf Session.Item("CompanyId") = "1" Then
                '    x = x + "<SVCURRENTCOMPANY>JSB CONSULTANTS</SVCURRENTCOMPANY> "
                'ElseIf Session.Item("CompanyId") = "4" Then
                '    x = x + "<SVCURRENTCOMPANY>JSB CONSULTANTS MUMBAI</SVCURRENTCOMPANY> "
                'End If

                If Session.Item("CompanyId") = "2" Then
                    x = x + "<SVCURRENTCOMPANY> Allenhouse Business School -(2021-2022)</SVCURRENTCOMPANY> "
                ElseIf Session.Item("CompanyId") = "1" Then
                    x = x + "<SVCURRENTCOMPANY> Allenhouse Business School -(2021-2022)</SVCURRENTCOMPANY> "
                ElseIf Session.Item("CompanyId") = "4" Then
                    x = x + "<SVCURRENTCOMPANY> Allenhouse Business School -(2021-2022)</SVCURRENTCOMPANY> "
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
                x = x + "<DATE>" + pInvoiceDate + " </DATE>"
                'x = x + "<DATE> 30/08/2018</DATE>"
                x = x + "<NARRATION>" + pNarr + "</NARRATION>"
                x = x + "<VOUCHERTYPENAME>Purchase</VOUCHERTYPENAME>"
                x = x + "<REFERENCE>" + pBillNo + " </REFERENCE>"
                x = x + "<VOUCHERNUMBER>" + pBillNo + "</VOUCHERNUMBER>"
                x = x + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>"
                ''---------------
                'x = x + "<PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>"
                x = x + "<PERSISTEDVIEW>Accounting Voucher View</PERSISTEDVIEW>"
                x = x + "<VCHGSTCLASS/>"
                x = x + "<PARTYLEDGERNAME>" & pLedgerName & " </PARTYLEDGERNAME>"
                x = x + "<ALLLEDGERENTRIES.LIST>"
                x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                x = x + " <LEDGERFROMITEM>No</LEDGERFROMITEM> "
                x = x + "<LEDGERNAME>" + pLedgerName + "</LEDGERNAME>"
                x = x + "<AMOUNT>+" + pTotalAmount + "</AMOUNT>"
                x = x + " <BILLALLOCATIONS.LIST>"
                x = x + " <NAME>" + pBillNo + " </NAME>"
                x = x + " <BILLTYPE>New Ref</BILLTYPE>"
                x = x + "  <AMOUNT>" + pTotalAmount + "</AMOUNT>"
                x = x + " </BILLALLOCATIONS.LIST>"
                x = x + "</ALLLEDGERENTRIES.LIST>"
                Dim pInvoiceItem As New CostBookingDtls
                pInvoiceItem.CostID = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                For Each p As CostBookingDtls In CostBookingDtls.ReturnPurchaseServiceListByCostId(pInvoiceItem)
                    Dim pServiceName As String = ""
                    Dim pAmount As String = ""
                    Dim Pimpcontid As Double = 0
                    Dim pservice As Double = 0
                    'Dim px As New ServiceMaster
                    'px.TerminalId = Session.Item("LoginTerminal")
                    'px.ServiceId = p.ServiceId
                    'ServiceMaster.ReturnServiceMasterByServiceId(px)
                    pServiceName = p.CreatedBy
                    pAmount = p.BaseRate
                    Dim intCounter As Double = 0
                    '   intCounter = p.BillQnty

                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                    ' x = x + "<LEDGERNAME>Transportation Charges Inter State</LEDGERNAME>"
                    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"
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
                    ' x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                    x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    x = x + " <ASSESSABLEAMOUNT>+" & p.Total & "</ASSESSABLEAMOUNT> "
                    x = x + " <REALISEDASSESSABLEAMOUNT>" & p.Total & "</REALISEDASSESSABLEAMOUNT> "

                    x = x + " </SUBCATEGORYALLOCATION.LIST>"

                    x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    x = x + " <SUBCATEGORY>Service Amount</SUBCATEGORY> "
                    x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                    x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    x = x + " <ASSESSABLEAMOUNT>+" & p.Total & "</ASSESSABLEAMOUNT> "
                    x = x + " <REALISEDASSESSABLEAMOUNT>+" & p.Total & "</REALISEDASSESSABLEAMOUNT> "
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
                    Dim pserviceTax As Integer = 0
                    Dim pInvoiceTax2 As New CostBookingDtls
                    '   pInvoiceTax2.TerminalId = Session.Item("LoginTerminal")
                    pInvoiceTax2.CostID = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                    pInvoiceTax2.ServiceID = p.ServiceID
                    x = x + " </TAXOBJECTALLOCATIONS.LIST>"
                    x = x + "<TDSEXPENSEALLOCATIONS.LIST /> "
                    x = x + "<VATSTATUTORYDETAILS.LIST /> "
                    x = x + "<COSTTRACKALLOCATIONS.LIST /> "
                    x = x + "</ALLLEDGERENTRIES.LIST>"
                Next
                Dim pInvoiceTax As New CostBookingDtls
                '  pInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                pInvoiceTax.CostID = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                For Each p As CostBookingDtls In CostBookingDtls.ReturnPurchaseGSTNWiseDetailsForTally(pInvoiceTax)
                    Dim pServiceName As String = ""
                    Dim pAmount As String = ""
                    Dim pCrossChecktax As String = 0
                    Dim pCrossCGST As String = 0
                    pCrossChecktax = chkTaxAmount
                    If p.CGSTRate <> 0 Then
                        pServiceName = "CGST INPUT"

                        pAmount = p.CGSTAmount
                        'chkTaxAmount = chkTaxAmount - p.CGSTAmount
                        x = x + "<ALLLEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "
                        'pCrossChecktax = pCrossChecktax - pAmount
                        'If pCrossChecktax <> pAmount Then
                        '    pAmount = pCrossChecktax + 0.005
                        x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"
                        'Else
                        '    x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"
                        'End If
                        x = x + "</ALLLEDGERENTRIES.LIST>"
                    End If
                    If p.SGSTRate <> 0 Then
                        pServiceName = "SGST INPUT"

                        pAmount = p.SGSTAmount
                        'chkTaxAmount = chkTaxAmount - p.SGSTAmount
                        'If chkTaxAmount <> 0 Then
                        '    pAmount = pAmount + chkTaxAmount
                        'End If
                        x = x + "<ALLLEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "
                        'If pAmount <> pCrossChecktax Then
                        '    pAmount = pCrossChecktax + 0.005
                        x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"
                        'Else
                        '    x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"
                        'End If


                        x = x + "</ALLLEDGERENTRIES.LIST>"
                    End If
                    If p.IGSTRate <> 0 Then
                        pServiceName = "IGST INPUT"

                        pAmount = p.TaxAmt
                        x = x + "<ALLLEDGERENTRIES.LIST>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                        x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                        x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                        x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                        x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                        x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                        x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                        x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                        x = x + "<AMOUNT>-" + pAmount + "</AMOUNT>"

                        x = x + "</ALLLEDGERENTRIES.LIST>"
                    End If
                    ' End If

                Next
                Dim TDSPer As Double = 0
                Dim tdsAmount As String = ""
                Dim tdsServiceName As String = ""
                Try
                    TDSPer = CType(rc.FindControl("hdnTDSPer"), HiddenField).Value
                    tdsAmount = CType(rc.FindControl("txtTDSAmount"), TextBox).Text
                    tdsServiceName = CType(rc.FindControl("txtTDSAmount"), TextBox).Text
                Catch ex As Exception
                    TDSPer = 0
                End Try
                If TDSPer > 0 Then
                    tdsServiceName = "TDS PAYABLE 194C @" & TDSPer & "%"
                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"
                    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "
                    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"
                    x = x + "</ALLLEDGERENTRIES.LIST>"
                End If
                
                'If TDSPer = 1 Then
                '    tdsServiceName = "TDS PAYABLE 194C @1%"

                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                '    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"
                '    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                '    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                '    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"

                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                'ElseIf TDSPer = 2 Then
                '    tdsServiceName = "TDS PAYABLE 194C @2%"
                '    x = x + "<ALLLEDGERENTRIES.LIST>"
                '    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                '    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"
                '    x = x + "<LEDGERNAME>" + tdsServiceName + "</LEDGERNAME>"
                '    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                '    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                '    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                '    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                '    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                '    x = x + "<AMOUNT>" + tdsAmount + "</AMOUNT>"

                '    x = x + "</ALLLEDGERENTRIES.LIST>"
                'End If
                x = x + "</VOUCHER>"
                x = x + "</TALLYMESSAGE>"
                x = x + "</DATA>"
                x = x + "</BODY>"
                x = x + "</ENVELOPE>"



                '        string strFullPath = Server.MapPath("~/temp.xml");        
                'string strContents = null;
                'System.IO.StreamReader objReader = default(System.IO.StreamReader);
                'objReader = new System.IO.StreamReader(strFullPath);
                'strContents = objReader.ReadToEnd();
                'objReader.Close();

                'string attachment = "attachment; filename=test.xml";
                'Response.ClearContent();
                'Response.ContentType = "application/xml";
                'Response.AddHeader("content-disposition", attachment);
                'Response.Write(strContents);
                'Response.End();   
                '        Dim 

                Dim request As WebRequest = WebRequest.Create("http://11")
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
                    Dim strConnectionString, cmd2 As String
                    Dim con As OleDbConnection
                    Try
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = "UPDATE COST_BOOKING SET TALLY_STATUS= 'Y', TDS_CREATED_ON=SYSDATE  WHERE  COST_ID=  " & Invoice_Id
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                    End Try
                    Try
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = "UPDATE COST_BOOKING_NEW SET TALLY_STATUS= 'Y', TDS_CREATED_ON=SYSDATE  WHERE  COST_ID IN (SELECT COST_ID FROM COST_BOOKING_NEW " &
                               " WHERE LINER_INV_NO=(SELECT LINER_INV_NO FROM COST_BOOKING_NEW WHERE COST_ID=" & Invoice_Id & "))"
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
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
                        dbr1 = db1.StoredProcedureReadDB("SELECT_PKG.SP_PUR_PEN_TALLY_INVOICES", strpParms1)
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
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PUR_PEN_TALLY_INVOICES", strpParms)
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

