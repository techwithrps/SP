Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_MovementSheet
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()

            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            textFromDate.Text = Format(Now, "dd/MM/yyyy")
            textToDate.Text = Format(Now, "dd/MM/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= lstTerminal.SelectedValue
            strpParms &= ",'" & textFromDate.Text & "'"
            strpParms &= ",'" & textToDate.Text & "'"
            strpParms &= "," & lstCustomer.SelectedValue
           strpParms &= "," & lstVehicle.SelectedValue
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_REPORT", strpParms)
            gvGRDetails.DataSource = dbr
            gvGRDetails.DataBind()
            GridViewMerger(gvGRDetails)
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
        Dim strConnectionString, cmd1, cmd2 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'S') ORDER BY CUSTOMER_NAME"
            cmd2 = "SELECT EQUIPMENT_ID,EQUIPMENT_NO FROM FLEET_EQUIPMENT_MASTER"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("Customer")
            ada.Fill(ds)
            lstCustomer.DataSource = ds.Tables(0)
            lstCustomer.DataTextField = "CUSTOMER_NAME"
            lstCustomer.DataValueField = "CUSTOMER_ID"
            lstCustomer.DataBind()
            lstCustomer.Items.Insert(0, (New ListItem("---All---", "0")))
            ds.Clear()

            ada = New OleDbDataAdapter(cmd2, con)
            Dim ds1 As New DataSet("Vehicle")
            ada.Fill(ds1)
            lstVehicle.DataSource = ds1.Tables(0)
            lstVehicle.DataTextField = "EQUIPMENT_NO"
            lstVehicle.DataValueField = "EQUIPMENT_ID"
            lstVehicle.DataBind()
            lstVehicle.Items.Insert(0, (New ListItem("---All---", 0)))
            ds1.Clear()

            Dim pterminal As New TerminalMaster
            lstTerminal.DataSource = TerminalMaster.ReturnTerminalMasterList(pterminal)
            lstTerminal.DataTextField = "TerminalName"
            lstTerminal.DataValueField = "TerminalId"
            lstTerminal.DataBind()
            lstTerminal.Items.Insert(0, (New ListItem("---All---", 0)))
            lstTerminal.SelectedValue = 0


        Catch ex As Exception
        End Try
    End Sub   
      Sub Permission(ByVal P As String)
        Dim PMI As New MenuItemMaster
        PMI.Url = P
        MenuItemMaster.ReturnMenuItemMasterByURL(PMI)
        Session.Item("Title") = PMI.Title
        Dim pJMI As New JobMenuItems
        pJMI.JobId = Session.Item("JobId")
        pJMI.MenuId = PMI.MenuId
        JobMenuItems.ReturnJobMenuItems(pJMI)

        Session.Item("Add") = pJMI.AddPermit
        Session.Item("Edit") = pJMI.EditPermit
        Session.Item("Search") = pJMI.SearchPermit
        Session.Item("Delete") = pJMI.DeletePermit
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvGRDetails.DataSource = Nothing
        gvGRDetails.DataBind()
        tblReport.Visible = False
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
        Dim strpParms As String = ""
        strpParms &= lstTerminal.SelectedValue
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstCustomer.SelectedValue
        strpParms &= "," & lstVehicle.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_MOVEMENT_REPORT", strpParms)
        gvGRDetails.DataSource = dbr
        gvGRDetails.DataBind()
        GridViewMerger(gvGRDetails)
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvGRDetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvGRDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter

        End If
    End Sub
 Public Sub GridViewMerger(ByVal gridView As GridView)
        For rowIndex As Integer = gridView.Rows.Count - 2 To 0 Step -1
            Dim currentRow As GridViewRow = gridView.Rows(rowIndex)
            Dim previousRow As GridViewRow = gridView.Rows(rowIndex + 1)
            If currentRow.Cells(14).Text = previousRow.Cells(14).Text Then
                previousRow.BackColor = Drawing.Color.LightSteelBlue
                currentRow.BackColor = Drawing.Color.LightSteelBlue

            End If

        Next
    End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    Try

    '        Dim strComa = ","
    '        Dim strFileName As String = "MovementSheet.csv"
    '        Dim attachment As String = "attachment; filename=" & strFileName
    '        Dim strb As New StringBuilder()
    '        Response.Clear()
    '        Response.ClearHeaders()
    '        Response.ClearContent()
    '        Response.AddHeader("content-disposition", attachment)
    '        Response.ContentType = "text/csv"
    '        Response.AddHeader("Pragma", "public")

    '        strb.Append(lblScreenTitle.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)
    '        strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
    '        strb.Append(Space(4) & vbCrLf)
    '        Dim strContHeader As String = Nothing
    '        Dim strSummaryHeader As String = Nothing
    '        strContHeader = lblrSrNo.Text & strComa & "Icd Out" & strComa & "Factory Out" & strComa & "Factory In" & strComa & "Icd In" & strComa & "Cont No" & strComa & "Cont Size" & strComa & "Exporter" & strComa & "Line" & strComa & "FPOD" & strComa & "Mty Pick up" & strComa & "From Location" & strComa & "To Location" & strComa & "Doc Type" & strComa & "Vehicle No" & strComa & "GR No" & strComa & "Toll Tax" & strComa & "KM" & strComa & "Driver Name" & strComa & "Party Name" & strComa & "Cash" & strComa & "Diesel" & strComa & "Total" & strComa & "BAL" & strComa & "Det. Days" & strComa & "BE No" & strComa & "BE Date"

    '        strb.Append(strContHeader & vbCrLf)

    '        If gvGRDetails.Rows.Count > 0 Then
    '            For Each r As GridViewRow In gvGRDetails.Rows
    '                For c As Integer = 0 To r.Cells.Count - 1
    '                    If r.Cells(c).Text.Trim.ToString <> Nothing Then
    '                          strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&nbsp;", "").Replace("&", " and ").Replace(Environment.NewLine, "") & strComa)
    '                  Else
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

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvGRDetails
        ' myN += 1
        CreateWorkBook(myGridViews, "MovementDetails", 80)

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
End Class
