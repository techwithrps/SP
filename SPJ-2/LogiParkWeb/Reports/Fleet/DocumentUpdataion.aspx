<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DocumentUpdataion.aspx.vb" Inherits="Reports_Fleet_DocumentUpdataion"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script language="javascript">

        function TabButton() {
            if (event.keyCode == 9) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }
        }

        function whichButton(event) {
            if (event.button == 2)//RIGHT CLICK
            {
                alert("Not Allow Right Click!");
            }

        }
        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            var msg = "Sorry, this functionality is disabled.";
            if (parseInt(code) == 17) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) == 8) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) == 46) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
        }
        function verifyDate(sender, args) {
            var d = new Date();
            var d1 = new Date();
            d.setDate(d.getDate() - 30)
            d1.setDate(d1.getDate() + 1)
            if (sender._selectedDate < d) {
                alert("Date should be Today or Greater than 30 days before Today");
                sender._textbox.set_Value('')
            }
            if (sender._selectedDate > d1) {
                alert("Date should be not greater then Today");
                sender._textbox.set_Value('')
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=TextConsignee]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Reports/Fleet/DocumentUpdataion.aspx/GetConsignee")%>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hdnConsigneeId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvInvoiceReport.ClientID %>";
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
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Width="300" Text="Documentation" CssClass="FormLabelTitle">
                </asp:Label>
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
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td colspan="7" align="center">
                            <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250"
                                class="FormLabelTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="13PX">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="CFS " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblLine" runat="server" Width="100PX" Text="Line " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="DISPLAY" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: RIGHT">
                            <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: RIGHT">
                            <asp:Label ID="LblPartyInvNo" runat="server" Text="Invoice No" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextInvNo" runat="server" CssClass="textbox" Width="100px">
                            </asp:TextBox>
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
                                <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                <asp:ListItem Value="1" Text="HEALTH NOT RECEIVED"></asp:ListItem>
                                <asp:ListItem Value="2" Text="PDA LOW"></asp:ListItem>
                                <asp:ListItem Value="3" Text="TEMPRATURE LOW"></asp:ListItem>
                                <asp:ListItem Value="4" Text="CUSTOM ISSUE"></asp:ListItem>
                                <asp:ListItem Value="5" Text="LOT INCOMPLETE"></asp:ListItem>
                                <asp:ListItem Value="6" Text="INVOICE DELAY"></asp:ListItem>
                                <asp:ListItem Value="7" Text="INVOICE PENDING"></asp:ListItem>
                                <asp:ListItem Value="8" Text="HOLIDAY"></asp:ListItem>
                                <asp:ListItem Value="9" Text="HOLD BY SHIPPER"></asp:ListItem>
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
                            <asp:Label ID="lblCartons" runat="server" Text="Cartons" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextCrtns" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNetWt" runat="server" Text="Net Wt." CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextNetwt" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="center" rowspan="3">
                            <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="FormButton" Visible="true" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Label ID="LblGrossWr" runat="server" Text="Gross Wt." CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextGWt" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="LblHandoverDate" runat="server" Text="Handover Date" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="texthandoverDate" runat="server" CssClass="textbox" Width="100px"
                                onMouseDown="whichButton(event)" onKeyDown="return noCTRL(event)"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cltexthandoverDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="texthandoverDate" OnClientDateSelectionChanged="verifyDate" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="lstuPOL" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: RIGHT">
                            <asp:Label ID="lblUPod" runat="server" Text="POD" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstUPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 4%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td style="width: 4%"></td>
            <td align="center">
                <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                <asp:Button ID="Button2" Width="150px" runat="server" Text="Handover Report" CssClass="FormButton" />
                <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="EXIT" CssClass="FormButton" />
            </td>
        </tr>
    </table>
    <div style="height: 100%; overflow: auto; width: 2500px;">
        <asp:GridView ID="gvInvoiceReport" ShowHeader="True" Font-Size="8pt" RowStyle-CssClass="FormListBoxLarg"
            AutoGenerateColumns="false" runat="server">
            <RowStyle CssClass="FormLabel" BackColor="LightGreen"></RowStyle>
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                <asp:BoundField DataField="CONSIGNOR_NAME" ItemStyle-Width="200px" HeaderText="Shipper"
                    HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblPartyInvocieNO" Width="140" runat="server" Text='<%# Eval("PARTY_INV_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblPartyInvoiceDate" Width="140" runat="server" Text='<%# Eval("PARTY_INV_DATE")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SB No." HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblSbNO" runat="server" Text='<%# Eval("SB_NO")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblSbDate" runat="server" Text='<%# Eval("SB_DATE")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='Booking No.  <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                        <asp:TextBox ID="TextBookingNo" runat="server" Text='<%# Eval("BOOKING_NO") %>' CssClass="textbox"
                            Visible="false" ToolTip="booking NO" OnTextChanged="checkBookingNo" AutoComplete="off" AutoPostBack="true">      
                        </asp:TextBox>
                        <asp:HiddenField ID="hdnConsigneeId" runat="server" />
                        <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                        <asp:HiddenField ID="HdnContJOId" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                        <asp:HiddenField ID="hdnInDate" runat="server" Value='<%# Eval("IN_dATE") %>' />
                        <asp:HiddenField ID="hdnConginor" runat="server" Value='<%# Eval("SHIPPER_ID") %>' />
                        <asp:HiddenField ID="hdnShipper" runat="server" Value='<%# Eval("SHIPPER_NAME") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='Booking Date <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblBookingDate" runat="server" Text='<%# Eval("BOOKING_DATE")%>'></asp:Label>
                        <asp:TextBox ID="TxtBookingDate" runat="server" CssClass="textbox" Width="100px" Text='<%# Eval("BOOKING_DATE")%>'
                            Visible="false" onKeyDown="TabButton();" onpaste="return false;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="reggg" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtBookingDate" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText='SI CutofDate <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblSiCut" runat="server" Width="130" Text='<%# Eval("SI_CUTOF_DATE")%>'></asp:Label>
                        <asp:TextBox ID="TxtSiCut" runat="server" AutoComplete="OFF" CssClass="textbox" Visible="false" onpaste="return false;"
                            BackColor="LightGreen" Text='<%# Eval("SI_CUTOF_DATE") %>'>>
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtSiCut" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtSiCut" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='Port Cut Of Date <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblPortCutOfDate" runat="server" Width="130" Text='<%# Eval("CUTOF_DATE")%>'></asp:Label>
                        <asp:TextBox ID="TextPortCutOfDate" AutoComplete="off" runat="server" Text='<%# Eval("CUTOF_DATE") %>'
                            CssClass="textbox" Visible="false" onKeyDown="TabButton();" onpaste="return false;"
                            ToolTip="Custom Handover">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTextPortCutOfDate" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TextPortCutOfDate" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LINE" ItemStyle-Width="200px" HeaderText="LINE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                        <asp:DropDownList ID="Lstpod" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                            OnDataBinding="preparePod" value='<%# Eval("POD_ID") %>' Width="85px" ToolTip="pod">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='CFS <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="AntiqueWhite" />
                    <ItemTemplate>
                        <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                        <asp:DropDownList ID="Lstcfs" runat="server" Width="85px" value='<%# Eval("CFS_ID") %>' CssClass="RptFormListBoxSmall"
                            Visible="false" OnDataBinding="prepareTerminal" ToolTip="Cfs">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='POL <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="AntiqueWhite" />
                    <ItemTemplate>
                        <asp:Label ID="lblPol" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                        <asp:DropDownList ID="Lstpol" Width="85px" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                            OnDataBinding="preparePort" value='<%# Eval("POL_ID") %>' ToolTip="POl">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='Plan Vessel <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemTemplate>
                        <asp:Label ID="lblPlanVessel" runat="server" Text='<%# Eval("CURRENT_VESSEL")%>'></asp:Label>
                        <asp:TextBox ID="TextPlanVessel" runat="server" Text='<%# Eval("CURRENT_VESSEL") %>'
                            CssClass="textbox" Visible="false" ToolTip="Plan Vessel">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='ETD <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblETD" runat="server" Text='<%# Eval("REQUIRED_ETD")%>'></asp:Label>
                        <asp:TextBox ID="TxtETD" runat="server" CssClass="textbox" Width="100px" Text='<%# Eval("REQUIRED_ETD")%>'
                            Visible="false" AutoComplete="off" onKeyDown="TabButton();" onpaste="return false;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtETD" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtETD" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText='ETA <span class="mandatory";> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblETA" runat="server" Text='<%# Eval("CURRENT_ETA")%>'></asp:Label>
                        <asp:TextBox ID="TxtETA" AutoComplete="off" runat="server" CssClass="textbox" Width="100px" Text='<%# Eval("CURRENT_ETA")%>'
                            Visible="false" onKeyDown="TabButton();" onpaste="return false;">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="clTxtETA" Format="dd/MM/yyyy" runat="server"
                            TargetControlID="TxtETA" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--ADDED BY ARJUN NEGI ON 31/01/2026 BY AKSHAY SIR--%> 
                <asp:TemplateField HeaderText='Transhipment Port <span class="mandatory"> *</span>' HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="AntiqueWhite" />
                    <ItemTemplate>
                        <asp:Label ID="lbltranshipmentPort" runat="server" Text='<%# Eval("TRANSHIPMENT_PORT")%>'></asp:Label>
                        <asp:DropDownList ID="LsttranshipmentPort" Width="85px" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                            OnDataBinding="preparePod1"  value='<%# Eval("TRANS_PORT_ID") %>' ToolTip="transhipment Port">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--ENDED--%>
                <asp:TemplateField HeaderText="Doc Type" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle />
                    <ItemTemplate>
                        <asp:Label ID="lblDocType" runat="server" Text='<%# Eval("TRIP_TYPE")%>'></asp:Label>
                        <asp:DropDownList ID="LstDocType" runat="server"
                            CssClass="RptFormListBoxSmall" Visible="false" Width="85px" ToolTip="Hold Remark">
                            <asp:ListItem Text="---Select---" Value="0">
                            </asp:ListItem>
                            <asp:ListItem Text="Export" Value="E">
                            </asp:ListItem>
                            <asp:ListItem Text="Domestic" Value="D">
                            </asp:ListItem>
                            <asp:ListItem Text="Export" Value="E">
                            </asp:ListItem>
                            <asp:ListItem Text="Import" Value="I">
                            </asp:ListItem>
                            <asp:ListItem Text="Empty Return" Value="M">
                            </asp:ListItem>
                            <asp:ListItem Text="Clearance" Value="C">
                            </asp:ListItem>
                            <asp:ListItem Text="Back To Town" Value="B">
                            </asp:ListItem>
                            <asp:ListItem Text="Reworking" Value="R">
                            </asp:ListItem>
                            <asp:ListItem Text="Nomination" Value="N">
                            </asp:ListItem>
                            <asp:ListItem Text="Transport" Value="T">
                            </asp:ListItem>
                            <asp:ListItem Text="Overseas" Value="O">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment Type" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" />
                    <ItemTemplate>
                        <asp:Label ID="lblConsignmentType" runat="server" Text='<%# Eval("CONSIGNMENT_TYPE")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="RepheaderNew">
                    <ItemStyle BackColor="#F7DC6F" />
                    <ItemTemplate>
                        <asp:Label ID="lblHoldremark" runat="server" Text='<%# Eval("HOLD_REMARK")%>'></asp:Label>
                        <asp:DropDownList ID="LstRemark" runat="server" text='<%# Eval("HOLD_REMARK_ID") %>'
                            CssClass="RptFormListBoxSmall" Visible="false" Width="85px" ToolTip="Hold Remark">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1" Text="HEALTH NOT RECEIVED"></asp:ListItem>
                            <asp:ListItem Value="2" Text="PDA LOW"></asp:ListItem>
                            <asp:ListItem Value="3" Text="TEMPRATURE LOW"></asp:ListItem>
                            <asp:ListItem Value="4" Text="CUSTOM ISSUE"></asp:ListItem>
                            <asp:ListItem Value="5" Text="LOT INCOMPLETE"></asp:ListItem>
                            <asp:ListItem Value="6" Text="INVOICE DELAY"></asp:ListItem>
                            <asp:ListItem Value="7" Text="INVOICE PENDING"></asp:ListItem>
                            <asp:ListItem Value="8" Text="HOLIDAY"></asp:ListItem>
                            <asp:ListItem Value="9" Text="HOLD BY SHIPPER"></asp:ListItem>
                            <asp:ListItem Value="10" Text="NO BOOKING"></asp:ListItem>
                            <asp:ListItem Value="11" Text="RAILING ISSUES"></asp:ListItem>
                            <asp:ListItem Value="12" Text="NO DETAILS"></asp:ListItem>
                            <asp:ListItem Value="13" Text="ORIGINAL DOC NOT RECEIVED"></asp:ListItem>
                            <asp:ListItem Value="14" Text="LATE GATE IN"></asp:ListItem>
                            <asp:ListItem Value="15" Text="ORIGINAL DOCS NOT RECEIVED"></asp:ListItem>
                            <asp:ListItem Value="16" Text="WRONG HEALTH CERTIFICATE"></asp:ListItem>
                            <asp:ListItem Value="17" Text="RFID SEAL NOT SUBMITTED"></asp:ListItem>
                            <asp:ListItem Value="18" Text="RFID SEAL NOT INTECTED"></asp:ListItem>
                            <asp:ListItem Value="19" Text="BOOKING HOLD BY SHIPPING LINE"></asp:ListItem>
                            <asp:ListItem Value="20" Text="POL CONFIRMATION PENDING  FROM SHIPPING LINE"></asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
