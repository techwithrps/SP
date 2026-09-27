<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/ChangePassword.aspx.vb" Inherits="ChangePassword"
    Title="LogiPark:: Change Password"Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    
    function kp_WithSpace() {
     if (event.keyCode == 32)
         event.returnValue = false;
     
 }

 function validatePassword(fld) {
    var error = "";
    var rtnval = true;
    var illegalChars = /[\W_]/; // allow only letters and numbers 
 
    if (fld.value == "") {
        //fld.style.background = 'Yellow';
        error = "You didn't enter a password.\n";
    } else if ((fld.value.length < 7) || (fld.value.length > 15)) {
        error = "The password is the wrong length. \n";
        //fld.style.background = 'Yellow';
    } else if (!((fld.value.search(/(a-z)+/)) && (fld.value.search(/(0-9)+/)))) {
        error = "The password must contain at least one numeral.\n";
        //fld.style.background = 'Yellow';
    } else {
        fld.style.background = 'White';
    }
    
    if (error.length > 0 )
    
    {
    rtnval=false;
    alert(error);
    fld.focus();
    }
   
   return rtnval;
}   
    </script>

    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Change Password" CssClass="FormLabelTitle">
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
                                   <table>
                        <tr>
                            <td style="text-align:left">
                                <asp:Label ID="lblUserId" runat="server" Text="User ID " CssClass="FormLabel">
                                </asp:Label>
                            </td>
                            <td style="text-align: left; width: 346px;">
                                <asp:TextBox ID="textUserId" runat="server" ToolTip="User ID" Width="100px" CssClass="textbox"
                                    MaxLength="15">
                                </asp:TextBox>
                                <asp:HiddenField ID="hdnUserId" runat="server" Value="0" />
                                <asp:HiddenField ID="hdnEmailId" runat="server" Value="" />
                                <asp:HiddenField ID="password" runat="server" Value="" />
                            </td>
                        </tr>
<%--                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblUserName" runat="server" Text="User Name " CssClass="FormLabel">
                                </asp:Label>
                            </td>
                            <td style="text-align: left; width: 346px;">
                                <asp:TextBox ID="textUserName" Width="200px" runat="server" ToolTip="User Name" CssClass="textbox"
                                    MaxLength="25">
                                </asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblOldPassword" runat="server" Text="Old Password " CssClass="FormLabel">
                                </asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textOldPassword" runat="server" ToolTip="Old Password" Width="150px"
                                    MaxLength="20" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                <span class="mandatory" style="vertical-align: top;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblNewPassword" runat="server" Text="New Password " CssClass="FormLabel">
                                </asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textNewPassword" runat="server" ToolTip="New Password" Width="150px"
                                    MaxLength="20" CssClass="textbox" TextMode="Password" onchange="return validatePassword(this);"
                                    onkeypress="kp_WithSpace();"></asp:TextBox>
                                <span class="mandatory" style="vertical-align: top;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password " CssClass="FormLabel">
                                </asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textConfirmPassword" runat="server" ToolTip="Confirm Password" Width="150px"
                                    MaxLength="20" CssClass="textbox" TextMode="Password" onkeypress="kp_WithSpace();"></asp:TextBox>
                                <span class="mandatory" style="vertical-align: top;">*</span>
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
                                                 <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
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
