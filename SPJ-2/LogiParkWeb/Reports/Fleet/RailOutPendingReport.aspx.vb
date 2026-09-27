Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_RailOutPendingReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindData()
            ListControlDataBind()
        End If
    End Sub
    Private Sub BindData()
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        textFromDate.Text = Format(Now.Date, "dd/MM/yyyy")
        textToDate.Text = Format(Now.Date, "dd/MM/yyyy")
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= 0
        strpParms &= "," & 0
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'U',0,0"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RAIL_OUT_PENDING_REPORT", strpParms)
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
            Dim pTerminalMaster As New TerminalMaster
            pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            lstCFS.DataTextField = "TerminalName"
            lstCFS.DataValueField = "TerminalId"
            lstCFS.DataBind()
            lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            lstCFS.SelectedValue = 0
            Dim pPortMaster As New PortMaster
            lstPOL.DataSource = PortMaster.ReturnPortMasterIndiaGateway(pPortMaster)
            lstPOL.DataTextField = "PortName"
            lstPOL.DataValueField = "PortId"
            lstPOL.DataBind()
            lstPOL.Items.Insert(0, (New ListItem("---All---", 0)))
            lstPOL.SelectedValue = 0
            Dim pCustomerMaster As New CustomerMaster
            lstLine.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            lstLine.DataTextField = "CustomerName"
            lstLine.DataValueField = "CustomerId"
            lstLine.DataBind()
            lstLine.Items.Insert(0, (New ListItem("---All---", 0)))
            lstLine.SelectedValue = 0
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
        'prepareTerminalData()
        'preparePortData()

        lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = "0"
        strpParms &= lstCFS.SelectedValue
        strpParms &= "," & lstPOL.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstInvoiceStatus.SelectedValue & "'"
        strpParms &= "," & lstCFS.SelectedValue
        'strpParms &= "," & lstPOL.SelectedValue
        strpParms &= "," & lstLine.SelectedValue
        'strpParms &= ",'" & textToDate.Text & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RAIL_OUT_PENDING_REPORT", strpParms)
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
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvtripPendencyList
        ' myN += 1
        CreateWorkBook(myGridViews, "RailOutPendingReport", 80)

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
                wsName = "Rail Out Pending"
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
End Class
