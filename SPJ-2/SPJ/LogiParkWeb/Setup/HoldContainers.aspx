<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="HoldContainers.aspx.vb" Inherits="Domestic_HoldContainers" Title="eLOGiPark:: Hold Containers"
    Theme="Forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>

    <script language="javascript" type="text/javascript" src="../Script/cont_validation.js">
    </script>

    <script language="javascript" type="text/javascript">

        function ValContNo() {
            var result = false;
            if (validateData(document.getElementById('<%=textContNo.clientId%>'),
                document.getElementById('<%=lblContNo.clientId%>').innerHTML))
                result = true;
            elseW
            result = false;
            else
            result = false;
            return result;
        }

        function ValContNo() {
            var result = false;
            if (validateData(document.getElementById('<%=textContNo.ClientId%>'),
                document.getElementById('<%=lblContNo.ClientId%>').innerHTML))
                result = true;
            else
                result = false;
            return result;
        }

        function saveValidation() {
            var result = false;
            if (validateDropDownIndex(document.getElementById('<%=lstHoldAgency.clientId%>'),
                document.getElementById('<%=lblHoldAgency.clientId%>').innerHTML))
                if (validateDropDownIndex(document.getElementById('<%=lstHoldReason.clientId%>'),
                    document.getElementById('<%=lblHoldReason.clientId%>').innerHTML))
                    if (validateData(document.getElementById('<%=textHoldRemarks.clientId%>'),
                        document.getElementById('<%=lblHoldRemarks.clientId%>').innerHTML))
                        result = true;
                    else
                        result = false;
                else
                    result = false;
            else
                result = false;

            return result;
        }
    </script>
    <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
        <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
            <tr style="height: 20px;">
                <td>
                    <asp:Label ID="lblScreenTitle" runat="server" Width="250px" Text="Hold Containers" CssClass="FormLabelTitle">
                    </asp:Label>
                    <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="FormLabelTitleHr"></td>
            </tr>
            <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                    <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                        <table>
                            <tr style="height: 10px;">
                                <td colspan="5"></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblContNo" runat="server" CssClass="FormLabel" Text="Cont No"></asp:Label>
                                </td>

                                <td style="text-align: left">
                                    <asp:TextBox ID="textContNo" runat="server" CssClass="FormTextBoxMediumMandatory" Width="100px"
                                        onkeypress="if (WebForm_TextBoxKeyHandler(event) == false) return false;javascript:keyPressInput.kp_convert_upper();"
                                        onChange="if(container_validation(this.getAttribute('value'))!= 'True') alert(container_validation(this.getAttribute('value')));"
                                        ToolTip="Cont No" AutoComplete="off" MaxLength="11">
                                    </asp:TextBox>
                                    <asp:Button ID="btnSearchContNo" runat="server" Visible="false" CssClass="FormButton" Text="GO"></asp:Button>

                                    <asp:HiddenField ID="hdnMtyContId" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnHandlingMode" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnDocType" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnLineId" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnHoldId" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnexporterId" runat="server" Value="" />
                                </td>


                                <td style="text-align: left">
                                    <asp:Label ID="lblSize" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="textSize" runat="server" Width="30px" CssClass="RptFormTextBoxMedium">
                                    </asp:TextBox>
                                    <asp:Label ID="lblType" runat="server" CssClass="FormLabel" Text="Type"></asp:Label>
                                    <asp:TextBox ID="textType" runat="server" Width="40px" CssClass="RptFormTextBoxMedium">
                                    </asp:TextBox>
                                    <asp:Button ID="btnAddContNo" runat="server" OnClientClick="return ValContNo();" Visible="false" Text="GO" CssClass="FormButton"></asp:Button>
                                </td>
                                <td style="text-align: left">&nbsp;</td>
                            </tr>

                            <tr>

                                <td style="text-align: left">
                                    <asp:Label ID="lblHoldDate" runat="server" CssClass="FormLabel" Text="HoldDate"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="textHoldDate" runat="server" CssClass="RptFormTextBoxMediumSys"
                                        Width="110px" ToolTip="Hold Date">
                                    </asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblHoldAgency" runat="server" CssClass="FormLabel" Text="Hold Agency"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:DropDownList ID="lstHoldAgency" runat="server" CssClass="FormListBoxMediumMandatory"
                                        Width="120px" ToolTip="Hold Agency">
                                    </asp:DropDownList>
                                </td>


                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblLine" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="textLine" runat="server" CssClass="RptFormTextBoxMedium" ToolTip="Line">
                                    </asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblCustomer" runat="server" CssClass="FormLabel" Text="Customer Name"></asp:Label>
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="textCustomer" runat="server" CssClass="RptFormTextBoxMedium" ToolTip="Customer Name">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>


                                <td style="text-align: left; vertical-align: top">
                                    <asp:Label ID="lblHoldReason" runat="server" CssClass="FormLabel" Text="Hold Reason"></asp:Label>
                                </td>
                                <td style="text-align: left; vertical-align: top">
                                    <asp:DropDownList ID="lstHoldReason" runat="server" CssClass="FormListBoxMediumMandatory"
                                        Width="224px" ToolTip="Hold Reason">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: left; vertical-align: top">
                                    <asp:Label ID="lblHoldRemarks" runat="server" CssClass="FormLabel" Text="Hold Remarks"></asp:Label>
                                </td>
                                <td style="text-align: left; vertical-align: top">
                                    <asp:TextBox ID="textHoldRemarks" runat="server" CssClass="FormTextBoxMediumMandatory" Height="40px"
                                        ToolTip="Hold Remarks" TextMode="MultiLine" onkeypress="convert_upper_ver2(this);">
                                    </asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td runat="server" id="T40" colspan="4" align="center">
                                    <table style="border: solid; border-width: thin;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:CheckBox ID="chkRelease" runat="server" CssClass="FormCheckBox" Text="Release" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReleaseDate" runat="server" CssClass="FormLabel" Text="ReleaseDate"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="txtReleaseDate" AutoComplete="OFF" runat="server" CssClass="FormTextBoxMediumMandatory"
                                                    Width="110px" ToolTip="Release Date" onKeyDown="TabButton();" onpaste="return false;">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clReleaseDate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="txtReleaseDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top">
                                                <asp:Label ID="lblReleaseRemarks" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textReleaseRemarks" runat="server" CssClass="FormTextBoxMediumMandatory" TextMode="MultiLine"
                                                    Height="40px" ToolTip="Release Remarks" onkeypress="convert_upper_ver2(this);">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="text-align: left; vertical-align: top">&nbsp;</td>
                                <td style="text-align: left; vertical-align: top">&nbsp;</td>
                                <td style="text-align: left; vertical-align: top">&nbsp;</td>

                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height: 30px;" colspan="4"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="dvButton" style="vertical-align: bottom;">
                        <table width="100%" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                            <tr style="margin-top: 0px;">
                                <td align="center">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" Visible="false" />
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                    <asp:Button ID="btnSave" runat="server" Visible="false" Text="Save" CssClass="FormButton"
                                        OnClientClick="return saveValidation();" />
                                    <asp:Button ID="btnPrint" runat="server" Visible="false" Text="Print" CssClass="FormButton" />
                                    <asp:Button ID="btnCancel" runat="server" Visible="false" Text="Cancel" CssClass="FormButton" />
                                    <asp:Button ID="btnExit" runat="server" Visible="false" Text="Exit" CssClass="FormButton" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
