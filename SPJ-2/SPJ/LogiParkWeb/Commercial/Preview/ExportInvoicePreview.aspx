<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExportInvoicePreview.aspx.vb"
    Inherits="Commercial_Preview_ExportInvoice" Theme="Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" height="10px" width="100%">
                        <tr>
                            <td align="center" width="10%" valign="top">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="imglogo" runat="server" Width="170px" Height="100px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" width="100%">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="2" align="center" style="text-decoration: none; font-family: Calibri;
                                            font-size: 20pt">
                                            <b>
                                                <asp:Label ID="lblHeaderText" runat="server" Text="Tax Invoice"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="text-decoration: none; font-family: Calibri;
                                            font-size: 15pt">
                                            <asp:Label ID="lblCDtls" runat="server" Text="SPJ CARGO PVT.LTD." Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblCompanyName1" CssClass="FormLabel" Text="International Freight Forwarders & Custom House Agent"
                                                runat="server"></asp:Label>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblTerminaladdress0" CssClass="FormLabel" Text="D-9/3, Okhla Industrial Area Phase-1, New Delhi-110020"
                                                runat="server"></asp:Label>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="Center">
                                            <asp:Label ID="labGSTN" CssClass="FormTextBoxLeft" runat="server" Text="GSTIN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="labService" CssClass="FormTextBoxLeft" runat="server" Text="07AAFPB3130K1Z5"
                                                Font-Size="Small"></asp:Label>
                                        </td>
                                        <td align="Center">
                                            <asp:Label ID="Label26" CssClass="FormTextBoxLeft" runat="server" Text="PAN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="lblPan" CssClass="FormTextBoxLeft" runat="server" Text="AAFPB3130K"
                                                Font-Size="Small"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td align="left">
                                            <asp:Label ID="Label2" runat="server" Font-Size="11pt" Text="Delhi, India"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="center" colspan="2">
                                            &nbsp;&nbsp;
                                            <asp:Label ID="lblCIN1" CssClass="FormTextBoxLeft" runat="server" Text="CIN :" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label2" CssClass="FormTextBoxLeft" runat="server" Text="U63013DL2003PTC121227"
                                                Font-Size="Small"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblcmContact0" runat="server" Text="Tel: +91 - 11-41062143-2147" Font-Size="11pt"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblEmail" CssClass="FormTextBoxLeft" runat="server" Text="Email: accounts@spjcargo.com"
                                                Font-Size="Small"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="Original For Receipent" Width="160"  Font-Size="10" Font-Bold="true" />
                                    <br />
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Duplicate For Supplier" Width="160" Font-Size="10" Font-Bold="true" />--%>
                                <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="160" Font-Size="10pt"
                                    Font-Bold="True" Font-Overline="False">
                                    <asp:ListItem Value="1" Selected="True">Original For Receipent</asp:ListItem>
                                    <asp:ListItem Value="2">Duplicate For Supplier</asp:ListItem>
                                </asp:CheckBoxList>--%>
                                <%--<input id="printpagebutton" type="button" value="Print" onclick="printpage()" />--%>
                            </td>
                           <%-- <td>
                                <asp:PlaceHolder ID="plBarCode" runat="server"></asp:PlaceHolder>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="100%" frame="Box">
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="Label28" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="To, "></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left" style="width: 180px">
                                <asp:Label ID="lblCustomerName" Font-Bold="true" Font-Size="Medium" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="Label1" runat="server" CssClass="FormTextBoxLeft" Text="Add" Font-Size="Small"></asp:Label>&nbsp;
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcustomeradd" Width="300px" CssClass="FormTextBoxLeft" Height="100%"
                                    Font-Size="Small" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="sb" runat="server">
                            <td align="left" class="auto-style2">
                                <asp:Label ID="textStateCode" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                    Text="State Code"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerState" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr id="cha" runat="server">
                            <td align="left" class="auto-style2">
                                <asp:Label ID="textGSTIN" runat="server" Font-Size="Small" Text="GSTIN" CssClass="FormTextBoxLeft"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerGSTIN" CssClass="FormLabel" runat="server" Text="07HYSPT6767J98V"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblCustomerType" Width="120px" CssClass="FormLabel" Text="Customer Type"
                                    runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblLine" Width="60px" CssClass="FormLabel" Text="Line" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textLine" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblBlNo" Width="60px" CssClass="FormLabel" Text="BL No" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textBlNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr id="TrNote" runat="server">
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblShippingBill" Width="90px" CssClass="FormLabel" Text="SB No." runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textSbNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblShippingDate" Width="90px" CssClass="FormLabel" Text="SB Date"
                                    runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextShippingBillDate" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr id="Tr2" runat="server">
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblETDSOV" Width="120px" CssClass="FormLabel" Text="ETD/SOB DATE"
                                    runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textsobdate" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table width="100%" height="100%" frame="Box">
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="lblConsignor" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Invoice No."></asp:Label>
                            </td>
                            <td class="auto-style3">
                                :
                            </td>
                            <td>
                                <asp:Label ID="textInvoiceNo" Font-Bold="true" Width="160px" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                                <br />
                                <asp:HiddenField ID="hdnAdvance" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="lblIDate" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Dated"></asp:Label>
                            </td>
                            <td class="auto-style3">
                                :
                            </td>
                            <td>
                                <asp:Label ID="textInvoiceDate" Font-Bold="true" Width="110px" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblJob" Width="60px" CssClass="FormLabel" Text="Job No" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left" style="width: 250px">
                                <asp:Label ID="TextJob" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblMode" Width="120px" CssClass="FormLabel" Text="Mode Of Shipment"
                                    runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextOfMode" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblPlaceOfSupply" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Place of Supply"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textPlaceOfSupply" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                    Text="07-Delhi"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblContSize" Width="60px" CssClass="FormLabel" Text="Size" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textContSize" CssClass="FormLabel" runat="server" Text="Size"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblContType" Width="60px" CssClass="FormLabel" Text="Type" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textContType" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblConsignee" Width="60px" CssClass="FormLabel" Text="Consignee" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textConsignee" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="lblPort" Width="60px" CssClass="FormLabel" Text="POL" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textPort" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style2">
                                <asp:Label ID="LblPOD" Width="60px" CssClass="FormLabel" Text="POD" runat="server"></asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextPod" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td align="Right" style="width: 200px">
                                <asp:Label ID="lblFromLocation" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Empty Pickup"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left" style="width: 200px">
                                <asp:Label ID="textLocationFrom" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblToLocation" Width="130px" CssClass="FormTextBoxLeft" Text="Factory Location"
                                    runat="server" Font-Size="Small"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left" style="width: 200px">
                                <asp:Label ID="textToLocation" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                            <td align="right" style="width: 200px">
                                <asp:Label ID="Label7" CssClass="FormTextBoxLeft" Text="Clerance Port" runat="server"
                                    Font-Size="Small"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left" style="width: 200px">
                                <asp:Label ID="textHandover" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt; height: 12px">
                    <strong>SUMMARY OF CHARGES</strong>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Repeater ID="repInvoiceDetails" runat="server">
                        <HeaderTemplate>
                            <table cellspacing="0">
                                <tr>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 90px;">
                                        <b>Cont No</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 250px;">
                                        <b>Service</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 40px;">
                                        <b>Qnty</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 55px;">
                                        <b>Rate</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 80px;">
                                        <b>Amount</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 100px;">
                                        <b>Service Tax</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 100px;">
                                        <b>Educ Tax</b>
                                    </td>
                                    <td align="right" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 100px;">
                                        <b>HEdu Tax</b>
                                    </td>
                                    <td align="center" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 100px;">
                                        <b>Tax Amount</b>
                                    </td>
                                    <td align="right" style="border-top-style: solid; font-family: Verdana; font-size: 11px;
                                        border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;
                                        width: 100px;">
                                        <b>Total Amount</b>
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="textContNo" runat="server" CssClass="FormTextBoxLeft" Width="90px"
                                        Text='<%#Eval("ContNo") %>'>
                                    </asp:Label>
                                    <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                </td>
                                <%-- <td>
                                                <asp:Label ID="textSize" runat="server" CssClass="FormTextBoxCenter" Width="20px"
                                                    Text='<%#Eval("ContSize") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="textGateInDate" runat="server" CssClass="FormTextBoxLeft" Width="110px"></asp:Label>
                                            </td>--%>
                                <td style="text-align: center;">
                                    <asp:Label ID="textService" runat="server" CssClass="FormTextBoxLeft" Width="250px"></asp:Label>
                                    <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                    <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="textQuntity" runat="server" Text='<%# Eval("BillQnty") %>' ToolTip="Quantity"
                                        CssClass="FormTextBoxNumeric" Width="40px">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textRate" runat="server" CssClass="FormTextBoxNumeric" Width="55px"
                                        Text='<%# Eval("BillRate") %>' ToolTip="Rate">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textAmount" runat="server" CssClass="FormTextBoxNumeric" Width="80px"
                                        Text='<%# string.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate")) - Eval("WeiverAprAmt")) %>'
                                        ToolTip="Amount">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textServiceTax" runat="server" CssClass="FormTextBoxNumeric" Width="100px"
                                        Text="" ToolTip="Service Tax">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textEducTax" runat="server" CssClass="FormTextBoxNumeric" Width="100px"
                                        Text="" ToolTip="Educ Tax">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textHEduTax" runat="server" CssClass="FormTextBoxNumeric" Width="100px"
                                        Text="" ToolTip="HEdu Tax">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textTaxAmount" runat="server" CssClass="FormTextBoxNumeric" Width="100px"
                                        Text='<%# string.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") *  Eval("BillRate"))-Eval("WeiverAprAmt"))) %>'
                                        ToolTip="Tax Amount">
                                                    ToolTip="Tax Amount">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="textTotalAmount" runat="server" CssClass="FormTextBoxNumeric" Width="100px"
                                        Text='<%# string.Format("{0:n2}",Eval("BillAmount")) %>' ToolTip="Total Amount">
                                    </asp:Label>
                                </td>
                                <%-- <td>
                                                <asp:Label ID="textWeiverReqAmt" runat="server" CssClass="FormTextBoxNumeric" Width="75px"
                                                    Text='<%# string.Format("{0:n2}", Eval("WeiverAprAmt")) %>'  onchange="return checkWeaverAmt();" ToolTip="Waiver Request Amount">
                                                </asp:Label>
                                            </td>--%>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<tr>
                                            <td colspan="4">
                                            </td>
                                            <td colspan="4" align="right">
                                                <hr style="height: 1px" />
                                            </td>
                                        </tr>--%>
                            <tr align="right">
                                <td colspan="2">
                                    <asp:Label ID="lbltotal" runat="server" Width="405px" CssClass="btnForm" BackColor="White"
                                        Font-Bold="true" Text="Grand Total :"></asp:Label>
                                </td>
                                <%-- <td width="80px" align="left">
                                                <asp:Label ID="textRepAmount" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                                    Width="80px" ToolTip="Amount"></asp:Label>
                                            </td>
                                            <td width="100px" align="left">
                                                <asp:Label ID="textRepServiceTax" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                                    Width="100px" ToolTip="Service Tax"></asp:Label>
                                            </td>
                                            <td width="100px" align="left">
                                                <asp:Label ID="textRepEducTax" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                                    Width="100px" ToolTip="Educ Tax"></asp:Label>
                                            </td>
                                            <td width="100px" align="left">
                                                <asp:Label ID="textRepHEducTax" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                                    Width="100px" ToolTip="HEdu Tax"></asp:Label>
                                            </td>--%>
                                <td width="100px" align="left">
                                    <asp:Label ID="textRepTaxAmount" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                        Width="100px" ToolTip="Tax Amount"></asp:Label>
                                </td>
                                <td width="100px" align="right">
                                    <asp:Label ID="textRepTotalAmount" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                        Width="100px" ToolTip="Total Amount"></asp:Label>
                                </td>
                                <%-- <td width="75px" align="left">
                                                <asp:Label ID="textRepWeiverReqAmt" runat="server" class="FormTextBoxNumeric" Font-Bold="true"
                                                    Width="75px" ToolTip="Weiver Request Amount"></asp:Label>
                                            </td>--%>
                            </tr>
                            </table></FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblInWords" CssClass="FormTextBoxLeft" Text="In Words :- " Font-Bold="true"
                        runat="server"></asp:Label>
                    <asp:Label ID="textInWords" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"></asp:Label>
                    <br />
                    <hr style="height: -2px" />
                </td>
            </tr>
        </table>
        </td> </tr> </table>
    </div>
    </form>
</body>
</html>
