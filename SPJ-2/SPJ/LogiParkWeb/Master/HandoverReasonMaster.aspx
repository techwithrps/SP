<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/BankMaster.aspx.vb" Inherits="Master_Admin_BankMaster"
    Title="LogiPark:: Bank Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textBankCode.clientId %>'),
                        document.getElementById('<%=lblBankCode.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textBankName.clientId %>'),
                            document.getElementById('<%=lblBankName.clientId %>').innerHTML))
                    
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
                                            <td style="text-align: right">
                                                <asp:Label ID="lblBankCode" runat="server" Text="Bank Code" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBankCode" runat="server" CssClass="FormTextBoxSmall" ToolTip="Bank Code"
                                                    onkeypress="kp_convert_upper()" MaxLength="10"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnBankId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblBankName" runat="server" Text="Bank Name" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBankName" runat="server" CssClass="FormTextBoxLarg" ToolTip="Bank Name"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblAccountNo" runat="server" Text="Account No" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAccountNo" runat="server" CssClass="FormTextBoxLarg" ToolTip="Account No"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblIfscCode" runat="server" CssClass="FormLabel" Text="IFSC Code"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textIfscCode" runat="server" MaxLength="15" Width="150px" CssClass="FormTextBoxMedium" ToolTip="IFSC Code"
                                                    onkeypress="kp_convert_upper()"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblSwift" runat="server" CssClass="FormLabel" Text="Swift Code"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textSwift" runat="server" MaxLength="15" Width="150px" CssClass="FormTextBoxMedium" ToolTip="IFSC Code"
                                                    onkeypress="kp_convert_upper()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="text-align: right">
                                                <asp:Label ID="lblBankAddress" runat="server" CssClass="FormLabel" Text="Bank Address"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBankAddress" Rows="3" runat="server" CssClass="FormTextBoxLarg"
                                                    Height="35px" TextMode="MultiLine" ToolTip="Bank Address"></asp:TextBox>
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
                            <td valign="top">
                                <div id="dvTreeView" class="RepScroling" style="height: 300px; width: 300px; border-left-color: Black;">
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
