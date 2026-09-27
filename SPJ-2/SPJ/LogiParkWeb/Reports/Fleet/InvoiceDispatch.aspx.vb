Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_InvoiceDispatch
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
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            BindData()
        End If
    End Sub
    Private Sub BindData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= 0
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_DISPATCH_PENDING_MAIL", strpParms)
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
        textDispatchDate.Text = ""
        lstCustomer.SelectedValue = 0
        lstMedium.SelectedValue = 0
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

    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            Dim pCustomerMaster As New CustomerMaster
            lstCustomer.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
            lstCustomer.DataTextField = "CustomerName"
            lstCustomer.DataValueField = "CustomerId"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCustomer.SelectedValue = 0
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstCustomer.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_INV_DISPATCH_PENDING_MAIL", strpParms)
        
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
    
    Protected Sub EditAllParty(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        gvtripPendencyList.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub CancelEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        gvtripPendencyList.EditIndex = -1
        BindData()
    End Sub
    Protected Sub AllPartyUpdate(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Dim hdnInvoiceNo As HiddenField = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("hdnInvoiceNo"), HiddenField)
        Dim ddlDispatchMedium As DropDownList = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("ddlDispatchMedium"), DropDownList)
        Dim textlDispatchDate As TextBox = TryCast(gvtripPendencyList.Rows(e.RowIndex).FindControl("txtDispatchDate"), TextBox)

        con = New OleDbConnection(cs)
        con.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET DISPATCH=" & Convert.ToInt32(ddlDispatchMedium.SelectedValue) & ",DISPATCH_DATE=""TO_DATE('" & textlDispatchDate.Text & "','DD/MM/YYYY'), WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnInvoiceNo.Value), con)
        cmd.ExecuteNonQuery()
        con.Close()
        gvtripPendencyList.EditIndex = -1
        BindData()
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
    End Sub
   
    Protected Sub OnCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        ImgBtnUpdate.Visible = True
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
                If isChecked Then
                    Dim hdnInvoiceNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnInvoiceNo"), HiddenField)
                    Dim ddlDispatchMedium As DropDownList = TryCast(row.Cells(0).FindControl("ddlDispatchMedium"), DropDownList)
                    Dim textlDispatchDate As TextBox = TryCast(row.Cells(0).FindControl("txtDispatchDate"), TextBox)

                    'Dim strConnectionString, cmd1 As String
                    'Dim con As OleDbConnection
                    'Dim ada As OleDbDataReader
                    'strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
                    'cmd1 = "SELECT nvl(DISPATCH_STATUS,0), DISPATCH_DATE FROM IMP_INVOICE WHERE INVOICE_NO=" & Convert.ToInt32(hdnInvoiceNo.Value)
                    'con = New OleDbConnection(strConnectionString)
                    'con.Open()
                    'Dim cmd As New OleDbCommand()
                    'cmd.Connection = con
                    'cmd.CommandText = cmd1
                    'ada = cmd.ExecuteReader
                    'ada.Read()
                    'Try
                    '    ddlDispatchMedium.SelectedValue = ada.GetValue(0)
                    'Catch ex As Exception
                    'End Try
                    'Try
                    '    textlDispatchDate.Text = ada.GetValue(1)
                    'Catch ex As Exception
                    'End Try
                    Try
                        If ddlDispatchMedium.SelectedValue = "0" Then
                            If lstMedium.SelectedItem.Text <> "" Then
                                ddlDispatchMedium.SelectedValue = lstMedium.SelectedValue
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If textlDispatchDate.Text = "" Then
                            If textDispatchDate.Text <> "" Then
                                textlDispatchDate.Text = textDispatchDate.Text
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    
                    'con.Close()
                End If
            End If
        Next
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                For i As Integer = 1 To row.Cells.Count - 1
                    'row.Cells(i).FindControl("txtDispatchDate").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblRemark").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblBL_NO").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblPOL").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblETD").Visible = Not isChecked
                    'row.Cells(i).FindControl("lblREQUIRED_VESSEL").Visible = Not isChecked

                    If row.Cells(i).Controls.OfType(Of DropDownList)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of DropDownList)().FirstOrDefault().Visible = isChecked
                    End If
                    If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    End If
                    If row.Cells(i).Controls.OfType(Of TextBox)().ToList().Count > 0 Then
                        row.Cells(i).Controls.OfType(Of TextBox)().FirstOrDefault().Visible = isChecked
                    End If
                    If isChecked AndAlso Not isUpdateVisible Then
                        isUpdateVisible = True
                    End If
                    If Not isChecked Then
                        chkAll.Checked = False
                    End If
                Next
            End If
        Next

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub ImgBtnUpdate_Click(sender As Object, e As EventArgs) Handles ImgBtnUpdate.Click
        For Each row As GridViewRow In gvtripPendencyList.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim isChecked As Boolean = row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked
                If isChecked Then
                    Dim hdnInvoiceNo As HiddenField = TryCast(row.Cells(0).FindControl("hdnInvoiceNo"), HiddenField)
                    Dim ddlDispatchMedium As DropDownList = TryCast(row.Cells(0).FindControl("ddlDispatchMedium"), DropDownList)
                    Dim textlDispatchDate As TextBox = TryCast(row.Cells(0).FindControl("txtDispatchDate"), TextBox)
                    'Dim txtBL_NO As TextBox = TryCast(row.Cells(0).FindControl("txtBL_NO"), TextBox)
                    'Dim txtLINE_HANDOVER_DATE As TextBox = TryCast(row.Cells(0).FindControl("txtLINE_HANDOVER_DATE"), TextBox)
                    'Dim ddlPOL As DropDownList = TryCast(row.Cells(0).FindControl("ddlPOL"), DropDownList)
                    'Dim txtTrainNo As TextBox = TryCast(row.Cells(0).FindControl("txtTrainNo"), TextBox)
                    'Dim txtOutDate As TextBox = TryCast(row.Cells(0).FindControl("txtOutDate"), TextBox)
                    'Dim txtETD As TextBox = TryCast(row.Cells(0).FindControl("txtETD"), TextBox)
                    'Dim txtREQUIRED_VESSEL As TextBox = TryCast(row.Cells(0).FindControl("txtREQUIRED_VESSEL"), TextBox)
                    'Try
                    If ddlDispatchMedium.SelectedValue = 0 Then
                        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select Dispatch Medium")
                        Functions.ControlFocus(ddlDispatchMedium)
                        Return
                    End If
                    Try
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cmd As OleDbCommand = New OleDbCommand("UPDATE IMP_INVOICE SET DISPATCH_STATUS=" & Convert.ToInt32(ddlDispatchMedium.SelectedValue) & ",DISPATCH_DATE=TO_DATE('" & textlDispatchDate.Text & "','DD/MM/YYYY') WHERE INVOICE_NO= " & Convert.ToInt32(hdnInvoiceNo.Value), con)
                        'nvert.ToInt32(ddlCFS.SelectedValue) & ",BOOKING_NO = '" & txtBL_NO.Text & "',POL_ID = " & ddlPOL.SelectedValue & ",POL='" & ddlPOL.SelectedItem.Text & "',TRAIN_NO='" & txtTrainNo.Text.Trim & "',TRAIN_OUT_DATE=TO_DATE('" & txtOutDate.Text.Trim & "','DD/MM/YYYY'),REQUIRED_ETD=TO_DATE('" & txtETD.Text & "','DD/MM/YYYY'),REQUIRED_VESSEL='" & txtREQUIRED_VESSEL.Text & "',CURRENT_ETD=TO_DATE('" & txtETD.Text & "','DD/MM/YYYY'),CURRENT_VESSEL='" & txtREQUIRED_VESSEL.Text & "' WHERE MTY_CONT_ID= " & Convert.ToInt32(hdnMTY_CONT_ID.Value), con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try

                    gvtripPendencyList.EditIndex = -1
                    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Update Successfully")
                End If
            End If
        Next
        ImgBtnUpdate.Visible = False
        BindData()
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvtripPendencyList
        ' myN += 1
        CreateWorkBook(myGridViews, "Invoice Dispatch Status", 80)

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
            If wsName = "gvtripPendencyList" Then
                wsName = "Invoice Dispatch Status"
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

    Protected Sub gvtripPendencyList_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvtripPendencyList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(1).Text = intCounter
        End If
    End Sub
End Class
