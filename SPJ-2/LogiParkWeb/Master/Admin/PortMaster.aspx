<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/PortMaster.aspx.vb" Inherits="Master_Admin_PortMaster"
    Title="eLOGiFreight:: Port Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textPortCode.clientId %>'),
                        document.getElementById('<%=lblPortCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textPortName.clientId %>'),
                            document.getElementById('<%=lblPortName.clientId %>').innerHTML))
                    if (validateDropDownIndex(document.getElementById('<%=lstCountry.clientId %>'),
                            document.getElementById('<%=lblCountry.clientId %>').innerHTML))
                        if (validateData(document.getElementById('<%=textAddress.clientId %>'),
                            document.getElementById('<%=lblAddress.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textCustomRefImport.clientId %>'),
                            document.getElementById('<%=lblCustomRefImport.clientId %>').innerHTML))
                                if (validateData(document.getElementById('<%=textCustomRefExport.clientId %>'),
                           document.getElementById('<%=lblCustomRefExport.clientId %>').innerHTML))
                                    result = true;
                                else
                                    result = false;
                            else
                                result = false;
                        else
                            result = false;
                    else
                        result = false;
                else
                    result = false;
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
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Port Master" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                                <td style="width: 100%; vertical-align: top;" align="center">
                                    <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                        <table border="0" cellpadding="0" style="border-style: none;">
                                            <tr style="height: 30px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPortCode" runat="server" Text="Port Code" CssClass="FormLabel"></asp:Label>&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="textPortCode" runat="server" CssClass="textbox" ToolTip="Port Code"
                                                        onkeypress="kp_convert_upper()" MaxLength="20" Width="120px"></asp:TextBox>
                                                    <strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                    <asp:HiddenField ID="hdnPortId" runat="server" Value="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblPortName" runat="server" Text="Port Name" CssClass="FormLabel"></asp:Label>&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="textPortName" runat="server" CssClass="textbox" ToolTip="Port Name"
                                                        onkeypress="kp_convert_upper()"></asp:TextBox>
                                                    <strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" valign="top">
                                                    <asp:Label ID="lblAddress" runat="server" CssClass="FormLabel" Text="Address"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="textAddress" Rows="3" runat="server" CssClass="textbox"
                                                        TextMode="MultiLine" Height="35px" ToolTip="Address">
                                                    </asp:TextBox>
                                                    <strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="FormLabel"></asp:Label>&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="lstCountry" runat="server" Width="120px" CssClass="ddlMedium"
                                                        ToolTip="Country">
                                                    </asp:DropDownList>
                                                    <strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblCustomRefImport" runat="server" CssClass="FormLabel" Text="Custom Ref Code"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="textCustomRefImport" runat="server" CssClass="textbox"
                                                        ToolTip="Custom Ref Code" onkeypress="kp_convert_upper()" MaxLength="10" Width="120px"></asp:TextBox>
                                                    <strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblCustomRefExport" runat="server" CssClass="FormLabel" Text="Custom Ref Export"
                                                        Visible="true"></asp:Label>&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="textCustomRefExport" runat="server" CssClass="textbox"
                                                        ToolTip="Custom Ref Export" MaxLength="10" onkeypress="kp_convert_upper()" Width="120px"
                                                        Visible="true"></asp:TextBox>
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
                                <td valign="top">
                                    <div id="RepScroling" class="RepScroling" style="height: 300px; width: 300px; border-left-color: Black; overflow:auto;">
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
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" OnClientClick="return saveValidation();" />
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
