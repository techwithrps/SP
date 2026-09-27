<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DocumentUpdataion1.aspx.vb" Inherits="Reports_Fleet_DocumentUpdataion1"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">

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
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="300" Text="All Party Document Update"
                    CssClass="FormLabelTitle">
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
    <table width="100%">
        <tr>
            <td>
                <table>
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
                                    <td height="13PX">
                                        &nbsp;
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
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;">
                        </td>
                        <td>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="Label4" runat="server" Text="REMARK - FILTER" Width="250px" class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" height="12px">
                                    </td>
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
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnRDisplay" runat="server" Text="DISPLAY" CssClass="FormButton" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%">
                        </td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;">
                        </td>
                        <td style="width: 4%">
                        </td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblUpdate" runat="server" Text="WRITE & SELECT - DRAG" Width="250px"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" height="12px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
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
                                    <td align="Center" rowspan="3">
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="FormButton" Visible="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
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
                                    <td>
                                    </td>
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
                        <td style="width: 4%">
                        </td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;">
                        </td>
                        <td style="width: 4%">
                        </td>
                        <td align="center">
                            <asp:Button ID="Button2" Width="150px" runat="server" Text="Handover Report" CssClass="FormButton" />
                            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="EXIT" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr class="RepHead">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr" Width="30px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrCustomerName" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer Name" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No." Width="130px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Date" Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrIGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="IGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="CSGT" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrSGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="SGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrTotalAmt" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total" Width="100px"></asp:Label>
                            </td>

                            <td style="background-color: White; width: 15px;"></td>
                        </tr>--%>
                        <tr>
                            <td colspan="20">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="True" RowStyle-CssClass="FormListBoxLarg"
                                        AutoGenerateColumns="false" runat="server">
                                        <RowStyle CssClass="FormLabel" BackColor="LightGreen"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle Font-Bold="true" CssClass="RepheaderNew" />
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew"
                                                ItemStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Factory" HeaderStyle-CssClass="RepheaderNew" ItemStyle-Width="200PX">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" Width="200px" runat="server" Text='<%# Eval("TO_LOCATION")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="TO_LOCATION" width="150px" HeaderText="Factory Location"
                                                HeaderStyle-CssClass="RepheaderNew" />--%>
                                            <%--<asp:TemplateField ItemStyle-Width="300PX" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipper" Width="300PX" runat="server" Text='<%# Eval("SHIPPER_NAME")%>'></asp:Label>
                                                    <asp:TextBox ID="TextShipper" runat="server" Text='<%# Eval("SHIPPER_NAME") %>' CssClass="textbox"
                                                        Width="300px" Visible="false" ToolTip="Shipper" AutoCompleteType="Enabled">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <%--<asp:TemplateField ItemStyle-Width="300PX" HeaderText="Exporter" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConsignor" Width="300PX" runat="server" Text='<%# Eval("CONSIGNOR_NAME")%>'></asp:Label>
                                                    <asp:DropDownList ID="TextConsignor" runat="server" Value='<%# Eval("CONSIGNOR_ID") %>'
                                                        CssClass="ddlMedium" Width="300px" Visible="false" ToolTip="CONSIGNOR" OnDataBinding="prepareCustomer">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField ItemStyle-Width="300PX" HeaderText="Consignee" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConsignee" runat="server" Text='<%# Eval("CONSINGEE_NAME")%>' Width="300PX"></asp:Label>
                                                    <asp:TextBox ID="TextConsignee" runat="server" Text='<%# Eval("CONSINGEE_NAME") %>'
                                                        Width="300PX" CssClass="textbox" Visible="false" ToolTip="Consignee">
                                                    </asp:TextBox>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                    <asp:HiddenField ID="HdnContJOId" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                                                    <asp:HiddenField ID="hdnInDate" runat="server" Value='<%# Eval("IN_dATE") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LOT" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLot" runat="server" Text='<%# Eval("LOT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Health Cert. No." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHealthNo" runat="server" Text='<%# Eval("HEALTH_CERTIFICATE_NO")%>'></asp:Label>
                                                    <asp:TextBox ID="TextHeathNo" runat="server" Text='<%# Eval("HEALTH_CERTIFICATE_NO") %>'
                                                        CssClass="textbox" Visible="false" ToolTip="helath No">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartyInvocieNO" runat="server" Text='<%# Eval("PARTY_INV_NO")%>'></asp:Label>
                                                    <asp:TextBox ID="TextPartyInvoiceNO" ReadOnly="false" runat="server" Text='<%# Eval("PARTY_INV_NO") %>'
                                                        CssClass="textbox" Visible="false" ToolTip="Party Invoice No">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Invoice Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartyInvoiceDate" runat="server" Text='<%# Eval("PARTY_INV_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextPartyInvoicedate" runat="server" ReadOnly="false" Text='<%# Eval("PARTY_INV_DATE") %>'
                                                        CssClass="textbox" Visible="false" onMouseDown="whichButton(event)" onKeyDown="return noCTRL(event)"
                                                        ToolTip="Party Invoice Date">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clTextPartyInvoicedate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TextPartyInvoicedate" OnClientDateSelectionChanged="verifyDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SB No." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSbNO" runat="server" Text='<%# Eval("SB_NO")%>'></asp:Label>
                                                    <asp:TextBox ID="TextSbNo" runat="server" Text='<%# Eval("SB_NO") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="Sb no">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSbDate" runat="server" Text='<%# Eval("SB_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextSbDate" runat="server" Text='<%# Eval("SB_DATE") %>' CssClass="textbox"
                                                        Visible="false" onMouseDown="whichButton(event)" onKeyDown="return noCTRL(event)"
                                                        ToolTip="Sb Date">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TextSbDate" OnClientDateSelectionChanged="verifyDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Custom Handover" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomHandover" runat="server" Text='<%# Eval("CUSTOMS_HANDOVER_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextCustomHandover" runat="server" Text='<%# Eval("CUSTOMS_HANDOVER_DATE") %>'
                                                        CssClass="textbox" Visible="false" onMouseDown="whichButton(event)" onKeyDown="return noCTRL(event)"
                                                        ToolTip="Custom Handover">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clTextCustomHandover" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TextCustomHandover" OnClientDateSelectionChanged="verifyDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbllineHandover" runat="server" Text='<%# Eval("LINE_HANDOVER_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextLineHandover" runat="server" Text='<%# Eval("LINE_HANDOVER_DATE") %>'
                                                        CssClass="textbox" Visible="false" ReadOnly="false" onMouseDown="whichButton(event)"
                                                        onKeyDown="return noCTRL(event)" ToolTip="Line Handover Date">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clTextLineHandover" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TextLineHandover" OnClientDateSelectionChanged="verifyDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sb Received" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSbReceived" runat="server" Text='<%# Eval("SB_RECEIVED")%>'></asp:Label>
                                                    <asp:DropDownList ID="LstSbReceived" runat="server" value='<%# Eval("SB_RECEIVED") %>'
                                                        CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Sb received">
                                                        <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Received"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Received and checked"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Packet" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPacket" runat="server" Text='<%# Eval("CARTONS")%>'></asp:Label>
                                                    <asp:TextBox ID="TextPacket" runat="server" Text='<%# Eval("CARTONS") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="Cartons">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pcs" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPcs" runat="server" Text='<%# Eval("PCS")%>'></asp:Label>
                                                    <asp:TextBox ID="TextPcs" runat="server" Text='<%# Eval("PCS") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="PCS">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cube" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCube" runat="server" Text='<%# Eval("CUBE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextCube" runat="server" Text='<%# Eval("CUBE") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="Cube">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Net Wt." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("NET_WT")%>'></asp:Label>
                                                    <asp:TextBox ID="TextWeight" runat="server" Text='<%# Eval("NET_WT") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="Net Wt">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gross Wt." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGrossWt" runat="server" Text='<%# Eval("GROSS_WT")%>'></asp:Label>
                                                    <asp:TextBox ID="TextGrossWeight" runat="server" Text='<%# Eval("GROSS_WT") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="Gross Wt.">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Line" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="" HeaderText="Health Cert. Lot" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                    <asp:DropDownList ID="Lstpod" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                                                        OnDataBinding="preparePod" value='<%# Eval("POD_ID") %>' ToolTip="pod">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                    <asp:DropDownList ID="Lstcfs" runat="server" value='<%# Eval("CFS_ID") %>' CssClass="RptFormListBoxSmall"
                                                        Visible="false" OnDataBinding="prepareTerminal" ToolTip="Cfs">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="AntiqueWhite" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPol" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                                                    <asp:DropDownList ID="Lstpol" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                                                        OnDataBinding="preparePort" value='<%# Eval("POL_ID") %>' ToolTip="POl">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Booking No." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                                                    <asp:TextBox ID="TextBookingNo" runat="server" Text='<%# Eval("BOOKING_NO") %>' CssClass="textbox"
                                                        Visible="false" ToolTip="booking NO">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL No." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBlNo" runat="server" Text='<%# Eval("BL_NO")%>'></asp:Label>
                                                    <asp:TextBox ID="TextBlNo" runat="server" Text='<%# Eval("BL_NO") %>' CssClass="textbox"
                                                        Visible="false" ToolTip=" Bl NO">
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consignment Type" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="#F7DC6F" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConsignmentType" runat="server" Text='<%# Eval("CONSIGNMENT_TYPE")%>'></asp:Label>
                                                    <asp:DropDownList ID="LstConsignmentType" runat="server" text='<%# Eval("CONSIGNMENT_TYPE_ID") %>'
                                                        CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Consignment Type">
                                                        <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="CNF"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="CIF"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="FOB"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remark" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="#F7DC6F" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHoldremark" runat="server" Text='<%# Eval("HOLD_REMARK")%>'></asp:Label>
                                                    <asp:DropDownList ID="LstRemark" runat="server" text='<%# Eval("HOLD_REMARK_ID") %>'
                                                        CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Hold Remark">
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
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <%--<asp:Label ID="lblSpace" runat="server" Width="720px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Width="70px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="ImgBtnUpdate" runat="server" ImageUrl="~/Images/btnUpdate.png"
                    Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
