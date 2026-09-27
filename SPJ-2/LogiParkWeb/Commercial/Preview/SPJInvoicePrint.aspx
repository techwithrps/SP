<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SPJInvoicePrint.aspx.vb"
    Inherits="Commercial_Preview_SPJInvoicePrint" Theme="Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: Invoice Print</title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
            font-size: smaller;
            font-style: normal;
        }
        
        .style1
        {
            height: 19px;
        }
    </style>
    <style type="text/css">
        .FormLabel
        {
            text-align: left;
        }
        
        .style1
        {
            text-align: left;
        }
        
        
        .FormTextBoxHead
        {
            text-align: left;
        }
        
        
        .style2
        {
            height: 25px;
        }
        
        .auto-style1
        {
            width: 43%;
        }
        
        .FormTextBoxLeft
        {
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <div align="center">
        <table width="100%">
            <tr>
                <td colspan="3">
                    <table border="0" width="100%">
                        <tr>
                            <td align="center" width="7%">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imglogo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCDtls" runat="server" Text="SPJ CARGO PVT.LTD." Font-Size="Large"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCompanyName1" CssClass="FormLabel" Text="International Freight Forwarders & Custom House Agent"
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblTerminaladdress0" CssClass="FormLabel" Text="D-9/3, Okhla Industrial Area Phase-1, New Delhi-110020"
                                                runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="textCompanyStateCode" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                                Text="State Code : 07, " Font-Bold="true"></asp:Label>
                                            <asp:Label ID="labGSTN" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="GSTIN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="labService" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="GSTIN: 07AAFPB3130K1Z5" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label1" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="," Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label26" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="PAN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label20" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="PAN NO: AAFPB3130K" Font-Size="Small"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCIN" CssClass="FormTextBoxLeft" runat="server" Text="CIN : U63013DL2003PTC121227"
                                                Font-Size="Small"></asp:Label>&nbsp;&nbsp;
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblEmail" CssClass="FormTextBoxLeft" runat="server" Text="Email: accounts@spjcargo.com"
                                                Font-Size="Small"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 13pt">
                    <b>TAX INVOICE</b>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" style="width: 50%;">
                    <%--style="border: 1px; border-color: Black; border-style: solid;"--%>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label12" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="To, "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <%-- <td align="left" width="145px">
                                <asp:Label ID="lblCustomerName" CssClass="FormTextBoxLeft" runat="server" Font-Size="Medium"
                                    Text="Customer Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" CssClass="FormTextBoxLeft" runat="server" Font-Size="Medium"
                                    Text=":"></asp:Label>
                            </td>--%>
                            <td align="left">
                                <asp:Label ID="lblCustomerName" Width="95%" Font-Bold="true" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <%--<td align="left" width="145px">
                                <asp:Label ID="lblCustAddress" CssClass="FormTextBoxLeft" runat="server" Font-Size="Medium"
                                    Text="Address"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" CssClass="FormTextBoxLeft" runat="server" Font-Size="Medium"
                                    Text=":"></asp:Label>
                            </td>--%>
                            <td align="left">
                                <asp:Label ID="lblcustomeradd" Width="400px" CssClass="FormTextBoxLeft" Height="100%"
                                    Font-Size="Small" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="textStateCode" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                    Text="State Code"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerState" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="textGSTIN" runat="server" Font-Size="Small" Text="GSTIN" CssClass="FormTextBoxLeft"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerGSTIN" CssClass="FormLabel" runat="server" Text="07HYSPT6767J98V"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblLine" Width="60px" CssClass="FormLabel" Text="Line" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textLine" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblBlNo" Width="60px" CssClass="FormLabel" Text="BL No" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textBlNo" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblGross" Width="60px" CssClass="FormLabel" Text="Gross Wt" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textGross" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPackages" Width="60px" CssClass="FormLabel" Text="Packages" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textPackages" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <%--  <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="LblPoNo" Width="60px" CssClass="FormLabel" Text="Party Invoice No." runat="server"></asp:Label>
                                </td>
                                <td align="left">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextPoNO" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="left">
                                    <asp:Label ID="LblPoDate" Width="60px" CssClass="FormLabel" Text="Party Invoice Date" runat="server"></asp:Label>
                                </td>
                                <td align="left">:
                                </td>
                                <td align="left">
                                    <asp:Label ID="TextPoDate" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                        <%--<tr>
                                <td align="left">
                                    <asp:Label ID="lblPartyInvoiceNo" Width="108px" CssClass="FormTextBoxLeft" Text="Party Inv No" runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:</td>
                                <td align="left">
                                    <asp:Label ID="textPartyInvoiceNo" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblPartyInvoiceDate" Width="97px" CssClass="FormTextBoxLeft" Text="Invoice Date" runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:</td>
                                <td align="left">
                                    <asp:Label ID="textPartyInvoiceDate" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                    </table>
                </td>
                <td style="width: 10px;">
                </td>
                <td align="left" valign="top" style="width: 50%;">
                    <%--style="border: 1px; border-color: Black; border-style: solid; vertical-align: top;"--%>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblConsignor" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Invoice No."></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textInvoiceNo" Font-Bold="true" Width="160px" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnAdvance" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblIDate" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Dated"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textInvoiceDate" Font-Bold="true" Width="110px" CssClass="FormLabel"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblJob" Width="60px" CssClass="FormLabel" Text="Job No" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextJob" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblMode" Width="60px" CssClass="FormLabel" Text="Mode Of Shipment"
                                    runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextOfMode" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPlaceOfSupply" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Place of Supply"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textPlaceOfSupply" runat="server" Font-Size="Small" CssClass="FormTextBoxLeft"
                                    Text="07-Delhi"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContSize" Width="60px" CssClass="FormLabel" Text="Size/Type" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textContSize" CssClass="FormLabel" runat="server" Text="40/RF"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                                <td align="left">
                                    <asp:Label ID="lblPOD" Width="60px" CssClass="FormTextBoxLeft" Text="POD" runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:</td>
                                <td align="left">
                                    <asp:Label ID="textPOD" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblBLNo" Width="60px" CssClass="FormTextBoxLeft" Text="B/L No" runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:</td>
                                <td align="left">
                                    <asp:Label ID="textBLNo" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblShippingLine" Width="60px" CssClass="FormTextBoxLeft" Text="S. Line" runat="server" Font-Size="Small"></asp:Label>
                                </td>
                                <td align="left">:</td>
                                <td align="left">
                                    <asp:Label ID="textShippingLine" CssClass="FormLabel" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblConsignee" Width="60px" CssClass="FormLabel" Text="Consignee" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textConsignee" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPort" Width="60px" CssClass="FormLabel" Text="POL" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textPort" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPOD" Width="60px" CssClass="FormLabel" Text="POD" runat="server"></asp:Label>
                            </td>
                            <td align="left">
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
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">
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
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <%--<tr>
                <td align="right" style="font-family: Calibri; font-size: 9pt">
                    Rail Freight Chg(Rs.Per MT) :
                </td>
                <td align="left">
                    <asp:Label ID="textRFPMT" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td align="right" style="font-family: Calibri; font-size: 9pt">
                    Handling Charges(Rs.Per MT) :
                </td>
                <td align="left">
                    <asp:Label ID="textHDPMT" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td align="right" style="font-family: Calibri; font-size: 9pt">
                    Transportation Charges(Rs.Per MT) :
                </td>
                <td align="left">
                    <asp:Label ID="textTPTPMT" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small" />
                </td>
            </tr>--%>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 5px;">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt">
                    <strong>MOVEMENT DETAILS</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 2px;">
                </td>
            </tr>
            <tr>
                <td valign="top" align="center" colspan="3">
                    <table cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <div>
                                    <asp:GridView ID="gvContainerDetail" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="38px" DataField="GR_NO" HeaderText="GR No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VEHICLE_NO" HeaderText="Vehicle No">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="125px" DataField="PO_NO" HeaderText="Party Inv No.">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="PO_DATE" HeaderText="DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="125px" DataField="SB_NO" HeaderText="Shipping Bill No.">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="PO_DATE" HeaderText="SB Date">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="75px" DataField="CONT_NO" HeaderText="Container No">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="ICD_OUT" HeaderText="ICD Out Date Time">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="ICD_IN" HeaderText="ICD In Date Time">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="HANDOVER_DATE" HeaderText="Handover Date">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="47px" DataField="DET_DAYS" HeaderText="Det Days">
                                            </asp:BoundField>
                                          <%--  <asp:BoundField ItemStyle-Width="47px" DataField="DET_AMT" HeaderText="Det Amt.">
                                            </asp:BoundField>--%>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt; height: 12px">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt; height: 12px">
                    <strong>SUMMARY OF CHARGES</strong>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    height: 2px;">
                </td>
            </tr>
            <tr>
                <td valign="top" align="center" colspan="3">
                    <table cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <div>
                                    <asp:GridView ID="gvPaymentDetail" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        ShowFooter="true">
                                        <RowStyle Font-Size="7pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.">
                                                <ItemStyle Width="35px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                    </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SERVICE" HeaderText="Service"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SERVICE_CODE" HeaderText="HSN/SAC">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="55px" DataField="QNTY" HeaderText="Qnty" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="55px" DataField="EX_RATE" HeaderText="Ex. Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CURRENCY" HeaderText="Curr."
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="BILL_RATE" HeaderText="Rate" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="AMOUNT" HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="C_RATE" HeaderText="CGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="HECESS" HeaderText="CGST Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="H_RATE" HeaderText="SGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="ECESS" HeaderText="SGST Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="S_RATE" HeaderText="IGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="SERVICE_TAX" HeaderText="IGST Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="TAX_AMOUNT" HeaderText="Tax Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="TOTAL_AMOUNT" HeaderText="Total Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                <table cellspacing="0" cellpadding="0">
                                    <tr align="right">
                                        <td width="350px" align="center">
                                        </td>
                                        <td width="50px" align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="10">
                                            <%--<asp:Label ID="lblInWords" CssClass="FormTextBoxLeft" Font-Size="X-Small" Text="In Words :- " Font-Bold="true" runat="server"></asp:Label>
                                                <asp:Label ID="textInWords" CssClass="FormTextBoxLeft" Font-Size="X-Small" Font-Bold="true" runat="server"></asp:Label>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <b>Amounts in Words : </b>
                    <asp:Label ID="lblAmountsInWords" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:Label ID="lblTerms" Text="Terms & Conditions" runat="server" Font-Size="Large"
                        Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    1. All Disputes Subject to the Delhi Jurisdiction.
                    <br />
                    <%--  <asp:Label ID="lblDDComapny" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label>           
                    <br />--%>
                    2. Interest @24% will be Charged If Bills are not paid within 10 Days of the Billing
                    date.
                    <br />
                    <%-- 3. GST on &quot;Road Transportation&quot; to be paid by Service Recipent under reverse
                    charge @ 5% amounting to Rs.
                    <br />--%>
                    3.Any Objection regarding the amount of the bill may please be intimated to us within
                    1 days from the date of Receipt of the Bill.
                    <%--<asp:Label ID="textTPTAmount" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label>--%>
                    <br />
                    <asp:Label ID="lblNote" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Invoice Note : "></asp:Label>
                    <asp:Label ID="txtInvoiceNote" Width="650px" CssClass="FormLabel" runat="server"
                        Font-Bold="true" Font-Italic="true" Font-Size="15"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2" class="auto-style1">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label25" runat="server" Text="Bank Details" Font-Size="Large" Font-Bold="true"></asp:Label>
                                <br />
                                <table>
                                    <tr>
                                        <td align="left" class="style2">
                                            <asp:Label ID="Label11" CssClass="FormTextBoxHead" runat="server" Text="SPJ CARGO PVT. LTD."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblAccountNo" runat="server" Text="AC"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LblIFSC" runat="server" Text="IFSC">
                                        </td>
                                        </asp:Label>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style2">
                                            <asp:Label ID="Label13" runat="server" Text="Bank Name.: -------  "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25px" align="left">
                                            <asp:Label ID="Label14" runat="server" Text="Branch.: ------- "></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center" style="font-size: 13pt;">
                    <asp:Label ID="lblSignComapny" runat="server" Font-Size="16" Style="font-weight: 700"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <b>Authorized Signatory</b>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td style="font-family: Verdana; font-size: 12px; text-align: left" colspan="3">
                    <p>
                        &nbsp;
                    </p>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnPDF" Text="ToPDF" runat="server" OnClick="btnPDF_Click" Visible="false" />
    <asp:Button ID="btnRTF" Text="ToRTF" runat="server" OnClick="btnRTF_Click" Visible="false" />
    </form>
</body>
</html>
