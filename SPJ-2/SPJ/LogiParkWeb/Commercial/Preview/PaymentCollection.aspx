<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PaymentCollection.aspx.vb" Inherits="Commercial_PaymentCollection"
    Title="eLOGiFleet :: Payment Collection" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/jscript" language="javascript">

        function PaymentMode(id) {
            var strsbno = "_lstPaymentMode";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));

            var PaymentMode = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_lstPaymentMode");
            var ChequeNo = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textChequeNo");
            var Branch = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textBranch");
            var Recon = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textReconcilationDate");


            var ChequeDate = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textChequeDate");
            var BankDetails = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_lstBankName");

            if ((PaymentMode.getAttribute('value') == 'C') || (PaymentMode.getAttribute('value') == 'T') || (PaymentMode.getAttribute('value') == 'S')) {
                ChequeNo.setAttribute('disabled', true);
                Branch.setAttribute('disabled', true);
                Recon.setAttribute('disabled', true);
                ChequeDate.setAttribute('disabled', true);
                BankDetails.setAttribute('disabled', true);
            }
            else if (PaymentMode.getAttribute('value') == 'P') {
                ChequeNo.setAttribute('disabled', false);

                ChequeDate.setAttribute('disabled', true);
                BankDetails.setAttribute('disabled', true);
            }
            else {
                ChequeNo.setAttribute('disabled', false);
                ChequeDate.setAttribute('disabled', false);
                Branch.setAttribute('disabled', false);
                Recon.setAttribute('disabled', false);

                BankDetails.setAttribute('disabled', false);
            }

        }
        function PaymentAmount(id) {
            var strsbno = "_textPaymentAmount";
            var totalPaymentAmount = 0;
            var totalRecBalanceAmount = 0;
            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));

            var PaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
            var RecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl" + tablename + "_textRecBalanceAmount");

            if (PaymentAmount.getAttribute('value') == null || PaymentAmount.getAttribute('value') == '' || PaymentAmount.getAttribute('value') == '0') {
                PaymentAmount.setAttribute('value', 0);
            }
            if (PaymentAmount.getAttribute('value') == null || PaymentAmount.getAttribute('value') == '' || PaymentAmount.getAttribute('value') == '0') {
                PaymentAmount.setAttribute('value', 0);
            }
            if (RecBalanceAmount.getAttribute('value') == null || RecBalanceAmount.getAttribute('value') == '' || RecBalanceAmount.getAttribute('value') == '0') {
                RecBalanceAmount.setAttribute('value', 0);
            }
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            if (textPaidAmountTotal.getAttribute('value') == null || textPaidAmountTotal.getAttribute('value') == '' || textPaidAmountTotal.getAttribute('value') == '0') {
                textPaidAmountTotal.setAttribute('value', 0);
            }
            var PymtType = document.getElementById("<%=lstPaymentType.clientid%>").getAttribute("value");
            var PreviousReceiptBal = 0;
            if (PymtType == 'I') {
                PreviousReceiptBal = document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute("value");
            }
            else {
                PreviousReceiptBal = 0;
            }
            totalPaymentAmount = parseFloat(totalPaymentAmount) + parseFloat(PaymentAmount.getAttribute('value'));
            RecBalanceAmount.setAttribute('value', (parseFloat(PreviousReceiptBal) + parseFloat(PaymentAmount.getAttribute('value')) - parseFloat(textPaidAmountTotal.getAttribute('value'))));
            totalRecBalanceAmount = parseFloat(totalRecBalanceAmount) + parseFloat(RecBalanceAmount.getAttribute('value'));
            texttotalPaymentAmount.setAttribute('value', totalPaymentAmount);
            textRecBalanceAmountTotal.setAttribute('value', totalRecBalanceAmount);

            if (parseFloat(texttotalPaymentAmount.getAttribute('value')) > 0) {

                if (PymtType == 'I') {
                    var strsbno1 = "_textPaymentAmount";
                    var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                    for (var j = 0; j < tablename1; j++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").setAttribute('disabled', false);
                        document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").setAttribute('disabled', false);

                    }
                }

            }

        }

        function CalcInvoice(id) {
            var rtnval = true;
            var strsbno = "_chkSelect";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            if (tablename == null || tablename == '') {
                strsbno = "_textPaidAmount";
                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            }

            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");

            if (texttotalPaymentAmount.getAttribute('value') == null || texttotalPaymentAmount.getAttribute('value') == '') {
                texttotalPaymentAmount.setAttribute('value', 0);
            }

            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");

            if (textRecBalanceAmountTotal.getAttribute('value') == null || textRecBalanceAmountTotal.getAttribute('value') == '') {
                textRecBalanceAmountTotal.setAttribute('value', 0);
            }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            if (textToPayAmount.getAttribute('value') == null || textToPayAmount.getAttribute('value') == '') {
                textToPayAmount.setAttribute('value', 0);
            }
            if (textBalanceAmount.getAttribute('value') == null || textBalanceAmount.getAttribute('value') == '') {
                textBalanceAmount.setAttribute('value', 0);
            }
            if (textPaidAmount.getAttribute('value') == null || textPaidAmount.getAttribute('value') == '') {
                textPaidAmount.setAttribute('value', 0);
            }

            if (textInvoiceMode.getAttribute('value') == 'Cash') {
                if (parseFloat(textPaidAmount.getAttribute('value')) > 0 && (parseFloat(textPaidAmount.getAttribute('value')) != parseFloat(hdnBalanceAmount.getAttribute('value')))) {
                    alert('Paid Amount should be equal to Balance Amount');
                    textPaidAmount.focus();
                    rtnval = false;
                }
            }
            else if (textInvoiceMode.getAttribute('value') == 'Credit') {
                if (parseFloat(textPaidAmount.getAttribute('value')) > parseFloat(hdnBalanceAmount.getAttribute('value'))) {
                    alert('Paid Amount should not be more than balance Amount');
                    textPaidAmount.focus();
                    rtnval = false;
                }
                if (parseFloat(textPaidAmount.getAttribute('value')) > parseFloat(textRecBalanceAmountTotal.getAttribute('value'))) {
                    alert('Not Sufficent Balance.');
                    textPaidAmount.focus();
                    rtnval = false;
                }

            }
            //   if (parseFloat(texttotalPaymentAmount.getAttribute('value')) <= 0)
            //   {
            //          alert('Enter the Payment Details');
            //            document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
            //          rtnval =false;
            //   }
            if (parseFloat(textRecBalanceAmountTotal.getAttribute('value')) <= 0) {
                alert('No Balance, Enter The Payment Details');
                document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
                rtnval = false;
            }
            if (rtnval == true) {
                var tempBalnnceAmount = (parseFloat(textToPayAmount.getAttribute('value')) - parseFloat(textPaidAmount.getAttribute('value')));
                textBalanceAmount.setAttribute('value', tempBalnnceAmount);


                var strsbno1 = "_textPaymentAmount";
                var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                var temptextPaidAmountTotal = 0;
                var temptextBalanceAmountTotal = 0;

                var temptexttotalPaymentAmount = 0;
                var temptextRecBalanceAmountTotal = 0;
                for (var j = 0; j < tablename1; j++) {

                    var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").getAttribute('value');
                    var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textBalanceAmount").getAttribute('value');

                    temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                    textPaidAmountTotal.setAttribute('value', temptextPaidAmountTotal);
                    temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                    textBalanceAmountTotal.setAttribute('value', temptextBalanceAmountTotal);

                    var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value');
                    if (prevBal == null || prevBal == '') {
                        document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value', 0);
                        prevBal = 0;
                    }

                    var temp = parseFloat(texttotalPaymentAmount.getAttribute('value')) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal);
                    textRecBalanceAmountTotal.setAttribute('value', temp);
                    document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textRecBalanceAmount").setAttribute('value', temp);
                }

            }


            return rtnval;
        }

        function OnCheckInvoice(id) {
            var rtnval = true;
            var strsbno = "_chkSelect";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            if (tablename == null || tablename == '') {
                strsbno = "_textPaidAmount";
                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            }

            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            if (texttotalPaymentAmount.getAttribute('value') == null || texttotalPaymentAmount.getAttribute('value') == '') {
                texttotalPaymentAmount.setAttribute('value', 0);
            }
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");

            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");

            if (textRecBalanceAmountTotal.getAttribute('value') == null || textRecBalanceAmountTotal.getAttribute('value') == '') {
                textRecBalanceAmountTotal.setAttribute('value', 0);
            }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            if (textToPayAmount.getAttribute('value') == null || textToPayAmount.getAttribute('value') == '') {
                textToPayAmount.setAttribute('value', 0);
            }
            if (textBalanceAmount.getAttribute('value') == null || textBalanceAmount.getAttribute('value') == '') {
                textBalanceAmount.setAttribute('value', 0);
            }
            if (textPaidAmount.getAttribute('value') == null || textPaidAmount.getAttribute('value') == '') {
                textPaidAmount.setAttribute('value', 0);
            }

            if (textInvoiceMode.getAttribute('value') == 'Cash') {
                if (chkSelect.getAttribute('checked') == true && (parseFloat(textRecBalanceAmountTotal.getAttribute('value')) < parseFloat(hdnBalanceAmount.getAttribute('value')))) {
                    alert('Not Sufficent Balance');
                    document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
                    rtnval = false;
                }
                else {
                    if (chkSelect.getAttribute('checked') == true) {
                        textPaidAmount.setAttribute('value', parseFloat(hdnBalanceAmount.getAttribute('value')));
                    }
                    else {
                        textBalanceAmount.setAttribute('value', parseFloat(textPaidAmount.getAttribute('value')));
                        textPaidAmount.setAttribute('value', 0);

                    }

                    var tempBalnnceAmount = (parseFloat(textToPayAmount.getAttribute('value')) - parseFloat(textPaidAmount.getAttribute('value')));
                    textBalanceAmount.setAttribute('value', tempBalnnceAmount);


                    var strsbno1 = "_textPaymentAmount";
                    var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                    var temptextPaidAmountTotal = 0;
                    var temptextBalanceAmountTotal = 0;

                    var temptexttotalPaymentAmount = 0;
                    var temptextRecBalanceAmountTotal = 0;
                    for (var j = 0; j < tablename1; j++) {

                        var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").getAttribute('value');
                        var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textBalanceAmount").getAttribute('value');

                        temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                        textPaidAmountTotal.setAttribute('value', temptextPaidAmountTotal);
                        temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                        textBalanceAmountTotal.setAttribute('value', temptextBalanceAmountTotal);
                        var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value');
                        if (prevBal == null || prevBal == '') {
                            document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value', 0);
                            prevBal = 0;
                        }

                        var temp = parseFloat(texttotalPaymentAmount.getAttribute('value')) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal);
                        textRecBalanceAmountTotal.setAttribute('value', temp);
                        document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textRecBalanceAmount").setAttribute('value', temp);
                    }

                }



            }
            else if (textInvoiceMode.getAttribute('value') == 'Credit') {
                var newPaidAmount = 0;
                if (chkSelect.getAttribute('checked') == true && parseFloat(textRecBalanceAmountTotal.getAttribute('value')) <= 0) {
                    alert('Not Sufficent Balance');
                    document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
                    rtnval = false;
                }
                else if (parseFloat(textRecBalanceAmountTotal.getAttribute('value')) >= 0) {
                    if (chkSelect.getAttribute('checked') == true) {
                        if (parseFloat(textRecBalanceAmountTotal.getAttribute('value')) < parseFloat(hdnBalanceAmount.getAttribute('value'))) {
                            newPaidAmount = parseFloat(textRecBalanceAmountTotal.getAttribute('value'));
                        }
                        else if (parseFloat(textRecBalanceAmountTotal.getAttribute('value')) >= parseFloat(hdnBalanceAmount.getAttribute('value'))) {
                            newPaidAmount = parseFloat(hdnBalanceAmount.getAttribute('value'));
                        }

                    }
                    else {

                        textBalanceAmount.setAttribute('value', parseFloat(textPaidAmount.getAttribute('value')) + parseFloat(textBalanceAmount.getAttribute('value')));
                        textPaidAmount.setAttribute('value', 0);
                        newPaidAmount = 0;
                    }

                    textPaidAmount.setAttribute('value', newPaidAmount);
                    var tempBalnnceAmount = (parseFloat(textBalanceAmount.getAttribute('value')) - parseFloat(textPaidAmount.getAttribute('value')));
                    textBalanceAmount.setAttribute('value', tempBalnnceAmount);


                    var strsbno1 = "_textPaymentAmount";
                    var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                    var temptextPaidAmountTotal = 0;
                    var temptextBalanceAmountTotal = 0;

                    var temptexttotalPaymentAmount = 0;
                    var temptextRecBalanceAmountTotal = 0;
                    for (var j = 0; j < tablename1; j++) {

                        var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").getAttribute('value');
                        var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textBalanceAmount").getAttribute('value');

                        temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                        textPaidAmountTotal.setAttribute('value', temptextPaidAmountTotal);
                        temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                        textBalanceAmountTotal.setAttribute('value', temptextBalanceAmountTotal);
                        var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value');
                        if (prevBal == null || prevBal == '') {
                            document.getElementById("<%=textPreviousBalance.clientid%>").getAttribute('value', 0);
                            prevBal = 0;
                        }

                        var temp = parseFloat(texttotalPaymentAmount.getAttribute('value')) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal);

                        textRecBalanceAmountTotal.setAttribute('value', temp);
                        document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textRecBalanceAmount").setAttribute('value', temp);
                    }
                }
                //                 else if (chkSelect.getAttribute('checked') == false )
                //                 {
                //                 
                //                 }

            }


            return rtnval;
        }
        function check(dodate) {
            var str1 = dodate.getAttribute('value').split('/');
            if (str1 != '') {
                var mm1 = str1[1];
                var dd1 = str1[0];
                var yy1 = str1[2];
                var today = new Date();
                var dd2 = today.getDate();
                var mm2 = today.getMonth() + 1;
                var yy2 = today.getFullYear();
                if (yy2 >= yy1) {
                    if (yy2 == yy1) {
                        if (mm2 >= mm1) {
                            if (mm2 == mm1) {
                                if (dd2 < dd1) {
                                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                                    dodate.value = '';
                                    dodate.style.border = '1px solid red';
                                    dodate.focus();
                                    return false;
                                }
                                else {
                                    dodate.style.border = '1px solid #B3CBFF';
                                }
                            }
                            else {
                                dodate.style.border = '1px solid #B3CBFF';
                            }
                        }
                        else {
                            alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                            dodate.value = '';
                            dodate.style.border = '1px solid red';
                            dodate.focus();
                            return false;
                        }
                    }
                    else {
                        dodate.style.border = '1px solid #B3CBFF';
                    }
                }
                else {
                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                    dodate.value = '';
                    dodate.style.border = '1px solid red';
                    dodate.focus();
                    return false;
                }
            }
            else {
                dodate.style.border = '1px solid #B3CBFF';
            }
        }
    </script>
    <table width="100%">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr>
                        <td valign="top" style="width: 20%">
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Payment Collection" class="FormLabelTitle">
                            </asp:Label>
                        </td>
                        <td valign="top" style="width: 80%">
                            <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
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
            </td>
        </tr>
        <tr>
            <td align="left">
                <div id="dvMain" runat="server" style="overflow: auto; width: 100%; height: 400px;">
                    <table>
                        <tr style="height: 70px;">
                            <td valign="top" width="100%">
                                <div id="dvCustomer" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPaymentType" runat="server" Width="150" ToolTip="Payment Type" CssClass="FormListBoxSmall">
                                                    <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="I" Text="Invoice"></asp:ListItem>
                                                    <asp:ListItem Value="A" Text="Advance"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblCustomer" runat="server" Text="Customer " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstCustomer" Width="300" runat="server" ToolTip="Customer" CssClass="FormListBoxLarg"></asp:DropDownList>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                                </td>
                                            <td>
                                                <asp:Label ID="lblFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="120px" ID="textPreviousBalance0" runat="server" ToolTip="Previous Balance"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:ImageButton ID="btnDisplay" runat="server" Visible="false" ImageUrl="~/Images/btnSearchtop.png" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblReceiptNo" runat="server" Text="Receipt No" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textReceiptNo" Width="130" runat="server" ToolTip="Receipt No" onkeypress="kp_convert_upper()" CssClass="FormTextBoxMedium">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                                            </td>
                                            <td align="left">
                                                <asp:ImageButton ID="btnSearchDisplay" runat="server" Visible="false"
                                                    ImageUrl="~/Images/brnAddtop.png" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceiptDate" runat="server" Text="Receipt Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textReceiptdate" Width="120" runat="server" ToolTip="Receipt Date" CssClass="RptFormTextBoxMedium">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPreviousreceiptNo" CssClass="FormLabel" BackColor="White" Font-Bold="true" runat="server" Text="Previous Receipt">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="130px" ID="textPreviousReceiptNo" runat="server" ToolTip="Previous Receipt No"></asp:TextBox>
                                                <asp:HiddenField ID="hdnPreviousReceiptNo" runat="server" />
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblPreviousBalance" CssClass="FormLabel" BackColor="White" Font-Bold="true" runat="server" Text="Previous Balance">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="120px" ID="textPreviousBalance" runat="server" ToolTip="Previous Balance"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 250px;">
                            <td valign="top" align="left" colspan="2">
                                <table>
                                    <tr>
                                        <td valign="top" align="left">
                                            <table style="text-align: left;">
                                                <tr class="RepHead">
                                                    <td align="center" colspan="8">
                                                        <asp:Label ID="lblPaymentDetails" Width="120px" runat="server" Font-Bold="true" CssClass="FormLabel"
                                                            Text="Payment Details"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="RepHead">
                                                    <td align="center">
                                                        <asp:Label ID="lblPaymentMode" CssClass="FormLabel" Width="100px" runat="server" Text="Payment Mode"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblChequeNo" CssClass="FormLabel" Width="90px" runat="server" Text="Instrument No"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblChequeDate" CssClass="FormLabel" Width="110px" runat="server" Text="Instrument Date"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblReconcilationDate" CssClass="FormLabel" Width="120px" runat="server" Text="Reconciliation Date"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBankName" CssClass="FormLabel" Width="300px" runat="server" Text="Bank Name"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBranch" CssClass="FormLabel" Width="140px" runat="server" Text="Branch"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblPaymentAmount" CssClass="FormLabel" Width="100px" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBalanceAmount" CssClass="FormLabel" Width="103px" runat="server"
                                                            Text="Balance Amount"></asp:Label>
                                                    </td>
                                                    <td align="center" width="15px" style="background-color: White">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="RepScroling" style="height: 52px; width: 1100px;">
                                                <asp:Repeater ID="repPaymentDetails" runat="server">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" cellpadding="0" id="pymt">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%--onchange="PaymentMode(this)"--%>
                                                                <asp:DropDownList class="FormListBoxLarg" Width="105px" ID="lstPaymentMode" runat="server"
                                                                     text='<%# Eval("ReceiptMode") %>' ToolTip="Payment Mode">
                                                                    <asp:ListItem Text="Cash" Value="C" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Cheque" Value="H"></asp:ListItem>
                                                                    <asp:ListItem Text="DD" Value="D"></asp:ListItem>
                                                                    <asp:ListItem Text="RTGS" Value="R"></asp:ListItem>
                                                                    <asp:ListItem Text="ADVC" Value="A"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="90px" ID="textChequeNo" runat="server"
                                                                    onkeypress="kp_integer();" MaxLength="6" Text='<%# Eval("ChequeNo") %>' ToolTip="Cheque\DD No"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="110px" ID="textChequeDate" runat="server"
                                                                    Text='<%# Eval("ChequeDate") %>' ToolTip="Cheque\DD Date" onblur="check(this);"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="clChequeDate" runat="server" Format="dd/MM/yyyy"
                                                                    TargetControlID="textChequeDate" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="120px" ID="textReconcilationDate" runat="server"
                                                                    Text='<%# Eval("ReconcilationDate") %>' ToolTip="Cheque\DD Date" MaxLength="10"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                    TargetControlID="textReconcilationDate" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList class="FormListBoxLarg" Width="305px" ID="lstBankName" runat="server"
                                                                    text='<%# Eval("BankId") %>' ToolTip="Bank Name">
                                                                    <asp:ListItem Value="0" Text="---- Select ----"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="State Bank of India"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Punjab National Bank"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="ICICI Bank"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="140px" ID="textBranch" runat="server"
                                                                    ToolTip="Branch" Text='<%# Eval("Branch") %>' MaxLength="20"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textPaymentAmount" runat="server"
                                                                    onchange="return PaymentAmount(this);" onkeypress="kp_numeric();" Text='<%# string.Format("{0:n2}" ,Eval("Amount")) %>'
                                                                    ToolTip="Amount"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textRecBalanceAmount" runat="server"
                                                                    onkeypress="kp_numeric();" ToolTip="Balance Amount"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <table cellspacing="0" cellpadding="0">
                                                <tr align="right">
                                                    <td align="right">
                                                        <asp:Label ID="Label8" Width="885px" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                            runat="server" Text="Total" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textTotalAmount" runat="server"
                                                            ToolTip="Total Amount"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textRecBalanceAmountTotal"
                                                            runat="server" ToolTip="Total Balance Amount"></asp:TextBox>
                                                    </td>
                                                    <td align="center" width="20px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" align="left">
                                            <table style="text-align: left;">
                                                <tr class="RepHead">
                                                    <td align="center" colspan="10">
                                                        <asp:Label ID="lblInvoiceDetails" runat="server" Font-Bold="true" CssClass="FormLabel"
                                                            Text="Invoice Details"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="RepHead">
                                                    <td align="center">
                                                        <asp:Label ID="lblInvoiceRefNo" CssClass="FormLabel" Width="120px" runat="server"
                                                            Text="Invoice Ref No"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblInvoiceDate" CssClass="FormLabel" Width="110px" runat="server"
                                                            Text="Invoice Date"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblInvoiceMode" CssClass="FormLabel" Width="90px" runat="server" Text="Invoice Mode"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBookingRefNo" CssClass="FormLabel" Width="120px" runat="server"
                                                            Text="Booking Ref No"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBookingDate" CssClass="FormLabel" Width="110px" runat="server"
                                                            Text="Booking Date"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBillAmount" CssClass="FormLabel" Width="100px" runat="server" Text="Bill Amount"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblWaiverApprove" CssClass="FormLabel" Width="100px" runat="server"
                                                            Text="Waiver Amount"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblToPayAmount" CssClass="FormLabel" Width="100px" runat="server"
                                                            Text="To Pay Amount"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblBananceAmount" CssClass="FormLabel" Width="100px" runat="server"
                                                            Text="Balance Amount"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblPaidAmount" CssClass="FormLabel" Width="100px" runat="server" Text="Paid Amount"></asp:Label>
                                                    </td>
                                                    <td align="center" width="10px" style="background-color: White">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 100px; overflow: auto;">
                                                <asp:Repeater ID="repInvoiceDetails" runat="server">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" cellpadding="0" id="inv">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxLarg" Width="120px" ID="textInvoiceRefNo" runat="server"
                                                                    ToolTip="Invoice Ref No">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="110px" ID="textInvoiceDate" runat="server"
                                                                    ToolTip="Invoice Date"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="90px" ID="textInvoiceMode" runat="server"
                                                                    ToolTip="Invoice Mode"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnPaymentMode" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="120px" ID="textBookingRefNo" runat="server"
                                                                    ToolTip="Booking Ref No"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxSmall" Width="110px" ID="textBookingDate" runat="server"
                                                                    ToolTip="Booking Date"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnBookingNo" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBillAmount" runat="server"
                                                                    onkeypress="kp_numeric();" Text='<%# string.Format("{0:n2}", Eval("DrAmount")) %>'
                                                                    ToolTip="Bill Amount"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textWaiverAmount" runat="server"
                                                                    onkeypress="kp_numeric();" ToolTip="Waiver Amount"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textToPayAmount" runat="server"
                                                                    onkeypress="kp_numeric();" Text='<%# string.Format("{0:n2}",Eval("CrAmount")) %>'
                                                                    ToolTip="To Pay Amount"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBalanceAmount" runat="server"
                                                                    onkeypress="kp_numeric();" ToolTip="Balance Amount"></asp:TextBox>
                                                                <asp:HiddenField ID="hdnBalanceAmount" runat="server" />
                                                                <asp:HiddenField ID="hdnTaxExemptionPerc" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textPaidAmount" runat="server"
                                                                    onchange="return CalcInvoice(this);" onkeypress="kp_numeric();" Text='<%# string.Format("{0:n2}", Eval("CrAmount")) %>'
                                                                    ToolTip="Paid Amount"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox Width="20px" ID="chkSelect" runat="server" onClick="return OnCheckInvoice(this);"
                                                                    ToolTip="Select"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <table cellspacing="0" cellpadding="0">
                                                <tr align="right">
                                                    <td colspan="4">
                                                        <asp:Label ID="lblGrandTotal" Width="570px" CssClass="FormLabel" BackColor="White"
                                                            Font-Bold="true" runat="server" Text="Total ">
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBillAmountTotal" runat="server"
                                                            onkeypress="kp_numeric();" ToolTip="Bill Amount Total"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textWaiverAmountotal" runat="server"
                                                            onkeypress="kp_numeric();" ToolTip="Waiver Amount Total"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textToPayAmountTotal" runat="server"
                                                            onkeypress="kp_numeric();" ToolTip="To Pay Amount Total"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBalanceAmountTotal"
                                                            runat="server" onkeypress="kp_numeric();" ToolTip="Balance Amount Total"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textPaidAmountTotal" runat="server"
                                                            onkeypress="kp_numeric();" ToolTip="Paid Amount Total"></asp:TextBox>
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
            <td align="center">
                <table width="100%" style="vertical-align: bottom;">
                    <tr>
                        <td style="width: 120px" align="left">
                            <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td align="center" style="width: 80%">
                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                            <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Images/btnPrint.png" />
                            <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                            <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                            <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
                        </td>
                        <td style="width: 120" align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
