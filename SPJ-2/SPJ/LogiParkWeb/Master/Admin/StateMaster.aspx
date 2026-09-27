<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="StateMaster.aspx.vb" Inherits="Master_Admin_StateMaster" Title="eLOGiRail:: State Code Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="State Master" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <hr />
            </td>
        </tr>
    </table>
    <table>
        <tr valign="top">
            <td style="width: 924%; vertical-align:central;" valign="top" >
                <div id="dvControl" runat="server" style="vertical-align:central;">
                    <table style="vertical-align:central;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblStateCode" runat="server" class="FormLabel" Text="State Code">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textStateCode" MaxLength="2" runat="server"
                                    class="FormTextBoxMedium" ToolTip="State Code">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblStateName" runat="server" class="FormLabel" Text="State Name">
                                </asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textStateName" onkeypress="kp_convert_upper()" runat="server" class="FormTextBoxLarg"
                                    Width="367px" ToolTip="State Name">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblStateType" runat="server" class="FormLabel" Text="State Type">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textStateType" runat="server" class="FormTextBoxMedium" ToolTip="State Type">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblStateAddress" runat="server" class="FormLabel" Text="Branch Address">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textStateAddress" runat="server" class="FormTextBoxLarg" TextMode="MultiLine"
                                    Width="367px" Height="55px" ToolTip="State Address">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblGSTIN" runat="server" class="FormLabel" Text="GSTIN">
                                </asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textGSTIN" runat="server" class="FormTextBoxLarg" ToolTip="GSTIN">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                            </td>
                            <td style="text-align: left;">
                                <asp:HiddenField ID="hdnStateID" runat="server" Value="" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td>
                <div id="dvTreeView" cssclass="tvScrollStyle" style="height: 385px; width: 300px;
                    overflow: auto;">
                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                        Width="144px">
                    </asp:TreeView>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" style="vertical-align: bottom; height: 2px;">
        <tr>
            <td style="width: 150" align="left">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
            <td align="center" style="width: 83%">
                <asp:Button ID="btnAdd" runat="server" CssClass="FormButton" Text="Add" />
                <asp:Button ID="btnEdit" runat="server" CssClass="FormButton" Text="Edit" />
                <asp:Button ID="btnSave" runat="server" CssClass="FormButton" Text="Save" />
                <asp:Button ID="btnCancel" runat="server" CssClass="FormButton" Text="Cancel" />
                <asp:Button ID="btnExit" runat="server" CssClass="FormButton" Text="Exit" />
            </td>
            <td style="width: 90px">
            </td>
        </tr>
    </table>
</asp:Content>
