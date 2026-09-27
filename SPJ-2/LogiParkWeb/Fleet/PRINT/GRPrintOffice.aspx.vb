Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Threading
Imports System.Drawing
Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.Image
Imports System.IO
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
'Imports System
'Imports System.Data
Imports System.Configuration
'Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Drawing.Imaging
Imports LogiParkLib.DBConnection

Partial Class Fleet_PRINT_GRPrintOffice
    Inherits System.Web.UI.Page
    Dim strGrId As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imglogo.ImageUrl = "~/Master/Images/logo.png"
        Image1.ImageUrl = "~/Master/Images/untitled.png"
        Image2.ImageUrl = "~/Master/Images/NotForSale.png"

        strGrId = Request.QueryString("GRNo")

        Dim p As New FleetGrMapping
        p.TerminalId = Session.Item("LoginTerminal")
        p.GrNo = strGrId
        FleetGrMapping.ReturnFleetGrMappingPrint(p)
        Dim strpParms As String = ""
        strpParms &= p.TerminalId
        strpParms &= "," & p.GrNo
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_FLEET_GR_PRINT_CONT", strpParms)
            gvContDetail.DataSource = dbr
            gvContDetail.DataBind()
        Catch ex As Exception
        End Try
        textTruck.Text = p.VehicleNo
        textConsignee.Text = p.CreatedBy
        textGrNo.Text = p.GrNo
        textdate.Text = p.CreatedOn

        Dim pGP As New FleetContJoDtls
        pGP.TerminalId = Session.Item("LoginTerminal")
        pGP.MtyContId = p.MtyContId
        FleetContJoDtls.ReturnFleetContJoDtls(pGP)


        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = pGP.ContJoId

        FleetContJo.ReturnFleetContJo(pFleetContJo)
        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        textConsignee.Text = pConsignee.CustomerName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.CustomerId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        textConsigner.Text = pConsignee.CustomerName


        ' textConsigner.Text = "KLPL"
        ' textContNo.Text = p.ContNo
        'textContSize.Text = p.ContSize
        TextTo.Text = p.ToLocation & "-" & p.FactoryLocation


    End Sub
End Class
