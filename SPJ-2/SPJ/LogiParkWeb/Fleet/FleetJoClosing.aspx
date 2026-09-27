<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetJoClosing.aspx.vb" Inherits="Fleet_FleetJoClosing" Title="eLOGiFleet :: Fleet Job Order"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript" language="javascript">

       
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Job Order Close"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="label" runat="server"></asp:Label>
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
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoType" runat="server" CssClass="label" Text="Jo No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstJoNo" runat="server" AutoPostBack="true" Width="170px" CssClass="ddlMedium"
                                                    ToolTip="Jo No">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnDriver" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnJoId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnMode" runat="server" Value="0" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoDate" runat="server" CssClass="label" Text="Jo Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoDate" runat="server" Width="100px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoValidity" runat="server" CssClass="label" Text="Jo Validity"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoValidity" runat="server" Width="100px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVehiclNo" runat="server" CssClass="label" Text="Vehicle No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVehicleNo" runat="server" Width="110px" AutoPostBack="true"
                                                    CssClass="Rpttextbox" ToolTip="VehicleNo">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVehicleType" runat="server" CssClass="label" Text="Vehicle Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVehicleType" runat="server" Width="100px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblLocation" runat="server" CssClass="label" Text="Workshop"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textWorkshop" runat="server" Width="170px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoFor" runat="server" CssClass="label" Text="Jo For"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoFor" runat="server" Width="100px" CssClass="Rpttextbox">
                                                   
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDriver" runat="server" CssClass="label" Text="Driver"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textDriver" runat="server" Width="170px" CssClass="Rpttextbox" ToolTip="VehicleNo">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Driver Contact No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" Width="100px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblRemark" runat="server" CssClass="label" Text="Remark"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textNote" runat="server" Width="230px" Height="35px" TextMode="MultiLine"
                                                    CssClass="textbox" ToolTip="Note">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr style="text-align: center">
                                            <td colspan="8" class="RepHeadFleet">
                                                <asp:Label ID="Label7" runat="server" CssClass="labelHeader" Text="JO Close Details"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTotal" runat="server" CssClass="label" Text="Total Advance"></asp:Label>
                                            </td>
                                            <td colspan="4" style="text-align: left">
                                                <asp:TextBox ID="textAdvanceTotal" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Balance Advance"></asp:Label>
                                                <asp:TextBox ID="textBalAdvance" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCLosingAmount" runat="server" CssClass="label" Text="JO Close Amount"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textClosAmt" onkeypress="kp_integer()" AutoPostBack="true" MaxLength="6"
                                                    runat="server" Width="115px" CssClass="textbox" Enabled="false">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAdvance" runat="server" CssClass="label" Text="Advance Refund"></asp:Label>
                                            </td>
                                            <td colspan="4" style="text-align: left">
                                                <asp:DropDownList ID="lstAdvance" runat="server" Width="200px" CssClass="ddlMedium">
                                                    <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Adjust from Salary" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Adjust from Job Order" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Close" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTripCloseDate" runat="server" CssClass="label" Text="Trip Close Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textCloseDate" runat="server" MaxLength="11" Width="115px" CssClass="textbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textCloseDate"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
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
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
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
