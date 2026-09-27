<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="SalesVsCostPending.aspx.vb" Inherits="Reports_Fleet_SalesVsCost" Title="eLOGiFleet:: Sales Vs Cost"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <%-- <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript">
        function ShowPopup() {
            $(function () {

                $("#dialog").dialog({
                    title: " Invoice Details",
                    width: 680,
                    height: 400,
                    resizable: false
                });
            });
        };

        function ShowPopup2() {
            $(function () {

                $("#Div1").dialog({
                    title: " Purchase Details",
                    width: 680,
                    height: 400,
                    resizable: false
                });
            });
        };
        function ShowPopupError() {
            $(function () {

                $("#dialogErr").dialog({
                    title: " Invoice Details",
                    width: 480,
                    height: 100,
                    resizable: false
                });
            });
        };

        function ShowPopup1() {
            $(function () {

                $("#dialog1").dialog({
                    title: " Service Details",
                    width: 620,
                    height: 400,
                    resizable: false
                });
            });
        };
       
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvInvoiceReport.ClientID %>";
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Sales Vs Cost Status Report"
                    Width="400px" CssClass="FormLabelTitle">
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
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date(Invoice)" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date(Invoice)" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblLine" runat="server" Text="Line" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstLine" runat="server" ToolTip="Serice Group" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Service Group" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstServiceGroup" runat="server" ToolTip="Serice Group" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">Transport Group</asp:ListItem>
                                <asp:ListItem Value="2">Freight Group</asp:ListItem>
                                <asp:ListItem Value="3">Clearence Group</asp:ListItem>
                                <asp:ListItem Value="4">Other Group</asp:ListItem>
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
                <div style="height: 390px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="11">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" ShowFooter="true"
                                        runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr. No" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="Port" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="BL_NO" HeaderText="BL No" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BASE_INV_AMOUNT" ItemStyle-HorizontalAlign="right"
                                                HeaderText="Base Invoice Amount" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="Total Invoice Amount" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkTIA" CommandArgument='<%# Eval("BL_NO" )%>'
                                                        Text='<%#Eval("TOTAL_INV_AMOUNT")%>' OnClick="OnClickHandlerTotalInvoice"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:ButtonField ControlStyle-Width="100px" DataTextField="TOTAL_INV_AMOUNT"  CommandName="OnClickHandler" ItemStyle-HorizontalAlign="right" HeaderText="Total Invoice Amount" HeaderStyle-CssClass="RepheaderNew"/>--%>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BASE_COST_AMOUNT" ItemStyle-HorizontalAlign="right"
                                                HeaderText="Base Cost Amount" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="Total Cost Amount" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkTCA" CommandArgument='<%# Eval("BL_NO" )%>'
                                                        Text='<%#Eval("TOTAL_COST_AMOUNT")%>' OnClick="OnClickHandlerTotalCost"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField ItemStyle-Width="100px" DataField="TOTAL_COST_AMOUNT" ItemStyle-HorizontalAlign="right" HeaderText="Total Cost Amount" HeaderStyle-CssClass="RepheaderNew"/>
                                            --%>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MARGIN" ItemStyle-HorizontalAlign="right"
                                                HeaderText="Margin" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkSTATUS" CommandArgument='<%# Eval("BL_NO" )%>'
                                                        Text='<%#Eval("STATUS")%>' OnClick="OnClickHandlerStatus"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="750px" CssClass="FormLabel" Visible="false"></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel"
                                    Font-Bold="true" Visible="false"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Width="70px" CssClass="FormLabel" Visible="false"></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <div id="dialog" style="display: none; width: 680px;">
        <table>
            <tr class="RepHead">
                <td>
                    <asp:GridView ID="gridviewVehicleDtls" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-CssClass="FormLabelTitle" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:HyperLinkField DataTextField="INVOICE_REF_NO" DataNavigateUrlFormatString="~/Commercial/Preview/ExportInvoicePrint.aspx?InvoiceNo={0}"
                                Target="_blank" ItemStyle-Width="300px" DataNavigateUrlFields="INVOICE_NO" HeaderText="Invoice No">
                            </asp:HyperLinkField>
                            <asp:BoundField ItemStyle-Width="120px" DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="BASE_AMOUNT" HeaderText="Base Amount" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="GST_AMOUNT" HeaderText="GST Amount" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="CR_AMOUNT" HeaderText="CR Amount" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="CR_TAX" HeaderText="CR Tax Amt" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="BILL_AMOUNT" HeaderText="Bill Amount" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="Div1" style="display: none; width: 680px;">
        <table>
            <tr class="RepHead">
                <td>
                    <asp:GridView ID="gridViewPurchase" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-CssClass="FormLabelTitle" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="120px" DataField="COST_TYPE" HeaderText="Type" />
                            <asp:HyperLinkField DataTextField="INVOICE_REF_NO" DataNavigateUrlFormatString="~/Commercial/CostBookingNew.aspx?CostId={0}"
                                Target="_blank" ItemStyle-Width="300px" DataNavigateUrlFields="INVOICE_REF_NO"
                                HeaderText="Invoice No"></asp:HyperLinkField>
                            <asp:BoundField ItemStyle-Width="120px" DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="BASE_AMOUNT" HeaderText="Base Amount" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="GST_AMOUNT" HeaderText="GST Amount" />
                            <%--<asp:BoundField ItemStyle-Width="120px" DataField="DR_AMOUNT" HeaderText="Dr Amount" />
                            <asp:BoundField ItemStyle-Width="120px" DataField="DR_TAX" HeaderText="Dr Tax Amt" />--%>
                            <asp:BoundField ItemStyle-Width="120px" DataField="BILL_AMOUNT" HeaderText="Bill Amount" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog1" style="display: none; width: 620px;">
        <table>
            <tr class="RepHead">
                <td>
                    <asp:GridView ID="gvStatus" ShowHeader="True" AutoGenerateColumns="false" RowStyle-Font-Size="Small"
                        runat="server" Height="40px" HeaderStyle-Font-Size="Small" HeaderStyle-CssClass="FormLabelTitle"
                        RowStyle-CssClass="FormLabel" ShowFooter="true">
                        <%-- <Columns>
                            <asp:BoundField ItemStyle-Width="310px" DataField="SALE_SERVICE_NAME" HeaderText="Sale Service" />
                            <asp:BoundField ItemStyle-Width="310px" DataField="PURCHASE_SERVICE_NAME" HeaderText="Purchase Service" />
                            
                        </Columns>--%>
                        <Columns>
                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" HeaderText="BL NO" />
                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="SERVICE" />
                            <asp:BoundField ItemStyle-Width="100px" DataField="RATE" HeaderText="SALE RATE" />
                            <asp:BoundField ItemStyle-Width="100px" DataField="COST" HeaderText="COST RATE" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
