<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/RouteMasterEntry.aspx.vb" Inherits="Master_Admin_RouteMasterEntry" Title="eLOGiRail :: Route Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script type="text/javascript" language="javascript">
    function findRoute()
    {
        if(document.getElementById('<%= lstToTerminal.clientId %>').getAttribute('disabled')==false)
        {
            var SourceTerminal=document.getElementById('<%= lstFromTerminal.clientId %>');
            var SelectedSource=SourceTerminal.options[SourceTerminal.selectedIndex].text;
            var DestTerminal=document.getElementById('<%= lstToTerminal.clientId %>');
            var SelectedDest=DestTerminal.options[DestTerminal.selectedIndex].text;
                document.getElementById('<%= textRouteName.clientId %>').value=SelectedSource + "-" + SelectedDest;
                 document.getElementById('<%= textTrainPrefix.clientId %>').value=SelectedSource + "-" + SelectedDest;
                
        }
     return true;
    }

    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Route Master" CssClass="FormLabelTitle">
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
            <td style="height: 100%">
                <table>
                    <tr>
                        <td style="width: 100%; vertical-align: middle;" align="center">
                            <div id="dvControl" runat="server" 
                                style="width: 100%; vertical-align: top; height: 362px;">
                                <table style="height: 370px">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblFromTerminal" runat="server" Text="From Terminal " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:DropDownList ID="lstFromTerminal" runat="server" CssClass="FormListBoxMedium"
                                                            ToolTip="From Terminal">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblToTerminal" runat="server" Text="To Terminal " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:DropDownList ID="lstToTerminal" runat="server" CssClass="FormListBoxMedium"
                                                            onChange="findRoute();" ToolTip="To Terminal">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblRouteType" runat="server" Text="Route Type " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:DropDownList ID="lstRouteType" runat="server" CssClass="FormListBoxMedium" ToolTip="Route Type">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblBillableDis" runat="server" Text="Billable Distance " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="textBillableDis" onkeypress="kp_numeric();" runat="server" ToolTip="Billable Distance"
                                                            CssClass="FormTextBoxNumSmall" MaxLength="5">
                                                        </asp:TextBox>
                                                        <span class="mandatory" style="vertical-align:top;">*</span>
                                                        <asp:HyperLink ID="hre" runat="server" onclick="window.open('http://rbs.indianrail.gov.in/ShortPath/ShortPath.jsp')"
                                                            text="Connect to RBS" Font-Underline="true" CssClass="FormButton" BorderStyle="None" BackColor="White"
                                                            style="width: 100px; color:Blue;" />
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblActualDis" runat="server" Text="Actual Distance " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="textActualDis" onkeypress="kp_numeric();" runat="server" ToolTip="Actual Distance"
                                                            CssClass="FormTextBoxNumSmall" MaxLength="5">
                                                        </asp:TextBox>
                                                        <span class="mandatory" style="vertical-align:top;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblRouteName" runat="server" Text="Route Name " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="textRouteName" onkeypress="kp_convert_upper()" runat="server" ToolTip="Route Name"
                                                            CssClass="FormTextBoxMedium">
                                                        </asp:TextBox>
                                                        <span class="mandatory" style="vertical-align:top;">*</span>
                                                        <asp:HiddenField ID="hdnRouteId" runat="server" Value="0" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblTrainPrefix" runat="server" Text="Train No. Prefix " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="textTrainPrefix" onkeypress="kp_convert_upper()" runat="server"
                                                            ToolTip="Train Prefix" CssClass="FormTextBoxMedium">
                                                        </asp:TextBox>
                                                        <span class="mandatory" style="vertical-align:top;">*</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right; height: 26px;">
                                                        <asp:Label ID="lblBeginNo" runat="server" Text="Begining Number " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left; height: 26px;">
                                                        <asp:TextBox ID="textBeginNo" onkeypress="kp_numeric();" runat="server" ToolTip="Train Begin Number"
                                                            CssClass="FormTextBoxNumSmall" MaxLength="5">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:Label ID="lblAverageTime" runat="server" Text="AverageTime (Hours) " CssClass="FormLabel">
                                                        </asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="textAverageTime" onkeypress="kp_numeric();" runat="server" ToolTip="AverageTime (Hours)"
                                                            CssClass="FormTextBoxNumSmall" MaxLength="3">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="center">
                                            <table cellspacing="0">
                                                <tr class="Repheader">
                                                    <td>
                                                        <asp:Label ID="lblSrSubTerminal" Width="130px" runat="server" Text="Sub Route Mapping"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 288px; vertical-align:top;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <div class="RepScroling" style="height: 250px;">
                                                                        <asp:Repeater ID="repSubRoute" runat="server">
                                                                            <HeaderTemplate>
                                                                                <table cellspacing="0">
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList class="FormListBoxSmall" Width="150px" ID="lstSubRoute" runat="server"
                                                                                            Text='<%# Eval("SubRouteId") %>' OnDataBinding="prepareRoute" ToolTip="Terminal">
                                                                                        </asp:DropDownList>
                                                                                        <asp:HiddenField ID="hdnRouteId" runat="server" Value='<%# Eval("RouteId") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                </table></FooterTemplate>
                                                                        </asp:Repeater>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnAddRow" runat="server" Visible="false" CssClass="FormButton" Text="Add Row" />
                                                                    <asp:Button ID="btnDeleteRow" runat="server" Visible="false" CssClass="FormButton"
                                                                        Text="Delete Row" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td>
                            <div id="dvTreeView" class="tvScrollStyle" 
                                style="height: 341px; width: 349px; overflow: auto;">
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
                <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
