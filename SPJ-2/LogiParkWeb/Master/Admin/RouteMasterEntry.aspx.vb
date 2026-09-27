Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_RouteMasterEntry
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 2
    Dim arrRouteId As ArrayList
    Dim arrRouteName As ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareRouteData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            manageUserControls(True)
            ListControlDataBind()
            fillRepeator(New ArrayList)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(lstFromTerminal)
            manageRepetorControl(False)
        End If
    End Sub

    

    Sub manageRepetorControl(ByVal pEnable As Boolean)
        For Each rep As RepeaterItem In repSubRoute.Items
            If CType(rep.FindControl("hdnRouteId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnRouteId"), HiddenField).Value > 0 Then
                CType(rep.FindControl("lstSubRoute"), DropDownList).Enabled = False
            Else
                CType(rep.FindControl("lstSubRoute"), DropDownList).Enabled = pEnable
            End If
        Next
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New ExtSubRouteMaster
                arr.Add(p)
            Next
        End If
        repSubRoute.DataSource = arr
        repSubRoute.DataBind()
    End Sub

    Protected Sub prepareRoute(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrRouteId.Count
                lst.Items.Add(New ListItem(arrRouteName(i), arrRouteId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub prepareRouteData()
        Try
            arrRouteId = New ArrayList
            arrRouteName = New ArrayList
            Dim pRouteMaster As New RouteMaster

            For Each obj As RouteMaster In RouteMaster.ReturnRouteMasterList(pRouteMaster)
                arrRouteName.Add(obj.RouteName)
                arrRouteId.Add(obj.RouteId)
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Select The First Node Of The Tree View
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub selectFirstNode()
        If tvTreeView.Nodes.Count > 0 Then
            tvTreeView.Nodes(0).Selected = True
            prepareControls(tvTreeView.Nodes(0))
        End If
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pRouteMaster As New ExtRouteMaster
        pRouteMaster.RouteId = pCodevalue.Value
        ExtRouteMaster.ReturnRouteMasterWithSubRoutesById(pRouteMaster)
        If pRouteMaster.RouteId > 0 Then
            hdnRouteId.Value = pRouteMaster.RouteId
        End If
        lstFromTerminal.SelectedValue = pRouteMaster.FromTerminalId
        lstToTerminal.SelectedValue = pRouteMaster.ToTerminalId
        lstRouteType.SelectedValue = pRouteMaster.RouteTypeId
        textBillableDis.Text = pRouteMaster.BillableDistance
        textActualDis.Text = pRouteMaster.ActualDistance
        textRouteName.Text = pRouteMaster.RouteName
        textTrainPrefix.Text = pRouteMaster.TrainNoPrefx
        textBeginNo.Text = pRouteMaster.BeginNo
        textAverageTime.Text = pRouteMaster.AverageTime
        fillRepeator(pRouteMaster.ExtSubRouteList)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
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
            For Each obj As RouteMaster In RouteMaster.ReturnRouteMasterList(pRouteMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.RouteId, obj.RouteName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Set All Input Control Enable or Disable
    ''' </summary>
    ''' <param name="pEnable">When True then Enable When False Then Disable</param>
    ''' <remarks></remarks>
    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    ''' <summary>
    ''' Setup the Button Controls With the respective events with Visiblity.
    ''' </summary>
    ''' <param name="pVisible"> </param>
    ''' <remarks></remarks>
    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If hdnRouteId.Value.Trim <> Nothing Then
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
            ' btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()
        Dim pTerminalMaster As New TerminalMaster
        lstFromTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstFromTerminal.DataTextField = "TerminalCode"
        lstFromTerminal.DataValueField = "TerminalId"
        lstFromTerminal.DataBind()

        lstToTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
        lstToTerminal.DataTextField = "TerminalCode"
        lstToTerminal.DataValueField = "TerminalId"
        lstToTerminal.DataBind()

        Dim pRouteType As New RouteType
        lstRouteType.DataSource = RouteType.ReturnRouteTypeList(pRouteType)
        lstRouteType.DataTextField = "RouteTypeName"
        lstRouteType.DataValueField = "RouteTypeId"
        lstRouteType.DataBind()
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If lstFromTerminal.SelectedValue <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select From Terminal.")
            rtnBool = False
            Functions.ControlFocus(lstFromTerminal)
            Return rtnBool
            Exit Function
        End If
        If lstToTerminal.SelectedValue <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select To Terminal.")
            rtnBool = False
            Functions.ControlFocus(lstToTerminal)
            Return rtnBool
            Exit Function
        End If
        If lstFromTerminal.SelectedValue = lstToTerminal.SelectedValue Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "From Terminal and To Terminal should not be same.")
            rtnBool = False
            Functions.ControlFocus(lstToTerminal)
            Return rtnBool
            Exit Function
        End If
        If textRouteName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblRouteName.Text & " is blank.")
            rtnBool = False
            Functions.ControlFocus(textRouteName)
            Return rtnBool
            Exit Function
        End If
        If textBillableDis.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblBillableDis.Text & " is blank.")
            rtnBool = False
            Functions.ControlFocus(textBillableDis)
            Return rtnBool
            Exit Function
        End If
        If textActualDis.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblActualDis.Text & " is blank.")
            rtnBool = False
            Functions.ControlFocus(textActualDis)
            Return rtnBool
            Exit Function
        End If
        If textTrainPrefix.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTrainPrefix.Text & " is blank.")
            rtnBool = False
            Functions.ControlFocus(textTrainPrefix)
            Return rtnBool
            Exit Function
        End If
        If textBeginNo.Text = "" Then
            textBeginNo.Text = 0
        End If
        If textAverageTime.Text = "" Then
            textAverageTime.Text = 0
        End If
        If repSubRoute.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim lstTerminalId, lstTerminalId1 As DropDownList

            For Each rep1 In repSubRoute.Items
                lstTerminalId = CType(rep1.FindControl("lstSubRoute"), DropDownList)
                If lstTerminalId.SelectedValue > 0 Then
                    If lstTerminalId.SelectedValue = lstFromTerminal.SelectedValue Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " List terminal should not be same as From Terminal.")
                        rtnBool = False
                        Functions.ControlFocus(lstTerminalId)
                        Return rtnBool
                        Exit Function
                    End If
                    If lstTerminalId.SelectedValue = lstToTerminal.SelectedValue Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " List terminal should not be same as To Terminal.")
                        rtnBool = False
                        Functions.ControlFocus(lstTerminalId)
                        Return rtnBool
                        Exit Function
                    End If
                    For Each rep2 In repSubRoute.Items
                        lstTerminalId1 = CType(rep2.FindControl("lstSubRoute"), DropDownList)
                        If lstTerminalId1.SelectedValue <> "0" Then
                            If rep1.ItemIndex <> rep2.ItemIndex Then
                                If lstTerminalId.SelectedValue = lstTerminalId1.SelectedValue Then
                                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " Duplicate row in list")
                                    rtnBool = False
                                    Functions.ControlFocus(lstTerminalId)
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
        Dim pRouteMaster As ExtRouteMaster = ReturnObject()
        ExtRouteMaster.InsertDetails(pRouteMaster)
        If pRouteMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pRouteMaster.Errormsg)
            Return
        End If

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")

        Dim strMsg As String = Nothing
        strMsg = SendMail(pRouteMaster)
        If strMsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
        End If

        hdnRouteId.Value = pRouteMaster.RouteId

        Dim pExtRouteMaster As New ExtRouteMaster
        pExtRouteMaster.RouteId = hdnRouteId.Value
        ExtRouteMaster.ReturnRouteMasterWithSubRoutesById(pRouteMaster)
        fillRepeator(pRouteMaster.ExtSubRouteList)

        Functions.addOrModifyLeaf(tvTreeView, pRouteMaster.RouteName, pRouteMaster.RouteId, hdnRouteId.Value)
        ButtonControlSetup(True)
        manageUserControls(True)
        manageRepetorControl(False)
        tvTreeView.Enabled = True
        tvTreeView.Nodes.Clear()
        LoadTreeViewData()
    End Sub

    Function SendMail(ByVal pRouteMaster As RouteMaster) As String
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = Session.Item("MenuId")
        xMailSetup.TerminalId = 0
        MailSetup.ReturnMailSetup(xMailSetup)

        xMailSetup.MailBody &= "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"

        xMailSetup.MailBody &= "Origin Terminal :- " & lstFromTerminal.SelectedItem.Text & "<br/>"
        xMailSetup.MailBody &= "Destination Terminal :- " & lstToTerminal.SelectedItem.Text & "<br/>"
        xMailSetup.MailBody &= "Route Name :- " & textRouteName.Text & "<br/>"
        xMailSetup.MailBody &= "Train No Prefix :- " & textTrainPrefix.Text & "<br/>"
        xMailSetup.MailBody &= "Actual Distance :- " & textActualDis.Text & "<br/>"
        'xMailSetup.MailBody &= "Subroute Name :- " & CType(repSubRoute.FindControl("lstSubRoute"), DropDownList).SelectedItem.Text & "<br/>"

        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"


        xMailSetup.MailBody &= " Thanks & Regards " & "<br/>"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"


        pStr = Functions.sendMailToCcBccWithAttachment(pMailConfig.FromId, pMailConfig.FromId, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)

        Return pStr
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvControl.Controls)
        tvTreeView.Enabled = False
        Functions.ControlFocus(lstFromTerminal)
    End Sub

    Private Function ReturnObject() As ExtRouteMaster
        Dim pRouteMaster As New ExtRouteMaster
        If hdnRouteId.Value.Trim <> Nothing Then
            pRouteMaster.RouteId = hdnRouteId.Value
        End If
        pRouteMaster.FromTerminalId = lstFromTerminal.SelectedValue
        pRouteMaster.ToTerminalId = lstToTerminal.SelectedValue
        pRouteMaster.RouteTypeId = lstRouteType.SelectedValue
        pRouteMaster.BillableDistance = textBillableDis.Text
        pRouteMaster.ActualDistance = textActualDis.Text
        pRouteMaster.RouteName = textRouteName.Text
        pRouteMaster.TrainNoPrefx = textTrainPrefix.Text
        pRouteMaster.BeginNo = textBeginNo.Text
        pRouteMaster.AverageTime = textAverageTime.Text

        pRouteMaster.ExtSubRouteList = New ArrayList
        For Each rep As RepeaterItem In repSubRoute.Items
            If CType(rep.FindControl("lstSubRoute"), DropDownList).SelectedValue > 0 Then
                Dim pSubRoute As New ExtSubRouteMaster
                Try
                    pSubRoute.SubRouteId = CType(rep.FindControl("lstSubRoute"), DropDownList).SelectedValue
                Catch ex As Exception
                End Try
                Try
                    pSubRoute.RouteId = CType(rep.FindControl("hdnRouteId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pRouteMaster.ExtSubRouteList.Add(pSubRoute)
            End If
        Next

        Return pRouteMaster
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        'selectFirstNode()
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        manageRepetorControl(True)
        tvTreeView.Enabled = False
        Functions.ControlFocus(lstFromTerminal)
        textBeginNo.Enabled = False
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub
End Class
