<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="CustomerProfileEntry.aspx.vb" Inherits="CustomerProfileEntry" Title="eLOGiPark :: Customer Profile Creation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
        function validateEmailId()
         {
            var result=false;    
            if (validateEmailID(document.getElementById('<%=textEmailId.clientId %>'),
                        document.getElementById('<%=lblEmailId.clientId %>').innerHTML))
                            result = true;
            else
              result=false;
           return result
         }
        function saveValidation()
         {
            var result=false;    
            if (validateData(document.getElementById('<%=textCustomerName.clientId %>'),
                        document.getElementById('<%=lblCustomerName.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textBusiness.clientId %>'),
                                document.getElementById('<%=lblBusiness.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textTurnOver.clientId %>'),
                                        document.getElementById('<%=lblTurnOver.clientId %>').innerHTML))
                                    if (validateData(document.getElementById('<%=textCompanyAge.clientId %>'),
                                                document.getElementById('<%=lblCompanyAge.clientId %>').innerHTML))
                                            if (validateData(document.getElementById('<%=textEstReveune.clientId %>'),
                                                        document.getElementById('<%=lblEstReveune.clientId %>').innerHTML))
                                                    if (validateData(document.getElementById('<%=textContactPerson.clientId %>'),
                                                                document.getElementById('<%=lblContactPerson.clientId %>').innerHTML))
                                                            if (validateData(document.getElementById('<%=textContactNo.clientId %>'),
                                                                        document.getElementById('<%=lblContactNo.clientId %>').innerHTML))
                                                                    if (validateData(document.getElementById('<%=textEmailId.clientId %>'),
                                                                                document.getElementById('<%=lblEmailId.clientId %>').innerHTML))                    
                                                                                    result = true;
                                                                    else
                                                                      result=false;
                                                            else 
                                                              result=false;
                                                    else
                                                      result=false;
                                            else 
                                              result=false;
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
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Customer Profile Creation"
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
                                    <table>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCustomerName" runat="server" ToolTip="Customer Name" CssClass="FormTextBoxMedium"
                                                    onkeypress="kp_convert_upper()" MaxLength="30">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                                <asp:HiddenField ID="hdnProfileId" runat="server" Value="0" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCompanyType" runat="server" Text="Company Type " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCompanyType" runat="server" CssClass="FormListBoxMedium"
                                                    ToolTip="Company Type" Width="100">
                                                    <asp:ListItem Value="P">Public</asp:ListItem>
                                                    <asp:ListItem Value="R">Private</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblBusiness" runat="server" Text="Business " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBusiness" runat="server" ToolTip="Business" CssClass="FormTextBoxLarg"
                                                    onkeypress="kp_convert_upper()" MaxLength="40">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTurnOver" runat="server" Text="Turn Over (Cr.) " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTurnOver" onkeypress="kp_numeric();" runat="server" ToolTip="Turn Over"
                                                    CssClass="FormTextBoxNumSmall" MaxLength="10">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblCompanyAge" runat="server" Text="Company Age " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCompanyAge" onkeypress="kp_numeric();" runat="server" ToolTip="Company Age"
                                                    CssClass="FormTextBoxNumSmall" MaxLength="3">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblTransportMode" Visible="false" runat="server" Text="Present Transportation Mode "
                                                    CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstTransportMode" runat="server" Visible="false" CssClass="FormListBoxMedium"
                                                    ToolTip="Transport Mode" Width="100">
                                                    <asp:ListItem Value="O">Road</asp:ListItem>
                                                    <asp:ListItem Value="R">Rail</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblTransportCost" runat="server" Text="Projected Volume " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTransportCost" onkeypress="kp_numeric();" runat="server" ToolTip="Projected Volume"
                                                    CssClass="FormTextBoxNumSmall" MaxLength="10">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblEstReveune" runat="server" Text="Projected Revenue " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEstReveune" runat="server" ToolTip="Projected Reveune" CssClass="FormTextBoxNumSmall"
                                                    onkeypress="kp_numeric();" MaxLength="10">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactPerson" runat="server" ToolTip="Contact Person" CssClass="FormTextBoxMedium"
                                                    MaxLength="30" onkeypress="kp_convert_upper()">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblContactNo" runat="server" Text="Contact No. " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" ToolTip="Contact No" MaxLength="10"
                                                    onkeypress="kp_phonenumber();" CssClass="FormTextBoxMedium" Width="90">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblEmailId" runat="server" Text="Email ID " CssClass="FormLabel">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailId" runat="server" ToolTip="Email Id" CssClass="FormTextBoxMedium"
                                                    onchange="validateEmailId();" MaxLength="30">
                                                </asp:TextBox>
                                                <span class="mandatory" style="vertical-align: top;">*</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right" valign="top">
                                                <asp:Label ID="lblAddress" runat="server" Text="Address " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAddress" runat="server" ToolTip="Address" CssClass="FormTextBoxLarg"
                                                    Height="30" TextMode="MultiLine" MaxLength="200">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right" valign="top">
                                                <asp:Label ID="lblRemarks" runat="server" Text="Remarks " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRemarks" runat="server" ToolTip="Remarks" CssClass="FormTextBoxLarg"
                                                    Height="30" TextMode="MultiLine" MaxLength="200">
                                                </asp:TextBox>
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
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" OnClientClick="return saveValidation();" />
                                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
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
