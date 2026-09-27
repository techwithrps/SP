<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="OnAccountReport.aspx.vb" Inherits="Reports_OnAccountReport" Title="eLOGiFleet:: On Account Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="On Account Report"
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
        <%--<tr>
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
                        <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPurchaseType" AutoPostBack="True" runat="server" ToolTip="Purchase Type"
                                Width="250px" CssClass="ddlMedium">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                <asp:ListItem Text="Clearing & Forwarding" Value="C"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer Name" Width="200px"
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
        </tr>--%>
        <tr>
            <td>
                <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table cellspacing="1" id="tblReport" runat="server">
                    <tr>
                        <td colspan="9">
                            <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <div style="height: 400px; overflow: auto;">
                                <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" HeaderStyle-CssClass="RepheaderNew"
                                    runat="server">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr No" />
                                        <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME" HeaderText="Customer" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="INSTRUMENT_NO" HeaderText="UTR/Cheque No" />
                                        <asp:BoundField ItemStyle-Width="100px" DataField="INSTRUMENT_DATE" HeaderText="UTR/Cheque Date"
                                            ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField ItemStyle-Width="150px" DataField="RECEIPT_REF_NO" HeaderText="Receipt No" />
                                        <asp:BoundField ItemStyle-Width="100px" DataField="RECEIPT_DATE" HeaderText="Receipt Date"
                                            ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField ItemStyle-Width="100px" DataField="BAL_AMOUNT" HeaderText="Balance Amount"
                                            ItemStyle-HorizontalAlign="Right" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
