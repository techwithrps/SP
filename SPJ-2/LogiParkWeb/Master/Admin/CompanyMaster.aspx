<%@ Page Language="VB" MasterPageFile="~/MasterPage.Master" AutoEventWireup="false" CodeFile="~/Master/Admin/CompanyMaster.aspx.vb" Inherits="Master_Admin_CompanyMaster"
    Title="eLOGiFleet :: Company Master" Theme="Forms" CodeBehind="CompanyMaster.aspx.vb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textCompanyCode.clientId %>'),
                        document.getElementById('<%=lblCompanyCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textCompanyName.clientId %>'),
                            document.getElementById('<%=lblCompanyName.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textPanNo.clientId %>'),
                            document.getElementById('<%=lblPanNo.clientId %>').innerHTML))
                        if (validateData(document.getElementById('<%=textTanNo.clientId %>'),
                               document.getElementById('<%=lblTanNo.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textServiceTaxReg.clientId %>'),
                                        document.getElementById('<%=lblServiceTaxReg.clientId %>').innerHTML))
                                if (validateData(document.getElementById('<%=textContactPerson.clientId %>'),
                                        document.getElementById('<%=lblContactPerson.clientId %>').innerHTML))
                                    if (validateData(document.getElementById('<%=textContactPerson.clientId %>'),
                                        document.getElementById('<%=lblContactPerson.clientId %>').innerHTML))
                                        result = true;
                                    else
                                        result = false;

                            else
                                result = false;
                    else
                        result = false;
            else
                result = false;
    else
        result = false;
else
    result = false;
else
    result = false;

return result;
}

function validateEmail() {
    var result = false;
    if (validateEmailID(document.getElementById('<%=textEmailID.clientId %>'),
                        document.getElementById('<%=lblEmailID.clientId %>').innerHTML))

        result = true;
    else
        result = false;
    return result;
}
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: 0px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Company Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                       
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCompanyCode" runat="server" Text="Company Code" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCompanyCode" runat="server" onkeypress="kp_convert_upper()"  CssClass="Txtstyle4"
                                                    ToolTip="Company Code" MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnCompanyCode" runat="server" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCompanyName" runat="server" MaxLength="100"  CssClass="Txtstyle4"
                                                    ToolTip="Company Name" Width="250px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblClassOfCompany" runat="server" CssClass="label" Text="Company Class"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCompanyClass" runat="server" width="170px" CssClass="Lststyle4" ToolTip="Company Class">
                                                    <asp:ListItem Value="1">Private</asp:ListItem>
                                                    <asp:ListItem Value="2">Public</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPanNo" runat="server" CssClass="label" Text="PAN"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPanNo" runat="server" CssClass="Txtstyle4" onkeypress="kp_convert_upper()"
                                                    onblur="pan_validate(this);" ToolTip="PAN" MaxLength="10"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTanNo" runat="server" CssClass="label" Text="TAN"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTanNo" runat="server" CssClass="Txtstyle4" onkeypress="kp_convert_upper()"
                                                    onblur="pan_validate(this);" ToolTip="TAN" MaxLength="10"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceTaxReg" runat="server" CssClass="label" Text="Service Tax Reg No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceTaxReg" runat="server" CssClass="Txtstyle4" onkeypress="kp_convert_upper()"
                                                    ToolTip="Service Tax Reg No" MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactPerson" runat="server" CssClass="label" Text="Contact Person"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactPerson" runat="server" CssClass="Txtstyle4" MaxLength="100"
                                                    ToolTip="Contact Person"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" CssClass="Txtstyle4" MaxLength="10"
                                                    onkeypress="kp_phonenumber();" ToolTip="Contact No"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td style="text-align: left">
                                                <asp:Label ID="lblRegisteredAddress" runat="server" CssClass="label" Text="Registered Address"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAddress" Rows="3" runat="server" CssClass="Txtstyle4" Width="250px"
                                                    TextMode="MultiLine" Height="70px" ToolTip="Registered Address">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailID" runat="server" CssClass="label" Text="Email ID"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailID" runat="server" Width="250px" CssClass="Txtstyle4" MaxLength="50"
                                                    onblur="return validateEmail()" ToolTip="Email ID" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                           
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCity" runat="server" CssClass="label" Text="City"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCity" runat="server" MaxLength="50" CssClass="Txtstyle4" ToolTip="City"></asp:TextBox>
                                            </td>
                                                <td style="text-align: left">
                                                <asp:Label ID="lblLogo" runat="server" CssClass="label" Text="Logo"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:FileUpload ID="floadLogo" runat="server" /></asp:FileUpload>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td style="text-align: left">
                                                <asp:Label ID="lblState" runat="server" CssClass="label" Text="State"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textState" runat="server" MaxLength="50" CssClass="Txtstyle4" ToolTip="State"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Country"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCountry" runat="server" Width="255px" CssClass="Lststyle4" 
                                                    ToolTip="Country">
                                                    <asp:ListItem Value="1">India</asp:ListItem>
                                                    <asp:ListItem Value="2">UAS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td> 
                                            </tr>
                                            <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPin" runat="server" CssClass="label" Text="PIN"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textZip" runat="server" Width="60px" onkeypress="kp_integer();"
                                                    MaxLength="6" CssClass="Txtstyle4" ToolTip="PIN"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDieselRate" runat="server" CssClass="label" Text="Diesel Rate"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textDieselRate" runat="server" Width="60px"
                                                    MaxLength="8" CssClass="Txtstyle4" ToolTip="Diesel Rate"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
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
