<%@ Page Title="eLOGiFleet::Purchase Custome Ledger" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="PurchaseCustomerLedger.aspx.vb" Inherits="Reports_CustomerLedger"
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
        function ShowPopup() {
            $(function () {
                $("#dialog").dialog({
                    title: "Payment Issue Details",
                    width: 450,
                    height: 300,
                    resizable: false,
                    buttons: {
                        Cancel: function () {
                            $(document.getElementById('<%= BtnCancelDetails.ClientID %>')).click();
                        },
                        Excel: function () {
                            $(document.getElementById('<%= AspPopupExcel.ClientID %>')).click();
                        },
                        Print: function () {
                            $(document.getElementById('<%= btnPrint.ClientID %>')).click();
                        },
                        Mail: function () {
                            $(document.getElementById('<%= btnMail.ClientID %>')).click();
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
    <%--<script type="text/javascript">
        $(function () {
            $("#<%=TextRemark.ClientID%>").bind("input", function () {
                var value1 = $("#<%=TextRemark.ClientID%>").val();
                $("#LblUpdateRemark").html(value);
            });
        });
     
    </script>--%>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Purchase Customer Ledger" Width="300px"
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
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPurchaseType" AutoPostBack="True" runat="server" ToolTip="Purchase Type" Width="250px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                                                   <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                                                    <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Transport" Value="T"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Clearing & Forwarding" Value="C"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
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
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        runat="server" ShowFooter="true">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Purchase Invoice/Instrument No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_NO" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Purchase Invoice/Instrument  Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_DATE" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Voucher Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="VOUCHER_TYPE" ItemStyle-Width="110px"></asp:BoundField>
                                            <%-- <asp:BoundField HeaderText="Instrument No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CHEQUE_NO" ItemStyle-Width="110px"></asp:BoundField>
                                            <asp:BoundField HeaderText="Instrument Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CHEQUE_DATE" ItemStyle-Width="110px"></asp:BoundField>--%>
                                            <asp:BoundField HeaderText="DR Amount(INR)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="DR" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="CR Amount(INR)" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CR" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="Adjudted Amount(INR)" HeaderStyle-CssClass="GVHeadText"
                                                ControlStyle-CssClass="FormLabel" DataField="TOTAL_CR" ItemStyle-Width="70px"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Map Receipt No" HeaderStyle-Width="130px" ControlStyle-Width="130px" >
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkSbNo" Width="130px" CommandArgument='<%# Eval("RECEIPT_NO" )%>'
                                                        Text='<%#Eval("RECEIPT_REF_NO")%>' OnClick="OnClickHandler"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                              <asp:BoundField HeaderText="Remarks" HeaderStyle-CssClass="GVHeadText"
                                                ControlStyle-CssClass="FormLabel" DataField="REMARKS" ItemStyle-Width="300px"
                                                ItemStyle-HorizontalAlign="left"></asp:BoundField>
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
    <div id="dialog" style="display: none;">
        <table>
            <tr class="RepHead">
                <td>
                    <asp:HiddenField ID="HdnReceiptNO" runat="server" />
                    <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text="Track Id:" Font-Bold="true"></asp:Label>
                    <asp:Label ID="LblReceiptno" runat="server" CssClass="FormLabel"></asp:Label>
                    <br />
                    <asp:Label ID="LblRemark" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                    <asp:TextBox ID="TextRemark" runat="server" CssClass="textbox" TextMode="MultiLine"
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
      <asp:Button ID="btnMail" runat="server" CssClass="FormButton" />
    <%-- <asp:Button ID="BtnCancelDetails" runat="server" OnClick="SaveContDetails" CssClass="FormButton" />--%>
</asp:Content>
