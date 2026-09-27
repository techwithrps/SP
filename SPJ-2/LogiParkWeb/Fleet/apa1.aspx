<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Theme="Forms" CodeFile="apa1.aspx.vb" Inherits="Fleet_apa1" %>

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
            $('input[type=text][id*=TextHandOverDate]').dynDateTime({
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
            $('input[type=text][id*=textSbDate]').dynDateTime({
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
            $('input[type=text][id*=textCustomHandoverDate]').dynDateTime({
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
            $('input[type=text][id*=textLinerInvDate]').dynDateTime({
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
            $('input[type=text][id*=textRailOutDate]').dynDateTime({
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
            $('input[type=text][id*=textPortGateInDate]').dynDateTime({
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
            $('input[type=text][id*=textEtd]').dynDateTime({
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
            $('input[type=text][id*=textSailStatus]').dynDateTime({
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
            $('input[type=text][id*=textEta]').dynDateTime({
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
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="All Party Account-Documentation"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>

                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                                <asp:HiddenField ID="hdnMode" runat="server" Value="" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>

                        </tr>
                        <tr class="UserControls" style="margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <table width="300px">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblShipper" runat="server" Text="Shipper" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textShipper" Width="180px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblConsignee" runat="server" Text="Consignee" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textConsignee" Width="180px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblBlNo0" runat="server" Text="BL No." CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextBlNO" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblBookingNo" runat="server" Text="Booking No" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textBookingNo" ToolTip="Line Booking Number" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblContainerLot" runat="server" Text="Container Lot" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textContainerLot" ToolTip="Container Lot" Width="50px" Enabled="false" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblContNO" runat="server" Text="Container No" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:HiddenField ID="hdnMtyContId" runat="server" Value="" />
                                                            <asp:HiddenField ID="hdngrId" runat="server" Value="" />
                                                            <asp:TextBox ID="TextGrno" runat="server" MaxLength="11" onkeypress="kp_integer();"
                                                                CssClass="textbox" Width="120px" Enabled="false" ToolTip="Item">
                                                            </asp:TextBox>
                                                            <span class="mandatory">*</span>
                                                            <asp:ImageButton ID="btnSearchGr" runat="server" Visible="false" Width="30px" ImageUrl="~/Images/brnAddtop.png"
                                                                Height="20px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblShippingLine" runat="server" Text="Shipping Line" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textShippingLine" Width="120px" runat="server" Enabled="false" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblIcdOut" runat="server" Text="Icd Out Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textOutDaTe" Width="120px" runat="server" Enabled="true" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblFinDate" runat="server" Text="Factory In Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextFInDate" Width="120px" runat="server" Enabled="true" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblFOutDate" runat="server" Text="Factory Out Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextFOutDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblIcdIn" runat="server" Text="Icd In Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextIcdIn" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblSbNo" runat="server" Text="SB No" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textSbNo" Width="120px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblSbDate" runat="server" Text="SB Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textSbDate" Width="120px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblSBReceived" runat="server" Text="SB Received" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstSbReceived" runat="server" CssClass="ddlMedium"
                                                                Width="180px">
                                                                <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Received"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Received and checked"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCartons" runat="server" Text="Cartons"
                                                                CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textCartons" Width="90px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblNetWeight" runat="server" Text="Net Weight"
                                                                CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textNetWeight" Width="90px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblGrossWeight" runat="server" Text="Gross Weight"
                                                                CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textGrossWeigh" Width="90px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCustomHandover" runat="server" Text="Customs Handover Date"
                                                                CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textCustomHandoverDate" Width="120px" Enabled="true" runat="server"
                                                                CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblLineHandOverDate0" runat="server" Text="Line Handover Date"
                                                                CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextHandOverDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPoNo" runat="server" Text="Party Inv No." CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextPInvNo" Width="180px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPoDate" runat="server" Text="Party Inv Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextPDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblHealthCerNo" runat="server" Text="Health Cert. No" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textHealthCertNo" ToolTip="Health Certificate Number" Width="180px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblHealthCerLot" runat="server" Text="Health Cert. Lot" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textHealthCertLot" ToolTip="Health Certificate Lot" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblBLStatus" runat="server" Text="BL Status" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstBLStatus" runat="server" CssClass="ddlMedium"
                                                                Width="180px" ToolTip="1-APPROVED, 2-CORRECTION, 3-RECEIVED, 4-WEB, 5-MANUAL, 6-PENDING BL INSTRUCTIONS, 7-SAVE, 8-SOB POST">                                                                
                                                                <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="APPROVED"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="CORRECTION"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="RECEIVED"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="WEB"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="MANUAL"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="PENDING BL INSTRUCTIONS"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="SAVE"></asp:ListItem>
                                                                <asp:ListItem Value="8" Text="SOB POST"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPoNo0" runat="server" Text="Liner Inv No." CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textLinerInvNo" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPoNo1" runat="server" Text="Liner Inv Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textLinerInvDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblFactoryLocation" runat="server" Text="Factory Location" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textFactoryLocation" Width="120px" ToolTip="Factory Location" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCFS" runat="server" Text="CFS" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstPol" runat="server" CssClass="ddlMedium" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblPod" runat="server" Text="FPOD" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="LstFOD" runat="server" CssClass="ddlMedium" Width="180px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblRailOutDate" runat="server" Text="Rail Out Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textRailOutDate" ToolTip="Health Certificate Lot" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblPortGateInDate" runat="server" Text="Port Gate In Date" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textPortGateInDate" ToolTip="Port Gate In Date" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblVesselName" runat="server" Text="Vessel Name" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textVesselName" ToolTip="Vessel Name" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblEtd" runat="server" Text="ETD" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textEtd" ToolTip="ETD" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblSailStatus" runat="server" Text="Sail Status" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textSailStatus" ToolTip="ETD" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblEta" runat="server" Text="ETA" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textEta" ToolTip="ETA" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblTransitTime" runat="server" Text="Transit Time" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textTransitTime" ToolTip="Transit Time" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblShipmentStatus" runat="server" Text="Shipment Status" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="textShipmentStatus" ToolTip="Shipment Status" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="LblExRate" runat="server" Text="Exchange Rate" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TextExRate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblTelexStatus" runat="server" Text="Telex Status" CssClass="label"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="lstTelexStatus" runat="server" CssClass="ddlMedium" Width="180px">
                                                                <asp:ListItem Value="" Text="NO"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="YES"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top">
                                                <table>
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <div style="height: 500px; width: 100%; overflow: auto;">
                                                                <asp:GridView ID="GridViewAllPartyPart3" runat="server" AutoGenerateColumns="False"
                                                                    BackColor="AliceBlue" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                                                    CellSpacing="1">
                                                                    <HeaderStyle CssClass="RepHead" Font-Size="12px" />
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="35px" HeaderText="Select">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblsrn" runat="server" CssClass="loginterminaltd"></asp:Label>
                                                                                <asp:HiddenField ID="hdnTackId" runat="server" Value='<%#Eval("TrackId") %>' />
                                                                                <asp:LinkButton ID="hdnMtyContId" runat="server" Text='<%#Eval("MtyContId") %>' CommandArgument='<%#Eval("MtyContId") %>'
                                                                                    CommandName="part4" CssClass="loginterminaltd"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Container No">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("ContNo") %>' CommandArgument='<%#Eval("ContNo") %>'
                                                                                    CommandName="part3" CssClass="loginterminaltd" Enabled="false"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Shipper">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblShipperName" runat="server" Text='<%#Eval("ShipperName") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Consingee">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblConsingeeName" runat="server" Text='<%#Eval("ConsingeeName") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Booking No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblrBookingNo" runat="server" Text='<%#Eval("BookingNo") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Health Cert. No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblrHealthCertNo" runat="server" Text='<%#Eval("HealthCertificateNo") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="SB No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSbNo" runat="server" Text='<%#Eval("SbNo") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="SB Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSbDate" runat="server" Text='<%#Eval("SbDate") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Cust Handover Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCustomsHandoverDate" runat="server" Text='<%#Eval("CustomsHandoverDate") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Line Handover Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLineHandoverDate" runat="server" Text='<%#Eval("LineHandoverDate") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sb Received">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSbReceived" runat="server" Text='<%#Eval("SbReceived") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Cartons">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCartons" runat="server" Text='<%#Eval("Cartons") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Net Wt">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="GrossWt">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BILLING">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblJsbBilling" runat="server" Text='<%#Eval("JsbBilling") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Shipment Type">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblShipmentType" runat="server" Text='<%#Eval("ShipmentType") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Units">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Port">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPort" runat="server" Text='<%#Eval("Port") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Line">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CFS">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCFS" runat="server" Text='<%#Eval("CFS") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Booking No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBookingNo" runat="server" Text='<%#Eval("BookingNo") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="BL No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBlNo" runat="server" Text='<%#Eval("BlNo") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Liner Inv No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLinerInvNo" runat="server" Text='<%#Eval("LinerInvNo") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Liner Inv Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLinerInvDate" runat="server" Text='<%#Eval("LinerInvDate") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="FOLLOW UP">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFollowUp" runat="server" Text='<%#Eval("FollowUp") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="SOB">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSob" runat="server" Text='<%#Eval("Sob") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="SAILED">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSailed" runat="server" Text='<%#Eval("Sailed") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="BL STATUS">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBlStatus" runat="server" Text='<%#Eval("BlStatus") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="OBL STATUS">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOblStatus" runat="server" Text='<%#Eval("OblStatus") %>' CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="OBL RELEAS PARTY">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOblIssueDate" runat="server" Text='<%#Eval("OblIssueDate") %>'
                                                                                    CssClass="loginterminaltd"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td rowspan="17">&nbsp;
                                            </td>
                                            <td rowspan="17">&nbsp;
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
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/Images/btnCancel.png" />
                                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
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
