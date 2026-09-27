Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Data.OleDb

Partial Class Fleet_DriverMaster
    Inherits System.Web.UI.Page
    Dim FileName As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then

            lblScreenTitle.Text = Session.Item("Title")
            LoadTreeViewData()
            ListControlDataBind()
            tvTreeView.Enabled = True
            ImgDriver.Visible = False
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
            Session.Item("MenuId") = row(0).ToString
            Session.Item("Add") = row(7).ToString
            Session.Item("Edit") = row(8).ToString
            Session.Item("Delete") = row(9).ToString
            Session.Item("Search") = row(10).ToString
            Session.Item("Title") = row(4).ToString
        Next
    End Sub

    Sub manageUserControls(ByVal pEnable As Boolean)
        Functions.ControlSetup(pEnable, Me.dvControl.Controls)
    End Sub
    Sub ListControlDataBind()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM  FLEET_EQUIPMENT_MASTER "

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("CONTAINER")
            ada.Fill(ds)
            lstVehicleNo.DataSource = ds.Tables(0)
            lstVehicleNo.DataTextField = "EQUIPMENT_NO"
            lstVehicleNo.DataValueField = "EQUIPMENT_ID"
            lstVehicleNo.DataBind()
            lstVehicleNo.Items.Insert(0, (New ListItem("---Select---", "0")))
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Sub LoadTreeViewData()
        Dim pDriverMaster As New FleetDriverMaster
        pDriverMaster.TerminalId = Session.Item("LoginTerminal")
        Try
            For Each obj As FleetDriverMaster In FleetDriverMaster.ReturnFleetDriverMasterList(pDriverMaster)
                Functions.treeViewNodeSetup(tvTreeView, "0", obj.DriverId, obj.DriverName)
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
        If textDriverName.Text.Trim <> Nothing Then
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
        Functions.ControlFocus(textDriverName)
        ImgDriver.ImageUrl = ""
        fileDriverPic.Visible = True
    End Sub

    Sub manageControls(ByRef pEnable As Boolean)
        textDriverName.Enabled = pEnable
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        manageUserControls(False)
        ButtonControlSetup(False)
        tvTreeView.Enabled = False
        manageControls(False)
        Functions.ControlFocus(textDriverName)
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
        If textDriverName.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblDriverName.Text & " is Blank.")
            rtnBool = False
            Functions.ControlFocus(textDriverName)
            Return rtnBool
            Exit Function
        End If
        If lstVehicleNo.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lstVehicleNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lstVehicleNo)
            Return rtnBool
            Exit Function
        End If
        If textContactNo.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblContactNo.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(lblContactNo)
            Return rtnBool
            Exit Function
        End If
        If textDlNO.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblDlNO.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textDlNO)
            Return rtnBool
            Exit Function
        End If
        If textRenewal.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblDlRenewal.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textRenewal)
            Return rtnBool
            Exit Function
        End If
        If textJoining.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblJoining.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textJoining)
            Return rtnBool
            Exit Function
        End If
        If textSalary.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, lblSalary.Text & "is Blank.")
            rtnBool = False
            Functions.ControlFocus(textSalary)
            Return rtnBool
            Exit Function
        End If
        Return rtnBool
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidationCheck() = False Then
            Return
        End If
        Dim pDriverMaster As FleetDriverMaster = ReturnObject()
        If hdnDriverId.Value <> Nothing Then
            FleetDriverMaster.Update(pDriverMaster)
        Else
            FleetDriverMaster.Insert(pDriverMaster)
        End If
        If pDriverMaster.Errormsg <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pDriverMaster.Errormsg)
            Functions.ControlFocus(textDriverName)
            Return
        End If
        lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Saved Successfully.")
        Try
            ImgDriver.ImageUrl = "~\\FleetImage\\" + hdnDriverPic.Value
            ImgDriver.Visible = True
        Catch ex As Exception
        End Try
        Functions.addOrModifyLeaf(tvTreeView, pDriverMaster.DriverName, pDriverMaster.DriverId, hdnDriverId.Value)
        hdnDriverId.Value = pDriverMaster.DriverId
        ButtonControlSetup(True)
        manageUserControls(True)
        tvTreeView.Enabled = True
        Functions.ControlFocus(btnAdd)
        fileDriverPic.Visible = False
    End Sub

    Private Function ReturnObject() As FleetDriverMaster
        Dim pDriverMaster As New FleetDriverMaster
        If hdnDriverId.Value <> "" AndAlso hdnDriverId.Value > 0 Then
            pDriverMaster.DriverId = hdnDriverId.Value
        End If
        pDriverMaster.TerminalId = Session.Item("LoginTerminal")
        pDriverMaster.DriverName = textDriverName.Text.Trim
        pDriverMaster.VehicleId = lstVehicleNo.SelectedValue
        pDriverMaster.VehicleNo = lstVehicleNo.SelectedItem.Text
        pDriverMaster.ContactNo = textContactNoPersonal.Text.Trim
        pDriverMaster.MobileNo = textContactNo.Text.Trim
        pDriverMaster.EmailId = textEmailid.Text.Trim
        pDriverMaster.BloodGroup = lstBloodGroup.SelectedValue
        pDriverMaster.DlNo = textDlNO.Text.Trim
        pDriverMaster.DlRenewableDate = textRenewal.Text
        pDriverMaster.JoiningDate = textJoining.Text
        pDriverMaster.Salary = textSalary.Text
        pDriverMaster.Address = textAddress.Text
        pDriverMaster.Gaurantor = textRef.Text
        pDriverMaster.PhoneNo = textMobileNo.Text
        pDriverMaster.EmergPhone = textEmergency.Text
        pDriverMaster.AddressDoc = hdnAddress.Value
        pDriverMaster.DlDoc = hdnDL.Value
        If ChkActive.Checked = True Then
            pDriverMaster.ActiveFlage = "Y"
        End If
        Try
            If fileDriverPic.PostedFile.FileName <> "" Then
                Try
                    pDriverMaster.Image = Path.GetFileName(fileDriverPic.PostedFile.FileName)
                    hdnDriverPic.Value = pDriverMaster.Image
                    fileDriverPic.PostedFile.SaveAs(Server.MapPath("~/FleetImage/") + pDriverMaster.Image)
                Catch ex As Exception

                End Try
            Else
                pDriverMaster.Image = hdnDriverPic.Value
            End If
        Catch ex As Exception
        End Try
        pDriverMaster.CreatedBy = Session.Item("LoginUser")
        Return pDriverMaster
    End Function

    Sub prepareControls(ByVal pCodevalue As TreeNode)
        Dim p As New FleetDriverMaster
        p.TerminalId = Session.Item("LoginTerminal")
        p.DriverId = pCodevalue.Value
        FleetDriverMaster.ReturnFleetDriverMaster(p)
        hdnDriverId.Value = p.DriverId
        textDriverName.Text = p.DriverName
        lstVehicleNo.SelectedValue = p.VehicleId
        textContactNo.Text = p.MobileNo
        textContactNoPersonal.Text = p.ContactNo
        textEmailid.Text = p.EmailId
        lstBloodGroup.SelectedValue = p.BloodGroup
        textDlNO.Text = p.DlNo
        textRenewal.Text = p.DlRenewableDate
        textJoining.Text = p.JoiningDate
        textSalary.Text = p.Salary
        textAddress.Text = p.Address
        textRef.Text = p.Gaurantor
        If p.ActiveFlage = "Y" Then
            ChkActive.Checked = True
        End If
        textMobileNo.Text = p.PhoneNo
        textEmergency.Text = p.EmergPhone
        Try
            ImgDriver.ImageUrl = "~\FleetImage\" + p.Image
            hdnDriverPic.Value = p.Image
            ImgDriver.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Sub DriverDtls()

        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT DRIVER_NAME,ADDRESS,VEHICLE_NO,CONTACT_NO,MOBILE_NO,EMAIL_ID,BLOOD_GROUP,JOINING_DATE,DL_NO,DL_RENEWABLE_DATE,SALARY FROM FLEET_DRIVER_MASTER "

            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("DTLS")
            ada.Fill(ds)
            gvDriverDtls.DataSource = ds.Tables(0)
            gvDriverDtls.DataBind()
            ds.Clear()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        DriverDtls()
        'Response.ClearContent()
        'Response.Buffer = True
        'Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Driver.xls"))
        'Response.ContentType = "application/ms-excel"
        'Dim sw As New StringWriter()
        'Dim htw As New HtmlTextWriter(sw)
        'gvDriverDtls.AllowPaging = False
        'DriverDtls()
        ''Change the Header Row back to white color
        'gvDriverDtls.HeaderRow.Style.Add("background-color", "#FFFFFF")
        ''Applying stlye to gridview header cells
        'For i As Integer = 0 To gvDriverDtls.HeaderRow.Cells.Count - 1
        '    gvDriverDtls.HeaderRow.Cells(i).Style.Add("background-color", "#df5015")
        'Next
        'gvDriverDtls.RenderControl(htw)
        'Response.Write(sw.ToString())
        'Response.[End]()

        Response.Clear()
        Response.Buffer = True

        Response.AddHeader("content-disposition", "attachment;filename=DriverMaster.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        gvDriverDtls.RenderControl(hw)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    Protected Sub OnClickHandler(ByVal Sender As Object, ByVal e As EventArgs)
        Try
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            Dim upload As LinkButton = Sender
            hdnClick.Value = upload.CommandArgument
            If hdnClick.Value = 1 Then
                hdnAddress.Value = textAddress.Text
            ElseIf hdnClick.Value = 2 Then
                hdnDL.Value = textDlNO.Text
            End If
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)

        Catch ex As Exception
        End Try

    End Sub
    Protected Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        Dim path As String = ""
        Dim files As HttpFileCollection = Request.Files

        For i As Integer = 0 To files.Count - 1

            Dim file As HttpPostedFile = files(i)

            If file.ContentLength > 0 Then
                If hdnClick.Value = 1 Then
                    path = Server.MapPath("~/Document/Adress/")
                    FileName = System.IO.Path.GetFileName(hdnAddress.Value & "-" & file.FileName)
                    hdnAddress.Value = FileName

                ElseIf hdnClick.Value = 2 Then
                    path = Server.MapPath("~/Document/DL/")
                    hdnDL.Value = System.IO.Path.GetFileName(hdnDL.Value & "-" & file.FileName)
                    lblErrorMessage.Text += "File : <b>" & FileName & "</b> uploaded successfully !<br />"

                End If
            End If
            Try
                file.SaveAs(path & FileName)

            Catch ex As Exception

            End Try
           
        Next
    End Sub

End Class
