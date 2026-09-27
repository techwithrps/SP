<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="VendorContract.aspx.vb" Inherits="Vendor_VendorContract" Title="eLOGiPark :: Vendor Contract - Handling"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript" language="javascript">
        function getAllFromDate() {
            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;
                var FromDate = document.getElementById("<%=textEffectiveFrom.clientid%>").getAttribute("value");
                if (FromDate != null && FromDate != '') {
                    for (var j = 0; j < rowCount; j++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textrFromDate").setAttribute("value", FromDate);
                    }
                }
            }
        }
        function getAllToDate() {
            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;
                var ToDate = document.getElementById("<%=textEffectiveTo.clientid%>").getAttribute("value");
                if (ToDate != null && ToDate != '') {
                    for (var j = 0; j < rowCount; j++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textrToDate").setAttribute("value", ToDate);
                    }
                }
            }
        }
    </script>
    <table width="100%" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: 0px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vendor Contract - Handling"
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
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table cellspacing="0" border="0">
                                        <tr style="width: 100%;">
                                            <td>
                                                <table cellspacing="0" border="0" style="border-color: White;">
                                                    <tr style="width: 100%;">
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblTerminalName" runat="server" Text="Terminal " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:DropDownList ID="lstTerminalName" runat="server" ToolTip="Terminal Name" CssClass="FormListBoxMedium"
                                                                Width="100">
                                                            </asp:DropDownList>
                                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:DropDownList ID="lstVendorType" runat="server" AutoPostBack="true" ToolTip="Vendor Type"
                                                                CssClass="FormListBoxMedium" Width="120">
                                                            </asp:DropDownList>
                                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblVendor" runat="server" Text="Vendor " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstVendor" runat="server" ToolTip="Vendor Name" CssClass="FormListBoxMedium"
                                                                        Width="150">
                                                                    </asp:DropDownList>
                                                                    <span class="mandatory" style="vertical-align: top;">*</span>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstVendorType" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:HiddenField ID="hdnContractId" Value="0" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblContractCode" runat="server" Text="Rate Ref. Code " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="textContractCode" onkeypress="kp_convert_upper()" runat="server"
                                                                ToolTip="Rate Reference Code" CssClass="FormTextBoxMedium">
                                                            </asp:TextBox>
                                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblEffectiveFrom" runat="server" Text="Effective From " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="textEffectiveFrom" runat="server" ToolTip="Effective From" onChange="getAllFromDate();"
                                                                CssClass="FormTextBoxDate">
                                                            </asp:TextBox>
                                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="textEffectiveFrom" />
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label2" runat="server" Text="Effective To " CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox ID="textEffectiveTo" runat="server" ToolTip="Effective To" onChange="getAllToDate();"
                                                                CssClass="FormTextBoxDate">
                                                            </asp:TextBox>
                                                            <span class="mandatory" style="vertical-align: top;">*</span>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="textEffectiveTo" />
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 20px;">
                                                        <td colspan="">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellspacing="1">
                                                    <tr class="RepHead">
                                                        <td align="center">
                                                            <asp:Label ID="lblRdSelect" Width="22px" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrFromDate" Width="80px" runat="server" CssClass="FormLabel" Text=" From Date<span class='mandatory'>*</span>"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrToDate" Width="80px" CssClass="FormLabel" runat="server" Text="To Date"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdUomCode" Width="90px" runat="server" Text="UOM" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRddService" Width="145px" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdDocument" Width="80px" runat="server" Text="Doc Type" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdContSize" Width="50px" runat="server" Text="Size" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdContStatus" Width="60px" runat="server" Text="Status" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdContType" Width="60px" runat="server" Text="Cont Type" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdIMO" Width="60px" runat="server" Text="IMO" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdFromRange" Width="60px" runat="server" Text="From Range" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdToRange" Width="60px" runat="server" Text="To Range" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRdRate" Width="80px" runat="server" Text="Rate" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td width="16px" style="background-color: White;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="14" valign="top" align="center">
                                                            <div id="dvdetails" class="RepScroling" runat="server" style="height: 198px;">
                                                                <asp:Repeater ID="repRateDetails" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont" cellspacing="0" style="margin-left: -6px; margin-right: -6px;">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox class="FormLabel" Width="20px" ID="chkSelect" runat="server" ToolTip="Select">
                                                                                </asp:CheckBox>
                                                                                <asp:HiddenField ID="hdnContractId" Value='<%# Eval("ContractId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnTerminalId" Value='<%# Eval("TerminalId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnContractRefId" Value='<%# Eval("ContractRefId") %>' runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textrFromDate" runat="server" Width="80px" CssClass="FormTextBoxSmall"
                                                                                    ToolTip="From Date (DD/MM/YYYY)" Text='<%# Eval("FromDate") %>'>
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                                                                    TargetControlID="textrFromDate">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textrToDate" runat="server" Format="dd/MM/yyyy" Width="80px" CssClass="FormTextBoxSmall"
                                                                                    ToolTip="To Date(DD/MM/YYYY)" Text='<%# Eval("ToDate") %>'>
                                                  
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="clToDate" runat="server" TargetControlID="textrToDate">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="95px" ID="lstUomId" runat="server"
                                                                                    Text='<%# Eval("UomId") %>' OnDataBinding="prepareUom" ToolTip="Unit Of Measurement">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="153px" ID="lstServiceId" runat="server"
                                                                                    Text='<%# Eval("ServiceId") %>' OnDataBinding="prepareService" ToolTip="Service">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="84px" ID="lstDocId" runat="server"
                                                                                    Text='<%# Eval("DocType") %>' ToolTip="Doc. Type">
                                                                                    <asp:ListItem Value="A" Text="---ALL---"></asp:ListItem>
                                                                                    <asp:ListItem Value="I" Text="IMPORT"></asp:ListItem>
                                                                                    <asp:ListItem Value="E" Text="EXPORT"></asp:ListItem>
                                                                                    <asp:ListItem Value="D" Text="DOMESTIC"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="54px" ID="lstContSize" runat="server"
                                                                                    Text='<%# Eval("ContSize") %>' ToolTip="Cont Size">
                                                                                    <asp:ListItem Value="A" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                                    <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                                    <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="64px" ID="lstContStatus" runat="server"
                                                                                    Text='<%# Eval("ContStatus") %>' ToolTip="Cont Status">
                                                                                    <asp:ListItem Value="A" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="E" Text="Empty"></asp:ListItem>
                                                                                    <asp:ListItem Value="L" Text="Laden"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="64px" ID="lstContType" runat="server"
                                                                                    Text='<%# Eval("ContType") %>' OnDataBinding="prepareContType" ToolTip="Cont Type">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxMedium" Width="64px" ID="lstImoId" runat="server"
                                                                                    Text='<%# Eval("ImoCode") %>' ToolTip="IMO Code">
                                                                                    <asp:ListItem Value="A" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="H" Text="HAZ" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Value="N" Text="NON-HAZ"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="60px" onkeypress="kp_integer();" ID="textFromRange"
                                                                                    runat="server" Text='<%# Eval("FromRange") %>' ToolTip="From Range"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="60px" onkeypress="kp_integer();" ID="textToRange"
                                                                                    runat="server" Text='<%# Eval("ToRange") %>' ToolTip="To Range"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="80px" onkeypress="kp_integer();" ID="textRate"
                                                                                    runat="server" Text='<%# Eval("Rate") %>' ToolTip="Rate"></asp:TextBox>
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
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="btnAddRow" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnDeleteRow" runat="server" ImageUrl="~/Images/btnDelete.png" />
                                            </td>
                                        </tr>
                                        <tr style="margin-top: 0px;">
                                            <td align="center" style="width: 80%">
                                                <asp:ImageButton ID="btnUpdate" runat="server" Visible="false" ImageUrl="~/Images/btnUpdate.png" />
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnEdit" Visible="false" runat="server" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnListAll" runat="server" ImageUrl="~/Images/btnShow.png" />
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
