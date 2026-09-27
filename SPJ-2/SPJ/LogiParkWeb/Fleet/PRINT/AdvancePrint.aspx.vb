Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System
Imports System.Configuration

Partial Class Fleet_PRINT_AdvancePrint
    Inherits System.Web.UI.Page
    Dim strGrId As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imglogo.ImageUrl = "~/Master/Images/logo.png"
        strGrId = Request.QueryString("GrId")
        Dim p As New FleetGrMapping
        p.TerminalId = Session.Item("LoginTerminal")
        p.GrId = strGrId
        FleetGrMapping.ReturnFleetGrMapping(p)
        If p.PrintStatus = "Y" Then
            lblPrint.Visible = True
        End If
        textTruck.Text = p.VehicleNo
        textGrNo.Text = p.GrNo
        textdate.Text = p.CreatedOn
        textPrintedBy.Text = Session.Item("LoginUser")
        textPrintedDate.Text = Now.Date
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = p.MtyContId
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        Dim pLocation As New LocationMaster
        pLocation.TerminalId = Session.Item("LoginTerminal")
        pLocation.LocationId = pFleetContJo.ToLocationId
        LocationMaster.ReturnLocationMasterByTerminalIdlocation(pLocation)
        TextTo.Text = pLocation.LocationName
      
        Dim pPV As New VendorMaster
        pPV.TerminalId = Session.Item("LoginTerminal")
        pPV.VendorId = p.PetrolVendor
        VendorMaster.ReturnVendorMaster(pPV)
        textPetrolPump.Text = pPV.VendorName

        pLocation.TerminalId = Session.Item("LoginTerminal")
        pLocation.LocationId = pFleetContJo.FromLocation
        LocationMaster.ReturnLocationMasterByTerminalIdlocation(pLocation)
        TextFrom.Text = pLocation.LocationName
        Dim pDriver As New FleetDriverMaster
        pDriver.TerminalId = Session.Item("LoginTerminal")
        pDriver.DriverId = p.DriverId
        FleetDriverMaster.ReturnFleetDriverMaster(pDriver)
        textDriver.Text = pDriver.DriverName
        textOilAdvance.Text = p.OilAdvance
        Dim strConnectionString, cmd As String
        Dim con As OleDbConnection
        Try
            strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")
            cmd = " UPDATE FLEET_GR_MAPPING SET PRINT_BY =" & "'" & Session.Item("LoginUser") & "'" & " ,PRINT_DATE = SYSDATE ,PRINT_STATUS='Y'  WHERE  GR_ID=  " & strGrId
            con = New OleDbConnection(strConnectionString)
            con.Open()
            Dim cmd3 As New OleDbCommand(cmd, con)
            cmd3.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

End Class
