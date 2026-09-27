<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CrPrint.aspx.vb" Inherits="Commercial_Preview_CrPrint"
    Theme="Print" %>

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
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" width="25%">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imglogo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="center" width="100%">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCDtls" runat="server" Text="JSB CONSULTANTS" Font-Size="Large"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblTerminaladdress0" CssClass="FormLabel" Text="Regd. Office : First Floor, 61, Durga Park, Delhi-110096 </br> Admin Occice : Room No-01, 363, Sector-1, Vaishali, Ghaziabad (U.P.) </br> Tel/Fax : +91-120-4263512,0120-463513"
                                                runat="server"></asp:Label>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="textCompanyStateCode" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                                Text="State Code : 07, " Font-Bold="true"></asp:Label>
                                            <asp:Label ID="labGSTN" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="GSTIN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="labService" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="GSTIN: 07AAFDB9585R1Z5" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label1" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="," Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label26" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="PAN:" Font-Size="Small"></asp:Label>
                                            <asp:Label ID="Label20" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Text="PAN NO: AAFDB9585R" Font-Size="Small"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCIN" CssClass="FormTextBoxLeft" runat="server" Text="CIN : test"
                                                Font-Size="Small"></asp:Label>&nbsp;&nbsp;
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblURL" CssClass="FormTextBoxLeft" Font-Underline="true" runat="server"
                                                Text="http://www.spjcargo.com" Font-Size="Small"></asp:Label>
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
                    font-size: 11pt">
                    <b>CREDIT NOTE</b>
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
                                <asp:Label ID="lblAc" Width="60px" CssClass="FormLabel" Text="A/C" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textAccount" CssClass="FormLabel" runat="server"></asp:Label>
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
                                <asp:Label ID="LblCrNO" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="CR No."></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextCrNo" Font-Bold="true" Width="160px" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCrDate" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="CR. Date"></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="TextCrDate" Font-Bold="true" Width="110px" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblConsignor" CssClass="FormTextBoxLeft" runat="server" Font-Size="Small"
                                    Text="Agst. Invoice No."></asp:Label>
                            </td>
                            <td align="left">
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textInvoiceNo" Font-Bold="true" Width="160px" CssClass="FormLabel"
                                    runat="server"></asp:Label>
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
                    font-size: 11pt; height: 12px">
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center" style="text-decoration: underline; font-family: Calibri;
                    font-size: 11pt; height: 12px">
                    <strong>SUMMARY OF CREDIT</strong>
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
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                    </asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="300px" DataField="SERVICE" HeaderText="Service">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SERVICE_CODE" HeaderText="HSN/SAC">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="55px" DataField="QNTY" HeaderText="Qnty" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="BILL_RATE" HeaderText="Rate" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="AMOUNT" HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="C_RATE" HeaderText="CGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="HECESS" HeaderText="CGST Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="H_RATE" HeaderText="SGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="ECESS" HeaderText="SGST Amount"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="105px" DataField="S_RATE" HeaderText="IGST Rate"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="SERVICE_TAX" HeaderText="IGST Amount"
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
                <td colspan="3" align="left">
                    <asp:Label ID="lblTerms" Text="Terms & Conditions" runat="server" Font-Size="Large"
                        Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    1. Consignor/Consignee will be responsible for paying GST applicable from 1-July-2017.
                    <br />
                    2. Cheques/DD should be drawn in favour of <b>
                        <asp:Label ID="lblDDComapny" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label></b>,
                    payable at New Delhi.
                    <br />
                    3. Any discrepancies in the bill should be brought to the notice of the company
                    within 2 week of bill date.
                    <br />
                    4. GST on &quot;Road Transportation&quot; to be paid by Service Recipent under reverse
                    charge @ 5% amounting to Rs.
                    <asp:Label ID="textTPTAmount" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:Label ID="lblNote" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Note : " Font-Italic="true" Font-Size="15"></asp:Label>
                    <asp:Label ID="txtInvoiceNote" Width="650px" CssClass="FormLabel" runat="server" Font-Bold="true" Font-Italic="true" Font-Size="15"></asp:Label>
                </td>
            </tr>
            
            <%--<tr>
                <td colspan="3" align="left">
                    <asp:Label ID="lblTerms" Text="Terms & Conditions" runat="server" Font-Size="Large"
                        Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    1. Consignor/Consignee will be responsible for paying service tax as per not FN.NO.30/2012
                    dated 20/06/2012.
                    <br />
                    2. Cheques/DD should be drawn in favour of <b>
                        <asp:Label ID="lblDDComapny" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label></b>,
                    payable at New Delhi.
                    <br />
                    3. Any discrepancies in the bill should be brought to the notice of the company
                    within 2 week of bill date.
                    <br />
                    4. GST on &quot;Road Transportation&quot; to be paid by Service Recipent under reverse
                    charge @ 5% amounting to Rs.
                    <asp:Label ID="textTPTAmount" runat="server" Font-Size="Small" Style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:Label ID="lblNote" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Invoice Note : "></asp:Label>
                    <asp:Label ID="txtInvoiceNote" Width="650px" CssClass="FormLabel" runat="server"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td align="left" valign="top" colspan="2" class="auto-style1">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label25" runat="server" Text="RTGS Details" Font-Size="Large" Font-Bold="true"></asp:Label>
                                <br />
                                <table>
                                    <tr>
                                        <td align="left" class="style2">
                                            <asp:Label ID="Label11" CssClass="FormTextBoxHead" runat="server" Text="JSB CONSULTANTS"></asp:Label>
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
