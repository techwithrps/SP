Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb
Imports System.IO

Partial Class Fleet_BedMaster
    Inherits System.Web.UI.Page
    Dim RowsTire As Integer = 15
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            'lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeView.Enabled = True

            fillRepeatorTire(New ArrayList)
            selectFirstNode()

            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
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
    Sub LoadTreeViewData()
        Dim pBedMaster As New FleetBedMaster
        ' pFleetEquipmentMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As FleetBedMaster In FleetBedMaster.ReturnFleetBedMasterList(pBedMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.BedNo, obj.BedNo)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fillRepeatorTire(ByVal arr As ArrayList)
        If arr.Count < RowsTire Then
            For i As Integer = 0 To RowsTire - arr.Count - 1
                Dim p As New FleetBedMaster
                arr.Add(p)
            Next
        End If
        repTireDtls.DataSource = arr
        repTireDtls.DataBind()
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
        If textBedNo.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textBedNo)

    End Sub
    Sub manageControls(ByRef pEnable As Boolean)
        textBedNo.Enabled = pEnable
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textBedNo)
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
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True
        If textBedNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBedNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textBedNo)
            Return rtnBool
            Exit Function
        End If


        If repTireDtls.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textTireSrNo, textInstallDate As TextBox
            Dim lstInstallLocation As DropDownList
            For Each rep1 In repTireDtls.Items
                textTireSrNo = rep1.FindControl("textTireNo")
                textInstallDate = rep1.FindControl("textInstallationDate")
                lstInstallLocation = rep1.FindControl("lstInstallationLoc")
                If textTireSrNo.Text.Trim <> Nothing Then
                    If textInstallDate.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Installation Date is Blank")
                        rtnBool = False
                        Functions.ControlFocus(textInstallDate)
                        Return rtnBool
                        Exit Function
                    End If
                    If lstInstallLocation.SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Installation Location")
                        rtnBool = False
                        Functions.ControlFocus(lstInstallLocation)
                        Return rtnBool
                        Exit Function
                    End If
                    Dim textTire2 As TextBox
                    For Each rep2 In repTireDtls.Items
                        textTire2 = rep2.FindControl("textTireNo")
                        If textTireSrNo.Text <> "" AndAlso textTire2.Text <> "" Then
                            If rep1.ItemIndex <> rep2.ItemIndex Then
                                If textTire2.Text = textTireSrNo.Text Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTireSrNo.Text & " is Duplicate.")
                                    rtnBool = False
                                    Functions.ControlFocus(textTireSrNo)
                                    Return rtnBool
                                    Exit Function
                                End If
                            End If
                        End If
                    Next

                End If
            Next
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pFleetBedMaster As FleetBedMaster = ReturnObject()
        If pFleetBedMaster.TireList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Tire Details.")
            Return
            Exit Sub
        End If
        FleetBedMaster.InsertUpdateBedDetails(pFleetBedMaster)

        If pFleetBedMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pFleetBedMaster.Errormsg)
            Functions.ControlFocus(textBedNo)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        'Dim strMsg As String = Nothing
        'strMsg = SendMail(pLocationMaster)
        'If strMsg <> Nothing Then
        '    'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, strMsg)
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        'End If
        ' fillRepeatorTire(FleetBedMaster.ReturnFleetBedMasterList(pFleetBedMaster))
        'hdnTerminalID.Value = pLocationMaster.LocationRefId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub
    Private Function ReturnObject() As FleetBedMaster
        Dim pBedMaster As New FleetBedMaster
        If textBedNo.Text >= 0 Then '
            pBedMaster.BedNo = textBedNo.Text
        End If

        pBedMaster.TireList = New ArrayList

        For Each rep As RepeaterItem In repTireDtls.Items
            If CType(rep.FindControl("textTireNo"), TextBox).Text <> "" Then
                Dim x As New FleetBedMaster
                'x.TerminalId = lstTerminal.SelectedValue
                x.BedNo = textBedNo.Text
                Try
                    x.BedRefId = CType(rep.FindControl("hdnBedRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    x.TireNo = CType(rep.FindControl("textTireNo"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.InstallationDate = CType(rep.FindControl("textInstallationDate"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    x.InstallLocation = CType(rep.FindControl("lstInstallationLoc"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                pBedMaster.TireList.Add(x)
            End If
        Next
        Return pBedMaster
    End Function
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pBedMaster As New FleetBedMaster
        pBedMaster.BedNo = pCodevalue.Value
        ' hdnTerminalID.Value = pLocationMaster.TerminalId
        textBedNo.Text = pBedMaster.BedNo
        Dim arr As New ArrayList
        arr = FleetBedMaster.ReturnFleetBedMasterListByBedNo(pBedMaster)

        fillRepeatorTire(arr)
    End Sub
    Sub LocationDtls()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT BED_NO,TIRE_NO,INSTALLATION_DATE,INSTALL_LOCATION FROM FLEET_BED_MASTER ORDER BY BED_NO ASC"

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("DTLS")
            ada.Fill(ds)
            gvBedDtls.DataSource = ds.Tables(0)
            gvBedDtls.DataBind()
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        LocationDtls()


        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=BedMaster.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvBedDtls.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub


End Class
