Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Vendor_VendorContractApprovalListAll
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
            tblReport.Visible = True
            Dim strParams As String = ""
            strParams &= Session.Item("LoginTerminal")
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New LogiParkLib.DBConnection.DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_LIST", strParams)
            If dbr.HasRows = True Then
                gvTrainSummary.DataSource = dbr
                gvTrainSummary.DataBind()
                dbr.Close()
                db.CloseDB()
                tblReport.Visible = True
            Else
                Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "All Vendor Contract is approved.")
                gvTrainSummary.DataSource = Nothing
                gvTrainSummary.DataBind()
            End If
        End If
    End Sub
End Class
