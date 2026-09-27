<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/RouteStationDetails.aspx.vb" Inherits="Master_Admin_RouteStationDetails" Theme="Forms"
    Title="eLOGiRail :: Route Station Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/validation.js">

    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Route Station Details" class="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
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
    <table style="width: 100%; margin-right: 0px; height: 159px;">
        <tr>
            <td width="100%">
                <table>
                    <tr>
                        <td style="vertical-align: top; width: 100%; height: 360px;">
                            <div id="dvMain" runat="server" style="width: 100%; vertical-align: top;">
                                <table align="center">
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblRouteName" runat="server" class="FormLabel" Text="Route Name"></asp:Label>
                                        </td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:HiddenField ID="hdnRouteRefID" runat="server" Value="0" />
                                            <asp:DropDownList ID="lstRouteName" runat="server" AutoPostBack="true" class="FormTListBoxSmall"
                                                Width="100px" ToolTip="Route Name">
                                            </asp:DropDownList>
                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblOrigin" runat="server" Text="Origin" Class="FormLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="textOrigin" runat="server" class="FormTextBoxMedium" Width="100px"
                                                        ToolTip="Origin">
                                                        
                                                    </asp:TextBox>
                                                    <asp:HiddenField ID="hdnOrigin" runat="server" Value="0" />
                                                      <asp:HiddenField ID="hdnMode" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hdnDestination" runat="server" Value="0" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="lstRouteName" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblDestination" runat="server" Text="Destination" Class="FormLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="textDestination" runat="server" class="FormTextBoxMedium" Width="100px"
                                                        ToolTip="Destination"></asp:TextBox>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="lstRouteName" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" valign="top" align="center">
                                            <table>
                                                <tr class="Repheader">
                                                    <td style="width: 110px">
                                                        <strong>Station Code</strong> <span class="mandatory">*</span>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <strong>Distance From Origin</strong>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 265px; overflow: auto; width: 240px">
                                                <asp:Repeater ID="repStationMaster" runat="server">
                                                    <HeaderTemplate>
                                                        <table id="cont" cellspacing="0">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:HiddenField ID="hdnStationRefId" Value='<%# Eval("StationRefId") %>' runat="server" />
                                                                <asp:TextBox class="FormTextBoxLarg" Width="100px" ID="textStationCode" runat="server"
                                                                    Text='<%# Eval("StationCode") %>' ToolTip="Station Code" MaxLength="5" onkeypress="kp_convert_upper();"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox class="FormTextBoxLarg" Width="80px" ID="textDistance" runat="server"
                                                                    Text='<%# Eval("DistanceOrigin") %>' ToolTip="Distance" MaxLength="5" onkeypress="kp_numeric();"></asp:TextBox>
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
                            </div>
                        </td>
                        <td>
                            <div id="dvTreeView" style="height: 365px; width: 300px; overflow: auto; vertical-align:top;">
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
    <table width="100%">
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
                <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
