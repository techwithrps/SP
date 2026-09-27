<%@ Page Title="eLOGiFleet :: Vessel Planing Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="TRUpdation.aspx.vb" Inherits="Reports_Fleet_TRUpdation"
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
                document.getElementById("ctl00_ContentPlaceHolder1_Button3").style.display = 'inline';
                var ctrlId = ctrl.id;

                const TxtTRHandover = document.getElementById(ctrlId.replace("CheckBox1", "TxtTRHandover"));
                TxtTRHandover.style.display = 'block';
                TxtTRHandover.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblTRDate")).style.display = 'none';

                //SECOND INPUT  TextVGMWt
                const TextVGMWt = document.getElementById(ctrlId.replace("CheckBox1", "TextVGMWt"));
                TextVGMWt.style.display = 'block';
                TextVGMWt.disabled = false;
                document.getElementById(ctrlId.replace("CheckBox1", "lblVGMWt")).style.display = 'none';


            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_Button3").style.display = 'none';
                var ctrlId = ctrl.id;
                document.getElementById(ctrlId.replace("CheckBox1", "TxtTRHandover")).style.display = 'none';
                document.getElementById(ctrlId.replace("CheckBox1", "TextVGMWt")).style.display = 'none';

                document.getElementById(ctrlId.replace("CheckBox1", "lblTRDate")).style.display = 'inline';
                document.getElementById(ctrlId.replace("CheckBox1", "lblVGMWt")).style.display = 'inline';

            }

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

            for (var i = 1; i < rows.length; i++) {
                var row = rows[i];
                var checkbox = row.querySelector("[type='checkbox']");
                var errorMessage = document.getElementById('ctl00_ContentPlaceHolder1_lblErrorMessage');
                var errorblank = errorMessage.innerText = '';

                if (checkbox !== null && checkbox.checked) {
                    var TxtTRHandover = row.querySelector("[id*='TxtTRHandover']");
                    var TextVGMWt = row.querySelector("[id*='TextVGMWt']");
                    var lblLineHandover = row.querySelector("[id*='lblLineHandover']");

                    // DATE VALIDATION

                    if (TxtTRHandover.value.trim() !== '') {
                        let GivenDate = TxtTRHandover.value.trim();
                        let Partydate = GivenDate.split(' ');
                        let [day, month, year] = Partydate[0].split('/');
                        let [hours, minutes] = Partydate[1].split(':');
                        let enteredDate = new Date(year, month - 1, day, hours, minutes);

                        let GivenDate1 = lblLineHandover.textContent.trim();
                        let Partydate1 = GivenDate1.split(' ');
                        let [day1, month1, year1] = Partydate1[0].split('/');
                        let LineHandover = new Date(year1, month1 - 1, day1);

                        if (enteredDate <= LineHandover) {
                            errorMessage.innerText = 'Please ensure that the "TR Handover" Date is greater  than or equal to the "Line Handover" Date.';
                            errorMessage.style.color = "red";
                            event.preventDefault();
                            return;
                        }
                    }


                    // Set the visibility of controls
                    if (TxtTRHandover.value === "") {
                        errorMessage.innerText = 'Please fill TR Date.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    } else if (TextVGMWt.value === "") {
                        errorMessage.innerText = 'Please fill VGM Wt.';
                        errorMessage.style.color = "red";
                        event.preventDefault();
                        return;
                    }
                    else {
                        //alert('okk aalll')
                    }


                }
            }
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="TR Updation" CssClass="FormLabelTitle"
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
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 100%; overflow: auto;">
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
                                            <asp:BoundField DataField="CONT_NO" HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="300px" HeaderText="Shipper"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="LINE" HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CUSTOMS_HANDOVER_DATE" HeaderText="Custom Handover" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <%--<asp:BoundField DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLineHandover" runat="server" Width="120" Text='<%# Eval("LINE_HANDOVER_DATE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TR Handover" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTRDate" runat="server" Text='<%# Eval("TR_HANDOVER_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TxtTRHandover" runat="server" CssClass="textbox" AutoComplete="OFF"
                                                        BackColor="LightGreen" Text='<%# Eval("TR_HANDOVER_DATE") %>' Style="display: none;">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="VGM Wt." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVGMWt" runat="server" Text='<%# Eval("VGM_WT")%>'></asp:Label>
                                                    <asp:TextBox ID="TextVGMWt" runat="server" onkeypress="kp_phonenumber();" Text='<%# Eval("VGM_WT") %>' CssClass="textbox"
                                                        ToolTip="VGM Wt." Style="display: none;">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
        <tr>
            <td align="center">&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
