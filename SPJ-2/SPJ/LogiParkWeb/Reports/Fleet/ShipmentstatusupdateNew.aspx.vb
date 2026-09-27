Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services
Imports AjaxControlToolkit

Partial Class Reports_Fleet_ShipmentstatusupdateNew
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
            lst.Items.Add(New ListItem("----Select----", "0"))
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
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
    'Protected Sub BTNGO_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BTNGO.Click
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    gvtripPendencyList.DataSource = Nothing
    '    gvtripPendencyList.DataBind()
    '    tblReport.Visible = False

    '    ' textFromDate.Text = Now.Date
    '    ' textToDate.Text = Now.Date

    '    lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
    '    Dim strCurrentDate As String
    '    strCurrentDate = Format(Now, "MM/dd/yyyy")
    '    Dim strpParms As String = "0"
    '    strpParms &= lstLine.SelectedValue
    '    strpParms &= "," & LstPort.SelectedValue
    '    strpParms &= "," & lststatus.SelectedValue
    '    strpParms &= "," & lsttport.SelectedValue
    '    strpParms &= "," & LstTransitTime.SelectedValue
    '    'strpParms &= "," & LstCFS.SelectedValue & ""
    '    'strpParms &= ",'" & textToDate.Text & "'"
    '    Dim dbr As OleDb.OleDbDataReader
    '    Dim db As New DBConnect
    '    dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_DELIVERY_PEND_REPORT", strpParms)
    '    'Dim dt As New DataTable
    '    'dt.Load(dbr)
    '    gvtripPendencyList.DataSource = dbr
    '    gvtripPendencyList.DataBind()
    '    If dbr.HasRows Then
    '        tblReport.Visible = True
    '    Else
    '        tblReport.Visible = False
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
    '    End If
    '    dbr.Close()
    '    db.CloseDB()
    'End Sub
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
    'Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnUpdate.Click
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
    '                Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
    '                Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
    '                Dim TxtDeliveryDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDeliveryDate"), TextBox)
    '                Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
    '                Dim TxtRequiredETD As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETD"), TextBox)
    '                Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
    '                Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
    '                Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
    '                Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
    '                Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
    '                'If ddlCFS.SelectedValue = 0 Then
    '                '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select CFS Terminal")
    '                '    Functions.ControlFocus(ddlCFS)
    '                '    Return
    '                'End If
    '                Try
    '                    con = New OleDbConnection(cs)
    '                    con.Open()
    '                    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",SAILED=TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY'),SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''),REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_VESSEL='" & TxtRequiredVessel.Text.Trim & "',REQUIRED_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY'),SHIPMENT_STATUS=NVL(" & lstShipmentStatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lstShipmentStatus.SelectedItem.Text & "',''),TRANSIT_TIME=NVL(" & TxtTransitTime.Text.Trim & ",0),DELIVERY_DATE=TO_DATE(NVL('" & TxtDeliveryDate.Text.Trim & "',''),'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                    cmd.ExecuteNonQuery()
    '                    con.Close()
    '                Catch ex As Exception
    '                End Try
    '                gvtripPendencyList.EditIndex = -1
    '                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    '            End If
    '        End If
    '    Next
    '    ImgBtnUpdate.Visible = False
    '    BindData()
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
    '                Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
    '                '  Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
    '                Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
    '                Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
    '                Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
    '                Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
    '                Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
    '                Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
    '                Dim clRailOutdate4 = TryCast(row.Cells(0).FindControl("clRailOutdate4"), CalendarExtender)
    '                clRailOutdate4.EndDate = DateTime.Now.Date
    '                'Dim clRailOutdate1 = TryCast(row.Cells(0).FindControl("clRailOutdate1"), CalendarExtender)
    '                'clRailOutdate1.EndDate = DateTime.Now.Date
    '                Dim clRailOutdate6 = TryCast(row.Cells(0).FindControl("clRailOutdate6"), CalendarExtender)
    '                clRailOutdate6.EndDate = DateTime.Now.Date
    '                Dim clRailOutdate7 = TryCast(row.Cells(0).FindControl("clRailOutdate7"), CalendarExtender)
    '                clRailOutdate7.EndDate = DateTime.Now.Date
    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = "SELECT nvl(SHIPMENT_STATUS,0),DECODE(SOB_REMARK,'MOVES NOT UPDATED',1,'HIGH',2,'STOP MAIL',3,0),nvl(TRANS_PORT_ID,0) FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader
    '                ada.Read()
    '                'Try
    '                '    lstShipmentStatus.SelectedValue = ada.GetValue(0)
    '                'Catch ex As Exception
    '                'End Try
    '                'Try
    '                'LstRemark.SelectedValue = ada.GetValue(1)
    '                'Catch ex As Exception
    '                'End Try
    '                Try
    '                    LsttranshipmentPort.SelectedValue = ada.GetValue(2)
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    If lstRemarks.SelectedValue = 4 Then
    '                        LstRemark.SelectedValue = lstRemarks.SelectedValue
    '                    End If
    '                Catch ex As Exception

    '                End Try
    '                'Try
    '                '    If lstShipmentStatus.SelectedValue = 0 Then
    '                '        If lstustaus.SelectedValue > 0 Then
    '                '            con = New OleDbConnection(cs)
    '                '            con.Open()
    '                '            Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET SHIPMENT_STATUS=" & lstustaus.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                '            cmd2.ExecuteNonQuery()
    '                '            con.Close()
    '                '            lstShipmentStatus.SelectedValue = lstustaus.SelectedValue
    '                '        End If
    '                '    End If

    '                'Catch ex As Exception

    '                'End Try
    '                'If TxtDeliveryDate.Text = "" Then
    '                '    If textDeliveryDate.Text <> "" Then
    '                '        TxtDeliveryDate.Text = textDeliveryDate.Text.Trim
    '                '    End If
    '                'End If

    '                'lstShipmentStatus.SelectedValue = lstustaus.SelectedValue


    '            End If
    '        End If
    '    Next
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                ''row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                row.Cells(i).FindControl("lblCurrentEta").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblDischargeDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblGateOutDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("LblTranshipmetEta").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblEmptyGateInDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblTransitTime").Visible = Not isChecked
    '                ' row.Cells(i).FindControl("lblTShipmentStatus").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRequiredETD").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRequiredVessel").Visible = Not isChecked
    '                row.Cells(i).FindControl("lbltranshipmentPort").Visible = Not isChecked
    '                row.Cells(i).FindControl("LblTranshipmetDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblTranshipmentVeseel").Visible = Not isChecked

    '                ' row.Cells(i).FindControl("lblRSailed").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
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
    '    ImgBtnUpdate.Visible = isUpdateVisible
    'End Sub


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
        'strpParms &= "," & LstCFS.SelectedValue & ""
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
        'strpParms &= "," & LstCFS.SelectedValue & ""
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
    Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
                    '    Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
                    Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
                    ' Dim TxtDeliveryDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDeliveryDate"), TextBox)
                    Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
                    Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
                    Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
                    Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
                    Dim TxtRequiredETD As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETD"), TextBox)
                    Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblCONT_NO"), Label)
                    'If ddlCFS.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select CFS Terminal")
                    '    Functions.ControlFocus(ddlCFS)
                    '    Return
                    'End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET EMPTY_POD_DATE=SYSDATE, TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY')," _
                        & " TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''),REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',FINAL_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY')," _
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
                    'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        BindData()
        'MsgBox(checkedRowCount & " :Records " & "Update Successfully", MsgBoxStyle.Information, "Update Records")

        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)
    End Sub

    Protected Sub btnRemarkUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemarkUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
                    ' Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
                    Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
                    ' Dim TxtDeliveryDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDeliveryDate"), TextBox)
                    Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
                    Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
                    Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
                    Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
                    Dim TxtRequiredETD As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETD"), TextBox)
                    Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
                    Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
                    Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
                    Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
                    Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
                    'If ddlCFS.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select CFS Terminal")
                    '    Functions.ControlFocus(ddlCFS)
                    '    Return
                    'End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        ' Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",SAILED=TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY'),SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''),REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_VESSEL='" & TxtRequiredVessel.Text.Trim & "',REQUIRED_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY'),SHIPMENT_STATUS=NVL(" & lstShipmentStatus.SelectedValue & ",0),SHIPMENT_STATUS_NAME=NVL('" & lstShipmentStatus.SelectedItem.Text & "',''),TRANSIT_TIME=NVL(" & TxtTransitTime.Text.Trim & ",0),DELIVERY_DATE=TO_DATE(NVL('" & TxtDeliveryDate.Text.Trim & "',''),'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET SOB_REMARK= NVL('" & lstRemarks.SelectedItem.Text & "',''),  CONFIRM_MAIL_DATE=TO_DATE(SYSDATE, 'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
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

    'Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim TxtTransitTime As TextBox = TryCast(row.Cells(0).FindControl("TxtTransitTime"), TextBox)
    '                '  Dim lstShipmentStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstShipmentStatus"), DropDownList)
    '                Dim TxtCurrentEta As TextBox = TryCast(row.Cells(0).FindControl("TxtCurrentEta"), TextBox)
    '                Dim TxtDischargeDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDischargeDate"), TextBox)
    '                Dim TxtGateOutDate As TextBox = TryCast(row.Cells(0).FindControl("TxtGateOutDate"), TextBox)
    '                Dim TxtEmptyGateInDate As TextBox = TryCast(row.Cells(0).FindControl("TxtEmptyGateInDate"), TextBox)
    '                ' Dim TxtDeliveryDate As TextBox = TryCast(row.Cells(0).FindControl("TxtDeliveryDate"), TextBox)
    '                Dim TxtRequiredVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredVessel"), TextBox)
    '                Dim TxtRequiredETD As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredETD"), TextBox)
    '                Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
    '                Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
    '                Dim TxtTranshipmetDate As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetDate"), TextBox)
    '                Dim TxtTranshipmentVeseel As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmentVeseel"), TextBox)
    '                Dim lstSob As TextBox = TryCast(row.Cells(0).FindControl("lstSob"), TextBox)
    '                Dim TxtTranshipmetETA As TextBox = TryCast(row.Cells(0).FindControl("TxtTranshipmetETA"), TextBox)
    '                'If TxtDeliveryDate.Text <> "" Then
    '                '    If lstShipmentStatus.SelectedValue <> 3 Then
    '                '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Shiment is delivered")
    '                '        Functions.ControlFocus(lstShipmentStatus)
    '                '        Return
    '                '    End If
    '                'End If

    '                Try
    '                    con = New OleDbConnection(cs)
    '                    con.Open()
    '                    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TRANSHIPMENT_VESSEL='" & TxtTranshipmentVeseel.Text.Trim & "',TRANSHIPMENT_ETD=TO_DATE('" & TxtTranshipmetDate.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_ETA=TO_DATE('" & TxtTranshipmetETA.Text.Trim & "','DD/MM/YYYY'),TRANSHIPMENT_PORT='" & LsttranshipmentPort.SelectedItem.Text & "',TRANS_PORT_ID=" & LsttranshipmentPort.SelectedValue & ",SAILED=TO_DATE('" & lstSob.Text.Trim & "','DD/MM/YYYY'),SOB_REMARK= NVL('" & LstRemark.SelectedItem.Text & "',''),REQUIRED_VESSEL='" & TxtRequiredVessel.Text.Trim & "',CURRENT_VESSEL='" & TxtRequiredVessel.Text.Trim & "',FINAL_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETD=TO_dATE('" & TxtRequiredETD.Text & "','DD/MM/YYYY'),CURRENT_ETA=TO_DATE('" & TxtCurrentEta.Text.Trim & "','DD/MM/YYYY'),TRANSIT_TIME=NVL(" & TxtTransitTime.Text.Trim & ",0),DISCHARGE_DATE=TO_DATE(NVL('" & TxtDischargeDate.Text.Trim & "',''),'DD/MM/YYYY'),GATE_OUT_DATE=TO_DATE(NVL('" & TxtGateOutDate.Text.Trim & "',''),'DD/MM/YYYY'),EMPTY_GATE_IN_DATE=TO_DATE(NVL('" & TxtEmptyGateInDate.Text.Trim & "',''),'DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                    cmd.ExecuteNonQuery()
    '                    con.Close()
    '                Catch ex As Exception
    '                End Try
    '                gvtripPendencyList.EditIndex = -1
    '                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    '            End If
    '        End If
    '    Next
    '    ImgBtnUpdate.Visible = False
    '    BindData()
    'End Sub

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
        'strpParms &= "," & LstCFS.SelectedValue & ""
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
        'Dim ds As New DataSet
        Dim dt As DataTable
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
        'Dim ds As New DataSet
        Dim dt As DataTable
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_EMPTY_RETURN", strpParms)
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
End Class

