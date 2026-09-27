<%@ Page Title="eLOGiFleet :: Shipment Status Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="ShipmentStatusReport.aspx.vb" Inherits="Reports_Fleet_ShipmentStatusReport"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
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
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Shipment Status Update" CssClass="FormLabelTitle">
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
                        <td style="text-align: left">
                            <asp:Label ID="lblPort" runat="server" Text="Port" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstPort" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="LBlLine" runat="server" Text="Line" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstLine" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="LblStatus" runat="server" Text="Shipment Status" CssClass="label"
                                Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lststatus" runat="server" CssClass="ddlMedium" Width="190px">
                                <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                <asp:ListItem Value="1" Text="DISCHARGED"></asp:ListItem>
                                <asp:ListItem Value="2" Text="GATE OUT"></asp:ListItem>
                                <asp:ListItem Value="3" Text="DELIVERED"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                        runat="server" RowStyle-CssClass="FormLabel">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="20px" HeaderText="Sr" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SHIPPER" HeaderText="Shipper"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_NO" HeaderText="Invoice NO"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CONSINGEE_NAME" HeaderText="Consignee"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="PORT" HeaderText="Port" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="BL_NO" HeaderText="BL NO." HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CURRENT_ETD" HeaderText="Required ETD"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="REQUIRED_VESSEL" HeaderText="Required Vessel"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SOB" HeaderText="SOB" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CURRENT_ETA" HeaderText="ETA"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSIT_TIME" HeaderText="Transit Time"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SHIPMENT_STATUS_NAME" HeaderText="Status"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
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
