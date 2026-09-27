Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Fleet_VendorPayment
    Inherits System.Web.UI.Page
    Dim rows As Integer = 10
    Public glPayFor As New ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
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
            Session.Item("Delete") = row(9).ToString
            'Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New CustomerMaster
                ' p.TaxHeadId = "0"
                arr.Add(p)
            Next
        End If
        repTaxHead.DataSource = arr
        repTaxHead.DataBind()
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            tvTreeView.Enabled = True
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If textTaxGroupCode.Text.Trim <> Nothing Then
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
    Sub ButtonControlEdit(ByVal pVisible As Boolean)
        btnSearchVendor.Visible = pVisible
        btnSearchVendor.Enabled = pVisible
        LstVendorType.Enabled = pVisible
        GetPaymentData.Visible = Not pVisible
        GetPaymentData.Enabled = Not pVisible
        LstVendorName.Enabled = Not pVisible
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        fillRepeator(New ArrayList)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        ButtonControlEdit(True)
        manageRepetorControl(False)
        'Functions.ControlFocus(textTaxGroupCode)
    End Sub
    Sub manageRepetorControl(ByRef pEnable As Boolean)
        For Each rep As RepeaterItem In repTaxHead.Items
            CType(rep.FindControl("lstTaxHead"), DropDownList).Enabled = pEnable
            CType(rep.FindControl("Textqnty"), TextBox).Enabled = pEnable
            CType(rep.FindControl("TextAmt"), TextBox).Enabled = pEnable
            CType(rep.FindControl("TextDate"), TextBox).Enabled = pEnable
        Next
    End Sub


    Protected Sub btnSearchVendor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchVendor.Click
        If LstVendorType.SelectedValue = "D" Then
            Dim pFleetDriverMaster As New FleetDriverMaster
            pFleetDriverMaster.TerminalId = Session.Item("LoginTerminal")
            LstVendorName.DataSource = FleetDriverMaster.ReturnFleetDriverMasterList(pFleetDriverMaster)
            LstVendorName.DataTextField = "DriverName"
            LstVendorName.DataValueField = "DriverId"
            LstVendorName.DataBind()
            LstVendorName.Items.Insert(0, (New ListItem("---All---", 0)))
            LstVendorName.SelectedValue = 0
        End If
        ButtonControlEdit(False)
    End Sub
    Sub preparePortDataPOD()
        Try
            arrPortId = New ArrayList
            arrPortName = New ArrayList
            Dim pFleetEquipmentMaster As New FleetEquipmentMaster
            For Each obj As FleetEquipmentMaster In FleetEquipmentMaster.ReturnFleetEquipmentMasterListByDriverId(pFleetEquipmentMaster)
                arrPortId.Add(obj.EquipmentId)
                arrPortName.Add(obj.EquipmentNo)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareBillingPartyData()
        Dim p As New FleetEquipmentMaster
        p.TerminalId = LstVendorName.SelectedValue
        glPayFor = FleetEquipmentMaster.ReturnFleetEquipmentMasterListByDriverId(p)
        rows = glPayFor.Count
    End Sub

    Protected Sub preparePaymentFor(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each bp As FleetEquipmentMaster In glPayFor
                lst.Items.Add(New ListItem(bp.EquipmentNo, bp.EquipmentId))
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GetPaymentData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GetPaymentData.Click
        If LstVendorType.SelectedValue = "D" Then
            prepareBillingPartyData()
            fillRepeator(New ArrayList)
            manageRepetorControl(True)
        End If
    End Sub
End Class
