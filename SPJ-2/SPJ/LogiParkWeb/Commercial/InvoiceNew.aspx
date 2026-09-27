<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Commercial/InvoiceNew.aspx.vb" Inherits="Commercial_InvoiceNew" Title="eLOGiFleet :: Invoice Generation"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

        function checkAll(id) {

            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;

                var id1 = document.getElementById("<%=chkSelect.clientid%>").checked;

                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect")
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked = id1;
                    }
                }
            }
        }


    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Invoice" CssClass="FormLabelTitle">
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
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblParty" runat="server" CssClass="FormLabel" Text="Consignee "></asp:Label>
                                                            <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnJoId" runat="server" />
                                                            <asp:HiddenField ID="hdnTempInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnPrintStatus" runat="server" />
                                                            <asp:HiddenField ID="hdnInvStatus" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstParty" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Party">
                                                            </asp:DropDownList>
                                                            <span class="mandatory">*</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="LblBookingType" runat="server" CssClass="FormLabel" Text="Booking Type"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstBookingType" runat="server" CssClass="FormListBoxMedium"
                                                                Width="90px" ToolTip="Party">
                                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Container" Value="C"></asp:ListItem>
                                                                <asp:ListItem Text="Vehicle" Value="V"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span class="mandatory">*</span>
                                                            <asp:ImageButton ID="btnSearchPendency" runat="server" Visible="false" Width="30px"
                                                                ImageUrl="~/Images/brnAddtop.png" Height="20px" />
                                                        </td>
                                                        <td style="vertical-align: top;" rowspan="2" align="left">
                                                            <asp:Label ID="lblJoNo" runat="server" CssClass="FormLabel" Text="JO No">
                                                            </asp:Label>
                                                        </td>
                                                        <td style="vertical-align: top;" rowspan="4" align="left">
                                                            <div style="width: 150px; height: 100px; text-align: left; overflow: auto;">
                                                                <asp:CheckBoxList ID="chkJoNo" CssClass="FormListBoxMedium" runat="server" Width="130px"
                                                                    AutoPostBack="True">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblConsignor" runat="server" CssClass="FormLabel" Text="Consignor "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstConsignor" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Consignor">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLine" runat="server" CssClass="FormLabel" Text="Line "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstLine" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Line">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCha" runat="server" CssClass="FormLabel" Text="CHA "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstCha" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="CHA">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAccount" runat="server" CssClass="FormLabel" Text="Account "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstAcount" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Account">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Invoice No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceRefNo" Width="130px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="Invoice No">
                                                            </asp:TextBox>
                                                            <asp:ImageButton ID="btnSearchInvoice" runat="server" Visible="false" Width="30px"
                                                                ImageUrl="~/Images/brnAddtop.png" Height="20px" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="127px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="clInvoiceDate" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="textInvoiceDate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Invoice To "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstInvoiceTo" AutoPostBack="true" Width="131px" runat="server"
                                                                CssClass="FormListBoxMedium" ToolTip="Invoice To">
                                                                <asp:ListItem Value="C" Text="CHA" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="A" Text="Account"></asp:ListItem>
                                                                <asp:ListItem Value="E" Text="Consignee"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="Consignor"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="Line"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnCustomer" runat="server" Value="0" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPaymentMode" runat="server" CssClass="FormLabel" Text="Payment Mode "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upPaymentMode" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstPaymentMode" Width="128px" runat="server" CssClass="FormListBoxMedium"
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
                                                        <td align="left"></td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="btnGenerate" Visible="false" runat="server" ImageUrl="~/Images/btnGenerate.png" />
                                                            <asp:ImageButton ID="btnPreview" Visible="false" runat="server" ImageUrl="~/Images/btnPreview.png" />
                                                        </td>
                                                        <%-- <td align="left">
                                                            <asp:Label ID="lblExporter" runat="server" CssClass="FormLabel" Text="Consignor "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textConsignor" runat="server" Width="270px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Exporter">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCha" runat="server" CssClass="FormLabel" Text="Consignee "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextConsignee" Width="274px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="CHA">
                                                          </asp:TextBox>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text="Customer Invoice "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textpono" runat="server" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstServiceType" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="A" Text="ALL" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="Ground Rent"></asp:ListItem>
                                                                <asp:ListItem Value="T" Text="Transportation"></asp:ListItem>
                                                                <asp:ListItem Value="S" Text="Special Service"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:DropDownCheckBoxes ID="ddchkContainer" EnableViewState="true" runat="server"
                                                                CssClass="ddlMedium" UseButtons="True" UseSelectAllNode="True">
                                                                <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="130" />
                                                            </asp:DropDownCheckBoxes>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCreditLimit" runat="server" CssClass="FormLabel" Text="Credit Limit "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="textCreditLimit" Width="90px" runat="server" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="Credit Limit">
                                                                    </asp:TextBox>&nbsp;&nbsp;
                                                                    <asp:Label ID="lblDueAmount" runat="server" CssClass="FormLabel" Text="Due Amount "></asp:Label><asp:TextBox
                                                                        ID="textDueAmount" Width="90px" runat="server" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="Due Amount">
                                                                    </asp:TextBox>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstInvoiceTo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblPoDate" runat="server" CssClass="FormLabel" Text="Date"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textPodate" runat="server" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                                                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textPodate" />--%>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Text="Invoice Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote" runat="server" Width="472px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Note">
                                                            </asp:TextBox>
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
                                    <div id="r" style="text-align: left; overflow: auto; height: 200px;">
                                        <table cellspacing="0" align="center">
                                            <tr class="RepHead" align="center">
                                                <td align="left">
                                                    <asp:CheckBox ID="chkSelect" runat="server" Width="30px" onClick="checkAll(this);"></asp:CheckBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblContNo" Width="120px" runat="server" CssClass="FormLabel" Text="Container No" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSize" Width="25px" runat="server" CssClass="FormLabel" Text="Size" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblservice" Width="305px" CssClass="FormLabel" runat="server" Text="Service" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblQuntity" Width="30px" CssClass="FormLabel" runat="server" Text="Qnty" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblRate" Width="60px" CssClass="FormLabel" runat="server" Text="Rate" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="CGST Rate" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCGSTAmount" Width="60px" CssClass="FormLabel" runat="server" Text="CGST Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="SGTS Rate" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSGSTAmount" Width="60px" CssClass="FormLabel" runat="server" Text="SGTS Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblIGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="IGST Rate" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblIGSTAmount" runat="server" Width="65px" CssClass="FormLabel" Text="IGST Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotalTaxAmount" Width="80px" CssClass="FormLabel" runat="server" Text="GST Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total Amount" Style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td style="width: 15px"></td>
                                            </tr>
                                            <tr>
                                                <td colspan="17" valign="top" align="left">
                                                    <div class="RepScroling" style="height: 138px;">
                                                        <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                                            <HeaderTemplate>
                                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: -2px;">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:HiddenField ID="hdnCont" runat="server" />
                                                                        <asp:HiddenField ID="hdnLineItemId" Value='<%# Eval("LineItemId") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnLineItem" Value='<%# Eval("LineItem") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnTaxId" runat="server" />
                                                                        <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                                                        <asp:CheckBox ID="chkSelect" Width="15px" runat="server" ToolTip=""></asp:CheckBox>
                                                                    </td>
                                                                    <td class="FormLabel" style="text-align: center; width: 30px; vertical-align: middle;">
                                                                        <%# Container.ItemIndex + 1 %>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textContNo" runat="server" CssClass="FormTextBoxMedium" Width="100px"
                                                                            Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No" MaxLength="11"
                                                                            AutoPostBack="true" OnTextChanged="checkContValid">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textSize" runat="server" Enabled="false" CssClass="FormTextBoxMedium"
                                                                            Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="textService" runat="server" Enabled="false" CssClass="FormListBoxMedium"
                                                                            Width="305px" ToolTip="Service" Text='<%# Eval("ServiceId") %>' OnDataBinding="prepareService">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textQuntity" runat="server" Enabled="false" Text='<%# Eval("BillQnty") %>'
                                                                            ToolTip="Quantity" CssClass="FormTextBoxNumeric" Width="30px">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textRate" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                                            Width="60px" MaxLength="7" Text='<%#  Eval("BillRate") %>' ToolTip="Rate" OnTextChanged="checkContNo"
                                                                            AutoPostBack="true">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="80px" Text='<%# string.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate")) - Eval("WeiverAprAmt")) %>'
                                                                            ToolTip="Amount">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textCGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="60px" Text='<% # Eval("CGSTRate")%>' ToolTip="CGST Rate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textCGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="60px" Text='<% # Eval("CGSTAmount")%>' ToolTip="CGST Amount">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textSGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="60px" Text='<% # Eval("SGSTRate")%>' ToolTip="SGST Rate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textSGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="55px" Text='<% # Eval("SGSTAmount")%>' ToolTip="SGST Amount">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textIGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="60px" Text='<% # Eval("IGSTRate")%>' ToolTip="IGST Rate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textIGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="60px" Text='<% # Eval("IGSTAmount")%>' ToolTip="IGST Amount">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Enabled="false"
                                                                            Width="70px" Text='<%# string.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") *  Eval("BillRate"))-Eval("WeiverAprAmt"))) %>'
                                                                            ToolTip="Tax Amount">
                                                                        </asp:TextBox>
                                                                        <asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                            Width="75px" Text='<%# string.Format("{0:n2}",Eval("BillAmount")) %>' Enabled="false"
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
                                            <tr>
                                                <td width="15px"></td>
                                                <td width="90px"></td>
                                                <td width="30px"></td>
                                                <td width="250px"></td>
                                                <%-- <td width="70px">
                                                </td>
                                                <td width="70px">
                                                </td>--%>
                                                <td width="30px"></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTotal" runat="server" Text="Total " CssClass="FormLabel" Width="60px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepAmount" runat="server" CssClass="RptFormTextBoxNumeric" Width="80px"
                                                        ToolTip="Amount Total" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepCGSTRate" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="55px" ToolTip="CGST Rate" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepCGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="55px" ToolTip="CGST Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepSGSTRate" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="65px" ToolTip="SGST Rate" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepSGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="65px" ToolTip="SGST Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepIGSTRate" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="60px" ToolTip="IGST Rate" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepIGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="60px" ToolTip="IGST Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="70px" ToolTip="Tax Amount Total" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="textRepTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="80px" ToolTip="Total Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>
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
                                                <asp:ImageButton ID="btnProceedPayment" runat="server" Visible="false" ImageUrl="~/Images/btnPayment.png" />
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                                <asp:ImageButton ID="btnCancelInvoice" runat="server" ImageUrl="~/Images/btnCancelInvoice.png" />
                                                <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Images/btnPrint.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:Button ID="Button2" runat="server" Text="New Print" Visible="false" />
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
