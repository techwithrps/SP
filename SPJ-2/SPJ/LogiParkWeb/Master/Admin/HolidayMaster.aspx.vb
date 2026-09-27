Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_HolidayMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
        End If
    End Sub

    

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub LoadTreeViewData()
        Dim pImpHolydayMaster As New ImpHolydayMaster
        pImpHolydayMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ImpHolydayMaster In ImpHolydayMaster.ReturnImpHolydayMasterList(pImpHolydayMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.HolydayId, obj.HolidayName)
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
        If textHolidayName.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textHolidayName)
    End Sub
    Sub manageControls(ByRef pEnable As Boolean)
        textHolidayName.Enabled = pEnable
        textNoOfDays.Enabled = False
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(True)
        Functions.ControlFocus(textHolidayName)
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
        If textHolidayName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblHolidayName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textHolidayName)
            Return rtnBool
            Exit Function
        End If
        If textHolidayFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblHolidayFromDate.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textHolidayFromDate)
            Return rtnBool
            Exit Function
        End If
        If textHolidayToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblHolidayToDate.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textHolidayToDate)
            Return rtnBool
            Exit Function
        End If
        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing
        Try
            dtFrom = Functions.todate_ddmmyyyy(textHolidayFromDate.Text, "/")
        Catch ex As Exception
        End Try
        Try
            dtTo = Functions.todate_ddmmyyyy(textHolidayToDate.Text, "/")
        Catch ex As Exception

        End Try
        If dtTo < dtFrom Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Holiday To Date should be gratter than Holiday From Date")
            rtnBool = False
            Functions.ControlFocus(textHolidayToDate)
            Return rtnBool
            Exit Function
        End If

        textNoOfDays.Text = DateAndTime.DateDiff(DateInterval.Day, dtFrom, dtTo) + 1

        'If dtTo < Today.Date Then
        '    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Holiday To Date should not be Less Than Today")
        '    rtnBool = False
        '    Functions.ControlFocus(textHolidayToDate)
        '    Exit Function
        'End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pImpHolydayMaster As ImpHolydayMaster = ReturnObject()
        If hdnHolidayId.Value <> Nothing Then
            ImpHolydayMaster.Update(pImpHolydayMaster)
        Else
            ImpHolydayMaster.Insert(pImpHolydayMaster)
        End If

        If pImpHolydayMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pImpHolydayMaster.Errormsg)
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pImpHolydayMaster.HolidayName, pImpHolydayMaster.HolydayId, hdnHolidayId.Value)
        hdnHolidayId.Value = pImpHolydayMaster.HolydayId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)

    End Sub
    Private Function ReturnObject() As ImpHolydayMaster
        Dim p As New ImpHolydayMaster
        If hdnHolidayId.Value <> "" AndAlso hdnHolidayId.Value > 0 Then
            p.HolydayId = hdnHolidayId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        'p.HolydayId = hdnHolidayId.Value
        p.HolidayName = textHolidayName.Text
        p.HolydayFromDate = textHolidayFromDate.Text
        p.HolydayToDate = textHolidayToDate.Text
        If chkIsChargable.Checked Then
            p.Chargable = "Y"
        Else
            p.Chargable = "N"
        End If
        Try
            p.NoOfDays = textNoOfDays.Text
        Catch ex As Exception

        End Try

        p.CreatedBy = Session.Item("LoginUser")
        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ImpHolydayMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.HolydayId = pCodevalue.Value
        ImpHolydayMaster.ReturnImpHolydayMaster(p)
        textHolidayName.Text = p.HolidayName
        textHolidayFromDate.Text = p.HolydayFromDate
        textHolidayToDate.Text = p.HolydayToDate
        textNoOfDays.Text = p.NoOfDays
        hdnHolidayId.Value = p.HolydayId
        If p.Chargable = "Y" Then
            chkIsChargable.Checked = True
        End If
    End Sub
End Class
