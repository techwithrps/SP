Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_FleetJoClosing
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6
    Dim glCommodityMaster As New ExtCommodityMaster
    Dim glItem As New ArrayList


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()

        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ButtonControlSetup(True)
            ListControlDataBind()
            lstJoNo.Enabled = True
            textNote.Enabled = True

        End If
    End Sub

    Protected Sub prepareDataRepControlsList()
        Dim pItem As New ItemMaster
        pItem.TerminalId = Session.Item("LoginTerminal")
        glItem = ItemMaster.ReturnItemMasterList(pItem)
    End Sub

    Protected Sub prepareItem(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", 0))
            For Each ic As ItemMaster In glItem
                lst.Items.Add(New ListItem(ic.ItemName, ic.ItemId))
            Next
        Catch ex As Exception
        End Try
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
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT JO_ID,JO_NO FROM FLEET_JO_DTLS WHERE CLOSE_DATE IS NULL AND JO_TYPE IN ('SJO','TPJO')  ORDER BY JO_ID "
        con = New OleDbConnection(strConnectionString)
        con.Open()
        ada = New OleDbDataAdapter(cmd1, con)
        Dim ds As New DataSet("CONTAINER")
        Try
            ada.Fill(ds)
            lstJoNo.DataSource = ds.Tables(0)
            lstJoNo.DataTextField = "JO_NO"
            lstJoNo.DataValueField = "JO_ID"
            lstJoNo.DataBind()
            lstJoNo.Items.Insert(0, (New ListItem("---Select---", "0")))
        Catch ex As Exception
        End Try

        ds.Clear()
        con.Close()
    End Sub
    Sub ListControlDataBindSearch()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT JO_ID,JO_NO FROM FLEET_JO_DTLS WHERE CLOSE_DATE IS NOT NULL AND JO_TYPE IN ('SJO','TPJO')  ORDER BY JO_ID "
        con = New OleDbConnection(strConnectionString)
        con.Open()
        ada = New OleDbDataAdapter(cmd1, con)
        Dim ds As New DataSet("CONTAINER")
        Try
            ada.Fill(ds)
            lstJoNo.DataSource = ds.Tables(0)
            lstJoNo.DataTextField = "JO_NO"
            lstJoNo.DataValueField = "JO_ID"
            lstJoNo.DataBind()
            lstJoNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            lstJoNo.SelectedValue = 0
        Catch ex As Exception
        End Try

        ds.Clear()
        con.Close()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        ListControlDataBindSearch()
        lstJoNo.Enabled = True
        hdnMode.Value = "Search"
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim pFleetJoDtls As ExtFleetJoDtls = ReturnObject()
        ExtFleetJoDtls.InsertUpdateFleetJoDtls(pFleetJoDtls)
        If pFleetJoDtls.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetJoDtls.Errormsg)
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
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
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
     Private Function ReturnObject() As FleetJoDtls
        Dim pFleetJoDtls As New ExtFleetJoDtls
        pFleetJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetJoDtls.JoId = hdnJoId.Value
        pFleetJoDtls.CloseAdvance = textClosAmt.Text
        pFleetJoDtls.Advance = Convert.ToInt16(textAdvanceTotal.Text) + Convert.ToInt16(textBalAdvance.Text)
        pFleetJoDtls.DriverId = hdnDriver.Value
        pFleetJoDtls.CloseStatus = lstAdvance.SelectedValue
        pFleetJoDtls.CloseBy = Session.Item("LoginUser")
        pFleetJoDtls.CloseNote = textNote.Text
        pFleetJoDtls.CloseDate = textCloseDate.Text
        pFleetJoDtls.ItemDtlsList = New ArrayList
        
        Return (pFleetJoDtls)
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        hdnMode.Value = "Add"
    End Sub

    Protected Sub lstJoNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstJoNo.SelectedIndexChanged
        If lstJoNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Job Order No")
            Functions.ControlFocus(lstJoNo)
            Exit Sub
        End If
        Dim pFJO As New FleetJoDtls
        pFJO.TerminalId = Session.Item("LoginTerminal")
        pFJO.JoNo = lstJoNo.SelectedItem.Text
        FleetJoDtls.ReturnFleetJoDtlsByJoNo(pFJO)
        textJoDate.Text = pFJO.JoDate
        textJoValidity.Text = pFJO.JoValidity
        textWorkshop.Text = pFJO.Location
        hdnJoId.Value = pFJO.JoId
        textVehicleNo.Text = pFJO.VehicleNo
        textJoFor.Text = pFJO.JoFor
        Try
            textAdvanceTotal.Text = pFJO.Advance + pFJO.OilAdvance
        Catch ex As Exception

        End Try
        '  lstAdvance.SelectedValue = pFJO.jo
        textNote.Text = pFJO.CloseNote
        Try
            lstAdvance.SelectedValue = pFJO.CloseStatus

        Catch ex As Exception

        End Try
        textClosAmt.Text = pFJO.CloseAdvance
        textCloseDate.Text = pFJO.CloseDate
        Dim pVehicle As New FleetEquipmentMaster
        pVehicle.TerminalId = pFJO.TerminalId
        pVehicle.EquipmentId = pFJO.VehicleId
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pVehicle)
        textVehicleType.Text = pVehicle.EquipmentType

        Dim pDriverMaster As New FleetDriverMaster
        pDriverMaster.TerminalId = pFJO.TerminalId
        pDriverMaster.DriverId = pFJO.DriverId
        FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
        textDriver.Text = pDriverMaster.DriverName
        hdnDriver.Value = pDriverMaster.DriverId
        textContactNo.Text = pDriverMaster.MobileNo
        If pDriverMaster.CreatedOn = "" Then
            textBalAdvance.Text = 0
        Else
            textBalAdvance.Text = pDriverMaster.CreatedOn
        End If
           If hdnMode.Value = "Search" Then
            ButtonControlSetup(True)
            manageUserControls(True)
        Else
            textClosAmt.Enabled = True
            textCloseDate.Enabled = True
            ButtonControlSetup(False)
        End If

    End Sub
    

    Protected Sub textClosAmt_TextChanged(sender As Object, e As System.EventArgs) Handles textClosAmt.TextChanged
        If Convert.ToInt64(textAdvanceTotal.Text) > Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.Enabled = True
        ElseIf Convert.ToInt64(textAdvanceTotal.Text) + Convert.ToInt64(textBalAdvance.Text) = Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.SelectedValue = 3
            lstAdvance.Enabled = False
        End If
    End Sub
End Class
