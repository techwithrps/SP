<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="InvoiceReport.aspx.vb" Inherits="Reports_Imports_InvoiceReport" Title="eLOGiFleet:: Invoice Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Invoice Report" CssClass="FormLabelTitle">
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
                        <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Document Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstDocumentType" runat="server" ToolTip="Document Type" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Domestic" Value="D"></asp:ListItem>
                                <asp:ListItem Text="Empty" Value="M"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Invoice Status" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstInvoiceStatus" runat="server" ToolTip="Document Type" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Generated" Value="G"></asp:ListItem>
                                <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                               
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
                        <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr" Width="30px"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:Label ID="lblrIGMNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrBookingDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo Date" Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrBillingParty" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Billing Party" Width="300px"></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label ID="lblrInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Date" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text=" Invoice Amount(INR)" Width="180px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrUserId" CssClass="FormLabel" runat="server" Font-Bold="True" Text="User ID" Width="100px"></asp:Label>
                            </td>

                            <td style="background-color: White; width: 15px;"></td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="JO_NO" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="JO_DATE" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="INVOICE_REF_NO" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="INVOICE_DATE" />
                                            <asp:BoundField ItemStyle-Width="180px" DataField="BILL_AMOUNT" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="720px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
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
