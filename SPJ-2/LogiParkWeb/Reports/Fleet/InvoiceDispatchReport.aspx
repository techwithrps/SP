<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="InvoiceDispatchReport.aspx.vb" Inherits="Reports_Fleet_InvoiceDispatchReport" Title="eLOGiFleet:: Invoice Dispatch Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Invoice Dispatch Report" Width="400px" CssClass="FormLabelTitle">
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
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
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
                            <td colspan="11">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11">
                                <div style="height: 450px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" ShowFooter="true" AlternatingRowStyle-CssClass="FormListBoxLarg" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr. No"  HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PARTY_INV_NO" HeaderText="INVOCIE NO" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="CONTAINER NO" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="PORT" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" HeaderText="BL NO" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="FRT_INVOICE" HeaderText="FRT INV NO." HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" DataField="FRT_AMT" HeaderText="AMT" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="TPT_INVOICE" HeaderText="TPT INV NO." HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" DataField="TPT_AMT" HeaderText="AMT" HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CLR_INVOICE" HeaderText="CLR INV NO." HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right" DataField="CLR_AMT" HeaderText="AMT" HeaderStyle-CssClass="RepheaderNew"/>
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
