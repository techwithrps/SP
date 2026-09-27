<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CustomerOutstandingReport.aspx.vb" Inherits="Reports_CustomerOutstandingReport"
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
    <%--<script type="text/javascript">
        function ShowPopup() {
            $(function () {
                $("#dialog").dialog({
                    title: "Payment Details",
                    width: 450,
                    height: 300,
                    resizable: false,
                    buttons: {
                        Cancel: function () {
                            $(document.getElementById('<%= BtnCancelDetails.ClientID %>')).click();
                        }

                    }
                });
            });
        };
    </script>--%>
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Customer OutStanding" Width="300px"
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
                        <%--<td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>--%>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
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
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        runat="server" ShowFooter="true">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Receipt No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_NO" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Receipt Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Voucher Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="VOUCHER_TYPE" ItemStyle-Width="110px"></asp:BoundField>
                                            <%-- <asp:BoundField HeaderText="Instrument No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CHEQUE_NO" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Instrument Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CHEQUE_DATE" ItemStyle-Width="110px"></asp:BoundField>--%>
                                            <asp:BoundField HeaderText="DR Amount(INR)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="DR_AMT" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="CR Amount(INR)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR_AMOUNT" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <%-- <asp:BoundField HeaderText="Adjudted Amount(INR)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TOTAL_CR" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>--%>
                                            <%-- <asp:TemplateField HeaderText="Map Receipt No">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkSbNo" CommandArgument='<%# Eval("RECEIPT_NO" )%>'
                                                        Text='<%#Eval("RECEIPT_REF_NO")%>' OnClick="OnClickHandler"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="right">
                                <asp:Label ID="lblTotalbalanceAmt" runat="server" CssClass="RepHead"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
