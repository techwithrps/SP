<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/LocationMaster.aspx.vb" Inherits="Master_Admin_LocationMaster"
    Title="eLOGiFleet:: Location Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
        var previousSelectedRow = null;
        var currentSelectedRow = null;
        function setrowcolor(chkSelectedRow) {
            if (chkSelectedRow.checked)
                chkSelectedRow.parentNode.parentNode.style.backgroundColor = "lightblue";
            else
                chkSelectedRow.parentNode.parentNode.style.backgroundColor = "";
        }

        function GetIdAll(ctrl) {
            try {
                document.getElementById(previousSelectedRow).checked = false;
                ctrl.parentNode.parentNode.style.backgroundColor = "";
            } catch (e) {

            }

            currentSelectedRow = ctrl.id.toString();
            previousSelectedRow = currentSelectedRow;
            currentSelectedRow = currentSelectedRow.replace('_chkSelectedRow', '');
            var lstLocation = document.getElementById('<%=lstLocation.clientId %>');
            var lstHandover = document.getElementById('<%=lstHandover.clientId %>');
            var lstCustomer = document.getElementById('<%=lstCustomer.clientId %>');
            lstLocation.value = document.getElementById(currentSelectedRow + "_hdnLocation").value;
            lstHandover.value = document.getElementById(currentSelectedRow + "_hdnHandover").value;
            lstCustomer.value = document.getElementById(currentSelectedRow + "_hdnCustomer").value;
            ctrl.parentNode.parentNode.style.backgroundColor = "lightblue";

        }
        function UpdateLocation() {
            if (currentSelectedRow == null) {
                alert("Please select a row");
                return false;
            }
            //            var lstLocation = document.getElementById('<%=lstLocation.clientId %>');
            //            document.getElementById(currentSelectedRow + "_hdnLocation").innerHTML = lstLocation.options[lstLocation.selectedIndex].value;
            //            document.getElementById(currentSelectedRow + "_lblLocation").innerHTML = lstLocation.options[lstLocation.selectedIndex].text;
            //            document.getElementById(currentSelectedRow + "_hdnLocation").value = lstLocation.options[lstLocation.selectedIndex].value;
            //            document.getElementById(currentSelectedRow + "_lblLocation").value = lstLocation.options[lstLocation.selectedIndex].text;
            var lstHandover = document.getElementById('<%=lstHandover.clientId %>');
            document.getElementById(currentSelectedRow + "_hdnHandover").innerHTML = lstHandover.options[lstHandover.selectedIndex].value;
            document.getElementById(currentSelectedRow + "_lblHandover").innerHTML = lstHandover.options[lstHandover.selectedIndex].text;
            document.getElementById(currentSelectedRow + "_hdnHandover").value = lstHandover.options[lstHandover.selectedIndex].value;
            document.getElementById(currentSelectedRow + "_lblHandover").value = lstHandover.options[lstHandover.selectedIndex].text;
            var lstCustomer = document.getElementById('<%=lstCustomer.clientId %>');
            document.getElementById(currentSelectedRow + "_hdnCustomer").innerHTML = lstCustomer.options[lstCustomer.selectedIndex].value;
            document.getElementById(currentSelectedRow + "_lblCustomer").innerHTML = lstCustomer.options[lstCustomer.selectedIndex].text;
            document.getElementById(currentSelectedRow + "_hdnCustomer").value = lstCustomer.options[lstCustomer.selectedIndex].value;
            document.getElementById(currentSelectedRow + "_lblCustomer").value = lstCustomer.options[lstCustomer.selectedIndex].text;
            return true;
        }
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Location Master"
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
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblTerminal" runat="server" class="FormLabel" Text="Terminal ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstTerminal" runat="server" class="ddlMedium" ToolTip="Terminal"
                                                    Width="220px" Style="margin-left: 0px">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnTerminalID" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 20px"></td>
                                        </tr>
                                    </table>
                                    <table width="100%" align="center">
                                        <tr>
                                            <td>
                                                <table cellspacing="0" align="center">

                                                    <tr>
                                                        <td colspan="15" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 240px;">
                                                                <asp:Repeater ID="repLocation" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="Location" cellspacing="0">
                                                                            <tr class="RepheaderNew">
                                                                                <td align="center" style="width=30px;">&nbsp;
                                                                                </td>
                                                                                <td align="center" width="200px" style="height: 20px">
                                                                                    <asp:Label ID="lblSrNo" Width="30px" Text="Sr." runat="server" CssClass="labelHeader" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLocation" Width="150px" runat="server" CssClass="labelHeader" Text='Location<span class="mandatory"> *</span>'></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblHandover" Width="150px" runat="server" CssClass="labelHeader" Text='Handover<span class="mandatory"> *</span>'></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCustomer" Width="150px" runat="server" CssClass="labelHeader" Text='Customer<span class="mandatory"> *</span>'></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="LblrVehicleType" Width="100px" runat="server" CssClass="labelHeader" Text='Vehicle Type<span class="mandatory"> *</span>'></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblToll" Width="80px" runat="server" CssClass="labelHeader" Text="Toll (Rs.)"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lbl20Oil" Width="80px" runat="server" CssClass="labelHeader" Text="20-Oil"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="Lbl20Amt" Width="80px" runat="server" CssClass="labelHeader" Text="20-Cash"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="Lbl40Oil" Width="80px" runat="server" CssClass="labelHeader" Text="40-Oil"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblOilAdvance" Width="80px" runat="server" CssClass="labelHeader"
                                                                                        Text="40-Advance"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="Lbldouble20oil" Width="80px" runat="server" CssClass="labelHeader" Text="Double 20-Oil"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lbldoubletwenty" Width="80px" runat="server" CssClass="labelHeader"
                                                                                        Text="Double 20"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblALadvance" Width="100px" runat="server" CssClass="labelHeader"
                                                                                        Text="Extra"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 12px; background-color: White;">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkSelectedRow" onClick="javascript:GetIdAll(this);" runat="server" />
                                                                            </td>
                                                                            <td class="FormLabel" style="text-align: center; width: 35px; vertical-align: middle;">
                                                                                <%# Container.ItemIndex + 1 %>
                                                                            </td>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnLocationRefId" Value='<%# Eval("LocationRefId") %>' runat="server" />
                                                                                <%-- <asp:TextBox class="Rpttextbox" ID="textLocation" runat="server" Enabled="false"
                                                                                    onkeypress="kp_convert_upper();" MaxLength="60" Text='<%# Eval("LocationName") %>'
                                                                                    Width="200px" ToolTip="Location">
                                                                                </asp:TextBox>--%>
                                                                                <asp:DropDownList CssClass="ddlMedium" Enabled="false" Visible="false" Width="150px"
                                                                                    ID="lstLocation1" runat="server" ToolTip="Location">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnLocation" Value='<%# Eval("LocationId") %>' runat="server" />
                                                                                <asp:Label CssClass="FormLabel" Text='<%# Eval("LocationName") %>' Width="150px"
                                                                                    ID="lblLocation" runat="server" ToolTip="Location">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <%-- <asp:TextBox class="Rpttextbox" ID="textDistance" runat="server" Enabled="false"
                                                                                    onkeypress="kp_numeric();" MaxLength="10" Text='<%# Eval("Distance") %>' Width="105px"
                                                                                    ToolTip="Distance">
                                                                                </asp:TextBox>--%>
                                                                                <asp:DropDownList CssClass="ddlMedium" Enabled="false" Visible="false" Width="150px"
                                                                                    ID="lstHandover" runat="server" ToolTip="HandOver Location">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnHandover" Value='<%# Eval("HandoverLocation") %>' runat="server" />
                                                                                <asp:Label CssClass="FormLabel" Text='<%# Eval("HandoverLocationName") %>' Width="150px"
                                                                                    ID="lblHandover" runat="server" ToolTip="Handover Location">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList CssClass="ddlMedium" Enabled="false" Visible="false" Width="150px"
                                                                                    ID="lstCustomer" runat="server" ToolTip="Customer">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnCustomer" Value='<%# Eval("CustomerId") %>' runat="server" />
                                                                                <asp:Label CssClass="FormLabel" Text='<%# Eval("CustomerName") %>' Width="150px"
                                                                                    ID="lblCustomer" runat="server" ToolTip="Customer Name">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList CssClass="ddlMedium" Enabled="false" Visible="false" Width="100px"
                                                                                    ID="LstVehicleType" runat="server" ToolTip="VehicleType">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="HiddenField1" Value='<%# Eval("VehicleType") %>' runat="server" />
                                                                                <asp:Label CssClass="FormLabel" Text='<%# Eval("VehicleType") %>' Width="150px"
                                                                                    ID="LblVehicleType" runat="server" ToolTip="Customer Name">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textToll" runat="server" Enabled="false" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("Toll") %>' Width="80px" ToolTip="Distance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="text20oil" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("Oil20") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("AdvanceRs") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="Text40Oil" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("Oil40") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textOilAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("OilAdvance") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="TextDouble20oil" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("Double20Oil") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textDoubleTwenty" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("DoubleTwenty") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="Rpttextbox" ID="textALAdvance" runat="server" onkeypress="kp_numeric();"
                                                                                    MaxLength="10" Text='<%# Eval("AlAdvance") %>' Width="80px" ToolTip="Advance">
                                                                                </asp:TextBox>
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
                                                    <tr>
                                                        <td height="10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:DropDownList CssClass="ddlMedium" Width="185px" ID="lstLocation" runat="server"
                                                                ToolTip="Location">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList CssClass="ddlMedium" Width="150px" ID="lstHandover" runat="server"
                                                                ToolTip="Handpver Location">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList CssClass="ddlMedium" Width="150px" ID="lstCustomer" runat="server"
                                                                ToolTip="Customer">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList CssClass="ddlMedium" Width="150px" ID="LstVehicleType" runat="server"
                                                                ToolTip="Customer">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAddRow" runat="server" Text="Add Row" CssClass="FormButton" />

                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnChange" runat="server" alt="Update" Text="Update" CssClass="FormButton" OnClientClick="javascript:return UpdateLocation();" />
                                                            <%--   <img id="" runat="server" alt="Update" onclick="javascript:return UpdateLocation();" src="~/Images/btnUpdate.png" />--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:TextBox class="Rpttextbox" ID="textOilAdvance" runat="server" onkeypress="kp_numeric();"
                                                                MaxLength="10" Text='<%# Eval("OilAdvance") %>' Width="80px" ToolTip="Advance">
                                                            </asp:TextBox>--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:TextBox class="Rpttextbox" ID="textDoubleTwenty" runat="server" onkeypress="kp_numeric();"
                                                                MaxLength="10" Text='<%# Eval("DoubleTwenty") %>' Width="80px" ToolTip="Advance">
                                                            </asp:TextBox>--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:TextBox class="Rpttextbox" ID="textALAdvance" runat="server" onkeypress="kp_numeric();"
                                                                MaxLength="10" Text='<%# Eval("AlAdvance") %>' Width="80px" ToolTip="Advance">
                                                            </asp:TextBox>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td style="vertical-align: top;">
                                <div id="RepScroling" class="RepScroling" style="height: 90%; width: 300px; border-left-color: Black; vertical-align: top;">
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
