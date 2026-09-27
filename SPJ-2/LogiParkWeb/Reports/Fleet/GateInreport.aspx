<%@ Page Title="eLOGiFreight::Gate In Report" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="GateInreport.aspx.vb" Inherits="Reports_Fleet_GateInreport" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Container Gate In Report" CssClass="FormLabelTitle">
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
            <td>
                <table>
                    <tr>
                        <td style="text-align: right">
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
                        </td>
                        <td>
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
                        <%--<tr class="RepHead">
                            <td>
                                <asp:Label ID="lblrSr" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Sr "
                                    Width="30px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblFrom" CssClass="FormLabel" Font-Bold="true" runat="server" Text="From"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblLocation" CssClass="FormLabel" Font-Bold="true" runat="server"
                                    Text="Location" Width="120px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblContNo" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Veh Size"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblSizetype" CssClass="FormLabel" Font-Bold="true" runat="server"
                                    Text="Size/Type" Width="80px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblExporter" CssClass="FormLabel" Font-Bold="true" runat="server"
                                    Text="Exporter" Width="200px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblLine" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Line"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Lblport" CssClass="FormLabel" Font-Bold="true" runat="server" Text="Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblGateout" runat="server" CssClass="FormLabel" Font-Bold="true" Text="Icd Out"
                                    Width="120px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblFactoryIn" runat="server" CssClass="FormLabel" Font-Bold="true"
                                    Text="Factory In" Width="120px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblFactoryOut" CssClass="FormLabel" runat="server" Font-Bold="true"
                                    Text="Factory Out" Width="120px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblAgeing" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Ageing (Days)"
                                    Width="50px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblIcdIn" CssClass="FormLabel" Font-Bold="true" runat="server" Text="ICd In"
                                    Width="120px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblInterminal" runat="server" CssClass="FormLabel" Font-Bold="true"
                                    Text="In Terminal" Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblVehicleNo" runat="server" CssClass="FormLabel" Font-Bold="true"
                                    Text="Vehicle No." Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="LblDriver" runat="server" CssClass="FormLabel" Font-Bold="true" Text="Driver"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="17">
                                <div style="height: 350px; width: 1350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        ShowHeader="true">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                   
                                            <asp:BoundField ItemStyle-Width="20px" DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="From"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LOCATION" HeaderText="Location"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CARGO_WEIGHT" HeaderText="Pay Load"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" HeaderText="Size/Type"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="EXPORTER" HeaderText="Exporter"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="Port" HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="GATE_OUT_DATE" HeaderText="ICD Out"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FACTORY_IN" HeaderText="Factory In"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FACTORY_OUT" HeaderText="Factory Out"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="DWEEL" HeaderText="Ageing(Days)"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="ICD_IN" HeaderText="ICD In" HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CFS" HeaderText="In Terminal"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VEHICLE_NO" HeaderText="Vehicle No"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="DRIVER_NAME" HeaderText="Driver"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                <%--   <asp:Label ID="Label2" runat="server" Width="1180px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel"
                                    Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Width="10px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
