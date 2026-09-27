<%@ Page Title="eLOGiFleet::Vehicle Excel Master" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="EquipmentTypeMaster.aspx.vb" Inherits="Master_EquipmentTypeMaster"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

</script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="250px" Text="Vehicle Model Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="FormLabelTitleHr"></td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table cellpadding="0" style="border-style: none;">
                                        <tr style="height: 10px;">
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblEquipmentCode" runat="server" Text="Equipment Code " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:TextBox ID="TextEquipmentCode" runat="server" ToolTip="Equipment Type" Width="100px"
                                                    CssClass="FormTextBoxMediumMandatory" MaxLength="15">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblEquipmenyName" runat="server" Text="Equipment Name " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:TextBox ID="textEquipmenyName" Width="200px" runat="server" ToolTip="Equipment Name"
                                                    CssClass="FormTextBoxMediumMandatory" MaxLength="25">
                                                </asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnTaxHeadID" runat="server" Value="" />
                                            </td>
                                            <td colspan="6">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="dvTreeView" class="RepScroling" style="height: 90%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" Visible="false" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" Visible="false" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" Visible="false" runat="server" Text="Save" CssClass="FormButton" />
                                                <asp:Button ID="btnCancel" Visible="false" runat="server" Text="Cancel" CssClass="FormButton" />
                                                <asp:Button ID="btnExit" Visible="false" runat="server" Text="Exit" CssClass="FormButton" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
