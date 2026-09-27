<%@ Page Title="eLoGiFreight::All Party Account-Customer Care" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="APACustomerCare.aspx.vb" Inherits="Reports_Fleet_APACustomerCare" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="GST Invoice Report" CssClass="FormLabelTitle">
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
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="txtFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>


                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
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
                        <%-- <tr class="RepHead">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr" Width="30px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrCustomerName" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer Name" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No." Width="130px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Date" Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrIGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="IGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="CSGT" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrSGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="SGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrTotalAmt" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total" Width="100px"></asp:Label>
                            </td>

                            <td style="background-color: White; width: 15px;"></td>
                        </tr>--%>
                        <tr>
                            <td colspan="10">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="True" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SHIPPER_NAME" HeaderText="Shipper" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CONSINGEE_NAME" HeaderText="Consignee" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" HeaderText="BL No." HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No." HeaderStyle-CssClass="RepHead" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No." HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Line" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SB_NO" HeaderText="SB NO." HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CUSTOMS_HANDOVER_DATE" HeaderText="Custom Handover" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_NO" HeaderText="Party Invoice No" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_DATE" HeaderText="Party Invoice Date" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CFS" HeaderText="CFS " HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="POD" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_NO" HeaderText="Train No" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT_ARRIVAL" HeaderText="Port Gate In Date" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="REQUIRED_VESSEL" HeaderText="Vessel Name" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="REQUIRED_ETD" HeaderText="ETD" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SAILED" HeaderText="Sail Date" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CURRENT_ETA" HeaderText="ETA" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSIT_TIME" HeaderText="Transit Time" HeaderStyle-CssClass="RepHead" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SHIPMENT_STATUS" HeaderText="Shipment Status" HeaderStyle-CssClass="RepHead" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="720px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Width="70px" CssClass="FormLabel "></asp:Label>
                                <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

