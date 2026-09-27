<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="GSTInvoiceReport.aspx.vb" Inherits="Reports_Imports_GSTInvoiceReport" Title="eLOGiFleet:: GST Invoice Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="GST Invoice Report" CssClass="FormLabelTitle">
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
                            <asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
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
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="10">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" Font-Size="8pt" AutoGenerateColumns="False" runat="server" AlternatingRowStyle-CssClass="FormLabel">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="Repheader">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="130" DataField="INVOICE_REF_NO" HeaderText="Invoice No" HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_DATE" HeaderText="Invoice Date" HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="AMOUNT" HeaderText="Amount" HeaderStyle-CssClass="Repheader" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="IGST" HeaderText="IGST" HeaderStyle-CssClass="Repheader" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CGST" HeaderText="CGST" HeaderStyle-CssClass="Repheader" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SGST" HeaderText="SGST" HeaderStyle-CssClass="Repheader" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="INVOICE_AMOUNT" HeaderText="Total Amount" HeaderStyle-CssClass="Repheader" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>

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
