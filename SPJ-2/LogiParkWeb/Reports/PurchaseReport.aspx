<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PurchaseReport.aspx.vb" Inherits="Reports_Imports_InvoiceReport" Title="eLOGiFleet:: Invoice Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Purchase Report"
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
                        <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPurchaseType" AutoPostBack="True" runat="server" ToolTip="Purchase Type"
                                Width="250px" CssClass="ddlMedium">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                <asp:ListItem Text="Clearing & Forwarding" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Transport" Value="T"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Customer/Vendor" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Document Type" Width="200px"
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
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--   <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr" Width="30px"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:Label ID="lblrIGMNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrBookingDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo Date" Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrBillingParty" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Billing Party" Width="300px"></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label ID="lblrInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Date" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text=" Invoice Amount(INR)" Width="180px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrUserId" CssClass="FormLabel" runat="server" Font-Bold="True" Text="User ID" Width="100px"></asp:Label>
                            </td>
<td>
                                <asp:Label ID="LblPaymentStatus" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Payment Status" Width="100px"></asp:Label>
                            </td>

                            <td style="background-color: White; width: 15px;"></td>
                        </tr>--%>
                        <tr>
                            <td colspan="10">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" ShowFooter="True"
                                        HeaderStyle-CssClass="RepheaderNew" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr No" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" />
                                            <%--    <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_NO"  HeaderText="Invoice No" />--%>
                                            <%-- <asp:HyperLinkField  Text="INVOICE_NO"  DataTextField="INVOICE_NO" DataNavigateUrlFormatString="~/Commercial/CostBookingNew.aspx?CostId={0}"
                                             Target="_blank"   ItemStyle-Width="100px" DataNavigateUrlFields="INVOICE_NO" HeaderText="Invoice No"></asp:HyperLinkField>--%>
                                            <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkInvoice" CommandArgument='<%# Eval("INVOICE_NO" )%>'
                                                        Text='<%#Eval("INVOICE_NO")%>' OnClick="OnClickHandlerStatus"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_No" HeaderText="BL No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TAXABLE_AMOUNT" HeaderText="Taxable Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TAX_AMT" HeaderText="Tax Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BILL_AMOUNT" HeaderText="Bill Amount"
                                                ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" HeaderText="Created By" />
<asp:BoundField ItemStyle-Width="100px" DataField="PAYMENT_STATUS" HeaderText="Payment Status" />
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
