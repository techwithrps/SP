<%@ Page Title="eLOGiFleet :: Vessel Planing Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="HandoverUpdation.aspx.vb" Inherits="Reports_Fleet_HandoverUpdation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <%--<script type="text/javascript"> 
        function ChkVesselEntry(id) {
            var strsbno = "_CheckBox1"; 
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            var HdnMtyContId = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_hdnMTY_CONT_ID");
            var lblRequiredEtd = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblRequiredEtd");
            var lblRequiredVessel = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblRequiredVessel");
            var lblRequiredETA = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblRequiredETA");
            var lblPortArrival = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblPortArrival");
            var lblRSailed = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblRSailed");
            var lbltranshipmentPort = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lbltranshipmentPort");
            var lblTranshipmentVeseel = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblTranshipmentVeseel");
            var lblRemark = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_lblRemark");
            var CheckBox1 = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + tablename + "_Chkselect");
            lblRequiredEtd.innerText = "0";
        } 
    </script>--%>
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtportArrival]').dynDateTime({
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
            $('input[type=text][id*=TxtHandover]').dynDateTime({
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
        function EnableDisableCtrol(ctrl) {

            if (ctrl.checked == true) {
                var ctrlId = ctrl.id;

                const TextLineSeal = document.getElementById(ctrlId.replace("CheckBox1", "TextLineSeal"));
                TextLineSeal.style.display = 'block';
                TextLineSeal.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblLineSeal")).style.display = 'none';

                //SECOND INPUT  TextCustom
                const TextCustom = document.getElementById(ctrlId.replace("CheckBox1", "TextCustom"));
                TextCustom.style.display = 'block';
                TextCustom.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblCustom")).style.display = 'none';

                //third input  TxtHandover

                const TxtHandover = document.getElementById(ctrlId.replace("CheckBox1", "TxtHandover"));
                TxtHandover.style.display = 'block';
                TxtHandover.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblHandoverDate")).style.display = 'none';



                //fourth input  TextRemarks

                const TextRemarks = document.getElementById(ctrlId.replace("CheckBox1", "TextRemarks"));
                TextRemarks.style.display = 'block';
                TextRemarks.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'none';


                //Five input  TextRemarks

                let lblHoldremarkObj = document.getElementById(ctrlId.replace("CheckBox1", "lblHoldremark"));
                let lblHoldremarkObj1 = lblHoldremarkObj.textContent;
                const LstRemark1 = document.getElementById(ctrlId.replace("CheckBox1", "LstRemark"));

                for (var i = 0; i < LstRemark1.options.length; i++) {
                    if (LstRemark1.options[i].textContent == lblHoldremarkObj1) {
                        LstRemark1.options[i].selected = true;
                    }
                }

                document.getElementById(ctrlId.replace("CheckBox1", "lblHoldremark")).style.display = 'none';
                const LstRemark = document.getElementById(ctrlId.replace("CheckBox1", "LstRemark"));
                LstRemark.style.display = 'block';
            }
            else {
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TextLineSeal")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TextCustom")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TxtHandover")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TextRemarks")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "LstRemark")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblLineSeal")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblCustom")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblHandoverDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblRemarks")).style.display = 'lblHoldremark';

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
                    var TextLineSeal = row.querySelector("[id*='TextLineSeal']");
                    var TextCustom = row.querySelector("[id*='TextCustom']");
                    var TxtHandover = row.querySelector("[id*='TxtHandover']");
                    var LstRemark = row.querySelector("[id*='LstRemark']");
                    var TextRemarks = row.querySelector("[id*='TextRemarks']");
                    var BookingNo = row.querySelector("[id*='lblBookingNo']");
                    var lblICDInDate = row.querySelector("[id*='lblICDInDate']");
                    var lblSBNo = row.querySelector("[id*='lblSBNo']");
                    var lblSBDate = row.querySelector("[id*='lblSBDate']");
                    var lblBookingDate = row.querySelector("[id*='lblBookingDate']");

                    var Sessionitem = '<%= Session("loginterminal") %>';
                    //console.log('Sessionitem value =', Sessionitem);

                    // Set the visibility of controls        

                    if (Sessionitem != 7 && Sessionitem != 5 && Sessionitem != 29 && Sessionitem != 53) {
                        let lblSBNo1 = lblSBNo.textContent
                        let lblSBDate1 = lblSBDate.textContent

                        if (lblSBNo1 === '' && lblSBDate1 === '') {
                            errorMessage.innerText = 'This Container EDI Not Updated';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtHandover.value != "") {
                        if (BookingNo.textContent === "") {
                            errorMessage.innerText = 'Documentation Page not updated';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtHandover.value.trim() !== "") {
                        if (TextLineSeal.value === "") {
                            errorMessage.innerText = 'Please Enter Line Seal No.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }
                    if (TxtHandover.value.trim() !== "") {
                        if (TextCustom.value === "") {
                            errorMessage.innerText = 'Please fill Custom Seal No.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (lblICDInDate.textContent.trim() !== "") {
                        let TxtHandover1 = TxtHandover.value.trim();
                        let lblICDInDate1 = lblICDInDate.textContent.trim();

                        let HandoverdateParts = TxtHandover1.split(' ');
                        let [day, month, year] = HandoverdateParts[0].split('/');
                        let [hours, minutes] = HandoverdateParts[1].split(':');
                        let parsedDateHandover = new Date(year, month - 1, day, hours, minutes);

                        let ICDdateParts = lblICDInDate1.split(' ');
                        let [ICDday, ICDmonth, ICDyear] = ICDdateParts[0].split('/');
                        let parsedDateIcd = new Date(ICDyear, ICDmonth - 1, ICDday);

                        if (parsedDateHandover < parsedDateIcd) {
                            errorMessage.innerText = 'Handover Date should not be less than ICD In Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (LstRemark.value.trim() !== "0") {
                        if (TextRemarks.value === "") {
                            errorMessage.innerText = 'Please fill Pending Reason or Remarks';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }

                    if (TxtHandover.value.trim() !== "") {
                        let TxtHandover1 = TxtHandover.value.trim();
                        let HandoverdateParts = TxtHandover1.split(' ');
                        let [day, month, year] = HandoverdateParts[0].split('/');
                        let [hours, minutes] = HandoverdateParts[1].split(':');
                        let parsedDateHandover = new Date(year, month - 1, day, hours, minutes);

                        let currentDate = new Date();

                        var currentDt = new Date();
                        currentDt.setDate(currentDt.getDate() - 4);

                        if ((parsedDateHandover < currentDt) || (parsedDateHandover >= currentDate)) {
                            errorMessage.innerText = 'Please ensure that the "Handover Date" is less than or equal to the Current Date.';
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
            for (i = 0; i < grid.attributes.length; i++) {
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");
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
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Handover Updation" CssClass="FormLabelTitle"
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
                        <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Style="display: none" OnClientClick="validateData(this)" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                            <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 400px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                    runat="server">
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
                                        <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="300px" HeaderText="Shipper"
                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                        <asp:BoundField DataField="LINE" HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                        <asp:TemplateField HeaderText="ICD In Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblICDInDate" runat="server" Width="120" Text='<%# Eval("ICD_IN_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Width="120" Text='<%# Eval("INV_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SB No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSBNo" runat="server" Width="120" Text='<%# Eval("SB_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSBDate" runat="server" Width="120" Text='<%# Eval("SB_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Booking No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingNo" runat="server" Width="120" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="BOOKING_DATE" HeaderText="Booking Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="Booking Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingDate" runat="server" Width="120" Text='<%# Eval("BOOKING_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle />
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOD" runat="server" Width="120" Text='<%# Eval("PORT")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">

                                            <ItemTemplate>
                                                <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Line Seal No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblLineSeal" runat="server" Text='<%# Eval("SEAL_NO")%>'></asp:Label>
                                                <asp:TextBox ID="TextLineSeal" runat="server" Text='<%# Eval("SEAL_NO") %>' AutoComplete="off" CssClass="textbox"
                                                    disabled="false" ToolTip="Line Seal No" Style="display: none;">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Custom Seal No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustom" runat="server" Text='<%# Eval("AGENT_SEAL")%>'></asp:Label>
                                                <asp:TextBox ID="TextCustom" runat="server" Text='<%# Eval("AGENT_SEAL") %>' AutoComplete="off" CssClass="textbox"
                                                    ToolTip="Custom Seal No" Style="display: none;">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Handover Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHandoverDate" runat="server" Width="120" Text='<%# Eval("LINE_HANDOVER_DATE")%>'></asp:Label>
                                                <asp:TextBox ID="TxtHandover" runat="server" CssClass="textbox" AutoComplete="OFF"
                                                    BackColor="LightGreen" Text='<%# Eval("LINE_HANDOVER_DATE") %>' Style="display: none;">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("HANDOVER_REMARK")%>'></asp:Label>
                                                <asp:TextBox ID="TextRemarks" runat="server" Text='<%# Eval("HANDOVER_REMARK") %>' AutoComplete="off" CssClass="textbox"
                                                    ToolTip="Remarks" Style="display: none;">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Pending Reason" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHoldremark" runat="server" Text='<%# Eval("HOLD_REMARK")%>'></asp:Label>
                                                    <asp:DropDownList ID="LstRemark" runat="server" CssClass="RptFormListBoxSmall" BackColor="LightGreen"
                                                        OnDataBinding="preparePort" value='<%# Eval("HOLD_REMARK_ID") %>' Width="85px" ToolTip="pod" Style="display: none;">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                        <%--                <asp:TemplateField HeaderText="Pending Reason" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="#F7DC6F" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoldremark" runat="server" Text='<%# Eval("HOLD_REMARK")%>'></asp:Label>
                                                <asp:DropDownList ID="LstRemark" runat="server" text='<%# Eval("HOLD_REMARK_ID") %>'
                                                    CssClass="RptFormListBoxSmall" ToolTip="Hold Remark" Style="display: none;">
                                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="ORIGINAL HEALTH CERTIFICATE (VHC) NOT RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="LOT NOT COMPLETED"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="CONTAINER LATE ARRIVED AT ICD"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="INSUFFICIENT TEMPERATURE OF CONTAINER"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="CUSTOMS RELATED DOCUMENTS UNDER APPRAISAL"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="HOLD BY SHIPPER"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="HOLD BY CUSTOMS FOR EXAMINATION"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="A.C.I.D. NUMBER NOT RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="SPACE CONSTRAINT ON VESSEL"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="CUSTOMS SYSTEM NOT WORKING"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="SHIPPING BILL NOT RECEIVED FROM ICEGATE"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="WEIGHT DISCREPANCY IN ORIGINAL HEALTH CERTIFICATE (VHC)"></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="CONTAINER GATE CLOSED IMPROPERLY"></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="RFID DATA NOT SUBMITTED"></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="RFID DATA WRONGLY SUBMITTED"></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="APEDA VALIDITY EXPIRED"></asp:ListItem>
                                                    <asp:ListItem Value="17" Text="BITECS PENDING"></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="BOOKING NOT RECEIVED FROM SHIPPING LINE"></asp:ListItem>
                                                    <asp:ListItem Value="19" Text="ECTN NO PENDING"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="LINK PROECSS PENDING"></asp:ListItem>
                                                    <asp:ListItem Value="21" Text="SHIPPING LINE SYSTEM ISSUE"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
           --%>                         </Columns>
                                    <AlternatingRowStyle></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>


</asp:Content>
