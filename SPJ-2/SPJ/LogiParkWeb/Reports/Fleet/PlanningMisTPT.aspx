<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PlanningMisTPT.aspx.vb" MasterPageFile="~/MasterPage.master"
    Inherits="Reports_Fleet_MisTPT" Title="eLOGiFleet :: Transport MIS" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Planning - Transport MIS" Width="400px" CssClass="FormLabelTitle">
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
                            <span class="mandatory" style="vertical-align: top;">
                            
                            <ajaxToolkit:CalendarExtender ID="textFromDate0_CalendarExtender" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                            *</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">
                            *</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right"><asp:Label ID="Label3" runat="server" Text="Report Name" CssClass="label"></asp:Label>
                        </td>
                        <td><asp:DropDownList ID="lstReportName" runat="server" CssClass="ddlMedium" Width="130px">
                                            <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Fooding Report"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pre Fuel Report"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Post Fuel Report"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Driver Salary Report"></asp:ListItem>
                                        </asp:DropDownList></td>
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
                            <td colspan="21">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Detail Report"></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                             <td colspan="7">
                                <asp:Label ID="Label1" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Summary Report"></asp:Label><asp:Label
                                    ID="Label2" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="21">
                            
                    <asp:GridView ID="gvRepoprt" ShowHeader="True" AutoGenerateColumns="true"
                        RowStyle-Font-Size="Small" runat="server" Height="50px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-CssClass="Repheader" >
                        <Columns>
                             
                        </Columns>
                    </asp:GridView>
</td>
   <td colspan="21" align="right" valign="top">
                            
                    <asp:GridView ID="gvSummary" ShowHeader="True" AutoGenerateColumns="true"
                        RowStyle-Font-Size="Small" runat="server" Height="50px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-CssClass="Repheader" >
                        <Columns>
                             
                        </Columns>
                    </asp:GridView>
</td>
</tr>
     </table>                               
     </div>
                      
            </td>
        </tr>
    </table>
    
</asp:Content>
