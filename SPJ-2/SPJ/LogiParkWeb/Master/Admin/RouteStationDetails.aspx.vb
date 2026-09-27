Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_RouteStationDetails
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 5
    Dim arr As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            ListControlDataBind()
            fillRepeator(New ArrayList)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
        End If
    End Sub

    

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New RouteStation

                arr.Add(p)
            Next
        End If
        repStationMaster.DataSource = arr
        repStationMaster.DataBind()
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub
    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pRouteMaster As New RouteMaster
        Try
            For Each obj As RouteMaster In RouteMaster.ReturnRouteMasterListRouteName(pRouteMaster)
                'arr.Add(obj.RouteId)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.RouteId, obj.RouteName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub
    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvMain.Controls)
    End Sub
    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)

        btnAdd.Visible = pVisible

        btnExit.Visible = pVisible
        btnEdit.Visible = True
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible

        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()
        Dim pRouteMaster As New RouteMaster
        lstRouteName.DataSource = RouteMaster.ReturnRouteMasterList(pRouteMaster)
        lstRouteName.DataTextField = "RouteName"
        lstRouteName.DataValueField = "RouteId"
        lstRouteName.DataBind()
        lstRouteName.Items.Add(New ListItem("--Select--", "0"))
        lstRouteName.SelectedValue = 0
    End Sub


    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If lstRouteName.SelectedValue = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Route Name")
            rtnBool = False
            Functions.ControlFocus(lstRouteName)
            Return rtnBool
            Exit Function
        End If
        If textOrigin.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Origin")
            rtnBool = False
            Functions.ControlFocus(textOrigin)
            Return rtnBool
            Exit Function
        End If
        If textDestination.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Destination")
            rtnBool = False
            Functions.ControlFocus(textOrigin)
            Return rtnBool
            Exit Function
        End If
        If repStationMaster.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim textStation, textStation1, textDistance As TextBox
            For Each rep1 In repStationMaster.Items
                textStation = rep1.FindControl("textStationCode")
                textDistance = rep1.FindControl("textDistance")
                If textStation.Text.Trim <> Nothing AndAlso textStation.Text.Trim <> "" Then
                    If textDistance.Text = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Distance.")
                        rtnBool = False
                        Functions.ControlFocus(textStation)
                    End If
                End If
                For Each rep2 In repStationMaster.Items
                    textStation1 = rep2.FindControl("textStationCode")
                    If textStation1.Text.Trim <> Nothing Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            If textStation.Text.Trim = textStation1.Text.Trim Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Duplicate Station Code.")
                                rtnBool = False
                                Functions.ControlFocus(textStation1)
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
        Dim pRouteStation As RouteStation = ReturnObject()

        If pRouteStation.RouteDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Station Details.")
            Return
            Exit Sub
        End If
        RouteStation.InsertUpdateDetails(pRouteStation)

        If pRouteStation.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRouteStation.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        'Dim i As Integer = 0
        'For Each pas As RouteMaster In arr
        '    If pas.RouteId <> lstRouteName.SelectedValue Then             
        '        i += 1
        '    End If
        'Next

        'If i > 0 Then
        Dim pRouteMaster As New RouteMaster
        pRouteMaster.RouteId = lstRouteName.SelectedValue
        RouteMaster.ReturnRouteMaster(pRouteMaster)
        hdnRouteRefID.Value = pRouteMaster.RouteId
        tvTreeView.Nodes.Clear()
        'Functions.addOrModifyLeaf(tvTreeView, pRouteMaster.RouteName, pRouteMaster.RouteId, hdnRouteRefID.Value)
        'End If
        LoadTreeViewData()
        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub
    Function ReturnObject() As RouteStation
        Dim pRouteStation As New RouteStation
        Dim pRouteDetails As New RouteStation

        pRouteStation.RouteDetailsList = New ArrayList
        For Each rep As RepeaterItem In repStationMaster.Items
            If CType(rep.FindControl("textStationCode"), TextBox).Text <> Nothing AndAlso CType(rep.FindControl("textStationCode"), TextBox).Text <> "" Then
                pRouteDetails.RouteId = lstRouteName.SelectedValue
                pRouteDetails.Origin = hdnOrigin.Value
                pRouteDetails.Destination = hdnDestination.Value
                Try
                    pRouteDetails.StationRefId = CType(rep.FindControl("hdnStationRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                Try
                    pRouteDetails.StationCode = CType(rep.FindControl("textStationCode"), TextBox).Text
                Catch ex As Exception
                End Try
                Try
                    pRouteDetails.DistanceOrigin = CType(rep.FindControl("textDistance"), TextBox).Text
                Catch ex As Exception
                End Try
                pRouteStation.RouteDetailsList.Add(pRouteDetails)
            End If
        Next


        Return pRouteStation
    End Function
    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Sub prepareControls(ByVal PCode As TreeNode)
        Dim pRouteStation As New RouteStation
        pRouteStation.RouteId = PCode.Value
        RouteStation.ReturnRouteStation(pRouteStation)
        hdnRouteRefID.Value = pRouteStation.RouteId
        lstRouteName.SelectedValue = pRouteStation.RouteId
        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pRouteStation.Origin
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        textOrigin.Text = pTerminal.TerminalCode
        hdnOrigin.Value = pRouteStation.Origin
        hdnDestination.Value = pRouteStation.Destination
        pTerminal.TerminalId = pRouteStation.Destination
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        textDestination.Text = pTerminal.TerminalCode
        Dim arr As New ArrayList
        arr = RouteStation.ReturnRouteStationList(pRouteStation)
        If arr.Count >= ROWS Then
            ROWS = arr.Count + 2
        End If
        fillRepeator(arr)
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvMain.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        btnEdit.Visible = False
        textOrigin.Enabled = False
        textDestination.Enabled = False
        lstRouteName.Enabled = False
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvMain.Controls)
        ButtonControlSetup(False)
        btnEdit.Visible = False
        hdnMode.Value = "A"
    End Sub
    Protected Sub lstRouteName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstRouteName.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If lstRouteName.SelectedValue = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Route Name")
            Functions.ControlFocus(lstRouteName)
        End If
        Dim pRouteMaster As New RouteMaster
        pRouteMaster.RouteId = lstRouteName.SelectedValue
        hdnRouteRefID.Value = lstRouteName.SelectedValue
        RouteMaster.ReturnRouteMaster(pRouteMaster)

        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pRouteMaster.FromTerminalId
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        textOrigin.Text = pTerminal.TerminalCode
        hdnOrigin.Value = pRouteMaster.FromTerminalId
        hdnDestination.Value = pRouteMaster.ToTerminalId
        pTerminal.TerminalId = pRouteMaster.ToTerminalId
        TerminalMaster.ReturnTerminalMaster(pTerminal)

        textDestination.Text = pTerminal.TerminalCode
    End Sub
    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ''Save Selected Path in viewstate
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            ''Expand all noed of treeview
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function
    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
        ButtonControlSetup(True)
    End Sub
End Class
