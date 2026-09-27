<%@ Page Title="eLOGiFleet :: Cost Tariff" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CostTariff.aspx.vb" Inherits="Master_Finance_CostTariff"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../../Script/ScrollableTablePlugin_1.0_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#cont').Scrollable({
                ScrollHeight: 200
            });
        });
    </script>
    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textValidFromDate.clientId %>'),
                        document.getElementById('<%=lblValidFromDate.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textValidToDate.clientId %>'),
                            document.getElementById('<%=lblValidToDate.clientId %>').innerHTML)) {
                    if ((document.getElementById('<%=lstCustomerType.clientId %>').getAttribute('value') != null) && (document.getElementById('<%=lstCustomerType.clientId %>').getAttribute('value') != '')) {
                        if (validateDropDownIndex(document.getElementById('<%=lstCustomer.clientId %>'),
                                document.getElementById('<%=lblCustomer.clientId %>').innerHTML))
                            result = true;
                        else {
                            result = false;
                        }
                    }
                    else {
                        result = true;
                    }

                    if (result == true) {
                        if (validateDropDownIndex(document.getElementById('<%=lstService.clientId %>'),
                                      document.getElementById('<%=lblService.clientId %>').innerHTML))
                            result = true;
                        else
                            result = false;
                    }
                    else
                        result = false;
                }
                else
                    result = false;
            else
                result = false;

            return result;
        }


        function manageDiscount(id) {

            var strsbno = "_lstDiscountType";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            if (tablename == null || tablename == '') {
                strsbno = "_textDiscount";
                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            }
            if (tablename == null || tablename == '') {
                strsbno = "_textBaseRate";
                tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            }

            var lstDiscountType = document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + tablename + "_lstDiscountType");
            var textDiscount = document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + tablename + "_textDiscount");
            var textBaseRate = document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + tablename + "_textBaseRate");
            var textToRang = document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + tablename + "_textToRange");
            var textRate = document.getElementById("ctl00_ContentPlaceHolder1_repRateDetails_ctl" + tablename + "_textRate");
            if ((textBaseRate.getAttribute('value') == null) || (textBaseRate.getAttribute('value') == '')) {
                textBaseRate.setAttribute('value', 0);
            }
            if ((textDiscount.getAttribute('value') == null) || (textDiscount.getAttribute('value') == '')) {
                textDiscount.setAttribute('value', 0);
            }

            if ((textToRang.getAttribute('value') != null) && (textToRang.getAttribute('value') != '')) {

                if ((lstDiscountType.value == null) || (lstDiscountType.value == '')) {
                    textDiscount.disabled = true;
                    textDiscount.value = 0;
                    textRate.value = textBaseRate.value;
                }
                else if (lstDiscountType.value == 'P') {
                    textDiscount.disabled = false;

                    if (parseFloat(textDiscount.value) > 100) {
                        alert("Discount % should less than 100")
                        focus.textDiscount;
                    }
                    else {
                        var rate = parseFloat(textBaseRate.value) - (parseFloat(textBaseRate.value) * parseFloat(textDiscount.value) / 100);
                        textRate.setAttribute('value', rate);
                    }

                }
                else if (lstDiscountType.value == 'I') {
                    textDiscount.disabled = false;
                    if (parseFloat(textDiscount.value) > parseFloat(textBaseRate.value)) {
                        alert("Discount should less than base rate")
                        focus.textDiscount;
                    }
                    else {
                        var rate = parseFloat(textBaseRate.value) - parseFloat(textDiscount.value);
                        textRate.setAttribute('value', rate);
                    }
                }
            }
        }
    </script>
    <table width="100%" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: 0px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Rate Master" CssClass="FormLabelTitle">
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
                        <tr class="UserControls" style="height: 400px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table cellspacing="0" border="0">
                                        <tr style="width: 100%;">
                                            <td>
                                            </td>
                                            <td align="left">
                                                <table cellspacing="0" border="0" style="border-color: White;">
                                                    
                                                    <tr>
                                                        
                                                        <td align="left">
                                                            <asp:Label ID="lblNUpload" runat="server" CssClass="label" Text="Browse"></asp:Label>&nbsp;
                                                            
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuFileLocation" Width="320px" Visible="true" Enabled="true" runat="server"
                                                                            CssClass="FormButton"/>
                                                            <asp:HiddenField ID="hdnRateId" runat="server" />
                                                            <asp:HiddenField ID="hdnUploadedTerminalId" runat="server" />
                                                            
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnDownload" Visible="false" runat="server" Text="Upload" CssClass="FormButton"/>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="linkDownload" Text="Download Format" Style="text-align: center;" runat="server" Font-Size="Medium"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblValidFromDate" runat="server" CssClass="FormLabel" Text="Valid From Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textValidFromDate" runat="server" CssClass="textbox" Width="85px"
                                                                ToolTip="Valid From Date" Enabled="false">
                                                            </asp:TextBox>
                                                            <strong>
                                                                <samp class="mandatory">
                                                                    *</samp></strong>
                                                            <ajaxToolkit:CalendarExtender ID="clValidFromDate" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textValidFromDate" />
                                                            <asp:Label ID="lblValidToDate" runat="server" CssClass="FormLabel" Text="Valid To Date "></asp:Label>
                                                            <asp:TextBox ID="textValidToDate" runat="server" CssClass="textbox" Width="85px"
                                                                ToolTip="Valid To Date" Enabled="false">
                                                            </asp:TextBox>
                                                            <strong>
                                                                <samp class="mandatory">
                                                                    *</samp></strong>
                                                            <ajaxToolkit:CalendarExtender ID="clValidToDate" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textValidToDate" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCustomerType" runat="server" CssClass="FormLabel" Text="Customer Type "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstCustomerType" AutoPostBack="true" runat="server" Width="150px"
                                                                CssClass="ddlMedium" ToolTip="Customer Type">
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="L">Line</asp:ListItem>
                                                                <asp:ListItem Value="V">Vendor</asp:ListItem>
                                                                <asp:ListItem Value="C">CHA</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCustomer" runat="server" CssClass="FormLabel" Text="Customer "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:UpdatePanel ID="upTitle" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="lstCustomer" Width="266" runat="server" CssClass="ddlMedium"
                                                                        ToolTip="Customer" Enabled="false">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstCustomerType" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRateAggrement" runat="server" CssClass="label" Text="Aggrement Copy"></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="FileRateAggrement" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblService" runat="server" CssClass="FormLabel" Text="Service "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstService" runat="server" CssClass="ddlMedium" ToolTip="Service"
                                                                Enabled="false">
                                                            </asp:DropDownList>
                                                            <strong>
                                                                <samp class="mandatory">
                                                                    *</samp></strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblTaxGroup" runat="server" CssClass="FormLabel" Text="Tax Group "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstTaxGroup" runat="server" CssClass="ddlMedium" ToolTip="TaxGroup"
                                                                Enabled="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblRemarks" runat="server" CssClass="FormLabel" Text="Remarks "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textRemarks" runat="server" CssClass="textbox" TextMode="MultiLine"
                                                                Height="30px" Width="266px" ToolTip="Remarks" onkeypress="kp_convert_upper()">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblApproval" Visible="false" runat="server" CssClass="FormLabel" Text="Approval "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:CheckBox ID="chkApproval" Visible="false" runat="server" ToolTip="Approval">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 20px;">
                                                        <td colspan="8">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td colspan="17" valign="top" align="center">
                                                            <asp:UpdatePanel ID="upRep" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <div class="RepScroling">
                                                                        <asp:Repeater ID="repRateDetails" runat="server">
                                                                            <HeaderTemplate>
                                                                                <table id="cont" cellspacing="0">
                                                                                    <tr class="RepheaderNew">
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblSrNo" Width="20px" CssClass="labelHeader" runat="server" Text="Sr."></asp:Label>
                                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblPort" Width="100px" runat="server" CssClass="FormLabel" Text="Port"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblContSize" Width="55px" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblContType" Width="50px" runat="server" CssClass="FormLabel" Text="Type"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblContStatus" Width="50px" runat="server" CssClass="FormLabel" Text="Status"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblDocType" Width="80px" runat="server" CssClass="FormLabel" Text="Doc Type"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblHandlingMode" Width="80px" CssClass="FormLabel" runat="server"
                                                                                                Text="Pickup Terminal"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblCargoType" Width="80px" CssClass="FormLabel" runat="server" Text="Drop Location"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblPod" Width="100px" CssClass="FormLabel" runat="server" Text="POL"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblCommodity" Width="150px" CssClass="FormLabel" runat="server" Text="Commodity"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblFromRange" Width="50px" CssClass="FormLabel" runat="server" Text="Range From (Kgs)"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblToRange" Width="50px" CssClass="FormLabel" runat="server" Text='Range To (Kgs)<span class="mandatory"> *</span>'></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblBaseRate" Width="70px" CssClass="FormLabel" runat="server" Text="Base Rate"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblCurrency" Width="70px" CssClass="FormLabel" runat="server" Text="Currency"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="Label1" Width="110px" CssClass="FormLabel" runat="server" Text="Det. Method"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblRateMethod" Width="110px" CssClass="FormLabel" runat="server" Text="Rate Method"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblTransitTime" Width="80px" CssClass="FormLabel" runat="server" Text="TT Days"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblrFreeDays" Width="100px" CssClass="FormLabel" runat="server" Text="POD Free Days"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                            <asp:Label ID="lblRateDifference" Width="110px" CssClass="FormLabel" runat="server" Text="Rate Diff."></asp:Label>
                                                                                        </td>
                                                                                        <td style="width: 15px">
                                                                                        </td>
                                                                                    </tr>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                     <td>
                                                                                        <asp:Label runat="server" ID="lblSrNo" Width="20px" Enabled="false" CssClass="textbox"
                                                                                         Text='<%# Container.ItemIndex + 1 %>'> ></asp:Label>
                                                                                     </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("PortId")%>' Width="100px"
                                                                                            ID="lstPortId" runat="server" OnDataBinding="preparePort" ToolTip="Port">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:HiddenField ID="hdnRateKeyId" runat="server" Value='<%# Eval("RateKeyId") %>' />
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("ContSize") %>' Width="55px"
                                                                                            ID="lstContSize" runat="server" ToolTip="Cont Size">
                                                                                            <asp:ListItem Value="" Text="ALL" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                                            <asp:ListItem Value="2*20" Text="2*20"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("ContType") %>' Width="50px"
                                                                                            ID="lstContType" runat="server" OnDataBinding="prepareContType" ToolTip="Cont Type">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("ContStatus") %>' Width="50px"
                                                                                            ID="lstContStatus" runat="server" ToolTip="Cont Status">
                                                                                            <asp:ListItem Value="0" Text="ALL" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="E" Text="Empty"></asp:ListItem>
                                                                                            <asp:ListItem Value="L" Text="Loaded"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("DocType") %>' Width="80px"
                                                                                            ID="lstDocType" runat="server" ToolTip="Doc type">
                                                                                            <asp:ListItem Value="0" Text="ALL" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="E" Text="Export"></asp:ListItem>
                                                                                            <asp:ListItem Value="I" Text="Import"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("HandlingMode") %>' Width="80px"
                                                                                            ID="lstHandlingMode" runat="server" OnDataBinding="prepareTerminal" ToolTip="Handling Mode"
                                                                                            OnSelectedIndexChanged="FillLocation" AutoPostBack="true">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("CargoType") %>' Width="80px"
                                                                                            ID="lstCargoType" runat="server" OnDataBinding="prepareTerminal" ToolTip="Cargo Type">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("Pol") %>' Width="100px" ID="lstPol"
                                                                                            runat="server" OnDataBinding="preparePol" ToolTip="Port of Loading">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("CommodityId") %>' Width="150px"
                                                                                            ID="lstCommodity" runat="server" OnDataBinding="prepareCommodity" ToolTip="Commodity">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Text='<%# Eval("FromRang") %>' Width="50px" ID="textFromRange"
                                                                                            runat="server" onkeypress="kp_integer();" ToolTip="From Range">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Text='<%# Eval("ToRang") %>' Width="50px" ID="textToRange"
                                                                                            runat="server" onkeypress="kp_integer();" ToolTip="To Range">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Text='<%# Eval("BaseRate") %>' Width="70px" ID="textBaseRate"
                                                                                            runat="server" onkeypress="kp_numeric();" ToolTip="Rate">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Text='<%# Eval("Currency")%>' Width="60px"
                                                                                            ID="lstCurrency" runat="server" ToolTip="Currency">
                                                                                            <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="INR" Text="INR"></asp:ListItem>
                                                                                            <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Width="110px" ID="LstDetMethod" text='<%# Eval("LineId") %>'
                                                                                            runat="server" ToolTip="Detension Method">
                                                                                            <asp:ListItem Value="0" Text="ALL" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="1" Text="Port To Port"></asp:ListItem>
                                                                                            <asp:ListItem Value="2" Text="Port To Terminal"></asp:ListItem>
                                                                                            <asp:ListItem Value="3" Text="Terminal To Terminal"></asp:ListItem>
                                                                                            <asp:ListItem Value="4" Text="Terminal To Port"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList CssClass="ddlMedium" Width="110px" ID="lstRateMethod" text='<%# Eval("DiscountType") %>'
                                                                                                          runat="server" ToolTip="Rate Method">
                                                                                            <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                                                            <asp:ListItem Value="A" Text="ALL"></asp:ListItem>
                                                                                            <asp:ListItem Value="H" Text="Handover"></asp:ListItem>
                                                                                            <asp:ListItem Value="S" Text="SOB"></asp:ListItem>
                                                                                            <asp:ListItem Value="P" Text="Pickup"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Text='<%# Eval("TransitTime") %>' Width="80px" ID="textTransitTimeDays"
                                                                                                     runat="server" ToolTip="Transit Time">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Text='<%# Eval("PodFreeDays") %>' Width="100px" ID="textFreeDays"
                                                                                                     runat="server" ToolTip="POD Free Days">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox CssClass="textbox" Width="110px" ID="textRateDifference" Enabled="False"
                                                                                                     runat="server" ToolTip="Rate Difference">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:Repeater>
                                                                    </div>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="lstCustomerType" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="10" valign="top" align="right">
                                                            <asp:Button ID="btnNewRows" runat="server" Text="Add Row" Visible="false" CssClass="FormButton" />
                                                            <asp:Button ID="btnDeleteRows" runat="server" Text="Delete" Visible="false" CssClass="FormButton" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div id="RepScroling" class="RepScroling" style="height: 400px; width: 320px;">
                                    <table>
                                        <tr>
                                            <td style="margin-left: 20px;">
                                                <asp:DropDownList ID="lstCustomerName" Style="vertical-align: top;" align="left"
                                                    runat="server" CssClass="FormListBoxMedium" Width="250px" ToolTip="Services">
                                                    <asp:ListItem Value="" Text="---Select---" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Button ID="btnGo" runat="server" Text="GO" align="center" Visible="true" CssClass="FormButton" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TreeView ID="tvServices" runat="server" align="left" Style="font-family: Verdana;
                                                    font-size: 10px;" Width="200px">
                                                </asp:TreeView>
                                            </td>
                                        </tr>
                                    </table>
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
