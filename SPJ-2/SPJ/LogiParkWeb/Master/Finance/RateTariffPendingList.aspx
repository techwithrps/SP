<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RateTariffPendingList.aspx.vb" Inherits="Master_Finance_RateTariffPendingList"
    Title="eLOGiFleet :: Rate Tariff Approval Pending List" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="Rate Tariff Approval Pending List"
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
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" cellpadding="0" id="tblReport" runat="server">
                        <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrRateId" CssClass="FormLabel" runat="server" Text="Rate ID" Width="35px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrFromDate" CssClass="FormLabel" runat="server" Text="From Date"
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrToDate" CssClass="FormLabel" runat="server" Text="To Date" Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCustomer" CssClass="FormLabel" runat="server" Text="Customer"
                                    Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCustomerype" CssClass="FormLabel" runat="server" Text="Type" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrService" CssClass="FormLabel" runat="server" Text="Service" Width="250px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCreatedBy" runat="server" CssClass="FormLabel" Text="Created By"
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCratedOn" CssClass="FormLabel" runat="server" Text="Created On"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrRemarks" CssClass="FormLabel" runat="server" Text="Remarks" Width="200px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <div>
                                    <asp:GridView ID="gvRateApprovalList" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:HyperLinkField DataTextField="RATE_ID" DataNavigateUrlFormatString="RateTariffApproval.aspx?rateid={0}"
                                                ItemStyle-Width="30px" DataNavigateUrlFields="RATE_ID"></asp:HyperLinkField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="FROM_DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TO_DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER_NAME"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CUSTOMER_TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="SERVICE_NAME"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CREATED_BY"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CREATED_ON"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="REMARKS"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
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
