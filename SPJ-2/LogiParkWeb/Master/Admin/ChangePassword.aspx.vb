Imports System.Data.OleDb
Imports CommonSendingMailLibary
Imports LogiParkLib.LogiParkObjects

Partial Class Master_Admin_ChangePassword
    Inherits System.Web.UI.Page

    Shared Message As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            manageUserControls(True)
            prepareControls(Session.Item("LoginUser"))
            manageControls(True)
        End If
        Functions.ControlFocus(textConfirmPassword)
    End Sub

    Sub prepareControls(ByVal PCode As String)
        Dim p As New ExtUserMaster
        p.UserId = PCode
        ExtUserMaster.ReturnUserMasterRolAndTerminalListByUserId(p)

        hdnUserId.Value = p.UserId
        textUserId.Text = p.UserId
        textUserName.Text = p.UserName
        hdnEmailId.Value = p.EmailId
        password.Value = p.Password
        If p.UserStatus <> "C" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Password will expire within " & p.CreatedOn & " days")
            btnExit.Enabled = False
            Return
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Your password has been expire")
            btnExit.Enabled = False
            Return
        End If
    End Sub

    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)

    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True

        If password.Value.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the password")
            rtnBool = False
            Functions.ControlFocus(textOldPassword)
            Return rtnBool
            Exit Function
        End If
        If textOldPassword.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Old Password")
            rtnBool = False
            Functions.ControlFocus(textOldPassword)
            Return rtnBool
            Exit Function
        End If
        If password.Value.Trim <> textOldPassword.Text.Trim Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Use original Password")
            rtnBool = False
            Functions.ControlFocus(textOldPassword)
            Return rtnBool
            Exit Function
        End If
        If textNewPassword.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the New Password.")
            rtnBool = False
            Functions.ControlFocus(textNewPassword)
            Return rtnBool
            Exit Function
        End If

        If textConfirmPassword.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter the Confirm Password.")
            rtnBool = False
            Functions.ControlFocus(textConfirmPassword)
            Return rtnBool
            Exit Function
        End If
        If textNewPassword.Text.Trim = password.Value.Trim Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "New Password should not be same as Old Password.")
            rtnBool = False
            Functions.ControlFocus(textNewPassword)
            Return rtnBool
            Exit Function
        End If
        If isValidate(textNewPassword.Text) = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, Message)
            Functions.ControlFocus(textNewPassword)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textNewPassword.Text.Trim <> textConfirmPassword.Text.Trim Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Confirm Password should not be same as New Password.")
            Functions.ControlFocus(textConfirmPassword)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtUserMaster As ExtUserMaster = ReturnObject()

        ExtUserMaster.ChangePassword(pExtUserMaster)
        If pExtUserMaster.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtUserMaster.Errormsg)
            Return
        End If
        hdnUserId.Value = pExtUserMaster.UserId
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved successfully.")
        Dim strMsg As String = Nothing
        strMsg = SendMail(pExtUserMaster)
        If strMsg <> Nothing Then
            'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, strMsg)
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        End If

        ButtonControlSetup(True)
        manageUserControls(True)
        Response.Redirect("~/Home.aspx")
    End Sub

    Function SendMail(ByVal pExtUserMaster As ExtUserMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.ToMailIds = pExtUserMaster.EmailId
        xMailSetup.CcIds = pExtUserMaster.EmailId
        xMailSetup.BccIds = pExtUserMaster.EmailId
        xMailSetup.Subject = "New Password"

        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= "New Password " & "<br/>"
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= " User Id : " & pExtUserMaster.UserId & "<br/>"
        xMailSetup.MailBody &= " User Name : " & pExtUserMaster.UserName & "<br/>"

        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"

        xMailSetup.MailBody &= " Thanks & Regards " & "<br/>"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"

        pStr = MailSender.SendMailToCcBccIDWithOrWithoutAttachment(pMailConfig.FromId,
                                                                                "",
                                                                                xMailSetup.ToMailIds,
                                                                                xMailSetup.CcIds,
                                                                                xMailSetup.BccIds,
                                                                                xMailSetup.Subject,
                                                                                xMailSetup.MailBody,
                                                                                pMailConfig.SmtpServer,
                                                                                pMailConfig.Password,
                                                                                pMailConfig.PortNo,
                                                                                EnumCompanyName.PRISTINE)

        Try
            Dim strConnectionString As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim con As OleDbConnection
            Dim cmd2 As String
            cmd2 = "INSERT INTO MAIL_STATUS (STATUS_ID,SUBJECT,MESSEGE,CREATED_ON,TO_MAIL_IDS,BOOKING_NO) VALUES (MAIL_STATUS_ID.NEXTVAL, '" & xMailSetup.Subject & "',DECODE('" & pStr & "','','Sucess','" & pStr & "'),SYSDATE, '" & xMailSetup.ToMailIds & "',' User Id - " & pExtUserMaster.UserId & "') "
            con = New OleDbConnection(strConnectionString)
            Dim cmd3 As New OleDbCommand(cmd2, con)
            con.Open()
            cmd3.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        Return pStr
    End Function

    Function ReturnObject() As ExtUserMaster
        Dim pExtUserMaster As New ExtUserMaster
        If hdnUserId.Value.Trim <> Nothing Then
            pExtUserMaster.UserId = hdnUserId.Value
        Else
            pExtUserMaster.UserId = textUserId.Text.Trim
        End If
        pExtUserMaster.EmailId = hdnEmailId.Value
        pExtUserMaster.UserName = textUserName.Text
        pExtUserMaster.Password = textNewPassword.Text

        Return pExtUserMaster
    End Function

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textUserName.Enabled = pEnable
        textNewPassword.Enabled = pEnable
        textConfirmPassword.Enabled = pEnable
        textOldPassword.Enabled = pEnable
        textUserId.Enabled = False
        'textOldPassword.Enabled = False
        textUserName.Enabled = False
        Functions.ControlFocus(textNewPassword)
    End Sub

    Public Shared Function isValidate(ByVal password As String) As Boolean

        If Not ((password.Length >= 8)) Then
            Message = "Password length should be greater and equal to 8 character"
            Return False
        End If

        If password.Contains(" ") Then
            Message = "Password Contains Space Value which not allow"
            Return False
        End If

        If True Then
            Dim count As Integer = 0

            For i As Integer = 0 To 9
                Dim str1 As String = i.ToString()

                If password.Contains(str1) Then
                    count = 1
                End If
            Next

            If count = 0 Then
                Message = "Password should contain at least one numeric value"
                Return False
            End If
        End If

        If Not (password.Contains("@") OrElse password.Contains("#") OrElse password.Contains("!") OrElse password.Contains("~") OrElse password.Contains("$") OrElse password.Contains("%") OrElse password.Contains("^") OrElse password.Contains("&") OrElse password.Contains("*") OrElse password.Contains("(") OrElse password.Contains(")") OrElse password.Contains("-") OrElse password.Contains("+") OrElse password.Contains("/") OrElse password.Contains(":") OrElse password.Contains(".") OrElse password.Contains(", ") OrElse password.Contains("<") OrElse password.Contains(">") OrElse password.Contains("?") OrElse password.Contains("|")) Then
            Message = "Password should contain at least one special character"
            Return False
        End If

        If True Then
            Dim count As Integer = 0

            For i As Integer = 65 To 90
                Dim c As Char = ChrW(i)
                Dim str1 As String = c.ToString()

                If password.Contains(str1) Then
                    count = 1
                End If
            Next

            If count = 0 Then
                Message = "Password should contain at least one Capital alphabet character"
                Return False
            End If
        End If

        If True Then
            Dim count As Integer = 0

            For i As Integer = 90 To 122
                Dim c As Char = ChrW(i)
                Dim str1 As String = c.ToString()

                If password.Contains(str1) Then
                    count = 1
                End If
            Next

            If count = 0 Then
                Message = "Password should contain at least one small alphabet character"
                Return False
            End If
        End If

        Return True
    End Function
End Class
