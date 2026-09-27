<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/BreakVan.aspx.vb" Inherits="Master_Admin_BreakVan" Title="eLOGiRail :: Brake Van Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Brake Van Master" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <hr />
            </td>
        </tr>
    </table>
    <table style="width: 100%; margin-right: 0px;">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="width: 100%; vertical-align: middle; vertical-align: top">
                            <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                <table width="100%">
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblBreakVanNo" runat="server" Text="Brake Van No " CssClass="FormLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="textBreakVanNo" runat="server" ToolTip="Brake Van No" CssClass="FormTextBoxMedium"
                                                Width="100" MaxLength="11" onkeypress="kp_convert_upper()">
                                            </asp:TextBox>
                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                            <asp:HiddenField ID="hdnBreakVanId" runat="server" Value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblBreakVanOwner" runat="server" Text="Owner" CssClass="FormLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="lstOwner" runat="server" CssClass="FormListBoxMedium" Width="150"
                                                ToolTip="Owner">
                                            </asp:DropDownList>
                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div id="dvTreeView" style="height: 365px; width: 300px; overflow: auto;">
                                <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                    Width="144px">
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" style="vertical-align: bottom;">
        <tr>
            <td style="width: 120px" align="left">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
            <td align="center" style="width: 80%">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
               <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
            </td>
            <td style="width: 120" align="left">
                <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
