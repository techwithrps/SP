<%@ Page Title="eLOGiFleet::Invoice Cancelation" Theme="Forms" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CancelInvoice.aspx.vb" Inherits="Commercial_CancelInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Cancel Export Invoice"
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
                        <tr class="UserControls" style="margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td>
                                                <table width="100%" style="border-color: White;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblClInvoiceNo" runat="server" CssClass="FormLabel" Text="Cancel Invoice No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textClInvoiceNo" Width="125px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Cancel Invoice No">
                                                            </asp:TextBox>
                                                            <asp:HiddenField ID="hdnClInvoiceId" runat="server" />
                                                        </td>
                                                        <td width="10px" rowspan="7">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblClInvoiceDate" runat="server" CssClass="FormLabel" Text="Cancel Invoice Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textClInvoiceDate" runat="server" Width="125px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Cancel Invoice Date">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Invoice No"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceRefNo" Width="125px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="Invoice No">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                            <asp:Button ID="btnAddInvoiceNo" runat="server" Visible="false" CssClass="FormButton"
                                                                Text="Go" />
                                                            <asp:Button ID="btnSearchInvoiceNo" runat="server" Visible="false" CssClass="FormButton"
                                                                Text="Go" />
                                                            <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="125px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td width="10px" rowspan="5">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblExporter" runat="server" CssClass="FormLabel" Text="Consignee"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textExporter" runat="server" Width="273px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Exporter">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <%--<asp:Label ID="lblBookingNo" runat="server" CssClass="FormLabel" Text="Booking No."></asp:Label>--%>
                                                        </td>
                                                        <td align="left">
                                                            <%-- <asp:TextBox ID="textBookingNo" Width="125px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Booking No">
                                                            </asp:TextBox>--%>
                                                            <asp:HiddenField ID="hdnBookingId" runat="server" />
                                                            <asp:HiddenField ID="hdnDocType" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Invoice To"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceTo" Width="125px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice To">                                                                
                                                            </asp:TextBox>
                                                            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCha" runat="server" CssClass="FormLabel" Text="Consignor"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textCha" Width="273px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="CHA">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPaymentMode" runat="server" CssClass="FormLabel" Text="Payment Mode"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textPaymentMode" Width="125px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Payment Mode">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLine" runat="server" CssClass="FormLabel" Text="Line "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textLine" Width="273px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Line">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstServiceType" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="A" Text="ALL" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="F" Text="FREIGHT"></asp:ListItem>
                                                                <asp:ListItem Value="T" Text="TRANSPORTATION"></asp:ListItem>
                                                                <asp:ListItem Value="C" Text="CLEARENCE"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="REBATE"></asp:ListItem>
                                                                <asp:ListItem Value="M" Text="AMENDMENT"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblGrTillDate" runat="server" CssClass="FormLabel" Text="Ground Rent Till Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textGrTillDate" Width="125px" runat="server" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Ground Rent Till Date">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRailOperator" runat="server" CssClass="FormLabel" Text="Rail Operator "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textRailOperator" runat="server" Width="273px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Rail Operator">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCancelNote" runat="server" CssClass="FormLabel" Text="Cancel Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="4">
                                                            <asp:TextBox ID="textCancelNote" runat="server" Width="513px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Cancel Note">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                        </td>
                                                    </tr>
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <table cellspacing="0">
                                    <tr>
                                        <td colspan="12" valign="top" align="center">
                                            <div class="RepScroling" style="height: 190px;">
                                                <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                                    <HeaderTemplate>
                                                        <table id="Sb" cellspacing="0">
                                                            <tr class="RepHead">
                                                                <td>
                                                                    <asp:Label ID="lblContNo" Width="90px" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblSize" Width="30px" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblservice" Width="250px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblQuntity" Width="40px" CssClass="FormLabel" runat="server" Text="Qnty"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblRate" Width="60px" CssClass="FormLabel" runat="server" Text="Rate"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Amount"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblServiceTax" Width="60px" CssClass="FormLabel" runat="server" Text="CGST"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblEducTax" Width="60px" CssClass="FormLabel" runat="server" Text="SGST"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblHeduTax" runat="server" Width="60px" CssClass="FormLabel" Text="IGST"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTaxAmount" Width="60px" CssClass="FormLabel" runat="server" Text="GST Amount"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total Amount"></asp:Label>
                                                                </td>
                                                                <td style="width: 17px; background-color: White;">
                                                                </td>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="textContNo" runat="server" CssClass="RptFormTextBoxMedium" Width="90px"
                                                                    Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hdnLineItemId" Value='<%# Eval("LineItemId") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnImpConId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnLineItem" Value='<%# Eval("LineItem") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textSize" runat="server" Enabled="false" CssClass="RptFormTextBoxMedium"
                                                                    Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textService" runat="server" Enabled="false" CssClass="RptFormTextBoxMedium"
                                                                    Width="250px" ToolTip="Service">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                                <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textQuntity" runat="server" Enabled="false" Text='<%# Eval("BillQnty") %>'
                                                                    ToolTip="Quantity" CssClass="RptFormTextBoxNumeric" Width="40px">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                    Width="60px" Text='<%#  Eval("BillRate") %>' ToolTip="Rate">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                    Width="80px" Text='<%# string.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate")) - Eval("WeiverAprAmt")) %>'
                                                                    ToolTip="Amount">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textServiceTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                    Width="60px" Text="" ToolTip="CGST">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textEducTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                    Width="60px" Text="" ToolTip="SGST">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textHEduTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                    Width="60px" Text="" ToolTip="IGST">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Enabled="false"
                                                                    Width="60px" Text='<%# string.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") *  Eval("BillRate"))-Eval("WeiverAprAmt"))) %>'
                                                                    ToolTip="Tax Amount">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="textTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                    Width="80px" Text='<%# string.Format("{0:n2}",Eval("BillAmount")) %>' Enabled="false"
                                                                    ToolTip="Total Amount">
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
                                    <%--<tr>
                                        <td align="right" style="width: 370px">
                                            <asp:Label ID="lblTotal" runat="server" Text="Total " CssClass="FormLabel"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepAmount" runat="server" CssClass="RptFormTextBoxNumeric" Width="80px"
                                                ToolTip="Amount Total" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepServiceTax" runat="server" CssClass="RptFormTextBoxNumeric"
                                                Width="60px" ToolTip="Service Tax" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepEducTax" runat="server" CssClass="RptFormTextBoxNumeric"
                                                Width="60px" ToolTip="Educ Tax" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepHEducTax" runat="server" CssClass="RptFormTextBoxNumeric"
                                                Width="60px" ToolTip="HEduc Tax" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                Width="60px" ToolTip="Tax Amount Total" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="textRepTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                Width="80px" ToolTip="Total Amount" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="chkConfirmCancel" runat="server" CssClass="FormLabel" Text="Confirm Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="FormButton" Text="Add" />
                                                <asp:Button ID="btnSearch" runat="server" CssClass="FormButton" Text="Search" />
                                                <asp:Button ID="btnPrint" runat="server" CssClass="FormButton" Text="Print" />
                                                <asp:Button ID="btnSave" runat="server" CssClass="FormButton" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="FormButton" Text="Cancel" />
                                                <asp:Button ID="btnExit" runat="server" CssClass="FormButton" Text="Exit" />
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
    </table>
</asp:Content>
