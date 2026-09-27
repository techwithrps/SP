<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TrackReport.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Reports_Fleet_TrackReport"
    Title="eLOGiFleet :: Track Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

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
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Track Report" Width="400px"
                    CssClass="FormLabelTitle"> </asp:Label>
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
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromLocation" runat="server" Text="Terminal Name" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTerminal" runat="server" ToolTip="Terminal Name" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                        <td id="tdMailSendingingItem" runat="server">
                            <asp:Label Text="To mail Ids" runat="server" CssClass="FormLabel"></asp:Label>
                            <asp:TextBox ID="textToMailIds" runat="server" TextMode="MultiLine" CssClass="textbox" Height="30" Width="220" />
                            <asp:Button ID="btnSend" Text="Send" runat="server" CssClass="FormButton" />
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
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="STATUS" HeaderText="Status"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CUSTOMER_CODE" HeaderText="Shipper"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PARTY_INV_NO" HeaderText="Inv. No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="210px" DataField="LINE" HeaderText="Shipping Line"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CFS" HeaderText="ICD "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BOOKING_NO" HeaderText="Booking No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_NO" HeaderText="Conatiner No"></asp:BoundField>
                                            <%-- <asp:BoundField ItemStyle-Width="30px" DataField="CONT_SIZE" HeaderText="SIZE"></asp:BoundField>
                                            --%>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="POL" HeaderText="POL"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PORT" HeaderText="POD"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FINAL_VESSEL" HeaderText="Vessel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REQUIRED_ETD" HeaderText="ETD"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ICD_OUT_DATE" HeaderText="ICD Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FACTORY_IN_DATE" HeaderText="Factory In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FACTORY_OUT_DATE" HeaderText="Factory Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ICD_IN_DATE" HeaderText="ICD In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="LINE_HANDOVER_DATE" HeaderText="Handover Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PORT_ARRIVAL" HeaderText="Pol Arrival Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SOB" HeaderText="SOB Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CURRENT_ETA" HeaderText="ETA Destination"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="TRANSIT_TIME" HeaderText="Transit Time"></asp:BoundField>

                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="Label2" runat="server" Width="1500px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="" Width="60px" CssClass="FormLabel"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Width="10px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
