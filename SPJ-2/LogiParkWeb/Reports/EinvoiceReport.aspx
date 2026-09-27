
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EinvoiceReport.aspx.vb" Inherits="Reports_EinvoiceReport" Title="eLOGiRail :: E-Invoice Report"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="E-Invoice Report" CssClass="FormLabelTitle"> </asp:Label>
            </td>
            <td valign="top" style="width: 100%">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr valign="top">
            <td>
                <hr />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr align="left" valign="top">
            <td style="text-align: right">
                <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="textFromDate" AutoComplete="off" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate"> </asp:TextBox>
                <span class="mandatory" style="vertical-align: top;">*</span>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="textFromDate" />
                &nbsp;
                <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                <asp:TextBox ID="textToDate" AutoComplete="off" runat="server" ToolTip="To Date" CssClass="FormTextBoxDate"> </asp:TextBox>
                &nbsp; <span class="mandatory" style="vertical-align: top;">*</span>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                    TargetControlID="textToDate" />
                
                
                <asp:Label ID="lblDocType" runat="server" Text="Status" CssClass="FormLabel"></asp:Label>
                <asp:DropDownList ID="lstDocType" Width="100px" runat="server" ToolTip="Status"
                    CssClass="FormListBoxSmall">
                    <asp:ListItem Text="--ALL--" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="E-Invoice Pending" Value="EP"></asp:ListItem>
                      <asp:ListItem Text="E-Invoice Pending Due to Error" Value="ER"></asp:ListItem>
                    <asp:ListItem Text="E-Invoice Generated" Value="EG"></asp:ListItem>
                    <asp:ListItem Text="E-Invoice Cancelled" Value="EC"></asp:ListItem>
                    <asp:ListItem Text="Invoice Cancelled" Value="IC"></asp:ListItem>
                    <asp:ListItem Text="E-Invoice Cancel Pending  Due to Error" Value="NM"></asp:ListItem>
                </asp:DropDownList>
                
                &nbsp;
                <asp:Button ID="btnDisplay" runat="server" class="FormButton" Text="Display" />
                <asp:Button ID="btnExcel" runat="server" class="FormButton" Text="Excel" />
                <asp:Button class="FormButton" ID="btnExit" runat="server" Text="Exit" PostBackUrl="~/Home.aspx" />
            </td>
        </tr>
        <tr style="height: 12px;">
            <td>
            </td>
        </tr>
    </table>
    <table id="tblReport" runat="server" cellspacing="0">
        <tr>
            <td colspan="7">
                <div style="height: 315px; overflow: auto;">
                                  
                    <asp:GridView ID="gvInvoiceListAll" AlternatingRowStyle-CssClass="FormListBoxLarg"
                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" 
                        FooterStyle-CssClass="RepheaderNew" ShowFooter="false"  OnRowCommand="gvInvoiceReport_RowCommand" >
                      <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:ButtonField ControlStyle-Width="120px" DataTextField="INVOICE_REF_NO" CommandName="Line" ItemStyle-HorizontalAlign="Left"  HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew"  />
                                                                                     
                            <asp:BoundField ItemStyle-Width="80px" DataField="INVOICE_DATE" HeaderText="Invoice Date"
                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                            <asp:BoundField ItemStyle-Width="180px" DataField="EINVOICE_STATUS" HeaderText="Status"
                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                            <asp:BoundField ItemStyle-Width="110px" DataField="EINVOICE_DATE" HeaderText="E-Invoice Date"
                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                            <asp:BoundField ItemStyle-Width="210px" DataField="IRN" HeaderText="IRN"
                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                            <asp:BoundField ItemStyle-Width="210px" DataField="ERROR_MESSAGE" HeaderText="Error Message"
                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                  <asp:TemplateField ItemStyle-Width="0px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("INVOICE_REF_NO") %>' />
                                                <asp:HiddenField ID="hdnInvoiceNo" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                                 <asp:HiddenField ID="hdnServiceType" runat="server" Value='<%# Eval("SERVICE_TYPE") %>' />
                                                </ItemTemplate>

                                        </asp:TemplateField>
                                                   </Columns>
                      
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" style="vertical-align: bottom;">
        <tr>
            <td style="width: 120px" align="left">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
            <td align="center" style="width: 80%">
            </td>
            <td style="width: 120" align="left">
                <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

