Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.Web.Services
Partial Class Fleet_FleetJobOrder
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6

    Dim glItem As New ArrayList


    <System.Web.Script.Services.ScriptMethod(),
System.Web.Services.WebMethod()>
    Public Shared Function SearchCustomers(ByVal prefixText As String, ByVal count As Integer) As List(Of String)
        Dim strConn As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConn)
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("Name", prefixText)
        ' cmd.CommandText = "SELECT ITEM_ID, ITEM_CODE, UPPER(ITEM_NAME) ITEM_NAME, ITEM_COST FROM ITEM_MASTER WHERE ITEM_NAME LIKE UPPER('%" & prefixText & "%') AND ITEM_COST_VALIDITY>=TO_DATE(SYSDATE, 'DD/MM/YYYY')"
        cmd.CommandText = "SELECT UPPER(ITEM_NAME) ITEM_NAME FROM ITEM_MASTER IM INNER JOIN ITEM_GROUP_MASTER IGM ON IM.ITEM_GROUP=IGM.ITEM_GROUP_ID WHERE ITEM_NAME LIKE UPPER('%" & prefixText & "%')"
        cmd.Connection = con
        con.Open()
        Dim customers As List(Of String) = New List(Of String)
        Dim sdr As OleDbDataReader = cmd.ExecuteReader
        While sdr.Read
            customers.Add(sdr("ITEM_NAME").ToString)
        End While
        con.Close()
        Return customers
    End Function
    <WebMethod()>
    Public Shared Function GetItemsDetailsByItemName(ByVal Item As String) As String
        Dim returnValue As String = ""
        'Dim p As New ItemMaster
        'p.ItemName = Item.Trim
        'ItemMaster.ReturnItem(p)
        'returnValue = p.ItemId & "%"
        'Return returnValue.Trim
        Dim strConn As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConn)
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Parameters.AddWithValue("Name", Item.Trim)
        cmd.CommandText = "SELECT ITEM_ID, ITEM_CODE, UPPER(ITEM_NAME) ITEM_NAME, ITEM_COST, IGM.ITEM_GROUP_NAME, ITEM_GROUP_ID FROM ITEM_MASTER IM INNER JOIN ITEM_GROUP_MASTER IGM ON IM.ITEM_GROUP=IGM.ITEM_GROUP_ID WHERE ITEM_NAME LIKE UPPER('%" & Item & "%')"
        Dim objDs As New DataSet()
        Dim dAdapter As New OleDbDataAdapter()
        dAdapter.SelectCommand = cmd
        con.Open()
        dAdapter.Fill(objDs)
        con.Close()

        returnValue = objDs.Tables(0).Rows(0)("ITEM_NAME").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_ID").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_COST").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_GROUP_NAME").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_GROUP_ID").ToString
        Return returnValue.Trim
    End Function
    'Public Shared Function GetItemsDetailsByItemName(ByVal Item As String) As String
    '    Dim returnValue As String = ""

    '    Dim strConn As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '    Dim con As New OleDbConnection(strConn)
    '    Dim cmd As New OleDbCommand()
    '    cmd.Connection = con
    '    cmd.CommandType = System.Data.CommandType.Text
    '    cmd.Parameters.AddWithValue("Name", Item.Trim)
    '    cmd.CommandText = "SELECT ITEM_ID, ITEM_CODE, UPPER(ITEM_NAME) ITEM_NAME, ITEM_COST FROM ITEM_MASTER WHERE ITEM_NAME LIKE UPPER('%" & Item & "%')"
    '    Dim objDs As New DataSet()
    '    Dim dAdapter As New OleDbDataAdapter()
    '    dAdapter.SelectCommand = cmd
    '    con.Open()
    '    dAdapter.Fill(objDs)
    '    con.Close()

    '    returnValue = objDs.Tables(0).Rows(0)("ITEM_NAME").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_ID").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_COST").ToString
    '    Return returnValue.Trim

    'End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            ButtonControlSetup(True)
            manageUserControls(True)
            lstJoType.Enabled = True
            lstVehicleNo.Enabled = True
            rows = 0
            fillRepeator(New ArrayList)
            Dim JoId As Long
            JoId = Request.QueryString("JoId")
            If JoId > 0 Then
                hdnJoId.Value = JoId
                Searchdata(JoId)
                btnPrint.Visible = True
            Else
                btnPrint.Visible = False
            End If
            btnSearch.Visible = True
            btnExit.Visible = True
            btnCancel.Visible = False
            btnEdit.Visible = False
            ' 
            textFind.Visible = True
            textFind.Enabled = True
        End If
    End Sub


    Sub Searchdata(ByVal pJoId As Long)
        Dim pFJO As New FleetJoDtls
        pFJO.TerminalId = Session.Item("LoginTerminal")
        pFJO.JoId = hdnJoId.Value
        FleetJoDtls.ReturnFleetJoDtlsByJoNo(pFJO)
        If pFJO.JoId <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Invalid Job Order")
            Functions.ControlFocus(textJoNo)
            Exit Sub
        End If
        lstJoType.Enabled = False
        lstVehicleNo.Enabled = False
        textJoNo.Text = pFJO.JoNo
        textJoDate.Text = pFJO.JoDate
        textJoValidity.Text = pFJO.JoValidity
        lstJoType.SelectedValue = pFJO.JoType
        lstWorkshop.SelectedItem.Text = pFJO.Location
        lstDriver.SelectedValue = pFJO.DriverId
        lstVehicleNo.SelectedItem.Text = pFJO.VehicleNo
        lstJoFor.SelectedItem.Text = pFJO.JoFor
        Dim pVehicle As New FleetEquipmentMaster
        pVehicle.TerminalId = pFJO.TerminalId
        pVehicle.EquipmentId = pFJO.VehicleId
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pVehicle)
        textVehicleType.Text = pVehicle.EquipmentType
        textAdvance.Text = pFJO.Advance
        textOilAdvance.Text = pFJO.OilAdvance
        Dim pDriverMaster As New FleetDriverMaster
        pDriverMaster.TerminalId = pFJO.TerminalId
        pDriverMaster.DriverId = pFJO.DriverId
        FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
        textContactNo.Text = pDriverMaster.ContactNo
        textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        textSurveyBy.Text = pFJO.ServeyBy
        Try
            textTotal.Text = Convert.ToInt32(textAdvance.Text) + Convert.ToInt32(textOilAdvance.Text)
        Catch ex As Exception

        End Try
        textNote.Text = pFJO.Note
        btnSearchJo.Visible = True
        btnPrint.Visible = True
        Dim pFJD As New FleetJoItemDtls
        pFJD.TerminalId = pFJO.TerminalId
        pFJD.JoId = hdnJoId.Value

        txtNoOfItems.Text = FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD).Count
        rows = txtNoOfItems.Text
        fillRepeatorWithValue(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If textJoNo.Text.Trim <> Nothing Then
            Response.Redirect("PRINT/FleetJobOrderPrint.aspx?JoId=" & hdnJoId.Value)
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
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT JO_TYPE,JO_CODE FROM FLEET_JO_TYPE WHERE JO_CODE  IN ('MSJO','BWJO','BIJO') ORDER BY JO_TYPE"
        cmd4 = "SELECT WR_ID,WR_NAME FROM WORKSHOP_MASTER "
        cmd2 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER WHERE COMPANY_ID= " & Session.Item("CompanyId") & " ORDER BY EQUIPMENT_NO"
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
        ada = New OleDbDataAdapter(cmd4, con)
        Try
            ada.Fill(ds)
            lstWorkshop.DataSource = ds.Tables(0)
            lstWorkshop.DataTextField = "WR_NAME"
            lstWorkshop.DataValueField = "WR_ID"
            lstWorkshop.DataBind()
            lstWorkshop.Items.Insert(0, (New ListItem("---Select---", "0")))
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
        ada = New OleDbDataAdapter(cmd3, con)
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
        Response.Redirect("FleetJOSearch.aspx")
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstDriver.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select " & lblDriver.Text)
            Functions.ControlFocus(lstDriver)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If textJoDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Job Date")
            Functions.ControlFocus(textJoDate)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textSurveyBy.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter SurveyBy")
            Functions.ControlFocus(textSurveyBy)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstWorkshop.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblLocation.Text & " is Blank.")
            rtnBool = False
            Return rtnBool
            Functions.ControlFocus(lstWorkshop)
            Exit Function
        End If


        If lstJoFor.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblJoFor.Text & " is Blank.")
            rtnBool = False
            Return rtnBool
            Functions.ControlFocus(lstJoFor)
            Exit Function
        End If
        If textJoValidity.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Job Validity Date")
            Functions.ControlFocus(textJoValidity)
            rtnBool = False
            Return rtnBool

            If lstVehicleNo.SelectedValue = 0 Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblLocation.Text & " is Blank.")
                rtnBool = False
                Return rtnBool
                Functions.ControlFocus(lstVehicleNo)
                Exit Function
            End If
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetJoDtls As ExtFleetJoDtls = ReturnObject()


        pFleetJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetJoDtls.VehicleNo = lstVehicleNo.SelectedItem.Text
        FleetJoDtls.ReturnFleetJoVehicleNo(pFleetJoDtls)

        If pFleetJoDtls.CloseDate = "" And pFleetJoDtls.CreatedOn <> "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " This Vehicle is already Job Created Kindly Close Previous Job Order.")
            Functions.ControlFocus(lstVehicleNo)
            Return
        End If

        If pFleetJoDtls.ItemDtlsList.Count <= 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Minimum One Item For Job")
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        ExtFleetJoDtls.InsertUpdateFleetJoDtls(pFleetJoDtls)
        'ExtFleetJoDtls.Insert(pFleetJoDtls)
        If pFleetJoDtls.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetJoDtls.Errormsg)
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnJoId.Value = pFleetJoDtls.JoId
        textJoNo.Text = pFleetJoDtls.JoNo
        textJoValidity.Text = pFleetJoDtls.JoValidity
        textJoDate.Text = pFleetJoDtls.JoDate
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
        btnPrint.Visible = True
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

    Private Function ReturnObject() As ExtFleetJoDtls
        Dim pFleetJoDtls As New ExtFleetJoDtls
        pFleetJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetJoDtls.CompanyId = Session.Item("CompanyId")
        pFleetJoDtls.JoDate = textJoDate.Text
        pFleetJoDtls.JoValidity = textJoValidity.Text
        pFleetJoDtls.JoType = lstJoType.SelectedValue
        pFleetJoDtls.VehicleId = lstVehicleNo.SelectedValue
        pFleetJoDtls.VehicleNo = lstVehicleNo.SelectedItem.Text
        pFleetJoDtls.Location = lstWorkshop.SelectedItem.Text
        pFleetJoDtls.ServeyBy = textSurveyBy.Text
        pFleetJoDtls.DriverId = lstDriver.SelectedValue
        pFleetJoDtls.Note = textNote.Text
        pFleetJoDtls.JoFor = lstJoFor.SelectedValue
        pFleetJoDtls.CreatedBy = Session.Item("LoginUser")
        pFleetJoDtls.WorkshopId = lstWorkshop.SelectedValue
       
        Try
            pFleetJoDtls.Advance = textAdvance.Text

        Catch ex As Exception

        End Try
        Try
            pFleetJoDtls.OilAdvance = textOilAdvance.Text
        Catch ex As Exception

        End Try

        pFleetJoDtls.ItemDtlsList = New ArrayList
        For Each rep As RepeaterItem In rpItem.Items
            If CType(rep.FindControl("textQnty"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textQnty"), TextBox).Text > 0 AndAlso CType(rep.FindControl("textItem"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("hdnItemId"), HiddenField).Value > 0 Then
                Dim pfId As New FleetJoItemDtls
                pfId.TerminalId = Session.Item("LoginTerminal")
                Try
                    pfId.JoDtlsId = CType(rep.FindControl("hdnJoDtlsId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pfId.ItemId = CType(rep.FindControl("hdnItemId"), HiddenField).Value
                pfId.ItemGroupId = CType(rep.FindControl("hdnItemGroupId"), HiddenField).Value
                pfId.ItemName = CType(rep.FindControl("textItem"), TextBox).Text
                pfId.CloseQnty = CType(rep.FindControl("textQnty"), TextBox).Text
                pfId.JoQnty = CType(rep.FindControl("textQnty"), TextBox).Text
                pfId.JoPrice = CType(rep.FindControl("textQnty"), TextBox).Text * CType(rep.FindControl("hdnItemCost"), HiddenField).Value
                Try
                    CType(rep.FindControl("txtItemGroupName"), TextBox).Text = CType(rep.FindControl("hdnItemGroupName"), HiddenField).Value
                Catch ex As Exception

                End Try
               
                pFleetJoDtls.ItemDtlsList.Add(pfId)
            End If
        Next
        Return (pFleetJoDtls)
    End Function
    Protected Sub textOil_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textOilAdvance.TextChanged
        Try
            textTotal.Text = Convert.ToInt32(textAdvance.Text) + Convert.ToInt32(textOilAdvance.Text)
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub textaDVANCE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textAdvance.TextChanged
        Try
            textTotal.Text = Convert.ToInt32(textAdvance.Text) + Convert.ToInt32(textOilAdvance.Text)
        Catch ex As Exception

        End Try

    End Sub
    Sub prepareControls(ByVal pFleetJoDtls As FleetJoDtls)
        lstJoType.SelectedValue = pFleetJoDtls.JoType
        lstVehicleNo.SelectedValue = pFleetJoDtls.VehicleId
        lstWorkshop.SelectedItem.Text = pFleetJoDtls.Location
        textSurveyBy.Text = pFleetJoDtls.ServeyBy
        lstDriver.SelectedValue = pFleetJoDtls.DriverId
        textNote.Text = pFleetJoDtls.Note
        Dim pFleetDriverMaster As New FleetDriverMaster
        pFleetDriverMaster.TerminalId = Session.Item("LoginTerminal")
        pFleetDriverMaster.DriverId = lstDriver.SelectedValue
        FleetDriverMaster.ReturnFleetDriverMaster(pFleetDriverMaster)
        textContactNo.Text = pFleetDriverMaster.MobileNo
        textLicenseValidity.Text = pFleetDriverMaster.DlRenewableDate
        textAdvance.Text = pFleetJoDtls.Advance
        textOilAdvance.Text = pFleetJoDtls.OilAdvance
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


    Protected Sub lstVehicleNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVehicleNo.SelectedIndexChanged
        Try
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.VehicleId = lstVehicleNo.SelectedValue
            pDriverMaster.VehicleNo = lstVehicleNo.SelectedItem.Text
            FleetDriverMaster.ReturnFleetDriverMasterByVehicle(pDriverMaster)
            lstDriver.SelectedValue = pDriverMaster.DriverId
            textContactNo.Text = pDriverMaster.MobileNo
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
            Dim pFE As New FleetEquipmentMaster
            pFE.TerminalId = Session.Item("LoginTerminal")
            pFE.EquipmentId = lstVehicleNo.SelectedValue
            FleetEquipmentMaster.ReturnFleetEquipmentMaster(pFE)
            textVehicleType.Text = pFE.EquipmentType
            manageUserControls(False)
            textVehicleType.Enabled = False
            textContactNo.Enabled = False
            textLicenseValidity.Enabled = False
            textTotal.Enabled = False
            ButtonControlSetup(False)

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lstDriver_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDriver.SelectedIndexChanged
        Try
            Dim pDriverMaster As New FleetDriverMaster
            pDriverMaster.TerminalId = Session.Item("LoginTerminal")
            pDriverMaster.DriverId = lstDriver.SelectedValue
            FleetDriverMaster.ReturnFleetDriverMaster(pDriverMaster)
            textContactNo.Text = pDriverMaster.MobileNo
            textBalanceAdv.Text = pDriverMaster.CreatedOn
            textLicenseValidity.Text = pDriverMaster.DlRenewableDate
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lstJoType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstJoType.SelectedIndexChanged
        If lstJoType.SelectedValue = "SJO" Then
            lstJoFor.SelectedValue = "S"
        ElseIf lstJoType.SelectedValue = "MSJO" Or lstJoType.SelectedValue = "TPJO" Then
            lstJoFor.SelectedValue = "M"
        End If
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If rows = 0 Then
            tbItem.Visible = False
        End If
        If arr.Count < rows Then
            For i As Integer = 0 To rows - arr.Count - 1
                Dim p As New FleetJoItemDtls
                arr.Add(p)
                tbItem.Visible = True
            Next
        End If
        rpItem.DataSource = arr
        rpItem.DataBind()
    End Sub


    Private Sub fillRepeatorWithValue(ByVal arr As ArrayList)
        rpItem.DataSource = arr
        rpItem.DataBind()
        tbItem.Visible = True
    End Sub



    Protected Sub txtNoOfItems_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOfItems.TextChanged
        rows = txtNoOfItems.Text.Trim
        Dim arr As New ArrayList
        fillRepeator(arr)
    End Sub

    Protected Sub textFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textFind.TextChanged
        lstVehicleNo.Items.Clear()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")

        cmd2 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER where UPPER(EQUIPMENT_NO) LIKE UPPER('%" & textFind.Text & "%') AND COMPANY_ID= " & Session.Item("CompanyId") & "  ORDER BY EQUIPMENT_NO"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        ada = New OleDbDataAdapter(cmd2, con)
        Dim ds As New DataSet("CONTAINER")


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
        con.Close()
    End Sub

    Protected Sub rpItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpItem.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value > 0 Then
                Dim pItemGroup As New ItemGroupMaster
                pItemGroup.ItemGroupId = CType(e.Item.FindControl("hdnItemGroupId"), HiddenField).Value
                pItemGroup.TerminalId = Session.Item("LoginTerminal")
                ItemGroupMaster.ReturnItemMaster(pItemGroup)
                CType(e.Item.FindControl("hdnItemGroupName"), HiddenField).Value = pItemGroup.ItemGroupName
                CType(e.Item.FindControl("txtItemGroupName"), TextBox).Text = pItemGroup.ItemGroupName
            End If
        End If

    End Sub


End Class
