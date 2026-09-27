Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Vendor_VendorContractListAll
    Inherits System.Web.UI.Page
    Dim intCounter As Long = 0

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        tblReport.Visible = True
        Dim strParams As String = ""

        strParams &= lstTerminalName.SelectedValue
        strParams &= "," & lstVendorName.SelectedValue
        strParams &= ",'" & lstVendorType.SelectedValue & "'"
        strParams &= ",'" & textContractCode.Text & "'"
        strParams &= ",'" & textEffectiveFrom.Text & "'"
        strParams &= ",'" & textEffectiveTo.Text & "'"

        Dim dbr As OleDb.OleDbDataReader
        Dim db As New LogiParkLib.DBConnection.DBConnect
        dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_VENDOR_CONTRACT_LIST_ALL", strParams)
        If dbr.HasRows = True Then
            gvVendorContractDetails.DataSource = dbr
            gvVendorContractDetails.DataBind()
            dbr.Close()
            db.CloseDB()
            tblReport.Visible = True
        Else
            Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Errors, lblErrorMessage, "Rate not found for selected parameters.")
            gvVendorContractDetails.DataSource = Nothing
            gvVendorContractDetails.DataBind()
        End If

    End Sub

    Sub ListControlDataBind()
        Dim pTerminal As New TerminalMaster
        lstTerminalName.DataSource = TerminalMaster.ReturnTerminalMasterList(pTerminal)
        lstTerminalName.DataTextField = "TerminalCode"
        lstTerminalName.DataValueField = "TerminalId"
        lstTerminalName.DataBind()
        lstTerminalName.Items.Insert(0, (New ListItem("---ALL---", "0")))
        lstTerminalName.SelectedValue = 0

        Dim pVendorType As New VendorType
        pVendorType.TerminalId = Session.Item("LoginTerminal")
        lstVendorType.DataSource = VendorType.ReturnVendorTypeList(pVendorType)
        lstVendorType.DataTextField = "VendorTypeName"
        lstVendorType.DataValueField = "VendorTypeCode"
        lstVendorType.DataBind()
        lstVendorType.Items.Insert(0, (New ListItem("---ALL---", "")))
        lstVendorType.SelectedValue = 0

        Dim pExtVendorMaster As New ExtVendorMaster
        pExtVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendorName.DataSource = ExtVendorMaster.ReturnVendorMasterListAll(pExtVendorMaster)
        lstVendorName.DataTextField = "VendorName"
        lstVendorName.DataValueField = "VendorId"
        lstVendorName.DataBind()
        lstVendorName.Items.Insert(0, (New ListItem("---ALL---", "0")))
        lstVendorName.SelectedValue = 0
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ListControlDataBind()
        End If
    End Sub

    Protected Sub lstVendorType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstVendorType.SelectedIndexChanged
        Functions.setMsgErrorClear_Setup(Functions.ErrMsgMode.Clear, lblErrorMessage, "")
        Dim pVendorMaster As New ExtVendorMaster
        pVendorMaster.TerminalId = Session.Item("LoginTerminal")
        lstVendorName.DataSource = ExtVendorMaster.ReturnVendorMasterListTypeCode(pVendorMaster, lstVendorType.SelectedValue)
        lstVendorName.DataTextField = "VendorName"
        lstVendorName.DataValueField = "VendorId"
        lstVendorName.DataBind()
        lstVendorName.Items.Insert(0, (New ListItem("---ALL---", "0")))
        lstVendorName.SelectedValue = 0
        If lstVendorType.SelectedValue = "" Then
            lstVendorName.Enabled = False
            lstVendorName.SelectedValue = 0
        Else
            lstVendorName.Enabled = True
        End If
        Functions.ControlFocus(lstVendorName)
    End Sub
End Class
