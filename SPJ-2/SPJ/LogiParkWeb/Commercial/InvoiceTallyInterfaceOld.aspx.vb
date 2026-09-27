Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.Net

Partial Class AdministratorUI_InvoiceTallyInterfaceOld
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim ROW As Integer = 5
    Dim count As Integer = 0
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
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
        Dim strpParms As Integer = 0
        strpParms = lnk.CommandArgument
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_ITM_DET_TALLY", strpParms)
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

                pInvoiceDate = CType(rc.FindControl("textInvoiceDate"), TextBox).Text
                pBillNo = CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                pLedgerName = CType(rc.FindControl("textCustomerName"), TextBox).Text
                pTotalAmount = CType(rc.FindControl("textBillAmount"), TextBox).Text


                Dim x As String = ""
                x = "<ENVELOPE>"
                x = x + "<HEADER>"
                x = x + "<VERSION>1</VERSION>"
                x = x + "<TALLYREQUEST>Import</TALLYREQUEST>"
                x = x + "<TYPE>Data</TYPE>"
                x = x + "<SVCURRENTCOMPANY>JSB CARGO MOVERS PVT.LTD.</SVCURRENTCOMPANY>"
                x = x + "<ID>Vouchers</ID>"
                x = x + "</HEADER>"
                x = x + "<BODY>"
                x = x + "<DESC></DESC>"
                x = x + "<DATA>"
                x = x + "<TALLYMESSAGE>"
                x = x + "<VOUCHER>"
                ' x = x + "< OBJVIEW>Invoice Voucher View <OBJVIEW>"
                x = x + "<DATE> " & pInvoiceDate & "</DATE>"
                x = x + "<NARRATION>Being Bill Booked Ags Container No.</NARRATION>"
                x = x + "<VOUCHERTYPENAME>Sales</VOUCHERTYPENAME>"
                x = x + "<REFERENCE>>28082018 </REFERENCE>"
                ' x = x + "<VOUCHERNUMBER>" + pBillNo + "</VOUCHERNUMBER>"
                x = x + "<VOUCHERNUMBER>28082018</VOUCHERNUMBER>"
                x = x + "   <FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE> "

                x = x + "<PERSISTEDVIEW>Accounting Voucher View</PERSISTEDVIEW> "
                x = x + "<VCHGSTCLASS/>"

                x = x + "   <PARTYLEDGERNAME>" & pLedgerName & " </PARTYLEDGERNAME> "

                x = x + "<ALLLEDGERENTRIES.LIST>"
                x = x + "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>"
                x = x + " <LEDGERFROMITEM>No</LEDGERFROMITEM> "
                x = x + "<LEDGERNAME>" + pLedgerName + "</LEDGERNAME>"
                x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                x = x + " <BILLALLOCATIONS.LIST>"
                x = x + " <NAME>" + pBillNo + " </NAME>"
                x = x + " <BILLTYPE>New Ref</BILLTYPE>"
                x = x + "  <AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                x = x + " </BILLALLOCATIONS.LIST>"
                x = x + "</ALLLEDGERENTRIES.LIST>"
                Dim pInvoiceItem As New ImpInvoiceItems
                pInvoiceItem.TerminalId = Session.Item("LoginTerminal")
                pInvoiceItem.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                For Each p As ImpInvoiceItems In ImpInvoiceItems.ReturnImpInvoiceItemsListByTally(pInvoiceItem)
                    Dim pServiceName As String = ""
                    Dim pAmount As String = ""
                    Dim Pimpcontid As Double = 0
                    Dim pservice As Double = 0
                    Dim px As New ServiceMaster
                    px.TerminalId = Session.Item("LoginTerminal")
                    px.ServiceId = p.ServiceId
                    ServiceMaster.ReturnServiceMasterByServiceId(px)
                    pServiceName = px.ServiceName
                    pAmount = p.BillRate
                    Dim intCounter As Long = 0
                    intCounter = p.BillQnty
                    x = x + "<ALLLEDGERENTRIES.LIST>"

                    x = x + "<LEDGERNAME>Transportation Charges Inter State</LEDGERNAME>"
                    'x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>" + pAmount + "</AMOUNT>"
                    x = x + "<TAXOBJECTALLOCATIONS.LIST>"
                    x = x + "  <CATEGORY>Cargo Handling Services</CATEGORY> "
                    x = x + " <TAXTYPE>Service Tax</TAXTYPE>"

                    ''If p.BillRate = 1150 Then
                    'x = x + " <TAXNAME> " & "Sale" & pBillNo & "-1</TAXNAME> "
                    ''Else
                    ''x = x + " <TAXNAME> " & "Sale" & pBillNo & "-2</TAXNAME> "

                    ''End If
                    x = x + " <PARTYLEDGER>" & pLedgerName & "</PARTYLEDGER>"
                    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + "<NATUREOFSERVICE>Taxable</NATUREOFSERVICE>"
                    x = x + "<REFTYPE>New Ref</REFTYPE>"

                    x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    x = x + " <SUBCATEGORY>Bill Value</SUBCATEGORY> "
                    x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    ' x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                    x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
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
                    x = x + " <ASSESSABLEAMOUNT>" & p.BillRate & "</ASSESSABLEAMOUNT> "
                    x = x + " <REALISEDASSESSABLEAMOUNT>" & p.BillRate & "</REALISEDASSESSABLEAMOUNT> "
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
                    Dim pInvoiceTax2 As New ImpInvoiceTax
                    pInvoiceTax2.TerminalId = Session.Item("LoginTerminal")
                    pInvoiceTax2.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                    pInvoiceTax2.ServiceId = p.ServiceId
                    For Each p2 As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListService(pInvoiceTax2)

                        Dim px2 As New TaxHeadMaster
                        px2.TerminalId = 1
                        px2.TaxHeadId = p2.TaxHeadId
                        TaxHeadMaster.ReturnTaxHeadMaster(px2)
                        pServiceName = px2.MapCode
                        pAmount = p2.TaxAmt
                        x = x + " <SUBCATEGORYALLOCATION.LIST>"
                        If px2.MapCode = 100 Then
                            x = x + "<SUBCATEGORY>Output Service Tax</SUBCATEGORY> "
                            x = x + "<SUBCATEGORY>Service Tax Payable</SUBCATEGORY>"
                            x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                            x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                            x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"


                            x = x + "<TAXRATE>12</TAXRATE>"
                            x = x + " <ASSESSABLEAMOUNT> " & p.BillRate & "</ASSESSABLEAMOUNT> "
                            x = x + " <REALISEDASSESSABLEAMOUNT>" & p.BillRate & "</REALISEDASSESSABLEAMOUNT> "

                            pserviceTax = pAmount
                            x = x + "<TAX>" & pAmount & "</TAX>"
                        ElseIf px2.MapCode = 101 Then
                            x = x + "<SUBCATEGORY>OutputEducationCess</SUBCATEGORY>"
                            x = x + "  <DUTYLEDGER>Education Tax Payable</DUTYLEDGER> "
                            x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                            x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                            x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"

                            x = x + "<TAXRATE>2</TAXRATE>"
                            x = x + " <ASSESSABLEAMOUNT>" & pserviceTax & "</ASSESSABLEAMOUNT> "
                            x = x + " <REALISEDASSESSABLEAMOUNT>" & pserviceTax & "</REALISEDASSESSABLEAMOUNT> "

                            x = x + "<TAX>" & p2.TaxAmt & "</TAX>"
                        ElseIf px2.MapCode = 102 Then
                            x = x + "<SUBCATEGORY>OutputSecondaryEducationCess</SUBCATEGORY> "
                            x = x + "  <DUTYLEDGER>SHEC Payable</DUTYLEDGER> "
                            x = x + "  <SUBCATZERORATED>No</SUBCATZERORATED> "
                            x = x + " <SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                            x = x + "  <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE>"
                            x = x + "<TAXRATE>1</TAXRATE>"
                            x = x + " <ASSESSABLEAMOUNT>" & pserviceTax & "</ASSESSABLEAMOUNT> "
                            x = x + " <REALISEDASSESSABLEAMOUNT>" & pserviceTax & "</REALISEDASSESSABLEAMOUNT> "
                            x = x + "<TAX>" & p2.TaxAmt & "</TAX>"
                        End If
                        x = x + " </SUBCATEGORYALLOCATION.LIST>"
                    Next
                    x = x + " </TAXOBJECTALLOCATIONS.LIST>"
                    x = x + "<TDSEXPENSEALLOCATIONS.LIST /> "
                    x = x + "<VATSTATUTORYDETAILS.LIST /> "
                    x = x + "<COSTTRACKALLOCATIONS.LIST /> "
                    x = x + "</ALLLEDGERENTRIES.LIST>"

                Next
                Dim pInvoiceTax As New ImpInvoiceTax
                pInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                pInvoiceTax.InvoiceNo = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                For Each p As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListTally(pInvoiceTax)
                    Dim pServiceName As String = ""
                    Dim pAmount As String = ""
                    Dim px As New TaxHeadMaster
                    px.TerminalId = 1
                    px.TaxHeadId = p.TaxHeadId
                    TaxHeadMaster.ReturnTaxHeadMaster(px)
                    If px.MapCode = 101 Then
                        pServiceName = "CGST OUTPUT"
                    ElseIf px.MapCode = 102 Then
                        pServiceName = "SGST OUTPUT"
                    Else
                        pServiceName = "IGST OUTPUT"
                    End If
                    pAmount = p.TaxAmt
                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                    'x = x + "<LEDGERNAME>Transportation Charges Inter State</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>"
                    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                    x = x + "<AMOUNT>" + pAmount + "</AMOUNT>"

                    x = x + "</ALLLEDGERENTRIES.LIST>"
                Next
                x = x + "</VOUCHER>"
                x = x + "</TALLYMESSAGE>"
                x = x + "</DATA>"
                x = x + "</BODY>"
                x = x + "</ENVELOPE>"
                Dim request As WebRequest = WebRequest.Create("http://192.168.88.223:9000")
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
                        cmd2 = " UPDATE IMP_INVOICE SET TALLY_STATUS= 'Y'  WHERE  INVOICE_NO=  " & Invoice_Id
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
                Else
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, Status)

                End If
            End If
        Next

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
