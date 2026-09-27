<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DeditNote.aspx.vb" Inherits="Commercial_DeditNote" Title="LogiPark:: Debit Note Generation"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
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
    <script type='text/javascript'>
        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            for (var j = 0; j < 222; j++) {
                var msg = "Sorry, this functionality is disabled.";
                if (parseInt(code) == j + 1) //CTRL
                {
                    window.event.returnValue = false;
                }
            }
        }
        
    </script>
    <script type="text/javascript">
        function Rate(id) {
            var strsbno = "_txtBillRate";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            var textQuntity = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textQuntity");
            var textRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textRate");
            var textAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textAmount");
            var textServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textServiceTax");
            var textEducTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textEducTax");
            var textHEduTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textHEduTax");
            var textTaxAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTaxAmount");
            var textTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTotalAmount");
            var HdnIgstPer = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_HdnIgstPer").value;
            var Hdnsgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_Hdnsgstper").value;
            var hdncgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_hdncgstper").value;
            var Rate = parseFloat(textRate.value) * parseFloat(textQuntity.value);
            textAmount.value = Rate;

            textServiceTax.value = parseFloat(Rate) / 100 * parseFloat(HdnIgstPer);
            textEducTax.value = parseFloat(Rate) / 100 * parseFloat(Hdnsgstper);
            textHEduTax.value = parseFloat(Rate) / 100 * parseFloat(hdncgstper);
            textTaxAmount.value = parseFloat(textServiceTax.value) + parseFloat(textEducTax.value) + parseFloat(textHEduTax.value);
            textTotalAmount.value = parseFloat(Rate) + parseFloat(textTaxAmount.value);
        }
        function qnty(id) {
            var strsbno = "_textQuntity";
            var tablename = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 2, id.getAttribute('Id').indexOf(strsbno));
            var textQuntity = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textQuntity");
            var textRate = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textRate");
            var textAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textAmount");
            var textServiceTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textServiceTax");
            var textEducTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textEducTax");
            var textHEduTax = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textHEduTax");
            var textTaxAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTaxAmount");
            var textTotalAmount = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_textTotalAmount");
            var HdnIgstPer = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_HdnIgstPer").value;
            var Hdnsgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_Hdnsgstper").value;
            var hdncgstper = document.getElementById("ctl00_ContentPlaceHolder1_Repeater1_ctl" + tablename + "_hdncgstper").value;
            var Rate = parseFloat(textRate.value) * parseFloat(textQuntity.value);
            textAmount.value = Rate;
            textServiceTax.value = parseFloat(Rate) / 100 * parseFloat(HdnIgstPer);
            textEducTax.value = parseFloat(Rate) / 100 * parseFloat(hdncgstper);
            textHEduTax.value = parseFloat(Rate) / 100 * parseFloat(Hdnsgstper);
            textTaxAmount.value = parseFloat(textServiceTax.value) + parseFloat(textEducTax.value) + parseFloat(textHEduTax.value);
            textTotalAmount.value = parseFloat(Rate) + parseFloat(textTaxAmount.value);
        }
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Dedit Note" CssClass="FormLabelTitle"> </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"> </asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 300px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td>
                                                <table width="100%" style="border-color: White;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCreditRefNo" runat="server" CssClass="FormLabel" Text="Debit No "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textCreditRefNo" Width="130px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="Credit No"> </asp:TextBox>
                                                            <asp:HiddenField ID="hdnDrId" runat="server" />
                                                            <asp:Button ID="BtnSearchCredit" runat="server" Visible="false" Width="30px" Text="Go"
                                                                CssClass="FormButton" Height="20px" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCreditDate" runat="server" CssClass="FormLabel" Text="Debit Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textCreditDate" runat="server" Width="121px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Credit Date"> </asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="textToDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="textCreditDate" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceRefNo" runat="server" CssClass="FormLabel" Text="Purchase Invoice No"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceRefNo" Width="130px" runat="server" CssClass="FormTextBoxSmall"
                                                                ToolTip="Invoice No"> </asp:TextBox>
                                                            <asp:Button ID="btnSearchInvoice" runat="server" Visible="false" Width="30px" Text="Go"
                                                                CssClass="FormButton" Height="20px" />
                                                            <asp:Button ID="btnAddInvoice" runat="server" Visible="false" Width="30px" Text="Go"
                                                                CssClass="FormButton" Height="20px" />
                                                            <asp:HiddenField ID="hdnCostId" runat="server" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblInvoiceDate" runat="server" CssClass="FormLabel" Text="Invoice Date "></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textInvoiceDate" runat="server" Width="121px" CssClass="FormTextBoxSmall"
                                                                ToolTip="Invoice Date"> </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label4" runat="server" CssClass="FormLabel" Text="Customer/Vendor"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList CssClass="ddlMedium" AutoPostBack="True" runat="server" ID="lstCustomer">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField runat="server" ID="hdnCmnyId" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Label5" runat="server" CssClass="FormLabel" Text="Purchase Type"></asp:Label>
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblNote1" runat="server" CssClass="FormLabel" Text="Debit Note "></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:TextBox ID="textNote1" runat="server" Width="463px" CssClass="FormTextBoxSmall"
                                                                TextMode="MultiLine" ToolTip="Note" Height="40px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 250px; border-left-color: Black;">
                                                    <asp:TreeView ID="tvInvoices" runat="server" Style="font-family: Verdana; font-size: 12px"
                                                        Width="144px">
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="Div1" style="text-align: left; overflow: auto; height: 160px;">
                                        <table cellspacing="0" align="Center">
                                            <tr class="RepHead" align="center">
                                                <td style="width: 17px">
                                                    <asp:CheckBox ID="ChkSelect1" runat="server" CssClass="FormCheckBox" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" Width="250px" CssClass="FormLabel" runat="server" Text="Service"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" Width="30px" CssClass="FormLabel" runat="server" Text="Qnty"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" Width="30px" CssClass="FormLabel" runat="server" Text="Rate"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" Width="30px" CssClass="FormLabel" runat="server" Text="Ex Rate"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" Width="60px" CssClass="FormLabel" runat="server" Text="Bill Amount"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label8" Width="80px" CssClass="FormLabel" runat="server" Text="Debit Amount"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" Width="60px" CssClass="FormLabel" runat="server" Text="IGST"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" Width="60px" CssClass="FormLabel" runat="server" Text="SGST"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Width="65px" CssClass="FormLabel" Text="CGST"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" Width="70px" CssClass="FormLabel" runat="server" Text="Dr Tax Amount"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label13" Width="80px" CssClass="FormLabel" runat="server" Text="Dr Total Amount"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="13" valign="top">
                                                    <div class="RepScroling" style="height: 100px;">
                                                        <asp:Repeater ID="Repeater1" runat="server">
                                                            <HeaderTemplate>
                                                                <table id="cont" cellspacing="0" style="margin-left: 0px; margin-right: 0px;">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="width: 17px">
                                                                        <asp:CheckBox ID="ChkCredit" runat="server" CssClass="FormCheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="textService" runat="server" Enabled="false" CssClass="FormListBoxMedium"
                                                                            Width="250px" Text='<%# Eval("ServiceId") %>' ToolTip="Service" OnDataBinding="prepareService">
                                                                        </asp:DropDownList>
                                                                        <asp:HiddenField ID="hdnInvoiceNo" Value='<%# Eval("CostId") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdnServiceId" Value='<%# Eval("ServiceId") %>' runat="server" />
                                                                        <asp:HiddenField ID="HdnIgstPer" Value='<%# Eval("IGSTRate") %>' runat="server" />
                                                                        <asp:HiddenField ID="Hdnsgstper" Value='<%# Eval("CGSTRate") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdncgstper" Value='<%# Eval("SGSTRate") %>' runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textQuntity" AutoPostBack="true" runat="server" Text='<%# Eval("BillQnty") %>'
                                                                            ToolTip="Quantity" CssClass="FormTextBoxNumeric" Width="30px" OnTextChanged="checkQnty">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtBillRate" AutoPostBack="true" runat="server" Text='<%# Eval("BillRate") %>'
                                                                            ToolTip="Quantity" CssClass="FormTextBoxNumeric" Width="30px" OnTextChanged="checkRate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtExRate" AutoPostBack="true" runat="server" Text='<%# Eval("ExRate") %>'
                                                                            ToolTip="Quantity" CssClass="FormTextBoxNumeric" Width="30px" OnTextChanged="checkExRate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtBillAmt" runat="server" Enabled="True" CssClass="FormTextBoxNumeric"
                                                                            Width="60px" Text='<%#  Eval("BillAmt") %>' ToolTip="Rate">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textDrAmt" runat="server" CssClass="RptFormTextBoxNumeric" Width="80px"
                                                                            Text='<%# Eval("DrAmt") %>' ToolTip="Amount" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textIGST" runat="server" CssClass="RptFormTextBoxNumeric" Width="60px"
                                                                            Text='<%# Eval("IGST") %>' ToolTip="Service Tax" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textEducTax" runat="server" CssClass="RptFormTextBoxNumeric" Width="60px"
                                                                            Text='<%# Eval("SGST") %>' ToolTip="Educ Tax" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textHEduTax" runat="server" CssClass="RptFormTextBoxNumeric" Width="65px"
                                                                            Text='<%# Eval("CGST") %>' ToolTip="HEdu Tax" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textDrTaxAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                            Width="70px" Text='<%# Eval("DrTax") %>' ToolTip="Tax Amount" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
                                                                        <%--<asp:HiddenField ID="hdnTaxPerc" Value='<%# Eval("TaxPerc") %>' runat="server" />--%>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textDrTotalAmount" runat="server" CssClass="RptFormTextBoxNumeric"
                                                                            Width="80px" Text='<%# string.Format("{0:n2}", (Eval("DrAmt") + Eval("DrTax"))) %>'
                                                                            ToolTip="Total Amount" AutoPostBack="true" onKeyDown="return noCTRL(event)">
                                                                        </asp:TextBox>
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
                                            <tr align="center">
                                                <td style="width: 17px">
                                                </td>
                                                <td style="width: 250px">
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblQnty" Width="30px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblRate" Width="30px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblExRate" Width="30px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblBillAmt" Width="60px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDebitAmt" Width="80px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblIGST" Width="60px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblSGST" Width="60px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCGST" runat="server" Width="65px" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDrTaxAmt" Width="70px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDrTotalAmt" Width="80px" CssClass="FormLabel" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="chkInvoiceChecked" runat="server" CssClass="FormLabel" Text="Invoice Checked" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="FormButton" Text="Add" />
                                                <asp:Button ID="btnSearch" runat="server" CssClass="FormButton" Text="Search" />
                                                <asp:Button ID="btnPrint" runat="server" CssClass="FormButton" Text="Print" />
                                                <asp:Button ID="btnSave" runat="server" CssClass="FormButton" Text="Save" />
                                                <asp:Button ID="BtnDelete" runat="server" CssClass="FormButton" Text="Delete" Visible="false"
                                                    OnClientClick="Confirm()" />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="FormButton" Text="Cancel" />
                                                <asp:Button ID="btnExit" runat="server" CssClass="FormButton" Text="Exit" />
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
