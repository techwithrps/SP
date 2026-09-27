<%@ Page Title="eLOGiFleet :: Vessel Planing Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="FreightPendencyReport.aspx.vb" Inherits="Reports_Fleet_FreightPendencyReport"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtportArrival]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtCutOfDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TxtTRHandover]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>--%>
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
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Freight Pendency Report" CssClass="FormLabelTitle"
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
                         <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Visible="false" />
                           <%-- <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />--%>
                            <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
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
                                        runat="server">
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
                                            <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                                                <asp:BoundField DataField="CONT_NO" HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="CUSTOMER_CODE" ItemStyle-Width="110px" HeaderText="Shipper"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                              <asp:BoundField DataField="LINE" HeaderText="S/Line" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                              <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                    <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                            <asp:BoundField DataField="POL" HeaderText="Pol" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="PORT" HeaderText="Port" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="JOB_NO" HeaderText="Job No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="BL_NO" HeaderText="Bl No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="TRIP_TYPE" HeaderText="Trip Type" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="PARTY_INV_NO" HeaderText="Party Inv No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                               <asp:BoundField DataField="BL_METHOD" HeaderText="Bl Method" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                                <asp:BoundField DataField="REQUIRED_ETD" HeaderText="ETD" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

                                            <asp:TemplateField HeaderText="REMARK" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFreightRemarks" runat="server" ></asp:Label>
                                                    <asp:TextBox ID="textFreightRemarks" runat="server" ItemStyle-Width="150px" CssClass="textbox" AutoComplete="OFF"
                                                         Visible="False" BackColor="LightGreen"  Text='<%# Eval("FREIGHT_REMARKS") %>'>
                                                    </asp:TextBox>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Billing Status" HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                 <ItemTemplate>
                                                <asp:DropDownList CssClass="ddlMedium" Width="80px"  Visible="False"
                                                                  ID="lstElogisolRemark" ItemStyle-Width="50px" runat="server" ToolTip="Enable/Disable">
                                                    <asp:ListItem Value="Y" Text="ENABLE"></asp:ListItem>
                                                    <asp:ListItem Value="N" Text="DISABLE"></asp:ListItem>
                                                </asp:DropDownList>
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
            <td align="center">&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
