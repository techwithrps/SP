Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_RateTariffReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim intCounterDesc As Long = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()

            gvRateMaster.DataSource = Nothing
            gvRateMaster.DataBind()
            tblReport.Visible = False
            tblRateDtls.Visible = False
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
    Sub ListControlDataBind()

        Dim pCusType As New CustomerType
        pCusType.TerminalId = Session.Item("LoginTerminal")
        lstCustomerType.DataSource = CustomerType.ReturnCustomerTypeList(pCusType)
        lstCustomerType.DataTextField = "CustomerTypeName"
        lstCustomerType.DataValueField = "CustomerTypeCode"
        lstCustomerType.DataBind()
        lstCustomerType.Items.Insert(0, (New ListItem("----All----", "")))
        lstCustomerType.SelectedValue = ""

        Dim pCustomer As New ExtCustomerMaster
        pCustomer.TerminalId = Session.Item("LoginTerminal")

        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAll(pCustomer)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Insert(0, (New ListItem("----All----", "0")))
    End Sub
    Protected Sub lstCustomerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomerType.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pCustomer As New ExtCustomerMaster
        pCustomer.TerminalId = Session.Item("LoginTerminal")

        lstCustomer.DataSource = ExtCustomerMaster.ReturnCustomerMasterListAllByCustomertypeCode(pCustomer, lstCustomerType.SelectedValue)
        lstCustomer.DataTextField = "CustomerName"
        lstCustomer.DataValueField = "CustomerId"
        lstCustomer.DataBind()
        lstCustomer.Items.Insert(0, (New ListItem("----All----", "0")))
        If lstCustomerType.SelectedValue = "" Then
            lstCustomer.Enabled = False
            lstCustomer.SelectedValue = 0
        Else
            lstCustomer.Enabled = True
            lstCustomer.SelectedValue = 0
        End If
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        tblRateDtls.Visible = False
        gvRateMaster.DataSource = Nothing
        gvRateMaster.DataBind()
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
        strpParms &= ",'" & lstCustomerType.SelectedValue & "'"
        strpParms &= "," & lstCustomer.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RATE_MASTER", strpParms)
        gvRateMaster.DataSource = dbr
        gvRateMaster.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvRateMaster_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRateMaster.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub
    Protected Sub gvRateMaster_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        gvRateDetails.DataSource = Nothing
        gvRateDetails.DataBind()
        Dim p1 As String = Nothing
        Dim currentRowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        p1 = CType(gvRateMaster.Rows(currentRowIndex).Cells(0).FindControl("hdnRateId"), HiddenField).Value.ToString()
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & p1
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RATE_DETAILS", strpParms)
        gvRateDetails.DataSource = dbr
        gvRateDetails.DataBind()
        tblRateDtls.Visible = True
        For Each row As GridViewRow In gvRateMaster.Rows
            If row.RowIndex = currentRowIndex Then
                row.BackColor = Color.AliceBlue
            Else
                row.BackColor = Color.White
            End If
        Next
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub gvRateDetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRateDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounterDesc = intCounterDesc + 1
            e.Row.Cells(0).Text = intCounterDesc
           
        End If
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
            Dim strFileName As String = "Rate Details.csv"
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
            strContentHeader = lblrSrNo.Text & strComa & lblRateId.Text & strComa & lblSize.Text & strComa & lblType.Text & strComa & lblStatus.Text & strComa &
            lblDocType.Text & strComa & lblFrom.Text & strComa & lblTo.Text & strComa & lblHandover.Text & strComa & lblCommodity.Text & strComa &
            lblRangeFrom.Text & strComa & lblRangeTo.Text & strComa & lblRate.Text
            strb.Append(strContentHeader & vbCrLf)
            If gvRateDetails.Rows.Count > 0 Then
                For Each r As GridViewRow In gvRateDetails.Rows
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


    Protected Sub btnExcelAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcelAll.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        tblRateDtls.Visible = False
        gvRateMaster.DataSource = Nothing
        gvRateMaster.DataBind()
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
        strpParms &= ",'" & lstCustomerType.SelectedValue & "'"
        strpParms &= "," & lstCustomer.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RATE_DETAILS_ALL", strpParms)
        GridView1.DataSource = dbr
        GridView1.DataBind()
        If dbr.HasRows Then
            Try
                Dim strComa = ","
                Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
                Dim strFileName As String = "Rate Details All.csv"
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
                strContentHeader = "Sr No." & strComa & lblRateIdd.Text & strComa & "Service" & strComa & "Customer" & strComa & lblSize.Text & strComa & lblType.Text & strComa & lblStatus.Text & strComa &
                lblDocType.Text & strComa & lblFrom.Text & strComa & lblTo.Text & strComa & lblHandover.Text & strComa & lblCommodity.Text & strComa &
                lblRangeFrom.Text & strComa & lblRangeTo.Text & strComa & lblRate.Text
                strb.Append(strContentHeader & vbCrLf)
                If GridView1.Rows.Count > 0 Then
                    For Each r As GridViewRow In GridView1.Rows
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
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
