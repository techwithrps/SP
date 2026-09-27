<%@ Page Title="eLOGiFleet :: SOB Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CODPanding.aspx.vb" Inherits="Reports_Fleet_CODPanding"
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
    <%--   <script language="javascript" type="text/javascript" src="../Script/validation.js"></script>
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

                //SECOND INPUT  ddlPOD
                let lblPortObj = document.getElementById(ctrlId.replace("CheckBox1", "lblPOD"));
                let lblPortObj1 = lblPortObj.textContent;
                const ddlPOD1 = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD"));

                for (var i = 0; i < ddlPOD1.options.length; i++) {
                    if (ddlPOD1.options[i].textContent == lblPortObj1) {
                        ddlPOD1.options[i].selected = true;
                    }
                }


                const ddlPOD = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD"));
                ddlPOD.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPOD")).style.display = 'none';






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








                //let lblCODTypeObj = document.getElementById(ctrlId.replace("CheckBox1", "lstCODType"));
                //let lblCODTypeObj1 = lblCODTypeObj.textContent;
                //const lstBlMethod1 = document.getElementById(ctrlId.replace("CheckBox1", "lstCODType"));

                //for (var i = 0; i < lstCODType1.options.length; i++) {
                //    if (lstCODType1.options[i].textContent == lblCODTypeObj1) {
                //        lstCODType1.options[i].selected = true;
                //    }
                //}

                ////SECOND INPUT  TxtRequiredVessel
                //const lstCODType = document.getElementById(ctrlId.replace("CheckBox1", "lstCODType"));
                //lstCODType.style.display = 'block';
                //document.getElementById(ctrlId.replace("CheckBox1", "lblCODType")).style.display = 'none';

            }
            else {
                var ctrlId = ctrl.id;
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lstCODType")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPOD")).style.display = 'inline';
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
                    var ddlPOD = row.querySelector("[id*='ddlPOD']");
                    var lstCODType = row.querySelector("[id*='lstCODType']");
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="COD Shipment" CssClass="FormLabelTitle"
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
                            <asp:Button ID="BtnSobUpdate" runat="server" Text="Update" Visible="true" CssClass="FormButton" />
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
                <asp:BoundField ItemStyle-Width="150px" DataField="PORT" HeaderText="POD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_NO" HeaderText="Invoice No"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="SAILED" HeaderText="Sailing Date"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblPOD" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                        <asp:DropDownList ID="ddlPOD" runat="server" CssClass="RptFormListBoxSmall" BackColor="LightGreen"
                            OnDataBinding="preparePod" value='<%# Eval("POD_ID") %>' Width="120px" ToolTip="pod" Style="display: none;">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COD TYPE" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblCODType" runat="server" Text='<%# Eval("COD_TYPE")%>'></asp:Label>
                        <asp:DropDownList ID="lstCODType" runat="server" CssClass="ddlMedium" Style="display: none;">
                            <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                            <asp:ListItem Value="1" Text="COD AT POL"></asp:ListItem>
                            <asp:ListItem Value="2" Text="COD AT TRANSHIPMENT PORT"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("COD_REMARK")%>'></asp:Label>
                        <asp:TextBox ID="TextRemarks" runat="server" Text='<%# Eval("COD_REMARK") %>' AutoComplete="off" CssClass="textbox"
                            ToolTip="Remarks" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <AlternatingRowStyle></AlternatingRowStyle>
        </asp:GridView>
    </div>
</asp:Content>
