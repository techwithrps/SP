<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/Commodity.aspx.vb" Inherits="Master_Admin_Commodity"
    Title="LogiPark:: Commodity" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textCommodityCode.clientId %>'),
                        document.getElementById('<%=lblCommodityCode.clientId %>').innerHTML))
               if (validateData(document.getElementById('<%=textCommodityName.clientId %>'),
                            document.getElementById('<%=lblCommodityName.clientId %>').innerHTML))
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Commodity" CssClass="FormLabelTitle">
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
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCommodityCode" runat="server" CssClass="FormLabel" Text="Commodity Code">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCommodityCode" runat="server" CssClass="FormTextBoxSmall" onkeypress="kp_convert_upper()"
                                                    ToolTip="Commodity Code" MaxLength="10">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                                <asp:HiddenField ID="hdnCommodityId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCommodityName" runat="server" CssClass="FormLabel" Text="Commodity Name">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCommodityName" runat="server" CssClass="FormTextBoxMedium" ToolTip="Commodity Name">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCommodityType" runat="server" CssClass="FormLabel" Text="Commodity Type">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCommodityType" runat="server" CssClass="FormListBoxMedium"
                                                    Width="150px" ToolTip="Commodity Type">
                                                    <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="GENL" Value="GENL"></asp:ListItem>
                                                    <asp:ListItem Text="REEFER" Value="REEFER"></asp:ListItem>
                                                    <asp:ListItem Text="HAZ" Value="HAZ"></asp:ListItem>
                                                    <asp:ListItem Text="ODC" Value="ODC"></asp:ListItem>
                                                    <asp:ListItem Text="REEFER HAZ" Value="REEFER_HAZ"></asp:ListItem>
                                                    <asp:ListItem Text="ODC HAZ" Value="ODC_HAZ"></asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="mandatory">*</span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" style="height: 100%; width: 300px; border-left-color: Black; overflow:auto;">
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
