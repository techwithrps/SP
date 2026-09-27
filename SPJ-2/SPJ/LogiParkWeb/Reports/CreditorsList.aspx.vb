Imports System.Net.Mail
Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_CreditorsList
    Inherits System.Web.UI.Page
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim myGridViews(0) As Object
    Dim myN As Integer = 1
    Dim adapt As New OleDbDataAdapter
    Dim intCounter As Long = 0
    Dim intCounter1 As Long = 0
    Dim dblCargoTotal As Double = 0
    Dim dblCuns As Double = 0
    Dim dblMum As Double = 0
    Dim dblother As Double = 0
    Dim dblTotal As Double = 0
    Dim dblExpectedPayment As Double = 0
    Dim TotCargo As Double
    Dim TotCon As Double = 0.0
    Dim TotMum As Double = 0.0
    Dim Totother As Double = 0.0
    Dim Total As Double = 0.0
    Dim totPlan As Double = 0.0
    Dim totalOverDue As Double = 0.0
    Dim OverDue As Double = 0.0
    Dim totalt0t30, totalt31t60, totalt61t90, totalt91t120, totalt121t150, totalt151t180, totalabove180, totalunAdj, agetotal As Double
    'Protected Sub GvAgeingWiseReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GvAgeingWiseReport.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        intCounter1 = intCounter1 + 1
    '        e.Row.Cells(0).Text = intCounter1
    '        totalt0t30 = totalt0t30 + Convert.ToDouble(e.Row.Cells(2).Text)
    '        totalt31t60 = totalt31t60 + Convert.ToDouble(e.Row.Cells(3).Text)
    '        totalt61t90 = totalt61t90 + Convert.ToDouble(e.Row.Cells(4).Text)
    '        totalt91t120 = totalt91t120 + Convert.ToDouble(e.Row.Cells(5).Text)
    '        totalt121t150 = totalt121t150 + Convert.ToDouble(e.Row.Cells(6).Text)
    '        totalt151t180 = totalt151t180 + Convert.ToDouble(e.Row.Cells(7).Text)
    '        totalabove180 = totalabove180 + Convert.ToDouble(e.Row.Cells(8).Text)
    '        totalunAdj = totalunAdj + Convert.ToDouble(e.Row.Cells(9).Text)
    '        agetotal = agetotal + Convert.ToDouble(e.Row.Cells(10).Text)
    '    ElseIf e.Row.RowType = DataControlRowType.Footer Then
    '        e.Row.Cells(0).Text = "Total"
    '        e.Row.Cells(0).ColumnSpan = "2"
    '        e.Row.Cells(0).Font.Bold = True
    '        e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '        e.Row.Cells(1).Text = Math.Round(totalt0t30, 2)
    '        e.Row.Cells(1).Font.Bold = True
    '        e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(2).Text = Math.Round(totalt31t60, 2)
    '        e.Row.Cells(2).Font.Bold = True
    '        e.Row.Cells(3).Text = Math.Round(totalt61t90, 2)
    '        e.Row.Cells(3).Font.Bold = True
    '        e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(4).Text = Math.Round(totalt91t120, 2)
    '        e.Row.Cells(4).Font.Bold = True
    '        e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(5).Text = Math.Round(totalt121t150, 2)
    '        e.Row.Cells(5).Font.Bold = True
    '        e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(6).Text = Math.Round(totalt151t180, 2)
    '        e.Row.Cells(6).Font.Bold = True
    '        e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(7).Text = Math.Round(totalabove180, 2)
    '        e.Row.Cells(7).Font.Bold = True
    '        e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(8).Text = Math.Round(totalunAdj, 2)
    '        e.Row.Cells(8).Font.Bold = True
    '        e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(9).Text = Math.Round(agetotal, 2)
    '        e.Row.Cells(9).Font.Bold = True
    '        e.Row.Cells(10).Visible = False
    '        'e.Row.Cells(11).Visible = False
    '    End If
    'End Sub
    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim isUpdateVisible As Boolean = False
        Dim chk As CheckBox = TryCast(sender, CheckBox)
        If chk.ID = "chkAll" Then
            For Each row As GridViewRow In gvInvoiceReport.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = chk.Checked
                    If chk.Checked = True Then
                        CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = True
                        'CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Enabled = True
                        CType(row.Cells(0).FindControl("txtOther"), TextBox).Enabled = True
                        CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Text = CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Text.Replace(",", "")
                        CType(row.Cells(0).FindControl("txtOther"), TextBox).Text = CType(row.Cells(0).FindControl("txtOther"), TextBox).Text.Replace(",", "")
                    Else
                        CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = False
                        ' CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Enabled = False
                        CType(row.Cells(0).FindControl("txtOther"), TextBox).Enabled = False
                    End If
                End If
            Next
        End If
        Dim chkAll As CheckBox = TryCast(gvInvoiceReport.HeaderRow.FindControl("chkAll"), CheckBox)
        chkAll.Checked = True
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = True
                    'CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Enabled = True
                    CType(row.Cells(0).FindControl("txtOther"), TextBox).Enabled = True
                    'CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Text = CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Text.Replace(",", "")
                    CType(row.Cells(0).FindControl("txtOther"), TextBox).Text = CType(row.Cells(0).FindControl("txtOther"), TextBox).Text.Replace(",", "")
                Else
                    CType(row.Cells(0).FindControl("txtComment"), TextBox).Enabled = False
                    'CType(row.Cells(0).FindControl("txtExpectedPayment"), TextBox).Enabled = True
                    CType(row.Cells(0).FindControl("txtOther"), TextBox).Enabled = False
                End If
            End If
        Next

    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
            dblCargoTotal = dblCargoTotal + Convert.ToDouble(e.Row.Cells(3).Text)
            dblCuns = dblCuns + Convert.ToDouble(e.Row.Cells(4).Text)
            dblMum = dblMum + Convert.ToDouble(e.Row.Cells(5).Text)
            dblTotal = dblTotal + Convert.ToDouble(e.Row.Cells(7).Text)
            totalOverDue = totalOverDue + Convert.ToDouble(e.Row.Cells(8).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).ColumnSpan = "3"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            e.Row.Cells(1).Text = Math.Round(dblCargoTotal, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).Text = Math.Round(dblCuns, 2)
            e.Row.Cells(2).Font.Bold = True

            e.Row.Cells(3).Text = Math.Round(dblMum, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(4).Text = ""
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(5).Text = Math.Round(dblTotal, 2)
            e.Row.Cells(5).Font.Bold = True
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(6).Text = Math.Round(totalOverDue, 2)
            e.Row.Cells(6).Font.Bold = True
            'e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        For Each row As GridViewRow In gvInvoiceReport.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnCustomerId As HiddenField = TryCast(row.Cells(0).FindControl("hdnCustomerId"), HiddenField)
                    Dim txtComment As TextBox = TryCast(row.Cells(0).FindControl("txtComment"), TextBox)
                    'Dim txtExpectedPayment As TextBox = TryCast(row.Cells(0).FindControl("txtExpectedPayment"), TextBox)
                    Dim txtother As TextBox = TryCast(row.Cells(0).FindControl("txtOther"), TextBox)
                    Dim hdnCustType As HiddenField = TryCast(row.Cells(0).FindControl("hdnCustType"), HiddenField)
                    Dim strHdnType As String
                    Try
                        strHdnType = hdnButtonType.Value
                    Catch ex As Exception
                        strHdnType = "0"
                    End Try
                    Dim strCustType As String
                    Try
                        strCustType = hdnCustType.Value
                    Catch ex As Exception
                        strCustType = ""
                    End Try
                    If strHdnType = "T" Then
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE VENDOR_MASTER SET CASH=" & txtother.Text.Trim & ", OUTSTANDING_COMMENT='" & txtComment.Text & "',OUTSTANDING_UPDATE_BY='" & Session.Item("LoginUser") & "', OUTSTANDING_UPDATE_ON=SYSDATE WHERE VENDOR_ID='" & hdnCustomerId.Value & "' AND 'V' = '" & strCustType & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE CUSTOMER_MASTER SET CASH=" & txtother.Text.Trim & ", OUTSTANDING_COMMENT='" & txtComment.Text & "',OUTSTANDING_UPDATE_BY='" & Session.Item("LoginUser") & "', OUTSTANDING_UPDATE_ON=SYSDATE WHERE CUSTOMER_ID='" & hdnCustomerId.Value & "' AND 'C' = '" & strCustType & "'", con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                End If
                gvInvoiceReport.EditIndex = -1
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
            End If
            'End If
        Next
        btnSave.Visible = False
        Try
            Dim strpParms As String = ""
            'strpParms &= lstCustomerName.SelectedValue
            BindSummary(strpParms)
            'Dim dbr As OleDb.OleDbDataReader
            'Dim db As New DBConnect
            'dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUS_OUT_STAND_SUMM", strpParms)
            'gvInvoiceReport.DataSource = dbr
            'gvInvoiceReport.DataBind()
            'If dbr.HasRows = False Then
            '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
            'End If
            'dbr.Close()
            'db.CloseDB()
            'tblReport.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        ExcelSummary()
    End Sub
    Sub ExcelSummary()
        Dim sb As New StringBuilder
        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=CREDITORS LIST.xls")
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
            sb.Append("CREDITORS LIST " + Now.Date)
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
            sb.Append("JSB CARGO")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("JSB CONSULTANT")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("JSB MUMBAI")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("OTHER")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("TOTAL")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("Over Due")
            sb.Append("</td>")
            sb.Append("<td>")
            sb.Append("COMMENT")
            sb.Append("</td>")
            sb.Append("</tr>")
            Dim pStr As String = ""
            Dim xMailSetup As String = ""
            Dim SR As Long = 0
            Dim adaDwellEXP As OleDbDataAdapter = New OleDbDataAdapter
            Dim cmdDwellEXP As OleDbCommand = con.CreateCommand
            cmdDwellEXP.Connection = con
            cmdDwellEXP.CommandType = CommandType.StoredProcedure
            procParam &= "'" & hdnButtonType.Value & "'," & 0
            If hdnButtonType.Value = "T" Then
                procName = "REPORT_PKG.SP_TRUCKER_CREDIT_SUMM"
            Else
                procName = "REPORT_PKG.SP_CUS_CREDIT_SUMM"
            End If
            cmdDwellEXP.CommandText = procName & "(" & procParam & ")"
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
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("CARGO"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("CON"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("MUM"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("OTHER"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("TOTAL"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("OVER_DUE"))
                sb.Append("</td>")
                sb.Append("<td>")
                sb.Append(dsDwellEXP.Tables(0).Rows(i)("COMMENTT"))
                sb.Append("</td>")
                TotCargo = TotCargo + dsDwellEXP.Tables(0).Rows(i)("CARGO")
                TotCon = TotCon + dsDwellEXP.Tables(0).Rows(i)("CON")
                TotMum = TotMum + dsDwellEXP.Tables(0).Rows(i)("MUM")
                Total = Total + dsDwellEXP.Tables(0).Rows(i)("TOTAL")
                Totother = Totother + dsDwellEXP.Tables(0).Rows(i)("OTHER")
                sb.Append("</tr>")

            Next
            sb.Append("<tr>")
            sb.Append("<td colspan='2'>")
            sb.Append("Total")
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(TotCargo)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(TotCon)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(TotMum)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(Totother)
            sb.Append("</td>")
            sb.Append("<td >")
            sb.Append(Total)
            sb.Append("</td>")
            sb.Append("<td >")

            sb.Append("</td>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("<tr>")
            sb.Append("</tr>")
            sb.Append("</table>")
        End If
        'If tblreport1.Visible = True Then
        '    sb.Append("DEBTORS LIST AGEING WISE " + Now.Date)
        '    sb.Append(Space(4) & vbCrLf)
        '    sb.Append(Space(4) & vbCrLf)
        '    sb.Append("<table border='1'>")
        '    sb.Append("<tr>")
        '    sb.Append("</tr>")
        '    sb.Append("<tr>")
        '    sb.Append("<td>")
        '    sb.Append("S.No")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("Customer Name")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("0To30")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("31To60")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("61To90")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("91To120")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("121To150")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("151To180")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("Above 180")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("Unadjusted Amount")
        '    sb.Append("</td>")
        '    sb.Append("<td>")
        '    sb.Append("Total")
        '    sb.Append("</td>")
        '    sb.Append("</tr>")
        '    Dim SR1 As Long = 0
        '    Dim AdaAgeing As OleDbDataAdapter = New OleDbDataAdapter
        '    Dim cmdAgeing As OleDbCommand = con.CreateCommand
        '    cmdAgeing.Connection = con
        '    cmdAgeing.CommandType = CommandType.StoredProcedure
        '    procParam &= lstCustomerName.SelectedValue
        '    'procParam &= ds.Tables(0).Rows(J)("CUSTOMER_ID")
        '    procName = "select_PKG.SP_AGE_DEBITOR_LIST"
        '    cmdAgeing.CommandText = procName & "(" & procParam & ")"
        '    AdaAgeing.SelectCommand = cmdAgeing
        '    Dim dsAgeing As New DataSet
        '    AdaAgeing.Fill(dsAgeing)
        '    For i = 0 To dsAgeing.Tables(0).Rows.Count - 1
        '        SR1 = SR1 + 1
        '        Dim ageing As String = ""
        '        sb.Append("<tr>")
        '        sb.Append("<td>")
        '        sb.Append((SR1))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("CUSTOMER_NAME"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE0T30"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE31T60"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE61TO90"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE91T120"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE121TO150"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGE151T180"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("AGEABOVE180"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("UN_ADJ"))
        '        sb.Append("</td>")
        '        sb.Append("<td>")
        '        sb.Append(dsAgeing.Tables(0).Rows(i)("TOTAL"))
        '        sb.Append("</td>")
        '        totalt0t30 = totalt0t30 + dsAgeing.Tables(0).Rows(i)("AGE0T30")
        '        totalt31t60 = totalt31t60 + dsAgeing.Tables(0).Rows(i)("AGE31T60")
        '        totalt61t90 = totalt61t90 + dsAgeing.Tables(0).Rows(i)("AGE61TO90")
        '        totalt91t120 = totalt91t120 + dsAgeing.Tables(0).Rows(i)("AGE91T120")
        '        totalt121t150 = totalt121t150 + dsAgeing.Tables(0).Rows(i)("AGE121TO150")
        '        totalt151t180 = totalt151t180 + dsAgeing.Tables(0).Rows(i)("AGE151T180")
        '        totalabove180 = totalabove180 + dsAgeing.Tables(0).Rows(i)("AGEABOVE180")
        '        totalunAdj = totalunAdj + dsAgeing.Tables(0).Rows(i)("UN_ADJ")
        '        agetotal = agetotal + dsAgeing.Tables(0).Rows(i)("TOTAL")
        '        sb.Append("</tr>")
        '    Next
        '    sb.Append("<tr>")
        '    sb.Append("<td colspan='2'>")
        '    sb.Append("Total")
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt0t30)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt31t60)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt61t90)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt91t120)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt121t150)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalt151t180)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalabove180)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(totalunAdj)
        '    sb.Append("</td>")
        '    sb.Append("<td >")
        '    sb.Append(agetotal)
        '    sb.Append("</td>")
        '    sb.Append("</tr>")
        '    sb.Append("</table>")
        'End If

        Response.Write(sb.ToString())
        Response.End()
    End Sub
    Public Shared Sub CreateWorkBook(ByVal cList As Object, ByVal wbName As String, ByVal CellWidth As Integer)
        Dim attachment As String = "attachment; filename=""" & wbName & ".xls"""
        HttpContext.Current.Response.ClearContent()
        HttpContext.Current.Response.AddHeader("content-disposition", attachment)
        HttpContext.Current.Response.ContentType = "application/ms-excel"
        Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
        sw.WriteLine("<?xml version=""1.0""?>")
        sw.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
        sw.WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
        sw.WriteLine("xmlns:o=""urn:schemas-microsoft-com:office:office""")
        sw.WriteLine("xmlns:x=""urn:schemas-microsoft-com:office:excel""")
        sw.WriteLine("xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
        sw.WriteLine("xmlns:html=""http://www.w3.org/TR/REC-html40"">")
        sw.WriteLine("<DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">")
        sw.WriteLine("<LastAuthor>Try Not Catch</LastAuthor>")
        sw.WriteLine("<Created>2010-05-15T19:14:19Z</Created>")
        sw.WriteLine("<Version>11.9999</Version>")
        sw.WriteLine("</DocumentProperties>")
        sw.WriteLine("<ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">")
        sw.WriteLine("<WindowHeight>9210</WindowHeight>")
        sw.WriteLine("<WindowWidth>19035</WindowWidth>")
        sw.WriteLine("<WindowTopX>0</WindowTopX>")
        sw.WriteLine("<WindowTopY>90</WindowTopY>")
        sw.WriteLine("<ProtectStructure>False</ProtectStructure>")
        sw.WriteLine("<ProtectWindows>False</ProtectWindows>")
        sw.WriteLine("</ExcelWorkbook>")
        sw.WriteLine("<Styles>")
        sw.WriteLine("<Style ss:ID=""Default"" ss:Name=""Normal"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom""/>")
        sw.WriteLine("<Borders/>")
        sw.WriteLine("<Font/>")
        sw.WriteLine("<Interior/>")
        sw.WriteLine("<NumberFormat/>")
        sw.WriteLine("<Protection/>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s22"">")
        sw.WriteLine("<Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("<Font ss:Bold=""1""/>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s23"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("</Style>")
        sw.WriteLine("<Style ss:ID=""s24"">")
        sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
        sw.WriteLine("<Borders>")
        sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
        sw.WriteLine("ss:Color=""#000000""/>")
        sw.WriteLine("</Borders>")
        sw.WriteLine("<Font ss:Color=""#FFFFFF""/>")
        sw.WriteLine("<Interior ss:Color=""#191970"" ss:Pattern=""Solid""/>") 'set header colour here
        sw.WriteLine("</Style>")
        sw.WriteLine("</Styles>")
        For Each gView As GridView In cList
            'Try
            '    If gView.ID.ToString = "gvsummary" Then
            '        CreateWorkSheet("Summary", sw, gView, CellWidth)
            '    ElseIf gView.ID.ToString = "gvExport" Then
            '        'gView.ID =
            '        CreateWorkSheet("20", sw, gView, CellWidth)
            '    ElseIf gView.ID.ToString = "gvDomestic" Then
            '        CreateWorkSheet("B/I 20", sw, gView, CellWidth)
            '        ' gView.ID = "B/I 20"
            '    ElseIf gView.ID.ToString = "gvImport" Then
            '        CreateWorkSheet("40", sw, gView, CellWidth)
            '        ' gView.ID = "40"
            '    ElseIf gView.ID.ToString = "GVI40" Then
            '        'gView.ID = "B/I 40"
            '        CreateWorkSheet("B/I 40", sw, gView, CellWidth)
            '    End If


            'Catch ex As Exception
            'End Try
            CreateWorkSheet(gView.ID.ToString, sw, gView, CellWidth)
        Next
        sw.WriteLine("</Workbook>")
        HttpContext.Current.Response.Write(sw.ToString())
        HttpContext.Current.Response.End()
    End Sub
    Private Shared Sub CreateWorkSheet(ByVal wsName As String, ByVal sw As System.IO.StringWriter, ByVal gv As GridView, ByVal cellwidth As Integer)
        If IsNothing(gv.HeaderRow) = False Then
            If wsName = "gvInvoiceReport" Then
                wsName = "Outstanding"
                'ElseIf wsName = "GVPVT" Then
                '    wsName = "PVT"
                'ElseIf wsName = "gvsummary" Then
                '    wsName = "Summary"
                'ElseIf wsName = "gvDomestic" Then
                '    wsName = "Idel20"
                'ElseIf wsName = "gvImport" Then
                '    wsName = "40"
                'ElseIf wsName = "GVI40" Then
                '    wsName = "Idel40"
            End If

            sw.WriteLine("<Worksheet ss:Name=""" & wsName & """>")
            Dim cCount As Integer = gv.HeaderRow.Cells.Count
            Dim rCount As Long = gv.Rows.Count + 1
            sw.WriteLine("<Table ss:ExpandedColumnCount=""" & cCount & """ ss:ExpandedRowCount=""" & rCount & """ x:FullColumns=""1""")
            sw.WriteLine("x:FullRows=""1"">")
            For i As Integer = (cCount - cCount) To (cCount - 1)
                sw.WriteLine("<Column ss:AutoFitWidth=""1"" ss:Width=""" & cellwidth & """/>")
            Next

            GridRowIterate(gv, sw)
            sw.WriteLine("</Table>")
            sw.WriteLine("<WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")

            sw.WriteLine("<Selected/>")
            sw.WriteLine("<DoNotDisplayGridlines/>")

            sw.WriteLine("<ProtectObjects>False</ProtectObjects>")
            sw.WriteLine("<ProtectScenarios>False</ProtectScenarios>")

            sw.WriteLine("</WorksheetOptions>")
            sw.WriteLine("</Worksheet>")
        End If
    End Sub
    Private Shared Sub GridRowIterate(ByVal gv As GridView, ByVal sw As System.IO.StringWriter)
        sw.WriteLine("<Row>")

        For Each tc As TableCell In gv.HeaderRow.Cells
            Dim tcText As String = tc.Text

            Dim tcWidth As String = gv.Width.Value
            Dim dType As String = "String"

            If IsNumeric(tcText) = True Then

                dType = "Number"

            End If
            sw.WriteLine("<Cell ss:StyleID=""s24""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

        Next
        sw.WriteLine("</Row>")

        For Each gr As GridViewRow In gv.Rows
            sw.WriteLine("<Row>")

            For Each gc As TableCell In gr.Cells
                Dim gcText As String = gc.Text
                Dim dType As String = "String"

                If IsNumeric(gcText) = True Then

                    dType = "Number"
                    gcText = CDbl(gcText)

                End If
                sw.WriteLine("<Cell ss:StyleID=""s23""><Data ss:Type=""" & dType & """>" & gcText & "</Data></Cell>")

            Next
            sw.WriteLine("</Row>")
        Next

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'ListControlDataBind()
            Dim str As String = ""
            BindSummary(str)
        End If
    End Sub
    Sub BindSummary(ByVal str As String)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strpParms As String = ""
        'strpParms &= lstCustomerName.SelectedValue
        strpParms &= "'" & str & "'," & 0
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CUS_CREDIT_SUMM", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        End If
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True
    End Sub
    Protected Sub btnSend_Click(sender As Object, e As System.EventArgs) Handles btnSend.Click
        loadedout()
    End Sub
    Function loadedout() As String
        Dim pStr As String = ""
        Dim xMailSetup As String = ""
        Dim strConnectionString As String
        Dim con As OleDbConnection
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        strConnectionString = "Provider=MSDAORA;Data Source=115.124.127.54;Persist Security Info=True;Password=spj;User ID=spj"
        con = New OleDbConnection(strConnectionString)
        con.Open()

        Dim SR As Long = 0
        Dim confirmMail As New StringBuilder
        confirmMail.AppendLine("<table style='width: 900px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
        confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='6'  >")
        confirmMail.Append("<b>CREDITORS LIST</b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Sr.</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 380px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Customer Name</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>JSB Cargo</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>JSB Consultant</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>JSB Mumbai</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Total</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")
        Dim adaDwellEXP As OleDbDataAdapter = New OleDbDataAdapter
        Dim cmdDwellEXP As OleDbCommand = con.CreateCommand
        cmdDwellEXP.Connection = con
        cmdDwellEXP.CommandType = CommandType.StoredProcedure
        Dim procName As String = ""
        Dim procParam As String = ""
        procParam &= "'" & hdnButtonType.Value & "'," & 0
        'procParam &= ds.Tables(0).Rows(J)("CUSTOMER_ID")
        procName = "REPORT_PKG.SP_CUS_CREDIT_SUMM"
        cmdDwellEXP.CommandText = procName & "(" & procParam & ")"
        adaDwellEXP.SelectCommand = cmdDwellEXP
        Dim dsDwellEXP As New DataSet
        adaDwellEXP.Fill(dsDwellEXP)
        For i = 0 To dsDwellEXP.Tables(0).Rows.Count - 1
            SR = SR + 1
            Dim ageing As String = ""
            ' ageing = dsDwellEXP.Tables(0).Rows(i)("DWEEL")
            confirmMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
            confirmMail.Append("<td style='width: 20px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(SR)
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 380px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(dsDwellEXP.Tables(0).Rows(i)("CUSTOMER_NAME"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(dsDwellEXP.Tables(0).Rows(i)("CARGO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(dsDwellEXP.Tables(0).Rows(i)("CON"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(dsDwellEXP.Tables(0).Rows(i)("MUM"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 22px'>")
            confirmMail.Append(dsDwellEXP.Tables(0).Rows(i)("TOTAL"))
            confirmMail.Append(" </td>")
            TotCargo = TotCargo + dsDwellEXP.Tables(0).Rows(i)("CARGO")
            TotCon = TotCon + dsDwellEXP.Tables(0).Rows(i)("CON")
            TotMum = TotMum + dsDwellEXP.Tables(0).Rows(i)("MUM")
            Total = Total + dsDwellEXP.Tables(0).Rows(i)("TOTAL")
            confirmMail.Append(" </tr>")
        Next
        confirmMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
        confirmMail.Append("<td style='width: 400px; font-size: 10pt; height: 5px' colspan='2' >")
        confirmMail.Append("Total")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(Format(CInt(TotCargo), "##,##,###"))
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(Format(CInt(TotCon), "##,##,###"))
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(Format(CInt(TotMum), "##,##,###"))
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append(Format(CInt(Total), "##,##,###"))
        confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("</table>")
        'Dim TOT As String = AmtInWord(Math.Round(totPlan, 2))
        Dim TOT1 As String = AmtInWord(Math.Round(Total, 2))
        Dim adamailconfig As OleDbDataAdapter
        Dim cmdmailconfig As String

        cmdmailconfig = "SELECT FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=1"

        adamailconfig = New OleDbDataAdapter(cmdmailconfig, con)
        Dim dsmailconfig As New DataSet
        adamailconfig.Fill(dsmailconfig)

        Dim adamailsetup As OleDbDataAdapter
        Dim cmdmailsetup As String
        cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=444"

        adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
        Dim dsmailsetup As New DataSet
        adamailsetup.Fill(dsmailsetup)
        'xMailSetup = "<font color='#00008B'>Dear Sir,<br><br>Please check pendency for bills. If not generated please make it.<br><br><br><br></font>"
        xMailSetup = confirmMail.ToString
        'xMailSetup &= "<br/>"
        'xMailSetup &= "<br/>"
        xMailSetup &= " <font color='#00008B' size= '10pt'> <b> Total Outstanding Payment : </b></font> "
        xMailSetup &= "<font size= '10pt'>" & TOT1 & "</font> "
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "<br/>"
        xMailSetup &= "<font color='#00008B'>Thanks n best regards, " & "<br><br>Billing Team<br></font><br><b><font color='Red'>JSB CARGO MOVERS PVT. LTD.</b></font><font color='#00008B'><br>Regd. Office : Ground Floor, 61, Durga Park,Dallupura, Delhi-110096 <br> Admin Office : Room No-02, 636, Sector-1, Vaishali, Ghaziabad (U.P.) <br>Tel/Fax NO.: +91-120-4263512,0120-4263513,<br> Website:http://www.jsb.in </font>"
        Dim strCCID As String = ""
        Try
            strCCID = dsmailsetup.Tables(0).Rows(0)("CC_IDS")
        Catch
            strCCID = ""
        End Try
        Dim strBccID As String = ""
        Try
            strBccID = dsmailsetup.Tables(0).Rows(0)("BCC_IDS")
        Catch
            strBccID = ""
        End Try
        Dim SUBJECT As String = "CREDITOS LIST"
        'pStr = Functions.sendMailToCcBccID("vrohit248@gmail.com", dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), "lalit@elogisol.in", "lalit@elogisol.in", "lalit@elogisol.in", SUBJECT, xMailSetup, "mail.jsb.in", "01!@INjsb18", "25")
        pStr = Functions.sendMailToCcBccID("vrohit248@gmail.com", dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), "vrohit248@gmail.com", "vrohit248@gmail.com", "amit.kumar@elogisol.in", SUBJECT, xMailSetup, "mail.jsb.in", "01", "25")
        'pStr = Functions.sendMailToCcBccID("vrohit248@gmail.com", dsmailconfig.Tables(0).Rows(0)("FROM_NAME"), dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS"), strCCID, strBccID, SUBJECT, xMailSetup, "mail.jsb.in", "01!@INjsb18", "25")
        If pStr = Nothing Then
            lblErrorMessage.Text = "Mail Sent "
        Else
            lblErrorMessage.Text = "Mail Sent fail "
        End If
        lblErrorMessage.Visible = True
    End Function
    Shared Function AmtInWord(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        AmtInWord = StrWord & " Only"
        Return AmtInWord
    End Function
    Shared Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function
    Shared Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function
    Shared Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function
    Shared Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function

    Shared Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function

    Protected Sub BtnLine_Click(sender As Object, e As System.EventArgs) Handles BtnLine.Click
        Dim str As String = "L"
        hdnButtonType.Value = "L"
        BindSummary(str)
    End Sub

    Protected Sub BtnVendor_Click(sender As Object, e As System.EventArgs) Handles BtnVendor.Click
        Dim str As String = "V"
        hdnButtonType.Value = "V"
        BindSummary(str)
    End Sub

    Protected Sub BtnAll_Click(sender As Object, e As System.EventArgs) Handles BtnAll.Click
        Dim str As String = ""
        hdnButtonType.Value = ""
        BindSummary(str)
    End Sub

    Protected Sub BtnTrucker_Click(sender As Object, e As System.EventArgs) Handles BtnTrucker.Click
        Dim str As String = "T"
        hdnButtonType.Value = "T"
        BindSummaryTrucker(str)
    End Sub

    Sub BindSummaryTrucker(ByVal str As String)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strpParms As String = ""
        'strpParms &= lstCustomerName.SelectedValue
        strpParms &= "'" & str & "'," & 0
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TRUCKER_CREDIT_SUMM", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        End If
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True
    End Sub
    Sub BindSummaryMaint(ByVal str As String)
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strpParms As String = ""
        'strpParms &= lstCustomerName.SelectedValue
        strpParms &= "'" & str & "'," & 0
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MAINT_CREDIT_SUMM", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        End If
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True
    End Sub



    Protected Sub BtnMaintenance_Click(sender As Object, e As System.EventArgs) Handles BtnMaintenance.Click
        Dim str As String = "M"
        hdnButtonType.Value = "M"
        BindSummaryMaint(str)
    End Sub

    Protected Sub btnCHA_Click(sender As Object, e As System.EventArgs) Handles btnCHA.Click
        Dim str As String = "C"
        hdnButtonType.Value = "C"
        BindSummary(str)
    End Sub
End Class
