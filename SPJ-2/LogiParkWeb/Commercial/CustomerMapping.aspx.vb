Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Public Class Commercial_CustomerMapping
    Inherits System.Web.UI.Page
    Dim rows As Integer = 3
    Public glBillingParty As New ArrayList
    Public glShippingLine As New ArrayList
    Public glServiceGroup As New ArrayList
    Public glTallyCustomer As New ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        prepareBillingPartyData()
        prepareShippingLineData()
        prepareTallyCustomerData()
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            lblScreenTitle.Text = Session.Item("Title")
            tvTreeView.Enabled = True
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
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            'Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count <= rows Then
            For i As Integer = 0 To rows - (arr.Count + 1)
                Dim p As New CustomerMaster
                ' p.TaxHeadId = "0"
                arr.Add(p)
            Next
        End If
        repTaxHead.DataSource = arr
        repTaxHead.DataBind()
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub


    Protected Overrides Function SaveViewState() As Object
        If Not tvTreeView.SelectedNode Is Nothing Then
            ViewState.Item("SelectedNodePath") = tvTreeView.SelectedNode.ValuePath
            tvTreeView.ExpandAll()
        End If
        Return MyBase.SaveViewState
    End Function

    Protected Sub prepareBillingPartyData()
        Dim p As New CustomerMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glBillingParty = CustomerMaster.ReturnCustomerMasterListConsignee(p)
    End Sub

    Protected Sub prepareBillingParty(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each bp As CustomerMaster In glBillingParty
                lst.Items.Add(New ListItem(bp.CustomerName, bp.CustomerId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareShippingLineData()
        Dim p As New CustomerMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glShippingLine = CustomerMaster.ReturnCustomerMasterListAllLine(p)
    End Sub

    Protected Sub prepareShippingLine(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each sl As CustomerMaster In glShippingLine
                lst.Items.Add(New ListItem(sl.CustomerName, sl.CustomerId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub prepareTallyCustomerData()
        Dim p As New CustomerMaster
        p.TerminalId = Session.Item("LoginTerminal")
        glTallyCustomer = CustomerMaster.ReturnCustomerMasterListConsignee(p)
    End Sub

    Protected Sub prepareTallyCustomer(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For Each sl As CustomerMaster In glTallyCustomer
                lst.Items.Add(New ListItem(sl.CustomerName, sl.CustomerId))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        If Not ViewState.Item("SelectedNodePath") Is Nothing Then
            Dim node As TreeNode = tvTreeView.FindNode(ViewState.Item("SelectedNodePath"))
            If Not node Is Nothing Then
                node.Select()
            End If
        End If
    End Sub

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        'If textTaxGroupCode.Text.Trim <> Nothing Then
        '    btnEdit.Visible = True
        'Else
        '    btnEdit.Visible = False
        'End If
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
        fillRepeator(New ArrayList)
        ButtonControlSetup(False)
        manageUserControls(False)
        tvTreeView.Enabled = False
        'Functions.ControlFocus(textTaxGroupCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
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
      
        Dim isTaxHead As Integer = 0
        If repTaxHead.Items.Count > 0 Then
            Dim rep1, rep2 As RepeaterItem
            Dim lstTaxHead, lstTaxHead1 As DropDownList

            For Each rep1 In repTaxHead.Items
                lstTaxHead = rep1.FindControl("lstTaxHead")

                For Each rep2 In repTaxHead.Items
                    lstTaxHead1 = rep2.FindControl("lstTaxHead")
                    If lstTaxHead1.SelectedValue <> "0" Then
                        If rep1.ItemIndex <> rep2.ItemIndex Then
                            isTaxHead += 1
                            If lstTaxHead.SelectedValue = lstTaxHead1.SelectedValue Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Tax Head is Duplicate.")
                                rtnBool = False
                                Functions.ControlFocus(lstTaxHead)
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

        'If ValidationCheck() = False Then
        '    Return
        'End If
        Dim pExtTaxGroup As CustomerMapping = ReturnObject()


        If pExtTaxGroup.CustomerMappingList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, " Select Tax Head.")
            repTaxHead.Items(0).Focus()
            Exit Sub
        End If

        CustomerMapping.InsertUpdateTransaction(pExtTaxGroup)

        If pExtTaxGroup.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtTaxGroup.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        '  Functions.addOrModifyLeaf(tvTreeView, pExtTaxGroup.TaxGroupCode, pExtTaxGroup.TaxGroupId, hdnTaxGroupID.Value)
        'hdnTaxGroupID.Value = pExtTaxGroup.TaxGroupId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As CustomerMapping
        Dim p As New CustomerMapping
        p.CustomerMappingList = New ArrayList
        For Each rep As RepeaterItem In repTaxHead.Items
            If CType(rep.FindControl("lstTaxHead"), DropDownList).SelectedValue <> "0" Then
                Dim pdet As New CustomerMapping
                pdet.CustomerId = CType(rep.FindControl("lstTaxHead"), DropDownList).SelectedValue
                pdet.LineId = CType(rep.FindControl("ddlShippingLine"), DropDownList).SelectedValue
                pdet.ServiceTypeCode = CType(rep.FindControl("ddlServiceGroup"), DropDownList).SelectedValue
                pdet.TallyCustomerId = CType(rep.FindControl("ddlTallyCustomer"), DropDownList).SelectedValue
                pdet.CreatedBy = Session.Item("LoginUser")
                p.CustomerMappingList.Add(pdet)
            End If
        Next

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New ExtTaxGroup
        p.TerminalId = Session.Item("LoginTerminal")
        p.TaxGroupId = pCodevalue.Value
        ExtTaxGroup.ReturnTaxGroupWithTaxGroupHeadDetailsByTaxGroupId(p)
        'hdnTaxGroupID.Value = p.TaxGroupId
        'textTaxGroupCode.Text = p.TaxGroupCode
        'textFromDate.Text = p.FromDate
        'textToDate.Text = p.ToDate
        fillRepeator(p.TaxGroupHeadList)
    End Sub
End Class