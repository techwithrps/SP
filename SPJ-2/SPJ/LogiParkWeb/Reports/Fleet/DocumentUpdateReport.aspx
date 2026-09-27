<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DocumentUpdateReport.aspx.vb" Inherits="Reports_Fleet_DocumentUpdateReport"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <td style="width: 400px;">
                <asp:Label ID="lblScreenTitle" Width="250px" runat="server" Text="All Party Document Update"
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
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Invoice Status" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstInvoiceStatus" runat="server" ToolTip="Document Type" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Updated" Value="U"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="CFS " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
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
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="True" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server"
                                        BackColor="AntiqueWhite">
                                        <Columns>
                                            <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="SHIPPER_NAME" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="CONSINGEE_NAME" HeaderText="Consignee" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="BL_NO" HeaderText="BL NO." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="BOOKING_NO" HeaderText="Booking NO." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="LOT" HeaderText="Lot" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="CONT_NO" HeaderText="Container No." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="ICD_GATE_OUT" HeaderText="Icd Out" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="FACTORY_IN" HeaderText="Factory In" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="FACTORY_OUT" HeaderText="Factory Out" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="ICD_GATE_IN" HeaderText="ICD In" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="SB_NO" HeaderText="SB NO." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="SB_DATE" HeaderText="Sb Date" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="SB_RECEIVED" HeaderText="Sb Received" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="CARTONS" HeaderText="Pkgs." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="NET_WT" HeaderText="Net Wt." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="GROSS_WT" HeaderText="Gross Wt." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="CUSTOMS_HANDOVER_DATE" HeaderText="Custom Handover" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="PARTY_INV_NO" HeaderText="Party Invoice No." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="PARTY_INV_DATE" HeaderText="Party Invoice Date" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="HEALTH_CERTIFICATE_NO" HeaderText="Health Cert. No." HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="" HeaderText="Health Cert. Lot" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="TO_LOCATION" HeaderText="Factory Location" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="PORT" HeaderText="PORT" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField DataField="HOLD_REMARK" HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <%--<tr>
            <td align="center">
                <asp:ImageButton ID="ImgBtnUpdate" runat="server" ImageUrl="~/Images/btnUpdate.png"
                    Visible="false" />
            </td>
        </tr>--%>
    </table>
</asp:Content>
