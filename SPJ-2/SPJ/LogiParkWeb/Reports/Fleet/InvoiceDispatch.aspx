<%@ Page Language="VB" AutoEventWireup="false" CodeFile="InvoiceDispatch.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Reports_Fleet_InvoiceDispatch"
    Title="eLOGiFleet :: Invoice Dispatch" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
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
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Invoice Dispatch" CssClass="FormLabelTitle" Width="400px"> </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field" ForeColor="Red"></asp:Label>
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
                                        <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250" class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstCustomer" runat="server" CssClass="ddlMedium" Width="250px">
                                        </asp:DropDownList>
                                    </td>

                                    <td align="right">
                                        <asp:Button ID="btnDisplay" runat="server" Text="DISPLAY" CssClass="FormButton" />
                                          <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 4%"></td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Label ID="lblUpdate" runat="server" Text="WRITE & SELECT - DRAG" Width="250px"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDispatchMedium" runat="server" Text="Medium" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstMedium" runat="server" CssClass="ddlMedium" Width="150px">
                                            <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Mail"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Courier"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="By Hand"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Internal Purpose"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblDispatchDate" runat="server" Text="Dispatch Date" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="textDispatchDate" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="clOutDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textDispatchDate" />
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="ImgBtnUpdate" runat="server" Text="Update" CssClass="FormButton" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">&nbsp;
                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">&nbsp;</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 4%"></td>




                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 4%"></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 100%; width: 100%; overflow: auto; margin-top: 0px;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="16">
                                <div id="tbCont" style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                               <%--             <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:BoundField  ItemStyle-Width="30px" HeaderText="Sr" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            
                                            <asp:BoundField DataField="CUSTOMER_NAME" ItemStyle-Width="300px" HeaderText="Customer Name" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="INVOICE_REF_NO" ItemStyle-Width="150px" HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="INVOICE_DATE" ItemStyle-Width="100px" HeaderText="Invoice Date" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="SERVICE_TYPE" ItemStyle-Width="100px" HeaderText="Service Type" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="BILL_AMOUNT" ItemStyle-Width="100px" HeaderText="Amount" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

                                            <asp:TemplateField HeaderText="Medium" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrDispatchMedium" runat="server" Text='<%# Eval("DISPATCH_MEDIUM")%>'></asp:Label>
                                                    <asp:DropDownList ID="ddlDispatchMedium" runat="server" CssClass="ddlMedium" BackColor="LightGreen" Visible="false" Width="100px" value='<%# Eval("DISPATCH_MEDIUM")%>'>
                                                        <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Mail"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Courier"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="By Hand"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Internal Purpose"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dispatch Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDispatchDate" runat="server" CssClass="textbox" Width="100px" Visible="false" BackColor="LightGreen">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDispatchDate" />
                                                     <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>
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
