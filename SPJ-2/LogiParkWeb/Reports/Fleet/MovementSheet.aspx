<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MovementSheet.aspx.vb" Inherits="Reports_Fleet_MovementSheet" Title="eLOGiFleet:: Movement Sheet Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvGRDetails.ClientID %>";
        var ScrollHeight = 300;
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
    <script language="javascript" type="text/javascript">
        function DisplayValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textFromDate.clientId %>'),
            document.getElementById('<%=lblFromDate.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textToDate.clientId %>'),
            document.getElementById('<%=lblToDate.clientId %>').innerHTML))
                    result = true;
                else
                    result = false;
            else
                result = false;
            return result;
        }
        function checktodate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that the To Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
        function checkfromdate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that From Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Movement Details"
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
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblTerminal" runat="server" Text="Terminal" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTerminal" Width="130px" runat="server" ToolTip="Terminal"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer" CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblVehicle" runat="server" Text="Vehicle No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstVehicle" Width="130px" runat="server" ToolTip="Vehicle No"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr class="RepheaderNew" style="height: 20px;">
                            <td align="center">
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                    Width="20px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblIcdOut" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Out"
                                    Width="120px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCont" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory In"
                                    Width="120px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label1" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory Out"
                                    Width="120px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFactoryIn" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="ICD In" Width="120px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label3" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="130px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                    Width="50px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblrCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer" Width="180px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Line"
                                    Width="180px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Font-Bold="True" Text="FPOD"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPickUp" CssClass="FormLabel" runat="server" Font-Bold="True" Text="From Location"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFromLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To Location" Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblToLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover Location" Width="130px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Doc Type"
                                    Width="60px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vehicle No" Width="90px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LBlJoNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblGrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gr No"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTollTax" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Toll Tax"
                                    Width="50px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblKm" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Km"
                                    Width="50px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDriverName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Driver Name" Width="90px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCash" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cash"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDisel" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Diesel"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTotal" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label4" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Det. Days"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label5" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BE No"
                                    Width="70px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label6" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BE. Date"
                                    Width="100px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="26">
                                <div style="height: 300px; overflow: auto;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="True" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="20px" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="ICD_OUT" HeaderText="Icd Out"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FACTORY_IN" HeaderText="Factory In"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FACTORY_OUT" HeaderText="Factory Out"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="ICD_IN" HeaderText="Icd In" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CONT_NO" HeaderText="Container No."
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" HeaderText="Size" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="180px" DataField="CUSTOMER" HeaderText="Customer"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="180px" DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FPOD" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MTY" HeaderText="From Location"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="To Location"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="TO_LOCATION" HeaderText="Handover Location"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="TRIP_TYPE" HeaderText="Doc Type"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" HeaderText="Vehicle No"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="JO_NO" HeaderText="JO No." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="GR_NO" HeaderText="Gr No." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="TOLL_TAX" HeaderText="Toll Tax"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="KM" HeaderText="KM" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="DRIVER" HeaderText="Driver" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="ADVANCE" HeaderText="Cash" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="OIL_ADVANCE" HeaderText="Diesel"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="TOTAL" HeaderText="Total" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DET_DAYS" HeaderText="Det. Days"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="BE_NO" HeaderText="BE No" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DO_VALIDITY" HeaderText="BE Date"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                        </Columns>
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
