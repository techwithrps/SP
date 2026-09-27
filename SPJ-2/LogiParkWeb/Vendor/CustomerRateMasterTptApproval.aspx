<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CustomerRateMasterTptApproval.aspx.vb" Inherits="Vendor_CustomerRateMasterTpt"
    Title="eLOGiPark :: Rate for Customer - Transportation" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Rate for Customer - Transportation"
                    class="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 500px;">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td style="width: 320px" align="left">
                <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
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
    <table style="width: 100%; height: 80%">
        <tr>
            <td align="left" valign="top">
                <div id="dvMain" runat="server" valign="top">
                    <table width="100%">
                        <tr style="height: 50px;">
                            <td valign="top" width="100%">
                                <div id="dvCustomer" runat="server" valign="top">
                                    <table width="100%">
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblRateCode" runat="server" Text="Rate Ref. Code " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRateCode" onkeypress="kp_convert_upper()" runat="server" ToolTip="Rate Ref. Code"
                                                    CssClass="FormTextBoxMedium" Width="150px">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                                <asp:HiddenField ID="hdnRateTptId" Value="0" runat="server" />
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblBillingCondition" runat="server" Text="Billing Condition " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBillingCondition" runat="server" ToolTip="Billing Condition"
                                                    CssClass="FormListBoxMedium">
                                                    <asp:ListItem Value="1" Text="Container Gross Weight" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Container Net Weight"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Article Based"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="Per Tone"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Non Revenue"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Wagon Gross Weight"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Wagon Net Weight"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTaxGroup" runat="server" CssClass="FormLabel" Text="Tax Group "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstTaxGroup" runat="server" CssClass="FormListBoxMedium" ToolTip="TaxGroup"
                                                    Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCustomerType" runat="server" CssClass="FormLabel" Text="Customer Type "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCustomerType" AutoPostBack="true" runat="server" Width="150px"
                                                    CssClass="FormListBoxLarg" ToolTip="Customer Type" Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="lstCustomerName" runat="server" Enabled="false" ToolTip="Vendor Name"
                                                            CssClass="FormListBoxMedium" Width="150px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="lstCustomerType" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblServiceName" runat="server" Text="Service Name " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstServiceName" runat="server" ToolTip="Service Name" Enabled="false"
                                                    CssClass="FormListBoxMedium">
                                                </asp:DropDownList>
                                            </td>
                                          <%--  <td style="text-align: left">
                                                <asp:CheckBox ID="chkApproval" runat="server" ToolTip="Approval" Text="Approval"
                                                    CssClass="FormLabel"></asp:CheckBox>
                                            </td>--%>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 300px;">
                            <td valign="top" align="center">
                                <table>
                                    <tr>
                                        <td valign="top" align="center">
                                            <table style="text-align: center;" cellspacing="1" cellpadding="0">
                                                <tr class="RepHead">
                                                    <td align="center">
                                                        <asp:Label ID="lblRdSelect" Width="20px" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdFromDate" Width="65px" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdToDate" Width="65px" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdDocumentType" Width="80px" runat="server" Text="Doc" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdFromDistance" Width="65px" runat="server" Text="From Distance"
                                                            CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdToDistance" Width="65px" runat="server" Text="To Distance " CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdStuffDestuff" Width="70px" runat="server" Text="Stuff/Dest" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdTrailorSize" Width="50px" runat="server" Text="Trailor Size"
                                                            CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdContPerTrailor" Width="50px" runat="server" Text="Cont" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdContSize" Width="48px" runat="server" Text="Size" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdContStatus" Width="60px" runat="server" Text="Status" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdContType" Width="82px" runat="server" Text="Cont Type" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdCommodity" Width="138px" runat="server" Text="Commodity" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdFromRange" Width="50px" runat="server" Text="From Range" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdToRange" Width="50px" runat="server" Text="To Range" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblRdRate" Width="80px" runat="server" Text="Rate" CssClass="FormLabel"></asp:Label>
                                                    </td>
                                                    <td width="10px" style="background-color: White" />
                                                </tr>
                                                <tr>
                                                    <td colspan="17">
                                                        <div id="dvDetails" runat="server" style="overflow: auto; direction: rtl; height: 200px;
                                                            text-align: center">
                                                            <div style="direction: ltr;">
                                                                <asp:Repeater ID="repRateDeatils" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table cellspacing="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox Width="15px" ID="chkSelect" runat="server" ToolTip="Select"></asp:CheckBox>
                                                                                <asp:HiddenField ID="hdnRateRefId" Value='<%# Eval("RateTptRefId") %>' runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="65px" ID="textFromDate" runat="server"
                                                                                    Text='<%# Eval("FromDate") %>' ToolTip="From Date">
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                                                                    TargetControlID="textFromDate" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="65px" ID="textToDate" runat="server"
                                                                                    Text='<%# Eval("ToDate") %>' ToolTip="To Date">
                                                                                </asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                                                                    TargetControlID="textToDate" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstDocumentType" Width="85px" runat="server" ToolTip="Document Type"
                                                                                    Text='<%# Eval("DocType") %>' CssClass="FormListBoxSmall">
                                                                                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="I" Text="IMPORT"></asp:ListItem>
                                                                                    <asp:ListItem Value="E" Text="EXPORT"></asp:ListItem>
                                                                                    <asp:ListItem Value="D" Text="DOMESTIC"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="65px" ID="textFromDistance" runat="server"
                                                                                    ToolTip="Distance" Text='<%# Eval("FromLocation") %>'>
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="65px" ID="textToDistance" runat="server"
                                                                                    ToolTip="Distance" Text='<%# Eval("ToLocation") %>'>
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="75px" ID="lstStuffDestuff" runat="server"
                                                                                    Text='<%# Eval("StuffDestuff") %>' ToolTip="Stuff Destuff">
                                                                                    <asp:ListItem Value="" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="D" Text="Destuff"></asp:ListItem>
                                                                                    <asp:ListItem Value="S" Text="Stuff"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="52px" ID="lstTrailorSize" runat="server"
                                                                                    Text='<%# Eval("TrailorSize") %>' ToolTip="Cont">
                                                                                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="20" Text="T20"></asp:ListItem>
                                                                                    <asp:ListItem Value="40" Text="T40"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="52px" ID="lstContPerTrailor" runat="server"
                                                                                    Text='<%# Eval("ContRepTrailor") %>' ToolTip="Trailor Size">
                                                                                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="50px" ID="lstContSize" runat="server"
                                                                                    Text='<%# Eval("ContSize") %>' ToolTip="Cont Size">
                                                                                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                                    <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                                    <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxSmall" Width="65px" ID="lstContStatus" runat="server"
                                                                                    Text='<%# Eval("ContStatus") %>' ToolTip="Cont Status">
                                                                                    <asp:ListItem Value="0" Text="ALL"></asp:ListItem>
                                                                                    <asp:ListItem Value="E" Text="Empty"></asp:ListItem>
                                                                                    <asp:ListItem Value="L" Text="Laden"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="lstCargoType" Width="85px" runat="server" CssClass="FormListBoxLarg"
                                                                                    Value='<%# Eval("ContType") %>' ToolTip="Cont Type">
                                                                                    <asp:ListItem Value="ALL" Text="ALL" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="NORMAL" Value="NORMAL"></asp:ListItem>
                                                                                    <asp:ListItem Text="REEFER" Value="REEFER"></asp:ListItem>
                                                                                    <asp:ListItem Text="HIGHCUBE" Value="HIGHCUBE"></asp:ListItem>
                                                                                    <asp:ListItem Text="HAZ" Value="HAZ"></asp:ListItem>
                                                                                    <asp:ListItem Text="ODC" Value="ODC"></asp:ListItem>
                                                                                    <asp:ListItem Text="TANK" Value="TANK"></asp:ListItem>
                                                                                    <asp:ListItem Text="VPU" Value="VPU"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxMedium" Width="140px" ID="lstCommodityID" runat="server"
                                                                                    Text='<%# Eval("CommodityID") %>' OnDataBinding="prepareCommodity" ToolTip="Commodity">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="50px" onkeypress="kp_integer();" ID="textFromRange"
                                                                                    runat="server" Text='<%# Eval("FromRange") %>' ToolTip="From Range"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="50px" onkeypress="kp_integer();" ID="textToRange"
                                                                                    runat="server" Text='<%# Eval("ToRange") %>' ToolTip="To Range"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxSmall" Width="80px" onkeypress="kp_integer();" ID="textRate"
                                                                                    runat="server" Text='<%# Eval("Rate") %>' ToolTip="Rate"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table></FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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
            <td align="center" colspan="2">
                <table style="width: 100%; height: 1px">
                    <tr>
                        <td align="center" style="text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <%--<asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server"></asp:Label>--%>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lstServiceName" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="btnAddRow" runat="server" ImageUrl="~/Images/btnAdd.png" />
                            <asp:ImageButton ID="btnDeleteRow" runat="server" ImageUrl="~/Images/btnDelete.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" style="text-align: center">
        <tr>
            <td align="center" style="width: 80%">
                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                <asp:Button ID="btnEdit" Visible="false" runat="server" ImageUrl="~/Images/btnEdit.png" />
                <asp:IMageButton ID="btnSave" runat="server" Visible="false"  Text="Approval" />
                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                <asp:ImageButton ID="btnListAll" runat="server" ImageUrl="~/Images/btnShow.png" />
                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
            </td>
        </tr>
    </table>
</asp:Content>
