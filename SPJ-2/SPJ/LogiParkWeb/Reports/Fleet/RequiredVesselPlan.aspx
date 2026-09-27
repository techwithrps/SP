<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RequiredVesselPlan.aspx.vb"
    MasterPageFile="~/MasterPage.master" Inherits="Reports_Fleet_RequiredVesselPlan"
    Title="eLOGiFleet :: Vessel Planing" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Required Vessel Details" CssClass="FormLabelTitle">
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
                        <td style="text-align: right">
                            <asp:Label ID="LblLine" runat="server" Text="Line " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="190px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblPol" runat="server" Text="POL" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label" Width="100px">
                            </asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblInvStatus" runat="server" Text="Status" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstInvoiceStatus" runat="server" ToolTip="Document Type" Width="150px"
                                CssClass="ddlMedium">
                                <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Updated" Value="U"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
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
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                        runat="server" AlternatingRowStyle-CssClass="FormLabel">
                                        <RowStyle Font-Size="8pt"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="Repheader">
                                                <ItemStyle Width="25px" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CONT_NO" HeaderText="Container No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="250px" DataField="CONSINGEE_NAME" HeaderText="Consignee"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="Shipping Line"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="FPOD" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="POL" HeaderText="POL" HeaderStyle-CssClass="Repheader">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="LINE_HANDOVER_DATE" HeaderText="Line Handover Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_NO" HeaderText="Train Number"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="TRAIN_OUT_DATE" HeaderText="Rail Out Date"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CURRENT_ETD" HeaderText="Required ETD"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="REQUIRED_VESSEL" HeaderText="Required Vessel"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="CURRENT_ETA" HeaderText="ETA"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="AGEING" HeaderText="Transit Time"
                                                HeaderStyle-CssClass="Repheader"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>
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
