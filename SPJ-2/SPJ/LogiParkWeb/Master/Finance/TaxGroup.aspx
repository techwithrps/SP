<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" CodeFile="~/Master/Finance/TaxGroup.aspx.vb"
    AutoEventWireup="false" Inherits="Finance_TaxGroup" Title="eLogiFleet:: Tax Group"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
      function saveValidation()
       {
        var result=false;    
          if (validateData(document.getElementById('<%=textTaxGroupCode.clientId %>'),
                        document.getElementById('<%=lblTaxGroupCode.clientId %>').innerHTML))
               
            result = true;
                       else
                         result=false;
                
            
         
 return result;
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="200px" Text="Tax Group" CssClass="FormLabelTitle">
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
                                       
                                        <tr align="center">
                                            <td style="text-align: left;" >
                                                <asp:Label ID="lblTaxGroupCode" runat="server" Text="Tax Group Code" CssClass="FormLabel"></asp:Label></td>
                                                <td style="text-align: left;">
                                                 <asp:TextBox ID="textTaxGroupCode" runat="server" CssClass="textbox" ToolTip="Tax Group Code"
                                                    Enabled="false" onkeypress="kp_convert_upper()" MaxLength="20" Width="180px"></asp:TextBox><strong>
                                                        <samp class="mandatory">
                                                            *</samp></strong>
                                                <asp:HiddenField ID="hdnTaxGroupID" runat="server" Value="0" />
                                                </td>
                                               
                                            
                                        </tr>
                                        <tr align="center">
                                            <td style="text-align: left;" >
                                                <asp:Label ID="lblFromDate" runat="server" Text="From Date" CssClass="FormLabel"></asp:Label>
                                                 </td>
                                                 <td style="text-align: left;">
                                                 <asp:TextBox ID="textFromDate" runat="server" CssClass="textbox" ToolTip="From Date"
                                                    Enabled="false"  MaxLength="12"></asp:TextBox>
                                                     <ajaxToolkit:CalendarExtender ID="clValidFromDate" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textFromDate" />
                                                 </td>
                                                
                                               
                                           
                                        </tr>
                                        <tr align="center">
                                            <td style="text-align: left;" >
                                                <asp:Label ID="lblToDate" runat="server" Text="To Date" CssClass="FormLabel"></asp:Label></td>
                                                <td style="text-align: left;">
                                                 <asp:TextBox ID="textToDate" runat="server" CssClass="textbox" ToolTip="To Date"
                                                    Enabled="false"  MaxLength="12" ></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clValidToDate" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textToDate" />
                                                </td>
                                               
                                                
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellspacing="0" border="0" cellpadding="0" style="border-color: White;">
                                                    <tr class="RepheaderNew">
                                                        <td align="center" width="150px" style="height:20px">
                                                            <asp:Label ID="lblTaxHead" Width="150px" runat="server" CssClass="FormLabel" Text='Tax Head <span class="mandatory"> *</span>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTaxPercentage" runat="server" CssClass="FormLabel" Text="Tax Percentage(%)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" valign="top" align="center">
                                                            <div class="RepScroling" style="height: 140px;">
                                                                <asp:Repeater ID="repTaxHead" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont1" cellspacing="0" border="0" cellpadding="0">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hdnRepTaxGroupId" Value='<%# Eval("TaxGroupId") %>' runat="server" />
                                                                                <asp:HiddenField ID="hdnRepTaxRefId" Value='<%# Eval("TaxRefId") %>' runat="server" />
                                                                                <asp:DropDownList CssClass="ddlMedium" Width="172px" Text='<%# Eval("TaxHeadId") %>'
                                                                                    ID="lstTaxHead" runat="server" OnDataBinding="prepareTaxHeads" ToolTip="Tax Head">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox CssClass="textbox" Width="105px" ID="textTaxPercentage"
                                                                                    runat="server" Value='<%# Eval("TaxPercentage") %>' onkeypress="kp_numeric();"
                                                                                    ToolTip="Tax %" MaxLength="8"></asp:TextBox>
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
