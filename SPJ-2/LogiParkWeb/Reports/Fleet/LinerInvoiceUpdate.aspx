<%@ Page Title="eLOGiFleet :: Liner invoice Pending" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="LinerInvoiceUpdate.aspx.vb" Inherits="Reports_Fleet_LinerInvoiceUpdate"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
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
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Liner Invoice Pending Update" CssClass="FormLabelTitle"
                    Width="300px"> </asp:Label>
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
            <td>
                <table>
                    <tr>
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="5" align="center">
                                        <asp:Label ID="lblFilter" runat="server" Text="FILTER CONTROL" Width="150" class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="textbox" Width="90px" onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                                        <span class="mandatory" style="vertical-align: top;">*</span>
                                        <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textFromDate" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox" onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                                        <span class="mandatory" style="vertical-align: top;">*</span>
                                        <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label1" runat="server" Text="Customer " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="190px"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                                        <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 5px"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 8px"></td>
                        <td>
                            <asp:Button ID="ImgBtnUpdate" runat="server" Text="Update" CssClass="FormButton" />
                        </td>
                        <td style="width: 5px"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 8px"></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>

            </td>

        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="12">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormLabel"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SHIPPER" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CONT_NO" HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Shipping Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:TemplateField ItemStyle-Width="120px" HeaderText="Liner Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLineInvoiceNO" runat="server" Text='<%# Eval("LINER_INV_NO")%>' Width="120px"></asp:Label>
                                                    <asp:TextBox ID="TextLineInvoiceNO" runat="server" CssClass="textbox" Width="120px" Visible="false" Text='<%# Eval("LINER_INV_NO") %>'>
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="100px" HeaderText="Invoice Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLineInvoiceDate" runat="server" Text='<%# Eval("LINER_INV_DATE")%>' Width="100px"></asp:Label>
                                                    <asp:TextBox ID="TxtLineInvoiceDate" runat="server" CssClass="textbox" Width="100px" Visible="false" Text='<%# Eval("LINER_INV_DATE") %>'>
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server" TargetControlID="TxtLineInvoiceDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderText="Inovice Status" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInvoiceStaus" runat="server" Text='<%# Eval("INVOICE_STATUS")%>' Width="150px"></asp:Label>
                                                    <asp:DropDownList ID="lstInvoiceStaus" runat="server" CssClass="ddlMedium" Width="150px" Visible="false" value='<%# Eval("INVOICE_STATUS") %>'>
                                                        <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                        <asp:ListItem Value="APPROVED" Text="APPROVED"></asp:ListItem>
                                                        <asp:ListItem Value="RECEIVED" Text="RECEIVED"></asp:ListItem>
                                                        <asp:ListItem Value="CORRECTION" Text="CORRECTION"></asp:ListItem>
                                                        <asp:ListItem Value="PENDING" Text="PENDING"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="200px" HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("INVOICE_REMARK")%>' Width="200px"></asp:Label>
                                                    <asp:TextBox ID="TxtRemarks" runat="server" CssClass="textbox" Width="200px" Visible="false" MaxLength="48" Text='<%# Eval("INVOICE_REMARK") %>'>
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle Font-Size="8pt"></AlternatingRowStyle>
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
