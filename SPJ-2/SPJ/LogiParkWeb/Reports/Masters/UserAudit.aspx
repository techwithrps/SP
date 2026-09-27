<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="UserAudit.aspx.vb" Inherits="Reports_Masters_UserAudit" Title="eLOGiPark :: User Audit Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="User Audit" CssClass="FormLabelTitle">
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
        <tr>
            <td colspan="3" align="left" valign="top">
            </td>
        </tr>
    </table>
    <table>
      
        <tr>
            <td align="left" valign="top">
                <div style="overflow: auto; height: 390px;">
                    <table id="Table1" cellspacing="0" cellpadding="0" runat="server">
                        <tr>
                            <td style="width: 100%">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepHead">
                            <td>
                                <table cellspacing="4" cellpadding="0" id="tblReport" runat="server">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="Sr. No" Width="40px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUserId" CssClass="FormLabel" runat="server" Font-Bold="True" Text="User ID"
                                                Width="100px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUserName" CssClass="FormLabel" runat="server" Font-Bold="true"
                                                Text="Uesr Name" Width="100px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUserType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="User Type" Width="80px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCompanyName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="Company Name" Width="150px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblLoginDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                                Text="Login Date" Width="130px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblLogoutdate" CssClass="FormLabel" runat="server" Font-Bold="true"
                                                Text="Logout date" Width="130px"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblLoginIP" CssClass="FormLabel" runat="server" Font-Bold="true" Text="IP Address"
                                                Width="130px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <asp:GridView ID="gvUserLogin" AutoGenerateColumns="false" runat="server" ShowHeader="false"
                                    AlternatingRowStyle-CssClass="FormListBoxLarg" RowStyle-CssClass="FormListBoxLarg">
                                    <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="38px" DataField=""></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="100px" DataField="USER_ID"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="100px" DataField="USER_NAME"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="80px" DataField="USER_TYPE"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="150px" DataField="COMPANY_NAME"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="130px" DataField="LOGIN_DATE"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="130px" DataField="LOGOUT_DATE"></asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="140px" DataField="IP_ADDRESS"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
