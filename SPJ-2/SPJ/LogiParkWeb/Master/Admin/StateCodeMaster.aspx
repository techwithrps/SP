<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/StateCodeMaster.aspx.vb" Inherits="Master_Admin_StateCodeMaster"
    Title="eLOGiFleet:: State Code Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
   
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Bank Master" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr style="height: 30px;">
                                            <td colspan="2">
                                            </td>
                                        </tr>
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
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" OnClientClick="return saveValidation();" />
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                               <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
