<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Master/Admin/TerminalMaster.aspx.vb" Inherits="Master_Admin_TerminalMaster"
    Title="eLogiFleet:: Terminal Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript">
        function saveValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textTerminalCode.clientId %>'),
                document.getElementById('<%=lblTerminalCode.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textTerminalName.clientId %>'),
                    document.getElementById('<%=lblTerminalName.clientId %>').innerHTML))
                    if (validateData(document.getElementById('<%=textAddress.clientId %>'),
                        document.getElementById('<%=lblAddress.clientId %>').innerHTML))
                        if (validateDropDownIndex(document.getElementById('<%=lstCountry.clientId %>'),
                            document.getElementById('<%=lblCountry.clientId %>').innerHTML))
                          if (validateDropDownIndex(document.getElementById('<%=lstCountry.clientId %>'),
                              document.getElementById('<%=lblCountry.clientId %>').innerHTML))
                           if (validateData(document.getElementById('<%=textServiceTaxNo.clientId %>'),
                               document.getElementById('<%=lblServiceTaxNo.clientId %>').innerHTML))


                                    result = true;
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



    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr style="height: 20px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Terminal Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
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
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">

                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTerminalCode" runat="server" Text="Terminal Code" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTerminalCode" runat="server" CssClass="textbox" ToolTip="Terminal Code"
                                                    onkeypress="kp_convert_upper()" MaxLength="10" Width="110px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnTerminalId" runat="server" Value="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTerminalName" runat="server" Text="Terminal Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTerminalName" runat="server" Width="250px" CssClass="textbox" ToolTip="Terminal Name"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="LblGroup" runat="server" Text="Terminal Group" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="LstTerminalGroup" runat="server" Width="250px" CssClass="ddlMedium" ToolTip="Terminal Group"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblAddress" runat="server" CssClass="label" Text="Address"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAddress" Rows="3" runat="server" CssClass="textbox"
                                                    TextMode="MultiLine" Height="35px" Width="250px" ToolTip="Address">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblCountry" runat="server" Text="Country" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="lstCountry" runat="server" Width="185px" CssClass="ddlMedium" ToolTip="Country">
                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="India" Value="I"></asp:ListItem>
                                                </asp:DropDownList>
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
                                                <asp:TextBox ID="textContactPerson" runat="server" Width="180px" CssClass="textbox" ToolTip="Contact Person"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailId" runat="server" CssClass="label" Text="Email ID"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailId" runat="server" Width="180px" CssClass="textbox" ToolTip="Email ID"
                                                    onchange="validateEmail()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" CssClass="textbox" ToolTip="Contact No"
                                                    onkeypress="kp_integer()" MaxLength="10" Width="110px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblServiceTaxNo" runat="server" CssClass="label" Text="IR No."></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textServiceTaxNo" runat="server" CssClass="textbox" ToolTip="IR No."
                                                    onkeypress="kp_convert_upper()" MaxLength="10" Width="110px"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblExportCartingRate" runat="server" CssClass="label" Text="Export Carting Rate"
                                                    Visible="false"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textExportCartingRate" runat="server" CssClass="textbox"
                                                    ToolTip="Export Carting Rate" onkeypress="kp_numeric()" MaxLength="7" Width="110px" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblExportCartingMinWt" runat="server" CssClass="label" Text="Export Carting Min Wt" Visible="false"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textExportCartingMinWt" runat="server" CssClass="textbox"
                                                    ToolTip="Export Carting Min WT" onkeypress="kp_numeric()" MaxLength="7" Width="110px" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div id="dvCtr" runat="server" style="border-style: none; vertical-align: top;">
                                                    <table cellspacing="0">
                                                        <tr class="RepHead">
                                                            <td>
                                                                <asp:Label ID="lblLocation" Width="260px" runat="server" CssClass="FormLabel" Text='Location<span class="mandatory"> *</span>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDistance" Width="110px" runat="server" CssClass="FormLabel" Text='Distance (Km)<span class="mandatory"> *</span>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" valign="top" align="center">
                                                                <div class="RepScroling" style="height: 150px; overflow: auto;">
                                                                    <asp:Repeater ID="repLocation" runat="server">
                                                                        <HeaderTemplate>
                                                                            <table id="Location" cellspacing="0">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:HiddenField ID="hdnLocationId" Value='<%# Eval("LocationId") %>' runat="server" />
                                                                                    <asp:TextBox class="textbox" ID="textLocation" runat="server" onkeyup="this.value=this.value.toUpperCase();"
                                                                                        MaxLength="150" Text='<%# Eval("LocationName") %>' Width="250px" ToolTip="Location">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox class="textbox" ID="textDistance" runat="server" onkeypress="kp_numeric();"
                                                                                        MaxLength="5" Text='<%# Eval("Distance") %>' Width="80px" ToolTip="Distance">
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
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">&nbsp;
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
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
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
