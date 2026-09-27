<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/EquipmentMaster.aspx.vb" Inherits="Master_Admin_EquipmentMaster"
    Title="LogiPark:: Equipment Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Equipment Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" Value="" />
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
                                    <table>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblVendor" runat="server" Text="Vendor" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="lstVendor" runat="server" CssClass="FormListBoxMedium" Enabled="false"
                                                    ToolTip="Vendor">
                                                </asp:DropDownList>
                                                <span class="mandatory">*</span>
                                                <asp:HiddenField ID="hdnEquipRefId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="0">
                                                    <tr class="RepHead">
                                                        <td align="center">
                                                            <asp:Label ID="lblrEquipmentType" Width="100px" runat="server" CssClass="FormLabel"
                                                                Text='Equipment Type<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblrEquipmentNo" Width="100px" runat="server" CssClass="FormLabel"
                                                                Text='Equipment No<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblrCapcity" Width="100px" runat="server" CssClass="FormLabel" Text='Capacity </br>(kgs)<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblValidFromdate" Width="110px" runat="server" CssClass="FormLabel"
                                                                Text='Valid From Date<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblValidToDate" Width="140px" runat="server" CssClass="FormLabel"
                                                                Text='Valid To Date<span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <%--<td>
                                                            <asp:Label ID="lblStatus" Width="40px" CssClass="FormLabel" runat="server" Text="Status"></asp:Label>
                                                        </td>--%>
                                                        <td style="width: 15px; background-color: White;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="7" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 240px;">
                                                                <asp:Repeater ID="rpEquipment" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont" cellspacing="0" style="margin-left: -15px; "  >
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstEquipmentType" text='<%# Eval("EquipmentTypeCode") %>' OnDataBinding="prepareEquipmentType"
                                                                                    runat="server" ToolTip="Equipment Type" Width="100px">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnRepEquipRefId" Value='<%# Eval("EquipRefId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnEquipmentId" Value='<%# Eval("EquipmentId") %>' runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textEquipmentNo" runat="server" Text='<%# Eval("EquipmentNo") %>'
                                                                                    onkeypress="kp_convert_upper();" ToolTip="Equipment No" CssClass="FormTextBoxSmall"
                                                                                    Width="100px" MaxLength="20"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textCapacity" runat="server" ToolTip="Capacity(kgs)" CssClass="FormTextBoxNumeric"
                                                                                    Text='<%# Eval("Capacity") %>' onkeypress="kp_numeric();" Width="100px" MaxLength="5"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textValidFromDate" runat="server" ToolTip="Valid From Date" Text='<%# Eval("ValidFrom") %>'
                                                                                    CssClass="FormTextBoxSmall" Width="110px" MaxLength="10" onkeypress="kp_date();"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="clValidFromDate" runat="server" Format="dd/MM/yyyy"
                                                                                    TargetControlID="textValidFromDate">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textValidToDate" runat="server" ToolTip="Valid To Date" Text='<%# Eval("ValidTo") %>'
                                                                                    CssClass="FormTextBoxSmall" Width="110px" MaxLength="10" onkeypress="kp_date();"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="clValidToDate" runat="server" Format="dd/MM/yyyy"
                                                                                    TargetControlID="textValidToDate">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <%--<td>
                                                                                <asp:CheckBox ID="chkStatus" Width="40px" runat="server" Checked='<%#iif(Eval("Status")="Y",true,false) %>'
                                                                                    ToolTip="Status"></asp:CheckBox>
                                                                            </td>--%>
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
                            <td style="vertical-align: top;">
                                <div id="RepScroling" class="RepScroling" style="height: 90%; width: 300px; border-left-color: Black;
                                    vertical-align: top;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
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
