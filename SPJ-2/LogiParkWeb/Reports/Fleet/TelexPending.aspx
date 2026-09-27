<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TelexPending.aspx.vb" MasterPageFile="~/MasterPage.master"
    Inherits="Reports_Fleet_TelexPending" Title="eLOGiFleet :: Telex Pending" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
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
            <td>
                <asp:Label ID="lblScreenTitle" runat="server" Width="250px" Text="Telex Pending"
                    CssClass="FormLabelTitle"></asp:Label>
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
                        <%--<td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>--%>
                        <td>
                            <asp:Label ID="lblCFS" runat="server" CssClass="label" Text="Customer"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblLine" runat="server" CssClass="label" Text="Line"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="Button1" runat="server" Text="Exit" CssClass="FormButton" />
                            <asp:Button ID="ImgBtnUpdate" runat="server" Text="UPDATE" CssClass="FormButton"
                                Visible="false" />
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
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                        runat="server" AlternatingRowStyle-CssClass="FormLabel" OnRowCancelingEdit="gvtripPendencyList_RowCancelingEdit"
                                        OnRowEditing="gvtripPendencyList_RowEditing" OnRowUpdating="gvtripPendencyList_RowUpdating"
                                        RowStyle-CssClass="FormLabel">
                                        <RowStyle Font-Size="8pt" BackColor="AntiqueWhite"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNewNew">
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
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shipper Name" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipperName" runat="server" Text='<%#Eval("SHIPPER_NAME")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Party Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPartyInvoiceNo" runat="server" Text='<%#Eval("PARTY_INV_NO")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textPartyInvoiceNo" runat="server" Text='<%#Eval("PARTY_INV_NO")%>'
                                                        Visible="false"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Port" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPort" runat="server" Text='<%#Eval("PORT")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Line" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLine" runat="server" Text='<%#Eval("LINE")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Container Number" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContNo" runat="server" Text='<%#Eval("CONT_NO")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="BL Number" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBlNo" runat="server" Text='<%#Eval("BL_NO")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textBlNo" runat="server" Text='<%#Eval("BL_NO")%>' Visible="false"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ETD" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEtd" runat="server" Text='<%#Eval("CURRENT_ETD")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textEtd" runat="server" Text='<%#Eval("CURRENT_ETD")%>' Visible="false"
                                                        ToolTip="DD/MM/YYYY"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vessel" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVessel" runat="server" Text='<%#Eval("CURRENT_VESSEL")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textVessel" runat="server" Text='<%#Eval("CURRENT_VESSEL")%>' Visible="false"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ETA" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEta" runat="server" Text='<%#Eval("CURRENT_ETA")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textEta" runat="server" Text='<%#Eval("CURRENT_ETA")%>' ToolTip="DD/MM/YYYY"
                                                        Visible="false"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shipment Status" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipmentStatus" runat="server" Text='<%#Eval("SHIPMENT_STATUS")%>'></asp:Label>
                                                    <%--<asp:TextBox ID="textShipmentStatus" runat="server" Text='<%#Eval("SHIPMENT_STATUS")%>'
                                                        ToolTip="1-DELIVERED,2-GATE OUT,3-DISCHARGE" Visible="false"></asp:TextBox>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telex " HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                                                    <asp:DropDownList ID="LstRemark" runat="server" CssClass="ddlMedium" Value='<%# Eval("TELEX_STATUS")%>'
                                                        Visible="false" BackColor="LightGreen">
                                                        <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="UPDATED"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Telex Date" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTalexDate" runat="server" Text='<%# Eval("TELEX_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="lstTelexDate" runat="server" CssClass="textbox" Text='<%# Eval("TELEX_DATE")%>'
                                                        Visible="false" BackColor="LightGreen">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="lstTelexDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ageing" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAgeing" runat="server" Text='<%#Eval("AGEING")%>'></asp:Label>
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
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
