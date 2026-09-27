<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="MovementHistoryReportNew.aspx.vb" Inherits="Reports_Fleet_MovementHistoryReportNew"
    Title="eLOGiFreight :: Movement History Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .active-link {
            color: blue !important;
            font-weight: normal;
        }
        .active-row td {
            background-color: #cce5ff !important;
            font-weight: normal;
        }
    </style>

    <%-- External validation script - standalone, no inline code --%>
    <script language="javascript" type="text/javascript" src="../../Script/validation.js"></script>

    <%-- Hidden field to persist selected container across postbacks --%>
    <asp:HiddenField ID="hdnSelectedCont" runat="server" />

    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Movement History Report" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <hr />
            </td>
        </tr>
    </table>

    <table width="100%">
        <tr style="padding: 5px; display: block; padding-left: 0px;">
            <td>
                <asp:RadioButton ID="rbContainer" runat="server"
                    GroupName="SearchType" Text="Search by Container No"
                    AutoPostBack="true" />
                <asp:RadioButton ID="rbInvoice" runat="server"
                    GroupName="SearchType" Text="Search by Shipper Invoice No"
                    AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblContNo" runat="server" Text="Container/Shipper Invoice No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContNo" runat="server" ToolTip="Container No" Width="120px" CssClass="FormTextBoxDate"
                                onkeypress="kp_convert_upper();" MaxLength="30">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Button ID="btnSearchContainer" runat="server" Text="Go" CssClass="FormButton" />
                        </td>
                        <td style="text-align: left">
                            &nbsp;
                        </td>
                           <td style="text-align: right">
                           <asp:Button ID="btnDisplay" runat="server" Text="Go" CssClass="FormButton" />
                         </td>
                        <td>
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px"></td>
                    </tr>
                </table>
                <table id="tblCont" runat="server">
                    <tr>
                        <td style="text-align: left;">
                            <asp:Label ID="lblrContSize" CssClass="FormLabel" runat="server" Visible="false" Text="Size" Width="30px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textSize" runat="server" ToolTip="Size" Enabled="false" Visible="false" Width="20px" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblrContType" CssClass="FormLabel" runat="server" Visible="false" Text="Type" Width="30px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textContType" runat="server" ToolTip="Type" Enabled="false" Visible="false" Width="20px" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Visible="false" Text="Doc Type" Width="55px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textDocType" runat="server" ToolTip="Doc Type" Enabled="false" Visible="false" Width="60px" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblTerminal" CssClass="FormLabel" runat="server" Visible="false" Text="Terminal" Width="50px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textTerminal" runat="server" ToolTip="Terminal" Enabled="false" Visible="false" Width="80px" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            <asp:Label ID="lblHandlingMode" CssClass="FormLabel" runat="server" Visible="false" Text="Handling Mode" Width="85px"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textHandlingMode" runat="server" ToolTip="Handling Mode" Enabled="false" Visible="false" Width="80px" CssClass="RptFormTextBoxMedium"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td align="left" valign="top">
                <div>
                    <table cellspacing="0" cellpadding="0" id="tblReporTNew" runat="server">
                        <tr class="RepheaderNew" style="height: 30px">
                            <td style="text-align: center">
                                <asp:Label ID="Label3" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr. No" Width="48px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Container No" Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label5" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size" Width="80px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Line" Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label8" CssClass="FormLabel" runat="server" Font-Bold="True" Text="POL" Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label1" CssClass="FormLabel" runat="server" Font-Bold="True" Text="POD" Width="100px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label2" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Party Invoice No" Width="150px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label10" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vessel" Width="150px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="Label11" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ETD" Width="150px"></asp:Label>
                            </td>
                             <td style="text-align: center">
                                <asp:Label ID="Label6" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Remarks" Width="150px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;"></td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <div style="height: 100px; width: 100%; overflow: auto;">
                                    <asp:GridView ID="gvMovementHistoryReportNew" ShowHeader="False"
                                        AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg"
                                        AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="48px" DataField=""></asp:BoundField>
                                            <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                                <ItemTemplate>
                                                    <asp:LinkButton
                                                        runat="server"
                                                        ID="lnkInvoice"
                                                        Width="120px"
                                                        CssClass="lnk"
                                                        CommandArgument='<%# Eval("CONT_NO") %>'
                                                        Text='<%# Eval("CONT_NO") %>'
                                                        OnClick="OnClickHandlerStatus"
                                                        OnClientClick="setActive(this);">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="80px" DataField="CONT_SIZE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POL"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POD"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="PARTY_INV_NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REQUIRED_VESSEL"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="REQUIRED_ETD"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="COD_REMARK"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>

        <tr>
            <td align="left" valign="top">
                <div>
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="15">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label>
                                <asp:Label ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew" style="height: 30px">
                            <td style="text-align: center">
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr. No" Width="52px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblActivity" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Activity Description" Width="351px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblDocNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Document No" Width="200px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblActivityDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Activity Date" Width="144px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblUserId" CssClass="FormLabel" runat="server" Font-Bold="True" Text="User Id" Width="144px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblUpdatedOn" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Updated On" Width="144px"></asp:Label>
                            </td>
                            <td style="text-align: center">
                                <asp:Label ID="lblremarks" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Remarks" Width="144px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;"></td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div style="height: 500px; width: 100%; overflow: auto;">
                                    <asp:GridView ID="gvMovementHistory" ShowHeader="False"
                                        AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg"
                                        AutoGenerateColumns="False" runat="server">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="48px" DataField=""></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="350px" DataField="ACTIVITY_NAME"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="DOC_NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="ACTIVITY_DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="CREATED_BY"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="CREATED_ON"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="140px" DataField="REMARKS"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>

    </table>

    <script language="javascript" type="text/javascript">

        // Called when user clicks a container link
        function setActive(el) {
            // Save the clicked container text into the hidden field so it survives postback
            var hiddenField = document.getElementById('<%= hdnSelectedCont.ClientID %>');
            if (hiddenField) {
                hiddenField.value = el.innerText.trim();
            }
        }

        // After postback, re-apply the highlight by reading the hidden field value
        window.onload = function () {
            var hiddenField = document.getElementById('<%= hdnSelectedCont.ClientID %>');
            if (!hiddenField || hiddenField.value === '') return;

            var selectedCont = hiddenField.value.trim();

            // Find all link buttons in the grid
            var allLinks = document.querySelectorAll('.lnk');
            allLinks.forEach(function (link) {
                if (link.innerText.trim() === selectedCont) {
                    // Remove any previous highlights
                    document.querySelectorAll('.active-row').forEach(function (r) {
                        r.classList.remove('active-row');
                    });
                    // Highlight the matching row
                    var parentRow = link.closest('tr');
                    if (parentRow) {
                        parentRow.classList.add('active-row');
                    }
                }
            });
        };

    </script>

</asp:Content>