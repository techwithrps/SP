<%@ Page Title="eLOGiFreight::Sales Report" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="SalesReport.aspx.vb" Inherits="Reports_SalesReport"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $('#InvoiceNo').text(message);
                var dlg = $("#dialog").dialog({
                    title: "Service Details",
                    width: 815,
                    height: 300,

                    resizable: false
                });
                dlg.parent().appendTo(jQuery("form:first"));
                return false;
            });
        };
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Sales Report" Width="300px" CssClass="FormLabelTitle"> </asp:Label>
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
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" CssClass="FormTextBoxDate"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                            <asp:HiddenField ID="HdnCustomerId" runat="server" />
                        </td>
                        <td rowspan="2">
                            <asp:Button ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="BtnSend" runat="server" Text="Send Mail" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblCompany" runat="server" Text="Company" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCompany" Width="250px" runat="server" ToolTip="Company Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblServiceType" runat="server" Text="Service Type " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstServiceType" Width="100px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="F">FREIGHT</asp:ListItem>
                                <asp:ListItem Value="C">CLEARENCE</asp:ListItem>
                                <asp:ListItem Value="T">TRANSPORT</asp:ListItem>
                                <asp:ListItem Value="M" Text="AMENDMENT"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblPaymentStatus" runat="server" Text="Payment Status" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPaymentStatus" Width="100px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="Y">PAID</asp:ListItem>
                                <asp:ListItem Value="N">PENDING</asp:ListItem>
                                <asp:ListItem Value="P">PARTIAL</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 100%; overflow: auto;">
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="11">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        runat="server" ShowFooter="true">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Customer" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="200px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="PARTY_INV_NO" HeaderText="Party Invoice No" />
                                            <asp:BoundField ItemStyle-Width="200px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="LINE" HeaderText="Line" />
                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="PORT" HeaderText="Port" />
                                            <asp:BoundField HeaderText="Invoice No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_REF_NO" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Invoice Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-Width="100px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Base Rate" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="RATE" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="Tax Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TAX_AMT" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Total" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TOTAL" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="SOB" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="SOB" ItemStyle-Width="100px"></asp:BoundField>
                                            <asp:BoundField HeaderText="BL Status" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BL_STATUS" ItemStyle-Width="100px"></asp:BoundField>
                                            <asp:BoundField HeaderText="BL Issue Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="ISSUE_DATE" ItemStyle-Width="100px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Payment Status" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="PAYMENT_STATUS" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Age(Days)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGEING" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Invoice No" HeaderStyle-Width="110px" ControlStyle-Width="110px">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkinvno" Width="110px" CommandArgument='<%# Eval("INVOICE_NO" )%>'
                                                        Text='<%#Eval("INVOICE_REF_NO")%>' OnClick="OnClickHandler"></asp:LinkButton>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div id="dialog" style="display: none;">
                    <asp:GridView ID="gridviewcontDtls" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-ForeColor="#004182" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="10px" ItemStyle-CssClass="FormTextBoxNumSmall" ItemStyle-Height="5px"
                                DataField="SR_NO" HeaderText="Sr." />
                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="System Service Name" />
                            <asp:BoundField ItemStyle-Width="200px" DataField="BILL_DESCRIPTION" HeaderText="Tally Service Name" />
                            <asp:BoundField ItemStyle-Width="200px" ItemStyle-CssClass="FormTextBoxNumSmall"
                                DataField="CONT_NO" HeaderText="Cont No" />
                            <asp:BoundField ItemStyle-Width="65px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="RATE"
                                HeaderText="Amount" />
                            <asp:BoundField ItemStyle-Width="70px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="TAX_AMOUNT"
                                HeaderText="Tax Amount" />
                            <asp:BoundField ItemStyle-Width="70px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="BILL_AMOUNT"
                                HeaderText="Total Amount" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
