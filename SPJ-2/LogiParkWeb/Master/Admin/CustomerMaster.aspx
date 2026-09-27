<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/CustomerMaster.aspx.vb" Inherits="Master_Admin_CustomerMaster"
    Title="eLOGiFleet:: Customer Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        function ValidatePan(id) {
            var strsbno = "_textPanNo";
            var textPanNo = document.getElementById('<%= textPanNo.clientid %>');
            var regpan = /^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$/;
            if (!regpan.test(textPanNo.value) && textPanNo.value != '') {
                alert('PAN is not valid. It should be in this "AAAAA1111Z" format');
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateGST(id) {
            var strsbno = "_textGSTN";
            var textGSTN = document.getElementById('<%= textGSTN.clientid %>');
            var reggst = /^([0-9]){2}([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}([0-9]){1}([a-zA-Z]){1}([0-9]){1}?$/;
            if (!reggst.test(textGSTN.value) && textGSTN.value != '' && textGSTN.length != 15) {
                alert('GST Identification Number is not valid. It should be in this "11AAAAA1111Z1A1" format');
            }
        }  
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textCustomerName.clientId %>'),
                        document.getElementById('<%=lblCustomerName.clientId %>').innerHTML))
                if (validateDropDownIndex(document.getElementById('<%=lstCustomerType.clientId %>'),
                            document.getElementById('<%=lblCustomerType.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textContactPerson.clientId %>'),
                                document.getElementById('<%=lblContactPerson.clientId %>').innerHTML))
                        if (validateData(document.getElementById('<%=textContactNo.clientId %>'),
                                    document.getElementById('<%=lblContactNo.clientId %>').innerHTML))
                            if (validateData(document.getElementById('<%=textAddress.clientId %>'),
                                                                document.getElementById('<%=lblRegisteredAddress.clientId %>').innerHTML))
                                if (validateData(document.getElementById('<%=textCity.clientId %>'),
                                                                    document.getElementById('<%=lblCity.clientId %>').innerHTML))
                                    if (validateData(document.getElementById('<%=textPin.clientId %>'),
                                                                        document.getElementById('<%=lblPin.clientId %>').innerHTML))
                                        if (validateDropDownIndex(document.getElementById('<%=lstCountry.clientId %>'),
                                                                            document.getElementById('<%=lblCountry.clientId %>').innerHTML))
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
            else
                result = false;
            return result;
        }


        function validateAccount() {

            var lstPaymentTerms = document.getElementById('<%= lstPaymentTerms.clientid %>')
            var textOpeningAmount = document.getElementById('<%= textOpeningAmount.clientid %>')
            var textCreditPeriod = document.getElementById('<%= textCreditPeriod.clientid %>')
            var textCreditLimit = document.getElementById('<%= textCreditLimit.clientid %>')

            if (lstPaymentTerms.getAttribute('value') == "C") {
                textOpeningAmount.setAttribute('disabled', true)
                textCreditPeriod.setAttribute('disabled', true)
                textCreditLimit.setAttribute('disabled', true)
            }
            else if (lstPaymentTerms.getAttribute('value') == "R") {
                textOpeningAmount.setAttribute('disabled', true)
                textCreditPeriod.setAttribute('disabled', false)
                textCreditLimit.setAttribute('disabled', false)
            }
            else {
                textOpeningAmount.setAttribute('disabled', false)
                textCreditPeriod.setAttribute('disabled', true)
                textCreditLimit.setAttribute('disabled', true)
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function populateServiceTextBox() {
            document.getElementById('<%=textServiceTaxNo.ClientID%>').value = document.getElementById('<%=textPanNo.ClientID%>').value;
        }
    </script>
    <table width="100%" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Customer Master"
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
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 410px; margin-top: 0px;">
                            <td style="width: 1368px;" valign="top" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div id="dvtabControl" runat="server" style="vertical-align: middle; overflow: auto;
                                            width: 100%;">
                                            <ajaxToolkit:TabContainer runat="server" ID="tabCustomerMaster" Width="100%" ActiveTabIndex="0"
                                                AutoPostBack="true">
                                                <ajaxToolkit:TabPanel runat="server" ID="tabMaster" TabIndex="0" HeaderText="Master Details">
                                                    <ContentTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="vertical-align: top;" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCustomerCode" runat="server" Text="Customer Code" CssClass="label"></asp:Label>
                                                                             <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textCustomerCode"  onblur="this.value=this.value.toUpperCase();"  runat="server" CssClass="textbox" ToolTip="Customer Code"
                                                                                    Width="100px"></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCustomerName" runat="server" CssClass="label" Text="Customer Name"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textCustomerName" runat="server" CssClass="textbox" MaxLength="100"
                                                                                    onblur="this.value=this.value.toUpperCase();" ToolTip="Customer Name" Width="200px"></asp:TextBox>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCustomerType" runat="server" CssClass="label" Text="Customer Type"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstCustomerType" runat="server" CssClass="ddlMedium" ToolTip="Customer Type"
                                                                                    Width="120px">
                                                                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblContactPerson" runat="server" CssClass="label" Text="Contact Person"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textContactPerson" runat="server" CssClass="textbox" ToolTip="Contact Person"
                                                                                    MaxLength="35" Width="200px"></asp:TextBox>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Contact No"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textContactNo" runat="server" CssClass="textbox" MaxLength="13"
                                                                                    onkeypress="kp_phonenumber();" ToolTip="Contact No" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblMobileNo" runat="server" CssClass="label" Text="Mobile No"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textMobileNo" runat="server" CssClass="textbox" MaxLength="10" onkeypress="kp_phonenumber();"
                                                                                    ToolTip="Mobile No" Width="114px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblEmailCommercial" runat="server" CssClass="label" Text="Email Commercial"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textEmailCommercial" runat="server" CssClass="textbox" ToolTip="Email Commercial"
                                                                                    Width="200px" Height="30px" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblEmailOperational" runat="server" CssClass="label" Text="Email Operational"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textEmailOperational" runat="server" CssClass="textbox" Height="30px"
                                                                                    TextMode="MultiLine" ToolTip="Email Operational" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblcustomerType1" runat="server" CssClass="label" Text="Cust Sub Type"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstCustomerType1" runat="server" CssClass="ddlMedium" ToolTip="Payment Terms"
                                                                                    Width="118px">
                                                                                    <asp:ListItem Selected="True" Text="Select" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Company" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Firm" Value="2"></asp:ListItem>
                                                                                    <asp:ListItem Text="HUF" Value="3"></asp:ListItem>
                                                                                    <asp:ListItem Text="Indivisul" Value="4"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblPaymentTerms" runat="server" CssClass="label" Text="Payment Terms"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstPaymentTerms" runat="server" onChange=" validateAccount();"
                                                                                    CssClass="ddlMedium" ToolTip="Payment Terms" Width="100px">
                                                                                    <asp:ListItem Value="C" Text="Immediate" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Value="R" Text="Credit"></asp:ListItem>
                                                                                    <asp:ListItem Value="P" Text="PDA"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblPanNo" runat="server" CssClass="label" Text="PAN"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPanNo" runat="server" CssClass="textbox" onkeyup="populateServiceTextBox();"
                                                                                    onchange="ValidatePan(this)" MaxLength="10" onkeypress="this.value=this.value.toUpperCase();"
                                                                                    ToolTip="Pan No" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td valign="bottom" style="text-align: left">
                                                                                <asp:CheckBox ID="chkStatus" runat="server" CssClass="label" Text="Status" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblOpeningAmount" runat="server" CssClass="label" Text="Opening Amount (INR)"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textOpeningAmount" runat="server" onkeypress="kp_numeric();" CssClass="textbox"
                                                                                    MaxLength="10" ToolTip="Opening Amount(INR)" Width="80px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblTanNo" runat="server" CssClass="label" Text="TAN"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textTanNo" runat="server" CssClass="textbox" MaxLength="20" onkeypress="this.value=this.value.toUpperCase();"
                                                                                    ToolTip="TAN No" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:CheckBox ID="chkExp" runat="server" CssClass="label" Text="Export" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCreditPeriod" runat="server" CssClass="label" Text="Credit Period (Days) "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textCreditPeriod" runat="server" onkeypress="kp_integer();" CssClass="textbox"
                                                                                    MaxLength="3" Width="80px" ToolTip="Credit Period (Days)"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblServiceTaxNo" runat="server" CssClass="label" Text="Service Tax No"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textServiceTaxNo" runat="server" CssClass="textbox" MaxLength="15"
                                                                                    onkeypress="this.value=this.value.toUpperCase();" onblur="this.value=this.value.toUpperCase();"
                                                                                    ToolTip="Service Tax No" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:CheckBox ID="chkImp" runat="server" CssClass="label" Text="Import" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCreditLimit" runat="server" CssClass="label" Text="Credit Limit (INR) "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textCreditLimit" runat="server" onkeypress="kp_numeric();" CssClass="textbox"
                                                                                    MaxLength="10" ToolTip="Credit Limit(INR)" Width="80px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblBin" runat="server" CssClass="label" Text="BIN/EIC"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textBin" runat="server" CssClass="textbox" MaxLength="10" onkeypress="kp_convert_upper();"
                                                                                    ToolTip="BIN/EIC" Width="120px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:CheckBox ID="chkDom" runat="server" CssClass="FormLabel" Text="Domestic" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblAccountNo" runat="server" CssClass="label" Text="Account No "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textAccountNo" Width="130px" runat="server" MaxLength="16" CssClass="textbox"
                                                                                    ToolTip="Account No" onkeypress="kp_integer();"></asp:TextBox>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblTaxExamption" runat="server" CssClass="label" Text="TDS %"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textTaxExemption" runat="server" CssClass="textbox" MaxLength="10"
                                                                                    onkeypress="kp_numeric();" ToolTip="Tax Exemption" Width="80px"></asp:TextBox>
                                                                            </td>
                                                                               <td style="text-align: left">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Tally SJ Customer Name"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="txtTallyTptCustomerName" runat="server" CssClass="textbox"
                                                                                  ToolTip="Tally Tpt Customer Name" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblAccountMapCode" runat="server" CssClass="label" Text="Account Map Code "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textAccountMapCode" runat="server" CssClass="textbox" MaxLength="10"
                                                                                    Width="80px" ToolTip="Account Map Code" onkeypress="kp_convert_upper();"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblState" runat="server" CssClass="label" Text="State"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="lstState" runat="server" CssClass="ddlMedium" ToolTip="Payment Terms"
                                                                                    Width="180px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                                 <td style="text-align: left">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Tally SPJ Customer Name"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="txttallyfrtCustomerName" runat="server" CssClass="textbox" 
                                                                                  ToolTip="Tally Frt Customer Name" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:Label ID="lblRegisteredAddress" runat="server" CssClass="label" Text="Registered Address "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textAddress" Rows="4" runat="server" CssClass="textbox" TextMode="MultiLine"
                                                                                    Height="35px" MaxLength="50" Width="200px" ToolTip="Registered Address"></asp:TextBox>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:Label ID="lblGSTN" runat="server" CssClass="label" Text="GSTIN"></asp:Label>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <asp:TextBox ID="textGSTN" runat="server" CssClass="textbox" MaxLength="15" onchange="ValidateGST(this)"
                                                                                    ToolTip="GSTN"></asp:TextBox>
                                                                            </td>
                                                                              <td align="left">
                                                                                <asp:Label ID="Label4" runat="server" CssClass="label" Text="Customer Group Name"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="lstCustomerGroupName" runat="server" CssClass="ddlMedium" ToolTip="Customer Group Name"
                                                                                    Width="200px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCity" runat="server" CssClass="label" Text="City"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:TextBox ID="textCity" runat="server" Width="199px" CssClass="textbox" MaxLength="50"
                                                                                    ToolTip="City"></asp:TextBox>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:Label ID="lblColor" runat="server" CssClass="label" Text="Color Code"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                               <td align="left">
                                                                                <asp:Label ID="Label5" runat="server" CssClass="label" Text="TDS"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="lstTDS" runat="server" CssClass="ddlMedium" ToolTip="TDS"
                                                                                    Width="100px">
                                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                                    
                                                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                                    
                                                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Country "></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstCountry" runat="server" CssClass="ddlMedium" ToolTip="Country"
                                                                                    Width="204px">
                                                                                    <asp:ListItem Text="---ALL---" Value="0"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="LblDiscountType1" runat="server" CssClass="FormLabel" Text="Discount Type"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:DropDownList ID="lstDiscounttype" runat="server" CssClass="ddlMedium">
                                                                                    <asp:ListItem Value="I">Invoice Date</asp:ListItem>
                                                                                    <asp:ListItem Value="H">Handover</asp:ListItem>
                                                                                    <asp:ListItem Value="S">SOB</asp:ListItem>
                                                                                    <asp:ListItem Value="O">OBL Isuue</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                               <td style="text-align: left">
                                                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Tally Purchase Customer Name"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="tallyPurchaseCustomerName" runat="server" CssClass="textbox" 
                                                                                  ToolTip="Tally Purchase Customer Name" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblPin" runat="server" CssClass="label" Text="PIN"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textPin" runat="server" CssClass="textbox" MaxLength="6" ToolTip="PIN"
                                                                                    Width="60px" onkeypress="kp_integer();"></asp:TextBox>
                                                                                <span class="mandatory">*</span>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="LblDiscountdays1" runat="server" CssClass="label" Text="Discount Days"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textDiscount" runat="server" onkeypress="kp_integer();" CssClass="textbox"></asp:TextBox>
                                                                            </td>

                                                                             <td style="text-align: left">
                                                                                <asp:Label ID="Label7" runat="server" CssClass="FormLabel" Text="Credit Discount Type"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left; vertical-align: top;">
                                                                                <asp:DropDownList ID="lstCreditDiscountType" runat="server" CssClass="ddlMedium">
                                                                                  <asp:ListItem Value="0"> ---Select---</asp:ListItem>
                                                                                    <asp:ListItem Value="I">Invoice Datewise</asp:ListItem>
                                                                                    <asp:ListItem Value="S">SOB Datewise</asp:ListItem>
                                                                                    <asp:ListItem Value="B"> < BL/SOB Datewise</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <tr>
                                                                                    <td style="text-align: left">
                                                                                <asp:Label ID="lblBillOfSupply" runat="server" CssClass="label" Text="Tally Bill Of Supply Name"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textBillOfSupply" runat="server" CssClass="textbox"
                                                                                  ToolTip="Tally Bill Of Supply Name" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                                 <td align="left">
                                                                                <asp:Label ID="lblBankNameInr" runat="server" Width="130" CssClass="label" Text="Bank Name INR"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstBankNameInr" runat="server" CssClass="ddlMedium" ToolTip="Bank Name INR"
                                                                                    Width="180px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                                 <td align="left">
                                                                                <asp:Label ID="Label8" runat="server" Width="130" CssClass="label" Text="Bank Name USD"></asp:Label>
                                                                            </td>
                                                                          <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstBankNameUSD" runat="server" CssClass="ddlMedium" ToolTip="Bank Name INR"
                                                                                    Width="180px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            </tr>

                                                                            <td style="text-align: left">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                    <div id="RepScroling" class="RepScroling" style="height: 100%; width: 300px; border-left-color: Black;
                                                                        text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textSearchCustomer" onkeypress="kp_convert_upper()" runat="server"
                                                                            CssClass="textbox" placeholder="Enter Customer Name.."></asp:TextBox>
                                                                        <asp:Button ID="btnSearchCustomer" runat="server" Text="Search" CssClass="FormButton" />
                                                                        <asp:TreeView ID="tvCustomer" runat="server" Style="font-family: Verdana; font-size: 12px"
                                                                            Width="144px" Height="110px">
                                                                        </asp:TreeView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <ajaxToolkit:TabPanel runat="server" ID="tabLocation" TabIndex="1" HeaderText="Location">
                                                    <ContentTemplate>
                                                        <table border="0" cellpadding="0" style="border-style: none;">
                                                            <tr>
                                                                <td align="center" valign="top" style="width: 900px">
                                                                    <table>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lbllCustomer" runat="server" class="label" Text="Customer"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textCustomer" runat="server" CssClass="Rpttextbox"></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnlCustomerId" runat="server" Value="0" />
                                                                                <asp:HiddenField ID="hdnLocationKeyId" runat="server" Value="0" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblLocation" runat="server" CssClass="label" Text="Location"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:DropDownList ID="lstLocation" runat="server" CssClass="ddlMedium" ToolTip="Location">
                                                                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                                                                    <%-- <asp:ListItem Text="Delhi" Value="D"></asp:ListItem>
                                                                                    <asp:ListItem Text="Lucknow" Value="L"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mumbai" Value="M"></asp:ListItem>
                                                                                    <asp:ListItem Text="Surat" Value="S"></asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblLong" runat="server" Text="Longitude" CssClass="label"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="Label1" runat="server" Text="Latitude" CssClass="label"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="text-align: left">
                                                                                <asp:Label ID="lblLocAddress" runat="server" CssClass="label" Text="Address"></asp:Label>
                                                                            </td>
                                                                            <td style="text-align: left">
                                                                                <asp:TextBox ID="textLocAddress" runat="server" CssClass="FormTextBoxLarg" ToolTip="Address"
                                                                                    MaxLength="100" onkeypress="kp_convert_upper()" TextMode="MultiLine" Height="70px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <div id="divLocation" style="height: 180px; width: 200px; overflow: auto;">
                                                                        <asp:TreeView ID="tvCustomerLocation" runat="server" Style="font-family: Verdana;
                                                                            font-size: 12px; text-align: left;" Width="145px" Height="145px">
                                                                        </asp:TreeView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                            </ajaxToolkit:TabContainer>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="tabCustomerMaster" EventName="ActiveTabChanged"
                                            runat="Server" />
                                    </Triggers>
                                </asp:UpdatePanel>
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
                                                <asp:ImageButton ID="btnTally" Visible="false" Width="125px" runat="server" ImageUrl="~/Images/btnTally.png" />
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
