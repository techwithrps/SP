Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Partial Class Master_Admin_StateMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnSave.Attributes.Add("onclick", "this.disabled=true;" + ClientScript.GetPostBackEventReference(btnSave, "").ToString())
        If Not IsPostBack Then
            manageUserControls(True)
            LoadTreeViewData()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(textStateCode)
        End If
    End Sub

    ''' <summary>
    ''' Fill the TreeView With Display Values and Display Text
    ''' </summary>
    ''' <remarks>Code is Value and Name is Text</remarks>
    Sub LoadTreeViewData()
        Dim pStateCodeMaster As New StateCodeMaster
        Try
            For Each obj As StateCodeMaster In StateCodeMaster.ReturnStateList(pStateCodeMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.StateId, obj.StateName)
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
        If hdnStateID.Value.Trim <> Nothing Then
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

        End If
        If Session.Item("Search") <> "Y" Then
            'btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    ''' <summary>
    ''' Validate the Manadatory Fields With Values
    ''' </summary>
    ''' <returns>Return False When Validation Condition Fails</returns>
    ''' <remarks></remarks>
    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True
        If textStateCode.Text.Trim = Nothing Then
            Functions.setErrorMessage_img(lblErrorMessage, lblStateCode.Text & " should not Blank.")
            rtnBool = False
            Exit Function
        End If
        If textStateName.Text.Trim = Nothing Then
            Functions.setErrorMessage_img(lblErrorMessage, lblStateName.Text & " should not Blank.")
            rtnBool = False
            Exit Function
        End If

        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pStateCodeMaster As StateCodeMaster = returnObjectWithValues()
        If hdnStateID.Value.Trim <> Nothing Then
            StateCodeMaster.Update(pStateCodeMaster)
        Else
            StateCodeMaster.Insert(pStateCodeMaster)
        End If
        If pStateCodeMaster.Errormsg <> Nothing Then
            Functions.setErrorMessage_img(lblErrorMessage, pStateCodeMaster.Errormsg)
            Return
        End If
        Functions.addOrModifyLeaf(tvTreeView, pStateCodeMaster.StateName, pStateCodeMaster.StateId, hdnStateID.Value)
        hdnStateID.Value = pStateCodeMaster.StateId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.setErrorMessage_img(lblErrorMessage, "")
    End Sub

    ''' <summary>
    ''' Return The Division Master Object With Values assigned by user Controls
    ''' </summary>
    ''' <returns>Return The Division Master Object With Values assigned by user Controls</returns>
    ''' <remarks></remarks>
    Private Function returnObjectWithValues() As StateCodeMaster
        Dim pStateCodeMaster As New StateCodeMaster
        If hdnStateID.Value.Trim <> Nothing Then
            pStateCodeMaster.StateId = hdnStateID.Value
        End If
        pStateCodeMaster.StateCode = textStateCode.Text.Trim.Replace("'", "''")
        pStateCodeMaster.StateName = textStateName.Text.Trim.Replace("'", "''")
        pStateCodeMaster.GSTN = textGSTIN.Text.Trim.Replace("'", "''")
        pStateCodeMaster.StateAddress = textStateAddress.Text.Trim.Replace("'", "''")
        pStateCodeMaster.CreatedBy = Session.Item("LoginUser")
        Return pStateCodeMaster
    End Function

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ButtonControlSetup(False)
        manageUserControls(False)
        Functions.clearControls(Me.dvControl.Controls)
        tvTreeView.Enabled = False
        Functions.ControlFocus(textStateCode)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.Controls)
        Functions.setErrorMessage_img(lblErrorMessage, "")
        manageUserControls(True)
        'selectFirstNode()
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setErrorMessage_img(lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        Functions.ControlFocus(textStateCode)
        'textServiceID.Enabled = False
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    ''' <summary>
    ''' Add the Select Node in to ViewState to Return on Same Node 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ''Save Selected Path in viewstate
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            ''Expand all noed of treeview
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

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

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pStateCodeMaster As New StateCodeMaster
        pStateCodeMaster.StateId = pCodevalue.Value
        StateCodeMaster.ReturnStateById(pStateCodeMaster)
        hdnStateID.Value = pStateCodeMaster.StateId
        textStateCode.Text = pStateCodeMaster.StateCode
        textStateName.Text = pStateCodeMaster.StateName
        textStateAddress.Text = pStateCodeMaster.StateAddress
        textGSTIN.Text = pStateCodeMaster.GSTN
    End Sub

    Private Sub ListItemDataBind()
        'lstCity.DataSource = LocalPorts.GetLocalPortsAll(Session.Item("loginLocation"))
        'lstCity.DataTextField = "CITY_CODE"
        'lstCity.DataValueField = "CITY_NAME"
        'lstCity.DataBind()
        'lstCity.Items.Insert(0, New ListItem("----Select Port----", 0))
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
