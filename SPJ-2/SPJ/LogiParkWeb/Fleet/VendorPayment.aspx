<%@ Page Title="eLOGiFleet::Vendor Payment" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="VendorPayment.aspx.vb" Inherits="Fleet_VendorPayment"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td>
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="200px" Text="Customer Mapping"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
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
                            <td style="width: 100%;" align="center" valign="top">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="LblVendorType" runat="server" CssClass="FormLabel" Text="Vendor Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="LstVendorType" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem>SELECT</asp:ListItem>
                                                    <asp:ListItem Value="D">DRIVER</asp:ListItem>
                                                    <asp:ListItem Value="L">LINE</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Button ID="btnSearchVendor" runat="server" CssClass="FormButton" Visible="false"
                                                    Text="Go" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LblVendorName" runat="server" CssClass="FormLabel" Text="Vendor Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="LstVendorName" runat="server" CssClass="ddlMedium" Width="120px">
                                                </asp:DropDownList>
                                                <asp:Button ID="GetPaymentData" runat="server" Visible="false" CssClass="FormButton"
                                                    Text="Go" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LblRemark" runat="server" CssClass="FormLabel" Text="Remark"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextRemark" Height="30px" runat="server" CssClass="ddlMedium" Width="120px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="0" border="0" cellpadding="0" style="border-color: White;">
                                                    <tr class="RepheaderNew">
                                                        <td align="center">
                                                            <asp:Label ID="LblPaymentFor" Width="200px" runat="server" CssClass="FormLabel" Text="Payment For"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblqnty" Width="50px" runat="server" CssClass="FormLabel" Text="Qnty"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblAmount" Width="50px" runat="server" CssClass="FormLabel" Text="Amount"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LblToDate" Width="100px" runat="server" CssClass="FormLabel" Text="To Date"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" valign="top" align="center">
                                                <div class="RepScroling" style="height: 140px;">
                                                    <asp:Repeater ID="repTaxHead" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont1" cellspacing="0" border="0" cellpadding="0">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList CssClass="ddlMedium" Width="180px" ID="lstTaxHead" runat="server"
                                                                        OnDataBinding="preparePaymentFor" ToolTip="Billing Party Name">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="FormListBoxMedium" Width="50px" ID="Textqnty" runat="server"
                                                                        ToolTip="Qnty">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="TextAmt" CssClass="FormListBoxMedium" Width="50px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="FormListBoxMedium" Width="100px" ID="TextDate" runat="server"
                                                                        ToolTip="Tally Customer Name">
                                                                    </asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                                        TargetControlID="TextDate" />
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
                            <td valign="top">
                                <div id="dvTreeView" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                    </table>
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
    </div> </td> </tr> </table> </table> </table> </table> </table>
</asp:Content>
