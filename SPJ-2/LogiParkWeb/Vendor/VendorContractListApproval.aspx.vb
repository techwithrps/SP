Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml

Partial Class Vendor_VendorContractListApproval
    Inherits System.Web.UI.Page
    Dim ROWS As Integer = 9

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pp As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, pp)
        If Not IsPostBack Then
            Dim lngContractId As Integer = Request.QueryString("ContractId")

            fillRepeator(New ArrayList)
            If lngContractId > 0 Then
                Dim pExtVendorContract As New ExtVendorContract
                pExtVendorContract.TerminalId = Session.Item("LoginTerminal")
                pExtVendorContract.ContractId = lngContractId
                ExtVendorContract.ReturnVendorContractById(pExtVendorContract)
                prepareControlData(pExtVendorContract)
            End If
            ButtonControlSetup(True)
            manageUserControls(True)
            manageRepControls(True)
        End If
    End Sub

    

    Sub ButtonControlSetup(ByVal pVisible As Boolean)
        btnExit.Visible = pVisible
        btnApproved.Visible = pVisible
        btnDisapproved.Visible = pVisible
        If Session.Item("Add") <> "Y" Then

        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then

        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub

    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count < ROWS Then
            For i As Integer = 0 To ROWS - 1
                Dim p As New VendorContractDetails
                arr.Add(p)
            Next
        End If
        repVendorContractDetails.DataSource = arr
        repVendorContractDetails.DataBind()
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub


    Sub prepareControlData(ByVal pExtVendorContract As ExtVendorContract)
        hdnContractId.Value = pExtVendorContract.ContractId

        Dim pTerminalMaster As New TerminalMaster
        pTerminalMaster.TerminalId = pExtVendorContract.TerminalId
        TerminalMaster.ReturnTerminalMaster(pTerminalMaster)
        textTerminalName.Text = pTerminalMaster.TerminalName

        Dim pExtVendorType As New ExtVendorType
        pExtVendorType.TerminalId = pExtVendorContract.TerminalId
        pExtVendorType.VendorTypeCode = pExtVendorContract.VendorTypeCode
        ExtVendorType.ReturnVendorType(pExtVendorType)
        textVendorType.Text = pExtVendorType.VendorTypeName

        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = pExtVendorContract.TerminalId
        pExtVendorMaster.VendorId = pExtVendorContract.VendorId
        ExtVendorMaster.ReturnVendorMasterById(pExtVendorMaster)
        textVendor.Text = pExtVendorMaster.VendorName
        textContractCode.Text = pExtVendorContract.ContractCode
        textEffectiveFrom.Text = pExtVendorContract.EffectiveFrom
        textEffectiveTo.Text = pExtVendorContract.EffectiveTo
        fillRepeator(pExtVendorContract.VendorContractDetailsList)
    End Sub

    Function ValidationCheck() As Boolean
        Dim rtnBool As Boolean = True

        Return rtnBool
    End Function

    Function ReturnObject() As ExtVendorContract
        Dim pExtVendorContract As New ExtVendorContract
        If hdnContractId.Value <> Nothing AndAlso hdnContractId.Value > 0 Then
            pExtVendorContract.ContractId = hdnContractId.Value
        End If
        pExtVendorContract.TerminalId = Session.Item("LoginTerminal")
        If hdnApprovalMode.Value = "Approved" Then
            pExtVendorContract.ApprovalFlage = "Y"
        ElseIf hdnApprovalMode.Value = "DisApproved" Then
            pExtVendorContract.ApprovalFlage = "N"
        End If
        pExtVendorContract.Remarks = textRemark.Text
        pExtVendorContract.VendorContractDetailsList = New ArrayList
        For Each rep As RepeaterItem In repVendorContractDetails.Items
            If CType(rep.FindControl("chkSelect"), CheckBox).Checked = True AndAlso CType(rep.FindControl("chkSelect"), CheckBox).Enabled = True Then
                Dim pVendorContractDetails As New VendorContractDetails
                pVendorContractDetails.TerminalId = Session.Item("LoginTerminal")
                Try
                    If hdnApprovalMode.Value = "Approved" Then
                        pVendorContractDetails.ApprovalFlag = "Y"
                    ElseIf hdnApprovalMode.Value = "DisApproved" Then
                        pVendorContractDetails.ApprovalFlag = "N"
                    End If
                Catch ex As Exception
                End Try
                Try
                    pVendorContractDetails.ContractRefId = CType(rep.FindControl("hdnContractRefId"), HiddenField).Value
                Catch ex As Exception
                End Try
                pExtVendorContract.VendorContractDetailsList.Add(pVendorContractDetails)
            End If
        Next
        Return pExtVendorContract
    End Function

    Protected Sub btnApproved_Click(sender As Object, e As System.EventArgs) Handles btnApproved.Click
        hdnApprovalMode.Value = "Approved"
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtVendorContract As ExtVendorContract = ReturnObject()

        If pExtVendorContract.VendorContractDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor Details")
            Return
        End If
        ExtVendorContract.ApproveUpdateTransaction(pExtVendorContract)

        If pExtVendorContract.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtVendorContract.Errormsg)
            Return
        End If

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Approved Successfully.")
        hdnContractId.Value = pExtVendorContract.ContractId

        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub

    Protected Sub btnDisapproved_Click(sender As Object, e As System.EventArgs) Handles btnDisapproved.Click
        hdnApprovalMode.Value = "DisApproved"
        If ValidationCheck() = False Then
            Return
        End If
        Dim pExtVendorContract As ExtVendorContract = ReturnObject()
        If pExtVendorContract.VendorContractDetailsList.Count <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Vendor Details")
            Return
        End If
        ExtVendorContract.ApproveUpdateTransaction(pExtVendorContract)

        If pExtVendorContract.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtVendorContract.Errormsg)
            Return
        End If

        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Disapproved Successfully.")
        hdnContractId.Value = pExtVendorContract.ContractId

        ButtonControlSetup(True)
        manageUserControls(True)
    End Sub

    Sub manageRepControls(ByVal pEnable As Boolean)
        textRemark.Enabled = pEnable
        For Each rep As RepeaterItem In repVendorContractDetails.Items
            If CType(rep.FindControl("hdnContractRefId"), HiddenField).Value <> Nothing AndAlso CType(rep.FindControl("hdnContractRefId"), HiddenField).Value <> "0" Then
                CType(rep.FindControl("chkSelect"), CheckBox).Enabled = pEnable
            End If
        Next
    End Sub

    Protected Sub repVendorContractDetails_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repVendorContractDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnContractRefId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnContractRefId"), HiddenField).Value <> "0" Then
                Dim pVendorContractDetails As New VendorContractDetails
                pVendorContractDetails.TerminalId = Session.Item("LoginTerminal")
                pVendorContractDetails.ContractRefId = CType(e.Item.FindControl("hdnContractRefId"), HiddenField).Value
                VendorContractDetails.ReturnVendorContractDetailsByContractRefId_ContractId(pVendorContractDetails)
                If pVendorContractDetails.UomId <= 0 Then
                    CType(e.Item.FindControl("textUomId"), TextBox).Text = "ALL"
                Else
                    Dim pUomMaster As New UomMaster
                    pUomMaster.TerminalId = pVendorContractDetails.TerminalId
                    pUomMaster.UomId = pVendorContractDetails.UomId
                    UomMaster.ReturnUomMaster(pUomMaster)
                    CType(e.Item.FindControl("textUomId"), TextBox).Text = pUomMaster.UomName
                End If
                If pVendorContractDetails.ServiceId <= 0 Then
                    CType(e.Item.FindControl("textServiceId"), TextBox).Text = "ALL"
                Else
                    Dim pServiceMaster As New ServiceMaster
                    pServiceMaster.TerminalId = pVendorContractDetails.TerminalId
                    pServiceMaster.ServiceId = pVendorContractDetails.ServiceId
                    ServiceMaster.ReturnServiceMasterByServiceId(pServiceMaster)
                    CType(e.Item.FindControl("textServiceId"), TextBox).Text = pServiceMaster.ServiceName
                End If
                If pVendorContractDetails.DocType = "I" Then
                    CType(e.Item.FindControl("textDocType"), TextBox).Text = "IMPORT"
                ElseIf pVendorContractDetails.DocType = "E" Then
                    CType(e.Item.FindControl("textDocType"), TextBox).Text = "EXPORT"
                ElseIf pVendorContractDetails.DocType = "D" Then
                    CType(e.Item.FindControl("textDocType"), TextBox).Text = "DOMESTIC"
                ElseIf pVendorContractDetails.DocType = "A" Then
                    CType(e.Item.FindControl("textDocType"), TextBox).Text = "ALL"
                End If

                If pVendorContractDetails.ContStatus = "L" Then
                    CType(e.Item.FindControl("textContStatus"), TextBox).Text = "Laden"
                ElseIf pVendorContractDetails.ContStatus = "E" Then
                    CType(e.Item.FindControl("textContStatus"), TextBox).Text = "Empty"
                ElseIf pVendorContractDetails.ContStatus = "A" Then
                    CType(e.Item.FindControl("textContStatus"), TextBox).Text = "ALL"
                End If

                If pVendorContractDetails.ImoCode = "H" Then
                    CType(e.Item.FindControl("textImoCode"), TextBox).Text = "HAZ"
                ElseIf pVendorContractDetails.ImoCode = "N" Then
                    CType(e.Item.FindControl("textImoCode"), TextBox).Text = "NON-HAZ"
                ElseIf pVendorContractDetails.ImoCode = "A" Then
                    CType(e.Item.FindControl("textImoCode"), TextBox).Text = "ALL"
                End If

                If pVendorContractDetails.ContSize = "20" Then
                    CType(e.Item.FindControl("textContSize"), TextBox).Text = "20"
                ElseIf pVendorContractDetails.ContSize = "40" Then
                    CType(e.Item.FindControl("textContSize"), TextBox).Text = "40"
                ElseIf pVendorContractDetails.ContSize = "45" Then
                    CType(e.Item.FindControl("textContSize"), TextBox).Text = "45"
                ElseIf pVendorContractDetails.ContSize = "A" Then
                    CType(e.Item.FindControl("textContSize"), TextBox).Text = "ALL"
                End If

                If pVendorContractDetails.ContType = "A" Then
                    CType(e.Item.FindControl("textContType"), TextBox).Text = "ALL"
                Else
                    CType(e.Item.FindControl("textContType"), TextBox).Text = pVendorContractDetails.ContType
                End If
            End If
        End If
    End Sub
End Class
