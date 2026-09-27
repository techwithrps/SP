Imports System.Net.Mail
Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_CreditorsAgingWise
    Inherits System.Web.UI.Page
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim myGridViews(0) As Object
    Dim myN As Integer = 1
    Dim adapt As New OleDbDataAdapter
    Dim intCounter As Long = 0
    Dim intCounter1 As Long = 0
    Dim dblTotal As Double = 0
    Dim TOTAL As Double = 0
    Dim OverDue As Double = 0
    Dim dbOverDue As Double = 0
    Dim dblTotalD As Double = 0
    Dim TOTALD As Double = 0
    Dim OverDueD As Double = 0
    Dim dbOverDueD As Double = 0
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        'tblreport1.Visible = False
        tblReport.Visible = False
        BindSummary()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            tblDetails.Visible = False
            tblReport.Visible = False
        End If

    End Sub
    Sub BindSummary()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If txtDueDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Status As On Date")
            Functions.ControlFocus(txtDueDate)
            Return
        End If
        If lstCustomerName.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Customer")
            Functions.ControlFocus(lstCustomerName)
            Return
        End If
        If lstCompanyName.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Company")
            Functions.ControlFocus(lstCompanyName)
            Return
        End If
        If txtAgeingFrom.Text.Trim = Nothing Or txtAgeingFrom.Text.Trim = 0 Then
            txtAgeingFrom.Text = 0
        End If
        If txtAgeingTo.Text.Trim = Nothing Or txtAgeingTo.Text.Trim = 0 Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter Ageing To Day")
            Functions.ControlFocus(txtAgeingTo)
            Return
        End If
        Dim AgeingFrom As Integer = 0
        Dim AgeingTo As Integer = 0
        AgeingFrom = Convert.ToInt32(txtAgeingFrom.Text)
        AgeingTo = Convert.ToInt32(txtAgeingTo.Text)
        If AgeingFrom >= AgeingTo Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Ageing To Day Should be Greater From Ageing Day")
            Functions.ControlFocus(txtAgeingTo)
            Return
        End If
        If lstReportType.SelectedValue = "S" Then
            Dim strpParms As String = ""
            strpParms &= lstCustomerName.SelectedValue
            strpParms &= "," & lstCompanyName.SelectedValue & ""
            strpParms &= "," & txtAgeingFrom.Text.Trim & ""
            strpParms &= "," & txtAgeingTo.Text.Trim & ""
            strpParms &= ",'" & txtDueDate.Text.Trim & "'"
            strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CREDITOR_LIST_AGEWISE", strpParms)
            gvInvoiceReport.DataSource = dbr
            gvInvoiceReport.DataBind()
            If dbr.HasRows = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
            End If
            dbr.Close()
            db.CloseDB()
            tblReport.Visible = True
            tblDetails.Visible = False
        ElseIf lstReportType.SelectedValue = "D" Then
            Dim strpParms As String = ""
            strpParms &= lstCustomerName.SelectedValue
            strpParms &= "," & lstCompanyName.SelectedValue & ""
            strpParms &= "," & txtAgeingFrom.Text.Trim & ""
            strpParms &= "," & txtAgeingTo.Text.Trim & ""
            strpParms &= ",'" & txtDueDate.Text.Trim & "'"
            strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CREDITOR_LIST_AGEWISE_DTLS", strpParms)
            gvDetails.DataSource = dbr
            gvDetails.DataBind()
            If dbr.HasRows = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
            End If
            dbr.Close()
            db.CloseDB()
            tblDetails.Visible = True
            tblReport.Visible = False
        Else
            Dim strpParms As String = ""
            strpParms &= lstCustomerName.SelectedValue
            strpParms &= "," & lstCompanyName.SelectedValue & ""
            strpParms &= "," & txtAgeingFrom.Text.Trim & ""
            strpParms &= "," & txtAgeingTo.Text.Trim & ""
            strpParms &= ",'" & txtDueDate.Text.Trim & "'"
            strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CREDITOR_LIST_AGEWISE", strpParms)
            gvInvoiceReport.DataSource = dbr
            gvInvoiceReport.DataBind()
            If dbr.HasRows = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
            End If
            dbr.Close()
            db.CloseDB()
            tblReport.Visible = True

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CREDITOR_LIST_AGEWISE_DTLS", strpParms)
            gvDetails.DataSource = dbr
            gvDetails.DataBind()
            If dbr.HasRows = False Then
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
            End If
            dbr.Close()
            db.CloseDB()
            tblDetails.Visible = True
        End If
       
    End Sub
    Sub ListControlDataBind()
        'Dim pCustomer As New ExtCustomerMaster
        'pCustomer.CustomerType = "0"
        'lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterGroupList(pCustomer)
        ''  lstCustomerName.DataSource = ExtCustomerMaster.ReturnCustomerMasterCostList(pCustomer)
        'lstCustomerName.DataTextField = "CustomerName"
        'lstCustomerName.DataValueField = "CustomerId"
        'lstCustomerName.DataBind()
        'lstCustomerName.Items.Insert(0, (New ListItem("----ALL----", "0")))


        Dim pCompanyMaster As New CompanyMaster
        lstCompanyName.DataSource = CompanyMaster.ReturnCompanyMasterList(pCompanyMaster)
        lstCompanyName.DataTextField = "CompanyName"
        lstCompanyName.DataValueField = "CompanyId"
        lstCompanyName.DataBind()
        lstCompanyName.Items.Insert(0, (New ListItem("All", 0)))
        lstCompanyName.SelectedValue = 0
    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TOTAL = TOTAL + Convert.ToDouble(e.Row.Cells(2).Text)
            OverDue = OverDue + Convert.ToDouble(e.Row.Cells(3).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).ColumnSpan = "2"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(1).Text = Math.Round(TOTAL, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(OverDue, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(OverDueD + TOTALD, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Visible = False
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        ExcelSummary()
    End Sub
    Sub ExcelSummary()
        Dim sb As New StringBuilder
        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=Creditors List Age Wise.xls")
        Response.Charset = ""
        Response.ContentType = "application/excel"
        Dim strConnectionString As String
        Dim con As OleDbConnection
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        strConnectionString = "Provider=MSDAORA;Data Source=115.124.127.54;Persist Security Info=True;Password=spj;User ID=spj"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim procName As String = ""
        Dim procParam As String = ""
        If tblReport.Visible = True Then
            sb.Append("Creditor List Age Wise " + Now.Date)
            sb.Append(Space(4) & vbCrLf)
            sb.Append(Space(4) & vbCrLf)
            sb.Append("<table border='1'>")
            sb.Append("<tr>")
            sb.Append("<td>")
            sb.Append("S.No")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Customer Name")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Within Credit Period")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Over Due Period")
            sb.Append("</td>")
         
            sb.Append("<td>")
            sb.Append("Ageing")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Due Date")
            sb.Append("</td>")
            sb.Append("</tr>")
            Dim pStr As String = ""
            Dim xMailSetup As String = ""
            Dim SR As Long = 0
            Dim adaDwellEXP As OleDbDataAdapter = New OleDbDataAdapter
            Dim cmdDwellEXP As OleDbCommand = con.CreateCommand
            cmdDwellEXP.Connection = con
            cmdDwellEXP.CommandType = CommandType.StoredProcedure
            '   procParam &= lstCustomerName.SelectedValue

            Dim strpParms As String = ""
            strpParms &= lstCustomerName.SelectedValue
            strpParms &= "," & lstCompanyName.SelectedValue & ""
            strpParms &= "," & txtAgeingFrom.Text.Trim & ""
            strpParms &= "," & txtAgeingTo.Text.Trim & ""
            strpParms &= ",'" & txtDueDate.Text.Trim & "'"
            strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
            'procParam &= ds.Tables(0).Rows(J)("CUSTOMER_ID")
            procName = "REPORT_PKG.SP_CREDITOR_LIST_AGEWISE"
            cmdDwellEXP.CommandText = procName & "(" & strpParms & ")"
            adaDwellEXP.SelectCommand = cmdDwellEXP
            Dim dsDwellEXP As New DataSet
            adaDwellEXP.Fill(dsDwellEXP)
            For i = 0 To dsDwellEXP.Tables(0).Rows.Count - 1
                SR = SR + 1
                Dim ageing As String = ""

                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append((SR))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("CUSTOMER_NAME"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("WITHIN_CREDIT"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("OVER_DUE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("AGE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("DUE_DATE"))
                sb.Append("</td>")
                dblTotal = dblTotal + dsDwellEXP.Tables(0).Rows(i)("WITHIN_CREDIT")
                dbOverDue = dbOverDue + dsDwellEXP.Tables(0).Rows(i)("OVER_DUE")
                sb.Append("</tr>")

            Next
            sb.Append("<tr>")
            sb.Append("<td colspan='2'>")
            sb.Append("Total")
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(dblTotal)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(dbOverDue)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append("")
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append("")
            sb.Append("</td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("</table>")
        End If
        If tblDetails.Visible = True Then
            sb.Append("Creditor Details Age Wise " + Now.Date)
            sb.Append(Space(4) & vbCrLf)
            sb.Append(Space(4) & vbCrLf)
            sb.Append("<table border='1'>")
            sb.Append("<tr>")
            sb.Append("<td>")
            sb.Append("S.No")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Customer Name")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Bill No")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Bill Date")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("BL No.")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Invoice Amount")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Within Credit Period")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Over Due Period")
            sb.Append("</td>")

            sb.Append("<td>")
            sb.Append("Ageing")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Due Date")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Type")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Comment")
            sb.Append("</td>")
            sb.Append("</tr>")
            Dim pStr As String = ""
            Dim xMailSetup As String = ""
            Dim SR As Long = 0
            Dim adaDwellEXP As OleDbDataAdapter = New OleDbDataAdapter
            Dim cmdDwellEXP As OleDbCommand = con.CreateCommand
            cmdDwellEXP.Connection = con
            cmdDwellEXP.CommandType = CommandType.StoredProcedure
            '   procParam &= lstCustomerName.SelectedValue
            Dim strpParms As String = ""
            strpParms &= lstCustomerName.SelectedValue
            strpParms &= "," & lstCompanyName.SelectedValue & ""
            strpParms &= "," & txtAgeingFrom.Text.Trim & ""
            strpParms &= "," & txtAgeingTo.Text.Trim & ""
            strpParms &= ",'" & txtDueDate.Text.Trim & "'"
            strpParms &= ",'" & lstPurchaseType.SelectedValue & "'"
            'procParam &= ds.Tables(0).Rows(J)("CUSTOMER_ID")
            procName = "REPORT_PKG.SP_CREDITOR_LIST_AGEWISE_DTLS"
            cmdDwellEXP.CommandText = procName & "(" & strpParms & ")"
            adaDwellEXP.SelectCommand = cmdDwellEXP
            Dim dsDwellEXP As New DataSet
            adaDwellEXP.Fill(dsDwellEXP)
            For i = 0 To dsDwellEXP.Tables(0).Rows.Count - 1
                SR = SR + 1
                Dim ageing As String = ""

                sb.Append("<tr>")
                sb.Append("<td>")
                sb.Append((SR))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("CUSTOMER_NAME"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("BILL_NO"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("BILL_DATE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("BL_NO"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("INVOICE_AMOUNT"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("WITHIN_CREDIT"))
                sb.Append("</td>")

                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("OVER_DUE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("AGE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("DUE_DATE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("TYPE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("CREDIT_REMARK"))
                sb.Append("</td>")
                dblTotalD = dblTotalD + dsDwellEXP.Tables(0).Rows(i)("WITHIN_CREDIT")
                dbOverDueD = dbOverDueD + dsDwellEXP.Tables(0).Rows(i)("OVER_DUE")
                sb.Append("</tr>")

            Next
            sb.Append("<tr>")
            sb.Append("<td colspan='6'>")
            sb.Append("Total")
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(dblTotalD)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(dbOverDueD)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append("")
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append("")
            sb.Append("</td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("</table>")
        End If
        Response.Write(sb.ToString())
        Response.End()
    End Sub

    Protected Sub gvDetails_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter1 = intCounter1 + 1
            e.Row.Cells(1).Text = intCounter1
            TOTALD = TOTALD + Convert.ToDouble(e.Row.Cells(6).Text)
            OverDueD = OverDueD + Convert.ToDouble(e.Row.Cells(7).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).ColumnSpan = "6"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(1).Text = Math.Round(TOTALD, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(OverDueD, 2)
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(3).Text = Math.Round(OverDueD + TOTALD, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
        End If
    End Sub

    Protected Sub lstPurchaseType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstPurchaseType.SelectedIndexChanged
        If lstPurchaseType.SelectedValue = "0" Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Purchase From")
            Functions.ControlFocus(lstPurchaseType)
            Return
        End If
        lstCustomerName.Items.Clear()
        Try
            If lstPurchaseType.SelectedValue = "C" Then
                Dim pTerminalMaster As New CustomerMaster
                lstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterGroupList(pTerminalMaster)
                lstCustomerName.DataTextField = "CustomerName"
                lstCustomerName.DataValueField = "CustomerId"
                lstCustomerName.DataBind()
                lstCustomerName.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomerName.SelectedValue = 0
            Else
                Dim pVendorMaster As New VendorMaster
                lstCustomerName.DataSource = VendorMaster.ReturnVendorMasterList(pVendorMaster)
                lstCustomerName.DataTextField = "VendorName"
                lstCustomerName.DataValueField = "VendorId"
                lstCustomerName.DataBind()
                lstCustomerName.Items.Insert(0, (New ListItem("---All---", 0)))
                lstCustomerName.SelectedValue = 0
            End If
         Catch ex As Exception
        End Try
    End Sub

    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvDetails.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                    If chk.Checked = True Then
                        CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = True

                    Else
                        CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = False


                    End If
                End If
            Next
        End If
        Dim chkAll As CheckBox = TryCast(gvDetails.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvDetails.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = True

                Else
                    CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = False

                End If
            End If
        Next

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        For Each row As GridViewRow In gvDetails.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnBillNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnBillNo"), HiddenField)
                    Dim txtComment As TextBox = TryCast(row.Cells(0).FindControl("txtComment"), TextBox)
                    Dim hdnType As HiddenField = TryCast(row.Cells(0).FindControl("hdnType"), HiddenField)
                    Dim strHdnType As String
                    Try
                        strHdnType = hdnType.Value
                    Catch ex As Exception
                        strHdnType = "0"
                    End Try
                    If strHdnType = "Debit Note" Then
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE DR_NOTE SET CREDIT_REMARK='" & txtComment.Text & "', CREDIT_REMARK_UPDATED_BY='" & Session.Item("LoginUser") & "', CREDIT_REMARK_UPDATED_ON=SYSDATE WHERE DR_REF_NO='" & hdnBillNo.Value & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    ElseIf strHdnType = "Purchase Invoice" Then
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING SET CREDIT_REMARK='" & txtComment.Text & "', CREDIT_REMARK_UPDATED_BY='" & Session.Item("LoginUser") & "', CREDIT_REMARK_UPDATED_ON=SYSDATE WHERE LINER_INV_NO='" & hdnBillNo.Value & "'", con)
                        cmd.ExecuteNonQuery()
                        Dim cmd1 As OleDbCommand = New OleDbCommand("UPDATE COST_BOOKING_NEW SET CREDIT_REMARK='" & txtComment.Text & "', CREDIT_REMARK_UPDATED_BY='" & Session.Item("LoginUser") & "', CREDIT_REMARK_UPDATED_ON=SYSDATE WHERE LINER_INV_NO='" & hdnBillNo.Value & "'", con)
                        cmd1.ExecuteNonQuery()
                        con.Close()
                    End If

                End If

                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
            End If
            'End If
        Next
        btnSave.Visible = False
    End Sub

End Class
