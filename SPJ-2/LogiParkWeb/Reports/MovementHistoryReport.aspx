<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MovementHistoryReport.aspx.vb" Inherits="Reports_MovementHistoryReport"
    Title="Logipark :: Movement History Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Movement History Report" CssClass="FormLabelTitle">
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
                            <asp:Label ID="lblContNo" runat="server" Text="Container No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContNo" runat="server" ToolTip="Container No" Width="120px" CssClass="FormTextBoxDate"
                                onkeypress="kp_convert_upper();" MaxLength="11">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
                        <td style="text-align: right">
                            &nbsp;
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">
                        </td>
                    </tr>
                </table>
                <table id="tblCont" runat="server">
                    <tr>
                        <td style="text-align: left;">
                            <asp:Label ID="lblrContSize" CssClass="FormLabel" runat="server" Visible="false"
                                Text="Size" Width="30px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textSize" runat="server" ToolTip="Size" Enabled="false" Visible="false"
                                Width="20px" CssClass="RptFormTextBoxMedium">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblrContType" CssClass="FormLabel" runat="server" Visible="false"
                                Text="Type" Width="30px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContType" runat="server" ToolTip="Type" Enabled="false" Visible="false"
                                Width="20px" CssClass="RptFormTextBoxMedium">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Visible="false" Text="Doc Type"
                                Width="55px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textDocType" runat="server" ToolTip="Doc Type" Enabled="false" Visible="false"
                                Width="60px" CssClass="RptFormTextBoxMedium">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblTerminal" CssClass="FormLabel" runat="server" Visible="false" Text="Terminal"
                                Width="50px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textTerminal" runat="server" ToolTip="Terminal" Enabled="false"
                                Visible="false" Width="80px" CssClass="RptFormTextBoxMedium">
                            </asp:TextBox>
                        </td>
                         <td style="text-align: left">
                            <asp:Label ID="lblHandlingMode" CssClass="FormLabel" runat="server" Visible="false" Text="Handling Mode"
                                Width="85px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textHandlingMode" runat="server" ToolTip="Handling Mode" Enabled="false"
                                Visible="false" Width="80px" CssClass="RptFormTextBoxMedium">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div>
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="15">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew" style="height:30px">
                            <td style="text-align: center">
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Sr. No" Width="52px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblActivity" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Activity Description" Width="351px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblDocNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Document No"
                                    Width="200px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblActivityDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Activity Date" Width="144px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblUserId" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="User Id" Width="144px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblremarks" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Remarks" Width="144px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div style="height:500px; width: 100%; overflow: auto;" >
                                    <asp:GridView ID="gvMovementHistory" ShowHeader="False" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="48px" DataField=""></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="350px" DataField="ACTIVITY_NAME"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="DOC_NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="ACTIVITY_DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="CREATED_BY"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="REMARKS"></asp:BoundField>
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
