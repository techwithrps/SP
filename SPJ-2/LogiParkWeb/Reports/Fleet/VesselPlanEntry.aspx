<%@ Page Title="eLOGiFleet :: Vessel Planing Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="VesselPlanEntry.aspx.vb" Inherits="Reports_Fleet_VesselPlanEntry"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function TabButton() {
            if (event.keyCode == 9) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }
        }


    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtCutOfDate]').dynDateTime({
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
    <%--  <script type="text/javascript">
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

                let ddlPOLObj = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL"));

                let hdnPOLSet = document.getElementById(ctrlId.replace("CheckBox1", "hdnPOL")).value;
                for (let i = 0; i < ddlPOLObj.options.length; i++) {
                    if (ddlPOLObj.options[i].value == parseInt(hdnPOLSet)) {
                        ddlPOLObj.options[i].selected = true;
                    }
                }
                const ddlPOL = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL"));
                ddlPOL.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPOL")).style.display = 'none';

                //SECOND INPUT  TxtPlanVessel
                const TxtPlanVessel = document.getElementById(ctrlId.replace("CheckBox1", "TxtPlanVessel"));
                TxtPlanVessel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPlanVessel")).style.display = 'none';

                // INPUT  TxtRequiredEtd
                const TxtRequiredEtd = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredEtd"));
                TxtRequiredEtd.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblETD")).style.display = 'none';

                // INPUT  TxtFinalVessel
                const TxtFinalVessel = document.getElementById(ctrlId.replace("CheckBox1", "TxtFinalVessel"));
                TxtFinalVessel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblFinalVessel")).style.display = 'none';

                // INPUT  TxtFinalEtd
                const TxtFinalEtd = document.getElementById(ctrlId.replace("CheckBox1", "TxtFinalEtd"));
                TxtFinalEtd.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblFinalETD")).style.display = 'none';

                // INPUT  TxtRequiredETA
                const TxtRequiredETA = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA"));
                TxtRequiredETA.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'none';
                //IMPUT LsttranshipmentPort
                let lbltranshipmentPortObj = document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort"));
                let lbltranshipmentPortObj1 = lbltranshipmentPortObj.textContent;
                const LsttranshipmentPort1 = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort"));

                for (var i = 0; i < LsttranshipmentPort1.options.length; i++) {
                    if (LsttranshipmentPort1.options[i].textContent == lbltranshipmentPortObj1) {
                        LsttranshipmentPort1.options[i].selected = true;
                    }
                }
                const LsttranshipmentPort = document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort"));
                LsttranshipmentPort.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort")).style.display = 'none';

                // INPUT  TxtVoyage
                const TxtVoyage = document.getElementById(ctrlId.replace("CheckBox1", "TxtVoyage"));
                TxtVoyage.style.display = 'block';

                // INPUT  TxtTRHandover
                const TxtTRHandover = document.getElementById(ctrlId.replace("CheckBox1", "TxtTRHandover"));
                TxtTRHandover.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTRDate")).style.display = 'none';

                // INPUT  TxtCutOfDate
                const TxtCutOfDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtCutOfDate"));
                TxtCutOfDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCutOfDate")).style.display = 'none';

                // INPUT  TxtportArrival
                const TxtportArrival = document.getElementById(ctrlId.replace("CheckBox1", "TxtportArrival"));
                TxtportArrival.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPortArrival")).style.display = 'none';

                // INPUT  TxtTransitTime
                const TxtTransitTime = document.getElementById(ctrlId.replace("CheckBox1", "TxtTransitTime"));
                TxtTransitTime.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTransitTime")).style.display = 'none';

                // INPUT  txtRemark
                const txtRemark = document.getElementById(ctrlId.replace("CheckBox1", "txtRemark"));
                txtRemark.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'none';

            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtPlanVessel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredEtd")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtFinalVessel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtFinalEtd")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtVoyage")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTRHandover")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtCutOfDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtportArrival")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTransitTime")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtRemark")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblPOL")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPlanVessel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblETD")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblFinalVessel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblFinalETD")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTRDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCutOfDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPortArrival")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTransitTime")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'inline';

            }

            document.getElementById("ctl00_ContentPlaceHolder1_Button3").style.display = 'inline';
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
                    var ddlPOL = row.querySelector("[id*='ddlPOL']");
                    var TxtTRHandover = row.querySelector("[id*='TxtTRHandover']");
                    var TxtportArrival = row.querySelector("[id*='TxtportArrival']");
                    var TxtFinalVessel = row.querySelector("[id*='TxtFinalVessel']");
                    var TxtFinalEtd = row.querySelector("[id*='TxtFinalEtd']");
                    var TxtRequiredEtd = row.querySelector("[id*='TxtRequiredEtd']");
                    var TxtVoyage = row.querySelector("[id*='TxtVoyage']");
                    var TxtRequiredETA = row.querySelector("[id*='TxtRequiredETA']");
                    var txtRemark = row.querySelector("[id*='txtRemark']");
                    var Sessionitem = '<%= Session("LoginUser") %>';


                    if (Sessionitem == "Akshay" || Sessionitem == "Nitin Saini") {
                        let GivenDate = TxtportArrival.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);

                        let today = new Date();
                        //var currentDt = new Date();
                        //currentDt.setDate(currentDt.getDate() - 3);

                        if (TxtportArrival.value.trim() !== "" && (enteredDate > today)) {
                            errorMessage.innerText = 'Please ensure that the Port Arrival Date is more than or equal to yesterday.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (Sessionitem !== "Akshay" && Sessionitem !== "Nitin Saini") {
                        let GivenDate = TxtportArrival.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);

                        let today = new Date();
                        var currentDt = new Date();
                        currentDt.setDate(currentDt.getDate() - 3);

                        if (TxtportArrival.value.trim() !== "" && (enteredDate > today) || (enteredDate < currentDt)) {
                            errorMessage.innerText = 'Please ensure that the Port Arrival Date is more than or equal to yesterday.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }



                    //data CONDITION       
                    if (Sessionitem !== "Akshay" && Sessionitem !== "Nitin Saini") {
                        if (TxtFinalEtd.value.trim() !== '') {
                            let GivenDate = TxtFinalEtd.value.trim();
                            let Partydate = GivenDate.split(' ');
                            let [day, month, year] = Partydate[0].split('/');
                            //let [hours, minutes] = PartyInvoicedateParts[1].split(':');
                            let enteredDate = new Date(year, month - 1, day);
                            let currentDate = new Date();
                            currentDate.setDate(currentDate.getDate() - 1);


                            if (enteredDate < currentDate) {
                                errorMessage.innerText = 'Please ensure that the "Final ETD" is greater than to the Current Date.';
                                errorMessage.style.color = "red";
                                event.preventDefault();
                                return;
                            }
                        }
                        if (TxtRequiredETA.value.trim() !== '') {
                            let GivenDate = TxtRequiredETA.value.trim();
                            let Partydate = GivenDate.split(' ');
                            let [day, month, year] = Partydate[0].split('/');
                            let enteredDate = new Date(year, month - 1, day);
                            let currentDate = new Date();
                            currentDate.setDate(currentDate.getDate() - 1);

                            if (enteredDate < currentDate) {
                                errorMessage.innerText = 'Please ensure that the "Final ETA" is greater than to the Current Date.';
                                errorMessage.style.color = "red";
                                event.preventDefault();
                                return;
                            }
                        }
                    }

                    //DATE VALIDATION 

                    let GivenDatePort = TxtportArrival.value.trim();
                    let PartydatePort = GivenDatePort.split(' ');
                    let [dayPort, monthPort, yearPort] = PartydatePort[0].split('/');
                    let enteredDatePort = new Date(yearPort, monthPort - 1, dayPort);

                    let GivenDateFinalEtd = TxtFinalEtd.value.trim();
                    let PartydateFinalEtd = GivenDateFinalEtd.split(' ');
                    let [dayFinalEtd, monthFinalEtd, yearFinalEtd] = PartydateFinalEtd[0].split('/');
                    let enteredDateFinalEtd = new Date(yearFinalEtd, monthFinalEtd - 1, dayFinalEtd);

                    let GivenDateEtd = TxtRequiredEtd.value.trim();
                    let PartydateEtd = GivenDateEtd.split(' ');
                    let [dayEtd, monthEtd, yearEtd] = PartydateEtd[0].split('/');
                    let enteredDateEtd = new Date(yearEtd, monthEtd - 1, dayEtd);

                    let GivenDateETA = TxtRequiredETA.value.trim();
                    let PartydateETA = GivenDateETA.split(' ');
                    let [dayETA, monthETA, yearETA] = PartydateETA[0].split('/');
                    let enteredDateETA = new Date(yearETA, monthETA - 1, dayETA);

                    //if (enteredDateEtd > enteredDateETA) {
                    //    errorMessage.innerText = 'ETD date should not be greater than ETA date.';
                    //    errorMessage.style.color = "red";
                    //    event.preventDefault();
                    //    return;
                    //}

                    if (enteredDateFinalEtd > enteredDateETA) {
                        errorMessage.innerText = 'ETD date should not be greater than ETA date.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }
                    if (enteredDatePort > enteredDateETA) {
                        errorMessage.innerText = 'Port Arrival date should not be greater than ETA date.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }

                    //INPUT VALIDATION         

                    if (TxtFinalVessel.value.trim() !== '' && TxtFinalEtd.value.trim() !== '' && TxtRequiredETA.value.trim() !== '' || txtRemark.value.trim() !== '') {
                        if (TxtFinalVessel.value === "") {
                            errorMessage.innerText = 'Please fill Vessel Detail.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtFinalEtd.value.trim() === "") {
                            errorMessage.innerText = 'Please fill Final ETD.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtRequiredETA.value.trim() === "") {
                            errorMessage.innerText = 'Please fill Final ETA.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (txtRemark.value.trim() === "") {
                            errorMessage.innerText = 'Please fill Remark.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtVoyage.value.trim() !== '' || TxtportArrival.value.trim() !== '') {
                        if (TxtVoyage.value === "") {
                            errorMessage.innerText = 'Please fill Voyage.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                        if (TxtportArrival.value.trim() === "") {
                            errorMessage.innerText = 'Port Arrival date is not updated.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    //if (ddlPOL.value === "0") {
                    //    errorMessage.innerText = 'Please Select Port.';
                    //    errorMessage.style.color = "red";
                    //    event.preventDefault();
                    //    return;
                    //} else if (TxtTRHandover.value.trim() === "") {
                    //    errorMessage.innerText = 'TR Handover date is not updated.';
                    //    errorMessage.style.color = "red";
                    //    event.preventDefault();
                    //    return;
                    //}  else if (TxtRequiredEtd.value === "") {
                    //    errorMessage.innerText = 'Please fill ETD.';
                    //    errorMessage.style.color = "red";
                    //    event.preventDefault();
                    //    return;
                    //} 
                    //else {
                    //    //
                    //}

                }
            }
        }

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Vessel Plan Details" CssClass="FormLabelTitle"
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
    <table width="1400px">
        <tr>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="7" align="center">
                            <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblLine" runat="server" Text="Line " CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPol" runat="server" Text="POL" CssClass="label"> </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label"> </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td style="width: 2%"></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="8" align="center">
                            <asp:Label ID="lblUpdate" runat="server" Text="WRITE & SELECT - DRAG" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">&nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LblRequiredEtd" runat="server" Text="Required ETD" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textRequiredETD" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="clOutDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textRequiredETD" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblvesselName" runat="server" Text="Vessel" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textVessel" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblETA" runat="server" Text="ETA" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextETA" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="clETA" Format="dd/MM/yyyy" runat="server" TargetControlID="TextETA" />
                        </td>
                        <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Style="display: none;" OnClientClick="validateData(this)" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td style="width: 2%"></td>
            <td align="left">
                <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
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
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="300px" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblCONT_NO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cont_size" HeaderText="SIZE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="LINE" HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="BOOKING_NO" HeaderText="Booking No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="INV_NO" HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="TRAIN_NO" HeaderText="Train No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="TRAIN_OUT_DATE" HeaderText="Railout Date" ItemStyle-Width="120px" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

                <asp:TemplateField HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                        <asp:Label ID="lblPOL" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                        <asp:DropDownList ID="ddlPOL" runat="server" CssClass="ddlMedium" OnDataBinding="preparePort"
                            VALUE='<%# Eval("POL_ID") %>' Width="150px" Style="display: none;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnPOL" runat="server" Value='<%# Eval("POL_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--    <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                                 <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlPOD" runat="server" CssClass="RptFormListBoxSmall" BackColor="LightGreen" Visible="false"
                                                        OnDataBinding="preparePod" value='<%# Eval("POD_ID") %>' Width="85px" ToolTip="pod">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Days" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblNO_DAYS" runat="server" Text='<%# Eval("AGEING")%>' BackColor="#F7DC6F"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Plan Vessel" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblPlanVessel" runat="server" Text='<%# Eval("CURRENT_VESSEL")%>'></asp:Label>
                        <asp:TextBox ID="TxtPlanVessel" runat="server" AutoComplete="OFF" CssClass="textbox"
                            BackColor="LightGreen" Text='<%# Eval("CURRENT_VESSEL") %>' Enabled="false" Width="150px" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ETD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblETD" runat="server" Text='<%# Eval("REQUIRED_ETD")%>'></asp:Label>
                        <asp:TextBox ID="TxtRequiredEtd" runat="server" CssClass="textbox" Enabled="false" Text='<%# Eval("REQUIRED_ETD")%>'
                            Width="100px" Style="display: none;"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clETD" Format="dd/MM/yyyy" runat="server" TargetControlID="TxtRequiredEtd" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Final Vessel" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblFinalVessel" runat="server" Text='<%# Eval("REQUIRED_VESSEL")%>'></asp:Label>
                        <asp:TextBox ID="TxtFinalVessel" AutoComplete="OFF" runat="server" CssClass="textbox"
                            BackColor="LightGreen" Text='<%# Eval("REQUIRED_VESSEL") %>' Width="150px" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Final ETD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblFinalETD" runat="server" Text='<%# Eval("FINAL_ETD")%>'></asp:Label>
                        <asp:TextBox ID="TxtFinalEtd" runat="server" CssClass="textbox" Text='<%# Eval("FINAL_ETD")%>'
                            Width="100px" onKeyDown="TabButton();" onpaste="return false;" Style="display: none;"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clFinalETD" Format="dd/MM/yyyy" runat="server" TargetControlID="TxtFinalEtd" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Final ETA" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredETA" runat="server" Text='<%# Eval("CURRENT_ETA")%>'></asp:Label>
                        <asp:TextBox ID="TxtRequiredETA" runat="server" CssClass="textbox"
                            Text='<%# Eval("CURRENT_ETA")%>' onKeyDown="TabButton();" onpaste="return false;" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtRequiredETA" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <%--ADDED BY ARJUN NEGI ON 04/02/2026--%>
                                            <asp:TemplateField HeaderText='Transhipment Port <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="AntiqueWhite" />
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT")%>'></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort" Width="85px" runat="server" CssClass="RptFormListBoxSmall"  Style="display: none;" OnDataBinding="preparePod1"  value='<%# Eval("TRANS_PORT_ID") %>' ToolTip="transhipment Port">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <%--END--%>
                <asp:TemplateField HeaderText="Voyage" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtVoyage" AutoComplete="OFF" runat="server" CssClass="textbox"
                            BackColor="LightGreen" Text='<%# Eval("VOYAGE") %>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TR Handover" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblTRDate" runat="server" Text='<%# Eval("TR_HANDOVER_DATE")%>'></asp:Label>
                        <asp:TextBox ID="TxtTRHandover" runat="server" CssClass="textbox" AutoComplete="OFF"
                            BackColor="LightGreen" Text='<%# Eval("TR_HANDOVER_DATE") %>'
                            Enabled="False" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--  <asp:TemplateField HeaderText="SI CutofDate" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtSiCut" runat="server" AutoComplete="OFF" CssClass="textbox" Visible="false"
                            BackColor="LightGreen" Text='<%# Eval("SI_CUTOF_DATE") %>' Enabled="False">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtSiCut" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtSiCut" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Port CutOf Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblCutOfDate" runat="server" Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtCutOfDate" runat="server" CssClass="textbox" AutoComplete="OFF"
                            BackColor="LightGreen" Text='<%# Eval("CUTOF_DATE") %>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Port Arrival" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="lblPortArrival" runat="server" Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtportArrival" runat="server" CssClass="textbox" AutoComplete="OFF"
                            BackColor="LightGreen" Text='<%# Eval("PORT_ARRIVAL") %>' Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtportArrival" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtportArrival" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transit Time" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblTransitTime" runat="server" Text='<%# Eval("TRANSIT_TIME")%>'></asp:Label>
                        <asp:TextBox ID="TxtTransitTime" runat="server" CssClass="textbox" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("VESSEL_OUT_REMARK")%>'></asp:Label>
                        <asp:TextBox ID="txtRemark" AutoComplete="OFF" runat="server" CssClass="textbox"
                            Text='<%# Eval("VESSEL_OUT_REMARK")%>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
