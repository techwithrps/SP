Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_HandoverUpdation
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
    Protected Sub preparePort(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", ""))
            For i As Integer = 0 To arrPortId.Count - 1
                lst.Items.Add(New ListItem(arrPortName(i), arrPortId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub preparePortData()
        Try
            arrPortId = New ArrayList
            arrPortName = New ArrayList
            Dim pPortMaster As New HandoverReason
            For Each obj As HandoverReason In HandoverReason.ReturnHandoverReasonList(pPortMaster)
                arrPortId.Add(obj.HandoverReason)
                arrPortName.Add(obj.HandoverReasonName)
            Next
        Catch ex As Exception

        End Try
    End Sub
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
        '    Dim arrdate, Day, Month, Year, FinalDate

        '    If strDate <> Nothing And strDate <> "" Then
        '        Dim parry = strDate.Trim()
        '        arrdate = parry.Split("/")
        '        Day = arrdate(0)
        '        Month = arrdate(1)
        '        Year = arrdate(2)
        '    End If
        '    FinalDate = New DateTime(Year, Month, Day, 0, 0, 0)
        '    Return FinalDate
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
        preparePortData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        ' strpParms &= 
        strpParms &= "," & 0
        strpParms &= "," & 0 & ",'','','P'"



        'Dim strpParms As String = ""
        'strpParms &= Session.Item("LoginTerminal")
        '' strpParms &= LstLine.SelectedValue
        ''prepareTerminalData()
        'strpParms &= "," & lstPol.SelectedValue
        'strpParms &= "," & lstPod.SelectedValue & ",'','','P'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PENDING_HAND_UPDATION", strpParms)
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
            preparePortData()
            'ListControlDataBind()
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            ' strpParms &= 
            strpParms &= "," & 0
            strpParms &= "," & 0 & ",'','','P'"
            'strpParms &= ",'" & textFromDate.Text & "'"
            'strpParms &= ",'" & textToDate.Text & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_PENDING_HAND_UPDATION", strpParms)
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


    'Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim isUpdateVisible As Boolean = False
    '    Dim chk As CheckBox = TryCast(sender, CheckBox)
    '    If chk.ID = "chkAll" Then
    '        For Each row As GridViewRow In gvtripPendencyList.Rows
    '            If row.RowType = DataControlRowType.DataRow Then
    '                row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
    '            End If
    '        Next
    '    End If
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
    '                Dim TxtHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtHandover"), TextBox)
    '                Dim lblICDInDate As Label = TryCast(row.Cells(0).FindControl("lblICDInDate"), Label)
    '                Dim TextLineSeal As TextBox = TryCast(row.Cells(0).FindControl("TextLineSeal"), TextBox)
    '                Dim TextCustom As TextBox = TryCast(row.Cells(0).FindControl("TextCustom"), TextBox)
    '                Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
    '                Dim TextRemarks As TextBox = TryCast(row.Cells(0).FindControl("TextRemarks"), TextBox)

    '                Dim DAY As Long = 0
    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = "SELECT nvl(POL_ID,0),POL FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader
    '                ada.Read()
    '            End If
    '        End If
    '    Next
    '    Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
    '    chkAll.Checked = True
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                row.Cells(i).FindControl("lblHandoverDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblHoldremark").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblCustom").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblLineSeal").Visible = Not isChecked

    '                If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                    row.Cells(i).FindControl("lblRemarks").Visible = Not isChecked
    '                End If
    '                'If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                '    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                'End If
    '                If isChecked AndAlso Not isUpdateVisible Then
    '                    isUpdateVisible = True
    '                End If
    '                If Not isChecked Then
    '                    chkAll.Checked = False
    '                End If
    '            Next
    '        End If
    '    Next
    '    Button3.Visible = isUpdateVisible
    'End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TxtHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtHandover"), TextBox)
                    Dim TextLineSeal As TextBox = TryCast(row.Cells(0).FindControl("TextLineSeal"), TextBox)
                    Dim TextCustom As TextBox = TryCast(row.Cells(0).FindControl("TextCustom"), TextBox)
                    Dim lblICDInDate As Label = TryCast(row.Cells(0).FindControl("lblICDInDate"), Label)
                    Dim lblSBNo As Label = TryCast(row.Cells(0).FindControl("lblSBNo"), Label)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                    Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
                    Dim lblBookingNo As Label = TryCast(row.Cells(0).FindControl("lblBookingNo"), Label)
                    Dim TextRemarks As TextBox = TryCast(row.Cells(0).FindControl("TextRemarks"), TextBox)
                    Dim Remark As Long = 0
                    Dim pAllPartyAccount As New AllPartyAccount
                    pAllPartyAccount.MtyContId = hdnMTY_CONT_ID.Value
                    pAllPartyAccount = AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
                    'If Not String.IsNullOrEmpty(TxtHandover.Text.Trim) Then
                    '    If TextLineSeal.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Line Seal No.")
                    '        Functions.ControlFocus(TextLineSeal)
                    '        Return
                    '    End If
                    'End If
                    Try
                        Remark = LstRemark.SelectedValue
                    Catch ex As Exception
                        Remark = 0
                    End Try

                    'If Not String.IsNullOrEmpty(TxtHandover.Text.Trim) Then
                    '    If TextCustom.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Custom Seal No.")
                    '        Functions.ControlFocus(TextCustom)
                    '        Return
                    '    End If
                    'End If

                    '.....
                    'If Not String.IsNullOrEmpty(LstRemark.SelectedItem.Text) Then
                    '    If TxtHandover.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Pending Reason.")
                    '        Functions.ControlFocus(LstRemark)
                    '        Return
                    '    End If
                    'End If
                    '.....

                    'If Not String.IsNullOrEmpty(LstRemark.SelectedItem.Text) Then
                    '    If TextRemarks.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Pending Reason or Remarks")
                    '        Functions.ControlFocus(TextRemarks)
                    '        Return
                    '    End If
                    'End If

                    '.......
                    'If Not String.IsNullOrEmpty(TextRemarks.Text) Then
                    '    If LstRemark.SelectedItem.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Pending Reason.")
                    '        Functions.ControlFocus(TextRemarks)
                    '        Return
                    '    End If
                    'End If
                    'If TextRemarks.Text = "" Then
                    '    If Not String.IsNullOrEmpty(TxtHandover.Text.Trim) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Handover Remarks.")
                    '        Functions.ControlFocus(TextRemarks)
                    '        Return
                    '    End If
                    'End If
                    '.......

                    'If Not String.IsNullOrEmpty(TxtHandover.Text) Then
                    '    If GetDateTime(TxtHandover.Text.Trim()) >= DateTime.Now Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the entered Date is less than or equal to the Current Date.")
                    '        Functions.ControlFocus(TxtHandover)
                    '        Return
                    '    End If
                    'End If
                    'Try
                    '    If Not String.IsNullOrWhiteSpace(lblICDInDate.Text) Then
                    '        If GetDateTime(TxtHandover.Text) < GetDateTime(lblICDInDate.Text) Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Handover Date should not be less than ICD In Date.")
                    '            Functions.ControlFocus(TxtHandover)
                    '            Return
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'If Session.Item("LoginTerminal") <> 7 Then
                    '    If Session.Item("LoginTerminal") <> 5 Then
                    '        If Session.Item("LoginTerminal") <> 29 Then
                    '            If Session.Item("LoginTerminal") <> 53 Then
                    '                If pAllPartyAccount.SbNo = Nothing Or pAllPartyAccount.SbDate Is Nothing Then
                    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "This Container EDI Not Updated ")
                    '                    Return
                    '                End If
                    '            End If
                    '        End If
                    '    End If
                    'End If

                    'If Not String.IsNullOrEmpty(TxtHandover.Text.Trim) Then
                    '    If pAllPartyAccount.BookingNo = Nothing Or pAllPartyAccount.BookingDate Is Nothing Or pAllPartyAccount.RequiredVessel Is Nothing Or
                    '        pAllPartyAccount.CurrentEta Is Nothing Or pAllPartyAccount.POL Is Nothing Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Documentation Page not updated ")
                    '        Return
                    '    End If
                    'End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET HAND_UPDATED_ON=SYSDATE, HANDOVER_REMARK='" & TextRemarks.Text.Trim & "',HOLD_REMARK_ID=NVL(" & Remark & ",0),HOLD_REMARK='" & LstRemark.SelectedItem.Text & "', LINE_HANDOVER_DATE=TO_DATE('" & TxtHandover.Text & "','DD/MM/YYYY HH24:MI')  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO_DTLS SET SEAL_NO='" & TextLineSeal.Text.Trim & "', AGENT_SEAL='" & TextCustom.Text.Trim & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd1.ExecuteNonQuery()
                        Dim cmd7 As String
                        cmd7 = " Insert into HANDOVER_UPDATION (H_TRACK_ID, LINE_HANDOVER_DATE,HANDOVER_REMARK,HOLD_REMARK, SEAL_NO , AGENT_SEAL," _
                                & " MTY_CONT_ID, CONT_NO, CREATED_BY, CREATED_ON) " _
                                & " VALUES (H_TRACK_ID.NEXTVAL,NVL(TO_DATE('" & TxtHandover.Text & "','DD/MM/YYYY HH24:MI'),''),nvl('" & TextRemarks.Text & "',''),nvl('" & LstRemark.SelectedItem.Text & "',''),nvl('" & TextLineSeal.Text & "',''),nvl('" & TextCustom.Text & "','')," _
                             & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate)"
                        Dim cmd5 As New OleDbCommand(cmd7, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
                        con.Close()
                    Catch ex As Exception
                    End Try
                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        Button4.Visible = True
        BindData()
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
