<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ContainerWiseInvoiceReport.aspx.vb" Inherits="Reports_Imports_ContainerWiseInvoiceReport"
    Title="eLOGiPark:: Invoice Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

</script>
<style>
table#ctl00_ContentPlaceHolder1_gvinvoicePending tbody tr th:nth-last-child(2), table#ctl00_ContentPlaceHolder1_gvinvoicePending tbody tr td:nth-last-child(2){
min-width:600px;
}
</style>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="250px" Text="Container Wise Invoice Report"
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
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" AutoComplete="OFF"
                                CssClass="FormTextBoxDate" Width="70px">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="txtToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" AutoComplete="OFF"
                                CssClass="FormTextBoxDate" Width="70px">
                            </asp:TextBox>
                            <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblDOC_TYPE" runat="server" Text="Doc Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstDocType" runat="server" Width="90px" ToolTip="Doc Type"
                                CssClass="FormListBoxMedium">
                                <asp:ListItem Text="All" Value="" />
                                <asp:ListItem Text="Domestic" Value="D" />
                                <asp:ListItem Text="Export" Value="E" />
                                <asp:ListItem Text="Empty" Value="M" />
                                <asp:ListItem Text="Import" Value="I" />
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblContNo" runat="server" Text="Container No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContNo" runat="server" ToolTip="Container No" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblBLNo1" runat="server" Text="BL No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textBlNo1" runat="server" ToolTip="BL No" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomer" runat="server" Text="Billing Party" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" Width="300px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblService" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstService" runat="server" Width="300px" ToolTip="Service"
                                CssClass="FormListBoxMedium">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Visible="false" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="Button1" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 500px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="22">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr. No"
                                    Width="32px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrcontNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Container No"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContSize" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Size" Width="50px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Type" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCustomerName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer Name" Width="200px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPartyinvNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Party Inv No" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblJobNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="JOB No" Width="170px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLine" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Shipping Line" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBLNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BL No"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblICDOutdate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Out Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblICDinDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gate In Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCFS" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Clearence Port"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPol" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Loading Port"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblHandoverDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Handover Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSOb" CssClass="FormLabel" runat="server" Font-Bold="True" Text="SOB Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPOD" CssClass="FormLabel" runat="server" Font-Bold="True" Text="POD"
                                    Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblCountry" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Country"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDocumentType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Doc Type" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrServiceName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Service Name" Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceRefNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Invoice No" Width="120px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Invoice Date" Width="85px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount"
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTaxAMount" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Tax Amount" Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTotal" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total Amount"
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRemarks" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Remarks"
                                    Width="80px"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="26">
                                <div style="height: 600px; overflow: auto;">
                                    <asp:GridView ID="gvinvoicePending" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server" HeaderStyle-CssClass="RepheaderNew">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderText="Sr. No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" HeaderText="Size" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE" HeaderText="Type" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER_NAME" HeaderText="Customer Name" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="PARTY_INV_NO" HeaderText="Party Inv No" />
                                            <asp:BoundField ItemStyle-Width="170" DataField="JOB_NO" HeaderText="JOB No" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="LINE" HeaderText="Shipping Line" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="BL_NO" HeaderText="BL No" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="SB_NO" HeaderText="SB No" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="SB_DATE" HeaderText="SB Date" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="ICD_OUT_DATE" HeaderText="ICD Out Date" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="ICD_IN_DATE" HeaderText="Gate In Date" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="CFS" HeaderText="Clearence Port" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="POL" HeaderText="Loading Port" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="LINE_HANDOVER_DATE" HeaderText="Handover Date" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="SAILED" HeaderText="SOB Date" />
                                            <asp:BoundField ItemStyle-Width="130" DataField="TRAIN_OUT_DATE" HeaderText="Railout Date" />
                                            <asp:BoundField ItemStyle-Width="150" DataField="PORT" HeaderText="POD" />
                                            <asp:BoundField ItemStyle-Width="110" DataField="COUNTRY_NAME" HeaderText="Country Name" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TRIP_TYPE" HeaderText="Doc Type" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SERVICE_NAME" HeaderText="Service Name" />
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew" HeaderText="Invoice Ref No">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkInvoice" Width="120px" CommandArgument='<%# Eval("INVOICE_REF_NO" )%>'
                                                        Text='<%#Eval("INVOICE_REF_NO")%>' OnClick="checkPrint"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew" HeaderText="Cr Ref No">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="lnkInvoice1" Width="120px" CommandArgument='<%# Eval("CR_REF_NO")%>'
                                                        Text='<%#Eval("CR_REF_NO")%>' OnClick="OnClickHandlerStatusCR"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="85px" DataField="INVOICE_DATE" HeaderText="Invoice Date" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="BILL_AMOUNT" ItemStyle-CssClass="FormTextBoxNumeric" HeaderText="Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TAX" ItemStyle-CssClass="FormTextBoxNumeric" HeaderText="Tax Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="AMOUNT" ItemStyle-CssClass="FormTextBoxNumeric" HeaderText="Total Amount" />
                                            <asp:BoundField ItemStyle-Width="80px" DataField="INVOICE_NOTE" ItemStyle-CssClass="FormTextBoxNumeric remarks" HeaderText="Remarks" />
                                            <asp:TemplateField ItemStyle-Width="0px">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                    <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
