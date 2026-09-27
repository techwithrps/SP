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
Partial Class Commercial_Preview_SPJInvoicePrint
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
        Dim pImpInvoice As New ImpInvoice
        pImpInvoice.TerminalId = Session.Item("LoginTerminal")
        pImpInvoice.InvoiceNo = lngInvoiceNo
        ImpInvoice.ReturnImpInvoiceByInvoiceNo(pImpInvoice)

        hdnAdvance.Value = pImpInvoice.AdvanceAmount
        Dim pComp As New CompanyMaster
        pComp.CompanyId = pImpInvoice.CompanyId
        CompanyMaster.ReturnCompanyMasterbyId(pComp)
        textCompanyStateCode.Text = "State Code : " & pComp.StateCode
        textPlaceOfSupply.Text = pComp.StateCode
        lblTerminaladdress0.Text = pComp.Address
        lblCompanyName1.Text = pComp.CompanyName1
        If pComp.Logo Is "" Then
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        Else
            imglogo.ImageUrl = "~/Master/Images/" + pComp.Logo
        End If

        labService.Text = pComp.Remarks
        Label20.Text = pComp.PanNo
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

        If pComp.CompanyId = 1 Then
            lblCIN.Text = ""
            Label13.Text = "Bank Name: STATE BANK OF INDIA."
            Label14.Text = "Add. :NEHRU PLACE"
            LblAccountNo.Text = "A/C No. : 20169024317"
            LblIFSC.Text = "IFSC Code :SBIN0011195"
        ElseIf pComp.CompanyId = 4 Then
            lblCIN.Text = ""
            Label13.Text = "Bank Name: STATE BANK OF INDIA."
            Label14.Text = "Add. :NEHRU PLACE"
            LblAccountNo.Text = "A/C No. : 20169024317"
            LblIFSC.Text = "IFSC Code :SBIN0011195"
        ElseIf pComp.CompanyId = 2 Then
            lblCIN.Text = "U63013DL2004PTC123789"
            Label13.Text = "Bank Name: STATE BANK OF INDIA."
            Label14.Text = "Add. :NEHRU PLACE"
            LblAccountNo.Text = "A/C No. : 20169024317"
            LblIFSC.Text = "IFSC Code :SBIN0011195"
        End If

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
        TextJob.Text = pFleetContJo.ContJoNo
        TextOfMode.Text = pFleetContJo.ModeType
        Dim pExtAllPartyAccount As New ExtAllPartyAccount
        pExtAllPartyAccount.ContJoId = pFleetContJo.ContJoId
        ExtAllPartyAccount.ReturnAllPartyAccountByContJoId(pExtAllPartyAccount)
        textBlNo.Text = pExtAllPartyAccount.BlNo
        textPort.Text = pExtAllPartyAccount.POL
        TextPod.Text = pExtAllPartyAccount.Port
        textConsignee.Text = pExtAllPartyAccount.ConsingeeName
        textGross.Text = pExtAllPartyAccount.GrossWt
        textPackages.Text = pExtAllPartyAccount.Cartons
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
        pConsignee.CustomerId = pExtImpInvoice.BillTo
        CustomerMaster.ReturnCustomerMaster(pConsignee)
        lblCustomerName.Text = pConsignee.CustomerName
        lblcustomeradd.Text = pConsignee.Address
        textCustomerState.Text = pConsignee.StateCode
        textCustomerGSTIN.Text = pConsignee.GSTN
        textInvoiceNo.Text = pExtImpInvoice.InvoiceRefNo
        textInvoiceDate.Text = pExtImpInvoice.InvoiceDate
        Dim pLine As New ExtCustomerMaster
        pLine.CustomerId = pFleetContJo.LineId
        ExtCustomerMaster.ReturnCustomerMaster(pLine)
        textLine.Text = pLine.CustomerCode
        Dim strpParms As String = ""
        strpParms &= pExtImpInvoice.InvoiceNo
        Try
            Dim dbr As OleDb.OleDbDataReader
            Dim db As New DBConnect
            dbr = db.StoredProcedureReadDB("SELECT_PKG.SP_SPJ_INV_PRINT", strpParms)
            gvContainerDetail.DataSource = dbr
            gvContainerDetail.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub gvContainerDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvContainerDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            intCounter = intCounter + 1
            e.Row.Cells(0).Text = intCounter
        End If
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

    Dim totalBaseAmount As Double = 0
    Dim totalCGSTAmount As Double = 0
    Dim totalSGSTAmount As Double = 0
    Dim totalIGSTAmount As Double = 0
    Dim totalTaxAmount As Double = 0
    Dim totalBillAmount As Double = 0
    Dim totaltptAmount As Double = 0
    Dim TotalAdvanceAmount As Double = 0
    Protected Sub gvPaymentDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPaymentDetail.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            totalBaseAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
            totalCGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "HECESS"))
            totalSGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ECESS"))
            totalIGSTAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SERVICE_TAX"))
            totalTaxAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TAX_AMOUNT"))
            totalBillAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_AMOUNT"))
            If DataBinder.Eval(e.Row.DataItem, "SERVICE_CODE") = "996511" Then
                totaltptAmount += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "AMOUNT"))
                'textTPTAmount.Text = (totaltptAmount * 5) / 100
            End If


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

        End If
        lblAmountsInWords.Text = NumberToWord.AmtInWord(Math.Round(totalBillAmount, 2))
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
        cell2.Text = Math.Round(totalBaseAmount, 2)
        cell2.HorizontalAlign = HorizontalAlign.Right
        cell2.Font.Bold = True
        row.Cells.Add(cell2)
        Dim cell3 As New TableCell()
        cell3.Text = ""
        cell3.HorizontalAlign = HorizontalAlign.Right
        cell3.Font.Bold = True
        row.Cells.Add(cell3)
        Dim cell4 As New TableCell()
        cell4.Text = Math.Round(totalCGSTAmount, 2)
        cell4.HorizontalAlign = HorizontalAlign.Right
        cell4.Font.Bold = True
        row.Cells.Add(cell4)
        Dim cell5 As New TableCell()
        cell5.Text = ""
        cell5.HorizontalAlign = HorizontalAlign.Right
        cell5.Font.Bold = True
        row.Cells.Add(cell5)
        Dim cell6 As New TableCell()
        cell6.Text = Math.Round(totalSGSTAmount, 2)
        cell6.HorizontalAlign = HorizontalAlign.Right
        cell6.Font.Bold = True
        row.Cells.Add(cell6)
        Dim cell7 As New TableCell()
        cell7.Text = ""
        cell7.HorizontalAlign = HorizontalAlign.Right
        cell7.Font.Bold = True
        row.Cells.Add(cell7)
        Dim cell8 As New TableCell()
        cell8.Text = Math.Round(totalIGSTAmount, 2)
        cell8.HorizontalAlign = HorizontalAlign.Right
        cell8.Font.Bold = True
        row.Cells.Add(cell8)
        Dim cell9 As New TableCell()
        cell9.Text = Math.Round(totalIGSTAmount, 2)
        cell9.HorizontalAlign = HorizontalAlign.Right
        cell9.Font.Bold = True
        row.Cells.Add(cell9)
        Dim cell10 As New TableCell()
        totalBillAmount = totalBillAmount - hdnAdvance.Value
        cell10.Text = Math.Round(totalBillAmount, 2)
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
End Class
