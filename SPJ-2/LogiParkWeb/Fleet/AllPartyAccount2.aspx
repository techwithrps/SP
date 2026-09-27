<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="~/Fleet/AllPartyAccount2.aspx.vb" Inherits="Fleet_AllPartyAccount2"
    Title="eLOGiFreight :: Container Booking" Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    td
    {
        cursor: pointer;
    }
    .selected_row
    {
        background-color: #A1DCF2;
    }
</style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=repBookingContDeatils] td").bind("click", function () {
                var row = $(this).parent();
                $("[id*=repBookingContDeatils] tr").each(function () {
                    if ($(this)[0] != row[0]) {
                        $("td", this).removeClass("selected_row");
                    }
                });
                $("td", row).each(function () {
                    if (!$(this).hasClass("selected_row")) {
                        $(this).addClass("selected_row");
                    } else {
                        $(this).removeClass("selected_row");
                    }
                });
            });
        });
    </script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />

    <table width="100%" style="vertical-align: top;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="All Party Account:Part-2" CssClass="FormLabelTitle"> </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 100%; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table id="tblCont" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                        <tr>
                                            <td colspan="4" align="center">
                                                <table cellspacing="0">
                                                    <tr>
                                                        <td colspan="14" valign="top" align="center">
                                                            <div style="overflow: auto; height: 240px;">
                                                                <asp:Repeater ID="repBookingContDeatils" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table id="cont" cellspacing="0">
                                                                            <tr class="RepHeadFleet">
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblChk" CssClass="labelHeader" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSrNo" CssClass="labelHeader" runat="server" Text="Sr."></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSHIPPERNAME" CssClass="labelHeader" runat="server" Text="SHIPPER NAME"></asp:Label>

                                                                                </td>
                                                                                
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPARTY_INV_NO" CssClass="labelHeader" runat="server" Text="PARTY INVOICE NO"></asp:Label>
                                                                                </td>
                                                                               
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSB_NO" CssClass="labelHeader" runat="server" Text="SB NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="LblSB_DATE" CssClass="labelHeader" runat="server" Text="SB DATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCUSTOMS_HANDOVER_DATE" CssClass="labelHeader" runat="server" Text="CUSTOMS HANDOVER DATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_HANDOVER_DATE" CssClass="labelHeader" runat="server" Text="LINE HANDOVER DATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSB_RECEIVED" CssClass="labelHeader" runat="server" Text="SB RECEIVED"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCARTONS" CssClass="labelHeader" runat="server" Text="CARTONS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblNET_WT" CssClass="labelHeader" runat="server" Text="NETT WEIGHT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblGROSS_WT" CssClass="labelHeader" runat="server" Text="GROSS WEIGHT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblTARE_WT" CssClass="labelHeader" runat="server" Text="TARE WEIGHT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblVGM_WT" CssClass="labelHeader" runat="server" Text="VGM WEIGHT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblVGM_SUBMITTED" CssClass="labelHeader" runat="server" Text="VGM SUBMITTED"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSHIPMENT_TYPE" CssClass="labelHeader" runat="server" Text="SHIPMENT TYPE"></asp:Label>
                                                                                </td>
                                                                           
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblUNITS" CssClass="labelHeader" runat="server" Text="UNITS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCONT_NO" CssClass="labelHeader" runat="server" Text="CONTAINER NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCONT_SIZE" CssClass="labelHeader" runat="server" Text="SIZE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCONT_TYPE" CssClass="labelHeader" runat="server" Text="TYPE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblICD_GATE_OUT" CssClass="labelHeader" runat="server" Text="ICD GATE OUT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblICD_GATE_IN" CssClass="labelHeader" runat="server" Text="ICD GATE IN"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPORT" CssClass="labelHeader" runat="server" Text="PORT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCOUNTRY" CssClass="labelHeader" runat="server" Text="COUNTRY"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblREGION" CssClass="labelHeader" runat="server" Text="REGION"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE" CssClass="labelHeader" runat="server" Text="SHIPPING LINE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCHA" CssClass="labelHeader" runat="server" Text="CHA"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPDA_ACCOUNT" CssClass="labelHeader" runat="server" Text="PDA ACCOUNT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBOOKING_NO" CssClass="labelHeader" runat="server" Text="BOOKING NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBL_NO" CssClass="labelHeader" runat="server" Text="BL NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblFOLLOW_UP" CssClass="labelHeader" runat="server" Text="FOLLOW UP"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBL_REMARKS" CssClass="labelHeader" runat="server" Text="BL REMARKS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSOB" CssClass="labelHeader" runat="server" Text="SOB"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSAILED" CssClass="labelHeader" runat="server" Text="SAILED"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBL_STATUS" CssClass="labelHeader" runat="server" Text="BL STATUS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_INVOICE" CssClass="labelHeader" runat="server" Text="LINE INVOICE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblREQUIRED_GST" CssClass="labelHeader" runat="server" Text="REQUIRED GST"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSPECIAL_COMMENTS" CssClass="labelHeader" runat="server" Text="SPECIAL COMMENTS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINER_INV_NO" CssClass="labelHeader" runat="server" Text="LINER INVOICE NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINER_INV_DATE" CssClass="labelHeader" runat="server" Text="LINER INVOICE DATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINER_DUE_DATE" CssClass="labelHeader" runat="server" Text="LINER DUEDATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblAGEING" CssClass="labelHeader" runat="server" Text="AGEING"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblBASE_FRT_USD" CssClass="labelHeader" runat="server" Text="BASE FRT (USD)"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblOTHER_CHARGES_USD" CssClass="labelHeader" runat="server" Text="OTHER CHARGES (USD)"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblTOTAL_FRT_USD" CssClass="labelHeader" runat="server" Text="TOTAL FRT (USD)"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblFRT_EX_RATE" CssClass="labelHeader" runat="server" Text="FRT EXCHANGE RATE"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblFRT_GST" CssClass="labelHeader" runat="server" Text="FRT GST"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblAMOUNT_INR" CssClass="labelHeader" runat="server" Text="AMOUNT (INR)"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_THC" CssClass="labelHeader" runat="server" Text="LINE THC"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPORT_THC" CssClass="labelHeader" runat="server" Text="PORT THC"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblORIGIN_THC" CssClass="labelHeader" runat="server" Text="ORIGIN THC"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblRAILFREIGHT" CssClass="labelHeader" runat="server" Text="RAILFREIGHT"></asp:Label>
                                                                                </td>

                                                                                <td align="center">
                                                                                    <asp:Label ID="lblDOC_CHARGES" CssClass="labelHeader" runat="server" Text="DOC CHARGES"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblMISC_CHARGES" CssClass="labelHeader" runat="server" Text="MISC CHARGES"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblIGST" CssClass="labelHeader" runat="server" Text="IGST"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblCGST" CssClass="labelHeader" runat="server" Text="CGST"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSGST" CssClass="labelHeader" runat="server" Text="SGST"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_CHEQUE_NO" CssClass="labelHeader" runat="server" Text="LINE CHEQUE NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_CHEQUE_DATE" CssClass="labelHeader" runat="server" Text="LINE CHEQUE DATE"></asp:Label>
                                                                                </td>

                                                                                <td align="center">
                                                                                    <asp:Label ID="lblLINE_CHEQUE_AMOUNT" CssClass="labelHeader" runat="server" Text="LINE CHEQUE AMOUNT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblPAYMENT_REMARKS" CssClass="labelHeader" runat="server" Text="PAYMENT REMARKS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblOBL_STATUS" CssClass="labelHeader" runat="server" Text="OBL STATUS"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblOBL_ISSUE_DATE" CssClass="labelHeader" runat="server" Text="OBL ISSUEDATE"></asp:Label>
                                                                                </td>
                                                                                
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSURRENDER_INV_NO" CssClass="labelHeader" runat="server" Text="SURRENDER INV NO"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSURRENDER_INV_AMOUNT" CssClass="labelHeader" runat="server" Text="SURRENDER INV AMOUNT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSURRENDER_INV_PAYMENT" CssClass="labelHeader" runat="server" Text="SURRENDER INV PAYMENT"></asp:Label>
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:Label ID="lblSURRENDER_INV_STATUS" CssClass="labelHeader" runat="server" Text="SURRENDER INV STATUS"></asp:Label>
                                                                                </td>
                                                                               
                                                                                <td style="width: 15px"></td>
                                                                            </tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr style="cursor:help" onmouseover="style.backgroundColor='red'" onkeypress="style.backgroundColor='red'" onmouseout="style.backgroundColor=''" class="label">
                                                                            <td>
                                                                                <asp:CheckBox ID="chkSelect" Width="20px" runat="server" ToolTip="Select Record"></asp:CheckBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="lblSrNo" Width="20px" Enabled="false" CssClass="textbox" runat="server" Text=' <%#Container.ItemIndex+1 %>'></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox Width="200px" ID="textShipperName" CssClass="label" runat="server" Text='<%# Eval("ShipperName")%>' ToolTip="SHIPPER NAME">
                                                                                </asp:TextBox>
                                                                                 <asp:HiddenField ID="hdnTrackId" runat="server" Value='<%# Eval("TrackId") %>' />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="150px" ID="textPartyInvoiceNo" runat="server" Text='<%# Eval("PartyInvNo")%>' ToolTip="Tare Wt">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSbNo" runat="server" Text='<%# Eval("SbNo")%>' ToolTip="Sb No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSbDate" runat="server" Text='<%# Eval("SbDate")%>' ToolTip="Sb Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textCustomsHandoverDate" runat="server" Text='<%# Eval("CustomsHandoverDate")%>'
                                                                                    ToolTip="Customs Handover Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineHandoverDate" runat="server" Text='<%# Eval("LineHandoverDate")%>'
                                                                                    ToolTip="Line Handover Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSbReceived" runat="server" Text='<%# Eval("SbReceived")%>' ToolTip="Sb Received">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textCartons" runat="server" Text='<%# Eval("Cartons")%>' ToolTip="Cartons">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textNetWt" runat="server" Text='<%# Eval("NetWt")%>' ToolTip="Net Weight">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textGrossWt" runat="server" Text='<%# Eval("GrossWt")%>' ToolTip="Gross Wt">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textTareWt1" runat="server" Text='<%# Eval("TareWt")%>' ToolTip="Tare Wt">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textVgmWt" runat="server" Text='<%# Eval("VgmWt")%>' ToolTip="Vgm Weight">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textVgmSubmitted" runat="server" Text='<%# Eval("VgmSubmitted")%>' ToolTip="Vgm Submitted">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="110px" ID="textShipmentType" runat="server" Text='<%# Eval("ShipmentType")%>' ToolTip="Shipment Type">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textUnits" runat="server" Text='<%# Eval("Units")%>' ToolTip="Units">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textContNo" runat="server" Text='<%# Eval("ContNo")%>' ToolTip="Cont No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="40px" ID="textContSize" runat="server" Text='<%# Eval("ContSize")%>' ToolTip="Cont Size">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="40px" ID="textContType" runat="server" Text='<%# Eval("ContType")%>' ToolTip="Cont Type">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textIcdGateOut" runat="server" Text='<%# Eval("IcdGateOut")%>' ToolTip="Icd Gate Out">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textIcdGateIn" runat="server" Text='<%# Eval("IcdGateIn")%>'
                                                                                    ToolTip="Icd Gate In">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textPort" runat="server" Text='<%# Eval("Port")%>'
                                                                                    ToolTip="Port">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textCountry" runat="server" Text='<%# Eval("Country")%>'
                                                                                    ToolTip="Country">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textRegion" runat="server" Text='<%# Eval("Region")%>'
                                                                                    ToolTip="Region">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="180px" ID="textLine" runat="server" Text='<%# Eval("Line")%>'
                                                                                    ToolTip="Line">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="180px" ID="textCha" runat="server" Text='<%# Eval("Cha")%>'
                                                                                    ToolTip="Cha">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="120px" ID="textPdaAccount" runat="server" Text='<%# Eval("PdaAccount")%>'
                                                                                    ToolTip="Pda Account">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textBookingNo" runat="server" Text='<%# Eval("BookingNo")%>'
                                                                                    ToolTip="Booking No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textBlno" runat="server" Text='<%# Eval("Blno")%>'
                                                                                    ToolTip="BL No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="200px" ID="textFollowUp" runat="server" Text='<%# Eval("FollowUp")%>'
                                                                                    ToolTip="Follow Up">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="200px" ID="textBlRemarks" runat="server" Text='<%# Eval("BlRemarks")%>'
                                                                                    ToolTip="BL Remarks">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSOB" runat="server" Text='<%# Eval("Sob")%>'
                                                                                    ToolTip="SOB">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSailed" runat="server" Text='<%# Eval("Sailed")%>'
                                                                                    ToolTip="Sailed">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="100px" ID="textBlStatus" runat="server" Text='<%# Eval("BlStatus")%>'
                                                                                    ToolTip="BL Status">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineInvoice" runat="server" Text='<%# Eval("LineInvoice")%>'
                                                                                    ToolTip="Line Invoice">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textRequiredGst" runat="server" Text='<%# Eval("RequiredGst")%>'
                                                                                    ToolTip="Required Gst">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="200px" ID="textSpecialComments" runat="server" Text='<%# Eval("SpecialComments")%>'
                                                                                    ToolTip="Special Comments">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLinerInvNo" runat="server" Text='<%# Eval("LinerInvNo")%>'
                                                                                    ToolTip="Liner Inv No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLinerInvDate" runat="server" Text='<%# Eval("LinerInvDate")%>'
                                                                                    ToolTip="Liner Inv Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLinerDueDate" runat="server" Text='<%# Eval("LinerDueDate")%>'
                                                                                    ToolTip="Liner Due Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textAgeing" runat="server" Text='<%# Eval("Ageing")%>'
                                                                                    ToolTip="Ageing">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textBaseFrtUsd" runat="server" Text='<%# Eval("BaseFrtUsd")%>'
                                                                                    ToolTip="Base Frt Usd">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textOtherChargesUsd" runat="server" Text='<%# Eval("OtherChargesUsd")%>'
                                                                                    ToolTip="Other Charges Usd">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textTotalFrtUsd" runat="server" Text='<%# Eval("TotalFrtUsd")%>'
                                                                                    ToolTip="Total Frt Usd">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textFrtExRate" runat="server" Text='<%# Eval("FrtExRate")%>'
                                                                                    ToolTip="Frt Ex Rate">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textFrtGst" runat="server" Text='<%# Eval("FrtGst")%>'
                                                                                    ToolTip="Frt Gst">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textAmountInr" runat="server" Text='<%# Eval("AmountInr")%>'
                                                                                    ToolTip="Amount Inr">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineThc" runat="server" Text='<%# Eval("LineThc")%>'
                                                                                    ToolTip="Line Thc">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="150px" ID="textPortThc" runat="server" Text='<%# Eval("PortThc")%>'
                                                                                    ToolTip="Port Thc">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textOriginThc" runat="server" Text='<%# Eval("OriginThc")%>'
                                                                                    ToolTip="Origin Thc">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textRailfreight" runat="server" Text='<%# Eval("Railfreight")%>'
                                                                                    ToolTip="Rail Freight">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textDocCharges" runat="server" Text='<%# Eval("DocCharges")%>'
                                                                                    ToolTip="Doc Charges">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textMiscCharges" runat="server" Text='<%# Eval("MiscCharges")%>'
                                                                                    ToolTip="Misc Charges">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textIgst" runat="server" Text='<%# Eval("Igst")%>'
                                                                                    ToolTip="Igst">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textCgst" runat="server" Text='<%# Eval("Cgst")%>'
                                                                                    ToolTip="Cgst">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSgst" runat="server" Text='<%# Eval("Sgst")%>'
                                                                                    ToolTip="Sgst">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineChequeNo" runat="server" Text='<%# Eval("LineChequeNo")%>'
                                                                                    ToolTip="Line Cheque No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineChequeDate" runat="server" Text='<%# Eval("LineChequeDate")%>'
                                                                                    ToolTip="Line Cheque Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textLineChequeAmount" runat="server" Text='<%# Eval("LineChequeAmount")%>'
                                                                                    ToolTip="Line Cheque Amount">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="200px" ID="textPaymentRemarks" runat="server" Text='<%# Eval("PaymentRemarks")%>'
                                                                                    ToolTip="Payment Remarks">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textOblStatus" runat="server" Text='<%# Eval("OblStatus")%>'
                                                                                    ToolTip="Obl Status">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textOblIssueDate" runat="server" Text='<%# Eval("OblIssueDate")%>'
                                                                                    ToolTip="Obl Issue Date">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                           
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSurrenderInvNo" runat="server" Text='<%# Eval("SurrenderInvNo")%>'
                                                                                    ToolTip="Surrender Inv No">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSurrenderInvAmount" runat="server" Text='<%# Eval("SurrenderInvAmount")%>'
                                                                                    ToolTip="Surrender Inv Amount">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSurrenderInvPayment" runat="server" Text='<%# Eval("SurrenderInvPayment")%>'
                                                                                    ToolTip="Surrender Inv Payment">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox class="textbox" Width="70px" ID="textSurrenderInvStatus" runat="server" Text='<%# Eval("SurrenderInvStatus")%>'
                                                                                    ToolTip="Surrender Inv Status">
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
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="left" width="100%">
                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnDelete" runat="server" Visible="false" ImageUrl="~/Images/btnDelete.png" />
                                                <asp:ImageButton ID="btnNewRows" runat="server" Visible="false" ImageUrl="~/Images/btnAddRow.png" />
                                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png" />
                                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
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
