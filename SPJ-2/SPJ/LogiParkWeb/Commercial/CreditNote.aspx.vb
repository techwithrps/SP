Imports System.Data
Imports System.Data.OleDb
Imports System.Net.Mail
Imports CommonSendingMailLibary
Imports LogiParkLib.LogiParkObjects

Partial Class Commercial_CreditNote
    Inherits System.Web.UI.Page
    Dim rows As Integer = 1
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
    Dim dblTaxperc As Double
    Dim strDocType As String
    Dim strBookingNo As String
    Dim lngBookingId As Long
    Dim glService As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            BtnSearchCredit.Visible = True
            BtnSearchCredit.Enabled = True
            textCreditRefNo.Enabled = True
            btnSave.Visible = False
            Dim StrCrNo As String = ""

            StrCrNo = Request.QueryString("CrNo")
            search(StrCrNo)
            ListControlDataBind()

        End If
    End Sub
    Sub ListControlDataBind()
        'Dim pExtTaxGroup As New ExtTaxGroup
        'pExtTaxGroup.TerminalId = Session.Item("LoginTerminal")
        'lstTaxGroup.DataSource = ExtTaxGroup.ReturnTaxGroupList(pExtTaxGroup)
        'lstTaxGroup.DataTextField = "TaxGroupCode"
        'lstTaxGroup.DataValueField = "TaxGroupId"
        'lstTaxGroup.DataBind()
        'lstTaxGroup.Items.Add(New ListItem("---Select---", 0))
        'lstTaxGroup.SelectedValue = 0
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

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Private Sub fillRepeatorCredit(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New ImpInvoiceItems
                p.ServiceId = 0
                arr.Add(p)
            Next
        End If
        Repeater1.DataSource = arr
        Repeater1.DataBind()
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New ImpInvoiceItems
                p.ServiceId = 0
                arr.Add(p)
            Next
        End If
        rcInvoiceDetails.DataSource = arr
        rcInvoiceDetails.DataBind()

        textRepAmount.Text = Math.Round(dblAmount, 2)
        textRepTaxAmount.Text = Math.Round(dblTaxAmount, 2)
        textRepTotalAmount.Text = Math.Round(dblTotalAmount, 2)
        textRepServiceTax.Text = Math.Round(dblServiceTax, 2)
        textRepEducTax.Text = Math.Round(dblEducTax, 2)
        textRepHEducTax.Text = Math.Round(dblHEduTax, 2)

        hdnMaxAmount.Value = (Math.Round(dblTotalAmount, 2) -
                              PreviousGenerateCRAmount()).ToString()
    End Sub

    Function PreviousGenerateCRAmount() As Double
        Dim conStr = ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(conStr)
        Dim command As New OleDbCommand("SELECT NVL(SUM(CN.CR_AMOUNT + CN.CR_TAX ),0) CR_AMOUNT_WITH_TAX FROM CR_NOTE CN WHERE CN.INVOICE_ID =" & hdnInvoiceNo.Value,
                                        con)
        con.Open()
        Dim ada As New OleDbDataAdapter(command)
        Dim dt As New DataTable
        ada.Fill(dt)
        con.Close()
        Return Math.Round(Convert.ToDouble(dt.Rows(0)("CR_AMOUNT_WITH_TAX").ToString()), 2)
    End Function

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnInvoiceNo.Value.Trim <> Nothing Then
            btnPrint.Visible = True
            'btnCancelInvoice.Visible = True
        Else
            btnPrint.Visible = False
            'btnCancelInvoice.Visible = False
        End If
        btnSave.Visible = pVisible
        btnCancel.Visible = Not pVisible

        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If
        'If Session.Item("Edit") <> "Y" Then

        'End If
        'If Session.Item("Search") <> "Y" Then
        '    btnSearch.Visible = False
        'End If
        'If Session.Item("Delete") <> "Y" Then
        '    btnCancelInvoice.Visible = False
        'End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddInvoice.Visible = True
        btnSearchInvoice.Visible = False
        textInvoiceRefNo.Enabled = True
        hdnMode.Value = "ADD"
        chkSelect.Enabled = True
        BtnSearchCredit.Visible = False
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        ListPartyBind()
        btnAddInvoice.Visible = False
        btnSearchInvoice.Visible = True
        ' textBookingNo.Enabled = True
        tvInvoices.Nodes.Clear()
        'textBlNo.Enabled = True
        textCreditRefNo.Enabled = True
        hdnMode.Value = "SEARCH"
        textNote1.Visible = True
        textNote1.Enabled = True
        'Functions.ControlFocus(textBookingNo)

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        tvInvoices.Nodes.Clear()
        btnAddInvoice.Visible = False
        btnSearchInvoice.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControl(ByVal pEnable As Boolean)
        'lstInvoiceTo.Enabled = pEnable
        '  lstPaymentMode.Enabled = pEnable
        textNote1.Enabled = pEnable
    End Sub

    Sub manageRepControl(ByVal pEnable As Boolean)
        textNote1.Enabled = pEnable
        For Each rep As RepeaterItem In rcInvoiceDetails.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            If CType(rep.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(rep.FindControl("textService"), DropDownList).SelectedValue > 0 Then
                CType(rep.FindControl("chkSelect"), CheckBox).Checked = pEnable
            Else
                CType(rep.FindControl("textContNo"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textSize"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textCargoType"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textService"), DropDownList).Enabled = pEnable
                CType(rep.FindControl("textFromdate"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textTodate"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textQuntity"), TextBox).Enabled = pEnable
                CType(rep.FindControl("textRate"), TextBox).Enabled = pEnable
            End If
        Next
    End Sub
    Sub LoadTreeViewData(ByVal pExtImpInvoice As ExtImpInvoice)
        textNote1.Visible = True
        textNote1.Enabled = True
        ' tvInvoices.Nodes.Clear()
        Try
            For Each obj As ImpInvoice In ExtImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                Functions.treeViewNodeSetup(tvInvoices, "0", obj.InvoiceNo, obj.InvoiceRefNo)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim pcount As Integer = 0
        For Each rc As RepeaterItem In Repeater1.Items

            If CType(rc.FindControl("ChkCredit"), CheckBox).Checked = True Then
                pcount = pcount + 1
                If Double.Parse(CType(rc.FindControl("textTotalAmount"), TextBox).Text) < 1 Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Credit Amount again")
                    rtnBool = False
                    Functions.ControlFocus(CType(rc.FindControl("textRate"), TextBox))
                    Return rtnBool
                    Exit Function
                End If

                If textNote1.Text = Nothing AndAlso textNote1.Text = "" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblNote.Text & "is blank.")
                    Functions.ControlFocus(textNote1)
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                '''' this chk for credit note

                Dim pImpInvoice As New ImpInvoice
                pImpInvoice.InvoiceNo = hdnInvoiceNo.Value
                pImpInvoice = ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
                If pImpInvoice.EinvoiceStatus = "" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Einvoice Not Done for Against Selected Invoice No ")
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
                Dim TOTAL As Double = 0.0
                Dim textTotalAmt As TextBox = CType(rc.FindControl("textTotalAmount"), TextBox)
                Dim service As DropDownList = CType(rc.FindControl("textService"), DropDownList)
                For Each rc1 As RepeaterItem In rcInvoiceDetails.Items
                    Dim textTotalAmt1 As TextBox = CType(rc1.FindControl("textTotalAmount"), TextBox)
                    Dim service1 As DropDownList = CType(rc1.FindControl("textService"), DropDownList)
                    If service.SelectedValue = service1.SelectedValue Then
                        TOTAL = TOTAL + Double.Parse(textTotalAmt1.Text)
                    End If
                Next

                'If TOTAL < Double.Parse(textTotalAmt.Text) Then
                '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Total amount not matching.")
                '    Functions.ControlFocus(textTotalAmt)
                '    rtnBool = False
                'End If
            End If
        Next
        If pcount = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select any one service.")
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
        If chkInvoiceChecked.Checked <> True Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Checked Invoice Check Box")
            Functions.ControlFocus(chkInvoiceChecked)
            Return
        End If
        Dim pExtImpInvoice As CrNote = returnObjectsData()
        Dim crAmountWithTax = pExtImpInvoice.CrAmt + pExtImpInvoice.CrTax
        'If Math.Round(crAmountWithTax, 2) > Convert.ToDouble(hdnMaxAmount.Value) Then
        '    pExtImpInvoice.Errormsg = "Credit note can be created of maximum amount(" & hdnMaxAmount.Value & ")"
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice.Errormsg)
        '    Return
        'End If

        CrNote.InsertCRDetails(pExtImpInvoice)

        If pExtImpInvoice.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtImpInvoice.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
        hdnCreditNo.Value = pExtImpInvoice.CrId
        textCreditRefNo.Text = pExtImpInvoice.CrRefNo
        Dim pCR As New CrNote
        pCR.CrId = pExtImpInvoice.CrId
        CrNote.ReturnCreaditNotebyid(pCR)
        textCreditDate.Text = pCR.CrDate
        Functions.ControlFocus(textNote1)
        tvInvoices.Enabled = True
        ButtonControlSetup(True)
        manageUserControls(True)
        btnPrint.Visible = True
        btnPrint.Enabled = True
        btnPreview.Visible = False

        sendmail()
    End Sub
    Sub sendmail()
        Dim pInvoice As New CancelImpInvoice
        'pInvoice.TerminalId = Session.Item("LoginTerminal")
        'pInvoice.ClInvoiceId = hdnClInvoiceId.Value
        'CancelImpInvoice.ReturnCancelImpInvoiceByClInvoiceId(pInvoice)
        Dim xMailSetup As String = ""
        Dim con As New OleDbConnection
        Dim strConnectionString As String = ""
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        'strConnectionString = "Provider=MSDAORA;Data Source=XE;Persist Security Info=True;Password=SPJ;User ID=SPJ"
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
        cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=465 AND TERMINAL_ID=1"
        adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
        Dim dsmailsetup As New DataSet
        adamailsetup.Fill(dsmailsetup)
        Dim confirmMail As New StringBuilder
        confirmMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>SR.</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Customer Name</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>CR No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Cr Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Invoice Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Amount</b>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Remarks</b>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>CR By</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>CR On</b>")
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
        procParam &= "," & hdnCreditNo.Value
        procName = "REPORT_PKG.SP_CR_NOTE_MAIL"
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
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CUSTOMER_NAME"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_DATE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_REF_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("INVOICE_DATE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_AMOUNT"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_NOTE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_BY"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(dsOSDRY.Tables(0).Rows(i)("CR_ON"))
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
        xMailSetup &= "<font color='#00008B'>Please find the below  Credit Note."
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
            '   pStr = sendMailToCcBccID(dsmailconfig.Tables(0).Rows(0)("FROM_ID"), dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS"), strCCID, strBccID, dsmailsetup.Tables(0).Rows(0)("SUBJECT"), xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), dsmailconfig.Tables(0).Rows(0)("PASSWORD"), dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            pStr = MailSender.SendMailToCcBccIDWithOrWithoutAttachment(dsmailconfig.Tables(0).Rows(0)("FROM_ID"), dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS"), strCCID, strBccID, dsmailsetup.Tables(0).Rows(0)("SUBJECT"), xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), dsmailconfig.Tables(0).Rows(0)("PASSWORD"), dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
            If pStr = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Save Successdully,Mail Sent")
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

    Sub ListPartyBind()
        Dim pExtCustomerMaster As New ExtCustomerMaster
        lstParty.DataSource = ExtCustomerMaster.ReturnCustomerMasterListConsignee(pExtCustomerMaster)
        lstParty.DataTextField = "CustomerName"
        lstParty.DataValueField = "CustomerId"
        lstParty.DataBind()
        lstParty.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstParty.SelectedValue = 0
    End Sub
    Function returnObjectsData() As CrNote
        Dim dblCrAmt As Double = 0.0
        Dim dblCrtax As Double = 0.0
        Dim pCr As New CrNote

        pCr.CRNoteList = New ArrayList
        For Each rc As RepeaterItem In Repeater1.Items


            If CType(rc.FindControl("ChkCredit"), CheckBox).Checked = True Then
                Dim pCreaditNote As New CreditItemDetails
                Try
                    pCreaditNote.CrId = hdnCreditNo.Value
                Catch ex As Exception
                End Try
                pCreaditNote.Invoiceno = hdnInvoiceNo.Value '
                pCreaditNote.TerminalId = Session.Item("LoginTerminal")
                Try
                    pCreaditNote.InvItemKeyId = CType(rc.FindControl("HdnItemKeyid"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.ServiceID = CType(rc.FindControl("textService"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.ServiceAmt = CType(rc.FindControl("textRate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.BillQnty = CType(rc.FindControl("textQuntity"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.CrAmt = Double.Parse(CType(rc.FindControl("textAmount"), TextBox).Text)
                Catch ex As Exception
                End Try

                Try
                    pCreaditNote.CrTax = Double.Parse(CType(rc.FindControl("textTaxAmount"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.IGST = Double.Parse(CType(rc.FindControl("textServiceTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.SGST = Double.Parse(CType(rc.FindControl("textEducTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.CGST = Double.Parse(CType(rc.FindControl("textHEduTax"), TextBox).Text)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.IGSTRate = Double.Parse(CType(rc.FindControl("HdnIgstPer"), HiddenField).Value)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.SGSTRate = Double.Parse(CType(rc.FindControl("Hdnsgstper"), HiddenField).Value)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.CGSTRate = Double.Parse(CType(rc.FindControl("hdncgstper"), HiddenField).Value)
                Catch ex As Exception
                End Try
                Try
                    pCreaditNote.ExRate = CType(rc.FindControl("TxtExRate"), TextBox).Text
                Catch ex As Exception

                End Try
                pCreaditNote.Currency = CType(rc.FindControl("HdnCurrency"), HiddenField).Value
                dblCrAmt = dblCrAmt + Double.Parse(CType(rc.FindControl("textAmount"), TextBox).Text)
                dblCrtax = dblCrtax + Double.Parse(CType(rc.FindControl("textTaxAmount"), TextBox).Text)
                pCr.CRNoteList.Add(pCreaditNote)
            End If

            'pII.ImpInvoiceList.Add(pExtImpInvoice)
        Next
        pCr.InvoiceID = hdnInvoiceNo.Value
        pCr.CompanyId = Session.Item("CompanyId")
        pCr.TerminalId = Session.Item("LoginTerminal")
        pCr.InvoiceAmt = textRepTotalAmount.Text
        pCr.CrBy = Session.Item("LoginUser")
        pCr.CrAmt = dblCrAmt
        pCr.CrTax = dblCrtax
        pCr.CrNotes = textNote1.Text
        pCr.ServiceType = hdnServiceType.Value

        Return pCr
    End Function

    'Protected Sub lstInvoiceTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInvoiceTo.SelectedIndexChanged
    '    Dim lngCustomer As Long = 0
    '    'If lstInvoiceTo.SelectedValue = "C" Then
    '    '    lngCustomer = hdnCHa.Value
    '    'ElseIf lstInvoiceTo.SelectedValue = "F" Then
    '    '    lngCustomer = HdnForwarder.Value
    '    'ElseIf lstInvoiceTo.SelectedValue = "L" Then
    '    '    lngCustomer = hdnLine.Value
    '    'End If

    '    Dim p As New ExtCustomerMaster
    '    p.TerminalId = Session.Item("LoginTerminal")
    '    p.CustomerId = lngCustomer
    '    ExtCustomerMaster.ReturnCustomerMasterDetailsById(p)

    '    'If p.PaymentTerms = "C" Then
    '    '    lstPaymentMode.SelectedValue = "C"
    '    '    lstPaymentMode.Enabled = False
    '    'ElseIf p.PaymentTerms = "R" Then
    '    '    lstPaymentMode.SelectedValue = "R"
    '    '    lstPaymentMode.Enabled = True
    '    'End If
    'End Sub

    Protected Sub btnAddBooking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddInvoice.Click
        ''''''Changes Done By Amit on 24/06/2023 to stop multiple CR
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pImpInvoice.InvoiceRefNo = textInvoiceRefNo.Text.Trim
        ImpInvoice.ReturnImpInvoiceByInvoiceRefNo(pImpInvoice)

        Dim pCrNote As New CrNote
        pCrNote.InvoiceID = pImpInvoice.InvoiceNo
        CrNote.ReturnCreaditNotebyInvoiceId(pCrNote)
        If pCrNote.CrRefNo <> "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Credit Note Generated Already-" & pCrNote.CrRefNo & "Total Credit Note Amount-" & pCrNote.CrAmt)
        End If

        AddBookingNo()
        btnPreview.Visible = True
    End Sub
    Sub AddBookingNo()
        'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textInvoiceRefNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Invoice No")
            Functions.ControlFocus(textInvoiceRefNo)
            Return
        End If
        ListPartyBind()
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pImpInvoice.InvoiceRefNo = textInvoiceRefNo.Text
        ImpInvoice.ReturnImpInvoiceByInvoiceRefNoAndCompany(pImpInvoice)
        If pImpInvoice.InvoiceNo = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Invoice No")
            Return
        End If
        hdnInvoiceNo.Value = pImpInvoice.InvoiceNo
        textInvoiceDate.Text = pImpInvoice.InvoiceDate
        hdnBookingId.Value = pImpInvoice.LineItemId
        hdnDocType.Value = pImpInvoice.DocType
        hdnServiceType.Value = pImpInvoice.ServiceType
        lstServiceType.SelectedValue = pImpInvoice.ServiceType
        Try
            lstParty.SelectedValue = pImpInvoice.BillTo
            pImpInvoice.CustomerType = lstInvoiceTo.SelectedValue
        Catch ex As Exception

        End Try
        Dim pImpInvoiceItems As New ImpInvoiceItems
        pImpInvoiceItems.TerminalId = Session.Item("LoginTerminal")
        pImpInvoiceItems.LineItemId = pImpInvoice.LineItemId
        pImpInvoiceItems.InvoiceNo = pImpInvoice.InvoiceNo

        fillRepeator(ImpInvoiceItems.ReturnImpInvoiceItemsListByInvoiceNo(pImpInvoiceItems))
        Dim pcr As New CreditItemDetails
        pcr.CrId = pImpInvoice.InvoiceNo
        fillRepeatorCredit(CreditItemDetails.ReturnCreaditItemListbyid(pcr))
        manageControl(True)
        btnAddInvoice.Visible = False
        Functions.ControlFocus(textCreditDate)
        If Session.Item("LoginUser") = "Ashish Devrani" Or Session.Item("LoginUser") = "Deepak Kandpal" Or Session.Item("LoginUser") = "Aaditya Tayal" Or Session.Item("LoginUser") = "ADMIN" Or Session.Item("LoginUser") = "Harish Kumar" Or Session.Item("LoginUser") = "Suman" Or Session.Item("LoginUser") = "Vansh" Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
        btnAdd.Visible = False
        btnSearch.Visible = False
        btnCancel.Visible = True
        btnPreview.Visible = True
    End Sub

    'Protected Sub btnSearchBooking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchInvoice.Click
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    'If textBookingNo.Text.Trim = Nothing Then
    '    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Booking No")
    '    '    Functions.ControlFocus(textBookingNo)
    '    '    Return
    '    'End If
    '    Dim pExtExportBooking As New ExtExportBooking
    '    pExtExportBooking.TerminalId = Session.Item("LoginTerminal")
    '    pExtExportBooking.BookingNo = textBookingNo.Text.Trim
    '    ExtExportBooking.ReturnExportBooking(pExtExportBooking)

    '    Dim pExtImpInvoice As New ExtImpInvoice
    '    pExtImpInvoice.TerminalId = pExtExportBooking.TerminalId
    '    pExtImpInvoice.LineItemId = pExtExportBooking.BookingId

    '    LoadTreeViewData(pExtImpInvoice)
    '    If tvInvoices.Nodes.Count <= 0 Then
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invoice Not Generated for Booking No")
    '        Functions.ControlFocus(textBookingNo)
    '        Return
    '    End If
    '    hdnInvoiceNo.Value = pExtImpInvoice.InvoiceNo
    '    If tvInvoices.Nodes.Count = 1 Then
    '        fillControlWithData(tvInvoices.Nodes(0))
    '        tvInvoices.Enabled = False
    '    Else
    '        tvInvoices.Enabled = True

    '    End If

    '    SaveViewState()
    '    hdnBookingId.Value = pExtExportBooking.BookingId

    '    Dim pInv As New ExtImpInvoice
    '    pInv.TerminalId = Session.Item("LoginTerminal")

    '    pInv.InvoiceNo = hdnInvoiceNo.Value
    '    ExtImpInvoice.ReturnImpInvoiceByInvoiceNo(pInv)


    '    textExporter.Text = pExtExportBooking.Exporter
    '    manageControl(True)
    '    btnSearchInvoice.Visible = False
    '    textBookingNo.Enabled = False

    '    manageUserControls(True)
    '    ButtonControlSetup(True)
    '    Functions.ControlFocus(btnAdd)
    'End Sub

    Protected Sub tvInvoices_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvInvoices.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        fillControlWithData(tvInvoices.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim p As New ExtImpInvoice
        p.InvoiceNo = PCodeValue.Value
        p.TerminalId = Session.Item("LoginTerminal")

        ExtImpInvoice.ReturnInvoiceWithItemDetails(p)

        hdnInvoiceNo.Value = p.InvoiceNo
        hdnCancelStatus.Value = p.CancleFlage
        hdnBookingId.Value = p.LineItemId
        hdnPrintStatus.Value = p.PrintStatus
        hdnReceiptNo.Value = p.ReceiptNo
        textInvoiceRefNo.Text = p.InvoiceRefNo
        textInvoiceDate.Text = p.InvoiceDate
        textNote1.Text = p.InvoiceNote
        'Try
        '    lstInvoiceTo.SelectedValue = p.CustomerType
        'Catch ex As Exception

        'End Try


        ' lstPaymentMode.SelectedValue = p.PaymentMode
        fillRepeator(p.ImpInvoiceItemsList)

    End Sub
    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then

                If hdnMode.Value = "ADD" And CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
                    Dim pImpInvoiceTax As New ImpInvoiceTax
                    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                    pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("textService"), DropDownList).SelectedValue
                    pImpInvoiceTax.ImpContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                    pImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                    Dim TotalTax As Double = 0.0
                    Dim IGST As Double = 0.0
                    Dim CGST As Double = 0.0
                    Dim SGST As Double = 0.0
                    Dim ExRate As Double = Double.Parse(CType(e.Item.FindControl("TxtExRate"), TextBox).Text)
                    For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByItemKeyRound(pImpInvoiceTax)

                        'For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByInvoiceNo(pImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
                            CType(e.Item.FindControl("HdnIgstPer"), HiddenField).Value = pTIT.TaxPerc
                            TotalTax += pTIT.TaxAmt
                            IGST = pTIT.TaxAmt
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
                            CType(e.Item.FindControl("Hdnsgstper"), HiddenField).Value = pTIT.TaxPerc
                            TotalTax += pTIT.TaxAmt
                            SGST = pTIT.TaxAmt
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
                            CType(e.Item.FindControl("hdncgstper"), HiddenField).Value = pTIT.TaxPerc
                            TotalTax += pTIT.TaxAmt
                            CGST = pTIT.TaxAmt
                        End If
                    Next
                    Dim Rate As Double = Double.Parse(CType(e.Item.FindControl("textRate"), TextBox).Text)
                    Dim Qnty As Double = Double.Parse(CType(e.Item.FindControl("textQuntity"), TextBox).Text)
                    Dim total As Double = Math.Round((Double.Parse(CType(e.Item.FindControl("textRate"), TextBox).Text) * Double.Parse(CType(e.Item.FindControl("textQuntity"), TextBox).Text) * ExRate + TotalTax), 2)
                    CType(e.Item.FindControl("textTaxAmount"), TextBox).Text = Math.Round(TotalTax, 2)
                    CType(e.Item.FindControl("textAmount"), TextBox).Text = Math.Round(CType(e.Item.FindControl("textRate"), TextBox).Text * Double.Parse(CType(e.Item.FindControl("textQuntity"), TextBox).Text) * ExRate, 2)
                    CType(e.Item.FindControl("textTotalAmount"), TextBox).Text = total

                End If
                'If hdnMode.Value = "SEARCH" Then
                '    Dim pImpInvoiceTax As New CreditItemDetails
                '    pImpInvoiceTax.CrId = hdnCreditNo.Value
                '    For Each pTIT As CreditItemDetails In CreditItemDetails.ReturnCreaditItemListbyid(pImpInvoiceTax)

                '        CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.IGST
                '        CType(e.Item.FindControl("HdnIgstPer"), HiddenField).Value = pTIT.IGSTRate
                '        CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.SGST
                '        CType(e.Item.FindControl("Hdnsgstper"), HiddenField).Value = pTIT.SGSTRate
                '        CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.CGST
                '        CType(e.Item.FindControl("hdncgstper"), HiddenField).Value = pTIT.CGSTRate
                '    Next
                'End If

            End If

        End If
    End Sub
    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("textService"), DropDownList).SelectedValue <> Nothing AndAlso CType(e.Item.FindControl("textService"), DropDownList).SelectedValue > 0 Then

                If hdnMode.Value = "ADD" And CType(e.Item.FindControl("textRate"), TextBox).Text <> 0 Then
                    Dim pImpInvoiceTax As New ImpInvoiceTax
                    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                    pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
                    pImpInvoiceTax.ImpContId = CType(e.Item.FindControl("hdnImpContId"), HiddenField).Value
                    For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByRound(pImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textServiceTax"), TextBox).Text = pTIT.TaxAmt
                            'CType(e.Item.FindControl("HdnIgstPer"), HiddenField).Value = pTIT.TaxPerc
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textEducTax"), TextBox).Text = pTIT.TaxAmt
                            ' CType(e.Item.FindControl("Hdnsgstper"), HiddenField).Value = pTIT.TaxPerc
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textHEduTax"), TextBox).Text = pTIT.TaxAmt
                            'CType(e.Item.FindControl("hdncgstper"), HiddenField).Value = pTIT.TaxPerc
                        End If
                    Next
                End If
                If hdnMode.Value = "SEARCH" Then
                    Dim pImpInvoiceTax As New ImpInvoiceTax
                    pImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pImpInvoiceTax.InvoiceNo = CType(e.Item.FindControl("hdnInvoiceNo"), HiddenField).Value
                    pImpInvoiceTax.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
                    For Each pTIT As ImpInvoiceTax In ImpInvoiceTax.ReturnImpInvoiceTaxListByRound(pImpInvoiceTax)
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
                dblWeaverAmt += Double.Parse(CType(e.Item.FindControl("textWeiverReqAmt"), TextBox).Text)
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

    Sub checkAmount(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim txtRate As TextBox = sender
            Dim txtQnty As Double = 0
            Dim igst As Double = 0.0
            Dim cgst As Double = 0.0
            Dim sgst As Double = 0.0
            Dim txtRateI As Double = 0
            Dim txtTaxable As Double = 0
            Dim txtTaxamount As Double = 0
            Dim index1 As Integer = Integer.Parse(txtRate.ClientID.Substring("ctl00_ContentPlaceHolder1_Repeater1_ctl".Length, txtRate.ClientID.IndexOf("_textRate") - "ctl00_ContentPlaceHolder1_Repeater1_ctl".Length))
            Dim rep As RepeaterItem
            rep = Repeater1.Items(index1 - 1)
            If txtRate.Text <> "" Then
                txtRateI = Double.Parse(txtRate.Text)
                igst = Double.Parse(CType(rep.FindControl("HdnIgstPer"), HiddenField).Value)
                cgst = Double.Parse(CType(rep.FindControl("Hdnsgstper"), HiddenField).Value)
                sgst = Double.Parse(CType(rep.FindControl("hdncgstper"), HiddenField).Value)
                txtQnty = Double.Parse(CType(rep.FindControl("textQuntity"), TextBox).Text)

                Dim pServiceMaster As New ServiceMaster
                pServiceMaster.TerminalId = Session.Item("LoginTerminal")
                pServiceMaster.ServiceId = CType(rep.FindControl("textService"), DropDownList).SelectedValue
                ServiceMaster.ReturnServiceMasterByServiceId(pServiceMaster)
                CType(rep.FindControl("hdnTaxPerc"), HiddenField).Value = pServiceMaster.TaxOnPercentage

                txtTaxable = txtRateI * txtQnty ' / 100 + 100
                Dim pTaxGroup As New TaxGroupHeads
                pTaxGroup.TerminalId = Session.Item("LoginTerminal")
                ' pTaxGroup.TaxGroupId = lstTaxGroup.SelectedValue
                pTaxGroup.TaxGroupId = 16
                txtTaxamount = txtTaxable / 100
                For Each p As TaxGroupHeads In TaxGroupHeads.ReturnTaxGroupHeadsListByTaxGroupId(pTaxGroup)
                    If p.TaxHeadId = "5" Then
                        CType(rep.FindControl("textServiceTax"), TextBox).Text = txtTaxamount * igst
                    ElseIf p.TaxHeadId = "6" Then
                        CType(rep.FindControl("textEducTax"), TextBox).Text = txtTaxamount * cgst
                    ElseIf p.TaxHeadId = "7" Then
                        CType(rep.FindControl("textHEduTax"), TextBox).Text = txtTaxamount * sgst
                    End If

                Next
                dblTaxperc = igst + cgst + igst
                Try
                    CType(rep.FindControl("hdnTaxPerc"), HiddenField).Value = dblTaxperc


                Catch ex As Exception

                End Try

                Try
                    CType(rep.FindControl("textTaxAmount"), TextBox).Text = Double.Parse(CType(rep.FindControl("textServiceTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)

                Catch ex As Exception

                End Try
                CType(rep.FindControl("textAmount"), TextBox).Text = (txtRateI * txtQnty)


                CType(rep.FindControl("textTotalAmount"), TextBox).Text = (txtRateI * txtQnty) + Double.Parse(CType(rep.FindControl("textServiceTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textEducTax"), TextBox).Text) + Double.Parse(CType(rep.FindControl("textHEduTax"), TextBox).Text)



                ' CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True

            End If
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Try
    '        If hdnBookingId.Value <> "" AndAlso hdnInvoiceNo.Value > 0 Then
    '            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Print/InvoicePrint.aspx?BookingId=" & hdnBookingId.Value & "&InvoiceNo=" & hdnInvoiceNo.Value & "" & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Sub checkContNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim chk As CheckBox = sender
            Dim index1 As Integer = Integer.Parse(chk.ClientID.Substring("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length, chk.ClientID.IndexOf("_chkSelect") - "ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl".Length))
            Dim rep As RepeaterItem
            rep = chk.NamingContainer
            Dim hdnItemKeyId As Integer = Double.Parse(CType(rep.FindControl("hdnItemKeyId"), HiddenField).Value)
            ' Dim hdncontid As Integer = Double.Parse(CType(rep.FindControl("hdnImpContId"), HiddenField).Value)
            If chk.Checked = True Then
                Dim p As New ImpInvoiceItems
                p.TerminalId = Session.Item("LoginTerminal")
                p.ItemKeyId = hdnItemKeyId
                p.InvoiceNo = hdnInvoiceNo.Value
                p.ImpContId = Double.Parse(CType(rep.FindControl("hdnImpContId"), HiddenField).Value)
                fillRepeatorCredit(ImpInvoiceItems.ReturnImpInvoiceItemsListCreditItemKeyId(p))

            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub prepareDataRepControlsList()
        Dim pService As New ServiceMaster
        pService.TerminalId = Session.Item("LoginTerminal")
        glService = ServiceMaster.ReturnServiceMasterList(pService)
    End Sub
    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", 0))
            For Each ic As ServiceMaster In glService
                lst.Items.Add(New ListItem(ic.ServiceName, ic.ServiceId))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim pCrNote As New CrNote
        pCrNote.CrRefNo = hdnCreditNo.Value
        CrNote.ReturnCreaditNotebyCrRefNo(pCrNote)
        If pCrNote.CrId <> 0 Then
            If pCrNote.ServiceType = "F" Then
                Response.Redirect("Preview/CrPrintNewRebate.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
            End If
        ElseIf Session.Item("CompanyId") = 1 Then
            Response.Redirect("Preview/SJCrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
        Else
            Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
        End If
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim crItemDetails As New DataTable
        Dim pCrNote = DataForPreview(crItemDetails)
        Me.Session.Add("CrNote", pCrNote)
        Me.Session.Add("CNItemDetail", crItemDetails)
        If String.IsNullOrEmpty(hdnServiceType.Value) AndAlso hdnServiceType.Value.Equals("F") Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/CrPrintNewRebate.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value & "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

            ' Response.Redirect("Preview/CrPrintNewRebate.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
        ElseIf Session.Item("CompanyId") = 1 Then
            ' Response.Redirect("Preview/SJCrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/SJCrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value & "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

        ElseIf Session.Item("CompanyId") = 2 AndAlso hdnServiceType.Value.Equals("R") Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/CrPrintNewRebate.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value & "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
        ElseIf Session.Item("CompanyId") = 2 AndAlso hdnServiceType.Value.Equals("B") Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/CrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value & "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

            ' Response.Redirect("Preview/CrPrintNewRebate.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('Preview/CrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value & "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

            ' Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & hdnCreditNo.Value & "&DocType=" & hdnDocType.Value)
        End If
    End Sub

    Function DataForPreview(ByRef crItemDetails As DataTable) As CrNote
        Dim dblCrAmt As Double = 0.0
        Dim dblCrTax As Double = 0.0
        Dim pCr As New CrNote
        crItemDetails.Columns.Add("SERVICE")
        crItemDetails.Columns.Add("SERVICE_CODE")
        crItemDetails.Columns.Add("QNTY")
        crItemDetails.Columns.Add("BILL_RATE")
        crItemDetails.Columns.Add("AMOUNT")
        crItemDetails.Columns.Add("C_RATE")
        crItemDetails.Columns.Add("HECESS")
        crItemDetails.Columns.Add("H_RATE")
        crItemDetails.Columns.Add("ECESS")
        crItemDetails.Columns.Add("S_RATE")
        crItemDetails.Columns.Add("SERVICE_TAX")
        crItemDetails.Columns.Add("TAX_AMOUNT")
        crItemDetails.Columns.Add("TOTAL_AMOUNT")
        crItemDetails.Columns.Add("EX_RATE")
        crItemDetails.Columns.Add("CURRENCY")

        Dim serviceList = glService.Cast(Of ServiceMaster).ToList()

        For Each rc As RepeaterItem In Repeater1.Items
            If CType(rc.FindControl("ChkCredit"), CheckBox).Checked Then

                Dim row = crItemDetails.NewRow()

                row("SERVICE") = CType(rc.FindControl("textService"), DropDownList).SelectedItem.Text
                Dim lngServiceId As Long = CType(CType(rc.FindControl("textService"), DropDownList).SelectedValue, Long)
                row("SERVICE_CODE") = serviceList.First(Function(item) item.ServiceId.Equals(lngServiceId)).ServiceCode
                row("QNTY") = CType(rc.FindControl("textQuntity"), TextBox).Text.Trim()
                row("BILL_RATE") = CType(rc.FindControl("textRate"), TextBox).Text.Trim()
                row("AMOUNT") = CType(rc.FindControl("textAmount"), TextBox).Text.Trim()
                row("C_RATE") = CType(rc.FindControl("hdncgstper"), HiddenField).Value
                row("HECESS") = CType(rc.FindControl("textHEduTax"), TextBox).Text.Trim()
                row("H_RATE") = CType(rc.FindControl("Hdnsgstper"), HiddenField).Value
                row("ECESS") = CType(rc.FindControl("textEducTax"), TextBox).Text.Trim()
                row("S_RATE") = CType(rc.FindControl("HdnIgstPer"), HiddenField).Value
                row("SERVICE_TAX") = CType(rc.FindControl("textServiceTax"), TextBox).Text.Trim()
                row("TAX_AMOUNT") = CType(rc.FindControl("textTaxAmount"), TextBox).Text.Trim()
                row("TOTAL_AMOUNT") = Double.Parse(CType(rc.FindControl("textAmount"), TextBox).Text.Trim()) +
                    Double.Parse(CType(rc.FindControl("textTaxAmount"), TextBox).Text.Trim())
                row("EX_RATE") = CType(rc.FindControl("TxtExRate"), TextBox).Text.Trim()
                row("CURRENCY") = CType(rc.FindControl("HdnCurrency"), HiddenField).Value

                crItemDetails.Rows.Add(row)
                dblCrAmt = dblCrAmt + Double.Parse(CType(rc.FindControl("textAmount"), TextBox).Text.Trim())
                dblCrTax = dblCrTax + Double.Parse(CType(rc.FindControl("textTaxAmount"), TextBox).Text.Trim())
            End If
        Next
        pCr.InvoiceID = CType(hdnInvoiceNo.Value, Long)
        pCr.CompanyId = CType(Session.Item("CompanyId"), Long)
        pCr.TerminalId = CType(Session.Item("LoginTerminal"), Long)
        pCr.InvoiceAmt = CType(textRepTotalAmount.Text, Double)
        pCr.CrBy = CType(Session.Item("LoginUser"), String)
        pCr.CrAmt = dblCrAmt
        pCr.CrTax = dblCrTax
        pCr.CrNotes = textNote1.Text
        pCr.ServiceType = hdnServiceType.Value
        Return pCr
    End Function

    Protected Sub BtnSearchCredit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSearchCredit.Click

    End Sub
    Sub search(ByVal CrNo As String)
        Dim pCrNote As New CrNote
        pCrNote.CrRefNo = CrNo
        CrNote.ReturnCreaditNotebyCrRefNo(pCrNote)

        If pCrNote.CrId <> 0 Then
            Response.Redirect("Preview/CrPrintNew.aspx?InvoiceNo=" & pCrNote.CrId & "&DocType=" & hdnDocType.Value)
        End If
    End Sub
End Class
