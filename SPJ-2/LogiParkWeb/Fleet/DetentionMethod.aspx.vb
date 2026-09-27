Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_DetentionMethod
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            manageUserControls(True)
            ' ListControlDataBind()
            ' ButtonControlSetup(True)
            btnSave.Visible = False
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        TextGrno.Enabled = True
        btnSearchGr.Visible = True
        btnSearchGr.Enabled = True
        LstDetMethod.Enabled = True
        textLineSealNo.Enabled = True
        btnSave.Enabled = True
        ButtonControlSetup(True)
        Functions.ControlFocus(TextGrno)
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
    Sub LoadTreeViewData(ByVal pFleetContJoDtls As FleetContJoDtls)
        tvContainers.Nodes.Clear()
        Try
            For Each obj As FleetContJoDtls In FleetContJoDtls.ReturnFleetContJoDtlslCont(pFleetContJoDtls)
                FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
                ' ImpInvoice.ReturnImpInvoiceListByLineItemId(pExtImpInvoice)
                Dim pFleetContJo As New FleetContJo
                pFleetContJo.ContJoId = obj.ContJoId
                FleetContJo.ReturnFleetContJo(pFleetContJo)
                btnSave.Enabled = True
                Dim pCustomerMaster As New CustomerMaster
                pCustomerMaster.CustomerId = pFleetContJo.ConsigneeId
                CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
                Dim pAllPartyAccount As New AllPartyAccount
                pAllPartyAccount.MtyContId = obj.MtyContId
                AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
                Functions.treeViewNodeSetup(tvContainers, "0", obj.MtyContId, obj.ContNo & " | SB-" & pAllPartyAccount.SbNo & " | Handover-" & obj.DOValidity & " | GR-" & obj.SealNo & " | " & "Consignee-" & pCustomerMaster.CustomerName)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub tvContainers_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvContainers.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        fillControlWithData(tvContainers.SelectedNode)
        ' SaveViewState()
        ' manageUserControls(True)
        'Functions.ControlFocus(btnAdd)

    End Sub
    Sub fillControlWithData(ByVal PCodeValue As TreeNode)
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.MtyContId = PCodeValue.Value
        ' LoadTreeViewData(pFleetContJoDtls)
        FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
        textLineSealNo.Text = pFleetContJoDtls.SealNo
        hdnMtyContId.Value = PCodeValue.Value
        If pFleetContJoDtls.MtyContId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Container not booked yet.")
            Return
        End If
        If pFleetContJoDtls.GrId = 0 Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Gr not Generated.")
            Return
        End If
        hdnMtyContId.Value = pFleetContJoDtls.MtyContId
        hdngrId.Value = pFleetContJoDtls.GrId
        Dim P As New FleetGrMapping
        P.GrId = pFleetContJoDtls.GrId
        FleetGrMapping.ReturnFleetGrMapping(P)

        Dim str As String
        Dim strArr() As String
        Dim count As Integer
        str = P.ContNo
        strArr = str.Split("-")
        For count = 0 To strArr.Length - 1
            If count = 0 Then
            Else
                textjoNo.Text = (strArr(count))
            End If
        Next
        Dim pContJO As New FleetContJo
        pContJO.ContJoNo = textjoNo.Text
        FleetContJo.ReturnFleetContJo(pContJO)

        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.MtyContId = pFleetContJoDtls.MtyContId
        pAllPartyAccount = AllPartyAccount.ReturnAPA2data(pAllPartyAccount)
        LstDetMethod.SelectedValue = pAllPartyAccount.DetMethod
        TextHandOverDate.Text = pAllPartyAccount.LineHandoverDate
        btnSave.Visible = True
        btnSave.Enabled = True
    End Sub
    Protected Sub btnSearchGr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchGr.Click
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.ContNo = TextGrno.Text
        LoadTreeViewData(pFleetContJoDtls)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strConnectionString, CMD51, cmd10 As String
        Dim con As OleDbConnection
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            CMD51 = " UPDATE ALL_PARTY_ACCOUNT SET  DET_METHOD=" & LstDetMethod.SelectedValue & " WHERE GR_ID=" & hdngrId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd55 As New OleDbCommand(CMD51, con)
            cmd55.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, ex.Message)
        End Try
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd10 = " UPDATE FLEET_CONT_JO_DTLS SET SEAL_NO='" & textLineSealNo.Text.Trim & "' WHERE MTY_CONT_ID=" & hdnMtyContId.Value & ""
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd11 As New OleDbCommand(cmd10, con)
            cmd11.ExecuteNonQuery()
        Catch ex As Exception
        End Try
       lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        ButtonControlSetup(True)
        manageUserControls(True)
        btnSave.Visible = True
        btnSave.Enabled = True
        'tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class