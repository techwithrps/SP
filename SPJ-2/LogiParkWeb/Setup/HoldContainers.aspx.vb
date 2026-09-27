Imports System.Data
Imports System.Xml
Imports LogiParkLib.LogiParkObjects

Partial Class Domestic_HoldContainers
    Inherits Page
    Dim rows As Integer = 5

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            ListControlDataBind()
            manageUserControls(True)
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            Add()
            btnAddContNo.Visible = True
            btnAdd.Visible = False
        End If
    End Sub
    Sub ListControlDataBind()
        Dim pHoldAgency As New HoldAgency
        pHoldAgency.TerminalId = Session.Item("LoginTerminal")
        lstHoldAgency.DataSource = HoldAgency.ReturnHoldAgencyList(pHoldAgency)
        lstHoldAgency.DataTextField = "HoldAgencyName"
        lstHoldAgency.DataValueField = "HoldAgencyId"
        lstHoldAgency.DataBind()
        lstHoldAgency.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstHoldAgency.SelectedValue = 0
        Dim pHoldReason As New HoldReason
        pHoldReason.TerminalId = Session.Item("LoginTerminal")
        lstHoldReason.DataSource = HoldReason.ReturnHoldReasonList(pHoldReason)
        lstHoldReason.DataTextField = "ReasonDeatils"
        lstHoldReason.DataValueField = "HoldReasonId"
        lstHoldReason.DataBind()
        lstHoldReason.Items.Insert(0, (New ListItem("---Select---", 0)))
        lstHoldReason.SelectedValue = 0
    End Sub

    Sub ButtonControlSetup(pVisible As Boolean)
        btnAdd.Visible = pVisible
        btnSearch.Visible = pVisible
        btnExit.Visible = pVisible

        btnSave.Visible = Not pVisible
        btnCancel.Visible = Not pVisible
        If Session.Item("Add") <> "Y" Then
            btnAdd.Visible = False
        End If
        If Session.Item("Edit") <> "Y" Then

        End If
        If Session.Item("Search") <> "Y" Then
            btnSearch.Visible = False
        End If
        If Session.Item("Delete") <> "Y" Then
        End If
    End Sub

    Sub manageUserControls(pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub


    Sub Add()
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddContNo.Visible = True
        btnSearchContNo.Visible = False
        ' lstDocType.Enabled = True
        textContNo.Enabled = True
        Functions.ControlFocus(textContNo)
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddContNo.Visible = False
        Functions.ControlFocus(btnAdd)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Functions.clearControls(Me.dvControl.Controls)
        manageUserControls(True)
        ButtonControlSetup(True)
        btnAddContNo.Visible = False
        btnSearchContNo.Visible = True
        textContNo.Enabled = True
        Functions.ControlFocus(textContNo)
    End Sub
    Protected Sub btnAddContNo_Click(sender As Object, e As EventArgs) Handles btnAddContNo.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textContNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Cont No")
            Functions.ControlFocus(textContNo)
            Exit Sub
        End If
        'If lstDocType.SelectedValue = "0" Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Doc Type")
        '    Functions.ControlFocus(textContNo)
        '    Exit Sub
        'End If
        Dim pHoldContainers As New HoldContainers
        pHoldContainers.TerminalId = Session.Item("LoginTerminal")
        pHoldContainers.ContNo = textContNo.Text
        HoldContainers.ReturnHoldContainers(pHoldContainers)
        'If pHoldContainers.ContId <> 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Already Hold")
        '    Functions.ControlFocus(lstDocType)
        '    Exit Sub
        'End If
        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.TerminalId = Session.Item("LoginTerminal")
            pFleetContJoDtls.ContNo = textContNo.Text
            FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
            'If pExpContAllotdtls.GateOutDate <> "" AndAlso pExpContAllotdtls.GateInDate = "" Then
            '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container Gate Out")
            '        Functions.ControlFocus(textContNo)
            '        Exit Sub
            '    End If
            Dim pFleetContJo As New FleetContJo
            pFleetContJo.TerminalId = Session.Item("LoginTerminal")
            pFleetContJo.ContJoId = pFleetContJo.ContJoId
            FleetContJo.ReturnFleetContJo(pFleetContJo)
            hdnexporterId.Value = pFleetContJo.ConsigneeId
            textSize.Text = pFleetContJoDtls.ContSize
            textType.Text = pFleetContJoDtls.ContType



            Dim pCustomerMasterLine As New CustomerMaster
            pCustomerMasterLine.TerminalId = pFleetContJoDtls.TerminalId
            pCustomerMasterLine.CustomerId = pFleetContJoDtls.LineId
            CustomerMaster.ReturnCustomerMaster(pCustomerMasterLine)
            textLine.Text = pCustomerMasterLine.CustomerName
            hdnMtyContId.Value = pFleetContJoDtls.MtyContId
        hdnLineId.Value = pFleetContJo.LineId

        Dim pCustomerMasterShipper As New CustomerMaster
        pCustomerMasterShipper.TerminalId = pFleetContJoDtls.TerminalId
        pCustomerMasterShipper.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pCustomerMasterShipper)
        textCustomer.Text = pCustomerMasterShipper.CustomerName
        If hdnMtyContId.Value <= "0" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Container  not found")
                Functions.ControlFocus(textContNo)
                ButtonControlSetup(True)
                Exit Sub
            End If
            manageUserControls(True)
        ButtonControlSetup(False)
        managecontrol(True)
        Functions.ControlFocus(lstHoldAgency)
        btnAddContNo.Visible = False
    End Sub

    Sub managecontrol(pEnable As Boolean)
        lstHoldAgency.Enabled = pEnable
        lstHoldReason.Enabled = pEnable
        textHoldRemarks.Enabled = pEnable
        T40.Disabled = pEnable
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool = True
        If lstHoldAgency.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Hold Agency")
            Functions.ControlFocus(lstHoldAgency)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If

        If lstHoldReason.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Hold Reason")
            Functions.ControlFocus(lstHoldReason)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If textHoldRemarks.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Hold Remarks")
            Functions.ControlFocus(textHoldRemarks)
            rtnBool = False
            Return rtnBool
            Exit Function
        End If
        If T40.Disabled = False Then
            If chkRelease.Checked = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Checkbox")
                Functions.ControlFocus(chkRelease)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If

            If textReleaseRemarks.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Release Remarks")
                Functions.ControlFocus(textReleaseRemarks)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
            If txtReleaseDate.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Release Date")
                Functions.ControlFocus(txtReleaseDate)
                rtnBool = False
                Return rtnBool
                Exit Function
            End If
        End If
        Return rtnBool
    End Function
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If

        Dim pHoldContainers As HoldContainers = ReturnObject()
        If pHoldContainers.HoldId <= 0 Then
            HoldContainers.Insert(pHoldContainers)
            ' SendMail()
        Else
            HoldContainers.Update(pHoldContainers)
        End If

        If pHoldContainers.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pHoldContainers.Errormsg)
            Return
        End If
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully")
        If pHoldContainers.HoldDate <> "" Then
            textHoldDate.Text = pHoldContainers.HoldDate
        End If
        ButtonControlSetup(True)
        manageUserControls(True)
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ReturnObject() As HoldContainers
        Dim pHoldContainers As New HoldContainers
        If hdnHoldId.Value <= "0" Or hdnHoldId.Value = "" Then
            pHoldContainers.ContId = hdnMtyContId.Value
            pHoldContainers.TerminalId = Session.Item("LoginTerminal")
            pHoldContainers.ContNo = textContNo.Text
            pHoldContainers.ContSize = textSize.Text
            pHoldContainers.ContType = textType.Text
            Try
                pHoldContainers.ContOwner = hdnLineId.Value
            Catch ex As Exception

            End Try
            pHoldContainers.DocType = hdnDocType.Value
            pHoldContainers.HoldRemarks = textHoldRemarks.Text
            pHoldContainers.HoldBy = Session.Item("LoginUser")
            pHoldContainers.HoldReasonId = lstHoldReason.SelectedValue
            pHoldContainers.HoldAgency = lstHoldAgency.SelectedValue
        Else
            pHoldContainers.ReleaseBy = hdnHandlingMode.Value
            pHoldContainers.ContId = hdnMtyContId.Value
            pHoldContainers.TerminalId = Session.Item("LoginTerminal")
            pHoldContainers.HoldId = hdnHoldId.Value
            pHoldContainers.ReleaseBy = Session.Item("LoginUser")
            pHoldContainers.ReleaseDate = txtReleaseDate.Text
            pHoldContainers.ReleaseRemarks = textReleaseRemarks.Text
            pHoldContainers.DocType = hdnDocType.Value
        End If
        Return pHoldContainers
    End Function

    Protected Sub btnSearchContNo_Click(sender As Object, e As EventArgs) Handles btnSearchContNo.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textContNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter The Cont No")
            Functions.ControlFocus(textContNo)
            Exit Sub
        End If
        Dim pHoldContainers As New HoldContainers
        pHoldContainers.TerminalId = Session.Item("LoginTerminal")
        pHoldContainers.ContNo = textContNo.Text
        HoldContainers.ReturnHoldContainers(pHoldContainers)

        If pHoldContainers.ContId <= 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage,
                                             "Container not found for release.")
            Functions.ControlFocus(textContNo)
            Exit Sub
        End If
        prepare(pHoldContainers)
        btnSearchContNo.Visible = False
        ButtonControlSetup(True)
        manageUserControls(True) '

        Dim clStartDate = DateTime.Now.Date

        If Not String.IsNullOrWhiteSpace(textHoldDate.Text) Then
            Dim dtTime = textHoldDate.Text.Trim.Split(CType(" ", Char))

            Dim dtArr = dtTime(0)
            Dim time = dtTime(1)
            Dim arr = dtArr.Split(CType("/", Char))

            Dim ddDate = Convert.ToInt32(arr(0))
            Dim ddMonth = Convert.ToInt32(arr(1))
            Dim ddYear = Convert.ToInt32(arr(2))

            Dim arrTime = time.Split(CType(":", Char))
            Dim hour = Convert.ToInt32(arrTime(0))
            Dim min = Convert.ToInt32(arrTime(1))
            clStartDate = New Date(ddYear, ddMonth, ddDate, hour, min, 0)
        End If

        clReleaseDate.StartDate = clStartDate
        clReleaseDate.EndDate = DateTime.Now.Date
    End Sub

    Sub prepare(pHoldContainers As HoldContainers)
        hdnMtyContId.Value = pHoldContainers.ContId
        hdnHoldId.Value = pHoldContainers.HoldId
        textHoldDate.Text = pHoldContainers.HoldDate
        ' txtReleaseDate.Text = pHoldContainers.ReleaseDate
        textSize.Text = pHoldContainers.ContSize
        textType.Text = pHoldContainers.ContType
        lstHoldAgency.SelectedValue = pHoldContainers.HoldAgency
        lstHoldReason.SelectedValue = pHoldContainers.HoldReasonId
        textHoldRemarks.Text = pHoldContainers.HoldRemarks
        Dim pCustomerMaster As New CustomerMaster
        pCustomerMaster.TerminalId = pHoldContainers.TerminalId
        pCustomerMaster.CustomerId = pHoldContainers.ContOwner
        CustomerMaster.ReturnCustomerMaster(pCustomerMaster)
        textLine.Text = pCustomerMaster.CustomerName


        Dim pShipperMaster As New CustomerMaster
        pShipperMaster.TerminalId = pHoldContainers.TerminalId
        pShipperMaster.CustomerId = pHoldContainers.ContOwner
        CustomerMaster.ReturnCustomerMaster(pShipperMaster)
        textCustomer.Text = pCustomerMaster.CustomerName
        'If pHoldContainers.DocType = "O" Then
        '    lstDocType.SelectedValue = "E"
        '    hdnDocType.Value = "O"
        'Else
        '    lstDocType.SelectedValue = pHoldContainers.DocType
        '    hdnDocType.Value = pHoldContainers.DocType
        'End If
        textReleaseRemarks.Text = pHoldContainers.ReleaseRemarks
        If pHoldContainers.ReleaseRemarks <> "" Then
            chkRelease.Checked = True
        Else
            btnEdit.Visible = True
        End If

    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If textContNo.Text = "" Then
            Functions.ControlFocus(textContNo)
        End If
    End Sub

    Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        T40.Disabled = False
        textReleaseRemarks.Enabled = True
        txtReleaseDate.Enabled = True
        chkRelease.Enabled = True
        Functions.ControlFocus(chkRelease)
        ButtonControlSetup(False)
        btnEdit.Visible = False
    End Sub

    Function SendMail() As String
        Dim pStr = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = Session.Item("LoginTerminal")
        MailConfig.ReturnMailConfig(pMailConfig)
        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = 212
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetup(xMailSetup)
        '  hdnMail.Value = xMailSetup.ToMailIds
        Dim confirmMail As New StringBuilder
        xMailSetup.MailBody = ""
        confirmMail.AppendLine(
            "<table style='width: 1000px; border-style:Solid; border-width:1px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")
        confirmMail.Append("<tr style='font-family: calibri; color: #4B6B94;'>")
        confirmMail.Append("<th style='align: center; font-size: 15px; height: 21px' colspan='8'>")
        confirmMail.Append("<b>Hold Containers</b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #C0C0C0;'>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Container No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Size</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Doc Type</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Shipper</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Hold Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Hold Remark</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Hold By</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")
        Dim pcus As New CustomerMaster
        pcus.TerminalId = 1
        pcus.CustomerId = hdnexporterId.Value
        CustomerMaster.ReturnCustomerMaster(pcus)
        Dim phold As New HoldContainers
        phold.TerminalId = Session.Item("LoginTerminal")
        phold.ContNo = textContNo.Text
        HoldContainers.ReturnHoldContainers(phold)
        confirmMail.Append("<tr style='font-family: calibri;'>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.ContNo)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.ContSize)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.ContType)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.DocType)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 80px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(pcus.CustomerName)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 70px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.HoldDate)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.HoldRemarks)
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 50px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(phold.HoldBy)
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")

        confirmMail.Append("</table>")
        xMailSetup.MailBody = "Dear Sir/Mam'm, "
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "Please find below details of valued shipment hold at ICD Panki:"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= confirmMail.ToString
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "<b>Thanks & Regards </b>" & "<br>"
        xMailSetup.Subject = "Hold Containers"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"
        'pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds,
        '                                   xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody,
        '                                   pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        Return pStr
    End Function
End Class
