<%@ Page Title="Tally Interface" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="InvoiceTallyInterfaceOld.aspx.vb" Inherits="AdministratorUI_InvoiceTallyInterfaceOld"
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
                    width: 530,
                    height: 158,

                    resizable: false
                });
                dlg.parent().appendTo(jQuery("form:first"));
                return false;
            });
        };
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
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Sales Voucher Approval" Width="200px" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0"  width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" id="tblReport" runat="server"  width="100%"> 
                    
                     <tr>
                        <td colspan="2">
                            <table cellpadding="0">
                                <tr style="text-align: center; height:20px;" class="RepheaderNew">
                                      <td>
                            <asp:Label ID="lblSelect" Width="20px" CssClass="FormLabel" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustomerName" Width="180px" CssClass="FormLabel" runat="server"
                                Text="Customer Name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBookingNo" Width="80px" CssClass="FormLabel" runat="server" Text="Booking No"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBookingDate" Width="80px" CssClass="FormLabel" runat="server" Text="Booking Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblinvoiceNo" Width="140px" CssClass="FormLabel" runat="server" Text="Invoice No"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate" Width="88px" CssClass="FormLabel" runat="server"
                                Text="Invoice Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceAmount" Width="85px" CssClass="FormLabel" runat="server"
                                Text="Amount"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTax" Width="85px" CssClass="FormLabel" runat="server" Text="Tax Amount"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" Width="85px" CssClass="FormLabel" runat="server" Text="Total Amount"></asp:Label>
                        </td>
                                    <td width="15px" style="background-color: White;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <div style="height: 350px; width:100%; overflow: auto;">
                                            <asp:Repeater ID="repIndentDetails" runat="server">
                                    <HeaderTemplate>
                                        <table id="cont" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:CheckBox Width="20px" ID="chkIndent" runat="server" Enabled="true" ToolTip="Select">
                                                </asp:CheckBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="180px" ID="textCustomerName" runat="server"
                                                    Enabled="false" Text='<%# Eval("Customer_Name") %>' ToolTip="Customer"> </asp:TextBox>
                                                <asp:HiddenField ID="hdnInvoiceId" runat="server" Value='<%# Eval("INVOICE_NO") %>' />
                                             
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxSmall" Enabled="false" Width="80px" Text='<%# Eval("CONT_JO_NO") %>'
                                                    ID="textBookingNo" runat="server" ToolTip="Booking No">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxSmall" Width="80px" Enabled="false" ID="textBookingDate"
                                                    runat="server" Text='<%# Eval("BOOKING_DATE") %>' ToolTip="Booking Date">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:LinkButton CssClass="FormTextBoxSmall" Text='<%# Eval("INVOICE_REF_NO") %>' 
                                                    Width="140px" ID="textInvoiceNo"  CommandArgument='<%# Eval("INVOICE_NO" )%>'
                                                  OnClick="OnClickHandler" runat="server" ToolTip="Invoice No">
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxSmall" Text='<%# Eval("INVOICE_DATE") %>' Enabled="false"
                                                    Width="88px" ID="textInvoiceDate" runat="server" ToolTip="Invoice Date">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxNumeric" Text='<%# Eval("AMOUNT") %>' Enabled="false"
                                                    Width="85px" ID="textAmount" runat="server" ToolTip="Amount">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxNumeric" Text='<%# Eval("TAX_AMOUNT") %>' Enabled="false"
                                                    Width="85px" ID="textTaxAmount" runat="server" ToolTip="Tax Amount">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxNumeric" Text='<%# Eval("INVOICE_AMOUNT") %>' Enabled="false"
                                                    Width="85px" ID="textBillAmount" runat="server" ToolTip="Total Amount">
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
                    <asp:Label ID="lblSbNo" Text="Invoice No:" CssClass="FormLabelTitle" Font-Size="Small"
                        runat="server"></asp:Label>
                    <span id="InvoiceNo" class="FormLabel"></span>
                    <br />
                    <asp:GridView ID="gridviewcontDtls" ShowHeader="True" AutoGenerateColumns="false"
                        RowStyle-Font-Size="Small" runat="server" Height="40px" HeaderStyle-Font-Size="Small"
                        HeaderStyle-ForeColor="#004182" RowStyle-CssClass="FormLabel">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="10px" ItemStyle-CssClass="FormTextBoxNumSmall" ItemStyle-Height="5px" DataField="SR_NO" HeaderText="Sr." />
                            <asp:BoundField ItemStyle-Width="200px" DataField="BILL_DESCRIPTION" HeaderText="Service" />
                            <asp:BoundField ItemStyle-Width="200px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="CONT_NO" HeaderText="Cont No" />
                            <asp:BoundField ItemStyle-Width="65px"  ItemStyle-CssClass="FormTextBoxNumSmall" DataField="RATE" HeaderText="Amount" />
                             <asp:BoundField ItemStyle-Width="70px" ItemStyle-CssClass="FormTextBoxNumSmall" DataField="TAX_AMOUNT" HeaderText="Tax Amount" />
                             <asp:BoundField ItemStyle-Width="70px"  ItemStyle-CssClass="FormTextBoxNumSmall" DataField="BILL_AMOUNT" HeaderText="Total Amount" />

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
            <td style="width: 90px">
            </td>
        </tr>
    </table>
</asp:Content>
