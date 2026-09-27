Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Partial Class Reports_Fleet_DailyReport
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0
    Dim intCounter1 As Long = 0
    Dim intCounterE As Long = 0
    Dim intCounterI As Long = 0
    Dim intCounterD As Long = 0
    Dim Total20 As Long = 0
    Dim Total40 As Long = 0
 Dim Total As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As String = Request.AppRelativeCurrentExecutionFilePath
        MenuItemHelper.Permission(Me.Page, p)
        If Not IsPostBack Then
            gvExport.DataSource = Nothing
            gvExport.DataBind()
            gvImport.DataSource = Nothing
            gvImport.DataBind()

            lblScreenTitle.Text = Session.Item("Title")
            tblReport.Visible = True
            tblReport.Visible = True

            Dim strpParms As String = ""
	    strpParms = Session.Item("LoginTerminal")
	    strpParms &= "," & ""
	    Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_EXP_DAILY_REPORT", strpParms)
            gvExport.DataSource = dbr
            gvExport.DataBind()
            If dbr.HasRows Then
                tblReport.Visible = True
            Else

                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found For Export")
            End If
            dbr.Close()
            db.CloseDB()

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_IMP_DAILY_REPORT", strpParms)
            gvImport.DataSource = dbr
            gvImport.DataBind()
            If dbr.HasRows Then
                tblImport.Visible = True
            Else
                'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found For Gate in")
            End If
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_DOM_DAILY_REPORT", strpParms)
            gvDomestic.DataSource = dbr
            gvDomestic.DataBind()
            If dbr.HasRows Then
                tblDomestic.Visible = True
            Else
                'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found For Gate in")
            End If
Dim Status as string=""
Dim strparms1 as string=""
strparms1 = "'" & "'" 
strparms1 & = "," & ""
	    
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_DAILY_SUMMARY_REPORT",strparms1)
            gvsummary.DataSource = dbr
            gvsummary.DataBind()
            If dbr.HasRows Then
                tblsummary.Visible = True
            Else
                'Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "No Record Found For Gate in")
            End If
            dbr.Close()
            db.CloseDB()
        End If
    End Sub

    

    Protected Sub gvsummary_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvsummary.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
            textTotal20.Text = e.Row.Cells(4).Text + Total20
            textTotal40.Text = e.Row.Cells(5).Text + Total40
   textTotalt.Text = e.Row.Cells(6).Text + Total

            Total20 = textTotal20.Text
            Total40 = textTotal40.Text
   Total=textTotalt.Text
        End If
    End Sub
  Protected Sub gveXPORT_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gveXPORT.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounterE = intCountere + 1
            e.Row.Cells(0).Text = intCounterE
           
        End If

    End Sub
 Protected Sub gvImport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvImport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounterI = intCounteri + 1
            e.Row.Cells(0).Text = intCounterI
           
        End If

    End Sub
Protected Sub gvDomestic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDomestic.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounterd = intCounterd + 1
            e.Row.Cells(0).Text = intCounterd
           
        End If

    End Sub

    Protected Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class