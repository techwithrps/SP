<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExpenseEntry.aspx.vb" MasterPageFile="~/MasterPage.master"
    Inherits="Fleet_ExpenseEntry" Title="eLOGiFleet :: Expense Entry" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript" language="javascript">
        var previousSelectedRow = null;
        var currentSelectedRow = null;
        function GetIdAll(ctrl) {
            try {
                if (previousSelectedRow != ctrl.id.toString()) {
                    document.getElementById(previousSelectedRow).checked = false;
                    //document.getElementById(previousSelectedRow).parentNode.
                }
            } catch (e) {

            }
            currentSelectedRow = ctrl.id.toString();
            previousSelectedRow = currentSelectedRow;
            currentSelectedRow = currentSelectedRow.replace('_chkSelect', '');
            document.getElementById('<%=hdnTripId.ClientID %>').value = document.getElementById(currentSelectedRow + "_hdnTripId").value;
            document.getElementById('<%=hdnJoType.ClientID %>').value = document.getElementById(currentSelectedRow + "_hdnJoType").value;
            document.getElementById('<%=hdnVehicleNo.ClientID %>').value = document.getElementById(currentSelectedRow + "_textVehicleNo").value;
            document.getElementById('<%=hdnIsSelected.ClientID %>').value = "Y";

            if (ctrl.checked == false) {
                document.getElementById('<%=hdnTripId.ClientID %>').value = "0";
                document.getElementById('<%=hdnJoType.ClientID %>').value = "0";
                document.getElementById('<%=hdnIsSelected.ClientID %>').value = "0";
                document.getElementById('<%=hdnVehicleNo.ClientID %>').value = "";
            }
        }
        window.onload = function () {
            document.onkeydown = function (e) {
                return (e.which || e.keyCode) != 116;
            };
        }
        //        window.onbeforeunload = function () { return True; }
    </script>
    <style type="text/css">
        .whenout {
            background-color: Green;
        }

        .whenTripClose {
            background-color: Red;
        }
    </style>
    <asp:Label ID="lblScreenTitle" runat="server" Text="Expense Entry" Width="400px" CssClass="FormLabelTitle">
    </asp:Label>

    <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
    <br />
    <hr />

    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Vehicle No" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textVehicleNo" runat="server" ToolTip="From Date" CssClass="FormTextBoxSmall"
                                Width="90px" MaxLength="10">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Cont No" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContNo" runat="server" ToolTip="From Date" CssClass="FormTextBoxSmall"
                                Width="90px" MaxLength="11">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>

                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="FormTextBoxDate"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>

                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>

        
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div id="dvMain" runat="server" style="height: 400px; width: 100%;">
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">

                        <tr>
                            <td colspan="12">
                                <div style="height: 150px; overflow-x: hidden;">
                                    <asp:Repeater ID="rcExpenseEntry" runat="server">
                                        <HeaderTemplate>
                                            <table id="cont1" cellspacing="0" width="100%">
                                                <tr class="RepHead">
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="" Width="20px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrVehicleNo" runat="server" Text="GR/JO No" Width="80px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrSize" runat="server" Text="GR/JO Date" Width="150px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrContNo" runat="server" Text="Vehicle No" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrContSizeType" runat="server" Text="Vh Type" Width="45px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrCustomer" runat="server" Text="Container No" Width="100px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrLocation" runat="server" Text="Size-Type" Width="60px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrDocType" runat="server" Text="Customer" Width="190px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblGateout" runat="server" Text="Location" Width="150px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblCash" runat="server" Text="Doc Type" Width="60px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LblRemark" runat="server" Text="Remark" Width="130px"></asp:Label>
                                                    </td>
                                                    <td style="width: 15px; background-color: White"></td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr id="trRowColor" runat="server">
                                                <td>
                                                    <asp:HiddenField ID="hdnTripId" Value='<%# Eval("TRIP_ID") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnJoType" Value='<%# Eval("JO_TYPE") %>' runat="server" />
                                                    <asp:HiddenField ID="hdnIsTripClose" Value='<%# Eval("IS_T_CLOSE") %>' runat="server" />
                                                    <asp:CheckBox ID="chkSelect" Width="20px" onClick="javascript:GetIdAll(this);" runat="server" Text=""></asp:CheckBox>

                                                </td>
                                                <td>
                                                    <asp:Label CssClass="label" Width="80px" ID="textGRNo" runat="server" ToolTip="GR Number" Text='<%# Eval("GR_NO") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblGrDate" Width="150px" ID="textGrDate" runat="server" ToolTip="GR Date" Text='<%# Eval("GR_DATE") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblVehicleNumber" Width="100px" ID="textVehicleNo" runat="server" ToolTip="Vehicle Number" Text='<%# Eval("VEHICLE_NO") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblVehicleType" Width="45px" ID="textVehicleType" runat="server" ToolTip="Vehicle Type" Text='<%# Eval("VEHICLE_TYPE") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblContainerNo" Width="100px" ID="textContNum" runat="server" ToolTip="Container Number" Text='<%# Eval("CONT_NO") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblContSize" Width="60px" ID="textContSZ" runat="server" ToolTip="Container Size" Text='<%# Eval("CONT_SIZE") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblCustomer" Width="190px" ID="textCustomer" runat="server" ToolTip="Customer Name" Text='<%# Eval("CUSTOMER") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblLocation" Width="150px" ID="textLocation" runat="server" ToolTip="Location Name" Text='<%# Eval("LOCATION") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="lblDocType" Width="60px" ID="textDocType" runat="server" ToolTip="Document Type:Import/Export/Domestic/Pft/Empty"
                                                        Text='<%# Eval("DOC_TYPE") %>'>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label CssClass="label" Width="130px" ID="textREMARK" runat="server" ToolTip="Remarks" Text='<%# Eval("REMARK") %>'>
                                                    </asp:Label>
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
                        <tr class="RepHead">
                            <td colspan="12" style="background-color: White">
                                <table  cellspacing="0" cellpadding="0">
                                    <tr class="RepHead">
                                        <td style="width: 182px">
                                            <asp:Label ID="Label3" runat="server" Text="Service" Width="180px" ForeColor="Black"></asp:Label>
                                            <asp:HiddenField ID="hdnTripId" Value="0" runat="server" />
                                            <asp:HiddenField ID="hdnVehicleNo" Value="0" runat="server" />
                                            <asp:HiddenField ID="hdnJoType" Value="" runat="server" />
                                            <asp:HiddenField ID="hdnIsSelected" Value="0" runat="server" />
                                        </td>
                                      
                                        <td>
                                            <asp:Label ID="lblVendor" runat="server" Text="Vendor" Width="130px" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBillNo" runat="server" Text="Bill No" Width="100px" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAmount" runat="server" Text="Amount" Width="100px" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Remarks" Width="200px" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="20">
                                            <div style="height: 150px; overflow: auto;">
                                                <asp:Repeater ID="repCostDtls" runat="server">
                                                    <HeaderTemplate>
                                                        <table id="cont1" cellspacing="0" width="97%">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td align="left" width="20px">
                                                                <asp:HiddenField ID="hdnTripId" Value='<%# Eval("TRIP_ID") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnCostDtls" Value='<%# Eval("COST_DTLS_ID") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnJoType" Value='<%# Eval("JO_TYPE") %>' runat="server" />
                                                                <asp:DropDownList ID="lstService" runat="server" Width="180px" CssClass="FormListBoxSmall"
                                                                    OnDataBinding="prepareService" ToolTip="Service">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("SERVICE_ID") %>' runat="server" />
                                                            </td>
                                                            
                                                            <td>
                                                                <asp:DropDownList ID="lstVendor" runat="server" Width="140px" CssClass="FormListBoxSmall"
                                                                    OnDataBinding="prepareVendor" ToolTip="Driver">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="100px" ID="textBillNo" runat="server" MaxLength="100"
                                                                    Text='<%# Eval("BILL_NO")%>' ToolTip="To Range"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="100px" ID="textAmount" runat="server" MaxLength="9"
                                                                    Text='<%# Eval("AMOUNT") %>' ToolTip="To Range"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="filterAmount" runat="server" FilterType="Numbers, Custom"
                                                                    ValidChars="." TargetControlID="textAmount" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="200px" ID="textRemarks" runat="server" ToolTip="Container Number"
                                                                    Text='<%# Eval("REMARKS") %>'>
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
                        <tr style="margin-top: 0px;">
                            <td colspan="20" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAdd" Visible="false" runat="server" Text="Add" CssClass="FormButton" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                <asp:Button ID="btnExit" Visible="false" runat="server" Text="Exit" CssClass="FormButton" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
