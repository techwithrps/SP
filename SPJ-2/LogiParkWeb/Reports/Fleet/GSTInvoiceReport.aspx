<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="GSTInvoiceReport.aspx.vb" Inherits="Reports_Imports_GSTInvoiceReport"
    Title="eLOGiFleet:: GST Invoice Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="GST Invoice Report" Width="400px"
                    CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <hr />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 390px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="11">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="12">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server"  HeaderStyle-CssClass="RepHead">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr. No" HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                                   <asp:BoundField ItemStyle-Width="300px" DataField="GSTN" HeaderText="GSTN No"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNewHai">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkInvoice" Width="120px" CommandArgument='<%# Eval("INVOICE_REF_NO" )%>'
                                                        Text='<%#Eval("INVOICE_REF_NO")%>' OnClick="OnClickHandlerStatus"></asp:LinkButton>
                                                </ItemTemplate>

                                            </asp:TemplateField>  
                                               <asp:TemplateField HeaderText="Cr Ref No" HeaderStyle-CssClass="RepheaderNewHai">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkCRInvoice" Width="120px" CommandArgument='<%# Eval("CR_REF_NO")%>'
                                                        Text='<%#Eval("CR_REF_NO")%>' OnClick="OnClickHandlerStatusCR"></asp:LinkButton>
                                                </ItemTemplate>

                                            </asp:TemplateField>   
                                             
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_DATE" HeaderText="Invoice Date"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="SERVICE_TYPE" HeaderText="Service Type"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BILL_QNTY" HeaderText="Ex Rate"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="AMOUNT" HeaderText="Amount" HeaderStyle-CssClass="RepheaderNewHai" />
                                          
                                            <asp:BoundField ItemStyle-Width="50px" DataField="IGST" HeaderText="IGST" HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CGST" HeaderText="CGST" HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="SGST" HeaderText="SGST" HeaderStyle-CssClass="RepheaderNewHai" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_AMOUNT" HeaderText="Total"
                                                HeaderStyle-CssClass="RepheaderNewHai" />
                                              <asp:BoundField ItemStyle-Width="120px" DataField="ACK_NO" HeaderText="Ack No" HeaderStyle-CssClass="RepheaderNewHai"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="ACK_DT" HeaderText="Ack Date" HeaderStyle-CssClass="RepheaderNewHai"></asp:BoundField>
                                             <asp:BoundField ItemStyle-Width="120px" DataField="IRN" HeaderText="Inr No" HeaderStyle-CssClass="RepheaderNewHai" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="SIGNED_QR_CODE" HeaderText="QR Code" HeaderStyle-CssClass="RepheaderNewHai" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                     
                                                  <asp:TemplateField ItemStyle-Width="0px">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                    <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="750px" CssClass="FormLabel" Visible="false"></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel"
                                    Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Width="70px" CssClass="FormLabel" Visible="false"></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
