<%@ Page Title="eLOGiFreight::Vehicle Running Report" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="VehicleRunningStatusReport.aspx.vb" Inherits="Reports_Fleet_Vehicle_Running_Status_Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vehicle Running Status Report" CssClass="FormLabelTitle">
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
                            <asp:TextBox ID="textFromDate" autocomplete="off" runat="server" ToolTip="From Date" CssClass="textbox"
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
                            <asp:TextBox ID="textToDate" autocomplete="off" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
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
                            <td colspan="17">
                                <div style="height: 350px; width: 1000px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server"
                                        ShowHeader="true">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                   
                                            <asp:BoundField ItemStyle-Width="20px" DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CFS" HeaderText="In Terminal"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                             <asp:BoundField ItemStyle-Width="220px" DataField="SHIPPER" HeaderText="Shipper"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                           <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Container No"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_LOCATION" HeaderText="Factory Location"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VEHICLE_NO" HeaderText="Vehicle No"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="ICD_OUT_DATE" HeaderText="ICD Out"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="120px" DataField="FACTORY_IN_DATE" HeaderText="Factory In"
                                                HeaderStyle-CssClass="RepheaderNew" ControlStyle-CssClass="FormLabel"></asp:BoundField>
                                            
<%--                                            <asp:BoundField ItemStyle-Width="120px" DataField="ICD_IN" HeaderText="ICD In" HeaderStyle-CssClass="RepheaderNew"
                                                ControlStyle-CssClass="RepheaderNew"></asp:BoundField>--%>
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
