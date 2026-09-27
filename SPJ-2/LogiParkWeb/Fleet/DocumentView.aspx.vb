Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Fleet_DocumentView
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
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

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
       
        Dim pFe As New FleetEquipmentMaster
        pFe.TerminalId = Session.Item("LoginTerminal")
        pFe.EquipmentNo = textVehicleNo.Text
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pFe)
        textinsuranceno.Text = pFe.InsuranceNo
        ' textRc.Text = pFe.RCDoc
        textFitness.Text = pFe.Validity
        lnkFitness.CommandArgument = "C:\\Software\\JSB\\Fitness\\" & pFe.FitnessDoc
        linkInsurance.CommandArgument = "C:\\Software\\JSB\\Insurance\\" & pFe.InsuranceDoc
        lnkPermit.CommandArgument = "C:\\Software\\JSB\\NationalPermit\\" & pFe.PermitA
        lnkRC.CommandArgument = "C:\\Software\\JSB\\RC\\" & pFe.RCDoc
        textPermit.Text = pFe.PermitFrom & "-" & pFe.PermitTo
        textinsuranceno.Visible = True
        textVehicleType.Text = pFe.EquipmentType
        End Sub

    Protected Sub lnkFitness_Click(sender As Object, e As System.EventArgs) Handles lnkFitness.Click
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('OpenDocument.aspx?filepath=" & lnkFitness.CommandArgument & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

    End Sub
    Protected Sub linkInsurance_Click(sender As Object, e As System.EventArgs) Handles linkInsurance.Click
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('OpenDocument.aspx?filepath=" & linkInsurance.CommandArgument & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

    End Sub
    Protected Sub lnkPermit_Click(sender As Object, e As System.EventArgs) Handles lnkPermit.Click
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('OpenDocument.aspx?filepath=" & lnkPermit.CommandArgument & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

    End Sub
    Protected Sub lnkRC_Click(sender As Object, e As System.EventArgs) Handles lnkRC.Click
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('OpenDocument.aspx?filepath=" & lnkRC.CommandArgument & "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)

    End Sub

    Protected Sub btnsaveshipper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsaveMail.Click
        If fileUpload.PostedFile.FileName <> Nothing Then
            fileUpload.PostedFile.SaveAs("C:\\Software\\JSB\\Others\\" + Path.GetFileName(fileUpload.PostedFile.FileName))

        End If
        Dim strMsg As String = Nothing
        strMsg = SendMail()
        If strMsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail sending failure.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Mail Sent Successfully.")
        End If
    End Sub
    Function SendMail() As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = Session.Item("LoginTerminal")
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.ToMailIds = textToMail.Text
        xMailSetup.CcIds = textCCMail.Text
        If chkFitness.Checked = True Then
            pMailConfig.FromName = lnkFitness.CommandArgument
        End If
        If chkInsurance.Checked = True Then
            pMailConfig.FromName &= "," & linkInsurance.CommandArgument
        End If
        If chkPermit.Checked = True Then
            pMailConfig.FromName &= "," & lnkPermit.CommandArgument
        End If
        If chkRc.Checked = True Then
            pMailConfig.FromName &= ", " & lnkRC.CommandArgument
        End If
        If fileUpload.PostedFile.FileName <> Nothing Then
            pMailConfig.FromName &= ", C:\\" & Path.GetFileName(fileUpload.PostedFile.FileName)

        End If
       
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= "Thanks & Regards" & "<br/>"

        xMailSetup.MailBody &= p.CompanyName & "<br/>"

        pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
