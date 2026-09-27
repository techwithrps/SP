Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit

Partial Class Reports_Fleet_VesselPlanEntry
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
    Dim arrPodId As ArrayList
    Dim arrPodName As ArrayList
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
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
                arrPortId.Add(obj.PortId)
                arrPortName.Add(obj.PortName)
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
    Private Sub BindData()
        preparePortData()
        preparePortDataPOD()
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
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_HANDOVER_PENDVESSEL_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
        textRequiredETD.Text = ""
        textVessel.Text = ""
        TextETA.Text = ""
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pCustomerMaster As New CustomerMaster
            LstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            LstLine.DataTextField = "CustomerName"
            LstLine.DataValueField = "CustomerId"
            LstLine.DataBind()
            LstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            LstLine.SelectedValue = 0
            Dim pPortMaster As New PortMaster
            lstPol.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            lstPol.DataTextField = "PortName"
            lstPol.DataValueField = "PortId"
            lstPol.DataBind()
            lstPol.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPol.SelectedValue = 0
            Dim pPortMaster1 As New PortMaster
            lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster1)
            lstPod.DataTextField = "PortName"
            lstPod.DataValueField = "PortId"
            lstPod.DataBind()
            lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPod.SelectedValue = 0
        Catch ex As Exception
        End Try
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
            ListControlDataBind()
            preparePortDataPOD()
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
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_HANDOVER_PENDVESSEL_REPORT", strpParms)
            gvtripPendencyList.DataSource = dbr
            gvtripPendencyList.DataBind()
            If Not dbr.HasRows Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
        End If

    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        BindData()

    End Sub
    Function GetDateTime(strDate As String) As DateTime
        Dim arrdate, Day, Month, Year, FinalDate

        If strDate <> Nothing And strDate <> "" Then
            Dim parry = strDate.Trim()
            If parry.Length > 10 Then
                parry = parry.Substring(0, 10)
            End If
            arrdate = parry.Split("/")
            Day = arrdate(0)
            Month = arrdate(1)
            Year = arrdate(2)
        End If
        FinalDate = New DateTime(Year, Month, Day, 0, 0, 0)
        Return FinalDate
    End Function
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
    '                Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox)
    '                Dim TxtPlanVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtPlanVessel"), TextBox)
    '                Dim TxtFinalVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtFinalVessel"), TextBox)
    '                Dim TxtVoyage As TextBox = TryCast(row.Cells(0).FindControl("TxtVoyage"), TextBox)
    '                Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
    '                Dim TxtTRHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtTRHandover"), TextBox)
    '                ' Dim TxtSiCut As TextBox = TryCast(row.Cells(0).FindControl("TxtSiCut"), TextBox)
    '                Dim TxtCutOfDate As TextBox = TryCast(row.Cells(0).FindControl("TxtCutOfDate"), TextBox)
    '                Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)
    '                Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)

    '                Dim clFinalETD = TryCast(row.Cells(0).FindControl("clFinalETD"), CalendarExtender)
    '                clFinalETD.StartDate = DateTime.Now.Date
    '                Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
    '                clRailOutdate1.StartDate = DateTime.Now.Date.AddDays(1)

    '                Dim DAY As Long = 0
    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),POL,PORT FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader
    '                ada.Read()
    '                Try
    '                    ddlPOL.SelectedValue = ada.GetValue(0)
    '                    ' ddlPOL.SelectedItem.Text = ada.GetValue(1)
    '                Catch ex As Exception
    '                End Try

    '                Try
    '                    If TxtRequiredEtd.Text = "" Then
    '                        If textRequiredETD.Text.Trim <> "" Then
    '                            TxtRequiredEtd.Text = textRequiredETD.Text.Trim
    '                        End If
    '                    End If

    '                    If TxtPlanVessel.Text = "" Then
    '                        If textVessel.Text.Trim <> "" Then
    '                            TxtPlanVessel.Text = textVessel.Text.Trim
    '                        End If
    '                    End If
    '                    If TxtRequiredETA.Text = "" Then
    '                        If TextETA.Text.Trim <> "" Then
    '                            TxtRequiredETA.Text = TextETA.Text
    '                        End If
    '                    End If
    '                    ' Dim span = textRequiredETD.Text - TextETA.Text
    '                    Dim date1 As Date = Format(textRequiredETD.Text, "dd/MM/yyyy")
    '                    Dim date2 As Date = Format(TextETA.Text, "dd/MM/yyyy")

    '                    'DAY = (date2 - date1).TotalDays
    '                    'DAY = DateDiff(DateInterval.Day, date1, date2)
    '                    'TxtTransitTime.Text = DateDiff(DateInterval.Day, date1, date2).ToString()
    '                    'DAY = DateDiff(TextETA.Text, textRequiredETD.Text)
    '                Catch ex As Exception

    '                End Try
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
    '                row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblTransitTime").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblETD").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRequiredETA").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblPortArrival").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblCutOfDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblTRDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblFinalVessel").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblPlanVessel").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblFinalETD").Visible = Not isChecked
    '                'row.Cells(i).FindControl("lblLINE_HANDOVER_DATE").Visible = Not isChecked
    '                'row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
    '                'row.Cells(i).FindControl("txtTrainNo").Visible = Not isChecked
    '                'row.Cells(i).FindControl("txtOutDate").Visible = Not isChecked

    '                If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
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
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TxtFinalVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtFinalVessel"), TextBox)
                    Dim TxtVoyage As TextBox = TryCast(row.Cells(0).FindControl("TxtVoyage"), TextBox)
                    Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
                    Dim TxtTRHandover As TextBox = TryCast(row.Cells(0).FindControl("TxtTRHandover"), TextBox)
                    '   Dim TxtSiCut As TextBox = TryCast(row.Cells(0).FindControl("TxtSiCut"), TextBox)
                    Dim TxtCutOfDate As TextBox = TryCast(row.Cells(0).FindControl("TxtCutOfDate"), TextBox)
                    Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox)
                    Dim TxtPlanVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtPlanVessel"), TextBox)
                    Dim TxtFinalEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtFinalEtd"), TextBox)
                    Dim txtRemark As TextBox = TryCast(row.Cells(0).FindControl("txtRemark"), TextBox)
                    Dim TxtportArrival As TextBox = TryCast(row.Cells(0).FindControl("TxtportArrival"), TextBox)
                    Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)

                    'If String.IsNullOrWhiteSpace(TxtTRHandover.Text) Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "TR Handover date is not updated.")
                    '    Return
                    'End If

                    'If String.IsNullOrWhiteSpace(TxtportArrival.Text) Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Port Arrival date is not updated.")
                    '    Return
                    'End If

                    ' If TxtFinalVessel.Text <> Nothing Then
                    'If TxtFinalVessel.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                    '    Functions.ControlFocus(TxtFinalVessel)
                    '    Return
                    'End If

                    'If String.IsNullOrWhiteSpace(TxtFinalEtd.Text) Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Final ETD.")
                    '    Functions.ControlFocus(TxtFinalEtd)
                    '    Return
                    'End If

                    '..........
                    'If TxtRequiredETA.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                    '    Functions.ControlFocus(TxtRequiredETA)
                    '    Return
                    'End If
                    '..........

                    'If TxtRequiredEtd.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                    '    Functions.ControlFocus(TxtRequiredEtd)
                    '    Return
                    'End If
                    'If TxtVoyage.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Voyage.")
                    '    Functions.ControlFocus(TxtVoyage)
                    '    Return
                    'End If

                    'Try
                    '    If GetDateTime(textRequiredETD.Text) > GetDateTime(TxtRequiredETA.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                    "ETD date should not be greater than ETA date.")
                    '        Functions.ControlFocus(textRequiredETD)
                    '        Return
                    '    End If

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    If GetDateTime(TxtFinalEtd.Text) > GetDateTime(TxtRequiredETA.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                    "ETD date should not be greater than ETA date.")
                    '        Functions.ControlFocus(TxtFinalEtd)
                    '        Return
                    '    End If

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    If GetDateTime(TxtportArrival.Text) > GetDateTime(TxtRequiredETA.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                    "Port Arrival date should not be greater than ETA date.")
                    '        Functions.ControlFocus(TxtportArrival)
                    '        Return
                    '    End If

                    'Catch ex As Exception

                    'End Try
                    '   If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
                    '       Dim rr = GetDateTime(TxtportArrival.Text.Trim())
                    '       'Dim newDt = rr.AddDays(-3)
                    '       Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    '       If Not String.IsNullOrWhiteSpace(TxtportArrival.Text) AndAlso (GetDateTime(TxtportArrival.Text.Trim()) > currentDt OrElse
                    'GetDateTime(TxtportArrival.Text.Trim()) < currentDt.AddDays(-3)) Then
                    '           Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the Port Arrival Date is more than or equal to yesterday.")
                    '           Functions.ControlFocus(TxtportArrival)
                    '           Return
                    '       End If
                    '   End If

                    '..............
                    'Try
                    '    If GetDateTime(TxtportArrival.Text) > GetDateTime(TxtFinalEtd.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                    "Port Arrival date should not be greater than Final ETD date.")
                    '        Functions.ControlFocus(TxtportArrival)
                    '        Return
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    'Try
                    '    If GetDateTime(TxtportArrival.Text) > GetDateTime(TxtRequiredEtd.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                    "Port Arrival date should not be greater than ETD date.")
                    '        Functions.ControlFocus(TxtportArrival)
                    '        Return
                    '    End If

                    'Catch ex As Exception

                    'End Try                   
                    '..............

                    'If ddlPOL.SelectedValue = "0" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Port.")
                    '    Functions.ControlFocus(ddlPOL)
                    '    Return
                    'End If

                    ' End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET PORT_ARRIVAL=TO_DATE('" & TxtportArrival.Text & "','DD/MM/YYYY'),CUTOF_DATE=TO_DATE('" & TxtCutOfDate.Text & "','DD/MM/YYYY HH24:MI'),TR_HANDOVER_DATE=TO_DATE('" & TxtTRHandover.Text & "','DD/MM/YYYY HH24:MI'), VESSEL_OUT_REMARK='" & txtRemark.Text.Trim & "', POL='" & ddlPOL.SelectedItem.Text & "', POL_ID=" & ddlPOL.SelectedValue & ", CURRENT_VESSEL='" & TxtPlanVessel.Text.Trim & "', VOYAGE='" & TxtVoyage.Text.Trim & "', REQUIRED_VESSEL='" & TxtFinalVessel.Text.Trim & "',REQUIRED_ETD=TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY'),FINAL_ETD=TO_DATE('" & TxtFinalEtd.Text.Trim & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY')  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO_DTLS SET POL = " & ddlPOL.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd1.ExecuteNonQuery()
                        con.Close()
                        Dim strConnectionString, cmd2 As String
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = " Insert into VESSEL_UPDATION (VESSEL_TRACK_ID,POL_ID,POL,PLAN_VESSEL,FINAL_VESSEL,ETD,FINAL_ETD,ETA,VOYAGE,PORT_CUTOF_DATE,PORT_ARRIVAL_DATE,REMARKS,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                             & " VALUES (VESSEL_TRACK_ID.NEXTVAL," & ddlPOL.SelectedValue & ",'" & ddlPOL.SelectedItem.Text & "','" & TxtPlanVessel.Text.Trim & "','" & TxtFinalVessel.Text.Trim & "', NVL(TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtFinalEtd.Text.Trim & "','DD/MM/YYYY'),''), " _
                              & " NVL(TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'),''),'" & TxtVoyage.Text.Trim & "', NVL(TO_DATE('" & TxtCutOfDate.Text.Trim & "','DD/MM/YYYY HH24:MI'),''),NVL(TO_DATE('" & TxtportArrival.Text.Trim & "','DD/MM/YYYY'),''),'" & txtRemark.Text.Trim & "'," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
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
        Button4.Visible = False
        BindData()
        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
