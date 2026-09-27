<%@ Page Title="Debit Note Tally Interface" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DebitNoteTallyInterface.aspx.vb" Inherits="AdministratorUI_DebitNoteTallyInterface"
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

                    var id1 = document.getElementById("<%=chkSelect.clientid%>").checked;

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
            <td valign="top" style="width: 20%">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Debit Note Voucher Approval" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top" style="width: 80%">
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" Font-Size="20px" runat="server"></asp:Label>
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
                                <tr style="text-align: center; height:20px;"  class="RepHeadFleet">
                                      <td>
                         
                                                    <asp:CheckBox ID="chkSelect" Height="20px" runat="server" Width="30px" ToolTip="" onClick="checkAll(this);"></asp:CheckBox>
                                                    <%--<asp:Label ID="Label1" Width="15px" runat="server" CssClass="FormLabel" Text=""></asp:Label>--%>
                                                
                        </td>
                        <td>
                            <asp:Label ID="lblCustomerName" Width="200px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Customer Name"></asp:Label>
                        </td>
                                 <td>
                            <asp:Label ID="Label2" Width="200px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Tally Customer Name"></asp:Label>
                        </td>
                      
                        <td>
                            <asp:Label ID="lblinvoiceNo" Width="150px" Font-Size="12" CssClass="FormLabel" runat="server" Text="Credit Note No"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Credit Note Date"></asp:Label>
                        </td>
                            <td>
                            <asp:Label ID="Label3" Width="200px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Invoice No"></asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label4" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Invoice Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceAmount" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server"
                                Text="Credit Amount"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTax" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server" Text="Tax Amount"></asp:Label>
                        </td>
                   
                        <td>
                            <asp:Label ID="Label1" Width="100px" Font-Size="12" CssClass="FormLabel" runat="server" Text="Total Amount"></asp:Label>
                        </td>
                                    <td width="5px" style="background-color: White;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="11">
                                        <div style="height: 450px; width:100%; overflow: auto;">
                                            <asp:Repeater ID="repIndentDetails" runat="server">
                                    <HeaderTemplate>
                                        <table id="cont" cellspacing="0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:CheckBox Width="20px" ID="chkIndent" Height="20" runat="server" Enabled="true" ToolTip="Select">
                                                </asp:CheckBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Width="200px" ID="textCustomerName" runat="server"
                                                    Enabled="false" Text='<%# Eval("Customer_Name") %>' ToolTip="Customer"> </asp:TextBox>
                                                <asp:HiddenField ID="hdnInvoiceId" runat="server" Value='<%# Eval("DR_ID") %>' />
                                                 <asp:HiddenField ID="hdnNote" runat="server" Value='<%# Eval("DR_NOTE") %>' />
                                             
                                            </td>
                                              <td style="text-align: left">
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Width="200px" ID="textTallyCustomerName" runat="server"
                                                    Enabled="false" Text='<%# Eval("TALLY_CUSTOMER_NAME") %>' ToolTip="Customer"> </asp:TextBox>
                                            </td>
                                        
                                            <td>
                                                <asp:LinkButton CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("DR_REF_NO") %>' 
                                                    Width="150px" ID="textInvoiceNo"  CommandArgument='<%# Eval("DR_ID" )%>'
                                                  OnClick="OnClickHandler" runat="server" ToolTip="Invoice No">
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("DR_DATE") %>' Enabled="false"
                                                    Width="100px" ID="textInvoiceDate" runat="server" ToolTip="Invoice Date">
                                                </asp:TextBox>
                                            </td>
                                                           <td>
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("LINER_INV_NO") %>' Enabled="false"
                                                    Width="200px" ID="txtBLNo" runat="server" ToolTip="BL No">
                                                </asp:TextBox>
                                            </td>

                                              <td>
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("LINER_INV_DATE") %>' Enabled="false"
                                                    Width="100px" ID="txtMainInvoiceDate" runat="server" ToolTip="Invoice Date">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("DR_AMOUNT") %>' Enabled="false"
                                                    Width="100px" ID="textAmount" runat="server" ToolTip="Amount">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12" Text='<%# Eval("DR_TAX") %>' Enabled="false"
                                                    Width="100px" ID="textTaxAmount" runat="server" ToolTip="Tax Amount">
                                                </asp:TextBox>
                                      
                                              
                                            <td style="text-align: right">
                                                <asp:TextBox CssClass="FormTextBoxLarg" Font-Size="12"  Text='<%# Eval("DR_TOTAL_AMOUNT") %>' Enabled="false"
                                                    Width="100px" ID="textBillAmount" runat="server" ToolTip="Total Amount">
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
                            <asp:BoundField ItemStyle-Width="10px" ItemStyle-CssClass="FormTextBoxNumSmall" ItemStyle-Height="5px" DataField="SR_NO" HeaderText="Sr." />
                             <asp:BoundField ItemStyle-Width="200px" DataField="SERVICE_NAME" HeaderText="System Service Name" />
                            <asp:BoundField ItemStyle-Width="200px" DataField="TALLY_SERVICE_NAME" HeaderText="Tally Service Name" />
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
               <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnApprove.png" /> 
                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btncancel.png" />
                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnexit.png" /> 
            </td>
            <td style="width: 90px">
            </td>
        </tr>
    </table>
</asp:Content>
