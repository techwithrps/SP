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
Imports LogiParkLib.DBConnection
Imports QRCoder
Partial Class Commercial_Preview_CrPrintNewRebate
    Inherits System.Web.UI.Page
    Dim intCounterTotal As Long = 0
    Dim lngRefId As Long = 0
    Dim rows As Integer = 10
    Dim lngImpContId As Integer = 0
    Dim dblAmountTotal As Double = 0
    Dim dblServiceTotal As Double = 0
    Dim dblEcessTotal As Double = 0
    Dim dblHcessTotal As Double = 0
    Dim dblTaxAmount As Double = 0
    Dim dblBillAmountTotal As Double = 0
    Dim lngInvoiceNo As Long
    Dim lngBookingId As Long
    Dim intCounter As Long = 0
    Dim lngBillAmountTotal As Long = 0
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
    Sub GetQrCode()
        Dim InvType As String = "C"
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
                    'lblHeaderText.Text = "Taxable Invoice"
                Else
                    plBarCode.Visible = False
                    lblIrnNo.Visible = False
                    textIrnNo.Visible = False
                    'lblHeaderText.Text = "Draft Invoice"
                End If
                QrCode(code)
            Catch ex As Exception

            End Try

        Else
            plBarCode.Visible = False
            lblIrnNo.Visible = False
            'lblHeaderText.Text = "Taxable Invoice"
        End If
    End Sub
    Sub Preview(ByVal pCr As CrNote, ByVal crItemDetails As DataTable)
        txtInvoiceNote.Text = pCr.CrNotes
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = pCr.TerminalId
        pImpInvoice.InvoiceNo = pCr.InvoiceID
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
        'textPlaceOfSupply.Text = "07"
        Dim pComp As New CompanyMaster
        pComp.CompanyId = pImpInvoice.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        lblTerminaladdress0.Text = pComp.Address
        lblCompanyName1.Text = pComp.CompanyName1
        labService.Text = pComp.ServiceTaxReg
        lblPan.Text = pComp.PanNo
        TextCrDate.Text = ""
        lblTerminaladdress0.Text = pComp.Address
        If Not String.IsNullOrEmpty(pComp.Logo) Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If

        'labService.Text = pComp.Remarks
        lblSignComapny.Text = pComp.CompanyName
        Label11.Text = pComp.CompanyName
        Try
            gvPaymentDetail.DataSource = crItemDetails
            gvPaymentDetail.DataBind()
        Catch ex As Exception
        End Try
        Dim pExtImpInvoice As New ExtImpInvoice
        pExtImpInvoice.TerminalId = pCr.TerminalId
        pExtImpInvoice.InvoiceNo = pCr.InvoiceID
        ExtImpInvoice.ReturnInvoiceWithItemDetails(pExtImpInvoice)
        prepare(pExtImpInvoice)
        Dim pBank As New BankMaster
        pBank.BankId = pExtImpInvoice.VisitId
        BankMaster.ReturnBankMaster(pBank)
        lblAcNo1.Text = pBank.AccountNo
        txtIFSC.Text = pBank.IfscCode
        TxtBank.Text = pBank.BankName
        Txtbranch.Text = pBank.BankAddress
        txtSwift.Text = pBank.SwiftCode
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim crObjFromSession = Me.Session.Item("CrNote")
        Dim tableCrItemDetails = Me.Session.Item("CNItemDetail")

        If crObjFromSession IsNot Nothing AndAlso tableCrItemDetails IsNot Nothing Then
            Dim p = CType(crObjFromSession, CrNote)
            Dim tb = CType(tableCrItemDetails, DataTable)
            If p IsNot Nothing AndAlso tb IsNot Nothing Then
                Preview(p, tb)
            End If
            Me.Session.Item("CrNote") = Nothing
            Me.Session.Remove("CrNote")

            Me.Session.Item("CNItemDetail") = Nothing
            Me.Session.Remove("CNItemDetail")
            Return
        End If
        lngInvoiceNo = Request.QueryString("InvoiceNo")
        Dim lngTerminal As Long = Session.Item("LoginTerminal")
        Dim pCr As New CrNote
        pCr.CrId = lngInvoiceNo
        CrNote.ReturnCreaditNotebyid(pCr)
        TextCrNo.Text = pCr.CrRefNo
        TextCrDate.Text = pCr.CrDate
        txtInvoiceNote.Text = pCr.CrNotes
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pImpInvoice.InvoiceNo = pCr.InvoiceID
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
        'textPlaceOfSupply.Text = "07"
        Dim pComp As New CompanyMaster
        pComp.CompanyId = pImpInvoice.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        lblTerminaladdress0.Text = pComp.Address
        lblCompanyName1.Text = pComp.CompanyName1
        lblCDtls.Text = pComp.CompanyName
        labService.Text = pComp.ServiceTaxReg
        lblPan.Text = pComp.PanNo
        lblTerminaladdress0.Text = pComp.Address
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If
        'labService.Text = pComp.Remarks
        lblSignComapny.Text = pComp.CompanyName
        Label11.Text = pComp.CompanyName
        Dim pImpInvoiceItems As New ImpInvoiceItems
        pImpInvoiceItems.InvoiceNo = lngInvoiceNo
        Dim strpParms As String = ""
        strpParms &= pCr.CrId
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_CR_PRINT", strpParms)
            gvPaymentDetail.DataSource = dbr
            gvPaymentDetail.DataBind()
        Catch ex As Exception
        End Try
        Dim pExtImpInvoice As New ExtImpInvoice
        pExtImpInvoice.TerminalId = lngTerminal
        pExtImpInvoice.InvoiceNo = pCr.InvoiceID
        ExtImpInvoice.ReturnInvoiceWithItemDetails(pExtImpInvoice)
        prepare(pExtImpInvoice)
        Dim pBank As New BankMaster
        ' pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pBank.BankId = pExtImpInvoice.VisitId
        BankMaster.ReturnBankMaster(pBank)
        lblAcNo1.Text = pBank.AccountNo
        txtIFSC.Text = pBank.IfscCode
        TxtBank.Text = pBank.BankName
        Txtbranch.Text = pBank.BankAddress
        txtSwift.Text = pBank.SwiftCode
        GetQrCode()
    End Sub
    Sub prepare(ByVal pExtImpInvoice As ExtImpInvoice)
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = pExtImpInvoice.LineItemId
        FleetContJo.ReturnFleetContJo(pFleetContJo)
        ' TextJob.Text = pFleetContJo.ContJoNo
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
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
        ' textToLocation.Text = pTerminalLocation.LocationName
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

        ' textCustomerType.Text = pConsignee.AccountMapCode
        textInvoiceNo.Text = pExtImpInvoice.InvoiceRefNo
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        Dim pLine As New ExtCustomerMaster
        pLine.CustomerId = pFleetContJo.LineId
        ExtCustomerMaster.ReturnCustomerMaster(pLine)
        Dim strpParms As String = ""
        strpParms &= pExtImpInvoice.InvoiceNo
    End Sub
    Protected Sub btnRTF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRTF.Click
        '  btnPDF.Visible = False
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

    Dim totalBaseAmount As Double = 0
    Dim totalCGSTAmount As Double = 0
    Dim totalSGSTAmount As Double = 0
    Dim totalIGSTAmount As Double = 0
    Dim totalTaxAmount As Double = 0
    Dim totalBillAmount As Double = 0
    Dim totaltptAmount As Double = 0
    Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            totalBaseAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
            totalCGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "HECESS"))
            totalSGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ECESS"))
            totalIGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SERVICE_TAX"))
            totalTaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TAX_AMOUNT"))
            totalBillAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_AMOUNT"))
            'If DataBinder.Eval(e.Row.DataItem, "SERVICE") = "Transportation Charges" Then
            '    totaltptAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
            '    textTPTAmount.Text = (totaltptAmount * 5) / 100
            'End If


        ElseIf e.Row.RowType = DataControlRowType.Footer Then

            e.Row.Cells(0).ColumnSpan = 7
            e.Row.Cells(0).Text = "Total Charges"
            e.Row.Cells(0).Font.Bold = True
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(1).Text = Math.Round(totalBaseAmount, 2)
            e.Row.Cells(1).Font.Bold = True
            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(2).Text = ""
            e.Row.Cells(2).Font.Bold = True
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(3).Text = Math.Round(totalCGSTAmount, 2)
            e.Row.Cells(3).Font.Bold = True
            e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(4).Text = ""
            e.Row.Cells(4).Font.Bold = True
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(5).Text = Math.Round(totalSGSTAmount, 2)
            e.Row.Cells(5).Font.Bold = True
            e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(6).Text = ""
            e.Row.Cells(6).Font.Bold = True
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(7).Text = Math.Round(totalIGSTAmount, 2)
            e.Row.Cells(7).Font.Bold = True
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(8).Text = Math.Round(totalTaxAmount, 2)
            e.Row.Cells(8).Font.Bold = True
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right

            e.Row.Cells(9).Text = Math.Round(totalBillAmount, 2)
            e.Row.Cells(9).Font.Bold = True
            e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False
            e.Row.Cells(15).Visible = False
        End If
        lblAmountsInWords.Text = NumberToWord.AmtInWord(Math.Round(totalBillAmount, 2))
    End Sub
End Class

