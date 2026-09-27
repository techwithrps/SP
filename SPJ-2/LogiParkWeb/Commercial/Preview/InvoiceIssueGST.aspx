<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InvoiceIssueGST.aspx.vb"
    Inherits="Commercial_Preview_InvoiceReceiptGST" Theme="Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Receipt Print</title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
            font-size: xx-small;
            font-style: normal;
        }
        
        .FormTextBoxLeft
        {
        }
        
        .auto-style1
        {
            width: 61px;
        }
        
        .auto-style3
        {
            width: 2px;
        }
    </style>
</head>
<body runat="server" id="myBody">
    <form id="form1" runat="server">
    <div id="wholepage">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2" align="center" style="text-decoration: underline; font-family: Calibri;
                                font-size: 11pt">
                                <b>Payment Issue Voucher</b>
                                <br />
                                <%--    [See Rule 5 under Tax Invoice, Credit and Debit Note Rules] --%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="imglogo" runat="server" ImageUrl="~/Images/logo.png" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCDtls" runat="server" Text="JSB CARGO MOVERS PRIVATE LIMITED" Font-Size="11pt"
                                                Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Size="11pt" Text="PAN : "></asp:Label>
                                            <asp:Label ID="lblpangst" runat="server" Font-Size="11pt" Text="PAN"></asp:Label>
                                            <asp:Label ID="Label15" runat="server" Font-Size="11pt" Text=", GSTIN : "></asp:Label>
                                            <asp:Label ID="lblGSTIN" runat="server" Font-Size="11pt" Text="GSTIN"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblCmAdress" runat="server" Font-Size="11pt" Text="Regd. Office : Grond Floor, 61, Durga Park,Dallupura, Delhi-110096 </br> Admin Occice : Room No-02, 636, Sector-1, Vaishali, Ghaziabad (U.P.) </br>Tel/Fax NO.: +91-120-4263512,0120-4263513"></asp:Label>&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
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
                <td valign="top" colspan="2">
                    <table width="100%" frame="box">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="lblVoucherNo" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                                Text="Voucher No."></asp:Label>
                                        </td>
                                        <td align="left" class="auto-style3">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textVoucherNo" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                                Font-Size="X-Small"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td align="left" class="auto-style1">
                                            <asp:Label ID="lblIDate" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                                Text="Date"></asp:Label>
                                        </td>
                                        <td align="left" class="auto-style3">
                                            :
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="textVoucherDate" Font-Bold="true" CssClass="FormTextBoxLeft" runat="server"
                                                Font-Size="X-Small"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
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
                <td align="center" style="text-decoration: underline; font-family: Calibri; font-size: 11pt"
                    colspan="2">
                    Details of Party (Paid to)
                </td>
            </tr>
            <tr>
                <td align="left" style="width: 50%; vertical-align: top;">
                    <%--style="border: 1px; border-color: Black; border-style: solid;"--%>
                    <table frame="box" style="width: 100%;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label4" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="textCustomerName" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label23" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Address"></asp:Label>
                            </td>
                            <td>
                                :
                            </td>
                            <td align="left">
                                <asp:Label ID="textAddress" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Level-4, Rectangle-1,Commercial Complex D-4, Saket, New Delhi-110 017, Corp. Office. 11th Floor, DLF Tower 9-B, DLF Cyber City, Phase - III, Sector 25A, Gurgaon, Haryana - 122002"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblSState" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="State"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label12" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="TextSState" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblSsCode" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="State Code"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="TextSScode" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblSGstIn" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="GSTIN/UIN"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label24" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="TextSGstInNo" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"></asp:Label>
                                <asp:HiddenField ID="hdnServiceMode" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" style="width: 50%; vertical-align: top;">
                    <%--style="border: 1px; border-color: Black; border-style: solid;"--%>
                    <table frame="box" style="width: 100%;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Payment Issue Mode"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtPaymentMode" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label9" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Receiver Bank"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label11" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtReceiverBank" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblChequeno" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Cheque No./Instrument No."></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtChequeNo" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label6" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Instrument Date"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtInstrumentDate" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label3" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text="Paid Amount"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" CssClass="FormTextBoxLeft" runat="server" Font-Size="X-Small"
                                    Text=":"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtReceivedAmount" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"
                                    Font-Size="X-Small"></asp:Label>
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
                <td valign="top" colspan="2">
                    <table cellspacing="0" cellpadding="0" style="height: 300px; width: 100%">
                        <tr>
                            <td valign="top" align="center" style="width: 100%">
                                <div style="width: 100%">
                                    <asp:GridView ID="gvPaymentDetail" Font-Size="8pt" ShowFooter="true" AutoGenerateColumns="False"
                                        runat="server">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="S" HeaderText="Sale Payment Status"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                                 <asp:BoundField ItemStyle-Width="150px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BL_NO" HeaderText="BL No" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_NO" HeaderText="Invoice No"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_DATE" HeaderText="Invoice Date"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <%-- <asp:BoundField ItemStyle-Width="50px" DataField="SERVICE_CODE" HeaderText="HSN/SAC" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>--%>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_AMOUNT" HeaderText="Invoice Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="DR_AMT" HeaderText="Dr Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TDS" HeaderText="TDS Amount" ItemStyle-HorizontalAlign="Right"
                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TA" HeaderText="Issue Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CGST_RATE" HeaderText="CGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CGST_AMOUNT" HeaderText="CGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SGST_RATE" HeaderText="SGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SGST_AMOUNT" HeaderText="SGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="IGST_RATE" HeaderText="IGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="IGST_AMOUNT" HeaderText="IGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BASIC_AMOUNT" Visible="false"
                                                HeaderText="Amount" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <table cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="height: 20px; vertical-align: bottom;">
                                            <br />
                                            <asp:Label ID="lblInWords" CssClass="FormTextBoxLeft" Text="Amount Paid In Words :- "
                                                runat="server" Font-Size="X-Small"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:Label ID="textInWords" CssClass="FormTextBoxLeft" Font-Size="Small" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; vertical-align: bottom;">
                                            <br />
                                            <asp:Label ID="LblNote" CssClass="FormTextBoxLeft" Text="NOTE :- " runat="server"
                                                Font-Size="X-Small"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:Label ID="TxtNote" CssClass="FormTextBoxLeft" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 130px;" colspan="2">
                    <table style="width: 70%; height: 100%;">
                        <tr>
                            <td style="font-size: 10pt; text-align: right; vertical-align: top;">
                                <b style="text-align: center;">Authorized Signatory</b>
                                <br />
                                Name:
                                <br />
                                Designation:
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
