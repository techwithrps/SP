Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Sales_CallLogEntry
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            ListControlDataBind()
            fillRepeator(New ArrayList)
            manageUserControls(True)
            LoadTreeViewData()
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(btnEdit)
            manageRepetorControl(False)
        End If
    End Sub

    

    Sub LoadTreeViewData()
        Dim pJM As New CustomerProfile
        pJM.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As CustomerProfile In CustomerProfile.ReturnCustomerProfileList(pJM)
                If obj.CallStatus = "" Then
                    Functions.treeViewNodeSetup(tvCallLog, "0", obj.ProfileId, obj.CustomerName)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub selectFirstNode()
        If tvCallLog.Nodes.Count > 0 Then
            tvCallLog.Nodes(0).Selected = True
            prepareControls(tvCallLog.Nodes(0))
        End If
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New CustomerCallLog
                arr.Add(p)
            Next
        Else
            Dim p As New CustomerCallLog
            arr.Add(p)
        End If
        repCallLog.DataSource = arr
        repCallLog.DataBind()
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
        btnExit.Visible = pVisible
        If hdnProfileId.Value.Trim <> Nothing AndAlso hdnProfileId.Value <> "0" Then
            btnEdit.Visible = True
        Else
            btnEdit.Visible = False
        End If
        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        If Session.Item("Add") <> "Y" Then
            'btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then
            btnEdit.Visible = False
        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub ListControlDataBind()

    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If hdnProfileId.Value.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Role Name")
            rtnBool = False
            'Functions.ControlFocus(textRole)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtCustomerProfile As ExtCustomerProfile = ReturnObject()

        If pExtCustomerProfile.CustomerCallLogList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Call Log details.")
            manageRepetorControl(True)
            Return
            Exit Sub
        End If
        ExtCustomerProfile.InsertUpdateCustomerCallLog(pExtCustomerProfile)
        If pExtCustomerProfile.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtCustomerProfile.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Updated Successfully.")
        Dim x As New ExtCustomerProfile
        x.ProfileId = hdnProfileId.Value
        x.TerminalId = Session.Item("LoginTerminal")
        ExtCustomerProfile.RetrunCustomerProfileCallLogDeatilsByProfileId(x)
        fillRepeator(x.CustomerCallLogList)
        tvCallLog.Nodes.Clear()
        LoadTreeViewData()
        ButtonControlSetup(True)
        manageUserControls(True)
        tvCallLog.Enabled = True
    End Sub

    Function ReturnObject() As ExtCustomerProfile
        Dim p As New ExtCustomerProfile
        If hdnProfileId.Value <> Nothing Then
            p.ProfileId = hdnProfileId.Value
        End If
        p.TerminalId = Session.Item("LoginTerminal")
        p.CustomerName = textCustomerName.Text
        If chkCallStatus.Checked Then
            p.CallStatus = "Y"
        Else
            p.CallStatus = ""
        End If

        p.CustomerCallLogList = New ArrayList
        For Each rep As RepeaterItem In repCallLog.Items
            If (CType(rep.FindControl("hdnCallLogId"), HiddenField).Value <> Nothing Or CType(rep.FindControl("hdnCallLogId"), HiddenField).Value = "0") _
           And CType(rep.FindControl("textCallDate"), TextBox).Text.Trim <> Nothing And CType(rep.FindControl("textCallDetails"), TextBox).Text.Trim <> Nothing _
            And CType(rep.FindControl("textContactPerson"), TextBox).Text.Trim <> Nothing Then

                If CType(rep.FindControl("textCallDate"), TextBox).Enabled = True Then
                    If CType(rep.FindControl("lstApproachMethod"), DropDownList).SelectedValue = "" Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Select Approach Method.")
                        Exit For
                    End If

                    Dim x As New CustomerCallLog
                    Try
                        x.CallLogId = CType(rep.FindControl("hdnCallLogId"), HiddenField).Value
                    Catch ex As Exception
                    End Try
                    Try
                        x.CustomerId = hdnProfileId.Value
                    Catch ex As Exception
                    End Try
                    Try
                        x.CallDate = CType(rep.FindControl("textCallDate"), TextBox).Text
                    Catch ex As Exception
                    End Try
                    Try
                        x.ContactPerson = CType(rep.FindControl("textContactPerson"), TextBox).Text
                    Catch ex As Exception
                    End Try
                    Try
                        x.ApproachMethod = CType(rep.FindControl("lstApproachMethod"), DropDownList).SelectedValue
                    Catch ex As Exception
                    End Try
                    Try
                        x.CallDetails = CType(rep.FindControl("textCallDetails"), TextBox).Text
                    Catch ex As Exception
                    End Try
                    x.CreatedBy = Session.Item("LoginUser")
                    x.TerminalId = Session.Item("LoginTerminal")
                    p.CustomerCallLogList.Add(x)
                End If
            End If
        Next
        Return p
    End Function

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Sub manageRepetorControl(ByRef pEnable As Boolean)
        Dim temp As TextBox = Nothing
        Dim lngCount As Integer = 0
        For Each rep As RepeaterItem In repCallLog.Items
            If CType(rep.FindControl("hdnCallLogId"), HiddenField).Value > 0 Then
                CType(rep.FindControl("textCallDate"), TextBox).Enabled = False
                CType(rep.FindControl("textContactPerson"), TextBox).Enabled = False
                CType(rep.FindControl("lstApproachMethod"), DropDownList).Enabled = False
                CType(rep.FindControl("textCallDetails"), TextBox).Enabled = False
            Else
                CType(rep.FindControl("textCallDate"), TextBox).Enabled = pEnable
                If lngCount = 0 Then
                    temp = CType(rep.FindControl("textCallDate"), TextBox)
                    lngCount += 1
                End If

                CType(rep.FindControl("textContactPerson"), TextBox).Enabled = pEnable
                CType(rep.FindControl("lstApproachMethod"), DropDownList).Enabled = pEnable
                CType(rep.FindControl("textCallDetails"), TextBox).Enabled = pEnable
            End If
        Next
        Try
            Functions.ControlFocus(temp)
        Catch ex As Exception

        End Try

    End Sub

    Sub prepareControls(ByVal PCode As TreeNode)
        Dim p As New ExtCustomerProfile
        p.ProfileId = PCode.Value
        p.TerminalId = Session.Item("LoginTerminal")
        ExtCustomerProfile.RetrunCustomerProfileCallLogDeatilsByProfileId(p)
        hdnProfileId.Value = p.ProfileId
        textCustomerName.Text = p.CustomerName
        fillRepeator(p.CustomerCallLogList)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        If Not tvCallLog.SelectedNode Is Nothing Then
            prepareControls(tvCallLog.SelectedNode)
        End If
        manageRepetorControl(False)
        tvCallLog.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(False)
        chkCallStatus.Enabled = True
        manageRepetorControl(True)
        tvCallLog.Enabled = False
        btnEdit.Visible = False
    End Sub

    Protected Sub tvService_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvCallLog.SelectedNodeChanged
        prepareControls(tvCallLog.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnEdit)
    End Sub

    Protected Overrides Function SaveViewState() As Object
        If Not tvCallLog.SelectedNode Is Nothing Then
            ''Save Selected Path in viewstate
            ViewState.Item("SelectedNodePath") = tvCallLog.SelectedNode.ValuePath
            ''Expand all noed of treeview
            tvCallLog.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvCallLog.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub
End Class
