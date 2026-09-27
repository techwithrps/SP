Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Data.OleDb

Partial Class FLeet_FleetLocationMaster
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 0
    Dim arrLocationRefId As ArrayList
    Dim arrLocationName As ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            fillRepeator(New ArrayList)
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnEdit)
        End If
    End Sub

    

    Sub ListControlDataBind()
        Dim pTerminalMaster As New TerminalMaster
        lstTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstTerminal.DataTextField = "TerminalName"
        lstTerminal.DataValueField = "TerminalId"
        lstTerminal.DataBind()
    End Sub

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

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
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


        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub


    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageRepeatorControl(True)
        Functions.ControlFocus(lstTerminal)
    End Sub

    Sub manageRepeatorControl(ByVal PEnable As Boolean)
        For Each rep As RepeaterItem In repLocation.Items
            If CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value > 0 Then
                CType(rep.FindControl("textAdvance"), TextBox).Enabled = True
                CType(rep.FindControl("textOilAdvance"), TextBox).Enabled = True
                CType(rep.FindControl("textALAdvance"), TextBox).Enabled = True

            Else
                CType(rep.FindControl("textALAdvance"), TextBox).Enabled = False
                CType(rep.FindControl("textAdvance"), TextBox).Enabled = False
                CType(rep.FindControl("textOilAdvance"), TextBox).Enabled = False

            End If
        Next
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
        Functions.ControlFocus(btnEdit)
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
        If repLocation.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textLocation, textLocation1, textDistance, textToll As TextBox

            For Each rep1 In repLocation.Items
                textLocation = rep1.FindControl("textLocation")
                textDistance = rep1.FindControl("textDistance")
                textToll = rep1.FindControl("textToll")
                If textLocation.Text <> Nothing Then
                    If textDistance.Text.Trim = Nothing Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblDistance.Text & "is Blank.")
                        rtnBool = False
                        Functions.ControlFocus(textLocation)
                        Return rtnBool
                        Exit Function
                    End If
                End If

                For Each rep2 In repLocation.Items
                    textLocation1 = rep2.FindControl("textLocation")
                    If textLocation1.Text <> "" Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            'If textLocation.Text = textLocation1.Text Then
                            '   Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Duplicate location.")
                            '   rtnBool = False
                            '   Functions.ControlFocus(textLocation1)
                            '  Return rtnBool
                            '   Exit Function
                            'End If
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
        fillRepeator(LocationMaster.ReturnLocationMasterList(pLocationMaster))
        hdnTerminalID.Value = pLocationMaster.LocationRefId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnEdit)

    End Sub

    Private Function ReturnObject() As LocationMaster
        Dim pLocationMaster As New LocationMaster
        If lstTerminal.SelectedValue >= 0 Then '
            pLocationMaster.TerminalId = lstTerminal.SelectedValue
        End If

        pLocationMaster.LocationList = New ArrayList

        For Each rep As RepeaterItem In repLocation.Items
            If CType(rep.FindControl("textLocation"), TextBox).Text <> "" Then
                Dim x As New LocationMaster
                x.TerminalId = lstTerminal.SelectedValue
                Try
                    x.LocationRefId = CType(rep.FindControl("hdnLocationRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    x.LocationName = CType(rep.FindControl("textLocation"), TextBox).Text
                Catch ex As Exception
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
                pLocationMaster.LocationList.Add(x)
            End If
        Next
        Return pLocationMaster
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pLocationMaster As New LocationMaster
        pLocationMaster.TerminalId = pCodevalue.Value
        hdnTerminalID.Value = pLocationMaster.TerminalId
        lstTerminal.SelectedValue = pLocationMaster.TerminalId
        Dim arr As New ArrayList
        arr = LocationMaster.ReturnLocationMasterListlocation(pLocationMaster)
        fillRepeator(arr)
    End Sub
    Sub LocationDtls()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT LOCATION_NAME,DISTANCE,TOLL,ADVANCE_RS  TWENTY_EICHER ,OIL_ADVANCE  TWENTY_AL ,AL_ADVANCE  FORTY_AL  FROM LOCATION_MASTER WHERE TERMINAL_ID='" & lstTerminal.SelectedValue & "'"

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("DTLS")
            ada.Fill(ds)
            gvLocationDtls.DataSource = ds.Tables(0)
            gvLocationDtls.DataBind()
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

        Response.AddHeader("content-disposition", "attachment;filename=LocationMaster.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvLocationDtls.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub

End Class


