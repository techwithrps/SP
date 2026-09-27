<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" CodeFile="~/Commercial/CustomerMapping.aspx.vb"
    AutoEventWireup="false" Inherits="Commercial_CustomerMapping" Title="eLOGiFreight:: Customer Mapping"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
      function saveValidation()
       {
      <%--  var result=false;    
          if (validateData(document.getElementById('<%=textTaxGroupCode.clientId %>'),
                        document.getElementById('<%=lblTaxGroupCode.clientId %>').innerHTML))
               
            result = true;
                       else
                         result=false;
                
            
         
 return result;--%>
    }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td>
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="200px" Text="Customer Mapping" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
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
                            <td style="width: 100%;" align="center" valign="top">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                       <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="0" border="0" cellpadding="0" style="border-color: White;">
                                                    <tr class="RepheaderNew">
                                                        <td align="center" width="150px" style="height:20px">
                                                            <asp:Label ID="lblBillingParty" Width="200px" runat="server" CssClass="FormLabel" Text='Billing Party <span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShippingLine" Width="200px"  runat="server" CssClass="FormLabel" Text="Shipping Line"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblServiceGroup" Width="200px" runat="server" CssClass="FormLabel" Text="Service Group"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTallyAccount" Width="200px" runat="server" CssClass="FormLabel" Text="Tally Account"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 140px;">
                                                                <asp:Repeater ID="repTaxHead" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0" border="0" cellpadding="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <%--<asp:HiddenField ID="hdnRepTaxGroupId" Value='<%# Eval("TaxGroupId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnRepTaxRefId" Value='<%# Eval("TaxRefId") %>' runat="server" />--%>
                                                                                <asp:DropDownList CssClass="ddlMedium" Width="200px" Text='<%# Eval("CustomerId")%>'
                                                                                    ID="lstTaxHead" runat="server" OnDataBinding="prepareBillingParty" ToolTip="Billing Party Name">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList CssClass="ddlMedium" Width="200px" Text='<%# Eval("CustomerId")%>'
                                                                                    ID="ddlShippingLine" runat="server" OnDataBinding="prepareShippingLine" ToolTip="Shipping Line">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                             <td>
                                                                                 <asp:DropDownList runat="server" ID="ddlServiceGroup" CssClass="ddlMedium" Width="200px">
                                                                                     <asp:ListItem Value="R" Text="Rebat"></asp:ListItem>
                                                                                     <asp:ListItem Value="T" Text="Transport"></asp:ListItem>
                                                                                     <asp:ListItem Value="A" Text="All"></asp:ListItem>
                                                                                     <asp:ListItem Value="C" Text="Clearance"></asp:ListItem>
                                                                                     <asp:ListItem Value="F" Text="Freight"></asp:ListItem>
                                                                                 </asp:DropDownList>
                                                                               <%-- <asp:DropDownList CssClass="ddlMedium" Width="200px" Text='<%# Eval("CustomerId")%>'
                                                                                    ID="ddlServiceGroup" runat="server" OnDataBinding="prepareBillingParty" ToolTip="Service Group">
                                                                                </asp:DropDownList>--%>
                                                                            </td>
                                                                             <td>
                                                                                <asp:DropDownList CssClass="ddlMedium" Width="200px" Text='<%# Eval("CustomerId")%>'
                                                                                    ID="ddlTallyCustomer" runat="server" OnDataBinding="prepareTallyCustomer" ToolTip="Tally Customer Name">
                                                                                </asp:DropDownList>
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
                            <td valign="top">
                                <div id="dvTreeView" class="tvScroling" style="height: 100%; width: 300px; border-left-color: Black;">
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
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" OnClientClick="saveValidation()"/>
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
