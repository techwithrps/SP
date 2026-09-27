<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ETDUpdate.aspx.vb" Inherits="Fleet_ETDUpdate" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=TextFInDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=TextFOutDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textOutDaTe]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=TextIcdIn]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=TextPDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textETD]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=TextHandOverDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textCustom]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textDischargeDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textGateoutDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textEmptyGateinDate]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textRailout]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        $(document).ready(function () {
            $('input[type=text][id*=textPortArrival]').dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="ETD Updation"
        CssClass="FormLabelTitle"></asp:Label>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
    <br />
    <hr />
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none;">
        <tr>
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left;">
                                                <asp:Label ID="LblContNO" runat="server" Text="Container No" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:HiddenField ID="hdnMtyContId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdngrId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnJobId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnLineHandoverDate" runat="server" Value="0" />
                                                <asp:TextBox ID="TextGrno" runat="server" MaxLength="11" onkeypress="kp_integer();"
                                                    CssClass="textbox" Width="120px" Enabled="false" ToolTip="Container Number">
                                                </asp:TextBox>
                                                <span class="mandatory">*</span>
                                                <asp:Button ID="btnSearchGr" runat="server" Visible="false" Text="GO" CssClass="FormButton" />
                                            </td>
                                            <td rowspan="13" width="30px" valign="top">&nbsp;
                                            </td>
                                            <td rowspan="13" valign="top">
                                                <div id="dvTreeView" class="RepScroling" style="height: 100px; width: 100%; border-left-color: Black;">
                                                    <asp:TreeView ID="tvContainers" runat="server" Style="font-family: Verdana; font-size: 12px; font-weight: 700;"
                                                        Width="100%">
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblJoNo" runat="server" Text="Job No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textjoNo" Width="80px" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblIcdOut" runat="server" Text="ICD Out Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textOutDaTe" Width="120px" autocomplete="off" runat="server" Enabled="true"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                            <td align="left">
                                                <asp:Label ID="LblFinDate" runat="server" Text="Factory In Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextFInDate" Width="120px" runat="server" Enabled="true" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>--%>
                        </tr>
                        <%-- <tr>
                                            <td align="left">
                                                <asp:Label ID="lblFOutDate" runat="server" Text="Factory Out Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextFOutDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblIcdIn" runat="server" Text="ICD In Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextIcdIn" Width="120px" Enabled="true" autocomplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%-- <td align="left">
                                <asp:Label ID="lblCustom" runat="server" Text="Custom Handover Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textCustom" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblLineHandOverDate" runat="server" Text="Handover Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextHandOverDate" AutoComplete="off" Width="120px" Enabled="true"
                                    runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPoNo" runat="server" Text="Shipper Inv No." CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextPInvNo" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                <asp:HiddenField ID="hdnPartyInvoiceNo" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPoDate" runat="server" Text="Shipper Inv Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextPDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblShippingBill" runat="server" Text="Shipping Bill" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textShippingBill" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblShippingDate" runat="server" Text="Shipping Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textShippingDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblBlNo" runat="server" Text="BL No." CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBlNO" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblBookingNo" runat="server" Text="Booking No" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBookingNO" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblBookingDate" runat="server" Text="Booking Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextBookingDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblSob" runat="server" Text="ETD Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textETD" Width="120px" AutoComplete="off" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblTrainNo" runat="server" Text="Train No" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textTrainNo" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="textTrainNo"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblRailo0ut" runat="server" Text="Railout Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textRailout" Width="120px" AutoComplete="off" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblPortArrival" runat="server" Text="Port Arrival Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textPortArrival" Width="120px" AutoComplete="off" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="Voyage" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textVoyage" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblGrossWt" runat="server" Text="Gross Wt." CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textGrossWt" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPacket" runat="server" Text="No of PCS." CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextPacket" Width="120px" Enabled="true" AutoComplete="off" runat="server"
                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPkgType" runat="server" CssClass="FormLabel" Text="Package Type"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lslPackageType" runat="server" CssClass="ddlMedium" Visible="true"
                                    ToolTip="Package Type">
                                    <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="CNTS"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="CUBE"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="PLTS"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="BGS"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="DRMS"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="PKG"></asp:ListItem>
                                     <asp:ListItem Value="8" Text="KG"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCFS" runat="server" Text="CFS" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstcfs" runat="server" CssClass="ddlMedium" Width="200px">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnHandoverCFS" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblLine" runat="server" Text="Shipping Line" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstline" runat="server" CssClass="ddlMedium" Width="200px">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnShippingLine" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPod" runat="server" Text="FPOD" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="LstFOD" runat="server" CssClass="ddlMedium" Width="200px">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnFPOD" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblAllPartyConsignor" runat="server" CssClass="FormLabel" Text="Shipper"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="LstConsignor" runat="server" CssClass="ddlLarge">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hdnConsignor" runat="server" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblCon" runat="server" CssClass="FormLabel" Text="Consignee Name"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="TextConsigneeName" Width="300px" runat="server" Enabled="true" CssClass="FormTextBoxLarg"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblDischargeDate" runat="server" Text="Discharge Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textDischargeDate" Width="120px" Enabled="true" AutoComplete="off" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblGateoutDate" runat="server" Text="GateOut Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textGateoutDate" Width="120px" Enabled="true" runat="server" AutoComplete="off" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <asp:Label ID="lblEmptyGateindate" runat="server" Text="EmptyIn Date" CssClass="label"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="textEmptyGateinDate" Width="120px" Enabled="true" runat="server" AutoComplete="off" CssClass="FormTextBoxSmall"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblDocType" runat="server" Text="Doc Type" CssClass="label">
                                </asp:Label>
                            </td>
                            <td align="left">
                                                  <asp:DropDownList ID="lstDocType" runat="server" CssClass="ddlLarge">
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
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="dvButton" style="vertical-align: bottom;">
                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; background-repeat: no-repeat;">
                        <tr style="margin-top: 0px;">
                            <td align="center">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                <asp:Button ID="btnEdit" runat="server" Visible="false" Text="Edit" CssClass="FormButton" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </div> </td> </tr> </table>
    <div style="visibility: hidden">
        <asp:GridView ID="gvBedDtls" runat="server">
        </asp:GridView>
    </div>
    </table>
</asp:Content>
