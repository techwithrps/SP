Imports LogiParkLib.LogiParkObjects
Partial Class Commercial_Preview_ExportInvoice
    Inherits System.Web.UI.Page
    Dim lngImpContId As Integer = 0
    Dim dblAmount As Double
    Dim dblTaxAmount As Double
    Dim dblTotalAmount As Double
    Dim dblWaiverAmt As Double
    Dim lngInvoiceno As Long
    Dim dblServiceTax As Double
    Dim dblEducTax As Double
    Dim dblHEduTax As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lngBookingId As Long = Request.QueryString("BookingId")
        Dim lngInvoiceTo As Long = Request.QueryString("InvoiceTo")
        Dim strPaymentMode As String = Request.QueryString("PaymentMode")
        lngInvoiceno = Request.QueryString("InvoiceNo")
        If strPaymentMode = "C" Then
            Dim p As New ExtImpInvoice
            p.InvoiceNo = lngInvoiceno
            p.TerminalId = Session.Item("LoginTerminal")

            ExtImpInvoice.ReturnInvoiceWithItemDetails(p)
            textInvoiceNo.Text = p.InvoiceNo
            textInvoiceDate.Text = p.CreatedOn

        End If
        Dim ptempPPP As New TempImpInvoiceItems
        ptempPPP.InvoiceNo = lngInvoiceno
        TempImpInvoiceItems.ReturnTempLineItemId(ptempPPP)
        ' ptemp.TerminalId = Session.Item("LoginTerminal")

        'ExtTempImpInvoice.ReturnTempImpInvoiceByInvoiceNo(ptemp)

        'Dim pFleetContJo As New FleetContJo
        'pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        'pFleetContJo.ContJoId = ptemp.LineItemId

        'FleetContJo.ReturnFleetContJo(pFleetContJo)
        'textBookingNo.Text = pFleetContJo.ContJoNo
        'Dim pConsignee As New CustomerMaster
        'pConsignee.TerminalId = Session.Item("LoginTerminal")
        'pConsignee.CustomerId = pFleetContJo.ConsigneeId
        'CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textCHA.Text = pConsignee.CustomerName


        'pConsignee.TerminalId = Session.Item("LoginTerminal")
        'pConsignee.CustomerId = pFleetContJo.CustomerId
        'CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textExporter.Text = pConsignee.CustomerName

        'pConsignee.TerminalId = Session.Item("LoginTerminal")
        'pConsignee.CustomerId = pFleetContJo.LineId
        'CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textLine.Text = pConsignee.CustomerName


        'Dim pExtCustomerMaster As New ExtCustomerMaster
        'pExtCustomerMaster.TerminalId = Session.Item("LoginTerminal")
        'pExtCustomerMaster.CustomerId = lngInvoiceTo
        'ExtCustomerMaster.ReturnCustomerMasterDetailsById(pExtCustomerMaster)
        'textInvoiceTo.Text = pExtCustomerMaster.CustomerName
        'textAddress.Text = pExtCustomerMaster.Address

        'If strPaymentMode = "C" Then
        '    textPaymentMode.Text = "Cash"
        'ElseIf strPaymentMode = "R" Then
        '    textPaymentMode.Text = "Credit"
        'Else
        '    textPaymentMode.Text = "PDA"
        'End If
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = ptempPPP.LineItemId
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        ' TextJob.Text = pFleetContJo.ContJoNo
        TextOfMode.Text = pFleetContJo.ModeType
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        textBlNo.Text = pExtAllPartyAccount.BlNo
        textPort.Text = pExtAllPartyAccount.POL
        TextPod.Text = pExtAllPartyAccount.Port
        TextJob.Text = pExtAllPartyAccount.JobNo
        textContType.Text = pExtAllPartyAccount.ContType
        textContSize.Text = pExtAllPartyAccount.ContSize
        textsobdate.Text = pExtAllPartyAccount.RequiredEtd
        textConsignee.Text = pExtAllPartyAccount.ConsingeeName
        'textGross.Text = pExtAllPartyAccount.GrossWt
        textSbNo.Text = pExtAllPartyAccount.SbNo
        TextShippingBillDate.Text = pExtAllPartyAccount.SbDate
        ' textPackages.Text = pExtAllPartyAccount.Cartons
        'textPackages.Text = pExtAllPartyAccount.Cartons
        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textAccount.Text = pConsignee.CustomerName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        ' Dim pLocation As New LocationMaster
        ' pLocation.TerminalId = pFleetContJo.TerminalId
        'pLocation.LocationId = pFleetContJo.FromLocation
        ' pLocation.HandoverLocation = pFleetContJo.ToLocationId
        ' pLocation.CustomerId = pFleetContJo.BillTo
        ' LocationMaster.ReturnLocationMasterByHandover(pLocation)
        ' textToLocation.Text = pLocation.LocationName
        Dim pTerminalLocation As New TerminalLocationMaster
        pTerminalLocation.LocationId = pFleetContJo.FromLocation
        TerminalLocationMaster.ReturnTerminalLocationByLocationId(pTerminalLocation)
        textToLocation.Text = pTerminalLocation.LocationName
        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pFleetContJo.MtyPickup
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        textLocationFrom.Text = pTerminal.TerminalName
        Dim pT As New TerminalMaster
        pT.TerminalId = pFleetContJo.ToLocationId
        TerminalMaster.ReturnTerminalMaster(pT)
        textHandover.Text = pT.TerminalName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        lblCustomerName.Text = pConsignee.CustomerName
        lblcustomeradd.Text = pConsignee.Address
        textCustomerState.Text = pConsignee.StateCode
        textCustomerGSTIN.Text = pConsignee.GSTN
        If pConsignee.AccountMapCode = 1 Then
            textCustomerType.Text = "B2B"
        Else

            'lblDDComapny.Text = "JSB CONSULTANTS"
            textCustomerType.Text = "BCB"
        End If
        ' textCustomerType.Text = pConsignee.AccountMapCode
        '  textInvoiceNo.Text = pExtImpInvoice.InvoiceRefNo
        ' textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        Dim pLine As New ExtCustomerMaster
        pLine.CustomerId = pFleetContJo.LineId
        ExtCustomerMaster.ReturnCustomerMaster(pLine)
        textLine.Text = pLine.CustomerCode

        Dim pTempInvoiceItems As New TempImpInvoiceItems
        pTempInvoiceItems.TerminalId = Session.Item("LoginTerminal")
        pTempInvoiceItems.InvoiceNo = lngInvoiceno
        fillRepeator(TempImpInvoiceItems.ReturnTempImpInvoiceItemsListBuInvoiceNo(pTempInvoiceItems))
        textInWords.Text = NumberToWord.AmtInWord(dblTotalAmount)
        Dim pComp As New CompanyMaster
        pComp.CompanyId = 2
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        ' textCompanyStateCode.Text = "State Code : " & pComp.StateCode
        textPlaceOfSupply.Text = pComp.StateCode
        lblTerminaladdress0.Text = pComp.Address
        lblCompanyName1.Text = pComp.CompanyName1
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If
        'If pImpInvoice.ServiceType = "F" Then
        '    lblHeaderText.Text = "Bill of Supply"
        'Else
        '    lblHeaderText.Text = "Tax Invoice"
        'End If

        labService.Text = pComp.ServiceTaxReg
        lblPan.Text = pComp.PanNo
        If pComp.CompanyId = 4 Then
            ' lblSignComapny.Text = "SPJ CARGO"
            lblCDtls.Text = "SPJ CARGO"
            'lblDDComapny.Text = "JSB CONSULTANTS"
            ' Label11.Text = "SPJ CARGO"

        Else
            ' lblSignComapny.Text = pComp.CompanyName
            lblCDtls.Text = pComp.CompanyName
            '  lblDDComapny.Text = pComp.CompanyName
            ' Label11.Text = pComp.CompanyName
        End If

        'If pComp.CompanyId = 1 Then
        '    If pImpInvoice.InvoiceDate > "24/09/2017" Then
        '        Label13.Text = "Bank Name: STATE BANK OF INDIA"
        '        Label14.Text = "NEW PLACE"
        '        LblAccountNo.Text = "A/C No. : 20169024317
        '        LblIFSC.Text = "IFSC Code :SBIN0011195"
        '    Else
        '        Label13.Text = "Bank Name: CORPORATION BANK"
        '        Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
        '        LblAccountNo.Text = "A/C No. : 510101005291096"
        '        LblIFSC.Text = "IFSC Code :CORP0000563"
        '    End If
        'ElseIf pComp.CompanyId = 2 Then
        '    If pImpInvoice.InvoiceDate > "24/09/2017" Then
        '        Label13.Text = "Bank Name: HDFC BANK"
        '        Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
        '        LblAccountNo.Text = "A/C No. : 50200018948863"
        '        LblIFSC.Text = "IFSC Code :HDFC0000329"
        '    Else
        '        Label13.Text = "Bank Name: CORPORATION BANK"
        '        Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
        '        LblAccountNo.Text = "A/C No. : 510101005289547"
        '        LblIFSC.Text = "IFSC Code :CORP0000563"
        '    End If

        'End If

    End Sub

 
    Private Sub fillRepeator(ByVal arr As ArrayList)
        If arr.Count = 0 Then
            Dim p As New TempImpInvoiceItems
            arr.Add(p)
        End If
        repInvoiceDetails.DataSource = arr
        repInvoiceDetails.DataBind()
    End Sub

    Protected Sub rcInvoiceDetails_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repInvoiceDetails.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim pTerminal As New CompanyMaster
            pTerminal.CompanyId = Session.Item("LoginTerminal")
            CompanyMaster.ReturnCompanyMasterbyId(pTerminal)
            '   textCompanyName.Text = pTerminal.CompanyName
            '  textCompanyAddress.Text = pTerminal.Address
            If CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value <> Nothing AndAlso CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value > 0 Then
                Dim pService As New ServiceMaster
                pService.TerminalId = Session.Item("LoginTerminal")
                pService.ServiceId = CType(e.Item.FindControl("hdnServiceId"), HiddenField).Value
                ServiceMaster.ReturnServiceMasterByServiceId(pService)
                CType(e.Item.FindControl("textService"), Label).Text = pService.ServiceName

                If CType(e.Item.FindControl("textRate"), Label).Text <> 0 Then
                    Dim pTempImpInvoiceTax As New TempImpInvoiceTax
                    pTempImpInvoiceTax.TerminalId = Session.Item("LoginTerminal")
                    pTempImpInvoiceTax.ItemKeyId = CType(e.Item.FindControl("hdnItemKeyId"), HiddenField).Value
                    For Each pTIT As TempImpInvoiceTax In TempImpInvoiceTax.ReturnTempImpInvoiceTaxListByItemKeyId(pTempImpInvoiceTax)
                        If pTIT.TaxHeadId = "5" Then
                            CType(e.Item.FindControl("textServiceTax"), Label).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "6" Then
                            CType(e.Item.FindControl("textEducTax"), Label).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                        If pTIT.TaxHeadId = "7" Then
                            CType(e.Item.FindControl("textHEduTax"), Label).Text = Math.Round(pTIT.TaxAmt, 2)
                        End If
                    Next
                End If
                
            End If
           
            Try
                dblAmount += Double.Parse(CType(e.Item.FindControl("textAmount"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblTaxAmount += Double.Parse(CType(e.Item.FindControl("textTaxAmount"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblTotalAmount += Double.Parse(CType(e.Item.FindControl("textTotalAmount"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblWaiverAmt += Double.Parse(CType(e.Item.FindControl("textWeiverReqAmt"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblServiceTax += Double.Parse(CType(e.Item.FindControl("textServiceTax"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblEducTax += Double.Parse(CType(e.Item.FindControl("textEducTax"), Label).Text)
            Catch ex As Exception
            End Try
            Try
                dblHEduTax += Double.Parse(CType(e.Item.FindControl("textHEduTax"), Label).Text)
            Catch ex As Exception
            End Try
        End If
        If e.Item.ItemType = ListItemType.Footer Then
            ' CType(e.Item.FindControl("textRepAmount"), Label).Text = Format(dblAmount, "#########,##0.00")
            CType(e.Item.FindControl("textRepTaxAmount"), Label).Text = Format(dblTaxAmount, "#########,##0.00")
            CType(e.Item.FindControl("textRepTotalAmount"), Label).Text = Format(dblTotalAmount, "#########,##0.00")
            ' CType(e.Item.FindControl("textRepWeiverReqAmt"), Label).Text = Format(dblWaiverAmt, "#########,##0.00")
            ' CType(e.Item.FindControl("textRepServiceTax"), Label).Text = Format(dblServiceTax, "#########,##0.00")
            'CType(e.Item.FindControl("textRepEducTax"), Label).Text = Format(dblEducTax, "#########,##0.00")
            '  CType(e.Item.FindControl("textRepHEducTax"), Label).Text = Format(dblHEduTax, "#########,##0.00")
        End If
    End Sub
End Class
