<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="PackageMaster.aspx.vb" Inherits="Master_Admin_PackageMaster" Title="LogiPark:: Package Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textPackageCode.clientId %>'),
                        document.getElementById('<%=lblPackageCode.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textPackageName.clientId %>'),
                            document.getElementById('<%=lblPackageName.clientId %>').innerHTML))
                    
                               result = true;
              else
                     result=false;
            else
               result=false;
      return result;
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Text="Package Master" CssClass="FormLabelTitle" Width="400px" >
                                </asp:Label>
                                
                                <asp:Label ID="lblErrorMessage" Text="" runat="server"></asp:Label>
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
                                <div id="dvControl" runat="server" style="width: 100%;  border-style: none;
                                    vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                    <tr style="height:20px" >
                                    </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblPackageCode" runat="server" CssClass="FormLabel" Text="Package Code">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPackageCode" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_convert_upper()"
                                                    ToolTip="Package Code" MaxLength="20" Width="120px">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnPackageId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblPackageName" runat="server" CssClass="FormLabel" Text="Package Name">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPackageName" runat="server" CssClass="FormTextBoxMedium" ToolTip="Package Name">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
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
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" OnClientClick="return saveValidation();"/>
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
