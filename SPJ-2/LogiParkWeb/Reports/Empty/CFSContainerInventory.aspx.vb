Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Partial Class Reports_Empty_CFSContainerInventory
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvInvoiceReport.DataSource = Nothing
            gvInvoiceReport.DataBind()
            tblReport.Visible = False
			ListControlDataBind()
			lblScreenTitle.Text = Session.Item("Title")
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
			Dim pExtTerminalMaster As New TerminalMaster
			lstFromLocation.DataSource = TerminalMaster.ReturnTerminalMasterList(pExtTerminalMaster)
			lstFromLocation.DataTextField = "TerminalName"
			lstFromLocation.DataValueField = "TerminalId"
			lstFromLocation.DataBind()
			lstFromLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
			lstFromLocation.SelectedValue = 0


			lstToLocation.DataSource = TerminalMaster.ReturnTerminalMasterListUserId(Session.Item("LoginUser"))
			lstToLocation.DataTextField = "TerminalName"
			lstToLocation.DataValueField = "TerminalId"
			lstToLocation.DataBind()
			lstToLocation.Items.Insert(0, (New ListItem("---Select---", 0)))
			lstToLocation.SelectedValue = 0
			con.Dispose()
			con.Close()
		Catch ex As Exception
		End Try
	End Sub

	

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim strFromDate As String
        Dim strToDate As String

        gvInvoiceReport.DataSource = Nothing
        gvInvoiceReport.DataBind()
		tblReport.Visible = False

		'If lstFromLocation.SelectedValue = 0 Then
		'	Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Select From Location")
		'	Functions.ControlFocus(lstFromLocation)
		'	Return
		'End If
		'If lstToLocation.SelectedValue = 0 Then
		'	Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Enter To Location")
		'	Functions.ControlFocus(lstToLocation)
		'	Return
		'End If

		lblReportDate.Text = Format(Now, "dd/MM/yyyy hh:mm:ss")
		strFromDate = Me.textFromDate.Text
		strToDate = Me.textToDate.Text

		Dim strpParms As String = ""
		strpParms &= "'" & strFromDate & "'"
        	strpParms &= ",'" & strToDate & "'"
        	strpParms &= "," & lstFromLocation.SelectedValue & ""
        	strpParms &= "," & lstToLocation.SelectedValue & ""
        strpParms &= ",'" & lstTransactionType.SelectedItem.Text & "'"


        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect

		'If lstTransactionType.SelectedValue = "0" Then
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_CFS_INVENTORY_REPORT", strpParms)
			gvInvoiceReport.DataSource = dbr
			gvInvoiceReport.DataBind()
			If dbr.HasRows Then
				tblReport.Visible = True
			Else
				tblReport.Visible = False
				Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found")
			End If
			dbr.Close()
			db.CloseDB()
		'End If
	End Sub

    Protected Sub gvInvoiceReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvInvoiceReport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
		Try
			Dim strComa = ","
			Dim strFileName As String = "ContainerInventory.csv"
			Dim attachment As String = "attachment; filename=" & strFileName
			Dim strb As New StringBuilder()
			Response.Clear()
			Response.ClearHeaders()
			Response.ClearContent()
			Response.AddHeader("content-disposition", attachment)
			Response.ContentType = "text/csv"
			Response.AddHeader("Pragma", "public")

			strb.Append(lblScreenTitle.Text & vbCrLf)
			strb.Append(Space(4) & vbCrLf)

			strb.Append(lblReport.Text & " : ")
			strb.Append(lblReportDate.Text & vbCrLf)
			strb.Append(Space(4) & vbCrLf)

			Dim strContHeader As String = Nothing
			Dim strSummaryHeader As String = Nothing
            strContHeader = lblrSerialNo.Text & strComa & lblrJobNo.Text & strComa & lblrBookingNo.Text & strComa & lblrBookingDate.Text & strComa & lblrLine.Text & strComa &
        lblrFromPort.Text & strComa & lblrICD.Text & strComa & lblrAllotmentDate.Text & strComa & lblrContNo.Text & strComa & lblrContSize.Text & strComa &
        lblrContType.Text & lblrStatus.Text & strComa & lblrAgeingDays.Text
			strb.Append(strContHeader & vbCrLf)

			If gvInvoiceReport.Rows.Count > 0 Then
				For Each r As GridViewRow In gvInvoiceReport.Rows
					For c As Integer = 0 To r.Cells.Count - 1
						If r.Cells(c).Text.Trim.ToString <> Nothing Then
							strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", " and ") & strComa)
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
	Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub

    Protected Sub BtnSend_Click(sender As Object, e As System.EventArgs) Handles BtnSend.Click
        Dim pStr As String = ""
        Dim pMailConfig As New MailConfig
        pMailConfig.TerminalId = 1
        MailConfig.ReturnMailConfig(pMailConfig)
        Dim xMailSetup As New MailSetup
        xMailSetup.MenuId = 24
        MailSetup.ReturnMailSetup(xMailSetup)
        Dim confirmMail As New StringBuilder
        xMailSetup.MailBody = ""
		confirmMail.AppendLine("<table style='width: 1200px; border-style:Solid; border-width:1px;  border-color:black; position: static; height: 100%' cellpadding='0' cellspacing='0' border='1' >")
		confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: 	#191970;' >")
		confirmMail.Append("<th style='align: center; font-size: 20px; font-bold:false; height: 21px ; border-style: solid;border-right:None;  border-bottom-color: #000000; border-left:None;   border-width: 0.1px; ' colspan='12'  >")
		confirmMail.Append("<b>Container Inventory</b>")
        confirmMail.Append(" </th>")
        confirmMail.Append(" </tr>")
        confirmMail.Append("<tr style='font-family: calibri; color: #FFFFFF; background-color: #4169E1;' >")
        confirmMail.Append("<td style='width: 10px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Sr</b>")
		confirmMail.Append(" </td>")
		confirmMail.Append("<td style='width: 250px; font-size: 10pt; height: 5px'>")
		confirmMail.Append("<b>Transporter</b>")
		confirmMail.Append(" </td>")
		confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
		confirmMail.Append("<b>Contact No</b>")
		confirmMail.Append(" </td>")
		confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>From</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>To</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Booking No</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 250px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Line</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Cont No.</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
        confirmMail.Append("<b>Pickup Date</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
		confirmMail.Append("<b>Empty Gate In</b>")
		confirmMail.Append(" </td>")
		confirmMail.Append("<td style='width: 180px; font-size: 10pt; height: 5px'>")
		confirmMail.Append("<b>Status</b>")
        confirmMail.Append(" </td>")
        confirmMail.Append("<td style='width: 30px; font-size: 10pt; height: 5px'>")
		confirmMail.Append("<b>Ageing</b>")
		confirmMail.Append(" </td>")
        confirmMail.Append(" </tr>")
        Dim SR As Long = 0
        Dim strConnectionString As String
        Dim con As OleDbConnection
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString") '"Provider=MSDAORA;Data Source=xe;Persist Security Info=True;Password=COMMITEDKLPL#$936END;User ID=TMSKLPL"
        con = New OleDbConnection(strConnectionString)
        con.Open()
        Dim ada As OleDbDataAdapter = New OleDbDataAdapter
        Dim cmd As OleDbCommand = con.CreateCommand
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        Dim procName As String = "REPORT_PKG.SP_CFS_INVENTORY_REPORT"
        ' Dim procParm As String = ""
        Dim procParm As String = "0,0,0"
        cmd.CommandText = procName & "(" & procParm & ")"
        'cmd.CommandText = procName & "(" & procParm & ")"
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
			confirmMail.Append(ds.Tables(0).Rows(i)("TRANSPORTER"))
			confirmMail.Append(" </td>")
			confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
			confirmMail.Append(ds.Tables(0).Rows(i)("MOBILE_NO"))
			confirmMail.Append(" </td>")
			confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("FROM_PORT"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("ICD"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 150px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("BOOKING_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 250px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("LINE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("CONT_NO"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("PICKUP_DATE"))
            confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 100px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("GATE_IN_DATE"))
            confirmMail.Append(" </td>")
			confirmMail.Append("<td style='width: 180px; font-size: 10pt; height: 5px'>")
			confirmMail.Append(ds.Tables(0).Rows(i)("STATUS"))
			confirmMail.Append(" </td>")
            confirmMail.Append("<td style='width: 30px; font-size: 10pt; height: 5px'>")
            confirmMail.Append(ds.Tables(0).Rows(i)("AGEING_DAYS"))
            confirmMail.Append(" </td>")
            confirmMail.Append(" </tr>")
        Next
        confirmMail.Append(" </table>")

        xMailSetup.MailBody &= "</br>"
        xMailSetup.MailBody &= "</br>"
        xMailSetup.MailBody &= confirmMail.ToString & "</br>"
        xMailSetup.MailBody &= "</br>"
        xMailSetup.MailBody &= "</br>"
        pStr = Functions.sendMailToCcBccID(pMailConfig.FromId, pMailConfig.FromName, "rohit@elogisol.in", "vrohit248@gmail.com,vrohit248@gmail.com", "", "Current Container Inventory", xMailSetup.MailBody, pMailConfig.SmtpServer, pMailConfig.Password, pMailConfig.PortNo)
		If pStr <> Nothing Then
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sending failed.")
        Else
            lblErrorMessage.Visible = True
            lblErrorMessage = Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Message, lblErrorMessage, "Message Sent Successfully.")
        End If

    End Sub
End Class
