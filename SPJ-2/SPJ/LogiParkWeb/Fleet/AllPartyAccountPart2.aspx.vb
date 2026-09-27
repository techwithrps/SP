Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection

Partial Class Fleet_AllPartyAccountPart2
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
        GridViewAllPartyPart1.DataSource = arr
        GridViewAllPartyPart1.DataBind()

    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        GridViewAllPartyPart1.DataSource = Nothing
        GridViewAllPartyPart1.DataBind()

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
        GridViewAllPartyPart1.DataSource = arr
        GridViewAllPartyPart1.DataBind()
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
        textConsingee.Enabled = pEnable
        textLot.Enabled = pEnable
        textHealthCertNo.Enabled = pEnable
        texthealthDate.Enabled = pEnable
        textExcSealingRpt.Enabled = pEnable
        textLInvoiceNo.Enabled = pEnable
        textLInvDate.Enabled = pEnable
        textSbDate.Enabled = pEnable
        textCustomHandOver.Enabled = pEnable
        textLineHandOver.Enabled = pEnable
        textSbillRcvd.Enabled = pEnable
        textCartons.Enabled = pEnable
        textNetWt.Enabled = pEnable
        textGrossWt.Enabled = pEnable
        textTareWeight.Enabled = pEnable
        textShipmentType.Enabled = pEnable
        textForValueInr.Enabled = pEnable
        textExRate.Enabled = pEnable
        textFobInUsd.Enabled = pEnable
        textCnfInUsd.Enabled = pEnable
        textUnits.Enabled = pEnable
        textCountry.Enabled = pEnable
        textRegion.Enabled = pEnable
        textCfs.Enabled = pEnable
        textCha.Enabled = pEnable
        textAccont.Enabled = pEnable

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
        pAllPartyAccount.ConsingeeName = textConsingee.Text
        pAllPartyAccount.Lot = textLot.Text
        pAllPartyAccount.HealthCertificateNo = textHealthCertNo.Text
        pAllPartyAccount.HealthCertificateDate = texthealthDate.Text
        pAllPartyAccount.SelfExcise = textExcSealingRpt.Text
        pAllPartyAccount.LinerInvNo = textLInvoiceNo.Text
        pAllPartyAccount.LinerInvDate = textLInvDate.Text
        pAllPartyAccount.SbDate = textSbDate.Text
        pAllPartyAccount.CustomsHandoverDate = textCustomHandOver.Text
        pAllPartyAccount.LineHandoverDate = textLineHandOver.Text
        pAllPartyAccount.SbReceived = textSbillRcvd.Text
        pAllPartyAccount.Cartons = textCartons.Text
        pAllPartyAccount.NetWt = textNetWt.Text
        pAllPartyAccount.GrossWt = textGrossWt.Text
        pAllPartyAccount.TareWt = textTareWeight.Text
        pAllPartyAccount.ShipmentType = textShipmentType.Text
        pAllPartyAccount.FobValueInr = textForValueInr.Text
        pAllPartyAccount.ExRate = textExRate.Text
        pAllPartyAccount.FobValueUsd = textFobInUsd.Text
        pAllPartyAccount.CnfUsd = textCnfInUsd.Text
        pAllPartyAccount.Units = textUnits.Text
        pAllPartyAccount.Country = textCountry.Text
        pAllPartyAccount.Region = textRegion.Text
        pAllPartyAccount.CFS = textCfs.Text
        pAllPartyAccount.Cha = textCha.Text
        pAllPartyAccount.PdaAccount = textAccont.Text

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
    Protected Sub GridViewAllPartyPart1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewAllPartyPart1.RowCommand

        If e.CommandName.Equals("part2") Then
            Dim ContNo As String = e.CommandArgument
            Dim pAllPartyAccount As New AllPartyAccount
            pAllPartyAccount.ContNo = ContNo
            pAllPartyAccount = AllPartyAccount.ReturnAllPartyAccountPart2(pAllPartyAccount)
            hdnContNo.Value = ContNo
            textConsingee.Text = pAllPartyAccount.ConsingeeName
            textLot.Text = pAllPartyAccount.Lot
            textHealthCertNo.Text = pAllPartyAccount.HealthCertificateNo
            texthealthDate.Text = pAllPartyAccount.HealthCertificateDate
            textExcSealingRpt.Text = pAllPartyAccount.SelfExcise
            textLInvoiceNo.Text = pAllPartyAccount.LinerInvNo
            textLInvDate.Text = pAllPartyAccount.LinerInvDate
            textSbDate.Text = pAllPartyAccount.SbDate
            textCustomHandOver.Text = pAllPartyAccount.CustomsHandoverDate
            textLineHandOver.Text = pAllPartyAccount.LineHandoverDate
            textSbillRcvd.Text = pAllPartyAccount.SbReceived
            textCartons.Text = pAllPartyAccount.Cartons
            textNetWt.Text = pAllPartyAccount.NetWt
            textGrossWt.Text = pAllPartyAccount.GrossWt
            textTareWeight.Text = pAllPartyAccount.TareWt
            textShipmentType.Text = pAllPartyAccount.ShipmentType
            textForValueInr.Text = pAllPartyAccount.FobValueInr
            textExRate.Text = pAllPartyAccount.ExRate
            textFobInUsd.Text = pAllPartyAccount.FobValueUsd
            textCnfInUsd.Text = pAllPartyAccount.CnfUsd
            textUnits.Text = pAllPartyAccount.Units
            textCountry.Text = pAllPartyAccount.Country
            textRegion.Text = pAllPartyAccount.Region
            textCfs.Text = pAllPartyAccount.CFS
            textCha.Text = pAllPartyAccount.Cha
            textAccont.Text = pAllPartyAccount.PdaAccount

            Dim aa As Boolean = True
            manageUserControl(aa)

            'Dim selectedRow As GridViewRow = DirectCast(DirectCast(e.CommandSource, ImageButton).NamingContainer, GridViewRow)
            'Dim RowIndexx As Integer = Convert.ToInt32(selectedRow.RowIndex)
            'GridViewAllPartyPart1.Rows(RowIndexx).BackColor = System.Drawing.Color.Blue
        End If
        'btnAdd.Visible = False
    End Sub
    Protected Sub GridViewAllPartyPart1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewAllPartyPart1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            'Dim lblblsrn As Label = GridViewAllPartyPart1.FindControl("lblsrn")
            Dim lblblsrn As Label = DirectCast(e.Row.FindControl("lblsrn"), Label)
            'e.Row.Cells(1).Text = intCounter
            lblblsrn.Text = intCounter.ToString()
        End If
    End Sub

    Private Shared Function ReturnObjectValues(ByVal dbr As OleDbDataReader, ByVal pAllPartyAccount As AllPartyAccount) As AllPartyAccount
        Throw New NotImplementedException
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pAllPartyAccount As AllPartyAccount = ReturnObject()
        AllPartyAccount.UpdatePart2(pAllPartyAccount)

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

    Sub ClearText()

        textConsingee.Text = ""
        textLot.Text = ""
        textHealthCertNo.Text = ""
        texthealthDate.Text = ""
        textExcSealingRpt.Text = ""
        textLInvoiceNo.Text = ""
        textLInvDate.Text = ""
        textSbDate.Text = ""
        textCustomHandOver.Text = ""
        textLineHandOver.Text = ""
        textSbillRcvd.Text = ""
        textCartons.Text = ""
        textNetWt.Text = ""
        textGrossWt.Text = ""
        textTareWeight.Text = ""
        textShipmentType.Text = ""
        textForValueInr.Text = ""
        textExRate.Text = ""
        textFobInUsd.Text = ""
        textCnfInUsd.Text = ""
        textUnits.Text = ""
        textCountry.Text = ""
        textRegion.Text = ""
        textCfs.Text = ""
        textCha.Text = ""
        textAccont.Text = ""
    End Sub
End Class
