Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_TelexPending
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim dt As DataTable
    Private Sub BindData()
       Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        ListControlDataBind()

        Dim strpParms As String = ""
        strpParms &= "'','',"
        ' strpParms &= ",'" & textToDate.Text & "',"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & LstLine.SelectedValue

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strCurrentDate As String
            'Dim strFromDate As String
            'Dim strToDate As String
            'textFromDate.Text = Format(Now, "dd/MM/yyyy")
            'textToDate.Text = Format(Now, "dd/MM/yyyy")
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            ' strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
            'strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")
            ListControlDataBind()

            Dim strpParms As String = ""
            strpParms &= "'','',"
            ' strpParms &= ",'" & textToDate.Text & "',"
            strpParms &= lstCFS.SelectedValue
            strpParms &= "," & LstLine.SelectedValue

            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
            gvtripPendencyList.DataSource = dbr
            gvtripPendencyList.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else
                tblReport.Visible = False
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
            End If
            dbr.Close()
            db.CloseDB()
        End If
    End Sub
    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        'For Each row As GridViewRow In gvtripPendencyList.Rows
        '    If row.RowType = DataControlRowType.DataRow Then
        '        Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
        '        If isChecked Then
        '            Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
        '            Dim LsttranshipmentPort As DropDownList = TryCast(row.Cells(0).FindControl("LsttranshipmentPort"), DropDownList)
        '            Dim strConnectionString, cmd1 As String
        '            Dim con As OleDbConnection
        '            Dim ada As OleDbDataReader
        '            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
        '            cmd1 = "SELECT nvl(TRANS_PORT_ID,0) FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
        '            ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
        '            con = New OleDbConnection(strConnectionString)
        '            con.Open()
        '            Dim cmd As New OleDbCommand()
        '            cmd.Connection = con
        '            cmd.CommandText = cmd1
        '            ada = cmd.ExecuteReader
        '            ada.Read()
        '            Try
        '                LsttranshipmentPort.SelectedValue = ada.GetValue(0)
        '            Catch ex As Exception
        '            End Try
        '            'Try
        '            '    Lstpod.SelectedValue = ada.GetValue(1)
        '            'Catch ex As Exception
        '            'End Try
        '            'Try
        '            '    Lstcfs.SelectedValue = ada.GetValue(2)
        '            'Catch ex As Exception
        '            'End Try

        '        End If
        '    End If
        'Next
        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvtripPendencyList.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                End If
            Next
        End If
        Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    ''row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
                    'row.Cells(i).FindControl("lblPartyInvoiceNo").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblBlNo").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblEtd").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblVessel").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblEta").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblShipmentStatus").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblRSailed").Visible = Not isChecked
                    'row.Cells(i).FindControl("lbltranshipmentPort").Visible = Not isChecked
                    'row.Cells(i).FindControl("LblTranshipmetDate").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblTranshipmentVeseel").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
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
        ImgBtnUpdate.Visible = isUpdateVisible
    End Sub
    Protected Sub gvtripPendencyList_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs)
        gvtripPendencyList.EditIndex = e.NewEditIndex
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        'strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        'strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= "'','',"
        ' strpParms &= ",'" & textToDate.Text & "',"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & LstLine.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    'Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnUpdate.Click
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                'Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim ContNo As Label = TryCast(row.Cells(0).FindControl("lblContNo"), Label)
    '                Dim MtyContId As HiddenField = TryCast(row.Cells(0).FindControl("hdnMtyContId"), HiddenField)
    '                Dim PartyInvoiceNo As TextBox = TryCast(row.Cells(0).FindControl("textPartyInvoiceNo"), TextBox)
    '                Dim Port As TextBox = TryCast(row.Cells(0).FindControl("textPort"), TextBox)
    '                Dim BlNo As TextBox = TryCast(row.Cells(0).FindControl("textBlNo"), TextBox)
    '                Dim Etd As TextBox = TryCast(row.Cells(0).FindControl("textEtd"), TextBox)
    '                Dim Vessel As TextBox = TryCast(row.Cells(0).FindControl("textVessel"), TextBox)
    '                Dim Eta As TextBox = TryCast(row.Cells(0).FindControl("textEta"), TextBox)
    '                Dim ShipmentStatus As TextBox = TryCast(row.Cells(0).FindControl("textShipmentStatus"), TextBox)
    '                con = New OleDbConnection(cs)
    '                con.Open()
    '                Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET PARTY_INV_NO='" & PartyInvoiceNo.Text & "',BL_NO = '" & BlNo.Text & "',CURRENT_ETD = TO_DATE('" & Etd.Text & "','DD/MM/YYYY'),REQUIRED_ETD = TO_DATE('" & Etd.Text & "','DD/MM/YYYY'),CURRENT_VESSEL = '" & Vessel.Text & "',REQUIRED_VESSEL = '" & Vessel.Text & "',CURRENT_ETA = TO_DATE('" & Eta.Text & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(MtyContId.Value), con)
    '                cmd.ExecuteNonQuery()
    '                con.Close()
    '                gvtripPendencyList.EditIndex = -1
    '                Dim strCurrentDate As String
    '                strCurrentDate = Format(Now, "MM/dd/yyyy")
    '                Dim strpParms As String = ""
    '                strpParms &= "'','',"
    '                ' strpParms &= ",'" & textToDate.Text & "',"
    '                strpParms &= lstCFS.SelectedValue
    '                strpParms &= "," & LstLine.SelectedValue
    '                Dim dbr As OleDb.OleDbDataReader
    '                Dim db As New DBConnect
    '                dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
    '                gvtripPendencyList.DataSource = dbr
    '                gvtripPendencyList.DataBind()
    '                If dbr.HasRows Then
    '                    tblReport.Visible = True
    '                Else
    '                    tblReport.Visible = False
    '                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
    '                End If
    '                dbr.Close()
    '                db.CloseDB()
    '                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    '            End If
    '        End If
    '    Next
    '    ImgBtnUpdate.Visible = False
    '    'BindData()
    'End Sub
    Protected Sub gvtripPendencyList_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)
        Dim ContNo As Label = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("lblContNo"), Label)
        Dim MtyContId As HiddenField = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("hdnMtyContId"), HiddenField)
        Dim PartyInvoiceNo As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textPartyInvoiceNo"), TextBox)
        Dim Port As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textPort"), TextBox)
        Dim BlNo As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textBlNo"), TextBox)
        Dim Etd As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textEtd"), TextBox)
        Dim Vessel As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textVessel"), TextBox)
        Dim Eta As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textEta"), TextBox)
        Dim ShipmentStatus As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("textShipmentStatus"), TextBox)
        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET PARTY_INV_NO='" & PartyInvoiceNo.Text & "',BL_NO = '" & BlNo.Text & "',CURRENT_ETD = TO_DATE('" & Etd.Text & "','DD/MM/YYYY'),CURRENT_VESSEL = '" & Vessel.Text & "',CURRENT_ETA = TO_DATE('" & Eta.Text & "','DD/MM/YYYY') WHERE MTY_CONT_ID= " & Convert.ToInt32(MtyContId.Value), con)
        cmd.ExecuteNonQuery()
        con.Close()
        gvtripPendencyList.EditIndex = -1
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")

        Dim strpParms As String = ""
        strpParms &= "'','',"
        ' strpParms &= ",'" & textToDate.Text & "',"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & LstLine.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub

    Protected Sub gvtripPendencyList_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs)
        gvtripPendencyList.EditIndex = -1
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        ' strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        'strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= "'','',"
        ' strpParms &= ",'" & textToDate.Text & "',"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & LstLine.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pCustomerMaster As New CustomerMaster
            pCustomerMaster.TerminalId = Session.Item("LoginTerminal")
            lstCFS.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
            lstCFS.DataTextField = "CustomerName"
            lstCFS.DataValueField = "CustomerId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
            LstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            LstLine.DataTextField = "CustomerName"
            LstLine.DataValueField = "CustomerId"
            LstLine.DataBind()
            LstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            LstLine.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
       gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date

        

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        'strFromDate = Me.textFromDate.Text
        'strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        'strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        'strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= "'','',"
        ' strpParms &= ",'" & textToDate.Text & "',"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & LstLine.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    'Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        intCounter = intCounter + 1
    '        e.Row.Cells(0).Text = intCounter
    '    End If
    'End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
            Dim strFileName As String = "TelexPending.csv"
            Dim attachment As String = "attachment; Filename=" & strFileName
            Dim strb As New StringBuilder
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")
            strb.Append(lblScreenTitle.Text & vbCrLf)

            strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
            'strb.Append(lblReportDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            Dim strContentHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContentHeader = "Sr." & strComa & "Shipper Name" & strComa & "Party Invoice No" & strComa & "Port" & strComa & _
            "Container Number" & strComa & "BL Number" & strComa & "ETD" & strComa & "Vessel" & strComa & "ETA" & strComa & "Shipment Status" & strComa & "Ageing"
            strb.Append(strContentHeader & vbCrLf)
            If gvtripPendencyList.Rows.Count > 0 Then
                For Each r As GridViewRow In gvtripPendencyList.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ") & strComa)
                        Else
                            strb.Append(" " & strComa)
                        End If
                    Next
                    strb.Append(vbCrLf)
                Next
            End If
            Response.Write(strb.ToString)
            Response.Flush()
            Response.End()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    'Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    ' Dim ContNo As Label = TryCast(row.Cells(0).FindControl("lblContNo"), Label)
                    Dim MtyContId As HiddenField = TryCast(row.Cells(0).FindControl("hdnMtyContId"), HiddenField)
                    'Dim PartyInvoiceNo As TextBox = TryCast(row.Cells(0).FindControl("textPartyInvoiceNo"), TextBox)
                    'Dim Port As TextBox = TryCast(row.Cells(0).FindControl("textPort"), TextBox)
                    'Dim BlNo As TextBox = TryCast(row.Cells(0).FindControl("textBlNo"), TextBox)
                    'Dim Etd As TextBox = TryCast(row.Cells(0).FindControl("textEtd"), TextBox)
                    'Dim Vessel As TextBox = TryCast(row.Cells(0).FindControl("textVessel"), TextBox)
                    'Dim Eta As TextBox = TryCast(row.Cells(0).FindControl("textEta"), TextBox)
                    Dim lstTelexDate As TextBox = TryCast(row.Cells(0).FindControl("lstTelexDate"), TextBox)
                    Dim LstRemark As DropDownList = TryCast(row.Cells(0).FindControl("LstRemark"), DropDownList)

                    If LstRemark.SelectedValue = 1 Then
                        If lstTelexDate.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Telex Date")
                            Functions.ControlFocus(lstTelexDate)
                            Return
                        End If
                    End If
                    If lstTelexDate.Text <= "" Then
                        If LstRemark.SelectedValue <> 1 Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Telex Is Received.")
                            Functions.ControlFocus(LstRemark)
                            Return
                        End If
                    End If
                   
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET TELEX_STATUS=" & LstRemark.SelectedValue & ",TELEX_DATE=DECODE(" & LstRemark.SelectedValue & ",0,'',TO_dATE('" & lstTelexDate.Text.Trim & "','DD/MM/YYYY')) WHERE MTY_CONT_ID= " & Convert.ToInt32(MtyContId.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                   
                    'gvtripPendencyList.EditIndex = -1
                    'Dim strCurrentDate As String
                    'strCurrentDate = Format(Now, "MM/dd/yyyy")
                    'Dim strpParms As String = ""
                    'strpParms &= "'" & textFromDate.Text & "'"
                    'strpParms &= ",'" & textToDate.Text & "',"
                    'strpParms &= lstCFS.SelectedValue
                    'Dim dbr As OleDb.OleDbDataReader
                    'Dim db As New DBConnect
                    'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TELEX_PENDING_REPORT", strpParms)
                    'gvtripPendencyList.DataSource = dbr
                    'gvtripPendencyList.DataBind()
                    'If dbr.HasRows Then
                    '    tblReport.Visible = True
                    'Else
                    '    tblReport.Visible = False
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
                    'End If
                    'dbr.Close()
                    'db.CloseDB()
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub
End Class
