Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection
Imports System.Web.Services
Partial Class DriverAttachDetach
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 0
    Dim gEquipmentTypeCode As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        If Not IsPostBack Then
            prepareDataRepControlsList()
            Dim pDriverAttachDetach As New DriverMapping
            fillRepeatorDetach1(DriverMapping.ReturnDriverMasterListForDriverAttachDetachDetach(pDriverAttachDetach))
            Dim pDriverDetach As New DriverMapping
            fillRepeatorAttach(DriverMapping.ReturnDriverMasterListForDriverDetach(pDriverAttachDetach))
            ListControlDataBind()
            manageUserControls(False)
            ButtonControlSetup(True)
            lstVehicleNo.Enabled = True
            btnAttach.Enabled = True
            btnDetach.Enabled = True
            btnAttach.Visible = True
            btnDetach.Visible = True
            btnEdit.Visible = False
        End If
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER  WHERE DRIVER_ATTCAH_STATUS IS NULL AND CONDITION='G'"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("EQUIPMNET")
            ada.Fill(ds)
            lstVehicleNo.Items.Clear()
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "EQUIPMENT_NO"
            lstVehicleNo.DataValueField = "EQUIPMENT_ID"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try

    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        btnEdit.Visible = pVisible

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

    Sub Permission(ByVal P As String)
        Dim ds2 = CType(Session.Item("MenuXml"), DataSet)
If ds2 Is Nothing Then
     Return
End If
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        If dv.ToTable.Rows.Count > 0 Then
            For Each row As DataRow In dv.ToTable.Rows
                Session.Item("Add") = row(7).ToString
                Session.Item("Edit") = row(8).ToString
                Session.Item("Delete") = row(9).ToString
                Session.Item("Search") = row(10).ToString
                Session.Item("Title") = row(4).ToString
            Next
        Else
            Response.Redirect("~/Restriction.aspx")
        End If

    End Sub

    Private Sub fillRepeatorAttach(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New DriverMapping
                arr.Add(p)
            Next
        End If
        repAttacedhList.DataSource = arr
        repAttacedhList.DataBind()
    End Sub
    Private Sub fillRepeatorDetach(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New DriverMapping
                arr.Add(p)
            Next
        End If
        repDetachedList.DataSource = arr
        repDetachedList.DataBind()
    End Sub
    Private Sub fillRepeatorDetach1(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New FleetDriverMaster
                arr.Add(p)
            Next
        End If
        repDetachedList.DataSource = arr
        repDetachedList.DataBind()
    End Sub
    Private Sub fillRepeatorAtachDriver(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New DriverMapping
                arr.Add(p)
            Next
        End If
        repDetachedList.DataSource = arr
        repDetachedList.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Protected Sub btnAttach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAttach.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pATTACH As DriverMapping = ReturnObject()
        If pATTACH.listDriverAttachDetach.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Vehicle Details.")
            Return
            Exit Sub
        End If
        DriverMapping.InsertDriverAttachDetachDetails(pATTACH)
        If pATTACH.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pATTACH.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")

        ButtonControlSetup(True)
        manageUserControls(True)
        prepareDataRepControlsList()

        'Dim pFleetBedMasterAttach As New FleetBedMaster
        Dim pDriverAttachDetach As New DriverMapping
        fillRepeatorDetach1(DriverMapping.ReturnDriverMasterListForDriverAttachDetachDetach(pDriverAttachDetach))
        Dim pDriverDetach1 As New DriverMapping
        fillRepeatorAttach(DriverMapping.ReturnDriverMasterListForDriverDetach(pDriverDetach1))
        ListControlDataBind()
        lstVehicleNo.Enabled = True
        btnEdit.Visible = False
    End Sub
    Private Function ReturnObject() As DriverMapping
        Dim pDriverMapping As New DriverMapping
        pDriverMapping.listDriverAttachDetach = New ArrayList
        For Each rep As RepeaterItem In repDetachedList.Items
            If CType(rep.FindControl("textPosition"), TextBox).Text <> Nothing Then
                Dim x As New DriverMapping
                Try
                    x.DriverId = CType(rep.FindControl("hdnDriverId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    x.DriverName = CType(rep.FindControl("lblequpmentCode"), Label).Text
                Catch ex As Exception
                End Try
                Try
                    x.VehicleType = CType(rep.FindControl("txtBedSize"), Label).Text
                Catch ex As Exception
                End Try
                Try
                    x.VehicleType = CType(rep.FindControl("lstBedType"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    x.EquipmentNo = CType(rep.FindControl("textPosition"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.EquipmentId = CType(rep.FindControl("hdnSelectedPositionId"), HiddenField).Value
                Catch ex As Exception
                End Try
                x.AttachBy = Session.Item("Loginuser")
                pDriverMapping.listDriverAttachDetach.Add(x)
            End If
        Next
        Return pDriverMapping
    End Function
    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        For Each rep As RepeaterItem In repDetachedList.Items
            Dim hdntireId As HiddenField = CType(rep.FindControl("hdntireId"), HiddenField)
            Dim textTireNo As Label = CType(rep.FindControl("textTireNo"), Label)
            Dim textPosition As TextBox = CType(rep.FindControl("textPosition"), TextBox)
            Dim ChkSelect As CheckBox = CType(rep.FindControl("chkSelect"), CheckBox)
            If textPosition.Text.ToString.Trim = String.Empty Then
                textPosition.Text = ""
            End If
            If textPosition.Text <> Nothing Then

                For Each rep2 As RepeaterItem In repDetachedList.Items
                    Dim hdntireId2 As HiddenField = CType(rep2.FindControl("hdntireId"), HiddenField)
                    Dim textTireNo2 As Label = CType(rep2.FindControl("textTireNo"), Label)
                    Dim textPosition2 As TextBox = CType(rep2.FindControl("textPosition"), TextBox)
                    If rep.ItemIndex <> rep2.ItemIndex Then
                        If textPosition2.Text = textPosition.Text Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please change tire position.")
                            Functions.ControlFocus(textPosition2)
                            rtnBool = False
                            Return rtnBool
                            Exit Function
                        End If
                    End If
                Next
            End If
        Next

        Return rtnBool
    End Function
    Function ValidationCheckDetach() As Boolean
        Dim rtnBool As Boolean = True
        For Each rep3 As RepeaterItem In repAttacedhList.Items
            Dim hdntireId3 As HiddenField = CType(rep3.FindControl("hdnUnitRefId"), HiddenField)
            Dim textTireNo3 As TextBox = CType(rep3.FindControl("textTireNo"), TextBox)
            Dim textPosition3 As TextBox = CType(rep3.FindControl("textTirePosition"), TextBox)
            Dim TextRemark As TextBox = CType(rep3.FindControl("TextrRemark"), TextBox)
            Dim ChkSelect As CheckBox = CType(rep3.FindControl("chkSelect"), CheckBox)
            If ChkSelect.Checked = True Then
                If TextRemark.Text = "" Then
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Kindly Enter Detach Remark.")
                    Functions.ControlFocus(TextRemark)
                    rtnBool = False
                    Return rtnBool
                    Exit Function
                End If
            End If

        Next
        Return rtnBool
    End Function
    Protected Sub btnDetach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetach.Click
        If ValidationCheckDetach() = False Then
            Return
        End If
        Dim pDriverDetach As DriverMapping = ReturnObjectdetach()
        If pDriverDetach.listDriverAttachDetach.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Tire Details.")
            Return
            Exit Sub
        End If
        DriverMapping.UpdateDriverDetachDetails(pDriverDetach)
        If pDriverDetach.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pDriverDetach.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        prepareDataRepControlsList()

        Dim pDriverAttachDetach As New DriverMapping
        fillRepeatorDetach1(DriverMapping.ReturnDriverMasterListForDriverAttachDetachDetach(pDriverAttachDetach))
        fillRepeatorAttach(DriverMapping.ReturnDriverMasterListForDriverDetach(pDriverAttachDetach))
        ListControlDataBind()
        lstVehicleNo.Enabled = True
        btnEdit.Visible = False
    End Sub
    Private Function ReturnObjectdetach() As DriverMapping
        Dim pDriverDetach As New DriverMapping
        pDriverDetach.listDriverAttachDetach = New ArrayList
        For Each rep As RepeaterItem In repAttacedhList.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True Then
                Dim x As New DriverMapping
                Try
                    x.AttachId = CType(rep.FindControl("HdnAttachId"), HiddenField).Value
                Catch ex As Exception
                End Try

                Try
                    x.DriverId = CType(rep.FindControl("textDetachBedNo"), TextBox).Text
                Catch ex As Exception

                End Try
                Try
                    x.VehicleType = CType(rep.FindControl("txtDetachBedSize"), Label).Text
                Catch ex As Exception

                End Try
                Try
                    x.EquipmentId = CType(rep.FindControl("hdnDetachEquipmentId"), HiddenField).Value
                Catch ex As Exception
                End Try

                Try
                    x.EquipmentNo = CType(rep.FindControl("txtDetachEquipmentNo"), Label).Text
                Catch ex As Exception

                End Try
                Try
                    x.DetachRemark = CType(rep.FindControl("TextrRemark"), TextBox).Text
                Catch ex As Exception
                End Try
                x.DetachBy = Session.Item("Loginuser")
                pDriverDetach.listDriverAttachDetach.Add(x)
            End If
        Next
        Return pDriverDetach
    End Function

    Protected Sub prepareContType(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("---Select---", ""))
            For Each ic As EquipmentType In gEquipmentTypeCode
                lst.Items.Add(New ListItem(ic.EquipmentTypeCode, ic.EquipmentTypeName))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareDataRepControlsList()
        Dim p As New EquipmentType
        p.TerminalId = Session.Item("LoginTerminal")
        gEquipmentTypeCode = EquipmentType.ReturnEquipmentTypeList(p)
    End Sub

    Protected Sub txtVehiclNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVehiclNo.TextChanged
        lstVehicleNo.Items.Clear()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_ID, EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER WHERE ATTACH_STATUS IS NULL AND BED_CHANGEABLE='Y' AND CONDITION='G' AND EQUIPMENT_NO LIKE '%" + txtVehiclNo.Text.Trim + "' ORDER BY EQUIPMENT_ID"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("EUIPMENT")
            ada.Fill(ds)
            lstVehicleNo.Items.Clear()
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "EQUIPMENT_NO"
            lstVehicleNo.DataValueField = "EQUIPMENT_ID"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
