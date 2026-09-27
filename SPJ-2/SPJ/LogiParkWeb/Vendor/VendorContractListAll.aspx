<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="VendorContractListAll.aspx.vb" Inherits="Vendor_VendorContractListAll"
    Title="eLOGiPark :: Vendor Contract - Handling" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%">
        <tr>
            <td valign="top">
                <table style="width: 100%">
                    <tr>
                        <td valign="top" style="width: 400px;">
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Vendor Contract List All" CssClass="FormLabelTitle">
                            </asp:Label>
                        </td>
                        <td valign="top" style="width: 600px;">
                            <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblMandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table cellspacing="0" border="0" style="border-color: White;">
                                <tr style="width: 100%;">
                                    <td style="text-align: left">
                                        <asp:Label ID="lblTerminalName" runat="server" Text="Terminal " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstTerminalName" runat="server" ToolTip="Terminal Name" CssClass="FormListBoxMedium"
                                            Width="100">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px" rowspan="2">
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstVendorType" runat="server" AutoPostBack="true" ToolTip="Vendor Type"
                                            CssClass="FormListBoxMedium" Width="120">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10px" rowspan="2">
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblVendor" runat="server" Text="Vendor Name" CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="lstVendorName" runat="server" ToolTip="Vendor Name" CssClass="FormListBoxMedium"
                                                    Width="250">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="lstVendorType" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:HiddenField ID="hdnContractId" Value="0" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblContractCode" runat="server" Text="Rate Ref. Code " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textContractCode" onkeypress="kp_convert_upper()" runat="server"
                                            ToolTip="Rate Reference Code" CssClass="FormTextBoxMedium">
                                        </asp:TextBox>
                                        <asp:ImageButton ID="btnSearchContractCode" runat="server" Visible="false" ImageUrl="~/Images/brnAddtop.png"
                                            Width="30px" Height="20px" />
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblEffectiveFrom" runat="server" Text="Effective From " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textEffectiveFrom" runat="server" ToolTip="Effective From" CssClass="FormTextBoxDate">
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                            TargetControlID="textEffectiveFrom" />
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblEffectiveTo" runat="server" Text="Effective To " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textEffectiveTo" runat="server" ToolTip="Effective To" CssClass="FormTextBoxDate">
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                            TargetControlID="textEffectiveTo" />
                                    </td>
                                </tr>
                                <tr style="height: 20px;">
                                    <td colspan="">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellspacing="0" id="tblReport" runat="server">
                                <tr>
                                    <td>
                                        <table cellspacing="1" cellpadding="0">
                                            <tr style="text-align: center;" class="RepHead">
                                                <td>
                                                    <asp:Label ID="lblrContractCode" runat="server" Text="Contract Code" Width="160px"
                                                        CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrVendor" runat="server" Text="Vendor" Width="200px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrVendorType" runat="server" Text="Vendor" Width="130px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTerminal" runat="server" Text="Terminal" Width="200px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrFromDate" runat="server" Text="From Date" Width="80px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrToDate" runat="server" Text="To Date" Width="82px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="background-color: White; width: 17px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <div style="height: 270px; overflow: auto;">
                                                        <asp:GridView ID="gvVendorContractDetails" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                            <Columns>
                                                                <asp:HyperLinkField DataTextField="CONTRACT_CODE" DataNavigateUrlFormatString="VendorContract.aspx?ContractId={0}"
                                                                    ItemStyle-Width="160px" DataNavigateUrlFields="CONTRACT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="VENDOR_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="130px" DataField="VENDOR_TYPE_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="TERMINAL_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="80px" DataField="EFFECTIVE_FROM"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="80px" DataField="EFFECTIVE_TO"></asp:BoundField>
                                                            </Columns>
                                                            <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" style="vertical-align: bottom; height: 2px;">
        <tr>
            <td align="center" style="width: 80%">
                <asp:ImageButton ID="btnDisplay" runat="server" ImageUrl="~/Images/btnDisplay.png" />
                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" PostBackUrl="~/Home.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
