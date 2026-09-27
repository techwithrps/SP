<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BedMaster.aspx.vb"
 Inherits="Fleet_BedMaster" Title="eLOGiFleet :: Bed Master"
    Theme="Forms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Trailer Master"
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
                                                   <asp:Label ID="lblBedNo" runat="server" Text="Bed No" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                               
                                                
                                                <asp:HiddenField ID="hdnBedId" runat="server" Value="" />
                                             
                                                <asp:TextBox ID="textBedNo" runat="server" MaxLength="5" onkeypress="kp_integer();" CssClass="textbox" Enabled="false"
                                                    ToolTip="Item">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
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
                                                        <td align="center">
                                                            <asp:Label ID="lblTireSrNo" Width="70px" Height="20PX" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Tire Sr No"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblInstallDate" Width="115px" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Installation Date"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblInstallLoc" Width="140px" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Installation Location"></asp:Label>
                                                        </td>
                                                        <td width="17px" style="background-color: White;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <div id="divTireDtls" runat="server" style="overflow: auto; height: 115px">
                                                                <asp:Repeater ID="repTireDtls" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table cellspacing="0" id="count">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Text='<%# Eval("TireNo") %>' Width="70px" ID="textTireNo"
                                                                                    runat="server" ToolTip="Tire Sr No" MaxLength="5"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hdnBedRefId" runat="server" Value='<%# Eval("BedRefId") %>' />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="110px" Text='<%# Eval("InstallationDate") %>'
                                                                                    ID="textInstallationDate" runat="server" ToolTip="Reading Date"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="textInstallationDate"
                                                                                    Format="dd/MM/yyyy">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstInstallationLoc" Text='<%# Eval("InstallLocation") %>' runat="server"
                                                                                    Width="130px" CssClass="FormListBoxMedium" ToolTip="Changeable Bed">
                                                                                    <asp:ListItem Text="-------Select-------" Value=""></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-I" Value="R1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-II-Inner" Value="R2I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-II-Outer" Value="R2O"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-III-Inner" Value="R3I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-III-Outer" Value="R3O"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-IV-Inner" Value="R4I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Right-IV-Outer" Value="R4O"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-I" Value="L1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-II-Inner" Value="L2I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-II-Outer" Value="L2O"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-III-Inner" Value="L3I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-III-Outer" Value="L3O"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-IV-Inner" Value="L4I"></asp:ListItem>
                                                                                    <asp:ListItem Text="Left-IV-Outer" Value="L4O"></asp:ListItem>
                                                                                </asp:DropDownList>
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
    <asp:GridView ID="gvBedDtls" runat="server">
    </asp:GridView>
    </div>
</asp:Content>

