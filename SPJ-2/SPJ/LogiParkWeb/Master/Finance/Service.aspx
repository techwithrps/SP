<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Finance/Service.aspx.vb" Inherits="Finance_Service" Title="eLOGiFleet :: Service Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textServiceCode.clientId %>'),
                        document.getElementById('<%=lblServiceCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textServiceName.clientId %>'),
                            document.getElementById('<%=lblServiceName.clientId %>').innerHTML))
                    if (validateDropDownIndex(document.getElementById('<%=lstServiceType.clientId %>'),
                            document.getElementById('<%=lblServiceType.clientId %>').innerHTML))
                        if (validateDropDownIndex(document.getElementById('<%=lstTaxGroupId.clientId %>'),
                               document.getElementById('<%=lblTaxGroupId.clientId %>').innerHTML))
                            if (validateDropDownIndex(document.getElementById('<%=lstUomId.clientId %>'),
                                        document.getElementById('<%=lblUomId.clientId %>').innerHTML))
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Service" CssClass="FormLabelTitle">
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
                            <td style="width: 100%;" align="center" valign="top">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceCode" runat="server" Text="Service Code" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceCode" runat="server" CssClass="textbox" onkeypress="kp_convert_upper()"
                                                    ToolTip="Service Code" MaxLength="20"></asp:TextBox><strong><samp class="mandatory">*</samp></strong>
                                                <asp:HiddenField ID="hdnServiceId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceName" runat="server" Text="Service Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceName" runat="server" CssClass="textbox" ToolTip="Service Name"></asp:TextBox><strong><samp
                                                    class="mandatory">*</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceType" runat="server" CssClass="label" Text="Service Type"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstServiceType" runat="server" CssClass="ddlMedium" ToolTip="Service Type"
                                                    Width="175px">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTaxGroupId" runat="server" CssClass="label" Text="Tax Group ID"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstTaxGroupId" runat="server" CssClass="ddlMedium" ToolTip="Tax Group"
                                                    Width="175px">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Unit"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textUnit" runat="server" CssClass="textbox" ToolTip="Unit"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblMapCode" runat="server" CssClass="label" Text="Map Code"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMapCode" runat="server" CssClass="textbox" ToolTip="Map Code"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTaxOnPercentage" runat="server" CssClass="label" Text="Tax On Percentage (%)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTaxOnPercentage" runat="server" CssClass="textbox" MaxLength="8"
                                                    onkeypress="kp_numeric()" ToolTip="Tax On Percentage (%)" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUomId" runat="server" CssClass="label" Text="UOM ID"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstUomId" runat="server" CssClass="ddlMedium" ToolTip="UOM ID"
                                                    Width="175px">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblExRate" runat="server" CssClass="label" Text="Ex Rate"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textExRate" runat="server" CssClass="textbox" ToolTip="Ex Rate"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" Text="Tally Inter State Service Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtTallyInterStateServiceName" runat="server" CssClass="textbox"
                                                    ToolTip="Tally Inter State Service Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label2" runat="server" Text="Tally Local State Service Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtTallyLocalStateServiceName" runat="server" CssClass="textbox"
                                                    ToolTip="Tally Local State Service Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label4" runat="server" Text="Tally Purchase Inter State Service Name"
                                                    CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtTallypurchaseInterStateServiceName" runat="server" CssClass="textbox"
                                                    ToolTip="Tally Inter State Service Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label5" runat="server" Text="Tally Purchase Local State Service Name"
                                                    CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtTallypurchaseLocalStateServiceName" runat="server" CssClass="textbox"
                                                    ToolTip="Tally Local State Service Name"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Service Group Name"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstServiceGroupName" runat="server" CssClass="ddlMedium" ToolTip="Service Group Name"
                                                    Width="175px">
                                                    <asp:ListItem Value="0">--Select Service Group--</asp:ListItem>
                                                    <asp:ListItem Value="1">Transport Group</asp:ListItem>
                                                    <asp:ListItem Value="2">Freight Group</asp:ListItem>
                                                    <asp:ListItem Value="3">Clearence Group</asp:ListItem>
                                                    <asp:ListItem Value="4">Other Group</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCurrency" runat="server" CssClass="label" Text="Service Type"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCurrency" runat="server" CssClass="ddlMedium" 
                                                                  ToolTip="Curreny"
                                                    Width="175px">
                                                    <asp:ListItem Value="0">--Select Currency--</asp:ListItem>
                                                    <asp:ListItem Value="INR" Text="INR"></asp:ListItem>
                                                    <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                                                    <asp:ListItem Value="EURO" Text="EURO"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="dvTreeView" class="RepScroling" style="height: 300px; width: 300px; border-left-color: Black;">
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
