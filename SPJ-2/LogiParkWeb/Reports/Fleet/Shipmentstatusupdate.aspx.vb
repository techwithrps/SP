Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports AjaxControlToolkit
Imports System.Windows
Imports System
Partial Class Reports_Fleet_PortArrivalUpdate
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrPodId As ArrayList
    Dim arrPodName As ArrayList
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'prepareTerminalData()
            'preparePortData()
            ListControlDataBind()
            ListControlDataBind1()
            BindData()
        End If
    End Sub
    Sub ListControlDataBind1()
        Dim strConnectionString, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSHIPMENT_VESSEL FROM ALL_PARTY_ACCOUNT AP WHERE SHIPMENT_STATUS <> 3 AND LINE_HANDOVER_DATE >=TO_DATE('1/11/2017','DD/MM/YYYY') AND TRANSHIPMENT_VESSEL IS NOT NULL  ORDER BY TRANSHIPMENT_VESSEL ASC"
            cmd4 = "SELECT DISTINCT REQUIRED_VESSEL FROM ALL_PARTY_ACCOUNT AP WHERE SHIPMENT_STATUS <> 3 AND LINE_HANDOVER_DATE >=TO_DATE('1/11/2017','DD/MM/YYYY') AND REQUIRED_VESSEL IS NOT NULL  ORDER BY REQUIRED_VESSEL ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ' ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada = New OleDbDataAdapter(cmd3, con)
            Dim ds3 As New DataSet("PORT_MASTER")
            ada.Fill(ds3)
            LstFtrans.DataSource = ds3.Tables(0)
            LstFtrans.DataTextField = "TRANSHIPMENT_VESSEL"
            LstFtrans.DataValueField = "TRANSHIPMENT_VESSEL"
            LstFtrans.DataBind()
            LstFtrans.Items.Insert(0, (New ListItem("---Select---", "")))
            ds3.Clear()
            con.Close()
            ada = New OleDbDataAdapter(cmd4, con)
            Dim ds4 As New DataSet("PORT_MASTER")
            ada.Fill(ds4)
            lstFRequiredVessel.DataSource = ds4.Tables(0)
            lstFRequiredVessel.DataTextField = "REQUIRED_VESSEL"
            lstFRequiredVessel.DataValueField = "REQUIRED_VESSEL"
            lstFRequiredVessel.DataBind()
            lstFRequiredVessel.Items.Insert(0, (New ListItem("---Select---", "")))
            ds4.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub preparePod(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("", ""))
            For i As Integer = 0 To arrPodId.Count - 1
                lst.Items.Add(New ListItem(arrPodName(i), arrPodId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub preparePortData()
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
    Private Sub BindData()
        Dim strConnectionString, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSIT_TIME FROM(SELECT  ROUND(FINAL_ETA-CURRENT_ETD)TRANSIT_TIME FROM ALL_PARTY_ACCOUNT AP,FLEET_CONT_JO_DTLS FCD WHERE LINE_HANDOVER_DATE >=TO_DATE('1/10/2017','DD/MM/YYYY') AND SAILED IS NOT NULL AND EMPTY_GATE_IN_DATE IS NULL " &
                "AND AP.POD_ID=DECODE(" & LstPort.SelectedValue & ",0,POD_ID," & LstPort.SelectedValue & ") AND AP.POL_ID=DECODE(" & Lstpol.SelectedValue & ",0,POL_ID," & Lstpol.SelectedValue & ")" &
                "AND FCD.MTY_CONT_ID=AP.MTY_CONT_ID AND FCD.LINE_ID =DECODE(" & lstLine.SelectedValue & ",0,FCD.LINE_ID," & lstLine.SelectedValue & ") AND NVL(AP.SHIPMENT_STATUS,0)=DECODE(" & lststatus.SelectedValue & ",0,0," & lststatus.SelectedValue & ") ) ORDER BY TRANSIT_TIME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ' ada = New OleDbDataAdapter(cmd1, con)
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
        preparePortData()
        prepareTerminalData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & lstLine.SelectedValue
        strpParms &= "," & LstPort.SelectedValue
        strpParms &= "," & Lstpol.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        Dim dt As DataTable
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        dt = New DataTable()
        dt = AddAutoIncrementColumn()
        dt.Load(dbr)
        gvtripPendencyList.DataSource = dt
        gvtripPendencyList.DataBind()
        'If dbr.HasRows Then
        '    tblReport.Visible = True
        'Else
        '    tblReport.Visible = False
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        'End If
        dbr.Close()
        db.CloseDB()
        btnRemarkUpdate.Visible = False
        '  lstustaus.SelectedValue = 0
        ' textDeliveryDate.Text = ""
    End Sub
    Private Shared Function AddAutoIncrementColumn() As DataTable

        Dim myDataColumn As New DataColumn()
        myDataColumn.AllowDBNull = False
        myDataColumn.AutoIncrement = True
        myDataColumn.AutoIncrementSeed = 1
        myDataColumn.AutoIncrementStep = 1
        myDataColumn.ColumnName = "Sr. No"
        myDataColumn.DataType = System.Type.[GetType]("System.Int32")
        myDataColumn.Unique = True

        'Create a new datatable
        Dim mydt As New DataTable()

        'Add this AutoIncrement Column to a new datatable
        mydt.Columns.Add(myDataColumn)

        Return mydt

    End Function
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pPortMaster As New PortMaster
            LstPort.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            LstPort.DataTextField = "PortName"
            LstPort.DataValueField = "PortId"
            LstPort.DataBind()
            LstPort.Items.Insert(0, (New ListItem("---All---", 0)))
            LstPort.SelectedValue = 0
            Lstpol.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            Lstpol.DataTextField = "PortName"
            Lstpol.DataValueField = "PortId"
            Lstpol.DataBind()
            Lstpol.Items.Insert(0, (New ListItem("---All---", 0)))
            Lstpol.SelectedValue = 0
            Dim PcustomerMaster As New CustomerMaster
            lstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(PcustomerMaster)
            lstLine.DataTextField = "CustomerName"
            lstLine.DataValueField = "CustomerId"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            lstLine.SelectedValue = 0
            lstetaline.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(PcustomerMaster)
            lstetaline.DataTextField = "CustomerName"
            lstetaline.DataValueField = "CustomerId"
            lstetaline.DataBind()
            lstetaline.Items.Insert(0, (New ListItem("---All---", 0)))
            lstetaline.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        preparePortData()
        Dim strConnectionString, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSIT_TIME FROM(SELECT  ROUND(FINAL_ETA-CURRENT_ETD)TRANSIT_TIME FROM ALL_PARTY_ACCOUNT AP,FLEET_CONT_JO_DTLS FCD WHERE LINE_HANDOVER_DATE >=TO_DATE('1/10/2017','DD/MM/YYYY') AND SAILED IS NOT NULL AND EMPTY_GATE_IN_DATE IS NULL" &
                "AND AP.POD_ID=DECODE(" & LstPort.SelectedValue & ",0,POD_ID," & LstPort.SelectedValue & ") AND AP.POL_ID=DECODE(" & Lstpol.SelectedValue & ",0,POL_ID," & Lstpol.SelectedValue & ")" &
                "AND FCD.MTY_CONT_ID=AP.MTY_CONT_ID AND FCD.LINE_ID =DECODE(" & lstLine.SelectedValue & ",0,FCD.LINE_ID," & lstLine.SelectedValue & ") AND NVL(AP.SHIPMENT_STATUS,0)=DECODE(" & lststatus.SelectedValue & ",0,0," & lststatus.SelectedValue & ") ) ORDER BY TRANSIT_TIME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ' ada = New OleDbDataAdapter(cmd1, con)
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
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & lstLine.SelectedValue
        strpParms &= "," & LstPort.SelectedValue
        strpParms &= "," & Lstpol.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
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
                    Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
                    '  Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
                    Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
                    Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
                    Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
                    Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
                    Dim ShipmentRemark As TextBox = TryCast(row.Cells(0).FindControl("ShipmentRemark"), TextBox)
                    Dim TxtFollowup As TextBox = TryCast(row.Cells(0).FindControl("TxtFollowup"), TextBox)
                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)
                    Dim lstTranshipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstTranshipmentStatus"), DropDownList)
                    Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)

                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim clRailOutdate4 = TryCast(row.Cells(0).FindControl("clRailOutdate4"), CalendarExtender)
                    clRailOutdate4.EndDate = DateTime.Now.Date
                    'Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
                    'clRailOutdate1.EndDate = DateTime.Now.Date
                    Dim clRailOutdate6 = TryCast(row.Cells(0).FindControl("clRailOutdate6"), CalendarExtender)
                    clRailOutdate6.EndDate = DateTime.Now.Date
                    Dim clRailOutdate7 = TryCast(row.Cells(0).FindControl("clRailOutdate7"), CalendarExtender)
                    clRailOutdate7.EndDate = DateTime.Now.Date
                    Dim clTxtFollowup = TryCast(row.Cells(0).FindControl("clTxtFollowup"), CalendarExtender)
                    clTxtFollowup.StartDate = DateTime.Now.Date
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT nvl(SHIPMENT_STATUS,0),DECODE(SOB_REMARK,'MOVES NOT UPDATED',1,'HIGH',2,'STOP MAIL',3,0),nvl(TRANS_PORT_ID,0) FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                    Try
                        LsttranshipmentPort.SelectedValue = ada.GetValue(2)
                    Catch ex As Exception
                    End Try

                End If
            End If
        Next
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    ''row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
                    row.Cells(i).FindControl("lblCurrentEta").Visible = Not isChecked
                    row.Cells(i).FindControl("lblDischargeDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblGateOutDate").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetEta").Visible = Not isChecked
                    row.Cells(i).FindControl("lblEmptyGateInDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblTransitTime").Visible = Not isChecked
                    row.Cells(i).FindControl("LblFollowup").Visible = Not isChecked
                    ' row.Cells(i).FindControl("lblTShipmentStatus").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRequiredETD").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRequiredVessel").Visible = Not isChecked
                    row.Cells(i).FindControl("lbltranshipmentPort").Visible = Not isChecked
                    row.Cells(i).FindControl("LblTranshipmetDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblTranshipmentVeseel").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCODType").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPOD").Visible = Not isChecked

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
        ImgBtnUpdate.Visible = isUpdateVisible
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        preparePortData()
        Dim strConnectionString, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd3 = "SELECT DISTINCT TRANSIT_TIME FROM(SELECT  ROUND(FINAL_ETA-CURRENT_ETD)TRANSIT_TIME FROM ALL_PARTY_ACCOUNT AP,FLEET_CONT_JO_DTLS FCD WHERE LINE_HANDOVER_DATE >=TO_DATE('1/10/2017','DD/MM/YYYY') AND SAILED IS NOT NULL AND EMPTY_GATE_IN_DATE IS NULL " &
                "AND AP.POD_ID=DECODE(" & LstPort.SelectedValue & ",0,POD_ID," & LstPort.SelectedValue & ") AND AP.POL_ID=DECODE(" & Lstpol.SelectedValue & ",0,POL_ID," & Lstpol.SelectedValue & ")" &
                "AND FCD.MTY_CONT_ID=AP.MTY_CONT_ID AND FCD.LINE_ID =DECODE(" & lstLine.SelectedValue & ",0,FCD.LINE_ID," & lstLine.SelectedValue & ") AND NVL(AP.SHIPMENT_STATUS,0)=DECODE(" & lststatus.SelectedValue & ",0,0," & lststatus.SelectedValue & ") ) ORDER BY TRANSIT_TIME ASC"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ' ada = New OleDbDataAdapter(cmd1, con)
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
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstLine.SelectedValue
        strpParms &= "," & LstPort.SelectedValue
        strpParms &= "," & lststatus.SelectedValue
        strpParms &= "," & Lstpol.SelectedValue
        strpParms &= "," & LstTransitTime.SelectedValue
        strpParms &= ",'" & lstdremark.SelectedItem.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        preparePortData()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstLine.SelectedValue
        strpParms &= "," & LstPort.SelectedValue
        strpParms &= "," & lststatus.SelectedValue
        strpParms &= "," & Lstpol.SelectedValue
        strpParms &= "," & LstTransitTime.SelectedValue
        strpParms &= ",'" & lstdremark.SelectedItem.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
                    Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
                    Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
                    Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
                    Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
                    Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
                    Dim TxtRequiredETD As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETD"), TextBox)
                    Dim ShipmentRemark As TextBox = TryCast(row.Cells(0).FindControl("ShipmentRemark"), TextBox)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    Dim TxtFollowup As TextBox = TryCast(row.Cells(0).FindControl("TxtFollowup"), TextBox)
                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)
                    Dim lstTranshipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstTranshipmentStatus"), DropDownList)

                    Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)

                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET FPOD_ID = '" & ddlPOD.SelectedValue & "',FPOD='" & ddlPOD.SelectedItem.Text & "',TRANSHIPMENT_STATUS_ID = '" & lstTranshipmentStatus.SelectedValue & "',TRANSHIPMENT_STATUS='" & lstTranshipmentStatus.SelectedItem.Text & "', COD_TYPE_ID = '" & lstCODType.SelectedValue & "',COD_TYPE='" & lstCODType.SelectedItem.Text & "', TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY')," _
                        & " TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID='" & LsttranshipmentPort.SelectedValue & "',SHIPMENT_REMARK= NVL('" & ShipmentRemark.Text.Trim & "',''),REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_ETA=TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY'),FOLLOWUP_DATE=TO_DATE('" & TxtFollowup.Text.Trim & "','DD/MM/YYYY')," _
                         & " DISCHARGE_DATE =TO_DATE(NVL('" & TxtDischargeDate.Text.Trim & "',''),'DD/MM/YYYY'),GATE_OUT_DATE=TO_DATE(NVL('" & TxtGateOutDate.Text.Trim & "',''),'DD/MM/YYYY'),EMPTY_GATE_IN_DATE=TO_DATE(NVL('" & TxtEmptyGateInDate.Text.Trim & "',''),'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                        Dim strConnectionString, cmd2 As String
                        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                        cmd2 = " Insert into SHIPMENT_UPDATION (SHIB_TRACK_ID,TRANS_PORT_ID,TRANSHIPMENT_PORT,FINAL_VESSEL,FINAL_ETD,ETA,TRANSHIPMENT_ETA,TRANSHIPMENT_ETD,TRANSHIPMENT_VESSEL,DISCHARGE_DATE,GATE_OUT_DATE,EMPTY_GATE_IN_DATE,MTY_CONT_ID,CONT_NO,CREATED_BY,CREATED_ON) " _
                             & " VALUES (SHIB_TRACK_ID.NEXTVAL," & LsttranshipmentPort.SelectedValue & ",'" & LsttranshipmentPort.SelectedItem.Text & "','" & TxtRequiredVessel.Text.Trim & "', NVL(TO_DATE('" & TxtRequiredETD.Text.Trim & "','DD/MM/YYYY'),''), NVL(TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),''), '" & TxtTranshipmentVeseel.Text.Trim & "'," _
                              & " NVL(TO_DATE('" & TxtDischargeDate.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtGateOutDate.Text.Trim & "','DD/MM/YYYY'),''),NVL(TO_DATE('" & TxtEmptyGateInDate.Text.Trim & "','DD/MM/YYYY'),'')," & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate) "
                        con = New OleDbConnection(strConnectionString)
                        con.Open()
                        Dim cmd5 As New OleDbCommand(cmd2, con)
                        cmd5.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                    End Try
                    gvtripPendencyList.EditIndex = -1
                End If
            End If
        Next
        BindData()

        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)


    End Sub

    Protected Sub btnRemarkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemarkUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET   SOB_REMARK= NVL('" & lstRemarks.SelectedItem.Text & "',''),  CONFIRM_MAIL_DATE=TO_DATE(SYSDATE, 'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                    End Try
                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        btnRemarkUpdate.Visible = False
        BindData()
    End Sub

    Protected Sub btnRDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRDisplay.Click
        preparePortData()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstLine.SelectedValue
        strpParms &= "," & LstPort.SelectedValue
        strpParms &= "," & lststatus.SelectedValue
        strpParms &= "," & Lstpol.SelectedValue
        strpParms &= "," & LstTransitTime.SelectedValue
        strpParms &= ",'" & lstdremark.SelectedItem.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub Btnetadisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnetadisplay.Click
        preparePortData()
        If textFromDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(textToDate)
            Return
        End If
        Dim strpParms As String = ""
        strpParms &= "'" & textFromDate.Text.Trim & "',"
        strpParms &= "'" & textToDate.Text.Trim & "',"
        strpParms &= lstetaline.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        Dim dt As DataTable
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        dt = New DataTable()
        dt = AddAutoIncrementColumn()
        dt.Load(dbr)
        gvtripPendencyList.DataSource = dt
        gvtripPendencyList.DataBind()
        dbr.Close()
        db.CloseDB()

    End Sub

    Protected Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        preparePortData()
        Dim strpParms As String = ""
        strpParms &= "'" & LstFtrans.SelectedValue & "',"
        strpParms &= "'" & lstFRequiredVessel.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        Dim dt As DataTable
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT_LIVE", strpParms)
        dt = New DataTable()
        dt = AddAutoIncrementColumn()
        dt.Load(dbr)
        gvtripPendencyList.DataSource = dt
        gvtripPendencyList.DataBind()
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub

    ' ================================================================
    ' BULK UPDATE VIA CSV
    ' Editable fields covered: Transhipment ETA, Transhipment Port,
    ' Transhipment ETD, Transhipment Vessel, ETA, Discharge Date,
    ' Gate Out Date, Empty Gate In Date, Followup Date.
    ' ================================================================

    ''' <summary>
    ''' Holder for every field one CSV row can update for a given MTY_CONT_ID.
    ''' </summary>
    Private Class UploadedShipmentDates
        Public Property TranshipmentETA As String
        Public Property TranshipmentPort As String
        Public Property TranshipmentETD As String
        Public Property TranshipmentVessel As String
        Public Property ETA As String
        Public Property DischargeDate As String
        Public Property GateOutDate As String
        Public Property EmptyGateInDate As String
        Public Property FollowupDate As String
    End Class

    ''' <summary>
    ''' Accepts "DD-MM-YYYY" or "DD/MM/YYYY" from the CSV and always returns "DD/MM/YYYY",
    ''' since that's the format every CalendarExtender, the client-side validateData() JS,
    ''' and the TO_DATE(...,'DD/MM/YYYY') calls in ImgBtnUpdate_Click all expect.
    ''' </summary>
    Private Function NormalizeDateString(ByVal value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty
        Return value.Trim().Replace("-", "/")
    End Function

    ''' <summary>
    ''' Replaces the HTML non-breaking space ASP.NET renders for empty grid cells
    ''' with an actual empty string, and trims the result.
    ''' </summary>
    Private Function CleanCellText(ByVal value As String) As String
        If String.IsNullOrEmpty(value) Then Return String.Empty
        Return value.Replace("&nbsp;", "").Trim()
    End Function

    ''' <summary>
    ''' Wraps a value in double quotes (escaping embedded quotes) if it contains a
    ''' comma, quote, or line break, so the CSV stays valid.
    ''' </summary>
    Private Function CsvEscape(ByVal value As String) As String
        If String.IsNullOrEmpty(value) Then Return String.Empty
        If value.Contains(",") OrElse value.Contains(""""c) OrElse value.Contains(vbCr) OrElse value.Contains(vbLf) Then
            Return """" & value.Replace("""", """""") & """"
        End If
        Return value
    End Function

    ''' <summary>
    ''' Downloads a CSV pre-filled with the CURRENT values for every field that can be
    ''' bulk-updated: Transhipment ETA/Port/ETD/Vessel, ETA, Discharge Date, Gate Out Date,
    ''' Empty Gate In Date and Followup Date. The user edits the columns they need changed
    ''' and re-uploads the same file. MTY_CONT_ID is the match key and must not be edited.
    ''' </summary>
    Protected Sub btnDownloadTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownloadTemplate.Click
        Try
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("MTY_CONT_ID,Container No,Port, Shipper, Line,Booking No,Transhipment ETA,Transhipment Port,Transhipment ETD,Transhipment Vessel,ETA,Discharge Date,Gate Out Date,Empty Gate In Date,Followup Date")

            ' Column indices for the plain BoundFields (0-based, per gvtripPendencyList markup):
            Const COL_SHIPPER As Integer = 5
            Const COL_LINE As Integer = 6
            Const COL_PORT As Integer = 4
            Const COL_BOOKING_NO As Integer = 7

            If gvtripPendencyList.Rows.Count = 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "There is no data in the grid to export.")
                Return
            End If

            For Each row As GridViewRow In gvtripPendencyList.Rows
                If row.RowType = DataControlRowType.DataRow Then

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim lblCONT_NO As Label = TryCast(row.Cells(2).FindControl("lblCONT_NO"), Label)

                    Dim lblTranshipmetEta As Label = TryCast(row.Cells(0).FindControl("LblTranshipmetEta"), Label)
                    Dim lblTranshipmentPort As Label = TryCast(row.Cells(0).FindControl("lbltranshipmentPort"), Label)
                    Dim lblTranshipmetDate As Label = TryCast(row.Cells(0).FindControl("LblTranshipmetDate"), Label)
                    Dim lblTranshipmentVeseel As Label = TryCast(row.Cells(0).FindControl("lblTranshipmentVeseel"), Label)
                    Dim lblCurrentEta As Label = TryCast(row.Cells(0).FindControl("lblCurrentEta"), Label)
                    Dim lblDischargeDate As Label = TryCast(row.Cells(0).FindControl("lblDischargeDate"), Label)
                    Dim lblGateOutDate As Label = TryCast(row.Cells(0).FindControl("lblGateOutDate"), Label)
                    Dim lblEmptyGateInDate As Label = TryCast(row.Cells(0).FindControl("lblEmptyGateInDate"), Label)
                    Dim lblFollowup As Label = TryCast(row.Cells(0).FindControl("LblFollowup"), Label)


                    Dim mtyContId As String = If(hdnMTY_CONT_ID IsNot Nothing, hdnMTY_CONT_ID.Value, String.Empty)
                    Dim containerNo As String = If(lblCONT_NO IsNot Nothing, lblCONT_NO.Text, String.Empty)
                    Dim port As String = row.Cells(COL_PORT).Text

                    Dim SHIPPER As String = row.Cells(COL_SHIPPER).Text
                    Dim LINE As String = row.Cells(COL_LINE).Text

                    Dim bookingNo As String = row.Cells(COL_BOOKING_NO).Text

                    Dim transEta As String = If(lblTranshipmetEta IsNot Nothing, lblTranshipmetEta.Text, String.Empty)
                    Dim transPort As String = If(lblTranshipmentPort IsNot Nothing, lblTranshipmentPort.Text, String.Empty)
                    Dim transEtd As String = If(lblTranshipmetDate IsNot Nothing, lblTranshipmetDate.Text, String.Empty)
                    Dim transVessel As String = If(lblTranshipmentVeseel IsNot Nothing, lblTranshipmentVeseel.Text, String.Empty)
                    Dim eta As String = If(lblCurrentEta IsNot Nothing, lblCurrentEta.Text, String.Empty)
                    Dim dischargeDate As String = If(lblDischargeDate IsNot Nothing, lblDischargeDate.Text, String.Empty)
                    Dim gateOutDate As String = If(lblGateOutDate IsNot Nothing, lblGateOutDate.Text, String.Empty)
                    Dim emptyGateInDate As String = If(lblEmptyGateInDate IsNot Nothing, lblEmptyGateInDate.Text, String.Empty)
                    Dim followupDate As String = If(lblFollowup IsNot Nothing, lblFollowup.Text, String.Empty)

                    ' "&nbsp;" is what empty BoundField/Label cells render as - treat it as blank.
                    mtyContId = CleanCellText(mtyContId)
                    port = CleanCellText(port)

                    SHIPPER = CleanCellText(SHIPPER)
                    LINE = CleanCellText(LINE)

                    bookingNo = CleanCellText(bookingNo)
                    transEta = CleanCellText(transEta)
                    transPort = CleanCellText(transPort)
                    transEtd = CleanCellText(transEtd)
                    transVessel = CleanCellText(transVessel)
                    eta = CleanCellText(eta)
                    dischargeDate = CleanCellText(dischargeDate)
                    gateOutDate = CleanCellText(gateOutDate)
                    emptyGateInDate = CleanCellText(emptyGateInDate)
                    followupDate = CleanCellText(followupDate)

                    sb.AppendLine(String.Join(",",
                        CsvEscape(mtyContId),
                        CsvEscape(containerNo),
                        CsvEscape(port),
                        CsvEscape(SHIPPER),
                            CsvEscape(LINE),
                        CsvEscape(bookingNo),
                        CsvEscape(transEta),
                        CsvEscape(transPort),
                        CsvEscape(transEtd),
                        CsvEscape(transVessel),
                        CsvEscape(eta),
                        CsvEscape(dischargeDate),
                        CsvEscape(gateOutDate),
                        CsvEscape(emptyGateInDate),
                        CsvEscape(followupDate)))
                End If
            Next

            Response.Clear()
            Response.ContentType = "text/csv"
            Response.AddHeader("Content-Disposition", "attachment; filename=ShipmentStatus_Template.csv")
            Response.Charset = ""
            Response.Write(sb.ToString())
            Response.Flush()
            Response.End()
        Catch ex As System.Threading.ThreadAbortException
            ' Raised by Response.End() - safe to ignore
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Unable to download template: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Reads the uploaded CSV (MTY_CONT_ID, Container No, Port, Booking No, Transhipment ETA,
    ''' Transhipment Port, Transhipment ETD, Transhipment Vessel, ETA, Discharge Date,
    ''' Gate Out Date, Empty Gate In Date, Followup Date) and matches each row to a grid row
    ''' in memory using the hidden MTY_CONT_ID field - no database call happens here.
    ''' Matching rows get checked and EVERY one of the 9 editable fields is explicitly set
    ''' (from the CSV value when non-blank, otherwise the field is left exactly as it was,
    ''' so nothing goes blank because of the upload). Transhipment Port is matched against
    ''' the dropdown's items by text. The 3 other editable dropdowns not covered by this CSV
    ''' (FPOD, COD Type, Transhipment Status) are pre-selected to their CURRENT database value
    ''' so that clicking Update afterwards does not silently overwrite them with a blank/first
    ''' item. Review the highlighted rows on screen, then click Update (ImgBtnUpdate) to save.
    ''' Expected date format: DD/MM/YYYY or DD-MM-YYYY (blank cell = leave field unchanged).
    ''' </summary>
    Protected Sub btnUploadCsv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadCsv.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        If Not FileUploadCsv.HasFile Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please select a CSV file to upload")
            Return
        End If

        If Not FileUploadCsv.FileName.ToLower().EndsWith(".csv") Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please upload a valid .csv file")
            Return
        End If

        ' Key = MTY_CONT_ID (as text) from the CSV, Value = the 9 editable field values for that row.
        Dim csvRowsById As New Dictionary(Of String, UploadedShipmentDates)
        Dim skippedRows As Integer = 0

        Dim sr As StreamReader = Nothing
        Try
            sr = New StreamReader(FileUploadCsv.FileContent)
            Dim isHeaderRow As Boolean = True
            Dim line As String

            Do While Not sr.EndOfStream
                line = sr.ReadLine()

                If isHeaderRow Then
                    isHeaderRow = False
                    Continue Do
                End If

                If String.IsNullOrWhiteSpace(line) Then Continue Do

                Dim cols() As String = line.Split(","c)
                Dim colGet As Func(Of Integer, String) = Function(idx As Integer) If(cols.Length > idx, cols(idx).Trim().Trim(""""c), "")

                Dim strMtyContId As String = colGet(0)
                ' cols(1)=Container No, cols(2)=Port, cols(3)=Booking No - reference only,
                ' matching is done on MTY_CONT_ID (cols(0)).

                If strMtyContId = "" Then
                    skippedRows += 1
                    Continue Do
                End If

                csvRowsById(strMtyContId) = New UploadedShipmentDates With {
                    .TranshipmentETA = colGet(6),
                    .TranshipmentPort = colGet(7),
                    .TranshipmentETD = colGet(8),
                    .TranshipmentVessel = colGet(9),
                    .ETA = colGet(10),
                    .DischargeDate = colGet(11),
                    .GateOutDate = colGet(12),
                    .EmptyGateInDate = colGet(13),
                    .FollowupDate = colGet(14)
                }
            Loop
        Catch ex As Exception
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Upload failed: " & ex.Message)
            Return
        Finally
            If sr IsNot Nothing Then sr.Close()
        End Try

        Dim matchedIds As New HashSet(Of String)
        Dim matchedCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                If hdnMTY_CONT_ID Is Nothing Then Continue For

                Dim rowId As String = hdnMTY_CONT_ID.Value.Trim()
                Dim uploadedDates As UploadedShipmentDates = Nothing

                If rowId <> "" AndAlso csvRowsById.TryGetValue(rowId, uploadedDates) Then
                    matchedIds.Add(rowId)
                    matchedCount += 1

                    Dim chkRow As CheckBox = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault()
                    If chkRow IsNot Nothing Then chkRow.Checked = True

                    Dim txtTranshipmetEta As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    Dim lstTranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim txtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim txtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim txtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
                    Dim txtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
                    Dim txtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
                    Dim txtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
                    Dim txtFollowup As TextBox = TryCast(row.Cells(0).FindControl("TxtFollowup"), TextBox)

                    ' ---- 9 CSV-driven fields: only overwrite when the CSV cell is non-blank ----
                    If uploadedDates.TranshipmentETA <> "" AndAlso txtTranshipmetEta IsNot Nothing Then
                        txtTranshipmetEta.Text = NormalizeDateString(uploadedDates.TranshipmentETA)
                    End If

                    If uploadedDates.TranshipmentPort <> "" AndAlso lstTranshipmentPort IsNot Nothing Then
                        Dim matched As Boolean = False
                        For Each li As ListItem In lstTranshipmentPort.Items
                            If String.Equals(li.Text.Trim(), uploadedDates.TranshipmentPort.Trim(), StringComparison.OrdinalIgnoreCase) Then
                                lstTranshipmentPort.ClearSelection()
                                li.Selected = True
                                matched = True
                                Exit For
                            End If
                        Next
                        ' If no match found, the dropdown keeps whatever it was pre-selected to
                        ' (its OnDataBinding="preparePod" default), so a typo in the CSV port
                        ' name never blanks out the existing port silently.
                    End If

                    If uploadedDates.TranshipmentETD <> "" AndAlso txtTranshipmetDate IsNot Nothing Then
                        txtTranshipmetDate.Text = NormalizeDateString(uploadedDates.TranshipmentETD)
                    End If
                    If uploadedDates.TranshipmentVessel <> "" AndAlso txtTranshipmentVeseel IsNot Nothing Then
                        txtTranshipmentVeseel.Text = uploadedDates.TranshipmentVessel
                    End If
                    If uploadedDates.ETA <> "" AndAlso txtCurrentEta IsNot Nothing Then
                        txtCurrentEta.Text = NormalizeDateString(uploadedDates.ETA)
                    End If
                    If uploadedDates.DischargeDate <> "" AndAlso txtDischargeDate IsNot Nothing Then
                        txtDischargeDate.Text = NormalizeDateString(uploadedDates.DischargeDate)
                    End If
                    If uploadedDates.GateOutDate <> "" AndAlso txtGateOutDate IsNot Nothing Then
                        txtGateOutDate.Text = NormalizeDateString(uploadedDates.GateOutDate)
                    End If
                    If uploadedDates.EmptyGateInDate <> "" AndAlso txtEmptyGateInDate IsNot Nothing Then
                        txtEmptyGateInDate.Text = NormalizeDateString(uploadedDates.EmptyGateInDate)
                    End If
                    If uploadedDates.FollowupDate <> "" AndAlso txtFollowup IsNot Nothing Then
                        txtFollowup.Text = NormalizeDateString(uploadedDates.FollowupDate)
                    End If

                    ' ---- Fields NOT covered by this CSV: pre-select them to their CURRENT
                    ' value so ImgBtnUpdate_Click (which always writes ddlPOD/lstCODType/
                    ' lstTranshipmentStatus back to the DB) does not blank them out. ----
                    Dim ddlPOD As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOD"), DropDownList)
                    Dim lblPOD As Label = TryCast(row.Cells(0).FindControl("lblPOD"), Label)
                    SelectDropDownByLabelText(ddlPOD, lblPOD)

                    Dim lstCODType As DropDownList = TryCast(row.Cells(0).FindControl("lstCODType"), DropDownList)
                    Dim lblCODType As Label = TryCast(row.Cells(0).FindControl("lblCODType"), Label)
                    SelectDropDownByLabelText(lstCODType, lblCODType)

                    Dim lstTranshipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstTranshipmentStatus"), DropDownList)
                    Dim lblTranshipmentStatus As Label = TryCast(row.Cells(0).FindControl("lblTranshipmentStatus"), Label)
                    SelectDropDownByLabelText(lstTranshipmentStatus, lblTranshipmentStatus)
                End If
            End If
        Next

        ' Toggle the inline "display" style (NOT the server-side .Visible property, since these
        ' controls are always rendered and are shown/hidden purely via CSS - see EnableDisableCtrol
        ' in the .aspx page). This is what actually makes the CSV-filled values appear on screen.
        Dim isUpdateVisible As Boolean = False

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim chkRow As CheckBox = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault()
                Dim isChecked As Boolean = chkRow IsNot Nothing AndAlso chkRow.Checked
                Dim displayVal As String = If(isChecked, "block", "none")
                Dim labelVal As String = If(isChecked, "none", "inline")

                Dim togglePairs As New Dictionary(Of String, String)
                togglePairs.Add("LblTranshipmetEta", "TxtTranshipmetETA")
                togglePairs.Add("lbltranshipmentPort", "LsttranshipmentPort")
                togglePairs.Add("LblTranshipmetDate", "TxtTranshipmetDate")
                togglePairs.Add("lblTranshipmentVeseel", "TxtTranshipmentVeseel")
                togglePairs.Add("lblCurrentEta", "TxtCurrentEta")
                togglePairs.Add("lblDischargeDate", "TxtDischargeDate")
                togglePairs.Add("lblGateOutDate", "TxtGateOutDate")
                togglePairs.Add("lblEmptyGateInDate", "TxtEmptyGateInDate")
                togglePairs.Add("LblFollowup", "TxtFollowup")
                togglePairs.Add("lblPOD", "ddlPOD")
                togglePairs.Add("lblCODType", "lstCODType")
                togglePairs.Add("lblTranshipmentStatus", "lstTranshipmentStatus")
                togglePairs.Add("lblRemark", "ShipmentRemark")

                For Each pair In togglePairs
                    Dim lbl As WebControl = TryCast(row.Cells(0).FindControl(pair.Key), WebControl)
                    Dim editor As WebControl = TryCast(row.Cells(0).FindControl(pair.Value), WebControl)
                    If lbl IsNot Nothing Then lbl.Style("display") = labelVal
                    If editor IsNot Nothing Then editor.Style("display") = displayVal
                Next

                If isChecked Then isUpdateVisible = True
            End If
        Next
        ImgBtnUpdate.Visible = isUpdateVisible

        Dim notFoundIds = csvRowsById.Keys.Where(Function(id) Not matchedIds.Contains(id)).ToList()

        Dim msg As String = matchedCount & " row(s) matched and filled in on the grid. Review the highlighted rows and click Update to save."
        If notFoundIds.Count > 0 Then
            msg &= " " & notFoundIds.Count & " MTY_CONT_ID value(s) from the file were not found in the grid (" & String.Join("; ", notFoundIds) & ")."
        End If
        If skippedRows > 0 Then
            msg &= " " & skippedRows & " row(s) in the file had no MTY_CONT_ID and were skipped."
        End If

        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, msg)
    End Sub

    ''' <summary>
    ''' Selects the item in ddl whose Text matches the current label text (case-insensitive),
    ''' so that a dropdown not covered by the CSV keeps showing/saving its existing value
    ''' instead of silently reverting to its first/blank item after Update.
    ''' </summary>
    Private Sub SelectDropDownByLabelText(ByVal ddl As DropDownList, ByVal lbl As Label)
        If ddl Is Nothing OrElse lbl Is Nothing Then Return
        Dim currentText As String = CleanCellText(lbl.Text)
        If currentText = "" Then Return
        For Each li As ListItem In ddl.Items
            If String.Equals(li.Text.Trim(), currentText, StringComparison.OrdinalIgnoreCase) Then
                ddl.ClearSelection()
                li.Selected = True
                Exit For
            End If
        Next
    End Sub
End Class