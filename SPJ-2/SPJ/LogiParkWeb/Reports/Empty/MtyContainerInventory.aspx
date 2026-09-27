<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MtyContainerInventory.aspx.vb" Inherits="Reports_Empty_MtyContainerInventory" Title="eLOGiFleet:: Container Inventory Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Empty Inventory Report" CssClass="FormLabelTitle"> </asp:Label>
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
                            <asp:Label ID="lblPOL" runat="server" Text="POL" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlPOL" runat="server" ToolTip="POL" Width="150px" CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblPOD" runat="server" Text="POD" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlPOD" runat="server" ToolTip="POD" Width="150px" CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblLine" runat="server" Text="Shipping Line" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddlLine" runat="server" ToolTip="Shipping Line" Width="150px" CssClass="ddlMedium">
                            </asp:DropDownList>
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
            <asp:GridView ID="gvtripPendencyList" ShowHeader="true" Width="3000" AlternatingRowStyle-CssClass="FormListBoxLarg"
                RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" HeaderStyle-CssClass="RepheaderNew">
                <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                <Columns>
                    <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="CONT_JO_NO" HeaderText="Cont Id"></asp:BoundField>
                    <asp:TemplateField HeaderText="Cont Jo No" ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkInvoice" Width="60" CommandArgument='<%# Eval("CONT_JO_NO")%>'
                                Text='<%#Eval("CONT_JO_NO")%>' OnClick="OnClickHandlerStatus" DataField="CONT_JO_NO"> </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="BOOKING_NO" HeaderText="Booking No"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="BOOKING_DATE" HeaderText="Booking Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="Validity" HeaderText="Re- Validity"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="400px" DataField="TRANSPORTER" HeaderText="Transporter"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="400px" DataField="SHIPPER" HeaderText="SHIPPER"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="LINE" HeaderText="Line"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="FROM_PORT" HeaderText="Pickup Location"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="ICD" HeaderText="Handover Location"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="POD" HeaderText="Local Port"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="STUFFING_PORT" HeaderText="Stuffing Port"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="HANDOVER_PORT" HeaderText="Handover Port"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="POL" HeaderText="POL"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="300px" DataField="VESSEL_NAME" HeaderText="Vessel Name"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="ETD_DATE" HeaderText="ETD Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="EMPTY_SI_CUTOF_DATE" HeaderText="SI CutOf Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="EMPTY_CUTOF_DATE" HeaderText="Port CutOf Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="VEHICLE_NO" HeaderText="Vehicle No "></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont No "></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="CONT_SIZE" HeaderText="Size "></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="CONT_TYPE" HeaderText="Type "></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="180px" DataField="EXTRA3" HeaderText="Allotment Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="PICKUP_DATE" HeaderText="Out Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="170px" DataField="GATE_IN_DATE" HeaderText="Gate In Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="250px" DataField="STATUS" HeaderText="Status"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="AGEING_DAYS" HeaderText="Ageing"></asp:BoundField>
                </Columns>
                <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
            </asp:GridView>
            </div>
        </tr>
    </table>

</asp:Content>
