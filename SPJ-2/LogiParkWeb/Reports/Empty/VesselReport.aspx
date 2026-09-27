<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="VesselReport.aspx.vb" Inherits="Reports_Empty_VesselReport" Title="eLOGiFleet:: Vessel Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vessel Report" CssClass="FormLabelTitle"> </asp:Label>
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
                     <%--   <td align="left">
                            <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="ICD Out From Date"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtICDOUtFrom" runat="server" AutoComplete="off" Width="127px" CssClass="textbox"
                                ToolTip="ICD Out From Date">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="txtICDOUtFrom" />
                        </td>
                        <td align="left">
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="ICD Out To Date"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtICDOutToDate" runat="server" AutoComplete="off" Width="127px" CssClass="textbox"
                                ToolTip="ICD Out From Date">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="txtICDOutToDate" />
                        </td>--%>

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
                            <asp:Label ID="lblShipper" runat="server" Text="Customer Name" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="ddShipper" runat="server" ToolTip="Terminal Name" Width="150px" CssClass="ddlMedium">
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
                            <asp:Button ID="BtnSend" runat="server" Text="Send Mail" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <asp:GridView ID="gvtripPendencyList" ShowHeader="true" Width="2000" AlternatingRowStyle-CssClass="FormListBoxLarg"
                RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" HeaderStyle-CssClass="RepheaderNew">
                <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                <Columns>
                    <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="CONT_JO_NO" HeaderText="Cont Id"></asp:BoundField>
                    <asp:TemplateField HeaderText="Cont Jo No" ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkInvoice" Width="60" CommandArgument='<%# Eval("CONT_JO_NO")%>'
                                Text='<%#Eval("CONT_JO_NO")%>' OnClick="OnClickHandlerStatus" DataField="CONT_JO_NO"> </asp:LinkButton>
                         <asp:HiddenField ID="hdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont No "></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="400px" DataField="SHIPPER" HeaderText="SHIPPER"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="ICD_OUT_DATE" HeaderText="ICD Out Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="LINE" HeaderText="Line"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="400px" DataField="TRANSPORTER" HeaderText="Transporter"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120px" DataField="BOOKING_NO" HeaderText="Booking No"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="BOOKING_DATE" HeaderText="Booking Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="PICKUP_LOCATION" HeaderText="Pickup Location"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="FACTORY_LOCATION" HeaderText="Factory Location"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="CFS" HeaderText="CFS"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="PORT" HeaderText="Port"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="POL" HeaderText="POL"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="300px" DataField="VESSEL_NAME" HeaderText="Vessel Name"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="ETD_DATE" HeaderText="ETD Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200px" DataField="SI_CUTOF_DATE" HeaderText="SI CutOf Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="220px" DataField="PORT_CUTOF_DATE" HeaderText="Port CutOf Date"></asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150px" DataField="AGEING_DAYS" HeaderText="Ageing"></asp:BoundField>
                </Columns>
                <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
            </asp:GridView>
            </div>
        </tr>
    </table>

</asp:Content>
