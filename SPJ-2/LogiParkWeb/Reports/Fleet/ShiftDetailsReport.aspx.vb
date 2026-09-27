Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_ShiftDetailsReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            gvJODetails.DataSource = Nothing
            gvJODetails.DataBind()
            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
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
        Dim strFromDate As String
        Dim strToDate As String

        gvJODetails.DataSource = Nothing
        gvJODetails.DataBind()
        tblReport.Visible = False
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

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        lblDate.Text = lblScreenTitle.Text & " From " & " " & strFromDate & " To " & strToDate

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        'Dim longhow As Int32
        'longhow = Date.Compare(strToDate, strFromDate)
        'If longhow < 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Date Must Be Less Than To Date")
        '    Functions.ControlFocus(textToDate)
        '    Return
        'End If
        'longhow = Date.Compare(strCurrentDate, strToDate)
        'If longhow < 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date Must Be Less Than Current Date")
        '    Functions.ControlFocus(textToDate)
        '    Return
        'End If

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_SHIFT_DTLS_REPORT", strpParms)
        gvJODetails.DataSource = dbr
        gvJODetails.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvJoDe_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvJODetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub

    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Try

    '        Dim strComa = ","
    '        Dim strFileName As String = "Cargo Gate In.csv"
    '        Dim attachment As String = "attachment; filename=" & strFileName
    '        Dim strb As New StringBuilder()
    '        Response.Clear()
    '        Response.ClearHeaders()
    '        Response.ClearContent()
    '        Response.AddHeader("content-disposition", attachment)
    '        Response.ContentType = "text/csv"
    '        Response.AddHeader("Pragma", "public")

    '        strb.Append(lblScreenTitle.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)

    '        strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
    '        strb.Append(lblDate.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)


    '        Dim strContHeader As String = Nothing
    '        Dim strSummaryHeader As String = Nothing
    '        strContHeader = lblrSrNo.Text & strComa & lblrContNo.Text & strComa & lblrSize.Text & strComa & _
    '               lblrPowerOnDate.Text & strComa & lblrPowerOffDate.Text & strComa & lblSurveyor.Text
    '        strb.Append(strContHeader & vbCrLf)

    '        If gvPowerOnOff.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvPowerOnOff.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                        strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
    '                    Else
    '                        strb.Append(" " & strComa)
    '                    End If
    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If

    '        Response.Write(strb.ToString)
    '        Response.Flush()
    '        Response.End()
    '    Catch ex As Exception

    '    End Try

    'End Sub


    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
