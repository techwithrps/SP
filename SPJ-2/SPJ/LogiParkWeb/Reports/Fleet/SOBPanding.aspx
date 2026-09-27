<%@ Page Title="eLOGiFleet :: SOB Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="SOBPanding.aspx.vb" Inherits="Reports_Fleet_SOBPanding"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <%--   <script language="javascript" type="text/javascript" src="ctl00_ContentPlaceHolder1../Script/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js"> </script>--%>
    <script language="javascript" type="text/javascript" src="../../Script/validation.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TextPortArrivalDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtPortArrival]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtPortCutofDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <%-- <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
        var ScrollHeight = 400;
        window.onload = function () {
            var grid = document.getElementById(GridId);
            var gridWidth = grid.offsetWidth;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;
            var table = document.createElement("table");
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            table.style.cssText = grid.style.cssText;
            table.style.width = gridWidth + "px";
            table.appendChild(document.createElement("tbody"));
            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];
            for (var i = 0; i < cells.length; i++) {
                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }
                cells[i].style.width = parseInt(width - 3) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
            }
            parentDiv.removeChild(grid);

            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
    </script>--%>

    <script type="text/javascript">
        function EnableDisableCtrol(ctrl) {


            if (ctrl.checked == true) {
                var ctrlId = ctrl.id;
                const TxtRequiredEtd = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredEtd"));
                TxtRequiredEtd.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredEtd")).style.display = 'none';

                //SECOND INPUT  TxtRequiredVessel
                const TxtRequiredVessel = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredVessel"));
                TxtRequiredVessel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredVessel")).style.display = 'none';

                //INPUT  TxtTranshipmetETA
                const TxtTranshipmetETA = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA"));
                TxtTranshipmetETA.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta")).style.display = 'none';
                //INPUT  TxtTranshipmetETA
                //SECOND INPUT  ddlPOD
                let lblCODTypeObj = document.getElementById(ctrlId.replace("CheckBox1", "lblCODType"));
                let lblCODTypeObj1 = lblCODTypeObj.textContent;
                const lstCODType1 = document.getElementById(ctrlId.replace("CheckBox1", "lstCODType"));

                for (var i = 0; i < lstCODType1.options.length; i++) {
                    if (lstCODType1.options[i].textContent == lblCODTypeObj1) {
                        lstCODType1.options[i].selected = true;
                    }
                }


                const lstCODType = document.getElementById(ctrlId.replace("CheckBox1", "lstCODType"));
                lstCODType.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCODType")).style.display = 'none';
                //INPUT  LsttranshipmentPort

                let LsttranshipmentPortObj = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort"));

                let hdntranshipmentPortSet = document.getElementById(ctrlId.replace("CheckBox1", "hdntranshipmentPort")).value;
                for (let i = 0; i < LsttranshipmentPortObj.options.length; i++) {
                    if (LsttranshipmentPortObj.options[i].value == parseInt(hdntranshipmentPortSet)) {
                        LsttranshipmentPortObj.options[i].selected = true;
                    }
                }
                const LsttranshipmentPort = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort"));
                LsttranshipmentPort.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort")).style.display = 'none';

                //INPUT  TxtTranshipmetDate
                const TxtTranshipmetDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate"));
                TxtTranshipmetDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate")).style.display = 'none';

                //INPUT  TxtTranshipmentVeseel
                const TxtTranshipmentVeseel = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel"));
                TxtTranshipmentVeseel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel")).style.display = 'none';

                //INPUT  TxtTranshipmetETA2
                const TxtTranshipmetETA2 = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA2"));
                TxtTranshipmetETA2.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta2")).style.display = 'none';

                //INPUT  LsttranshipmentPort2
                let LsttranshipmentPort2Obj = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort2"));

                let hdnLsttranshipmentPort2Set = document.getElementById(ctrlId.replace("CheckBox1", "hdnLsttranshipmentPort2")).value;
                for (let i = 0; i < LsttranshipmentPort2Obj.options.length; i++) {
                    if (LsttranshipmentPort2Obj.options[i].value == parseInt(hdnLsttranshipmentPort2Set)) {
                        LsttranshipmentPort2Obj.options[i].selected = true;
                    }
                }
                const LsttranshipmentPort2 = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort2"));
                LsttranshipmentPort2.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort2")).style.display = 'none';

                //INPUT  TxtTranshipmetDate2
                const TxtTranshipmetDate2 = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate2"));
                TxtTranshipmetDate2.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate2")).style.display = 'none';

                //INPUT  TxtTranshipmentVeseel2
                const TxtTranshipmentVeseel2 = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel2"));
                TxtTranshipmentVeseel2.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel2")).style.display = 'none';

                //INPUT  TxtRequiredETA
                const TxtRequiredETA = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA"));
                TxtRequiredETA.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'none';

                //INPUT  lstSob
                const lstSob = document.getElementById(ctrlId.replace("CheckBox1", "lstSob"));
                lstSob.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRSailed")).style.display = 'none';

                //INPUT  TxtFollowup
                const TxtFollowup = document.getElementById(ctrlId.replace("CheckBox1", "TxtFollowup"));
                TxtFollowup.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblFollowup")).style.display = 'none';

                //INPUT  TxtSobRemarks
                const TxtSobRemarks = document.getElementById(ctrlId.replace("CheckBox1", "TxtSobRemarks"));
                TxtSobRemarks.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'none';
            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredEtd")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredVessel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA2")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort2")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate2")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel2")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstSob")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtFollowup")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtSobRemarks")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstCODType")).style.display = 'none';


                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredEtd")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredVessel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta2")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort2")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate2")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel2")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRSailed")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblFollowup")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCODType")).style.display = 'inline';
            }

            //document.getElementById("ctl00_ContentPlaceHolder1_Button3").style.display = 'inline';
        }

        function AllChecked(chkAll) {
            var checkBoxes = document.querySelectorAll('[id*="CheckBox1"]');

            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i] !== chkAll) {
                    checkBoxes[i].checked = chkAll.checked;
                    EnableDisableCtrol(checkBoxes[i])
                }
            }
        }

        function validateData() {
            var gridView = document.getElementById("<%= gvtripPendencyList.ClientID %>");
            var rows = gridView.getElementsByTagName("tr");

            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                var checkbox = row.querySelector("[type='checkbox']");
                var errorMessage = document.getElementById('ctl00_ContentPlaceHolder1_lblErrorMessage');
                var errorblank = errorMessage.innerText = '';

                if (checkbox !== null && checkbox.checked) {
                    var TxtRequiredVessel = row.querySelector("[id*='TxtRequiredVessel']");
                    var TxtRequiredETA = row.querySelector("[id*='TxtRequiredETA']");
                    var TxtRequiredEtd = row.querySelector("[id*='TxtRequiredEtd']");  // FINAL ETD
                    var TxtSobRemarks = row.querySelector("[id*='TxtSobRemarks']");
                    var lstSob = row.querySelector("[id*='lstSob']"); //SOB
                    var Sessionitem = '<%= Session("LoginUser") %>';

                    var TxtTranshipmetETA = row.querySelector("[id*='TxtTranshipmetETA']");  // Transhipment ETA 1  TxtTranshipmetETA
                    var TxtTranshipmetDate = row.querySelector("[id*='TxtTranshipmetDate']");  // Transhipment ETD 1  TxtTranshipmetDate
                    var TxtTranshipmetETA2 = row.querySelector("[id*='TxtTranshipmetETA2']");  // Transhipment ETA 2
                    var TxtTranshipmetDate2 = row.querySelector("[id*='TxtTranshipmetDate2']");  // Transhipment ETD 2


                    if (lstSob.value.trim() !== '') {
                        let GivenDate = lstSob.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let SobenteredDate = new Date(year, month - 1, day);

                        let EtdGivenDate = TxtRequiredEtd.value.trim();
                        let EtdPartydate = EtdGivenDate.split(' ');
                        let [Etdday, Etdmonth, Etdyear] = EtdPartydate[0].split('/');
                        let EtdenteredDate = new Date(Etdyear, Etdmonth - 1, Etdday);

                        if (SobenteredDate > EtdenteredDate) {
                            errorMessage.innerText = 'Please ensure that the "SOB date" and "Final Etd" date are the same';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (SobenteredDate < EtdenteredDate) {
                            errorMessage.innerText = 'Please ensure that the "SOB date" and "Final Etd" date are the same';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtRequiredEtd != "") {
                        let EtdGivenDate = TxtRequiredEtd.value.trim();
                        let EtdPartydate = EtdGivenDate.split(' ');
                        let [Etdday, Etdmonth, Etdyear] = EtdPartydate[0].split('/');
                        let EtdenteredDate = new Date(Etdyear, Etdmonth - 1, Etdday);

                        let GivenDate = TxtTranshipmetETA.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let TranshipmetETAenteredDate = new Date(year, month - 1, day);

                        let GivenDate1 = TxtTranshipmetDate.value.trim();
                        let Partydate1 = GivenDate1.split(' ');
                        let [day1, month1, year1] = Partydate1[0].split('/');
                        let TranshipmetenteredDate = new Date(year1, month1 - 1, day1);

                        let GivenDate2 = TxtTranshipmetETA2.value.trim();
                        let Partydate2 = GivenDate2.split(' ');
                        let [day2, month2, year2] = Partydate2[0].split('/');
                        let TxtTranshipmetETA2enteredDate = new Date(year2, month2 - 1, day2);

                        let GivenDate3 = TxtTranshipmetDate2.value.trim();
                        let Partydate3 = GivenDate3.split(' ');
                        let [day3, month3, year3] = Partydate3[0].split('/');
                        let TxtTranshipmetDate2enteredDate = new Date(year3, month3 - 1, day3);

                        if (EtdenteredDate > TranshipmetETAenteredDate
                            || EtdenteredDate > TranshipmetenteredDate
                            || EtdenteredDate > TxtTranshipmetETA2enteredDate
                            || EtdenteredDate > TxtTranshipmetDate2enteredDate
                        ) {
                            errorMessage.innerText = 'Please ensure that the "Transhipment ETA 1", "Transhipment ETD 1", "Transhipment ETA 2" , "Transhipment ETD 2" Date is more than or equal to "Final ETD"';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }

                        let ETAGivenDate = TxtRequiredETA.value.trim();
                        let ETAPartydate = ETAGivenDate.split(' ');
                        let [ETAday, ETAmonth, ETAyear] = ETAPartydate[0].split('/');
                        let ETAenteredDate = new Date(ETAyear, ETAmonth - 1, ETAday);

                        if (EtdenteredDate > ETAenteredDate
                            || TranshipmetETAenteredDate > ETAenteredDate
                            || TranshipmetenteredDate > ETAenteredDate
                            || TxtTranshipmetETA2enteredDate > ETAenteredDate
                            || TxtTranshipmetDate2enteredDate > ETAenteredDate
                        ) {
                            errorMessage.innerText = '"Final ETD", "Transhipment ETA 1","Transhipment ETD 1", "Transhipment ETA 2", "Transhipment ETD 2" date should not be greater than "Final ETA" date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TranshipmetETAenteredDate > TranshipmetenteredDate
                            || TranshipmetETAenteredDate > TxtTranshipmetETA2enteredDate
                            || TranshipmetETAenteredDate > TxtTranshipmetDate2enteredDate
                        ) {
                            errorMessage.innerText = 'Please ensure that the  "Transhipment ETD 1", "Transhipment ETA 2" , "Transhipment ETD 2" Date is more than or equal to "TRANSHIPMENT ETA 1"';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }

                        if (TranshipmetenteredDate > TxtTranshipmetETA2enteredDate
                            || TranshipmetenteredDate > TxtTranshipmetDate2enteredDate
                        ) {
                            errorMessage.innerText = 'Please ensure that the "Transhipment ETA 2" , "Transhipment ETD 2" Date is more than or equal to "TRANSHIPMENT ETD 1"';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }

                        if (TxtTranshipmetETA2enteredDate > TxtTranshipmetDate2enteredDate
                        ) {
                            errorMessage.innerText = 'Please ensure that the  "Transhipment ETD 2" Date is more than or equal to "TRANSHIPMENT ETA 2"';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }

                    }

                    if (Sessionitem !== "Akshay" && Sessionitem !== "Nitin Saini" && Sessionitem !== "Parveen Deswal" && Sessionitem !== "Vansh" &&
                        Sessionitem !== "Faisal" && Sessionitem !== "Saurabh Chauhan" && Sessionitem !== "Khushnood Alam" && Sessionitem !== "Ayush Kapoor" && Sessionitem !== "ADMIN" && Sessionitem !== "SAHIL") {
                        if (lstSob.value === "") {
                            errorMessage.innerText = 'Please fill SOB.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        let EtdGivenDate = TxtRequiredEtd.value.trim();
                        let EtdPartydate = EtdGivenDate.split(' ');
                        let [Etdday, Etdmonth, Etdyear] = EtdPartydate[0].split('/');
                        let EtdenteredDate = new Date(Etdyear, Etdmonth - 1, Etdday);

                        let SobGivenDate = lstSob.value.trim();
                        let SobPartydate = SobGivenDate.split(' ');
                        let [Sobday, Sobmonth, Sobyear] = SobPartydate[0].split('/');
                        let SobenteredDate = new Date(Sobyear, Sobmonth - 1, Sobday);

                        if (EtdenteredDate > SobenteredDate || EtdenteredDate < SobenteredDate) {
                            errorMessage.innerText = 'Please ensure that the "SOB date" Date is  equal to "Final ETD"';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    //.............


                    if (TxtRequiredVessel.value !== null) {
                        if (TxtRequiredVessel.value === "") {
                            errorMessage.innerText = 'Please fill Vessel Detail.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredETA.value === "") {
                            errorMessage.innerText = 'Please fill ETA.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredEtd.value === "") {
                            alert("Please fill ETD.");
                            errorMessage.innerText = 'Please fill ETD.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtSobRemarks.value === "") {
                            errorMessage.innerText = 'Please fill Remarks.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtRequiredETA.value !== null & TxtRequiredETA.value !== undefined) {

                        if (TxtRequiredVessel.value === "") {
                            errorMessage.innerText = 'Please fill Vessel Detail.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredETA.value === "") {
                            errorMessage.innerText = 'Please fill ETA.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredEtd.value === "") {
                            errorMessage.innerText = 'Please fill ETD.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtSobRemarks.value === "") {
                            errorMessage.innerText = 'Please fill Remarks.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }





                     
                        //if (Sessionitem !== "Akshay" && Sessionitem !== "Nitin Saini") {
                        //    let GivenDate = lstSob.value.trim();
                        //    let Partydate = GivenDate.split(' ');
                        //    let [day, month, year] = Partydate[0].split('/');
                        //    let enteredDate = new Date(year, month - 1, day);

                        //    let today = new Date();
                        //    var currentDt = new Date();
                        //    currentDt.setDate(currentDt.getDate() - 3);

                        //    if (lstSob.value.trim() !== "" && (enteredDate > today) || (enteredDate < currentDt)) {
                        //        errorMessage.innerText = 'Please ensure that the SOB Date is more than or equal to yesterday.';
                        //        errorMessage.style.color = "red";
                        //        event.preventDefault();
                        //        return;
                        //    }
                        //}


                    }

                    if (TxtRequiredEtd.value !== null) {

                        if (TxtRequiredVessel.value === "") {
                            errorMessage.innerText = 'Please fill Vessel Detail.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredETA.value === "") {
                            errorMessage.innerText = 'Please fill ETA.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredEtd.value === "") {
                            errorMessage.innerText = 'Please fill ETD.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtSobRemarks.value === "") {
                            errorMessage.innerText = 'Please fill Remarks.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                }

            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtTRHandover]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Text="SOB Update" CssClass="FormLabelTitle"
                    Width="300px"> </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <hr />
            </td>
        </tr>
    </table>
    <table width="2000px">
        <tr>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="5" align="center">
                            <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblCustomer" runat="server" Text="Line" CssClass="label">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTrainNo" runat="server" Text="Train No" CssClass="label">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lsttrainNo" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPol" runat="server" Text="POL" CssClass="label">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblVessel" runat="server" Text="Req Vessel" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstVessel" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td width="2%"></td>
            <td>
                <table>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="Label1" runat="server" Text="TRANSIT TIME - FILTER" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblTransitTime" runat="server" Text="Transit Time" CssClass="label"> </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstTransitTime" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="BTNGO" runat="server" Text="DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td width="2%"></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="lblUpdate" runat="server" Text="TRANSHIPMENT - DRAG" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lBLtNSeTA" runat="server" Text="T/S ETA" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left" width="120px">
                            <asp:TextBox ID="TextTnaETA" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="TextTnaETA" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblTranshipmentPort" runat="server" Text="T/S Port" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTranshipemtPort" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td rowspan="3">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="FormButton"
                                Style="height: 29px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblTranshipmentETD" runat="server" Text="T/S ETD" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left" width="120px">
                            <asp:TextBox ID="TextTranshipmentETD" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="TextTranshipmentETD" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblvesselName" runat="server" Text="T/S Vessel " CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="textVessel" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td width="2%"></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="Label2" runat="server" Text="PORT ARRIVAL - DRAG" Width="250px" class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblPortArrival" runat="server" Text="Port Arrival" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextPortArrivalDate" runat="server" AutoComplete="OFF" CssClass="textbox"
                                Width="110px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                        <td>
                            <asp:Button ID="BtnUpPArrival" runat="server" Text="Update" Visible="true" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td width="2%"></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="Label3" runat="server" Text="SOB UPDATE - DRAG" Width="250px" class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblSOB" runat="server" Text="SOB" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="textsob" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="clOutDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textsob" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                        <td>
                            <asp:Button ID="BtnSobUpdate" runat="server" Text="Update" Visible="true" CssClass="FormButton" OnClientClick="validateData(this)" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td width="2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td width="2%"></td>
            <td>
                <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
            </td>
        </tr>
    </table>

    <div style="height: 400px; width: 100%; overflow: auto;">
        <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False" runat="server">
            <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" onClick="AllChecked(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" onClick="EnableDisableCtrol(this);" />
                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                <asp:BoundField DataField="SHIPPER" ItemStyle-Width="100px" HeaderText="Shipper"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

                <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblCONT_NO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ItemStyle-Width="100px" DataField="cont_size" HeaderText="SIZE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="200px" DataField="LINE" HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="150px" DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_NO" HeaderText="Invoice No"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="120px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="CUTOF_DATE" HeaderText="PortCutOf Date"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="PORT_ARRIVAL" HeaderText="Port Arrival"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Days" ItemStyle-Width="50px" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblDays" runat="server" Text='<%# Eval("AGE")%>' BackColor="#F7DC6F"
                            Width="50px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Final ETD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredEtd" runat="server" Text='<%# Eval("FINAL_ETD")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtRequiredEtd" runat="server" AutoComplete="off" CssClass="textbox" Width="100px"
                            Text='<%# Eval("FINAL_ETD")%>' Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtRequiredEtd" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Final Vessel" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredVessel" runat="server" Text='<%# Eval("REQUIRED_VESSEL")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtRequiredVessel" runat="server" AutoComplete="off" CssClass="textbox" Width="100px"
                            Text='<%# Eval("REQUIRED_VESSEL")%>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETA 1" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetEta" runat="server" Text='<%# Eval("TRANSHIPMENT_ETA")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetETA" runat="server" AutoComplete="off" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETA")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetEta" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetETA" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px" HeaderText="Transhipment Port 1" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT")%>'
                            Width="120px"></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort" BackColor="LightGreen" runat="server"
                            CssClass="RptFormListBoxSmall" Width="120px" OnDataBinding="preparePod"
                            value='<%# Eval("TRANS_PORT_ID") %>' Style="display: none;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdntranshipmentPort" runat="server" Value='<%# Eval("TRANS_PORT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETD 1" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetDate" runat="server" Text='<%# Eval("TRANSHIPMENT_ETD")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetDate" runat="server" AutoComplete="off" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETD")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetDate" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment Vessel 1" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblTranshipmentVeseel" runat="server" Text='<%# Eval("TRANSHIPMENT_VESSEL")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmentVeseel" runat="server" CssClass="textbox" Width="100px" AutoComplete="off"
                            BackColor="LightGreen" Text='<%# Eval("TRANSHIPMENT_VESSEL")%>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETA 2" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetEta2" runat="server" Text='<%# Eval("TRANSHIPMENT_ETA2")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetETA2" runat="server" AutoComplete="off" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETA2")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetEta2" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetETA2" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px" HeaderText="Transhipment Port 2" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort2" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT2")%>'
                            Width="120px"></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort2" BackColor="LightGreen" runat="server"
                            CssClass="RptFormListBoxSmall" Width="120px" OnDataBinding="preparePod"
                            value='<%# Eval("TRANS_PORT_ID2") %>' Style="display: none;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnLsttranshipmentPort2" runat="server" Value='<%# Eval("TRANS_PORT_ID2") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETD 2" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetDate2" runat="server" Text='<%# Eval("TRANSHIPMENT_ETD2")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetDate2" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETD2")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetDate2" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetDate2" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment Vessel 2" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblTranshipmentVeseel2" runat="server" Text='<%# Eval("TRANSHIPMENT_VESSEL2")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmentVeseel2" runat="server" CssClass="textbox" Width="100px"
                            BackColor="LightGreen" Text='<%# Eval("TRANSHIPMENT_VESSEL2")%>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--   <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETA 3" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetEta3" runat="server" Text='<%# Eval("TRANSHIPMENT_ETA3")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetETA3" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETA3")%>' Visible="false" BackColor="LightGreen">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetEta3" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetETA3" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px" HeaderText="Transhipment Port 3" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort3" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT3")%>'
                            Width="120px"></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort3" BackColor="LightGreen" runat="server"
                            CssClass="RptFormListBoxSmall" Width="120px" Visible="false" OnDataBinding="preparePod"
                            value='<%# Eval("TRANS_PORT_ID3") %>'>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment ETD 3" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetDate3" runat="server" Text='<%# Eval("TRANSHIPMENT_ETD3")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetDate3" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETD3")%>' Visible="false" BackColor="LightGreen">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetDate3" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetDate3" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Transhipment Vessel 3" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblTranshipmentVeseel3" runat="server" Text='<%# Eval("TRANSHIPMENT_VESSEL3")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmentVeseel3" runat="server" CssClass="textbox" Width="100px"
                            Visible="false" BackColor="LightGreen" Text='<%# Eval("TRANSHIPMENT_VESSEL3")%>'>
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Final ETA" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredETA" runat="server" Text='<%# Eval("CURRENT_ETA")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtRequiredETA" runat="server" CssClass="textbox" Text='<%# Eval("CURRENT_ETA")%>'
                            Width="100px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate2" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtRequiredETA" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transit Time" ItemStyle-Width="60px" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblNO_DAYS" runat="server" Text='<%# Eval("TRANSIT_TIME")%>' Width="60px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px" HeaderText="SOB" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblRSailed" runat="server" Text='<%# Eval("SAILED")%>' Width="120px"></asp:Label>
                        <asp:TextBox ID="lstSob" runat="server" CssClass="textbox" Text='<%# Eval("SAILED")%>' AutoComplete="off"
                            Width="120px" BackColor="LightGreen" Style="display: none;">
                        Width="100px" Visible="false" onKeyDown="TabButton();" onpaste="return false;"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cllstSob" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="lstSob" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px" HeaderText="Followup Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblFollowup" runat="server" Text='<%# Eval("FOLLOWUP_DATE")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtFollowup" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("FOLLOWUP_DATE")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtFollowup" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtFollowup" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="COD TYPE" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblCODType" runat="server" Text='<%# Eval("COD_TYPE")%>'></asp:Label>
                        <asp:DropDownList ID="lstCODType" runat="server" CssClass="ddlMedium" Style="display: none;">
                            <asp:ListItem Value="" Text=""></asp:ListItem>
                             <asp:ListItem Value="1" Text="COD AT POL"></asp:ListItem>
                            <asp:ListItem Value="2" Text="COD AT TRANSHIPMENT PORT"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="120px" HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("SOB_REMARK")%>' Width="120px"></asp:Label>
                        <%--<asp:DropDownList ID="LstRemark" runat="server" CssClass="ddlMedium" Value='<%# Eval("SOB_REMARK_ID")%>'
                            Width="120px" Visible="false">
                            <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                            <asp:ListItem Value="1" Text="MOVES NOT UPDATED"></asp:ListItem>
                            <asp:ListItem Value="2" Text="HIGH"></asp:ListItem>
                            <asp:ListItem Value="3" Text="STOP MAIL"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Confirm"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="TxtSobRemarks" runat="server" CssClass="textbox" Text='<%# Eval("SOB_REMARK")%>'
                            Width="120px" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle></AlternatingRowStyle>
        </asp:GridView>
    </div>
</asp:Content>
