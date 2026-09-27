Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.DataTable
Imports System.Xml

Partial Class Reports_Fleet_MovementHistoryReportNew
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        lblScreenTitle.Text = Session.Item("Title")
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvMovementHistory.DataSource = Nothing
            gvMovementHistory.DataBind()
            tblReport.Visible = False
            tblReporTNew.Visible = False
            btnSearchContainer.Visible = False
            btnDisplay.Visible = False
            lblScreenTitle.Text = Session.Item("Title")
        End If
    End Sub


    'Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    gvMovementHistory.DataSource = Nothing
    '    gvMovementHistory.DataBind()
    '    tblReport.Visible = False
    '    If textContNo.Text.Trim = Nothing Then
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Container Number.")
    '        Functions.ControlFocus(textContNo)
    '        Return
    '    End If
    '    lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
    '    Dim strpParms As String = ""
    '    'strpParms &= Session.Item("LoginTerminal")
    '    strpParms &= ",'" & textContNo.Text & "'"
    '    Try
    '        Dim dbr As OleDb.OleDbDataReader
    '        Dim db As New DBConnect
    '        tblReport.Visible = True
    '        If rbContainer.Checked = True Then
    '            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_NEW", strpParms)
    '            Dim pContainerQueryReport As New AllPartyAccount
    '            pContainerQueryReport.ContNo = textContNo.Text
    '            AllPartyAccount.ReturnAllPartyAccountPart2(pContainerQueryReport)
    '            textSize.Text = pContainerQueryReport.ContSize
    '            textContType.Text = pContainerQueryReport.ContType
    '        Else
    '            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_NEW", ",'" & textContNo.Text.Trim & "'")
    '            Dim pContainerQueryReport As New AllPartyAccount
    '            pContainerQueryReport.ContNo = textContNo.Text.Trim
    '            AllPartyAccount.ReturnAllPartyAccountPart2(pContainerQueryReport)
    '            textSize.Text = pContainerQueryReport.ContSize
    '            textContType.Text = pContainerQueryReport.ContType


    '        End If
    '        'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_NEW", strpParms)
    '        gvMovementHistory.DataSource = dbr
    '        gvMovementHistory.DataBind()
    '        If dbr.HasRows Then
    '            Prepare(True)
    '        Else
    '            tblReport.Visible = False
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
    '            Prepare(False)
    '        End If
    '        dbr.Close()
    '        db.CloseDB()
    '    Catch ex As Exception
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
    '    End Try
    'End Sub

    Sub Prepare(ByVal pEnable As Boolean)
        textContType.Visible = pEnable
        textSize.Visible = pEnable
        lblrContSize.Visible = pEnable
        lblrContType.Visible = pEnable
        tblReport.Visible = True
    End Sub

    Protected Sub gvContQuery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovementHistory.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub

    Protected Sub gvContQuerySummary_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovementHistoryReportNew.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub rbContainer_CheckedChanged(sender As Object, e As EventArgs) Handles rbContainer.CheckedChanged
        If rbContainer.Checked = True Then
            btnSearchContainer.Visible = False
            btnDisplay.Visible = True
            tblReport.Visible = False
            tblReporTNew.Visible = False


        End If
    End Sub

    Protected Sub rbInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles rbInvoice.CheckedChanged
        If rbInvoice.Checked = True Then
            btnSearchContainer.Visible = True
            btnDisplay.Visible = False
            textContNo.Text = ""
            textSize.Text = ""
            textContType.Text = ""
        End If
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvMovementHistory.DataSource = Nothing
        gvMovementHistory.DataBind()
        tblReport.Visible = False
        If textContNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Container Number.")
            Functions.ControlFocus(textContNo)
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strpParms As String = ""
        'strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textContNo.Text & "'"
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            tblReport.Visible = True
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_PK", strpParms)
            gvMovementHistory.DataSource = dbr
            gvMovementHistory.DataBind()
            If dbr.HasRows Then

                Prepare(True)
                Dim pContainerQueryReport As New AllPartyAccount
                pContainerQueryReport.ContNo = textContNo.Text
                AllPartyAccount.ReturnAllPartyAccountPart2(pContainerQueryReport)
                textSize.Text = pContainerQueryReport.ContSize
                textContType.Text = pContainerQueryReport.ContType
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
                Prepare(False)
            End If
            dbr.Close()
            db.CloseDB()
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End Try
    End Sub

    Protected Sub btnSearchContainer_Click(sender As Object, e As EventArgs) Handles btnSearchContainer.Click
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvMovementHistoryReportNew.DataSource = Nothing
        gvMovementHistoryReportNew.DataBind()
        tblReport.Visible = False
        If textContNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Container Number.")
            Functions.ControlFocus(textContNo)
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strpParms As String = ""
        'strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textContNo.Text & "'"
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            tblReporTNew.Visible = True
            tblReport.Visible = False

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_SUMMARY", strpParms)
            Dim pContainerQueryReport As New AllPartyAccount
            pContainerQueryReport.ContNo = textContNo.Text
            AllPartyAccount.ReturnAllPartyAccountPart2(pContainerQueryReport)
            textSize.Text = pContainerQueryReport.ContSize
            textContType.Text = pContainerQueryReport.ContType
            gvMovementHistoryReportNew.DataSource = dbr
            gvMovementHistoryReportNew.DataBind()

            If dbr.HasRows Then
                Prepare(True)
            Else
                tblReporTNew.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
                Prepare(False)
            End If
            dbr.Close()
            db.CloseDB()
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End Try
    End Sub

    Protected Sub OnClickHandlerStatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Dim pCrNote As New ImpInvoice

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvMovementHistory.DataSource = Nothing
        gvMovementHistory.DataBind()
        tblReport.Visible = False

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strpParms As String = ""
        strpParms &= ",'" & lnk.Text & "'"
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            tblReport.Visible = True

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_NEW", strpParms)
                Dim pContainerQueryReport As New AllPartyAccount
                pContainerQueryReport.ContNo = textContNo.Text
                AllPartyAccount.ReturnAllPartyAccountPart2(pContainerQueryReport)
                textSize.Text = pContainerQueryReport.ContSize
            textContType.Text = pContainerQueryReport.ContType
            gvMovementHistory.DataSource = dbr
            gvMovementHistory.DataBind()
            Prepare(True)

            dbr.Close()
            db.CloseDB()
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End Try
    End Sub
End Class