<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PaymentCollection.aspx.vb" Inherits="Commercial_PaymentCollection"
    Title="eLOGiPark :: Payment Collection" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Script/ScrollableTablePlugin_1.0_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#inv').Scrollable({
                ScrollHeight: 200
            });
        });
    </script>
    <script type="text/javascript">
        function GetCrAmt(ctrl) {
            //if (ctrl.value != '') {
            try {
                var currentRow = ctrl.id.toString().replace('_TextCrNo', '');
                var prvcrAmt = document.getElementById(currentRow + "_hdnCrAmt1").value;
                var PrvCrNo = document.getElementById(currentRow + "_HdnCrNo").value;
                var BalAmt = document.getElementById(currentRow + "_textBalanceAmount").value;
                var HdnCRAmt = document.getElementById(currentRow + "_HdnCRAmt").value;
                var TextTdsAmt = document.getElementById(currentRow + "_TextTdsAmt").value;
                var HdnTdsAmt = document.getElementById(currentRow + "_HdnTdsAmt").value;
                var textBillAmount = document.getElementById(currentRow + "_textBillAmount").value;
                PageMethods.GetItemsDetails(ctrl.value, PrvCrNo, prvcrAmt, BalAmt, TextTdsAmt, textBillAmount, HdnCRAmt, HdnTdsAmt, onSucess, onError);
                function onSucess(result) {
                    //alert(result);
                    var dtls = result;
                    if (dtls == 'N') {
                        alert('Item Does Not Exist!');
                        return;
                    }
                    if (dtls != '') {
                        var AllDetails = dtls.split(',');
                        var Billto = document.getElementById("<%=lstCustomer.clientid%>").value;
                        var Billto1 = AllDetails[1];
                        var amt = AllDetails[6];
                        if (Billto != Billto1) {
                            if (amt == 0) {
                                document.getElementById(currentRow + "_textBalanceAmount").value = AllDetails[5];
                                document.getElementById(currentRow + "_hdnCrAmt1").value = 0
                                document.getElementById(currentRow + "_HdnCrNo").value = 0;
                                document.getElementById(currentRow + "_TextCrAmt").value = 0;
                            }
                        }
                        if (Billto == Billto1) {
                            document.getElementById(currentRow + "_textBalanceAmount").value = AllDetails[5];
                            document.getElementById(currentRow + "_hdnCrAmt1").value = AllDetails[6];
                            document.getElementById(currentRow + "_HdnCrNo").value = AllDetails[3];
                            document.getElementById(currentRow + "_TextCrAmt").value = AllDetails[6];

                        }
                    }
                    else {
                        alert('Item details not updated!');
                        return;
                    }
                }
                function onError(result) {
                    alert('Something wrong.');
                    return;
                }
            }
            catch (e) {
                alert('failed to call web service. Error: ' + e);
            }
            //  }
        }
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
        function EnableKey(e) {
            var code = (document.all) ? event.keyCode : e.which;
            window.event.returnValue = false;
            if (parseInt(code) == 8) //CTRL
            {
                window.event.returnValue = true;
            }
            if (parseInt(code) == 9) //CTRL
            {
                window.event.returnValue = true;
            }
            for (var j = 47; j < 57; j++) {
                var msg = "Sorry, this functionality is disabled.";
                if (parseInt(code) == j + 1) //CTRL
                {
                    window.event.returnValue = true;
                }
            }
            for (var j = 95; j < 105; j++) {
                var msg = "Sorry, this functionality is disabled.";
                if (parseInt(code) == j + 1) //CTRL
                {
                    window.event.returnValue = true;
                }
            }
        }

    </script>
    <script type="text/javascript">
        function OnCheckpayment(id) {
            var strsbno = "_CheckBox1";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //var tablename = 105;
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var lblReceiptNO = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabLocation_gvOnAccountDtls_ctl" + tablename + "_lblReceiptNO");
            var lblBalance = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabLocation_gvOnAccountDtls_ctl" + tablename + "_lblBalance");
            var lblReceiptDate = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabLocation_gvOnAccountDtls_ctl" + tablename + "_lblReceiptDate");
            var hdnRECEIPT_NO = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabLocation_gvOnAccountDtls_ctl" + tablename + "_hdnRECEIPT_NO");
            var lstPaymentMode = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstPaymentMode");
            var textRecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount");
            var textChequeNo = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textChequeNo");
            var textChequeDate = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textChequeDate");
            var lstReceiverBank = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstReceiverBank");
            var lstBankName = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstBankName");
            var lstDrCr = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstDrCr");
            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount");
            var CheckBox1 = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabLocation_gvOnAccountDtls_ctl" + tablename + "_CheckBox1");
            var HdnTotalPayment = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_HdnTotalPayment");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");
            var HdnpaymentMode = document.getElementById("<%=HdnpaymentMode.clientid%>");
            var hdnReceiptNo = document.getElementById("<%=hdnReceiptNo.clientid%>");
            HdnpaymentMode.value = 'O';
            hdnReceiptNo.value = hdnRECEIPT_NO.value;
            textRecBalanceAmount.value = 0;
            HdnTotalPayment.value = 0;
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");
            var hdnPreviousReceiptNo = document.getElementById("<%=hdnPreviousReceiptNo.clientid%>");
            var textPreviousReceiptNo = document.getElementById("<%=textPreviousReceiptNo.clientid%>");
            var textPreviousBalance = document.getElementById("<%=textPreviousBalance.clientid%>");
            lstBankName.disabled = true;
            lstReceiverBank.disabled = true;
            textPaymentAmount.disabled = true;
            lstDrCr.disabled = true;
            textChequeDate.disabled = true;
            textChequeNo.disabled = true;
            lstPaymentMode.disabled = true;
            if (CheckBox1.checked == true) {
                document.getElementById("<%=hdnReceiptNo.clientid%>").value = hdnRECEIPT_NO.value;
                hdnPreviousReceiptNo.value = hdnRECEIPT_NO.value;
                textRecBalanceAmountTotal.value = lblBalance.innerText;
                textPreviousReceiptNo.value = lblReceiptNO.innerText;
                textRecBalanceAmount.value = lblBalance.innerText;
                textPreviousBalance.value = lblBalance.innerText;
            }
            else {
                hdnPreviousReceiptNo.value = 0;
                textRecBalanceAmountTotal.value = 0;
                textPreviousReceiptNo.value = 0;
                textRecBalanceAmount.value = 0;
                textPreviousBalance.value = 0;
            }

        }

        function TotalAmounttds(id) {
            var strsbno = "_TextTdsAmt";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //var tablename = 105;
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBillAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBillAmount");
            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
            var HdnCRAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_HdnCRAmt");
            var HdnTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_HdnTdsAmt");
            var HdnTdsAmt1 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_HdnTdsAmt");
            var CrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
            document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_HdnTdsAmt1").setAttribute('value', TextTdsAmt.value);
            if (TextTdsAmt.value == '')
            { TextTdsAmt.value = 0; }
            var totalcr = parseFloat(TextTdsAmt.value) + parseFloat(CrAmt.value);
            var HdnRcvAmt = parseFloat(HdnCRAmt.value) + parseFloat(HdnTdsAmt.value);
            var totalrcv = parseFloat(HdnTdsAmt.value) + parseFloat(HdnCRAmt.value)
            if (totalcr > totalrcv) {
                alert('TDS Amount Should Not Be Greater Then Balance Amt.');
                //var temp = parseFloat(textBillAmount.value) - parseFloat(CrAmt.value);
                //textBalanceAmount.value = temp;
                TextTdsAmt.value = 0;
            }
            else {
                var temp = parseFloat(totalrcv) - parseFloat(TextTdsAmt.value) - parseFloat(CrAmt.value);
                textBalanceAmount.value = temp;
                //                if (textBillAmount.value <= HdnRcvAmt) {
                //                    var temp = parseFloat(textBillAmount.value) - parseFloat(TextTdsAmt.value) - parseFloat(CrAmt.value);
                //                    textBalanceAmount.value = temp;
                //                    //textToPayAmount.value = temp;
                //                }
                //                else {
                //                    var temp = parseFloat(HdnCRAmt.value) - parseFloat(TextTdsAmt.value) - parseFloat(CrAmt.value);
                //                    textBalanceAmount.value = temp;
                //                    //textToPayAmount.value = temp;
                //                }
            }

        }
        function ListEnable(id) {
            var strsbno = "_lstPaymentType";
            var lstService = document.getElementById('<%= lstService.clientid %>');
            var lstPaymentType = document.getElementById('<%= lstPaymentType.clientid %>');
            if (lstPaymentType.value == 'I') {
                lstService.disabled = true;
            }
            else if (lstPaymentType.value == 'A') {
                lstService.disabled = false;

            }
            else if (lstPaymentType.value == 'O') {
                lstService.disabled = true;

            }
        }

        function TotalBalAmount(id) {
            var strsbno = "_textPaymentAmount";
            var BalanceAmt = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount").value;
            var PaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount").value;
            var HdnPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_hdnPaymentAmount");
            var hdnTotalPayment = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_HdnTotalPayment").value;
            var textPaidAmountTotal = document.getElementById('<%=textPaidAmountTotal.ClientId %>');
            if (textPaidAmountTotal.value > PaymentAmount) {
                alert('Please enter amount greater then Paid amount.');
            }
            else {
                BalanceAmt = parseFloat(hdnTotalPayment) + parseFloat(PaymentAmount) - parseFloat(textPaidAmountTotal.value);
                document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount").value = BalanceAmt;
                document.getElementById('<%=textTotalAmount.ClientId %>').value = PaymentAmount;
                document.getElementById('<%=textRecBalanceAmountTotal.ClientId %>').value = BalanceAmt;
                HdnPaymentAmount.value = PaymentAmount;
            }

        }
        function PaymentMode(id) {
            var strsbno = "_lstPaymentMode";
            var PaymentMode = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstPaymentMode");
            var ChequeNo = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textChequeNo");
            var ChequeDate = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textChequeDate");
            var BankDetails = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstBankName");
            var RcvBank = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_lstReceiverBank");

            if ((PaymentMode.value == 'T') || (PaymentMode.value == 'S')) {
                ChequeNo.disabled = true;
                ChequeDate.disabled = true;
                BankDetails.disabled = true;
                RcvBank.disabled = true;
            }
            else if (PaymentMode.value == 'P') {
                ChequeNo.disabled = false;
                ChequeDate.disabled = true;
                BankDetails.disabled = true;
                RcvBank.disabled = true;
            }
            else {
                ChequeNo.disabled = false;
                ChequeDate.disabled = false;
                BankDetails.disabled = false;
                RcvBank.disabled = false;
            }

        }
        function PaymentAmount(id) {
            var strsbno = "_textPaymentAmount";
            var totalPaymentAmount = 0;
            var totalRecBalanceAmount = 0;
            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.Clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.Clientid%>");
            var tablename = id.Id.substring(id.Id.indexOf(strsbno) - 2, id.Id.indexOf(strsbno));

            var PaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
            var RecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textRecBalanceAmount");

            if (PaymentAmount.value == null || PaymentAmount.value == '' || PaymentAmount.value == '0') {
                PaymentAmount.value = 0;
            }
            if (PaymentAmount.value == null || PaymentAmount.value == '' || PaymentAmount.value == '0') {
                PaymentAmount.value = 0;
            }
            if (RecBalanceAmount.value == null || RecBalanceAmount.value == '' || RecBalanceAmount.value == '0') {
                RecBalanceAmount.value = 0;
            }
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.Clientid%>");
            if (textPaidAmountTotal.value == null || textPaidAmountTotal.value == '' || textPaidAmountTotal.value == '0') {
                textPaidAmountTotal.value = 0;
            }
            var PymtType = document.getElementById("<%=lstPaymentType.Clientid%>").value;
            var PreviousReceiptBal = 0;
            if (PymtType == 'I') {
                PreviousReceiptBal = document.getElementById("<%=textPreviousBalance.Clientid%>").value;
            }
            else {
                PreviousReceiptBal = 0;
            }
            totalPaymentAmount = parseFloat(totalPaymentAmount) + parseFloat(PaymentAmount.value);
            RecBalanceAmount.value = (parseFloat(PreviousReceiptBal) + parseFloat(PaymentAmount.value) - parseFloat(textPaidAmountTotal.value));
            totalRecBalanceAmount = parseFloat(totalRecBalanceAmount) + parseFloat(RecBalanceAmount.value);
            texttotalPaymentAmount.value = totalPaymentAmount;
            textRecBalanceAmountTotal.value = totalRecBalanceAmount;

            if (parseFloat(texttotalPaymentAmount.value) > 0) {

                if (PymtType == 'I') {
                    var strsbno1 = "_textPaymentAmount";
                    var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                    for (var j = 0; j < tablename1; j++) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").disabled = false;
                        document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").disabled = false;

                    }
                }

            }

        }
        function OnCheckInvoice(id) {
            var strsbno = "_chkSelect";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            if (texttotalPaymentAmount.value == null || texttotalPaymentAmount.value == '') {
                texttotalPaymentAmount.value = 0;
            }
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");

            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");

            if (textRecBalanceAmountTotal.value == null || textRecBalanceAmountTotal.value == '') {
                textRecBalanceAmountTotal.value = 0;
            }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
            var TextCrNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrNo");
            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var chkSelect2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
            var textInvoiceRefNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceRefNo");
            var textInvoiceDate = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceDate");
            var textPartyInvNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPartyInvNo");
            var TextBaseAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextBaseAmount");
            var textBillAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBillAmount");
            var textWaiverAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textWaiverAmount");
            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
            hdnPaidAmt.value = 0;
            TextTdsAmt.disabled = true;
            TextCrAmt.disabled = true;
            TextCrNo.disabled = true;
            textPaidAmount.disabled = false;

            if (chkSelect.checked == true) {
                chkSelect2.checked = true;
                textInvoiceRefNo.style.color = "#FF4500";
                textInvoiceMode.style.color = "#FF4500";
                textToPayAmount.style.color = "#FF4500";
                textBalanceAmount.style.color = "#FF4500";
                textPaidAmount.style.color = "#FF4500";
                TextTdsAmt.style.color = "#FF4500";
                //textPaymentAmount.style.color = "#FFA500";
                textInvoiceDate.style.color = "#FF4500";
                textPartyInvNo.style.color = "#FF4500";
                TextBaseAmount.style.color = "#FF4500";
                textBillAmount.style.color = "#FF4500";
                textWaiverAmount.style.color = "#FF4500";
                TextCrAmt.style.color = "#FF8C00";
                textInvoiceRefNo.style.fontWeight = "bold";
                textInvoiceMode.style.fontWeight = "bold";
                textToPayAmount.style.fontWeight = "bold";
                textBalanceAmount.style.fontWeight = "bold";
                textPaidAmount.style.fontWeight = "bold";
                TextTdsAmt.style.fontWeight = "bold";
                textInvoiceDate.style.fontWeight = "bold";
                textPartyInvNo.style.fontWeight = "bold";
                TextBaseAmount.style.fontWeight = "bold";
                textBillAmount.style.fontWeight = "bold";
                textWaiverAmount.style.fontWeight = "bold";
                TextCrAmt.style.fontWeight = "bold";
                //textPaymentAmount.style.fontWeight = "bold";

            }
            else {
                chkSelect2.checked = false;
                textInvoiceRefNo.style.color = "black";
                textInvoiceMode.style.color = "black";
                textToPayAmount.style.color = "black";
                textBalanceAmount.style.color = "black";
                textPaidAmount.style.color = "black";
                TextTdsAmt.style.color = "black";
                //textPaymentAmount.style.color = "#FFA500";
                textInvoiceDate.style.color = "black";
                textPartyInvNo.style.color = "black";
                TextBaseAmount.style.color = "black";
                textBillAmount.style.color = "black";
                textWaiverAmount.style.color = "black";
                TextCrAmt.style.color = "black";
                textInvoiceRefNo.style.fontWeight = "normal";
                textInvoiceMode.style.fontWeight = "normal";
                textToPayAmount.style.fontWeight = "normal";
                textBalanceAmount.style.fontWeight = "normal";
                textPaidAmount.style.fontWeight = "normal";
                TextTdsAmt.style.fontWeight = "normal";
                textInvoiceDate.style.fontWeight = "normal";
                textPartyInvNo.style.fontWeight = "normal";
                TextBaseAmount.style.fontWeight = "normal";
                textBillAmount.style.fontWeight = "normal";
                textWaiverAmount.style.fontWeight = "normal";
                TextCrAmt.style.fontWeight = "normal";
            }
            if (textToPayAmount.value == null || textToPayAmount.value == '') {
                textToPayAmount.value = 0;
            }
            if (textBalanceAmount.value == null || textBalanceAmount.value == '') {
                textBalanceAmount.value = 0;
            }
            if (textPaidAmount.value == null || textPaidAmount.value == '') {
                textPaidAmount.value = 0;
            }

            if (chkSelect.checked == true && parseFloat(textRecBalanceAmountTotal.value) <= 0) {
                alert('Not Sufficent Balance');
                document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount").focus();
                rtnval = false;
            }
            else if (parseFloat(textRecBalanceAmountTotal.value) >= 0) {
                if (chkSelect.checked == true) {
                    if (parseFloat(textRecBalanceAmountTotal.value) < parseFloat(textBalanceAmount.value)) {
                        newPaidAmount = parseFloat(textRecBalanceAmountTotal.value).toFixed(2);
                    }
                    else if (parseFloat(textRecBalanceAmountTotal.value) >= parseFloat(textBalanceAmount.value)) {
                        newPaidAmount = parseFloat(textBalanceAmount.value).toFixed(2);
                    }

                }
                else {

                    textBalanceAmount.value = parseFloat(parseFloat(textPaidAmount.value) + parseFloat(textBalanceAmount.value)).toFixed(2);
                    textPaidAmount.value = 0;
                    newPaidAmount = 0;
                }
                if (parseFloat(textToPayAmount.value) < parseFloat(textBalanceAmount)) {
                    alert('Enter amount is greater then balance amount.');
                }
                textPaidAmount.value = newPaidAmount;
                hdnPaidAmt.value = newPaidAmount;
                var tempBalnnceAmount = parseFloat((parseFloat(textBalanceAmount.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                textBalanceAmount.value = tempBalnnceAmount;


                var strsbno1 = "_textPaymentAmount";
                var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                var temptextPaidAmountTotal = 0;
                var temptextBalanceAmountTotal = 0;

                var temptexttotalPaymentAmount = 0;
                var temptextRecBalanceAmountTotal = 0;
                for (var j = 2; j < tablename1 + 2; j++) {

                    var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textPaidAmount").value;
                    var temphdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_hdnPaidAmt");
                    var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textBalanceAmount").value;
                    temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                    textPaidAmountTotal.value = temptextPaidAmountTotal;
                    temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                    textBalanceAmountTotal.value = temptextBalanceAmountTotal;
                    var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").value;
                    if (prevBal == null || prevBal == '') {
                        document.getElementById("<%=textPreviousBalance.clientid%>").value = 0;
                        prevBal = 0;
                    }
                    var temp = parseFloat(parseFloat(texttotalPaymentAmount.value) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal)).toFixed(2);
                    textRecBalanceAmountTotal.value = temp;
                    var textRecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount");
                    if (chkSelect.checked == false) {
                        TextTdsAmt.disabled = false;
                        textPaidAmount.disabled = true;
                    }

                    textRecBalanceAmount.value = temp;
                    //textRecBalanceAmount.value = temp;

                }
            }
            //
            // }
            //return rtnval;
        }
        function OnCheckInvoice1(id) {
            var strsbno = "_CheckBox2";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //var tablename = 105;
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            //            if (tablename == null || tablename == '') {
            //                strsbno = "_textPaidAmount";
            //                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            //            }

            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            if (texttotalPaymentAmount.value == null || texttotalPaymentAmount.value == '') {
                texttotalPaymentAmount.value = 0;
            }
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");

            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");

            if (textRecBalanceAmountTotal.value == null || textRecBalanceAmountTotal.value == '') {
                textRecBalanceAmountTotal.value = 0;
            }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
            var TextCrNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrNo");
            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var chkSelect2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
            var textInvoiceRefNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceRefNo");
            var textInvoiceDate = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceDate");
            var textPartyInvNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPartyInvNo");
            var TextBaseAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextBaseAmount");
            var textBillAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBillAmount");
            var textWaiverAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textWaiverAmount");
            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
            hdnPaidAmt.value = 0;
            TextTdsAmt.disabled = true;
            textPaidAmount.disabled = false;
            TextCrAmt.disabled = true;
            TextCrNo.disabled = true;
            if (chkSelect2.checked == true) {
                chkSelect.checked = true;
                textInvoiceRefNo.style.color = "#FF4500";
                textInvoiceMode.style.color = "#FF4500";
                textToPayAmount.style.color = "#FF4500";
                textBalanceAmount.style.color = "#FF4500";
                textPaidAmount.style.color = "#FF4500";
                TextTdsAmt.style.color = "#FF4500";
                //textPaymentAmount.style.color = "#FFA500";
                textInvoiceDate.style.color = "#FF4500";
                textPartyInvNo.style.color = "#FF4500";
                TextBaseAmount.style.color = "#FF4500";
                textBillAmount.style.color = "#FF4500";
                textWaiverAmount.style.color = "#FF4500";
                TextCrAmt.style.color = "#FF8C00";
                textInvoiceRefNo.style.fontWeight = "bold";
                textInvoiceMode.style.fontWeight = "bold";
                textToPayAmount.style.fontWeight = "bold";
                textBalanceAmount.style.fontWeight = "bold";
                textPaidAmount.style.fontWeight = "bold";
                TextTdsAmt.style.fontWeight = "bold";
                textInvoiceDate.style.fontWeight = "bold";
                textPartyInvNo.style.fontWeight = "bold";
                TextBaseAmount.style.fontWeight = "bold";
                textBillAmount.style.fontWeight = "bold";
                textWaiverAmount.style.fontWeight = "bold";
                TextCrAmt.style.fontWeight = "bold";
                //textPaymentAmount.style.fontWeight = "bold";

            }
            else {
                chkSelect.checked = false;
                textInvoiceRefNo.style.color = "black";
                textInvoiceMode.style.color = "black";
                textToPayAmount.style.color = "black";
                textBalanceAmount.style.color = "black";
                textPaidAmount.style.color = "black";
                TextTdsAmt.style.color = "black";
                //textPaymentAmount.style.color = "#FFA500";
                textInvoiceDate.style.color = "black";
                textPartyInvNo.style.color = "black";
                TextBaseAmount.style.color = "black";
                textBillAmount.style.color = "black";
                textWaiverAmount.style.color = "black";
                TextCrAmt.style.color = "black";
                textInvoiceRefNo.style.fontWeight = "normal";
                textInvoiceMode.style.fontWeight = "normal";
                textToPayAmount.style.fontWeight = "normal";
                textBalanceAmount.style.fontWeight = "normal";
                textPaidAmount.style.fontWeight = "normal";
                TextTdsAmt.style.fontWeight = "normal";
                textInvoiceDate.style.fontWeight = "normal";
                textPartyInvNo.style.fontWeight = "normal";
                TextBaseAmount.style.fontWeight = "normal";
                textBillAmount.style.fontWeight = "normal";
                textWaiverAmount.style.fontWeight = "normal";
                TextCrAmt.style.fontWeight = "normal";
            }

            if (textToPayAmount.value == null || textToPayAmount.value == '') {
                textToPayAmount.value = 0;
                textInvoiceRefNo.style.color = "black";
            }
            if (textBalanceAmount.value == null || textBalanceAmount.value == '') {
                textBalanceAmount.value = 0;
            }
            if (textPaidAmount.value == null || textPaidAmount.value == '') {
                textPaidAmount.value = 0;
            }

            if (chkSelect.checked == true && parseFloat(textRecBalanceAmountTotal.value) <= 0) {
                alert('Not Sufficent Balance');
                document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount").focus();
                rtnval = false;
            }
            else if (parseFloat(textRecBalanceAmountTotal.value) >= 0) {
                if (chkSelect.checked == true) {
                    if (parseFloat(textRecBalanceAmountTotal.value) < parseFloat(textBalanceAmount.value)) {
                        newPaidAmount = parseFloat(textRecBalanceAmountTotal.value).toFixed(2);

                    }
                    else if (parseFloat(textRecBalanceAmountTotal.value) >= parseFloat(textBalanceAmount.value)) {
                        newPaidAmount = parseFloat(textBalanceAmount.value).toFixed(2);
                    }

                }
                else {

                    textBalanceAmount.value = parseFloat(textPaidAmount.value) + parseFloat(textBalanceAmount.value);
                    textPaidAmount.value = 0;
                    newPaidAmount = 0;
                }
                if (parseFloat(textToPayAmount.value) < parseFloat(textBalanceAmount)) {
                    alert('Enter amount is greater then balance amount.');
                }
                textPaidAmount.value = newPaidAmount;
                hdnPaidAmt.value = newPaidAmount;
                var tempBalnnceAmount = parseFloat(parseFloat(textBalanceAmount.value) - parseFloat(textPaidAmount.value)).toFixed(2);
                textBalanceAmount.value = tempBalnnceAmount;


                var strsbno1 = "_textPaymentAmount";
                var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                var temptextPaidAmountTotal = 0;
                var temptextBalanceAmountTotal = 0;

                var temptexttotalPaymentAmount = 0;
                var temptextRecBalanceAmountTotal = 0;
                for (var j = 2; j < tablename1 + 2; j++) {
                    var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textPaidAmount").value;
                    var temphdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_hdnPaidAmt");
                    var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textBalanceAmount").value;
                    temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                    textPaidAmountTotal.value = temptextPaidAmountTotal;
                    temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                    textBalanceAmountTotal.value = temptextBalanceAmountTotal;
                    var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").value;
                    if (prevBal == null || prevBal == '') {
                        document.getElementById("<%=textPreviousBalance.clientid%>").value = 0;
                        prevBal = 0;
                    }
                    var temp = parseFloat(parseFloat(texttotalPaymentAmount.value) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal)).toFixed(2);
                    textRecBalanceAmountTotal.value = temp;
                    var textRecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount");
                    if (chkSelect.checked == false) {
                        TextTdsAmt.disabled = false;
                        textPaidAmount.disabled = true;
                    }

                    textRecBalanceAmount.value = temp;
                    //textRecBalanceAmount.value = temp;

                }
            }
            //
            // }
            //return rtnval;
        }
        function OnCheckInvoiceAmt(id) {
            strsbno = "_textPaidAmount";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //var tablename = 105;
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            if (texttotalPaymentAmount.value == null || texttotalPaymentAmount.value == '') {
                texttotalPaymentAmount.value = 0;
            }
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");
            if (textRecBalanceAmountTotal.value == null || textRecBalanceAmountTotal.value == '') {
                textRecBalanceAmountTotal.value = 0;
            }
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount");
            var textRecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var textRecBalanceAmountTotal = document.getElementById('<%=textRecBalanceAmountTotal.ClientId %>');
            var textPaidAmountTotal = document.getElementById('<%=textPaidAmountTotal.ClientId %>');
            if (textToPayAmount.value == null || textToPayAmount.value == '') {
                textToPayAmount.value = 0;
            }
            if (textBalanceAmount.value == null || textBalanceAmount.value == '') {
                textBalanceAmount.value = 0;
            }
            if (textPaidAmount.value == null || textPaidAmount.value == '') {
                textPaidAmount.value = 0;
            }
            var balamt = parseFloat(hdnPaidAmt.value) + parseFloat(textBalanceAmount.value) - parseFloat(textPaidAmount.value);
            var tempamt = parseFloat(hdnPaidAmt.value) - parseFloat(textPaidAmount.value) + parseFloat(textRecBalanceAmount.value);
            var temppaybalamt = parseFloat(hdnPaidAmt.value) - parseFloat(textPaidAmount.value) + parseFloat(textRecBalanceAmountTotal.value);
            var temppaidamt = parseFloat(textPaidAmount.value) + parseFloat(textPaidAmountTotal.value) - parseFloat(hdnPaidAmt.value);
            var RecBalanceAmountTotal = parseFloat(textRecBalanceAmountTotal.value);
            var RecBalanceAmount = parseFloat(textRecBalanceAmount.value);
            var balaamt = parseFloat(textBalanceAmount.value);
            var hdnPaidAmt1 = parseFloat(hdnPaidAmt.value);
            textRecBalanceAmountTotal.value = temppaybalamt + parseFloat(textPaidAmount.value);
            textRecBalanceAmount.value = tempamt + parseFloat(textPaidAmount.value);
            if (balamt < 0) {
                //                textBalanceAmount.value = balaamt;
                //                textPaidAmount.value = hdnPaidAmt;
                textPaidAmount.value = hdnPaidAmt1;
                textRecBalanceAmount.value = RecBalanceAmount;
                textRecBalanceAmountTotal.value = RecBalanceAmountTotal
                textBalanceAmount.value = textBalanceAmount.value;
                textPaidAmountTotal.value = textPaidAmountTotal.value;
                hdnPaidAmt.value = hdnPaidAmt1;
            }
            else {
                if (parseFloat(textRecBalanceAmount.value) < parseFloat(textPaidAmount.value)) {
                    alert('Paid Amount Should Be Less Then Total Balance Amount.');
                    textPaidAmount.value = hdnPaidAmt.value;
                    textRecBalanceAmount.value = RecBalanceAmount;
                    textRecBalanceAmountTotal.value = RecBalanceAmountTotal
                    textBalanceAmount.value = textBalanceAmount.value;
                    textPaidAmountTotal.value = textPaidAmountTotal.value;
                    hdnPaidAmt.value = hdnPaidAmt.value;
                }
                else {
                    textRecBalanceAmountTotal.value = temppaybalamt;
                    textRecBalanceAmount.value = tempamt;
                    textBalanceAmount.value = balamt;
                    textPaidAmountTotal.value = temppaidamt;
                    hdnPaidAmt.value = textPaidAmount.value;

                }
            }

            if (parseFloat(textToPayAmount.value) < (parseFloat(textBalanceAmount.value) + parseFloat(textPaidAmount.value))) {
                alert('Enter amount is greater then balance amount.');
            }

            //}
        }
    </script>
    <%--<script type="text/jscript" language="javascript">



        function CalcInvoice(id) {
            var rtnval = true;
            var strsbno = "_chkSelect";
            var tablename = id.Id.substring(id.Id.indexOf(strsbno) - 2, id.Id.indexOf(strsbno));
            if (tablename == null || tablename == '') {
                strsbno = "_textPaidAmount";
                tablename = id.Id.substring(id.Id.indexOf(strsbno) - 2, id.Id.indexOf(strsbno));
            }

            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.Clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.Clientid%>");

            if (texttotalPaymentAmount.value == null || texttotalPaymentAmount.value == '') {
                texttotalPaymentAmount.value = 0;
            }

            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.Clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.Clientid%>");

            if (textRecBalanceAmountTotal.value == null || textRecBalanceAmountTotal.value == '') {
                textRecBalanceAmountTotal.value = 0;
            }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            if (textToPayAmount.value == null || textToPayAmount.value == '') {
                textToPayAmount.value = 0;
            }
            if (textBalanceAmount.value == null || textBalanceAmount.value == '') {
                textBalanceAmount.value = 0;
            }
            if (textPaidAmount.value == null || textPaidAmount.value == '') {
                textPaidAmount.value = 0;
            }

            if (textInvoiceMode.value == 'Cash') {
                if (parseFloat(textPaidAmount.value) > 0 && (parseFloat(textPaidAmount.value) != parseFloat(hdnBalanceAmount.value))) {
                    alert('Paid Amount should be equal to Balance Amount');
                    textPaidAmount.focus();
                    rtnval = false;
                }
            }
            else if (textInvoiceMode.value == 'Credit') {
                if (parseFloat(textPaidAmount.value) > parseFloat(hdnBalanceAmount.value)) {
                    alert('Paid Amount should not be more than balance Amount');
                    textPaidAmount.focus();
                    rtnval = false;
                }
                if (parseFloat(textPaidAmount.value) > parseFloat(textRecBalanceAmountTotal.value)) {
                    alert('Not Sufficent Balance.');
                    textPaidAmount.focus();
                    rtnval = false;
                }

            }
            //   if (parseFloat(texttotalPaymentAmount.value) <= 0)
            //   {
            //          alert('Enter the Payment Details');
            //            document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
            //          rtnval =false;
            //   }
            if (parseFloat(textRecBalanceAmountTotal.value) <= 0) {
                alert('No Balance, Enter The Payment Details');
                document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textPaymentAmount").focus();
                rtnval = false;
            }
            if (rtnval == true) {
                var tempBalnnceAmount = (parseFloat(textToPayAmount.value) - parseFloat(textPaidAmount.value));
                textBalanceAmount.value = tempBalnnceAmount;


                var strsbno1 = "_textPaymentAmount";
                var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
                var temptextPaidAmountTotal = 0;
                var temptextBalanceAmountTotal = 0;

                var temptexttotalPaymentAmount = 0;
                var temptextRecBalanceAmountTotal = 0;
                for (var j = 0; j < tablename1; j++) {

                    var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textPaidAmount").value;
                    var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textBalanceAmount").value;

                    temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
                    textPaidAmountTotal.value = temptextPaidAmountTotal;
                    temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
                    textBalanceAmountTotal.value = temptextBalanceAmountTotal;

                    var prevBal = document.getElementById("<%=textPreviousBalance.Clientid%>").value;
                    if (prevBal == null || prevBal == '') {
                        document.getElementById("<%=textPreviousBalance.Clientid%>").value = 0;
                        prevBal = 0;
                    }

                    var temp = parseFloat(texttotalPaymentAmount.value) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal);
                    textRecBalanceAmountTotal.value = temp;
                    document.getElementById("ctl00_ContentPlaceHolder1_repPaymentDetails_ctl01_textRecBalanceAmount").value = temp;
                }

            }


            return rtnval;
        }

       
    </script>--%>
    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td valign="top" style="width: 400px">
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Payment Collection" Width="400px"
                                class="FormLabelTitle">
                            </asp:Label>
                        </td>
                        <td valign="top" style="width: 80%">
                            <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left">
                <div id="dvMain" runat="server" style="overflow: auto; width: 100%;">
                    <table>
                        <tr style="height: 70px;">
                            <td valign="top">
                                <div id="dvCustomer" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPaymentType" runat="server" Width="130" ToolTip="Payment Type"
                                                    CssClass="FormListBoxMediumMandatory" onchange="ListEnable(this)">
                                                    <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="I" Text="Invoice"></asp:ListItem>
                                                    <asp:ListItem Value="A" Text="Advance"></asp:ListItem>
                                                    <asp:ListItem Value="O" Text="OnAccount"></asp:ListItem>
                                                    <asp:ListItem Value="B" Text="Opening Balance"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCustomer" runat="server" Text="Customer " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstCustomer" Width="280" runat="server" ToolTip="Customer"
                                                    CssClass="FormListBoxLargMandatory">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnDisplay" runat="server" Visible="false" Text="Go" CssClass="FormButton" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceiptNo" runat="server" Text="Receipt No" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textReceiptNo" Width="130" runat="server" ToolTip="Receipt No" onkeypress="kp_convert_upper()"
                                                    CssClass="FormTextBoxMedium">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnReceiptNo" runat="server" />
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnSearchDisplay" runat="server" Visible="false" Text="Go" CssClass="FormButton" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceiptDate" runat="server" Text="Receipt Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textReceiptdate" Width="120" runat="server" ToolTip="Receipt Date"
                                                    CssClass="FormTextBoxMedium">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="ClReceiptDate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textReceiptdate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblService" runat="server" Text="Service " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstService" Width="280" runat="server" ToolTip="Customer" CssClass="FormListBoxLarg">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdnPreviousReceiptNo" runat="server" />
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblStateName" runat="server" Text="State Name" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="130px" ID="textStateName" runat="server"
                                                    ToolTip="State Name"></asp:TextBox>
                                                <asp:HiddenField ID="hdnStateCode" runat="server" />
                                                <asp:HiddenField ID="HdnpaymentMode" runat="server" />
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPreviousreceiptNo" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                    runat="server" Text="Previous Receipt">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="130px" ID="textPreviousReceiptNo"
                                                    runat="server" ToolTip="Previous Receipt No"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPreviousBalance" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                    runat="server" Text="Previous Balance">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="120px" ID="textPreviousBalance"
                                                    runat="server" ToolTip="Previous Balance"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRemarks" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                                            </td>
                                            <td colspan="5">
                                                <asp:TextBox ID="TxtRemarks" Width="500px" MaxLength="500" runat="server" Height="45px"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
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
        <tr>
            <td valign="top" align="left" colspan="2">
                <table>
                    <tr class="UserControls" style="height: 150px; margin-top: 0px;">
                        <td style="width: 1368px;" valign="top" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div id="RepScroling" runat="server" style="vertical-align: middle; overflow: auto;
                                        width: 100%;">
                                        <ajaxToolkit:TabContainer runat="server" ID="tabCustomerMaster" Width="100%" ActiveTabIndex="0"
                                            AutoPostBack="true">
                                            <ajaxToolkit:TabPanel runat="server" ID="tabMaster" TabIndex="0" HeaderText="Payment Details">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="vertical-align: top;" align="center">
                                                                <asp:Repeater ID="repPaymentDetails" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table cellspacing="0" cellpadding="0" id="pymt">
                                                                            <tr class="RepHead">
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPaymentMode" CssClass="FormLabel" Width="100px" runat="server"
                                                                                        Text="Payment Mode"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblChequeNo" CssClass="FormLabel" Width="90px" runat="server" Text="Instrument No"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblChequeDate" CssClass="FormLabel" Width="110px" runat="server" Text="Instrument Date"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBankName" CssClass="FormLabel" Width="300px" runat="server" Text="Payable Bank Name"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblReceiverBank" CssClass="FormLabel" Width="300px" runat="server"
                                                                                        Text="Receiver Bank Name"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblDrCr" CssClass="FormLabel" Width="100px" runat="server" Text="Dr./Cr."></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPaymentAmount" CssClass="FormLabel" Width="100px" runat="server"
                                                                                        Text="Amount"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBalanceAmount" CssClass="FormLabel" Width="103px" runat="server"
                                                                                        Text="Balance Amount"></asp:Label>
                                                                                </td>
                                                                                <td align="center" width="15px" style="background-color: White">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="105px" ID="lstPaymentMode" runat="server"
                                                                                    onchange="PaymentMode(this)" text='<%# Eval("ReceiptMode") %>' ToolTip="Payment Mode">
                                                                                    <asp:ListItem Text="Cash" Value="C" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Cheque" Value="H"></asp:ListItem>
                                                                                    <asp:ListItem Text="NEFT" Value="N"></asp:ListItem>
                                                                                    <asp:ListItem Text="RTGS" Value="R"></asp:ListItem>
                                                                                    <asp:ListItem Text="TDS" Value="T"></asp:ListItem>
                                                                                    <asp:ListItem Text="DD" Value="D"></asp:ListItem>
                                                                                    <asp:ListItem Text="ADVC" Value="A"></asp:ListItem>
                                                                                    <asp:ListItem Text="ON ACCOUNT" Value="O"></asp:ListItem>
                                                                                    <asp:ListItem Text="OPENING BALANCE" Value="B"></asp:ListItem>
                                                                                    <asp:ListItem Text="Adjustment Against VIP" Value="G"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxNumeric" Width="90px" ID="textChequeNo" runat="server"
                                                                                    MaxLength="30" Text='<%# Eval("ChequeNo") %>' ToolTip="Cheque\DD No"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxDate" Width="110px" ID="textChequeDate" runat="server"
                                                                                    Text='<%# Eval("ChequeDate") %>' ToolTip="Cheque\DD Date"></asp:TextBox>
                                                                                <ajaxToolkit:CalendarExtender ID="clChequeDate" runat="server" Format="dd/MM/yyyy"
                                                                                    TargetControlID="textChequeDate" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="305px" ID="lstBankName" runat="server"
                                                                                    text='<%# Eval("BankId") %>' ToolTip="Bank Name" OnDataBinding="prepareBank">
                                                                                    <%-- <asp:ListItem Value="0" Text="---- Select ----"></asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="State Bank of India"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="Punjab National Bank"></asp:ListItem>
                                                                                    <asp:ListItem Value="3" Text="ICICI Bank"></asp:ListItem>
                                                                                    <asp:ListItem Value="4" Text="bank Of Borada"></asp:ListItem>
                                                                                    <asp:ListItem Value="5" Text="Corporation Bank"></asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="305px" ID="lstReceiverBank" runat="server"
                                                                                    text='<%# Eval("BankId") %>' ToolTip="Receiver Bank Name" OnDataBinding="prepareBank">
                                                                                    <%--<asp:ListItem Value="0" Text="---- Select ----"></asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="State Bank of India"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="Punjab National Bank"></asp:ListItem>
                                                                                    <asp:ListItem Value="3" Text="ICICI Bank"></asp:ListItem>
                                                                                    <asp:ListItem Value="4" Text="bank Of Borada"></asp:ListItem>
                                                                                    <asp:ListItem Value="5" Text="Corporation Bank"></asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList class="FormListBoxLarg" Width="100px" ID="lstDrCr" runat="server"
                                                                                    ToolTip="Receiver Bank Name">
                                                                                    <asp:ListItem Value="0" Text="---- Select ----"></asp:ListItem>
                                                                                    <asp:ListItem Value="D" Text="Dr"></asp:ListItem>
                                                                                    <asp:ListItem Value="C" Text="Cr"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textPaymentAmount" runat="server"
                                                                                    onchange="TotalBalAmount(this)" onkeypress="kp_numeric();" Text='<%# Eval("Amount") %>'
                                                                                    ToolTip="Amount"></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnPaymentAmount" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textRecBalanceAmount" runat="server"
                                                                                    onkeypress="kp_numeric();" ToolTip="Balance Amount" onKeyDown="return noCTRL(event)"></asp:TextBox>
                                                                                <asp:HiddenField ID="HdnTotalPayment" runat="server" Value="0" />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellspacing="0" cellpadding="0">
                                                        <tr align="right">
                                                            <td align="right">
                                                                <asp:Label ID="Label8" Width="1023px" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                                    runat="server" Text="Total" />
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textTotalAmount" runat="server"
                                                                    ToolTip="Total Amount" onKeyDown="return noCTRL(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textRecBalanceAmountTotal"
                                                                    runat="server" ToolTip="Total Balance Amount" onKeyDown="return noCTRL(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center" width="20px">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel runat="server" ID="tabLocation" TabIndex="1" HeaderText="On Account Details">
                                                <ContentTemplate>
                                                    <table border="0" cellpadding="0" style="border-style: none;">
                                                        <tr>
                                                            <td align="center" valign="top" style="width: 900px">
                                                                <table>
                                                                    <tr>
                                                                        <td style="text-align: left">
                                                                            <div id="tbCont" style="height: 100%; overflow: auto;">
                                                                                <asp:GridView ID="gvOnAccountDtls" AutoGenerateColumns="False" runat="server">
                                                                                    <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <asp:CheckBox ID="chkAll" runat="server" Enabled="false" Visible="false" />
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox1" runat="server" onClick="OnCheckpayment(this)" />
                                                                                                <asp:HiddenField ID="hdnRECEIPT_NO" runat="server" Value='<%# Eval("RECEIPT_NO") %>' />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="RECEIPT_MODE" HeaderText="Payment Mode">
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Instrument No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblInstumentNo" runat="server" Text='<%# Eval("INSTRUMENT_NO")%>'></asp:Label>
                                                                                                <%-- <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Text='<%# Eval("RAIL_REMARK")%>'
                                                                                                    Visible="false">
                                                                                                </asp:TextBox>--%>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Instrument Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblInstrumentDate" runat="server" Text='<%# Eval("INSTRUMENT_DATE")%>'></asp:Label>
                                                                                                <%-- <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Text='<%# Eval("RAIL_REMARK")%>'
                                                                                                    Visible="false">
                                                                                                </asp:TextBox>--%>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="PAYMENT_BANK" HeaderText="Payment Bank">
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                            <ItemStyle Width="200px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="RECEIVER_BANK" HeaderText="Receiver Bank">
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Receipt No">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblReceiptNO" runat="server" Text='<%# Eval("RECEIPT_REF_NO")%>'></asp:Label>
                                                                                                <%-- <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Text='<%# Eval("RAIL_REMARK")%>'
                                                                                                    Visible="false">
                                                                                                </asp:TextBox>--%>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Receipt Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblReceiptDate" runat="server" Text='<%# Eval("RECEIPT_DATE")%>'></asp:Label>
                                                                                                <%-- <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Text='<%# Eval("RAIL_REMARK")%>'
                                                                                                    Visible="false">
                                                                                                </asp:TextBox>--%>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="CR_AMOUNT" HeaderText="CR Amount">
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="DR_AMOUNT" HeaderText="DR Amount">
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                            <ItemStyle Width="100px" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="CR Balance">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("BAL_AMOUNT")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel runat="server" ID="TbCrNote" TabIndex="1" HeaderText="Cr Note">
                                                <ContentTemplate>
                                                    <table border="0" cellpadding="0" style="border-style: none;">
                                                        <tr>
                                                            <td align="center" valign="top" style="width: 900px">
                                                                <table>
                                                                    <tr>
                                                                        <td style="text-align: left">
                                                                            <div id="DivCrNote" style="height: 100%; overflow: auto;">
                                                                                <asp:GridView ID="GvPendingCrNOte" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" HeaderStyle-CssClass="RepheaderNew"
                                                                                    runat="server">
                                                                                    <Columns>
                                                                                        <asp:BoundField ItemStyle-Width="120px" DataField="CR_REF_NO" HeaderText="Cr No" />
                                                                                        <asp:BoundField ItemStyle-Width="120px" DataField="CR_DATE" HeaderText="Cr Date" />
                                                                                        <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_REF_NO" HeaderText="Invoice No" />
                                                                                        <asp:BoundField ItemStyle-Width="100px" DataField="CR_AMOUNT" HeaderText="Cr Basic Amount"
                                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField ItemStyle-Width="100px" DataField="CR_TAX" HeaderText="Cr Tax Amount"
                                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField ItemStyle-Width="100px" DataField="TOTAL" HeaderText="Cr Total Amount"
                                                                                            ItemStyle-HorizontalAlign="Right" />
                                                                                        <asp:BoundField ItemStyle-Width="250px" DataField="BAL_AMT" HeaderText="Balance Amount"
                                                                                            ItemStyle-HorizontalAlign="left" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                        </ajaxToolkit:TabContainer>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="tabCustomerMaster" EventName="ActiveTabChanged"
                                        runat="Server" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="RepHead">
            <td align="center">
                <asp:Label ID="lblInvoiceDetails" runat="server" Font-Size="12" Width="220px" Font-Bold="true"
                    CssClass="FormLabel" Text="Invoice Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <asp:Repeater ID="repInvoiceDetails" runat="server">
                        <HeaderTemplate>
                            <table cellspacing="0" cellpadding="0" id="inv">
                                <tr class="RepHead">
                                    <td align="center">
                                        <asp:Label ID="Label2" Width="20px" runat="server" Text="" CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceRefNo" Font-Size="12" Font-Bold="true" CssClass="FormLabel"
                                            Width="220px" runat="server" Text="Invoice No"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceDate" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="120px" runat="server" Text="Inv. Date"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceMode" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="120px" runat="server" Text="Inv. Mode"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblPartyInvoiceNo" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="150px" runat="server" Text="Party Inv. No."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LblBaseAmt" CssClass="FormLabel" Width="120px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="Base Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblBillAmount" CssClass="FormLabel" Width="100px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="Total"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblWaiverApprove" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="100px" runat="server" Text="Waiver Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblTdsAmt" CssClass="FormLabel" Width="100px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="TDS Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label1" CssClass="FormLabel" Width="150px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="CRN. No"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LblCrAmt" CssClass="FormLabel" Width="100px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="Cr. Amt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblToPayAmount" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="100px" runat="server" Text="Rev. Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblBananceAmount" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="100px" runat="server" Text="Bal. Amt.t"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblPaidAmount" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="100px" runat="server" Text="Paid Amt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblSelect" Width="20px" runat="server" Text="" CssClass="FormLabel"></asp:Label>
                                    </td>
                                    <%-- <td align="center" width="10px" style="background-color: White">
                                        &nbsp;
                                    </td>--%>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox Width="20px" ID="CheckBox2" runat="server" ToolTip="Select" onClick="OnCheckInvoice1(this)">
                                    </asp:CheckBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxLarg" Font-Size="12" Width="190px" ID="textInvoiceRefNo"
                                        runat="server" ToolTip="Invoice Ref No">
                                    </asp:TextBox>
                                    <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                    <asp:HiddenField ID="hdnCustomerID" Value='<%# Eval("CustomerId") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                    <%-- <asp:HiddenField ID="hdnTrnType" Value='<%# Eval("TrnType") %>' runat="server" />--%>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="12" Width="120px" ID="textInvoiceDate"
                                        runat="server" ToolTip="Invoice Date"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="12" Width="120px" ID="textInvoiceMode"
                                        runat="server" ToolTip="Invoice Mode"></asp:TextBox>
                                    <asp:HiddenField ID="hdnPaymentMode" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="12" Width="150px" ID="textPartyInvNo"
                                        runat="server" ToolTip="PartyInvNo"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="120px" ID="TextBaseAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("TERMINALID") %>' onKeyDown="return noCTRL(event)"
                                        ToolTip="Bill Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="textBillAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("DrAmount") %>' ToolTip="Bill Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="textWaiverAmount"
                                        runat="server" onkeypress="kp_numeric();" ToolTip="Waiver Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="TextTdsAmt"
                                        runat="server" onkeypress="kp_numeric();" ToolTip="Waiver Amount" onchange="TotalAmounttds(this)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnTdsAmt" runat="server" />
                                    <asp:HiddenField ID="HdnTdsAmt1" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="150px" ID="TextCrNo"
                                        runat="server" ToolTip="Credit Note NO" onchange="GetCrAmt(this)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnCrId" runat="server" />
                                    <asp:HiddenField ID="hdnCrAmt1" runat="server" Value="0" />
                                    <asp:HiddenField ID="HdnCrNo" runat="server" />
                                    <%--<ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchCrNote" MinimumPrefixLength="2"
                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="TextCrNo"
                                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false" ServicePath="~/Commercial/PaymentCollection.aspx">
                                    </ajaxToolkit:AutoCompleteExtender>--%>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="TextCrAmt"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("TrnValue") %>' onKeyDown="return noCTRL(event)"
                                        ToolTip="Cr Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="textToPayAmount"
                                        runat="server" onkeypress="kp_numeric();" ToolTip="To Pay Amount" onKeyDown="return noCTRL(event)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnRcvAmt" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="textBalanceAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("CrAmount") %>' ToolTip="Balance Amount"
                                        onKeyDown="return noCTRL(event)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnCRAmt" runat="server" Value='<%# Eval("CrAmount") %>' />
                                    <asp:HiddenField ID="hdnBalanceAmount" runat="server" />
                                    <asp:HiddenField ID="hdnTaxExemptionPerc" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="textPaidAmount"
                                        runat="server" onchange="OnCheckInvoiceAmt(this)" Text='<%# Eval("TrnValue") %>'
                                        ToolTip="Paid Amount" Enabled="false"></asp:TextBox>
                                    <asp:HiddenField ID="HdnTrnType" runat="server" Value='<%# Eval("TrnType") %>' />
                                    <asp:HiddenField ID="hdnRemarks" runat="server" Value='<%# Eval("Remarks") %>' />
                                    <asp:HiddenField ID="hdnPaidAmt" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox Width="20px" ID="chkSelect" runat="server" ToolTip="Select" onClick="OnCheckInvoice(this)">
                                    </asp:CheckBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <table cellspacing="0" cellpadding="0">
                    <tr align="right">
                        <td colspan="4">
                            <asp:Label ID="lblGrandTotal" Width="610px" CssClass="FormLabel" BackColor="White"
                                Font-Bold="true" runat="server" Text="Total ">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="120px" ID="textBaseAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Bill Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBillAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Bill Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textWaiverAmountotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="TextTdsTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblCr" runat="server" Width="150"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="TextCrTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textToPayAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="To Pay Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBalanceAmountTotal"
                                runat="server" onkeypress="kp_numeric();" ToolTip="Balance Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textPaidAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Paid Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                    </tr>
                </table>
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
                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                            <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="FormButton" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                            <asp:Button ID="BtnSendMail" runat="server" Text="Send Mail" CssClass="FormButton" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                        <td style="width: 120px" align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
