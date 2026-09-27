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
Imports LogiParkLib.DBConnection
Imports QRCoder
Partial Class Import_Preview_ImportInvoicePrint

    Inherits System.Web.UI.Page
    Dim intCounterTotal As Long = 0
    Dim LngImpKeyId As Long = 0
    Dim lngBankId As Long = 0
    Dim lngBillTo As Long = 0
    Dim StrType As String = ""
    Dim StrItemKeyId As String = ""
    Dim lngRefId As Long = 0
    Dim rows As Integer = 10
    Dim lngImpContId As Integer = 0
    Dim dblAmountTotal As Double = 0.0
    Dim dblServiceTotal As Double = 0.0
    Dim dblEcessTotal As Double = 0.0
    Dim dblHcessTotal As Double = 0.0
    Dim dblTaxAmount As Double = 0.0
    Dim dblBillAmountTotal As Double = 0.0
    Dim lngInvoiceNo As Long
    Dim lngBookingId As Long
    Dim intCounter As Long = 0
    Dim lngBillAmountTotal As Long = 0.0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' imglogo.ImageUrl = "~/Master/Images/logogcf.png"
        lngInvoiceNo = Request.QueryString("InvoiceNo")
        StrType = Request.QueryString("Type")
        StrItemKeyId = Request.QueryString("ItemKeyId")
        lngBankId = Request.QueryString("BankId")
        lngBillTo = Request.QueryString("BillTo")
        Dim lngTerminal As Long = Session.Item("LoginTerminal")
        Dim pComp As New CompanyMaster
        If StrType = "" Then
            StrType = "Print"
        End If
        If StrType = "Print" Then
            Dim InvType As String = "M"
            Dim strpParms5 As String = ""
            strpParms5 &= lngInvoiceNo
            strpParms5 &= ", '" & InvType & "'"
            Dim liveStatus As String = ""

            Dim dbr5 As OleDb.OleDbDataReader
            Dim db5 As New DBConnect
            Dim dt5 As New DataTable
            dbr5 = db5.StoredProcedureReadDB("EINVOICE_PKG.SP_EINV_LIVE_BY_INV", strpParms5)
            dt5.Load(dbr5)
            liveStatus = dt5.Rows(0)("ELIVE_STATUS")
            If liveStatus = "Y" Then
                Dim strpParms6 As String = ""
                Dim code As String = ""
                Dim IRN As String = ""
                strpParms6 &= lngInvoiceNo
                Dim dbr6 As OleDb.OleDbDataReader
                Dim db6 As New DBConnect
                Dim dt6 As New DataTable
                dbr6 = db6.StoredProcedureReadDB("EINVOICE_PKG.SP_ERN_DTLS_BY_INV_NO", strpParms6)
                dt6.Load(dbr6)
                Try

                    If dt6.Rows.Count > 0 Then
                        code = dt6.Rows(0)("SIGNED_QR_CODE")
                        IRN = dt6.Rows(0)("IRN")

                        plBarCode.Visible = True
                        lblIrnNo.Visible = True
                        textIrnNo.Text = IRN
                        textIrnNo.Visible = True
                        lblHeaderText.Text = "Taxable Invoice"
                    Else
                        plBarCode.Visible = False
                        lblIrnNo.Visible = False
                        textIrnNo.Visible = False
                        lblHeaderText.Text = "Performa Invoice"
                    End If
                    QrCode(code)
                Catch ex As Exception

                End Try

            Else
                plBarCode.Visible = False
                lblIrnNo.Visible = False
                lblHeaderText.Text = "Performa Invoice"
            End If

            Dim pImpInvoice As New ImpInvoice
            pImpInvoice.TerminalId = Session.Item("LoginTerminal")
            pImpInvoice.InvoiceNo = lngInvoiceNo
            ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
            hdnAdvance.Value = pImpInvoice.AdvanceAmount
            pComp.CompanyId = pImpInvoice.CompanyId
            CompanyMaster.ReturnCompanyMasterbyId(pComp)

            Try
                If pImpInvoice.InvoiceNo > 161114 Then
                    lblCompanyName1.Text = pComp.CompanyTypeName
                Else
                    lblCompanyName1.Text = pComp.CompanyName1
                End If
            Catch ex As Exception

            End Try

            If pImpInvoice.PrintStatus = "Y" Then
                lblHeaderText.Text = "Tax Invoice"
            Else
                lblHeaderText.Text = "Proforma Invoice"
            End If
            If pImpInvoice.ServiceType = "O" Then
                ' lblHeaderText.Text = "Tax Invoice"
                TrUsd.Visible = True
                lblInWord.Text = "Amount In INR : -"
                lblInWord.Font.Bold = True
            Else
                ' lblHeaderText.Text = "Tax Invoice"
                TrUsd.Visible = False
            End If
            Dim pExtImpInvoice As New ExtImpInvoice
            pExtImpInvoice.TerminalId = lngTerminal
            pExtImpInvoice.InvoiceNo = lngInvoiceNo
            ExtImpInvoice.ReturnInvoiceWithItemDetails(pExtImpInvoice)
            prepare(pExtImpInvoice)
            txtInvoiceNote.Text = pExtImpInvoice.InvoiceNote
            lngBankId = pExtImpInvoice.VisitId
        Else
            ''''''''''''''''''''''''''''''For Priview''''''''''''''''''''''''''''''''''''''''
            '''
            pComp.CompanyId = Session.Item("CompanyId")
            CompanyMaster.ReturnCompanyMasterbyId(pComp)
            lblHeaderText.Text = "Performa Invoice"
            PriviewDetails()
            TrUsd.Visible = False

        End If
        ' textCompanyStateCode.Text = "State Code : " & pComp.StateCode
        ' textPlaceOfSupply.Text = pComp.StateCode
        '   lblTerminaladdress0.Text = pComp.Address
        ' lblCompanyName1.Text = pComp.CompanyName1
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If
        labService.Text = pComp.ServiceTaxReg
        lblPan.Text = pComp.PanNo
        If pComp.CompanyId = 4 Then
            lblSignComapny.Text = "SPJ CARGO"
            lblCDtls.Text = "SPJ CARGO"
            'lblDDComapny.Text = "JSB CONSULTANTS"
            Label11.Text = "SPJ CARGO"

        Else
            lblSignComapny.Text = pComp.CompanyName
            lblCDtls.Text = pComp.CompanyName
            '  lblDDComapny.Text = pComp.CompanyName
            Label11.Text = pComp.CompanyName

            hdnAdvance.Value = 0
            ' lblIrnNo.Visible = False
        End If


        Dim pBank As New BankMaster
        ' pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pBank.BankId = lngBankId
        BankMaster.ReturnBankMaster(pBank)
        lblAcNo1.Text = pBank.AccountNo
        txtIFSC.Text = pBank.IfscCode
        TxtBank.Text = pBank.BankName
        Txtbranch.Text = pBank.BankAddress
        txtSwift.Text = pBank.SwiftCode
        'txtSwift.Text = pBank.AccountNo
        'txtInvoiceNote.Text = pBank.BankName

        'If pComp.CompanyId = 1 Then
        '    ' lblCIN.Text = ""
        '    Label13.Text = "Bank Name: STATE BANK OF INDIA."
        '    Label14.Text = "Add. :NEHRU PLACE"
        '    LblAccountNo.Text = "A/C No. : 20169024317"
        '    LblIFSC.Text = "IFSC Code :SBIN0011195"
        'ElseIf pComp.CompanyId = 4 Then
        '    '  lblCIN.Text = ""
        '    Label13.Text = "Bank Name: STATE BANK OF INDIA."
        '    Label14.Text = "Add. :NEHRU PLACE"
        '    LblAccountNo.Text = "A/C No. : 20169024317"
        '    LblIFSC.Text = "IFSC Code :SBIN0011195"
        'ElseIf pComp.CompanyId = 2 Then
        '    ' lblCIN.Text = "U63013DL2004PTC123789"
        '    Label13.Text = "Bank Name: Union Bank of India"
        '    Label14.Text = "Add. :SSI, OKHLA-1, NEW DELHI-110020"
        '    LblAccountNo.Text = "A/C No. : 502204010000061"
        '    LblIFSC.Text = "IFSC Code :UBIN0550221"
        'End If

        'If pComp.CompanyId = 1 Then
        '    If pImpInvoice.InvoiceDate > "24/09/2017" Then
        '        Label13.Text = "Bank Name: HDFC BANK"
        '        Label14.Text = "Add. :VASUNDHARA ENCLAVE, NEW DELHI"
        '        LblAccountNo.Text = "A/C No. : 50200018947070"
        '        LblIFSC.Text = "IFSC Code :HDFC0000329"
        '    Else
        '        Label13.Text = "Bank Name: CORPORATION BANK"
        '        Label14.Text = "Add. :VASUNDARA ENCLAVE DELHI-110096"
        '        LblAccountNo.Text = "A/C No. : 510101005291096"
        '        LblIFSC.Text = "IFSC Code :CORP0000563"
        '    End If
        '    lblCIN.Text = ""
        'ElseIf pComp.CompanyId = 2 Then
        '    lblCIN.Text = "U63013DL2004PTC123789"
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

        Dim pImpInvoiceItems As New ImpInvoiceItems
        pImpInvoiceItems.InvoiceNo = lngInvoiceNo
        Dim strpParms As String = ""
        strpParms &= pImpInvoiceItems.InvoiceNo
        strpParms &= ",'" & StrType & "','" & StrItemKeyId & "'"
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EXP_INV_PRINT2", strpParms)
            gvPaymentDetail.DataSource = dbr
            gvPaymentDetail.DataBind()
        Catch ex As Exception

        End Try

        'textInWords.Text = NumberToWord.AmtInWord(lngBillAmountTotal)
        'textPrintedBy.Text = Session.Item("LoginUser")
    End Sub
    Sub PriviewDetails()
        Dim strConnectionString, cmd1 As String
        strConnectionString = System.Configuration.ConfigurationManager.AppSettings("DBConnectionString")

        cmd1 = "SELECT LINE_ITEM_ID FROM TEMP_IMP_INVOICE_ITEMS WHERE INVOICE_NO=" & lngInvoiceNo
        Using con As New OleDb.OleDbConnection(strConnectionString)
            con.Open()
            Dim ada As New OleDb.OleDbDataAdapter(cmd1, con)
            Dim dt As New DataTable
            ada.Fill(dt)

            If dt.Rows.Count > 0 Then
                HdnLineItemId.Value = dt.Rows(0).Item("LINE_ITEM_ID")
            End If

        End Using
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = HdnLineItemId.Value
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        ' TextJob.Text = pFleetContJo.ContJoNo
        '  TextOfMode.Text = pFleetContJo.ModeType
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        ' textBlNo.Text = pExtAllPartyAccount.BlNo
        'textPort.Text = pExtAllPartyAccount.POL
        'TextPod.Text = pExtAllPartyAccount.Port
        'TextJob.Text = pExtAllPartyAccount.JobNo
        'textContType.Text = pExtAllPartyAccount.ContType
        'textContSize.Text = pExtAllPartyAccount.ContSize
        'textsobdate.Text = pExtAllPartyAccount.RequiredEtd
        'textConsignee.Text = pExtAllPartyAccount.ConsingeeName
        'textGross.Text = pExtAllPartyAccount.GrossWt
        'textSbNo.Text = pExtAllPartyAccount.SbNo
        'TextShippingBillDate.Text = pExtAllPartyAccount.SbDate
        ' textPackages.Text = pExtAllPartyAccount.Cartons
        'textPackages.Text = pExtAllPartyAccount.Cartons
        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textAccount.Text = pConsignee.CustomerName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        textPlaceOfSupply.Text = pConsignee.StateCode
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
        'textToLocation.Text = pTerminalLocation.LocationName
        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pFleetContJo.MtyPickup
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        'textLocationFrom.Text = pTerminal.TerminalName
        Dim pT As New TerminalMaster
        pT.TerminalId = pFleetContJo.ToLocationId
        TerminalMaster.ReturnTerminalMaster(pT)
        'textHandover.Text = pT.TerminalName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = lngBillTo
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
        textShipmentType.Text = "SEA IMPORT/AIR IMPORT"
        ' textCustomerType.Text = pConsignee.AccountMapCode
        Dim pLine As New ExtCustomerMaster
        pLine.CustomerId = pFleetContJo.LineId
        ExtCustomerMaster.ReturnCustomerMaster(pLine)
        'textLine.Text = pLine.CustomerCode
        Dim strpParms As String = ""
        strpParms &= lngInvoiceNo
        strpParms &= ",'" & StrItemKeyId & "'"
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            'dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SPJ_INV_PRINT", strpParms)
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SPJ_INV_PRIVIEW", strpParms)
            '   gvContainerDetail.DataSource = dbr
            '  gvContainerDetail.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub prepare(ByVal pExtImpInvoice As ExtImpInvoice)
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = pExtImpInvoice.LineItemId
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        ' TextJob.Text = pFleetContJo.ContJoNo
        'TextOfMode.Text = pFleetContJo.ModeType
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        'textBlNo.Text = pExtAllPartyAccount.BlNo
        'textPort.Text = pExtAllPartyAccount.POL
        'TextPod.Text = pExtAllPartyAccount.Port
        'TextJob.Text = pExtAllPartyAccount.JobNo
        'textContType.Text = pExtAllPartyAccount.ContType
        'textContSize.Text = pExtAllPartyAccount.ContSize
        'textsobdate.Text = pExtAllPartyAccount.RequiredEtd
        'textConsignee.Text = pExtAllPartyAccount.ConsingeeName
        'textGross.Text = pExtAllPartyAccount.GrossWt
        'textSbNo.Text = pExtAllPartyAccount.SbNo
        'TextShippingBillDate.Text = pExtAllPartyAccount.SbDate
        ' textPackages.Text = pExtAllPartyAccount.Cartons
        'textPackages.Text = pExtAllPartyAccount.Cartons
        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textAccount.Text = pConsignee.CustomerName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        'textPlaceOfSupply.Text = pConsignee.StateCode
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
        'textToLocation.Text = pTerminalLocation.LocationName
        Dim pTerminal As New TerminalMaster
        pTerminal.TerminalId = pFleetContJo.MtyPickup
        TerminalMaster.ReturnTerminalMaster(pTerminal)
        'textLocationFrom.Text = pTerminal.TerminalName
        Dim pT As New TerminalMaster
        pT.TerminalId = pFleetContJo.ToLocationId
        TerminalMaster.ReturnTerminalMaster(pT)
        'textHandover.Text = pT.TerminalName
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pExtImpInvoice.BillTo
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        lblCustomerName.Text = pConsignee.CustomerName
        lblcustomeradd.Text = pConsignee.Address
        textCustomerState.Text = pConsignee.StateCode
        textCustomerGSTIN.Text = pConsignee.GSTN
        Try
            If pConsignee.AccountMapCode = 1 Then
                textCustomerType.Text = "B2B"
            Else

                'lblDDComapny.Text = "JSB CONSULTANTS"
                textCustomerType.Text = "BCB"
            End If
        Catch ex As Exception
            textCustomerType.Text = "B2B"
        End Try
        textShipmentType.Text = "SEA IMPORT/AIR IMPORT"

        ' textCustomerType.Text = pConsignee.AccountMapCode
        textInvoiceNo.Text = pExtImpInvoice.InvoiceRefNo
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        Try
            textjobNo.Text = pExtImpInvoice.BookingNo
        Catch ex As Exception
        End Try
        Dim pCustomer As New CustomerMaster
        pCustomer.TerminalId = Session.Item("LoginTerminal")
        pCustomer.CustomerId = pExtImpInvoice.BillTo
        CustomerMaster.ReturnCustomerMaster(pCustomer)
        textPlaceOfSupply.Text = pCustomer.StateCode
        pConsignee.TerminalId = Session.Item("LoginTerminal")


        Dim pLine As New ExtCustomerMaster
        pLine.CustomerId = pFleetContJo.LineId
        ExtCustomerMaster.ReturnCustomerMaster(pLine)
        'textLine.Text = pLine.CustomerCode
        Dim strpParms As String = ""
        strpParms &= pExtImpInvoice.InvoiceNo
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SPJ_INV_PRINT", strpParms)

            '   gvContainerDetail.DataSource = dbr
            '  gvContainerDetail.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub gvContainerDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContainerDetail.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        intCounter = intCounter + 1
    '        e.Row.Cells(0).Text = intCounter
    '    End If
    'End Sub



    Protected Sub btnPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        'If Page.IsPostBack Then
        '    Page.Controls.Remove(Page.FindControl("repInvoiceDetails"))
        '    Page.Controls.Remove(Page.FindControl("hdnServiceMode")))
        'End If
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Dim sb As New StringBuilder()
        'Dim sw As New StringWriter(sb)
        'Dim hw As New HtmlTextWriter(sw)
        'pnlInvoice.RenderControl(hw)
        'Dim sr As New StringReader(sw.ToString())
        'Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        'Dim htmlparser As New HTMLWorker(pdfDoc)
        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        'pdfDoc.Open()
        'htmlparser.Parse(sr)
        'pdfDoc.Close()
        'Response.Write(pdfDoc)
        'Response.[End]()

        'Dim pdfpath As String = Server.MapPath("PDFs")
        'Dim imagepath As String = Server.MapPath("Images")
        'Dim doc As New Document()
        'Try
        '    PdfWriter.GetInstance(doc, New FileStream(pdfpath & "/Images.pdf", FileMode.Create))
        '    doc.Open()

        '    doc.Add(New Paragraph("GIF"))
        '    Dim gif As Image = Image.GetInstance(imagepath & "/mikesdotnetting.gif")
        '    doc.Add(gif)
        '    'Log error;
        'Catch ex As Exception
        'Finally
        '    doc.Close()
        'End Try
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf")
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Dim sw As New StringWriter()
        'Dim hw As New HtmlTextWriter(sw)
        'Me.Page.RenderControl(hw)
        'Dim sr As New StringReader(sw.ToString())
        'Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        'Dim htmlparser As New HTMLWorker(pdfDoc)

        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        'pdfDoc.Open()
        'Try
        '    Dim imagepath As String = HttpContext.Current.Server.MapPath("~/Master/Images/Logo.png")

        '    Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath)
        '    png.ScaleToFit(100, 100)
        '    png.SetAbsolutePosition(100.0F, 680.0F)
        '    pdfDoc.Add(png)
        'Catch ex As Exception

        'End Try
        'htmlparser.Parse(sr)
        'pdfDoc.Close()
        'Response.Write(pdfDoc)
        'Response.[End]()
    End Sub

    Protected Sub btnRTF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRTF.Click
        btnPDF.Visible = False
        btnRTF.Visible = False
        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Charset = ""

        HttpContext.Current.Response.ContentType = "application/msword"

        Dim strFileName As String = "GenerateDocument" + ".doc"
        HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName)

        Dim strHTMLContent As New StringBuilder()
        Dim sw As New StringWriter(strHTMLContent)
        Dim hw As New HtmlTextWriter(sw)
        Me.Page.RenderControl(hw)

        HttpContext.Current.Response.Write(strHTMLContent)
        HttpContext.Current.Response.End()
        HttpContext.Current.Response.Flush()
    End Sub

    Dim totalBaseAmount As Double = 0.0
    Dim totalCGSTAmount As Double = 0.0
    Dim totalSGSTAmount As Double = 0.0
    Dim totalIGSTAmount As Double = 0.0
    Dim totalTaxAmount As Double = 0.0
    Dim totalBillAmount As Double = 0.0
    Dim totaltptAmount As Double = 0.0
    Dim TotalAdvanceAmount As Double = 0.0
    Dim totalRate As Double = 0.0
    Dim ExRate As Double = 0.0
    Dim TotalQnty As Double = 0.0
    Dim TotalQnty1 As Double = 0.0
    Dim totalusd As Double = 0.0
    Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            totalBaseAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
            totalCGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "HECESS"))
            totalSGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ECESS"))
            totalIGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SERVICE_TAX"))
            totalTaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TAX_AMOUNT"))
            totalBillAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_AMOUNT"))
            ExRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "EX_RATE"))
            ' If DataBinder.Eval(e.Row.DataItem, "SERVICE_CODE") = "996511" Then
            totaltptAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
            totalRate += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BILL_RATE"))
            TotalQnty += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "QNTY"))
            TotalQnty1 = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "QNTY"))
            'textTPTAmount.Text = (totaltptAmount * 5) / 100
            'End If
            'totalusd = totalRate * TotalQnty1 / totalBillAmount / ExRate

            totalusd = totalBillAmount / ExRate

        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            If hdnAdvance.Value > 0 Then
                e.Row.Cells(0).ColumnSpan = 7
                e.Row.Cells(0).Text = "Advance"
                e.Row.Cells(0).Font.Bold = True
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(1).Text = "0"
                e.Row.Cells(1).Font.Bold = True
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(2).Text = ""
                e.Row.Cells(2).Font.Bold = True
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(3).Text = "0"
                e.Row.Cells(3).Font.Bold = True
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(4).Text = ""
                e.Row.Cells(4).Font.Bold = True
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(5).Text = "0"
                e.Row.Cells(5).Font.Bold = True
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(6).Text = ""
                e.Row.Cells(6).Font.Bold = True
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(7).Text = "0"
                e.Row.Cells(7).Font.Bold = True
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(8).Text = "0"
                e.Row.Cells(8).Font.Bold = True
                e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
                TotalAdvanceAmount = hdnAdvance.Value
                e.Row.Cells(9).Text = Math.Round(TotalAdvanceAmount, 2)
                e.Row.Cells(9).Font.Bold = True
                e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(10).Visible = False
                e.Row.Cells(11).Visible = False
                e.Row.Cells(12).Visible = False
                e.Row.Cells(13).Visible = False
                e.Row.Cells(14).Visible = False
                e.Row.Cells(15).Visible = False
                Total()
            Else
                e.Row.Cells(0).ColumnSpan = 7
                e.Row.Cells(0).Text = "Total Charges"
                e.Row.Cells(0).Font.Bold = True
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(1).Text = Math.Round(totalBaseAmount, 2).ToString("0.00")
                e.Row.Cells(1).Font.Bold = True
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(2).Text = ""
                e.Row.Cells(2).Font.Bold = True
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(3).Text = Math.Round(totalCGSTAmount, 2).ToString("0.00")
                e.Row.Cells(3).Font.Bold = True
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(4).Text = ""
                e.Row.Cells(4).Font.Bold = True
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(5).Text = Math.Round(totalSGSTAmount, 2).ToString("0.00")
                e.Row.Cells(5).Font.Bold = True
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(6).Text = ""
                e.Row.Cells(6).Font.Bold = True
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(7).Text = Math.Round(totalIGSTAmount, 2).ToString("0.00")
                e.Row.Cells(7).Font.Bold = True
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(8).Text = Math.Round(totalTaxAmount, 2).ToString("0.00")
                e.Row.Cells(8).Font.Bold = True
                e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(9).Text = Math.Round(totalBillAmount, 2).ToString("0.00")
                e.Row.Cells(9).Font.Bold = True
                e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right

                e.Row.Cells(10).Visible = False
                e.Row.Cells(11).Visible = False
                e.Row.Cells(12).Visible = False
                e.Row.Cells(13).Visible = False
                e.Row.Cells(14).Visible = False
                e.Row.Cells(15).Visible = False

            End If
            less()
        End If

    End Sub
    Sub less()
        Dim index As Integer = gvPaymentDetail.Rows.Count
        Dim row As New GridViewRow(1, 0, DataControlRowType.Footer, DataControlRowState.Normal)
        Dim cell As New TableCell()
        cell.ColumnSpan = 14
        cell.Text = "Round Of Amount"
        cell.Font.Size = 12
        cell.Font.Bold = True
        cell.Font.Bold = True
        cell.HorizontalAlign = HorizontalAlign.Right
        row.Cells.Add(cell)
        gvPaymentDetail.Controls(0).Controls.Add(row)
        'Dim cell6 As New TableCell()
        'row.Cells.Add(cell6)
        Dim cell2 As New TableCell()
        cell2.ColumnSpan = 2
        cell2.Text = Format(Math.Round(totalBillAmount, 0, MidpointRounding.AwayFromZero), "0.00")
        Dim total As Long = Format(Math.Round(totalBillAmount, 0, MidpointRounding.AwayFromZero), "0.00")
        cell2.Font.Size = 12
        cell2.Font.Bold = True
        ' totalsbST = cell2.Text
        cell2.HorizontalAlign = HorizontalAlign.Right
        cell2.Font.Bold = True
        row.Cells.Add(cell2)
        totalusd = Math.Round(totalusd, 2)
        TxtUsd.Text = "($" & totalusd & ")" & NumberToWord.AmtInUSDWord(Math.Round(totalusd, 0))
        lblAmountsInWords.Text = NumberToWord.AmtInWord(Math.Round(total, 0))
    End Sub
    Sub Total()
        Dim index As Integer = gvPaymentDetail.Rows.Count
        Dim row As New GridViewRow(1, 0, DataControlRowType.Footer, DataControlRowState.Normal)
        Dim cell As New TableCell()
        cell.Text = "Total Charges "
        cell.Font.Bold = True
        cell.HorizontalAlign = HorizontalAlign.Right
        row.Cells.Add(cell)
        gvPaymentDetail.Controls(0).Controls.Add(row)
        cell.ColumnSpan = 7
        Dim cell2 As New TableCell()
        cell2.Text = Math.Round(totalBaseAmount, 2).ToString("0.00")
        cell2.HorizontalAlign = HorizontalAlign.Right
        cell2.Font.Bold = True
        row.Cells.Add(cell2)
        Dim cell3 As New TableCell()
        cell3.Text = ""
        cell3.HorizontalAlign = HorizontalAlign.Right
        cell3.Font.Bold = True
        row.Cells.Add(cell3)
        Dim cell4 As New TableCell()
        cell4.Text = Math.Round(totalCGSTAmount, 2).ToString("0.00")
        cell4.HorizontalAlign = HorizontalAlign.Right
        cell4.Font.Bold = True
        row.Cells.Add(cell4)
        Dim cell5 As New TableCell()
        cell5.Text = ""
        cell5.HorizontalAlign = HorizontalAlign.Right
        cell5.Font.Bold = True
        row.Cells.Add(cell5)
        Dim cell6 As New TableCell()
        cell6.Text = Math.Round(totalSGSTAmount, 2).ToString("0.00")
        cell6.HorizontalAlign = HorizontalAlign.Right
        cell6.Font.Bold = True
        row.Cells.Add(cell6)
        Dim cell7 As New TableCell()
        cell7.Text = ""
        cell7.HorizontalAlign = HorizontalAlign.Right
        cell7.Font.Bold = True
        row.Cells.Add(cell7)
        Dim cell8 As New TableCell()
        cell8.Text = Math.Round(totalIGSTAmount, 2).ToString("0.00")
        cell8.HorizontalAlign = HorizontalAlign.Right
        cell8.Font.Bold = True
        row.Cells.Add(cell8)
        Dim cell9 As New TableCell()
        cell9.Text = Math.Round(totalIGSTAmount, 2).ToString("0.00")
        cell9.HorizontalAlign = HorizontalAlign.Right
        cell9.Font.Bold = True
        row.Cells.Add(cell9)
        Dim cell10 As New TableCell()
        totalBillAmount = totalBillAmount - hdnAdvance.Value
        cell10.Text = Math.Round(totalBillAmount, 2).ToString("0.00")
        cell10.HorizontalAlign = HorizontalAlign.Right
        cell10.Font.Bold = True
        row.Cells.Add(cell10)

    End Sub

    'Sub HDRF()
    '    Dim index As Integer = gvServiceDetail.Rows.Count
    '    Dim row As New GridViewRow(2, 0, DataControlRowType.Footer, DataControlRowState.Normal)
    '    Dim cell As New TableCell()
    '    cell.Text = "Service Tax Handling @ 14% "
    '    cell.Font.Bold = True
    '    cell.HorizontalAlign = HorizontalAlign.Right
    '    row.Cells.Add(cell)
    '    gvServiceDetail.Controls(0).Controls.Add(row)
    '    cell.ColumnSpan = 12
    '    Dim cell2 As New TableCell()
    '    cell2.Text = 0
    '    cell2.HorizontalAlign = HorizontalAlign.Right
    '    cell2.Font.Bold = True
    '    row.Cells.Add(cell2)
    '    Dim cell3 As New TableCell()
    '    cell3.Text = 0
    '    cell3.HorizontalAlign = HorizontalAlign.Right
    '    cell3.Font.Bold = True
    '    row.Cells.Add(cell3)
    '    Dim cell4 As New TableCell()
    '    cell4.Text = Math.Round((totalHD * 0.14), 2)
    '    cell4.HorizontalAlign = HorizontalAlign.Right
    '    cell4.Font.Bold = True
    '    row.Cells.Add(cell4)
    '    Dim cell5 As New TableCell()
    '    cell5.Text = 0
    '    cell5.HorizontalAlign = HorizontalAlign.Right
    '    cell5.Font.Bold = True
    '    row.Cells.Add(cell5)
    '    Dim cell6 As New TableCell()
    '    cell6.Text = 0
    '    cell6.HorizontalAlign = HorizontalAlign.Right
    '    cell6.Font.Bold = True
    '    row.Cells.Add(cell6)
    '    Dim cell7 As New TableCell()
    '    cell7.Text = Math.Round((totalHD * 0.14), 2)
    '    cell7.HorizontalAlign = HorizontalAlign.Right
    '    cell7.Font.Bold = True
    '    row.Cells.Add(cell7)
    'End Sub
    'Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then

    '        dblAmountTotal = dblAmountTotal + Math.Round(Double.Parse(e.Row.Cells(3).Text), 2)
    '        dblServiceTotal = dblServiceTotal + Math.Round(Double.Parse(e.Row.Cells(4).Text), 2)
    '        dblEcessTotal = dblEcessTotal + Math.Round(Double.Parse(e.Row.Cells(5).Text), 2)
    '        dblHcessTotal = dblHcessTotal + Math.Round(Double.Parse(e.Row.Cells(6).Text), 2)
    '        dblTaxAmount = dblTaxAmount + Math.Round(Double.Parse(e.Row.Cells(7).Text), 2)
    '        dblBillAmountTotal = dblBillAmountTotal + Math.Round(Double.Parse(e.Row.Cells(8).Text), 2)
    '        textAmountTotal.Text = dblAmountTotal
    '        textServiceTotal.Text = dblServiceTotal
    '        textEcessTotal.Text = dblEcessTotal
    '        textHcessTotal.Text = dblHcessTotal
    '        textTaxAmount.Text = dblTaxAmount
    '        lngBillAmountTotal = Convert.ToInt64(dblBillAmountTotal)
    '        textBillAmountTotal.Text = lngBillAmountTotal
    '    End If
    'End Sub
    Sub QrCode(ByVal QrCode1 As String)
        Dim code As String = QrCode1
        ' Dim code As String = "test1"
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.L)
        Dim imgBarCode As New System.Web.UI.WebControls.Image()
        imgBarCode.Height = 160
        imgBarCode.Width = 160
        Dim qrCode As QRCode = New QRCode(qrCodeData)
        Using bitMap As Bitmap = qrCode.GetGraphic(5)
            Using ms As New MemoryStream()
                bitMap.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim byteImage As Byte() = ms.ToArray()
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage)
            End Using
            plBarCode.Controls.Add(imgBarCode)
        End Using
    End Sub
End Class
