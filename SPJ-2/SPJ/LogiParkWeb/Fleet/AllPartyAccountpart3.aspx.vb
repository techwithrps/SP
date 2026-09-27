Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection


Partial Class Fleet_AllPartyAccountPart3
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Private Shared Property dbr As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'btnSearch.Visible = True

        End If
    End Sub
    Private Sub GridView()
        Dim party As New AllPartyAccount
        Dim arr As ArrayList
        arr = AllPartyAccount.ReturnAllPartyAccountList(party)
        GridViewAllPartyPart3.DataSource = arr
        GridViewAllPartyPart3.DataBind()

    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        GridViewAllPartyPart3.DataSource = Nothing
        GridViewAllPartyPart3.DataBind()

        If textFromDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        ''lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim party As New AllPartyAccount
        party.CreatedBy = textFromDate.Text
        party.CreatedOn = textToDate.Text
        party.BlNo = txtBLNo.Text
        party.ConsingeeName = textCustomer.Text
        party.SelfExcise = textLocation.Text
        Dim arr As ArrayList
        arr = AllPartyAccount.ReturnAllPartyAccountSearchList(party)
        GridViewAllPartyPart3.DataSource = arr
        GridViewAllPartyPart3.DataBind()
        If arr.Count > 0 Then
            tblReport.Visible = True
        Else
            tblReport.Visible = True
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        'dbr.Close()
        'db.CloseDB()

    End Sub

  Sub ButtonControlSetup(ByVal pVisible As Boolean)
        'btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        btnSave.Visible = pVisible
        btnCancel.Visible = pVisible
        'btnEditContDetail.Visible = pVisible
        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If

        If Session.Item("Save") <> "Y" Then
            btnSave.Visible = True
        End If

        If Session.Item("Edit") <> "Y" Then

        End If

        'If Session.Item("Search") <> "Y" Then
        '    btnSearch.Visible = False
        'End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub
    Sub manageUserControl(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.Div1.Controls)
        textLinerBilling.Enabled = pEnable
        textBlNo.Enabled = pEnable
        textBlStatus.Enabled = pEnable
        textOblStatus.Enabled = pEnable
        textFollowUp.Enabled = pEnable
        textOblReleased.Enabled = pEnable
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        Dim isContNo As Integer = 0

        If hdnContNo.Value Is Nothing Or hdnContNo.Value = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select a container Number")
            rtnBool = False
            'Functions.ControlFocus(textContNo)
            Return rtnBool
            Exit Function
        End If

        Return rtnBool
    End Function
    Private Function ReturnObject() As AllPartyAccount
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.ContNo = hdnContNo.Value()
        pAllPartyAccount.JsbBilling = textLinerBilling.Text
        pAllPartyAccount.BlNo = textBlNo.Text
        pAllPartyAccount.BlStatus = textBlStatus.Text
        pAllPartyAccount.OblStatus = textOblStatus.Text
        pAllPartyAccount.FollowUp = textFollowUp.Text
        pAllPartyAccount.OblIssueDate = textOblReleased.Text

        Return pAllPartyAccount

    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.Div1.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControl(True)
        ButtonControlSetup(True)
        'btnAdd.Visible = True
        'btnAddBookingNo.Visible = False
        'Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub GridViewAllPartyPart3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewAllPartyPart3.RowCommand
        If e.CommandName.Equals("part3") Then
            Dim ContNo As String = e.CommandArgument
            Dim pAllPartyAccount As New AllPartyAccount
            pAllPartyAccount.ContNo = ContNo
            pAllPartyAccount = AllPartyAccount.ReturnAllPartyAccountPart2(pAllPartyAccount)
            hdnContNo.Value = ContNo
            textLinerBilling.Text = pAllPartyAccount.JsbBilling
            textBlNo.Text = pAllPartyAccount.BlNo
            textBlStatus.Text = pAllPartyAccount.BlStatus
            textOblStatus.Text = pAllPartyAccount.OblStatus
            textFollowUp.Text = pAllPartyAccount.FollowUp
            textOblReleased.Text = pAllPartyAccount.OblIssueDate
            Dim aa As Boolean = True
            manageUserControl(aa)

        End If
        'btnAdd.Visible = False
    End Sub

    Protected Sub GridViewAllPartyPart1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewAllPartyPart3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            'Dim lblblsrn As Label = GridViewAllPartyPart1.FindControl("lblsrn")
            Dim lblblsrn As Label = DirectCast(e.Row.FindControl("lblsrn"), Label)
            'e.Row.Cells(1).Text = intCounter
            lblblsrn.Text = intCounter.ToString()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pAllPartyAccount As AllPartyAccount = ReturnObject()
        AllPartyAccount.UpdatePart3(pAllPartyAccount)

        If pAllPartyAccount.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pAllPartyAccount.Errormsg)
            ' Functions.ControlFocus(lstDocType)
            Return
        End If
        btnDisplay_Click(sender, e)
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControl(True)
        'Functions.ControlFocus(btnAdd)
        'btnAdd.Visible = True
        ClearText()

    End Sub

    Sub cleartext()

        textLinerBilling.Text = ""
        textBlNo.Text = ""
        textBlStatus.Text = ""
        textOblStatus.Text = ""
        textFollowUp.Text = ""
        textOblReleased.Text = ""

    End Sub

End Class



