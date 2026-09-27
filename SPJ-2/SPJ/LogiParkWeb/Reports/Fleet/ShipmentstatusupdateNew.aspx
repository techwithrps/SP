<%@ Page Title="eLOGiFleet :: Shipment Status Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="ShipmentstatusupdateNew.aspx.vb" Inherits="Reports_Fleet_ShipmentstatusupdateNew"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
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

                const TxtRequiredETD = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETD"));
                TxtRequiredETD.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETD")).style.display = 'none';

                //SECOND INPUT  TxtRequiredVessel
                const TxtRequiredVessel = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredVessel"));
                TxtRequiredVessel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredVessel")).style.display = 'none';

                // INPUT  TxtTranshipmetETA
                const TxtTranshipmetETA = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA"));
                TxtTranshipmetETA.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta")).style.display = 'none';


                // INPUT  LsttranshipmentPort
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


                // INPUT  TxtTranshipmetDate
                const TxtTranshipmetDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate"));
                TxtTranshipmetDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate")).style.display = 'none';

                // INPUT  TxtTranshipmentVeseel
                const TxtTranshipmentVeseel = document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel"));
                TxtTranshipmentVeseel.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel")).style.display = 'none';

                // INPUT  TxtCurrentEta
                const TxtCurrentEta = document.getElementById(ctrlId.replace("CheckBox1", "TxtCurrentEta"));
                TxtCurrentEta.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCurrentEta")).style.display = 'none';

                // INPUT  TxtTransitTime
                const TxtTransitTime = document.getElementById(ctrlId.replace("CheckBox1", "TxtTransitTime"));
                TxtTransitTime.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTransitTime")).style.display = 'none';

                // INPUT  TxtDischargeDate
                const TxtDischargeDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtDischargeDate"));
                TxtDischargeDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblDischargeDate")).style.display = 'none';


                // INPUT  TxtGateOutDate
                const TxtGateOutDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtGateOutDate"));
                TxtGateOutDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblGateOutDate")).style.display = 'none';

                // INPUT  TxtEmptyGateInDate
                const TxtEmptyGateInDate = document.getElementById(ctrlId.replace("CheckBox1", "TxtEmptyGateInDate"));
                TxtEmptyGateInDate.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblEmptyGateInDate")).style.display = 'none';

                // INPUT  LstRemark
                const LstRemark = document.getElementById(ctrlId.replace("CheckBox1", "LstRemark"));
                LstRemark.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'none';

            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETD")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredVessel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetETA")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LsttranshipmentPort")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmetDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTranshipmentVeseel")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtCurrentEta")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTransitTime")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtDischargeDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtGateOutDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtEmptyGateInDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LstRemark")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETD")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredVessel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetEta")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lbltranshipmentPort")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "LblTranshipmetDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTranshipmentVeseel")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCurrentEta")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblTransitTime")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblDischargeDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblGateOutDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblEmptyGateInDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'inline';

            }

            document.getElementById("ctl00_ContentPlaceHolder1_ImgBtnUpdate").style.display = 'inline';
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
                    var TxtDischargeDate = row.querySelector("[id*='TxtDischargeDate']");
                    var TxtGateOutDate = row.querySelector("[id*='TxtGateOutDate']");
                    var TxtEmptyGateInDate = row.querySelector("[id*='TxtEmptyGateInDate']");

                    if (TxtDischargeDate.value.trim() !== '') {
                        let TxtHandover1 = TxtDischargeDate.value.trim();
                        let lblICDInDate1 = TxtGateOutDate.value.trim();

                        let HandoverdateParts = TxtHandover1.split(' ');
                        let [day, month, year] = HandoverdateParts[0].split('/');
                        // let [hours, minutes] = HandoverdateParts[1].split(':');
                        let parsedDischargeDate = new Date(year, month - 1, day);

                        let ICDdateParts = lblICDInDate1.split(' ');
                        let [ICDday, ICDmonth, ICDyear] = ICDdateParts[0].split('/');
                        let parsedGateOutDate = new Date(ICDyear, ICDmonth - 1, ICDday);

                        if (parsedGateOutDate < parsedDischargeDate) {
                            errorMessage.innerText = 'Discharge Date should  be less than  or equal to Gate Out Date';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                   
                    if (TxtGateOutDate.value.trim() !== '') {
                        let TxtHandover1 = TxtGateOutDate.value.trim();
                        let lblICDInDate1 = TxtEmptyGateInDate.value.trim();

                        let HandoverdateParts = TxtHandover1.split(' ');
                        let [day, month, year] = HandoverdateParts[0].split('/');
                        // let [hours, minutes] = HandoverdateParts[1].split(':');
                        let parsedGateOutDate = new Date(year, month - 1, day);

                        let ICDdateParts = lblICDInDate1.split(' ');
                        let [ICDday, ICDmonth, ICDyear] = ICDdateParts[0].split('/');
                        let parsedEmptyGateInDate = new Date(ICDyear, ICDmonth - 1, ICDday);

                        if (parsedEmptyGateInDate < parsedGateOutDate) {
                            errorMessage.innerText = 'Gate Out Date should be less than or equal to  Empty Gate In Date';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    

                    if (TxtDischargeDate.value.trim() !== '') {
                        let GivenDate = TxtDischargeDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        //let [hours, minutes] = PartyInvoicedateParts[1].split(':');
                        let enteredDate = new Date(year, month - 1, day);
                        let currentDate = new Date();

                        if (enteredDate >= currentDate) {
                            errorMessage.innerText = 'Please ensure that the "Discharge Date" is less than to the Current Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    if (TxtGateOutDate.value.trim() !== '') {
                        let GivenDate = TxtGateOutDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);
                        let currentDate = new Date();

                        if (enteredDate >= currentDate) {
                            errorMessage.innerText = 'Please ensure that the "Gate Out Date" is less than to the Current Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }

                    }
                    if (TxtEmptyGateInDate.value.trim() !== '') {
                        let GivenDate = TxtEmptyGateInDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);
                        let currentDate = new Date();

                        if (enteredDate >= currentDate) {
                            errorMessage.innerText = 'Please ensure that the "Empty Gate In Date" is less than to the Current Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }


                }
            }
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Shipment Status Gate out and Empty Return" CssClass="FormLabelTitle"
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
                            <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblPort" runat="server" Text="Port" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstPort" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td rowspan="3">
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LBlLine" runat="server" Text="Line" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstLine" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblTPort" runat="server" Text="Loading Port" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="Lstpol" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
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
                            <asp:Label ID="Label1" runat="server" Text="SHIPMENT STATUS - FILTER" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="LblStatus" runat="server" Text="Shipment Status" CssClass="label">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lststatus" runat="server" CssClass="ddlMedium" Width="120px">
                                <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                <asp:ListItem Value="1" Text="DISCHARGED"></asp:ListItem>
                                <asp:ListItem Value="2" Text="GATE OUT"></asp:ListItem>
                                <asp:ListItem Value="3" Text="DELIVERED"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="Button2" runat="server" Text="DISPLAY" CssClass="FormButton" />
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
                <table>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="Label2" runat="server" Text="TRANSIT TIME - FILTER" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblTransitTime" runat="server" Text="Transit Time" CssClass="label">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstTransitTime" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td></td>
            <td>
                <table>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="Label4" runat="server" Text="REMARK - FILTER" Width="250px" class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDRemark" runat="server" Text="Remark" CssClass="label">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstdremark" runat="server" CssClass="ddlMedium" Width="130px">
                                <asp:ListItem Value="" Text="SELECT"></asp:ListItem>
                                <asp:ListItem Value="1" Text="MOVES NOT UPDATED"></asp:ListItem>
                                <asp:ListItem Value="2" Text="HIGH"></asp:ListItem>
                                <asp:ListItem Value="3" Text="STOP MAIL"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Confirm"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Button ID="btnRDisplay" runat="server" Text="DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="8" align="center">
                            <asp:Label ID="lblUpdate" runat="server" Text="Updation Button" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center" height="12px"></td>
                    </tr>
                    <%--  <tr>
                                    <td align="left">
                                        <asp:Label ID="lbluStatus" runat="server" Text="Shipment Status" CssClass="label">
                                        </asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstustaus" runat="server" CssClass="ddlMedium" Width="120px">
                                            <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="DISCHARGED"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="GATE OUT"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="DELIVERED"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="ImgBtnUpdate" runat="server" Text="Update" CssClass="FormButton"
                                Visible="True" OnClientClick="validateData(this)" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td></td>
            <td>
                <table border="0">
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Label ID="Label7" runat="server" Text="REMARKS  - DRAG" Width="250px"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" height="12px"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label8" runat="server" Text="Remarks" CssClass="label">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstRemarks" runat="server" CssClass="ddlMedium" Width="120px">
                                <asp:ListItem Value="" Text="SELECT"></asp:ListItem>
                                <asp:ListItem Value="1" Text="MOVES NOT UPDATED"></asp:ListItem>
                                <asp:ListItem Value="2" Text="HIGH"></asp:ListItem>
                                <asp:ListItem Value="3" Text="STOP MAIL"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Confirm"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnRemarkUpdate" runat="server" Text="Update" CssClass="FormButton"
                                Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td></td>
            <td>
                <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="25">
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="25">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label5" runat="server" Text="FILTER - ETA WISE" Width="250" class="FormLabelTitle"></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td align="left">
                            <asp:Label ID="Label6" runat="server" Text="Line" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstetaline" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Btnetadisplay" runat="server" Text="ETA WISE DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="25">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label9" runat="server" Text="FILTER VESSEL WISE" Width="250" class="FormLabelTitle"></asp:Label>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblRequiredVesself" runat="server" Text="Required Vessel" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstFRequiredVessel" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label10" runat="server" Text="Transhipment Vessel" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstFtrans" runat="server" CssClass="ddlMedium" Width="120px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" Text="Vessel WISE DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="25">
                <hr />
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
                <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblCONT_NO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="POL"
                    HeaderText="Load Port" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="PORT"
                    HeaderText="Port" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="SHIPPER" ItemStyle-Width="100px" HeaderText="Shipper"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="LINE"
                    HeaderText="Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="BOOKING_NO"
                    HeaderText="Booking No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:BoundField DataField="BL_NO"
                    HeaderText="BL NO." HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Final ETD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                        <asp:Label ID="lblRequiredETD" runat="server" Text='<%# Eval("FINAL_ETD")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtRequiredETD" runat="server" CssClass="textbox" Text='<%# Eval("FINAL_ETD")%>'
                            Width="100px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtRequiredETD" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtRequiredETD" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Final Vessel" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblRequiredVessel" runat="server" Text='<%# Eval("REQUIRED_VESSEL")%>'
                            Width="140px"></asp:Label>
                        <asp:TextBox ID="TxtRequiredVessel" runat="server" CssClass="textbox" Text='<%# Eval("REQUIRED_VESSEL")%>'
                            Width="140px" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transhipmet ETA" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="LightGreen" />
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetEta" runat="server" Text='<%# Eval("TRANSHIPMENT_ETA")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetETA" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETA")%>' BackColor="LightGreen" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetEta" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetETA" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transhipment Port" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT")%>'
                            Width="120px"></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort" runat="server" CssClass="RptFormListBoxSmall"
                            Width="120px" OnDataBinding="preparePod" value='<%# Eval("TRANS_PORT_ID") %>' Style="display: none;">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdntranshipmentPort" runat="server" Value='<%# Eval("TRANS_PORT_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transhipmet ETD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="LblTranshipmetDate" runat="server" Text='<%# Eval("TRANSHIPMENT_ETD")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmetDate" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_ETD")%>' Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTranshipmetDate" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtTranshipmetDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transhipmet Vessel" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblTranshipmentVeseel" runat="server" Text='<%# Eval("TRANSHIPMENT_VESSEL")%>'
                            Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTranshipmentVeseel" runat="server" CssClass="textbox" Width="100px"
                            Text='<%# Eval("TRANSHIPMENT_VESSEL")%>' Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SAILED" HeaderText="Sailing Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <%-- <asp:TemplateField HeaderText="Sail Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblRSailed" runat="server" Text='<%# Eval("SAILED")%>' Width="80px"></asp:Label>
                        <asp:TextBox ID="lstSob" runat="server" CssClass="textbox" Text='<%# Eval("SAILED")%>'
                            Width="80px" Visible="false">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="lstSob" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="SOB" HeaderText="SOB" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="ETA" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrentEta" runat="server" Text='<%# Eval("CURRENT_ETA")%>' Width="80px"></asp:Label>
                        <asp:TextBox ID="TxtCurrentEta" runat="server" CssClass="textbox" Text='<%# Eval("CURRENT_ETA")%>'
                            Width="80px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtCurrentEta" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transit Time" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" Font-Bold="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblTransitTime" runat="server" Text='<%# Eval("TRANSIT_TIME")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtTransitTime" runat="server" CssClass="textbox" Text='<%# Eval("TRANSIT_TIME")%>'
                            Width="100px" BackColor="#F7DC6F" Style="display: none;">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Discharge Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblDischargeDate" runat="server" Text='<%# Eval("DISCHARGE_DATE")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtDischargeDate" AutoComplete="off" runat="server" CssClass="textbox" Text='<%# Eval("DISCHARGE_DATE")%>'
                            Width="140px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate4" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtDischargeDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gate Out Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblGateOutDate" runat="server" Text='<%# Eval("GATE_OUT_DATE")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtGateOutDate" AutoComplete="off" runat="server" CssClass="textbox" Text='<%# Eval("GATE_OUT_DATE")%>'
                            Width="140px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate6" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtGateOutDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Empty Gate In Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblEmptyGateInDate" runat="server" Text='<%# Eval("EMPTY_GATE_IN_DATE")%>' Width="100px"></asp:Label>
                        <asp:TextBox ID="TxtEmptyGateInDate" AutoComplete="off" runat="server" CssClass="textbox" Text='<%# Eval("EMPTY_GATE_IN_DATE")%>'
                            Width="140px" Style="display: none;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clRailOutdate7" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtEmptyGateInDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("SOB_REMARK")%>' Width="100px"></asp:Label>
                        <asp:DropDownList ID="LstRemark" runat="server" CssClass="ddlMedium" Value='<%# Eval("SOB_REMARK_ID")%>'
                            Width="100px" Style="display: none;">
                            <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                            <asp:ListItem Value="1" Text="MOVES NOT UPDATED"></asp:ListItem>
                            <asp:ListItem Value="2" Text="HIGH"></asp:ListItem>
                            <asp:ListItem Value="3" Text="STOP MAIL"></asp:ListItem>
                            <asp:ListItem Value="4" Text="Confirm"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle></AlternatingRowStyle>
        </asp:GridView>
    </div>
</asp:Content>
