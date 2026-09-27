<%@ Page Title="eLoGiFleet::Manuual Invoice" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="SRInvoice.aspx.vb" Inherits="Commercial_Default" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <%-- Start 14/12/2022 --%>
    <script language="javascript" type="text/javascript">
        //Start
        function checkAll(id) {
            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;
                var id1 = document.getElementById("<%=chkSelect.Clientid%>").checked;
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" +
                        LPad((j + 1) + "", 2, "0") +
                        "_chkSelectRow")
                    SelectAmount();
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" +
                            LPad((j + 1) + "", 2, "0") +
                            "_chkSelectRow").checked = id1;
                    }
                }
            }
        }

    </script>
    <%-- End --%>
    <script language="javascript" type="text/javascript">
        function SelectAmount(id) {
            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;
                var tAmount = 0;
                var tServiceTax = 0;
                var tECess = 0;
                var tHEess = 0;
                var tTax = 0;
                var tTotalAmount = 0;
                for (var j = 0; j < rowCount; j++) {
                    var rowCheck = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelectRow").checked;
                    var contNo = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_hdnLineItemId").getAttribute('value');
                    var trAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textAmount").getAttribute('value');
                    var trServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTAmount").getAttribute('value');
                    var trEcessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textSGSTAmount").getAttribute('value');
                    var trHCessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textCGSTAmount").getAttribute('value');
                    var trTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTaxAmount").getAttribute('value');
                    var trTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTotalAmount").getAttribute('value');
                    if (rowCheck == true) {
                        tAmount += parseFloat(trAmount);
                        tServiceTax += parseFloat(trServiceTax);
                        tECess += parseFloat(trEcessTax);
                        tHEess += parseFloat(trHCessTax);
                        tTax += parseFloat(trTax);
                        tTotalAmount += parseFloat(trTotalAmount);
                    }
                    //Added 13/12/2022
                    document.getElementById('<%= textAmountTotal.Clientid %>').value = tAmount;
                    document.getElementById('<%= TxtIGST.Clientid %>').value = tServiceTax;
                    document.getElementById('<%= TextSGST.Clientid %>').value = tECess;
                    document.getElementById('<%= TextCGST.Clientid %>').value = tHEess;
                    document.getElementById('<%= TextTaxTotalAmount.Clientid %>').value = tTax;
                    document.getElementById('<%= textrepTotalAmount.Clientid %>').value = tTotalAmount;
                }
                return true;
            }
        }
         //End
    </script>

    <script language="javascript" type="text/javascript">

        function checkAll(id) {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var id1 = document.getElementById("<%=chkSelect.clientid%>").checked;
                var tAmount = 0;
                var tServiceTax = 0;
                var tECess = 0;
                var tHEess = 0;
                var tTax = 0;
                var tTotalAmount = 0;
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect")
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked = id1;
                        var rowCheck = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked;
                        var contNo = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_hdnLineItemId").value;
                        var trAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textAmount").value.replace(/[^0-9\.]+/g, "");
                        var trServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTAmount").value.replace(/[^0-9\.]+/g, "");
                        var trEcessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textSGSTAmount").value.replace(/[^0-9\.]+/g, "");
                        var trHCessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textCGSTAmount").value.replace(/[^0-9\.]+/g, "");
                        var trTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTaxAmount").value.replace(/[^0-9\.]+/g, "");
                        var trTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTotalAmount").value.replace(/[^0-9\.]+/g, "");
                        if (rowCheck == true) {
                            trAmount = trAmount.replace(",", "");
                            tAmount += parseFloat(trAmount);
                            tServiceTax += parseFloat(trServiceTax);
                            tECess += parseFloat(trEcessTax);
                            tHEess += parseFloat(trHCessTax);
                            tTax += parseFloat(trTax);
                            tTotalAmount += parseFloat(trTotalAmount);

                        }
                    }
                    document.getElementById('<%= textAmountTotal.Clientid %>').value = tAmount.toFixed(2);
                    document.getElementById('<%= TxtIGST.Clientid %>').value = tServiceTax.toFixed(2);
                    document.getElementById('<%= TextSGST.Clientid %>').value = tECess.toFixed(2);
                    document.getElementById('<%= TextCGST.Clientid %>').value = tHEess.toFixed(2);
                    document.getElementById('<%= TextTaxTotalAmount.Clientid %>').value = tTax.toFixed(2);
                    document.getElementById('<%= textrepTotalAmount.Clientid %>').value = tTotalAmount.toFixed(2);

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
                                    <table style="width: 82%; float: left; text-align: left;">
                                        <tr>
                                            <td>
                                                <table width="100%" style="border-color: White;">
                                                    <tr>
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
                                                            <asp:Button ID="BtnInvoiceNo" runat="server" Text="GO" CssClass="FormButton" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date " Style="white-space: nowrap;"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="130px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
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
                                                            <asp:Label ID="lblBookingNo" runat="server" CssClass="FormLabel" Style="white-space: nowrap;" Text="Job No. "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <%--<asp:TextBox ID="textBookingNo" AutoComplete="off" Width="130px"
                                                                runat="server" onkeypress="kp_convert_upper()"
                                                                CssClass="FormTextBoxSmall" ToolTip="Booking No" MaxLength="20">
                                                            </asp:TextBox>--%>
                                                            <asp:TextBox ID="textBookingNo" Width="130px"
                                                                runat="server"
                                                                CssClass="RptFormTextBoxSmall" ToolTip="Booking No" MaxLength="20">
                                                            </asp:TextBox>
                                                            <%--<span class="mandatory">*</span>--%>
                                                            <asp:HiddenField ID="hdnBookingId" runat="server" />
                                                            <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                                                            <asp:HiddenField ID="hdnDocType" runat="server" />
                                                            <asp:HiddenField ID="hdnCancelStatus" runat="server" />
                                                            <%--<asp:Button ID="btnAddBooking" runat="server" Text="GO" CssClass="FormButton" />--%>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblBookingDate" runat="server" CssClass="FormLabel" Style="white-space: nowrap;" Text="Job Date">
                                                            </asp:Label>
                                                        </td>

                                                        <td align="left">
                                                            <asp:TextBox ID="txtBookingDate" runat="server" Width="130px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Job Date">
                                                            </asp:TextBox>

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
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Invoice To "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstInvoiceTo" Width="133px" runat="server"
                                                                CssClass="FormListBoxMedium" ToolTip="Invoice To">
                                                                <asp:ListItem Value="E" Text="Shipper" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="Line"></asp:ListItem>
                                                                <asp:ListItem Value="F" Text="Forwader"></asp:ListItem>
                                                                <asp:ListItem Value="T" Text="Agent"></asp:ListItem>
                                                                <asp:ListItem Value="C" Text="Cha"></asp:ListItem>
                                                                <asp:ListItem Value="I" Text="Importer"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnTaxId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnTaxOnPercentage" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnLineId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnChaId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnServiceId" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnStateCode" runat="server" Value="0" />
                                                            <asp:Button ID="BtnInvoiceTo" runat="server" Text="GO" CssClass="FormButton" />
                                                        </td>
                                                        <td class="tdstyle">
                                                            <asp:Label ID="LblBillpartyName" runat="server" Style="white-space: nowrap;" Text="Bill Paty" CssClass="FormLabel"></asp:Label>
                                                        </td>
                                                        <td class="tdstyle">
                                                            <asp:DropDownList ID="LstBiitoPartyNamne" runat="server" CssClass="FormListBoxMedium">
                                                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>

                                                        <%-- <td align="left">
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

                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstServiceType" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="R" Text="Tax Invoice" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="O" Text="Bill of Supply"></asp:ListItem>
                                                                <asp:ListItem Value="J" Text="Import Invoice"></asp:ListItem>
                                                                <asp:ListItem Value="D" Text="Transportation"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Style="white-space: nowrap;" Text="Invoice Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote" runat="server" Width="463px" CssClass="FormTextBoxSmall"
                                                                TextMode="MultiLine" ToolTip="Note" Height="40px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                            </td>


                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblBankDetails" runat="server" Width="100px" CssClass="FormLabel"
                                                    Text="Bank Details "></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstBank" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                    ToolTip="Bank">
                                                    <asp:ListItem Text="---Select---" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                    <td>
                                        <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 250px; border-left-color: Black;">
                                            <asp:TreeView ID="tvInvoices" runat="server" Style="font-family: Verdana; font-size: 12px"
                                                Width="144px">
                                            </asp:TreeView>
                                        </div>
                                    </td>
                        </tr>
                    </table>
                    <div id="r" style="text-align: left; overflow: auto; width: 100%; margin: 0px auto">
                        <table cellspacing="0" align="center" width="95%">
                            <tr class="RepheaderNew" align="center">
                                <%-- start 14/12/2022 --%>
                                <td>
                                    <asp:Label ID="lblSrNo" Width="50px" Style="white-space: nowrap" runat="server" CssClass="FormLabel" Text="Sr No."></asp:Label>
                                </td>
                                <td style="text-align: center">
                                    <asp:CheckBox ID="chkSelect" onClick="checkAll(this);" CssClass="FormLabel" runat="server"
                                        Text="" Width="15px"></asp:CheckBox>
                                </td>
                                <%-- end --%>
                                <td align="left">
                                    <asp:Label ID="lblchk" runat="server" Width="15px"></asp:Label>
                                </td>
                                <%-- <td>
                                                    <asp:Label ID="lblContNo" Width="90px" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSize" Width="30px" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                                </td>--%>
                                <td>
                                    <asp:Label ID="lblservice" Width="266px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblQuntity" Width="70px" CssClass="FormLabel" runat="server" Text="Qnty"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblExRate" Width="70px" CssClass="FormLabel" runat="server" Text="Ex.Rate"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCurrency" Width="100px" runat="server" CssClass="FormLabel" Text="Currency"></asp:Label>
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
                                    <asp:Label ID="LblSBT" Width="60px" CssClass="FormLabel" runat="server" Text="SGST"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblEducTax" Width="60px" CssClass="FormLabel" runat="server" Text="CGST"></asp:Label>
                                </td>
                                <%--<td>
                                                    <asp:Label ID="lblHeduTax" runat="server" Width="65px" CssClass="FormLabel" Text="HEdu Cess"></asp:Label>
                                                </td>--%>
                                <td>
                                    <asp:Label ID="lblTaxAmount" Width="70px" CssClass="FormLabel" runat="server" Text="Tax"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total"></asp:Label>
                                </td>
                                <%--<td>
                                                    <asp:Label ID="lblWeiverReqAmt" Width="96px" CssClass="FormLabel" runat="server"
                                                        Text="Waiver Request"></asp:Label>
                                                </td>--%>
                            </tr>
                            <tr>
                                <td colspan="14" valign="top">
                                    <div class="RepScroling" style="height: 202px;">
                                        <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                            <HeaderTemplate>
                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px; width: 100%">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <%-- Added 14/12/2022 --%>
                                                    <td style="min-width: 50px; border: 1px solid #B3CBFF; text-align: center; font-size: 8pt; font-family: Verdana;">
                                                        <%# Container.ItemIndex + 1%>
                                                    </td>
                                                    <%-- End --%>
                                                    <td>
                                                        <asp:HiddenField ID="hdnCont" runat="server" />
                                                        <asp:HiddenField ID="hdnLineItemId" Value='<%# Eval("LineItemId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnLineItem" Value='<%# Eval("LineItem") %>' runat="server" />
                                                        <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                                        <asp:CheckBox ID="chkSelectRow" EnableViewState="False" Width="15px" runat="server" ToolTip="" onclick="return SelectAmount(this);"></asp:CheckBox>
                                                    </td>
                                                    <%--  <td>
                                                                        <asp:TextBox ID="textContNo" runat="server" CssClass="RptFormTextBoxMedium" Width="90px"
                                                                            Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textSize" runat="server" Enabled="false" CssClass="RptFormTextBoxMedium"
                                                                            Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                                                        </asp:TextBox>
                                                                        <asp:HiddenField ID="hdnContId" Value='<%# Eval("ImpContId") %>' runat="server" />

                                                                    </td>--%>
                                                    <td>
                                                        <asp:DropDownList CssClass="SRInvoice" ID="lstService" runat="server"
                                                            OnDataBinding="prepareService" ToolTip="Service Name" Text='<%# Eval("ServiceId") %>'>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textQuntity" runat="server" Enabled="false" ToolTip="Quantity" CssClass="FormTextBoxNumeric"
                                                            Width="70px" MaxLength="5" Text='<%# Eval("BillQnty") %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textExRate" AutoComplete="off" runat="server" Enabled="false" ToolTip="Ex Rate" CssClass="FormTextBoxNumeric"
                                                            Width="70px" MaxLength="5" Text='<%# Eval("ExRate") %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="lstCurrency" runat="server" CssClass="FormListBoxLarg" ToolTip="Service Group Name"
                                                            Width="160px">
                                                            <asp:ListItem Value="0">--Select CurrencyType--</asp:ListItem>
                                                            <asp:ListItem Value="INR" Text="INR"></asp:ListItem>
                                                            <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                                                            <asp:ListItem Value="EURO" Text="EURO"></asp:ListItem>
                                                            <asp:ListItem Value="QAR" Text="QAR"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textRate" AutoComplete="off" MaxLength="10" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                            Width="60px" ToolTip="Rate" Text='<%#  Eval("BillRate") %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="80px" ToolTip="Amount" Text='<%#String.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate") * Eval("ExRate")) - Eval("WeiverAprAmt")) %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textIGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" ToolTip="Service Tax" Text='<% # Eval("IGSTAmount")%>'>
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="hdnIGSTTaxPerc" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textCGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" ToolTip="SBT" Text='<% # Eval("CGSTAmount")%>'>
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="hdnCGSTTaxPerc" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textSGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                            Width="60px" ToolTip="KKC" Text='<% # Eval("SGSTAmount")%>'>
                                                        </asp:TextBox>
                                                        <asp:HiddenField ID="hdnSGSTTaxPerc" runat="server" />
                                                    </td>
                                                    <%--<td>
                                                                        <asp:TextBox ID="textHEduTax" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                            Width="65px" Text="" ToolTip="HEdu Tax">
                                                                        </asp:TextBox>
                                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Enabled="false"
                                                            Width="70px" ToolTip="Tax Amount" Text='<%#String.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") * Eval("BillRate") * Eval("ExRate")) - Eval("WeiverAprAmt"))) %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="textTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                            Width="80px" Enabled="false" ToolTip="Total Amount" Text='<%#String.Format("{0:n2}", Eval("BillAmount")) %>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                                        <asp:TextBox ID="textWeiverReqAmt" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                            Width="80px" onkeypress="kp_numeric();" Enabled="false" onchange="return checkWeaverAmt();"
                                                                            ToolTip="Waiver Amount">
                                                                        </asp:TextBox>
                                                                    </td>--%>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                            <%-- Added 13/12/2022 --%>
                            <tr>
                                <td style="height: 10px"></td>
                            </tr>
                            <tr>
                                <td colspan="8" align="right" style="width: 650px">
                                    <asp:Label ID="lblTotal" runat="server" Text="Total " CssClass="FormLabel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="textAmountTotal" runat="server" CssClass="FormTextBoxNumeric" Width="80px"
                                        ToolTip="Amount" Enabled="false">
                                    </asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="TxtIGST" runat="server" CssClass="FormTextBoxNumeric" Width="80px"
                                        ToolTip="IGST" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textSGST" runat="server" CssClass="FormTextBoxNumeric" Width="60px"
                                        ToolTip="SGST" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextCGST" runat="server" CssClass="FormTextBoxNumeric" Width="60px"
                                        ToolTip="CGST" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextTaxTotalAmount" runat="server" CssClass="FormTextBoxNumeric"
                                        Width="60px" ToolTip="Tax Amount" Enabled="false">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textrepTotalAmount" runat="server" CssClass="FormTextBoxNumeric"
                                        Width="75px" ToolTip="Total Amount" Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <%-- End --%>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 65%">
                <asp:CheckBox ID="chkInvoiceChecked" runat="server" CssClass="FormLabel" Text="Invoice Checked" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="dvButton" style="vertical-align: bottom; width: 65%">
                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                        <tr style="margin-top: 0px;">
                            <td align="center">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="FormButton" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="FormButton" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                <asp:Button ID="Button2" runat="server" Text="New Print" Visible="false" />
                                <asp:Button ID="BtnSearch" runat="server" Text="Search"  CssClass="FormButton" />
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


