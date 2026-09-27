Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Master_Admin_LocationMaster
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 1
    Dim count As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub ListControlDataBind()
        'Dim pTerminalMaster As New TerminalMaster
        'lstTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        'lstTerminal.DataTextField = "TerminalName"
        'lstTerminal.DataValueField = "TerminalId"
        'lstTerminal.DataBind()

        Dim table As New DataTable
        Dim strConnString As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConnString)
        Dim cmd As New OleDbCommand()
        Dim ada As New OleDbDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT TERMINAL_ID,TERMINAL_NAME FROM TERMINAL_MASTER ORDER BY TERMINAL_NAME ASC"
        cmd.Connection = con
        ada.SelectCommand = cmd
        Try
            con.Open()
            ada.Fill(table)
            lstTerminal.DataSource = table
            lstTerminal.DataTextField = "TERMINAL_NAME"
            lstTerminal.DataValueField = "TERMINAL_ID"
            lstTerminal.DataBind()

            lstHandover.DataSource = table
            lstHandover.DataTextField = "TERMINAL_NAME"
            lstHandover.DataValueField = "TERMINAL_ID"
            lstHandover.DataBind()
            lstHandover.Items.Insert(0, New ListItem("ALL", "0"))
            ViewState("TERMINAL") = table

            table = New DataTable()
            ada = New OleDbDataAdapter()
            cmd.CommandText = "SELECT CUSTOMER_ID,UPPER(CUSTOMER_NAME ||'-'||CUSTOMER_TYPE) CUSTOMER_NAME FROM CUSTOMER_MASTER ORDER BY CUSTOMER_NAME ASC"
            ada.SelectCommand = cmd
            ada.Fill(table)
            lstCustomer.DataSource = table
            lstCustomer.DataTextField = "CUSTOMER_NAME"
            lstCustomer.DataValueField = "CUSTOMER_ID"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, New ListItem("ALL", "0"))
            ViewState("CUSTOMER") = table
            table = New DataTable()
            ada = New OleDbDataAdapter()
            cmd.CommandText = "SELECT EQUIPMENT_TYPE_CODE,EQUIPMENT_TYPE_NAME FROM EQUIPMENT_TYPE ORDER BY EQUIPMENT_TYPE_NAME"
            ada.SelectCommand = cmd
            ada.Fill(table)
            LstVehicleType.DataSource = table
            LstVehicleType.DataTextField = "EQUIPMENT_TYPE_NAME"
            LstVehicleType.DataValueField = "EQUIPMENT_TYPE_CODE"
            LstVehicleType.DataBind()
            LstVehicleType.Items.Insert(0, New ListItem("ALL", "0"))
            ViewState("EQUIPMENTTYPE") = table
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
    Protected Sub prepareDataRepControlsList(ByVal pCodevalue As TreeNode)

        'Dim pCustomer As New CustomerMaster
        'glCustomer = CustomerMaster.ReturnCustomerMasterTypeDtls(pCustomer)

        'Dim pTerminal As New TerminalMaster
        'glTerminal = TerminalMaster.ReturnTerminalMasterList(pTerminal)

        'Dim pLocationMaster As New TerminalLocationMaster
        'pLocationMaster.TerminalId = pCodevalue.Value
        'glLocation = TerminalLocationMaster.ReturnTerminalLocationMasterList(pLocationMaster)
    End Sub
    'Protected Sub prepareToLocation(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim lst As DropDownList = sender
    '        lst.Items.Clear()
    '        lst.Items.Add(New ListItem("--Select--", "0"))
    '        For Each ic As TerminalLocationMaster In glLocation
    '            lst.Items.Add(New ListItem(ic.LocationName, ic.LocationId))
    '        Next

    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim lst As DropDownList = sender
    '        lst.Items.Clear()

    '        lst.Items.Add(New ListItem("ALL", "0"))
    '        For Each ic As TerminalMaster In glTerminal
    '            lst.Items.Add(New ListItem(ic.TerminalName, ic.TerminalId))
    '        Next

    '    Catch ex As Exception
    '    End Try
    'End Sub
    'Protected Sub prepareCustomer(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim lst As DropDownList = sender
    '        lst.Items.Clear()

    '        lst.Items.Add(New ListItem("ALL", "0"))
    '        For Each ic As CustomerMaster In glCustomer
    '            lst.Items.Add(New ListItem(ic.CustomerName, ic.CustomerId))
    '        Next

    '    Catch ex As Exception
    '    End Try
    'End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pTerminalMaster As New TerminalMaster
        Try
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.TerminalId, obj.TerminalName)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
        End If
        Return MyBase.SaveViewState
    End Function

    Sub prepareLocationData()
        tvTreeView.ExpandAll()
        Try
            Dim pLocationMaster As New LocationMaster
            pLocationMaster.TerminalId = lstTerminal.SelectedValue
            Dim arr As New ArrayList
            arr = LocationMaster.ReturnLocationMasterList(pLocationMaster)
            If arr.Count >= ROWS Then
                ROWS = arr.Count + 10
            End If
            fillRepeator(arr)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New LocationMaster
                arr.Add(p)
            Next

        End If
        repLocation.DataSource = arr
        repLocation.DataBind()
    End Sub

    Private Sub fillRepeatorHari(ByVal table As DataTable)
        'If table.Rows.Count <= 0 Then
        '    For i As Integer = 0 To ROWS - 1
        '        'Dim p As New LocationMaster
        '        'arr.Add(p)
        '    Next
        'End If
        repLocation.DataSource = table
        repLocation.DataBind()
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If lstTerminal.SelectedValue <> Nothing Then
        '    btnEdit.Visible = True
        'Else
        '    btnEdit.Visible = False
        'End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        Functions.ControlFocus(lstTerminal)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        'Functions.ControlFocus(lstTerminal)
        lstTerminal.Enabled = False
        manageRepeatorControl(True)
        lstLocation.Enabled = False

        lstLocation.Visible = True
        lstHandover.Visible = True
        lstCustomer.Visible = True
        btnChange.Visible = True
        lstLocation.Enabled = True
    End Sub

    Sub manageRepeatorControl(ByVal PEnable As Boolean)
        'For Each rep As RepeaterItem In repLocation.Items
        '    If CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value > 0 Then
        '        CType(rep.FindControl("textLocation"), TextBox).Enabled = False
        '        CType(rep.FindControl("textAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textOilAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textALAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textDoubleTwenty"), TextBox).Enabled = True

        '    Else
        '        CType(rep.FindControl("textLocation"), TextBox).Enabled = PEnable
        '        CType(rep.FindControl("textToll"), TextBox).Enabled = PEnable
        '        CType(rep.FindControl("textAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textOilAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textALAdvance"), TextBox).Enabled = True
        '        CType(rep.FindControl("textDoubleTwenty"), TextBox).Enabled = True


        '    End If
        'Next
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareDataRepControlsList(tvTreeView.SelectedNode)
            prepareControls(tvTreeView.SelectedNode)
        End If
        manageUserControls(True)
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        'prepareDataRepControlsList(tvTreeView.SelectedNode)
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If lstTerminal.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select terminal")
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        'If repLocation.Items.Count > 0 Then
        '    Dim rep1, rep2 As RepeaterItem
        '    Dim textLocation, textLocation1, textDistance, textToll As TextBox
        '    Dim lstLocation As DropDownList

        '    For Each rep1 In repLocation.Items
        '        lstLocation = rep1.FindControl("lstLocation")
        '        'textDistance = rep1.FindControl("textDistance")
        '        'textToll = rep1.FindControl("textToll")
        '        If lstLocation.SelectedValue = 0 Then

        '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblLocation.Text & "is Blank.")
        '            rtnBool = False
        '            Functions.ControlFocus(textL)
        '            Return rtnBool
        '            Exit Function

        '        End If

        'For Each rep2 In repLocation.Items
        '    textLocation1 = rep2.FindControl("textLocation")
        '    If textLocation1.Text <> "" Then
        '        If rep1.ItemIndex <> rep2.ItemIndex Then
        '            'If textLocation.Text = textLocation1.Text Then
        '            '   Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Duplicate location.")
        '            '   rtnBool = False
        '            '   Functions.ControlFocus(textLocation1)
        '            '  Return rtnBool
        '            '   Exit Function
        '            'End If
        '        End If

        '    End If
        'Next
        '    Next
        ' End If
        If lstLocation.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Duplicate location.")
            rtnBool = False
            Functions.ControlFocus(lstLocation)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pLocationMaster As LocationMaster = ReturnObject()
        If pLocationMaster.LocationList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Location Details.")
            Return
            Exit Sub
        End If
        LocationMaster.InsertUpdateLocationDetails(pLocationMaster)

        If pLocationMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pLocationMaster.Errormsg)
            Functions.ControlFocus(lstTerminal)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Dim strMsg As String = Nothing
        strMsg = SendMail(pLocationMaster)
        If strMsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        End If


        Dim table As New DataTable
        Dim strConnString As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConnString)
        Dim cmd As New OleDbCommand()
        Dim ada As New OleDbDataAdapter()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SELECT_PKG.SP_LOCATION_MASTER_BY_HARI"
        cmd.Parameters.AddWithValue("@p_TERMINAL_ID", lstTerminal.SelectedValue)
        cmd.Connection = con
        ada.SelectCommand = cmd
        Try
            con.Open()
            ada.Fill(table)

            If table.Rows.Count > 0 Then
                ViewState("totalRows") = table.Rows.Count
            Else
                ViewState("totalRows") = 0
            End If
            ViewState("table") = table

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        fillRepeatorHari(table)

        hdnTerminalID.Value = pLocationMaster.LocationRefId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub
    Function SendMail(ByVal plOCATIONmaSTER As LocationMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = Session.Item("LoginTerminal")
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = Session.Item("MenuId")
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetupByMenuId(xMailSetup)

        xMailSetup.MailBody &= xMailSetup.Signature & "<br/>"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"

        pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromId, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function


    Private Function ReturnObject() As LocationMaster
        Dim pLocationMaster As New LocationMaster
        If lstTerminal.SelectedValue >= 0 Then
            pLocationMaster.TerminalId = lstTerminal.SelectedValue
        End If

        pLocationMaster.LocationList = New ArrayList

        For Each rep As RepeaterItem In repLocation.Items
            Dim LocationId As Long = 0
            Try
                LocationId = lstLocation.SelectedValue
            Catch ex As Exception
            End Try
            If CType(rep.FindControl("chkSelectedRow"), CheckBox).Checked = True Then

                Dim x As New LocationMaster
                x.TerminalId = lstTerminal.SelectedValue
                Try
                    x.LocationRefId = CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    x.LocationId = CType(rep.FindControl("lstLocation1"), DropDownList).SelectedValue
                Catch ex As Exception
                    x.LocationId = CType(rep.FindControl("hdnLocation"), HiddenField).Value
                End Try
                Try
                    x.LocationName = CType(rep.FindControl("lstLocation1"), DropDownList).SelectedItem.Text
                Catch ex As Exception
                    x.LocationName = CType(rep.FindControl("lblLocation"), Label).Text
                End Try
                Try
                    x.Distance = CType(rep.FindControl("textDistance"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.Toll = CType(rep.FindControl("textToll"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.AdvanceRs = CType(rep.FindControl("textAdvance"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.OilAdvance = CType(rep.FindControl("textOilAdvance"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.ALAdvance = CType(rep.FindControl("textAlAdvance"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.Oil20 = CType(rep.FindControl("text20oil"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.Oil40 = CType(rep.FindControl("Text40Oil"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.Double20Oil = CType(rep.FindControl("TextDouble20oil"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.DoubleTwenty = CType(rep.FindControl("textDoubleTwenty"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.HandoverLocation = CType(rep.FindControl("lstHandover"), DropDownList).SelectedValue
                Catch ex As Exception
                    x.HandoverLocation = CType(rep.FindControl("hdnHandover"), HiddenField).Value
                End Try
                Try
                    x.CustomerId = CType(rep.FindControl("lstCustomer"), DropDownList).SelectedValue
                Catch ex As Exception
                    x.CustomerId = CType(rep.FindControl("hdnCustomer"), HiddenField).Value
                End Try
                Try
                    x.VehicleType = CType(rep.FindControl("LstVehicleType"), DropDownList).SelectedValue
                Catch ex As Exception
                    x.VehicleType = CType(rep.FindControl("HiddenField1"), HiddenField).Value
                End Try
                pLocationMaster.LocationList.Add(x)
            End If
        Next
        Return pLocationMaster
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        'Dim pLocationMaster As New LocationMaster
        'pLocationMaster.TerminalId = pCodevalue.Value
        'hdnTerminalID.Value = pLocationMaster.TerminalId
        'lstTerminal.SelectedValue = pLocationMaster.TerminalId

        hdnTerminalID.Value = pCodevalue.Value
        lstTerminal.SelectedValue = pCodevalue.Value
        'Dim arr As New ArrayList
        'arr = LocationMaster.ReturnLocationMasterListlocation(pLocationMaster)
        'If arr.Count >= ROWS Then
        '    ROWS = (arr.Count + 10)
        'End If
        'fillRepeator(arr)

        Dim table As New DataTable
        Dim strConnString As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConnString)
        Dim cmd As New OleDbCommand()
        Dim ada As New OleDbDataAdapter()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SELECT_PKG.SP_LOCATION_MASTER_BY_HARI"
        cmd.Parameters.AddWithValue("@p_TERMINAL_ID", pCodevalue.Value)
        cmd.Connection = con
        ada.SelectCommand = cmd
        Try
            con.Open()
            ada.Fill(table)

            If table.Rows.Count > 0 Then
                ViewState("totalRows") = table.Rows.Count
            Else
                ViewState("totalRows") = 0
            End If
            ViewState("table") = table

            Dim tb As New DataTable()
            ada = New OleDbDataAdapter()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT LOCATION_ID , LOCATION_NAME FROM TERMINAL_LOCATION_MASTER WHERE TERMINAL_ID=" & pCodevalue.Value & " ORDER BY LOCATION_NAME ASC"
            ada.SelectCommand = cmd
            ada.Fill(tb)
            lstLocation.DataSource = tb
            lstLocation.DataTextField = "LOCATION_NAME"
            lstLocation.DataValueField = "LOCATION_ID"
            lstLocation.DataBind()
            lstLocation.Items.Insert(0, New ListItem("--Select--", "0"))
            lstCustomer.SelectedValue = "0"
            lstHandover.SelectedValue = "0"
            ViewState("LOCATION") = tb

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        fillRepeatorHari(table)
    End Sub

    Protected Sub repLocation_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repLocation.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then

            If e.Item.ItemIndex >= ViewState("totalRows") Then
                CType(e.Item.FindControl("hdnLocation"), HiddenField).Visible = False
                CType(e.Item.FindControl("lblLocation"), Label).Enabled = False
                CType(e.Item.FindControl("lblLocation"), Label).Visible = False
                CType(e.Item.FindControl("lstLocation1"), DropDownList).Visible = True
                CType(e.Item.FindControl("lstLocation1"), DropDownList).Enabled = True
                CType(e.Item.FindControl("lstLocation1"), DropDownList).DataSource = ViewState("LOCATION")
                CType(e.Item.FindControl("lstLocation1"), DropDownList).DataTextField = "LOCATION_NAME"
                CType(e.Item.FindControl("lstLocation1"), DropDownList).DataValueField = "LOCATION_ID"
                CType(e.Item.FindControl("lstLocation1"), DropDownList).DataBind()
                CType(e.Item.FindControl("lstLocation1"), DropDownList).Items.Insert(0, New ListItem("--Select--", "0"))

                CType(e.Item.FindControl("HiddenField1"), HiddenField).Visible = False
                CType(e.Item.FindControl("LblVehicleType"), Label).Enabled = False
                CType(e.Item.FindControl("LblVehicleType"), Label).Visible = False
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).Visible = True
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).Enabled = True
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).DataSource = ViewState("EQUIPMENTTYPE")
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).DataTextField = "EQUIPMENT_TYPE_NAME"
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).DataValueField = "EQUIPMENT_TYPE_CODE"
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).DataBind()
                CType(e.Item.FindControl("LstVehicleType"), DropDownList).Items.Insert(0, New ListItem("--Select--", "0"))

                CType(e.Item.FindControl("hdnHandover"), HiddenField).Visible = False
                CType(e.Item.FindControl("lblHandover"), Label).Enabled = False
                CType(e.Item.FindControl("lblHandover"), Label).Visible = False
                CType(e.Item.FindControl("lstHandover"), DropDownList).Visible = True
                CType(e.Item.FindControl("lstHandover"), DropDownList).Enabled = True

                CType(e.Item.FindControl("lstHandover"), DropDownList).DataSource = ViewState("TERMINAL")
                CType(e.Item.FindControl("lstHandover"), DropDownList).DataTextField = "TERMINAL_NAME"
                CType(e.Item.FindControl("lstHandover"), DropDownList).DataValueField = "TERMINAL_ID"
                CType(e.Item.FindControl("lstHandover"), DropDownList).DataBind()
                CType(e.Item.FindControl("lstHandover"), DropDownList).Items.Insert(0, New ListItem("ALL", "0"))

                CType(e.Item.FindControl("hdnCustomer"), HiddenField).Visible = False
                CType(e.Item.FindControl("lblCustomer"), Label).Enabled = False
                CType(e.Item.FindControl("lblCustomer"), Label).Visible = False
                CType(e.Item.FindControl("lstCustomer"), DropDownList).Visible = True
                CType(e.Item.FindControl("lstCustomer"), DropDownList).Enabled = True

                CType(e.Item.FindControl("lstCustomer"), DropDownList).DataSource = ViewState("CUSTOMER")
                CType(e.Item.FindControl("lstCustomer"), DropDownList).DataTextField = "CUSTOMER_NAME"
                CType(e.Item.FindControl("lstCustomer"), DropDownList).DataValueField = "CUSTOMER_ID"
                CType(e.Item.FindControl("lstCustomer"), DropDownList).DataBind()
                CType(e.Item.FindControl("lstCustomer"), DropDownList).Items.Insert(0, New ListItem("ALL", "0"))
            End If

        End If
    End Sub
    Protected Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Dim table As New DataTable
        table = ViewState("table")
        table.Rows.Add("0", "0", "0", "", "0", "0", "0", "0", "0", "0", "0", "0", "0")
        table.Rows.Add("0", "0", "0", "", "0", "0", "0", "0", "0", "0", "0", "0", "0")
        table.Rows.Add("0", "0", "0", "", "0", "0", "0", "0", "0", "0", "0", "0", "0")
        table.Rows.Add("0", "0", "0", "", "0", "0", "0", "0", "0", "0", "0", "0", "0")
        fillRepeatorHari(table)
        lstLocation.Visible = False
        lstHandover.Visible = False
        lstCustomer.Visible = False
        btnChange.Visible = False
        btnEdit.Visible = False
        btnSave.Visible = True
        btnCancel.Visible = True
        manageUserControls(False)
        tvTreeView.Enabled = False
        lstTerminal.Enabled = False
        manageRepeatorControl(True)
        lstLocation.Enabled = False
    End Sub

End Class


