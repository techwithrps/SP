Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Xml

Partial Class ClientLogin
    Inherits System.Web.UI.Page
    Dim intJobId As Long
    Dim strPasswordChangeDate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lstBranch.Visible = False
            lstCompany.Visible = False
            btnLogin.Visible = False
            lblBranch.Visible = False
            lblCompany.Visible = False
        End If
        textUserName.Focus()
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
            If hdnwrongloginattempts.Value > 2 Then
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

        If (pUser.UserStatus <> "Y" And pUser.UserStatus <> "R") Then
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
End Class
