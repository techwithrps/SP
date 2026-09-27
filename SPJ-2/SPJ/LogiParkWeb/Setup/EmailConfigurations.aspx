<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="EmailConfigurations.aspx.vb" Inherits="Setup_EmailConfigurations" Title="eLOGiFleet :: E-Mail Configurations"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="E-Mail Configurations"
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
                                    <table align="center">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTitle" runat="server" class="label" Text="Title ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTitle" runat="server" class="textbox" ToolTip="Title" Width="250px"></asp:TextBox>
                                                <asp:HiddenField ID="hdnMenuId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblToEmailId" runat="server" class="label" Text="To Email ID ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textToEmailId" runat="server" Height="35" Rows="3" class="textbox"
                                                   onblur="return validateEmail()" TextMode="MultiLine" ToolTip="To Email ids" Width="250px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCcEmailId" runat="server" class="label" Text="Cc Email ID ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCcEmailId" runat="server" Height="35" Rows="3" class="textbox"
                                                 onblur="return validateEmail()"   TextMode="MultiLine" ToolTip="Cc Email Ids" Width="250px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblBCcEmailId" runat="server" class="label" Text="BCc Email ID ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBCcEmailId" runat="server" Height="35" Rows="3" class="textbox"
                                                 onblur="return validateEmail()"   TextMode="MultiLine" ToolTip="BCc Email Ids" Width="250px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblSubject" runat="server" class="label" Text="Subject ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textSubject" runat="server" class="textbox" MaxLength="100" ToolTip="Subject" Width="250px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblBody" runat="server" class="label" Text="Body ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="textBody" runat="server" Height="35" Rows="3" class="textbox" TextMode="MultiLine"
                                                    ToolTip="Body" Width="250px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblSignature" runat="server" class="label" Text="Signature ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="textSignature" runat="server" Height="35" Rows="3" class="textbox"
                                                    ToolTip="Signature" TextMode="MultiLine" Width="250px">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 320px; width: 300px; border-left-color: Black;
                                    vertical-align: top;">
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
                                                <asp:ImageButton ID="btnEdit" Visible="false" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
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
