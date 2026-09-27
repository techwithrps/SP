<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/TripClose.aspx.vb" Inherits="Fleet_TripClose" Title="eLOGiFleet :: Trip Closing"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        var ddlText, ddlValue, ddl, lblMesg;
        function CacheItems() {
            ddlText = new Array();
            ddlValue = new Array();
            ddl = document.getElementById("<%=lstVehicleNo.ClientID %>");

            for (var i = 0; i < ddl.options.length; i++) {
                ddlText[ddlText.length] = ddl.options[i].text;
                ddlValue[ddlValue.length] = ddl.options[i].value;
            }

        }
        window.onload = CacheItems;

        function FilterItems(value) {
            ddl.options.length = 0;
            for (var i = 0; i < ddlText.length; i++) {
                if (ddlText[i].toLowerCase().indexOf(value) != -1) {
                    AddItem(ddlText[i], ddlValue[i]);
                }
            }

        }



        function AddItem(text, value) {
            var opt = document.createElement("option");
            opt.text = text;
            opt.value = value;
            ddl.options.add(opt);
        }
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Trip Close" CssClass="FormLabelTitle">
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
                                                <asp:Label ID="lblVehicleNO" runat="server" CssClass="label" Text="Vehicle No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstVehicleNo" runat="server" Width="110px" CssClass="ddlMedium"
                                                    ToolTip="Cont No">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="textFind" onkeyup="FilterItems(this.value)" runat="server" Width="50px"
                                                    CssClass="Rpttextbox">                                                   
                                                </asp:TextBox>
                                                <asp:Button ID="btnAddVehicle" runat="server" Text="Go" Visible="false" CssClass="FormButton" />
                                                <asp:HiddenField ID="hdnDriverId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnGrId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnTransporterId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnFromTerminalId" runat="server" Value="0" />
                                                <asp:HiddenField ID="HdnToLocationId" runat="server" Value="0" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblSize" runat="server" CssClass="label" Text="Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVehicleSize" runat="server" Width="70px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                                &nbsp;&nbsp;
                                                <asp:HiddenField ID="hdnTripType" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblGRNo" runat="server" CssClass="label" Text="GR No"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textGrNo" Width="110px" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGrDate" runat="server" CssClass="label" Text="GR Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textGrDate" runat="server" Width="110px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Customer"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textCustomer" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTransportar" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblCustomerName" runat="server" CssClass="label" Text="Shipper Name"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="textShipper" runat="server" Width="250px" CssClass="Rpttextbox" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblFromLocation" runat="server" CssClass="label" Text="From Location"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textFromLocation" runat="server" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblToLocation" runat="server" CssClass="label" Text="To Location"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="lstToLocation" runat="server" Width="225px" CssClass="ddlMedium"
                                    Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblHandover" runat="server" CssClass="label" Text="Handover"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textHandover" runat="server" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblTripType" runat="server" CssClass="label" Text="Doc Type"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textTripType" runat="server" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblContNo" runat="server" CssClass="label" Text="Cont No"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textContNo" runat="server" Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDriver" runat="server" CssClass="label" Text="Driver"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textDriver" runat="server" Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Driver Contact No"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textContactNo" runat="server" Width="110px" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblLicenseValidity" runat="server" CssClass="label" Text="License Validity"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textLicenseValidity" runat="server" Width="110px" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <%--<tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="LblCFS" runat="server" CssClass="label" Text="CFS"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="LstCfs" runat="server" CssClass="ddlMediumq" Width="150px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lBLiNE" runat="server" CssClass="label" Text="Line"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstLine" runat="server" CssClass="ddlMediumq" Width="150px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>--%>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td colspan="4" class="RepHeadFleet">
                                <asp:Label ID="lblAdvanceDtls" runat="server" CssClass="labelHeader" Text="Trip Advance Details"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblAdvance" runat="server" CssClass="label" Text="Cash Rs."></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textAdvance" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblOilAdvance" runat="server" CssClass="label" Text="Oil Advance(Rs)"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textOilAdvance" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Balance(Rs)"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textBalance" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblTotal" runat="server" CssClass="label" Text="Total"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textAdvanceTotal" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                    Width="110px" CssClass="Rpttextbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr style="text-align: left">
                            <td colspan="4" class="RepHeadFleet">
                                <asp:Label ID="Label1" runat="server" CssClass="labelHeader" Text="Trip Close Details"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblCLosingAmount" runat="server" CssClass="label" Text="Trip Close Amount"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textClosAmt" onkeypress="kp_integer()" MaxLength="6" AutoPostBack="true"
                                    runat="server" Width="110px" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Advance Refund"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="lstAdvance" runat="server" Width="170px" CssClass="ddlMedium">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Adjust from Salary" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Adjust from Job Order" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Close" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblTripCloseDate" runat="server" CssClass="label" Text="Trip Close Date"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textCloseDate" runat="server" AutoComplete="off" MaxLength="10" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textCloseDate"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <asp:DropDownList ID="lstCloseDateHH" runat="server" Width="50px" ToolTip="Hours"
                                    CssClass="ddlMedium">
                                </asp:DropDownList>
                                <ajaxToolkit:DropDownExtender ID="lstCloseDateHH_DropDownExtender" runat="server"
                                    DynamicServicePath="" TargetControlID="lstCloseDateHH">
                                </ajaxToolkit:DropDownExtender>
                                <asp:DropDownList ID="lstCloseDateMM" Width="50px" runat="server" ToolTip="Minutes"
                                    CssClass="ddlMedium">
                                </asp:DropDownList>
                                <ajaxToolkit:DropDownExtender ID="lstCloseDateMM_DropDownExtender" runat="server"
                                    DynamicServicePath="" TargetControlID="lstCloseDateMM">
                                </ajaxToolkit:DropDownExtender>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblRemark" runat="server" CssClass="label" Text="Remark"></asp:Label>
                            </td>
                            <td style="text-align: left" colspan="3">
                                <asp:TextBox ID="textRemark" runat="server" Width="230px" Height="35px" TextMode="MultiLine"
                                    CssClass="textbox" MaxLength="40" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px"></td>
                        </tr>
                    </table>
                </div>
            </td>
            </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="FormButton" />
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
