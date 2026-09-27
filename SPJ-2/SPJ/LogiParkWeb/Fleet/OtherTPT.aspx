<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="OtherTPT.aspx.vb" Inherits="Fleet_OtherTPT" Theme="Forms" %>

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
            $('input[type=text][id*=textAllotmentDate]').dynDateTime({
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
            $('input[type=text][id*=textSob]').dynDateTime({
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
                ifFormat: "%d/%m/%Y",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblin('.dtcDisplayArea')",
                button: ".next()"
            });
        });
        //$(document).ready(function () {
        //    $('input[type=text][id*=textCustom]').dynDateTime({
        //        showsTime: true,
        //        ifFormat: "%d/%m/%Y",
        //        daFormat: "%l;%M %p, %e %m,  %Y",
        //        align: "BR",
        //        electric: false,
        //        singleClick: false,
        //        displayArea: ".siblin('.dtcDisplayArea')",
        //        button: ".next()"
        //    });
        //});
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none;">
        <tr>
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="300px" Text="SHIPPER TRANSPORTATION"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="label" runat="server"></asp:Label>
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
                                    <table>
                                        <tr>
                                            <td align="left" style="background-color: bisque;" colspan="4" valign="top">
                                                <div id="dvTreeView" class="RepScroling" style="height: 100%; width: 100%; border-left-color: Black;">
                                                    <asp:TreeView ID="tvContainers" runat="server" Style="font-family: Verdana; font-size: 12px; font-weight: 700;"
                                                        Width="100%">
                                                    </asp:TreeView>
                                                </div>
                                            </td>
                                        </tr>

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
                                            <td style="text-align: left;">&nbsp;</td>
                                            <td style="text-align: left;">&nbsp;</td>
                                            <td rowspan="13" width="30px" valign="top">&nbsp;
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label Text="Size" runat="server" CssClass="label"></asp:Label>
                                            </td>

                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstSize" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                    <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label Text="Type" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList Width="100px" ID="lstType" runat="server" class="ddlMedium"
                                                    ToolTip="Cont Type">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="LblJoNo" runat="server" Text="Job No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textjoNo" Width="120px" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblAllotmentDate" runat="server" Text="Allotment Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textAllotmentDate" Width="120px" runat="server" Enabled="true" CssClass="FormTextBoxSmall"></asp:TextBox>
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
                                            <td align="left">
                                                <asp:Label ID="LblIcdIn" runat="server" Text="ICD In Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextIcdIn" Width="120px" Enabled="true" autocomplete="off" runat="server"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblEmptyGateInDate" runat="server" Text="Empty Gate In Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textEmptyGateInDate" Width="120px" AutoComplete="off" Enabled="true" runat="server"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
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
                                                <asp:Label ID="lblShippingBill" runat="server" Text="Shipping Bill" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textShippingBill" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblShippingDate" runat="server" Text="Shipping Bill Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textShippingDate" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblBookingNo" runat="server" Text="Booking No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBookingNO" Width="120px" Enabled="False" AutoComplete="off" runat="server"
                                                    CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblBookingDate" runat="server" Text="Booking Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBookingDate" Width="120px" Enabled="False" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblSob" runat="server" Text="SOB Date" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textSob" Width="120px" Enabled="true" runat="server" CssClass="FormTextBoxSmall"></asp:TextBox>
                                            </td>
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
                                            <td align="left">
                                                <asp:Label ID="LblPol" runat="server" Text="POL" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lstPol" Enabled="False" runat="server" CssClass="ddlMedium" Width="200px">
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
                                            <td align="left">
                                                <asp:Label ID="LblStatus" runat="server" Text="Shipment Status" CssClass="label">
                                                </asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="lststatus" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="DISCHARGED"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="GATE OUT"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="DELIVERED"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="STOP MAIL"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblConsignmentType" runat="server" Text="Consignment Type" CssClass="label">
                                                </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstConsignmentType" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="CNF"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="CIF"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="FOB"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="LblAllPartyConsignor" runat="server" CssClass="FormLabel" Text="Consignee"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
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
                                            <td align="left">
                                                <asp:Label ID="Label2" runat="server" CssClass="FormLabel" Text="Remarks"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="LstRemark" runat="server" CssClass="ddlLarge" Visible="true"
                                                    ToolTip="Hold Remark">
                                                    <asp:ListItem Value="0" Text=""></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="HEALTH NOT RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="PDA LOW"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="TEMPRATURE LOW"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="CUSTOM ISSUE"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="LOT INCOMPLETE"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="INVOICE DELAY"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="INVOICE PENDING"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="HOLIDAY"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="HOLD BY SHIPPER"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="NO BOOKING"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="RAILING ISSUES"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="NO DETAILS"></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="ORIGINAL DOC NOT RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="LATE GATE IN"></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="ORIGINAL DOCS NOT RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="WRONG HEALTH CERTIFICATE"></asp:ListItem>
                                                    <asp:ListItem Value="17" Text="RFID SEAL NOT SUBMITTED"></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="RFID SEAL NOT INTECTED"></asp:ListItem>
                                                    <asp:ListItem Value="19" Text="BOOKING HOLD BY SHIPPING LINE"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="POL CONFIRMATION PENDING  FROM SHIPPING LINE"></asp:ListItem>


                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblSealNo" runat="server" Text="Line Seal No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textLineSealNo" Width="120px" runat="server" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblCustomSeal" runat="server" Text="Custom Seal No" CssClass="label"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="textCustomSeal" Width="120px" runat="server" CssClass="textbox"></asp:TextBox>
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
                                            <td style="text-align: left">
                                                <asp:Label ID="lblFreeType" runat="server" Text="Container Free" CssClass="label"> </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstFreeType" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="YES"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td align="left">
                                                <asp:Label ID="LblBlMethod" runat="server" Text="BL Method" CssClass="label"> </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBlMethod" runat="server" CssClass="ddlMedium" Width="120px">
                                                    <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="RFS"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="SOB"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label3" runat="server" Text="BL Type" CssClass="label"> </asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBLStatus" runat="server" CssClass="ddlMedium" Width="160px">
                                                    <asp:ListItem Value="0" Text="----SELECT----"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="ORIGINAL B/L-RFS"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="ORIGINAL B/L-SOB"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="SEAWAY B/L"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="DESTINATION B/L"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="APPROVED"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="CORRECTION"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="RECEIVED"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="DRAFT BL"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">&nbsp;</td>
                                            <td style="text-align: left">&nbsp;</td>
                                            <td style="text-align: left">&nbsp;</td>
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
                                           <%--     <asp:Button ID="btnEdit" runat="server" Visible="false" Text="Edit" CssClass="FormButton" />
                                          --%>      <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
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
    <div style="visibility: hidden">
        <asp:GridView ID="gvBedDtls" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
