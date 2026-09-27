<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="EDIReport.aspx.vb" Inherits="Reports_Fleet_EDIReport"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <asp:Label ID="lblScreenTitle" Width="250px" runat="server" Text="EDI Report"
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
                        <td align="left">
                            <asp:Label ID="lblShipper" runat="server" Text="Shipper Name " CssClass="label"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="LstShipper" runat="server" CssClass="ddlMedium" Width="190px">
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
                                <div style="height: 100%; overflow: auto; width: 2300px;">
                                    <asp:GridView ID="gvInvoiceReport" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        BackColor="AntiqueWhite">
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONSIGNOR_NAME" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>                                           
                                            <asp:BoundField DataField="CONSINGEE_NAME" HeaderText="Consignee" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SHIPPER_NAME" HeaderText="Notify Party" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONT_JO_ID" HeaderText="Elogisol Id" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONT_NO" HeaderText="Container No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONT_SIZE" HeaderText="Size" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONT_TYPE" HeaderText="Type" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="TRIP_TYPE" HeaderText="Doc Type" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="GROSS_WT" HeaderText="Gross Wt." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NET_WT" HeaderText="Net Wt." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                              <asp:BoundField DataField="REF_ID" HeaderText="REF ID" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HEALTH_CERTIFICATE_NO" HeaderText="Heath Cert. No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PACKAGE_TYPE" HeaderText="Package No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CARTONS" HeaderText="Items" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="INV_NO" HeaderText="Shipper Invoice No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BL_NO" HeaderText="BL No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PARTY_INV_DATE" HeaderText="Shipper Invoice Date" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SB_NO" HeaderText="SB No." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CONSIGNMENT_TYPE" HeaderText="Consignment Type" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FOB_VALUE_INR" HeaderText="FOB Value" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PORT" HeaderText="POD" ItemStyle-Width="120px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="JOB_NO" HeaderText="JOB No" ItemStyle-Width="120px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="JOB_DATE" HeaderText="JOB Date" ItemStyle-Width="120px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
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
