<%@ Page Title="eLOGiFleet:: Sales Vs Purchase" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="SaleVsCostServiceWiseNew.aspx.vb" Inherits="Reports_Fleet_SaleVsCostServiceWiseNew"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Sales Vs Purchase"
                    CssClass="FormLabelTitle">
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
                            <span class="mandatory">
                                <asp:TextBox ID="textFromDate" runat="server" Text="" CssClass="FormTextBoxDate"></asp:TextBox>
                                *</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <span class="mandatory">
                                <asp:TextBox ID="textToDate" runat="server" Text="" CssClass="FormTextBoxDate"></asp:TextBox>
                                *</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtCustomer" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <span class="mandatory">
                                <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer Name" Width="150px"
                                    CssClass="ddlMedium">
                                </asp:DropDownList>
                                *</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblService" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstService" runat="server" ToolTip="Transaction Type" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstPol" runat="server" ToolTip="POL" Width="150px" CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="LblPod" runat="server" Text="POD" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstPod" runat="server" ToolTip="POL" Width="150px" CssClass="ddlMedium">
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
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 390px; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="11">
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
                                <asp:Label ID="lblrPickup" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Pickup"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrPartyName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer Name" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblRBlNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BL No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrService" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Service" Width="200px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sale Line"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblr1Line" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Purchase Line"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCFS" CssClass="FormLabel" runat="server" Font-Bold="True" Text="CFS"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrPol" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrFPOD" CssClass="FormLabel" runat="server" Font-Bold="True" Text="FPOD"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblSaleExRate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Sale Ex. Rate" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblRSaleRate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Sale Rate" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrSale" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sale"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblPExRate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="P. Ex. Rate"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblrPurchaseRate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Purchase Rate" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrPurchase" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Purchase" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrMargin" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Margin"
                                    Width="100px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="19">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PICKUP" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE1" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CFS" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POL" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="S_EX_RATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SALE_RATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SALES_PRICE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="P_EX_RATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="P_RATE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PURCHASE" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MARGIN" />
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
