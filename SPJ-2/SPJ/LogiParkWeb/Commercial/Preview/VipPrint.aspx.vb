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
Partial Class Commercial_Preview_VipPrint
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
        imglogo.ImageUrl = "~/Master/Images/logogcf.png"

        lngInvoiceNo = Request.QueryString("InvoiceNo")
        Dim lngTerminal As Long = Session.Item("LoginTerminal")
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pImpInvoice.InvoiceNo = lngInvoiceNo
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)
        textPlaceOfSupply.Text = "07"
        Dim pComp As New CompanyMaster
        pComp.CompanyId = pImpInvoice.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        lblCDtls.Text = pComp.CompanyName
        lblTerminaladdress0.Text = pComp.Address
        labService.Text = pComp.Remarks
        Label20.Text = pComp.PanNo
        lblSignComapny.Text = pComp.CompanyName
        lblDDComapny.Text = pComp.CompanyName
        Label11.Text = pComp.CompanyName
        If pComp.CompanyId = 1 Then
            lblCIN.Text = ""
            Label13.Text = "Bank Name: YES BANK LTD."
            Label14.Text = "Add. :SECTOR-3, VAISHALI"
            LblAccountNo.Text = "A/C No. : 047084600000184"
            LblIFSC.Text = "IFSC Code :YESB0000470"
        ElseIf pComp.CompanyId = 2 Then
            lblCIN.Text = "U63013DL2004PTC123789"
            Label13.Text = "Bank Name: YES BANK LTD."
            Label14.Text = "Add. :SHALIMAR BAGH, NEW DELHI"
            LblAccountNo.Text = "A/C No. : 034884600000352"
            LblIFSC.Text = "IFSC Code :YESB0000348"
        End If


        Dim pImpInvoiceItems As New ImpInvoiceItems
        pImpInvoiceItems.InvoiceNo = lngInvoiceNo
        Dim strpParms As String = ""
        strpParms &= pImpInvoiceItems.InvoiceNo
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_EXP_INV_PRINT2", strpParms)
            gvPaymentDetail.DataSource = dbr
            gvPaymentDetail.DataBind()
        Catch ex As Exception
        End Try
        Dim pExtImpInvoice As New ExtImpInvoice
        pExtImpInvoice.TerminalId = lngTerminal
        pExtImpInvoice.InvoiceNo = lngInvoiceNo
        ExtImpInvoice.ReturnInvoiceWithItemDetails(pExtImpInvoice)
        prepare(pExtImpInvoice)
        txtInvoiceNote.Text = pExtImpInvoice.InvoiceNote
        'textInWords.Text = NumberToWord.AmtInWord(lngBillAmountTotal)
        'textPrintedBy.Text = Session.Item("LoginUser")
    End Sub

    Sub prepare(ByVal pExtImpInvoice As ExtImpInvoice)
        Dim pFleetContJo As New FleetContJo
        pFleetContJo.TerminalId = Session.Item("LoginTerminal")
        pFleetContJo.ContJoId = pExtImpInvoice.LineItemId
        FleetContJo.ReturnFleetContJo(pFleetContJo)

        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        'LblContNO.Text = pExtAllPartyAccount.ContNo
        'TextPoDate.Text = pExtAllPartyAccount.PartyInvDate
        'TextPoNO.Text = pExtAllPartyAccount.PartyInvNo

        Dim pConsignee As New CustomerMaster
        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pFleetContJo.ConsigneeId
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        'textAccount.Text = pConsignee.CustomerName

        pConsignee.TerminalId = Session.Item("LoginTerminal")

        pConsignee.TerminalId = Session.Item("LoginTerminal")
        pConsignee.CustomerId = pExtImpInvoice.BillTo
        CustomerMaster.ReturnCustomerMaster(pConsignee)

        lblCustomerName.Text = pConsignee.CustomerName
        lblcustomeradd.Text = pConsignee.Address
        textCustomerState.Text = pConsignee.StateCode
        textCustomerGSTIN.Text = pConsignee.GSTN
        textInvoiceNo.Text = pExtImpInvoice.InvoiceRefNo
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate

        Dim pLine As New ExtCustomerMaster

    End Sub
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
        'Try
        '    Dim imagepath As String = HttpContext.Current.Server.MapPath("~/Master/Images/Logo.png")

        '    Dim png As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imagepath)
        '    png.ScaleToFit(100, 100)
        '    png.SetAbsolutePosition(100.0F, 680.0F)
        '    pdfDoc.Add(png)
        'Catch ex As Exception

        'End Try
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
            If DataBinder.Eval(e.Row.DataItem, "SERVICE") = "Transportation Charges" Then
                totaltptAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
                textTPTAmount.Text = (totaltptAmount * 5) / 100
            End If


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
End Class
