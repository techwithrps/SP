<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="BulkInvoicePrintByBL.aspx.vb" Inherits="Reports_Imports_BulkInvoicePrintByBL"
    Title="eLOGiPark:: Bulk Invoice PDF Download" Theme="Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Bulk Invoice PDF Download (by B/L No)"
                    CssClass="FormLabelTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <hr />
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblCsv" runat="server" Text="CSV File (B/L No)" CssClass="FormLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:FileUpload ID="fuCsv" runat="server" ToolTip="Upload a .csv file with one column: B/L No" />
            </td>
            <td>
                <asp:Button ID="btnProcess" runat="server" Text="Download Invoices" CssClass="FormButton" OnClick="btnProcess_Click" />
                <asp:Button ID="btnDownloadZip" runat="server" Text="Download ZIP" CssClass="FormButton" Visible="false" OnClick="btnDownloadZip_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMessage" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
        </tr>
    </table>

    <table width="100%">
        <tr>
            <td>
                <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="false"
                    HeaderStyle-CssClass="RepheaderNew" RowStyle-CssClass="FormListBoxLarg"
                    AlternatingRowStyle-CssClass="FormListBoxLarg" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="BLNo" HeaderText="B/L No" />
                        <asp:BoundField DataField="InvoiceRefNo" HeaderText="Invoice Ref No" />
                        <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="FilePath" HeaderText="Saved File" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
