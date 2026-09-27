<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="JoReferenceMaster.aspx.vb" Inherits="Master_Admin_JoReferenceMaster"
    Title="eLOGiFleet :: Job Order Reference" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textJobOrderCode.clientId %>'),
                        document.getElementById('<%=lblJobOrderCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textJODescription.clientId %>'),
                        document.getElementById('<%=lblJODescription.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textReferenceStart.clientId %>'),
                        document.getElementById('<%=lblReferenceStart.clientId %>').innerHTML))
                        if (validateData(document.getElementById('<%=textReferenceLength.clientId %>'),
                        document.getElementById('<%=lblReferenceLength.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textReferenceNumber.clientId %>'),
                        document.getElementById('<%=lblReferenceNumber.clientId %>').innerHTML))
                                if (validateData(document.getElementById('<%=textReferenceEnd.clientId %>'),
                        document.getElementById('<%=lblReferenceEnd.clientId %>').innerHTML))
                                    if (validateDropDownIndex(document.getElementById('<%=lstModuleId.clientId %>'),
                            document.getElementById('<%=lblModuleId.clientId %>').innerHTML))
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
                            <td style="height: 20px;">
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Job Order Reference"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
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
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJobOrderCode" runat="server" Text="Job Order Code" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJobOrderCode" runat="server" CssClass="textbox" ToolTip="Job Order Code"
                                                    onkeypress="kp_convert_upper();" MaxLength="20" Width="200px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnJobOrderId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnReferenceKeyId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJODescription" runat="server" Text="JO Description" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJODescription" runat="server" CssClass="textbox" ToolTip="Job Order Description" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReferenceStart" runat="server" CssClass="label" Text="Reference Start"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textReferenceStart" runat="server" CssClass="textbox" ToolTip="Reference Start"
                                                    onkeypress="kp_convert_upper();" MaxLength="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReferenceLength" runat="server" CssClass="label" Text="Reference Length"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textReferenceLength" runat="server" CssClass="textbox" onkeypress="kp_integer()"
                                                    ToolTip="Reference Length" MaxLength="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReferenceNumber" runat="server" CssClass="label" Text="Reference No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textReferenceNumber" runat="server" CssClass="textbox" onkeypress="kp_integer()"
                                                    ToolTip="Reference No" MaxLength="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReferenceEnd" runat="server" CssClass="label" Text="Reference End"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textReferenceEnd" runat="server" CssClass="textbox" ToolTip="Reference End"
                                                    onkeypress="kp_convert_upper();" MaxLength="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblModuleId" runat="server" CssClass="label" Text="Module"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstModuleId" runat="server" CssClass="ddlMedium" ToolTip="Module">
                                                    <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                           <td valign="top">
                                <div id="dvTreeView" class="RepScroling" style="height: 100%; width: 200px; border-left-color: Black;">
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
