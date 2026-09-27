<%@ Page Title="Tally Interface" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CreditNoteApproval.aspx.vb" Inherits="AdministratorUI_CreditNoteApproval"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $('#InvoiceNo').text(message);
                var dlg = $("#dialog").dialog({
                    title: "Service Details",
                    width: 815,
                    height: 300,

                    resizable: false
                });
                dlg.parent().appendTo(jQuery("form:first"));
                return false;
            });
        };
    </script>
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function checkAll(id) {

            if (document.getElementById("cont") != null) {
                var rowCount = document.getElementById("cont").getElementsByTagName("tr").length;

                var id1 = document.getElementById("<%=chkSelect.Clientid%>").checked;

                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById("ctl00_ContentPlaceHolder1_repIndentDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkIndent")
                    if (chkSelect.disabled == false) {
                        document.getElementById("ctl00_ContentPlaceHolder1_repIndentDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkIndent").checked = id1;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function checkAllLoad(id) {

            if (document.getElementById('cont') != null) {
                var rowCount = document.getElementById('contdtls').getElementsByTagName('tr').length;
                var j = 0;
                var count = 0;
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById('ctl00_ContentPlaceHolder1_repLoadDetails_ctl' + LPad((j + 1) + '', 2, '0') + '_ChkPosition')
                    if (chkSelect.checked == true) {
                        count = count + 1;
                        if (count > 1) {
                            alert("Single selection is permitted")
                            document.getElementById("ctl00_ContentPlaceHolder1_repLoadDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_ChkPosition").checked = false;

                        }
                    }

                }

            }
        }

        function checkAllIndent(id) {

            if (document.getElementById('cont') != null) {
                var rowCount = document.getElementById('cont').getElementsByTagName('tr').length;
                var j = 0;
                var count = 0;
                for (var j = 0; j < rowCount; j++) {
                    var chkSelect = document.getElementById('ctl00_ContentPlaceHolder1_repIndentDetails_ctl' + LPad((j + 1) + '', 2, '0') + '_chkIndent')
                    if (chkSelect.checked == true) {
                        count = count + 1;
                        if (count > 1) {
                            alert("Single selection is permitted")
                            document.getElementById("ctl00_ContentPlaceHolder1_repIndentDetails_ctl" + LPad((j + 1) + "", 2, "0") + "_chkIndent").checked = false;
                        }

                    }

                }

            }
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="CR Note Approval Pending List"
                    CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" Font-Size="20px" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td valign="top" colspan="3">
                <hr />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" id="tblReport" runat="server" width="100%">
                    <tr>
                        <td colspan="2">
                            <table cellpadding="0">
                                <tr style="text-align: center; height: 20px;" class="RepheaderNew">
                                    <td>
                                        <asp:CheckBox ID="chkSelect" Height="20px" runat="server" Width="20px" ToolTip=""
                                            onClick="checkAll(this);"></asp:CheckBox>
                                        <%--<asp:Label ID="Label1" Width="15px" runat="server" CssClass="FormLabel" Text=""></asp:Label>--%>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblCustomerName" Width="340px" Font-Size="12" CssClass="FormLabel"
                                            runat="server" Text="Customer Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblinvoiceNo" Width="150px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="Invoice No"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblInvoiceDate" Width="120px" Font-Size="12" CssClass="FormLabel"
                                            runat="server" Text="Date"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblTax" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="IGST"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label2" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="SGST"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label3" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="CGST"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label1" Width="150px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="Total Amount"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblCrNote" Width="150px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="CR Note"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label5" Width="300px" Font-Size="12" CssClass="FormLabel" runat="server"
                                            Text="Approval CR Note"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        <div style="height: 450px; width: 100%; overflow: auto;">
                                            <asp:Repeater ID="repIndentDetails" runat="server">
                                                <HeaderTemplate>
                                                    <table id="cont" cellspacing="0">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:CheckBox Width="20px" ID="chkIndent" Height="20" runat="server" Enabled="true"
                                                                ToolTip="Select"></asp:CheckBox>
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Width="340px" ID="textCustomerName"
                                                                runat="server" Enabled="false" Text='<%# Eval("Customer_Name") %>' ToolTip="Customer"> </asp:TextBox>
                                                            <asp:HiddenField ID="hdnInvoiceId" runat="server" Value='<%# Eval("CR_ID") %>' />
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Button ID="btnApprove" Width="150px" runat="server" Text='<%# Eval("INVOICE_REF_NO") %>'
                                                                OnClick="Approve" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("INVOICE_DATE") %>'
                                                                Enabled="false" Width="120px" ID="textInvoiceDate" runat="server" ToolTip="Invoice Date">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("IGST") %>'
                                                                Enabled="false" Width="100px" ID="textTaxAmount" runat="server" ToolTip="Tax Amount">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("SGST") %>'
                                                                Enabled="false" Width="100px" ID="TextBox1" runat="server" ToolTip="Tax Amount">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("CGST") %>'
                                                                Enabled="false" Width="100px" ID="TextBox2" runat="server" ToolTip="Tax Amount">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("INVOICE_AMOUNT") %>'
                                                                Enabled="false" Width="150px" ID="textBillAmount" runat="server" ToolTip="Total Amount">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("CR_NOTE") %>'
                                                                Enabled="false" Width="150px" ID="TextBox4" runat="server" ToolTip="Cr Note">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Enabled="true" Visible="true" Text='<%# Eval("CR_APPROVAL_NOTE") %>'
                                                                Width="300px" ID="textCRnoteNew" runat="server" ToolTip="Total Amount">
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
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div id="dialog" style="display: none;">
                    <asp:GridView ID="gridviewcontDtls" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-ForeColor="#004182" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="10px" ItemStyle-CssClass="FormTextBoxNumSmall" ItemStyle-Height="5px"
                                DataField="SR_NO" HeaderText="Sr." />
                            <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="System Service Name" />
                            <asp:BoundField ItemStyle-Width="200px" DataField="BILL_DESCRIPTION" HeaderText="Tally Service Name" />
                            <asp:BoundField ItemStyle-Width="200px" ItemStyle-CssClass="FormTextBoxNumSmall"
                                DataField="CONT_NO" HeaderText="Cont No" />
                            <asp:BoundField ItemStyle-Width="65px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="RATE"
                                HeaderText="Amount" />
                            <asp:BoundField ItemStyle-Width="70px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="TAX_AMOUNT"
                                HeaderText="Tax Amount" />
                            <asp:BoundField ItemStyle-Width="70px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="BILL_AMOUNT"
                                HeaderText="Total Amount" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <table style="background-position: 50% bottom; width: 100%; vertical-align: bottom;">
        <tr>
            <td style="width: 150" align="left">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
            <td align="center" style="width: 83%">
                <asp:Button ID="btnSave" runat="server" Text="Approve" CssClass="FormButton" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
            </td>
            <td style="width: 90px"></td>
        </tr>
    </table>
</asp:Content>
