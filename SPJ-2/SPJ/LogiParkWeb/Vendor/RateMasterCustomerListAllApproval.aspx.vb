Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class AdministratorUI_RateMasterCustomerListAll
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        tblReport.Visible = True
        Dim strParams As String = ""
     
        Dim dbr As OleDb.OleDbDataReader
        Dim db As New LogiParkLib.DBConnection.DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_CUSTOMER_APPROVAL", strParams)
        If dbr.HasRows = True Then
            gvTrainSummary.DataSource = dbr
            gvTrainSummary.DataBind()
            dbr.Close()
            db.CloseDB()
            tblReport.Visible = True
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Rate not found for selected parameters.")
            gvTrainSummary.DataSource = Nothing
            gvTrainSummary.DataBind()
        End If

    End Sub

 

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
               End If
    End Sub
End Class
