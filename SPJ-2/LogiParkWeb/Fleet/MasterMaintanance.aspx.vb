Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO
Partial Class Fleet_MasterMaintanance
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ' ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            ListControlDataBind()
        End If
    End Sub

    Sub ListControlDataBind()
        Dim pPOL As New PortMaster
        pPOL.TerminalId = 1
        lstPOL.DataSource = PortMaster.ReturnPortMasterIndia(pPOL)
        lstPOL.DataValueField = "PortId"
        lstPOL.DataTextField = "PortName"
        lstPOL.DataBind()
        lstPOL.Items.Add(New ListItem("---Select---", "0"))
        lstPOL.SelectedValue = 0

        Dim pFPOL As New PortMaster
        pFPOL.TerminalId = 1
        lstFPOD.DataSource = PortMaster.ReturnPortMasterList(pPOL)
        lstFPOD.DataValueField = "PortId"
        lstFPOD.DataTextField = "PortName"
        lstFPOD.DataBind()
        lstFPOD.Items.Add(New ListItem("---Select---", "0"))
        lstFPOD.SelectedValue = 0

        Dim strConnectionString, cmd1, cmd2, cmd3, cmd4, cmd5 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'S') ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('E','I') ORDER BY CUSTOMER_NAME"
            cmd3 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'L' ORDER BY CUSTOMER_NAME"
            cmd4 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N') = 'A' ORDER BY CUSTOMER_NAME"
            cmd5 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(EXPORT,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('C') ORDER BY CUSTOMER_NAME"
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
            lstLine.DataSource = ds.Tables(0)
            lstLine.DataTextField = "CUSTOMER_NAME"
            lstLine.DataValueField = "CUSTOMER_ID"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()

            Dim pExtTerminalMaster As New TerminalMaster
            lstMtyPickup.DataSource = TerminalMaster.ReturnTerminalMasterListUserId(Session.Item("LoginUser"))
            lstMtyPickup.DataTextField = "TerminalName"
            lstMtyPickup.DataValueField = "TerminalId"
            lstMtyPickup.DataBind()
            lstMtyPickup.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstMtyPickup.SelectedValue = Session.Item("LoginTerminal")

            lstHandover.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            lstHandover.DataTextField = "TerminalName"
            lstHandover.DataValueField = "TerminalId"
            lstHandover.DataBind()
            lstHandover.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstHandover.SelectedValue = 0

            Dim pExtLocationMaster As New TerminalLocationMaster
            pExtLocationMaster.TerminalId = Session.Item("LoginTerminal")
            lstFactory.DataSource = TerminalLocationMaster.ReturnTerminalLocationMasterList(pExtLocationMaster)
            lstFactory.DataTextField = "LocationName"
            lstFactory.DataValueField = "LocationId"
            lstFactory.DataBind()
            lstFactory.Items.Insert(0, (New ListItem("---Select---", 0)))
            lstFactory.SelectedValue = 0

            con.Dispose()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        textContNo.Enabled = True
        btnSearchGr.Visible = True
        btnSearchGr.Enabled = True
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
      

    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible

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

    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearchGr.Click
        Dim pFleetGrMapping As New FleetGrMapping
        pFleetGrMapping.ContNo = textContNo.Text
        lstGRNo.DataSource = FleetGrMapping.ReturnFleetGrMappingListByContNo(pFleetGrMapping)
        lstGRNo.DataValueField = "GrId"
        lstGRNo.DataTextField = "GrNo"
        lstGRNo.DataBind()
        lstGRNo.Items.Add(New ListItem("---ALL---", "0"))
        lstGRNo.SelectedValue = 0
        lstGRNo.Enabled = True
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")

        ButtonControlSetup(True)
        manageUserControls(True)
        'tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub lstGRNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGRNo.SelectedIndexChanged
        If lstGRNo.SelectedValue = "0" Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Seletc GR No from list.")
        Else
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim pGr As New FleetGrMapping
            pGr.TerminalId = 1
            pGr.GrNo = lstGRNo.SelectedItem.Text
            FleetGrMapping.ReturnFleetGrMappingByGrNo(pGr)
            textGRdate.Text = pGr.GrDate
            lstPOL.SelectedValue = pGr.POL
            lstFPOD.SelectedValue = pGr.FPOD
            lstConsignmentType.SelectedValue = pGr.ConsignmentType

            Dim pFleetVehicleStatus As New FleetVehicleStatus
            pFleetVehicleStatus.GrNo = lstGRNo.SelectedItem.Text
            FleetVehicleStatus.ReturnFleetVehicleStatus(pFleetVehicleStatus)
            textICDOutDate.Text = pFleetVehicleStatus.IcdOut
            textFactoryInDate.Text = pFleetVehicleStatus.FactoryIn
            textFactoryOutDate.Text = pFleetVehicleStatus.FactoryOut
            textICDInDate.Text = pFleetVehicleStatus.IcdIn

            Dim pFleetContJo As New ExtFleetContJo
            pFleetContJo.ContJoId = pGr.ContJoId
            ExtFleetContJo.ReturnFleetContJo(pFleetContJo)
            textJONo.Text = pFleetContJo.ContJoNo
            textJODate.Text = pFleetContJo.CreatedOn
            lstMtyPickup.SelectedValue = pFleetContJo.MtyPickup
            Try
                lstFactory.SelectedValue = pFleetContJo.FromLocation
            Catch ex As Exception
            End Try
            

            lstHandover.SelectedValue = pFleetContJo.HandLocation
            lstCustomer.SelectedValue = pFleetContJo.CustomerId
            lstConsignee.SelectedValue = pFleetContJo.ConsigneeId
            lstLine.SelectedValue = pFleetContJo.LineId
            btnEdit.Visible = True
        End If
    End Sub
End Class
