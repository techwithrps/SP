<%@ Page Title="eLOGiFleet::Driver Attach Detach" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DriverAttachDetach.aspx.vb" Inherits="DriverAttachDetach"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">

    </script>
    <script type="text/javascript" language="javascript">
        var previousSelectedRow = null;
        var currentSelectedRow = null;

        function FillDeatils(ctrl) {
            var selectedText = document.getElementById('<%= lstVehicleNo.ClientID %>').options[document.getElementById('<%= lstVehicleNo.ClientID %>').selectedIndex].innerHTML;
            var selectedValue = document.getElementById('<%= lstVehicleNo.ClientID %>').value;
            var IsAquired = parseInt(document.getElementById(ctrl.id.toString().replace('_chkSelect', '') + "_hdnSelectedPositionId").value);
            if (IsAquired > 0 && (IsAquired != parseInt(selectedValue))) {
                ctrl.checked = false;
                alert('First Clear this!');
                return;
            }
            if (ctrl.checked == false) {
                ClearThisRow(document.getElementById(ctrl.id.toString().replace('_chkSelect', '') + "_linkClear"));
                lblItemName.value = ""
                return;
            }


            if (selectedValue == '' || selectedValue == '0') {
                ctrl.checked = false;
                alert('Please select a Vehicle!');
                return;
            }

            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;

                for (var j = 0; j < rowCount; j++) {
                    var hdnItemId = document.getElementById("ctl00_ContentPlaceHolder1_repDetachedList_ctl" + LPad((j + 1) + "", 2, "0") + "_hdnSelectedPositionId").value;
                    if (selectedValue == hdnItemId) {
                        alert('Duplicate Selection!');
                        ctrl.checked = false;
                        return;
                    }
                }
            }

            try {
                if (previousSelectedRow != ctrl.id.toString()) {
                    document.getElementById(previousSelectedRow).checked = false;
                }
            } catch (e) {

            }

            currentSelectedRow = ctrl.id.toString();
            previousSelectedRow = currentSelectedRow;
            currentSelectedRow = currentSelectedRow.replace('_chkSelect', '');
            var selectedText = document.getElementById('<%= lstVehicleNo.ClientID %>').options[document.getElementById('<%= lstVehicleNo.ClientID %>').selectedIndex].innerHTML;
            var selectedValue = document.getElementById('<%= lstVehicleNo.ClientID %>').value;

            var lblItemName = document.getElementById(currentSelectedRow + "_textPosition");
            var hdnSelectedPositionId = document.getElementById(currentSelectedRow + "_hdnSelectedPositionId");
            lblItemName.value = selectedText;
            hdnSelectedPositionId.value = selectedValue;
            ctrl.parentNode.parentNode.style.backgroundColor = "lightblue";
            //            if (selectedValue != '' && selectedValue != '0') {
            //                try {
            //                    PageMethods.GetItemDeatils(selectedValue, onSucess, onError);
            //                    function onSucess(result) {
            //                        var dtls = result;
            //                        if (dtls != '') {
            //                            var AllDetails = dtls.split(',');

            //                            textAvlQnty.value = AllDetails[0];
            //                            textPart1.value = AllDetails[1];

            //                        } else {
            //                            alert('Item not Found!');
            //                            return;
            //                        }
            //                    }
            //                    function onError(result) {
            //                        alert('Something wrong.');
            //                        return;
            //                    }
            //                }
            //                catch (e) {
            //                    alert('failed to call web service. Error: ' + e);
            //                }
            //            }
        }
        function ClearThisRow(ctrl) {
            var selectedRow = ctrl.id.toString();
            selectedRow = selectedRow.replace('_linkClear', '');
            var hdnSelectedPositionId = document.getElementById(selectedRow + "_hdnSelectedPositionId");
            var chkSelect = document.getElementById(selectedRow + "_chkSelect");
            var textPosition = document.getElementById(selectedRow + "_textPosition");
            textPosition.readOnly = false;
            chkSelect.checked = false;
            textPosition.value = "";
            hdnSelectedPositionId.value = "0";
            return false;
        }

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 30%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Driver-Vehicle Mapping" Width="250px"
                    CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 70%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <hr />
            </td>
        </tr>
    </table>
    <table style="width: 100%; margin-right: 0px;">
        <tr>
            <td style="height: 100%" valign="top">
                <table>
                    <tr>
                        <td style="width: 924%;" align="center">
                            <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <div style="width: 100%; vertical-align: top;">
                                                <table width="100%">
                                                    <%--<tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblBedVehicle" runat="server" Text="Bed/Vehicle" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:DropDownList ID="LstEquipmentType" runat="server" CssClass="ddlMedium">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Value="B">BED</asp:ListItem>
                                                              
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblBedVehicleNO" runat="server" Text="Bed/Vehicle No." CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="TextBedVehicleNO" Enabled="false" runat="server" CssClass="RptFormTextBoxMedium"
                                                                ToolTip="EquipmentNo" Width="100">
                                                            </asp:TextBox>
                                                            <asp:Button ID="BtnSearchEquipment" runat="server" Text="Search" CssClass="FormButton" />
                                                            <asp:HiddenField ID="HdnEquipmentId" runat="server" Value="0" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="LblEquipmentType" runat="server" Text="EquipmentType " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="textEquipmentType" Enabled="false" runat="server" CssClass="RptFormTextBoxMedium"
                                                                ToolTip="From Terminal" Width="180"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblNoOfTires" runat="server" Text="No Of Tires" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="textNoOfTires" Enabled="false" runat="server" CssClass="RptFormTextBoxMedium"
                                                                ToolTip="To Terminal" Width="180">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lbldDriverName" runat="server" CssClass="FormLabel" Text="Vehicle No"></asp:Label>
                                                        </td>
                                                        <td colspan="3" align="left">
                                                            <asp:DropDownList ID="lstVehicleNo" runat="server" Width="200px" CssClass="FormListBoxSmall">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <asp:TextBox ID="txtVehiclNo" runat="server" Width="100px" text-align="right" AutoPostBack="true"
                                                            CssClass="FormTextBoxMedium"></asp:TextBox>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" height="40px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <div style="width: 100%; vertical-align: middle; height: 300px;">
                                                                <table cellspacing="0">
                                                                    <tr class="Repheader">
                                                                        <td align="center" colspan="5">
                                                                            <asp:Label ID="lblInventoryList" Width="260px" runat="server" Text="Inventory List "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="Repheader">
                                                                        <td align="center">
                                                                            <asp:Label ID="lbldlSelect" Width="10px" runat="server" Text=" "></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lbldlTireNo" Width="80px" runat="server" Text="Driver ID"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label2" Width="80px" runat="server" Text="Driver Code"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label3" Width="100px" runat="server" Text="Driver Name"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lbldlPositon" Width="200px" runat="server" Text="Vehicle No"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="5">
                                                                            <div style="height: 240px; overflow: auto;">
                                                                                <asp:Repeater ID="repDetachedList" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <table id="cont1" cellspacing="0">
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:CheckBox ID="chkSelect" runat="server" Enabled="true" onClick="javascript:FillDeatils(this);"
                                                                                                    Checked="false" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label class="RptFormTextBoxLarg" Width="80px" ID="textTireNo" runat="server"
                                                                                                    Enabled="false" Text='<%# Eval("DriverId") %>' ToolTip="Wagon No"></asp:Label>
                                                                                                <asp:HiddenField ID="hdnDriverId" Value='<%# Eval("DriverId") %>' runat="server" />
                                                                                                <asp:HiddenField ID="hdnPositionName" Value="" runat="server" />
                                                                                                <asp:HiddenField ID="hdnSelectedPositionId" Value="0" runat="server" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label class="RptFormTextBoxLarg" Width="70px" ID="txtBedSize" runat="server"
                                                                                                    Enabled="false" Text='<%# Eval("EquipmentNo") %>' ToolTip="Wagon No"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <td>
                                                                                                    <%--     <asp:DropDownList CssClass="FormListBoxSmall" Width="100px" ID="lstBedType" runat="server"
                                                                                OnDataBinding="prepareContType" Text='<%# Eval("EquipmentNo") %>' ToolTip="Type">
                                                                            </asp:DropDownList>--%>
                                                                                                    <asp:Label class="RptFormTextBoxLarg" Width="160px" ID="lblequpmentCode" runat="server"
                                                                                                        Enabled="false" Text='<%# Eval("DriverName") %>' ToolTip="Wagon No"></asp:Label>
                                                                                                </td>
                                                                                            </td>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox class="RptFormTextBoxLarg" Width="100px" ID="textPosition" runat="server"
                                                                                                    Enabled="True" ToolTip="Unit No"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="text-align: left">
                                                                                                <asp:LinkButton ID="linkClear" Text="Clear" CssClass="label" runat="server" OnClientClick="javasctipt:return ClearThisRow(this);"
                                                                                                    Width="50px">
                                                                                                </asp:LinkButton>
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
                                                                        <td align="center" colspan="5">
                                                                            <asp:Button ID="btnAttach" runat="server" Visible="false" CssClass="FormButton" Text="Attach" />
                                                                            <asp:Button ID="btnShift" runat="server" Visible="false" CssClass="FormButton" Text="Shift" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td colspan="2" align="center">
                                                            <div style="width: 100%; vertical-align: middle; height: 300px;">
                                                                <table cellspacing="0">
                                                                    <tr class="Repheader">
                                                                        <td align="center" colspan="6">
                                                                            <asp:Label ID="lblalAttachedTireList" Width="310px" runat="server" Text="Attached Driver List"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="Repheader">
                                                                        <td align="center">
                                                                            <asp:Label ID="lblalSelect" Width="10px" runat="server" Text=" "></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblaTirePosition" Width="80px" runat="server" Text="Driver ID"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label4" Width="90px" runat="server" Text="Driver Code"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label5" Width="110px" runat="server" Text="Driver Name"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblaTireNo" Width="110px" runat="server" Text="Vehicle No"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDRemark" Width="200px" runat="server" Text="Remarks"></asp:Label><span
                                                                                class="mandatory" style="vertical-align: top;">*</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="6">
                                                                            <div style="height: 240px; overflow: auto;">
                                                                                <asp:Repeater ID="repAttacedhList" runat="server">
                                                                                    <HeaderTemplate>
                                                                                        <table cellspacing="0">
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:CheckBox ID="chkSelect" runat="server" Checked="false" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox class="RptFormTextBoxMedium" Width="80px" ID="textDetachBedNo" runat="server"
                                                                                                    Enabled="false" Text='<%# Eval("DriverId") %>' ToolTip="Tire Position"></asp:TextBox>
                                                                                                <asp:HiddenField ID="HdnAttachId" Value='<%# Eval("AttachId") %>' runat="server" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label class="RptFormTextBoxLarg" Width="70px" ID="txtDetachBedSize" runat="server"
                                                                                                    Enabled="false" Text='<%# Eval("VehicleSize") %>' ToolTip="Wagon No"></asp:Label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <td>
                                                                                                    <asp:Label class="RptFormTextBoxLarg" Width="160px" ID="textDriverName" runat="server"
                                                                                                        Enabled="false" Text='<%# Eval("DriverName") %>' ToolTip="Wagon No"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Label class="RptFormTextBoxLarg" Width="100px" ID="txtDetachEquipmentNo" runat="server"
                                                                                                        Enabled="false" Text='<%# Eval("EquipmentNo") %>' ToolTip="Wagon No"></asp:Label>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="FormTextBoxLarg" Width="200px" ID="TextrRemark" runat="server"
                                                                                                            ToolTip="Remark"></asp:TextBox>
                                                                                                        <asp:HiddenField ID="hdnDetachEquipmentId" Value='<%# Eval("EquipmentId") %>' runat="server" />
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
                                                                        <td align="center" colspan="6">
                                                                            <asp:Button ID="btnDetach" runat="server" Visible="false" CssClass="FormButton" Text="Detach" />
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
                            </div>
                        </td>
                        <%--<td>
                            <div id="dvTreeView" class="tvScrollStyle" style="height: 377px; width: 349px; overflow: auto;">
                                <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                    Width="144px">
                                </asp:TreeView>
                            </div>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" style="vertical-align: bottom;">
        <tr>
            <td style="width: 120px" align="left">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
            <td align="center" style="width: 80%">
                <asp:Button ID="btnEdit" runat="server" CssClass="FormButton" Text="Edit" Visible="false" />
                <asp:Button ID="btnSave" runat="server" CssClass="FormButton" Text="Save" />
                <asp:Button ID="btnCancel" runat="server" CssClass="FormButton" Text="Cancel" />
                <asp:Button ID="btnExit" runat="server" CssClass="FormButton" Text="Exit" />
            </td>
            <td style="width: 120" align="left">
                <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
