Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_FleetVehicleJo
    Inherits System.Web.UI.Page
    Dim rows As Integer = 6
    Dim glVehicleList As New ArrayList
    Dim count As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareContData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            ListControlDataBind()
            btnAdd.Visible = True
            fillRepeator(New ArrayList)
            manageUserControls(False)
            ButtonControlSetup(False)
            textGrNo.Enabled = False
            textGrDate.Enabled = False
        End If
    End Sub
    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < rows Then
            For i As Integer = 0 To rows - arr.Count - 1
                Dim p As New FleetContJoDtls
                arr.Add(p)
            Next
        End If
        repBookingContDeatils.DataSource = arr
        repBookingContDeatils.DataBind()
    End Sub
    Protected Sub preparevehicle(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("--Select--", 0))
            For Each ic As FleetEquipmentMaster In glVehicleList
                lst.Items.Add(New ListItem(ic.EquipmentNo, ic.EquipmentId))
            Next

        Catch ex As Exception
        End Try
    End Sub
    Sub prepareContData()

        Dim pIso As New FleetEquipmentMaster
        pIso.TerminalId = Session.Item("LoginTerminal")
        glVehicleList = FleetEquipmentMaster.ReturnFleetEquipmentMasterListPending(pIso)
    End Sub

    Sub ListControlDataBind()
        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'S') ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('E','I') ORDER BY CUSTOMER_NAME"
            cmd3 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'L' ORDER BY CUSTOMER_NAME"
            cmd4 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'A' ORDER BY CUSTOMER_NAME"


            con = New OleDbConnection(strConnectionString)
            con.Open()

            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            lstCustomer.DataSource = ds.Tables(0)
            lstCustomer.DataTextField = "CUSTOMER_NAME"
            lstCustomer.DataValueField = "CUSTOMER_ID"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            ada = New OleDbDataAdapter(cmd2, con)
            ada.Fill(ds)
            lstConsignee.DataSource = ds.Tables(0)
            lstConsignee.DataTextField = "CUSTOMER_NAME"
            lstConsignee.DataValueField = "CUSTOMER_ID"
            lstConsignee.DataBind()
            lstConsignee.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            ada = New OleDbDataAdapter(cmd3, con)
            ada.Fill(ds)
            lstLine1.DataSource = ds.Tables(0)
            lstLine1.DataTextField = "CUSTOMER_NAME"
            lstLine1.DataValueField = "CUSTOMER_ID"
            lstLine1.DataBind()
            lstLine1.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            ada = New OleDbDataAdapter(cmd4, con)
            ada.Fill(ds)
            lstOnAccount.DataSource = ds.Tables(0)
            lstOnAccount.DataTextField = "CUSTOMER_NAME"
            lstOnAccount.DataValueField = "CUSTOMER_ID"
            lstOnAccount.DataBind()
            lstOnAccount.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            Dim pExtVendorMaster As New ExtVendorMaster
            pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
            lstTransportar.DataSource = ExtVendorMaster.ReturnVendorMasterListAllExportTransporter(pExtVendorMaster)
            lstTransportar.DataTextField = "VendorName"
            lstTransportar.DataValueField = "VendorId"
            lstTransportar.DataBind()
            lstTransportar.Items.Insert(0, (New ListItem("---Self---", 0)))
            lstTransportar.SelectedValue = 0

            Dim pExtLocationMaster As New TerminalLocationMaster
            pExtLocationMaster.TerminalId = Session.Item("LoginTerminal")
            lstFromLocation.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
            lstFromLocation.DataTextField = "LocationName"
            lstFromLocation.DataValueField = "LocationId"
            lstFromLocation.DataBind()
            lstFromLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstFromLocation.SelectedValue = 0

            Dim pExtTerminalMaster As New TerminalMaster
            lstToLocation.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            lstToLocation.DataTextField = "TerminalName"
            lstToLocation.DataValueField = "TerminalId"
            lstToLocation.DataBind()
            lstToLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstToLocation.SelectedValue = 0        
            con.Dispose()
            con.Close()
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

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnsearchJo.Visible = True
        textGrNo.Enabled = True

    End Sub



    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True


        If lstCustomer.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblExporterShipper.Text)
            Functions.ControlFocus(lstCustomer)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstConsignee.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblConsignee.Text)
            Functions.ControlFocus(lstConsignee)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstLine1.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblLine1.Text)
            Functions.ControlFocus(lstLine1)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
    
        If lstFromLocation.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblFromLocation.Text)
            Functions.ControlFocus(lstFromLocation)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstToLocation.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select" & lblToLocation.Text)
            Functions.ControlFocus(lstToLocation)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If lstFromLocation.SelectedValue = lstToLocation.SelectedValue Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Location and To Location can not be same.")
            Functions.ControlFocus(lstFromLocation)
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
        Dim pFleetContJo As ExtFleetContJo = ReturnObject()
        ExtFleetContJo.InsertUpdateFleetContJo(pFleetContJo)
        If pFleetContJo.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetContJo.Errormsg)
            'Functions.ControlFocus(lstCHA)
            Return
        End If
        textGrDate.Text = pFleetContJo.CreatedOn
        textGrNo.Text = pFleetContJo.ContJoNo
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        btnAdd.Visible = True
    End Sub

    Sub FILLDATA(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim lstVehicleNo As DropDownList = sender
            Dim index1 As Integer = Integer.Parse(lstVehicleNo.ClientID.Substring("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length, lstVehicleNo.ClientID.IndexOf("_lstVehicleNo") - "ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl".Length))
            Dim rep As RepeaterItem
            Dim rep1 As Repeater = repBookingContDeatils
            rep = repBookingContDeatils.Items(index1 - 1)
            If lstVehicleNo.SelectedItem.Text <> "" Then
                Dim pVehicle As New FleetEquipmentMaster
                pVehicle.TerminalId = Session.Item("LoginTerminal")
                pVehicle.EquipmentNo = lstVehicleNo.SelectedItem.Text
                FleetEquipmentMaster.ReturnFleetEquipmentMaster(pVehicle)
                If pVehicle.EquipmentType = "T40" Then
                    CType(rep.FindControl("textSize"), TextBox).Text = "40"
                ElseIf pVehicle.EquipmentType = "T20" Then
                    CType(rep.FindControl("textSize"), TextBox).Text = "20"
                End If
                CType(rep.FindControl("textType"), TextBox).Text = pVehicle.CreatedBy
            End If
        Catch ex As Exception
        End Try
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

    Private Function ReturnObject() As ExtFleetContJo
        Dim pGrMapping As New ExtFleetContJo
        pGrMapping.TerminalId = Session.Item("LoginTerminal")
        pGrMapping.TripType = lstDocType.SelectedValue
        pGrMapping.JoType = "V"
       
        pGrMapping.OnAccount = lstOnAccount.SelectedValue
        pGrMapping.CreatedBy = Session.Item("LoginUser")
        pGrMapping.CustomerId = lstCustomer.SelectedValue
        pGrMapping.ConsigneeId = lstConsignee.SelectedValue
        pGrMapping.TransporterId = lstTransportar.SelectedValue
        pGrMapping.ToLocationId = lstToLocation.SelectedValue
        pGrMapping.FromLocation = lstFromLocation.SelectedValue
        pGrMapping.TripType = lstDocType.SelectedValue
        pGrMapping.LineId = lstLine1.SelectedValue
        pGrMapping.OnAccount = lstOnAccount.SelectedValue
        If lstBillTo.SelectedValue = "R" Then
            pGrMapping.BillTo = pGrMapping.CustomerId
        ElseIf lstBillTo.SelectedValue = "E" Then
            pGrMapping.BillTo = pGrMapping.ConsigneeId
        ElseIf lstBillTo.SelectedValue = "L" Then
            pGrMapping.BillTo = pGrMapping.LineId
        ElseIf lstBillTo.SelectedValue = "O" Then
            pGrMapping.BillTo = pGrMapping.OnAccount

        End If
        pGrMapping.ContJoDtlsList = New ArrayList
        For Each rep As RepeaterItem In repBookingContDeatils.Items
            If CType(rep.FindControl("lstVehicleNo"), DropDownList).SelectedValue > 0 Then
                Dim pfId As New FleetContJoDtls
                pfId.TerminalId = Session.Item("LoginTerminal")
                Try
                    pfId.MtyContId = CType(rep.FindControl("hdnContId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pfId.ContJoId = hdnJoId.Value

                Catch ex As Exception

                End Try
                pfId.TripType = lstDocType.SelectedValue
                pfId.JoType = "V"
                pfId.GrId = CType(rep.FindControl("lstVehicleNo"), DropDownList).SelectedValue
                pfId.ContNo = CType(rep.FindControl("lstVehicleNo"), DropDownList).SelectedItem.Text
                '   pfId.Weight = CType(rep.FindControl("textWeight"), TextBox).Text
                pfId.ContSize = CType(rep.FindControl("textSize"), TextBox).Text
                pfId.ContType = CType(rep.FindControl("textType"), TextBox).Text
                pGrMapping.ContJoDtlsList.Add(pfId)
            End If
        Next
        Return pGrMapping
    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(False)
        ButtonControlSetup(False)
        'textBookingNo.Enabled = True
        'btnSearchbookingNo.Visible = False
        'btnAddBookingNo.Visible = True
        textGrNo.Enabled = False
        textGrDate.Enabled = False
        ' Functions.ControlFocus(lstVehicleNo)

    End Sub

    Protected Sub btnsearchJo_Click(sender As Object, e As System.EventArgs) Handles btnsearchJo.Click

        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoNo = textGrNo.Text
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
        lstCustomer.SelectedValue = pFleetContJo.CustomerId

        lstLine1.SelectedValue = pFleetContJo.LineId
        If pFleetContJo.LineId = pFleetContJo.BillTo Then
            lstBillTo.SelectedValue = "L"
        ElseIf pFleetContJo.ConsigneeId = pFleetContJo.BillTo Then
            lstBillTo.SelectedValue = "E"
        ElseIf pFleetContJo.CustomerId = pFleetContJo.BillTo Then
            lstBillTo.SelectedValue = "R"
        End If
        lstTransportar.SelectedValue = pFleetContJo.TransporterId
        lstFromLocation.SelectedValue = pFleetContJo.FromLocation
        lstToLocation.SelectedValue = pFleetContJo.ToLocationId
        textGrDate.Text = pFleetContJo.CreatedOn
        lstDocType.SelectedValue = pFleetContJo.TripType
        btnsearchJo.Visible = False
    End Sub
End Class
