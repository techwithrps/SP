<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/ChangeRequest.aspx.vb" Inherits="Master_Admin_ChangeRequest"
    Title="eLOGiFreight:: Change Request" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Change Request"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
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

                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblCrNo" runat="server" Text="CR No" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:HiddenField ID="hdnTaskId" runat="server" />
                                                <asp:HiddenField ID="hdnCreateBy" runat="server" />
                                                <asp:TextBox ID="TextCrNo" runat="server" CssClass="FormTextBoxLarg" Enabled="false" Width="150px"></asp:TextBox>
                                            </td>
                                            
                                        </tr>

                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCRDate" runat="server" Text="CR Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCRdate" runat="server" ToolTip="CR Date" CssClass="FormTextBoxDate" Enabled="false" Width="150px"></asp:TextBox>
                                            </td>
                                       
                                        </tr>

                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblTask" runat="server" CssClass="FormLabel" Text="Task"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstTask" runat="server" CssClass="FormListBoxLarg" ToolTip="Task">
                                                </asp:DropDownList>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblTaskHeader" runat="server" Text="Task Header" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textTaskHeader" runat="server" ToolTip="Task Header" CssClass="FormTextBoxLarg"></asp:TextBox>
                                            </td>
                                         
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblDescription" runat="server" CssClass="FormLabel" Text="Description"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textDiscription" Rows="3" runat="server" CssClass="FormTextBoxLarg"
                                                    Height="50px" TextMode="MultiLine" onkeypress="kp_convert_upper();" MaxLength="450"
                                                    Width="300px" ToolTip="Problem Discription"></asp:TextBox>
                                                <span class="mandatory">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCloseRemark" runat="server" CssClass="FormLabel" Text="Close Remark"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCloseRemark" Rows="3" runat="server" CssClass="FormTextBoxLarg"
                                                    Height="50px" TextMode="MultiLine" onkeypress="kp_convert_upper();" MaxLength="450"
                                                    Width="300px" ToolTip="Close Discription"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCloseDate" runat="server" Text="Close Date" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCloseDate" runat="server" ToolTip="colseDate Date" CssClass="FormTextBoxDate"
                                                    Width="150px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textCloseDate" />
                                                <span class="mandatory">*</span></td>
                                           
                                           
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 100%; width: 100%; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="100%">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
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
