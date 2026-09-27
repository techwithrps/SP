<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CFSContainerInventory.aspx.vb" Inherits="Reports_Empty_CFSContainerInventory"
    Title="eLOGiFleet:: CFS Inventory Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Empty Inventory Report"
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
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="70px" CssClass="textbox"> </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="70px" CssClass="textbox"> </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromLocation" runat="server" Text="From Location" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstFromLocation" runat="server" ToolTip="From Location" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToLocation" runat="server" Text="To Location" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstToLocation" runat="server" ToolTip="To Location" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblTransactionType" runat="server" Text="Transaction Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTransactionType" runat="server" ToolTip="Transaction Type"
                                Width="150px" CssClass="ddlMedium">
                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                <asp:ListItem Text="INTRANSIT" Value="1"></asp:ListItem>
                                <asp:ListItem Text="EMPTY GATE IN - ICD" Value="2"></asp:ListItem>
                                <asp:ListItem Text="OUT FOR STUFFING" Value="3"></asp:ListItem>
                                <asp:ListItem Text="LOADED GATE IN" Value="4"></asp:ListItem>
                                <asp:ListItem Text="RAIL OUT" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            &nbsp;
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
            <td align="left" valign="top">
                <div style="height: 390px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="10">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Sr" Width="30px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrJobNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Job No"
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrBookingNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking No" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrBookingDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking Date" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Line"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrFromPort" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="From Port" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrICD" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrAllotmentDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Allotment Date" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrContNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrContSize" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Size" Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrContType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Type" Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrStatus" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Status"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrAgeingDays" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Ageing (Days)" Width="70px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="13">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CONT_JO_NO" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BOOKING_NO" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BOOKING_DATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_PORT" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PICKUP_DATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" />
                                            <asp:BoundField ItemStyle-Width="40px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="40px" DataField="CONT_TYPE" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="STATUS" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="AGEING_DAYS" />
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
