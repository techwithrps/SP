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

            lblScreenTitle.Text = Session.Item("Title")
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
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_HISTORY_NEW", strpParms)
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

    Sub Prepare(ByVal pEnable As Boolean)
        textContType.Visible = pEnable
        textSize.Visible = pEnable
        'textHandlingMode.Visible = pEnable
        'lblHandlingMode.Visible = pEnable
        'textDocType.Visible = pEnable
        'textTerminal.Visible = pEnable
        lblrContSize.Visible = pEnable
        lblrContType.Visible = pEnable
        'lblDocType.Visible = pEnable
        'lblTerminal.Visible = pEnable
        tblReport.Visible = True
    End Sub

    Protected Sub gvContQuery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovementHistory.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class