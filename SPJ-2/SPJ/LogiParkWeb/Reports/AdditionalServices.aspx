<%@ Page Title="eLOGiPark::Additional Service Report" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AdditionalServices.aspx.vb" 
    Inherits="Reports_AdditionalServices" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Additional Services Report" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red">
                </asp:Label>
            </td>
        </tr>
        
    </table>
    <table width="100%">
        <tr>
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate"
                                autocomplete="off">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" autocomplete="off"
                                CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>
                       <%-- <td style="text-align: right">
                            <asp:Label ID="lblDocNo" runat="server" Text="Job No" CssClass="FormLabel"></asp:Label>
                        </td>
                         <td style="text-align: left">
                            <asp:TextBox ID="textDocNo" runat="server" ToolTip="Document No - Container Number/SB/BOE"
                                CssClass="FormTextBoxSmall">
                            </asp:TextBox>
                            
                        </td>--%>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" OnClientClick="return Display Validation();"
                                Text="Display" CssClass="FormButton" />
                                      <asp:Button ID="btnExport" Width="80px" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 380px; width: 100%; overflow: auto;">
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="15">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label>
                                <asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server">
                                </asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="19">
                                <div id="AdditionalServices" style="height: 330px; overflow: auto;">
                                    <asp:GridView ID="gvExportBooking" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" HeaderStyle-CssClass="RepHead">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderText="Sr. No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CONT_JO_NO" HeaderText="Job No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="TERMINAL_NAME" HeaderText="Terminal Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="300px" DataField="CUSTOMER_NAME" HeaderText="Billing Party"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CONT_NO" HeaderText="Cont No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CONT_SIZE" HeaderText="Size"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="350px" DataField="SERVICE_NAME" HeaderText="Service Name"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SERVICE_TYPE" HeaderText="Service Type"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="QNTY" HeaderText="Qnty"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="EX_RATE" HeaderText="Ex Rate"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="CURRENCY" HeaderText="Currency"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="RATE" HeaderText="Rate"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" HeaderText="Created By"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CREATED_ON" HeaderText="Created On"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
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

