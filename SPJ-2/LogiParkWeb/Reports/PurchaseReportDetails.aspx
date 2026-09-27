<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PurchaseReportDetails.aspx.vb" Inherits="Reports_Imports_InvoiceReport"
    Title="eLOGiFleet:: Purchase Customer/Service Wise Report" Theme="Forms" %>

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
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Purchase Customer/Service Wise Report"
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
                            <td colspan="9">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Customer Wise Purchase Details Report as on: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" ShowFooter="True"
                                        FooterStyle-CssClass="RepheaderNew" HeaderStyle-CssClass="RepheaderNew" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr No" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="COMPANY_NAME" HeaderText="Company Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PURCHASE_TYPE" HeaderText="Purchase Type" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="BL_NO" HeaderText="BL NO" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINER_INV_NO" HeaderText="Invoice No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINER_INV_DATE" HeaderText="Invoice Date" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="Service Name" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TAXABLE_AMT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Taxable Amount" />
                                                        <asp:BoundField ItemStyle-Width="80px" DataField="EX_RATE" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Ex. Rate" />

                                                         <asp:BoundField ItemStyle-Width="80px" DataField="QNTY" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Qnty" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TAX_AMT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Tax Amount" />
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CGST_RATE" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="CGST Rate" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="CGST Amount" />
                                            <asp:BoundField ItemStyle-Width="30px" DataField="SGST_RATE" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="SGST Rate" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="SGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="SGST Amount" />
                                            <asp:BoundField ItemStyle-Width="30px" DataField="IGST_RATE" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="IGST Rate" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="IGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="IGST Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TDS_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="TDS Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TOTAL" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Bill Amount" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="Table1" runat="server">
                        <tr>
                            <td colspan="9">
                                <asp:Label ID="lblReportService" CssClass="FormLabel" Visible="false" runat="server"
                                    Font-Bold="true" Text="Service Wise Purchase Details Report as on: "></asp:Label><asp:Label
                                        ID="lblReportDate1" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvService" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" ShowFooter="True"
                                        FooterStyle-CssClass="RepheaderNew" HeaderStyle-CssClass="RepheaderNew" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr No" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="COMPANY_NAME" HeaderText="Company Name" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="Service Name" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TAXABLE_AMT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Taxable Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TAX_AMT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Tax Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="CGST Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="SGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="SGST Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="IGST_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="IGST Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TDS_AMOUNT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="TDS Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TOTAL" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Bill Amount" />
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
