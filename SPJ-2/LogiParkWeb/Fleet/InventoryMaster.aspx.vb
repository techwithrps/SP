Imports LogiParkLib.LogiParkObjects
Imports System.Data.OleDb
Imports System.Data
Imports LogiParkLib.DBConnection
Imports System.Xml
Imports System.IO

Partial Class Fleet_InventoryMaster
    Inherits System.Web.UI.Page
    Dim rows As Integer = 15
    Public glEquipmentType As New ExtEquipmentType
    Public glManufacturer As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareDataRepControlsList()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            fillRepeatorContainers(New ArrayList)
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If lstItem.SelectedValue <> Nothing Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
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

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        'textEquipmentCode.Enabled = pEnable
    End Sub

    Sub ListControlDataBind()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT ITEM_NAME, ITEM_ID FROM ITEM_MASTER  WHERE  TERMINAL_ID = " & Session.Item("LoginTerminal") & ""

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            lstItem.DataSource = ds.Tables(0)
            lstItem.DataTextField = "ITEM_NAME"
            lstItem.DataValueField = "ITEM_ID"
            lstItem.DataBind()
            lstItem.Items.Insert(0, (New ListItem("---Select---", "0")))
            lstItem.Visible = True
            ds.Clear()
            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try

        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendor.DataSource = ExtVendorMaster.ReturnVendorMasterList(pExtVendorMaster)
        lstVendor.DataTextField = "VendorName"
        lstVendor.DataValueField = "VendorId"
        lstVendor.DataBind()
        lstVendor.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstVendor.SelectedValue = 0
    End Sub

    Sub LoadTreeViewData()
        Dim pFleetInventory As New FleetInventory
        pFleetInventory.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As FleetInventory In FleetInventory.ReturnFleetInventoryList(pFleetInventory)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.InventId, obj.Items)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

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
            manageUserControls(True)
        End If
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Sub fillRepeatorContainers(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New FleetInventoryDtls
                p.InventDtls = "0"
                p.Manufacture = "0"
                arr.Add(p)
            Next
        End If
        rpItem.DataSource = arr
        rpItem.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        hdnMode.Value = "ADD"
        Functions.ControlFocus(lstItem)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ' manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        hdnMode.Value = "EDIT"
        Functions.ControlFocus(lstVendor)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        manageUserControls(True)
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub prepareDataRepControlsList()
        Dim p As New PersonnelMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glManufacturer = PersonnelMaster.ReturnPersonnelMasterList(p)
    End Sub
    Protected Sub prepareManufacturer(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", "0"))
            For Each ic As PersonnelMaster In glManufacturer
                lst.Items.Add(New ListItem(ic.PrName, ic.PrId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareEquipmentType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", "0"))
            For Each CT As EquipmentType In glEquipmentType.EquipmentTypeList
                lst.Items.Add(New ListItem(CT.EquipmentTypeName, CT.EquipmentTypeCode))
            Next
        Catch ex As Exception
        End Try
    End Sub


    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If lstItem.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Item.")
            rtnBool = False
            Functions.ControlFocus(lstItem)
            Return rtnBool
            Exit Function
        End If
        If textQnty.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Qnty")
            rtnBool = False
            Functions.ControlFocus(textQnty)
            Return rtnBool
            Exit Function
        ElseIf textQnty.Text = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Qnty")
            rtnBool = False
            Functions.ControlFocus(textQnty)
            Return rtnBool
            Exit Function
        End If
        If textUnitPrice.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Unit Price")
            rtnBool = False
            Functions.ControlFocus(textUnitPrice)
            Return rtnBool
            Exit Function
        ElseIf textUnitPrice.Text = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Unit Price")
            rtnBool = False
            Functions.ControlFocus(textUnitPrice)
            Return rtnBool
            Exit Function

        End If

        If textBuyingDate.Text = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Buying Date")
            rtnBool = False
            Functions.ControlFocus(textBuyingDate)
            Return rtnBool
            Exit Function
        End If
        If lstVendor.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor.")
            rtnBool = False
            Functions.ControlFocus(lstVendor)
            Return rtnBool
            Exit Function
        End If
        If rpItem.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textItemNo, textItemType, textModelNo, textValidToDate As TextBox
            Dim lstManufacture As DropDownList
            For Each rep1 In rpItem.Items
                textItemNo = rep1.FindControl("textItemNo")
                textItemType = rep1.FindControl("textType")
                textModelNo = rep1.FindControl("textModel")
                textValidToDate = rep1.FindControl("textDate")
                lstManufacture = rep1.FindControl("lstManufacturer")
                If textItemNo.Text.Trim <> Nothing Then
                    'If textItemType.Text.Trim = Nothing Or Double.Parse(textItemType.Text) = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Item Type is Blank.")
                    '    rtnBool = False
                    '    Functions.ControlFocus(textItemType)
                    '    Return rtnBool
                    '    Exit Function
                    'End If
                    'If textModelNo.Text.Trim = Nothing Or Double.Parse(textModelNo.Text) = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Model No is Blank.")
                    '    rtnBool = False
                    '    Functions.ControlFocus(textModelNo)
                    '    Return rtnBool
                    '    Exit Function
                    'End If
                    If lstManufacture.SelectedValue = "0" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Manufacture is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(lstManufacture)
                        Return rtnBool
                        Exit Function
                    End If
                    If textValidToDate.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Date is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textValidToDate)
                        Return rtnBool
                        Exit Function
                    End If

                End If
                For Each rep2 In rpItem.Items
                    Dim textItemNo1 As TextBox
                    textItemNo1 = rep2.FindControl("textItemNo")
                    If textItemNo1.Text <> Nothing Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            If textItemNo.Text = textItemNo1.Text Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblItem.Text & " is Duplicate.")
                                rtnBool = False
                                Functions.ControlFocus(textItemNo)
                                Return rtnBool
                                Exit Function
                            End If
                        End If
                    End If
                Next
            Next
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFIM As ExtFleetInventory = ReturnObject()
        'If pFIM.InventoryDtlsList.Count <= 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Inventory Details.")
        '    Return
        '    Exit Sub
        'End If

        ExtFleetInventory.InsertUpdateFleetInventory(pFIM)
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        hdnInvtId.Value = pFIM.InventId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ExtFleetInventory
        Dim pFleetInventory As New ExtFleetInventory
        If hdnInvtId.Value <> "" AndAlso hdnInvtId.Value > 0 Then
            pFleetInventory.InventId = hdnInvtId.Value
        End If
        pFleetInventory.TerminalId = Session.Item("LoginTerminal")
        pFleetInventory.VendorId = lstVendor.SelectedValue
        pFleetInventory.CreatedBy = Session.Item("LoginUser")
        pFleetInventory.Qnty = textQnty.Text
        pFleetInventory.UnitPrice = textUnitPrice.Text
        pFleetInventory.ItemId = lstItem.SelectedValue
        pFleetInventory.Items = lstItem.SelectedItem.Text
        pFleetInventory.BuyDate = textBuyingDate.Text
        pFleetInventory.InventoryDtlsList = New ArrayList
        For Each rep As RepeaterItem In rpItem.Items
            If CType(rep.FindControl("textItemNo"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textItemNo"), TextBox).Text <> "" Then
                Dim pfid As New FleetInventoryDtls
                pfid.TerminalId = Session.Item("LoginTerminal")
                Try
                    pfid.InventDtls = CType(rep.FindControl("hdnItemDtls"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pfid.InventId = hdnInvtId.Value
                Catch ex As Exception
                End Try
                pfid.ItemType = CType(rep.FindControl("textType"), TextBox).Text
                pfid.ItemNo = CType(rep.FindControl("textItemNo"), TextBox).Text
                pfid.Manufacture = CType(rep.FindControl("lstManufacturer"), DropDownList).SelectedValue
                pfid.ModelNo = CType(rep.FindControl("textModel"), TextBox).Text
                pfid.BuyingDate = CType(rep.FindControl("textDate"), TextBox).Text
                pFleetInventory.InventoryDtlsList.Add(pfid)
            End If
        Next
        Return pFleetInventory
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pfim As New FleetInventory
        pfim.TerminalId = Session.Item("LoginTerminal")
        pfim.InventId = pCodevalue.Value
        FleetInventory.ReturnFleetInventory(pfim)
        hdnInvtId.Value = pfim.InventId
        lstVendor.SelectedValue = pfim.VendorId
        textUnitPrice.Text = pfim.UnitPrice
        textQnty.Text = pfim.Qnty
        textBuyingDate.Text = pfim.BuyDate
        lstItem.SelectedValue = pfim.ItemId
        Dim p As New FleetInventoryDtls
        p.InventId = hdnInvtId.Value
        fillRepeatorContainers(FleetInventoryDtls.ReturnFleetInventoryDtlsList(p))
    End Sub
    Sub InventoryDtls()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT ITEMS,(SELECT VENDOR_NAME FROM VENDOR_MASTER WHERE VENDOR_ID=FLEET_INVENTORY.VENDOR_ID)VENDOR,UNIT_PRICE,QNTY,BUY_DATE FROM FLEET_INVENTORY "

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("DTLS")
            ada.Fill(ds)
            gvInventoryDtls.DataSource = ds.Tables(0)
            gvInventoryDtls.DataBind()
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        InventoryDtls()


        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=InventoryMaster.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvInventoryDtls.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
End Class


