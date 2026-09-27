Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Fleet_TripPendency
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strpParms As String = ""
        strpParms = Session.Item("LoginTerminal")
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        If tabTripPendency.ActiveTabIndex = 0 Then

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_TRIP_PENDENCY", strpParms)
            gvtripPendencyList.DataSource = dbr
            gvtripPendencyList.DataBind()
       
        ElseIf tabTripPendency.ActiveTabIndex = 1 Then

            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_TRIP_PENDENCY_IMP", strpParms)
            gvImport.DataSource = dbr
            gvImport.DataBind()
        Else
            dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_FLEET_TRIP_DOM_PENDING", strpParms)
            gvDomestic.DataSource = dbr
            gvDomestic.DataBind()

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
    Protected Sub gvDomestic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDomestic.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub
    Protected Sub gvImport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvImport.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
    End Sub
  

End Class
