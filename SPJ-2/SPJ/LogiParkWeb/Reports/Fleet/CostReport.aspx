<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CostReport.aspx.vb" MasterPageFile="~/MasterPage.master"
    Inherits="Reports_Fleet_CostReport" Title="eLOGiFleet :: Cost Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Cost Report" Width="400px" CssClass="FormLabelTitle">
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
            <td>
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
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
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="12">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" DataField="" HeaderText="Sr No" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="BL_NO" HeaderText="BL No"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="LINER_INV_NO" HeaderText="Liner Inv No"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="LINER_INV_DATE" HeaderText="Liner Inv Date"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="130px" DataField="LINE" HeaderText="Shipping Line"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="Service"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="BASE_RATE" HeaderText="Base Rate" ItemStyle-HorizontalAlign="Right"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TAX_PERC" HeaderText="Tax %" ItemStyle-HorizontalAlign="Right"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TAX_AMT" HeaderText="Tax Amount" ItemStyle-HorizontalAlign="Right"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TOTAL" HeaderText="Total" ItemStyle-HorizontalAlign="Right"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="EX_RATE" HeaderText="Ex Rate" ItemStyle-HorizontalAlign="Right"  HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>

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
