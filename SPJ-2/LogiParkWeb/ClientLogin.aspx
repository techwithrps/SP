<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClientLogin.aspx.vb" Inherits="ClientLogin"
    Theme="Forms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: Freight Forwarding System</title>
    
    <script type="text/javascript" src="Script/device-uuid.min.js"></script>
    <script type="text/javascript">
        function GetMacAddress() {
            var uuid = new DeviceUUID().get();
            var du = new DeviceUUID().parse();
            var dua = [
                du.language,
                du.platform,
                du.os,
                du.cpuCores,
                du.isAuthoritative,
                du.silkAccelerated,
                du.isKindleFire,
                du.isDesktop,
                du.isMobile,
                du.isTablet,
                du.isWindows,
                du.isLinux,
                du.isLinux64,
                du.isMac,
                du.isiPad,
                du.isiPhone,
                du.isiPod,
                du.isSmartTV,
                du.pixelDepth,
                du.isTouchScreen
            ];
            var uuid2 = du.hashMD5(dua.join(':'));
            var uuid3 = du.hashInt(dua.join(':'));
            document.getElementById("hdnMacAddress").value = uuid + uuid2 + uuid3;
        }
    </script>

    <style type="text/css">
    .FormLabel {
    font-size: 14px !important;
    color: red !important;
    Font-weight: bold;
}

        .style2 {
            height: 24px;
            font-family: Verdana;
            font-size: large;
            vertical-align: top;
            text-align: left;
            color: #3366FF;
            background-image: url('images/pagebghome.gif');
            background-repeat: repeat-y;
        }

        .FormTextBoxMedium {
        }

        .style8 {
            height: 28px;
        }

        .auto-style1 {
            font-family: Verdana;
            font-size: 10pt;
            color: #000000;
        }

        .auto-style4 {
            height: 55px;
        }

        .auto-style5 {
            font-size: small;
        }

        .auto-style6 {
            font-family: Verdana;
            font-size: 10pt;
            color: #000000;
            text-decoration: underline;
        }
        img#Image1 {
    height: 440px;
    float: right;
}
        a#lnkForgetPassword {
    font-size: 13px;
    margin-right: 22px;
    margin-bottom: 5px;
    color:#144a9d;
}
    </style>
</head>
<body style="height: 100%; margin-top: -10px; margin-left: -.1px; margin-right: -.1px;" onload="GetMacAddress();">
    <form id="form1" runat="server" style="width: 100%">
        <div class="auto-style4" style="background-color: #282B3E; vertical-align: middle;">
            <br />
            &nbsp;&nbsp; <a class="navbar-brand">
                <asp:Label ID="Label5" runat="server" Font-Size="18pt" Style="font-weight: 700; font-size: 14pt; font-family: Verdana; color: white;"
                    Text="eLOGiFreight Ver. 1.0"></asp:Label>
            </a>
        </div>
        <div>
            <table border="0" style="vertical-align: middle; height: 100%; width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle" class="style2">
                        <table width="100%">
                            <tr>
                                <td align="center" style="height: 470px; width: 750px; padding-top:20px;">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SPJ-Group.jpg"/>
                                </td>
                                <td align="center" valign="middle">
                                    <table style="padding: 10px; margin-top:70px" >
                                        <tr>
                                            <td align="center" colspan="2" class="FormLabel">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="auto-style5" align="center">
                                                <strong>SIGN IN </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label1" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblUserName" runat="server" Text="Login ID" CssClass="auto-style1"></asp:Label>
                                                <asp:HiddenField ID="hdnMacAddress" Value="" runat="server"/>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox AutoCompleteType="Disabled" AutoComplete="off" ID="textUserName" CssClass="FormTextBoxMedium"
                                                    Height="20px" onkeypress="capLock(event)" placeholder="User Name..." runat="server"
                                                    MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPassword" runat="server" CssClass="auto-style1" Text="Password"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPassword" runat="server" placeholder="Password..." CssClass="FormTextBoxMedium"
                                                    onkeypress="capLock(event)" TextMode="Password" MaxLength="15" Height="20px"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                <td></td>
                                <td style="text-align: right">
                                    <a id="lnkForgetPassword" href="ChangePassword.aspx" style="text-decoration: none;">Forgot Password?</a>
                                </td>
                            </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value="0" />
                                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSubmit" runat="server" Visible="true" Text="Submit" CssClass="FormButton" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblCompany" runat="server" CssClass="auto-style1" Text="Company"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstCompany" CssClass="FormListBoxMedium" runat="server" ForeColor="Black"
                                                    TextMode="Company" Width="222px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblBranch" runat="server" CssClass="auto-style1" Text="Branch"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstBranch" CssClass="FormListBoxSmall" Width="222px" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <%--   ---------------------------%>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtEntCaptcha" runat="server" onCopy="return false" AutoComplete="OFF"
                                                    onPaste="return false" Width="218px" CssClass="TextBoxPwd"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="text-align: left; width: 250px">
                                                <asp:Label ID="TxtCaptcha" Height="30px" Width="120px" Font-Bold="true" Style="font-weight: 700"
                                                    Font-Size="12" BackColor="#CCFFFF" Font-Names="Verdana" runat="server" ForeColor="#CC6600"></asp:Label>
                                                <asp:ImageButton ID="BtnRef" runat="server" Width="20px" ImageUrl="~/Images/refresh.png"
                                                    Height="20px" />
                                            </td>
                                        </tr>
                                        <%-------------------------%>
                                        <tr>
                                            <td style="text-align: center">&nbsp;
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Button ID="btnLogin" runat="server" Visible="true" Text="Login" CssClass="FormButton" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <div id="divMayus" class="FormLabel" style="visibility: hidden; color: red;">
                                                    Caps Lock is on.
                                                </div>
                                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="justify" style="width: 300px; font-family: Verdana; font-size: 8pt;">Access of this application is governed by the credential policy of the company.You
                                            are liable to be held responsible for any kind of the unauthorized access/misuse
                                            of this application.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hdnwrongloginattempts" runat="server" Value="0" />
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle" style="height: 50px; background-image: url(images/pagebghome.gif); background-repeat: repeat-y; vertical-align: top; text-align: center">&nbsp;
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="bottom" align="center" style="font-size: small; font-family: Verdana">© 2019 eLOGiSol, All rights reserved.
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
