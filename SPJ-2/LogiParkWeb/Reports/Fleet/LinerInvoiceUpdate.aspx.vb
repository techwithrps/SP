Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_LinerInvoiceUpdate
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

    Private Sub BindData()

        Dim strCurrentDate As String
        Dim strFromDate As String
        Dim strToDate As String
        textFromDate.Text = Format(Now, "dd/MM/yyyy")
        textToDate.Text = Format(Now, "dd/MM/yyyy")
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue
        'strpParms &= ",'" & textFromDate.Text & "'"
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_LINE_INVOICE_UPDATE", strpParms)
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
            Dim pTerminalMaster As New CustomerMaster
            lstCFS.DataSource = CustomerMaster.ReturnCustomerMasterList(pTerminalMaster)
            lstCFS.DataTextField = "CustomerName"
            lstCFS.DataValueField = "CustomerId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date
        'prepareTerminalData()
        'preparePortData()

        If textFromDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter From Date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue
        'strpParms &= "," & LstCFS.SelectedValue & ""
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_LINE_INVOICE_UPDATE", strpParms)
        'Dim dt As New DataTable
        'dt.Load(dbr)
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
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    intCounter = intCounter + 1
        '    e.Row.Cells(0).Text = intCounter
        'End If

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try
            Dim strComa = ","
            Dim strCurDt As String = Today.Day & "/" & Today.Month & "/" & Today.Year & " " & Now.Hour & ":" & Now.Minute
            Dim strFileName As String = "RailOutPending.csv"
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
            'strb.Append(lblDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)

            Dim strContentHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContentHeader = "Sr." & strComa & "CFS" & strComa & "Factory Location" & strComa & "Conatiner No" & strComa & _
            "Shipping Line" & strComa & "POD" & strComa & "BL No" & strComa & "ICD Gate In Date" & strComa & "Line Handover Date" & strComa & "Load Port" & strComa & "Rail Out Status"
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
    Protected Sub EditAllParty(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvtripPendencyList.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvtripPendencyList.EditIndex = -1
        BindData()
    End Sub
    Protected Sub AllPartyUpdate(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim txtPOL As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtPOL"), TextBox)
        Dim hdnMTY_CONT_ID As HiddenField = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("hdnMTY_CONT_ID"), HiddenField)
        Dim TextLineInvoiceNO As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TextLineInvoiceNO"), TextBox)
        Dim TxtLineInvoiceDate As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtLineInvoiceDate"), TextBox)
        Dim TxtRemarks As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("TxtRemarks"), TextBox)
        Dim lstInvoiceStaus As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("lstInvoiceStaus"), DropDownList)
        If TextLineInvoiceNO.Text <> Nothing Then
            If TextLineInvoiceNO.Text = "" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice No.")
                Functions.ControlFocus(TextLineInvoiceNO)
                Return
            End If
            If TxtLineInvoiceDate.Text = "" Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date.")
                Functions.ControlFocus(TxtLineInvoiceDate)
                Return
            End If
        End If

        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET LINER_INV_NO=" & TextLineInvoiceNO.Text.Trim & ",LINER_INV_DATE=TO_DATE('" & TxtLineInvoiceDate.Text.Trim & "','DD/MM/YYYY'),INVOICE_STATUS='" & lstInvoiceStaus.SelectedItem.Text & "',INVOICE_REMARK='" & TxtRemarks.Text & "'  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
        cmd.ExecuteNonQuery()
        con.Close()
        gvtripPendencyList.EditIndex = -1
        BindData()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    End Sub
    Protected Sub ImgBtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgBtnUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim TextLineInvoiceNO As TextBox = TryCast(row.Cells(0).FindControl("TextLineInvoiceNO"), TextBox)
                    Dim TxtLineInvoiceDate As TextBox = TryCast(row.Cells(0).FindControl("TxtLineInvoiceDate"), TextBox)
                    Dim TxtRemarks As TextBox = TryCast(row.Cells(0).FindControl("TxtRemarks"), TextBox)
                    Dim lstInvoiceStaus As DropDownList = TryCast(row.Cells(0).FindControl("lstInvoiceStaus"), DropDownList)
                    If TextLineInvoiceNO.Text <> Nothing Then
                        If TextLineInvoiceNO.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice No.")
                            Functions.ControlFocus(TextLineInvoiceNO)
                            Return
                        End If
                        If TxtLineInvoiceDate.Text = "" Then
                            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Please Enter Invoice Date.")
                            Functions.ControlFocus(TxtLineInvoiceDate)
                            Return
                        End If
                    End If
                    con = New OleDbConnection(cs)
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("UPDATE ALL_PARTY_ACCOUNT SET LINER_INV_NO='" & TextLineInvoiceNO.Text.Trim & "',LINER_INV_DATE=TO_DATE('" & TxtLineInvoiceDate.Text.Trim & "','DD/MM/YYYY'),INVOICE_STATUS='" & lstInvoiceStaus.SelectedItem.Text & "',INVOICE_REMARK='" & TxtRemarks.Text & "'  WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                    cmd.ExecuteNonQuery()
                    con.Close()
                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub

    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnMTY_CONT_ID As HiddenField = TryCast(row.Cells(0).FindControl("hdnMTY_CONT_ID"), HiddenField)
                    Dim lstInvoiceStaus As DropDownList = TryCast(row.Cells(0).FindControl("lstInvoiceStaus"), DropDownList)
                    Dim strConnectionString, cmd1 As String
                    Dim con As OleDbConnection
                    Dim ada As OleDbDataReader
                    strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    cmd1 = "SELECT INVOICE_STATUS FROM ALL_PARTY_ACCOUNT WHERE MTY_CONT_ID=" & Convert.ToInt32(hdnMTY_CONT_ID.Value)
                    ' CMD4 = "SELECT LOCATION_KEY_ID FROM CUSTOMER_LOCATION WHERE CUSTOMER_ID='" & pcustomermaster.CustomerId & "' AND LOCATION_ID=(SELECT LOCATION_ID FROM LOCATION_MASTER WHERE LOCATION_NAME='" & textFactoryLoc.Text & "'"
                    con = New OleDbConnection(strConnectionString)
                    con.Open()
                    Dim cmd As New OleDbCommand()
                    cmd.Connection = con
                    cmd.CommandText = cmd1
                    ada = cmd.ExecuteReader
                    ada.Read()
                    Try
                        lstInvoiceStaus.SelectedItem.Text = ada.GetValue(0)
                    Catch ex As Exception
                    End Try

                End If
            End If
        Next
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
                    'row.Cells(i).Controls.OfType(Of Label)().FirstOrDefault().Visible = Not isChecked
                    row.Cells(i).FindControl("lblInvoiceStaus").Visible = Not isChecked
                    row.Cells(i).FindControl("lblRemarks").Visible = Not isChecked
                    row.Cells(i).FindControl("lblLineInvoiceDate").Visible = Not isChecked
                    row.Cells(i).FindControl("lblLineInvoiceNO").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
                    'row.Cells(i).FindControl("txtTrainNo").Visible = Not isChecked
                    'row.Cells(i).FindControl("txtOutDate").Visible = Not isChecked

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
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class

