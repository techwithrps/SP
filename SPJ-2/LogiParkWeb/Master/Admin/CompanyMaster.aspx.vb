Imports LogiParkLib.LogiParkObjects
Imports System.IO
Imports System.Data
Imports System.Xml

Partial Class Master_Admin_CompanyMaster
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            LoadTreeViewData()
            tvTreeView.Enabled = True
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
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Search") = row(9).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Sub ListControlDataBind()
        Dim pCountry As New CountryMaster
        lstCountry.DataSource = CountryMaster.ReturnCountryMasterList()
        lstCountry.DataTextField = "CountryName"
        lstCountry.DataValueField = "CountryId"
        lstCountry.DataBind()
        lstCountry.Items.Add(New ListItem("----Select----", "0"))
    End Sub

    Sub LoadTreeViewData()
        Dim pCompanyMaster As New CompanyMaster

        Try
            For Each obj As CompanyMaster In CompanyMaster.ReturnCompanyMasterList(pCompanyMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.CompanyCode, obj.CompanyName)
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
        If tvTreeView.Nodes.Count > 0 Then
            btnAdd.Visible = False
        Else
            btnAdd.Visible = pVisible
        End If
        btnEdit.Visible = pVisible
        btnExit.Visible = pVisible
        If textCompanyCode.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textCompanyCode)
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textCompanyCode.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textCompanyName)
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
        If textCompanyCode.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCompanyCode.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCompanyCode)
            Return rtnBool
            Exit Function
        End If
        If textCompanyName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblCompanyName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textCompanyName)
            Return rtnBool
            Exit Function
        End If
     
        If textPanNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPanNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textPanNo)
            Return rtnBool
            Exit Function
        End If
        If textTanNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblTanNo.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textTanNo)
            Return rtnBool
            Exit Function
        End If
        If textServiceTaxReg.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblServiceTaxReg.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textServiceTaxReg)
            Return rtnBool
            Exit Function
        End If
        If textContactPerson.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContactPerson.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textContactPerson)
            Return rtnBool
            Exit Function
        End If
        If textZip.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblPin.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textZip)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        If (floadLogo.HasFile) Then
            Try
                Dim fileName As String
                fileName = Path.GetFileName(floadLogo.FileName)
                fileName = "logo.png"
                floadLogo.SaveAs(Server.MapPath("../Images/") + fileName)
            Catch ex As Exception

            End Try
        End If
        Dim pCompanyMaster As CompanyMaster = ReturnObject()
        If hdnCompanyCode.Value <> Nothing Then
            CompanyMaster.Update(pCompanyMaster)
        Else
            CompanyMaster.Insert(pCompanyMaster)
        End If

        If pCompanyMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pCompanyMaster.Errormsg)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Functions.addOrModifyLeaf(tvTreeView, pCompanyMaster.CompanyName, pCompanyMaster.CompanyCode, textCompanyCode.Text)
        hdnCompanyCode.Value = pCompanyMaster.CompanyCode
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As CompanyMaster
        Dim p As New CompanyMaster
        p.CompanyCode = textCompanyCode.Text
        p.CompanyName = textCompanyName.Text
        p.Address = textAddress.Text
        p.CompanyClass = lstCompanyClass.SelectedValue
        p.PanNo = textPanNo.Text
        p.TanNo = textTanNo.Text
        p.ServiceTaxReg = textServiceTaxReg.Text
        p.ContactPerson = textContactPerson.Text
        p.ContactNo = textContactNo.Text
        p.EmailId = textEmailID.Text
        p.City = textCity.Text
        p.State = textState.Text
        p.Country = lstCountry.SelectedValue
        p.Pin = textZip.Text
        'p.DieselRate = textDieselRate.Text
        'p.Remarks = textRemarks.Text

        Return p
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New CompanyMaster
        p.CompanyCode = pCodevalue.Value
        CompanyMaster.ReturnCompanyMaster(p)
        textCompanyCode.Text = p.CompanyCode
        hdnCompanyCode.value = p.CompanyCode
        textCompanyName.Text = p.CompanyName
        Try
            lstCompanyClass.SelectedValue = p.CompanyClass
        Catch ex As Exception
        End Try

        textPanNo.Text = p.PanNo
        textTanNo.Text = p.TanNo
        textServiceTaxReg.Text = p.ServiceTaxReg
        textContactPerson.Text = p.ContactPerson
        textContactNo.Text = p.ContactNo
        textCity.Text = p.City
        textState.Text = p.State
        textEmailID.Text = p.EmailId
        lstCountry.SelectedValue = p.Country
        textAddress.Text = p.Address
        textZip.Text = p.Pin
        'textDieselRate.Text = p.DieselRate
        'textRemarks.Text = p.Remarks
    End Sub
End Class
