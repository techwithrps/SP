Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data.OleDb
Imports System.Net.WebClient

Partial Class AdministratorUI_DebitNoteTallyInterface
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
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PEN_DR_NOTE_FOR_TALLY", strpParms)
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
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DR_SERVICE_WISE_CHARGE", strpParms)
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
                Dim pCreditNoteNo As String = ""
                Dim pCreditDate As String = ""
                Dim pNote As String = ""
                Dim pInviceNo As String = ""
                Dim pTotalAmount As String = ""
                Dim pBillNo As String = ""
                Dim pNarr As String = ""
                Dim pTaxName As String = ""
                Dim pCheckTotalAmount As Double = 0
                Dim pCheckTaxAmount As Double = 0
                Dim pBalTaxAmount As Double = 0
                Dim chkTaxAmount As Double = 0
                Dim pInvoiceDate As String = ""
                pCreditDate = CType(rc.FindControl("textInvoiceDate"), TextBox).Text
                pCreditNoteNo = CType(rc.FindControl("textInvoiceNo"), LinkButton).Text
                pInviceNo = CType(rc.FindControl("txtBLNo"), TextBox).Text
                pLedgerName = CType(rc.FindControl("textTallyCustomerName"), TextBox).Text
                pTotalAmount = CType(rc.FindControl("textBillAmount"), TextBox).Text
                chkTaxAmount = 0
                chkTaxAmount = CType(rc.FindControl("textTaxAmount"), TextBox).Text
                pNote = CType(rc.FindControl("hdnNote"), HiddenField).Value

                pInvoiceDate = CType(rc.FindControl("txtMainInvoiceDate"), TextBox).Text
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
                x = x + "<DATE>" + pCreditDate + " </DATE>"
                x = x + "<REFERENCEDATE>" + pInvoiceDate + "</REFERENCEDATE>"

                'x = x + "<DATE> 30/08/2018</DATE>"
                x = x + "<NARRATION>" + pNote + "</NARRATION>"
                x = x + "<VOUCHERTYPENAME>Debit Note</VOUCHERTYPENAME>"
                x = x + "<REFERENCE>" + pInviceNo + " </REFERENCE>"
                x = x + "<VOUCHERNUMBER>" + pCreditNoteNo + "</VOUCHERNUMBER>"
                x = x + "<FBTPAYMENTTYPE>Default</FBTPAYMENTTYPE>"
                x = x + "<PERSISTEDVIEW>Accounting Voucher View</PERSISTEDVIEW>"
                x = x + "<VCHGSTCLASS/>"
                x = x + "<PARTYLEDGERNAME>" & pLedgerName & " </PARTYLEDGERNAME>"
                x = x + "<ALLLEDGERENTRIES.LIST>"
                x = x + "<ISDEEMEDPOSITIVE>YES</ISDEEMEDPOSITIVE>"
                x = x + " <LEDGERFROMITEM>NO</LEDGERFROMITEM> "
                x = x + "<LEDGERNAME>" + pLedgerName + "</LEDGERNAME>"
                x = x + "<AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                x = x + " <BILLALLOCATIONS.LIST>"
                x = x + " <NAME>" + pInviceNo + " </NAME>"
                x = x + " <BILLTYPE>Agst Ref</BILLTYPE>"
                x = x + "  <AMOUNT>-" + pTotalAmount + "</AMOUNT>"
                x = x + " </BILLALLOCATIONS.LIST>"
                x = x + "</ALLLEDGERENTRIES.LIST>"
                Dim pCrItemDetails As New DrItemDetails
                pCrItemDetails.DrId = CType(rc.FindControl("hdnInvoiceId"), HiddenField).Value
                Dim CgstAmount As Double = 0
                Dim sgstAmount As Double = 0
                Dim IgstAmount As Double = 0
                Dim cgstRate As Double = 0
                Dim sgstRate As Double = 0
                Dim igstRate As Double = 0
                For Each p As DrItemDetails In DrItemDetails.ReturnDebitServiceTallyListByDRId(pCrItemDetails)
                    Dim pServiceName As String = ""
                    Dim pAmount As String = ""
                    Dim Pimpcontid As Double = 0
                    Dim pservice As Double = 0
                    pServiceName = p.DrOn
                    pAmount = p.DrAmt
                    Dim intCounter As Double = 0
                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + pServiceName + "</LEDGERNAME>"
                    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "<ISPARTYLEDGER>No</ISPARTYLEDGER>"
                    x = x + " <ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE>"

                    x = x + "<AMOUNT>" + pAmount + "</AMOUNT>"
                    x = x + "<TAXOBJECTALLOCATIONS.LIST>"
                    x = x + "  <CATEGORY>Cargo Handling Services</CATEGORY> "
                    x = x + " <TAXTYPE>Service Tax</TAXTYPE>"
                    x = x + " <PARTYLEDGER>" & pLedgerName & "</PARTYLEDGER>"
                    x = x + "<METHODTYPE>As User Defined Value</METHODTYPE>"
                    x = x + "<NATUREOFSERVICE>Taxable</NATUREOFSERVICE>"
                    x = x + "<REFTYPE>Agst Ref</REFTYPE>"

                    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    'x = x + " <SUBCATEGORY>Bill Value</SUBCATEGORY> "
                    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    '' x = x + "<METHODTYPE>As User Defined Value</METHODTYPE> "
                    'x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    'x = x + " <ASSESSABLEAMOUNT>" & p.CrAmt + p.CrTax & "</ASSESSABLEAMOUNT> "
                    'x = x + " <REALISEDASSESSABLEAMOUNT>" & p.CrAmt + p.CrTax & "</REALISEDASSESSABLEAMOUNT> "

                    'x = x + " </SUBCATEGORYALLOCATION.LIST>"

                    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    'x = x + " <SUBCATEGORY>Service Amount</SUBCATEGORY> "
                    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    'x = x + " <SUBCATZERORATED>No</SUBCATZERORATED> "
                    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    'x = x + " <ASSESSABLEAMOUNT>+" & p.CrAmt + p.CrTax & "</ASSESSABLEAMOUNT> "
                    'x = x + " <REALISEDASSESSABLEAMOUNT>+" & p.CrAmt + p.CrTax & "</REALISEDASSESSABLEAMOUNT> "
                    'x = x + " </SUBCATEGORYALLOCATION.LIST>"
                    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    'x = x + " <SUBCATEGORY>Abatement</SUBCATEGORY> "
                    'x = x + "<DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    'x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    'x = x + " <SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    'x = x + "</SUBCATEGORYALLOCATION.LIST>"
                    'x = x + "<SUBCATEGORYALLOCATION.LIST>"
                    'x = x + "<SUBCATEGORY>Expenses</SUBCATEGORY> "
                    'x = x + " <DUTYLEDGER>" & pLedgerName & "</DUTYLEDGER> "
                    'x = x + "<SUBCATZERORATED>No</SUBCATZERORATED> "
                    'x = x + "<SUBCATEXEMPTED>No</SUBCATEXEMPTED> "
                    'x = x + "<SUBCATISSPECIALRATE>No</SUBCATISSPECIALRATE> "
                    'x = x + "</SUBCATEGORYALLOCATION.LIST>"
                    x = x + " </TAXOBJECTALLOCATIONS.LIST>"
                    x = x + "<TDSEXPENSEALLOCATIONS.LIST /> "
                    x = x + "<VATSTATUTORYDETAILS.LIST /> "
                    x = x + "<COSTTRACKALLOCATIONS.LIST /> "
                    x = x + "</ALLLEDGERENTRIES.LIST>"
                    CgstAmount = CgstAmount + p.CGST
                    sgstAmount = sgstAmount + p.SGST
                    IgstAmount = IgstAmount + p.IGST

                    cgstRate = cgstRate + p.CGSTRate
                    sgstRate = sgstRate + p.SGSTRate
                    igstRate = igstRate + p.IGSTRate
                Next


                If cgstRate <> 0 Then
                    Dim pamount As String = 0
                    Dim PServiceName As String
                    PServiceName = "CGST INPUT"

                    pamount = CgstAmount
                    ' chkTaxAmount = chkTaxAmount - p.CGSTAmount
                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                    x = x + "<AMOUNT>" + pamount + "</AMOUNT>"

                    x = x + "</ALLLEDGERENTRIES.LIST>"
                End If
                If sgstRate <> 0 Then

                    Dim pamount1 As String = 0
                    Dim PServiceName1 As String

                    PServiceName1 = "SGST INPUT"

                    pamount1 = sgstAmount

                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + PServiceName1 + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                    x = x + "<LEDGERNAME>" + PServiceName1 + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                    x = x + "<AMOUNT>" + pamount1 + "</AMOUNT>"

                    x = x + "</ALLLEDGERENTRIES.LIST>"
                End If
                If igstRate <> 0 Then
                    Dim pamount As String = 0
                    Dim PServiceName As String

                    PServiceName = "IGST INPUT"

                    pamount = IgstAmount
                    x = x + "<ALLLEDGERENTRIES.LIST>"
                    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "<AMOUNT>" + pTotalAmount + "</AMOUNT>"
                    x = x + "<LEDGERNAME>" + PServiceName + "</LEDGERNAME>"
                    x = x + "<ISDEEMEDPOSITIVE>NO</ISDEEMEDPOSITIVE>"
                    x = x + "  <LEDGERFROMITEM>No</LEDGERFROMITEM>"
                    x = x + " <REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES> "
                    x = x + "  <ISPARTYLEDGER>No</ISPARTYLEDGER> "
                    x = x + " <ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE> "

                    x = x + "<AMOUNT>" + pamount + "</AMOUNT>"

                    x = x + "</ALLLEDGERENTRIES.LIST>"
                End If
                '  End If


                x = x + "</VOUCHER>"
                x = x + "</TALLYMESSAGE>"
                x = x + "</DATA>"
                x = x + "</BODY>"
                x = x + "</ENVELOPE>"
                Dim request As WebRequest = WebRequest.Create("http://117.242.39.55:9000")
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
                        cmd2 = "UPDATE DR_NOTE SET TALLY_STATUS= 'Y', TALLY_CREATED_ON=SYSDATE  WHERE  DR_ID=  " & Invoice_Id
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
                        strpParms1 &= Session.Item("CompanyId")
                        'strpParms1 = 1
                        Dim dbr1 As OleDb.OleDbDataReader
                        Dim db1 As New DBConnect
                        dbr1 = db1.StoredProcedureReadDB("SELECT_PKG.SP_PEN_DR_NOTE_FOR_TALLY", strpParms1)
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
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_PEN_DR_NOTE_FOR_TALLY", strpParms)
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

