
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection
Imports LogiParkLib.LogiParkObjects

Partial Class Reports_AdditionalServices
    Inherits Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvExportBooking.DataSource = Nothing
            gvExportBooking.DataBind()
            tblReport.Visible = False
            textFromDate.Text = Format(Now, "dd/MM/yyyy")
            textToDate.Text = Format(Now, "dd/MM/yyyy")
            'lblScreenTitle.Text = Session.Item("Title")
        End If
    End Sub
    Protected Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        tblReport.Visible = False
        If textFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date.")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date.")
            Functions.ControlFocus(textToDate)
            Return
        End If
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text
        'lblDate.Text = lblScreenTitle.Text & " From " & " " & strFromDate & " To " & strToDate

        Dim strpParms = ""
        strpParms &= Session.Item("LoginTerminal") & ""
        'strpParms &= ",'" & textDocNo.Text & "'"
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"


        Dim dbr As OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_ADDITIONAL_SSR_REPORT", strpParms)
        gvExportBooking.DataSource = dbr
        gvExportBooking.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub

    Protected Sub gvExportBooking_RowDataBound(sender As Object, e As GridViewRowEventArgs) _
    Handles gvExportBooking.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("Home.aspx")
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvExportBooking)
    End Sub
End Class
