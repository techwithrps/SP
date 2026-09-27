<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/VehicleStatus.aspx.vb" Inherits="Fleet_VehicleStatus" Title="eLOGiFleet :: Vehicle Master"
    Theme="Forms" %>

<%@ Register Src="~/UserControl/DateTimeTextBox.ascx" TagPrefix="uc1" TagName="DateTimeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .highlight {
            background-color: rebeccapurple;
            color: white;
        }

        .normal {
            background-color: none;
            color: black;
        }
    </style>
    <style type="text/css">
        .selected {
            background-color: blue;
        }

        .unSelected {
            background-color: white;
        }
    </style>
    <script type="text/javascript">
        function CheckChanged(ctrl) {
            var textICDOutDate = document.getElementById(ctrl.id.replace("chkSelect", "textIcdOut") + "_textDateTime");
            var textFactoryIn = document.getElementById(ctrl.id.replace("chkSelect", "textFactoryIn") + "_textDateTime");
            var textFactoryOut = document.getElementById(ctrl.id.replace("chkSelect", "textFactoryOut") + "_textDateTime");
            var textICDLadenGateInDate = document.getElementById(ctrl.id.replace("chkSelect", "textIcdIn") + "_textDateTime");
            var txtBufferInDate = document.getElementById(ctrl.id.replace("chkSelect", "textBufferInDate") + "_textDateTime");
            var txtBufferOutDate = document.getElementById(ctrl.id.replace("chkSelect", "textBufferOutDate") + "_textDateTime");
            var txtMtyGateInDate = document.getElementById(ctrl.id.replace("chkSelect", "textEmptyGateInDate") + "_textDateTime");

            var selectedRow = ctrl.closest('tr').closest('table').closest('tr');

            if (ctrl.checked === true) {
                selectedRow.classList.toggle("selected");
            }
            else {
                selectedRow.classList.toggle("unSelected");
            }

            if (textICDOutDate.value === '') {
                if (ctrl.checked === true) {
                    textICDOutDate.value = document.getElementById('<%= textICDOutDate.ClientID%>' + '_textDateTime').value;
                } else {
                    textICDOutDate.value = '';
                }
            }

            if (textFactoryIn.value === '') {
                if (ctrl.checked === true) {
                    textFactoryIn.value = document.getElementById('<%= textFactoryInDate.ClientID%>' + '_textDateTime').value;
                } else {
                    textFactoryIn.value = '';
                }
            }

            if (textFactoryOut.value === '') {
                if (ctrl.checked === true) {
                    textFactoryOut.value = document.getElementById('<%= textFactoryOutDate.ClientID%>' + '_textDateTime').value;
                } else {
                    textFactoryOut.value = '';
                }
            }

            if (textICDLadenGateInDate.value === '') {
                if (ctrl.checked === true) {
                    textICDLadenGateInDate.value = document.getElementById('<%= textICDLadenGateInDate.ClientID%>' + '_textDateTime').value;
                } else {
                    textICDLadenGateInDate.value = '';
                }
            }

            if (txtBufferInDate.value === '') {
                if (ctrl.checked === true) {
                    txtBufferInDate.value = document.getElementById('<%= textBufferInDate.ClientID%>' + '_textDateTime').value;
                } else {
                    txtBufferInDate.value = '';
                }
            }

            if (txtBufferOutDate.value === '') {
                if (ctrl.checked === true) {
                    txtBufferOutDate.value = document.getElementById('<%= textBufferOutDate.ClientID%>' + '_textDateTime').value;
                } else {
                    txtBufferOutDate.value = '';
                }
            }

            if (txtMtyGateInDate.value === '') {
                if (ctrl.checked === true) {
                    txtMtyGateInDate.value = document.getElementById('<%= textEmptyGateInDate.ClientID%>' + '_textDateTime').value;
                } else {
                    txtMtyGateInDate.value = '';
                }
            }
        }
    </script>
    <div style="height: 520px">
        <table style="width: 100%">
            <tr>
                <td valign="top" style="width: 20%">
                    <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="Vehicle Running Status" CssClass="FormLabelTitle"> </asp:Label>
                </td>
                <td valign="top" style="width: 80%">
                    <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
                </td>
                <td style="width: 120px" align="left">
                    <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                        Width="120px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <hr />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" Text="ICD Out Date" runat="server" CssClass="label">
                    </asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textICDOutDate" runat="server" Width="85px" CssClass="textbox"
                        MaxLength="20" ToolTip="ICD Out Date"></uc1:DateTimeTextBox>
                </td>
                <td>
                    <asp:Label ID="lblFactoryInDate" Text="Factory In" runat="server" CssClass="label">
                    </asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textFactoryInDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox"
                        MaxLength="20" ToolTip="Factory In"></uc1:DateTimeTextBox>
                </td>
                <td>
                    <asp:Label ID="lblFactoryOutDate" runat="server" Text="Factory Out" CssClass="label"></asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textFactoryOutDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox" Text='<%# Eval("FactoryOut") %>'
                        MaxLength="20" ToolTip="Factory Out"></uc1:DateTimeTextBox>

                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblFilter" runat="server" Text="Filter" CssClass="label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="lstFilter" runat="server" CssClass="ddlMedium">
                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                      <%--  <asp:ListItem Value="6" Text="ICD Out Date"></asp:ListItem>
                      --%>  <asp:ListItem Value="1" Text="Factory In"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Factory Out"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Buffer In"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Buffer Out"></asp:ListItem>
                        <asp:ListItem Value="5" Text="ICD In Date"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBufferInDate" Text="Buffer In Date" runat="server" CssClass="label">
                    </asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textBufferInDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox"
                        MaxLength="20" ToolTip="Buffer In Date"></uc1:DateTimeTextBox>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblBufferOutDate" runat="server" Text="Buffer Out Date" CssClass="label"></asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textBufferOutDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox" Text='<%# Eval("FactoryOut") %>'
                        MaxLength="20" ToolTip="Buffer Out Date"></uc1:DateTimeTextBox>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblICDLagenGateIn" Text="ICD Laden Gate In Date" runat="server" CssClass="label">
                    </asp:Label>
                </td>
                <td>
                    <uc1:DateTimeTextBox ID="textICDLadenGateInDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox"
                        MaxLength="20" ToolTip="ICD Laden Gate In Date"></uc1:DateTimeTextBox>
                </td>
                <td>
                    <asp:Label ID="lblEmptyGateInDate" runat="server" Text="Empty Gate In Date" CssClass="label"></asp:Label>
                </td>
                <td>

                    <uc1:DateTimeTextBox ID="textEmptyGateInDate" runat="server" Width="85px" Font-Size="X-Small" CssClass="Rpttextbox" Text='<%# Eval("FactoryOut") %>'
                        MaxLength="20" ToolTip="Empty Gate In Date"></uc1:DateTimeTextBox>

                </td>
                <td>

                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="FormButton" />
                    <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />

                </td>
            </tr>
            <tr>
                <td colspan="8" style="text-align: center;">&nbsp;</td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <div id="dvMain" runat="server" style="height: 400px; width: 100%; overflow: auto">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <table id="tblCont" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">

                                                <tr>
                                                    <td colspan="18" valign="top" align="left">
                                                        <div style="height: 350px; overflow: auto;">
                                                            <asp:Repeater ID="repVehicleStatus" runat="server">
                                                                <HeaderTemplate>
                                                                    <table id="cont" cellspacing="0">
                                                                        <tr class="RepheaderNew" style="height: 30px; position: sticky; top: 0; z-index: 50;">
                                                                            <td>
                                                                                <asp:Label ID="lblSr" runat="server" CssClass="labelHeader" Text="Sr" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblContNo" runat="server" CssClass="labelHeader" Text="Cont No"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label2" runat="server" CssClass="labelHeader" Text="Line"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblSize" runat="server" CssClass="labelHeader" Text="Size"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblTo" runat="server" CssClass="labelHeader" Text="CFS"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblConsignor" runat="server" CssClass="labelHeader" Text="Customer"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblrVehicleNo" runat="server" CssClass="labelHeader" Text="Vehicle No"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblOffLoad" runat="server" CssClass="labelHeader" Width="85px" Text="GR No"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblProgramDate" runat="server" CssClass="labelHeader" Text="GR Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblhAllotmentDate" runat="server" CssClass="labelHeader"
                                                                                    Text="Allotment Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblrIcdOut" runat="server" CssClass="labelHeader" Width="85px" Text="ICD Out"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblrFactoryIn" runat="server" CssClass="labelHeader" Width="85px"
                                                                                    Text="Factory In"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblrFactoryOut" runat="server" CssClass="labelHeader" Width="85px"
                                                                                    Text="Factory Out"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblhBufferInDate" runat="server" CssClass="labelHeader"
                                                                                    Width="85px" Text="Buffer In Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblhBufferOutDate" runat="server" CssClass="labelHeader" Text="Buffer Out Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblrIcdIn" runat="server" CssClass="labelHeader" Text="ICD In Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblhEmptyGateInDate" runat="server" CssClass="labelHeader" Text="Empty Gate In Date"> </asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblhDocType" runat="server" CssClass="labelHeader"
                                                                                    Width="85px" Text="Doc Type"> </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td style="width: 55px" class="labelHeader">
                                                                            <table>
                                                                                <tr>
                                                                                    <td><%#Container.ItemIndex + 1%>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="chkSelect" runat="server" onclick="javascript:CheckChanged(this);" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textContNo" runat="server" Width="100" MaxLength="20" Font-Size="X-Small"
                                                                                CssClass="Rpttextbox" Enabled="false" Text='<%# Eval("Cont_No")%>' ToolTip="Train/Truck No.">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="70px" Enabled="false" Font-Size="X-Small" MaxLength="20" CssClass="Rpttextbox"
                                                                                Text='<%# Eval("LINE") %>' ToolTip="Line">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textSize" runat="server" Width="60px" Enabled="false" CssClass="Rpttextbox" Font-Size="X-Small" Text='<%# Eval("Cont_Size") %>'
                                                                                ToolTip="Size">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textTo" runat="server" Width="130px" MaxLength="100" Enabled="false" Font-Size="X-Small" CssClass="Rpttextbox"
                                                                                Text='<%# Eval("TERMINAL_NAME") %>' ToolTip="CFS">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textCustomer" runat="server" Width="250px" Enabled="false" Font-Size="X-Small" MaxLength="20" CssClass="Rpttextbox"
                                                                                Text='<%# Eval("CUSTOMER_NAME") %>' ToolTip="Customer">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textVehicleNo" runat="server" Width="100" MaxLength="20" Font-Size="X-Small"
                                                                                CssClass="Rpttextbox" Enabled="false" Text='<%# Eval("Vehicle_No") %>' ToolTip="Train/Truck No.">
                                                                            </asp:TextBox>
                                                                             <asp:HiddenField ID="hdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                                            <asp:HiddenField ID="hdnContJoId" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                                                                            <asp:HiddenField ID="hdnTransporterId" runat="server" Value='<%# Eval("TRANSPORTER_ID") %>' />
                                                                            <asp:HiddenField ID="hdnSbNo" runat="server" Value='<%# Eval("SB_NO") %>' />
                                                                            <asp:HiddenField ID="hdnSbDate" runat="server" Value='<%# Eval("SB_DATE") %>' />
                                                                            <asp:HiddenField ID="hdnInvDate" runat="server" Value='<%# Eval("PARTY_INV_DATE") %>' />
                                                                            <asp:HiddenField ID="hdnInvNo" runat="server" Value='<%# Eval("PARTY_INV_NO") %>' />
                                                                              <asp:HiddenField ID="hdnIcdIndate" runat="server" Value='<%# Eval("ICD_IN_DATE") %>' />
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textGRNo" runat="server" Width="105px" Font-Size="X-Small" Enabled="false" MaxLength="20" CssClass="Rpttextbox"
                                                                                Text='<%# Eval("GR_NO") %>' ToolTip="GR No">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="textGRDate" runat="server" Width="100px" Enabled="false" Font-Size="X-Small" CssClass="Rpttextbox"
                                                                                Text='<%# Eval("GR_DATE") %>' ToolTip="GR Date"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <%--<asp:TextBox ID="textAllotmentDate" runat="server" Enabled="false" Width="85px" Font-Size="X-Small"
                                                                                CssClass="Rpttextbox" Text='<%# Eval("ALLOTMENT_DATE") %>' MaxLength="20" ToolTip="Allotment Date"></asp:TextBox>--%>
                                                                            <uc1:DateTimeTextBox ID="textAllotmentDate" runat="server" Enabled="false" Width="85px" Font-Size="X-Small"
                                                                                CssClass="Rpttextbox" Text='<%# Eval("ALLOTMENT_DATE") %>' MaxLength="20" ToolTip="Allotment Date"></uc1:DateTimeTextBox>
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textIcdOut" runat="server" Width="85px" Font-Size="X-Small"
                                                                                CssClass="textbox" Text='<%# Eval("ICD_OUT_DATE") %>'
                                                                                ToolTip="ICD Out Date"></uc1:DateTimeTextBox>
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textFactoryIn" runat="server" Width="85px"
                                                                                Font-Size="X-Small" CssClass="textbox" Text='<%# Eval("FACTORY_IN_DATE") %>'
                                                                                MaxLength="20" ToolTip="Factory In Date"></uc1:DateTimeTextBox>
                                                                            <asp:HiddenField runat="server" Value='<%# Eval("FACTORY_IN_DATE") %>' ID="hdnFactoryInDate" />
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textFactoryOut" runat="server" Width="85px" Font-Size="X-Small"
                                                                                CssClass="textbox" Text='<%# Eval("FACTORY_OUT_DATE") %>'
                                                                                MaxLength="20" ToolTip="Factory Out Date"></uc1:DateTimeTextBox>
                                                                            <asp:HiddenField runat="server" Value='<%# Eval("FACTORY_OUT_DATE") %>' ID="hdnFactoryOutDate" />
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textBufferInDate" runat="server" Width="85px" Font-Size="X-Small"
                                                                                CssClass="textbox" Text='<%# Eval("BUFFER_DATE") %>'
                                                                                MaxLength="20" ToolTip="Buffer In Date"></uc1:DateTimeTextBox>
                                                                            <asp:HiddenField runat="server" Value='<%# Eval("BUFFER_DATE") %>' ID="hdnBufferInDate" />
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textBufferOutDate" runat="server" Width="85px" Font-Size="X-Small"
                                                                                CssClass="textbox" Text='<%# Eval("BUFFER_OUT_DATE") %>'
                                                                                MaxLength="20" ToolTip="Buffer Out Date"></uc1:DateTimeTextBox>
                                                                            <asp:HiddenField runat="server" Value='<%# Eval("BUFFER_OUT_DATE") %>' ID="hdnBufferOutDate" />
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textIcdIn" runat="server" Width="85px" Font-Size="X-Small" MaxLength="20" CssClass="textbox" ToolTip="Icd In Date"></uc1:DateTimeTextBox>
                                                                        </td>
                                                                        <td>
                                                                            <uc1:DateTimeTextBox ID="textEmptyGateInDate" runat="server" Width="85px" Font-Size="X-Small"
                                                                                CssClass="textbox" Text='<%# Eval("EMPTYGATE_IN_DATE") %>'
                                                                                MaxLength="20" ToolTip="Empty Gate In Date"></uc1:DateTimeTextBox>
                                                                            <asp:HiddenField runat="server" Value='<%# Eval("EMPTYGATE_IN_DATE") %>' ID="hdnEmptyGateInDate" />
                                                                        </td>
                                                                        <%--<td>
                                                                            <asp:TextBox ID="textDocType" runat="server" Width="85px" Enabled="False"
                                                                                Font-Size="X-Small" Text='<%# Eval("TRIP_TYPE") %>'
                                                                                CssClass="Rpttextbox" ToolTip="Trip Type">
                                                                            </asp:TextBox>
                                                                        </td>--%>
                                                                        <td align="left" class="ddlarge">
                                                                            <asp:DropDownList ID="lstDocType" runat="server" Width="85px" Text='<%# Eval("TRIP_TYPE") %>' CssClass="ddlMedium"
                                                                                Visible="True" ToolTip="Doc Type">
                                                                                <asp:ListItem Text="---Select---" Value="0">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Domestic" Value="D">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Export" Value="E">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Import" Value="I">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Empty Return" Value="M">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Clearance" Value="C">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Back To Town" Value="B">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Reworking" Value="R">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Nomination" Value="N">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Transport" Value="T">
                                                                                </asp:ListItem>
                                                                                <asp:ListItem Text="Overseas" Value="O">
                                                                                </asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="background-color: White; width: 15px;"></td>
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
                            </ContentTemplate>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="repVehicleStatus" runat="server" />
                            </Triggers>--%>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
