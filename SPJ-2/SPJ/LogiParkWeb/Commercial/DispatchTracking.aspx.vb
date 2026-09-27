Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit

Partial Class Commercial_DispatchTracking
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrCustomerId As ArrayList
    Dim arrCustomerName As ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrTerminalId.Count - 1
                lst.Items.Add(New ListItem(arrTerminalName(i), arrTerminalId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Function GetDateTime(strDate As String) As DateTime
        Dim strday, strtime, arrdate, Day, Month, Year, arrtime, Hour, Minute, FinalDate

        Dim parry = strDate.Split(" ")
        If parry.Length = 2 Then
            strday = parry(0)
            strtime = parry(1)

            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            arrtime = strtime.Split(":")
            Hour = arrtime(0)
            Minute = arrtime(1)
        ElseIf parry.Length = 1 Then
            strday = parry(0)
            arrdate = strday.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
            Hour = 0
            Minute = 0
        End If
        FinalDate = New DateTime(Year, Month, Day, Hour, Minute, 0)
        Return FinalDate
    End Function

    Sub prepareTerminalData()
        Try
            arrTerminalId = New ArrayList
            arrTerminalName = New ArrayList
            Dim pTerminalMaster As New TerminalMaster
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                arrTerminalId.Add(obj.TerminalId)
                arrTerminalName.Add(obj.TerminalName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG_NO_OBJ.SP_DISPATCH_TRACKING", strpParms)
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
    Sub lstlinebind()
        Try
            arrCustomerId = New ArrayList
            arrCustomerId = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerId.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            prepareTerminalData()
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= ",'" & Session.Item("CompanyId") & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG_NO_OBJ.SP_DISPATCH_TRACKING", strpParms)
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
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
        End If

    End Sub
    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvtripPendencyList.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                End If
            Next
        End If
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnJobNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnJobNo"), HiddenField)
                    Dim TextFileSendBilling As TextBox = TryCast(row.Cells(0).FindControl("TextFileSendBilling"), TextBox)
                    Dim textSendingDispatch As TextBox = TryCast(row.Cells(0).FindControl("textSendingDispatch"), TextBox)
                    Dim textFileRecDate As TextBox = TryCast(row.Cells(0).FindControl("textFileRecDate"), TextBox)
                    Dim textSoftCopyDate As TextBox = TryCast(row.Cells(0).FindControl("textSoftCopyDate"), TextBox)
                    Dim textHardCopyDate As TextBox = TryCast(row.Cells(0).FindControl("textHardCopyDate"), TextBox)
                    Dim lblRemarks As TextBox = TryCast(row.Cells(0).FindControl("lblRemarks"), TextBox)
                    Dim textFilereceived As TextBox = TryCast(row.Cells(0).FindControl("textFilereceived"), TextBox)


                    If Not String.IsNullOrEmpty(TextFileSendBilling.Text) Then
                        TextFileSendBilling.Enabled = False
                    End If
                    If Not String.IsNullOrEmpty(textSendingDispatch.Text) Then
                        textSendingDispatch.Enabled = False
                    End If
                    If Not String.IsNullOrEmpty(textFileRecDate.Text) Then
                        textFileRecDate.Enabled = False
                    End If
                    If Not String.IsNullOrEmpty(textSoftCopyDate.Text) Then
                        textSoftCopyDate.Enabled = False
                    End If
                    If Not String.IsNullOrEmpty(textHardCopyDate.Text) Then
                        textHardCopyDate.Enabled = False
                    End If

                    Dim clFileSendBilling = TryCast(row.Cells(0).FindControl("clFileSendBilling"), CalendarExtender)
                    clFileSendBilling.StartDate = DateTime.Now.Date
                    clFileSendBilling.EndDate = DateTime.Now.Date
                    Dim cltSendingDispatch = TryCast(row.Cells(0).FindControl("cltSendingDispatch"), CalendarExtender)
                    cltSendingDispatch.StartDate = DateTime.Now.Date
                    cltSendingDispatch.EndDate = DateTime.Now.Date
                    Dim cltFilereceived = TryCast(row.Cells(0).FindControl("cltFilereceived"), CalendarExtender)
                    cltFilereceived.StartDate = DateTime.Now.Date
                    cltFilereceived.EndDate = DateTime.Now.Date

                    Dim cltFileRecDate = TryCast(row.Cells(0).FindControl("cltFileRecDate"), CalendarExtender)
                    cltFileRecDate.StartDate = DateTime.Now.Date
                    cltFileRecDate.EndDate = DateTime.Now.Date
                    Dim cltSoftCopyDate = TryCast(row.Cells(0).FindControl("cltSoftCopyDate"), CalendarExtender)
                    cltSoftCopyDate.StartDate = DateTime.Now.Date
                    cltSoftCopyDate.EndDate = DateTime.Now.Date
                    Dim cltHardCopyDate = TryCast(row.Cells(0).FindControl("cltHardCopyDate"), CalendarExtender)
                    cltHardCopyDate.StartDate = DateTime.Now.Date
                    cltHardCopyDate.EndDate = DateTime.Now.Date
                    Dim DAY As Long = 0
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT nvl(JOB_NO,0)JOB_NO FROM ALL_PARTY_ACCOUNT WHERE JOB_NO='" & hdnJobNo.Value & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                End If
            End If
        Next
        Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    row.Cells(i).FindControl("lblFileSendBilling").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSendingDispatch").Visible = Not isChecked
                    row.Cells(i).FindControl("lblFileRecDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSoftCopyDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblHardCopyDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRemarks").Visible = Not isChecked
                    row.Cells(i).FindControl("lblFilereceived").Visible = Not isChecked


                    If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
                    End If
                    If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    End If
                    If isChecked AndAlso Not isUpdateVisible Then
                        isUpdateVisible = True
                    End If
                    If Not isChecked Then
                        chkAll.Checked = False
                    End If
                Next
            End If
        Next
        Button3.Visible = isUpdateVisible
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnJobNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnJobNo"), HiddenField)
                    Dim TextFileSendBilling As TextBox = TryCast(row.Cells(0).FindControl("TextFileSendBilling"), TextBox)
                    Dim textSendingDispatch As TextBox = TryCast(row.Cells(0).FindControl("textSendingDispatch"), TextBox)
                    Dim textFileRecDate As TextBox = TryCast(row.Cells(0).FindControl("textFileRecDate"), TextBox)
                    Dim textSoftCopyDate As TextBox = TryCast(row.Cells(0).FindControl("textSoftCopyDate"), TextBox)
                    Dim textHardCopyDate As TextBox = TryCast(row.Cells(0).FindControl("textHardCopyDate"), TextBox)
                    Dim TextRemarks As TextBox = TryCast(row.Cells(0).FindControl("TextRemarks"), TextBox)
                    Dim textFilereceived As TextBox = TryCast(row.Cells(0).FindControl("textFilereceived"), TextBox)
                    Dim p As New DispatchTracking
                    p.SendingDate = TextFileSendBilling.Text
                    p.SendingDispatch = textSendingDispatch.Text
                        p.FileRecDate = textFileRecDate.Text
                        p.SoftCopyDate = textSoftCopyDate.Text
                    p.HardCopyDate = textHardCopyDate.Text
                    p.FileReceivedDispatch = textFilereceived.Text
                    p.Remarks = TextRemarks.Text
                    p.CreatedBy = Session.Item("LoginUser")
                    p.JobNo = hdnJobNo.Value


                    If Not String.IsNullOrEmpty(TextFileSendBilling.Text) Then
                            If GetDateTime(TextFileSendBilling.Text.Trim()) >= DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                                Functions.ControlFocus(TextFileSendBilling)
                                Return
                            End If
                        End If
                    If Not String.IsNullOrEmpty(textFilereceived.Text) Then
                        If GetDateTime(textFilereceived.Text.Trim()) >= DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                            Functions.ControlFocus(textFilereceived)
                            Return
                        End If
                    End If
                    If Not String.IsNullOrEmpty(textSendingDispatch.Text) Then
                        If GetDateTime(textSendingDispatch.Text.Trim()) >= DateTime.Now Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                            Functions.ControlFocus(textSendingDispatch)
                            Return
                        End If
                    End If
                    If Not String.IsNullOrEmpty(textFileRecDate.Text) Then
                            If GetDateTime(textFileRecDate.Text.Trim()) >= DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                                Functions.ControlFocus(textFileRecDate)
                                Return
                            End If
                        End If
                        If Not String.IsNullOrEmpty(textSoftCopyDate.Text) Then
                            If GetDateTime(textSoftCopyDate.Text.Trim()) >= DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                                Functions.ControlFocus(textSoftCopyDate)
                                Return
                            End If
                        End If
                        DispatchTracking.Update(p)
                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                    End If
                End If
        Next
        Button4.Visible = False
        BindData()
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
