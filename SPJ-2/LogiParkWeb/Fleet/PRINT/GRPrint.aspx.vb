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

Partial Class Fleet_PRINT_GRPrint
    Inherits System.Web.UI.Page
    Dim strGrId As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        strGrId = Request.QueryString("GRNo")

        Dim p As New FleetGrMapping
        p.TerminalId = Session.Item("LoginTerminal")
        p.GrNo = strGrId
        FleetGrMapping.ReturnFleetGrMappingPrint(p)
        Dim Pdriver As New FleetDriverMaster
        Pdriver.DriverId = p.DriverId
        Pdriver.TerminalId = Session.Item("LoginTerminal")
        FleetDriverMaster.ReturnFleetDriverMaster(Pdriver)
        textDriverName.Text = Pdriver.DriverName
        textDriverName1.Text = Pdriver.DriverName
        textDriverName2.Text = Pdriver.DriverName
        LblDriverMobileNo.Text = Pdriver.MobileNo
        LblDriverMobileNo1.Text = Pdriver.MobileNo
        LblDriverMobileNo2.Text = Pdriver.MobileNo
        Dim pComp As New CompanyMaster
        pComp.CompanyId = p.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        Label2.Text = pComp.CompanyName
        Label4.Text = pComp.CompanyName
        Label3.Text = pComp.CompanyName
        ' Label5.Text = pComp.Address
        Label14.Text = pComp.Address
        If p.GrNo > 34989 Then
            lblCompanyName1.Text = pComp.CompanyTypeName
            Label70.Text = pComp.CompanyTypeName
            Label71.Text = pComp.CompanyTypeName
        Else
            lblCompanyName1.Text = pComp.CompanyName1
            Label70.Text = pComp.CompanyName1
            Label71.Text = pComp.CompanyName1
        End If
        'Label70.Text = pComp.CompanyName1
        'Label71.Text = pComp.CompanyName1
        Label11.Text = pComp.Address
        LblPanNo.Text = pComp.PanNo
        LblPan2.Text = pComp.PanNo
        lblGSTn.Text = pComp.ServiceTaxReg
        LblPan1.Text = pComp.PanNo
        LblStax1.Text = pComp.ServiceTaxReg
        LblStax2.Text = pComp.ServiceTaxReg
        Dim strpParms As String = ""
        strpParms &= p.TerminalId
        strpParms &= "," & p.GrNo
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If
        If pComp.Logo Is "" Then
            imglogo1.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo1.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If
        If pComp.Logo Is "" Then
            Image1.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            Image1.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If

        Dim str As String
        Dim strArr() As String
        Dim count As Integer
        str = p.ContNo
        strArr = str.Split("-")
        For count = 0 To strArr.Length - 1
            If count = 0 Then
                textContNo.Text = (strArr(count))
                textContNo1.Text = (strArr(count))
                textContNo2.Text = (strArr(count))
            Else
                TextJoNo.Text = (strArr(count))
                TextJoNo1.Text = (strArr(count))
                TextJoNo2.Text = (strArr(count))
            End If
        Next

        '  If count = 1 Then

        '  End If
        'Dim pCONTjO As New FleetContJo
        'pCONTjO.TerminalId = Session.Item("LoginTerminal")
        'pCONTjO.ContJoId = p.
        'For count = 0 To strArr.Length - 1
        '    MsgBox(strArr(count))
        'Next
        'textContNo.Text = p.ContNo
        textContSize.Text = p.ContSize
        textContSize2.Text = p.ContSize
        textContType.Text = p.ContType

        textContType2.Text = p.ContType

        Dim pFleetContJoDtls As New FleetContJoDtls
        pFleetContJoDtls.TerminalId = Session.Item("LoginTerminal")
        pFleetContJoDtls.MtyContId = p.MtyContId
        FleetContJoDtls.ReturnFleetContJoDtls(pFleetContJoDtls)
        textSelaNo.Text = pFleetContJoDtls.SealNo
        textPayLoad.Text = pFleetContJoDtls.CargoWt
        textSelaNo2.Text = pFleetContJoDtls.SealNo
        textPayLoad2.Text = pFleetContJoDtls.CargoWt
        'textSelaNo.Text = "0000"
        ' textPayLoad.Text = "23000"
        'textGrossWt.Text = pFleetContJoDtls.Weight
        'textNetWt.Text = ""
        'textGrossWt2.Text = pFleetContJoDtls.Weight
        'textNetWt2.Text = ""
        textTruck.Text = p.VehicleNo
        textTruck2.Text = p.VehicleNo
        ' textContNo1.Text = p.ContNo
        textContSize1.Text = p.ContSize
        textContType1.Text = p.ContType
        Dim pCustomerLine As New CustomerMaster
        pCustomerLine.TerminalId = Session.Item("LoginTerminal")
        pCustomerLine.CustomerId = pFleetContJoDtls.LineId
        CustomerMaster.ReturnCustomerMaster(pCustomerLine)
        textLine2.Text = pCustomerLine.CustomerName
        textLine.Text = pCustomerLine.CustomerName
        textLine1.Text = pCustomerLine.CustomerName
        textSelaNo1.Text = pFleetContJoDtls.SealNo
        textPayLoad1.Text = pFleetContJoDtls.CargoWt
        'textGrossWt1.Text = pFleetContJoDtls.Weight
        'textNetWt1.Text = ""
        textTruck1.Text = p.VehicleNo
        'textTruck1.Text = p.VehicleNo
        'textTruck2.Text = p.VehicleNo
        textOilSlipNo.Text = p.SlipNo
        textOilSlipNo1.Text = p.SlipNo
        'textConsignee.Text = p.CreatedBy
        'textConsignee1.Text = p.CreatedBy
        'textConsignee2.Text = p.CreatedBy
        TextFrom.Text = p.FromLocation
        TextFrom1.Text = p.FromLocation
        TextFrom2.Text = p.FromLocation
        textGrNo.Text = p.GrNo
        textGrNo1.Text = p.GrNo
        textGrNo2.Text = p.GrNo
        '=====added by arjun negi on 8/1/2026
         Dim pCommodityMaster As New CommodityMaster
        pCommodityMaster.CommodityId = p.CommodityId
        CommodityMaster.ReturnCommodityMasterAll(pCommodityMaster)
        Try
            txtCommodity.Text = pCommodityMaster.CommodityName
            txtCommodity1.Text = pCommodityMaster.CommodityName
            txtCommodity2.Text = pCommodityMaster.CommodityName
        Catch ex As Exception

        End Try
        ' textGrNo2.Text = p.GrNo
        ''''prabhakar
        textdate.Text = p.GrDate
        textdate1.Text = p.GrDate
        textdate2.Text = p.GrDate

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
        textConsigneeAddress.Text = pConsignee.Address
        textParyGSTIN.Text = pConsignee.GSTN

        textConsigneeAddress0.Text = pConsignee.Address
        textParyGSTIN0.Text = pConsignee.GSTN

        textConsigneeAddress1.Text = pConsignee.Address
        textParyGSTIN1.Text = pConsignee.GSTN

        textConsignee1.Text = pConsignee.CustomerName
        textConsignee2.Text = pConsignee.CustomerName

        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.CustomerId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        textConsigner.Text = pConsignee.CustomerName
        textConsigner1.Text = pConsignee.CustomerName
        textConsignor2.Text = pConsignee.CustomerName
        Dim pfcj As New FleetContJoDtls
        Dim pLocation As New TerminalLocationMaster
        pLocation.TerminalId = Session.Item("LoginTerminal")
        pLocation.LocationId = pFleetContJo.FromLocation
        TerminalLocationMaster.ReturnTerminalLocationByLocationId(pLocation)
        TextTo.Text = pLocation.LocationName
        TextTo1.Text = pLocation.LocationName
        textTo2.Text = pLocation.LocationName


        ' TextTo.Text = p.ToLocation
        'TextTo1.Text = p.ToLocation
        'textTo2.Text = p.ToLocation
        ' Dim pLocationDes As New TerminalLocationMaster
        ' pLocationDes.TerminalId = Session.Item("LoginTerminal")
        ' pLocationDes.LocationId = pFleetContJo.ToLocationId
        'TerminalLocationMaster.ReturnTerminalLocationByLocationId(pLocation)
        textPort.Text = p.FactoryLocation
        textPort1.Text = p.FactoryLocation
        textPort2.Text = p.FactoryLocation

        Dim pPormMaster As New PortMaster
        pPormMaster.TerminalId = 1
        pPormMaster.PortId = pGP.Fpod
        PortMaster.ReturnPortMaster(pPormMaster)
        Textdport.Text = pPormMaster.PortName
        Textdport1.Text = pPormMaster.PortName
        Textdport2.Text = pPormMaster.PortName

    End Sub

End Class
