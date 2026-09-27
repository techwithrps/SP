Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit
Partial Class Reports_Fleet_UpdateBlStatus
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
            ListControlDataBind()
        End If
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
    Private Sub BindData()
        prepareTerminalData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal") & ",0,0"
        'strpParms &= ",'" & textFromDate.Text & "'"
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_BL_UPDATE", strpParms)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
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
            Dim pTerminalMaster As New CustomerMaster
            lstCFS.DataSource = CustomerMaster.ReturnCustomerMasterList(pTerminalMaster)
            lstCFS.DataTextField = "CustomerName"
            lstCFS.DataValueField = "CustomerId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
            Dim pPortMaster As New PortMaster
            LSTpod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            LSTpod.DataTextField = "PortName"
            LSTpod.DataValueField = "PortId"
            LSTpod.DataBind()
            LSTpod.Items.Insert(0, (New ListItem("---All---", 0)))
            LSTpod.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date
        'prepareTerminalData()
        'preparePortData()


        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")

        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue & "," & LSTpod.SelectedValue & "," & LStRemark.SelectedValue
        'strpParms &= "," & LstCFS.SelectedValue & ""
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_BL_UPDATE", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
        gvtripPendencyList.DataSource = dbr
        gvtripPendencyList.DataBind()
        If Not dbr.HasRows Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    intCounter = intCounter + 1
        '    e.Row.Cells(0).Text = intCounter
        'End If

    End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Try
    '        Dim strComa = ","
    '        Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
    '        Dim strFileName As String = "RailOutPending.csv"
    '        Dim attachment As String = "attachment; Filename=" & strFileName
    '        Dim strb As New StringBuilder
    '        Response.Clear()
    '        Response.ClearHeaders()
    '        Response.ClearContent()
    '        Response.AddHeader("content-disposition", attachment)
    '        Response.ContentType = "text/csv"
    '        Response.AddHeader("Pragma", "public")
    '        strb.Append(lblScreenTitle.Text & vbCrLf)

    '        strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
    '        'strb.Append(lblDate.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)

    '        Dim strContentHeader As String = Nothing
    '        Dim strSummaryHeader As String = Nothing
    '        strContentHeader = "Sr." & strComa & "CFS" & strComa & "Factory Location" & strComa & "Conatiner No" & strComa & _
    '        "Shipping Line" & strComa & "POD" & strComa & "BL No" & strComa & "ICD Gate In Date" & strComa & "Line Handover Date" & strComa & "Load Port" & strComa & "Rail Out Status"
    '        strb.Append(strContentHeader & vbCrLf)
    '        If gvtripPendencyList.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvtripPendencyList.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                        strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ") & strComa)
    '                    Else
    '                        strb.Append(" " & strComa)
    '                    End If
    '                Next
    '                strb.Append(vbCrLf)
    '            Next
    '        End If
    '        Response.Write(strb.ToString)
    '        Response.Flush()
    '        Response.End()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub EditAllParty(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvtripPendencyList.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvtripPendencyList.EditIndex = -1
        BindData()
    End Sub
    'Protected Sub AllPartyUpdate(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
    '    Dim hdnMTY_CONT_ID As HiddenField = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '    ' Dim TextLineInvoiceNO As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TextLineInvoiceNO"), TextBox)
    '    'Dim TxtLineInvoiceDate As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtLineInvoiceDate"), TextBox)
    '    Dim TxtBookingNo As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtBookingNo"), TextBox)
    '    Dim TxtBLNO As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtBLNO"), TextBox)
    '    Dim lstBLStatus As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("lstBLStatus"), DropDownList)
    '    Dim TxtBLRemark As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtBLRemark"), TextBox)
    '    Dim lstOBLStatus As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("lstOBLStatus"), DropDownList)
    '    Dim lstBlMethod As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("lstBlMethod"), DropDownList)
    '    Dim TxtOBLStatusDate As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtOBLStatusDate"), TextBox)



    '    If lstBLStatus.SelectedValue = 0 Then
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select BL Type")
    '        Functions.ControlFocus(lstBLStatus)
    '        Return
    '    End If
    '    If lstOBLStatus.SelectedValue = 0 Then
    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select BL Status")
    '        Functions.ControlFocus(lstOBLStatus)
    '        Return
    '    End If

    '    If lstOBLStatus.SelectedValue = 2 Then
    '        If TxtOBLStatusDate.Text = "" Then
    '            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter BL Issued Date ")
    '            Functions.ControlFocus(TxtOBLStatusDate)
    '            Return
    '        End If
    '    End If

    '    con = New OleDbConnection(cs)
    '    con.Open()
    '    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET OBL_STATUS='" & lstOBLStatus.SelectedItem.Text & "', OBL_ISSUE_DATE=TO_dATE('" & TxtOBLStatusDate.Text.Trim & "','DD/MM/YYYY'), BL_REMARK='" & TxtBLRemark.Text.Trim & "',BOOKING_NO='" & TxtBookingNo.Text.Trim & "',BL_NO='" & TxtBLNO.Text.Trim & "',BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID=NVL(" & lstBLStatus.SelectedValue & ",0)  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
    '    cmd.ExecuteNonQuery()
    '    con.Close()
    '    gvtripPendencyList.EditIndex = -1
    '    BindData()
    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    'End Sub


    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim checkedRowCount As Integer = 0

        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    checkedRowCount += 1

                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    ' Dim TextLineInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextLineInvoiceNO"), TextBox)
                    ' Dim TxtLineInvoiceDate As TextBox = TryCast(row.Cells(0).FindControl("TxtLineInvoiceDate"), TextBox)
                    Dim TxtBookingNo As TextBox = TryCast(row.Cells(0).FindControl("TxtBookingNo"), TextBox)
                    Dim TxtBLNO As TextBox = TryCast(row.Cells(0).FindControl("TxtBLNO"), TextBox)
                    Dim lstBLStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstBLStatus"), DropDownList)
                    Dim lstBlMethod As DropDownList = TryCast(row.Cells(0).FindControl("lstBlMethod"), DropDownList)
                    Dim TxtBLRemark As TextBox = TryCast(row.Cells(0).FindControl("TxtBLRemark"), TextBox)
                    Dim lstOBLStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstOBLStatus"), DropDownList)
                    Dim TxtOBLStatusDate As TextBox = TryCast(row.Cells(0).FindControl("TxtOBLStatusDate"), TextBox)
                    Dim TxtConsigneeName As TextBox = TryCast(row.Cells(0).FindControl("TxtConsigneeName"), TextBox)
                    Dim LstBillTo As DropDownList = TryCast(row.Cells(0).FindControl("LstBillTo"), DropDownList)
                    Dim lblContNO As Label = TryCast(row.Cells(0).FindControl("lblContNO"), Label)
                    'If lstBLStatus.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select BL Type")
                    '    Functions.ControlFocus(lstBLStatus)
                    '    Return
                    'End If
                    'If lstOBLStatus.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select BL Status")
                    '    Functions.ControlFocus(lstOBLStatus)
                    '    Return
                    'End If
                    'If lstBlMethod.SelectedValue = 0 Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Select BL Method")
                    '    Functions.ControlFocus(lstBlMethod)
                    '    Return
                    'End If
                    'If lstOBLStatus.SelectedValue = 2 Then
                    '    If TxtOBLStatusDate.Text = "" Then
                    '        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter BL Issued Date ")
                    '        Functions.ControlFocus(TxtOBLStatusDate)
                    '        Return
                    '    End If
                    'End If
                    'If TxtBLRemark.Text = "" Then
                    '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Remarks Name.")
                    '    Functions.ControlFocus(TxtBLRemark)
                    '    Return
                    'End If
                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET BILLING_PARTY=" & LstBillTo.SelectedValue & ",CONSINGEE_NAME='" & TxtConsigneeName.Text.Trim & "',OBL_STATUS='" & lstOBLStatus.SelectedItem.Text & "', OBL_ISSUE_DATE=TO_dATE('" & TxtOBLStatusDate.Text.Trim & "','DD/MM/YYYY'),BL_REMARK='" & TxtBLRemark.Text.Trim & "',BOOKING_NO='" & TxtBookingNo.Text.Trim & "',BL_NO='" & TxtBLNO.Text.Trim & "',BL_METHOD='" & lstBlMethod.SelectedItem.Text & "',BL_METHOD_ID=NVL(" & lstBlMethod.SelectedValue & ",0),BL_STATUS='" & lstBLStatus.SelectedItem.Text & "',BL_STATUS_ID=NVL(" & lstBLStatus.SelectedValue & ",0)  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    cmd.ExecuteNonQuery()
                    Dim cmd1 As String
                    cmd1 = " Insert into BL_UPDATION (BL_TRACK_ID, BL_STATUS_ID,BL_STATUS,BL_METHOD_ID,BL_METHOD,OBL_STATUS,OBL_ISSUE_DATE, BL_NO , BOOKING_NO," _
                            & " MTY_CONT_ID, CONSINGEE_NAME, CONT_NO, CREATED_BY, CREATED_ON) " _
                            & " VALUES (BL_TRACK_ID.NEXTVAL, nvl(" & lstBLStatus.SelectedValue & ", 0), nvl('" & lstBLStatus.SelectedItem.Text & "',''),nvl(" & lstBlMethod.SelectedValue & ", 0), nvl('" & lstBlMethod.SelectedItem.Text & "',''),nvl('" & lstOBLStatus.SelectedItem.Text & "',''),NVL(TO_DATE('" & TxtOBLStatusDate.Text & "','DD/MM/YYYY'),''),nvl('" & TxtBLNO.Text & "',''),nvl('" & TxtBookingNo.Text & "','')," _
                         & Convert.ToInt32(hdnMTY_CONT_ID.Value) & ", '" & TxtConsigneeName.Text & "', '" & lblContNO.Text.Trim & "','" & Session.Item("LoginUser") & "',sysdate)"
                    Dim cmd5 As New OleDbCommand(cmd1, con)
                    cmd5.ExecuteNonQuery()
                    con.Close()
                    gvtripPendencyList.EditIndex = -1
                    BindData()
                    'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        BindData()
        'MsgBox(checkedRowCount & " :Records " & "Update Successfully", MsgBoxStyle.Information, "Update Records")

        Dim script As String = "alert('" & checkedRowCount & " :Records " & " Update Successfully ');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertScript", script, True)
        'BtnUpdate.Visible = False
    End Sub

    'Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    Dim isUpdateVisible As Boolean = False
    '    Dim chk As CheckBox = TryCast(sender, CheckBox)
    '    If chk.ID = "chkAll" Then
    '        For Each row As GridViewRow In gvtripPendencyList.Rows
    '            If row.RowType = DataControlRowType.DataRow Then
    '                row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
    '            End If
    '        Next
    '    End If
    '    Dim chkAll As CheckBox = TryCast(gvtripPendencyList.HeaderRow.FindControl("chkAll"), CheckBox)
    '    chkAll.Checked = True
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            If isChecked Then
    '                Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
    '                Dim lstBLStatus As DropDownList = TryCast(row.Cells(0).FindControl("lstBLStatus"), DropDownList)
    '                Dim TxtBLRemark As TextBox = TryCast(row.Cells(0).FindControl("TxtBLRemark"), TextBox)
    '                Dim LstBillTo As DropDownList = TryCast(row.Cells(0).FindControl("LstBillTo"), DropDownList)
    '                Dim clROBLStatus = TryCast(row.Cells(0).FindControl("clROBLStatus"), CalendarExtender)
    '                clROBLStatus.EndDate = DateTime.Now.Date



    '                Dim strConnectionString, cmd1 As String
    '                Dim con As OleDbConnection
    '                Dim ada As OleDbDataReader
    '                strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    '                'cmd1 = "SELECT BL_STATUS_ID,BILLING_PARTY FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
    '                cmd1 = "SELECT nvl(BL_STATUS_ID,0),BILLING_PARTY FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)

    '                ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
    '                con = New OleDbConnection(strConnectionString)
    '                con.Open()
    '                Dim cmd As New OleDbCommand()
    '                cmd.Connection = con
    '                cmd.CommandText = cmd1
    '                ada = cmd.ExecuteReader
    '                ada.Read()
    '                Try
    '                    lstBLStatus.SelectedValue = ada.GetValue(0)
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    LstBillTo.SelectedValue = ada.GetValue(1)
    '                Catch ex As Exception
    '                End Try

    '            End If
    '        End If
    '    Next
    '    For Each row As GridViewRow In gvtripPendencyList.Rows
    '        If row.RowType = DataControlRowType.DataRow Then
    '            Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
    '            For i As Integer = 1 To row.Cells.Count - 1
    '                'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
    '                row.Cells(i).FindControl("lblBLStatus").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblBLNO").Visible = Not isChecked
    '                ' row.Cells(i).FindControl("lblLineInvoiceDate").Visible = Not isChecked
    '                'row.Cells(i).FindControl("lblLineInvoiceNO").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblBlRemark").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblOBLStatusDate").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblOBLStatus").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblBookingNo").Visible = Not isChecked
    '                row.Cells(i).FindControl("lblBillTo").Visible = Not isChecked

    '                If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
    '                End If
    '                If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                End If
    '                'If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
    '                '    row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
    '                'End If
    '                If isChecked AndAlso Not isUpdateVisible Then
    '                    isUpdateVisible = True
    '                End If
    '                If Not isChecked Then
    '                    chkAll.Checked = False
    '                End If
    '            Next
    '        End If
    '    Next
    '    BtnUpdate.Visible = isUpdateVisible
    'End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Functions.ExportToCSV(Me.Page, gvtripPendencyList)
    End Sub
End Class

