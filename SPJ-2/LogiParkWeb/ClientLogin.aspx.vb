Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Net.Mail
Imports System.Xml

Partial Class ClientLogin
    Inherits System.Web.UI.Page
    Dim intJobId As Long
    Dim strPasswordChangeDate As String
    Dim _captchaText, pass As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim strUser As String = ""
            Dim StrPass As String = ""
            strUser = Request.QueryString("user")
            StrPass = Request.QueryString("pass")

            lstBranch.Visible = False
            lstCompany.Visible = False
            btnLogin.Visible = False
            lblBranch.Visible = False
            lblCompany.Visible = False
            TxtCaptcha.Visible = False
            txtEntCaptcha.Visible = False
            BtnRef.Visible = False
            If strUser <> "" And StrPass <> "" Then
                loginbystring(strUser, StrPass)

            End If
        End If
        textUserName.Focus()


    End Sub
    Sub loginbystring(ByVal strUser As String, ByVal strPass As String)
        Session.Clear()
        Dim pUser As New ExtUserMaster

        pUser.UserId = strUser
        pUser.Password = strPass
        textUserName.Text = strUser
        textPassword.Text = strPass
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserIAssign(pUser)
        If pUser.Errormsg <> Nothing Then
            lblErrorMessage.Text = pUser.Errormsg
            textUserName.Focus()
        End If
        If pUser.UserName = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid User")
            textUserName.Text = String.Empty
            textPassword.Text = String.Empty
            textUserName.Focus()
            Return
        End If
        If pUser.Password <> textPassword.Text.Trim Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Password")
            textPassword.Focus()

            hdnwrongloginattempts.Value += 1
            If hdnwrongloginattempts.Value > 9 Then
                Dim strConnectionString, cmd1 As String
                Dim con As OleDbConnection
                Dim ada As New OleDbDataAdapter
                Try
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "UPDATE USER_MASTER SET REMARKS='Unsuccessful 3 attempts' ,USER_STATUS= ''  WHERE USER_ID= " & "'" & textUserName.Text & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
                Dim strMsg As String = Nothing
                strMsg = SendMail(pUser)
                If strMsg = Nothing Then
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "  Mail sending Successfully, ")
                End If

                Response.Redirect("~/demo.aspx")
            End If
            Return
        End If

        If (pUser.UserStatus <> "Y" And pUser.UserStatus <> "R" And pUser.UserStatus <> "C") Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Inactive User")
            textUserName.Focus()
            Return
        End If


        If (pUser.UserStatus <> "Y" And pUser.UserStatus <> "R") Then
            lblErrorMessage.Text = "Inactive User, Login not allowed "
            textUserName.Text = String.Empty
            textPassword.Text = String.Empty
            textUserName.Focus()
            Return
        End If


        Dim prole As New UserJobs
        prole.UserId = pUser.UserId
        UserJobs.ReturnUserJobsByUserId(prole)
        intJobId = prole.JobId
        If prole.JobId <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No role assigned to user")
            textUserName.Focus()
            Return
        End If

        If pUser.TerminalList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Branch assigned to user")
            textUserName.Focus()
            Return
        End If

        If pUser.CompanyList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Company assigned to user")
            textUserName.Focus()
            Return
        End If
        lstBranch.DataSource = pUser.TerminalList
        lstBranch.DataTextField = "UserId"
        lstBranch.DataValueField = "TerminalId"
        lstBranch.DataBind()
        lstBranch.Items.Insert(0, (New ListItem("---Select---", "0")))

        lstCompany.DataSource = pUser.CompanyList
        lstCompany.DataTextField = "CompanyName"
        lstCompany.DataValueField = "CompanyId"
        lstCompany.DataBind()
        lstCompany.Items.Insert(0, (New ListItem("---Select---", "0")))


        ''User Login Details
        ''Created on 16.08.2013 by Amit K. Singh
        Dim strIPAddress
        strIPAddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        Dim strHostname As String = System.Net.Dns.GetHostName()

        If strIPAddress = "" Then
            strIPAddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        Session.Add("LoginUser", textUserName.Text)
        Session.Add("LoginUserName", textUserName.Text)
        hdnStatus.Value = pUser.UserStatus

        Session.Add("Add", "N")
        Session.Add("Edit", "N")
        Session.Add("Search", "N")
        Session.Add("Delete", "N")
        Session.Add("Title", "N")
        Session.Add("JobId", intJobId)


        Dim pUserLogin As New UserLogin
        pUserLogin.UserId = textUserName.Text
        pUserLogin.UserName = textUserName.Text
        pUserLogin.LoginDate = Today
        pUserLogin.IpAddress = strIPAddress
        UserLogin.Insert(pUserLogin)
        Session.Add("TrnId", pUserLogin.TrnId)

        lstBranch.Visible = True
        lstCompany.Visible = True
        btnLogin.Visible = True
        lblBranch.Visible = True
        lblCompany.Visible = True
        btnSubmit.Visible = False
        textUserName.Enabled = False
        textPassword.Enabled = False
        lblErrorMessage.Text = ""
        lstCompany.Focus()
        TxtCaptcha.Text = RandomString(8, True)
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Session.Clear()
        If textUserName.Text.Trim = Nothing Then
            lblErrorMessage.Text = "Enter the User name"
            textUserName.Text = String.Empty
            textPassword.Text = String.Empty
            ' Return
        End If
        If textUserName.Text.Trim = Nothing Then
            lblErrorMessage.Text = "Enter the Password"
            textUserName.Text = String.Empty
            textPassword.Text = String.Empty
            ' Return
        End If

        Dim pUser As New ExtUserMaster

        pUser.UserId = textUserName.Text.Trim
        pUser.Password = textPassword.Text.Trim
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserIAssign(pUser)
        If pUser.Errormsg <> Nothing Then
            lblErrorMessage.Text = pUser.Errormsg
            textUserName.Focus()
        End If
        If pUser.UserName = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid User")
            textUserName.Text = String.Empty
            textPassword.Text = String.Empty
            textUserName.Focus()
            Return
        End If
        If pUser.Password <> textPassword.Text.Trim Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Password")
            textPassword.Focus()

            hdnwrongloginattempts.Value += 1
            If hdnwrongloginattempts.Value > 9 Then
                Dim strConnectionString, cmd1 As String
                Dim con As OleDbConnection
                Dim ada As New OleDbDataAdapter
                Try
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "UPDATE USER_MASTER SET REMARKS='Unsuccessful 3 attempts' ,USER_STATUS= ''  WHERE USER_ID= " & "'" & textUserName.Text & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
                Dim strMsg As String = Nothing
                strMsg = SendMail(pUser)
                If strMsg = Nothing Then
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "  Mail sending Successfully, ")
                End If

                Response.Redirect("~/demo.aspx")
            End If
            Return
        End If

        If (pUser.UserStatus <> "Y" And pUser.UserStatus <> "R" And pUser.UserStatus <> "C") Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Inactive User")
            textUserName.Focus()
            Return
        End If
        If (pUser.UserStatus = "C") Then

            'lblErrorMessage.Text = "Password has been expired. Please reset password."
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Password has been expired. Please reset password.")

            textUserName.Focus()
            Return
        End If

        'If (pUser.UserStatus <> "Y" And pUser.UserStatus <> "R") Then
        '    lblErrorMessage.Text = "Inactive User, Login not allowed "
        '    textUserName.Text = String.Empty
        '    textPassword.Text = String.Empty
        '    textUserName.Focus()
        '    Return
        'End If

        If Not pUser.UserId.Equals("ADMIN", StringComparison.OrdinalIgnoreCase) AndAlso
           Not pUser.UserId.Equals("Ashish devrani", StringComparison.OrdinalIgnoreCase) AndAlso
           Not pUser.UserId.Equals("Nitin Saini", StringComparison.OrdinalIgnoreCase) AndAlso
           Not pUser.UserId.Equals("Superuser", StringComparison.OrdinalIgnoreCase) AndAlso
           Not pUser.UserId.Equals("Harendra Singh", StringComparison.OrdinalIgnoreCase) AndAlso
            Not pUser.UserId.Equals("Vansh", StringComparison.OrdinalIgnoreCase) AndAlso
            Not pUser.UserId.Equals("SAHIL", StringComparison.OrdinalIgnoreCase) AndAlso
           Not pUser.UserId.Equals("Gaurav Singh", StringComparison.OrdinalIgnoreCase) Then
            Dim clientMacAddress = hdnMacAddress.Value 'GetClientMAC(GetIPAddress())

            If Not String.IsNullOrEmpty(pUser.MACAddress) Then
                Dim arrMacAddress = pUser.MACAddress
                Dim isPresentDevice = CustomContain(arrMacAddress, clientMacAddress)
                ' Dim isPresentDevice = CustomContain(pUser.MACAddress, clientMacAddress)
                '  If Not isPresentDevice Then
                If Not isPresentDevice AndAlso arrMacAddress.Length.Equals(1) Then
                    lblErrorMessage.Text = "Login not allowed, Please contact to admin."
                    textUserName.Text = String.Empty
                    textPassword.Text = String.Empty
                    textUserName.Focus()
                    SendUnKnownDeviceInfoMail(pUser)
                    Return
                ElseIf Not isPresentDevice AndAlso String.IsNullOrWhiteSpace(pUser.MACAddress) Then
                    InsertNewMacAddress(pUser, clientMacAddress)
                ElseIf isPresentDevice Then
                Else
                    lblErrorMessage.Text = "Login not allowed, Please contact to admin."
                    textUserName.Text = String.Empty
                    textPassword.Text = String.Empty
                    textUserName.Focus()
                    SendUnKnownDeviceInfoMail(pUser)
                    Return
                End If
            Else
                InsertNewMacAddress(pUser, clientMacAddress)
            End If
        End If


        Dim prole As New UserJobs
        prole.UserId = pUser.UserId
        UserJobs.ReturnUserJobsByUserId(prole)
        intJobId = prole.JobId
        If prole.JobId <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No role assigned to user")
            textUserName.Focus()
            Return
        End If

        If pUser.TerminalList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Branch assigned to user")
            textUserName.Focus()
            Return
        End If

        If pUser.CompanyList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Company assigned to user")
            textUserName.Focus()
            Return
        End If
        lstBranch.DataSource = pUser.TerminalList
        lstBranch.DataTextField = "UserId"
        lstBranch.DataValueField = "TerminalId"
        lstBranch.DataBind()
        lstBranch.Items.Insert(0, (New ListItem("---Select---", "0")))

        lstCompany.DataSource = pUser.CompanyList
        lstCompany.DataTextField = "CompanyName"
        lstCompany.DataValueField = "CompanyId"
        lstCompany.DataBind()
        lstCompany.Items.Insert(0, (New ListItem("---Select---", "0")))


        ''User Login Details
        ''Created on 16.08.2013 by Amit K. Singh
        Dim strIPAddress
        strIPAddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        Dim strHostname As String = System.Net.Dns.GetHostName()

        If strIPAddress = "" Then
            strIPAddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        Session.Add("LoginUser", textUserName.Text)
        Session.Add("LoginUserName", textUserName.Text)
        hdnStatus.Value = pUser.UserStatus

        Session.Add("Add", "N")
        Session.Add("Edit", "N")
        Session.Add("Search", "N")
        Session.Add("Delete", "N")
        Session.Add("Title", "N")
        Session.Add("JobId", intJobId)


        Dim pUserLogin As New UserLogin
        pUserLogin.UserId = textUserName.Text
        pUserLogin.UserName = textUserName.Text
        pUserLogin.LoginDate = Today
        pUserLogin.IpAddress = strIPAddress
        UserLogin.Insert(pUserLogin)
        Session.Add("TrnId", pUserLogin.TrnId)

        lstBranch.Visible = True
        lstCompany.Visible = True
        btnLogin.Visible = True
        lblBranch.Visible = True
        lblCompany.Visible = True
        TxtCaptcha.Visible = True
        txtEntCaptcha.Visible = True
        BtnRef.Visible = True
        btnSubmit.Visible = False
        textUserName.Enabled = False
        textPassword.Enabled = False
        lblErrorMessage.Text = ""
        lstCompany.Focus()
        TxtCaptcha.Text = RandomString(8, True)
    End Sub

    Function SendMail(ByVal pUserMaster As UserMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = 1
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.ToMailIds &= pUserMaster.EmailId & "," & "amit.singh@elogisol.in"
        xMailSetup.Subject &= "Exceed Login attempt"
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " User Id :- " & pUserMaster.UserId & "<br/>"
        xMailSetup.MailBody &= " User Name :- " & pUserMaster.UserName & "<br/>"
        xMailSetup.MailBody &= "Please contect to your administrator. " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= xMailSetup.Signature & "<br/>"
        pStr = Functions.sendmail(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If lstCompany.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Comapny.")
            lstCompany.Focus()
            Return
        End If
        If lstBranch.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Branch.")
            lstBranch.Focus()
            Return
        End If
        If TxtCaptcha.Text <> txtEntCaptcha.Text Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Wrong Captcha.")
            txtEntCaptcha.Focus()
            Return
        End If


        Session.Add("LoginTerminal", lstBranch.SelectedValue)
        Session.Add("CompanyId", lstCompany.SelectedValue)
        Session.Add("CompanyName", lstCompany.SelectedItem.Text)

        MenuItemHelper.ReadMenuXml(Me.Page)

        If hdnStatus.Value = "Y" Then
            Response.Redirect("~/Home.aspx")
        ElseIf hdnStatus.Value = "R" Then
            Response.Redirect("~/Master/Admin/ChangePassword.aspx")
        End If
    End Sub

    Protected Sub BtnRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRef.Click
        TxtCaptcha.Text = RandomString(4, True)
    End Sub
    Private Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
        Dim builder As New StringBuilder()
        Dim random As New Random()
        Dim result As String
        Dim sb As New StringBuilder
        Dim s As String = "0123456789"
        For i As Integer = 1 To 4
            Dim idx As Integer = random.Next(0, 10)
            sb.Append(s.Substring(idx, 1))
        Next

        result = sb.ToString()
        _captchaText = sb.ToString()
        Return result
    End Function

    Function CustomContain(clientMac As String, valToCheck As String) As Boolean
        If valToCheck.Equals(clientMac) Then
            Return True
        End If
        Return False
    End Function

    Private Shared Sub InsertNewMacAddress(pUser As UserMaster, macAddress As String)
        Dim con As OleDbConnection
        Dim strConnectionString = ConfigurationManager.AppSettings("DBConnectionString")
        Dim strUpdateStatement = "UPDATE USER_MASTER SET MAC_ADDRESSES='" & macAddress & "' WHERE USER_ID= '" & pUser.UserId & "'"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim cmd = New OleDbCommand(strUpdateStatement, con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Function SendUnKnownDeviceInfoMail(ByVal pUserMaster As UserMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = 1
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim strIPAddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")

        If String.IsNullOrWhiteSpace(strIPAddress) Then
            strIPAddress = Request.ServerVariables("REMOTE_ADDR")
        End If


        Dim xMailSetup As New MailSetup
        xMailSetup.ToMailIds &= "akshay@spjcargo.com,softsupport@spjcargo.com"
        xMailSetup.Subject &= "Login attempted from Unknown Device"
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " User Id :- " & pUserMaster.UserId & "<br/>"
        xMailSetup.MailBody &= " User Name :- " & pUserMaster.UserName & "<br/>"
        xMailSetup.MailBody &= " Ip Address :- " & strIPAddress.ToString() & "<br/>"
        xMailSetup.MailBody &= "Please contact to your administrator. " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= xMailSetup.Signature & "<br/>"

        pStr = CommonSendingMailLibary.MailSender.SendMailToCcBccIDWithOrWithoutAttachment(pMailConfig.FromId,
                              pMailConfig.FromName,
                              xMailSetup.ToMailIds, String.Empty, String.Empty,
                              xMailSetup.Subject,
                              xMailSetup.MailBody,
                              pMailConfig.SmtpServer,
                              pMailConfig.Password,
                              pMailConfig.PortNo)
        Return pStr
    End Function

End Class
