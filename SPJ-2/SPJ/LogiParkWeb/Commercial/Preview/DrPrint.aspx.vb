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
Partial Class Commercial_Preview_DrPrint
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' imglogo.ImageUrl = "~/Master/Images/logogcf.png"

        lngInvoiceNo = Request.QueryString("InvoiceNo")
        Dim lngTerminal As Long = Session.Item("LoginTerminal")
        Dim pCr As New DrNote
        pCr.DrId = lngInvoiceNo
        DrNote.ReturnCreaditNotebyid(pCr)
        TextCrNo.Text = pCr.DrRefNo
        TextCrDate.Text = pCr.DrDate
        txtInvoiceNote.Text = pCr.DrNotes
        Dim pCostBooking As New CostBooking
        pCostBooking.CostID = pCr.CostId
        ' pCostBooking.TerminalId = Session.Item("LoginTerminal")
        CostBooking.ReturnPurchaseDetailsByCostId(pCostBooking)
        'Dim pImpInvoice As New ImpInvoice
        'pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        'pImpInvoice.InvoiceNo = pCr.InvoiceID
        'ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
        textPlaceOfSupply.Text = "07"
        Dim pComp As New CompanyMaster
        pComp.CompanyId = pCostBooking.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        lblCDtls.Text = pComp.CompanyName
        lblTerminaladdress0.Text = pComp.Address
        labService.Text = pComp.Remarks
        Label20.Text = pComp.PanNo
        lblSignComapny.Text = pComp.CompanyName
        lblDDComapny.Text = pComp.CompanyName
        Label11.Text = pComp.CompanyName
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If

        'Dim pImpInvoiceItems As New ImpInvoiceItems
        'pImpInvoiceItems.InvoiceNo = lngInvoiceNo
        Dim strpParms As String = ""
        strpParms &= pCr.DrId
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_DR_PRINT", strpParms)
            gvPaymentDetail.DataSource = dbr
            gvPaymentDetail.DataBind()
        Catch ex As Exception
        End Try
        'Dim pExtImpInvoice As New ExtImpInvoice
        'pExtImpInvoice.TerminalId = lngTerminal
        'pExtImpInvoice.InvoiceNo = pCr.InvoiceID
        'ExtImpInvoice.ReturnInvoiceWithItemDetails(pExtImpInvoice)
        prepare(pCostBooking)
        'txtInvoiceNote.Text = pExtImpInvoice.InvoiceNote
        'textInWords.Text = NumberToWord.AmtInWord(lngBillAmountTotal)
        'textPrintedBy.Text = Session.Item("LoginUser")

        If pComp.CompanyId = 1 Then
            If pCostBooking.LinerInvoiceDate > "24/09/2017" Then
                Label13.Text = "Bank Name: HDFC BANK"
                Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
                LblAccountNo.Text = "A/C No. : 50200018947070"
                LblIFSC.Text = "IFSC Code :HDFC0000329"
            Else
                Label13.Text = "Bank Name: CORPORATION BANK"
                Label14.Text = "Add. :VASUNDARA ENCLAVE DELHI-110096"
                LblAccountNo.Text = "A/C No. : 510101005291096"
                LblIFSC.Text = "IFSC Code :CORP0000563"
            End If
            lblCIN.Text = ""
        ElseIf pComp.CompanyId = 2 Then
            lblCIN.Text = "U63013DL2004PTC123789"
            If pCostBooking.LinerInvoiceDate > "24/09/2017" Then
                Label13.Text = "Bank Name: HDFC BANK"
                Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
                LblAccountNo.Text = "A/C No. : 50200018948863"
                LblIFSC.Text = "IFSC Code :HDFC0000329"
            Else
                Label13.Text = "Bank Name: CORPORATION BANK"
                Label14.Text = "Add. :VASHUNDRA ENCLAVE DELHI-110096"
                LblAccountNo.Text = "A/C No. : 510101005289547"
                LblIFSC.Text = "IFSC Code :CORP0000563"
            End If

        End If

    End Sub

    Sub prepare(ByVal pCostBooking As CostBooking)
        'Dim pFleetContJo As New FleetContJo
        'pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        'pFleetContJo.ContJoId = pExtImpInvoice.LineItemId
        'FleetContJo.ReturnFleetContJo(pFleetContJo)
        'Dim pExtAllPartyAccount As New ExtAllPartyAccount
        'pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        'ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        textBlNo.Text = pCostBooking.BLNO
        'textPort.Text = pExtAllPartyAccount.POL
        'TextPod.Text = pExtAllPartyAccount.Port
        If pCostBooking.PurchaseType = "L" Then
            Dim pConsignee As New CustomerMaster
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.CustomerId = pCostBooking.BillingParty
            CustomerMaster.ReturnCustomerMaster(pConsignee)
            textAccount.Text = pConsignee.CustomerName
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.CustomerId = pCostBooking.BillingParty
            CustomerMaster.ReturnCustomerMaster(pConsignee)
            lblCustomerName.Text = pConsignee.CustomerName
            lblcustomeradd.Text = pConsignee.Address
            textCustomerState.Text = pConsignee.StateCode
            textCustomerGSTIN.Text = pConsignee.GSTN
            textInvoiceNo.Text = pCostBooking.LinerInvoiceNo
            textInvoiceDate.Text = pCostBooking.LinerInvoiceDate
        Else
            Dim pConsignee As New VendorMaster
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.VendorId = pCostBooking.BillingParty
            VendorMaster.ReturnVendorMaster(pConsignee)
            textAccount.Text = pConsignee.VendorName
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.TerminalId = Session.Item("LoginTerminal")
            pConsignee.VendorId = pCostBooking.BillingParty
            VendorMaster.ReturnVendorMaster(pConsignee)
            lblCustomerName.Text = pConsignee.VendorName
            lblcustomeradd.Text = pConsignee.Address
            textCustomerState.Text = pConsignee.State
            textCustomerGSTIN.Text = pConsignee.GSTIN
            textInvoiceNo.Text = pCostBooking.LinerInvoiceNo
            textInvoiceDate.Text = pCostBooking.LinerInvoiceDate

        End If
          End Sub
    Protected Sub btnPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        Me.Page.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()
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

            e.Row.Cells(0).ColumnSpan = 6
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

