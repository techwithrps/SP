Imports System.Data.OleDb
Imports LogiParkLib.LogiParkObjects
Imports System
Imports System.Web
Imports System.IO
Imports LogiParkLib.DBConnection
Partial Class Fleet_Print_FleetJobOrderPrint
    Inherits System.Web.UI.Page
    Dim rows As Integer = 1
    Dim JoID As Long = 0
    Dim intCounter As Long = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        JoID = Request.QueryString("JoId")
        Dim lngTerminal As Long = Session.Item("LoginTerminal")
        ' Dim CompanyId As Long = Session.Item("CompanyId")

      
        Dim pFJO As New FleetJoDtls
        pFJO.TerminalId = lngTerminal
        'pFJO.TerminalId = Session.Item("CompanyId")
        pFJO.JoId = JoID
        prepare(pFJO)
    End Sub

    Sub prepare(ByVal PfJO As FleetJoDtls)
      
         FleetJoDtls.ReturnFleetJoDtlsByJoNo(PfJO)
        textJoNO.Text = PfJO.JoNo
        textJoDate.Text = PfJO.JoDate
        textJoValidity.Text = PfJO.JoValidity
        textVehicleNo.Text = PfJO.VehicleNo
        textWorkshop.Text = PfJO.Location
        textJoFor.Text = PfJO.JoFor
        textJoType.Text = PfJO.JoType
        Session.Item("CompanyId") = PfJO.CompanyId
        '    Textamt.Text = PfJO.CloseAdvance
        'textremark.Text = PfJO.Note
        Dim pVehicle As New FleetEquipmentMaster
        pVehicle.TerminalId = PfJO.TerminalId
        pVehicle.EquipmentId = PfJO.VehicleId
        FleetEquipmentMaster.ReturnFleetEquipmentMaster(pVehicle)
        textVehicleType.Text = pVehicle.EquipmentType

        Dim pComp As New CompanyMaster
        pComp.CompanyId = PfJO.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        lblCDtls.Text = pComp.CompanyName

        If PfJO.CloseDate <> "" Then
            lblScreenTitle.Text = "Maintenance Job Order Close"
           

            '  textCremark.Text = PfJO.CloseNote
            ' TextMech.Text = PfJO.Mech
        Else
            lblScreenTitle.Text = "Maintenance Job Order"
        End If
        Dim pFJD As New FleetJoItemDtls
        pFJD.TerminalId = PfJO.TerminalId
        pFJD.JoId = PfJO.JoId
        fillRepeator2(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))
        'Dim pFJD As New FleetJoItemDtls
        'pFJD.TerminalId = PfJO.TerminalId
        'pFJD.JoId = PfJO.JoId
        'fillRepeator2(FleetJoItemDtls.ReturnFleetJoItemDtlsList(pFJD))


    End Sub
    Private Sub fillRepeator2(ByVal arr2 As ArrayList)
        If arr2.Count <= rows Then
            For i As Integer = 0 To rows - (arr2.Count + 1)
                Dim p As New FleetJoItemDtls
                arr2.Add(p)
            Next
        End If
        rcContainers.DataSource = arr2
        rcContainers.DataBind()
    End Sub


    Protected Sub rcContainers_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rcContainers.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            If CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnJoDtlsId"), HiddenField).Value > 0 Then
                Dim pItemGroup As New ItemGroupMaster
                pItemGroup.ItemGroupId = CType(e.Item.FindControl("hdnItemGroupId"), HiddenField).Value
                pItemGroup.TerminalId = Session.Item("LoginTerminal")
                ItemGroupMaster.ReturnItemMaster(pItemGroup)
                CType(e.Item.FindControl("txtItemGroupName"), Label).Text = pItemGroup.ItemGroupName
            End If
        End If

    End Sub
End Class
