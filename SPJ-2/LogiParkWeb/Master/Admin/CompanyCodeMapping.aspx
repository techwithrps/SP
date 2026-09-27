<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CompanyCodeMapping.aspx.vb" Inherits="Master_Admin_CompanyCodeMapping"
    Title="LogiPark:: Company Code Mapping" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <%--<script language="javascript" type="text/javascript">
      function saveValidation()
        {
          var result=false;    
          if (validateData(document.getElementById('<%=textDivisionCode.clientId %>'),
                      document.getElementById('<%=lblDivisionCode.clientId %>').innerHTML))
              if (validateData(document.getElementById('<%=textDivisionName.clientId %>'),
                          document.getElementById('<%=lblDivisionName.clientId %>').innerHTML))
                               result = true;
              else
                result=false;
          else
            result=false;
          return result;
        }
    </script>--%>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table>
                        <tr valign="top">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Company Code Mapping"
                                    CssClass="FormLabelTitle">
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
                                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name" CssClass="FormLabel"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCompanyName" runat="server" CssClass="FormTextBoxMedium" ToolTip="Company Name"></asp:TextBox>
                                                <span class="mandatory">*</span>
                                                <asp:HiddenField ID="hdnMappingId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnCompanyCode" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="1">
                                                    <tr class="RepHead">
                                                        <td align="center" width="20px">
                                                            <asp:CheckBox ID="chkrSelect" runat="server"></asp:CheckBox>
                                                        </td>
                                                        <td align="left" width="235px">
                                                            <asp:Label ID="lblrDivisionName" runat="server" CssClass="FormLabel" Text="Division Name">
                                                            </asp:Label>
                                                        </td>
                                                        <td style="width: 14px; background-color: White;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" valign="top">
                                                            <div class="RepScroling" style="height: 240px;">
                                                                <asp:Repeater ID="repCompanyMapping" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table cellspacing="0" id="cont" style="margin-right: -3px;">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="center" width="20px">
                                                                                <asp:CheckBox ID="chkSelect" runat="server" ToolTip="Select"></asp:CheckBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="textDivisionName" Enabled="false" runat="server" Width="235px" CssClass="FormTextBoxLarg"
                                                                                    ToolTip="Division Name" Text='<%# Eval("DivisionName") %>'>
                                                                                </asp:TextBox>
                                                                                <asp:HiddenField ID="hdnDivisionId" runat="server" Value='<%# Eval("DivisionId") %>' />
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
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
