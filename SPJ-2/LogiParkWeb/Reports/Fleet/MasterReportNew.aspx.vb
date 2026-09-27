Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_MasterReportNew
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Dim Total As Long = 0
    Shared tableGroupCode As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Dim serviceType = ""

            lblTotal1.Visible = False
            Dim strCurrentDate As String
            Dim strFromDate As String
            Dim strToDate As String
            textFromDate.Text = Format(Now, "dd/MM/yyyy")
            textToDate.Text = Format(Now, "dd/MM/yyyy")
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
            strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")
            ListControlDataBind()

            Dim strpParms As String = ""
            strpParms &= "'" & textFromDate.Text & "'"
            strpParms &= ",'" & textToDate.Text & "'"
            strpParms &= "," & LstShipper.SelectedValue & ""
            strpParms &= "," & LstShipper.SelectedValue & ""
            strpParms &= "," & lstPod.SelectedValue & ""
            strpParms &= "," & lstPod.SelectedValue & ""

            'Commented 16/12/2022
            'For Each repItem As RepeaterItem In rptTerminal.Items
            '    Dim chk = CType(repItem.FindControl("chkSelect"), CheckBox)
            '    '  If chk.Checked Then
            '    Dim hddTerminalCode = CType(repItem.FindControl("hddTerminalCode"), HiddenField)
            '    If String.IsNullOrEmpty(strpParms) Then
            '        strpParms &= hddTerminalCode.Value
            '    Else
            '        strpParms &= "," & hddTerminalCode.Value
            '    End If
            '    'End If
            'Next
            'End commented
            ' strpParms &= "," & hddTerminalCode.Value & ""
            'strpParms &= "," + str
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SPJ_MASTER_REPORT_NEW", strpParms)
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
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            con = New OleDbConnection(strConnectionString)
            con.Open()
            'Dim pExtTerminalMaster As New TerminalMaster
            'lstTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
            'lstTerminal.DataTextField = "TerminalName"
            'lstTerminal.DataValueField = "TerminalId"
            'lstTerminal.DataBind()
            'lstTerminal.Items.Insert(0, (New ListItem("---Select---", 0)))
            'lstTerminal.SelectedValue = 0


            Dim pPortMaster As New PortMaster
            lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            lstPod.DataTextField = "PortName"
            lstPod.DataValueField = "PortId"
            lstPod.DataBind()
            lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPod.SelectedValue = 0
            'Added 16/12/2022
            Dim pTerminalMaster As New TerminalMaster
            lstTerminalName.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            lstTerminalName.DataTextField = "TerminalName"
            lstTerminalName.DataValueField = "TerminalId"
            lstTerminalName.DataBind()
            lstTerminalName.Items.Insert(0, (New ListItem("---Select", 0)))
            'lstTerminalName.SelectedValue = 0
            Dim pCustomerMaster1 As New CustomerMaster
            LstShipper.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster1)
            LstShipper.DataTextField = "CustomerName"
            LstShipper.DataValueField = "CustomerId"
            LstShipper.DataBind()
            LstShipper.Items.Insert(0, (New ListItem("---All---", 0)))
            LstShipper.SelectedValue = 0
            Dim pLine As New CustomerMaster
            lstline.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pLine)
            lstline.DataTextField = "CustomerName"
            lstline.DataValueField = "CustomerId"
            lstline.DataBind()
            lstline.Items.Insert(0, (New ListItem("---All---", 0)))
            lstline.SelectedValue = 0
            '    Dim params = New Dictionary(Of String, Object) From {{"p_TERMINAL_ID", Session.Item("LoginTerminal")}, {"p_YEAR", 0}}
            '    tableGroupCode = QueryMaster.GetDataTable("SELECT_PKG_NO_OBJ.SP_TERMINAL_MASTER", params)
            '    rptTerminal.DataSource = tableGroupCode        'Commented 16/12/2022
            '    rptTerminal.DataBind()                         'Commented 16/12/2022
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String
        lblTotal1.Visible = True
        gvtripPendencyList.DataSource = Nothing
        gvtripPendencyList.DataBind()
        tblReport.Visible = False

        ' textFromDate.Text = Now.Date
        ' textToDate.Text = Now.Date

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

        ' lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        strFromDate = Me.textFromDate.Text
        strToDate = Me.textToDate.Text

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        ' strpParms &= Session.Item("LoginTerminal")
        strpParms &= "'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        ' strpParms &= "," & LstShipper.SelectedValue

        Dim strShipper As [String] = ""
        For i As Integer = 0 To LstShipper.Items.Count - 1

            If LstShipper.Items(i).Selected Then

                If strShipper = "" Then
                    strShipper = "'" & LstShipper.Items(i).Value
                Else

                    strShipper += "," + LstShipper.Items(i).Value

                End If
            End If
        Next
        strpParms &= "," + strShipper & "'"

        Dim str As [String] = ""
        For i As Integer = 0 To lstline.Items.Count - 1

            If lstline.Items(i).Selected Then

                If str = "" Then
                    str = "'" & lstline.Items(i).Value
                Else

                    str += "," + lstline.Items(i).Value

                End If
            End If
        Next
        strpParms &= "," + str & "'"
        Dim str3 As [String] = ""
        For i As Integer = 0 To lstPod.Items.Count - 1

            If lstPod.Items(i).Selected Then

                If str3 = "" Then
                    str3 = "'" & lstPod.Items(i).Value
                Else

                    str3 += "," + lstPod.Items(i).Value

                End If
            End If
        Next
        strpParms &= "," + str3 & "'"

        'Dim terminalId As String
        'For Each repItem As RepeaterItem In rptTerminal.Items
        '    Dim chk = CType(repItem.FindControl("chkSelect"), CheckBox)
        '    If chk.Checked Then
        '        Dim hddTerminalCode = CType(repItem.FindControl("hddTerminalCode"), HiddenField)
        '        terminalId &= hddTerminalCode.Value + ","
        '    End If
        'Next


        'strpParms &= "," & lstPod.SelectedValue
        'Dim terminalId As String
        'For Each repItem As RepeaterItem In rptTerminal.Items
        '    Dim chk = CType(repItem.FindControl("chkSelect"), CheckBox)
        '    If chk.Checked Then
        '        Dim hddTerminalCode = CType(repItem.FindControl("hddTerminalCode"), HiddenField)
        '        terminalId &= hddTerminalCode.Value + ","
        '    End If
        'Next

        Dim strTerminal As [String] = ""
        For i As Integer = 0 To lstTerminalName.Items.Count - 1

            If lstTerminalName.Items(i).Selected Then

                If strTerminal = "" Then
                    strTerminal = "'" & lstTerminalName.Items(i).Value
                Else

                    strTerminal += "," + lstTerminalName.Items(i).Value

                End If
            End If
        Next

        'End
        'strpParms &= "," + terminalId.TrimEnd(CType(",", Char))        'Commented 16/12/2022
        strpParms &= "," + strTerminal & "'"

        'strpParms &= "," & rptTerminal.DataSource & ""
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_SPJ_MASTER_REPORT_NEW", strpParms)
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

        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvtripPendencyList
        ' myN += 1
        CreateWorkBook(myGridViews, "Master Report", 80)

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
                wsName = "Trip Mis"
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

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    'Protected Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
    '    For i As Integer = 0 To lstTerminalName.Items.Count - 1
    '        lstTerminalName.SetItemChecked(i, True)
    '    Next
    '    Dim checked As Boolean = True   ' Set to True or False, as required.
    '    For i As Integer = 0 To lstTerminalName.Items.Count - 1
    '        lstTerminalName.SetItemChecked(i, checked)
    '    Next
    '    Dim isAllChecked As Boolean = True
    '    For i As Integer = 0 To lstTerminalName.Items.Count - 1
    '        If Not lstTerminalName.GetItemChecked(i) Then
    '            isAllChecked = False
    '            Exit For
    '        End If
    '    Next

    '    lstTerminalName.Checked = isAllChecked
    'End Sub
    Protected Sub Check_UnCheckAll(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstTerminalName.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAll.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub

    Protected Sub CheckBox_Checked_Unchecked(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As ListItem In lstTerminalName.Items
            If Not item.Selected Then
                isAllChecked = False
                Exit For
            End If
        Next

        chkAll.Checked = isAllChecked
    End Sub
    Protected Sub Check_chkAllShipper(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In LstShipper.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllShipper.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub Check_UnCheckAllShipper(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In LstShipper.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllShipper.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub Check_UnCheckAllLine(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstline.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllLine.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub
    Protected Sub Check_UnCheckAllPOD(ByVal sender As Object, ByVal e As EventArgs)
        For Each item As ListItem In lstPod.Items
            If item.Value = 0 Then

            Else
                item.Selected = chkAllPOD.Checked
            End If
            'item.Selected = chkAll.Checked
        Next
    End Sub

    Protected Sub CheckBox_Checked_UncheckedLine(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As ListItem In lstline.Items
            If Not item.Selected Then
                isAllChecked = False
                Exit For
            End If
        Next

        chkAll.Checked = isAllChecked
    End Sub
    Protected Sub CheckBox_Checked_UnCheckAllLine(ByVal sender As Object, ByVal e As EventArgs)
        Dim isAllChecked As Boolean = True
        For Each item As ListItem In lstPod.Items
            If Not item.Selected Then
                isAllChecked = False
                Exit For
            End If
        Next

        chkAll.Checked = isAllChecked
    End Sub
End Class
