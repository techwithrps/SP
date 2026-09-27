<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="VendorContractListApproval.aspx.vb" Inherits="Vendor_VendorContractListApproval"
    Title="eLOGiPark :: Vendor Contract - Handling" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vendor Contract - Handling"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnApprovalMode" runat="server" Value="" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                    <table cellspacing="0" border="0" style="border-color: White;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTerminalName" runat="server" Text="Terminal" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTerminalName" runat="server" ToolTip="Terminal Name" CssClass="RptFormTextBoxMedium"
                                                    Width="150">
                                                </asp:TextBox>
                                            </td>
                                            <td rowspan="2" width="10px">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVendorType" runat="server" Text="Vendor Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVendorType" runat="server" ToolTip="Vendor Type" CssClass="RptFormTextBoxMedium"
                                                    Width="120">
                                                </asp:TextBox>
                                            </td>
                                            <td rowspan="2" width="10px">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVendor" runat="server" Text="Vendor" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVendor" runat="server" ToolTip="Vendor Name" CssClass="RptFormTextBoxMedium"
                                                    Width="200">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnContractId" Value="0" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContractCode" runat="server" Text="Contract Code" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContractCode" runat="server" ToolTip="Rate Reference Code" CssClass="RptFormTextBoxMedium">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEffectiveFrom" runat="server" Text="Effective From" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEffectiveFrom" runat="server" ToolTip="Effective From" CssClass="RptFormTextBoxDate">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEffectiveTo" runat="server" Text="Effective To" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEffectiveTo" runat="server" ToolTip="Effective To" CssClass="RptFormTextBoxDate">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRemark" runat="server" Text="Remark" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left" colspan="4">
                                                <asp:TextBox ID="textRemark" runat="server" ToolTip="Remark" CssClass="FormTextBoxLarg"
                                                    Width="412px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="height: 20px;">
                                            <td colspan="8">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="1">
                                        <tr class="RepHead">
                                            <td>
                                                <asp:CheckBox class="FormLabel" Width="20px" ID="chkrSelect" runat="server" ToolTip="Select">
                                                </asp:CheckBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrFromDate" Width="80px" runat="server" CssClass="FormLabel" Text="From Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrToDate" Width="80px" CssClass="FormLabel" runat="server" Text="To Date"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblRdUomCode" Width="90px" runat="server" Text="UOM" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblRddService" Width="150px" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>
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
                                                <div id="dvdetails" class="RepScroling" runat="server" style="height: 160px;">
                                                    <asp:Repeater ID="repVendorContractDetails" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont" cellspacing="0" style="margin-left: -7px; margin-right: -7px;">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox class="FormLabel" Width="20px" ID="chkSelect" runat="server" ToolTip="Select">
                                                                    </asp:CheckBox>
                                                                    <asp:HiddenField ID="hdnContractId" Value='<%# Eval("ContractId") %>' runat="server" />
                                                                    <asp:HiddenField ID="hdnContractRefId" Value='<%# Eval("ContractRefId") %>' runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textrFromDate" runat="server" Width="80px" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="From Date (DD/MM/YYYY)" Text='<%# Eval("FromDate") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textrToDate" runat="server" Format="dd/MM/yyyy" Width="80px" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="To Date(DD/MM/YYYY)" Text='<%# Eval("ToDate") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="91px" ID="textUomId" runat="server"
                                                                        Text="" ToolTip="Unit Of Measurement">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="155px" ID="textServiceId" runat="server"
                                                                        Text="" ToolTip="Service">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="80px" ID="textDocType" runat="server"
                                                                        Text="" ToolTip="Doc. Type">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="50px" ID="textContSize" runat="server"
                                                                        Text="" ToolTip="Cont Size">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="60px" ID="textContStatus" runat="server"
                                                                        Text="" ToolTip="Cont Status">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="60px" ID="textContType" runat="server"
                                                                        Text="" ToolTip="Cont Type">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="60px" ID="textImoCode" runat="server"
                                                                        Text="" ToolTip="IMO Code">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="60px" ID="textFromRange" runat="server"
                                                                        Text='<%# Eval("FromRange") %>' ToolTip="From Range"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="60px" ID="textToRange" runat="server"
                                                                        Text='<%# Eval("ToRange") %>' ToolTip="To Range"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox class="RptFormTextBoxMedium" Width="80px" ID="textRate" runat="server"
                                                                        Text='<%# Eval("Rate") %>' ToolTip="Rate"></asp:TextBox>
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:ImageButton ID="btnApproved" runat="server" ImageUrl="~/Images/btnApprove.png" />
                                                <asp:ImageButton ID="btnDisapproved" runat="server" ImageUrl="~/Images/btnNotApprove.png" />
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
