<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Commercial/OverseasBilling.aspx.vb" Inherits="Commercial_OverseasBilling" Title="eLOGiFleet :: Import Invoice Generation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/json2/0.1/json2.js"></script>

    <%--    <script type="text/javascript" language="javascript">
        function checkKeyCode(evt)// for F5 disable
        {

            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if (event.keyCode == 116)//disable F5
            {
                evt.keyCode = 0;
                return false
            }
            if (event.keyCode == 123) {
                evt.keyCode = 0;
                return false
            }
            if (event.keyCode == 93) {
                evt.keyCode = 0;
                return false
            }
            if (event.altKey == true && event.keyCode == 115) //disable alt-F4
            {
                evt.keyCode = 0;
                return false
            }

            //alert(event.keyCode);
        }

        document.onkeydown = checkKeyCode;

    </script>--%>

    <%-- <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>--%>

    <script type="text/javascript">

        function SaveExRate(ctrl) {
            var ctrlId = ctrl.id;
            var chkSelect = document.getElementById(ctrlId.replace("Btnsave", "chkSelect"));
            var exRate = document.getElementById(ctrlId.replace("Btnsave", "textExRate")).value;
            var mtyContid = document.getElementById(ctrlId.replace("Btnsave", "hdnMtyContid")).value;
            if (chkSelect.checked) {
                var ExRate = {};
                ExRate.MtyContId = mtyContid;
                ExRate.ExRate = exRate;
                $.ajax({
                    type: "POST",
                    url: "Invoice.aspx/SaveExRate",
                    data: '{objExRate: ' + JSON.stringify(ExRate) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert("Ex Rate updated successfully.");
                    },
                    error: function (errorResponse) {
                        alert("Rate not updated, please contact admin.");
                    }
                });
            }
            return false;
        }

    </script>

    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function SelectAmount(id) {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var tAmount = 0;
                var tServiceTax = 0;
                var tECess = 0;
                var tHEess = 0;
                var tTax = 0;
                var tTotalAmount = 0;
                for (var j = 0; j < rowCount; j++) {
                    var rowCheck = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked;
                    var contNo = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textContNo").value;
                    var trAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textAmount").value.replace(/[^0-9\.]+/g, "");
                    var trServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTAmount").value.replace(/[^0-9\.]+/g, "");
                    var trEcessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textCGSTAmount").value.replace(/[^0-9\.]+/g, "");
                    var trHCessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTRate").value.replace(/[^0-9\.]+/g, "");
                    var trTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTaxAmount").value.replace(/[^0-9\.]+/g, "");
                    var trTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTotalAmount").value.replace(/[^0-9\.]+/g, "");
                    if (rowCheck == true) {
                        tAmount += parseFloat(trAmount);
                        tServiceTax += parseFloat(trServiceTax);
                        tECess += parseFloat(trEcessTax);
                        tHEess += parseFloat(trHCessTax);
                        tTax += parseFloat(trTax);
                        tTotalAmount += parseFloat(trTotalAmount);

                    }
                }
                document.getElementById('<%= textRepAmount.Clientid %>').value = tAmount.toFixed(2);
                document.getElementById('<%= textRepIGSTAmount.clientid %>').value = tServiceTax.toFixed(2);
                document.getElementById('<%= textRepCGSTAmount.clientid %>').value = tECess.toFixed(2);
                document.getElementById('<%= textRepSGSTAmount.clientid %>').value = tHEess.toFixed(2);
                document.getElementById('<%= textRepTaxAmount.Clientid %>').value = tTax.toFixed(2);
                document.getElementById('<%= textRepTotalAmount.Clientid %>').value = tTotalAmount.toFixed(2);

                return true;
            }
        }
    </script>
    <script language="javascript" type="text/javascript">

        function checkAll(id) {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var id1 = document.getElementById("<%=chkSelect.clientid%>").checked;
                var tAmount = 0;
                var tServiceTax = 0;
                var tECess = 0;
                var tHEess = 0;
                var tTax = 0;
                var tTotalAmount = 0;
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect")
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked = id1;
                        var rowCheck = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkSelect").checked;
                        var contNo = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textContNo").value;
                        var trAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textAmount").value.replace(/[^0-9\.]+/g, "");
                        var trServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTAmount").value.replace(/[^0-9\.]+/g, "");
                        var trEcessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textCGSTAmount").value.replace(/[^0-9\.]+/g, "");
                        var trHCessTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textIGSTRate").value.replace(/[^0-9\.]+/g, "");
                        var trTax = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTaxAmount").value.replace(/[^0-9\.]+/g, "");
                        var trTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_rcInvoiceDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_textTotalAmount").value.replace(/[^0-9\.]+/g, "");
                        if (rowCheck == true) {
                            trAmount = trAmount.replace(",", "");
                            tAmount += parseFloat(trAmount);
                            tServiceTax += parseFloat(trServiceTax);
                            tECess += parseFloat(trEcessTax);
                            tHEess += parseFloat(trHCessTax);
                            tTax += parseFloat(trTax);
                            tTotalAmount += parseFloat(trTotalAmount);

                        }
                    }
                    document.getElementById('<%= textRepAmount.clientid %>').value = tAmount.toFixed(2);
                    document.getElementById('<%= textRepIGSTAmount.clientid %>').value = tServiceTax.toFixed(2);
                    document.getElementById('<%= textRepCGSTAmount.clientid %>').value = tECess.toFixed(2);
                    document.getElementById('<%= textRepSGSTAmount.clientid %>').value = tHEess.toFixed(2);
                    document.getElementById('<%= textRepTaxAmount.Clientid %>').value = tTax.toFixed(2);
                    document.getElementById('<%= textRepTotalAmount.Clientid %>').value = tTotalAmount.toFixed(2);

                }
            }
        }


    </script>
    <%-- <script type="text/javascript">
        $(function () {
            $('#btnSave').one('click', function () {
                $(this).attr('disabled', 'disabled');
            });
        });
    </script>--%>
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
        var ScrollHeight = 100;
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
    </script>
    <script type="text/javascript" language="javascript">
        function EnableDisableCtrol(ctrl) {
            if (ctrl.checked) {
                var ctrlId = ctrl.id;
                var consigneeId = document.getElementById(ctrlId.replace("chkSelect", "hdnCustomerId")).value;
                var lineId = document.getElementById(ctrlId.replace("chkSelect", "hdnLineId")).value;
                var chaId = document.getElementById(ctrlId.replace("chkSelect", "hdnCHAId")).value;
                var consignorId = document.getElementById(ctrlId.replace("chkSelect", "hdnconsignorId")).value;
                var textExRate = document.getElementById(ctrlId.replace("chkSelect", "textExRate"));

                if (parseInt(consignorId) > 0) {
                    document.getElementById('<%= lstConsignor.ClientID %>').value = consignorId;
                }

                if (parseInt(lineId) > 0) {
                    document.getElementById('<%= lstLine.ClientID %>').value = lineId;
                }

                if (parseInt(chaId) > 0) {
                    document.getElementById('<%= lstCha.ClientID %>').value = chaId;
                }

                document.getElementById('<%= lstRateMethod.ClientID %>').disabled = false;
                document.getElementById('<%= lstBank.ClientID %>').disabled = false;
                document.getElementById('<%= textAdvanceAmount.ClientID %>').disabled = false;
                document.getElementById('<%= lstServiceType.ClientID %>').disabled = false;
                textExRate.disabled = false;
            }
            else {
                document.getElementById('<%= lstRateMethod.ClientID %>').disabled = true;
                document.getElementById('<%= lstBank.ClientID %>').disabled = true;
                document.getElementById('<%= textAdvanceAmount.ClientID %>').disabled = true;
                document.getElementById('<%= lstServiceType.ClientID %>').disabled = true;
                textExRate.disabled = true;
            }
        }

        function check(ctrl) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList") != null) {
                var val = id.checked;
                var rowCount = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList").getElementsByTagName("tr").length;
                var k = 1;
                for (var j = 0; j < rowCount; j++) {
                    k = k + 1;
                    document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + LPad((k) + "", 2, "0") + "_chkSelect").checked = val;

                } return true;
            }
        }
    </script>

    <script type="text/javascript">
       <%-- document.querySelector('#' +<%= chkSelect.ClientID %>).change(function () {
            alert("yes");
            var status = this.checked;
            if (status)
                document.querySelector('#txtUsername').prop("disabled", false);
            else
                document.querySelector('#txtUsername').prop("disabled", true);
        });--%>
        /*  function EnableDisableTextBox(elmnt) {*/
           <%-- alert("yes");
            $('#' <%= lstServiceType.ClientID %>).prop("disabled", false);

            var lstServiceType = 
            lstServiceType.disabled = check.checked ? false : true;
            if (!lstServiceType.disabled) {
                lstServiceType.focus();
            }--%>
        //    alert("yes");
        //    document.querySelector('ctl00_ContentPlaceHolder1_lstServiceType').prop("disabled", false);
        //    //var ctrl = document.getElementById("ctl00_ContentPlaceHolder1_lstServiceType");
        //    //ctrl.prop("disabled", false);
        //}
    </script>

    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Overseas Invoice" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red">
                                </asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" align="center" id="contdata" runat="server">
                                <table border="1">
                                    <tr>
                                        <td>
                                            <div style="text-align: left; overflow-x: hidden; width: 100%;">
                                                <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                                    runat="server">
                                                    <RowStyle CssClass="FormLabel"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                            <HeaderTemplate>
                                                                <asp:CheckBox ID="chkAll" onClick="check(this);" runat="server" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" onClick="EnableDisableCtrol(this);" runat="server" />
                                                                <asp:HiddenField ID="hdnJoID" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                                                                <asp:HiddenField ID="hdnMtyContid" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                                <asp:HiddenField ID="HdnStateCode" runat="server" Value='<%# Eval("STATE_CODE") %>' />
                                                                <asp:HiddenField ID="hdnCustomerId" runat="server" Value='<%# Eval("CONSIGNEE_ID") %>' />
                                                                <asp:HiddenField ID="hdnLineId" runat="server" Value='<%# Eval("LINE_ID") %>' />
                                                                <asp:HiddenField ID="hdnCHAId" runat="server" Value='<%# Eval("CHA_ID") %>' />
                                                                <asp:HiddenField ID="hdnconsignorId" runat="server" Value='<%# Eval("CUSTOMER_ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont NO"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="120px" DataField="CONT_JO_NO" HeaderText="JOB NO"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="120px" DataField="BL_NO" HeaderText="BL NO" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="INV_NO" HeaderText="Inv. No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="LINE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="ICD_OUT" HeaderText="ICD OUT"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <%--    <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_IN" HeaderText="FACTORY IN"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_OUT" HeaderText="FACTORY OUT"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="FAC_DETAIN" HeaderText="TPT DAYS"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="ICD_IN" HeaderText="ICD IN" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="LINE_HANDOVER_DATE" HeaderText="H/O DATE"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="BL_METHOD" HeaderText="BL Type"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="SOB" HeaderText="RFS/SOB"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="70px" DataField="LINE_DETAIN" HeaderText="LINE DAYS"
                                                            HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="120px" DataField="PORT" HeaderText="POD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="120px" DataField="FPOD" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:BoundField ItemStyle-Width="100px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                        <asp:TemplateField HeaderStyle-CssClass="RepheaderNew" HeaderText="EX. RATE" ItemStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="LblExRate" Width="100Px" runat="server" CssClass="label" Text='<%# Eval("EX_RATE") %>'></asp:Label>
                                                                --%>
                                                                <asp:TextBox ID="textExRate" Width="100Px" MaxLength="5" runat="server" Enabled="false" CssClass="textbox"
                                                                    Text='<%# Eval("EX_RATE") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Button ID="Btnsave" Enabled="tRUE" runat="server"
                                                                    OnClientClick="SaveExRate(this);return false;"
                                                                    CssClass="FormButton" Text="Save" Width="40px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <%--<asp:CheckBoxList ID="chkJoNo" CssClass="FormListBoxMedium" runat="server" Width="400px"
                                                                    AutoPostBack="True">
                                                                </asp:CheckBoxList>--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="1">
                                <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td>
                                                <table width="100%" style="border-color: White;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblParty" runat="server" CssClass="FormLabel" Text="Consignee "></asp:Label>
                                                            <asp:HiddenField ID="hdnInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnJoId" runat="server" />
                                                            <asp:HiddenField ID="hdnMtyContId" runat="server" />
                                                            <asp:HiddenField ID="hdnTempInvoiceNo" runat="server" />
                                                            <asp:HiddenField ID="hdnPrintStatus" runat="server" />
                                                            <asp:HiddenField ID="hdnInvStatus" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstParty" AutoPostBack="true" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Party">
                                                            </asp:DropDownList>
                                                            <span class="mandatory">*</span>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="LblBookingType" runat="server" CssClass="FormLabel" Text="Booking Type"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstBookingType" runat="server" CssClass="FormListBoxMedium"
                                                                Width="90px" ToolTip="Party">
                                                                <asp:ListItem Text="Container" Value="C"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span class="mandatory">*</span>
                                                            <asp:Button ID="btnSearchPendency" runat="server" Text="GO" Visible="false" CssClass="FormButton" />
                                                        </td>
                                                        <td style="vertical-align: top;" rowspan="3" align="left">
                                                            <asp:Label ID="lblJoNo" runat="server" CssClass="FormLabel" Text="JO No">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="ICD Out From Date"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtICDOUtFrom" runat="server" Width="150px" CssClass="FormTextBoxSmall"
                                                                ToolTip="ICD Out From Date">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="txtICDOUtFrom" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="ICD Out To Date"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtICDOutToDate" runat="server" Width="150px" CssClass="FormTextBoxSmall"
                                                                ToolTip="ICD Out From Date">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="txtICDOutToDate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblBlNo" runat="server" CssClass="FormLabel" Text="BL No"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textBLNo" runat="server" Width="150px" AutoComplete="off" CssClass="FormTextBoxSmall"
                                                                ToolTip="BL No">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPartyInvNo" runat="server" CssClass="FormLabel" Text="Shipper Inv No"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textPartyInvNo" runat="server" Width="150px" AutoComplete="off" CssClass="FormTextBoxSmall"
                                                                ToolTip="Shipper Inv No">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblConsignor" runat="server" CssClass="FormLabel" Text="Accounts Of "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstConsignor" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Consignor">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblLine" runat="server" CssClass="FormLabel" Text="Line "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstLine" runat="server" AutoPostBack="true" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Line">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCha" runat="server" CssClass="FormLabel" Text="CHA "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstCha" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="CHA">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAccount" runat="server" CssClass="FormLabel" Text="Account "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstAcount" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Account">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblForwader" runat="server" CssClass="FormLabel" Text="Forwader "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstForwader" runat="server" AutoPostBack="true" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="CHA">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAgent" runat="server" CssClass="FormLabel" Text="Agent "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstAgent" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                                                ToolTip="Account">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Invoice No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceRefNo" AutoComplete="off" Width="130px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="Invoice No">
                                                            </asp:TextBox>
                                                            <asp:Button ID="btnSearchInvoice" runat="server" Text="GO" Visible="false" CssClass="FormButton" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="127px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="clInvoiceDate" Format="dd/MM/yyyy" runat="server"
                                                                TargetControlID="textInvoiceDate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCancelInvoice" runat="server" CssClass="FormLabel" Text="Cancel Invoice No"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstCancelInvoice" Width="131px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Cancel Invoice">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAdvanceAmount" runat="server" CssClass="FormLabel" Text="Advance Amount"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textAdvanceAmount" runat="server" Width="127px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Advance Invoice Amount">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceTo" runat="server" CssClass="FormLabel" Text="Invoice To "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstInvoiceTo" AutoPostBack="true" Width="131px" runat="server"
                                                                CssClass="FormListBoxMedium" ToolTip="Invoice To">
                                                                <asp:ListItem Value="E" Text="Shipper"></asp:ListItem>
                                                                <asp:ListItem Value="F" Text="Forwader"></asp:ListItem>
                                                                <asp:ListItem Value="T" Text="Agent"></asp:ListItem>
                                                                <asp:ListItem Value="C" Text="Cha"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="Line"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="accounts of"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnPaymentMode" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnInvoiceTo" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnCustomer" runat="server" Value="0" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblPaymentMode" runat="server" CssClass="FormLabel" Text="Payment Mode "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upPaymentMode" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstPaymentMode" Width="128px" runat="server" CssClass="FormListBoxMedium"
                                                                        ToolTip="Payment Mode">
                                                                        <asp:ListItem Value="C" Text="Cash" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Value="R" Text="Credit"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstInvoiceTo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left"></td>
                                                        <td align="left">
                                                            <asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="FormButton" />
                                                            <asp:Button ID="btnPreview" runat="server" Text="Preview" CssClass="FormButton" />
                                                        </td>
                                                        <%-- <td align="left">
                                                            <asp:Label ID="lblExporter" runat="server" CssClass="FormLabel" Text="Consignor "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textConsignor" runat="server" Width="270px" CssClass="RptFormTextBoxSmall"
                                                                ToolTip="Exporter">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCha" runat="server" CssClass="FormLabel" Text="Consignee "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextConsignee" Width="274px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="CHA">
                                                          </asp:TextBox>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text="Customer Invoice "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textpono" runat="server" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblServiceType" runat="server" CssClass="FormLabel" Text="Service Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstServiceType" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="0" Text="---Select---" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="A" Text="Tax Invoice"></asp:ListItem>
                                                                <asp:ListItem Value="F" Text="Bill of Supply"></asp:ListItem>
                                                                <asp:ListItem Value="C" Text="CLEARENCE"></asp:ListItem>
                                                                <asp:ListItem Value="R" Text="REBATE"></asp:ListItem>
                                                                <asp:ListItem Value="I" Text="Import Invoice"></asp:ListItem>
                                                                <asp:ListItem Value="X" Text="ReExport Invoice"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRateMethod" runat="server" CssClass="FormLabel" Text="Rate Method "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstRateMethod" Width="127px" runat="server" CssClass="FormListBoxMedium"
                                                                ToolTip="Service Type">
                                                                <asp:ListItem Value="0" Text="---Select---" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Value="H" Text="Handover"></asp:ListItem>
                                                                <asp:ListItem Value="S" Text="SOB"></asp:ListItem>
                                                                <asp:ListItem Value="L" Text="ALLOTMENT"></asp:ListItem>
                                                                <asp:ListItem Value="A" Text="ALL"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCreditLimit" runat="server" CssClass="FormLabel" Text="Credit Limit "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="textCreditLimit" Width="90px" runat="server" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="Credit Limit">
                                                                    </asp:TextBox>&nbsp;&nbsp;
                                                                    <asp:Label ID="lblDueAmount" runat="server" CssClass="FormLabel" Text="Due Amount "></asp:Label><asp:TextBox
                                                                        ID="textDueAmount" Width="90px" runat="server" CssClass="RptFormTextBoxMedium"
                                                                        ToolTip="Due Amount">
                                                                    </asp:TextBox>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstInvoiceTo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label4" runat="server" CssClass="FormLabel" Text="State Name"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstState" runat="server" CssClass="FormListBoxMedium" Width="150px"
                                                                ToolTip="State">
                                                            </asp:DropDownList>
                                                        </td>

                                                          <td align="left">
                                                            <asp:Label ID="lblGSTNo" runat="server" CssClass="FormLabel" Text="GST No."></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textGSTNo" runat="server" Width="220px" AutoComplete="off" CssClass="FormTextBoxSmall"
                                                                ToolTip="GST No.">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblPoDate" runat="server" CssClass="FormLabel" Text="Date"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textPodate" runat="server" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                                                            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textPodate" />--%>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Text="Invoice Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote" runat="server" Width="463px" CssClass="FormTextBoxSmall"
                                                                TextMode="MultiLine" ToolTip="Note" Height="40px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%-- <td align="left">
                                                            <asp:Label ID="lblNote" runat="server" CssClass="FormLabel" Text="Invoice Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote" runat="server" Width="472px" Height="20"  CssClass="FormTextBoxSmall"
                                                                ToolTip="Note">
                                                            </asp:TextBox>
                                                        </td>--%>
                                        </tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblLogo" runat="server" CssClass="FormLabel" Text="Supporting Doc"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:FileUpload runat="server" ID="imgLogo" accept=".pdf" CssClass="FormListBoxMediumMandatory"
                                                ToolTip="Select Supporting Doc" />
                                            <asp:HiddenField runat="server" ID="hdnsupportingdoc" />
                                        </td>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblBankDetails" runat="server" Width="100px" CssClass="FormLabel"
                                    Text="Bank Details "></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstBank" runat="server" CssClass="FormListBoxMedium" Width="220px"
                                    ToolTip="Bank">
                                    <asp:ListItem Text="---Select---" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="tptCheckbox" runat="server" Width="60" CssClass="FormLabel" Text="Agricultural." />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <table>
                    <tr>
                        <td colspan="2">
                            <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 250px; border-left-color: Black;">
                                <asp:TreeView ID="tvInvoices" runat="server" Style="font-family: Verdana; font-size: 12px"
                                    Width="144px">
                                </asp:TreeView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" align="left">
                            <asp:Label ID="LblDispatchStatus" runat="server" Visible="false" CssClass="FormLabel"
                                Text="Dispatch Status">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstDispatchStatus" runat="server" Visible="false" CssClass="FormListBoxMedium"
                                Width="90px" ToolTip="Party">
                                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                <asp:ListItem Text="VIA MAIL" Value="1"></asp:ListItem>
                                <asp:ListItem Text="CURIOUR" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" align="left">
                            <asp:Label ID="LblDispatchDate" Visible="false" runat="server" CssClass="FormLabel"
                                Text="Dispatch Date">
                            </asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextDispatchDate" Visible="false" runat="server" CssClass="FormListBoxMedium"
                                Width="100px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cltexthandoverDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="TextDispatchDate" OnClientDateSelectionChanged="verifyDate" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Button ID="BtnUpdateDispatch" runat="server" CssClass="FormButton" Text="Update"
                                Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="r" style="text-align: left; overflow: auto; height: 400px;">
        <table cellspacing="0" align="center">
            <tr class="RepheaderNew" align="center">
                <td align="left">
                    <asp:CheckBox ID="chkSelect" runat="server" Width="30px" onClick="checkAll(this);"></asp:CheckBox>
                </td>
                <td>
                    <asp:Label ID="lblContNo" Width="120px" runat="server" CssClass="FormLabel" Text="Container No"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSize" Width="25px" runat="server" CssClass="FormLabel" Text="Size"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblservice" Width="305px" CssClass="FormLabel" runat="server" Text="Service"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblQuntity" Width="30px" CssClass="FormLabel" runat="server" Text="Qnty"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="LblExRate" Width="60px" CssClass="FormLabel" runat="server" Text="Ex. Rate"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblRate" Width="60px" CssClass="FormLabel" runat="server" Text="Rate"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Amount"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="CGST Rate"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCGSTAmount" Width="60px" CssClass="FormLabel" runat="server" Text="CGST Amount"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="SGTS Rate"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSGSTAmount" Width="60px" CssClass="FormLabel" runat="server" Text="SGTS Amount"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="IGST Rate"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblIGSTAmount" runat="server" Width="65px" CssClass="FormLabel" Text="IGST Amount"
                        Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalTaxAmount" Width="80px" CssClass="FormLabel" runat="server"
                        Text="GST Amount" Style="font-weight: 700"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total Amount"
                        Style="font-weight: 700"></asp:Label>
                </td>

            </tr>
            <tr>
                <td colspan="16">
                    <asp:Repeater ID="rcInvoiceDetails" runat="server">
                        <HeaderTemplate>
                            <table id="cont1" cellspacing="0" style="margin-left: 0px; margin-right: -2px;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hdnCont" runat="server" />
                                    <asp:HiddenField ID="hdnLineItemId" Value='<%# Eval("LineItemId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("ImpContId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnLineItem" Value='<%# Eval("LineItem") %>' runat="server" />
                                    <asp:HiddenField ID="hdnCommodityId" Value='<%# Eval("CommodityId") %>' runat="server" />
                                    <asp:HiddenField ID="hdnTaxId" runat="server" />
                                    <asp:HiddenField ID="hdnItemKeyId" Value='<%# Eval("ItemKeyId") %>' runat="server" />
                                    <asp:CheckBox ID="chkSelect" Width="15px" runat="server" onclick="SelectAmount(this);"
                                        ToolTip=""></asp:CheckBox>
                                </td>
                                <td class="FormLabel" style="text-align: center; width: 30px; vertical-align: middle;">
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td>
                                    <asp:TextBox ID="textContNo" Style="font-weight: 800" runat="server" CssClass="FormTextBoxMedium"
                                        Width="100px" Text='<%# Eval("ContNo") %>' Enabled="false" ToolTip="Cont No"
                                        MaxLength="11" AutoPostBack="true" OnTextChanged="checkContValid">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textSize" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="FormTextBoxMedium" Width="30px" Text='<%# Eval("ContSize") %>' ToolTip="Size">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="textService" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="FormListBoxMedium" Width="305px" ToolTip="Service" Text='<%# Eval("ServiceId") %>'
                                        OnDataBinding="prepareService">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("InvoiceNo") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="textQuntity" Style="font-weight: 800" runat="server" Enabled="false"
                                        Text='<%# Eval("BillQnty") %>' ToolTip="Quantity" CssClass="FormTextBoxNumeric"
                                        Width="20px">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExRate" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="FormTextBoxNumeric" Width="40px" MaxLength="7" Text='<%#  Eval("ExRate") %>'
                                        ToolTip="Rate">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textRate" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="FormTextBoxNumeric" Width="60px" MaxLength="7" Text='<%#  Eval("BillRate") %>'
                                        ToolTip="Rate" OnTextChanged="checkContNo" AutoPostBack="true">
                                    </asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="textAmount" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="80px" Text='<%#String.Format("{0:n2}", (Eval("BillQnty") * Eval("BillRate") * Eval("ExRate")) - Eval("WeiverAprAmt")) %>'
                                        ToolTip="Amount">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textCGSTRate" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="60px" Text='<% # Eval("CGSTRate")%>'
                                        ToolTip="CGST Rate">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textCGSTAmount" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="60px" Text='<% # Eval("CGSTAmount")%>'
                                        ToolTip="CGST Amount">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textSGSTRate" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="60px" Text='<% # Eval("SGSTRate")%>'
                                        ToolTip="SGST Rate">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textSGSTAmount" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="55px" Text='<% # Eval("SGSTAmount")%>'
                                        ToolTip="SGST Amount">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textIGSTRate" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="60px" Text='<% # Eval("IGSTRate")%>'
                                        ToolTip="IGST Rate">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textIGSTAmount" Style="font-weight: 800" runat="server" Enabled="false"
                                        CssClass="RptFormTextBoxNumeric" Width="60px" Text='<% # Eval("IGSTAmount")%>'
                                        ToolTip="IGST Amount">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="textTaxAmount" Style="font-weight: 800" runat="server" CssClass="RptFormTextBoxNumeric"
                                        Enabled="false" Width="70px" Text='<%#String.Format("{0:n2}", Eval("BillAmount") - ((Eval("BillQnty") * Eval("BillRate") * Eval("ExRate")) - Eval("WeiverAprAmt"))) %>'
                                        ToolTip="Tax Amount">
                                    </asp:TextBox>
                                    <asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:TextBox ID="textTotalAmount" Style="font-weight: 800" runat="server" CssClass="RptFormTextBoxNumeric"
                                        Width="75px" Text='<%# string.Format("{0:n2}",Eval("BillAmount")) %>' Enabled="false"
                                        ToolTip="Total Amount">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>


            <tr>
                <td width="15px"></td>
                <td width="90px"></td>
                <td width="30px"></td>
                <td width="250px"></td>
                <%-- <td width="70px">
                                                </td>
                                                <td width="70px">
                                                </td>--%>
                <td width="30px"></td>
                <td width="70px"></td>
                <td align="right">
                    <asp:Label ID="lblTotal" runat="server" Text="Total " CssClass="FormLabel" Width="60px"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="textRepAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="80px" ToolTip="Amount Total" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepCGSTRate" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="55px" ToolTip="CGST Rate" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepCGSTAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="55px" ToolTip="CGST Amount" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepSGSTRate" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="65px" ToolTip="SGST Rate" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepSGSTAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="65px" ToolTip="SGST Amount" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepIGSTRate" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="60px" ToolTip="IGST Rate" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepIGSTAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="60px" ToolTip="IGST Amount" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepTaxAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="70px" ToolTip="Tax Amount Total" Enabled="false">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="textRepTotalAmount" runat="server" Style="font-weight: 800" CssClass="RptFormTextBoxNumeric"
                        Width="80px" ToolTip="Total Amount" Enabled="false">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="18" style="text-align: right;">
                    <asp:CheckBox ID="chkInvoiceChecked" runat="server" CssClass="FormLabel" Text="Invoice Checked" />
                </td>

            </tr>



            <tr>
                <td colspan="6">
                    <div id="dvButton" style="vertical-align: bottom;">
                        <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                            <tr style="margin-top: 0px;">
                                <td align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="FormButton" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                    <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" Visible="false" />
                                    <asp:Button ID="Button2" runat="server" Text="New Print" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </table>
    </table>
</asp:Content>
