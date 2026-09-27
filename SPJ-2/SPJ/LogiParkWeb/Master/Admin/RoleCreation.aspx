<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" CodeFile="~/Master/Admin/RoleCreation.aspx.vb"
    AutoEventWireup="false" Inherits="Master_Admin_RoleCreation" Title="eLOGiFreight :: Role Creation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript" language="jscript">

        function check(id) {
            if (document.getElementById("cont") != null) {
                var val = id.checked;
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;
                var result = true;
                for (var j = 0; j < rowCount; j++) {

                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkAdd").checked=val;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked = val;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkEdit").checked = val;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSearch").checked = val;
                } return true;
            }
        }

        function checkMenu(id) {

            var strsbno = "_chkSelect";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //var tablename = 105;
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + tablename + "_chkSelect").checked;
            var parentid = document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + tablename + "_hdnParentId").value;
            document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + tablename + "_chkAdd").checked = chkSelect;
            document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + tablename + "_chkEdit").checked = chkSelect;
            document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + tablename + "_chkSearch").checked = chkSelect;

            var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;

            for (var j = 0; j < rowCount; j++) {

                var chkSelectParent = document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkselect").checked;
                var rowmenuid = document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_hdnMenuId").value;
                if ((parentid == rowmenuid)) {
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkAdd").checked = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked = true;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkEdit").checked=true;
                    document.getElementById("ctl00_ContentPlaceHolder1_repRoleMaster_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSearch").checked=true;
                }
            }

        }
  
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Role Creation"
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
                            <td style="width: 100%; vertical-align: top;" align="center" width="600px">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table width="100%" border="0" cellpadding="0" style="border-style: none;">
                                        <tr align="center">
                                            <td style="text-align: center">
                                                <asp:Label ID="lblRoleName" runat="server" Text="Role Name" CssClass="label"></asp:Label>
                                                <asp:TextBox ID="textRoleName" runat="server" CssClass="textbox" Width="200px" ToolTip="Role Name"
                                                    MaxLength="50" Enabled="false"></asp:TextBox><strong> <span class="mandatory" style="vertical-align: top;">
                                                        *</span></strong>
                                                <asp:HiddenField ID="hdnRoleId" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="0">
                                                    <tr class="RepHead">
                                                        <td align="left" width="40px">
                                                            <asp:CheckBox ID="chkBcdSelect" onClick="check(this);" runat="server"></asp:CheckBox>
                                                        </td>
                                                        <td align="left" width="280px">
                                                            <asp:Label ID="lblBcdMenuDescription" runat="server" CssClass="labelHeader" Font-Bold="true"
                                                                Text="Menu Description">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="40px">
                                                            <asp:Label ID="lblAdd" runat="server" CssClass="labelHeader" Font-Bold="true" Text="Add">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="40px">
                                                            <asp:Label ID="lblEdit" runat="server" CssClass="labelHeader" Font-Bold="true" Text="Edit">
                                                            </asp:Label>
                                                        </td>
                                                        <td align="left" width="40px">
                                                            <asp:Label ID="lblSearch" runat="server" CssClass="labelHeader" Font-Bold="true"
                                                                Text="Search">
                                                            </asp:Label>
                                                        </td>
                                                        <td style="width: 15px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6" valign="top" align="left">
                                                            <div class="RepScroling" style="height: 350px; width: 500px">
                                                                <asp:Repeater ID="repRoleMaster" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table cellspacing="0" id="cont" style="margin-left: -10;">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr align="left">
                                                                            <td align="center">
                                                                                <asp:CheckBox ID="chkSelect" onClick="checkMenu(this);" runat="server" ToolTip="Select">
                                                                                </asp:CheckBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobId") %>' />
                                                                                <asp:HiddenField ID="hdnMenuId" runat="server" Value='<%# Eval("MenuId") %>' />
                                                                                <asp:HiddenField ID="hdnParentId" Value="0" runat="server" />
                                                                                <asp:Label ID="textMenuId" Enabled="false" runat="server" Width="300px" CssClass="label"
                                                                                    ToolTip="Menu" Text='<%# Eval("MenuId") %>'>
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td width="40px">
                                                                                <asp:CheckBox ID="chkAdd" runat="server" ToolTip="Add" Checked='<%#IIf(Eval("AddPermit") = "Y", True, False) %>'>
                                                                                </asp:CheckBox>
                                                                            </td>
                                                                            <td width="40px">
                                                                                <asp:CheckBox ID="chkEdit" runat="server" ToolTip="Edit" Checked='<%#IIf(Eval("EditPermit") = "Y", True, False) %>'>
                                                                                </asp:CheckBox>
                                                                            </td>
                                                                            <td width="40px">
                                                                                <asp:CheckBox ID="chkSearch" runat="server" ToolTip="Search" Checked='<%#IIf(Eval("SearchPermit") = "Y", True, False) %>'>
                                                                                </asp:CheckBox>
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
                            <td valign="top">
                                <div id="tvTreeView" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvService" runat="server" Style="font-family: Verdana; font-size: 12px"
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
