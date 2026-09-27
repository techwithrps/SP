Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Reports_Fleet_RateSummaryTPT
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
            tblReport.Visible = False
            Dim p As String = Request.AppRelativeCurrentExecutionFilePath
            MenuItemHelper.Permission(Me.Page, p)

            Dim strCurrentDate As String
            strCurrentDate = Format(Now, "MM/dd/yyyy")
            Dim strpParms As String = ""
            strpParms &= lstCustomer.SelectedValue
            strpParms &= "," & lstPickupLocation.SelectedValue
            strpParms &= "," & lstFactoryLocation.SelectedValue
            strpParms &= "," & lstHandOverLocation.SelectedValue

            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TRANSPORT_CHARGES", strpParms)
            gvGRDetails.DataSource = dbr
            gvGRDetails.DataBind()
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
        Dim strConnectionString, cmd1 As String
        Dim con As OleDbConnection
        Dim ada As New OleDbDataAdapter
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT CUSTOMER_ID,CUSTOMER_NAME FROM CUSTOMER_MASTER WHERE NVL(STATUS,'N') = 'Y' AND NVL(CUSTOMER_TYPE,'N')  IN ('R', 'E') ORDER BY CUSTOMER_NAME"
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
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT TERMINAL_ID, TERMINAL_NAME FROM TERMINAL_MASTER"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("PickupLocation")
            ada.Fill(ds)
            lstPickupLocation.DataSource = ds.Tables(0)
            lstPickupLocation.DataTextField = "TERMINAL_NAME"
            lstPickupLocation.DataValueField = "TERMINAL_ID"
            lstPickupLocation.DataBind()
            lstPickupLocation.Items.Insert(0, (New ListItem("---All---", "0")))
            ds.Clear()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT DISTINCT TL.LOCATION_ID, TL.LOCATION_NAME FROM TERMINAL_LOCATION_MASTER TL, RATE_DETAILS RD WHERE TL.LOCATION_ID = RD.CARGO_TYPE"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("FactoryLocation")
            ada.Fill(ds)
            lstFactoryLocation.DataSource = ds.Tables(0)
            lstFactoryLocation.DataTextField = "LOCATION_NAME"
            lstFactoryLocation.DataValueField = "LOCATION_ID"
            lstFactoryLocation.DataBind()
            lstFactoryLocation.Items.Insert(0, (New ListItem("---All---", "0")))
            ds.Clear()
        Catch ex As Exception
        End Try

        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd1 = "SELECT DISTINCT TL.TERMINAL_ID, TL.TERMINAL_NAME  FROM TERMINAL_MASTER TL,RATE_DETAILS RD WHERE TL.TERMINAL_ID = RD.HANDLING_MODE ORDER BY TERMINAL_NAME"
            con = New OleDbConnection(strConnectionString)
            con.Open()
            ada = New OleDbDataAdapter(cmd1, con)
            Dim ds As New DataSet("HandoverLocation")
            ada.Fill(ds)
            lstHandOverLocation.DataSource = ds.Tables(0)
            lstHandOverLocation.DataTextField = "TERMINAL_NAME"
            lstHandOverLocation.DataValueField = "TERMINAL_ID"
            lstHandOverLocation.DataBind()
            lstHandOverLocation.Items.Insert(0, (New ListItem("---All---", "0")))
            ds.Clear()
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
        gvGRDetails.DataSource = Nothing
        gvGRDetails.DataBind()
        tblReport.Visible = False
        Dim strCurrentDate As String
        strCurrentDate = Format(Now, "MM/dd/yyyy")
        Dim strpParms As String = ""
        strpParms &= lstCustomer.SelectedValue
        strpParms &= "," & lstPickupLocation.SelectedValue
        strpParms &= "," & lstFactoryLocation.SelectedValue
        strpParms &= "," & lstHandOverLocation.SelectedValue

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_TRANSPORT_CHARGES", strpParms)
        gvGRDetails.DataSource = dbr
        gvGRDetails.DataBind()
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
    Protected Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Try

            Dim strComa = ","
            Dim strFileName As String = "RateSummaryTPT.csv"
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

            strb.Append(lblReport.Text & " : " & lblReportDate.Text & vbCrLf)
            strb.Append(Space(4) & vbCrLf)


            Dim strContHeader As String = Nothing
            Dim strSummaryHeader As String = Nothing
            strContHeader = "Sr." & strComa & "Customer Name" & strComa & "Pickup Location" & strComa & "Factory Location" & strComa & "Handover Location" & strComa & "Cont Size" & strComa & "Transport Charges" & strComa & "Tool Charges" & strComa & "Detention" & strComa & "Agency" & strComa & "Clearing" & strComa & "Weighment" & strComa & "Tool"

            strb.Append(strContHeader & vbCrLf)

            If gvGRDetails.Rows.Count > 0 Then
                For Each r As GridViewRow In gvGRDetails.Rows
                    For c As Integer = 0 To r.Cells.Count - 1
                        If r.Cells(c).Text.Trim.ToString <> Nothing Then
                            strb.Append((r.Cells(c).Text.ToString).Replace(",", "").Replace("&", "  and nbsp; ") & strComa)
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
