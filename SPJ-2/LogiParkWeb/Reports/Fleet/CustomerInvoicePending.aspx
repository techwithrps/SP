<%@ Page Title="eLOGiFreight::Customer Inovice Pending Report" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CustomerInvoicePending.aspx.vb" Inherits="Reports_Fleet_CustomerInvoicePending"
    Theme="Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Customer Invoice Pending" CssClass="FormLabelTitle">
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
                <div style="height: 420px; width: 1350px; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="17">
                                <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepHeadFleet" style="height: 20px;">
                            <td align="center">
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                    Width="20px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblFrom" CssClass="FormLabel" runat="server" Font-Bold="True" Text="From"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Location" Width="120px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblContNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPayLoad" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Pay Load"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size/Type"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblExporter" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Exporter" Width="200px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Line"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblPort" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblIcdOut" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Icd Out"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFactoryin" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Factory IN" Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblFactoryOut" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Factory Out" Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblAgeing" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Ageing(Days)"
                                    Width="60px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LblIcdIn" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD IN"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vehicle No" Width="90px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LbldriverName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Driver" Width="100px"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="LBlStatus" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Status"
                                    Width="100px"></asp:Label>
                            </td>
                            <td align="center" width="15PX">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="18">
                                <div style="height: 300px; overflow: auto;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="20px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="LOCATION" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CARGO_WEIGHT" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="EXPORTER" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GATE_OUT_DATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_IN" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_OUT" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="DWEEL" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD_IN" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="DRIVER_NAME" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="STATUS" />
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
</asp:Content>
