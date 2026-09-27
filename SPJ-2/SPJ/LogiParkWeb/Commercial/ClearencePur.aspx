<%@ Page Title="eLOGiFreight:: Cleareance Purchse Entry" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="ClearencePur.aspx.vb" Inherits="Commercial_ClearencePur"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript">
        function Confirm() {
            var d1 = "Do you want to Delete the data.";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(d1)) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type="text/javascript">
        function checkAll(id) {
            var tCont = 0;
            if (document.getElementById("tbCont") != null) {
                var rowCount = document.getElementById("tbCont").getElementsByTagName("tr").length;
                var id1 = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl00_chkAll")
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + LPad((j + 1) + "", 2, "0") + "_CheckBox1")
                    document.getElementById("ctl00_ContentPlaceHolder1_gvtripPendencyList_ctl" + LPad((j + 1) + "", 2, "0") + "_CheckBox1").checked = id1;
                    tCont += 1;
                    document.getElementById('<%= TextTotalCont.clientid %>').value = tCont;
                }
                if (id1 == false) {
                    document.getElementById('TextTotalCont.clientid').value = 0;
                }
            }
        }
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
        var ScrollHeight = 100;
        window.onload = function () {
            var grid = document.getElementById(GridId);
            var gridWidth = grid.offsetWidth;
            var gridHeight = grid.offsetHeight;
            var headerCellWidths = new Array();
            for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
            }
            grid.parentNode.appendChild(document.createElement("div"));
            var parentDiv = grid.parentNode;

            var table = document.createElement("table");
            for (i = 0; i < grid.attributes.length; i++) {
                if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                    table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                }
            }
            table.style.cssText = grid.style.cssText;
            table.style.width = gridWidth + "px";
            table.appendChild(document.createElement("tbody"));
            table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
            var cells = table.getElementsByTagName("TH");

            var gridRow = grid.getElementsByTagName("TR")[0];
            for (var i = 0; i < cells.length; i++) {
                var width;
                if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                    width = headerCellWidths[i];
                }
                else {
                    width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                }
                cells[i].style.width = parseInt(width - 3) + "px";
                gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
            }
            parentDiv.removeChild(grid);

            var dummyHeader = document.createElement("div");
            dummyHeader.appendChild(table);
            parentDiv.appendChild(dummyHeader);
            var scrollableDiv = document.createElement("div");
            if (parseInt(gridHeight) > ScrollHeight) {
                gridWidth = parseInt(gridWidth) + 17;
            }
            scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
            scrollableDiv.appendChild(grid);
            parentDiv.appendChild(scrollableDiv);
        }
    </script>
    <div id="dvControl" runat="server" style="vertical-align: top; overflow: auto; width: 100%;">
        <%--<table style="width: 100%; border-style: none;" border="0" cellpadding="0">
            <div id="dvControl" runat="server" style="width: 100%; border-style: none;">--%>
        <table border="0" cellpadding="0" style="border-style: none;">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="Purchase Booking"
                        CssClass="FormLabelTitle">
                    </asp:Label>
                    <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="LblFromDate" runat="server" CssClass="FormLabel" Text="Form Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="FormTextBoxDate"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                    TargetControlID="TxtFromDate" />
                            </td>
                            <td>
                                <asp:Label ID="LblToDate" runat="server" CssClass="FormLabel" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="FormTextBoxDate"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                    TargetControlID="txtToDate" />
                            </td>
                            <td>
                                <asp:Label ID="LblLine" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="lstLine" runat="server" CssClass="ddlSmall">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LblCfs" runat="server" CssClass="FormLabel" Text="CFS"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LstCFS" runat="server" CssClass="ddlSmall">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LblPol" runat="server" CssClass="FormLabel" Text="POL"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LstPol" runat="server" CssClass="ddlSmall">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LblPod" runat="server" CssClass="FormLabel" Text="POD"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LstPod" runat="server" CssClass="ddlSmall">
                                </asp:DropDownList>
                            </td>

                              <td>
                                <asp:Label ID="Label13" runat="server" CssClass="FormLabel" Text="CHA"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="lstCHA" runat="server" CssClass="ddlSmall">
                                </asp:DropDownList>
                            </td>


                            <td>
                                <asp:Button ID="BtnDisplay" runat="server" CssClass="FormButton" Text="Display" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" ID="lstPurchaseType">
                                    <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Maintenence" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Software/Networking" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Shipping Line Purchase" Value="L"></asp:ListItem>
                                    <asp:ListItem Text="Clearing & Forwading" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Transport" Value="T"></asp:ListItem>
                                </asp:DropDownList>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="LblBillingParty" runat="server" Text="Bill To" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="LstBillingParty">
                                </asp:DropDownList>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblShippingLine" runat="server" Text="Customer/Vendor" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" ID="lstVendorList">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnTaxGroupID" runat="server" Value="0" />
                                <asp:HiddenField ID="hdnCostId" runat="server" Value="0" />
                                <asp:HiddenField ID="HdnStatus" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label8" runat="server" Text="State" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="lstState">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblGSTINNo" runat="server" Text="GSTIN" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtGSTIN" runat="server" CssClass="textbox" ToolTip="GSTIN" Enabled="false"
                                    MaxLength="20"></asp:TextBox>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="text-align: left;">
                                <asp:Label ID="LblLineInvoiceNo" runat="server" Text="Invoice No" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="TextInvNo" runat="server" CssClass="textbox" ToolTip="To Date" Enabled="false"
                                    AutoPostBack="True"></asp:TextBox>
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong><asp:Button ID="btnSearchInvoice" runat="server" Text="GO" CssClass="FormButton" />
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textToDate0" runat="server" CssClass="textbox" ToolTip="To Date"
                                    Enabled="false" MaxLength="12"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="textToDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="textToDate0" />
                                <strong>
                                    <samp class="mandatory">
                                        *</samp></strong>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="text-align: left;">
                                <asp:Label ID="lblDueDate" runat="server" Text="Due Date" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="textDueDate" runat="server" CssClass="textbox" ToolTip="To Date"
                                    Enabled="false"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="textDueDate" />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblTdsApplicable" runat="server" Text="TDS Applicable" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList CssClass="ddlMedium" runat="server" ID="lstTdsApplicable" Width="80">
                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnServiceType" runat="server" />
                                <asp:Label ID="lblTdsPer" runat="server" CssClass="FormLabel" Text="%"></asp:Label>
                                <asp:TextBox ID="TextTdsPer" runat="server" Width="20px" CssClass="textbox" ToolTip="%"
                                    Enabled="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblrService" runat="server" CssClass="FormLabel" Text="Service"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownCheckBoxes ID="ddchkContainer" EnableViewState="true" runat="server"
                                    CssClass="ddlMedium" Enabled="true" UseButtons="True" UseSelectAllNode="True"
                                    OnSelectedIndexChanged="ddchkContainer_SelectedIndexChanged">
                                    <Style SelectBoxWidth="200" DropDownBoxBoxWidth="300" DropDownBoxBoxHeight="200" />
                                </asp:DropDownCheckBoxes>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label9" runat="server" Text="Ex Rate" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="TextTotalCont" Width="100px" runat="server" CssClass="textbox" ToolTip="To Date"
                                    Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label10" runat="server" Text="Remarks" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtRemak" Width="300px" runat="server" CssClass="textbox" ToolTip="To Date"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="BtnGenerate" runat="server" CssClass="FormButton" Text="Generate" />
                                <asp:Button ID="btnPriview" runat="server" CssClass="FormButton" Text="Priview" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <div id="tbCont" style="height: 100%; overflow: auto;">
                        <asp:GridView ID="gvtripPendencyList" AutoGenerateColumns="False" runat="server">
                            <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onClick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Container No" HeaderStyle-CssClass="RepheaderNew">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCONT_NO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                        <asp:HiddenField ID="HdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BL_NO" HeaderStyle-CssClass="RepheaderNew">
                                    <ItemTemplate>
                                        <asp:Label ID="LBLBlNo" runat="server" Text='<%# Eval("BL_NO")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <table cellspacing="0" border="0" cellpadding="0" style="border-color: White;">
                        <tr>
                            <td colspan="8" valign="top" align="center" width="1020px">
                                <div id="r" style="text-align: left; overflow: auto; height: 200px;">
                                    <table cellspacing="0" align="center">
                                        <tr class="RepheaderNew" align="center">
                                            <td align="left">
                                                <asp:CheckBox ID="chkSelect" runat="server" Width="30px" onClick="checkAll(this);">
                                                </asp:CheckBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblContNo" Width="120px" runat="server" CssClass="FormLabel" Text="Container No"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="LblBlNo" Width="120px" runat="server" CssClass="FormLabel" Text="BL No"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblservice" Width="295px" CssClass="FormLabel" runat="server" Text="Service"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblQuntity" Width="55px" CssClass="FormLabel" runat="server" Text="Qnty"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label2" Width="60px" CssClass="FormLabel" runat="server" Text="Rate"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label12" Width="55px" CssClass="FormLabel" runat="server" Text="Ex Rate(INR)"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label11" Width="70px" CssClass="FormLabel" runat="server" Text="Rate(INR)"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAmount" Width="70px" CssClass="FormLabel" runat="server" Text="Amount"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblCGSTRate" Width="50px" CssClass="FormLabel" runat="server" Text="CGST Rate"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label3" Width="50px" CssClass="FormLabel" runat="server" Text="CGST Amount"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblSGSTRate" Width="60px" CssClass="FormLabel" runat="server" Text="SGST Rate"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label4" Width="40px" CssClass="FormLabel" runat="server" Text="SGST Amount"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblIGSTRate" Width="70px" CssClass="FormLabel" runat="server" Text="IGST Rate"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label5" runat="server" Width="70px" CssClass="FormLabel" Text="IGST Amount"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotalTaxAmount" Width="70px" CssClass="FormLabel" runat="server"
                                                    Text="GST Amount" Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTotalAmount" Width="80px" CssClass="FormLabel" runat="server" Text="Total Amount"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label7" Width="100px" CssClass="FormLabel" runat="server" Text="TDS"
                                                    Style="font-weight: 700"></asp:Label>
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="19" valign="top" align="left">
                                                <div class="RepScroling" style="height: 138px;">
                                                    <asp:Repeater ID="rcInvoiceDetails" runat="server">
                                                        <HeaderTemplate>
                                                            <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px;">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:HiddenField ID="hdnCont" runat="server" />
                                                                    <asp:HiddenField ID="hdnImpContId" Value='<%# Eval("MtyContId") %>' runat="server" />
                                                                    <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                                    <asp:HiddenField ID="HdnKeyId" Value='<%# Eval("KeyId") %>' runat="server" />
                                                                    <asp:HiddenField ID="HdnBlNo" runat="server" />
                                                                    <asp:HiddenField ID="hdnTaxId" runat="server" />
                                                                    <asp:CheckBox ID="chkSelect" Width="15px" runat="server" ToolTip=""></asp:CheckBox>
                                                                </td>
                                                                <td class="FormLabel" style="text-align: center; width: 30px; vertical-align: middle;">
                                                                    <%# Container.ItemIndex + 1 %>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textContNo" runat="server" CssClass="FormTextBoxMedium" Width="110px"
                                                                        Enabled="false" ToolTip="Cont No" MaxLength="11" Text='<%# Eval("ContNO") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBlNo" runat="server" CssClass="FormTextBoxMedium" Width="110px"
                                                                        Enabled="false" ToolTip="Cont No">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="textService" runat="server" Enabled="false" CssClass="FormListBoxMedium"
                                                                        Width="305px" ToolTip="Service" Text='<%# Eval("ServiceId") %>' OnDataBinding="prepareService">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("CostId") %>' runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textQuntity" runat="server" Enabled="false" Text='<%# Eval("Qnty") %>'
                                                                        ToolTip="Quantity" CssClass="FormTextBoxNumeric" Width="60px">
                                                                    </asp:TextBox>
                                                                    <asp:HiddenField ID="HdnExRate" runat="server" Value='<%# Eval("Qnty") %>' />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                                        Width="65px" Text='<%#  Eval("Rate") %>' ToolTip="Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                                        Width="66px" Text='<%#  Eval("ExRate") %>' ToolTip="Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textRate" runat="server" Enabled="false" CssClass="FormTextBoxNumeric"
                                                                        Width="65px" Text='<%#  Eval("Rate") * Eval("ExRate") %>' ToolTip="Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="80px" Text='<%# string.Format("{0:n2}", (Eval("Qnty") * Eval("Rate") * Eval("ExRate"))) %>'
                                                                        ToolTip="Amount">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textCGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="60px" Text='<% # Eval("CGSTRate")%>' ToolTip="CGST Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textCGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="60px" Text='<% # Eval("CGSTAmount")%>' ToolTip="CGST Amount">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textSGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="60px" Text='<% # Eval("SGSTRate")%>' ToolTip="SGST Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textSGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="70px" Text='<% # Eval("SGSTAmount")%>' ToolTip="SGST Amount">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textIGSTRate" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="75px" Text='<% # Eval("IGSTRate")%>' ToolTip="IGST Rate">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textIGSTAmount" runat="server" Enabled="false" CssClass="RptFormTextBoxNumeric"
                                                                        Width="75px" Text='<% # Eval("IGSTAmount")%>' ToolTip="IGST Amount">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric" Enabled="false"
                                                                        Width="75px" Text='<%# string.Format("{0:n2}", Eval("IgstAmount") + ((Eval("SgstAmount") *  2))) %>'
                                                                        ToolTip="Tax Amount">
                                                                    </asp:TextBox>
                                                                    <asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="textTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                        Width="75px" Text='<%# string.Format("{0:n2}",Eval("Total")) %>' Enabled="false"
                                                                        ToolTip="Total Amount">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="RptFormTextBoxNumeric" Width="105px" ID="textTDSAmount" Text='<%# Eval("TDSAmount") %>'
                                                                        runat="server" ToolTip="TDS Amount" MaxLength="8" Enabled="true"></asp:TextBox>
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
                                        <tr>
                                            <td colspan="8" align="right">
                                                <asp:Label ID="Label6" runat="server" Text="Total " CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepAmount" runat="server" CssClass="RptFormTextBoxNumeric" Width="70px"
                                                    ToolTip="Amount Total" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="width: 50px;">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepCGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="50px" ToolTip="CGST Amount" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="width: 50px;">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepSGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="50px" ToolTip="SGST Amount" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="width: 50px;">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepIGSTAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="60px" ToolTip="IGST Amount" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="70px" ToolTip="Tax Amount Total" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textRepTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="80px" ToolTip="Total Amount" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                             <td>
                                                <asp:TextBox ID="textRepTotalTds" runat="server" CssClass="RptFormTextBoxNumeric"
                                                    Width="100px" ToolTip="Total TDS" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td align="right" style="width: 195px">
                                                <asp:Label ID="LblTotal" runat="server" CssClass="FormLabel" Text="Total"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 90px">
                                                <asp:Label ID="LblRate" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 180px">
                                                <asp:Label ID="lblBaseAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="lblCGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 150px">
                                                <asp:Label ID="lblSGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 180px">
                                                <asp:Label ID="lblIGSTAmount" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 130px">
                                                <asp:Label ID="LblTaxAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="LblTotalAmt" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                            <td align="center" style="width: 100px">
                                                <asp:Label ID="lblTotalTDS" runat="server" CssClass="FormLabel"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnConfirm" runat="server" CssClass="FormButton" Text="Calculate" />
                                    <asp:Button ID="BtnEditDetails" runat="server" CssClass="FormButton" Visible="false"
                                        Text="Edit Details" />
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                </td>
                            </tr>--%>
            <tr>
                <td colspan="2">
                    <div id="dvButton" style="vertical-align: bottom;">
                        <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                            background-repeat: no-repeat;">
                            <tr style="margin-top: 0px;">
                                <td align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" Visible="false"
                                        OnClientClick="saveValidation()" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" Text="Delete" CssClass="FormButton"
                                        OnClientClick="Confirm()" />
                                    <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <%--</div>
        </table>--%>
    </div>
</asp:Content>
