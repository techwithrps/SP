<%@ Page Title="eLOGiFleet:: Invoice Print" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="InvoicePrint.aspx.vb" Inherits="Commercial_InvoicePrint"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Invoice Print" CssClass="FormLabelTitle">
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
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" autocomplete="off" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" autocomplete="off" ToolTip="To Date" Width="90px" CssClass="textbox" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>

                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Service Type" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstServiceType" runat="server" CssClass="FormListBoxMedium"
                                Width="150px" ToolTip="Party">
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                <asp:ListItem Text="All" Value="A"></asp:ListItem>
                                <asp:ListItem Text="Transport" Value="T"></asp:ListItem>
                                <asp:ListItem Text="Clearence" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Freight" Value="F"></asp:ListItem>
                                 <asp:ListItem Text="Rebate" Value="R"></asp:ListItem>
                                 <asp:ListItem Text="Bill Of Supply" Value="O"></asp:ListItem>
                            </asp:DropDownList>


                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Visible="false" Text="Excel Download" CssClass="FormButton" />
                               <asp:Button ID="btnExport" Width="80px" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text=" Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew" td align="center" width="200px" style="height: 20px">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr"
                                    Width="31px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Invoice No" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Invoice Date" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBookingNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking No" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBookingDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking Date" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount"
                                    Width="60px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTaxAmount" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Tax Amount" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTotalAmount" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Total Amount" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Service Type" Width="100px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 450px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderText="Sr. No" />
                                            <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkInvoice" Width="120px" CommandArgument='<%# Eval("INVOICE_REF_NO" )%>'
                                                        Text='<%#Eval("INVOICE_REF_NO")%>' OnClick="OnClickHandlerStatus"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="INVOICE_DATE" HeaderText="Invoice Date" ></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="CONT_JO_NO" HeaderText="Cont Jo No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BOOKING_DATE" HeaderText="Booking Date" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="AMOUNT" HeaderText="Amount" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TAX_AMOUNT" HeaderText="Tax Amount" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_AMOUNT" HeaderText="Total Amount" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SERVICE_TYPE" HeaderText="Service Type" />
                                            <asp:TemplateField ItemStyle-Width="0px">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                    <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                    <asp:HiddenField ID="HdnServiceType" runat="server" Value='<%# Eval("SERVICE_TYPE") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
