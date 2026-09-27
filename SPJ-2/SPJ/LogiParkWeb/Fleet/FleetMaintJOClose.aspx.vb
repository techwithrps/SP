Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.Web.Services

Partial Class Fleet_FleetMaintJOClose
    Inherits System.Web.UI.Page
    Dim rows As Integer = 5
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
            fillRepeator(New ArrayList)
            ListControlDataBind()
            lstJoNo.Enabled = True
            textNote.Enabled = True
            Dim JoId As Long
            JoId = Request.QueryString("JoId")
            If JoId > 0 Then
                hdnJoId.Value = JoId
                Searchdata(JoId)
            End If
        End If
    End Sub

    Sub Searchdata(ByVal pJoId As Long)
        Dim pFJO As New FleetJoDtls
        pFJO.TerminalId = Session.Item("LoginTerminal")
        pFJO.JoId = hdnJoId.Value
        FleetJoDtls.ReturnFleetJoDtlsByJoNo(pFJO)
        textJoDate.Text = pFJO.JoDate
        textJoValidity.Text = pFJO.JoValidity
        textWorkshop.Text = pFJO.Location
        hdnJoId.Value = pFJO.JoId
        textVehicleNo.Text = pFJO.JoNo
        textJoFor.Text = pFJO.JoFor
        lstJoNo.SelectedItem.Text = pFJO.VehicleNo
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
        Dim pFJD As New FleetJoItemDtls
        pFJD.TerminalId = pFJO.TerminalId
        pFJD.JoId = pFJO.JoId
        fillRepeator(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))
        If hdnMode.Value = "Search" Then
            ButtonControlSetup(True)
            manageUserControls(True)
        Else
            textClosAmt.Enabled = True
            ButtonControlSetup(False)
        End If
        ' lstItem.Enable = False
        btnSave.Visible = False
        ' rpItem.EnableViewState = False
        lstJoNo.Enabled = False
        btnSearch.Visible = True
        btnPrint.Visible = True
    End Sub
    Protected Sub prepareDataRepControlsList()
        Dim pItem As New ItemMaster
        pItem.TerminalId = Session.Item("LoginTerminal")
        glItem = ItemMaster.ReturnItemMasterList(pItem)
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If hdnJoId.Value <> Nothing Then
            Response.Redirect("PRINT/FleetJobOrderPrint.aspx?JoId=" & hdnJoId.Value)
        End If
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
            btnSearch.Visible = True
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        cmd1 = "SELECT JO_ID,VEHICLE_NO JO_NO FROM FLEET_JO_DTLS WHERE CLOSE_DATE IS NULL AND JO_TYPE IN ('MSJO','BWJO','BIJO') AND COMPANY_ID= " & Session.Item("CompanyId") & " ORDER BY JO_ID "
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
        cmd1 = "SELECT JO_ID,VEHICLE_NO JO_NO FROM FLEET_JO_DTLS WHERE CLOSE_DATE IS NULL AND JO_TYPE IN ('MSJO','BWJO','BIJO') AND COMPANY_ID= " & Session.Item("CompanyId") & " ORDER BY JO_ID "
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
        Response.Redirect("FleetJoCloseSearch.aspx")
        lstJoNo.Enabled = True
        hdnMode.Value = "Search"
        btnPrint.Visible = True
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim pFleetJoDtls As ExtFleetJoDtls = ReturnObject()
        If lstAdvance.SelectedValue = "" Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Advance Refund")
            Functions.ControlFocus(lstAdvance)
            Return
        End If
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

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub FillItemDetails(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim lstItem As DropDownList = sender
            Dim index1 As Integer = Integer.Parse(lstItem.ClientID.Substring("ctl00_ContentPlaceHolder1_rpItem_ctl".Length, lstItem.ClientID.IndexOf("_lstItem") - "ctl00_ContentPlaceHolder1_rpItem_ctl".Length))
            Dim rep As RepeaterItem
            Dim rep1 As Repeater = rpItem

            rep = rpItem.Items(index1 - 1)
            If lstItem.SelectedValue <> "0" Then
                Dim p As New ItemMaster
                p.TerminalId = Session.Item("LoginTerminal")
                p.ItemId = lstItem.SelectedValue
                ItemMaster.ReturnItemMaster(p)
                CType(rep.FindControl("textAvlQnty"), TextBox).Text = p.BalQnty
                CType(rep.FindControl("textAvlQnty"), TextBox).Enabled = False
                CType(rep.FindControl("textTotal"), TextBox).Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function ReturnObject() As FleetJoDtls
        Dim pFleetJoDtls As New ExtFleetJoDtls
        pFleetJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetJoDtls.CompanyId = Session.Item("CompanyId")
        pFleetJoDtls.JoId = hdnJoId.Value
        pFleetJoDtls.CloseAdvance = textClosAmt.Text
        pFleetJoDtls.Advance = Convert.ToInt16(textAdvanceTotal.Text) + Convert.ToInt16(textBalAdvance.Text)
        pFleetJoDtls.DriverId = hdnDriver.Value
        pFleetJoDtls.CloseStatus = lstAdvance.SelectedValue
        pFleetJoDtls.CloseBy = Session.Item("LoginUser")
        pFleetJoDtls.CloseNote = textNote.Text
         pFleetJoDtls.ItemDtlsList = New ArrayList
        For Each rep As RepeaterItem In rpItem.Items
            If CType(rep.FindControl("textQnty"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textQnty"), TextBox).Text > 0 AndAlso CType(rep.FindControl("textItem"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("hdnItemId"), HiddenField).Value > 0 AndAlso CType(rep.FindControl("txtRate"), TextBox).Text > 0 Then
                Dim pfId As New FleetJoItemDtls
                pfId.TerminalId = Session.Item("LoginTerminal")
               
                Try
                    pfId.JoDtlsId = CType(rep.FindControl("hdnJoDtlsId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pfId.ItemId = CType(rep.FindControl("hdnItemId"), HiddenField).Value

                Dim PItem As New ItemMaster
                PItem.ItemId = pfId.ItemId
                ItemMaster.ReturnItemMaster(PItem)
                pfId.ItemName = CType(rep.FindControl("textItem"), TextBox).Text
                pfId.CloseQnty = CType(rep.FindControl("textQnty"), TextBox).Text
                pfId.JoPrice = pfId.CloseQnty * CType(rep.FindControl("txtRate"), TextBox).Text
                pfId.ItemGroupId = CType(rep.FindControl("hdnItemGroupId"), HiddenField).Value
                '    CType(rep.FindControl("txtRate"), TextBox).Text = CType(rep.FindControl("textQnty"), TextBox).Text * PItem.ItemCost
                pFleetJoDtls.ItemDtlsList.Add(pfId)
            End If
        Next
        Return (pFleetJoDtls)
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        hdnMode.Value = "Add"
        lstJoNo.Enabled = True
    End Sub

    Protected Sub lstJoNo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstJoNo.SelectedIndexChanged
        If lstJoNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Job Order No")
            Functions.ControlFocus(lstJoNo)
            Exit Sub
        End If
        lstAdvance.Enabled = True
        Dim pFJO As New FleetJoDtls
        pFJO.TerminalId = Session.Item("LoginTerminal")
        pFJO.CompanyId = Session.Item("CompanyId")
        pFJO.JoId = lstJoNo.SelectedValue
        FleetJoDtls.ReturnFleetJoDtlsByJoNo(pFJO)
        textJoDate.Text = pFJO.JoDate
        textJoValidity.Text = pFJO.JoValidity
        textWorkshop.Text = pFJO.Location
        hdnJoId.Value = pFJO.JoId
        textVehicleNo.Text = pFJO.JoNo
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
        Dim pFJD As New FleetJoItemDtls
        pFJD.TerminalId = pFJO.TerminalId
        pFJD.JoId = pFJO.JoId

        txtNoOfItems.Text = FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD).Count
        rows = txtNoOfItems.Text
        fillRepeator(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))

        If hdnMode.Value = "Search" Then
            ButtonControlSetup(True)
            manageUserControls(True)
        Else
            textClosAmt.Enabled = True
            ButtonControlSetup(False)
        End If
        txtNoOfItems.Enabled = True
    End Sub
    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - arr.Count - 1
                Dim p As New FleetJoItemDtls
                arr.Add(p)
            Next
        End If
        rpItem.DataSource = arr
        rpItem.DataBind()
    End Sub

    Protected Sub textClosAmt_TextChanged(sender As Object, e As System.EventArgs) Handles textClosAmt.TextChanged
        If Convert.ToInt64(textAdvanceTotal.Text) > Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.Enabled = True
        ElseIf Convert.ToInt64(textAdvanceTotal.Text) + Convert.ToInt64(textBalAdvance.Text) = Convert.ToInt64(textClosAmt.Text) Then
            lstAdvance.SelectedValue = 3
            lstAdvance.Enabled = False
        End If
    End Sub


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
        cmd.CommandText = "SELECT ITEM_ID, ITEM_CODE, UPPER(ITEM_NAME) ITEM_NAME, ITEM_COST FROM ITEM_MASTER WHERE ITEM_NAME LIKE UPPER('%" & Item & "%')"
        Dim objDs As New DataSet()
        Dim dAdapter As New OleDbDataAdapter()
        dAdapter.SelectCommand = cmd
        con.Open()
        dAdapter.Fill(objDs)
        con.Close()

        returnValue = objDs.Tables(0).Rows(0)("ITEM_NAME").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_ID").ToString & "%" & objDs.Tables(0).Rows(0)("ITEM_COST").ToString
        Return returnValue.Trim
    End Function
    Protected Sub txtNoOfItems_TextChanged(sender As Object, e As System.EventArgs) Handles txtNoOfItems.TextChanged
        lblErrorMessage.Text = ""
        Dim pFJD As New FleetJoItemDtls
        pFJD.TerminalId = Session.Item("LoginTerminal")
        pFJD.JoId = hdnJoId.Value

        rows = txtNoOfItems.Text.Trim
        Dim rows1 As Integer = 0
        rows1 = FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD).Count
        If rows1 > rows Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No of Items Should be greater or equal to already assigned item")
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        fillRepeator(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))
    End Sub


    Sub checkQnty(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim textQnty As TextBox = sender
            Dim txtDblQnty As Double = 0
            Dim itemId As Integer = 0
            Dim index1 As Integer = Integer.Parse(textQnty.ClientID.Substring("ctl00_ContentPlaceHolder1_rpItem_ctl".Length, textQnty.ClientID.IndexOf("_textQnty") - "ctl00_ContentPlaceHolder1_rpItem_ctl".Length))
            Dim rep As RepeaterItem
            rep = rpItem.Items(index1 - 1)
            If textQnty.Text <> "" Then
                'CType(rep.FindControl("hdnServiceId"), HiddenField).Value = 1
                txtDblQnty = Double.Parse(CType(rep.FindControl("textQnty"), TextBox).Text)
                itemId = CType(rep.FindControl("hdnItemId"), HiddenField).Value

                Dim PItem As New ItemMaster
                PItem.ItemId = itemId
                ItemMaster.ReturnItemMaster(PItem)
                CType(rep.FindControl("txtRate"), TextBox).Text = txtDblQnty * PItem.ItemCost
                CType(rep.FindControl("hdnItemCost"), HiddenField).Value = txtDblQnty * PItem.ItemCost
               
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub rpItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rpItem.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value > 0 Then
                Dim pItemGroup As New ItemGroupMaster
                pItemGroup.ItemGroupId = CType(e.Item.FindControl("hdnItemGroupId"), HiddenField).Value
                pItemGroup.TerminalId = Session.Item("LoginTerminal")
                ItemGroupMaster.ReturnItemMaster(pItemGroup)
                CType(e.Item.FindControl("txtItemGroupName"), TextBox).Text = pItemGroup.ItemGroupName
            End If
        End If

    End Sub

End Class
