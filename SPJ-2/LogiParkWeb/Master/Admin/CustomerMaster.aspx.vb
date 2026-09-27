Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb

Partial Class Master_Admin_CustomerMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            ListControlLocationBind()
            LoadTreeViewData()
            tvCustomer.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            textSearchCustomer.Enabled = True
            Functions.ControlFocus(textSearchCustomer)
        End If
    End Sub

    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("MenuId") = row(0).ToString
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnCustomerId.Value.Trim <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ListControlDataBind()
        Dim pCustomerType As New CustomerType
        pCustomerType.TerminalId = Session.Item("LoginTerminal")
        lstCustomerType.DataSource = CustomerType.ReturnCustomerTypeList(pCustomerType)
        lstCustomerType.DataTextField = "CustomerTypeName"
        lstCustomerType.DataValueField = "CustomerTypeCode"
        lstCustomerType.DataBind()
        lstCustomerType.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstCustomerType.SelectedValue = 0

        Dim pCountry As New CountryMaster
        lstCountry.DataSource = CountryMaster.ReturnCountryMasterList()
        lstCountry.DataTextField = "CountryName"
        lstCountry.DataValueField = "CountryId"
        lstCountry.DataBind()
        lstCountry.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstCountry.SelectedValue = 0

        Dim pBankmaster As New BankMaster
        lstBankNameInr.DataSource = BankMaster.ReturnBankMasterList(pBankmaster)
        lstBankNameInr.DataTextField = "BankName"
        lstBankNameInr.DataValueField = "BankId"
        lstBankNameInr.DataBind()
        lstBankNameInr.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstBankNameInr.SelectedValue = 0

        Dim pBankmasterUSD As New BankMaster
        lstBankNameUSD.DataSource = BankMaster.ReturnBankMasterList(pBankmasterUSD)
        lstBankNameUSD.DataTextField = "BankName"
        lstBankNameUSD.DataValueField = "BankId"
        lstBankNameUSD.DataBind()
        lstBankNameUSD.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstBankNameUSD.SelectedValue = 0

        Dim pStateCodeMaster As New StateCodeMaster
        lstState.DataSource = StateCodeMaster.ReturnStateList(pStateCodeMaster)
        lstState.DataTextField = "StateName"
        lstState.DataValueField = "StateCode"
        lstState.DataBind()
        lstState.Items.Add(New ListItem("----Select----", "0"))

        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        lstCustomerGroupName.DataSource = CustomerMaster.ReturnCustomerMasterGroupList(pCustomerMaster)
        lstCustomerGroupName.DataTextField = "CustomerName"
        lstCustomerGroupName.DataValueField = "CustomerId"
        lstCustomerGroupName.DataBind()
        lstCustomerGroupName.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstCustomerGroupName.SelectedValue = 0

    End Sub

    Sub ListControlLocationBind()
        Dim strConnectionString, cmdLocation As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmdLocation = "SELECT LOCATION_ID,LOCATION_NAME FROM LOCATION_MASTER WHERE TERMINAL_ID=" & Session.Item("LoginTerminal") & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmdLocation, con)
            Dim ds As New DataSet("z")
            ada.Fill(ds)
            lstLocation.DataSource = ds.Tables(0)
            lstLocation.DataTextField = "LOCATION_NAME"
            lstLocation.DataValueField = "LOCATION_ID"
            lstLocation.DataBind()
            lstLocation.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadTreeViewData()
        Dim pExtCustomerMaster As New ExtCustomerMaster
        pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ExtCustomerMaster In ExtCustomerMaster.ReturnCustomerMasterListAll(pExtCustomerMaster)
                Functions.treeViewNodeSetup(tvCustomer, "0", obj.CustomerId, obj.CustomerName)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Function lederCreation(ByVal x As String) As String
        Dim pPanNo As String = ""
        Dim pTanNo As String = ""

        x = "<ENVELOPE>"
        x = x & "<HEADER>"
        x = x & "<VERSION>1</VERSION>"
        x = x & "<TALLYREQUEST>Import </TALLYREQUEST>"
        x = x & "<TYPE>Data</TYPE>"
        x = x & "<ID>All Masters</ID>"
        x = x & "</HEADER>"
        x = x & "<BODY>"
        x = x & "<DESC>"
        x = x & "<STATICVARIABLES>"
        x = x & "<SVCURRENTCOMPANY>ELOGISOL</SVCURRENTCOMPANY>"
        x = x & "</STATICVARIABLES>"
        x = x & "</DESC>"
        x = x & "<DATA>"
        x = x & "<TALLYMESSAGE xmlns:UDF='TallyUDF'>"
        x = x & "<LEDGER ACTION='Create'>"
        x = x & "<NAME.LIST>"
        x = x & "<NAME>" + textCustomerName.Text + "</NAME>"
        x = x & "</NAME.LIST>"
        x = x & "<PARENT>Sundry Debtors</PARENT>"
        x = x & "<OPENINGBALANCE>13500</OPENINGBALANCE>"
        x = x & "<ADDRESS.LIST>"
        x = x & "<ADDRESS>" + textAddress.Text + "</ADDRESS>"
        x = x & "</ADDRESS.LIST>"
        x = x & "<STATENAME>Delhi</STATENAME>"
        x = x & "<PINCODE>110019</PINCODE>"
        x = x & "<PANNO>" + textPanNo.Text + "</PANNO>"
        x = x & "<TAXNO>" + textTanNo.Text + "</TAXNO>"
        x = x & "<LEDGERPHONE>" + textContactNo.Text + "</LEDGERPHONE>"
        x = x & "<LEDGERFAX>" + textContactNo.Text + "</LEDGERFAX>"
        x = x & "<EMAIL>" + textEmailOperational.Text + "</EMAIL>"
        x = x & "<ADDITIONALNAME>"
        x = x & "</ADDITIONALNAME>"
        x = x & "</LEDGER>"
        x = x & "</TALLYMESSAGE>"
        x = x & "</DATA>"
        x = x & "</BODY>"
        x = x & "</ENVELOPE>"
        Return x
    End Function
    Protected Overrides Function SaveViewState() As Object
        If Not tvCustomer.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvCustomer.SelectedNode.ValuePath
            tvCustomer.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvCustomer.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvCustomer.Nodes.Count > 0 Then
            tvCustomer.Nodes(0).Selected = True
            prepareControls(tvCustomer.Nodes(0))
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        If tabCustomerMaster.ActiveTabIndex = 0 Then
            Functions.clearControls(Me.dvControl.Controls)
            ButtonControlSetup(False)
            manageUserControls(False)
            tvCustomer.Enabled = False
            manageControls(False)
            textCreditLimit.Text = 0
            textCreditPeriod.Text = 0
            textSearchCustomer.Enabled = False
            btnSearchCustomer.Enabled = False
            Functions.ControlFocus(textCustomerName)
            lstCountry.SelectedValue = 19
        Else
            If textCustomer.Text = "" Then
                lstLocation.Enabled = False
                textLocAddress.Enabled = False
                ButtonControlSetup(True)
            Else
                lstLocation.SelectedValue = 0
                hdnLocationKeyId.Value = ""
                textLocAddress.Text = ""
                lstLocation.Enabled = True
                textLocAddress.Enabled = True
                ButtonControlSetup(False)
                Functions.ControlFocus(lstLocation)
            End If
        End If
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textOpeningAmount.Enabled = pEnable
        textCreditLimit.Enabled = pEnable
        textCreditPeriod.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvCustomer.Enabled = False
        If lstPaymentTerms.SelectedValue = "P" Then
            manageControls(True)
        Else
            manageControls(False)
        End If
        textSearchCustomer.Enabled = False
        btnSearchCustomer.Enabled = False
        Functions.ControlFocus(textCustomerName)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvCustomer.SelectedNode Is Nothing Then
            prepareControls(tvCustomer.SelectedNode)
        End If
        manageUserControls(True)
        tvCustomer.Enabled = True
        textSearchCustomer.Enabled = True
        btnSearchCustomer.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvCustomer_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvCustomer.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvCustomer.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        textSearchCustomer.Enabled = True
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textCustomerName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomerName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomerName)
            Return rtnBool
            Exit Function
        End If
        If lstCustomerType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Customer Type.")
            rtnBool = False
            Functions.ControlFocus(lstCustomerType)
            Return rtnBool
            Exit Function
        End If
        If lstTDS.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select TDS Type.")
            rtnBool = False
            Functions.ControlFocus(lstTDS)
            Return rtnBool
            Exit Function
        End If
        If textContactPerson.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContactPerson.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContactPerson)
            Return rtnBool
            Exit Function
        End If
        If textCustomerCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomerCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomerCode)
            Return rtnBool
            Exit Function
        End If
        If textCustomerCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCustomerCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCustomerCode)
            Return rtnBool
            Exit Function
        End If
        'If textEmailCommercial.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEmailCommercial.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textEmailCommercial)
        '    Return rtnBool
        '    Exit Function
        'End If
        'If textEmailOperational.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEmailOperational.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textEmailOperational)
        '    Return rtnBool
        '    Exit Function
        'End If
        If lstPaymentTerms.SelectedValue = "R" Then
            If textCreditLimit.Text.Trim = Nothing AndAlso Double.Parse(textCreditLimit.Text) <= 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCreditLimit.Text & " Should not Blank for Credit Customer.")
                rtnBool = False
                Functions.ControlFocus(textCreditLimit)
                Return rtnBool
                Exit Function
            End If
            If textCreditPeriod.Text.Trim = Nothing AndAlso Double.Parse(textCreditPeriod.Text) <= 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCreditPeriod.Text & " Should not Blank for Credit Customer.")
                rtnBool = False
                Functions.ControlFocus(textCreditPeriod)
                Return rtnBool
                Exit Function
            End If
        End If
        'If textServiceTaxNo.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblServiceTaxNo.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textServiceTaxNo)
        '    Exit Function
        'End If
        'If textTanNo.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTanNo.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textTanNo)
        '    Exit Function
        'End If
        'If textPanNo.Text.Trim = Nothing Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPanNo.Text & " is Blank.")
        '    rtnBool = False
        '    Functions.ControlFocus(textPanNo)
        '    Exit Function
        'End If
        If textAddress.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblRegisteredAddress.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textAddress)
            Return rtnBool
            Exit Function
        End If
        If textCity.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCity.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCity)
            Return rtnBool
            Exit Function
        End If
        If textPin.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPin.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPin)
            Return rtnBool
            Exit Function
        End If

        ' Make country selection field is not mandatory because it is used in Rebate invoice
        ' Done on 14 july 2021 by hariom pandey as suggested by Rohit
        If lstCountry.SelectedValue = 19 Then
            If lstCountry.SelectedValue = "0" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Country Name.")
                rtnBool = False
                Functions.ControlFocus(lstCountry)
                Return rtnBool
                Exit Function
            End If
        End If
        Return rtnBool
    End Function
    Sub ledger()
        Dim request As WebRequest = WebRequest.Create("http://localhost:9000")
        Dim xmlRequest As String = ""
        xmlRequest = lederCreation(xmlRequest)
        DirectCast(request, HttpWebRequest).UserAgent = ".NET Framework Example Client"
        request.Method = "POST"
        Dim POSTDATA As String = xmlRequest
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
        Dim TallyResponseDataSet As New DataSet()
        TallyResponseDataSet.ReadXml(New StringReader(responseFromTallyServer))
        reader.Close()
        dataStream.Close()
        response.Close()
        byteArray = Nothing
        response = Nothing
        responseFromTallyServer = Nothing
        Respo = Nothing
        dataStream = Nothing
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If tabCustomerMaster.ActiveTabIndex = 0 Then
            If ValidationCheck() = False Then
                Return
            End If
            Dim pCustomerMaster As CustomerMaster = ReturnObject()

            Try
                If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Shanu Thakur" AndAlso Session.Item("LoginUser") <> "ADMIN" Then
                    If hdnCustomerId.Value > 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Customer already created,so edit not allow. ")
                        Return
                        btnSave.Visible = False
                    End If
                End If
            Catch ex As Exception
            End Try
            If hdnCustomerId.Value <> Nothing Then
                CustomerMaster.Update(pCustomerMaster)
            Else
                CustomerMaster.Insert(pCustomerMaster)
            End If
            If pCustomerMaster.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCustomerMaster.Errormsg)
                Return
            End If
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
            Functions.addOrModifyLeaf(tvCustomer, pCustomerMaster.CustomerName, pCustomerMaster.CustomerId, hdnCustomerId.Value)
            hdnCustomerId.Value = pCustomerMaster.CustomerId
            textCustomerCode.Text = pCustomerMaster.CustomerCode

            Dim strMsg As String = Nothing
            strMsg = SendMail(pCustomerMaster)
            If strMsg <> Nothing Then
                'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, strMsg)
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
            End If
            'ledger()

            btntally.visible = True
        ElseIf tabCustomerMaster.ActiveTabIndex = 1 Then

            If lstLocation.SelectedValue = 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Location")
                Return
            End If
            If textLocAddress.Text = "" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Address is Blank.")
                Return
            End If

            Dim pCustomerLocation As CustomerLocation = ReturnObjectLocation()
            If hdnLocationKeyId.Value = 0 Then
                CustomerLocation.Insert(pCustomerLocation)

            Else
                CustomerLocation.Update(pCustomerLocation)

            End If

            If pCustomerLocation.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCustomerLocation.Errormsg)
                Return
            End If
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
            Functions.addOrModifyLeaf(tvCustomerLocation, lstLocation.SelectedItem.Text, pCustomerLocation.LocationKeyId, hdnLocationKeyId.Value)
            hdnLocationKeyId.Value = pCustomerLocation.LocationKeyId

        End If
        ButtonControlSetup(True)
        manageUserControls(True)
        tvCustomer.Enabled = True
        textSearchCustomer.Enabled = True
        btnSearchCustomer.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub
    Function SendMail(ByVal pExtCustomerMaster As CustomerMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = Session.Item("LoginTerminal")
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = Session.Item("MenuId")
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetupByMenuId(xMailSetup)
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " Customer Id :- " & pExtCustomerMaster.CustomerId & "<br/>"
        xMailSetup.MailBody &= " Customer Name :- " & pExtCustomerMaster.CustomerName & "<br/>"
        xMailSetup.MailBody &= " Address :- " & pExtCustomerMaster.Address & "<br/>"
        xMailSetup.MailBody &= " Payment Terms :- " & lstPaymentTerms.SelectedItem.Text & "<br/>"
        If lstPaymentTerms.SelectedValue = "R" Then
            xMailSetup.MailBody &= " Credit Period :- " & pExtCustomerMaster.CreditPeriod & "<br/>"
            xMailSetup.MailBody &= " Credit Limit :- " & pExtCustomerMaster.CreditLimit & "<br/>"
        ElseIf lstPaymentTerms.SelectedValue = "P" Then
            xMailSetup.MailBody &= " Min PDA Balance :- " & textCreditLimit.Text & " Rs." & "<br/>"
        End If
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"


        xMailSetup.MailBody &= xMailSetup.Signature & "<br/>"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= "Thanks & Regards <br/>"
        xMailSetup.MailBody &= p.CompanyName & "<br/>"

        pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromId, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function
    Private Function ReturnObject() As CustomerMaster
        Dim pCustomerMaster As New CustomerMaster
        If hdnCustomerId.Value <> "" AndAlso hdnCustomerId.Value > 0 Then
            pCustomerMaster.CustomerId = hdnCustomerId.Value
        End If
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        'pCustomerMaster.CustomerCode = textCustomerCode.Text
        pCustomerMaster.CustomerName = textCustomerName.Text
        pCustomerMaster.CustomerCode = textCustomerCode.Text
        pCustomerMaster.CustomerType = lstCustomerType.SelectedValue
        pCustomerMaster.ContactPerson = textContactPerson.Text
        pCustomerMaster.ContactNo = textContactNo.Text
        pCustomerMaster.MobileNo = textMobileNo.Text
        pCustomerMaster.EmailCommercial = textEmailCommercial.Text
        pCustomerMaster.EmailOperational = textEmailOperational.Text
        pCustomerMaster.PaymentTerms = lstPaymentTerms.SelectedValue
        pCustomerMaster.CustSubId = lstCustomerType1.SelectedValue
        pCustomerMaster.StateCode = lstState.SelectedValue
        pCustomerMaster.GSTN = textGSTN.Text
        'If lstPaymentTerms.SelectedValue = "R" Then
        '    Try
        '        pCustomerMaster.CreditLimit = textCreditLimit.Text
        '    Catch ex As Exception
        '    End Try
        '    Try
        '        pCustomerMaster.CreditPeriod = textCreditPeriod.Text
        '    Catch ex As Exception
        '    End Try
        'End If
        'Try
        '    pCustomerMaster.OpeningAmount = textOpeningAmount.Text
        'Catch ex As Exception
        '    pCustomerMaster.OpeningAmount = 0
        'End Try
        'Try

        'Catch ex As Exception
        '    pCustomerMaster.CreditPeriod = textCreditPeriod.Text
        'End Try

        'pCustomerMaster.CreditLimit = textCreditLimit.Text
        If lstPaymentTerms.SelectedIndex = 0 Then
            pCustomerMaster.OpeningAmount = 0
            pCustomerMaster.CreditLimit = 0
            pCustomerMaster.CreditPeriod = 0
        End If
        If lstPaymentTerms.SelectedIndex = 1 Then
            pCustomerMaster.OpeningAmount = 0
            pCustomerMaster.CreditPeriod = textCreditPeriod.Text
            pCustomerMaster.CreditLimit = textCreditLimit.Text
        End If
        If lstPaymentTerms.SelectedIndex = 2 Then
            pCustomerMaster.OpeningAmount = textOpeningAmount.Text
            pCustomerMaster.CreditPeriod = 0
            pCustomerMaster.CreditLimit = 0
        End If
        pCustomerMaster.AccountNo = textAccountNo.Text
        pCustomerMaster.AccountMapCode = 1
        pCustomerMaster.ServiceTaxNo = textServiceTaxNo.Text
        pCustomerMaster.TanNo = textTanNo.Text
        pCustomerMaster.PanNo = textPanNo.Text
        pCustomerMaster.BinNo = textBin.Text
        If textTaxExemption.Text = "" Then
            textTaxExemption.Text = 0
        Else
            pCustomerMaster.Exemption = textTaxExemption.Text
        End If
        pCustomerMaster.Address = textAddress.Text
        pCustomerMaster.City = textCity.Text
        pCustomerMaster.Pin = textPin.Text
        pCustomerMaster.CountryId = lstCountry.SelectedValue
        If chkStatus.Checked = True Then
            pCustomerMaster.Status = "Y"
        Else
            pCustomerMaster.Status = "N"
        End If
        If chkExp.Checked = True Then
            pCustomerMaster.Export = "Y"
        Else
            pCustomerMaster.Export = "N"
        End If
        If chkImp.Checked = True Then
            pCustomerMaster.Import = "Y"
        Else
            pCustomerMaster.Import = "N"
        End If
        If chkDom.Checked = True Then
            pCustomerMaster.Domestic = "Y"
        Else
            pCustomerMaster.Domestic = "N"
        End If
        Try
            pCustomerMaster.CustomerGroupId = lstCustomerGroupName.SelectedValue
        Catch ex As Exception
            pCustomerMaster.CustomerGroupId = 0
        End Try
        Try
            pCustomerMaster.TallyFrtCustomerName = txttallyfrtCustomerName.Text
        Catch ex As Exception
            pCustomerMaster.TallyFrtCustomerName = ""
        End Try
        Try
            pCustomerMaster.TallyUSDCustomerName = textBillOfSupply.Text
        Catch ex As Exception
            pCustomerMaster.TallyUSDCustomerName = ""
        End Try
        Try
            pCustomerMaster.TallyTptCustomerName = txtTallyTptCustomerName.Text
        Catch ex As Exception
            pCustomerMaster.TallyTptCustomerName = ""
        End Try
        Try
            pCustomerMaster.TDS = lstTDS.SelectedValue
        Catch ex As Exception
            pCustomerMaster.TDS = ""
        End Try
        Try
            pCustomerMaster.TallyPurchaseCustomerName = tallyPurchaseCustomerName.Text
        Catch ex As Exception
            pCustomerMaster.TallyPurchaseCustomerName = ""
        End Try
        pCustomerMaster.CreatedBy = Session.Item("LoginUser")
        pCustomerMaster.UpdatedBy = Session.Item("LoginUser")
        pCustomerMaster.CreditType = lstDiscounttype.SelectedValue
        Try
            pCustomerMaster.discountDays = textDiscount.Text

        Catch ex As Exception
            pCustomerMaster.discountDays = 0

        End Try
        Try
            pCustomerMaster.CreditDiscountType = lstCreditDiscountType.SelectedValue
        Catch ex As Exception

        End Try
        Try
            pCustomerMaster.BankId = lstBankNameInr.SelectedValue
            pCustomerMaster.BankIdUSD = lstBankNameUSD.SelectedValue

        Catch ex As Exception

        End Try

        Return pCustomerMaster
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pCustomerMaster As New ExtCustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerId = pCodevalue.Value
        ExtCustomerMaster.ReturnCustomerMasterDetailsById(pCustomerMaster)

        hdnCustomerId.Value = pCustomerMaster.CustomerId
        textCustomerCode.Text = pCustomerMaster.CustomerCode
        textCustomerName.Text = pCustomerMaster.CustomerName
        lstCustomerType.SelectedValue = pCustomerMaster.CustomerType
        textContactPerson.Text = pCustomerMaster.ContactPerson
        textContactNo.Text = pCustomerMaster.ContactNo
        textMobileNo.Text = pCustomerMaster.MobileNo
        textEmailCommercial.Text = pCustomerMaster.EmailCommercial
        textEmailOperational.Text = pCustomerMaster.EmailOperational
        lstPaymentTerms.SelectedValue = pCustomerMaster.PaymentTerms
        textOpeningAmount.Text = pCustomerMaster.OpeningAmount
        textCreditLimit.Text = pCustomerMaster.CreditLimit
        textCreditPeriod.Text = pCustomerMaster.CreditPeriod
        textAccountNo.Text = pCustomerMaster.AccountNo
        textAccountMapCode.Text = pCustomerMaster.AccountMapCode
        textServiceTaxNo.Text = pCustomerMaster.ServiceTaxNo
        textTanNo.Text = pCustomerMaster.TanNo
        textPanNo.Text = pCustomerMaster.PanNo
        textBin.Text = pCustomerMaster.BinNo
        textTaxExemption.Text = pCustomerMaster.Exemption
        textAddress.Text = pCustomerMaster.Address
        textCity.Text = pCustomerMaster.City
        textPin.Text = pCustomerMaster.Pin
        lstCountry.SelectedValue = pCustomerMaster.CountryId

        Try
            lstCustomerType1.SelectedValue = pCustomerMaster.CustSubId
        Catch ex As Exception
        End Try
        Try
            lstBankNameInr.SelectedValue = pCustomerMaster.BankId
            lstBankNameUSD.SelectedValue = pCustomerMaster.BankIdUSD
        Catch ex As Exception
        End Try
        Try
            lstState.SelectedValue = pCustomerMaster.StateCode
        Catch ex As Exception
        End Try
        Try
            textGSTN.Text = pCustomerMaster.GSTN
        Catch ex As Exception
        End Try

        If pCustomerMaster.Status = "Y" Then
            chkStatus.Checked = True
        Else
            chkStatus.Checked = False
        End If
        If pCustomerMaster.Export = "Y" Then
            chkExp.Checked = True
        Else
            chkExp.Checked = False
        End If
        If pCustomerMaster.Import = "Y" Then
            chkImp.Checked = True
        Else
            chkImp.Checked = False
        End If
        If pCustomerMaster.Domestic = "Y" Then
            chkDom.Checked = True
        Else
            chkDom.Checked = False
        End If
        lstCustomerType1.SelectedValue = pCustomerMaster.CustSubId
        Try
            lstDiscounttype.SelectedValue = pCustomerMaster.CreditType
        Catch ex As Exception

        End Try
        Try
            lstCustomerGroupName.SelectedValue = pCustomerMaster.CustomerGroupId
        Catch ex As Exception
            lstCustomerGroupName.SelectedValue = 0
        End Try
        Try
            txttallyfrtCustomerName.Text = pCustomerMaster.TallyFrtCustomerName
        Catch ex As Exception
            txttallyfrtCustomerName.Text = ""
        End Try
        Try
            txtTallyTptCustomerName.Text = pCustomerMaster.TallyTptCustomerName
        Catch ex As Exception
            txtTallyTptCustomerName.Text = ""
        End Try
        Try
            textBillOfSupply.Text = pCustomerMaster.TallyUSDCustomerName
        Catch ex As Exception
            textBillOfSupply.Text = ""
        End Try
        Try
            tallyPurchaseCustomerName.Text = pCustomerMaster.TallyPurchaseCustomerName
        Catch ex As Exception
            tallyPurchaseCustomerName.Text = ""
        End Try
        Try
            lstTDS.SelectedValue = pCustomerMaster.TDS
        Catch ex As Exception
            lstTDS.SelectedValue = "0"
        End Try
        textDiscount.Text = pCustomerMaster.discountDays
        Try
            lstCreditDiscountType.SelectedValue = pCustomerMaster.CreditDiscountType
        Catch ex As Exception
            lstCreditDiscountType.SelectedValue = "0"
        End Try
        Try
            lstBankNameInr.SelectedValue = pCustomerMaster.BankId
            lstBankNameUSD.SelectedValue = pCustomerMaster.BankIdUSD
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearchCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCustomer.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textSearchCustomer.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The search Value")
            Functions.ControlFocus(textSearchCustomer)
            Exit Sub
        End If
        tvCustomer.Nodes.Clear()
        LoadTreeViewDataCustomer()
    End Sub

    Sub LoadTreeViewDataCustomer()
        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        pCustomerMaster.CustomerName = textSearchCustomer.Text.Trim
        Try
            For Each obj As CustomerMaster In ExtCustomerMaster.ReturnCustomerMasterListByCustomerNameSearch(pCustomerMaster)
                Functions.treeViewNodeSetup(tvCustomer, "0", obj.CustomerId, obj.CustomerName)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub tabCustomerMaster_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCustomerMaster.ActiveTabChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If tabCustomerMaster.ActiveTabIndex = 1 Then
            tvCustomerLocation.Nodes.Clear()
            textCustomer.Text = textCustomerName.Text
            LoadTreeViewDataLocation()
            btnTally.Visible = False
        End If
    End Sub
    Private Function ReturnObjectLocation() As CustomerLocation
        Dim pCustomerLocation As New CustomerLocation
        pCustomerLocation.CustomerId = hdnCustomerId.Value
        pCustomerLocation.TerminalId = Session.Item("LoginTerminal")
        pCustomerLocation.CreatedBy = Session.Item("LoginUser")
        pCustomerLocation.LocationId = lstLocation.SelectedValue
        Try
            pCustomerLocation.LocationKeyId = hdnLocationKeyId.Value

        Catch ex As Exception
        End Try
        pCustomerLocation.Address = textLocAddress.Text
        ' pCustomerLocation()
        pCustomerLocation.Longitude = TextBox1.Text
        pCustomerLocation.Latitude = TextBox2.Text
        ' = textEicher20.Text
        'pCustomerLocation.Ashok20 = textAshok20.Text
        'pCustomerLocation.Ashok40 = textAshok40.Text
        Return pCustomerLocation
    End Function

    Sub LoadTreeViewDataLocation()
        Dim pCustomerLocation As New CustomerLocation
        pCustomerLocation.TerminalId = Session.Item("LoginTerminal")
        pCustomerLocation.CustomerId = hdnCustomerId.Value
        Try
            For Each obj As CustomerLocation In CustomerLocation.ReturnCustomerLocationList(pCustomerLocation)
                Functions.treeViewNodeSetup(tvCustomerLocation, "0", obj.LocationKeyId, obj.Address)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub prepareControlLocation(ByVal pCodevalue As TreeNode)
        Dim pCustomerLocation As New CustomerLocation
        pCustomerLocation.TerminalId = Session.Item("LoginTerminal")
        pCustomerLocation.LocationKeyId = pCodevalue.Value
        CustomerLocation.ReturnCustomerLocation(pCustomerLocation)
        hdnLocationKeyId.Value = pCustomerLocation.LocationKeyId
        'hdnCustomerId.Value = pCustomerMaster.CustomerId
        lstLocation.SelectedValue = pCustomerLocation.LocationId
        textLocAddress.Text = pCustomerLocation.Address
        TextBox1.Text = pCustomerLocation.Longitude
        TextBox2.Text = pCustomerLocation.Latitude
        textCustomer.Text = textCustomerName.Text
        textCustomerCode.Text = textCustomerCode.Text

    End Sub

    Protected Sub tvCustomerLocation_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvCustomerLocation.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControlLocation(tvCustomerLocation.SelectedNode)
        manageUserControls(True)
        Functions.ControlFocus(btnEdit)
    End Sub

    Protected Sub btntally_Click(sender As Object, e As System.EventArgs) Handles btntally.Click
        ledger()
    End Sub
End Class
