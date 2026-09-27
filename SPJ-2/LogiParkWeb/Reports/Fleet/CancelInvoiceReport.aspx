<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CancelInvoiceReport.aspx.vb" Inherits="Reports_Fleet_CancelInvoiceReport"
    Title="eLOGiFleet:: Cancel Invoice Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Invoice Report"
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
                            <asp:TextBox ID="textFromDate" AutoComplete="off" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" AutoComplete="off" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" runat="server" ToolTip="Customer Name" Width="250px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
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
                            <td colspan="9">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server"
                                        HeaderStyle-CssClass="RepheaderNew">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="20px" DataField="" HeaderText="Sr.No." HeaderStyle-Height="22px" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_JO_NO" HeaderText="Job No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="JO_DATE" HeaderText="Job Date" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" />
                                            <asp:HyperLinkField DataTextField="INVOICE_REF_NO" DataNavigateUrlFormatString="Preview/CancelExportInvoicePrint.aspx?ClInvoiceID={0}"
                                                ItemStyle-Width="112px" DataNavigateUrlFields="CL_INVOICE_ID" HeaderStyle-CssClass="RepheaderNew"
                                                HeaderText="Invoice Ref No"></asp:HyperLinkField>
                                            <asp:BoundField ItemStyle-Width="110px" DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="BILL_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Bill Amount" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CANCEL_BY" HeaderText="Cancel By" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CANCEL_ON" HeaderText="Cancel Date" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CANCEL_NOTE" HeaderText="Cancel Note" />
                                            <asp:TemplateField ItemStyle-Width="0px">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                    <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="720px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Width="70px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
