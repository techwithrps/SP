<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" CodeFile="~/Commercial/CostBookingNew.aspx.vb"
    AutoEventWireup="false" Inherits="Commercial_CostBooking" Title="eLOGiFleet:: Cost Booking"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <%--  <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    --%>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        function Confirm() {
            var d1 = "Do you want to Delete the data.";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(d1)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <div id="dvPage" style="vertical-align: top; overflow: auto; width: 81%;">
        <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
            <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                <td style="width: 100%;" align="center" valign="top">
                    <div id="dvControl" runat="server" style="width: 100%; border-style: none;">
                        <table border="0" cellpadding="0" style="border-style: none;">
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="Purchase Booking"
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
                                <td colspan="3">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label1" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" ID="lstPurchaseType">
                                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                                    <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                                    <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                                    <asp:ListItem Text="Clearing & Forwading" Value="C"></asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="LblBillingParty" runat="server" Text="Bill To" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="LstBillingParty">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblBlNo" runat="server" Text="BL Number" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textBlNo" runat="server" CssClass="textbox" ToolTip="From Date"
                                                    Enabled="false" MaxLength="20"></asp:TextBox>
                                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="lstJoNo">
                                                </asp:DropDownList>
                                                <asp:Button ID="btnGo" runat="server" Text="GO" CssClass="FormButton" />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblShippingLine" runat="server"  TabIndex="0" Text="Customer/Vendor" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" TabIndex="0" ID="lstShippingLine">
                                                </asp:DropDownList>
                                                <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" ID="lstVendorList">
                                                </asp:DropDownList>
                                                <%--    <strong>
                                                                <samp class="mandatory">
                                                                    *</samp></strong>--%>
                                                <asp:HiddenField ID="hdnTaxGroupID" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnCostId" runat="server" Value="0" />
                                                <asp:HiddenField ID="HdnStatus" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label8" runat="server" Text="State" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="lstState">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblGSTINNo" runat="server" Text="GSTIN" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtGSTIN" runat="server" CssClass="textbox" ToolTip="GSTIN" Enabled="false"
                                                    MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td style="text-align: left;">
                                                <asp:Label ID="LblLineInvoiceNo" runat="server" Text="Invoice No" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="TextInvNo" runat="server"  CssClass="textbox" ToolTip="To Date" Enabled="false"
                                                    AutoPostBack="True"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong><asp:Button ID="btnSearchInvoice" runat="server" Text="GO" CssClass="FormButton" />
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textToDate0" runat="server" CssClass="textbox" ToolTip="To Date"
                                                    Enabled="false" MaxLength="12"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="textToDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="textToDate0" />
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblDueDate" runat="server" Text="Due Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="textDueDate" runat="server" CssClass="textbox" ToolTip="To Date"
                                                    Enabled="false"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="textDueDate" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTdsApplicable" runat="server" Text="TDS Applicable" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="lstTdsApplicable" Width="80">
                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblTdsPer" runat="server" CssClass="FormLabel" Text="%"></asp:Label>
                                                <asp:TextBox ID="TextTdsPer" runat="server" Width="20px" CssClass="textbox" ToolTip="%" Enabled="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td style="text-align: left;">
                                                <asp:Label ID="Label9" runat="server" Text="Ex. Rate" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="TxtExchangeRate" Width="300px" runat="server" CssClass="textbox" ToolTip="Ex Rate"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="Label10" runat="server" Text="Remarks" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtRemak" Width="300px" runat="server" CssClass="textbox" ToolTip="To Date"
                                                    Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                    <table cellspacing="0" border="0" cellpadding="0" style="border-color: White;">
                                        <tr>
                                            <td colspan="8" valign="top" align="center">
                                                <div class="RepScroling" style="height: 140px;">
                                                    <asp:Repeater ID="repTaxHead" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont1" cellspacing="0" border="0" cellpadding="0">
                                                                <tr class="RepheaderNew">
                                                                    <td align="center" width="150px" style="height: 20px">
                                                                        <asp:Label ID="lblService" Width="150px" runat="server" CssClass="FormLabel" Text='Service Name<span class="mandatory"> *</span>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblQnty" runat="server" CssClass="FormLabel" Text="Qnty"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRate" runat="server" CssClass="FormLabel" Text="Rate"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblExRate" runat="server" CssClass="FormLabel" Text="Ex. Rate"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblBaseRate" runat="server" CssClass="FormLabel" Text="Base Amount"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="CGST Rate"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="CGST Amount"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" CssClass="FormLabel" Text="SGST Rate"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server" CssClass="FormLabel" Text="SGST Amount"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label6" runat="server" CssClass="FormLabel" Text="IGST Rate"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label7" runat="server" CssClass="FormLabel" Text="IGST Amount"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTaxPer" runat="server" CssClass="FormLabel" Text="Tax (%)"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTaxAmount" runat="server" CssClass="FormLabel" Text="Tax Amount"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTotal" runat="server" CssClass="FormLabel" Text="Total"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTdsAmount" runat="server" CssClass="FormLabel" Text="TDS Amount"></asp:Label>
                                                                    </td>
                                                                    <td width="17px">
                                                                    </td>
                                                                </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%-- <asp:HiddenField ID="hdnRepTaxGroupId" Value='<%# Eval("TaxGroupId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnRepTaxRefId" Value='<%# Eval("TaxRefId") %>' runat="server" />--%>
                                                                    <asp:HiddenField ID="hdnCostDtlsId" Value='<%# Eval("CostDtlsId") %>' runat="server" />
                                                                    <asp:DropDownList CssClass="ddlMedium" Width="172px" Text='<%# Eval("ServiceId") %>'
                                                                        ID="lstService" runat="server" OnDataBinding="prepareServiceMaster" ToolTip="Service Name">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="textbox" Width="50px" ID="textQnty" Text='<%# Eval("Qnty") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="textbox" Width="90px" ID="textRate" Text='<%# Eval("Rate") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="textbox" Width="40px" ID="textExRate" Text='<%# Eval("ExRate") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:TextBox CssClass="textbox" Width="90px" ID="textBaseAmount" Text='<%# Eval("BaseRate") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Text='<%# Eval("CGSTRate") %>' Width="50px" ID="txtCGSTRate"
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="CGST Rate" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="90px" Text='<%# Eval("CGSTAmount") %>' ID="txtCGSTAmount"
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="CGST Amount" MaxLength="15"
                                                                        Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="50px" Text='<%# Eval("SGSTRate") %>' ID="txtSGSTRate"
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="SGST Rate" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="90px" Text='<%# Eval("SGSTAmount") %>' ID="txtSGSTAmount"
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="SGST Amount" MaxLength="15"
                                                                        Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="50px" ID="txtIGSTRate" Text='<%# Eval("IGSTRate") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="IGST Rate" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="90px" ID="txtIGSTAmount" Text='<%# Eval("IGSTAmount") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="IGST Amount" MaxLength="15"
                                                                        Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="50px" ID="textPerc" Text='<%# Eval("TaxPerc") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8" AutoPostBack="true"
                                                                        Enabled="false" OnTextChanged="checkper"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="105px" ID="TextBox5" Text='<%# Eval("TaxAmt") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="105px" ID="TextBox6" Text='<%# Eval("Total") %>'
                                                                        runat="server" onkeypress="kp_numeric();" ToolTip="Tax %" MaxLength="8" Enabled="false"></asp:TextBox>
                                                                </td>
                                                                <td style="text-align: right;">
                                                                    <asp:TextBox CssClass="textbox" Width="105px" ID="textTDSAmount" Text='<%# Eval("TDSAmount") %>'
                                                                        runat="server" ToolTip="TDS Amount" MaxLength="8" Enabled="true"></asp:TextBox>
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
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td align="right" style="width: 195px">
                                                <asp:Label ID="LblTotal" runat="server" CssClass="FormLabel" Text="Total"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 90px">
                                                <asp:Label ID="LblRate" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 180px">
                                                <asp:Label ID="lblBaseAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="lblCGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 150px">
                                                <asp:Label ID="lblSGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 180px">
                                                <asp:Label ID="lblIGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 130px">
                                                <asp:Label ID="LblTaxAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="LblTotalAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="lblTotalTDS" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnConfirm" runat="server" CssClass="FormButton" Text="Calculate" />
                                    <asp:Button ID="BtnEditDetails" runat="server" CssClass="FormButton" Visible="false"
                                        Text="Edit Details" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="height: 130px; overflow: auto;">
                                        <asp:GridView ID="gvContainerDetails" CssClass="FormLabel" AutoGenerateColumns="False"
                                            runat="server">
                                            <RowStyle Font-Size="8pt" BackColor="AntiqueWhite"></RowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField ItemStyle-Width="120px" DataField="CONT_NO" HeaderText="Container No"
                                                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" HeaderText="Size" HeaderStyle-CssClass="RepheaderNew">
                                                </asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE" HeaderText="Type" HeaderStyle-CssClass="RepheaderNew">
                                                </asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="50px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                </asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="70px" DataField="PORT" HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Base Rate" HeaderStyle-CssClass="RepheaderNew">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtBaseAmt" runat="server" Text='<%# Eval("BASE_RATE")%>' Width="100px"
                                                            Visible="True"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Amount" HeaderStyle-CssClass="RepheaderNew">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtTaxAmt" runat="server" Text='<%# Eval("TAX_AMOUNT")%>' Width="100px"
                                                            Visible="True"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount" HeaderStyle-CssClass="RepheaderNew">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtTotal" runat="server" Text='<%# Eval("TOTAL_AMOUNT")%>' Width="100px"
                                                            Visible="True"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle></AlternatingRowStyle>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <%--  <td valign="top">
                                <div id="dvTreeView" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>--%>
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
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" Visible="false"
                                        OnClientClick="saveValidation()" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" Text="Delete" CssClass="FormButton"
                                        OnClientClick="Confirm()" />
                                    <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
