<%@ Page Title="eLOGiFleet :: SOB Pending Report" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="SOBPendingReport.aspx.vb" Inherits="Reports_Fleet_SOBPendingReport"
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="SOB Update" CssClass="FormLabelTitle">
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
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Width="100PX" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Width="100PX" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Status" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstInvoiceStatus" runat="server" ToolTip="Document Type" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Updated" Value="U"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblTrainNo" runat="server" Text="TrainNo" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lsttrainNo" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblPol" runat="server" Text="POL" CssClass="label" Width="50px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label" Width="50px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="12" align="center">
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
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CONT_NO" HeaderText="Container No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CONSINGEE_NAME" HeaderText="Consignee"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Shipping Line"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRAIN_NO" HeaderText="Train No."
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="PORT_ARRIVAL" HeaderText="Port Arrival"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="REQUIRED_ETD" HeaderText="Required ETD"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="REQUIRED_VESSEL" HeaderText="Required Vessel"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRANSHIPMENT_PORT" HeaderText="Transhipment Port"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRANSHIPMENT_ETD" HeaderText="Transhipment ETD"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRANSHIPMENT_VESSEL" HeaderText="Transhipment Vessel"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CURRENT_ETA" HeaderText="ETA"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRANSIT_TIME" HeaderText="Transit Time"
                                                HeaderStyle-CssClass="Repheader" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="SAILED" HeaderText="SOB" HeaderStyle-CssClass="Repheader" />
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
            <td align="center">
                <asp:ImageButton ID="ImgBtnUpdate" runat="server" ImageUrl="~/Images/btnUpdate.png"
                    Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
