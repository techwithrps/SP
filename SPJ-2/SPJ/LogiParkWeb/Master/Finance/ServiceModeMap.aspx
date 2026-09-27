<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" CodeFile="~/Master/Finance/ServiceModeMap.aspx.vb"
    AutoEventWireup="false" Inherits="Finance_ServiceModeMap" Title="LogiPark:: Service Mode Map"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
      
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Service Mode Map"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
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
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr style="height: 30px">
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Doc Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceType" runat="server" CssClass="RptFormTextBoxSmall" ToolTip="Doc Type"
                                                    Width="70px"></asp:TextBox>
                                            </td>
                                            <td>
                                            &nbsp;
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblServiceMode" runat="server" Text="Service Mode" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstServiceMode" AutoPostBack="true" runat="server" CssClass="FormListBoxMedium"
                                                    ToolTip="Service Mode" Enabled="false" onkeypress="kp_convert_upper()" MaxLength="20"
                                                    Width="180px">
                                                </asp:DropDownList>
                                                <samp class="mandatory">
                                                    *</samp>
                                                <asp:HiddenField ID="hdnServiceMode" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" align="center">
                                                <table cellspacing="2" border="0" cellpadding="0" style="border-color: White;">
                                                    <tr class="RepHead">
                                                        <td>
                                                            <asp:Label ID="lblSelect" Width="20px" runat="server" CssClass="FormLabel" Text=' <span class="mandatory"> </span>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblService" Width="300px" runat="server" CssClass="FormLabel" Text="Service"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 240px;">
                                                                <asp:Repeater ID="repService" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="1" border="0" cellpadding="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                                                <%--'<asp:HiddenField ID="hdnModeId" Value='<%# Eval("ModeId") %>' runat="server" />--%>
                                                                                <asp:CheckBox CssClass="FormLabel" Width="30px" ID="chkSelect" runat="server" ToolTip="Select">
                                                                                </asp:CheckBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox CssClass="FormTextBoxMedium" Width="300px" Text='<%# Eval("ServiceName") %>'
                                                                                    ID="textServiceName" Enabled="false" runat="server"></asp:TextBox>
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
                            <td>
                                <div id="dvTreeView" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="FormButton" />
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
</asp:Content>
