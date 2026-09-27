Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services

Partial Class Reports_Fleet_DocumentUpdataion1
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
    '<WebMethod()>
    'Public Shared Function GetCustomerName(ByVal prefix As String) As String()
    '    Dim customers As New List(Of String)()
    '    Using conn As New OleDbConnection()
    '        conn.ConnectionString = ConfigurationManager.AppSettings("DBConnectionString")
    '        Using cmd As New OleDbCommand()
    '            cmd.CommandText = "SELECT DISTINCT CUSTOMER_NAME,CUSTOMER_ID FROM CUSTOMER_MASTER  WHERE CUSTOMER_NAME like ('%" + prefix + "%') AND CUSTOMER_TYPE='E'  ORDER BY CUSTOMER_NAME ASC"
    '            'cmd.Parameters.AddWithValue("@SearchText", prefix)
    '            cmd.Connection = conn
    '            conn.Open()
    '            Dim dr As OleDbDataReader = cmd.ExecuteReader()
    '            While dr.Read()
    '                'customers.Add(String.Format("{0}.{1}", dr("CUSTOMER_NAME"), dr("GR_ID")))
    '                customers.Add(String.Format("{0}/{1}", dr("CUSTOMER_NAME"), dr("CUSTOMER_ID")))
    '            End While
    '            conn.Close()
    '        End Using
    '    End Using
    '    Return customers.ToArray()
    'End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ListControlDataBind()
            'prepareTerminalData()
            'prepareCustomerData()
            'preparePortData()
            'preparePortDataPOD()
            'BindData()

        End If

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

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue & ",'','','P'"
        strpParms &= "," & LstLine.SelectedValue & "," & lstPod.SelectedValue
        strpParms &= ",'" & TextInvNo.Text.Trim & "'"
        strpParms &= "," & lstdremark.SelectedValue
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_AP_REPORT_DOCUMENTATION", strpParms)
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
        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue & ",'','','P'"
        strpParms &= "," & LstLine.SelectedValue & "," & lstPod.SelectedValue
        strpParms &= ",'" & TextInvNo.Text.Trim & "'"
        strpParms &= "," & lstdremark.SelectedValue

        'strpParms &= ",'" & textFromDate.Text & "'"
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_AP_REPORT_DOCUMENTATION", strpParms)
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
        Try
            TextCrtns.Text = ""
            TextNetwt.Text = ""
            TextGWt.Text = ""
            texthandoverDate.Text = ""
            LstUPod.SelectedValue = 0
            lstuPOL.SelectedValue = 0
        Catch ex As Exception

        End Try

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
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            lstCFS.DataTextField = "TerminalName"
            lstCFS.DataValueField = "TerminalId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
            Dim pCustomerMaster As New CustomerMaster
            LstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            LstLine.DataTextField = "CustomerName"
            LstLine.DataValueField = "CustomerId"
            LstLine.DataBind()
            LstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            LstLine.SelectedValue = 0
            Dim pPol As New PortMaster
            lstuPOL.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPol)
            lstuPOL.DataTextField = "PortName"
            lstuPOL.DataValueField = "PortId"
            Try
                lstuPOL.DataBind()
            Catch ex As Exception

            End Try

            lstuPOL.Items.Insert(0, (New ListItem("---All---", 0)))
            lstuPOL.SelectedValue = 0
            Dim pPod As New PortMaster
            LstUPod.DataSource = PortMaster.ReturnPortMasterList(pPod)
            LstUPod.DataTextField = "PortName"
            LstUPod.DataValueField = "PortId"
            LstUPod.DataBind()
            LstUPod.Items.Insert(0, (New ListItem("---All---", 0)))
            LstUPod.SelectedValue = 0
            Dim pPortMaster As New PortMaster
            lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            lstPod.DataTextField = "PortName"
            lstPod.DataValueField = "PortId"
            lstPod.DataBind()
            lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPod.SelectedValue = 0


        Catch ex As Exception
        End Try
    End Sub

    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
        End If

    End Sub
    Protected Sub EditAllParty(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvInvoiceReport.EditIndex = e.NewEditIndex
        'BindData()
    End Sub

    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvInvoiceReport.EditIndex = -1
        'BindData()
    End Sub
    'Protected Sub AllPartyUpdate(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    '    Dim hdnMTY_CONT_ID As HiddenField = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '    Dim TextConsignor As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextConsignor"), DropDownList)
    '    Dim TextConsignee As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextConsignee"), TextBox)
    '    Dim TextBlNo As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextBlNo"), TextBox)
    '    Dim TextBookingNo As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextBookingNo"), TextBox)
    '    Dim TextSbNo As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextSbNo"), TextBox)
    '    Dim TextSbDate As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextSbDate"), TextBox)
    '    Dim LstSbReceived As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("LstSbReceived"), DropDownList)
    '    Dim TextPacket As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextPacket"), TextBox)
    '    Dim TextWeight As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextWeight"), TextBox)
    '    Dim TextGrossWeight As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextGrossWeight"), TextBox)
    '    Dim TextCustomHandover As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextCustomHandover"), TextBox)
    '    Dim TextLineHandover As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextLineHandover"), TextBox)
    '    Dim TextPartyInvoiceNO As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextPartyInvoiceNO"), TextBox)
    '    Dim TextPartyInvoicedate As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextPartyInvoicedate"), TextBox)
    '    Dim TextHeathNo As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextHeathNo"), TextBox)
    '    Dim Lstcfs As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("Lstcfs"), DropDownList)
    '    Dim Lstpol As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("Lstpol"), DropDownList)
    '    Dim Lstpod As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("Lstpod"), DropDownList)
    '    Dim LstRemark As DropDownList = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("LstRemark"), DropDownList)
    '    Dim lblContNO As Label = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("lblContNO"), Label)
    '    Dim TextPcs As TextBox = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextPcs"), TextBox)
    '    Dim TextCube As Label = TryCast(gvInvoiceReport.Rows(e.RowIndex).FindControl("TextCube"), Label)
    '    If TextLineHandover.Text <> Nothing Then
    '        If TextConsignee.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Consignee Name.")
    '            Functions.ControlFocus(TextConsignee)
    '            Return
    '        End If
    '        If TextBookingNo.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Booking No.")
    '            Functions.ControlFocus(TextBookingNo)
    '            Return
    '        End If
    '        If TextSbDate.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB Date.")
    '            Functions.ControlFocus(TextSbDate)
    '            Return
    '        End If
    '        If TextSbNo.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB No.")
    '            Functions.ControlFocus(TextSbNo)
    '            Return
    '        End If

    '        If TextPacket.Text = Nothing Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Packet.")
    '            Functions.ControlFocus(TextPacket)
    '            Return
    '        End If
    '        If TextWeight.Text = Nothing Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter weight.")
    '            Functions.ControlFocus(TextWeight)
    '            Return
    '        End If
    '        If TextCustomHandover.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Custom Handover Date.")
    '            Functions.ControlFocus(TextCustomHandover)
    '            Return
    '        End If
    '        If TextLineHandover.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Line Handover Date.")
    '            Functions.ControlFocus(TextLineHandover)
    '            Return
    '        End If
    '        If TextPartyInvoicedate.Text = Nothing Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date.")
    '            Functions.ControlFocus(TextPartyInvoicedate)
    '            Return
    '        End If
    '        If TextPartyInvoiceNO.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice No.")
    '            Functions.ControlFocus(TextPartyInvoiceNO)
    '            Return
    '        End If
    '        If TextHeathNo.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Health No.")
    '            Functions.ControlFocus(TextHeathNo)
    '            Return
    '        End If
    '        If Lstpol.SelectedValue = 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select POL.")
    '            Functions.ControlFocus(Lstpol)
    '            Return
    '        End If
    '        If Lstpod.SelectedValue = 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select POD.")
    '            Functions.ControlFocus(Lstpod)
    '            Return
    '        End If
    '        If Lstcfs.SelectedValue = 0 Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select CFS.")
    '            Functions.ControlFocus(Lstcfs)
    '            Return
    '        End If
    '    End If

    '    con = New OleDbConnection(cs)
    '    con.Open()
    '    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET PCS=NVL('" & TextPcs.Text.Trim & "',0),CUBE=NVL('" & TextCube.Text.Trim & "',0),POL_ID=" & Lstpol.SelectedValue & ",POD_ID=" & Lstpod.SelectedValue & ",HOLD_REMARK_ID=nvl(" & LstRemark.SelectedValue & ",0),HOLD_REMARK=nvl('" & LstRemark.SelectedItem.Text & "',''),CONSIGNOR_NAME=nvl('" & TextConsignor.SelectedValue.Trim & "',''),CONSIGNOR_ID=" & TextConsignor.SelectedValue & ",CONSINGEE_NAME=nvl('" & TextConsignee.Text & "',''),POL=nvl('" & Lstpol.SelectedItem.Text & "',''), " _
    '            & " BOOKING_NO=nvl('" & TextBookingNo.Text & "',''),HEALTH_CERTIFICATE_NO=nvl('" & TextHeathNo.Text & "',''),SB_RECEIVED=nvl('" & LstSbReceived.SelectedItem.Text & "',''), " _
    '            & " CARTONS=nvl('" & TextPacket.Text & "',''),NET_WT=nvl('" & TextWeight.Text & "',''),GROSS_WT=nvl('" & TextGrossWeight.Text & "',''),CFS=nvl('" & Lstcfs.SelectedItem.Text & "',''),CFS_ID=nvl(" & Lstcfs.SelectedValue & ",0), " _
    '            & " CUSTOMS_HANDOVER_DATE=TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
    '            & " PORT=NVL('" & Lstpod.SelectedItem.Text & "',''),BL_NO=NVL('" & TextBlNo.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
    '            & " PARTY_INV_DATE=NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),SB_NO=NVL('" & TextSbNo.Text.Trim & "',''), " _
    '            & " SB_DATE=NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),''),POD_ID=NVL(" & Lstpod.SelectedValue & ",0) WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    cmd.ExecuteNonQuery()
    '    Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE FLEET_GR_MAPPING SET POL = " & Lstpol.SelectedValue & ",POD=" & Lstpod.SelectedValue & ",CHA_ID=" & Lstcfs.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    cmd2.ExecuteNonQuery()
    '    con.Close()
    '    Dim strConnectionString, cmd1 As String
    '    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '    cmd1 = " Insert into ALL_PARTY_DOCUMENT (PCS,CUBE,D_TRACK_ID, POL_ID, POD_ID, HOLD_REMARK_ID, HOLD_REMARK, SHIPPER_NAME, CONSINGEE_NAME, POL, BOOKING_NO, HEALTH_CERTIFICATE_NO, " _
    '            & " SB_RECEIVED, CARTONS, NET_WT, GROSS_WT, CFS, CFS_ID, PORT, BL_NO, PARTY_INV_NO, PARTY_INV_DATE,SB_NO, SB_DATE, MTY_CONT_ID, CONT_NO, CREATED_BY, CREATED_ON) " _
    '            & " VALUES (NVL('" & TextPcs.Text.Trim & "',0),NVL('" & TextCube.Text.Trim & "',0),D_TRACK_ID.NEXTVAL," & Lstpol.SelectedValue & "," & Lstpod.SelectedValue & ",nvl(" & LstRemark.SelectedValue & ",0),nvl('" & LstRemark.SelectedItem.Text & "',''),nvl('" & TextConsignor.SelectedItem.Text & "',''),nvl('" & TextConsignee.Text & "',''),nvl('" & Lstpol.SelectedItem.Text & "',''), " _
    '            & " nvl('" & TextBookingNo.Text & "',''),nvl('" & TextHeathNo.Text & "',''),nvl('" & LstSbReceived.SelectedItem.Text & "',''), " _
    '            & " nvl('" & TextPacket.Text & "',''),nvl('" & TextWeight.Text & "',''),nvl('" & TextGrossWeight.Text & "',''),nvl('" & Lstcfs.SelectedItem.Text & "',''),nvl(" & Lstcfs.SelectedValue & ",0), " _
    '            & " TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
    '            & " NVL('" & Lstpod.SelectedItem.Text & "',''),NVL('" & TextBlNo.Text.Trim & "',''),NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
    '            & " NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),NVL('" & TextSbNo.Text.Trim & "',''), " _
    '            & " NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),''), " & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate)"
    '    'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    con = New OleDbConnection(strConnectionString)
    '    con.Open()
    '    Dim cmd5 As New OleDbCommand(cmd1, con)
    '    cmd5.ExecuteNonQuery()
    '    ' cmd1.ExecuteNonQuery()

    '    gvInvoiceReport.EditIndex = -1
    '    BindData()
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    'End Sub
    'Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
    '    For Each row As GridViewRow In gvInvoiceReport.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then

    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim TextShipper As TextBox = TryCast(row.Cells(0).FindControl("TextShipper"), TextBox)
    '                Dim TextConsignee As TextBox = TryCast(row.Cells(0).FindControl("TextConsignee"), TextBox)
    '                Dim TextBlNo As TextBox = TryCast(row.Cells(0).FindControl("TextBlNo"), TextBox)
    '                Dim TextBookingNo As TextBox = TryCast(row.Cells(0).FindControl("TextBookingNo"), TextBox)
    '                Dim TextSbNo As TextBox = TryCast(row.Cells(0).FindControl("TextSbNo"), TextBox)
    '                Dim TextSbDate As TextBox = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox) 'TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox)
    '                Dim LstSbReceived As DropDownList = TryCast(row.Cells(0).FindControl("LstSbReceived"), DropDownList)
    '                Dim TextPacket As TextBox = TryCast(row.Cells(0).FindControl("TextPacket"), TextBox)
    '                Dim TextWeight As TextBox = TryCast(row.Cells(0).FindControl("TextWeight"), TextBox)
    '                Dim TextGrossWeight As TextBox = TryCast(row.Cells(0).FindControl("TextGrossWeight"), TextBox)
    '                Dim TextCustomHandover As TextBox = TryCast(row.Cells(0).FindControl("TextCustomHandover"), TextBox)
    '                Dim TextLineHandover As TextBox = TryCast(row.Cells(0).FindControl("TextLineHandover"), TextBox)
    '                Dim TextPartyInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoiceNO"), TextBox)
    '                Dim TextPartyInvoicedate As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoicedate"), TextBox)
    '                Dim TextHeathNo As TextBox = TryCast(row.Cells(0).FindControl("TextHeathNo"), TextBox)
    '                Dim Lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("Lstcfs"), DropDownList)
    '                Dim Lstpol As DropDownList = TryCast(row.Cells(0).FindControl("Lstpol"), DropDownList)
    '                Dim Lstpod As DropDownList = TryCast(row.Cells(0).FindControl("Lstpod"), DropDownList)
    '                Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
    '                Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)

    '                Dim POL As Long = 0
    '                Dim POD As Long = 0
    '                Dim Remark As Long = 0
    '                Dim sbdate As String = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox).Text
    '                Try
    '                    POL = Lstpol.SelectedValue
    '                Catch ex As Exception
    '                    POL = 0
    '                End Try
    '                Try
    '                    POD = Lstpod.SelectedValue
    '                Catch ex As Exception
    '                    POD = 0
    '                End Try
    '                Try
    '                    Remark = LstRemark.SelectedValue
    '                Catch ex As Exception
    '                    Remark = 0
    '                End Try
    '                If TextLineHandover.Text <> Nothing Then
    '                    Try
    '                        If TextConsignee.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Consignee Name.")
    '                            Functions.ControlFocus(TextConsignee)
    '                            Return
    '                        End If
    '                        If TextBookingNo.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Booking No.")
    '                            Functions.ControlFocus(TextBookingNo)
    '                            Return
    '                        End If
    '                        If sbdate = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB Date.")
    '                            Functions.ControlFocus(TextSbDate)
    '                            Return
    '                        End If
    '                        If TextSbDate.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB Date.")
    '                            Functions.ControlFocus(TextSbDate)
    '                            Return
    '                        End If
    '                        If TextSbNo.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB No.")
    '                            Functions.ControlFocus(TextSbNo)
    '                            Return
    '                        End If

    '                        If TextPacket.Text = Nothing Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Packet.")
    '                            Functions.ControlFocus(TextPacket)
    '                            Return
    '                        End If
    '                        If TextWeight.Text = Nothing Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter weight.")
    '                            Functions.ControlFocus(TextWeight)
    '                            Return
    '                        End If
    '                        If TextCustomHandover.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Custom Handover Date.")
    '                            Functions.ControlFocus(TextCustomHandover)
    '                            Return
    '                        End If
    '                        If TextLineHandover.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Line Handover Date.")
    '                            Functions.ControlFocus(TextLineHandover)
    '                            Return
    '                        End If
    '                        If TextPartyInvoicedate.Text = Nothing Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date.")
    '                            Functions.ControlFocus(TextPartyInvoicedate)
    '                            Return
    '                        End If
    '                        If TextPartyInvoiceNO.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice No.")
    '                            Functions.ControlFocus(TextPartyInvoiceNO)
    '                            Return
    '                        End If
    '                        If TextHeathNo.Text = "" Then
    '                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Health No.")
    '                            Functions.ControlFocus(TextHeathNo)
    '                            Return
    '                        End If
    '                        'If Lstpol.SelectedValue = 0 Then
    '                        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select POL.")
    '                        '    Functions.ControlFocus(Lstpol)
    '                        '    Return
    '                        'End If
    '                        'If Lstpod.SelectedValue = 0 Then
    '                        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select POD.")
    '                        '    Functions.ControlFocus(Lstpod)
    '                        '    Return
    '                        'End If
    '                        'If Lstcfs.SelectedValue = 0 Then
    '                        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select CFS.")
    '                        '    Functions.ControlFocus(Lstcfs)
    '                        '    Return
    '                        'End If
    '                    Catch ex As Exception

    '                    End Try

    '                End If

    '                con = New OleDbConnection(cs)
    '                con.Open()
    '                Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET POL_ID=NVL(" & POL & ",0),POD_ID=NVL(" & POD & ",0),HOLD_REMARK_ID=NVL(" & Remark & ",0),HOLD_REMARK='" & LstRemark.SelectedItem.Text & "',SHIPPER_NAME='" & TextShipper.Text.Trim & "',CONSINGEE_NAME='" & TextConsignee.Text & "',POL='" & Lstpol.SelectedItem.Text & "', " _
    '                                         & " BOOKING_NO='" & TextBookingNo.Text & "',HEALTH_CERTIFICATE_NO='" & TextHeathNo.Text & "',SB_RECEIVED='" & LstSbReceived.SelectedItem.Text & "', " _
    '                                         & " CARTONS='" & TextPacket.Text & "',NET_WT='" & TextWeight.Text & "',GROSS_WT='" & TextGrossWeight.Text & "',CFS='" & Lstcfs.SelectedItem.Text & "',CFS_ID='" & Lstcfs.SelectedValue & "', " _
    '                                         & " CUSTOMS_HANDOVER_DATE=TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
    '                                         & " PORT=NVL('" & Lstpod.SelectedItem.Text & "',''),BL_NO=NVL('" & TextBlNo.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
    '                                         & " PARTY_INV_DATE=NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),SB_NO=NVL('" & TextSbNo.Text.Trim & "',''), " _
    '                                         & " SB_DATE=NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),'') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                cmd.ExecuteNonQuery()
    '                Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE FLEET_GR_MAPPING SET POL = " & Lstpol.SelectedValue & ",FPOD=" & Lstpod.SelectedValue & ",CHA_ID=" & Lstcfs.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                cmd2.ExecuteNonQuery()
    '                con.Close()
    '                Dim strConnectionString, cmd1 As String
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                cmd1 = " Insert into ALL_PARTY_DOCUMENT (D_TRACK_ID, POL_ID, POD_ID, HOLD_REMARK_ID, HOLD_REMARK, SHIPPER_NAME, CONSINGEE_NAME, POL, BOOKING_NO, HEALTH_CERTIFICATE_NO, " _
    '                        & " SB_RECEIVED, CARTONS, NET_WT, GROSS_WT, CFS, CFS_ID,CUSTOMS_HANDOVER_DATE,LINE_HANDOVER_DATE, PORT, BL_NO, PARTY_INV_NO, PARTY_INV_DATE,SB_NO, SB_DATE, MTY_CONT_ID, CONT_NO, CREATED_BY, CREATED_ON) " _
    '                        & " VALUES (D_TRACK_ID.NEXTVAL," & Lstpol.SelectedValue & "," & Lstpod.SelectedValue & ",nvl(" & LstRemark.SelectedValue & ",0),nvl('" & LstRemark.SelectedItem.Text & "',''),nvl('" & TextShipper.Text.Trim & "',''),nvl('" & TextConsignee.Text & "',''),nvl('" & Lstpol.SelectedItem.Text & "',''), " _
    '                        & " nvl('" & TextBookingNo.Text & "',''),nvl('" & TextHeathNo.Text & "',''),nvl('" & LstSbReceived.SelectedItem.Text & "',''), " _
    '                        & " nvl('" & TextPacket.Text & "',''),nvl('" & TextWeight.Text & "',''),nvl('" & TextGrossWeight.Text & "',''),nvl('" & Lstcfs.SelectedItem.Text & "',''),nvl(" & Lstcfs.SelectedValue & ",0), " _
    '                        & " TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
    '                        & " NVL('" & Lstpod.SelectedItem.Text & "',''),NVL('" & TextBlNo.Text.Trim & "',''),NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
    '                        & " NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),NVL('" & TextSbNo.Text.Trim & "',''), " _
    '                        & " NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),''), " & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate)"
    '                'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd5 As New OleDbCommand(cmd1, con)
    '                cmd5.ExecuteNonQuery()
    '                gvInvoiceReport.EditIndex = -1
    '                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    '            End If
    '        End If
    '    Next
    '    ImgBtnUpdate.Visible = False
    '    BindData()
    'End Sub

    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvInvoiceReport.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                End If
            Next
        End If
        Dim chkAll As CheckBox = TryCast(gvInvoiceReport.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim Lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("Lstcfs"), DropDownList)
                    Dim Lstpol As DropDownList = TryCast(row.Cells(0).FindControl("Lstpol"), DropDownList)
                    Dim Lstpod As DropDownList = TryCast(row.Cells(0).FindControl("Lstpod"), DropDownList)
                    Dim TxtShipper As TextBox = TryCast(row.Cells(0).FindControl("TextShipper"), TextBox)
                    Dim TxtConsignee As TextBox = TryCast(row.Cells(0).FindControl("TextConsignee"), TextBox)
                    Dim TextPacket As TextBox = TryCast(row.Cells(0).FindControl("TextPacket"), TextBox)
                    Dim TextWeight As TextBox = TryCast(row.Cells(0).FindControl("TextWeight"), TextBox)
                    Dim TextGrossWeight As TextBox = TryCast(row.Cells(0).FindControl("TextGrossWeight"), TextBox)
                    Dim TextCustomHandover As TextBox = TryCast(row.Cells(0).FindControl("TextCustomHandover"), TextBox)
                    Dim TextLineHandover As TextBox = TryCast(row.Cells(0).FindControl("TextLineHandover"), TextBox)
                    'Dim TextConsignor As DropDownList = TryCast(row.Cells(0).FindControl("TextConsignor"), DropDownList)
                    'prepareTerminalData()
                    'prepareCustomerData()
                    'preparePortData()
                    'preparePortDataPOD()
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT nvl(POL_ID,0),NVL(POD_ID,0),NVL(CFS_ID,0),PORT,POL,CFS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                    ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                    Try
                        Lstpol.SelectedValue = ada.GetValue(0)
                    Catch ex As Exception
                    End Try
                    Try
                        Lstpod.SelectedValue = ada.GetValue(1)
                    Catch ex As Exception
                    End Try
                    Try
                        Lstcfs.SelectedValue = ada.GetValue(2)
                    Catch ex As Exception
                    End Try

                    Try
                        If Lstpol.SelectedValue = 0 Then
                            If lstuPOL.SelectedValue > 0 Then
                                con = New OleDbConnection(cs)
                                con.Open()
                                Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET pol_id=" & lstuPOL.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                                cmd2.ExecuteNonQuery()
                                con.Close()
                                Lstpol.SelectedValue = lstuPOL.SelectedValue
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Lstpod.SelectedValue = 0 Then
                            If LstUPod.SelectedValue > 0 Then
                                con = New OleDbConnection(cs)
                                con.Open()
                                Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET pod_id=" & LstUPod.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                                cmd2.ExecuteNonQuery()
                                con.Close()
                                Lstpod.SelectedValue = LstUPod.SelectedValue
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If TextPacket.Text = "" Then
                            If TextCrtns.Text <> "" Then
                                TextPacket.Text = TextCrtns.Text
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If TextWeight.Text = 0 Then
                            If TextNetwt.Text <> "" Then
                                TextWeight.Text = TextNetwt.Text
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If TextGrossWeight.Text = 0 Then
                            If TextGWt.Text <> "" Then
                                TextGrossWeight.Text = TextGWt.Text
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    If TextCustomHandover.Text = "" Then
                        If texthandoverDate.Text <> "" Then
                            TextCustomHandover.Text = texthandoverDate.Text
                        End If
                    End If
                    If TextLineHandover.Text = "" Then
                        If texthandoverDate.Text <> "" Then
                            TextLineHandover.Text = texthandoverDate.Text
                        End If
                    End If
                End If
            End If
        Next
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
                    row.Cells(i).FindControl("lblHoldremark").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPort").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPol").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCFS").Visible = Not isChecked
                    row.Cells(i).FindControl("lblHealthNo").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPartyInvoiceDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPartyInvocieNO").Visible = Not isChecked
                    row.Cells(i).FindControl("lbllineHandover").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCustomHandover").Visible = Not isChecked
                    row.Cells(i).FindControl("lblGrossWt").Visible = Not isChecked
                    row.Cells(i).FindControl("lblWeight").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPacket").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSbReceived").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSbDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblSbNO").Visible = Not isChecked
                    row.Cells(i).FindControl("lblBookingNo").Visible = Not isChecked
                    row.Cells(i).FindControl("lblBlNo").Visible = Not isChecked
                    row.Cells(i).FindControl("lblConsignee").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblConsignor").Visible = Not isChecked
                    row.Cells(i).FindControl("lblCube").Visible = Not isChecked
                    row.Cells(i).FindControl("lblPcs").Visible = Not isChecked
                    row.Cells(i).FindControl("lblConsignmentType").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblShipper").Visible = Not isChecked

                    If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
                    End If
                    If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    End If
                    'If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                    '    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    'End If
                    If isChecked AndAlso Not isUpdateVisible Then
                        isUpdateVisible = True
                    End If
                    If Not isChecked Then
                        chkAll.Checked = False
                    End If
                Next
            End If
        Next
        'ImgBtnUpdate.Visible = isUpdateVisible
    End Sub

    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim HdnContJOId As HiddenField = TryCast(row.Cells(0).FindControl("HdnContJOId"), HiddenField)
                    Dim hdnInDate As HiddenField = TryCast(row.Cells(0).FindControl("hdnInDate"), HiddenField)
                    'Dim TextConsignor As DropDownList = TryCast(row.Cells(0).FindControl("TextConsignor"), DropDownList)
                    'Dim TextShipper As TextBox = TryCast(row.Cells(0).FindControl("TextShipper"), TextBox)
                    Dim TextConsignee As TextBox = TryCast(row.Cells(0).FindControl("TextConsignee"), TextBox)
                    Dim TextBlNo As TextBox = TryCast(row.Cells(0).FindControl("TextBlNo"), TextBox)
                    Dim TextBookingNo As TextBox = TryCast(row.Cells(0).FindControl("TextBookingNo"), TextBox)
                    Dim TextSbNo As TextBox = TryCast(row.Cells(0).FindControl("TextSbNo"), TextBox)
                    Dim TextSbDate As TextBox = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox) 'TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox)
                    Dim LstSbReceived As DropDownList = TryCast(row.Cells(0).FindControl("LstSbReceived"), DropDownList)
                    Dim TextPacket As TextBox = TryCast(row.Cells(0).FindControl("TextPacket"), TextBox)
                    Dim TextWeight As TextBox = TryCast(row.Cells(0).FindControl("TextWeight"), TextBox)
                    Dim TextGrossWeight As TextBox = TryCast(row.Cells(0).FindControl("TextGrossWeight"), TextBox)
                    Dim TextCustomHandover As TextBox = TryCast(row.Cells(0).FindControl("TextCustomHandover"), TextBox)
                    Dim TextLineHandover As TextBox = TryCast(row.Cells(0).FindControl("TextLineHandover"), TextBox)
                    Dim TextPartyInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoiceNO"), TextBox)
                    Dim TextPartyInvoicedate As TextBox = TryCast(row.Cells(0).FindControl("TextPartyInvoicedate"), TextBox)
                    Dim TextHeathNo As TextBox = TryCast(row.Cells(0).FindControl("TextHeathNo"), TextBox)
                    Dim Lstcfs As DropDownList = TryCast(row.Cells(0).FindControl("Lstcfs"), DropDownList)
                    Dim Lstpol As DropDownList = TryCast(row.Cells(0).FindControl("Lstpol"), DropDownList)
                    Dim Lstpod As DropDownList = TryCast(row.Cells(0).FindControl("Lstpod"), DropDownList)
                    Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                    Dim LstConsignmentType As DropDownList = TryCast(row.Cells(0).FindControl("LstConsignmentType"), DropDownList)
                    Dim POL As Long = 0
                    Dim POD As Long = 0
                    Dim Remark As Long = 0
                    Dim sbdate As String = TryCast(row.Cells(0).FindControl("TextSbDate"), TextBox).Text
                    Try
                        POL = Lstpol.SelectedValue
                    Catch ex As Exception
                        POL = 0
                    End Try
                    Try
                        POD = Lstpod.SelectedValue
                    Catch ex As Exception
                        POD = 0
                    End Try
                    Try
                        Remark = LstRemark.SelectedValue
                    Catch ex As Exception
                        Remark = 0
                    End Try
                    If TextLineHandover.Text <> Nothing Then
                        Try
                            If TextConsignee.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Consignee Name.")
                                Functions.ControlFocus(TextConsignee)
                                Return
                            End If
                            If TextBookingNo.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Booking No.")
                                Functions.ControlFocus(TextBookingNo)
                                Return
                            End If
                            If sbdate = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB Date.")
                                Functions.ControlFocus(TextSbDate)
                                Return
                            End If
                            If TextSbDate.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB Date.")
                                Functions.ControlFocus(TextSbDate)
                                Return
                            End If
                            If TextSbNo.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter SB No.")
                                Functions.ControlFocus(TextSbNo)
                                Return
                            End If

                            If TextPacket.Text = Nothing Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Packet.")
                                Functions.ControlFocus(TextPacket)
                                Return
                            End If
                            If TextWeight.Text = Nothing Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter weight.")
                                Functions.ControlFocus(TextWeight)
                                Return
                            End If
                            If TextCustomHandover.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Custom Handover Date.")
                                Functions.ControlFocus(TextCustomHandover)
                                Return
                            End If
                            If TextLineHandover.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Line Handover Date.")
                                Functions.ControlFocus(TextLineHandover)
                                Return
                            End If
                            If TextPartyInvoicedate.Text = Nothing Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date.")
                                Functions.ControlFocus(TextPartyInvoicedate)
                                Return
                            End If
                            If TextPartyInvoiceNO.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice No.")
                                Functions.ControlFocus(TextPartyInvoiceNO)
                                Return
                            End If
                            If TextHeathNo.Text = "" Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Health No.")
                                Functions.ControlFocus(TextHeathNo)
                                Return
                            End If
                            If LstConsignmentType.SelectedValue = 0 Then
                                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select Consignment Type.")
                                Functions.ControlFocus(LstConsignmentType)
                                Return
                            End If
                            'If Lstpod.SelectedValue = 0 Then
                            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select POD.")
                            '    Functions.ControlFocus(Lstpod)
                            '    Return
                            'End If
                            'If Lstcfs.SelectedValue = 0 Then
                            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select CFS.")
                            '    Functions.ControlFocus(Lstcfs)
                            '    Return
                            'End If
                        Catch ex As Exception

                        End Try

                    End If

                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CONSIGNMENT_TYPE='" & LstConsignmentType.SelectedItem.Text & "',CONSIGNMENT_TYPE_ID=" & LstConsignmentType.SelectedValue & ", POL_ID=NVL(" & POL & ",0),POD_ID=NVL(" & POD & ",0),HOLD_REMARK_ID=NVL(" & Remark & ",0),HOLD_REMARK='" & LstRemark.SelectedItem.Text & "',CONSINGEE_NAME='" & TextConsignee.Text & "',POL='" & Lstpol.SelectedItem.Text & "', " _
                                             & " BOOKING_NO='" & TextBookingNo.Text & "',HEALTH_CERTIFICATE_NO='" & TextHeathNo.Text & "',SB_RECEIVED='" & LstSbReceived.SelectedItem.Text & "', " _
                                             & " CARTONS='" & TextPacket.Text & "',NET_WT='" & TextWeight.Text & "',GROSS_WT='" & TextGrossWeight.Text & "',CFS='" & Lstcfs.SelectedItem.Text & "',CFS_ID='" & Lstcfs.SelectedValue & "', " _
                                             & " CUSTOMS_HANDOVER_DATE=TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
                                             & " PORT=NVL('" & Lstpod.SelectedItem.Text & "',''),BL_NO=NVL('" & TextBlNo.Text.Trim & "',''),PARTY_INV_NO=NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
                                             & " PARTY_INV_DATE=NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),SB_NO=NVL('" & TextSbNo.Text.Trim & "',''), " _
                                             & " SB_DATE=NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),'') WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    cmd.ExecuteNonQuery()
                    Dim cmd2 As OleDbCommand = New OleDbCommand("UPDATE FLEET_GR_MAPPING SET POL = " & Lstpol.SelectedValue & ",FPOD=" & Lstpod.SelectedValue & " WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    cmd2.ExecuteNonQuery()
                    'Dim cmd4 As OleDbCommand = New OleDbCommand("UPDATE FLEET_CONT_JO SET CONSIGNEE_ID=" & TextConsignor.SelectedValue & " WHERE CONT_JO_ID= " & Convert.ToInt32(HdnContJOId.Value), con)
                    'cmd4.ExecuteNonQuery()
                    con.Close()
                    Dim strConnectionString, cmd1 As String
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = " Insert into ALL_PARTY_DOCUMENT (CONSIGNMENT_TYPE,CONSIGNMENT_TYPE_ID,D_TRACK_ID, POL_ID, POD_ID, HOLD_REMARK_ID, HOLD_REMARK, CONSINGEE_NAME, POL, BOOKING_NO, HEALTH_CERTIFICATE_NO, " _
                            & " SB_RECEIVED, CARTONS, NET_WT, GROSS_WT, CFS, CFS_ID,CUSTOMS_HANDOVER_DATE,LINE_HANDOVER_DATE, PORT, BL_NO, PARTY_INV_NO, PARTY_INV_DATE,SB_NO, SB_DATE, MTY_CONT_ID, CONT_NO, CREATED_BY, CREATED_ON) " _
                            & " VALUES ('" & LstConsignmentType.SelectedItem.Text & "'," & LstConsignmentType.SelectedValue & ",D_TRACK_ID.NEXTVAL," & Lstpol.SelectedValue & "," & Lstpod.SelectedValue & ",nvl(" & LstRemark.SelectedValue & ",0),nvl('" & LstRemark.SelectedItem.Text & "',''),nvl('" & TextConsignee.Text & "',''),nvl('" & Lstpol.SelectedItem.Text & "',''), " _
                            & " nvl('" & TextBookingNo.Text & "',''),nvl('" & TextHeathNo.Text & "',''),nvl('" & LstSbReceived.SelectedItem.Text & "',''), " _
                            & " nvl('" & TextPacket.Text & "',''),nvl('" & TextWeight.Text & "',''),nvl('" & TextGrossWeight.Text & "',''),nvl('" & Lstcfs.SelectedItem.Text & "',''),nvl(" & Lstcfs.SelectedValue & ",0), " _
                            & " TO_DATE('" & TextCustomHandover.Text & "','DD/MM/YYYY'), TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY')," _
                            & " NVL('" & Lstpod.SelectedItem.Text & "',''),NVL('" & TextBlNo.Text.Trim & "',''),NVL('" & TextPartyInvoiceNO.Text.Trim & "','')," _
                            & " NVL(TO_DATE('" & TextPartyInvoicedate.Text & "','DD/MM/YYYY'),''),NVL('" & TextSbNo.Text.Trim & "',''), " _
                            & " NVL(TO_DATE('" & TextSbDate.Text & "','DD/MM/YYYY HH24:MI'),''), " & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ",'" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate)"
                    'Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET CFS_ID=" & Convert.ToInt32(Lstcfs.SelectedValue) & ",CONSINGEE_NAME='" & TextConsignee.Text & "',BL_NO = '" & TextBlNo.Text & "',LINE_HANDOVER_DATE=TO_DATE('" & TextLineHandover.Text & "','DD/MM/YYYY'),POL = '" & Lstpol.SelectedItem.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd5 As New OleDbCommand(cmd1, con)
                    cmd5.ExecuteNonQuery()
                    'If TextLineHandover.Text = "" Then
                    '    If LstRemark.SelectedValue = 1 Or LstRemark.SelectedValue = 2 Or LstRemark.SelectedValue = 3 Or LstRemark.SelectedValue = 4 Or LstRemark.SelectedValue = 5 Or LstRemark.SelectedValue = 8 Then
                    '        Dim pStr As String = ""
                    '        Dim pMailConfig As New MailConfig
                    '        pMailConfig.TerminalId = Session.Item("LoginTerminal")
                    '        MailConfig.ReturnMailConfig(pMailConfig)
                    '        Dim SR As Long = 0
                    '        Dim confirmMail As New StringBuilder
                    '        confirmMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
                    '        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
                    '        confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='6'  >")
                    '        If LstRemark.SelectedValue = "1" Then
                    '            confirmMail.Append("<b>PENDING HEALTH CERTIFICATE</b>")
                    '        ElseIf LstRemark.SelectedValue = "2" Then
                    '            confirmMail.Append("<b>LOW PDA BALANCE</b>")
                    '        ElseIf LstRemark.SelectedValue = "3" Then
                    '            confirmMail.Append("<b>LOW TEMPERATURE</b>")
                    '        ElseIf LstRemark.SelectedValue = "4" Then
                    '            confirmMail.Append("<b>CUSTOM ISSUE</b>")
                    '        ElseIf LstRemark.SelectedValue = "5" Then
                    '            confirmMail.Append("<b>LOT INCOMPLETE</b>")
                    '        ElseIf LstRemark.SelectedValue = "8" Then
                    '            confirmMail.Append("<b>HOLIDAY</b>")
                    '        End If
                    '        confirmMail.Append(" </th>")
                    '        confirmMail.Append(" </tr>")
                    '        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
                    '        'confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
                    '        'confirmMail.Append("<b>Sr.</b>")
                    '        'confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 300px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>Party</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>Party Invoice No</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>ICD In</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>CFS</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>Cont No</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append("<b>Remarks</b>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append(" </tr>")
                    '        'xMailSetup.MailBody = ""
                    '        confirmMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
                    '        confirmMail.Append("<td style='width: 300px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append(TextConsignor.SelectedItem.Text)
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px'>")
                    '        Try
                    '            confirmMail.Append(TextPartyInvoiceNO.Text)
                    '        Catch ex As Exception
                    '            confirmMail.Append("Pending")
                    '        End Try
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        Try
                    '            confirmMail.Append(hdnInDate.Value)
                    '        Catch ex As Exception
                    '            confirmMail.Append("Pending")
                    '        End Try
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        Try
                    '            confirmMail.Append(Lstcfs.SelectedItem.Text)
                    '        Catch ex As Exception

                    '        End Try
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                    '        confirmMail.Append(lblContNO.Text)
                    '        confirmMail.Append(" </td>")
                    '        'confirmMail.Append("<font color='red'>Pending</font>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append("<td style='width: 200px; font-size: 10pt; height: 5px, color: red'>")
                    '        Try
                    '            confirmMail.Append(LstRemark.SelectedItem.Text)
                    '        Catch ex As Exception
                    '            confirmMail.Append("Pending")
                    '        End Try
                    '        'confirmMail.Append("<font color='red'>Pending</font>")
                    '        confirmMail.Append(" </td>")
                    '        confirmMail.Append(" </tr>")
                    '        confirmMail.Append("</table>")
                    '        Dim xMailSetup As String = ""
                    '        If LstRemark.SelectedValue = "1" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please note the health certificate is not received by us till now although the units are already gate into ICD. Request you to kindly arrange us health certificate to procceds for handover to Custom / Line.<br><br><br></font>"
                    '        ElseIf LstRemark.SelectedValue = "2" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please note the following units are not booked today due to low PDA Balance. Request you to kindly arrange urgently payment of train operator on priority in order to move below units.<br><br> We are still trying to convence train operator to move the same and have assured that your payments would be done very soon by your side. So please arrange their payment ASAP.<br><br> <br></font>"
                    '        ElseIf LstRemark.SelectedValue = "3" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please note the temprature for below units is not proper for handover. Kindly provide us current temprature and advise the issue related with the units. Hope the same will be rectified at your end ASAP. We need to book the container today so please provide us the quick assitance.<br><br><br></font>"
                    '        ElseIf LstRemark.SelectedValue = "4" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please note due to some customs issue, the below unit were not handover today. Regret for delay.<br><br><br></font>"
                    '        ElseIf LstRemark.SelectedValue = "5" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please not the lot of below units are not yet completed. Request you to kindly confirm lot & enable us to handover without any delay.<br><br><br></font>"
                    '        ElseIf LstRemark.SelectedValue = "8" Then
                    '            xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Due to holiday, Below units can not handover to custom today.<br><br>Please take a note of this.<br><br><br></font>"
                    '        End If
                    '        'cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY FROM MAIL_SETUP WHERE MENU_ID=23.6 AND TERMINAL_ID=1"
                    '        xMailSetup &= confirmMail.ToString
                    '        xMailSetup &= "<br/>"
                    '        xMailSetup &= "<br/>"
                    '        xMailSetup &= " " & "<br/>"
                    '        xMailSetup &= " " & "<br/>"
                    '        xMailSetup &= "<font color='#00008B'>Thanks n best regards, " & "<br><br>Vikash<br></font><br><b><font color='Red'>JSB CARGO MOVERS PVT. LTD.</b></font><font color='#00008B'><br>Regd. Office : Ground Floor, 61, Durga Park,Dallupura, Delhi-110096 <br> Admin Office : Room No-02, 636, Sector-1, Vaishali, Ghaziabad (U.P.) <br>Tel/Fax NO.: +91-120-4263512,0120-4263513,<br> Website:http://www.jsb.in </font>"


                    '        Dim subject As String = "" ' "Total Containers Not booked "
                    '        If LstRemark.SelectedValue = "1" Then
                    '            subject = "PENDING HEALTH CERTIFICATE"
                    '        ElseIf LstRemark.SelectedValue = "2" Then
                    '            subject = "LOW PDA BALANCE"
                    '        ElseIf LstRemark.SelectedValue = "3" Then
                    '            subject = "TEMPERATURE ISSUE"
                    '        ElseIf LstRemark.SelectedValue = "4" Then
                    '            subject = "CUSTOM ISSUE"
                    '        ElseIf LstRemark.SelectedValue = "5" Then
                    '            subject = "LOT INCOMPLETE"
                    '        ElseIf LstRemark.SelectedValue = "8" Then
                    '            subject = "HOLIDAY"
                    '        End If
                    '        subject &= " - " & lblContNO.Text
                    '        Dim adamailsetup As OleDbDataAdapter
                    '        Dim cmdmailsetup As String
                    '        Dim strccID As String = ""
                    '        Dim strBccID As String = ""
                    '        Dim strtoID As String = ""
                    '        Try
                    '            cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY FROM MAIL_SETUP WHERE MENU_ID=4"
                    '            adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
                    '            Dim dsmailsetup As New DataSet
                    '            adamailsetup.Fill(dsmailsetup)

                    '            Try
                    '                strBccID = dsmailsetup.Tables(0).Rows(0)("BCC_IDS")
                    '            Catch
                    '                strBccID = ""
                    '            End Try

                    '            Try
                    '                strtoID = dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS")
                    '            Catch
                    '                strtoID = ""
                    '            End Try

                    '            Try
                    '                strccID = dsmailsetup.Tables(0).Rows(0)("CC_IDS")
                    '            Catch
                    '                strccID = ""
                    '            End Try
                    '        Catch ex As Exception
                    '        End Try
                    '        If LstRemark.SelectedValue = 3 Then
                    '            Dim pTermianlMaster As New TerminalMaster
                    '            pTermianlMaster.TerminalId = Lstcfs.SelectedValue
                    '            TerminalMaster.ReturnTerminalMaster(pTermianlMaster)
                    '            strtoID = pTermianlMaster.EmailId
                    '            'strtoID = "amit.kumar@elogisol.in"
                    '        Else
                    '            Dim PcustomerMaster As New CustomerMaster
                    '            PcustomerMaster.CustomerId = TextConsignor.SelectedValue
                    '            CustomerMaster.ReturnCustomerMaster(PcustomerMaster)
                    '            strtoID = PcustomerMaster.EmailOperational
                    '            'strtoID = "rohit@elogisol.in"
                    '        End If

                    '        Dim pMailConfig1 As New MailConfig
                    '        pMailConfig1.TerminalId = 1
                    '        MailConfig.ReturnMailConfig(pMailConfig1)

                    '        Try
                    '            pStr = Functions.sendMailToCcBccID(pMailConfig1.FromId, pMailConfig1.FromName, strtoID, strccID, strBccID, subject, xMailSetup, pMailConfig1.SmtpServer, pMailConfig1.Password, pMailConfig1.PortNo)
                    '            'pStr = pStr = sendMailToCcBccID("vrohit248@gmail.com", dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), "vrohit248@gmail.com", "vrohit248@gmail.com", "", subject, xMailSetup, dsmailconfig.Tables(0).Rows(0)("SMTP_SERVER"), "77#consul14", dsmailconfig.Tables(0).Rows(0)("PORT_NO"))
                    '        Catch ex As Exception

                    '        End Try
                    '        If pStr = Nothing Then
                    '            Label1.Text = "Mail Sent "
                    '        Else
                    '            Label1.Text = "Mail Sent fail "
                    '        End If
                    '    End If

                    'Return pStr


                    'End If
                End If
                gvInvoiceReport.EditIndex = -1
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
            End If
            'End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub

    Protected Sub btnRDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")

        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date
        prepareTerminalData()
        preparePortData()
        prepareCustomerData()
        preparePortDataPOD()
        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue & ",'','','P'"
        strpParms &= "," & LstLine.SelectedValue & "," & lstPod.SelectedValue
        strpParms &= ",'" & TextInvNo.Text.Trim & "'"
        strpParms &= "," & lstdremark.SelectedValue
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_AP_REPORT_DOCUMENTATION", strpParms)
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

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "", "window.open('DocumentUpdateReport.aspx',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=1')", True)
    End Sub
End Class
