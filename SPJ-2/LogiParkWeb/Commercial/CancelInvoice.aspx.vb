Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports LogiParkLib.DBConnection
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient
Imports CommonSendingMailLibary

Partial Class Commercial_CancelInvoice
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Dim lngImpContId As Integer = 0
    Dim dblAmount As Double
    Dim dblTaxAmount As Double
    Dim dblTotalAmount As Double
    Dim dblWeaverAmt As Double
    Dim dblServiceTax As Double
    Dim dblEducTax As Double
    Dim dblHEduTax As Double
    Dim strTerminalId As String
    Dim strInvoiceNo As String
    Dim strDocType As String
    Dim strBookingNo As String
    Dim lngBookingId As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
            fillRepeator(New ArrayList)
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
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

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnClInvoiceId.Value.Trim <> Nothing Then
            btnPrint.Visible = True
        Else
            btnPrint.Visible = False
        End If
        ' btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New ImpInvoiceItems
                arr.Add(p)
            Next
        End If
        rcInvoiceDetails.DataSource = arr
        rcInvoiceDetails.DataBind()

        'textRepAmount.Text = Math.Round(dblAmount, 2)
        'textRepTaxAmount.Text = Math.Round(dblTaxAmount, 2)
        'textRepTotalAmount.Text = Math.Round(dblTotalAmount, 2)
        ''textRepWeiverReqAmt.Text = Math.Round(dblWeaverAmt, 2)
        'textRepServiceTax.Text = Math.Round(dblServiceTax, 2)
        'textRepEducTax.Text = Math.Round(dblEducTax, 2)
        'textRepHEducTax.Text = Math.Round(dblHEduTax, 2)
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddInvoiceNo.Visible = True
        btnSearchInvoiceNo.Visible = False
        textInvoiceRefNo.Enabled = True
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "ADD"
        Functions.ControlFocus(textInvoiceRefNo)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddInvoiceNo.Visible = False
        btnSearchInvoiceNo.Visible = True
        textInvoiceRefNo.Enabled = True
        tvInvoices.Nodes.Clear()
        hdnMode.Value = "SEARCH"
        Functions.ControlFocus(textInvoiceRefNo)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        btnAddInvoiceNo.Visible = False
        btnSearchInvoiceNo.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        textCancelNote.Enabled = pEnable
    End Sub
    Protected Sub btnAddInvoiceNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddInvoiceNo.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textInvoiceRefNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Invoice No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        Dim pExtImpInvoice As New ExtImpInvoice
        pExtImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pExtImpInvoice.InvoiceRefNo = textInvoiceRefNo.Text
        ExtImpInvoice.ReturnImpInvoiceByInvoiceRefNoComapny(pExtImpInvoice)
        If pExtImpInvoice.InvoiceNo <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Invoice No.")
            Exit Sub
        End If
        'If pExtImpInvoice.CancleFlage = "C" Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Invoice Number")
        '    Functions.ControlFocus(textInvoiceRefNo)
        '    Return
        'End If
        prepareControls(pExtImpInvoice)
        btnAddInvoiceNo.Visible = False
        btnSearchInvoiceNo.Visible = False
        manageUserControls(True)
        ButtonControlSetup(False)
        manageControl(True)
        Functions.ControlFocus(textCancelNote)
        If Session.Item("LoginUser") = "Ashish Devrani" Or Session.Item("LoginUser") = "Suman" Or Session.Item("LoginUser") = "Deepak Kandpal" Or Session.Item("LoginUser") = "Vansh" Or Session.Item("LoginUser") = "Pooja" Or Session.Item("LoginUser") = "ADMIN" Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

    End Sub

    Sub prepareControls(ByVal pExtImpInvoice As ExtImpInvoice)
        textInvoiceRefNo.Text = pExtImpInvoice.InvoiceRefNo
        hdnInvoiceNo.Value = pExtImpInvoice.InvoiceNo
        hdnBookingId.Value = pExtImpInvoice.LineItemId
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        If pExtImpInvoice.PaymentMode = "C" Then
            textPaymentMode.Text = "Cash"
        ElseIf pExtImpInvoice.PaymentMode = "R" Then
            textPaymentMode.Text = "Credit"
        End If
        Try
            lstServiceType.SelectedValue = pExtImpInvoice.ServiceType
        Catch ex As Exception

        End Try
        If pExtImpInvoice.CustomerType = "C" Then
            textInvoiceTo.Text = "CHA"
        ElseIf pExtImpInvoice.CustomerType = "A" Then
            textInvoiceTo.Text = "Agent"
        ElseIf pExtImpInvoice.CustomerType = "L" Then
            textInvoiceTo.Text = "Line"
        ElseIf pExtImpInvoice.CustomerType = "B" Then
            textInvoiceTo.Text = "Billing Party"
        End If
        Dim pExtCustomerMaster As New ExtCustomerMaster
        pExtCustomerMaster.TerminalId = pExtImpInvoice.TerminalId
        pExtCustomerMaster.CustomerId = pExtImpInvoice.BillTo
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        'textBillingParty.Text = pExtCustomerMaster.CustomerName

        Dim pExtExportBooking As New FleetContJo
        pExtExportBooking.TerminalId = Session.Item("LoginTerminal")
        pExtExportBooking.ContJoId = pExtImpInvoice.LineItemId
        FleetContJo.ReturnFleetContJo(pExtExportBooking)
        'textBookingNo.Text = pExtExportBooking.BookingNo
        pExtCustomerMaster.CustomerId = pExtExportBooking.CustomerId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textCha.Text = pExtCustomerMaster.CustomerName

        pExtCustomerMaster.CustomerId = pExtExportBooking.LineId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textLine.Text = pExtCustomerMaster.CustomerName

        pExtCustomerMaster.CustomerId = pExtExportBooking.ConsigneeId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textExporter.Text = pExtCustomerMaster.CustomerName

        Dim pImpInvoiceItems As New ImpInvoiceItems
        pImpInvoiceItems.TerminalId = pExtImpInvoice.TerminalId
        pImpInvoiceItems.InvoiceNo = pExtImpInvoice.InvoiceNo
        fillRepeator(ImpInvoiceItems.ReturnImpInvoiceItemsListByInvoiceNo(pImpInvoiceItems))
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textCancelNote.Text = Nothing AndAlso textCancelNote.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCancelNote.Text & "is blank.")
            Functions.ControlFocus(textCancelNote)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If chkConfirmCancel.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Confirm Cancel Check Box")
            Functions.ControlFocus(chkConfirmCancel)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pCancelImpInvoice As CancelImpInvoice = returnObjectsData()
        If hdnClInvoiceId.Value <> Nothing AndAlso hdnClInvoiceId.Value > 0 Then
            CancelImpInvoice.Update(pCancelImpInvoice)
        Else
            CancelImpInvoice.Insert(pCancelImpInvoice)
        End If
        If pCancelImpInvoice.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCancelImpInvoice.Errormsg)
            Return
        End If

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnClInvoiceId.Value = pCancelImpInvoice.ClInvoiceId
        textClInvoiceNo.Text = pCancelImpInvoice.ClInvoiceNo
        textClInvoiceDate.Text = pCancelImpInvoice.CancelOn
        LoadTreeViewData(pCancelImpInvoice)
        Dim strConnectionString, cmd1 As String
        Dim con As New OleDbConnection
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "DELETE FROM PAYMENT_DATA WHERE REF_NO='" & textInvoiceRefNo.Text.Trim & "'"
        con = New OleDbConnection(strConnectionString)
        con.Open() '
        Dim cmd5 As New OleDbCommand(cmd1, con)
        cmd5.ExecuteNonQuery()
        con.Close()
        tvInvoices.Enabled = True
        ButtonControlSetup(True)
        manageUserControls(True)
        sendmail()
    End Sub
    Sub sendmail()
        Dim pInvoice As New CancelImpInvoice
        pInvoice.TerminalId = Session.Item("LoginTerminal")
        pInvoice.ClInvoiceId = hdnClInvoiceId.Value
        CancelImpInvoice.ReturnCancelImpInvoiceByClInvoiceId(pInvoice)
        Dim xMailSetup As String = ""
        Dim con As New OleDbConnection
        Dim strConnectionString As String = ""
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        'strConnectionString = "Provider=MSDAORA;Data Source=SPJLIVE;Persist Security Info=True;Password=SPjlive_961619#;User ID=SPJLIVE"
        con = New OleDbConnection(strConnectionString)
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        Dim ada1 As OleDbDataAdapter = New OleDbDataAdapter
        Dim CMD1 As String = ""
        Dim adamailconfig As OleDbDataAdapter
        Dim cmdmailconfig As String
        cmdmailconfig = "SELECT FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=5"
        adamailconfig = New OleDbDataAdapter(cmdmailconfig, con)
        Dim dsmailconfig As New DataSet
        adamailconfig.Fill(dsmailconfig)
        Dim adamailsetup As OleDbDataAdapter
        Dim cmdmailsetup As String
        cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=464 AND TERMINAL_ID=1"
        adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
        Dim dsmailsetup As New DataSet
        adamailsetup.Fill(dsmailsetup)
        Dim confirmMail As New StringBuilder
        confirmMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>SR.</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Customer Name</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Amount</b>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Remarks</b>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Cancel By</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Cancel On</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </td>")
        Dim ada2 As OleDbDataAdapter = New OleDbDataAdapter
        Dim cmd As OleDbCommand = con.CreateCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        Dim procName As String = ""
        Dim procParam As String = ""
        procParam &= Session.Item("LoginTerminal")
        procParam &= ",'" & Session.Item("CompanyId") & "'"
        ' procParam &= "," & hdnClInvoiceId.Value & ""
        procParam &= "," & hdnInvoiceNo.Value
        procName = "REPORT_PKG.SP_CANCEL_INVOICE_MAIL"
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
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_REF_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_DATE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CUSTOMER_NAME"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("BILL_AMOUNT"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CANCEL_NOTE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CANCEL_BY"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CANCEL_ON"))
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
        xMailSetup &= "<font color='#00008B'>Dear All,"
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "<font color='#00008B'>Please find the below  cancel invoice."
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= confirmMail.ToString
        xMailSetup &= "<br/>"
        'xMailSetup &= dsmailsetup.Tables(0).Rows(0)("MAIL_BODY")
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= " " & "<br/>"
        xMailSetup &= " " & "<br/>"
        xMailSetup &= "<font color='#00008B'>Thanks n best regards, " & "<br><br>Akshay Saxena<br>"
        'xMailSetup &= dsmailsetup.Tables(0).Rows(0)("SIGNATURE") & "<br>"
        Dim strCCID As String = ""
        Try
            strCCID = dsmailsetup.Tables(0).Rows(0)("CC_IDS")
        Catch
            strCCID = ""
        End Try
        Dim strBccID As String = ""
        Try
            strBccID = dsmailsetup.Tables(0).Rows(0)("BCC_IDS")
        Catch
            strBccID = ""
        End Try
        Dim pStr As String = ""
        If dsOSDRY.Tables(0).Rows.Count > 0 Then
            ' pStr = sendMailToCcBccID(dsmailconfig.Tables(0).Rows(0)("FROM_ID"), dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS"), strCCID, strBccID, dsmailsetup.Tables(0).Rows(0)("SUBJECT"), xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), dsmailconfig.Tables(0).Rows(0)("PASSWORD"), dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            pStr = MailSender.SendMailToCcBccIDWithOrWithoutAttachment(dsmailconfig.Tables(0).Rows(0)("FROM_ID"), dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS"), strCCID, strBccID, dsmailsetup.Tables(0).Rows(0)("SUBJECT"), xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), dsmailconfig.Tables(0).Rows(0)("PASSWORD"), dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            If pStr = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent")
            Else
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent fail")
            End If
        End If
    End Sub
    Public Shared Function sendMailToCcBccID(ByVal fromMailId As String, ByVal fromName As String, ByVal toMailIds As String, ByVal CCIds As String, ByVal BccIds As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal passWord As String, ByVal port As String) As String
        Dim returnStr As String = String.Empty
        Try
            Dim objMM As New MailMessage
            Dim i As Integer = 0


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
                'objMM.Attachments.Add(New Attachment(fromName))

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

            Dim sm As SmtpClient = New SmtpClient(smtpServer, port)
            'sm.Host = smtpServer
            'sm.Port = port
            sm.Credentials = New System.Net.NetworkCredential(fromMailId, passWord)
            Try
                sm.EnableSsl = True
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                ' sm.UseDefaultCredentials = True
                sm.Send(objMM)
                sm = Nothing
            Catch ex As Exception
                sm.EnableSsl = False
                sm.DeliveryMethod = SmtpDeliveryMethod.Network
                ' sm.UseDefaultCredentials = True
                sm.Send(objMM)
                sm = Nothing
            End Try

        Catch ex As Exception
            returnStr = ex.Message
        End Try
        Return returnStr
    End Function

    Function returnObjectsData() As CancelImpInvoice
        Dim pCancelImpInvoice As New CancelImpInvoice
        If hdnClInvoiceId.Value <> Nothing AndAlso hdnClInvoiceId.Value > 0 Then
            pCancelImpInvoice.ClInvoiceNo = hdnClInvoiceId.Value
        End If
        pCancelImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pCancelImpInvoice.InvoiceNo = hdnInvoiceNo.Value
        pCancelImpInvoice.LineItemId = hdnBookingId.Value
        pCancelImpInvoice.CancelNote = textCancelNote.Text
        pCancelImpInvoice.DocType = Session.Item("CompanyId")
        pCancelImpInvoice.CancelBy = Session.Item("LoginUser")
        Return pCancelImpInvoice
    End Function

    Protected Sub btnSearchInvoiceNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchInvoiceNo.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textInvoiceRefNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Number is blank")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        Dim pCancelImpInvoice As New CancelImpInvoice
        pCancelImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pCancelImpInvoice.InvoiceRefNo = textInvoiceRefNo.Text
        CancelImpInvoice.ReturnCancelImpInvoiceByInvoiceRefNo(pCancelImpInvoice)
        If pCancelImpInvoice.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCancelImpInvoice.Errormsg)
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        'If pCancelImpInvoice.ClInvoiceId <= 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Invoice Number.")
        '    Functions.ControlFocus(textInvoiceRefNo)
        '    Return
        'End If
        'If pCancelImpInvoice.DocType <> "E" Or pCancelImpInvoice.DocType <> "M" Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Invoice Number.")
        '    Functions.ControlFocus(textInvoiceRefNo)
        '    Return
        'End If
        SaveViewState()
        If Session.Item("LoginUser") = "Ashish Devrani" Or Session.Item("LoginUser") = "Deepak Kandpal" Or Session.Item("LoginUser") = "Vansh" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Pooja" Or Session.Item("LoginUser") = "Suman" Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
        ' btnSearchInvoice.Visible = False
        btnPrint.Visible = True
        ' btnEdit.Visible = False
    End Sub

    Sub prepareControlsSearchData(ByVal pCancelImpInvoice As CancelImpInvoice)
        textInvoiceRefNo.Text = pCancelImpInvoice.InvoiceRefNo
        hdnInvoiceNo.Value = pCancelImpInvoice.InvoiceNo
        hdnBookingId.Value = pCancelImpInvoice.LineItemId
        textInvoiceDate.Text = pCancelImpInvoice.InvoiceDate
        If pCancelImpInvoice.PaymentMode = "C" Then
            textPaymentMode.Text = "Cash"
        ElseIf pCancelImpInvoice.PaymentMode = "R" Then
            textPaymentMode.Text = "Credit"
        End If
        lstServiceType.SelectedValue = pCancelImpInvoice.ServiceType
        If pCancelImpInvoice.CustomerType = "L" Then
            textInvoiceTo.Text = "Line"
        ElseIf pCancelImpInvoice.CustomerType = "E" Then
            textInvoiceTo.Text = "Consignee"
        ElseIf pCancelImpInvoice.CustomerType = "R" Then
            textInvoiceTo.Text = "Consignor"
        ElseIf pCancelImpInvoice.CustomerType = "B" Then
            textInvoiceTo.Text = "Billing Party"
        End If
        'textGrTillDate.Text = pCancelImpInvoice.GrTillDate

        Dim pExtCustomerMaster As New ExtCustomerMaster
        pExtCustomerMaster.TerminalId = pCancelImpInvoice.TerminalId
        pExtCustomerMaster.CustomerId = pCancelImpInvoice.BillTo
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        'textBillingParty.Text = pExtCustomerMaster.CustomerName

        Dim pExtExportBooking As New FleetContJo
        pExtExportBooking.TerminalId = Session.Item("LoginTerminal")
        pExtExportBooking.ContJoId = pCancelImpInvoice.LineItemId
        FleetContJo.ReturnFleetContJo(pExtExportBooking)
        'textBookingNo.Text = pExtExportBooking.BookingNo



        pExtCustomerMaster.CustomerId = pExtExportBooking.CustomerId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textCha.Text = pExtCustomerMaster.CustomerName

        pExtCustomerMaster.CustomerId = pExtExportBooking.LineId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textLine.Text = pExtCustomerMaster.CustomerName

        pExtCustomerMaster.CustomerId = pExtExportBooking.ConsigneeId
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        textExporter.Text = pExtCustomerMaster.CustomerName

        Dim pCancelImpInvoiceItems As New CancelImpInvoiceItems
        pCancelImpInvoiceItems.TerminalId = pCancelImpInvoice.TerminalId
        pCancelImpInvoiceItems.ClInvoiceId = pCancelImpInvoice.ClInvoiceId
        fillRepeator(CancelImpInvoiceItems.ReturnCancelImpInvoiceItemsListByClInvoiceId(pCancelImpInvoiceItems))
    End Sub

    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value > 0 Then
                Dim pService As New ServiceMaster
                pService.TerminalId = Session.Item("LoginTerminal")
                pService.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
                ServiceMaster.ReturnServiceMasterByServiceId(pService)
                CType(e.Item.FindControl("textService"), TextBox).Text = pService.ServiceName

                'Dim pMtyCont As New ExtMtyContainers
                'pMtyCont.TerminalId = Session.Item("LoginTerminal")
                'pMtyCont.MtyContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                'ExtMtyContainers.ReturnMtyContainers(pMtyCont)
                'CType(e.Item.FindControl("textGateInDate"), TextBox).Text = pMtyCont.InDate
                If hdnMode.Value = "ADD" Then
                    If CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
                        Dim pImpInvoiceTax As New ImpInvoiceTax
                        pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                        pImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
                        For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByItemKeyId(pImpInvoiceTax)
                            If pTIT.TaxHeadId = "7" Then
                                CType(e.Item.FindControl("textServiceTax"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                            End If
                            If pTIT.TaxHeadId = "6" Then
                                CType(e.Item.FindControl("textEducTax"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                            End If
                            If pTIT.TaxHeadId = "5" Then
                                CType(e.Item.FindControl("textHEduTax"), TextBox).Text = Math.Round(pTIT.TaxAmt, 2)
                            End If
                        Next

                    End If
                End If
                If hdnMode.Value = "SEARCH" Then
                    Dim pCancelImpInvoiceTax As New CancelImpInvoiceTax
                    pCancelImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pCancelImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
                    For Each pTIT As CancelImpInvoiceTax In CancelImpInvoiceTax.ReturnCancelImpInvoiceTaxListByItemKeyId(pCancelImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
                        End If
                    Next
                End If
            End If
            Try
                dblAmount += Double.Parse(CType(e.Item.FindControl("textAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(e.Item.FindControl("textTaxAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblTotalAmount += Double.Parse(CType(e.Item.FindControl("textTotalAmount"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblServiceTax += Double.Parse(CType(e.Item.FindControl("textServiceTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblEducTax += Double.Parse(CType(e.Item.FindControl("textEducTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            Try
                dblHEduTax += Double.Parse(CType(e.Item.FindControl("textHEduTax"), TextBox).Text)
            Catch ex As Exception
            End Try
            If CType(e.Item.FindControl("textServiceTax"), TextBox).Text = "0" AndAlso
                            CType(e.Item.FindControl("textEducTax"), TextBox).Text = "0" AndAlso
                            CType(e.Item.FindControl("textHEduTax"), TextBox).Text = "0" Then
                CType(e.Item.FindControl("textTaxAmount"), TextBox).Text = "0"
            End If

        End If
    End Sub

    Sub LoadTreeViewData(ByVal pCancelImpInvoice As CancelImpInvoice)
        tvInvoices.Nodes.Clear()
        Try
            For Each obj As CancelImpInvoice In CancelImpInvoice.ReturnCancelImpInvoiceListByLineItemId(pCancelImpInvoice)
                Functions.treeViewNodeSetup(tvInvoices, "0", obj.ClInvoiceId, obj.ClInvoiceNo)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub tvInvoices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvInvoices.SelectedNodeChanged
        fillControlWithData(tvInvoices.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        ButtonControlSetup(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim pCancelImpInvoice As New CancelImpInvoice
        pCancelImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pCancelImpInvoice.ClInvoiceId = PCodeValue.Value
        CancelImpInvoice.ReturnCancelImpInvoiceByClInvoiceId(pCancelImpInvoice)
        prepareControlsSearchData(pCancelImpInvoice)
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If hdnClInvoiceId.Value <> "" AndAlso hdnClInvoiceId.Value <> Nothing Then
            Response.Redirect("Preview/CancelExportInvoicePrint.aspx?ClInvoiceId=" & hdnClInvoiceId.Value)
        End If
    End Sub
End Class


