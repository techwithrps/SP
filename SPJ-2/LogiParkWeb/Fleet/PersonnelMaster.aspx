<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/PersonnelMaster.aspx.vb" Inherits="Fleet_PersonnelMaster" Title="eLOGiFleet :: Personnel Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textTerminalCode.clientId %>'),
                        document.getElementById('<%=lblTerminalCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textTerminalName.clientId %>'),
                        document.getElementById('<%=lblTerminalName.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textAddress.clientId %>'),
                        document.getElementById('<%=lblAddress.clientId %>').innerHTML))
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Terminal Master"
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
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr style="height: 20px;">
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTerminalCode" runat="server" Text="Manufacture Code" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTerminalCode" runat="server" CssClass="FormTextBoxSmall" ToolTip="Manufacture Code"
                                                    onkeypress="kp_convert_upper()" MaxLength="10" Width="110px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnTerminalId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTerminalName" runat="server" Text="Manufacture Name" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTerminalName" runat="server" CssClass="FormTextBoxLarg" ToolTip="Manufacture  Name"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="text-align: right">
                                                <asp:Label ID="lblAddress" runat="server" CssClass="FormLabel" Text="Address"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAddress" Rows="3" runat="server" CssClass="FormTextBoxLarg"
                                                    TextMode="MultiLine" Height="35px" ToolTip="Address">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="FormLabel" Text="Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" CssClass="FormTextBoxSmall" ToolTip="Contact No"
                                                    onkeypress="kp_integer()" MaxLength="10" Width="110px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;">
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
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" OnClientClick="return saveValidation();" />
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
</asp:Content>
