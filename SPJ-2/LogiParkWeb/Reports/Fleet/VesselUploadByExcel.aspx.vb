Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services

Partial Class Reports_Fleet_VesselUploadByExcel
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Dim arrPortId As ArrayList
    Dim arrPortName As ArrayList
    Dim arrPodId As ArrayList
    Dim arrPodName As ArrayList
    Dim arrCustomerId As ArrayList
    Dim arrCustomerName As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ListControlDataBind()

            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            ' txtICDOUtFrom.Text = Format(Now, "dd/MM/yyyy")
            ' txtICDOutToDate.Text = Format(Now, "dd/MM/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            'strpParms &= ",'" & txtICDOUtFrom.Text & "'"
            'strpParms &= ",'" & txtICDOutToDate.Text & "'"
            strpParms &= "," & ddlPOL.SelectedValue & ""
            strpParms &= "," & ddlPOD.SelectedValue & ""
            strpParms &= "," & ddlLine.SelectedValue & ""
            strpParms &= "," & ddShipper.SelectedValue & ""
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect

            ' If lstTransactionType.SelectedValue = "0" Then
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VESSEL_REPORT_DATA", strpParms)
            gvInvoiceReport.DataSource = dbr
            gvInvoiceReport.DataBind()

            btnUpload.Visible = False
            btnupdate.Visible = False

        End If

    End Sub
    Sub ListControlDataBind()
        Try
            Dim pPortMaster As New PortMaster
            ddlPOL.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            ddlPOL.DataTextField = "PortName"
            ddlPOL.DataValueField = "PortId"
            ddlPOL.DataBind()
            ddlPOL.Items.Insert(0, (New ListItem("---ALL---", 0)))

            ddlPOD.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            ddlPOD.DataTextField = "PortName"
            ddlPOD.DataValueField = "PortId"
            ddlPOD.DataBind()
            ddlPOD.Items.Insert(0, (New ListItem("---ALL---", 0)))

            Dim pCustomerMaster As New CustomerMaster
            ddlLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            ddlLine.DataTextField = "CustomerName"
            ddlLine.DataValueField = "CustomerId"
            ddlLine.DataBind()
            ddlLine.Items.Insert(0, (New ListItem("---ALL---", 0)))
            Dim pShipper As New CustomerMaster
            ddShipper.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
            ddShipper.DataTextField = "CustomerName"
            ddShipper.DataValueField = "CustomerId"
            ddShipper.DataBind()
            ddShipper.Items.Insert(0, (New ListItem("---All---", 0)))
            ddShipper.SelectedValue = 0


        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date
        prepareTerminalData()
        preparePortData()
        ' prepareCustomerData()
        preparePortDataPOD()
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & ddlPOL.SelectedValue & ""
        strpParms &= "," & ddlPOD.SelectedValue & ""
        strpParms &= "," & ddlLine.SelectedValue & ""
        strpParms &= "," & ddShipper.SelectedValue & ""
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        ' If lstTransactionType.SelectedValue = "0" Then
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VESSEL_REPORT_DATA", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Private Sub BindData()
        prepareTerminalData()
        preparePortData()
        'prepareCustomerData()
        preparePortDataPOD()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= hdnFileId.Value
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VESSEL_UPLOAD", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
            btnupdate.Visible = False
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()


    End Sub
    Protected Sub prepareCustomer(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrCustomerId.Count - 1
                lst.Items.Add(New ListItem(arrCustomerName(i), arrCustomerId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub prepareCustomerData()
        Try
            arrCustomerId = New ArrayList
            arrCustomerName = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerName.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub prepareTerminal(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrTerminalId.Count - 1
                lst.Items.Add(New ListItem(arrTerminalName(i), arrTerminalId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub prepareTerminalData()
        Try
            arrTerminalId = New ArrayList
            arrTerminalName = New ArrayList
            Dim pTerminalMaster As New TerminalMaster
            For Each obj As TerminalMaster In TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
                arrTerminalId.Add(obj.TerminalId)
                arrTerminalName.Add(obj.TerminalName)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub preparePort(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrPortId.Count - 1
                lst.Items.Add(New ListItem(arrPortName(i), arrPortId(i)))
            Next
        Catch ex As Exception
        End Try
    End Sub

    Sub preparePortData()
        Try
            arrPortId = New ArrayList
            arrPortName = New ArrayList
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
                arrPortId.Add(obj.PortId)
                arrPortName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub preparePod(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim lst As DropDownList = sender
            lst.Items.Clear()
            lst.Items.Add(New ListItem("----Select----", "0"))
            For i As Integer = 0 To arrPodId.Count - 1
                lst.Items.Add(New ListItem(arrPodName(i), arrPodId(i)))
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub preparePortDataPOD()
        Try
            arrPodId = New ArrayList
            arrPodName = New ArrayList
            Dim pPortMaster As New PortMaster
            For Each obj As PortMaster In PortMaster.ReturnPortMasterList(pPortMaster)
                arrPodId.Add(obj.PortId)
                arrPodName.Add(obj.PortName)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                '  Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                ' If isChecked Then
                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                Dim txtContNo As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                '  Dim HdnContJOId As HiddenField = TryCast(row.Cells(0).FindControl("HdnContJOId"), HiddenField)
                Dim TxtFinalVessel As TextBox = TryCast(row.Cells(0).FindControl("TxtFinalVessel"), TextBox)
                Dim TxtRequiredEtd As TextBox = TryCast(row.Cells(0).FindControl("TxtRequiredEtd"), TextBox) 
                Dim TextETA As TextBox = TryCast(row.Cells(0).FindControl("TextETA"), TextBox)
                Dim TxtSiCut As TextBox = TryCast(row.Cells(0).FindControl("TxtSiCut"), TextBox)
                Dim txtpod As TextBox = TryCast(row.Cells(0).FindControl("txtpod"), TextBox)
                Dim txtPOL As TextBox = TryCast(row.Cells(0).FindControl("txtPOL"), TextBox)
                Dim hdnPOL As HiddenField = TryCast(row.Cells(0).FindControl("hdnPOL"), HiddenField)
                Dim hdnPort As HiddenField = TryCast(row.Cells(0).FindControl("hdnPort"), HiddenField)
                Dim TextPortCutOfDate As TextBox = TryCast(row.Cells(0).FindControl("TextPortCutOfDate"), TextBox)
                Dim Lstpol As TextBox = TryCast(row.Cells(0).FindControl("Lstpol"), TextBox)
                Dim Lstpod As TextBox = TryCast(row.Cells(0).FindControl("Lstpod"), TextBox)
                Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                ' Dim hdnShipper As HiddenField = TryCast(row.Cells(0).FindControl("hdnShipper"), HiddenField)
                'Dim LstConsignmentType As DropDownList = TryCast(row.Cells(0).FindControl("LstConsignmentType"), DropDownList)
                'Dim LslPackageType As DropDownList = TryCast(row.Cells(0).FindControl("LslPackageType"), DropDownList)
                Dim strConnectionString, cmd1 As String
                Dim con As OleDbConnection
                Dim ada As OleDbDataReader
                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                ' cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),NVL(CFS_ID,0),PORT,POL,CFS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                'cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),NVL(CFS_ID,0),PORT,POL,CFS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                cmd1 = "SELECT NVL(POL,0) POL_ID , NVL(POD,0) POD_ID, PMD.PORT_NAME|| '-' || CM.COUNTRY_NAME PORT , PML.PORT_NAME POL FROM VESSL_UPLOAD A LEFT JOIN PORT_MASTER PMD ON A.POD = PMD.PORT_ID " _
                 & "  LEFT JOIN PORT_MASTER PML On A.POL=PML.PORT_ID   " _
                 & " LEFT JOIN COUNTRY_MASTER CM On PMD.COUNTRY_ID=CM.COUNTRY_ID  where A.CONT_NO= '" & txtContNo.Text & "' AND A.FILE_ID= '" & hdnFileId.Value & "'"
                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
                con = New OleDbConnection(strConnectionString)
                con.Open()
                Dim cmd As New OleDbCommand()
                cmd.Connection = con
                cmd.CommandText = cmd1
                ada = cmd.ExecuteReader
                ada.Read()
                'Try
                '    Lstpol.SelectedValue = ada.GetValue(0)
                'Catch ex As Exception
                'End Try
                Try
                    txtPOL.Text = ada.GetValue(0)
                Catch ex As Exception
                End Try
                Try
                    txtpod.Text = ada.GetValue(1)
                Catch ex As Exception
                End Try

                Try
                    hdnPort.Value = ada.GetValue(2)
                Catch ex As Exception
                End Try

                Try
                    hdnPOL.Value = ada.GetValue(3)
                Catch ex As Exception
                End Try

                con = New OleDbConnection(cs)
                con.Open()
                Dim cmd11 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET POL_ID=NVL(" & txtPOL.Text & ",0),POD_ID=NVL(" & txtpod.Text & ",0),POL='" & hdnPOL.Value & "', " _
                                         & " CURRENT_VESSEL='" & TxtFinalVessel.Text & "',REQUIRED_VESSEL='" & TxtFinalVessel.Text & "', " _
                                         & " CUTOF_DATE=TO_DATE('" & TextPortCutOfDate.Text & "','DD/MM/YYYY')," _
                                         & " PORT=NVL('" & hdnPort.Value & "','')," _
                                         & " SI_CUTOF_DATE=NVL(TO_DATE('" & TxtSiCut.Text & "','DD/MM/YYYY'),''), " _
                                         & " REQUIRED_ETD=NVL(TO_DATE('" & TxtRequiredEtd.Text & "','DD/MM/YYYY'),'') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                cmd11.ExecuteNonQuery()
                Try
                    Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO_DTLS SET VESSEL_NAME = '" & TxtFinalVessel.Text & "', STUFFING_POL = " & txtPOL.Text & ",STUFFING_POD=" & txtpod.Text & ",POL = " & txtPOL.Text & ",FPOD=" & txtpod.Text & ",  " _
                                             & "  ETD_DATE=NVL(TO_DATE('" & TxtRequiredEtd.Text & "','DD/MM/YYYY'),''),PORT_CUTOF_DATE=TO_DATE('" & TextPortCutOfDate.Text & "','DD/MM/YYYY')," _
                                              & " UPDATED_BY='" & Session.Item("LoginUser") & "',UPDATED_ON=SYSDATE,  SI_CUTOF_DATE=TO_DATE('" & TxtSiCut.Text & "','DD/MM/YYYY'), ETA_DATE=TO_DATE('" & TextETA.Text & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    cmd2.ExecuteNonQuery()
                Catch ex As Exception

                End Try

                'Dim cmd4 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO SET CONSIGNEE_ID=" & TextConsignor.SelectedValue & " WHERE CONT_JO_ID= " & Convert.ToInt32(HdnContJOId.Value), con)
                'cmd4.ExecuteNonQuery()
                con.Close()

            End If

            gvInvoiceReport.EditIndex = -1
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Save Successfully")

        Next

        BindData()

    End Sub

    Protected Sub btnRDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
        tblReport.Visible = False


        prepareTerminalData()
        preparePortData()
        prepareCustomerData()
        preparePortDataPOD()
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= "," & ddlPOL.SelectedValue & ""
        strpParms &= "," & ddlPOD.SelectedValue & ""
        strpParms &= "," & ddlLine.SelectedValue & ""
        strpParms &= "," & ddShipper.SelectedValue & ""
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        ' If lstTransactionType.SelectedValue = "0" Then
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VESSEL_REPORT_DATA", strpParms)
        'dt.Load(dbr)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
            btnUpload.Visible = True
            btnupdate.Visible = False
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub linkDownload_Click(sender As Object, e As System.EventArgs) Handles linkDownload.Click
        Dim filePath As String = Server.MapPath("~/Format/VesselFormat.csv")
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath))
        Response.WriteFile(filePath)
        Response.End()
    End Sub

    Protected Sub btnDownload_Click(sender As Object, e As System.EventArgs) Handles btnDownload.Click
        download()
        btnDownload.Visible = False
    End Sub
    Private Function prepareObjectFroUploadData() As ExtUploadFile
        Dim pUploadData As New ExtUploadFile
        pUploadData.CreatedBy = Session.Item("LoginUser")
        pUploadData.TerminalId = Session.Item("LoginTerminal")
        pUploadData.FileName = fuFileLocation.FileName
        pUploadData.UploadFileDataList = New ArrayList
        Try
            Dim fileobj As HttpPostedFile = fuFileLocation.PostedFile
            Dim objStreamReader As System.IO.StreamReader
            Dim strLine As String = ""
            Dim index As Long = 1
            If fileobj IsNot Nothing Then
                objStreamReader = New System.IO.StreamReader(fileobj.InputStream)
                strLine = objStreamReader.ReadLine
                Do While Not strLine Is Nothing
                    Dim p As New UploadFileData
                    p.FileData = strLine
                    p.RecordId = index
                    p.TerminalId = Session.Item("LoginTerminal")
                    pUploadData.UploadFileDataList.Add(p)
                    index += 1
                    strLine = objStreamReader.ReadLine
                Loop
            End If
        Catch ex As Exception
        End Try
        Return pUploadData
    End Function

    Protected Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pExtUploadFile As ExtUploadFile = prepareObjectFroUploadData()
        ExtUploadFile.UploadFileDataIGM(pExtUploadFile)
        If pExtUploadFile.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pExtUploadFile.Errormsg)
            Return
        End If
        Dim pAllPartyAccount As New AllPartyAccount
        pAllPartyAccount.TrackId = pExtUploadFile.FileId
        Try
            hdnFileId.Value = pExtUploadFile.FileId
        Catch ex As Exception
            hdnFileId.Value = 0
        End Try
        pAllPartyAccount.CreatedBy = Session.Item("LoginUser")
        AllPartyAccount.UploadVesselFileId(pAllPartyAccount)
        If pAllPartyAccount.Errormsg <> Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, pAllPartyAccount.Errormsg)
            Return
        End If
        Try
            hdnCheckUpload.Value = "Upload"
        Catch ex As Exception

        End Try
        prepareTerminalData()
        preparePortData()
        ' prepareCustomerData()
        preparePortDataPOD()
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= hdnFileId.Value
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_VESSEL_UPLOAD", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
            btnupdate.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
        linkDownload.Visible = False
        btnDownload.Visible = True
        btnUpload.Visible = False
    End Sub


    Sub download()

        Dim strConnString As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        Dim con As New OleDbConnection(strConnString)
        Dim cmd As New OleDbCommand()
        Dim ad As New OleDbDataAdapter()
        Dim ds As New DataSet
        cmd.CommandType = CommandType.StoredProcedure
        Try
            If hdnFileId.Value = Nothing Then
                hdnFileId.Value = 0
            End If
            If hdnFileId.Value = Nothing Then
                hdnFileId.Value = 0
            End If
        Catch ex As Exception
            hdnFileId.Value = 0
        End Try
        cmd.CommandText = "REPORT_PKG.SP_AP_REPORT_DOCUMEN_DOW"
        cmd.Parameters.AddWithValue("@p_TERMINAL_ID", Session.Item("LoginTerminal"))
        cmd.Parameters.AddWithValue("@p_FILE_ID", hdnFileId.Value)
        cmd.Parameters.AddWithValue("@p_STATUS", "P")
        cmd.Connection = con
        Try
            con.Open()
            cmd.CommandTimeout = 72000
            ad.SelectCommand = cmd
            ad.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim filename As String = "All Party Documnet Uploaded Status.xls"
                Dim tw As System.IO.StringWriter = New System.IO.StringWriter()
                Dim hw As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(tw)
                Dim dgGrid As DataGrid = New DataGrid()
                dgGrid.DataSource = ds.Tables(0)
                dgGrid.DataBind()
                dgGrid.RenderControl(hw)
                Response.ContentType = "application/vnd.ms-excel"
                Response.AppendHeader("Content-Disposition", "attachment; filename=" & filename & "")
                'Response.TransmitFile(Server.MapPath(filename))
                Me.EnableViewState = False
                Response.Write(tw.ToString())
                Response.[End]()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Sub
    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvInvoiceReport)
    End Sub

End Class
