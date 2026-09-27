<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/ItemGroup.aspx.vb" Inherits="Master_Admin_ItemGroup"
    Title="LogiPark :: Tax Head" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textItemGroupName.clientId %>'),
                        document.getElementById('<%=lblTaxHeadName.clientId %>').innerHTML))
                result = true;
            else
                result = false;

            return result;
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="200px" Text="Item Group" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" Text="" runat="server" CssClass="FormLabel"></asp:Label>
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
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTaxHeadName" runat="server" CssClass="FormLabel" Text="Item Group Name">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textItemGroupName" runat="server" CssClass="textbox" Width="250"
                                                    ToolTip="Item Group Name">
                                                </asp:TextBox><strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTaxPercentage" runat="server" CssClass="FormLabel" Text="Tax Percentage ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTaxPercentage" runat="server" CssClass="FormTextBoxNumeric" MaxLength="8" onkeypress="kp_numeric()"
                                                    ToolTip="Tax Percentage">
                                                </asp:TextBox><strong><samp class="mandatory">*</samp></strong>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblMapCode" runat="server" CssClass="FormLabel" Text="Map Code">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMapCode" runat="server" CssClass="textbox" ToolTip="Item Group Code"
                                                    MaxLength="20">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnTaxHeadID" runat="server" Value="" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="tvScroling" style="height: 400px; width: 300px; border-left-color: Black;">
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
                                                <asp:Button ID="btnAdd" Text="ADD" runat="server" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" Text="EDIT" runat="server" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" Text="SAVE" runat="server" CssClass="FormButton" OnClientClick="return saveValidation();" />
                                                <asp:Button ID="btnCancel" Text="CANCEL" runat="server" CssClass="FormButton" />
                                                <asp:Button ID="btnExit" Text="EXIT" runat="server" CssClass="FormButton" />
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
