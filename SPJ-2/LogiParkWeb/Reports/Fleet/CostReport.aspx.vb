Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_CostReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim strCurrentDate As String
            Dim strFromDate As String
            Dim strToDate As String
            textFromDate.Text = Format(Now, "dd/MM/yyyy")
            textToDate.Text = Format(Now, "dd/MM/yyyy")
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
            strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= ",'" & textFromDate.Text & "'"
            strpParms &= ",'" & textToDate.Text & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_COST_REPORT", strpParms)
            gvtripPendencyList.DataSource = dbr
            gvtripPendencyList.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
        End If

    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date

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

        ' lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_COST_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            'TextTotal.Text = e.Row.Cells(15).Text + Total
            'Total = TextTotal.Text
        End If

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
            Dim strFileName As String = "CostReport.csv"
            Dim attachment As String = "attachment; Filename=" & strFileName
            Dim strb As New StringBuilder
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")
            strb.Append(lblScreenTitle.Text & vbCrLf)

            ' strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
            'strb.Append(lblDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            Dim strContentHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContentHeader = "Sr No" & strComa & "BL No" & strComa & "Liner Inv No" & strComa & "Liner Inv Date" & strComa & _
            "Shipping Line" & strComa & "Service" & strComa & "Cont No" & strComa & "Base Rate" & strComa & "Tax %" & strComa & _
            "Tax Amount" & strComa & "Total" & strComa & "Ex Rate"
            strb.Append(strContentHeader & vbCrLf)
            If gvtripPendencyList.Rows.Count > 0 Then
                For Each r As GridViewRow In gvtripPendencyList.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ") & strComa)
                        Else
                            strb.Append(" " & strComa)
                        End If
                    Next
                    strb.Append(vbCrLf)
                Next
            End If
            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
