<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PaymentReceiptReport.aspx.vb" Inherits="Reports_Fleet_PaymentReceiptReport"
    Title="eLOGiFleet:: Payment Receipt Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup() {
            $(function () {
                $("#dialog").dialog({
                    title: "Payment Details",
                    width: 450,
                    height: 300,
                    resizable: false,
                    buttons: {
                        Delete: function () {
                            $(document.getElementById('<%= BtnCancelDetails.ClientID %>')).click();
                        },
                        Excel: function () {
                            $(document.getElementById('<%= AspPopupExcel.ClientID %>')).click();
                        },
                        Print: function () {
                            $(document.getElementById('<%= btnPrint.ClientID %>')).click();
                        },
                        Update: function () {
                            $(document.getElementById('<%= BtnUpdate.ClientID %>')).click();
                        }

                    }
                });
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Payment Receipt Report" Width="400px"
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
                            <asp:Label ID="LblPayMentType" runat="server" Text="Payment Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstreceiptType" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                                <asp:ListItem Value="I">Payment Receipt</asp:ListItem>
                                <asp:ListItem Value="P">PAYMENT ISSUE</asp:ListItem>
                            </asp:DropDownList>
                            <span class="mandatory">*</span>
                        </td>
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
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Receiver Bank Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstReceiverBank" Width="250px" runat="server" ToolTip="Receiver Bank Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="Receipt NO"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" TextMode="MultiLine"
                                Height="30"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="11">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="12">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="true" ShowFooter="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr. No" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:TemplateField HeaderText="Receipt No" HeaderStyle-Width="100px" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkSbNo" Width="100px" CommandArgument='<%# Eval("RECEIPT_NO" )%>'
                                                        Text='<%#Eval("RECEIPT_REF_NO")%>' OnClick="OnClickHandler"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RECEIPT_DATE" HeaderText="Receipt Date"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="INSTRUMENT_DATE" HeaderText="Instrument Date"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="INSTRUMENT_NO" HeaderText="Instrument No"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="BANK_NAME" HeaderText="Receiver Bank Name"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Customer Name"
                                                HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CONS_AMT" ItemStyle-HorizontalAlign="Right"
                                                HeaderText="Consultant Amount" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" DataField="CARGO_AMT"
                                                HeaderText="Cargo Amount" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" DataField="MUM_AMT"
                                                HeaderText="Consultant Amount MUM" HeaderStyle-CssClass="RepheaderNew" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="RECEIPT_REF_NO" HeaderText="Receipt NO"
                                                HeaderStyle-CssClass="RepheaderNew" />
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
    <div id="dialog" style="display: none;">
        <table>
            <tr class="RepHead">
                <td>
                    <asp:HiddenField ID="HdnReceiptNO" runat="server" />
                    <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="Track Id:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="LblReceiptno" runat="server" CssClass="FormLabel"></asp:Label>
                    <br />
                    <asp:Label ID="LblRemark" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                    <asp:TextBox ID="TextRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
                        Height="30"></asp:TextBox>
                    <asp:Label ID="LblReceipt_no" runat="server" CssClass="FormLabel" Text="Receipt NO"></asp:Label>
                    <asp:TextBox ID="TxtChqNo" runat="server" CssClass="textbox" TextMode="MultiLine"
                        Height="30"></asp:TextBox>
                    <asp:Label ID="LblUpdateRemark" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:GridView ID="gridviewVehicleDtls" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-CssClass="FormLabelTitle" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="115px" DataField="INSTRUMENT_NO" HeaderText="Agst. Reference" />
                            <asp:BoundField ItemStyle-Width="115px" DataField="INSTRUMENT_DATE" HeaderText="Date" />
                            <asp:BoundField ItemStyle-Width="115px" DataField="CR_AMOUNT" HeaderText="Amount" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="BtnCancelDetails" runat="server" CssClass="FormButton" />
    <asp:Button ID="AspPopupExcel" runat="server" CssClass="FormButton" />
    <asp:Button ID="btnPrint" runat="server" CssClass="FormButton" />
    <asp:Button ID="BtnUpdate" runat="server" CssClass="FormButton" />
</asp:Content>
