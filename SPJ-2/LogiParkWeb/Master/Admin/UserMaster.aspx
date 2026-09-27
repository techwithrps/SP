<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/UserMaster.aspx.vb" Inherits="Master_Admin_UserMaster"
    Title="eLOGiTrans :: User Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../../Script/validatePassword.js"></script>
    <script language="javascript" type="text/javascript">
        function validateEmailComm() {
            var result = false;
            if (validateEmailID(document.getElementById('<%=textEmailId.clientId %>'),
                        document.getElementById('<%=lblEmailId.clientId %>').innerHTML))

                result = true;
            else
                result = false;
            return result
        }
        function Select(id) {

            if (document.getElementById("cont2") != null) {
                var val = id.getAttribute('checked');
                var rowCount = document.getElementById("cont2").getElementsByTagName("tr").length;

                for (var k = 0; k < rowCount; k++) {
                    if (val == true) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repTerminal_ctl" + LPad((k + 1) + "", 2, "0") + "_chkTerminal").setAttribute('checked', true);
                    }
                    else {
                        document.getElementById("ctl00_ContentPlaceHolder1_repTerminal_ctl" + LPad((k + 1) + "", 2, "0") + "_chkTerminal").setAttribute('checked', false);
                    }

                }
            }
        }

        function checkRole(id) {

            if (document.getElementById("cont1") != null) {
                var val = id.getAttribute('checked');
                var count = 0;
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                if (val == true) {
                    for (var k = 0; k < rowCount; k++) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_repRole_ctl" + LPad((k + 1) + "", 2, "0") + "_chkRole").getAttribute('checked') == true) {
                            count += 1;
                        }

                    }
                    if (count > 1) {
                        alert('Only One Role Can be selected');
                        id.setAttribute('checked', false);
                    }
                }
            }
        }
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%; height: 490px">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="User Master" CssClass="FormLabelTitle">
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
                        <tr class="UserControls" style="height: 400px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUserId" runat="server" Text="User ID " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:TextBox ID="textUserId" runat="server" ToolTip="User ID" Width="100px" CssClass="textbox"
                                                    MaxLength="15">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                                <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPassword" runat="server" Text="Password " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                           <td align="left">
                                                <asp:TextBox ID="textPassword" runat="server" ToolTip="Password" AutoComplete="off" Width="100px" MaxLength="20"
                                                    CssClass="FormTextBoxMedium"></asp:TextBox>
                                                <asp:HiddenField runat="server" ID="hdnPassword" />
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUserName" runat="server" Text="User Name " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:TextBox ID="textUserName" Width="200px" runat="server" ToolTip="User Name" CssClass="textbox"
                                                    MaxLength="25">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailId" runat="server" Text="Email ID " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailId" onChange="return validateEmailComm();" runat="server"
                                                    Width="200px" ToolTip="Email ID" CssClass="textbox">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDepartment" runat="server" Text="Department " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:DropDownList ID="lstDepartment" runat="server" ToolTip="Department" Width="205px"
                                                    CssClass="ddlMedium">
                                                    <asp:ListItem Value="O">OPERATION</asp:ListItem>
                                                    <asp:ListItem Value="S">SALES &amp; MARKETING</asp:ListItem>
                                                    <asp:ListItem Value="A">ADMIN</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDesignation" runat="server" Text="Designation " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstDesignation" runat="server" ToolTip="Designation" Width="205px"
                                                    CssClass="ddlMedium">
                                                    <asp:ListItem Value="C">CEO</asp:ListItem>
                                                    <asp:ListItem Value="V">CFO</asp:ListItem>
                                                    <asp:ListItem Value="AC">GENERAL MANAGER</asp:ListItem>
                                                    <asp:ListItem Value="CM">MANAGER</asp:ListItem>
                                                    <asp:ListItem Value="E">EXECUTIVE</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUserType" runat="server" Text="User Type " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:DropDownList ID="lstUserType" runat="server" ToolTip="User Type" Width="205px"
                                                    CssClass="ddlMedium">
                                                    <asp:ListItem Value="I">INTERNAL</asp:ListItem>
                                                    <asp:ListItem Value="V">VENDOR</asp:ListItem>
                                                    <asp:ListItem Value="C">CUSTOMER</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRestrictedIP" runat="server" Text="Restricted IP " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRestrictedIP" runat="server" ToolTip="Restricted IP address"
                                                    CssClass="textbox">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPassexpirydays" runat="server" Text="Password expiry " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left; width: 346px;">
                                                <asp:TextBox ID="textPassexpirydays" runat="server" ToolTip="Password expiry days"
                                                    CssClass="textbox" onkeypress="kp_phonenumber();" MaxLength="3">
                                                </asp:TextBox>
                                                <asp:Label ID="Label1" runat="server" Text="(in days)" CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkUserStatus" runat="server" ToolTip="Active User" Checked="true">
                                                </asp:CheckBox>
                                                <asp:Label ID="lblUserStatus" runat="server" Text="Active User" CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td style="text-align: left">
                                                <asp:Label ID="lblMACadd" runat="server" Text="MAC Address" Width="150px" CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMAC" runat="server" ToolTip="MAC address" Width="500px"
                                                    CssClass="textbox">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center">
                                                <table>
                                                    <tr class="RepheaderNew">
                                                        <td align="center" width="200px" style="height:20px">
                                                            <asp:Label ID="lblRole" runat="server" CssClass="FormLabel" Text="Role">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="center" width="170px">
                                                            <asp:CheckBox ID="chkTerminal" Visible="false" onClick="Select(this);" runat="server"
                                                                ToolTip="Select All"></asp:CheckBox>
                                                            <asp:Label ID="lblTerminal" runat="server" CssClass="FormLabel" Text="Location">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="center" width="230px">
                                                            <asp:CheckBox ID="CheckCompany" Visible="false" onClick="Select(this);" runat="server"
                                                                ToolTip="Select All"></asp:CheckBox>
                                                            <asp:Label ID="lblCompany" runat="server" CssClass="FormLabel" Text="Company">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="center" width="170px">
                                                            <asp:CheckBox ID="chkUser" Visible="false" onClick="Select(this);" runat="server"
                                                                ToolTip="Select All"></asp:CheckBox>
                                                            <asp:Label ID="lblUser" runat="server" CssClass="FormLabel" Text="Users">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="height: 155px; width: 200px; text-align: left; overflow: auto">
                                                                <asp:Repeater ID="repRole" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:CheckBox ID="chkRole" onClick="checkRole(this);" runat="server" ToolTip="Role">
                                                                                </asp:CheckBox>
                                                                                <asp:Label ID="textJobName" runat="server" Width="150" CssClass="FormLabel" ToolTip="Role">
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobId") %>' />
                                                                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%# Eval("UserId") %>' />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table></FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                        <td style="width: 112px; border: 1px;">
                                                            <div style="height: 155px; text-align: left; width: 170px; overflow: auto">
                                                                <asp:Repeater ID="repTerminal" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont2" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:CheckBox Width="20px" ID="chkTerminal" runat="server" ToolTip="Terminal"></asp:CheckBox>
                                                                                <asp:Label ID="textTerminalName" runat="server" Width="120" CssClass="FormLabel"
                                                                                    ToolTip="Role">
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdnTerminalId" runat="server" Value='<%# Eval("TerminalId") %>' />
                                                                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%# Eval("UserId") %>' />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table></FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                        <td style="width: 112px; border: 1px;">
                                                            <div style="height: 155px; text-align: left; width: 230px; overflow: auto">
                                                                <asp:Repeater ID="repCompany" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont3" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:CheckBox Width="20px" ID="chkCompany" runat="server" ToolTip="Company"></asp:CheckBox>
                                                                                <asp:Label ID="textCompanyName" runat="server" Width="180" CssClass="FormLabel" ToolTip="Company">
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdnCompanyId" runat="server" Value='<%# Eval("CompanyId") %>' />
                                                                                <asp:HiddenField ID="hdnCompnayUserId" runat="server" Value='<%# Eval("UserId") %>' />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table></FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                         <td style="width: 112px;">
                                                            <div style="height: 155px; text-align: left; width: 170px; overflow: auto">
                                                                <asp:Repeater ID="repUser" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont4" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:CheckBox Width="20px" ID="chkUsers" runat="server" ToolTip="User"></asp:CheckBox>
                                                                                <asp:Label ID="textUser" runat="server" Width="120" CssClass="FormLabel" ToolTip="Users">
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdnMappUser" runat="server" Value='<%# Eval("MappedUser") %>' />
                                                                                <asp:HiddenField ID="hdnMapUserId" runat="server" Value='<%# Eval("UserId") %>' />
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
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 335px; width: 300px; border-left-color: Black;">
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
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
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
