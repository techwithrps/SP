<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetLocationMaster.aspx.vb" Inherits="FLeet_FleetLocationMaster"
    Title="eLOGiFleet :: Location Master" Theme="Forms" EnableEventValidation="false" %>

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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Location Master"
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
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none; width:100%">
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblTerminal" runat="server" CssClass="label" Text="Terminal ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstTerminal" runat="server" CssClass="ddlMedium" ToolTip="Terminal Name"
                                                    Width="250px" Style="margin-left: 0px">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnTerminalID" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" align="center">
                                        <tr>
                                            <td>
                                                <table cellspacing="0" align="center">
                                                    <tr class="RepHeadFleet">
                                                        <td align="center">
                                                            <asp:Label ID="lblLocation" Width="200px" runat="server" CssClass="labelHeader" Text='Location<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblDistance" Width="105px" runat="server" CssClass="labelHeader" Text='Distance (Km)<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblToll" Width="80px" runat="server" CssClass="labelHeader" Text="Toll (Rs.)"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblAdvance" Width="80px" runat="server" CssClass="labelHeader" Text="20' Eicher"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblOilAdvance" Width="80px" runat="server" CssClass="labelHeader" Text="20 AL'"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblALadvance" Width="100px" runat="server" CssClass="labelHeader" Text="40' AL"></asp:Label>
                                                        </td>
                                                        <td style="width: 12px; background-color: White;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 260px;">
                                                                <asp:Repeater ID="repLocation" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="Location" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnLocationRefId" Value='<%# Eval("LocationRefId") %>'  runat="server"/>
                                                                                <asp:TextBox class="Rpttextbox" ID="textLocation" runat="server" Enabled="false"
                                                                                    onkeypress="kp_convert_upper();" MaxLength="60" Text='<%# Eval("LocationName") %>'
                                                                                    Width="200px" ToolTip="Location">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textDistance" runat="server" Enabled="false"
                                                                                    onkeypress="kp_numeric();" MaxLength="10" Text='<%# Eval("Distance") %>' Width="105px"
                                                                                    ToolTip="Distance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textToll" runat="server" Enabled="false"
                                                                                    onkeypress="kp_numeric();" MaxLength="10" Text='<%# Eval("Toll") %>' Width="80px"
                                                                                    ToolTip="Distance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("AdvanceRs") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textOilAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("OilAdvance") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                             <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textALAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("AlAdvance") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table></FooterTemplate>
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
                                <div id="RepScroling" class="RepScroling" style="height: 90%; width: 300px; border-left-color: Black;
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
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
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
    <asp:GridView ID="gvLocationDtls" runat="server">
    </asp:GridView>
    </div>
</asp:Content>
