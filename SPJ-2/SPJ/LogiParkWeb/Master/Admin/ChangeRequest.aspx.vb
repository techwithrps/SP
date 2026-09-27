Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.Data.OleDb

Partial Class Master_Admin_ChangeRequest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        Permission(p)
        If Not IsPostBack Then
            lblScreenTitle.Text = "Change Request"
            LoadTreeViewData()
            manageControlsdtls(False)
            ListControlDataBind()
            tvTreeView.Enabled = True
            selectFirstNode()
            ButtonControlSetup(True)
            Functions.ControlFocus(btnAdd)
            CalendarExtender1.EndDate = DateTime.Now.Date
        End If
    End Sub

    'Sub Permission(ByVal P As String)
    '    Dim xmlFile As XmlReader
    '    xmlFile = XmlReader.Create(Server.MapPath("~/MenuXml.xml"), New XmlReaderSettings())
    '    Dim ds2 As New DataSet
    '    ds2.ReadXml(xmlFile)
    '    Dim dv As New DataView
    '    If P.Contains("~/") Then
    '        P = P.Replace("~/", "")
    '    End If
    '    dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
    '    dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
    '    If dv.ToTable.Rows.Count > 0 Then
    '        For Each row As DataRow In dv.ToTable.Rows
    '            Session.Item("Add") = row(7).ToString
    '            Session.Item("Edit") = row(8).ToString
    '            Session.Item("Delete") = row(9).ToString
    '            Session.Item("Search") = row(10).ToString
    '            Session.Item("Title") = row(4).ToString
    '        Next
    '    Else
    '        '   Response.Redirect("~/Restriction.aspx", False)
    '    End If
    'End Sub

    Sub Permission(ByVal P As String)
        Dim xmlFile As XmlReader
        xmlFile = XmlReader.Create(Server.MapPath("~/MenuXml.xml"), New XmlReaderSettings())
        Dim ds2 As New DataSet
        ds2.ReadXml(xmlFile)
        Dim dv As New DataView
        dv = New DataView(ds2.Tables(0), "URL = '" & P & "'", "", DataViewRowState.CurrentRows)
        dv = New DataView(dv.ToTable, "JOB_ID = '" & Session.Item("JobId") & "'", "", DataViewRowState.CurrentRows)
        For Each row As DataRow In dv.ToTable.Rows
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageControlsdtls(ByVal pEnable As Boolean)
        textCloseDate.Enabled = pEnable
        textCloseRemark.Enabled = pEnable
        textDiscription.Enabled = pEnable
        lstTask.Enabled = pEnable
        textTaskHeader.Enabled = pEnable
        textCRdate.Enabled = False
        TextCrNo.Enabled = False
    End Sub

    Sub ListControlDataBind()
        lstTask.DataSource = MenuItemMaster.ReturnMenuItemMasterListByLoginUserIdCR(Session.Item("JobId"))
        lstTask.DataTextField = "Title"
        lstTask.DataValueField = "MenuId"
        lstTask.DataBind()
        lstTask.Items.Insert(0, (New ListItem("New Task", 0)))
    End Sub

    Sub LoadTreeViewData()
        Dim pChangeRequest As New ChangeRequest
        pChangeRequest.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As ChangeRequest In ChangeRequest.ReturnChangeRequestList(pChangeRequest)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.TaskId, obj.TaskHeader)
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
        If hdnTaskId.Value <> Nothing Then
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
        manageControlsdtls(False)
        tvTreeView.Enabled = False
        lstTask.Enabled = True
        textDiscription.Enabled = True
        textTaskHeader.Enabled = True
        Functions.ControlFocus(lstTask)
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        textCloseDate.Enabled = True
        textCloseRemark.Enabled = True
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Functions.clearControls(Me.dvControl.Controls)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If Not tvTreeView.SelectedNode Is Nothing Then
            prepareControls(tvTreeView.SelectedNode)
        End If
        tvTreeView.Enabled = True
        ButtonControlSetup(True)
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx", False)
    End Sub

    Protected Sub tvTreeView_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvTreeView.SelectedNodeChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        prepareControls(tvTreeView.SelectedNode)
        SaveViewState()
        Functions.ControlFocus(btnAdd)
    End Sub

    Function ValidationCheck() As Boolean
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim rtnBool As Boolean = True

        If hdnTaskId.Value = Nothing Then
            If textTaskHeader.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Task Header is Blank.")
                rtnBool = False
                Functions.ControlFocus(textTaskHeader)
                Return rtnBool
                Exit Function
            End If
            If textDiscription.Text.Trim = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Description is Blank.")
                rtnBool = False
                Functions.ControlFocus(textDiscription)
                Return rtnBool
                Exit Function
            End If
        Else
            If textCloseDate.Text = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Close Date is Blank .")
                rtnBool = False
                Functions.ControlFocus(textCloseDate)
                Return rtnBool
                Exit Function
            End If
            If textCloseRemark.Text = Nothing Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Close Remark is Blank.")
                rtnBool = False
                Functions.ControlFocus(textCloseDate)
                Return rtnBool
                Exit Function
            End If
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pChangeRequest As ChangeRequest = ReturnObject()
        If hdnTaskId.Value <> Nothing Then
            ChangeRequest.Update(pChangeRequest)
            If pChangeRequest.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pChangeRequest.Errormsg)
                Functions.ControlFocus(lstTask)
                Return
            End If
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Else
            ChangeRequest.Insert(pChangeRequest)
            If pChangeRequest.Errormsg <> Nothing Then
                lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pChangeRequest.Errormsg)
                Functions.ControlFocus(lstTask)
                Return
            End If
            textCRdate.Text = pChangeRequest.OpenDate
            TextCrNo.Text = pChangeRequest.TaskId
            If hdnTaskId.Value = Nothing Then
                Dim strMsg As String = Nothing
                strMsg = SendMail(pChangeRequest)
                If strMsg <> Nothing Then
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully, Mail sending failure.")
                Else

                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
                End If
            End If
            Functions.addOrModifyLeaf(tvTreeView, pChangeRequest.OpenDate & "-" & textTaskHeader.Text, pChangeRequest.TaskId, hdnTaskId.Value)
            hdnTaskId.Value = pChangeRequest.TaskId
        End If
        ButtonControlSetup(True)
        manageControlsdtls(False)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
    End Sub

    Private Function ReturnObject() As ChangeRequest
        Dim pChangeRequest As New ChangeRequest

        If hdnTaskId.Value <> "" AndAlso hdnTaskId.Value > 0 Then
            pChangeRequest.TaskId = hdnTaskId.Value
        End If
        pChangeRequest.CloseDate = textCloseDate.Text
        pChangeRequest.MenuId = lstTask.SelectedValue
        pChangeRequest.OpenDate = textCRdate.Text
        pChangeRequest.TaskHeader = textTaskHeader.Text
        pChangeRequest.CreatedBy = Session.Item("LoginUser")
        pChangeRequest.UpdatedBy = Session.Item("LoginUser")
        pChangeRequest.TerminalId = Session.Item("LoginTerminal")
        pChangeRequest.CloseRemark = textCloseRemark.Text
        pChangeRequest.Description = textDiscription.Text

        Return pChangeRequest
    End Function
    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim pQM As New ChangeRequest
        pQM.TerminalId = Session.Item("LoginTerminal")
        pQM.TaskId = pCodevalue.Value
        ChangeRequest.ReturnChangeRequest(pQM)
        hdnTaskId.Value = pQM.TaskId
        Try
            lstTask.SelectedValue = pQM.MenuId
        Catch ex As Exception
        End Try
        textCloseRemark.Text = pQM.CloseRemark
        textCRdate.Text = pQM.OpenDate
        textTaskHeader.Text = pQM.TaskHeader
        textCloseDate.Text = pQM.CloseDate
        hdnCreateBy.Value = pQM.CreatedBy
        textDiscription.Text = pQM.Description
        TextCrNo.Text = pQM.TaskId
    End Sub
    Function SendMail(ByVal pChangeRequest As ChangeRequest) As String
        Dim pStr As String = ""

        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = Session.Item("LoginTerminal")
        MailConfig.ReturnMailConfig(pMailConfig)

        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = 287
        xMailSetup.TerminalId = Session.Item("LoginTerminal")
        MailSetup.ReturnMailSetup(xMailSetup)

        Dim confirmMail As New StringBuilder
        confirmMail.AppendLine("<table style='width: 100%; border-style:Solid; border-width:1px; position: static; height: 100%' cellpadding='0' cellspacing='0'>")
        confirmMail.Append("<tr style='color: #4B6B94'>")

        confirmMail.Append("<th style='font-family: calibri;'  colspan='3'>")
        confirmMail.Append("<b>Change Request</b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr>")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>CR No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; height: 5px; width: 100%'>")
        confirmMail.Append(TextCrNo.Text)
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("<tr >")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>Title</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; width: 100%; height: 5px'>")
        confirmMail.Append(lstTask.SelectedItem.Text)
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("<tr >")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>Open By</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; width: 100%; height: 5px'>")
        confirmMail.Append(hdnCreateBy.Value)
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("<tr >")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>CR Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; width: 100%; height: 5px'>")
        confirmMail.Append(textCRdate.Text)
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("<tr >")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>Status</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; width: 100%; height: 5px'>")
        confirmMail.Append("Open")
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")
        confirmMail.Append("<tr >")
        confirmMail.Append("<td style='font-size: 10pt; width:70px; height: 5px; color: #4B6B94;'>")
        confirmMail.Append("<b>Task Description</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td>")
        confirmMail.Append("<b>:</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='font-size: 10pt; width: 100%; height: 5px'>")
        confirmMail.Append(textDiscription.Text)
        confirmMail.Append(" </td>")
        confirmMail.Append("</tr>")

        Dim pCustomer As New UserMaster
        pCustomer.TerminalId = pChangeRequest.TerminalId
        pCustomer.UserId = hdnCreateBy.Value
        UserMaster.ReturnUserMaster(pCustomer)
        xMailSetup.ToMailIds &= "," & pCustomer.EmailId


        xMailSetup.MailBody = ""
        confirmMail.Append("</table>")

        xMailSetup.MailBody = confirmMail.ToString
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= " " & "<br/>"
        xMailSetup.MailBody &= "<b>Thanks & Regards </b>" & "<br>"
        Dim p As New CompanyMaster
        CompanyMaster.ReturnCompanyMaster(p)
        xMailSetup.MailBody &= p.CompanyName & "<br/>"
        ' pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, xMailSetup.ToMailIds, xMailSetup.CcIds, xMailSetup.BccIds, xMailSetup.Subject, xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
        Return pStr
    End Function
End Class
