<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PaymentIssue.aspx.vb" Inherits="Commercial_PaymentIssue" Title="eLOGiPark :: Payment Issue"
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
    <script type="text/javascript">
        $(function () {
            $('#inv').Scrollable({
                ScrollHeight: 400
            });
        });
    </script>
    <script type='text/javascript'>
        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            for (var j = 0; j < 222; j++) {
                var msg = "Sorry, this functionality is disabled.";
                if (parseInt(code) == j + 1) //CTRL
                {
                    window.event.returnValue = true;
                }
            }
        }
        function noCTRL1(e) {
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
        function GetCrAmt(ctrl) {
            //if (ctrl.value != '') {
            try {
                var currentRow = ctrl.id.toString().replace('_TextDrNo', '');
                var prvcrAmt = document.getElementById(currentRow + "_hdnDrAmt1").value;
                var PrvCrNo = document.getElementById(currentRow + "_HdnDrNo").value;
                var BalAmt = document.getElementById(currentRow + "_textBalanceAmount").value;
                var HdnCRAmt = document.getElementById(currentRow + "_HdnCRAmt").value;
                PageMethods.GetItemsDetails(ctrl.value, PrvCrNo, prvcrAmt, BalAmt, HdnCRAmt, onSucess, onError);
                function onSucess(result) {
                    //alert(result);
                    var dtls = result;
                    if (dtls == 'N') {
                        alert('Item Does Not Exist!');
                        return;
                    }
                    if (dtls != '') {
                        var AllDetails = dtls.split(',');
                        var Billto = document.getElementById(currentRow + "_HdnCustomerId").value;
                        var amt = AllDetails[6];
                        var Billto1 = AllDetails[1];
                        if (Billto != Billto1) {
                            if (amt == 0) {
                                document.getElementById(currentRow + "_textBalanceAmount").value = AllDetails[5];
                                document.getElementById(currentRow + "_hdnDrAmt1").value = 0;
                                document.getElementById(currentRow + "_HdnDrNo").value = 0;
                                document.getElementById(currentRow + "_txtDrAmt").value = 0;
                                document.getElementById(currentRow + "_textPaidAmount").value = AllDetails[5];
                            }
                        }
                        if (Billto == Billto1) {
                            document.getElementById(currentRow + "_textBalanceAmount").value = AllDetails[5];
                            document.getElementById(currentRow + "_hdnDrAmt1").value = AllDetails[6];
                            document.getElementById(currentRow + "_HdnDrNo").value = AllDetails[3];
                            document.getElementById(currentRow + "_txtDrAmt").value = AllDetails[6];
                            document.getElementById(currentRow + "_textPaidAmount").value = AllDetails[5];
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
            var hdnPreviousReceiptNo = document.getElementById("<%=hdnPreviousReceiptNo.clientid%>");
            var hdnPreviousBalance = document.getElementById("<%=hdnPreviousBalance.clientid%>");
            var hdnPreviousDate = document.getElementById("<%=hdnPreviousDate.clientid%>");
            var hdnPreviousReceiptRefNo = document.getElementById("<%=hdnPreviousReceiptRefNo.clientid%>");
            HdnpaymentMode.value = 'T';
            hdnReceiptNo.value = hdnRECEIPT_NO.value;
            textRecBalanceAmount.value = 0;
            HdnTotalPayment.value = 0;
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");
            var textPreviousReceiptNo = document.getElementById("<%=textPreviousReceiptNo.clientid%>");
            var textPreviousBalance = document.getElementById("<%=textPreviousBalance.clientid%>");
            var textTotalAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            lstBankName.disabled = true;
            lstReceiverBank.disabled = true;
            textPaymentAmount.disabled = true;
            lstDrCr.disabled = true;
            textChequeDate.disabled = true;
            textChequeNo.disabled = true;
            lstPaymentMode.disabled = true;
            if (CheckBox1.checked == true) {
                document.getElementById("<%=hdnReceiptNo.clientid%>").value = hdnRECEIPT_NO.value;
                textRecBalanceAmountTotal.value = lblBalance.innerText;
                textPreviousReceiptNo.value = lblReceiptNO.innerText;
                textRecBalanceAmount.value = lblBalance.innerText;
                textPreviousBalance.value = lblBalance.innerText;
                hdnPreviousBalance.value = lblBalance.innerText;
                hdnPreviousReceiptNo.value = hdnRECEIPT_NO.value;
                hdnPreviousDate.value = lblReceiptDate.innerText;
                hdnPreviousReceiptRefNo.value = lblReceiptNO.innerText;
                textTotalAmount.value = lblBalance.innerText;
            }
            else {
                document.getElementById("<%=hdnReceiptNo.clientid%>").value = 0;
                textRecBalanceAmountTotal.value = 0;
                textPreviousReceiptNo.value = 0;
                textRecBalanceAmount.value = 0;
                textPreviousBalance.value = 0;
                hdnPreviousDate.value = 0;
                hdnPreviousReceiptRefNo.value = 0;
                textTotalAmount.value = 0;
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
            document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_HdnTdsAmt1").setAttribute('value', TextTdsAmt.value);
            var HdnRcvAmt = parseFloat(HdnCRAmt.value) + parseFloat(HdnTdsAmt.value);
            if (textBillAmount.value <= HdnRcvAmt) {
                var temp = parseFloat(textBillAmount.value) - parseFloat(TextTdsAmt.value);
                textBalanceAmount.value = temp;
                textToPayAmount.value = temp;
            }
            else {
                var temp = parseFloat(HdnCRAmt.value) - parseFloat(TextTdsAmt.value);
                textBalanceAmount.value = temp;
                textToPayAmount.value = temp;
            }
        }
        function ListEnable(id) {
            var strsbno = "_lstPaymentType";

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
//        function OnCheckInvoice(id) {
//            var strsbno = "_chkSelect";
//            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
//            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
//            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
//            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
//            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
//            var hdnPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmount");
//            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
//            //            if (parseFloat(textPaidAmount.value) == 0) {
//            //                alert('Paying amount should be  greater then zero.');
//            //                document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
//            //                chkSelect.checked = false;
//            //                rtnval = false;
//            //            }


//            if (parseFloat(textPaidAmount.value) > parseFloat(textBalanceAmount.value)) {
//                alert('Paid amount should be less then qual to balance amount.');
//                document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
//                // chkSelect.checked = false;
//                rtnval = false;
//            }

//            if (chkSelect.checked == true) {
//                textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
//                hdnPaidAmount.value = parseFloat(textPaidAmount.value).toFixed(2);

//            }
//            if (chkSelect.checked == false) {
//                textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
//                // textPaidAmount.disabled = false;
//            }


//            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
//            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
//            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
//            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
//            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
//            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
//            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
//            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
//            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
//            var chkSelect2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
//            var textInvoiceRefNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceRefNo");
//            var textInvoiceDate = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceDate");
//            var textPartyInvNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPartyInvNo");
//            var TextBaseAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextBaseAmount");
//            var textBillAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBillAmount");
//            var textWaiverAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textWaiverAmount");
//            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
//            if (chkSelect.checked == true) {
//                chkSelect2.checked = true;
//                textInvoiceRefNo.style.color = "#FF4500";
//                textInvoiceMode.style.color = "#FF4500";
//                textToPayAmount.style.color = "#FF4500";
//                textBalanceAmount.style.color = "#FF4500";
//                textPaidAmount.style.color = "#FF4500";
//                TextTdsAmt.style.color = "#FF4500";
//                //textPaymentAmount.style.color = "#FFA500";
//                textInvoiceDate.style.color = "#FF4500";
//                textPartyInvNo.style.color = "#FF4500";
//                TextBaseAmount.style.color = "#FF4500";
//                textBillAmount.style.color = "#FF4500";
//                textWaiverAmount.style.color = "#FF4500";
//                TextCrAmt.style.color = "#FF8C00";
//                textInvoiceRefNo.style.fontWeight = "bold";
//                textInvoiceMode.style.fontWeight = "bold";
//                textToPayAmount.style.fontWeight = "bold";
//                textBalanceAmount.style.fontWeight = "bold";
//                textPaidAmount.style.fontWeight = "bold";
//                TextTdsAmt.style.fontWeight = "bold";
//                textInvoiceDate.style.fontWeight = "bold";
//                textPartyInvNo.style.fontWeight = "bold";
//                TextBaseAmount.style.fontWeight = "bold";
//                textBillAmount.style.fontWeight = "bold";
//                textWaiverAmount.style.fontWeight = "bold";
//                TextCrAmt.style.fontWeight = "bold";
//                //textPaymentAmount.style.fontWeight = "bold";

//            }
//            else {
//                chkSelect2.checked = false;
//                textInvoiceRefNo.style.color = "black";
//                textInvoiceMode.style.color = "black";
//                textToPayAmount.style.color = "black";
//                textBalanceAmount.style.color = "black";
//                textPaidAmount.style.color = "black";
//                TextTdsAmt.style.color = "black";
//                //textPaymentAmount.style.color = "#FFA500";
//                textInvoiceDate.style.color = "black";
//                textPartyInvNo.style.color = "black";
//                TextBaseAmount.style.color = "black";
//                textBillAmount.style.color = "black";
//                textWaiverAmount.style.color = "black";
//                TextCrAmt.style.color = "black";
//                textInvoiceRefNo.style.fontWeight = "normal";
//                textInvoiceMode.style.fontWeight = "normal";
//                textToPayAmount.style.fontWeight = "normal";
//                textBalanceAmount.style.fontWeight = "normal";
//                textPaidAmount.style.fontWeight = "normal";
//                TextTdsAmt.style.fontWeight = "normal";
//                textInvoiceDate.style.fontWeight = "normal";
//                textPartyInvNo.style.fontWeight = "normal";
//                TextBaseAmount.style.fontWeight = "normal";
//                textBillAmount.style.fontWeight = "normal";
//                textWaiverAmount.style.fontWeight = "normal";
//                TextCrAmt.style.fontWeight = "normal";
//            }
//        }
//        function OnCheckInvoice1(id) {
//            var strsbno = "_CheckBox2";
//            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
//            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
//            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
//            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
//            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
//            var hdnPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmount");
//            //            if (parseFloat(textPaidAmount.value) == 0) {
//            //                alert('Paying amount should be  greater then zero.');
//            //                document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();

//            //                chkSelect.checked = false;
//            //                rtnval = false;
//            //            }

//            if (chkSelect.checked == true) {
//                textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
//                hdnPaidAmount.value = parseFloat(textPaidAmount.value).toFixed(2);
//                // textPaidAmount.disabled = true;
//                //  rtnval = false;
//            }
//            if (chkSelect.checked == false) {
//                textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
//                //textPaidAmount.disabled = false;
//            }


//            //var tablename = 105;
//            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
//            //            if (tablename == null || tablename == '') {
//            //                strsbno = "_textPaidAmount";
//            //                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
//            //            }

//            var texttotalPaymentAmount = document.getElementById("<%=textTotalAmount.clientid%>");
//            if (texttotalPaymentAmount.value == null || texttotalPaymentAmount.value == '') {
//                texttotalPaymentAmount.value = 0;
//            }
//            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");

//            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
//            var textBalanceAmountTotal = document.getElementById("<%=textBalanceAmountTotal.clientid%>");

//            if (textRecBalanceAmountTotal.value == null || textRecBalanceAmountTotal.value == '') {
//                textRecBalanceAmountTotal.value = 0;
//            }

//            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
//            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
//            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
//            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
//            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
//            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
//            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
//            var textPaymentAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl" + tablename + "_textPaymentAmount");
//            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
//            var chkSelect2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
//            var textInvoiceRefNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceRefNo");
//            var textInvoiceDate = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceDate");
//            var textPartyInvNo = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPartyInvNo");
//            var TextBaseAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextBaseAmount");
//            var textBillAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBillAmount");
//            var textWaiverAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textWaiverAmount");
//            var TextCrAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextCrAmt");
//            hdnPaidAmt.value = 0;
//            TextTdsAmt.disabled = true;
//            textPaidAmount.disabled = false;
//            if (chkSelect2.checked == true) {
//                chkSelect.checked = true;
//                textInvoiceRefNo.style.color = "#FF4500";
//                textInvoiceMode.style.color = "#FF4500";
//                textToPayAmount.style.color = "#FF4500";
//                textBalanceAmount.style.color = "#FF4500";
//                textPaidAmount.style.color = "#FF4500";
//                TextTdsAmt.style.color = "#FF4500";
//                //textPaymentAmount.style.color = "#FFA500";
//                textInvoiceDate.style.color = "#FF4500";
//                textPartyInvNo.style.color = "#FF4500";
//                TextBaseAmount.style.color = "#FF4500";
//                textBillAmount.style.color = "#FF4500";
//                textWaiverAmount.style.color = "#FF4500";
//                TextCrAmt.style.color = "#FF8C00";
//                textInvoiceRefNo.style.fontWeight = "bold";
//                textInvoiceMode.style.fontWeight = "bold";
//                textToPayAmount.style.fontWeight = "bold";
//                textBalanceAmount.style.fontWeight = "bold";
//                textPaidAmount.style.fontWeight = "bold";
//                TextTdsAmt.style.fontWeight = "bold";
//                textInvoiceDate.style.fontWeight = "bold";
//                textPartyInvNo.style.fontWeight = "bold";
//                TextBaseAmount.style.fontWeight = "bold";
//                textBillAmount.style.fontWeight = "bold";
//                textWaiverAmount.style.fontWeight = "bold";
//                TextCrAmt.style.fontWeight = "bold";
//                //textPaymentAmount.style.fontWeight = "bold";

//            }
//            else {
//                chkSelect.checked = false;
//                textInvoiceRefNo.style.color = "black";
//                textInvoiceMode.style.color = "black";
//                textToPayAmount.style.color = "black";
//                textBalanceAmount.style.color = "black";
//                textPaidAmount.style.color = "black";
//                TextTdsAmt.style.color = "black";
//                //textPaymentAmount.style.color = "#FFA500";
//                textInvoiceDate.style.color = "black";
//                textPartyInvNo.style.color = "black";
//                TextBaseAmount.style.color = "black";
//                textBillAmount.style.color = "black";
//                textWaiverAmount.style.color = "black";
//                TextCrAmt.style.color = "black";
//                textInvoiceRefNo.style.fontWeight = "normal";
//                textInvoiceMode.style.fontWeight = "normal";
//                textToPayAmount.style.fontWeight = "normal";
//                textBalanceAmount.style.fontWeight = "normal";
//                textPaidAmount.style.fontWeight = "normal";
//                TextTdsAmt.style.fontWeight = "normal";
//                textInvoiceDate.style.fontWeight = "normal";
//                textPartyInvNo.style.fontWeight = "normal";
//                TextBaseAmount.style.fontWeight = "normal";
//                textBillAmount.style.fontWeight = "normal";
//                textWaiverAmount.style.fontWeight = "normal";
//                TextCrAmt.style.fontWeight = "normal";
//            }

//            if (textToPayAmount.value == null || textToPayAmount.value == '') {
//                textToPayAmount.value = 0;
//                textInvoiceRefNo.style.color = "black";
//            }
//            if (textBalanceAmount.value == null || textBalanceAmount.value == '') {
//                textBalanceAmount.value = 0;
//            }
//            if (textPaidAmount.value == null || textPaidAmount.value == '') {
//                textPaidAmount.value = 0;
//            }

//            if (chkSelect.checked == true && parseFloat(textRecBalanceAmountTotal.value) <= 0) {
//                alert('Not Sufficent Balance');
//                document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textPaymentAmount").focus();
//                rtnval = false;
//            }
//            else if (parseFloat(textRecBalanceAmountTotal.value) >= 0) {
//                if (chkSelect.checked == true) {
//                    if (parseFloat(textRecBalanceAmountTotal.value) < parseFloat(textBalanceAmount.value)) {
//                        newPaidAmount = parseFloat(textRecBalanceAmountTotal.value).toFixed(2);

//                    }
//                    else if (parseFloat(textRecBalanceAmountTotal.value) >= parseFloat(textBalanceAmount.value)) {
//                        newPaidAmount = parseFloat(textBalanceAmount.value).toFixed(2);
//                    }

//                }
//                else {

//                    textBalanceAmount.value = parseFloat(textPaidAmount.value) + parseFloat(textBalanceAmount.value);
//                    textPaidAmount.value = 0;
//                    newPaidAmount = 0;
//                }
//                if (parseFloat(textToPayAmount.value) < parseFloat(textBalanceAmount)) {
//                    alert('Enter amount is greater then balance amount.');
//                    rtnval = false;
//                }
//                textPaidAmount.value = newPaidAmount;
//                hdnPaidAmt.value = newPaidAmount;
//                var tempBalnnceAmount = parseFloat(parseFloat(textBalanceAmount.value) - parseFloat(textPaidAmount.value)).toFixed(2);
//                textBalanceAmount.value = tempBalnnceAmount;


//                var strsbno1 = "_textPaymentAmount";
//                var tablename1 = document.getElementById("inv").getElementsByTagName("tr").length;
//                var temptextPaidAmountTotal = 0;
//                var temptextBalanceAmountTotal = 0;

//                var temptexttotalPaymentAmount = 0;
//                var temptextRecBalanceAmountTotal = 0;
//                for (var j = 2; j < tablename1; j++) {
//                    var tempPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textPaidAmount").value;
//                    var temphdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_hdnPaidAmt");
//                    var tempInvBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + LPad((j - 1) + "", 2, "0") + "_textBalanceAmount").value;
//                    temptextPaidAmountTotal = parseFloat(temptextPaidAmountTotal) + parseFloat(tempPaidAmount);
//                    textPaidAmountTotal.value = temptextPaidAmountTotal;
//                    temptextBalanceAmountTotal = parseFloat(temptextBalanceAmountTotal) + parseFloat(tempInvBalanceAmount)
//                    textBalanceAmountTotal.value = temptextBalanceAmountTotal;
//                    var prevBal = document.getElementById("<%=textPreviousBalance.clientid%>").value;
//                    if (prevBal == null || prevBal == '') {
//                        document.getElementById("<%=textPreviousBalance.clientid%>").value = 0;
//                        prevBal = 0;
//                    }
//                    var temp = parseFloat(parseFloat(texttotalPaymentAmount.value) - parseFloat(temptextPaidAmountTotal) + parseFloat(prevBal)).toFixed(2);
//                    textRecBalanceAmountTotal.value = temp;
//                    var textRecBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_tabCustomerMaster_tabMaster_repPaymentDetails_ctl01_textRecBalanceAmount");
//                    if (chkSelect.checked == false) {
//                        TextTdsAmt.disabled = false;
//                        textPaidAmount.disabled = true;
//                    }

//                    textRecBalanceAmount.value = temp;
//                    //textRecBalanceAmount.value = temp;

//                }
//            }
//            //
//            // }
//            //return rtnval;
        //        }


        function OnCheckInvoice(id) {
            debugger;
            var strsbno = "_chkSelect";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var hdnPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var textTotalAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");
            var i = 0;
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmount.value) > parseFloat(textBalanceAmount.value)) {
                    alert('Paid amount should be less then qual to balance amount.');
                    document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;
                } 
            }
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmount.value) > parseFloat(textRecBalanceAmountTotal.value)) {
                    alert('Paid Amount Should be equal to Payment Balance amount.');
                    // textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;
                }
            }
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmountTotal.value) > parseFloat(textTotalAmount.value)) {
                    alert('Paid Amount Should be equal to payment amount.');
                    //   textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;

                }
            }
            if (chkSelect.checked == true) {
                if (i == 0) {
                    textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
                    hdnPaidAmount.value = parseFloat(textPaidAmount.value).toFixed(2);
                    textRecBalanceAmountTotal.value = parseFloat((parseFloat(textRecBalanceAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                }
            }
            if (chkSelect.checked == false) {
               
                    textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                    textRecBalanceAmountTotal.value = parseFloat((parseFloat(textRecBalanceAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
                }
                if (chkSelect.checked == true && i > 0) {
                    chkSelect.checked = false;
                }

            var textInvoiceMode = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textInvoiceMode");
            var textToPayAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textToPayAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var hdnBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnBalanceAmount");
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var hdnPaidAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmt");
            var TextTdsAmt = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_TextTdsAmt");
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
        }
        function OnCheckInvoice1(id) {
            var strsbno = "_CheckBox2";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            var hdnPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var textTotalAmount = document.getElementById("<%=textTotalAmount.clientid%>");
            var textRecBalanceAmountTotal = document.getElementById("<%=textRecBalanceAmountTotal.clientid%>");
            var i = 0;
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmount.value) > parseFloat(textBalanceAmount.value)) {
                    alert('Paid amount should be less then qual to balance amount.');
                    document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;
                }
            }
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmount.value) > parseFloat(textRecBalanceAmountTotal.value)) {
                    alert('Paid Amount Should be equal to Payment Balance amount.');
                    // textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;
                }
            }
            if (chkSelect.checked == true) {
                if (parseFloat(textPaidAmountTotal.value) > parseFloat(textTotalAmount.value)) {
                    alert('Paid Amount Should be equal to payment amount.');
                    //   textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                    // chkSelect.checked = false;
                    rtnval = false;
                    i++;

                }
            }
            if (chkSelect.checked == true) {
                if (i == 0) {
                    textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
                    hdnPaidAmount.value = parseFloat(textPaidAmount.value).toFixed(2);
                    textRecBalanceAmountTotal.value = parseFloat((parseFloat(textRecBalanceAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                }
            }
            if (chkSelect.checked == false) {

                textPaidAmountTotal.value = parseFloat((parseFloat(textPaidAmountTotal.value) - parseFloat(textPaidAmount.value))).toFixed(2);
                textRecBalanceAmountTotal.value = parseFloat((parseFloat(textRecBalanceAmountTotal.value) + parseFloat(textPaidAmount.value))).toFixed(2);
            }
            if (chkSelect.checked == true && i > 0) {
                chkSelect.checked = false;
            }
           

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
                    rtnval = false;
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
                for (var j = 2; j < tablename1; j++) {
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
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var CheckBox2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
            var hdnPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnPaidAmount");
            var textPaidAmountTotal = document.getElementById("<%=textPaidAmountTotal.clientid%>");
            if (chkSelect.checked == true) {
                alert('You can"t changed Paid amount, when purchase invoice already checked');
                textPaidAmount.value = parseFloat(hdnPaidAmount.value);
                rtnval = false;
            }

            if (CheckBox2.checked == true) {
                alert('You cant changed Paid amount, when purchase invoice already checked');
                textPaidAmount.value = parseFloat(hdnPaidAmount.value);
                rtnval = false;
            }

            if (parseFloat(textPaidAmount.value) > parseFloat(textBalanceAmount.value)) {
                alert('Enter amount is greater then balance amount.');
                document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
                //    chkSelect.checked = false;
                textPaidAmount.value = parseFloat(parseFloat(textBalanceAmount.value)).toFixed(2);
                rtnval = false;

            }

            if (parseFloat(textPaidAmount.value) == 0) {
                alert('Paying amount should be  greater then zero.');
                document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount").focus();
                chkSelect.checked = false;
                rtnval = false;
            }


        }

        function OnRoundOffAmt(id) {
            debugger;
            strsbno = "_txtRoundOff";
            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            var textPaidAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textPaidAmount");
            var textBalanceAmount = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_textBalanceAmount");
            var txtRoundOff = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_txtRoundOff");
            var hdnRoundOff = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_hdnRoundOff");
            var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_chkSelect");
            var CheckBox2 = document.getElementById("ctl00_ContentPlaceHolder1_repInvoiceDetails_ctl" + tablename + "_CheckBox2");
            var roundoffhdn = hdnRoundOff.value;
            if (chkSelect.checked == true) {
                alert('You can"t changed Round Off amount, when purchase invoice already checked');
                txtRoundOff.value = parseFloat(hdnRoundOff.value);
                rtnval = false;
            }


            if (hdnRoundOff.value == null || hdnRoundOff.value == '' || hdnRoundOff.value == 0) {
                hdnRoundOff.value = 0;
                var balanceamount1 = parseFloat(parseFloat(textPaidAmount.value) + parseFloat(txtRoundOff.value)).toFixed(2);
                var paidamount1 = parseFloat(parseFloat(textPaidAmount.value) + parseFloat(txtRoundOff.value)).toFixed(2);
                textPaidAmount.value = paidamount1;
                textBalanceAmount.value = balanceamount1;
                hdnRoundOff.value = parseFloat(txtRoundOff.value);

            }
            else {
                var balanceamount = parseFloat(parseFloat(textPaidAmount.value) + parseFloat(txtRoundOff.value) - parseFloat(hdnRoundOff.value)).toFixed(2);
                var paidamount = parseFloat(parseFloat(textPaidAmount.value) + parseFloat(txtRoundOff.value) - parseFloat(hdnRoundOff.value)).toFixed(2);
                textPaidAmount.value = balanceamount;
                textBalanceAmount.value = paidamount;
                hdnRoundOff.value = parseFloat(txtRoundOff.value);
            }

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
                            <asp:Label ID="lblScreenTitle" runat="server" Text="Payment Issue" Width="400px"
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
                                                <asp:Label ID="Label1" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPurchaseType" AutoPostBack="true" Width="130" runat="server"
                                                    ToolTip="Purchase Type" CssClass="FormListBoxLargMandatory">
                                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Maintenance" Value="M"></asp:ListItem>
                                                      <asp:ListItem Text="Expense" Value="E"></asp:ListItem>
                                                     <asp:ListItem Text="Transport" Value="T"></asp:ListItem>
                                                    <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                                    <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                                    <asp:ListItem Text="Clearing & Forwading" Value="C"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPaymentType" runat="server" Text="Payment Type" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPaymentType" runat="server" Width="130" ToolTip="Payment Type"
                                                    CssClass="FormListBoxMediumMandatory" onchange="ListEnable(this)">
                                                    <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="P" Text="Purchase Invoice"></asp:ListItem>
                                                    <asp:ListItem Value="S" Text="Advance"></asp:ListItem>
                                                    <asp:ListItem Value="T" Text="OnAccount"></asp:ListItem>
                                                    <asp:ListItem Value="V" Text="Opening Balance"></asp:ListItem>
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
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate"
                                                    Width="90px" onkeypress="kp_date();" MaxLength="10">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textFromDate" />
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="FormTextBoxDate"
                                                    onkeypress="kp_date();" MaxLength="10">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <%-- <td align="left">
                                                <asp:Label ID="lblService" runat="server" Text="Service " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstService" Width="280" runat="server" ToolTip="Customer" CssClass="FormListBoxLarg">
                                                </asp:DropDownList>
                                               
                                            </td>--%>
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
                                                <asp:Label ID="lblPreviousreceiptNo" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                    runat="server" Text="Previous Receipt">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="130px" ID="textPreviousReceiptNo"
                                                    runat="server" ToolTip="Previous Receipt No"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPreviousBalance" CssClass="FormLabel" BackColor="White" Font-Bold="true"
                                                    runat="server" Text="Previous Balance">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="RptFormTextBoxMedium" Width="120px" ID="textPreviousBalance"
                                                    runat="server" ToolTip="Previous Balance"></asp:TextBox>
                                                <asp:HiddenField ID="hdnPreviousBalance" runat="server" />
                                                <asp:HiddenField ID="hdnPreviousDate" runat="server" />
                                                <asp:HiddenField ID="hdnPreviousReceiptRefNo" runat="server" />
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReceiptDate" runat="server" Text="Receipt Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textReceiptdate" Width="120" runat="server" ToolTip="Receipt Date"
                                                    CssClass="RptFormTextBoxMedium">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnPreviousReceiptNo" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRemarks" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="TxtRemarks" Width="500px" MaxLength="500" runat="server" Height="45px"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>

                                             <td>
                                                <asp:Label ID="lblService" runat="server" CssClass="FormLabel" Text="Service"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="lstService" runat="server" Width="250" ToolTip="Service"
                                                    CssClass="FormListBoxMediumMandatory" >
                                                    <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="P" Text="Purchase Invoice"></asp:ListItem>
                                                    <asp:ListItem Value="S" Text="Advance"></asp:ListItem>
                                                    <asp:ListItem Value="T" Text="OnAccount"></asp:ListItem>
                                                    <asp:ListItem Value="V" Text="Opening Balance"></asp:ListItem>
                                                </asp:DropDownList>
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
            <td>
                <div style="overflow: auto; height: 250px;">
                    <asp:Repeater ID="repInvoiceDetails" runat="server">
                        <HeaderTemplate>
                            <table cellspacing="0" cellpadding="0" id="inv">
                                <tr class="RepHead">
                                    <td align="center" colspan="3">
                                        <asp:Label ID="lblInvoiceDetails" runat="server" Font-Size="11" Width="330px" Font-Bold="true"
                                            CssClass="FormLabel" Text="Purchase Invoice Details"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="RepHead">
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceRefNo" Font-Size="11" Font-Bold="true" CssClass="FormLabel"
                                            Width="220px" runat="server" Text="Purchase Invoice No"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceDate" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="120px" runat="server" Text="Purchase Inv. Date"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceMode" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="120px" runat="server" Text="Inv. Mode"></asp:Label>
                                    </td>
                                    <%--  <td align="center">
                                        <asp:Label ID="lblPartyInvoiceNo" CssClass="FormLabel" Font-Size="12" Font-Bold="true"
                                            Width="150px" runat="server" Text="Sale Inv. No."></asp:Label>
                                    </td>--%>
                                    <td align="center">
                                        <asp:Label ID="LblBaseAmt" CssClass="FormLabel" Width="100px" Font-Size="11" Font-Bold="true"
                                            runat="server" Text="Base Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblBillAmount" CssClass="FormLabel" Width="100px" Font-Size="11" Font-Bold="true"
                                            runat="server" Text="Total"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblWaiverApprove" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="70px" runat="server" Text="W.Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblTdsAmt" CssClass="FormLabel" Width="100px" Font-Size="11" Font-Bold="true"
                                            runat="server" Text="TDS Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label1" CssClass="FormLabel" Width="150px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="CRN. No"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label5" CssClass="FormLabel" Width="100px" Font-Size="12" Font-Bold="true"
                                            runat="server" Text="Cr. Amt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="LblCrAmt" CssClass="FormLabel" Width="100px" Font-Size="11" Font-Bold="true"
                                            runat="server" Text="Dr. Amt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblToPayAmount" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="100px" runat="server" Text="Issue. Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label4" CssClass="FormLabel" Font-Size="11" Font-Bold="true" Width="70px"
                                            runat="server" Text="Round Off"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblBananceAmount" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="100px" runat="server" Text="Bal. Amt."></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblPaidAmount" CssClass="FormLabel" Font-Size="11" Font-Bold="true"
                                            Width="100px" runat="server" Text="Paid Amt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblSelect" Width="20px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td align="center" width="10px" style="background-color: White">
                                        &nbsp;
                                    </td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox Width="20px" ID="CheckBox2" Height="20" CssClass="biggerCheckbox" runat="server"
                                        ToolTip="Select" onClick="OnCheckInvoice1(this)"></asp:CheckBox>
                                    <asp:TextBox class="FormTextBoxLarg" Font-Size="10" Width="190px" ID="textInvoiceRefNo"
                                        runat="server" ToolTip="Invoice Ref No">
                                    </asp:TextBox>
                                    <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                    <asp:HiddenField ID="HdnCustomerId" Value='<%# Eval("CustomerId") %>' runat="server" />
                                    <%-- <asp:HiddenField ID="hdnTrnType" Value='<%# Eval("TrnType") %>' runat="server" />--%>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="10" Width="120px" ID="textInvoiceDate"
                                        runat="server" ToolTip="Invoice Date"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="10" Width="120px" ID="textInvoiceMode"
                                        runat="server" ToolTip="Invoice Mode"></asp:TextBox>
                                    <%--<asp:HiddenField ID="hdnPaymentMode" runat="server" />--%>
                                </td>
                                <%--   <td>
                                    <asp:TextBox class="FormTextBoxSmall" Font-Size="12" Width="150px" ID="textPartyInvNo"
                                        runat="server" ToolTip="PartyInvNo"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="TextBaseAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("TERMINALID") %>' onKeyDown="return noCTRL(event)"
                                        ToolTip="Bill Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="textBillAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("CrAmount") %>' ToolTip="Bill Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="70px" ID="textWaiverAmount"
                                        runat="server" onkeypress="kp_numeric();" ToolTip="Waiver Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="TextTdsAmt"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("KeyId") %>' ToolTip="Waiver Amount"
                                        onchange="TotalAmounttds(this)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnTdsAmt" runat="server" Value='<%# Eval("KeyId") %>' />
                                    <asp:HiddenField ID="HdnTdsAmt1" runat="server" Value='<%# Eval("KeyId")%>' />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="150px" ID="TextDrNo"
                                        runat="server" ToolTip="Credit Note NO" onchange="GetCrAmt(this)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnDrId" runat="server" />
                                    <asp:HiddenField ID="hdnDrAmt1" runat="server" Value="0" />
                                    <asp:HiddenField ID="HdnDrNo" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="12" Width="100px" ID="txtDrAmt"
                                        runat="server" onkeypress="kp_numeric();" onKeyDown="return noCTRL(event)" ToolTip="Cr Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="TextCrAmt"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("TrnValue") %>' onKeyDown="return noCTRL(event)"
                                        ToolTip="Waiver Amount"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="textToPayAmount"
                                        runat="server" onkeypress="kp_numeric();" ToolTip="To Pay Amount" onKeyDown="return noCTRL(event)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnRcvAmt" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" ID="txtRoundOff" Width="70px"
                                        runat="server" onchange="OnRoundOffAmt(this)" ToolTip="Round Off Amount"></asp:TextBox>
                                    <asp:HiddenField ID="hdnRoundOff" runat="server" />
                                    <asp:HiddenField ID="hdnRoundOffStatus" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="textBalanceAmount"
                                        runat="server" onkeypress="kp_numeric();" Text='<%# Eval("CrAmount") %>' ToolTip="Balance Amount"
                                        onKeyDown="return noCTRL(event)"></asp:TextBox>
                                    <asp:HiddenField ID="HdnCRAmt" runat="server" Value='<%# Eval("CrAmount") %>' />
                                    <asp:HiddenField ID="hdnBalanceAmount" runat="server" />
                                    <asp:HiddenField ID="hdnTaxExemptionPerc" runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox class="FormTextBoxNumeric" Font-Size="10" Width="100px" ID="textPaidAmount"
                                        runat="server" onchange="OnCheckInvoiceAmt(this)" ToolTip="Paid Amount" Enabled="false"></asp:TextBox>
                                    <asp:HiddenField ID="HdnTrnType" runat="server" Value='<%# Eval("TrnType") %>' />
                                    <asp:HiddenField ID="hdnPaidAmt" runat="server" />
                                    <asp:HiddenField ID="hdnPaidAmount" runat="server" />
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
                            <asp:Label ID="lblGrandTotal" Width="465px" CssClass="FormLabel" BackColor="White"
                                Font-Bold="true" runat="server" Text="Total ">
                            </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBaseAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Bill Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textBillAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Bill Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="70px" ID="textWaiverAmountotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="TextTdsTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td width="150px">
                        </td>
                        <td width="100px">
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="TextCrTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="Waiver Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox class="FormTextBoxNumeric" Width="100px" ID="textToPayAmountTotal" runat="server"
                                onkeypress="kp_numeric();" ToolTip="To Pay Amount Total" onKeyDown="return noCTRL(event)"></asp:TextBox>
                        </td>
                        <td width="70px">
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
            <td valign="top" align="left" colspan="2">
                <table>
                    <tr class="UserControls" style="height: 100px; margin-top: 0px;">
                        <td style="width: 1368px;" valign="top" colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div id="RepScroling" runat="server" style="vertical-align: middle; overflow: auto;
                                        width: 100%;">
                                        <ajaxToolkit:TabContainer runat="server" ID="tabCustomerMaster" Width="100%" ActiveTabIndex="1"
                                            AutoPostBack="true">
                                            <ajaxToolkit:TabPanel runat="server" ID="tabMaster" TabIndex="0" HeaderText="Payment Details">
                                                <HeaderTemplate>
                                                    Payment Details
                                                </HeaderTemplate>
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
                                                                                    <asp:ListItem Text="DD" Value="D"></asp:ListItem>
                                                                                    <asp:ListItem Text="RTGS" Value="R"></asp:ListItem>
                                                                                    <asp:ListItem Text="ADVC" Value="A"></asp:ListItem>
                                                                                    <asp:ListItem Text="ON ACCOUNT" Value="O"></asp:ListItem>
                                                                                    <asp:ListItem Text="OPENING BALANCE" Value="B"></asp:ListItem>
                                                                                    <asp:ListItem Text="NEFT" Value="N"></asp:ListItem>
                                                                                         <asp:ListItem Text="Rebate Adjust" Value="I"></asp:ListItem>
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
                                                                <asp:Label ID="Label8" Width="1023px" CssClass="FormLabel" BackColor="White" Font-Bold="True"
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
                                                <HeaderTemplate>
                                                    On Account Details
                                                </HeaderTemplate>
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
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Instrument Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblInstrumentDate" runat="server" Text='<%# Eval("INSTRUMENT_DATE")%>'></asp:Label>
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
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle CssClass="RepheaderNew" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Receipt Date">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblReceiptDate" runat="server" Text='<%# Eval("RECEIPT_DATE")%>'></asp:Label>
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
                                                                                        <asp:TemplateField HeaderText="DR Balance">
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
