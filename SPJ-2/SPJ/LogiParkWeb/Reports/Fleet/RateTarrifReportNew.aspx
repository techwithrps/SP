<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="RateTarrifReportNew.aspx.vb" Inherits="Reports_Fleet_RateTarrifReportNew"
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
                <asp:Label ID="lblScreenTitle" Width="250px" runat="server" Text="Rate  Tariff Report"
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
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" AutoComplete="off" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" AutoComplete="off" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                         <td align="left">
                                        <asp:Label ID="lblShipper" runat="server" Text="Shipper Name " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstCustomer" runat="server" CssClass="ddlMedium" Width="190px">
                                        </asp:DropDownList>
                                    </td>
                          <td style="text-align: right">
                            <asp:Label ID="lblService" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstService" runat="server" Width="300px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                          <td style="text-align: right">
                            <asp:Label ID="lblPOD" runat="server" Text="POD" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" Width="300px" ToolTip="POD"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />                  </td>
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
                                              <asp:BoundField DataField="RateId" HeaderText="Rate Id" ItemStyle-Width="80px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TerminalName" HeaderText="TerminalName" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromDate" HeaderText="FromDate" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                               <asp:BoundField DataField="ToDate" HeaderText="ToDate" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="SERVICE_NAME" HeaderText="ServiceName" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CustomerType" HeaderText="CustomerType" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CustomerTypeTable" HeaderText="CustomerTypeTable" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CustomerNameTable" HeaderText="CustomerNameTable" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LineName" HeaderText="LineName" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContSize" HeaderText="ContSize." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContType" HeaderText="ContType." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContStatus" HeaderText="ContStatus." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DocType" HeaderText="DocType" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromLocation" HeaderText="FromLocation" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ToLocation" HeaderText="ToLocation" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HandoverLocation" HeaderText="HandoverLocation." HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="POD" HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Commodity" HeaderText="Commodity" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FromRange" HeaderText="FromRange" ItemStyle-Width="100px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ToRange" HeaderText="ToRange" ItemStyle-Width="100px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="RateMethod" HeaderText="RateMethod" ItemStyle-Width="100px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BaseRate" HeaderText="BaseRate" ItemStyle-Width="60px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Currency" HeaderText="Currency" ItemStyle-Width="100px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Enable/Disable" HeaderText="Enable/Disable" ItemStyle-Width="80px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="DiscountType" HeaderText="DiscountType" ItemStyle-Width="60px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                              <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-Width="60px" HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderStyle CssClass="RepheaderNew"></HeaderStyle>
                                            </asp:BoundField>
                                              <asp:BoundField DataField="Rate" HeaderText="Rate" ItemStyle-Width="60px" HeaderStyle-CssClass="RepheaderNew">
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
