Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CommonSendingMailLibary

Partial Class Reports_Operation_HandoverReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0
    Dim myGridViews(0) As Object
    Dim myN As Integer = 0
    Dim arrTerminalId As ArrayList
    Dim arrTerminalName As ArrayList
    Dim arrCustomerId As ArrayList
    Dim arrCustomerName As ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            prepareTerminalData()
            prepareCustomerData()
            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            textFromDate.Text = Format(Now, "dd/MM/yyyy")
            textToDate.Text = Format(Now, "dd/MM/yyyy")
            Dim strpParms As String = ""
            strpParms &= Session.Item("LoginTerminal")
            strpParms &= ",'" & textFromDate.Text & "'"
            strpParms &= ",'" & textToDate.Text & "'"
            strpParms &= "," & LstShipper.SelectedValue
            BtnSend.Visible = False
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.HAND_REP_NEW", strpParms)
            gvInvoiceReport.DataSource = dbr
            gvInvoiceReport.DataBind()
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
    Sub prepareCustomerData()
        Try
            arrCustomerId = New ArrayList
            arrCustomerName = New ArrayList
            Dim pCustomerMaster As New CustomerMaster
            For Each obj As CustomerMaster In CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster)
                arrCustomerId.Add(obj.CustomerId)
                arrCustomerName.Add(obj.CustomerName)
            Next
        Catch ex As Exception

        End Try
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
    Sub ListControlDataBind()
        Dim strConnectionString As String
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            'Dim pTerminalMaster As New TerminalMaster
            'pTerminalMaster.TerminalId = Session.Item("LoginTerminal")
            'lstCFS.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminalMaster)
            'lstCFS.DataTextField = "TerminalName"
            'lstCFS.DataValueField = "TerminalId"
            'lstCFS.DataBind()
            'lstCFS.Items.Insert(0, (New ListItem("---All---", 0)))
            'lstCFS.SelectedValue = 0

            'Dim pPortMaster As New PortMaster
            'lstPod.DataSource = PortMaster.ReturnPortMasterList(pPortMaster)
            'lstPod.DataTextField = "PortName"
            'lstPod.DataValueField = "PortId"
            'lstPod.DataBind()
            'lstPod.Items.Insert(0, (New ListItem("---All---", 0)))
            'lstPod.SelectedValue = 0

            'Dim pCustomerMaster As New CustomerMaster
            'lstShipping.DataSource = CustomerMaster.ReturnCustomerMasterListAllLine(pCustomerMaster)
            'lstShipping.DataTextField = "CustomerName"
            'lstShipping.DataValueField = "CustomerId"
            'lstShipping.DataBind()
            'lstShipping.Items.Insert(0, (New ListItem("---All---", 0)))
            'lstShipping.SelectedValue = 0
            Dim pCustomerMaster1 As New CustomerMaster
            LstShipper.DataSource = CustomerMaster.ReturnCustomerMasterListConsignee(pCustomerMaster1)
            LstShipper.DataTextField = "CustomerName"
            LstShipper.DataValueField = "CustomerId"
            LstShipper.DataBind()
            LstShipper.Items.Insert(0, (New ListItem("---All---", 0)))
            LstShipper.SelectedValue = 0


        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
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
        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & LstShipper.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.HAND_REP_NEW", strpParms)
        gvInvoiceReport.DataSource = dbr
        gvInvoiceReport.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()
        BtnSend.Visible = True

    End Sub
    Protected Sub gvtripPendencyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If

    End Sub
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        myGridViews(myN) = gvInvoiceReport
        ' myN += 1
        CreateWorkBook(myGridViews, "Handover Report", 80)

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
                wsName = "Handover Report"
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
    Protected Sub BtnSend_Click(sender As Object, e As System.EventArgs) Handles BtnSend.Click
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        Dim con As OleDbConnection
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        Dim CMD1 As String
        pMailConfig.TerminalId = 5
        MailConfig.ReturnMailConfig(pMailConfig)
        Dim strConnectionString As String
        ' Dim con As OleDbConnection
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString") '"Provider=MSDAORA;Data Source=xe;Persist Security Info=True;Password=COMMITEDKLPL#$936END;User ID=TMSKLPL"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim confirmMail As New StringBuilder
        CMD1 = "SELECT DISTINCT CUSTOMER_NAME,CUSTOMER_ID,CUSTOMER_CODE,EMAIL_OPERATIONAL EMAIL_OPERATIONAL FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='E' AND CUSTOMER_ID='" & LstShipper.SelectedValue & "'" & " UNION Select DISTINCT 'ALL' CUSTOMER_NAME,0 CUSTOMER_ID, 'ALL' CUSTOMER_CODE ,'akshay@spjcargo.com' EMAIL_OPERATIONAL FROM CUSTOMER_MASTER "
        'CMD1 = "SELECT DISTINCT CUSTOMER_NAME,CUSTOMER_ID,CUSTOMER_CODE,EMAIL_OPERATIONAL EMAIL_OPERATIONAL FROM CUSTOMER_MASTER WHERE CUSTOMER_TYPE='E' AND CUSTOMER_ID='" & LstShipper.SelectedValue & "'" & "  "
        ada = New OleDbDataAdapter(CMD1, con)
        Dim ds1 As New DataSet
        ada.Fill(ds1)
        For J = 0 To ds1.Tables(0).Rows.Count - 1
            confirmMail = New StringBuilder
            confirmMail.AppendLine("<table style='width: 1500px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
            confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
            confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='17'  >")
            confirmMail.Append("<b>Handover Report</b>")
            confirmMail.Append(" </th>")
            confirmMail.Append(" </tr>")
            confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
            confirmMail.Append("<td style='width: 10px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Sr</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 250px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Shipper</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Cont No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Line</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>ICD In Date</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Invoice No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>SB No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>SB Date</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Booking No.</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Booking Date</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>POD</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>CFS</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Line Seal No</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Custom Seal No</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Handover Date</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Remarks</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append("<b>Pending Reason</b>")
            confirmMail.Append(" </td>")
            confirmMail.Append(" </tr>")
            Dim SR As Long = 0
            Dim cmd As OleDbCommand = con.CreateCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            Dim procName As String = "REPORT_PKG.HAND_REP_NEW"
            ' Dim procParm As String = ""
            Dim procParm As String = ""
            procParm &= Session.Item("LoginTerminal")
            procParm &= ",'" & textFromDate.Text & "'"
            procParm &= ",'" & textToDate.Text & "'"
            procParm &= "," & LstShipper.SelectedValue & ""
            'procParm &= "," & ds1.Tables(0).Rows(J)("CUSTOMER_ID") & ddShipper.SelectedValue & ""
            cmd.CommandText = procName & "(" & procParm & ")"
            ada.SelectCommand = cmd
            Dim ds As New DataSet
            ada.Fill(ds)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                SR = SR + 1
                confirmMail.Append("<tr style='font-family: calibri; color: #00008B;' >")
                confirmMail.Append("<td style='width: 10px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(SR)
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 250px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("SHIPPER"))
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("CONT_NO"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("LINE"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("ICD_IN_DATE"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("INV_NO"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("SB_NO"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("SB_DATE"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("BOOKING_NO"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("BOOKING_DATE"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("PORT"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("CFS"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("SEAL_NO"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("AGENT_SEAL"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("LINE_HANDOVER_DATE"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 120px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("HANDOVER_REMARK"))
                confirmMail.Append(" </td>")
                confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
                confirmMail.Append(ds.Tables(0).Rows(i)("HOLD_REMARK"))
                confirmMail.Append(" </td>")
            Next
            confirmMail.Append(" </table>")

            Dim adamailconfig As OleDbDataAdapter
            Dim cmdmailconfig As String
            'Dim con As New c

            cmdmailconfig = "SELECT FROM_NAME,FROM_ID,SMTP_SERVER,PORT_NO,PASSWORD FROM MAIL_CONFIG WHERE TERMINAL_ID=5"

            adamailconfig = New OleDbDataAdapter(cmdmailconfig, con)
            ' Dim dsmailconfig As New DataSet
            '  adamailconfig.Fill(dsmailconfig)
            Dim xMailSetup As String = ""
            Dim cmdmailsetup As String


            Dim adamailsetup As OleDbDataAdapter
            cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=14"
            'cmdmailsetup = "SELECT TO_MAIL_IDS,CC_IDS,BCC_IDS,SUBJECT,MAIL_BODY,SIGNATURE FROM MAIL_SETUP WHERE MENU_ID=10"

            adamailsetup = New OleDbDataAdapter(cmdmailsetup, con)
            Dim dsmailsetup As New DataSet
            adamailsetup.Fill(dsmailsetup)
            'xMailSetup &= dsmailsetup.Tables(0).Rows(0)("MAIL_BODY")
            xMailSetup &= "<font color='#00008B'>Dear All,"
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"
            xMailSetup &= "<font color='#00008B'>Please find here below the list of containers handover details"
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"
            xMailSetup &= "<br/>"
            xMailSetup &= confirmMail.ToString
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= "<font color='#00008B'>Thanks &  Regards, " & "<br></font><br><b><font color='Red'>SPJ CARGO PVT. LTD.</b></font><font color='#00008B'><br>Regd. Office : D-9/3, 2nd Floor Okhla Industrial Area Phase-1 New Delhi-110020<br> Website:http://www.spjcargo.com </font>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup &= " " & "<br/>"
            xMailSetup += "<font color='#00008B'>***************************This is system generated auto mail. For any query please get in touch with SPJ Team***************************"


            Dim strToID As String = ""
            Try
                strToID = dsmailsetup.Tables(0).Rows(0)("TO_MAIL_IDS")
            Catch
                strToID = ""
            End Try
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
            Dim SUBJECT As String = ""
            SUBJECT &= "Handover Report - " & ds1.Tables(0).Rows(J)("CUSTOMER_CODE") & " " & SR & "" & " CONTAINERS"
            If ds.Tables(0).Rows.Count > 0 Then
                MailSender.SendMailToCcBccIDWithOrWithoutAttachment(pMailConfig.FromId,
                                                            pMailConfig.FromName,
                                                           strToID,
                                                            strCCID,
                                                            strBccID,
                                                            SUBJECT,
                                                            xMailSetup,
                                                            pMailConfig.SmtpServer,
                                                            pMailConfig.Password,
                                                            pMailConfig.PortNo)
                If pStr <> Nothing Then
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sending failed.")
                Else
                    lblErrorMessage.Visible = True
                    lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sent Successfully.")
                End If
            End If
        Next
    End Sub

End Class
