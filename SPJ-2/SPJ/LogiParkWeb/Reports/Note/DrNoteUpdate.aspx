<%@ Page Title="eLOGiFreight:: Dr Note Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DrNoteUpdate.aspx.vb" Inherits="Reports_Note_DrNoteUpdate"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Dr Note Update"
        CssClass="FormLabelTitle"></asp:Label>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
    <br />
    <hr />
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none;">
        <tr>
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="LblContNO" runat="server" Text="Debit Note No" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:HiddenField ID="HdnDrId" runat="server" Value="" />
                                                <asp:TextBox ID="TextGrno" runat="server" MaxLength="20" onkeypress="kp_integer();"
                                                    CssClass="textbox" Width="120px" Enabled="false" ToolTip="Container Number">
                                                </asp:TextBox>
                                                <asp:Button ID="btnSearchGr" runat="server" Visible="false" Text="GO" CssClass="FormButton" />
                                            </td>
                                            <td rowspan="13" width="30px" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblJoNo" runat="server" Text="Balance Amount" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textjoNo" Width="80px" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Visible="false" Text="Edit" CssClass="FormButton" />
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
