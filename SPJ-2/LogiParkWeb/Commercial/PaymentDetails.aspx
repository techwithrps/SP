<%@ Page Title="eLOGiFreight:: Payment History" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="PaymentDetails.aspx.vb" Inherits="Commercial_PaymentDetails"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Payment Details"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblInvoiceNo" runat="server" CssClass="FormLabel" Text="Inovice No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtInvoiceNo" Width="150px" runat="server" CssClass="FormTextBoxMedium"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnDisplay" runat="server" CssClass="FormButton" Text="GO" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table id="tblReport" runat="server">
                                    <tr>
                                        <td>
                                            <div style="overflow: auto;">
                                                <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                                    ShowFooter="False" runat="server">
                                                    <HeaderStyle CssClass="RepHead" />
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="" HeaderText="Sr." />
                                                        <asp:BoundField HeaderText="Receipt No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="RECEIPT_REF_NO" ItemStyle-Width="100px"></asp:BoundField>
                                                        <asp:BoundField HeaderText="UTR / Cheque No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="CHEQUE_NO" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Paid Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="CR_AMOUNT" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right">
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="TDS" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                            DataField="TDS" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Adjustment Against Credit Note" HeaderStyle-CssClass="GVHeadText"
                                                            ControlStyle-CssClass="FormLabel" DataField="CR_AMT" ItemStyle-Width="100px"
                                                            ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                                    </Columns>
                                                    <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
