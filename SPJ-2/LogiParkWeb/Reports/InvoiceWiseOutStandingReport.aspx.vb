Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_InvoiceWiseOutStandingReport
    Inherits System.Web.UI.Page
    Dim cs As String = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
    Dim con As New OleDbConnection
    Dim adapt As New OleDbDataAdapter
    Dim intCounter As Long = 0
    Dim receipt As Long = 0
    Dim TotalDr As Double = 0.0
    Dim TotalCr As Double = 0.0
    Dim TotalAdj As Double = 0.0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0



    Sub ListControlDataBind()
        Dim pCustomerMaster As New CustomerMaster
        lstCustomerName.DataSource = CustomerMaster.ReturnCustomerMasterList(pCustomerMaster)
        lstCustomerName.DataTextField = "CustomerName"
        lstCustomerName.DataValueField = "CustomerId"
        lstCustomerName.DataBind()
        lstCustomerName.Items.Insert(0, (New ListItem("---All---", 0)))
        lstCustomerName.SelectedValue = 0
    End Sub


    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        If textFromDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter from date")
            Functions.ControlFocus(textFromDate)
            Return
        End If
        If textToDate.Text.Trim = Nothing Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter to date")
            Functions.ControlFocus(textToDate)
            Return
        End If
        'If lstCustomerName.SelectedValue = 0 Then
        '    Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select a Customer")
        '    Functions.ControlFocus(lstCustomerName)
        '    Return
        'End If
        Dim dFrm, dTo As Date
        dFrm = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        dTo = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        If Date.Parse(dFrm) > Date.Parse(dTo) Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "To Date Should not be less than From Date")
            Functions.ControlFocus(textToDate)
            Return
        End If

        Dim strpParms As String = ""
        strpParms &= "" & lstCustomerName.SelectedValue & ""
        strpParms &= "," & Session.Item("CompanyId") & ""
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= ",'" & lstTDS.SelectedValue & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_OUTSTANDING_INVOICE_WISE", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows = False Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No record Found")
        End If
        dbr.Close()
        db.CloseDB()
        tblReport.Visible = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("Home.aspx")
    End Sub

    Dim rowTotalAmount As Double = 0.0
    Dim rowPendingAmount As Double = 0.0
    Dim rowTDSAmount As Double = 0.0
    Dim status As String = ""
    Protected Sub gvBookingSummary_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            If e.Row.Cells(0).Text = "SRNO" Then
                e.Row.Cells(0).Width = 30
                e.Row.Cells(0).Text = "Sr No"
            End If
            If e.Row.Cells(1).Text = "CUSTOMER_NAME" Then
                e.Row.Cells(1).Width = 300
                e.Row.Cells(1).Text = "Customer Name"
            End If
            If e.Row.Cells(2).Text = "REF_NO" Then
                e.Row.Cells(2).Width = 150
                e.Row.Cells(2).Text = "Ref No"
            End If
            If e.Row.Cells(3).Text = "TYPE" Then
                e.Row.Cells(3).Width = 50
                e.Row.Cells(3).Text = "Type"
            End If
            If e.Row.Cells(4).Text = "INVOICE_DATE" Then
                e.Row.Cells(4).Width = 100
                e.Row.Cells(4).Text = "Invoice Date"
            End If
            If e.Row.Cells(5).Text = "TOTAL_AMOUNT" Then
                e.Row.Cells(5).Width = 100
                e.Row.Cells(5).Text = "Total Amount"
            End If
            If e.Row.Cells(6).Text = "PENDING_AMOUNT" Then
                e.Row.Cells(6).Width = 120
                e.Row.Cells(6).Text = "Pending Amount"
            End If
            If e.Row.Cells(7).Text = "TDS_AMOUNT" Then
                e.Row.Cells(7).Width = 100
                e.Row.Cells(7).Text = "TDS Amount"
                e.Row.Cells(8).Width = 100
                e.Row.Cells(8).Text = "Due Date"
                e.Row.Cells(9).Width = 50
                e.Row.Cells(9).Text = "Days"
                status = "Y"
            Else
                e.Row.Cells(7).Width = 100
                e.Row.Cells(7).Text = "Due Date"
                e.Row.Cells(8).Width = 50
                e.Row.Cells(8).Text = "Days"
            End If
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            If status = "Y" Then
                e.Row.Cells(0).Width = 30
                e.Row.Cells(1).Width = 300
                e.Row.Cells(2).Width = 150
                e.Row.Cells(3).Width = 50
                e.Row.Cells(4).Width = 100
                e.Row.Cells(5).Width = 100
                e.Row.Cells(6).Width = 120
                e.Row.Cells(7).Width = 100
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(8).Width = 100
                e.Row.Cells(9).Width = 50

                rowTotalAmount = rowTotalAmount + Convert.ToDouble(e.Row.Cells(5).Text)
                rowPendingAmount = rowPendingAmount + Convert.ToDouble(e.Row.Cells(6).Text)
                rowTDSAmount = rowTDSAmount + Convert.ToDouble(e.Row.Cells(7).Text)
            Else
                e.Row.Cells(0).Width = 30
                e.Row.Cells(1).Width = 300
                e.Row.Cells(2).Width = 150
                e.Row.Cells(3).Width = 50
                e.Row.Cells(4).Width = 100
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(7).Width = 100
                e.Row.Cells(8).Width = 50

                rowTotalAmount = rowTotalAmount + Convert.ToDouble(e.Row.Cells(5).Text)
                rowPendingAmount = rowPendingAmount + Convert.ToDouble(e.Row.Cells(6).Text)
            End If

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Total"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
            If status = "Y" Then
                e.Row.Cells(5).Text = Math.Round(rowTotalAmount, 2)
                e.Row.Cells(6).Text = Math.Round(rowPendingAmount, 2)
                e.Row.Cells(7).Text = Math.Round(rowTDSAmount, 2)
                e.Row.Cells(5).Font.Bold = True
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(6).Font.Bold = True
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(7).Font.Bold = True
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
            Else
                e.Row.Cells(5).Text = Math.Round(rowTotalAmount, 2)
                e.Row.Cells(6).Text = Math.Round(rowPendingAmount, 2)
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(6).Font.Bold = True
                e.Row.Cells(5).Font.Bold = True
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            End If
          
        End If
    End Sub
    'Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
    '    myGridViews(myN) = gvInvoiceReport
    '    ' myN += 1
    '    CreateWorkBook(myGridViews, "Invoice Wise OutStanding Report", 80)

    'End Sub
    'Public Shared Sub CreateWorkBook(ByVal cList As Object, ByVal wbName As String, ByVal CellWidth As Integer)
    '    Dim attachment As String = "attachment; filename=""" & wbName & ".xls"""
    '    HttpContext.Current.Response.ClearContent()
    '    HttpContext.Current.Response.AddHeader("content-disposition", attachment)
    '    HttpContext.Current.Response.ContentType = "application/ms-excel"
    '    Dim sw As System.IO.StringWriter = New System.IO.StringWriter()
    '    sw.WriteLine("<?xml version=""1.0""?>")
    '    sw.WriteLine("<?mso-application progid=""Excel.Sheet""?>")
    '    sw.WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet""")
    '    sw.WriteLine("xmlns:o=""urn:schemas-microsoft-com:office:office""")
    '    sw.WriteLine("xmlns:x=""urn:schemas-microsoft-com:office:excel""")
    '    sw.WriteLine("xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""")
    '    sw.WriteLine("xmlns:html=""http://www.w3.org/TR/REC-html40"">")
    '    sw.WriteLine("<DocumentProperties xmlns=""urn:schemas-microsoft-com:office:office"">")
    '    sw.WriteLine("<LastAuthor>Try Not Catch</LastAuthor>")
    '    sw.WriteLine("<Created>2010-05-15T19:14:19Z</Created>")
    '    sw.WriteLine("<Version>11.9999</Version>")
    '    sw.WriteLine("</DocumentProperties>")
    '    sw.WriteLine("<ExcelWorkbook xmlns=""urn:schemas-microsoft-com:office:excel"">")
    '    sw.WriteLine("<WindowHeight>9210</WindowHeight>")
    '    sw.WriteLine("<WindowWidth>19035</WindowWidth>")
    '    sw.WriteLine("<WindowTopX>0</WindowTopX>")
    '    sw.WriteLine("<WindowTopY>90</WindowTopY>")
    '    sw.WriteLine("<ProtectStructure>False</ProtectStructure>")
    '    sw.WriteLine("<ProtectWindows>False</ProtectWindows>")
    '    sw.WriteLine("</ExcelWorkbook>")
    '    sw.WriteLine("<Styles>")
    '    sw.WriteLine("<Style ss:ID=""Default"" ss:Name=""Normal"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom""/>")
    '    sw.WriteLine("<Borders/>")
    '    sw.WriteLine("<Font/>")
    '    sw.WriteLine("<Interior/>")
    '    sw.WriteLine("<NumberFormat/>")
    '    sw.WriteLine("<Protection/>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s22"">")
    '    sw.WriteLine("<Alignment ss:Horizontal=""Center"" ss:Vertical=""Center"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("<Font ss:Bold=""1""/>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s23"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s24"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("<Font ss:Color=""#FFFFFF""/>")
    '    sw.WriteLine("<Interior ss:Color=""#191970"" ss:Pattern=""Solid""/>") 'set header colour here
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("<Style ss:ID=""s27"">")
    '    sw.WriteLine("<Alignment ss:Vertical=""Bottom"" ss:WrapText=""1""/>")
    '    sw.WriteLine("<Borders>")
    '    sw.WriteLine("<Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("<Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""")
    '    sw.WriteLine("ss:Color=""#000000""/>")
    '    sw.WriteLine("</Borders>")
    '    sw.WriteLine("<Font ss:Color=""#000000"" />")
    '    sw.WriteLine("<Interior ss:Color=""#FFFF2A"" ss:Pattern=""Solid""/>")
    '    sw.WriteLine("</Style>")
    '    sw.WriteLine("</Styles>")
    '    For Each gView As GridView In cList
    '        'Try
    '        '    If gView.ID.ToString = "gvsummary" Then
    '        '        CreateWorkSheet("Summary", sw, gView, CellWidth)
    '        '    ElseIf gView.ID.ToString = "gvExport" Then
    '        '        'gView.ID =
    '        '        CreateWorkSheet("20", sw, gView, CellWidth)
    '        '    ElseIf gView.ID.ToString = "gvDomestic" Then
    '        '        CreateWorkSheet("B/I 20", sw, gView, CellWidth)
    '        '        ' gView.ID = "B/I 20"
    '        '    ElseIf gView.ID.ToString = "gvImport" Then
    '        '        CreateWorkSheet("40", sw, gView, CellWidth)
    '        '        ' gView.ID = "40"
    '        '    ElseIf gView.ID.ToString = "GVI40" Then
    '        '        'gView.ID = "B/I 40"
    '        '        CreateWorkSheet("B/I 40", sw, gView, CellWidth)
    '        '    End If


    '        'Catch ex As Exception
    '        'End Try
    '        CreateWorkSheet(gView.ID.ToString, sw, gView, CellWidth)
    '    Next
    '    sw.WriteLine("</Workbook>")
    '    HttpContext.Current.Response.Write(sw.ToString())
    '    HttpContext.Current.Response.End()
    'End Sub
    'Private Shared Sub CreateWorkSheet(ByVal wsName As String, ByVal sw As System.IO.StringWriter, ByVal gv As GridView, ByVal cellwidth As Integer)
    '    If IsNothing(gv.HeaderRow) = False Then
    '        If wsName = "gvInvoiceReport" Then
    '            wsName = "Invoice Wise Outstanding"
    '            'ElseIf wsName = "GVPVT" Then
    '            '    wsName = "PVT"
    '            'ElseIf wsName = "gvsummary" Then
    '            '    wsName = "Summary"
    '            'ElseIf wsName = "gvDomestic" Then
    '            '    wsName = "Idel20"
    '            'ElseIf wsName = "gvImport" Then
    '            '    wsName = "40"
    '            'ElseIf wsName = "GVI40" Then
    '            '    wsName = "Idel40"
    '        End If

    '        sw.WriteLine("<Worksheet ss:Name=""" & wsName & """>")
    '        Dim cCount As Integer = gv.HeaderRow.Cells.Count + 1
    '        Dim rCount As Long = gv.Rows.Count + 2
    '        sw.WriteLine("<Table ss:ExpandedColumnCount=""" & cCount & """ ss:ExpandedRowCount=""" & rCount & """ x:FullColumns=""1""")
    '        sw.WriteLine("x:FullRows=""1"">")
    '        For i As Integer = (cCount - cCount) To (cCount - 1)
    '            sw.WriteLine("<Column ss:AutoFitWidth=""1"" ss:Width=""" & cellwidth & """/>")
    '        Next

    '        GridRowIterate(gv, sw)
    '        sw.WriteLine("</Table>")
    '        sw.WriteLine("<WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")

    '        sw.WriteLine("<Selected/>")
    '        sw.WriteLine("<DoNotDisplayGridlines/>")

    '        sw.WriteLine("<ProtectObjects>False</ProtectObjects>")
    '        sw.WriteLine("<ProtectScenarios>False</ProtectScenarios>")

    '        sw.WriteLine("</WorksheetOptions>")
    '        sw.WriteLine("</Worksheet>")
    '    End If
    'End Sub
    'Private Shared Sub GridRowIterate(ByVal gv As GridView, ByVal sw As System.IO.StringWriter)
    '    sw.WriteLine("<Row>")

    '    For Each tc As TableCell In gv.HeaderRow.Cells
    '        Dim tcText As String = tc.Text

    '        Dim tcWidth As String = gv.Width.Value
    '        Dim dType As String = "String"

    '        If IsNumeric(tcText) = True Then

    '            dType = "Number"

    '        End If
    '        sw.WriteLine("<Cell ss:StyleID=""s24""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

    '    Next
    '    sw.WriteLine("</Row>")

    '    For Each gr As GridViewRow In gv.Rows
    '        sw.WriteLine("<Row>")

    '        For Each gc As TableCell In gr.Cells
    '            Dim gcText As String = gc.Text
    '            Dim dType As String = "String"

    '            If IsNumeric(gcText) = True Then

    '                dType = "Number"
    '                gcText = CDbl(gcText)

    '            End If
    '            sw.WriteLine("<Cell ss:StyleID=""s23""><Data ss:Type=""" & dType & """>" & gcText & "</Data></Cell>")

    '        Next
    '        sw.WriteLine("</Row>")
    '    Next
    '      For Each tc As TableCell In gv.FooterRow.Cells
    '        Dim tcText As String = tc.Text

    '        Dim tcWidth As String = gv.Width.Value
    '        Dim dType As String = "String"

    '        If IsNumeric(tcText) = True Then

    '            dType = "Number"

    '        End If
    '        sw.WriteLine("<Cell ss:StyleID=""s24""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

    '    Next
    '    sw.WriteLine("</Row>")
    'End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvInvoiceReport
        ' myN += 1
        CreateWorkBook(myGridViews, "Invoice Wise OutStanding Report", 80)

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

        sw.WriteLine("<Style ss:ID=""s27"">")
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
        sw.WriteLine("<Font ss:Color=""#000000"" />")
        sw.WriteLine("<Interior ss:Color=""#FFFF2A"" ss:Pattern=""Solid""/>")
        sw.WriteLine("</Style>")

        sw.WriteLine("<Style ss:ID=""s25"">")
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
            If wsName = "gvInvoiceAgeingReport" Then
                wsName = "Invoice Wise OutStanding"
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
            Dim cCount As Integer = gv.HeaderRow.Cells.Count + 1
            Dim rCount As Long = gv.Rows.Count + 2
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
        sw.WriteLine("<Row>")

        For Each tc As TableCell In gv.FooterRow.Cells
            Dim tcText As String = tc.Text

            Dim tcWidth As String = gv.Width.Value
            Dim dType As String = "String"

            If IsNumeric(tcText) = True Then

                dType = "Number"

            End If
            sw.WriteLine("<Cell ss:StyleID=""s27""><Data ss:Type=""String"">" & tcText & "</Data></Cell>")

        Next
        sw.WriteLine("</Row>")
    End Sub
End Class



