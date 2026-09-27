Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit
Imports System.Windows

Partial Class Reports_Fleet_RailOutPending
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Dim arrPodId As ArrayList
    Dim arrPodName As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            prepareTerminalData()
            preparePortData()
            BindData()
        End If
    End Sub
    Private Sub BindData()
        prepareTerminalData()
        preparePortData()
        preparePortDataPOD()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & 0 & ",'','','P',0,0"
        'strpParms &= ",'" & textFromDate.Text & "'"
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RAIL_OUT_PENDING_REPORT", strpParms)
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
        textTrainNO.Text = ""
        textOutDate.Text = ""
        lstcpol.SelectedValue = 0
    End Sub
    Function GetDateTime(strDate As String) As DateTime
        Dim arrdate, Day, Month, Year, FinalDate

        If strDate <> Nothing And strDate <> "" Then
            Dim parry = strDate.Trim()
            arrdate = parry.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
        End If
        FinalDate = New DateTime(Year, Month, Day, 0, 0, 0)
        Return FinalDate
    End Function
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

    Protected Sub preparePort(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
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
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
                arrPortId.Add(obj.PortId)
                arrPortName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub preparePod(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrPodId.Count - 1
                lst.Items.Add(New ListItem(arrPodName(i), arrPodId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub preparePortDataPOD()
        Try
            arrPodId = New ArrayList
            arrPodName = New ArrayList
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterList(pPortMaster)
                arrPodId.Add(obj.PortId)
                arrPodName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            lstCFS.DataTextField = "TerminalName"
            lstCFS.DataValueField = "TerminalId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
            Dim pPortMaster As New PortMaster
            lstPOL.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            lstPOL.DataTextField = "PortName"
            lstPOL.DataValueField = "PortId"
            lstPOL.DataBind()
            lstPOL.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPOL.SelectedValue = 0
            lstcpol.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            lstcpol.DataTextField = "PortName"
            lstcpol.DataValueField = "PortId"
            lstcpol.DataBind()
            lstcpol.Items.Insert(0, (New ListItem("---All---", 0)))
            lstcpol.SelectedValue = 0
            lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            lstPod.DataTextField = "PortName"
            lstPod.DataValueField = "PortId"
            lstPod.DataBind()
            lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPod.SelectedValue = 0
            Dim pCustomerMaster As New CustomerMaster
            lstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            lstLine.DataTextField = "CustomerName"
            lstLine.DataValueField = "CustomerId"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            lstLine.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date
        prepareTerminalData()
        preparePortData()
        ' BindData()

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & lstPOL.SelectedValue & ",'','','P'"
        strpParms &= "," & lstPod.SelectedValue
        strpParms &= "," & lstLine.SelectedValue
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RAIL_OUT_PENDING_REPORT", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
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
            e.Row.Cells(1).Text = intCounter
        End If

    End Sub

    Protected Sub EditAllParty(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvtripPendencyList.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvtripPendencyList.EditIndex = -1
        BindData()
    End Sub
    'Protected Sub AllPartyUpdate(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    '    Dim hdnMTY_CONT_ID As HiddenField = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '    'Dim ddlCFS As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("ddlCFS"), DropDownList)
    '    Dim txtPORT As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtPORT"), TextBox)
    '    Dim txtBL_NO As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtBL_NO"), TextBox)
    '    Dim txtLINE_HANDOVER_DATE As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtLINE_HANDOVER_DATE"), TextBox)
    '    Dim txtPOL As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtPOL"), TextBox)

    '    'If ddlCFS.SelectedValue = 0 Then
    '    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select CFS Terminal")
    '    '    Functions.ControlFocus(ddlCFS)
    '    '    Return
    '    'End If

    '    con = New OleDbConnection(cs)
    '    con.Open()
    '    ' Removed from below cmd statement
    '    'CFS_ID=" & Convert.ToInt32(ddlCFS.SelectedValue) & ",
    '    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET POL='" & txtPORT.Text & "',BOOKING_NO = '" & txtBL_NO.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & txtLINE_HANDOVER_DATE.Text & "','DD/MM/YYYY'),POL = '" & txtPOL.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    cmd.ExecuteNonQuery()
    '    con.Close()
    '    gvtripPendencyList.EditIndex = -1
    '    BindData()
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    'End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        If ValidationCheck() = False Then
            Return
        End If
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    'Dim ddlCFS As DropDownList = TryCast(row.Cells(0).FindControl("ddlCFS"), DropDownList)
                    Dim txtRemark As TextBox = TryCast(row.Cells(0).FindControl("txtRemark"), TextBox)
                    '  Dim txtBooking_NO As TextBox = TryCast(row.Cells(0).FindControl("txtBooking_No"), TextBox)
                    Dim txtLINE_HANDOVER_DATE As TextBox = TryCast(row.Cells(0).FindControl("txtLINE_HANDOVER_DATE"), TextBox)
                    Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
                    Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
                    Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)
                    Dim txtTrainNo As TextBox = TryCast(row.Cells(0).FindControl("txtTrainNo"), TextBox)
                    Dim txtOutDate As TextBox = TryCast(row.Cells(0).FindControl("txtOutDate"), TextBox)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)

                    'Dim TxtTRHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtTRHandover"), TextBox)
                    ' Dim txtWagonNo As TextBox = TryCast(row.Cells(0).FindControl("txtWagonNo"), TextBox)
                    Dim txtETD As TextBox = TryCast(row.Cells(0).FindControl("txtETD"), TextBox)
                    '  Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                    Dim txtREQUIRED_VESSEL As TextBox = TryCast(row.Cells(0).FindControl("txtREQUIRED_VESSEL"), TextBox)

                    'If TxtTRHandover.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill TR Handover.")
                    '    Functions.ControlFocus(TxtTRHandover)
                    '    Return
                    'End If
                    'If Not String.IsNullOrEmpty(txtRemark.Text.Trim) Then
                    '    If txtTrainNo.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Train No.")
                    '        Functions.ControlFocus(txtTrainNo)
                    '        Return
                    '    End If
                    'End If
                    'Try
                    '    If Not String.IsNullOrEmpty(txtRemark.Text.Trim) Then
                    '        If txtOutDate.Text = "" Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Rail Out Date.")
                    '            Functions.ControlFocus(txtOutDate)
                    '            Return
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    Try
                        If GetDateTime(txtETD.Text) > GetDateTime(TxtRequiredETA.Text) Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                  "ETD date should not be greater than ETA date.")
                            Functions.ControlFocus(txtETD)
                            Return
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
                            Dim rr = GetDateTime(txtOutDate.Text.Trim())
                            Dim newDt = rr.AddDays(-3)
                            Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                            If Not String.IsNullOrWhiteSpace(txtOutDate.Text) AndAlso (GetDateTime(txtOutDate.Text.Trim()) > currentDt OrElse
                      GetDateTime(txtOutDate.Text.Trim()) < currentDt.AddDays(-3)) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Railout Date is more than or equal to yesterday.")
                                Functions.ControlFocus(txtOutDate)
                                Return
                            End If
                        End If
                    Catch ex As Exception

                    End Try

                    'Try
                    'If ddlCFS.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select CFS Terminal")
                    '    Functions.ControlFocus(ddlCFS)
                    '    Return
                    'End If
                    ' Catch ex As Exception

                    'End Try
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        'Removed from below cmd
                        ',PORT_ARRIVAL=TO_DATE('" & TxtTRHandover.Text.Trim & "','DD/MM/YYYY HH24:MI')
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'),RAIL_REMARK='" & txtRemark.Text.Trim & "', POL_ID = " & ddlPOL.SelectedValue & ",POL='" & ddlPOL.SelectedItem.Text & "', POD_ID = " & ddlPOD.SelectedValue & ",PORT='" & ddlPOD.SelectedItem.Text & "',TRAIN_NO='" & txtTrainNo.Text.Trim & "',TRAIN_OUT_DATE=TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY'),REQUIRED_ETD=TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY'),FINAL_ETD=TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY'),REQUIRED_VESSEL='" & txtREQUIRED_VESSEL.Text.Trim & "',CURRENT_VESSEL='" & txtREQUIRED_VESSEL.Text.Trim & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO_DTLS SET POL = " & ddlPOL.SelectedValue & ",FPOD=" & ddlPOD.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd1.ExecuteNonQuery()
                        If txtOutDate.Text <> Nothing Then
                            Dim cmd3 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET RAILOUT_UPDATION=SYSDATE WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                            cmd3.ExecuteNonQuery()
                        End If
                        con.Close()
                        '    Dim strConnectionString, cmd2 As String
                        '    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        '    'cmd2 = " Insert into ALL_PARTY_RAILOUT (MTY_CONT_ID,D_TRACK_ID,POL_ID,POL,TRAIN_NO,OUT_DATE,) " _
                        '    '       & " VALUES (" & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",D_TRACK_ID.NEXTVAL," & lstPOL.SelectedValue & ",'" & lstPOL.SelectedItem.Text & "','" & textTrainNO.Text.Trim & "',NVL(TO_DATE('" & textOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),'')) "

                        '    cmd2 = " Insert into ALL_PARTY_RAILOUT (D_TRACK_ID,POL_ID,POL,TRAIN_NO,OUT_DATE,ETD,VESSEL,ETA,REMARKS,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                        '           & " VALUES (D_TRACK_ID.NEXTVAL," & ddlPOL.SelectedValue & ",'" & ddlPOL.SelectedItem.Text & "','" & txtTrainNo.Text.Trim & "', " _
                        '            & " NVL(TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtREQUIRED_VESSEL.Text.Trim & "',NVL(TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtRemark.Text.Trim & "'," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
                        '    con = New OleDbConnection(strConnectionString)
                        '    con.Open()
                        '    Dim cmd5 As New OleDbCommand(cmd2, con)
                        '    cmd5.ExecuteNonQuery()
                        '    con.Close()
                        'Catch ex As Exception

                        'End Try
                        Dim strConnectionString, cmd2 As String
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")

                        cmd2 = " Insert into ALL_PARTY_RAILOUT (D_TRACK_ID,POL_ID,POL,TRAIN_NO,OUT_DATE,ETD,VESSEL,ETA,REMARKS,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                       & " VALUES (D_TRACK_ID.NEXTVAL," & ddlPOL.SelectedValue & ",'" & ddlPOL.SelectedItem.Text & "','" & txtTrainNo.Text.Trim & "', " _
                        & " NVL(TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtREQUIRED_VESSEL.Text.Trim & "',NVL(TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtRemark.Text.Trim & "'," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try

                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub
    'Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnUpdate.Click

    'End Sub
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
    '    Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
    '    chkAll.Checked = True
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                'Dim ddlCFS As DropDownList = TryCast(row.Cells(0).FindControl("ddlCFS"), DropDownList)
    '                Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
    '                Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)
    '                Dim txtTrainNo As TextBox = TryCast(row.Cells(0).FindControl("txtTrainNo"), TextBox)
    '                Dim txtOutDate As TextBox = TryCast(row.Cells(0).FindControl("txtOutDate"), TextBox)
    '                ' Dim txtWagonNo As TextBox = TryCast(row.Cells(0).FindControl("txtWagonNo"), TextBox)
    '                Dim clRailOutdate = TryCast(row.Cells(0).FindControl("clRailOutdate"), CalendarExtender)
    '                clRailOutdate.EndDate = DateTime.Now.Date
    '                'Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
    '                'clRailOutdate1.EndDate = DateTime.Now.Date
    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),NVL(CFS_ID,0),POL,PORT,CFS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader()
    '                ada.Read()
    '                Try
    '                    ddlPOL.SelectedValue = ada.GetValue(0)
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    ddlPOD.SelectedValue = ada.GetValue(1)
    '                Catch ex As Exception
    '                End Try
    '                'Try
    '                '    If ddlPOL.SelectedValue = 0 Then
    '                '        If lstcpol.SelectedValue > 0 Then
    '                '            con = New OleDbConnection(cs)
    '                '            con.Open()
    '                '            Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET pol_id=" & lstcpol.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                '            cmd2.ExecuteNonQuery()
    '                '            con.Close()

    '                '            ddlPOL.SelectedValue = lstcpol.SelectedValue
    '                '        End If
    '                '    End If
    '                'Catch ex As Exception

    '                'End Try

    '                If lstcpol.SelectedValue <> 0 Then
    '                    ddlPOL.SelectedValue = lstcpol.SelectedValue
    '                End If

    '                If txtOutDate.Text = "" Then
    '                    If textOutDate.Text <> "" Then
    '                        txtOutDate.Text = textOutDate.Text
    '                    End If
    '                End If
    '                If txtTrainNo.Text = "" Then
    '                    If textTrainNO.Text <> "" Then
    '                        txtTrainNo.Text = textTrainNO.Text
    '                    End If
    '                End If

    '            End If
    '        End If
    '    Next
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                'row.Cells(i).FindControl("lblCFS").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
    '                'row.Cells(i).FindControl("lblBL_NO").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRequiredETA").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblPort").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblETD").Visible = Not isChecked
    '                'Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
    '                'clRailOutdate1.EndDate = DateTime.Now.Date
    '                'Dim clETD = TryCast(row.Cells(0).FindControl("clETD"), CalendarExtender)
    '                'clETD.EndDate = DateTime.Now.Date
    '                'row.Cells(i).FindControl("lblBooking_NO").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblREQUIRED_VESSEL").Visible = Not isChecked
    '                If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If isChecked AndAlso Not isUpdateVisible Then
    '                    isUpdateVisible = True
    '                End If
    '                If Not isChecked Then
    '                    chkAll.Checked = False
    '                End If
    '            Next
    '        End If
    '    Next
    '    If textTrainNO.Text = "" Then
    '        BtnupDate.Visible = isUpdateVisible
    '        ImgBtnUpdate.Visible = Not isUpdateVisible
    '    Else
    '        ImgBtnUpdate.Visible = isUpdateVisible
    '        BtnupDate.Visible = Not isUpdateVisible
    '    End If
    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True

        Dim txtTrainNo, txtTrainNo1 As TextBox
        Dim ddlPOL, ddlPOL1 As DropDownList
        Dim lblContNo, lblContNo1 As Label

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then

                    txtTrainNo = row.FindControl("txtTrainNo")
                    ddlPOL = row.FindControl("ddlPOL")
                    lblContNo = row.FindControl("lblCONT_NO")

                    For Each row1 As GridViewRow In gvtripPendencyList.Rows
                        If row.RowType = DataControlRowType.DataRow Then
                            Dim isChecked1 As Boolean = row1.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                            If isChecked1 Then
                                txtTrainNo1 = row1.FindControl("txtTrainNo")
                                ddlPOL1 = row1.FindControl("ddlPOL")
                                lblContNo1 = row1.FindControl("lblCONT_NO")

                                If lblContNo.Text <> lblContNo1.Text Then
                                    If ddlPOL.SelectedValue = ddlPOL1.SelectedValue AndAlso txtTrainNo.Text <> txtTrainNo1.Text Then
                                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Train no can not be different for same pol.")
                                        rtnBool = False
                                        Functions.ControlFocus(ddlPOL1)
                                        Return rtnBool
                                        Exit Function
                                    End If
                                    If ddlPOL.SelectedValue <> ddlPOL1.SelectedValue AndAlso txtTrainNo.Text = txtTrainNo1.Text Then
                                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Train no can not be same for different pol.")
                                        rtnBool = False
                                        Functions.ControlFocus(ddlPOL1)
                                        Return rtnBool
                                        Exit Function
                                    End If

                                End If
                            End If
                        End If
                    Next
                End If
            End If
        Next
        Return rtnBool
    End Function
    Protected Sub BtnupDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnupDate.Click
        'If ValidationCheck() = False Then
        '    Return
        'End If
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim txtRemark As TextBox = TryCast(row.Cells(0).FindControl("txtRemark"), TextBox)
                    Dim txtLINE_HANDOVER_DATE As Label = TryCast(row.Cells(0).FindControl("lblLINE_HANDOVER_DATE"), Label)
                    Dim hdnCustomHandover As HiddenField = TryCast(row.Cells(0).FindControl("hdnCustomHandover"), HiddenField)
                    Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
                    Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
                    Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)
                    Dim txtTrainNo As TextBox = TryCast(row.Cells(0).FindControl("txtTrainNo"), TextBox)
                    Dim txtOutDate As TextBox = TryCast(row.Cells(0).FindControl("txtOutDate"), TextBox)
                    ' Dim txtWagonNo As TextBox = TryCast(row.Cells(0).FindControl("txtWagonNo"), TextBox)
                    Dim txtETD As TextBox = TryCast(row.Cells(0).FindControl("txtETD"), TextBox)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)
                    Dim txtREQUIRED_VESSEL As TextBox = TryCast(row.Cells(0).FindControl("txtREQUIRED_VESSEL"), TextBox)
                    Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
                    clRailOutdate1.EndDate = DateTime.Now.Date
                    Dim clETD = TryCast(row.Cells(0).FindControl("clETD"), CalendarExtender)
                    clETD.EndDate = DateTime.Now.Date
                    Dim clRailOutdate = TryCast(row.Cells(0).FindControl("clRailOutdate"), CalendarExtender)
                    clRailOutdate.EndDate = DateTime.Now.Date
                    '..........
                    'If Not String.IsNullOrEmpty(txtRemark.Text.Trim) Then
                    '    If txtTrainNo.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Train No.")
                    '        Functions.ControlFocus(txtTrainNo)
                    '        Return
                    '    End If
                    'End If
                    'Try
                    '    If Not String.IsNullOrEmpty(txtRemark.Text.Trim) Then
                    '        If txtOutDate.Text = "" Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Rail Out Date.")
                    '            Functions.ControlFocus(txtOutDate)
                    '            Return
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try

                    'If Not String.IsNullOrEmpty(txtRemark.Text) Then
                    '    If txtTrainNo.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks")
                    '        Functions.ControlFocus(txtTrainNo)
                    '        Return
                    '    End If
                    'End If
                    '..........

                    'Try
                    '    If GetDateTime(txtETD.Text) > GetDateTime(TxtRequiredETA.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '              "ETD date should not be greater than ETA date.")
                    '        Functions.ControlFocus(txtETD)
                    '        Return
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    'Try
                    '    If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
                    '        Dim rr = GetDateTime(txtOutDate.Text.Trim())
                    '        Dim newDt = rr.AddDays(-3)
                    '        Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    '        If Not String.IsNullOrWhiteSpace(txtOutDate.Text) AndAlso (GetDateTime(txtOutDate.Text.Trim()) > currentDt OrElse
                    '  GetDateTime(txtOutDate.Text.Trim()) < currentDt.AddDays(-3)) Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Railout Date is more than or equal to yesterday.")
                    '            Functions.ControlFocus(txtOutDate)
                    '            Return
                    '        End If
                    '    End If
                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    If Not String.IsNullOrWhiteSpace(txtLINE_HANDOVER_DATE.Text) Then
                    '        If GetDateTime(txtOutDate.Text) < GetDateTime(txtLINE_HANDOVER_DATE.Text) Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Rail Out date should not be less than handover date..")
                    '            Functions.ControlFocus(txtOutDate)
                    '            Return
                    '        End If
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET RAIL_REMARK='" & txtRemark.Text.Trim & "',POL_ID = " & ddlPOL.SelectedValue & ",POL='" & ddlPOL.SelectedItem.Text & "',POD_ID = " & ddlPOD.SelectedValue & ",PORT='" & ddlPOD.SelectedItem.Text & "', TRAIN_NO='" & txtTrainNo.Text.Trim & "',TRAIN_OUT_DATE=TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY'), REQUIRED_VESSEL='" & txtREQUIRED_VESSEL.Text.Trim & "',REQUIRED_ETD=TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY'),FINAL_ETD=TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'),CURRENT_VESSEL='" & txtREQUIRED_VESSEL.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO_DTLS SET POL = " & ddlPOL.SelectedValue & ",FPOD=" & ddlPOD.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd1.ExecuteNonQuery()
                        If txtOutDate.Text <> Nothing Then
                            Dim cmd3 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET RAILOUT_UPDATION=SYSDATE WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                            cmd3.ExecuteNonQuery()
                        End If
                        con.Close()
                        Dim strConnectionString, cmd2 As String
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")

                        cmd2 = " Insert into ALL_PARTY_RAILOUT (D_TRACK_ID,POL_ID,POL,POD,TRAIN_NO,OUT_DATE,ETD,VESSEL,ETA,REMARKS,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                       & " VALUES (D_TRACK_ID.NEXTVAL," & ddlPOL.SelectedValue & ",'" & ddlPOL.SelectedItem.Text & "','" & ddlPOD.SelectedItem.Text & "','" & txtTrainNo.Text.Trim & "', " _
                        & " NVL(TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & txtETD.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtREQUIRED_VESSEL.Text.Trim & "',NVL(TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),'" & txtRemark.Text.Trim & "'," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    gvtripPendencyList.EditIndex = -1
                    'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()

        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
End Class
