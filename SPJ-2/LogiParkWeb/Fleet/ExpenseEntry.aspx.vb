Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Fleet_ExpenseEntry
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0S
    Dim rows As Integer = 10
    Function CreateTable() As DataTable
        Dim table As New DataTable
        table.Columns.Add("TRIP_ID", GetType(String))
        table.Columns.Add("COST_DTLS_ID", GetType(String))
        table.Columns.Add("JO_TYPE", GetType(String))
        table.Columns.Add("SERVICE_ID", GetType(String))
        table.Columns.Add("EQUIPMENT_ID", GetType(String))
        table.Columns.Add("VENDOR_ID", GetType(String))
        table.Columns.Add("BILL_NO", GetType(String))
        table.Columns.Add("AMOUNT", GetType(String))
        table.Columns.Add("REMARKS", GetType(String))
        Return table
    End Function
    Function AddCustomNoOfRows(ByVal table As DataTable, ByVal noOfRow As Integer) As DataTable
        For i As Integer = 1 To noOfRow
            table.Rows.Add("0", "0", "", "0", "0", "0", "", "", "")
        Next
        Return table
    End Function
    Private Sub fillRepeator(ByVal tbl As DataTable)
        If tbl.Rows.Count = 0 Then
            AddCustomNoOfRows(tbl, 8)
        End If
        ViewState("Discount") = tbl
        repCostDtls.DataSource = tbl
        repCostDtls.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControDataBindMain()
            ListControDataBind()
            ListControDataBind1()
            ListControDataBind2()
            ListControDataBind3()
            Dim tbl As DataTable = CreateTable()
            fillRepeator(tbl)
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
            strpParms &= ",'" & textToDate.Text & "','',''"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TPT_MIS_EE", strpParms)
            rcExpenseEntry.DataSource = dbr
            rcExpenseEntry.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
            Functions.ControlSetup(True, Me.dvMain.Controls)
            ManageControl()
            BtnAdd.Visible = False
        End If
    End Sub

    Sub ListControDataBindMain()
        Dim pTerminalMaster As New TerminalMaster
        pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
        lstTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstTerminal.DataTextField = "TerminalName"
        lstTerminal.DataValueField = "TerminalId"
        lstTerminal.DataBind()
        lstTerminal.Items.Add(New ListItem("-- Select --  ", "0"))
    End Sub

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        rcExpenseEntry.DataSource = Nothing
        rcExpenseEntry.DataBind()
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

        ' lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")

        Dim strpParms As String = ""
        strpParms &= lstTerminal.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & textVehicleNo.Text.Trim & "'"
        strpParms &= ",'" & textContNo.Text.Trim & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TPT_MIS_EE", strpParms)
        rcExpenseEntry.DataSource = dbr
        rcExpenseEntry.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
        Functions.ControlSetup(True, Me.dvMain.Controls)
        ManageControl()
        BtnAdd.Visible = False
    End Sub

    Sub ManageControl()
        For Each rep As RepeaterItem In repCostDtls.Items
            CType(rep.FindControl("lstService"), DropDownList).Enabled = True
            CType(rep.FindControl("lstVendor"), DropDownList).Enabled = True
            CType(rep.FindControl("textBillNo"), TextBox).Enabled = True
            CType(rep.FindControl("textAmount"), TextBox).Enabled = True
            CType(rep.FindControl("textRemarks"), TextBox).Enabled = True
            CType(rep.FindControl("lstService"), DropDownList).SelectedValue = "0"
            CType(rep.FindControl("textAmount"), TextBox).Text = ""
            CType(rep.FindControl("textRemarks"), TextBox).Text = ""
        Next

        For Each rep As RepeaterItem In rcExpenseEntry.Items
            CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True
            CType(rep.FindControl("chkselect"), CheckBox).Checked = False
        Next
    End Sub

    Protected Sub prepareService(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tblService As DataTable = ViewState("tblService")
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To tblService.Rows.Count
                lst.Items.Add(New ListItem(tblService.Rows(i).Item("SERVICE_NAME"), tblService.Rows(i).Item("SERVICE_ID")))
            Next
        Catch ex As Exception
        End Try
    End Sub


    Sub ListControDataBind()
        Dim tblService As New DataTable()
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            Using cmd = New OleDbCommand("SELECT SERVICE_ID ,SERVICE_NAME FROM SERVICE_MASTER WHERE SERVICE_TYPE_CODE='F'", con)
                Using da = New OleDbDataAdapter(cmd)
                    cmd.CommandType = CommandType.Text
                    da.Fill(tblService)
                End Using
            End Using
        End Using

        ViewState("tblService") = tblService
    End Sub
    Protected Sub prepareDriver(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tbldRIVER As DataTable = ViewState("tbldRIVER")
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To tbldRIVER.Rows.Count
                lst.Items.Add(New ListItem(tbldRIVER.Rows(i).Item("DRIVER_NAME"), tbldRIVER.Rows(i).Item("DRIVER_ID")))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub ListControDataBind1()
        Dim tbldRIVER As New DataTable()
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            Using cmd = New OleDbCommand("SELECT DRIVER_ID ,DRIVER_NAME FROM FLEET_DRIVER_MASTER WHERE ACTIVE_FLAGE='Y' ", con)
                Using da = New OleDbDataAdapter(cmd)
                    cmd.CommandType = CommandType.Text
                    da.Fill(tbldRIVER)
                End Using
            End Using
        End Using

        ViewState("tbldRIVER") = tbldRIVER
    End Sub

    Protected Sub prepareVehicleNo(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tblVehicleNo As DataTable = ViewState("tblVehicleNo")
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To tblVehicleNo.Rows.Count
                lst.Items.Add(New ListItem(tblVehicleNo.Rows(i).Item("EQUIPMENT_NO"), tblVehicleNo.Rows(i).Item("EQUIPMENT_ID")))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub ListControDataBind2()
        Dim tblVehicleNo As New DataTable()
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            Using cmd = New OleDbCommand("SELECT EQUIPMENT_ID, EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER WHERE STATUS ='Y' ORDER BY EQUIPMENT_NO", con)
                Using da = New OleDbDataAdapter(cmd)
                    cmd.CommandType = CommandType.Text
                    da.Fill(tblVehicleNo)
                End Using
            End Using
        End Using

        ViewState("tblVehicleNo") = tblVehicleNo
    End Sub

    Protected Sub prepareVendor(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim tblVendor As DataTable = ViewState("tblVendor")
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---ALL---", "0"))
            For i As Integer = 0 To tblVendor.Rows.Count
                lst.Items.Add(New ListItem(tblVendor.Rows(i).Item("VENDOR_NAME"), tblVendor.Rows(i).Item("VENDOR_ID")))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub ListControDataBind3()
        Dim tblVendor As New DataTable()
        Using con = New OleDbConnection(ConfigurationManager.AppSettings("DBConnectionString"))
            Using cmd = New OleDbCommand("SELECT VENDOR_ID, VENDOR_NAME FROM VENDOR_MASTER", con)
                Using da = New OleDbDataAdapter(cmd)
                    cmd.CommandType = CommandType.Text
                    da.Fill(tblVendor)
                End Using
            End Using
        End Using

        ViewState("tblVendor") = tblVendor
    End Sub
    Function ValidationCheck() As Boolean
        Dim rtnBol = True
        Return rtnBol
    End Function
    Function ReturnObject() As FleetCostDtls
        Dim pFleetCostDtls As New FleetCostDtls
        pFleetCostDtls.FleetCostDtlsList = New ArrayList
        For Each rep As RepeaterItem In repCostDtls.Items
            Dim firctCheck As Boolean = False
            firctCheck = CType(rep.FindControl("lstService"), DropDownList).SelectedValue <> "0" AndAlso CType(rep.FindControl("textAmount"), TextBox).Text <> Nothing

            If firctCheck Then

                Dim p As New FleetCostDtls
                Try
                    p.ServiceId = CType(rep.FindControl("lstService"), DropDownList).SelectedValue
                Catch ex As Exception

                End Try
                Try
                    p.TripId = hdnTripId.Value
                Catch ex As Exception

                End Try
                Try
                    p.Amount = CType(rep.FindControl("textAmount"), TextBox).Text.Trim
                Catch ex As Exception

                End Try
                Try
                    p.Remarks = CType(rep.FindControl("textRemarks"), TextBox).Text.Trim
                Catch ex As Exception

                End Try
              
                Try
                    p.VendorId = CType(rep.FindControl("lstVendor"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    p.VehicleNo = hdnVehicleNo.Value
                Catch ex As Exception
                End Try
                Try
                    p.BillNo = CType(rep.FindControl("textBillNo"), TextBox).Text.Trim
                Catch ex As Exception
                End Try
                p.CreatedBy = Session.Item("LoginUser")
                p.TerminalId = Session.Item("LoginTerminal")
                p.JoType = hdnJoType.Value
                pFleetCostDtls.FleetCostDtlsList.Add(p)

            End If
        Next

        Return pFleetCostDtls
    End Function


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        ' btnSave.Attributes.Add("onclick", "return false;")
        Dim lstdriver, lstService As DropDownList
        For Each rep As RepeaterItem In repCostDtls.Items
            lstService = rep.FindControl("lstService")
            'If lstService.SelectedValue > "0" Then
            '    If hdnIsSelected.Value <> "Y" AndAlso lstdriver.SelectedValue >= 0 Then
            '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Vehicle, Container and Driver are not selected at the same time.")
            '        Return
            '    End If
            '    If hdnIsSelected.Value <> "Y" And lstdriver.SelectedValue = 0 Then
            '        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please select driver Or vehicle.")
            '        Return
            '    End If
            'End If
        Next
        Dim pFleetCostDtls As FleetCostDtls = ReturnObject()

        If pFleetCostDtls.FleetCostDtlsList.Count = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Service or Amount not entered.")
            Return
        End If

        FleetCostDtls.InsertTransaction(pFleetCostDtls)
        If pFleetCostDtls.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetCostDtls.Errormsg)
            Return
        End If
        ' btnSave.Attributes.Add("onclick", "return false;")

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        'Response.Redirect("~/Reports/Fleet/MisTPT.aspx")
        btnSave.Visible = False
        btnAdd.Visible = True
    End Sub

    Protected Sub rcExpenseEntry_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcExpenseEntry.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnTripId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnTripId"), HiddenField).Value > 0 Then
                Dim trRowColor As HtmlTableRow = CType(e.Item.FindControl("trRowColor"), HtmlTableRow)
                If CType(e.Item.FindControl("hdnIsTripClose"), HiddenField).Value = "Y" Then
                    trRowColor.BgColor = "Red"
                ElseIf CType(e.Item.FindControl("hdnIsTripClose"), HiddenField).Value = "N" Then
                    trRowColor.BgColor = "Green"
                End If
            End If
        End If
    End Sub

    'Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdd.Click
    '    Response.Redirect("~/home.aspx")
    'End Sub

    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAdd.Click
        ListControDataBind()
        ListControDataBind1()
        ListControDataBind2()
        ListControDataBind3()
        ManageControl()
        btnSave.Visible = True
        btnsave.Enabled = True
        btnAdd.Visible = False
        'btnSave.Attributes.Add("onclick", "return false;")
    End Sub

    Protected Sub BtnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExit.Click
        Response.Redirect("~/home.aspx")
    End Sub

End Class
