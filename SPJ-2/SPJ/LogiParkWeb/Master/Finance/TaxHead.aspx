<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Finance/TaxHead.aspx.vb" Inherits="Finance_TaxHead" Title="eLogiFleet :: Tax Head"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
    function saveValidation()
    {
    var result=false;    
          if (validateData(document.getElementById('<%=textTaxHeadName.clientId %>'),
                        document.getElementById('<%=lblTaxHeadName.clientId %>').innerHTML))
               result = true;
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
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Tax Head" CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" Text="" runat="server" CssClass="label" ></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
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
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTaxHeadName" runat="server" CssClass="label" Text="Tax Head Name">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTaxHeadName" runat="server" CssClass="textbox" ToolTip="Tax Head Name">
                                                </asp:TextBox><strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTaxPercentage" runat="server" CssClass="label" Text="Tax Percentage ">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTaxPercentage" runat="server" CssClass="textbox" MaxLength="8" onkeypress="kp_numeric()"
                                                    ToolTip="Tax Percentage">
                                                </asp:TextBox><strong><samp class="mandatory">*</samp></strong>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblMapCode" runat="server" CssClass="label" Text="Map Code">
                                                </asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMapCode" runat="server" CssClass="textbox" ToolTip="Map Code"
                                                    MaxLength="20">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnTaxHeadID" runat="server" Value="" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="dvTreeView" class="RepScroling" style="height: 90%; width: 300px; border-left-color: Black;">
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
