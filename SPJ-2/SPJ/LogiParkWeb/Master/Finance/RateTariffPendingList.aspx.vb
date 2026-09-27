Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports LogiParkLib.DBConnection
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Master_Finance_RateTariffPendingList
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strpParms As String = ""
        strpParms = Session.Item("LoginTerminal")
        strpParms &= ",'" & Session.Item("CompanyId") & "'"
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New DBConnect
        dbr = db.StoredProcedureReadDB("REPORT_PKG.SP_RATE_APPROVAL_PENDENCY", strpParms)
        gvRateApprovalList.DataSource = dbr
        gvRateApprovalList.DataBind()
        dbr.Close()
        db.CloseDB()
    End Sub
End Class
