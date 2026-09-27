Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class AdministratorUI_RateMasterVendorListAll
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        tblReport.Visible = True
        Dim strParams As String = ""

        strParams &= "'" & textRateCode.Text & "',"
        strParams &= "," & lstBillingCondition.SelectedValue
        strParams &= "," & lstServiceName.SelectedValue
        strParams &= "," & lstVendorName.SelectedValue
        strParams &= "," & Session.Item("LoginTerminal")
        strParams &= ",'" & textEffectiveFrom.Text & "'"
        strParams &= ",'" & textEffectiveTo.Text & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New LogiParkLib.DBConnection.DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_RATE_TPT_VENDOR_LIST", strParams)
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

    Sub ListControlDataBind()
        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendorName.DataSource = ExtVendorMaster.ReturnVendorMasterListAll(pExtVendorMaster)
        lstVendorName.DataTextField = "VendorName"
        lstVendorName.DataValueField = "VendorId"
        lstVendorName.DataBind()
        lstVendorName.Items.Add(New ListItem("---ALL---", "0"))
        lstVendorName.SelectedValue = 0

        Dim pCostServiceMaster As New ServiceMaster
        pCostServiceMaster.TerminalId = Session.Item("LoginTerminal")
        lstServiceName.DataSource = ServiceMaster.ReturnServiceMasterList(pCostServiceMaster)
        lstServiceName.DataTextField = "ServiceName"
        lstServiceName.DataValueField = "ServiceId"
        lstServiceName.DataBind()
        lstServiceName.Items.Add(New ListItem("---ALL---", "0"))
        lstServiceName.SelectedValue = 0

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
        End If
    End Sub
End Class
