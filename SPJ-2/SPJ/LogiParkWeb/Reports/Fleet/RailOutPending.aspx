<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RailOutPending.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Reports_Fleet_RailOutPending"
    Title="eLOGiFleet :: Rail Out Pending" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function ()  
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

                //   INPUT  ddlPOL
                let lblPOLObj = document.getElementById(ctrlId.replace("CheckBox1", "lblPOL"));
                let lblPOLObj1 = lblPOLObj.textContent;
                const ddlPOL1 = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL"));

                for (var i = 0; i < ddlPOL1.options.length; i++) {
                    if (ddlPOL1.options[i].textContent == lblPOLObj1) {
                        ddlPOL1.options[i].selected = true;
                    }
                }


                const ddlPOL = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL"));
                ddlPOL.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPOL")).style.display = 'none';

                //SECOND INPUT  ddlPOD
                let lblPortObj = document.getElementById(ctrlId.replace("CheckBox1", "lblPort"));
                let lblPortObj1 = lblPortObj.textContent;
                const ddlPOD1 = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD"));

                for (var i = 0; i < ddlPOD1.options.length; i++) {
                    if (ddlPOD1.options[i].textContent == lblPortObj1) {
                        ddlPOD1.options[i].selected = true;
                    }
                }


                const ddlPOD = document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD"));
                ddlPOD.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPort")).style.display = 'none';

                //INPUT  txtTrainNo
                const txtTrainNo = document.getElementById(ctrlId.replace("CheckBox1", "txtTrainNo"));
                txtTrainNo.style.display = 'block';

                // INPUT txtOutDate 
                const txtOutDate = document.getElementById(ctrlId.replace("CheckBox1", "txtOutDate"));
                txtOutDate.style.display = 'block';

                //INPUT  txtETD
                const txtETD = document.getElementById(ctrlId.replace("CheckBox1", "txtETD"));
                txtETD.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblETD")).style.display = 'none';

                //INPUT  txtREQUIRED_VESSEL
                const txtREQUIRED_VESSEL = document.getElementById(ctrlId.replace("CheckBox1", "txtREQUIRED_VESSEL"));
                txtREQUIRED_VESSEL.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblREQUIRED_VESSEL")).style.display = 'none';

                //INPUT  TxtRequiredETA
                const TxtRequiredETA = document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA"));
                TxtRequiredETA.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'none';

                //INPUT  txtRemark
                const txtRemark = document.getElementById(ctrlId.replace("CheckBox1", "txtRemark"));
                txtRemark.style.display = 'block';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'none';

            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "ddlPOL")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "ddlPOD")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtTrainNo")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtOutDate")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtETD")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtREQUIRED_VESSEL")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtRequiredETA")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "txtRemark")).style.display = 'none';


                document.getElementById(ctrlId.replace("CheckBox1", "lblPOL")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblPort")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblETD")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblREQUIRED_VESSEL")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRequiredETA")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemark")).style.display = 'inline';


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


        function validationCheck() {
            let gridView = document.getElementById("<%= gvtripPendencyList.ClientID %>");
            let rows = gridView.getElementsByTagName("tr");
            let rtnBool = true;

            for (let i = 0; i < rows.length; i++) {
                let row = rows[i];
                let checkbox = row.querySelector("[type='checkbox']");
                let errorMessage = document.getElementById('ctl00_ContentPlaceHolder1_lblErrorMessage');
                let errorblank = errorMessage.innerText = '';

                if (checkbox !== null && checkbox.checked) {
                    let txtTrainNo = row.querySelector("[id$='txtTrainNo']");
                    let ddlPOL = row.querySelector("[id$='ddlPOL']");
                    let lblContNo = row.querySelector("[id$='lblCONT_NO']");

                    for (let j = 0; j < rows.length; j++) {
                        let row1 = rows[j];
                        let checkbox1 = row1.querySelector("[type='checkbox']");

                        if (checkbox1 !== null && checkbox1.checked) {
                            let txtTrainNo1 = row1.querySelector("[id$='txtTrainNo']");
                            let ddlPOL1 = row1.querySelector("[id$='ddlPOL']");
                            let lblContNo1 = row1.querySelector("[id$='lblCONT_NO']");

                            if (lblContNo.textContent !== lblContNo1.textContent) {
                                if (ddlPOL.value === ddlPOL1.value && txtTrainNo.value !== txtTrainNo1.value) {
                                    errorMessage.innerText = 'Train no can not be different for same pol.';
                                    errorMessage.style.color = "red";
                                    rtnBool = false;
                                    event.preventDefault();
                                    return rtnBool;
                                }
                                if (ddlPOL.value !== ddlPOL1.value && txtTrainNo.value === txtTrainNo1.value) {
                                    errorMessage.innerText = 'Train no can not be same for different pol.';
                                    errorMessage.style.color = "red";
                                    rtnBool = false;
                                    event.preventDefault();
                                    return rtnBool;
                                }
                            }

                        }
                    }

                }
            }
            return rtnBool;
        }





        function validateData() {
            if (!validationCheck()) {
                return;
            }

            let gridView = document.getElementById("<%= gvtripPendencyList.ClientID %>");
            let rows = gridView.getElementsByTagName("tr");

            for (let i = 0; i < rows.length; i++) {
                let row = rows[i];
                let checkbox = row.querySelector("[type='checkbox']");
                let errorMessage = document.getElementById('ctl00_ContentPlaceHolder1_lblErrorMessage');
                let errorblank = errorMessage.innerText = '';

                if (checkbox !== null && checkbox.checked) {
                    var txtETD = row.querySelector("[id*='txtETD']");
                    var TxtRequiredETA = row.querySelector("[id*='TxtRequiredETA']");
                    var txtOutDate = row.querySelector("[id*='txtOutDate']");
                    var txtLINE_HANDOVER_DATE = row.querySelector("[id*='txtLINE_HANDOVER_DATE']");
                    var Sessionitem = '<%= Session("LoginUser") %>';

                    let EtdGivenDate = txtETD.value.trim();
                    let EtdPartydate = EtdGivenDate.split(' ');
                    let [Etdday, Etdmonth, Etdyear] = EtdPartydate[0].split('/');
                    let EtdenteredDate = new Date(Etdyear, Etdmonth - 1, Etdday);

                    let ETAGivenDate = TxtRequiredETA.value.trim();
                    let ETAPartydate = ETAGivenDate.split(' ');
                    let [ETAday, ETAmonth, ETAyear] = ETAPartydate[0].split('/');
                    let ETAenteredDate = new Date(ETAyear, ETAmonth - 1, ETAday);

                    if (EtdenteredDate > ETAenteredDate) {
                        errorMessage.innerText = 'ETD date should not be greater than ETA date.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }
                    if (txtOutDate.value.trim() !== '') {
                        let GivenDate = txtOutDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);
                        let currentDate = new Date();

                        if (enteredDate > currentDate) {
                            errorMessage.innerText = '"Out Date" can not be more than current date';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    if (Sessionitem !== "Akshay" && Sessionitem !== "Nitin Saini") {
                        let GivenDate = txtOutDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let enteredDate = new Date(year, month - 1, day);

                        let today = new Date();
                        var currentDt = new Date();
                        currentDt.setDate(currentDt.getDate() - 3);

                        if (txtOutDate.value.trim() !== "" && (enteredDate > today) || (enteredDate < currentDt)) {
                            errorMessage.innerText = 'Please ensure that the Railout Date is more than or equal to yesterday.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    if (txtLINE_HANDOVER_DATE.value.trim() !== "") {
                        let GivenDate = txtOutDate.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let txtOutDate = new Date(year, month - 1, day);

                        let LineGivenDate = txtLINE_HANDOVER_DATE.value.trim();
                        let LinePartydate = LineGivenDate.split(' ');
                        let [Lineday, Linemonth, Lineyear] = LinePartydate[0].split('/');
                        let txtLINE_HANDOVER_DATE = new Date(Lineyear, Linemonth - 1, Lineday);

                        if (txtOutDate < txtLINE_HANDOVER_DATE) {
                            errorMessage.innerText = 'Rail Out date should not be less than handover date.';
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Rail Out Status" CssClass="FormLabelTitle"
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
    <table width="100%">
        <tr>
            <td>
                <table>
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
                                        <asp:Label ID="Label1" runat="server" Text="CFS " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstPOL" runat="server" CssClass="ddlMedium" Width="190px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnDisplay" runat="server" Text="DISPLAY" CssClass="FormButton" />
                                        <%--<asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label">
                                        </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblLine" runat="server" Text="Line " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstLine" runat="server" CssClass="ddlMedium" Width="190px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 4%"></td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblUpdate" runat="server" Text="WRITE & SELECT - DRAG" Width="250px"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblTrainNo" runat="server" Text="Train No" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="textTrainNO" runat="server" CssClass="textbox" Width="145px"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblOutDate" runat="server" Text="Train Out Date" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="textOutDate" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="clOutDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textOutDate" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="ImgBtnUpdate" runat="server" Text="Update" CssClass="FormButton"
                                            Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCpol" runat="server" Text="POL" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstcpol" runat="server" CssClass="ddlMedium" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 4%"></td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="Label2" runat="server" Text="SELECT & WRITE - UPDATE" Width="250px"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblUpdate1" Width="150" runat="server" Text="UPDATE ONE BY ONE" CssClass="label"
                                            Visible="TRUE" />
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="BtnupDate" runat="server" Text="UPDATE" CssClass="FormButton" Visible="TRUE" OnClientClick="validateData(this)" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 4%"></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                            <%-- <asp:Button ID="Button2" Width="150px" runat="server" Text="Train Summary" CssClass="FormButton" />
                            --%>         </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 400px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="9">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="17">
                                <div id="tbCont" style="height: 400px; width: 100%; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" AutoGenerateColumns="False" runat="server">
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
                                            <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="300px" HeaderText="Shipper"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <%--<asp:BoundField DataField="CONSINGEE_NAME" ItemStyle-Width="300px" HeaderText="Consignee"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Handover Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLINE_HANDOVER_DATE" runat="server" Text='<%# Eval("LINE_HANDOVER_DATE")%>'></asp:Label>
                                                    <%-- <asp:TextBox ID="txtLINE_HANDOVER_DATE" runat="server" CssClass="textbox" Text='<%# Eval("LINE_HANDOVER_DATE")%>'
                                                        Visible="false"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clLineHandover" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="txtLINE_HANDOVER_DATE" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCONT_NO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="cont_size" HeaderText="SIZE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="BOOKING_NO" HeaderText="Booking No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="INV_NO" HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:TemplateField HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLINE" runat="server" Text='<%# Eval("LINE")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlCFS" runat="server" Width="100px" CssClass="ddlMedium" OnDataBinding="prepareTerminal"
                                                        Visible="false" VALUE='<%# Eval("TERMINAL_ID") %>'>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%-- <asp:TemplateField HeaderText="Booking No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBooking_NO" runat="server" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--<asp:TemplateField HeaderText="BL No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBL_NO" runat="server" Text='<%# Eval("BL_No")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPOL" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlPOL" runat="server" CssClass="ddlMedium" OnDataBinding="preparePort"
                                                        BackColor="LightGreen" Width="70px" value='<%# Eval("POL_id") %>' Style="display: none;">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlPOD" runat="server" CssClass="RptFormListBoxSmall" BackColor="LightGreen"
                                                        OnDataBinding="preparePod" value='<%# Eval("POD_ID") %>' Width="85px" ToolTip="pod" Style="display: none;">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Train No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTrainNo" AutoComplete="OFF" runat="server" CssClass="textbox" BackColor="LightGreen" Style="display: none;"> </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Out Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOutDate" AutoComplete="OFF" runat="server" CssClass="textbox" Width="130px"
                                                        BackColor="LightGreen" onKeyDown="TabButton();" onpaste="return false;" Style="display: none;">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="txtOutDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--   <asp:TemplateField HeaderText="Wagon No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtWagonNo" AutoComplete="OFF" runat="server" CssClass="textbox" Visible="false" BackColor="LightGreen"> </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--<asp:TemplateField HeaderText="Port Arrival"  HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRDate" runat="server" Width="100px"></asp:Label>
                                                    <asp:TextBox ID="TxtTRHandover" AutoComplete="OFF"  runat="server" CssClass="textbox"
                                                        Visible="false" onKeyDown="TabButton();" onpaste="return false;"
                                                        BackColor="LightGreen" Text='<%# Eval("PORT_ARRIVAL") %>'>
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Days" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="#F7DC6F" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNO_DAYS" runat="server" Text='<%# Eval("NO_DAYS")%>' BackColor="#F7DC6F"
                                                        Width="40px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ETD" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblETD" runat="server" Text='<%# Eval("ETD")%>'></asp:Label>
                                                    <asp:TextBox ID="txtETD" runat="server" CssClass="textbox" Text='<%# Eval("ETD")%>'
                                                        Width="100px" Style="display: none;"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clETD" Format="dd/MM/yyyy" runat="server" TargetControlID="txtETD" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Plan Vessel" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblREQUIRED_VESSEL" runat="server" Text='<%# Eval("CURRENT_VESSEL")%>'></asp:Label>
                                                    <asp:TextBox ID="txtREQUIRED_VESSEL" runat="server" CssClass="textbox" Text='<%# Eval("CURRENT_VESSEL")%>'
                                                        Style="display: none;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ETA" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequiredETA" runat="server" Text='<%# Eval("ETA")%>'></asp:Label>
                                                    <asp:TextBox ID="TxtRequiredETA" runat="server" AutoComplete="off" CssClass="textbox"
                                                        Text='<%# Eval("ETA")%>'
                                                        Style="display: none;">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TxtRequiredETA" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("RAIL_REMARK")%>'></asp:Label>
                                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Text='<%# Eval("RAIL_REMARK")%>'
                                                        Style="display: none;">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:CommandField  ShowEditButton="True" />--%>
                                        </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
