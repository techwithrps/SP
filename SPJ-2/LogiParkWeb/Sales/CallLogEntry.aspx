<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CallLogEntry.aspx.vb" Inherits="Sales_CallLogEntry" Title="eLOGiPark :: Customer Call Log Monitoring"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function check(dodate)
    {
    var startDate = dodate.getAttribute('value');
    var currentTime = new Date()
    var month = currentTime.getMonth() + 1
    var day = currentTime.getDate()
    var year = currentTime.getFullYear()
        endDate = (day + "/" + month + "/" + year)
        startDate = Date.parse(startDate);
        endDate = Date.parse(endDate);

        if(startDate > endDate)
        {
            alert("Please ensure that the entered Date is less than or equal to the Current Date.");
            dodate.value='';
            dodate.style.border='1px solid red';
            dodate.focus();
            return false;
        } 
        dodate.style.border='1px solid #B3CBFF';
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Customer Call Log Monitoring"
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
                                    <table>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCustomer" runat="server" Text="Customer Name " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCustomerName" onkeypress="kp_phonenumber();" runat="server"
                                                    Enabled="false" CssClass="RptFormTextBoxMedium">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnProfileId" runat="server" Value="0" />
                                            </td>
                                            <td style="text-align: right">
                                            </td>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkCallStatus" runat="server" Checked="false" CssClass="FormLabel"
                                                   ToolTip="Select" Text="Customer Confirmation"></asp:CheckBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="1">
                                        <tr class="RepHead">
                                            <td align="center">
                                                <asp:Label ID="lblClCallDate" Width="90px" CssClass="FormLabel" runat="server" Text='Call Date<span class="mandatory"> *</span>'>
                                                </asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblClContactPerson" Width="250px" CssClass="FormLabel" runat="server" Text='Contact Person<span class="mandatory"> * </span>'>
                                                </asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblClApproachMethod" Width="100px" CssClass="FormLabel" runat="server" Text='Contact Medium<span class="mandatory"> *</span>'>
                                                </asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblClCallDetails" Width="300px" CssClass="FormLabel" runat="server" Text='Call Details<span class="mandatory"> *</span>'>
                                                </asp:Label>
                                            </td>
                                            <td style="width: 15px; background-color: White;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" valign="top" align="center">
                                                <div style="height: 286px; overflow: auto;">
                                                    <asp:Repeater ID="repCallLog" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont" cellspacing="0" style="margin-left:-1px">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <%--<td>
                                                                    <asp:CheckBox Width="20px" ID="chkSelect" runat="server" Visible="false" ToolTip="Select">
                                                                    </asp:CheckBox>
                                                                </td>--%>
                                                                <td valign="top">
                                                                    <asp:HiddenField ID="hdnCallLogId" Value='<%# Eval("CallLogId") %>' runat="server" />
                                                                    <asp:TextBox ID="textCallDate" Enabled="false" Text='<%# Eval("CallDate") %>' runat="server"
                                                                        CssClass="FormTextBoxDate" Width="90px" ToolTip="Call Date " onblur="check(this);">
                                                                    </asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="clCallDate" Format="dd/MM/yyyy" runat="server"
                                                                        PopupPosition="TopRight" TargetControlID="textCallDate" />
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:TextBox Width="250px" ID="textContactPerson" runat="server" CssClass="FormTextBoxMedium"
                                                                        MaxLength="40" onkeypress="kp_convert_upper()" ToolTip="Contact Person" Text='<%# Eval("ContactPerson") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList Width="106px" ID="lstApproachMethod" runat="server" CssClass="FormListBoxMedium"
                                                                        ToolTip="Approach Method" Text='<%# Eval("ApproachMethod") %>'>
                                                                        <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                                        <asp:ListItem Value="E" Text="E-Mail"></asp:ListItem>
                                                                        <asp:ListItem Value="P" Text="Phone"></asp:ListItem>
                                                                        <asp:ListItem Value="V" Text="Visit"></asp:ListItem>
                                                                        <asp:ListItem Value="W" Text="Web Portal"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox Width="300px" ID="textCallDetails" runat="server" CssClass="FormTextBoxLarg"
                                                                        TextMode="MultiLine" Height="30px" ToolTip="Call Details" Text='<%# Eval("CallDetails") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table></FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvCallLog" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
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
                                                <asp:ImageButton ID="btnEdit" Visible="false" runat="server" ImageUrl="~/Images/btnEdit.png" />
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
