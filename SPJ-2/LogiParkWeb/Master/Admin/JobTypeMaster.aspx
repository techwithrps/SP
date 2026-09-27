<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/JobTypeMaster.aspx.vb" Inherits="Master_Admin_JobTypeMaster"
    Title="LogiPark:: JobTypeMaster" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateDropDownIndex(document.getElementById('<%=lstDocumentType.clientId %>'),
                        document.getElementById('<%=lblDocumentType.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textJobOrderCode.clientId %>'),
                            document.getElementById('<%=lblJobOrderCode.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textJobOrderName.clientId %>'),
                            document.getElementById('<%=lblJobOrderName.clientId %>').innerHTML))
                     if (validateDropDownIndex(document.getElementById('<%=lstService.clientId %>'),
                            document.getElementById('<%=lblService.clientId %>').innerHTML))     
                               result = true;
                       else
                         result=false;
                 else
                     result=false;
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Job Type Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
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
                                        <tr style="height: 20px;">
                                            <td style="text-align: right;">
                                            </td>
                                            <td style="text-align: left;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblDocumentType" runat="server" Text="Document Type" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstDocumentType" runat="server" CssClass="FormListBoxSmall"
                                                    Width="105px" ToolTip="Document Type">
                                                     <asp:ListItem Text="---Select---" Value="" />
                                                     <asp:ListItem Text="Export" Value="E" />
                                                     <asp:ListItem Text="Import" Value="I" />
                                                     <asp:ListItem Text="Empty" Value="M" />  
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnJobOrderId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblJobOrderCode" runat="server" Text="Job Order Code" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJobOrderCode" runat="server" CssClass="FormTextBoxSmall" ToolTip="Job Order Code"
                                                    onkeypress="kp_convert_upper()" MaxLength="10" Width="100px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblJobOrderName" runat="server" CssClass="FormLabel" Text="Job Order Name"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJobOrderName" runat="server" CssClass="FormTextBoxLarg" ToolTip="Job Order Name"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblService" runat="server" Text="Service" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstService" runat="server" CssClass="FormListBoxSmall" Width="250px"
                                                    ToolTip="Service">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
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
                                <div id="RepScroling" class="RepScroling" style="height: 250px; width: 300px; border-left-color: Black;">
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
