<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/InventoryMaster.aspx.vb" Inherits="Fleet_InventoryMaster" Title="eLOGiFleet :: Inventory Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Inventory Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" Value="" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblItem" runat="server" Text="Item" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="lstItem" Width="120px" runat="server" CssClass="ddlMedium"
                                                    Enabled="false" ToolTip="Item">
                                                </asp:DropDownList>
                                                <span class="mandatory">*</span>
                                                <asp:HiddenField ID="hdnInvtId" runat="server" Value="" />
                                                <asp:Label ID="lblQnty" runat="server" Text="Qnty" CssClass="label"></asp:Label>
                                                <asp:TextBox ID="textQnty" runat="server" MaxLength="5" onkeypress="kp_integer();" Width="54px" CssClass="textbox" Enabled="false"
                                                    ToolTip="Item">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textUnitPrice" runat="server" MaxLength="6" onkeypress="kp_integer();" Width="58px" CssClass="textbox" Enabled="false"
                                                    ToolTip="Item">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                                <asp:Label ID="lblBuyingDate" runat="server" CssClass="label" Text="Buying Date"></asp:Label>&nbsp;
                                                <asp:TextBox ID="textBuyingDate" runat="server" onkeypress="kp_date();" Width="65px" MaxLength="12" CssClass="textbox"
                                                    ToolTip="Buying Date"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textBuyingDate"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblVendor" runat="server" Text="Vendor" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="lstVendor" runat="server" Width="228px" CssClass="ddlMedium"
                                                    Enabled="false" ToolTip="Vendor">
                                                </asp:DropDownList>
                                                <span class="mandatory">*</span>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRemarks" runat="server" CssClass="label" Text="Remarks"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRemarks" runat="server" Width="230px" Height="35px" TextMode="MultiLine" MaxLength="100" CssClass="textbox"
                                                    ToolTip="Remarks"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <table cellspacing="0">
                                                    <tr class="RepheaderNew">
                                                        <td align="center" width="100px" style="height:25px">
                                                            <asp:Label ID="lblrItemNo" Width="98px" runat="server" CssClass="labelHeader" Text="Item No"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblItemType" runat="server" CssClass="labelHeader" Width="93px" Text="Type"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrModel" Width="85px" runat="server" CssClass="labelHeader" Text="Model No"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrManufacture" Width="201px" runat="server" CssClass="labelHeader"
                                                                Text="Manufacture"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrBuyingDate" Width="67px" runat="server" CssClass="labelHeader"
                                                                Text="Date"></asp:Label>
                                                        </td>
                                                        <td width="17px" style="background-color: White;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" valign="top">
                                                            <div class="RepScroling" style="height: 240px;">
                                                                <asp:Repeater ID="rpItem" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="textItemNo" runat="server" Text='<%# Eval("ItemNo") %>' MaxLength="10"
                                                                                    CssClass="textbox" Width="90px">
                                                                                </asp:TextBox>
                                                                                <asp:HiddenField ID="hdnItemDtls" Value='<%# Eval("InventDtls") %>' runat="server" />
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textType" runat="server" Text='<%# Eval("ItemType") %>' MaxLength="10"
                                                                                    CssClass="textbox" Width="90px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textModel" runat="server" Text='<%# Eval("ModelNo") %>' MaxLength="15"
                                                                                    CssClass="textbox" Width="80px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstManufacturer" CssClass="ddlMedium" runat="server" ToolTip="Equipment Type"
                                                                                    Width="200px" text='<%# Eval("Manufacture") %>' OnDataBinding="prepareManufacturer">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textDate" runat="server" Text='<%# Eval("BuyingDate") %>' onkeypress="kp_date();"
                                                                                    CssClass="textbox" MaxLength="11" Width="65px">
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textDate"
                                                                                    Format="dd/MM/yyyy">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td style="vertical-align: top;">
                                <div id="RepScroling" class="RepScroling" style="height: 90%; width: 150px; border-left-color: Black;
                                    vertical-align: top;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                                  <asp:Button ID="btnExcel" runat="server" Text="Exil Download" CssClass="FormButton" />
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                               <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
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
     <div style="visibility:hidden">
    <asp:GridView ID="gvInventoryDtls" runat="server">
    </asp:GridView>
    </div>
</asp:Content>
