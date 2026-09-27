<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MasterMaintanance.aspx.vb" Inherits="Fleet_MasterMaintanance" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">



        $(document).ready(function () {
            $('input[type=text][id*=TextFInDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=TextFOutDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
       
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Master Maintenance" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field" ForeColor="Red"></asp:Label>
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
                                            <td align="left">
                                                <asp:Label ID="lblContNo" runat="server" Text="Container No" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="textContNo" runat="server" MaxLength="11" CssClass="textbox" Width="120px" ToolTip="Container No">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span><asp:ImageButton ID="btnSearchGr" runat="server" Visible="false" Width="30px"
                                                    ImageUrl="~/Images/brnAddtop.png" Height="20px" />
                                            </td>
                                            <td style="text-align: left; margin-left: 40px;">
                                                <asp:Label ID="lblGrNo" runat="server" Text="GR No" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="lstGRNo" runat="server" AutoPostBack="true" Width="170px"
                                                    CssClass="ddlMedium" ToolTip="GR No">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblGrDate" runat="server" Text="GR Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                 <asp:Label ID="textGRdate" runat="server" Text="00/00/0000" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblJONo" runat="server" Text="Job No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textJONo" runat="server" MaxLength="10" CssClass="textbox" Width="120px" Enabled="false" ToolTip="Item">
                                                </asp:TextBox>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblJODate" runat="server" Text="Job Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textJODate" runat="server" MaxLength="10" CssClass="textbox" Width="120px" Enabled="false" ToolTip="Item">
                                                </asp:TextBox>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblConsignmentType" runat="server" Text="Consignment Type" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstConsignmentType" runat="server" AutoPostBack="true" Width="100px"
                                                    CssClass="ddlMedium" ToolTip="ConsignmentType">
                                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="FOB" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="CNF" Value="1"></asp:ListItem>

                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignor"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstCustomer" runat="server" Width="280px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstConsignee" runat="server" Width="280px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblCha" runat="server" CssClass="label" Text="Shipping Line"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="lstLine" runat="server" Width="190px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblICDOutDate" runat="server" Text="ICD Out Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textICDOutDate" runat="server" MaxLength="10"
                                                    CssClass="FormTextBoxSmall" Width="120px" Enabled="false" ToolTip="Item">
                                                </asp:TextBox>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblFactoryInDate" runat="server" Text="Factory In Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textFactoryInDate" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblFactoryOutDate" runat="server" Text="Factory Out Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textFactoryOutDate" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblICDInDate" runat="server" Text="ICD In Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textICDInDate" Width="120px" Enabled="false" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblMtyPickUp" runat="server" Text="Empty Pickup" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstMtyPickup" runat="server"  Width="170px" CssClass="ddlMedium" ToolTip="Empty Pickup">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblFactory" runat="server" Text="Factory" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstFactory" runat="server"  Width="170px" CssClass="ddlMedium" ToolTip="Factory">
                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblHandover" runat="server" Text="Handover" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstHandover" runat="server"  Width="170px" CssClass="ddlMedium" ToolTip="Handover">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblLineHandoverDate" runat="server" Text="Line Handover Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textLineHandoverDate" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPOL" runat="server" Text="POL" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPOL" runat="server"  Width="170px" CssClass="ddlMedium" ToolTip="POL">
                                                </asp:DropDownList>
                                                </td>
                                            <td align="left">
                                                <asp:Label ID="lblFPOD" runat="server" Text="FPOD" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstFPOD" runat="server"  Width="170px" CssClass="ddlMedium" ToolTip="FPOD">
                                                </asp:DropDownList>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPartyInvoiceNo" runat="server" Text="Party Invoice No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textPartyInvoiceNo" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPartyInvoiceDate" runat="server" Text="Party Invoice Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textPartyInvoiceDate" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
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
    <div style="visibility: hidden">
        <asp:GridView ID="gvBedDtls" runat="server">
        </asp:GridView>
    </div>
    </table> </table>
</asp:Content>
