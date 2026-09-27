<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DebitNoteMapping.aspx.vb" Inherits="Reports_DebitNoteMapping" Title="eLOGiFleet:: Debit Note Mapping"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Debit Note Mapping"
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
                        <td style="text-align: right">
                            <asp:Label ID="lblDocumentType" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPurchaseType" AutoPostBack="True" runat="server" ToolTip="Purchase Type"
                                Width="100px" CssClass="ddlMedium">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                <asp:ListItem Text="Clearing & Forwarding" Value="C"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer Name" Width="150px"
                                CssClass="ddlMedium">
                            </asp:DropDownList>
                             <asp:Button ID="btnGO" runat="server" Text="GO" CssClass="FormButton" />
                        </td>
                        

                           <td align="left">
                                <asp:Label ID="lblrService" runat="server" CssClass="FormLabel" Text="Issue No."></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownCheckBoxes ID="ddchkContainer" EnableViewState="true" runat="server"
                                    CssClass="ddlMedium" Enabled="true" UseButtons="True" UseSelectAllNode="True"
                                    OnSelectedIndexChanged="ddchkContainer_SelectedIndexChanged">
                                    <Style SelectBoxWidth="200" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="200" />
                                </asp:DropDownCheckBoxes>
                            </td>
                            <asp:HiddenField runat="server" ID="hdnReceiptNo" />

                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                             <asp:Button ID="btnPDF" runat="server" Text="PDF" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table cellspacing="1" id="tblReport" runat="server">
                    <tr>
                        <td colspan="9">
                            <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="10">
                            <div style="height: 400px; overflow: auto;">
                               <asp:GridView ID="gvPaymentDetail" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" ShowFooter="True"
                                    HeaderStyle-CssClass="RepheaderNew" runat="server">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="S" HeaderText="Sale Payment Status"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="BL_NO" HeaderText="BL No" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_NO" HeaderText="Invoice No"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_DATE" HeaderText="Invoice Date"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                            <%-- <asp:BoundField ItemStyle-Width="50px" DataField="SERVICE_CODE" HeaderText="HSN/SAC" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center"></asp:BoundField>--%>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="INVOICE_AMOUNT" HeaderText="Invoice Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="DR_AMT" HeaderText="Dr Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TDS" HeaderText="TDS Amount" ItemStyle-HorizontalAlign="Right"
                                                HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TA" HeaderText="Issue Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CGST_RATE" HeaderText="CGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CGST_AMOUNT" HeaderText="CGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SGST_RATE" HeaderText="SGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SGST_AMOUNT" HeaderText="SGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="IGST_RATE" HeaderText="IGST Rate"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="IGST_AMOUNT" HeaderText="IGST Amount"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BASIC_AMOUNT" Visible="false"
                                                HeaderText="Amount" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
