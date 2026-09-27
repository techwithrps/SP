<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RateMasterVendorListAll.aspx.vb" Inherits="AdministratorUI_RateMasterVendorListAll"
    Title="eLOGiPark :: Vendor Rate List" Theme="Forms" %>

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
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Vendor Rate List" CssClass="FormLabelTitle">
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
                            <table>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblRateCode" runat="server" Text="Rate Ref. Code " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textRateCode" onkeypress="kp_convert_upper()" runat="server" ToolTip="Rate Ref. Code"
                                            CssClass="FormTextBoxMedium" Width="250">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblServiceName" runat="server" Text="Service Name " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstServiceName" runat="server" ToolTip="Service Name" CssClass="FormListBoxMedium"
                                            Width="254">
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="hdnRateId" Value="0" runat="server" />
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblBillingCondition" runat="server" Text="Billing Condition " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstBillingCondition" runat="server" ToolTip="Billing Condition"
                                            CssClass="FormListBoxMedium" Width="180">
                                            <asp:ListItem Value="1" Text="Container Gross Weight" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Container Net Weight"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Article Based"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Per Tone"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Non Revenue"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Wagon Gross Weight"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Wagon Net Weight"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblVendorName" runat="server" Text="Vendor Name " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstVendorName" runat="server" ToolTip="Vendor Name" CssClass="FormListBoxMedium">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblEffectiveFrom" runat="server" Text="Effective From " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textEffectiveFrom" runat="server" ToolTip="Customer Type" CssClass="FormTextBoxDate">
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                            TargetControlID="textEffectiveFrom" />
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label2" runat="server" Text="Effective To " CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textEffectiveTo" runat="server" ToolTip="Effective To" CssClass="FormTextBoxDate">
                                        </asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                            TargetControlID="textEffectiveTo" />
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
                                                    <asp:Label ID="lblrRateId" runat="server" Text="Rate Code" Width="130px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrVendor" runat="server" Text="Vendor" Width="200px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTerminal" runat="server" Text="Terminal" Width="100px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrFromDate" runat="server" Text="From Date" Width="90px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrToDate" runat="server" Text="To Date" Width="90px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblrBillCondition" runat="server" Text="Bill Condition" Width="200px"
                                                        CssClass="FormLabel"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="7">
                                                    <div style="height: 270px; overflow: auto;">
                                                        <asp:GridView ID="gvTrainSummary" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                            RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                                            <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                                            <Columns>
                                                                <asp:HyperLinkField DataTextField="Rate_CODE" DataNavigateUrlFormatString="RateMasterTpt.aspx?rateid={0}"
                                                                    ItemStyle-Width="130px" DataNavigateUrlFields="RATE_TPT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="VENDOR_NAME"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="100px" DataField="TERMINAL_CODE"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="90px" DataField="EFFECTIVE_FROM"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="90px" DataField="EFFECTIVE_TO"></asp:BoundField>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="BILLING_CONDITION"></asp:BoundField>
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
