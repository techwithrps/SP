<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClientLogin.aspx.vb" Inherits="ClientLogin"
    Theme="Forms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: Freight Forwarding System</title>
    <style type="text/css">
        .FormLabel
        {
            font-size: small;
            color: #000000;
        }
        .style2
        {
            height: 24px;
            font-family: Verdana;
            font-size: large;
            vertical-align: top;
            text-align: left;
            color: #3366FF;
            background-image: url('images/pagebghome.gif');
            background-repeat: repeat-y;
        }
        .FormTextBoxMedium
        {
        }
        .style8
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" style="vertical-align: middle; margin-top: 15px; height: 361px;"
            cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" class="style2">
                    <strong>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/logo.png" />
                        &nbsp;</strong><asp:Label ID="Label5" runat="server" Font-Size="18pt" Style="font-weight: 700;
                            font-size: 10pt; font-family: Verdana;" Text="eLOGiFreight Ver. 1.0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="middle" style="text-align: left; background-color: #FFFFFF">
                    <hr style="height: 7px; color: #666699; font-weight: 700; background-color: #FFFFFF;" />
                </td>
            </tr>
            <tr>
                <td valign="middle" style="background-color: #FFFFFF">
                    <hr style="height: -7px; color: #666699; font-weight: 700; background-color: #FFFFFF;" />
                </td>
            </tr>
            <tr>
                <td valign="middle" style="background-color: #FFFFFF">
                    <table style="width: 292px">
                        <tr>
                            <td style="background-image: url('Images/1284140a.gif');" class="style8">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="middle" class="style2">
                    <table style="background-color: #FFFFFF">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblUserName" runat="server" Text="Login ID" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox AutoCompleteType="Disabled" ID="textUserName" CssClass="FormTextBoxMedium"
                                    runat="server" ForeColor="Black" Width="200px" MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPassword" runat="server" CssClass="FormLabel" Text="Password"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textPassword" CssClass="FormTextBoxMedium" runat="server" ForeColor="Black"
                                    TextMode="Password" Width="200px" MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:HiddenField ID="hdnStatus" runat="server" Value="0" />
                                <asp:Button ID="btnSubmit" runat="server" Visible="true" Text="Submit" CssClass="FormButton" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCompany" runat="server" CssClass="FormLabel" Text="Company"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstCompany" CssClass="FormListBoxMedium" runat="server" ForeColor="Black"
                                    TextMode="Company" Width="205px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblBranch" runat="server" CssClass="FormLabel" Text="Branch"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstBranch" CssClass="FormListBoxSmall" Width="205px" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                &nbsp;
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="btnLogin" runat="server" Visible="true" Text="Login" CssClass="FormButton" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <div id="divMayus" class="FormLabel" style="visibility: hidden; color: red;">
                                    Caps Lock is on.</div>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnwrongloginattempts" runat="server" Value="0" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="middle" style="height: 230px; background-image: url(images/pagebghome.gif);
                    background-repeat: repeat-y; vertical-align: top; text-align: center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="bottom" align="center" style="font-size: x-small; font-family: Verdana">
                                © 2014 eLOGiSol, All rights reserved.
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
