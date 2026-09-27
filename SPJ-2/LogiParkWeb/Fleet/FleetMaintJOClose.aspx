<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetMaintJOClose.aspx.vb" Inherits="Fleet_FleetMaintJOClose"
    Title="eLOGiFleet :: Job Order Closing" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript">
        function GetItemId(ctrl) {
            if (ctrl.value != '') {
                try {
                    PageMethods.GetItemsDetailsByItemName(ctrl.value, onSucess, onError);
                    function onSucess(result) {
                        //alert(result);
                        var dtls = result;
                        if (dtls == 'N') {
                            alert('Item Does Not Exist!');
                            return;
                        }
                        if (dtls != '') {
                            var AllDetails = dtls.split('%');
                            var currentRow = ctrl.id.toString().replace('_textItem', '');
                            document.getElementById(currentRow + "_hdnItemId").value = AllDetails[1];
                            document.getElementById(currentRow + "_hdnItemCost").value = AllDetails[2];
                            document.getElementById(currentRow + "_txtRate").value = AllDetails[2];
                            document.getElementById(currentRow + "_hdnChangeStatus").value = "Y";


                        } else {
                            alert('Item details not updated!');
                            return;
                        }
                    }
                    function onError(result) {
                        alert('Something wrong.');
                        return;
                    }
                }
                catch (e) {
                    alert('failed to call web service. Error: ' + e);
                }
            }
        }

    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Maintenance Job Order Close"
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
                        <tr class="UserControls" style="height: 350px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVehiclNo" runat="server" CssClass="label" Text="Vehicle No"></asp:Label>
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
                                                <asp:TextBox ID="textJoDate" runat="server" Width="110px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoValidity" runat="server" CssClass="label" Text="Jo Validity"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoValidity" runat="server" Width="110px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoType" runat="server" CssClass="label" Text="Jo No"></asp:Label>
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
                                                <asp:TextBox ID="textVehicleType" runat="server" Width="110px" CssClass="Rpttextbox"
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
                                                <asp:TextBox ID="textJoFor" runat="server" Width="110px" CssClass="Rpttextbox">
                                                   
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
                                                <asp:TextBox ID="textContactNo" runat="server" Width="110px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAdvance" runat="server" CssClass="label" Text="Advance Refund"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstAdvance" runat="server" Width="170px" CssClass="ddlMedium">
                                                    <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Adjust from Salary" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Adjust from Job Order" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Close" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblRemark" runat="server" CssClass="label" Text="Remark"></asp:Label>
                                            </td>
                                            <td colspan="3" style="text-align: left">
                                                <asp:TextBox ID="textNote" runat="server" Width="230px" Height="35px" TextMode="MultiLine"
                                                    CssClass="textbox" ToolTip="Note">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="text-align: center">
                                            <td colspan="6" class="RepHeadFleet">
                                                <asp:Label ID="Label7" runat="server" CssClass="labelHeader" Text="JO Close Details"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotal" runat="server" CssClass="label" Text="Total Advance"></asp:Label>
                                            </td>
                                            <td colspan="6" style="text-align: left">
                                                <asp:TextBox ID="textAdvanceTotal" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                                    Width="90px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Balance Advance"></asp:Label>
                                                <asp:TextBox ID="textBalAdvance" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                                    Width="90px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                                <asp:Label ID="lblCLosingAmount" runat="server" CssClass="label" Text="JO Close Amount"></asp:Label>
                                                <asp:TextBox ID="textClosAmt" onkeypress="kp_integer()" AutoPostBack="true" MaxLength="6"
                                                    runat="server" Width="90px" CssClass="textbox" Enabled="false">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="NO of Items"></asp:Label>
                                                <asp:TextBox ID="txtNoOfItems" onkeypress="kp_integer()" MaxLength="6" AutoPostBack="true"
                                                    runat="server" Width="50px" CssClass="textbox" Enabled="false">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- <table width="100%">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <table cellspacing="0">
                                                    <tr class="RepheaderNew" align="center" width="200px" style="height:20px">
                                                        <td>
                                                            <asp:Label ID="lblrItemNo" Width="160px" runat="server" CssClass="labelHeader" Text="Item"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAvlQnty" runat="server" CssClass="labelHeader" Width="70px" Text="Avl Qnty"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBalQnty" runat="server" CssClass="labelHeader" Width="70px" Text="Qnty"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" CssClass="labelHeader" Width="70px" Text="Part 1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" CssClass="labelHeader" Width="70px" Text="Part 2"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" CssClass="labelHeader" Width="70px" Text="Part 3"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" CssClass="labelHeader" Width="70px" Text="Part 4"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" CssClass="labelHeader" Width="70px" Text="Part 5"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 170px;">
                                                                <asp:Repeater ID="rpItem" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstItem" runat="server" AutoPostBack="true" OnDataBinding="prepareItem"
                                                                                    OnSelectedIndexChanged="FillItemDetails" CssClass="ddlMedium" SelectedValue='<%# Eval("ItemId") %>'
                                                                                    Width="160px">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnItemId" Value='<%# Eval("ItemId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnJoDtlsId" Value='<%# Eval("JoDtlsId") %>' runat="server" />
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textAvlQnty" runat="server" Text='<%# Eval("AvlQnty") %>' CssClass="Rpttextbox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textQnty" runat="server" Text='<%# Eval("CloseQnty") %>' CssClass="textbox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPart1" runat="server" Text='<%# Eval("Part1") %>' CssClass="textBox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPart2" runat="server" Text='<%# Eval("Part2") %>' CssClass="textBox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPart3" runat="server" Text='<%# Eval("Part3") %>' CssClass="textBox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPart4" runat="server" Text='<%# Eval("Part4") %>' CssClass="textBox"
                                                                                    Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPart5" runat="server" Text='<%# Eval("Part5") %>' CssClass="textBox"
                                                                                    Width="70px">
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
                                                </table>
                                            </td>
                                        </tr>
                                    </table>--%>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <table cellspacing="0">
                                                    <tr class="RepheaderNew" align="center" style="height: 20px">
                                                        <td colspan="4">
                                                            <asp:Label ID="lblrItemNo" Width="260px" runat="server" CssClass="labelHeader" Text="Item"></asp:Label>
                                                        </td>
                                                         <td colspan="2">
                                                            <asp:Label ID="Label2" Width="260px" runat="server" CssClass="labelHeader" Text="Item Group Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblBalQnty" runat="server" CssClass="labelHeader" Width="70px" Text="Qnty"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRate" runat="server" CssClass="labelHeader" Width="70px" Text="Rate"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="8" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 170px;">
                                                                <asp:Repeater ID="rpItem" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td colspan="4">
                                                                                <%-- <asp:DropDownList ID="lstItem" runat="server" AutoPostBack="true" OnDataBinding="prepareItem"
                                                                                    OnSelectedIndexChanged="FillItemDetails" CssClass="ddlMedium" SelectedValue='<%# Eval("ItemId") %>'
                                                                                    Width="160px">
                                                                                </asp:DropDownList>
                                                                                <asp:HiddenField ID="hdnItemId" Value='<%# Eval("ItemId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnJoDtlsId" Value='<%# Eval("JoDtlsId") %>' runat="server" />--%>
                                                                                <asp:HiddenField ID="hdnJoDtlsId" Value='<%# Eval("JoDtlsId") %>' runat="server" />
                                                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="260px" ID="textItem" onchange="javascript:GetItemId(this);"
                                                                                    runat="server" MaxLength="11" ToolTip="Item" Text='<%# Eval("ItemName") %>'></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnItemId" Value='<%# Eval("ItemId") %>' runat="server" />
                                                                                <ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchCustomers" MinimumPrefixLength="2"
                                                                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="textItem"
                                                                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" ServicePath="~/Fleet/FleetMaintJOClose.aspx">
                                                                                </ajaxToolkit:AutoCompleteExtender>
                                                                                <asp:HiddenField ID="hdnItemCost" runat="server" Value='<%# Eval("JoPrice") %>' />
                                                                                <asp:HiddenField ID="hdnChangeStatus" runat="server" Value="N" />
                                                                            </td>
                                                                             <td colspan="2">
                                                                              <asp:HiddenField ID="hdnItemGroupId" runat="server" Value='<%# Eval("ItemGroupId") %>' />
                                                                                <asp:TextBox CssClass="FormTextBoxSmall" Enabled="false" Width="260px" ID="txtItemGroupName" 
                                                                                    runat="server" MaxLength="11" ToolTip="Item Group Name"></asp:TextBox>
                                                                              </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textQnty" OnTextChanged="checkQnty" AutoPostBack="true" runat="server"
                                                                                    Text='<%# Eval("CloseQnty") %>' CssClass="textbox" Width="70px">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="txtRate" runat="server" Text='<%# Eval("JoPrice") %>' CssClass="textbox"
                                                                                    Width="70px">
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
                                                </table>
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
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnSearch" runat="server" Text="search" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                                <asp:Button ID="btnPrint" runat="server" Text="Print" Visible="false" CssClass="FormButton" />
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
