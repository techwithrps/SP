<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SPJMasterReport.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Reports_Fleet_SPJMasterReport"
    Title="eLOGiFleet :: Master Report" Theme="Forms" %>

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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Master Report" Width="400px"
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

                          <td style="text-align: left">
                            <asp:Label ID="lblShipper" runat="server" CssClass="FormLabel" Text="Shipper Name"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstShipper" runat="server" Width="100px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblLine" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:DropDownList ID="lstline" runat="server" Width="100px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblPOD" runat="server" CssClass="FormLabel" Text="POD"></asp:Label>
                        </td>
                       <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" Width="100px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                       
                        <%--<td align="left">
                                            <asp:Label ID="lblrTerminal" runat="server" CssClass="FormLabel" Text="Terminal Name"></asp:Label>
                                        </td>
                                        <td align="left" rowspan="2">
                                            <div style="height: 100px; overflow: auto; width: 100%">
                                                <asp:Repeater ID="rptTerminal" runat="server">
                                                    <HeaderTemplate>
                                                        <table cellspacing="0" rules="all" border="1" style="border: 1px solid #CCC;">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                            </td>
                                                            <td>
                                                               
                                                                <asp:Label ID="lstTerminalName2" CssClass="FormLabel" Text='<%# Eval("TERMINAL_NAME")%>' runat="server" />
                                                                <asp:HiddenField ID="hddTerminalCode" Value='<%# Eval("TERMINAL_ID")%>' runat="server" />
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                               
                                            </div>
                                          
                                        </td>--%>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="Terminal Name"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTerminalName" runat="server" Width="100px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>

                        <td align="right">
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
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="51">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CONT_NO" HeaderText="Container No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CONT_SIZE" HeaderText="Size"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="CONT_TYPE" HeaderText="Type"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="TRIP_TYPE" HeaderText="Doc Type"></asp:BoundField>
                                          <%--    <asp:BoundField ItemStyle-Width="70px" DataField="CONT_JO_ID" HeaderText="Elogisol Id"></asp:BoundField>
                                          <asp:BoundField ItemStyle-Width="100px" DataField="EMPTY_BOOKING_NO" HeaderText="Empty Booking No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="EMPTY_BOOKING_DATE" HeaderText="Empty Booking Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="210px" DataField="LINE" HeaderText="Line Code"></asp:BoundField>
                                      --%>      <asp:BoundField ItemStyle-Width="210px" DataField="LINE_NAME" HeaderText="Line Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="TARE_WT" HeaderText="Tare Wt"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="GROSS_WT" HeaderText="Gross Wt"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="PAYLOAD" HeaderText="Total Payload"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FROM_LOCATION" HeaderText="From Location"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FACTORY_LOCATION" HeaderText="Factory Location"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CFS" HeaderText="CFS "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CUSTOMER" HeaderText="Shipper Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CHA" HeaderText="CHA Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CONSIGNEE" HeaderText="Consignee Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ALLOTMENT_DATE" HeaderText="Allotment Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ICD_OUT_DATE" HeaderText="Factory Stuffing Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FACTORY_IN_DATE" HeaderText="Factory In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FACTORY_OUT_DATE" HeaderText="Factory Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BUFFER_IN_DATE" HeaderText="Buffer In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BUFFER_OUT_DATE" HeaderText="Buffer Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ICD_IN_DATE" HeaderText="CFS Loaded In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CUSTOM_SEAL" HeaderText="E-Seal No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="LINE_SEAL" HeaderText="Line Seal No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="GR_NO" HeaderText="GR No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="GR_DATE" HeaderText="GR Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="OWN_VEHICLE_NO" HeaderText="Vehicle No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="VENDOR_NAME" HeaderText="Transporter Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BOOKING_NO" HeaderText="Booking No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BOOKING_DATE" HeaderText="Booking Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" HeaderText="BL No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SB_NO" HeaderText="SB No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SB_DATE" HeaderText="SB Date "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="JOB_NO" HeaderText="JOB No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="JOB_DATE" HeaderText="JOB Date "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PARTY_INV_NO" HeaderText="Shipper Inv No "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_DATE" HeaderText="Shipper Inv Date "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_METHOD" HeaderText="BL Type "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="COMMODITY_NAME" HeaderText="Commodity "></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CUSTOMS_HANDOVER_DATE" HeaderText="Docs Handover Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="LINE_HANDOVER_DATE" HeaderText="CFS Handover Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="POL" HeaderText="POL"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TRAIN_NO" HeaderText="Train No"></asp:BoundField>
                                        <%--    <asp:BoundField ItemStyle-Width="150px" DataField="WAGON_NO" HeaderText="Wagon No"></asp:BoundField>
                                     --%>       <asp:BoundField ItemStyle-Width="150px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PORT_ARRIVAL" HeaderText="Pol Arrival Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PORT" HeaderText="POD"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REGION" HeaderText="REGION"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SOB" HeaderText="SOB Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FINAL_VESSEL" HeaderText="Vessel Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REQUIRED_ETD" HeaderText="ETD Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="FINAL_ETD" HeaderText="Final ETD Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CURRENT_ETA" HeaderText="ETA Destination"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="DISCHARGE_DATE" HeaderText="Discharge Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="GATE_OUT_DATE" HeaderText="Gate Out Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="EMPTY_GATE_IN_DATE" HeaderText="Empty Gate In Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="TRANSIT_TIME" HeaderText="Transit Time"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="STATUS" HeaderText="Remarks"></asp:BoundField>
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
