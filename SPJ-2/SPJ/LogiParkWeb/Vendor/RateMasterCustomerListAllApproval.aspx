<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RateMasterCustomerListAllApproval.aspx.vb" Inherits="AdministratorUI_RateMasterCustomerListAll"
    Title="eLOGiPark :: Customer Rate List" Theme="Forms" %>

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
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Customer Rate List" CssClass="FormLabelTitle">
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
                                                    <asp:Label ID="lblrCustomer" runat="server" Text="Customer" Width="200px" CssClass="FormLabel"></asp:Label>
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
                                                                <asp:HyperLinkField DataTextField="Rate_CODE" DataNavigateUrlFormatString="CustomerRateMasterTptApproval.aspx?rateid={0}"
                                                                    ItemStyle-Width="130px" DataNavigateUrlFields="RATE_TPT_ID"></asp:HyperLinkField>
                                                                <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME"></asp:BoundField>
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
