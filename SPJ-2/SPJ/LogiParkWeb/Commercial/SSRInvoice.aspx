<%@ Page Title="eLoGiFleet::Manuual Invoice" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="SSRInvoice.aspx.vb" Inherits="Commercial_Default1"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Service Mapping Request"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red">
                                </asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" />
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
                                    <table>
                                        <tr>
                                            <td>
                                                <table width="100%" style="border-color: White;">
                                                    <%-- <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Invoice No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceRefNo" Width="130px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice No">
                                                            </asp:TextBox>
                                                            <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnTempInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnPrintStatus" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="130px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <%--<td align="left">
                                                            <asp:Label ID="lblDocType" runat="server" CssClass="FormLabel" Text="Doc Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstDocType" AutoPostBack="true" Width="133px" runat="server"
                                                                CssClass="FormListBoxMedium" ToolTip="Doc Type">
                                                                <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                                <asp:ListItem Value="D" Text="Domestic" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="E" Text="Export"></asp:ListItem>
                                                                <asp:ListItem Value="I" Text="Import"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>--%>
                                                        <td align="left">
                                                            <asp:Label ID="lblBookingNo" runat="server" CssClass="FormLabel" Text="Booking No. "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textBookingNo" AutoComplete="off" Width="130px" runat="server" onkeypress="kp_convert_upper()"
                                                                CssClass="FormTextBoxSmall" ToolTip="Booking No" MaxLength="20">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                            <asp:HiddenField ID="hdnBookingId" runat="server" />
                                                            <asp:HiddenField ID="hdnService" runat="server" />
                                                            <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                                                            <asp:HiddenField ID="hdnDocType" runat="server" />
                                                            <asp:HiddenField ID="hdnCancelStatus" runat="server" />
                                                            <asp:Button ID="btnAddBooking" runat="server" Text="GO" Visible="false" CssClass="FormButton"
                                                                Height="20px" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblIGM" runat="server" CssClass="FormLabel" Text="IGM No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textIGMNo" Width="130px" runat="server" onkeypress="kp_convert_upper()"
                                                                CssClass="FormTextBoxSmall" ToolTip="IGM No" MaxLength="20">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLineItem" runat="server" CssClass="FormLabel" Text="Line Item "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textLineItem" Width="130px" runat="server" onkeypress="kp_convert_upper()"
                                                                CssClass="FormTextBoxSmall" ToolTip="Line Item" MaxLength="20">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                            <asp:ImageButton ID="btnAddLineItem" runat="server" Visible="false" Width="30px"
                                                                ImageUrl="~/Images/btnSearchtop.png" Height="20px" />
                                                        </td>
                                                    </tr>--%>
                                                    <%-- <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Invoice To "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstInvoiceTo" Width="133px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Invoice To">
                                                                <asp:ListItem Value="E" Text="CONSIGNEE" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="Line"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="CONSIGNOR"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnTaxId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnTaxOnPercentage" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnLineId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnChaId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnServiceId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnStateCode" runat="server" Value="0" />
                                                            <asp:Button ID="BtnInvoiceTo" runat="server" Text="GO" Visible="false" Width="30px" CssClass="FormButton"
                                                                Height="20px" />
                                                        </td>
                                                        <td class="tdstyle">
                                                            <asp:Label ID="LblBillpartyName" runat="server" Text="Bill Paty" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td class="tdstyle">
                                                            <asp:DropDownList ID="LstBiitoPartyNamne" runat="server" CssClass="FormListBoxMedium">
                                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    --%><%-- <td align="left">
                                                            <asp:Label ID="lblCustomerDetails" runat="server" CssClass="FormLabel" Text="Customer"></asp:Label>
                                                        </td>--%>
                                                    <%--<td align="left">
                                                            <asp:Label ID="lblPaymentMode" runat="server" CssClass="FormLabel" Text="Payment Mode "></asp:Label>
                                                        </td>--%>
                                                    <%-- <td align="left">
                                                            <asp:DropDownList ID="lstbillingparty" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Customer Type">
                                                            </asp:DropDownList>
                                                        </td>--%>
                                                    <%--<td align="left">
                                                            <asp:UpdatePanel ID="upPaymentMode" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstPaymentMode" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                        ToolTip="Payment Mode">
                                                                        <asp:ListItem Value="C" Text="Cash" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Value="R" Text="Credit"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstInvoiceTo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>--%>
                                        </tr>
                                        <%--<tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstServiceType" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="S" Text="Special Service" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>--%>
                                        <%-- <td align="left">
                                                            <asp:Label ID="lblCustomerDetails" runat="server" CssClass="FormLabel" Text="Customer"></asp:Label>
                                                        </td>--%>
                                        <%--    <td align="left">
                                                            <asp:DropDownList ID="lstCustomerDetails" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Customer Type">
                                                                <asp:ListItem Value="S" Text="" Selected="True"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>--%>
                                        <%--  <td align="left">
                                                            <asp:Label ID="lblPaymentMode" runat="server" CssClass="FormLabel" Text="Payment Mode "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upPaymentMode" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstPaymentMode" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                        ToolTip="Payment Mode">
                                                                        <asp:ListItem Value="C" Text="Cash" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Value="R" Text="Credit"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstInvoiceTo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="LblTaxGroup" runat="server" CssClass="FormLabel" Text="Tax Group"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lSTtAX" Width="125px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="1" Text="SERVICE TAX" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="14" Text="NO TAX"></asp:ListItem>
                                                                <asp:ListItem Value="16" Text="Gst18%"></asp:ListItem>
                                                                <asp:ListItem Value="17" Text="Gst12%"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                        <%--<tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Text="Invoice Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote" runat="server" Width="496px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Note">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                    </table>
                            </td>
                            <td>
                                <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 250px; border-left-color: Black;">
                                    <asp:TreeView ID="tvInvoices" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="r" style="text-align: left; overflow: auto; height: 120px;">
                        <table cellspacing="0" align="center">
                            <tr class="RepheaderNew" align="center">
                                <td align="left">
                                    <asp:Label ID="lblchk" runat="server" Width="15px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblContNo" Width="90px" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSize" Width="30px" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblservice" Width="290px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblServicetype" Width="150px" CssClass="FormLabel" runat="server" Text="Service Type"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblQnty" runat="server" CssClass="FormLabel" Text="Qnty"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblExRate" runat="server" CssClass="FormLabel" Text="Ex. Rate"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCurrency" runat="server" CssClass="FormLabel" Text="Currency"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblRate" runat="server" CssClass="FormLabel" Text="Rate"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="9" valign="top">
                                    <div class="RepScroling" style="height: 110px;">
                                        <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                            <HeaderTemplate>
                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px;">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="chkSelect" Width="15px" runat="server" ToolTip="" onclick="return SelectAmount(this);"></asp:CheckBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textContNo" runat="server" CssClass="RptFormTextBoxMedium" Width="90px"
                                                            Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textSize" runat="server" Enabled="false" CssClass="RptFormTextBoxMedium"
                                                            Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="hdnContId" Value='<%# Eval("MtyContId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnTaxPerc" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList CssClass="FormListBoxLarg" Width="300px" ID="lstService" runat="server"
                                                            OnDataBinding="prepareService" ToolTip="Service Name">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="lstServiceType" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                            ToolTip="Service Type">
                                                            <asp:ListItem Value="0" Text="---Select---" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Value="A" Text="Tax Invoice"></asp:ListItem>
                                                            <asp:ListItem Value="F" Text="Bill of Supply"></asp:ListItem>
                                                            <asp:ListItem Value="B" Text="B/L Surrender"></asp:ListItem>
                                                            <asp:ListItem Value="T" Text="TRANSPORTATION"></asp:ListItem>
                                                            <asp:ListItem Value="C" Text="CLEARENCE"></asp:ListItem>
                                                            <asp:ListItem Value="R" Text="REBATE"></asp:ListItem>
                                                            <asp:ListItem Value="M" Text="AMENDMENT"></asp:ListItem>
                                                            <asp:ListItem Value="I" Text="Import Invoice"></asp:ListItem>
                                                            <asp:ListItem Value="X" Text="ReExport Invoice"></asp:ListItem>
                                                            <asp:ListItem Value="S" Text="FAIR GROUP"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textQuntity" AutoComplete="off" runat="server" Enabled="false" ToolTip="Quantity" CssClass="FormTextBoxNumeric"
                                                            Width="30px">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textExRate" AutoComplete="off" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                            Width="60px" ToolTip="Rate">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="lstCurrency" runat="server" CssClass="FormListBoxLarg" ToolTip="Service Group Name"
                                                            Width="100px">
                                                            <asp:ListItem Value="0">--Select CurrencyType--</asp:ListItem>
                                                            <asp:ListItem Value="INR" Text="INR"></asp:ListItem>
                                                            <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                                                            <asp:ListItem Value="OMR" Text="OMR"></asp:ListItem>
                                                            <asp:ListItem Value="QAR" Text="QAR"></asp:ListItem>
                                                            <asp:ListItem Value="AED" Text="AED"></asp:ListItem>
                                                            <asp:ListItem Value="BHD" Text="BHD"></asp:ListItem>
                                                            <asp:ListItem Value="EURO" Text="EURO"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textRate" AutoComplete="off" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                            Width="60px" ToolTip="Rate">
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
                                <td width="15px"></td>
                                <td width="90px"></td>
                                <td width="30px"></td>
                                <td width="250px"></td>
                                <td width="30px"></td>
                                <%--<td>
                                                    <asp:TextBox ID="textRepWeiverReqAmt" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="96px" ToolTip="Total Weiver Request Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>--%>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:CheckBox ID="chkInvoiceChecked" runat="server" CssClass="FormLabel" Text="Invoice Checked" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="dvButton" style="vertical-align: bottom;">
                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                        <tr style="margin-top: 0px;">
                            <td align="center">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                <asp:Button ID="Button2" runat="server" Text="New Print" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div> </td> </tr> </table>
</asp:Content>
