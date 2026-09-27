Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit

Partial Class Reports_Fleet_SOBPanding
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
    Dim arrPodId As ArrayList
    Dim arrPodName As ArrayList
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            ListControlDataBind1()
            preparePortDataPOD()
            prepareTerminalData()
            BindData()
            btnUpdate.Visible = False
            BtnUpPArrival.Visible = False
        End If
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
        Dim arrdate, Day, Month, Year, FinalDate
        Try
            If strDate <> Nothing And strDate <> "" Then
                Dim parry = strDate.Trim()
                arrdate = parry.Split("/")
                Day = arrdate(0)
                Month = arrdate(1)
                Year = arrdate(2)
            End If
            FinalDate = New DateTime(Year, Month, Day, 0, 0, 0)
            Return FinalDate

        Catch ex As Exception

        End Try

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
    ''' <summary>
    ''' hariom sir
    ''' </summary>
    Shared gvData As New DataTable

    Private Sub BindData()
        preparePortDataPOD()
        prepareTerminalData()
        Dim strConnectionString, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSIT_TIME FROM(SELECT  ROUND(CURRENT_ETA-CURRENT_ETD)TRANSIT_TIME FROM ALL_PARTY_ACCOUNT AP WHERE LINE_HANDOVER_DATE >=TO_DATE('1/10/2017','DD/MM/YYYY') AND (SAILED IS NULL OR PORT_ARRIVAL IS NULL) )  ORDER BY TRANSIT_TIME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim ds As New DataSet("CONTAINER")

            ada = New OleDbDataAdapter(cmd3, con)
            Dim ds3 As New DataSet("PORT_MASTER")
            ada.Fill(ds3)
            LstTransitTime.DataSource = ds3.Tables(0)
            LstTransitTime.DataTextField = "TRANSIT_TIME"
            LstTransitTime.DataValueField = "TRANSIT_TIME"
            LstTransitTime.DataBind()
            LstTransitTime.Items.Insert(0, (New ListItem("---Select---", 100000)))
            ds3.Clear()
            con.Close()
        Catch ex As Exception
        End Try
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & lsttrainNo.SelectedValue & "'"
        strpParms &= "," & 0
        strpParms &= "," & 0 & ",'','','P',100000,''"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_HANDOVER_PENDSOB_REPORT", strpParms)
        ''''''harriom
        'Dim dt As New DataTable
        'dt.Load(dbr)
        'gvData = dt
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
        textsob.Text = ""
        TextPortArrivalDate.Text = ""
        TextTranshipmentETD.Text = ""
        textVessel.Text = ""
        lstTranshipemtPort.SelectedValue = 0
    End Sub
    Sub ListControlDataBind1()
        Dim strConnectionString, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRAIN_NO FROM ALL_PARTY_ACCOUNT AP WHERE PORT_ARRIVAL IS NULL AND LINE_HANDOVER_DATE >=TO_DATE('1/11/2017','DD/MM/YYYY') AND TRAIN_NO IS NOT NULL  ORDER BY TRAIN_NO ASC"
            cmd4 = "SELECT DISTINCT REQUIRED_VESSEL FROM ALL_PARTY_ACCOUNT AP WHERE SAILED IS NULL AND LINE_HANDOVER_DATE >=TO_DATE('1/11/2017','DD/MM/YYYY') AND REQUIRED_VESSEL IS NOT NULL  ORDER BY REQUIRED_VESSEL ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim ds As New DataSet("CONTAINER")

            ada = New OleDbDataAdapter(cmd3, con)
            Dim ds3 As New DataSet("PORT_MASTER")
            ada.Fill(ds3)
            lsttrainNo.DataSource = ds3.Tables(0)
            lsttrainNo.DataTextField = "TRAIN_NO"
            lsttrainNo.DataValueField = "TRAIN_NO"
            lsttrainNo.DataBind()
            lsttrainNo.Items.Insert(0, (New ListItem("---Select---", "")))
            ds3.Clear()
            con.Close()
            ada = New OleDbDataAdapter(cmd4, con)
            Dim ds4 As New DataSet("PORT_MASTER")
            ada.Fill(ds4)
            lstVessel.DataSource = ds4.Tables(0)
            lstVessel.DataTextField = "REQUIRED_VESSEL"
            lstVessel.DataValueField = "REQUIRED_VESSEL"
            lstVessel.DataBind()
            lstVessel.Items.Insert(0, (New ListItem("---Select---", "")))
            ds4.Clear()
            con.Close()
        Catch ex As Exception
        End Try
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
            lstTranshipemtPort.DataSource = PortMaster.ReturnPortMasterList(pPortMaster1)
            lstTranshipemtPort.DataTextField = "PortName"
            lstTranshipemtPort.DataValueField = "PortId"
            lstTranshipemtPort.DataBind()
            lstTranshipemtPort.Items.Insert(0, (New ListItem("---All---", 0)))
            lstTranshipemtPort.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Dim strConnectionString, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSIT_TIME FROM(SELECT  ROUND(CURRENT_ETA-CURRENT_ETD)TRANSIT_TIME FROM ALL_PARTY_ACCOUNT AP,FLEET_CONT_JO_DTLS FCD WHERE LINE_HANDOVER_DATE >=TO_DATE('1/10/2017','DD/MM/YYYY') AND (SAILED IS NULL OR PORT_ARRIVAL IS NULL) " &
                "AND AP.POL_ID=DECODE(" & lstPol.SelectedValue & ",0,POL_ID," & lstPol.SelectedValue & ") AND AP.POD_ID=DECODE(" & lstPod.SelectedValue & ",0,POD_ID," & lstPod.SelectedValue & ")" &
                "AND AP.TRAIN_NO=DECODE('" & lsttrainNo.SelectedValue & "','',AP.TRAIN_NO,'" & lsttrainNo.SelectedValue & "') AND FCD.MTY_CONT_ID=AP.MTY_CONT_ID " &
                "AND FCD.LINE_ID = DECODE(" & LstLine.SelectedValue & ",0,FCD.LINE_ID," & LstLine.SelectedValue & ") AND AP.REQUIRED_VESSEL=DECODE('" & lstVessel.SelectedValue & "','',REQUIRED_VESSEL,'" & lstVessel.SelectedValue & "') ) ORDER BY TRANSIT_TIME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim ds As New DataSet("CONTAINER")

            ada = New OleDbDataAdapter(cmd3, con)
            Dim ds3 As New DataSet("PORT_MASTER")
            ada.Fill(ds3)
            LstTransitTime.DataSource = ds3.Tables(0)
            LstTransitTime.DataTextField = "TRANSIT_TIME"
            LstTransitTime.DataValueField = "TRANSIT_TIME"
            LstTransitTime.DataBind()
            LstTransitTime.Items.Insert(0, (New ListItem("---Select---", 100000)))
            ds3.Clear()
            con.Close()
        Catch ex As Exception
        End Try
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        preparePortDataPOD()
        prepareTerminalData()
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= LstLine.SelectedValue
        strpParms &= ",'" & lsttrainNo.SelectedValue & "'"
        strpParms &= "," & lstPol.SelectedValue & "," & lstPod.SelectedValue & ",'','','P'"
        strpParms &= "," & 100000
        strpParms &= ",'" & lstVessel.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_HANDOVER_PENDSOB_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
        Else
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
        Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim LsttranshipmentPort2 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort2"), DropDownList)
                    ' Dim LsttranshipmentPort3 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort3"), DropDownList)
                    Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)

                    Dim TxtTranshipmetDate2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate2"), TextBox)
                    Dim TxtTranshipmentVeseel2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel2"), TextBox)
                    Dim TxtTranshipmetETA2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA2"), TextBox)
                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)

                    'Dim TxtTranshipmetDate3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate3"), TextBox)
                    'Dim TxtTranshipmentVeseel3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel3"), TextBox)
                    'Dim TxtTranshipmetETA3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA3"), TextBox)
                    Dim cllstSob = TryCast(row.Cells(0).FindControl("cllstSob"), CalendarExtender)
                    cllstSob.EndDate = DateTime.Now.Date
                    Dim clTxtFollowup = TryCast(row.Cells(0).FindControl("clTxtFollowup"), CalendarExtender)
                    clTxtFollowup.StartDate = DateTime.Now.Date
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT nvl(TRANS_PORT_ID,0),nvl(TRANS_PORT_ID2,0),nvl(TRANS_PORT_ID3,0) FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                    Try
                        LsttranshipmentPort.SelectedValue = ada.GetValue(0)
                    Catch ex As Exception
                    End Try

                    Try
                        LsttranshipmentPort2.SelectedValue = ada.GetValue(0)
                    Catch ex As Exception
                    End Try
                    'Try
                    '    LsttranshipmentPort3.SelectedValue = ada.GetValue(0)
                    'Catch ex As Exception
                    'End Try

                    Try
                        If LsttranshipmentPort.SelectedValue = 0 Then
                            If lstTranshipemtPort.SelectedValue > 0 Then
                                con = New OleDbConnection(cs)
                                con.Open()
                                Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TRANS_PORT_ID=" & lstTranshipemtPort.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                                cmd2.ExecuteNonQuery()
                                con.Close()

                                LsttranshipmentPort.SelectedValue = lstTranshipemtPort.SelectedValue
                            End If
                        End If
                        If lstSob.Text = "" Then
                            If textsob.Text <> "" Then
                                lstSob.Text = textsob.Text.Trim
                            End If
                        End If
                        If TxtTranshipmetDate.Text = "" Then
                            If TextTranshipmentETD.Text <> "" Then
                                TxtTranshipmetDate.Text = TextTranshipmentETD.Text.Trim
                            End If
                        End If
                        If TxtTranshipmetETA.Text = "" Then
                            If TextTnaETA.Text <> "" Then
                                TxtTranshipmetETA.Text = TextTnaETA.Text.Trim
                            End If
                        End If
                        If TxtTranshipmentVeseel.Text = "" Then
                            If textVessel.Text <> "" Then
                                TxtTranshipmentVeseel.Text = textVessel.Text.Trim
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    row.Cells(i).FindControl("lblRequiredEtd").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRequiredVessel").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRequiredETA").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRSailed").Visible = Not isChecked
                    row.Cells(i).FindControl("lbltranshipmentPort").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetDate").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetEta").Visible = Not isChecked
                    row.Cells(i).FindControl("lblTranshipmentVeseel").Visible = Not isChecked

                    row.Cells(i).FindControl("lbltranshipmentPort2").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetEta2").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetDate2").Visible = Not isChecked
                    row.Cells(i).FindControl("lblTranshipmentVeseel2").Visible = Not isChecked
                    row.Cells(i).FindControl("LblFollowup").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCODType").Visible = Not isChecked


                    'row.Cells(i).FindControl("lbltranshipmentPort3").Visible = Not isChecked
                    'row.Cells(i).FindControl("LblTranshipmetEta3").Visible = Not isChecked
                    'row.Cells(i).FindControl("LblTranshipmetDate3").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblTranshipmentVeseel3").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
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
    End Sub

    Protected Sub BTNGO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNGO.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        preparePortDataPOD()
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= LstLine.SelectedValue
        strpParms &= ",'" & lsttrainNo.SelectedValue & "'"
        strpParms &= "," & lstPol.SelectedValue & "," & lstPod.SelectedValue & ",'','','P'"
        strpParms &= "," & LstTransitTime.SelectedValue
        strpParms &= ",'" & lstVessel.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_HANDOVER_PENDSOB_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    'Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
    '                Dim cllstSob = TryCast(row.Cells(0).FindControl("cllstSob"), CalendarExtender)
    '                cllstSob.EndDate = DateTime.Now.Date
    '                Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox)
    '                Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
    '                Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
    '                Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
    '                Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
    '                Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
    '                Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)

    '                Dim LsttranshipmentPort2 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort2"), DropDownList)
    '                Dim TxtTranshipmetDate2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate2"), TextBox)
    '                Dim TxtTranshipmentVeseel2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel2"), TextBox)
    '                Dim TxtTranshipmetETA2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA2"), TextBox)


    '                Dim LsttranshipmentPort3 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort3"), DropDownList)
    '                Dim TxtTranshipmetDate3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate3"), TextBox)
    '                Dim TxtTranshipmentVeseel3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel3"), TextBox)
    '                Dim TxtTranshipmetETA3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA3"), TextBox)
    '                Dim TxtSobRemarks As TextBox = TryCast(row.Cells(0).FindControl("TxtSobRemarks"), TextBox)

    '                If String.IsNullOrWhiteSpace(TxtRequiredETA.Text) Then
    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Final ETA.")
    '                    Functions.ControlFocus(TxtRequiredETA)
    '                    Return
    '                End If
    '                Try
    '                    If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Parveen Deswal" AndAlso
    '                Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Faisal" AndAlso Session.Item("LoginUser") <> "Saurabh Chauhan" AndAlso
    '                Session.Item("LoginUser") <> "Khushnood Alam" AndAlso Session.Item("LoginUser") <> "Ayush Kapoor" AndAlso Session.Item("LoginUser") <> "ADMIN" Then
    '                        If String.IsNullOrWhiteSpace(lstSob.Text) Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill SOB Date.")
    '                            Functions.ControlFocus(lstSob)
    '                            Return
    '                        End If
    '                    End If

    '                Catch ex As Exception

    '                End Try
    '                Try
    '                    If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Parveen Deswal" AndAlso
    '             Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Faisal" AndAlso Session.Item("LoginUser") <> "Saurabh Chauhan" AndAlso
    '             Session.Item("LoginUser") <> "Khushnood Alam" AndAlso Session.Item("LoginUser") <> "Ayush Kapoor" AndAlso Session.Item("LoginUser") <> "ADMIN" Then

    '                        If GetDateTime(lstSob.Text) > GetDateTime(TxtRequiredETA.Text) Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
    '                                                             "SOB date should not be greater than Final ETA.")
    '                            Functions.ControlFocus(lstSob)
    '                            Return
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                End Try

    '                If TxtRequiredVessel.Text <> Nothing Then
    '                        If TxtRequiredVessel.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
    '                            Functions.ControlFocus(TxtRequiredVessel)
    '                            Return
    '                        End If
    '                        If TxtRequiredETA.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
    '                            Functions.ControlFocus(TxtRequiredETA)
    '                            Return
    '                        End If
    '                    If TxtRequiredEtd.Text = "" Then
    '                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
    '                        Functions.ControlFocus(TxtRequiredEtd)
    '                        Return
    '                    End If
    '                    If TxtSobRemarks.Text = "" Then
    '                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
    '                        Functions.ControlFocus(TxtSobRemarks)
    '                        Return
    '                    End If
    '                End If
    '                    If TxtRequiredETA.Text <> Nothing Then
    '                        If TxtRequiredVessel.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
    '                            Functions.ControlFocus(TxtRequiredVessel)
    '                            Return
    '                        End If
    '                        If TxtRequiredETA.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
    '                            Functions.ControlFocus(TxtRequiredETA)
    '                            Return
    '                        End If
    '                    If TxtRequiredEtd.Text = "" Then
    '                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
    '                        Functions.ControlFocus(TxtRequiredEtd)
    '                        Return
    '                    End If
    '                    If TxtSobRemarks.Text = "" Then
    '                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
    '                        Functions.ControlFocus(TxtSobRemarks)
    '                        Return
    '                    End If
    '                    Try
    '                            If GetDateTime(TxtRequiredEtd.Text) > GetDateTime(TxtRequiredETA.Text) Then
    '                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
    '                                                                        "ETD date should not be greater than ETA date.")
    '                                Functions.ControlFocus(TxtRequiredEtd)
    '                                Return
    '                            End If

    '                        Catch ex As Exception

    '                        End Try

    '                    End If
    '                    If TxtRequiredEtd.Text <> Nothing Then
    '                        If TxtRequiredVessel.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
    '                            Functions.ControlFocus(TxtRequiredVessel)
    '                            Return
    '                        End If
    '                        If TxtRequiredETA.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
    '                            Functions.ControlFocus(TxtRequiredETA)
    '                            Return
    '                        End If
    '                        If TxtRequiredEtd.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
    '                            Functions.ControlFocus(TxtRequiredEtd)
    '                            Return
    '                        End If
    '                    If TxtSobRemarks.Text = "" Then
    '                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
    '                        Functions.ControlFocus(TxtSobRemarks)
    '                        Return
    '                    End If

    '                End If
    '                    Try
    '                        con = New OleDbConnection(cs)
    '                        con.Open()
    '                        If LstRemark.SelectedItem.Value = "4" Then
    '                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET SHIPMENT_STATUS=0,SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''), TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "', TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",SAILED=TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY'),SOB='SOB',REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',FINAL_ETD=TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'), CONFIRM_MAIL_DATE=TO_DATE(SYSDATE, 'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)

    '                        cmd.ExecuteNonQuery()
    '                            con.Close()
    '                        Else
    '                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET SHIPMENT_STATUS=0,SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''), TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",TRANSHIPMENT_VESSEL2='" & TxtTranshipmentVeseel2.Text.Trim & "',TRANSHIPMENT_ETD2=TO_DATE('" & TxtTranshipmetDate2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA2=TO_DATE('" & TxtTranshipmetETA2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT2='" & LsttranshipmentPort2.SelectedItem.Text & "',TRANS_PORT_ID2=" & LsttranshipmentPort2.SelectedValue & ",TRANSHIPMENT_VESSEL3='" & TxtTranshipmentVeseel3.Text.Trim & "',TRANSHIPMENT_ETD3=TO_DATE('" & TxtTranshipmetDate3.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA3=TO_DATE('" & TxtTranshipmetETA3.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT3='" & LsttranshipmentPort3.SelectedItem.Text & "',TRANS_PORT_ID3=" & LsttranshipmentPort3.SelectedValue & ",SAILED=TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY'),SOB='SOB',REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',FINAL_ETD=TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)

    '                        cmd.ExecuteNonQuery()
    '                            con.Close()
    '                        End If

    '                    Catch ex As Exception

    '                    End Try

    '                    gvtripPendencyList.EditIndex = -1
    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    '                End If
    '            End If
    '    Next
    '    btnUpdate.Visible = False
    '    BindData()
    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub BtnUpPArrival_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpPArrival.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
                    Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox)
                    Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
                    Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    Dim LsttranshipmentPort2 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort2"), DropDownList)
                    Dim TxtTranshipmetDate2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate2"), TextBox)
                    Dim TxtTranshipmentVeseel2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel2"), TextBox)
                    Dim TxtTranshipmetETA2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA2"), TextBox)
                    Dim TxtFollowup As TextBox = TryCast(row.Cells(0).FindControl("TxtFollowup"), TextBox)
                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)

                    'Dim LsttranshipmentPort3 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort3"), DropDownList)
                    'Dim TxtTranshipmetDate3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate3"), TextBox)
                    'Dim TxtTranshipmentVeseel3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel3"), TextBox)
                    'Dim TxtTranshipmetETA3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA3"), TextBox)
                    Dim TxtSobRemarks As TextBox = TryCast(row.Cells(0).FindControl("TxtSobRemarks"), TextBox)

                    If TxtRequiredVessel.Text <> Nothing Then
                        If TxtRequiredVessel.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                            Functions.ControlFocus(TxtRequiredVessel)
                            Return
                        End If
                        If TxtRequiredETA.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                            Functions.ControlFocus(TxtRequiredETA)
                            Return
                        End If
                        If TxtRequiredEtd.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                            Functions.ControlFocus(TxtRequiredEtd)
                            Return
                        End If
                        If TxtSobRemarks.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
                            Functions.ControlFocus(TxtSobRemarks)
                            Return
                        End If
                    End If
                    If TxtRequiredETA.Text <> Nothing Then
                        If TxtRequiredVessel.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                            Functions.ControlFocus(TxtRequiredVessel)
                            Return
                        End If
                        If TxtRequiredETA.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                            Functions.ControlFocus(TxtRequiredETA)
                            Return
                        End If
                        If TxtRequiredEtd.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                            Functions.ControlFocus(TxtRequiredEtd)
                            Return
                        End If
                        If TxtSobRemarks.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
                            Functions.ControlFocus(TxtSobRemarks)
                            Return
                        End If

                        Try

                            If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Parveen Deswal" AndAlso
                       Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Faisal" AndAlso Session.Item("LoginUser") <> "Saurabh Chauhan" AndAlso
                       Session.Item("LoginUser") <> "Khushnood Alam" AndAlso Session.Item("LoginUser") <> "Ayush Kapoor" AndAlso Session.Item("LoginUser") <> "ADMIN" Then
                                If lstSob.Text = "" Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill SOB.")
                                    Functions.ControlFocus(lstSob)
                                    Return
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                        Try
                            If GetDateTime(lstSob.Text.Trim()) > DateTime.Now Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "SOB Date can not be more than current date")
                                Functions.ControlFocus(lstSob)
                                Return
                            End If
                        Catch ex As Exception

                        End Try


                    End If
                    If TxtRequiredEtd.Text <> Nothing Then
                        If TxtRequiredVessel.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                            Functions.ControlFocus(TxtRequiredVessel)
                            Return
                        End If
                        If TxtRequiredETA.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                            Functions.ControlFocus(TxtRequiredETA)
                            Return
                        End If
                        If TxtRequiredEtd.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                            Functions.ControlFocus(TxtRequiredEtd)
                            Return
                        End If
                        Try
                            If GetDateTime(TxtRequiredEtd.Text) > GetDateTime(TxtRequiredETA.Text) Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                                                        "ETD date should not be greater than ETA date.")
                                Functions.ControlFocus(TxtRequiredEtd)
                                Return
                            End If

                        Catch ex As Exception

                        End Try
                    End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET COD_TYPE_ID = '" & lstCODType.SelectedValue & "',COD_TYPE='" & lstCODType.SelectedItem.Text & "', TRANSHIPMENT_ETA=DECODE('" & TxtTranshipmetETA.Text.Trim & "','',TRANSHIPMENT_ETA,TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY')),SOB_REMARK= '" & TxtSobRemarks.Text.Trim & "', TRANSHIPMENT_VESSEL=DECODE('" & TxtTranshipmentVeseel.Text.Trim & "','',TRANSHIPMENT_VESSEL,'" & TxtTranshipmentVeseel.Text.Trim & "'),TRANSHIPMENT_ETD=DECODE('" & TxtTranshipmetDate.Text.Trim & "','',TRANSHIPMENT_ETD,TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY')),TRANSHIPMENT_PORT=DECODE('" & LsttranshipmentPort.SelectedItem.Text & "','',TRANSHIPMENT_PORT,'" & LsttranshipmentPort.SelectedItem.Text & "'),TRANS_PORT_ID=DECODE(" & LsttranshipmentPort.SelectedValue & ",0,TRANS_PORT_ID," & LsttranshipmentPort.SelectedValue & "), TRANSHIPMENT_VESSEL2='" & TxtTranshipmentVeseel2.Text.Trim & "',TRANSHIPMENT_ETD2=TO_DATE('" & TxtTranshipmetDate2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA2=TO_DATE('" & TxtTranshipmetETA2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT2='" & LsttranshipmentPort2.SelectedItem.Text & "',TRANS_PORT_ID2=" & LsttranshipmentPort2.SelectedValue & ",SAILED=DECODE('" & lstSob.Text.Trim & "','',FOLLOWUP_DATE=TO_DATE('" & TxtFollowup.Text.Trim & "','DD/MM/YYYY'),SAILED,TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY')),SOB='SOB',REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)

                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try

                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        btnUpdate.Visible = False
        BindData()
    End Sub
    'Private Sub FilterTableByMtyContId(table As DataTable)
    '    Dim hdnMTY_CONT_ID As HiddenField = FindControl("hdnMTY_CONT_ID")
    '    Dim dv = New DataView(table, "MTY_CONT_ID = " & hdnMTY_CONT_ID.Value & "", "", DataViewRowState.CurrentRows)

    'End Sub
    Protected Sub BtnSobUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSobUpdate.Click
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
                    Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox)
                    Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
                    Dim TxtRequiredETA As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETA"), TextBox)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    Dim LsttranshipmentPort2 As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort2"), DropDownList)
                    Dim TxtTranshipmetDate2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate2"), TextBox)
                    Dim TxtTranshipmentVeseel2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel2"), TextBox)
                    Dim TxtTranshipmetETA2 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA2"), TextBox)
                    Dim TxtFollowup As TextBox = TryCast(row.Cells(0).FindControl("TxtFollowup"), TextBox)
                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)
                    'Dim TxtTranshipmetDate3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate3"), TextBox)
                    'Dim TxtTranshipmentVeseel3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel3"), TextBox)
                    'Dim TxtTranshipmetETA3 As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA3"), TextBox)
                    Dim TxtSobRemarks As TextBox = TryCast(row.Cells(0).FindControl("TxtSobRemarks"), TextBox)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)
                    'If TxtRequiredVessel.Text <> Nothing Then
                    '    If TxtRequiredVessel.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                    '        Functions.ControlFocus(TxtRequiredVessel)
                    '        Return
                    '    End If
                    '    If TxtRequiredETA.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                    '        Functions.ControlFocus(TxtRequiredETA)
                    '        Return
                    '    End If
                    '    If TxtRequiredEtd.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                    '        Functions.ControlFocus(TxtRequiredEtd)
                    '        Return
                    '    End If
                    '    If TxtSobRemarks.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
                    '        Functions.ControlFocus(TxtSobRemarks)
                    '        Return
                    '    End If
                    'End If
                    'If TxtRequiredETA.Text <> Nothing Then
                    'If TxtRequiredVessel.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                    '    Functions.ControlFocus(TxtRequiredVessel)
                    '    Return
                    'End If
                    'If TxtRequiredETA.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                    '    Functions.ControlFocus(TxtRequiredETA)
                    '    Return
                    'End If
                    'If TxtRequiredEtd.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                    '    Functions.ControlFocus(TxtRequiredEtd)
                    '    Return
                    'End If
                    'If TxtSobRemarks.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
                    '    Functions.ControlFocus(TxtSobRemarks)
                    '    Return
                    'End If

                    'If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Parveen Deswal" AndAlso
                    '    Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Faisal" AndAlso Session.Item("LoginUser") <> "Saurabh Chauhan" AndAlso
                    '    Session.Item("LoginUser") <> "Khushnood Alam" AndAlso Session.Item("LoginUser") <> "Ayush Kapoor" AndAlso Session.Item("LoginUser") <> "ADMIN" Then
                    '    If lstSob.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill SOB.")
                    '        Functions.ControlFocus(lstSob)
                    '        Return
                    '    End If
                    'End If
                    'Try
                    '    If GetDateTime(lstSob.Text.Trim()) > DateTime.Now Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "SOB Date can not be more than current date")
                    '        Functions.ControlFocus(lstSob)
                    '        Return
                    '    End If
                    'Catch ex As Exception

                    'End Try

                    'Try
                    '    If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" Then
                    '        Dim rr = GetDateTime(lstSob.Text.Trim())
                    '        Dim newDt = rr.AddDays(-3)
                    '        Dim currentDt = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    '        If Not String.IsNullOrWhiteSpace(lstSob.Text) AndAlso (GetDateTime(lstSob.Text.Trim()) > currentDt OrElse
                    ' GetDateTime(lstSob.Text.Trim()) < currentDt.AddDays(-3)) Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please ensure that the SOB Date is more than or equal to yesterday.")
                    '            Functions.ControlFocus(lstSob)
                    '            Return
                    '        End If
                    '    End If

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    If GetDateTime(TxtRequiredEtd.Text) > GetDateTime(TxtRequiredETA.Text) Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                            "ETD date should not be greater than ETA date.")
                    '        Functions.ControlFocus(TxtRequiredEtd)
                    '        Return
                    '    End If

                    'Catch ex As Exception
                    'End Try
                    'Try
                    '    If Session.Item("LoginUser") <> "Akshay" AndAlso Session.Item("LoginUser") <> "Nitin Saini" AndAlso Session.Item("LoginUser") <> "Parveen Deswal" AndAlso
                    '       Session.Item("LoginUser") <> "Vansh" AndAlso Session.Item("LoginUser") <> "Faisal" AndAlso Session.Item("LoginUser") <> "Saurabh Chauhan" AndAlso
                    '       Session.Item("LoginUser") <> "Khushnood Alam" AndAlso Session.Item("LoginUser") <> "Ayush Kapoor" AndAlso Session.Item("LoginUser") <> "ADMIN" Then
                    '        If GetDateTime(TxtRequiredEtd.Text) > GetDateTime(lstSob.Text) Then
                    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                    '                                                "SOB  date will not less than Final ETD date.")
                    '            Functions.ControlFocus(TxtRequiredEtd)
                    '            Return
                    '        End If
                    '    End If

                    'Catch ex As Exception

                    'End Try
                    'End If

                    'If TxtRequiredEtd.Text <> Nothing Then
                    '    If TxtRequiredVessel.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Vessel Detail.")
                    '        Functions.ControlFocus(TxtRequiredVessel)
                    '        Return
                    '    End If
                    '    If TxtRequiredETA.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETA.")
                    '        Functions.ControlFocus(TxtRequiredETA)
                    '        Return
                    '    End If
                    '    If TxtRequiredEtd.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill ETD.")
                    '        Functions.ControlFocus(TxtRequiredEtd)
                    '        Return
                    '    End If
                    '    If TxtSobRemarks.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please fill Remarks.")
                    '        Functions.ControlFocus(TxtSobRemarks)
                    '        Return
                    '    End If

                    'End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET COD_TYPE_ID = '" & lstCODType.SelectedValue & "',COD_TYPE='" & lstCODType.SelectedItem.Text & "',  TRANSHIPMENT_ETA=DECODE('" & TxtTranshipmetETA.Text.Trim & "','',TRANSHIPMENT_ETA,TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY')),SOB_REMARK= '" & TxtSobRemarks.Text.Trim & "', TRANSHIPMENT_VESSEL=DECODE('" & TxtTranshipmentVeseel.Text.Trim & "','',TRANSHIPMENT_VESSEL,'" & TxtTranshipmentVeseel.Text.Trim & "'),TRANSHIPMENT_ETD=DECODE('" & TxtTranshipmetDate.Text.Trim & "','',TRANSHIPMENT_ETD,TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY')),TRANSHIPMENT_PORT=DECODE('" & LsttranshipmentPort.SelectedItem.Text & "','',TRANSHIPMENT_PORT,'" & LsttranshipmentPort.SelectedItem.Text & "'),TRANS_PORT_ID=DECODE(" & LsttranshipmentPort.SelectedValue & ",0,TRANS_PORT_ID," & LsttranshipmentPort.SelectedValue & "), TRANSHIPMENT_VESSEL2='" & TxtTranshipmentVeseel2.Text.Trim & "',TRANSHIPMENT_ETD2=TO_DATE('" & TxtTranshipmetDate2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA2=TO_DATE('" & TxtTranshipmetETA2.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT2='" & LsttranshipmentPort2.SelectedItem.Text & "',TRANS_PORT_ID2=" & LsttranshipmentPort2.SelectedValue & ",FOLLOWUP_DATE=TO_DATE('" & TxtFollowup.Text.Trim & "','DD/MM/YYYY'), SAILED=DECODE('" & lstSob.Text.Trim & "','',SAILED,TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY')),SOB='SOB',REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_ETA=TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'),FINAL_ETD=TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        Dim strConnectionString, cmd2 As String
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = " Insert into SOB_UPDATION (SOB_TRACK_ID,TRANS_PORT_ID,TRANSHIPMENT_PORT,FINAL_VESSEL,FINAL_ETD,ETA,TRANSHIPMENT_ETA,TRANSHIPMENT_ETD,TRANSHIPMENT_VESSEL,SOB_DATE,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                             & " VALUES (SOB_TRACK_ID.NEXTVAL," & LsttranshipmentPort.SelectedValue & ",'" & LsttranshipmentPort.SelectedItem.Text & "','" & TxtRequiredVessel.Text.Trim & "', NVL(TO_DATE('" & TxtRequiredEtd.Text.Trim & "','DD/MM/YYYY'),''), NVL(TO_DATE('" & TxtRequiredETA.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),''), '" & TxtTranshipmentVeseel.Text.Trim & "'," _
                              & "  NVL(TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY HH24:MI'),'')," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
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
        btnUpdate.Visible = False
        BindData()
        'MsgBox(checkedRowCount & " :Records " & "Update Successfully", MsgBoxStyle.Information, "Update Records")

        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

    End Sub
End Class


