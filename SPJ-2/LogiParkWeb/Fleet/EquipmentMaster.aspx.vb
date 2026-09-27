Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Data.OleDb
Imports LogiParkLib.DBConnection

Partial Class Fleet_EquipmentMaster
    Inherits System.Web.UI.Page
    Dim RowsService As Integer = 3
    Dim RowsTire As Integer = 15
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            tvTreeView.Enabled = True
            ' fillRepeatorTire(New ArrayList)
            ' fillRepeatorService(New ArrayList)
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            tblBedDtls.Visible = False



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
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_TYPE_CODE,EQUIPMENT_TYPE_NAME FROM EQUIPMENT_TYPE ORDER BY EQUIPMENT_TYPE_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("EUIPMENT")
            ada.Fill(ds)
            lstEuipmentType.DataSource = ds.Tables(0)
            lstEuipmentType.DataTextField = "EQUIPMENT_TYPE_NAME"
            lstEuipmentType.DataValueField = "EQUIPMENT_TYPE_CODE"
            lstEuipmentType.DataBind()
            lstEuipmentType.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
        Dim pBedMaster As New FleetBedMaster
        lstBedNo.DataSource = FleetBedMaster.ReturnFleetBedMasterList(pBedMaster)
        lstBedNo.DataTextField = "BedNo"
        lstBedNo.DataValueField = "BedNo"
        lstBedNo.DataBind()
        lstBedNo.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstBedNo.SelectedValue = 0
        Dim pBankMaster As New BankMaster
        pBankMaster.TerminalId = Session.Item("LoginTerminal")

        lstHpBy.DataSource = BankMaster.ReturnBankMasterList(pBankMaster)
        lstHpBy.DataTextField = "BankName"
        lstHpBy.DataValueField = "BankId"
        lstHpBy.DataBind()
        lstHpBy.Items.Insert(0, (New ListItem("----Select----", "0")))

        Dim pVendor As New VendorMaster
        pVendor.TerminalId = Session.Item("LoginTerminal")
        LstTransporter.DataSource = VendorMaster.ReturnVendorMasterList(pVendor)
        LstTransporter.DataTextField = "VendorName"
        LstTransporter.DataValueField = "VendorId"
        LstTransporter.DataBind()
        LstTransporter.Items.Insert(0, (New ListItem("---Select---", 0)))
        LstTransporter.SelectedValue = 0
    End Sub
    Sub LoadTreeViewData()
        Dim pFleetEquipmentMaster As New FleetEquipmentMaster
        pFleetEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        pFleetEquipmentMaster.CompanyId = Session.Item("CompanyId")
        Try
            For Each obj As FleetEquipmentMaster In FleetEquipmentMaster.ReturnFleetEquipmentMasterList(pFleetEquipmentMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.EquipmentId, obj.EquipmentNo)
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
        End If
    End Sub
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textEquipmentNo.Text.Trim <> Nothing Then
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
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        Functions.ControlFocus(textEquipmentNo)
        FileInsurance.Visible = True
        FileRc.Visible = True
        fileVehicleFitness.Visible = True
        FilePermitPartA.Visible = True
        FilePermitB.Visible = True
        lblInsuDtls.Visible = False
        lblRcDtls.Visible = False
        lblpermitAdtls.Visible = False
        lblPermitBDtls.Visible = False
        lblFitDtls.Visible = False
    End Sub
    Sub manageControls(ByRef pEnable As Boolean)
        textEquipmentNo.Enabled = pEnable
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textEquipmentNo)
        FileInsurance.Visible = True
        FileRc.Visible = True
        fileVehicleFitness.Visible = True
        FilePermitPartA.Visible = True
        FilePermitB.Visible = True

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

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.clearControls(Me.dvControl.Controls)
        lblFitDtls.Text = ""
        lblRcDtls.Text = ""
        lblpermitAdtls.Text = ""
        lblPermitBDtls.Text = ""
        lblInsuDtls.Text = ""
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textEquipmentNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEquipmentNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEquipmentNo)
            Return rtnBool
            Exit Function
        End If
        If lstEuipmentType.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lstEuipmentType.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstEuipmentType)
            Return rtnBool
            Exit Function
        End If
        If textEngNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblEngNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textEngNo)
            Return rtnBool
            Exit Function
        End If
        If textChassisNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblChassisNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textChassisNo)
            Return rtnBool
            Exit Function
        End If
        If textManufacturingYear.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblManufacturingYear.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textManufacturingYear)
            Return rtnBool
            Exit Function
        End If
        If lstManufacturer.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblManufacturer.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstManufacturer)
            Return rtnBool
            Exit Function
        End If
        If lstCondition.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCondition.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstCondition)
            Return rtnBool
            Exit Function
        End If
        If lstBedNo.SelectedValue = "" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBedNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstBedNo)
            Return rtnBool
            Exit Function
        End If
        If textTareWt.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTareWt.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTareWt)
            Return rtnBool
            Exit Function
        End If
        If textGrossWt.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblGrossWt.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textGrossWt)
            Return rtnBool
            Exit Function
        End If

        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetEquipmentMaster As FleetEquipmentMaster = ReturnObject()
        FleetEquipmentMaster.InsertUpdate(pFleetEquipmentMaster)
        If pFleetEquipmentMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetEquipmentMaster.Errormsg)
            Functions.ControlFocus(textEquipmentNo)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")

        Functions.addOrModifyLeaf(tvTreeView, pFleetEquipmentMaster.EquipmentNo, pFleetEquipmentMaster.EquipmentId, hdnEquipmentId.Value)
        hdnEquipmentId.Value = pFleetEquipmentMaster.EquipmentId
        Try

            If fileVehicleFitness.PostedFile.FileName <> "" Then
                fileVehicleFitness.PostedFile.SaveAs("C:\Software\JSB\Fitness\" + hdnEquipmentId.Value & pFleetEquipmentMaster.FitnessDoc)

            Else
                pFleetEquipmentMaster.FitnessDoc = hdnVehiclePic.Value
            End If
        Catch ex As Exception
        End Try
        Try
            If FileRc.PostedFile.FileName <> "" Then

                FileRc.PostedFile.SaveAs("C:\Software\JSB\RC\" + hdnEquipmentId.Value & pFleetEquipmentMaster.RCDoc)

            End If
        Catch ex As Exception
        End Try
        Try
            If FilePermitB.PostedFile.FileName <> "" Then

                FilePermitB.PostedFile.SaveAs("C:\Software\JSB\PermitAB\" + hdnEquipmentId.Value & pFleetEquipmentMaster.PermitB)

            End If
        Catch ex As Exception
        End Try
        Try
            If FilePermitPartA.PostedFile.FileName <> "" Then

                FilePermitPartA.PostedFile.SaveAs("C:\Software\JSB\NationalPermit\" + hdnEquipmentId.Value & pFleetEquipmentMaster.PermitA)

            End If
        Catch ex As Exception
        End Try
        Try

            If FileInsurance.PostedFile.FileName <> "" Then

                FileInsurance.PostedFile.SaveAs("C:\Software\JSB\Insurance\" + hdnEquipmentId.Value & pFleetEquipmentMaster.InsuranceDoc)

            End If
        Catch ex As Exception
        End Try
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub
    Private Function ReturnObject() As FleetEquipmentMaster
        Dim pFleetEquipmentMaster As New FleetEquipmentMaster
        If hdnEquipmentId.Value <> "" AndAlso hdnEquipmentId.Value > 0 Then
            pFleetEquipmentMaster.EquipmentId = hdnEquipmentId.Value
        End If
        pFleetEquipmentMaster.CompanyId = Session.Item("CompanyId")
        pFleetEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        pFleetEquipmentMaster.EquipmentNo = textEquipmentNo.Text
        pFleetEquipmentMaster.EquipmentType = lstEuipmentType.SelectedValue
        pFleetEquipmentMaster.PurchageDate = textPucrchageDate.Text
        pFleetEquipmentMaster.InsuranceNo = textInsuranceNo.Text
        pFleetEquipmentMaster.EngNo = textEngNo.Text
        pFleetEquipmentMaster.EngType = textEngType.Text
        pFleetEquipmentMaster.VinNo = textChassisNo.Text
        pFleetEquipmentMaster.ManufacturingYear = textManufacturingYear.Text
        pFleetEquipmentMaster.Model = textModel.Text
        pFleetEquipmentMaster.Condition = lstCondition.SelectedValue
        pFleetEquipmentMaster.Manufacturer = lstManufacturer.SelectedValue
        pFleetEquipmentMaster.RegistrationDate = textRegistrationDate.Text
        pFleetEquipmentMaster.TareWt = textTareWt.Text
        pFleetEquipmentMaster.GrossWt = textGrossWt.Text
        pFleetEquipmentMaster.BedChangeable = lstChangeableBed.SelectedValue
        pFleetEquipmentMaster.BedNo = lstBedNo.SelectedValue
        pFleetEquipmentMaster.InsVendor = lstInsurance.SelectedValue
        pFleetEquipmentMaster.InsValidity = textInsuranceValidity.Text
        pFleetEquipmentMaster.PermitFrom = textPermitFrom.Text
        pFleetEquipmentMaster.PermitTo = textPermitTo.Text
        pFleetEquipmentMaster.PollutionValidity = textpollutionValidity.Text
        pFleetEquipmentMaster.RTO = textRto.Text
        pFleetEquipmentMaster.HpBy = lstHpBy.SelectedValue
        pFleetEquipmentMaster.XlType = textXlType.Text
        If ChkActive.Checked = True Then
            pFleetEquipmentMaster.Status = "Y"
        End If
        Try
            pFleetEquipmentMaster.Validity = textValidity.Text

        Catch ex As Exception

        End Try
        Try
            If fileVehicleFitness.PostedFile.FileName <> "" Then

                pFleetEquipmentMaster.FitnessDoc = Path.GetFileName(fileVehicleFitness.PostedFile.FileName)
                hdnVehiclePic.Value = pFleetEquipmentMaster.Image

            Else
                pFleetEquipmentMaster.FitnessDoc = hdnVehiclePic.Value
            End If
        Catch ex As Exception
        End Try
        Try
            If FileRc.PostedFile.FileName <> "" Then

                pFleetEquipmentMaster.RCDoc = Path.GetFileName(FileRc.PostedFile.FileName)

            End If
        Catch ex As Exception
        End Try
        Try
            If FilePermitB.PostedFile.FileName <> "" Then

                pFleetEquipmentMaster.PermitB = Path.GetFileName(FilePermitB.PostedFile.FileName)

            End If
        Catch ex As Exception
        End Try
        Try
            If FilePermitPartA.PostedFile.FileName <> "" Then

                pFleetEquipmentMaster.PermitA = Path.GetFileName(FilePermitPartA.PostedFile.FileName)

            End If
        Catch ex As Exception
        End Try
        Try
            If FileInsurance.PostedFile.FileName <> "" Then

                pFleetEquipmentMaster.InsuranceDoc = Path.GetFileName(FileInsurance.PostedFile.FileName)

            End If
        Catch ex As Exception
        End Try
        Try
            pFleetEquipmentMaster.VendorId = LstTransporter.SelectedValue
        Catch ex As Exception

        End Try
        pFleetEquipmentMaster.CreatedBy = Session.Item("LoginUser")
        Return pFleetEquipmentMaster
    End Function
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New FleetEquipmentMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.EquipmentId = pCodevalue.Value
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(p)
        hdnEquipmentId.Value = p.EquipmentId
        textEquipmentNo.Text = p.EquipmentNo
        lstEuipmentType.SelectedValue = p.EquipmentType
        textPucrchageDate.Text = p.PurchageDate
        textInsuranceNo.Text = p.InsuranceNo
        textEngNo.Text = p.EngNo
        textEngType.Text = p.EngType
        textChassisNo.Text = p.VinNo
        textManufacturingYear.Text = p.ManufacturingYear
        textModel.Text = p.Model
        lstCondition.SelectedValue = p.Condition
        lstManufacturer.SelectedValue = p.Manufacturer
        textRegistrationDate.Text = p.RegistrationDate
        textTareWt.Text = p.TareWt
        textGrossWt.Text = p.GrossWt
        lstChangeableBed.SelectedValue = p.BedChangeable
        If p.Status = "Y" Then
            ChkActive.Checked = True
        End If
        Try
            lstBedNo.SelectedValue = p.BedNo
        Catch ex As Exception
        End Try
        lstInsurance.SelectedValue = p.InsVendor
        textInsuranceValidity.Text = p.InsValidity
        textPermitFrom.Text = p.PermitFrom
        textPermitTo.Text = p.PermitTo
        textpollutionValidity.Text = p.PollutionValidity
        textRto.Text = p.RTO
        textValidity.Text = p.Validity
        textXlType.Text = p.XlType
        lstHpBy.SelectedValue = p.HpBy
        If p.InsuranceDoc <> Nothing Then
            FileInsurance.Visible = False
            lblInsuDtls.Text = p.InsuranceDoc
        End If
        If p.RCDoc <> Nothing Then
            FileRc.Visible = False
            lblRcDtls.Text = p.RCDoc
        End If
        If p.FitnessDoc <> Nothing Then
            fileVehicleFitness.Visible = False
            lblFitDtls.Text = p.FitnessDoc
        End If
        If p.PermitA <> Nothing Then
            FilePermitPartA.Visible = False
            lblpermitAdtls.Text = p.PermitA
        End If
        If p.PermitB <> Nothing Then
            FilePermitB.Visible = False
            lblPermitBDtls.Text = p.PermitB
        End If
        Try
            LstTransporter.SelectedValue = p.VendorId
        Catch ex As Exception

        End Try
    End Sub
    Sub EqpmntDtls()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_NO VEHICLE_NO,EQUIPMENT_TYPE VEHICLE_TYPE,XL_TYPE,INSURANCE_NO,ENG_NO,DECODE(MANUFACTURER,1,'TATA',2,'ASHOK LEYLAND',3,'EICHER')MANUFACTURER," _
                    & " DECODE(INS_VENDOR,1,'ICICI LOMABRD',2,'LIC',3,'HDFC',4,'UIICL',5,'NIICL',6,'ORIENTEL',7,'IFFCO-TOKIO',8,'NATIONAL INSURANCE')INS_VENDOR," _
                    & " TO_CHAR(INS_VALIDITY,'DD/MM/YYYY')INS_VALIDITY,VIN_NO CHASSIS_NO,MODEL,TO_CHAR(PERMIT_FROM,'DD/MM/YYYY')NATIONAL_PERMIT_VALIDITY,TO_CHAR(POLLUTION_VALIDITY,'DD/MM/YYYY')POLLUTION_VALIDITY," _
                    & " DECODE(STATUS,'0','NOT ACTIVE','Y','ACTIVE')STATUS,TO_CHAR(VALIDITY,'DD/MM/YYYY')FITNESS_VALIDITY,MANUFACTURING_YEAR FROM FLEET_EQUIPMENT_MASTER "

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("DTLS")
            ada.Fill(ds)
            gvEqpmntDtls.DataSource = ds.Tables(0)
            gvEqpmntDtls.DataBind()
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        EqpmntDtls()


        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=VehicleMaster.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvEqpmntDtls.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    Sub TireDtls()
        Dim strpParms As String = ""
        strpParms &= lstBedNo.SelectedValue

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_BED_MASTER_BY_BED", strpParms)
        gvTireDetails.DataSource = dbr
        gvTireDetails.DataBind()
        If dbr.HasRows Then
            tblBedDtls.Visible = True
        Else
            tblBedDtls.Visible = False

        End If
        dbr.Close()
        db.CloseDB()

    End Sub

End Class
