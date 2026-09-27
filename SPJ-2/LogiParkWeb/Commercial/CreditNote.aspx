<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CreditNote.aspx.vb" Inherits="Commercial_CreditNote" Title="eLOGiFreight:: Credit Note Generation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type='text/javascript'>
        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            for (var j = 0; j < 222; j++) {
                var msg = "Sorry, this functionality is disabled.";
                if (parseInt(code) == j + 1) //CTRL
                {
                    window.event.returnValue = false;
                }
            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        function checkAll(id) {

            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;

                var id1 = document.getElementById("<%=chkSelect.Clientid%>").checked;

                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + LPad((j + 1) + "", 2, "0") + "_ChkCredit")
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + LPad((j + 1) + "", 2, "0") + "_ChkCredit").checked = id1;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function Rate(id) {
            var strsbno = "_textRate";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            var textQuntity = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textQuntity");
            var textRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textRate");
            var textAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textAmount");
            var textServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textServiceTax");
            var textEducTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textEducTax");
            var textHEduTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textHEduTax");
            var textTaxAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTaxAmount");
            var textTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTotalAmount");
            var HdnIgstPer = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_HdnIgstPer").value;
            var Hdnsgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_Hdnsgstper").value;
            var hdncgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_hdncgstper").value;
            var TxtExRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_TxtExRate");
            if (textRate.value == '') { textRate.value = 0; }
            var Rate = parseFloat(textRate.value) * parseFloat(textQuntity.value) * parseFloat(TxtExRate.value);
            textAmount.value = Rate;

            textServiceTax.value = (parseFloat(Rate) / 100 * parseFloat(HdnIgstPer)).toFixed(2);
            textEducTax.value = (parseFloat(Rate) / 100 * parseFloat(Hdnsgstper)).toFixed(2);
            textHEduTax.value = (parseFloat(Rate) / 100 * parseFloat(hdncgstper)).toFixed(2);
            textTaxAmount.value = (parseFloat(textServiceTax.value) + parseFloat(textEducTax.value) + parseFloat(textHEduTax.value)).toFixed(2);
            textTotalAmount.value = (parseFloat(Rate) + parseFloat(textTaxAmount.value)).toFixed(2);
        }
        function qnty(id) {
            var strsbno = "_textQuntity";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            var textQuntity = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textQuntity");
            var textRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textRate");
            var textAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textAmount");
            var textServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textServiceTax");
            var textEducTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textEducTax");
            var textHEduTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textHEduTax");
            var textTaxAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTaxAmount");
            var textTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTotalAmount");
            var HdnIgstPer = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_HdnIgstPer").value;
            var Hdnsgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_Hdnsgstper").value;
            var hdncgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_hdncgstper").value;
            var HdnQnty = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_HdnQnty");
            var TxtExRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_TxtExRate");
            if (textQuntity.value == '') { textQuntity.value = 1; }
            if ((parseFloat(textQuntity.value)) > (parseFloat(HdnQnty.value))) {
                textQuntity.value = HdnQnty.value;
            }
            //else { HdnQnty.value = textQuntity.value; }
            var Rate = parseFloat(textRate.value) * parseFloat(textQuntity.value) * parseFloat(TxtExRate.value);
            textAmount.value = Rate.toFixed(2);
            textServiceTax.value = (parseFloat(Rate) / 100 * parseFloat(HdnIgstPer)).toFixed(2);
            textEducTax.value = (parseFloat(Rate) / 100 * parseFloat(hdncgstper)).toFixed(2);
            textHEduTax.value = (parseFloat(Rate) / 100 * parseFloat(Hdnsgstper)).toFixed(2);
            textTaxAmount.value = (parseFloat(textServiceTax.value) + parseFloat(textEducTax.value) + parseFloat(textHEduTax.value)).toFixed(2);
            textTotalAmount.value = (parseFloat(Rate) + parseFloat(textTaxAmount.value)).toFixed(2);
        }
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Credit Note Generation" CssClass="FormLabelTitle">
                </asp:Label>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel" style="font-weight: 700; font-size: large"></asp:Label>
            </td>

            <td align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red">
                </asp:Label>
                <asp:HiddenField ID="hdnMode" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <hr />
            </td>
        </tr>
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">

                        <tr class="UserControls" style="height: 300px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">

                                    <table width="100%" style="border-color: White;">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCreditRefNo" runat="server" CssClass="FormLabel" Text="Credit No "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCreditRefNo" Width="130px" runat="server" AutoComplete="off" CssClass="FormTextBoxSmall"
                                                    ToolTip="Credit No">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnCreditNo" runat="server" />
                                                <asp:HiddenField ID="hdnrate" runat="server" />
                                                <asp:HiddenField ID="hdnTempInvoiceNo" runat="server" />
                                                <asp:HiddenField ID="hdnPrintStatus" runat="server" />
                                                <asp:HiddenField ID="hdnServiceType" runat="server" />
                                                <asp:HiddenField ID="hdnCHa" runat="server" />
                                                <asp:HiddenField ID="hdnLine" runat="server" />
                                                <asp:HiddenField ID="HdnForwarder" runat="server" />
                                                <asp:Button ID="BtnSearchCredit" runat="server" Visible="false" Text="Go"
                                                    CssClass="FormButton" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCreditDate" runat="server" CssClass="FormLabel" Text="Credit Date "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCreditDate" runat="server" Width="121px" CssClass="FormTextBoxSmall"
                                                    ToolTip="Credit Date">
                                                </asp:TextBox>
                                            </td>
                                            <%-- <td align="left">
                                                            <asp:Label ID="lblExporter" runat="server" CssClass="FormLabel" Text="Exporter "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textExporter" runat="server" Width="274px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Exporter">
                                                            </asp:TextBox>
                                                        </td>--%>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Invoice No "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textInvoiceRefNo" Width="130px" runat="server" CssClass="FormTextBoxSmall"
                                                    ToolTip="Invoice No">
                                                </asp:TextBox>
                                                <asp:Button ID="btnSearchInvoice" runat="server" Visible="false" Text="Go"
                                                    CssClass="FormButton" />
                                                <asp:Button ID="btnAddInvoice" runat="server" Visible="false" Text="Go"
                                                    CssClass="FormButton" />
                                                <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
                                                <asp:HiddenField ID="hdnMaxAmount" runat="server" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textInvoiceDate" runat="server" Width="121px" CssClass="FormTextBoxSmall"
                                                    ToolTip="Invoice Date">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                                <asp:HiddenField ID="hdnBookingId" runat="server" />
                                                <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                                                <asp:HiddenField ID="hdnDocType" runat="server" />
                                                <asp:HiddenField ID="hdnCancelStatus" runat="server" />
                                                <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnItemKeyId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnExporter" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnTaxGroup" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblParty" runat="server" CssClass="FormLabel" Text="Shipper Name "></asp:Label>

                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstParty" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                    ToolTip="Party">
                                                </asp:DropDownList>

                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Shipper Type "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstInvoiceTo" AutoPostBack="true" Width="131px" runat="server"
                                                    CssClass="FormListBoxMedium" ToolTip="Invoice To">
                                                    <asp:ListItem Value="E" Text="Shipper"></asp:ListItem>
                                                    <asp:ListItem Value="F" Text="Forwader"></asp:ListItem>
                                                    <asp:ListItem Value="T" Text="Agent"></asp:ListItem>
                                                    <asp:ListItem Value="C" Text="Cha"></asp:ListItem>
                                                    <asp:ListItem Value="L" Text="Line"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnCustomer" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <td align="left">
                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                        </td>
                                        <td align="left">
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
                                                <asp:ListItem Value="X" Text="Import Invoice"></asp:ListItem>
                                                <asp:ListItem Value="J" Text="Import Invoice"></asp:ListItem>
                                                <asp:ListItem Value="S" Text="FAIR GROUP"></asp:ListItem>
                                                <asp:ListItem Value="D" Text="TPT REBATE"></asp:ListItem>
                                                <asp:ListItem Value="E" Text="AL-ALI/MARHABA"></asp:ListItem>
                                                <asp:ListItem Value="V" Text="Bill of Supply-AL-ALI/MARHABA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Text="Invoice Note "></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="textNote1" runat="server" Width="463px" CssClass="FormTextBoxSmall"
                                                ToolTip="Note" Height="30px"></asp:TextBox>
                                        </td>
                                        <tr>
                                            <td align="left"></td>
                                            <td align="left"></td>
                                            <td align="left"></td>
                                        </tr>
                                    </table>
                                </div>
                            </td>

                            <td valign="top">
                                <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 250px; border-left-color: Black;">
                                    <asp:TreeView ID="tvInvoices" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="r" style="overflow: auto; height: 100%; text-align: left">
                        <table cellspacing="0" align="left">
                            <tr class="RepHead" align="center">
                                <td align="left">
                                    <asp:CheckBox ID="chkSelect1" runat="server" Width="15px"></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblContNo" Width="90px" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSize" Width="30px" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCargoType" Width="70px" runat="server" CssClass="FormLabel" Text="Cargo Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblservice" Width="250px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblQuntity" Width="30px" CssClass="FormLabel" runat="server" Text="Qnty"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRate" Width="60px" CssClass="FormLabel" runat="server" Text="Rate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblServiceTax" Width="60px" CssClass="FormLabel" runat="server" Text="IGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEducTax" Width="60px" CssClass="FormLabel" runat="server" Text="SGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHeduTax" runat="server" Width="65px" CssClass="FormLabel" Text="CGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTaxAmount" Width="70px" CssClass="FormLabel" runat="server" Text="Tax Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total Amount"></asp:Label>
                                </td>
                                <td style="width: 15px"></td>
                            </tr>
                            <tr>
                                <td colspan="14" valign="top" align="left">
                                    <div class="RepScroling" style="height: 100px;">
                                        <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                            <HeaderTemplate>
                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px;">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <%--  <td style="width: 17px">
                                                                        <asp:CheckBox ID="ChkCredit" runat="server" CssClass="FormCheckBox" />
                                                                    </td>--%>
                                                    <td>
                                                        <asp:HiddenField ID="hdnLineItemId" Value='<%# Eval("LineItemId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnLineItem" Value='<%# Eval("LineItem") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnTaxId" runat="server" />
                                                        <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                                        <asp:CheckBox ID="chkSelect1" Width="15px" runat="server" ToolTip=""></asp:CheckBox>
                                                        <%-- <asp:CheckBox ID="chkSelect" Width="15px" runat="server" ToolTip="" AutoPostBack="true">
                                                                        </asp:CheckBox>--%>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textContNo" runat="server" CssClass="FormTextBoxMedium" Width="90px"
                                                            Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textSize" runat="server" Enabled="false" CssClass="FormTextBoxMedium"
                                                            Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textCargoType" runat="server" Enabled="false" CssClass="FormTextBoxMedium"
                                                            Width="70px" Text='<%# Eval("CargoType") %>' ToolTip="Cargo Type">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="textService" runat="server" Enabled="false" CssClass="FormListBoxMedium"
                                                            Width="250px" ToolTip="Service" Text='<%# Eval("ServiceId") %>' OnDataBinding="prepareService">
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
                                                            Width="60px" Text='<%#  Eval("BillRate") %>' onkeypress="kp_phonenumber();" ToolTip="Rate" AutoPostBack="true">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="80px" Text='<%#String.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate")) - Eval("WeiverAprAmt")) %>'
                                                            ToolTip="Amount">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textServiceTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" Text="" ToolTip="Service Tax">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textEducTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" Text="" ToolTip="Educ Tax">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textHEduTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="65px" Text="" ToolTip="HEdu Tax">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Enabled="false"
                                                            Width="70px" Text='<%#String.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") * Eval("BillRate")) - Eval("WeiverAprAmt"))) %>'
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
                            <tr>
                                <td width="15px"></td>
                                <td width="90px"></td>
                                <td width="30px"></td>
                                <td width="70px"></td>
                                <td width="250px"></td>
                                <td width="70px"></td>
                                <td align="right">
                                    <asp:Label ID="lblTotal" runat="server" Text="Total " CssClass="FormLabel" Width="60px"></asp:Label>
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
                                        Width="65px" ToolTip="HEduc Tax" Enabled="false">
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
                                <%-- <td>
                                                    <asp:TextBox ID="textRepWeiverReqAmt" runat="server" CssClass="RptFormTextBoxNumeric"
                                                        Width="96px" ToolTip="Total Weiver Request Amount" Enabled="false">
                                                    </asp:TextBox>
                                                </td>--%>
                            </tr>
                        </table>
                    </div>
                    <div id="Div1" style="text-align: left; overflow: auto; height: 160px;">
                        <table align="left" cellspacing="0">
                            <tr class="RepHead" align="center">
                                <td style="width: 17px">
                                    <asp:CheckBox ID="chkSelect" Height="20px" runat="server" Width="20px" ToolTip=""
                                        onClick="checkAll(this);"></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" Width="250px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" Width="30px" CssClass="FormLabel" runat="server" Text="Qnty"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" Width="30px" CssClass="FormLabel" runat="server" Text="Ex Rate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" Width="60px" CssClass="FormLabel" runat="server" Text="Credit Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" Width="80px" CssClass="FormLabel" runat="server" Text="Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" Width="60px" CssClass="FormLabel" runat="server" Text="IGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" Width="60px" CssClass="FormLabel" runat="server" Text="SGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Width="65px" CssClass="FormLabel" Text="CGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" Width="70px" CssClass="FormLabel" runat="server" Text="Tax Amount"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" Width="120px" CssClass="FormLabel" runat="server" Text="Total Amount"></asp:Label>
                                </td>
                                <td style="width: 15px"></td>
                            </tr>
                            <tr>
                                <td colspan="12" valign="top">
                                    <div class="RepScroling" style="height: 100px;">
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <HeaderTemplate>
                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px;">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 17px">
                                                        <asp:CheckBox ID="ChkCredit" runat="server" CssClass="FormCheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="textService" runat="server" Enabled="false" CssClass="FormListBoxMedium"
                                                            Width="250px" Text='<%# Eval("ServiceId") %>' ToolTip="Service" OnDataBinding="prepareService">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                        <asp:HiddenField ID="HdnImpContId" Value='<%# Eval("crrefId") %>' runat="server" />
                                                        <asp:HiddenField ID="HdnIgstPer" runat="server" />
                                                        <asp:HiddenField ID="Hdnsgstper" runat="server" />
                                                        <asp:HiddenField ID="hdncgstper" runat="server" />
                                                        <asp:HiddenField ID="HdnItemKeyid" runat="server" Value='<%# Eval("InvItemKeyId") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textQuntity" runat="server" Text='<%# Eval("BillQnty") %>' ToolTip="Quantity"
                                                            CssClass="FormTextBoxNumeric" Width="30px" onchange="qnty(this);">
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="HdnQnty" runat="server" Value='<%# Eval("BillQnty") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TxtExRate" runat="server" Text='<%# Eval("ExRate") %>' ToolTip="Quantity"
                                                            CssClass="RptFormTextBoxNumeric" Width="30px" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="HdnCurrency" runat="server" Value='<%# Eval("Currency") %>' />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textRate" runat="server" Enabled="True" CssClass="FormTextBoxNumeric"
                                                            Width="60px" Text='<%#  Eval("ServiceAmt") %>' ToolTip="Rate" onchange="Rate(this);">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textAmount" runat="server" CssClass="RptFormTextBoxNumeric" Width="80px"
                                                            Text='<%# Eval("CrAmt") %>' ToolTip="Amount" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textServiceTax" runat="server" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" Text='<%# Eval("IGST") %>' ToolTip="Service Tax" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textEducTax" runat="server" CssClass="RptFormTextBoxNumeric" Width="60px"
                                                            Text='<%# Eval("SGST") %>' ToolTip="Educ Tax" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textHEduTax" runat="server" CssClass="RptFormTextBoxNumeric" Width="65px"
                                                            Text='<%# Eval("CGST") %>' ToolTip="HEdu Tax" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Width="70px"
                                                            Text='<%# Eval("CrTax") %>' ToolTip="Tax Amount" onKeyDown="return noCTRL(event)">
                                                        </asp:TextBox>
                                                        <%--<asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textTotalAmount" runat="server" CssClass="RptFormTextBoxNumericLeft"
                                                            Width="70px" Text='<%#String.Format("{0:n2}", (Eval("CrAmt") + Eval("CrTax"))) %>'
                                                            ToolTip="Total Amount" AutoPostBack="true" onKeyDown="return noCTRL(event)">
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
                                <asp:Button ID="btnAdd" runat="server" CssClass="FormButton" Text="Add" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="FormButton" Text="Search" />
                                <asp:Button ID="btnPrint" runat="server" CssClass="FormButton" Text="Print" />
                                <asp:Button ID="btnPreview" runat="server" CssClass="FormButton" Text="Preview" Visible="False" />
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
</asp:Content>
