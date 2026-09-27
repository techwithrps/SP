<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/VendorMaster.aspx.vb" Inherits="Master_Admin_VendorMaster"
    Title="eLogiFleet:: Vendor Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textVendorName.clientId %>'),
                        document.getElementById('<%=lblVendorName.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textAddress.clientId %>'),
                        document.getElementById('<%=lblAddress.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textZipCode.clientId %>'),
                            document.getElementById('<%=lblZipCode.clientId %>').innerHTML))
                        if (validateData(document.getElementById('<%=textEmailId1.clientId %>'),
                         document.getElementById('<%=lblEmailId1.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textEmailId2.clientId %>'),
                           document.getElementById('<%=lblEmailId2.clientId %>').innerHTML))
                                if (validateData(document.getElementById('<%=textContactNo.clientId %>'),
                                 document.getElementById('<%=lblContactNo.clientId %>').innerHTML))
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
            return result;
        }

        function validateEmailId1() {
            var result = false;
            if (validateEmailID(document.getElementById('<%=textEmailId1.clientId %>'),
                        document.getElementById('<%=lblEmailId1.clientId %>').innerHTML))

                result = true;
            else
                result = false;
            return result;
        }

        function validateEmailId2() {
            var result = false;
            if (validateEmailID(document.getElementById('<%=textEmailId2.clientId %>'),
                        document.getElementById('<%=lblEmailId2.clientId %>').innerHTML))

                result = true;
            else
                result = false;
            return result;
        }
    

    </script>
    <script language="javascript" type="text/javascript">
        function populateServiceTextBox() {
            document.getElementById('<%=textServiceTaxRegNo.ClientID%>').value = document.getElementById('<%=textPanNo.ClientID%>').value;
        }
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vendor Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="label" runat="server"></asp:Label>
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
                        <tr class="UserControls" style="height: 400px; margin-top: 0px;">
                            <td style="width: 100%;" align="center" colspan="1" valign="top">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVendorCode" runat="server" Text="Vendor Code" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVendorCode" runat="server" Width="100px" CssClass="Rpttextbox"
                                                    ToolTip="Vendor Code" Enabled="false"></asp:TextBox>
                                                <asp:HiddenField ID="hdnVendorId" runat="server" Value="" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVendorName" runat="server" Text="Vendor Name" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textVendorName" runat="server" CssClass="textbox" ToolTip="Vendor Name"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left" rowspan="2" valign="top">
                                                <asp:Label ID="lblAddress" runat="server" CssClass="label" Text="Address "></asp:Label>
                                            </td>
                                            <td style="text-align: left" rowspan="2">
                                                <asp:TextBox ID="textAddress" runat="server" Width="250px" MaxLength="300" CssClass="textbox"
                                                    TextMode="MultiLine" Height="40px" ToolTip="Address">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Country"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCountry" runat="server" Width="177px" CssClass="ddlMedium"
                                                    ToolTip="Country">
                                                </asp:DropDownList>
                                            </td>
                                            <%--<td style="text-align: left">
                                                <asp:Label ID="lblCity" runat="server" CssClass="label" Text="City"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCity" runat="server" CssClass="textbox" ToolTip="City">
                                                </asp:TextBox>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblZipCode" runat="server" CssClass="label" Text="Pin Code"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textZipCode" runat="server" CssClass="textbox" MaxLength="6" ToolTip="Zip Code"
                                                    onkeypress="kp_integer();" Width="65px">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <%--<td style="text-align: left">
                                                <asp:Label ID="lblState" runat="server" CssClass="label" Text="State"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textState" runat="server" CssClass="textbox" ToolTip="State">
                                                </asp:TextBox>
                                            </td>--%>
                                        </tr>
                                        <tr style="height: 5px;">
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailId1" runat="server" CssClass="label" Text="Operation Email"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailId1" runat="server" onChange="return validateEmailId1()"
                                                    CssClass="textbox" ToolTip="Operation Email"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailId2" runat="server" CssClass="label" Text="Finance Email"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailId2" runat="server" onChange="return validateEmailId2()"
                                                    CssClass="textbox" ToolTip="Finance Email"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactPerson" runat="server" CssClass="label" Text="Contact Person"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactPerson" runat="server" CssClass="textbox" MaxLength="20"
                                                    ToolTip="Contact Person" onkeypress="kp_upper_character();" Width="110px">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" onkeypress="kp_phonenumber();" MaxLength="10"
                                                    CssClass="textbox" ToolTip="Contact No" Width="110px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblMobileNo" runat="server" CssClass="label" Text="Mobile No (SMS)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMobileNumber" runat="server" onkeypress="kp_phonenumber();"
                                                    MaxLength="10" CssClass="textbox" ToolTip="Mobile No (SMS)" Width="110px"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblFax" runat="server" CssClass="label" Text="Fax"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textFax" runat="server" onkeypress="kp_integer();" CssClass="textbox"
                                                    ToolTip="Fax" MaxLength="10" Width="110px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="height: 5px;">
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPanNo" runat="server" CssClass="label" Text="PAN No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPanNo" runat="server" MaxLength="10" CssClass="textbox" ToolTip="PAN No"
                                                    onblur="validatePAN(this);this.value=this.value.toUpperCase();" onkeyup="populateServiceTextBox();"
                                                    onkeypress="this.value=this.value.toUpperCase();" Width="110px"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTanNo" runat="server" CssClass="label" Text="TAN No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTanNo" runat="server" 
                                                    onkeypress="this.value=this.value.toUpperCase();" MaxLength="10" CssClass="textbox"
                                                    ToolTip="TAN No" Width="110px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceTaxRegNo" runat="server" CssClass="label" Text="Service Tax Reg. No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceTaxRegNo" runat="server" onkeypress="this.value=this.value.toUpperCase();"
                                                    onblur="this.value=this.value.toUpperCase();" CssClass="textbox" ToolTip="Service Tax Reg. No"
                                                    MaxLength="15" Width="110px"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPaymentTerms" runat="server" CssClass="label" Text="Payment Terms "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstPaymentTerms" runat="server" Width="177px" CssClass="ddlMedium"
                                                    ToolTip="Payment Terms">
                                                    <asp:ListItem Value="C">Cash</asp:ListItem>
                                                    <asp:ListItem Value="R">Credit</asp:ListItem>
                                                    <asp:ListItem Value="P">PDA</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblBankName" runat="server" CssClass="label" Text="Bank Name"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBankName" runat="server" Width="177px" CssClass="ddlMedium"
                                                    ToolTip="Bank Name">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblBranchName" runat="server" CssClass="label" Text="Branch"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBankBranch" runat="server" MaxLength="25" CssClass="textbox"
                                                    ToolTip="Branch"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblIfsc" runat="server" CssClass="label" Text="IFCS"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textIfsc" runat="server" onkeypress="kp_convert_upper();" CssClass="textbox"
                                                    ToolTip="IFSC" MaxLength="20"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                    </samp>
                                                </strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAccountNo" runat="server" CssClass="label" Text="Account No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAccountNo" runat="server" onkeypress="kp_convert_upper();" CssClass="textbox"
                                                    MaxLength="20" ToolTip="Account No"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAccountMapCode" runat="server" CssClass="label" Text="Account Map Code"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAccountMapCode" runat="server" onkeypress="kp_convert_upper();"
                                                    CssClass="textbox" MaxLength="20" ToolTip="Account Map Code"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="LblRate" runat="server" Text="Rate" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="TextRate" runat="server" CssClass="textbox" MaxLength="5"></asp:TextBox>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="State"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                 <asp:DropDownList ID="lstState" runat="server" Width="177px" CssClass="ddlMedium"
                                                    ToolTip="State">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label2" runat="server" Text="GSTIN" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtGSTIN" runat="server" CssClass="textbox" MaxLength="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                         <td style="text-align: left">
                                                <asp:Label ID="Label3" runat="server" Text="Tally Vendor Name" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtTallyVendor" runat="server" CssClass="textbox" Width="200px" MaxLength="500"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="height: 5px;">
                                            <td style="text-align: left">
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="1">
                                        <tr class="RepheaderNew">
                                            <td>
                                                <asp:Label ID="lblVendorType" Width="120px" runat="server" CssClass="label" Text='Vendor Type <span class="mandatory"> *</span>'></asp:Label>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTDSCode" Width="240px" CssClass="label" runat="server" Text="Applicable TDS"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblImport" Width="50px" CssClass="label" runat="server" Text="Import"></asp:Label>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblExport" Width="50px" CssClass="label" runat="server" Text="Export"></asp:Label>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDomestic" Width="50px" CssClass="label" runat="server" Text="Domestic"></asp:Label>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStatus" Width="50px" CssClass="label" runat="server" Text="Status"></asp:Label>&nbsp;
                                            </td>
                                            <td style="width: 15px; background-color: White">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" valign="top" align="center">
                                                <div class="RepScroling" style="height: 75px;">
                                                    <asp:Repeater ID="RepVendor" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont1" cellspacing="1" style="margin-left: -2px;">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="hdnVendorKeyId" Value='<%# Eval("VendorKeyId") %>' runat="server" />
                                                                    <asp:HiddenField ID="hdnRepVendorId" Value='<%# Eval("VendorId") %>' runat="server" />
                                                                    <asp:DropDownList CssClass="ddlMedium" Width="125px" ID="lstVendorType" runat="server"
                                                                        text='<%# Eval("VenderTypeCode") %>' OnDataBinding="prepareVendorType" ToolTip="Vendor Type">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <%--<td>
                                                                            <asp:TextBox class="ddlMedium" Width="50px" ID="TextRate" runat="server" MaxLength="5"
                                                                                OnDataBinding="prepareTds" Text='<%# Eval("RATE") %>' ToolTip="Rate">
                                                                            </asp:TextBox>
                                                                        </td>--%>
                                                                <td>
                                                                    <asp:DropDownList class="ddlMedium" Width="250px" ID="lstTds" runat="server" OnDataBinding="prepareTds"
                                                                        Text='<%# Eval("TdsCode") %>' ToolTip="Applicable TDS">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td width="50px">
                                                                    <asp:CheckBox Width="50px" ID="chkImport" Checked='<%#iif(Eval("Import")="Y",true,false) %>'
                                                                        runat="server" ToolTip="Import"></asp:CheckBox>
                                                                </td>
                                                                <td width="60px">
                                                                    <asp:CheckBox Width="50px" ID="chkExport" Checked='<%#iif(Eval("Export")="Y",true,false) %>'
                                                                        runat="server" ToolTip="Export"></asp:CheckBox>
                                                                </td>
                                                                <td width="60px">
                                                                    <asp:CheckBox Width="50px" ID="chkDomestic" Checked='<%#iif(Eval("Domestic")="Y",true,false) %>'
                                                                        runat="server" ToolTip="Domestic"></asp:CheckBox>
                                                                </td>
                                                                <td width="60px">
                                                                    <asp:CheckBox Width="40px" ID="chkStatus" Checked='<%#iif(Eval("Status")="Y",true,false) %>'
                                                                        runat="server" ToolTip="Status"></asp:CheckBox>
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
                                </div>
                            </td>
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 5px;">
                            <td style="text-align: left">
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
