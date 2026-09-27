Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_FleetJobOrderClosing
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6
    Dim glCommodityMaster As New ExtCommodityMaster

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ListControlDataBind()
            ButtonControlSetup(True)
            lstVehicleNo.Enabled = True
            btnAddVehicleNo.Visible = True
        End If
    End Sub

    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("MenuId") = row(0).ToString
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Search") = row(9).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT JO_TYPE,JO_CODE FROM FLEET_JO_TYPE ORDER BY JO_TYPE"
        cmd2 = "SELECT VEHICLE_ID,VEHICLE_NO FROM FLEET_JO_DTLS WHERE CLOSE_DATE IS NULL ORDER BY VEHICLE_NO"
        cmd3 = "SELECT DRIVER_ID,DRIVER_NAME FROM FLEET_DRIVER_MASTER ORDER BY DRIVER_NAME"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        ada = New OleDbDataAdapter(cmd1, con)
        Dim ds As New DataSet("CONTAINER")
        Try
            ada.Fill(ds)
            lstJoType.DataSource = ds.Tables(0)
            lstJoType.DataTextField = "JO_TYPE"
            lstJoType.DataValueField = "JO_CODE"
            lstJoType.DataBind()
            lstJoType.Items.Insert(0, (New ListItem("---Select---", "0")))
        Catch ex As Exception
        End Try
        ds.Clear()
        ada = New OleDbDataAdapter(cmd2, con)
        Try
            ada.Fill(ds)
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "EQUIPMENT_NO"
            lstVehicleNo.DataValueField = "EQUIPMENT_ID"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))

        Catch ex As Exception
        End Try
        ds.Clear()
        ada = New OleDbDataAdapter(cmd2, con)
        Try
            ada.Fill(ds)
            lstDriver.DataSource = ds.Tables(0)
            lstDriver.DataTextField = "DRIVER_NAME"
            lstDriver.DataValueField = "DRIVER_ID"
            lstDriver.DataBind()
            lstDriver.Items.Insert(0, (New ListItem("---Select---", "0")))
        Catch ex As Exception
        End Try
        ds.Clear()
        con.Close()
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible
        btnAdd.Visible = False
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        'If Session.Item("Add") <> "Y" Then
        '    btnAdd.Visible = False
        'End If
        If Session.Item("Edit") <> "Y" Then

        End If

        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textCloseDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblCloseDate.Text)
            Functions.ControlFocus(textCloseDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetJoDtls As FleetJoDtls = ReturnObject()
        FleetJoDtls.Update(pFleetJoDtls)
        If pFleetJoDtls.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetJoDtls.Errormsg)
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnJoId.Value = pFleetJoDtls.JoId
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAdd.Visible = True
        Functions.ControlFocus(btnAdd)
    End Sub

    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
    '    Functions.clearControls(Me.dvControl.Controls)
    '    manageUserControls(True)
    '    ButtonControlSetup(True)
    '    textBookingNo.Enabled = True
    '    btnSearchJoNo.Visible = False
    '    btnSearchbookingNo.Visible = False
    '    btnAddBookingNo.Visible = True
    '    Functions.ControlFocus(textBookingNo)
    'End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Private Function ReturnObject() As FleetJoDtls
        Dim pFleetJoDtls As New FleetJoDtls
        pFleetJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetJoDtls.JoType = lstJoType.SelectedValue
        pFleetJoDtls.JoId = hdnJoId.Value
        pFleetJoDtls.VehicleId = lstVehicleNo.SelectedValue
        pFleetJoDtls.VehicleNo = lstVehicleNo.SelectedItem.Text
        pFleetJoDtls.Location = textLocation.Text
        pFleetJoDtls.ServeyBy = textSurveyBy.Text
        pFleetJoDtls.DriverId = lstDriver.SelectedValue
        pFleetJoDtls.Note = textNote.Text
        pFleetJoDtls.CreatedBy = Session.Item("LoginUser")
        Return (pFleetJoDtls)
    End Function
    Sub prepareControls(ByVal pFleetJoDtls As FleetJoDtls)
        hdnJoId.Value = pFleetJoDtls.JoId
        lstJoType.SelectedValue = pFleetJoDtls.JoType
        textJoNo.Text = pFleetJoDtls.JoNo
        textJoDate.Text = pFleetJoDtls.JoDate
        textLocation.Text = pFleetJoDtls.Location
        textSurveyBy.Text = pFleetJoDtls.ServeyBy
        lstDriver.SelectedValue = pFleetJoDtls.DriverId
        textNote.Text = pFleetJoDtls.Note
        Dim pFleetDriverMaster As New FleetDriverMaster
        pFleetDriverMaster.TerminalId = Session.Item("LoginTerminal")
        pFleetDriverMaster.DriverId = lstDriver.SelectedValue
        FleetDriverMaster.ReturnFleetDriverMaster(pFleetDriverMaster)
        textContactNo.Text = pFleetDriverMaster.MobileNo
        textLicenseValidity.Text = pFleetDriverMaster.DlRenewableDate
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        'textBookingNo.Enabled = True
        'btnSearchbookingNo.Visible = False
        'btnAddBookingNo.Visible = True
        'Functions.ControlFocus(textBookingNo)
    End Sub
    Protected Sub btnAddVehicleNo_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnAddVehicleNo.Click
        If lstVehicleNo.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblVehiclNo.Text)
            Functions.ControlFocus(lstVehicleNo)
            Exit Sub
        End If
        Dim pFleetJoDtls As New FleetJoDtls
        pFleetJoDtls.VehicleId = lstVehicleNo.SelectedValue
        pFleetJoDtls.VehicleNo = lstVehicleNo.SelectedItem.Text
        FleetJoDtls.ReturnFleetJoDtls(pFleetJoDtls)
        prepareControls(pFleetJoDtls)
        ButtonControlSetup(False)
        textCloseDate.Enabled = True
    End Sub

    Protected Sub lstVehicleNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstVehicleNo.SelectedIndexChanged
        Try
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.VehicleId = lstVehicleNo.SelectedValue
            pDriverMaster.VehicleNo = lstVehicleNo.SelectedItem.Text
            FleetDriverMaster.ReturnFleetDriverMasterByVehicle(pDriverMaster)
            lstDriver.SelectedValue = pDriverMaster.DriverId
            textContactNo.Text = pDriverMaster.MobileNo
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lstDriver_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstDriver.SelectedIndexChanged
        Try
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.DriverId = lstDriver.SelectedValue
            FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
            textContactNo.Text = pDriverMaster.MobileNo
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        Catch ex As Exception
        End Try
    End Sub
End Class
