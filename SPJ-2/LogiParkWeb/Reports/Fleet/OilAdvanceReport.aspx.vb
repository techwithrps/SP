Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_OilAdvanceReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()

            gvOilAdvance.DataSource = Nothing
            gvOilAdvance.DataBind()
            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)
            lblScreenTitle.Text = Session.Item("Title")
        End If

    End Sub
    Sub ListControlDataBind()
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT VM.VENDOR_ID,VENDOR_NAME FROM VENDOR_MASTER VM,VENDOR_TYPE_DETAILS VD WHERE VD.VENDOR_ID=VM.VENDOR_ID AND VD.VENDER_TYPE_CODE='P' "
            con = New OleDbConnection(strConnectionString)
            con.Open()

            ada = New OleDbDataAdapter(cmd1, con)

            Dim ds2 As New DataSet("VENDOR")
            ada.Fill(ds2)
            lstVendor.DataSource = ds2.Tables(0)
            lstVendor.DataTextField = "VENDOR_NAME"
            lstVendor.DataValueField = "VENDOR_ID"
            lstVendor.DataBind()
            lstVendor.Items.Insert(0, (New ListItem("---All---", "0")))
            con.Close()
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

        gvOilAdvance.DataSource = Nothing
        gvOilAdvance.DataBind()
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

        lblDate.Text = lblScreenTitle.Text & " From " & " " & strFromDate & " To " & strToDate

        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        strFromDate = Functions.todate_ddmmyyyy(textFromDate.Text, "/")
        strToDate = Functions.todate_ddmmyyyy(textToDate.Text, "/")

        Dim strpParms As String = ""
        strpParms &= Session.Item("LoginTerminal")
        strpParms &= ",'" & textFromDate.Text & "'"
        strpParms &= ",'" & textToDate.Text & "'"
        strpParms &= "," & lstVendor.SelectedValue
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_OIL_ADVANCE", strpParms)
        gvOilAdvance.DataSource = dbr
        gvOilAdvance.DataBind()
        If dbr.HasRows Then
            tblReport.Visible = True
        Else
            tblReport.Visible = False
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "No Record Found")
        End If
        dbr.Close()
        db.CloseDB()

    End Sub
    Protected Sub gvJoDe_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOilAdvance.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            TextTotal.Text = e.Row.Cells(4).Text + Total
            Total = TextTotal.Text
        End If
    End Sub

    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try

            Dim strComa = ","
            Dim strFileName As String = "OIL ADVANCE.csv"
            Dim attachment As String = "attachment; filename=" & strFileName
            Dim strb As New StringBuilder()
            Response.Clear()
            Response.ClearHeaders()
            Response.ClearContent()
            Response.AddHeader("content-disposition", attachment)
            Response.ContentType = "text/csv"
            Response.AddHeader("Pragma", "public")

            strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
            strb.Append(lblDate.Text & vbCrLf)
            strb.Append(lstVendor.SelectedItem.Text)
            strb.Append(Space(4) & vbCrLf)


            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = lblrSrNo.Text & strComa & lblrSlipNo.Text & strComa & lblrVehicleNo.Text & strComa & _
                   lblrDriverName.Text & strComa & lblrAmount.Text & strComa & lblVendor.Text
            strb.Append(strContHeader & vbCrLf)

            If gvOilAdvance.Rows.Count > 0 Then
                For Each r As GridViewRow In gvOilAdvance.Rows
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
End Class
