<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GRPrint.aspx.vb" Inherits="Fleet_PRINT_GRPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eLOGiFreight :: GR Print</title>
    <style type="text/css">
        .FormLabel {
            font-family: Calibri;
            text-align: left;
            font-size: 18px;
        }


        .FormTextBoxHead {
            font-family: Calibri;
            text-align: left;
            font-size: 22px;
        }

        .auto-style1 {
            width: 166px;
        }
    </style>
</head>
<body>
    <div align="center" style="height: 1450px;">
        <table align="center" width="100%">
            <tr>
                <td height="25px" colspan="2" align="right">
                    <asp:Label ID="Label5" Font-Size="20px" ForeColor="Red" Font-Bold="true" CssClass="FormLabel"
                        runat="server" Text="Original Copy"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" width="34%">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="imglogo" Width="120px" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" width="72%">
                    <table border="0" cellpadding="0" cellspacing="0" width="83%">
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label4" Font-Bold="true" ForeColor="Blue" Font-Size="30px" CssClass="FormLabelTitle"
                                    runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="lblCompanyName1" Font-Bold="true" Font-Size="20px" CssClass="FormLabel"
                                    runat="server" Text="(Transport Contractors & Fleet Owner)"></asp:Label>
                            </td>
                            <td height="25px" align="center"></td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label14" CssClass="FormLabel" Font-Size="20px" runat="server" Text="D-9/3, Okhla Industrial Area Phase-1 New Delhi"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">PAN NO.:
                                <asp:Label ID="LblPanNo" runat="server"></asp:Label>, GSTN NO.:<asp:Label ID="lblGSTn"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">Contact No.:8285148316,8750183111,8750189777,8750183777
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center; height: 15px;" class="FormLabel">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 208px;">
            <tr>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigner" Font-Bold="False" CssClass="FormLabel" runat="server"
                        Text="Consignor " Width="115px"></asp:Label>
                </td>
                <td width="450px" align="left" style="border-bottom: none; border-top: none;">
                    <asp:Label ID="textConsigner" Width="90%" CssClass="FormTextBoxHead" Font-Bold="false"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblGrNo" runat="server" Text="GR No" CssClass="FormLabel "></asp:Label>
                </td>
                <td align="left" style="border-top: none; border-bottom: none; border-right: none;">
                    <asp:Label ID="textGrNo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsignee" CssClass="FormLabel" runat="server" Text="Consignee "
                        Width="115px"></asp:Label>
                    &nbsp;
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsignee" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lbldate" runat="server" Text="Date" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textdate" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneeAddress" CssClass="FormLabel" runat="server" Text="Address "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsigneeAddress" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneGST" CssClass="FormLabel" runat="server" Text="Party GSTIN "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textParyGSTIN" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck" CssClass="FormLabel" runat="server" Text="Trailor/Truck No  "></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textTruck" Width="145px" CssClass="FormTextBoxHead" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Labelform" runat="server" Text="Origin" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextFrom" runat="server" Text="" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck3" CssClass="FormLabel" runat="server" Text="Driver Name"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textDriverName" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="LblTo" runat="server" Text="To" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextTo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck4" CssClass="FormLabel" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="LblDriverMobileNo" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="textBE" Width="65px" CssClass="FormLabel" Text="Handover" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textPort" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-bottom: none; border-right: none; border-left: none;" align="left"
                    colspan="2">
                    <asp:Label ID="lblno" runat="server" CssClass="FormLabel" Text="Movement:"></asp:Label>
                    <asp:Label ID="LblDescription" runat="server" CssClass="FormLabel" Text="Empty Container Out For Stuffing"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblCommodity" runat="server" CssClass="FormLabel" Text="Commodity"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="txtCommodity" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 408px;">
            <tr>
                <td rowspan="8" valign="top" style="width: 534px;">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblJoNo" runat="server" CssClass="FormLabel" Text="Jo No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="TextJoNo" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContainerNo" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="textContNo" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContSize" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContSize" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContType" runat="server" CssClass="FormLabel" Text="Type"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContType" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblLineName" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textLine" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblSealNo" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textSelaNo" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPayLoad" runat="server" CssClass="FormLabel" Text="Pay Load"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textPayLoad" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left">
                                <asp:Label ID="lblGrossWt" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textGrossWt" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblNetWt" runat="server" CssClass="FormLabel" Text="Net Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textNetWt" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblOilSlipNo" runat="server" CssClass="FormLabel" Text="Oil Slip No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="textOilSlipNo" runat="server" CssClass="FormLabel" Text="Net Weight"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblPort" runat="server" CssClass="FormLabel" Text="Port"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="Textdport" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table border="0" style="border-bottom: hidden; width: 380px; height: 400px;">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblInvoiceNo" runat="server" CssClass="FormLabel" Text="(TO BE FILLED BY PARTY)"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyRefNo" runat="server" CssClass="FormLabel" Text="Party Ref No."></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyAdvance" runat="server" CssClass="FormLabel" Text="Party Advance"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartySealNo" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                      <%--  <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyGrossWt" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblFactoryOut" runat="server" CssClass="FormLabel" Text="Factory Site Reporting"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">
                                <asp:Label ID="textReporting" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblOwnerRisk" runat="server" CssClass="FormLabel" Text="Factory Site Release"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textRelease" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label7" CssClass="FormLabel" runat="server" Text="VIA"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; font-size: 20px; height: 108px;">
            <tr>
                <td align="left" class="FormLabel" style="height: 150px;" valign="top">
                    <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="FOR FACTORY STAMP & SIGNATURE"
                        CssClass="FormLabel"></asp:Label>
                </td>
                <td style="font-size: 20px; font-weight: bold" align="right" class="FormLabel" valign="top"
                    width="450px;">Authorised Signatory
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; font-weight: bold; text-align: center" class="FormLabel">DECLARATION
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; text-align: left" class="FormLabel">
                    <strong>Note: </strong>
                    <br />
                    Goods are Transported at Owners risk.<br />
                    Company will not be responsible for the damage of goods,leakage and breakage.<br />
                    Consignee is responsible for the correctness of GSTIN &amp; other details.
                    <br />
                    All Matter of disputes will be settled in DELHI Jurisdication only.
                </td>
            </tr>
        </table>
    </div>
    <div align="center" style="height: 1450px;">
        <table align="center" width="100%">
            <tr>
                <td height="25px" colspan="2" align="center">&nbsp;
                </td>
            </tr>
            <tr>
                <td height="25px" colspan="2" align="right">
                    <asp:Label ID="Label8" Font-Size="20px" ForeColor="Red" Font-Bold="true" CssClass="FormLabel"
                        runat="server" Text="Duplicate Copy"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" width="34%">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="imglogo1" Width="120px" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" width="72%">
                    <table border="0" cellpadding="0" cellspacing="0" width="83%">
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label2" Font-Bold="true" ForeColor="Blue" Font-Size="30px" CssClass="FormLabelTitle"
                                    runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label70" Font-Bold="true" Font-Size="20px" CssClass="FormLabel" runat="server"
                                    Text="(Transport Contractors & Fleet Owner)"></asp:Label>
                            </td>
                            <td height="25px" align="center"></td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="lbl70" CssClass="FormLabel" Font-Size="20px" runat="server" Text="D-9/3, Okhla Industrial Area Phase-1 New Delhi"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">PAN NO.:
                                <asp:Label ID="LblPan1" runat="server"></asp:Label>, GSTN NO.:<asp:Label ID="LblStax1"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">Contact No.:8285148316,8750183111,8750189777,8750183777
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center; height: 15px;" class="FormLabel">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 208px;">
            <tr>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigner1" Font-Bold="False" CssClass="FormLabel" runat="server"
                        Text="Consignor " Width="115px"></asp:Label>
                </td>
                <td width="450px" align="left" style="border-bottom: none; border-top: none;">
                    <asp:Label ID="textConsigner1" Width="90%" CssClass="FormTextBoxHead" Font-Bold="false"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblGrNo1" runat="server" Text="GR No" CssClass="FormLabel "></asp:Label>
                </td>
                <td align="left" style="border-top: none; border-bottom: none; border-right: none;">
                    <asp:Label ID="textGrNo1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsignee1" CssClass="FormLabel" runat="server" Text="Consignee "
                        Width="115px"></asp:Label>
                    &nbsp;
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsignee1" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lbldate1" runat="server" Text="Date" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textdate1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneeAddress0" CssClass="FormLabel" runat="server" Text="Address "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsigneeAddress0" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneGST0" CssClass="FormLabel" runat="server" Text="Party GSTIN "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textParyGSTIN0" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck1" CssClass="FormLabel" runat="server" Text="Trailor/Truck No  "></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textTruck1" Width="145px" CssClass="FormTextBoxHead" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Labelform1" runat="server" Text="Origin" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextFrom1" runat="server" Text="" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck5" CssClass="FormLabel" runat="server" Text="Driver Name"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textDriverName1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="LblTo1" runat="server" Text="To" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextTo1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblTruck6" CssClass="FormLabel" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="LblDriverMobileNo1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="textBE1" Width="65px" CssClass="FormLabel" Text="Handover" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textPort1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <%--CHANGE--%>
             <tr>
                <td style="border-bottom: none; border-right: none; border-left: none;" align="left"
                    colspan="2">
                    <asp:Label ID="Label6" runat="server" CssClass="FormLabel" Text="Movement:"></asp:Label>
                    <asp:Label ID="Label9" runat="server" CssClass="FormLabel" Text="Empty Container Out For Stuffing"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label12" runat="server" CssClass="FormLabel" Text="Commodity"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="txtCommodity1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 350px;">
            <tr>
                <td rowspan="8" valign="top" style="width: 535px;">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblJoNo1" runat="server" CssClass="FormLabel" Text="Jo No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="TextJoNo1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContainerNo1" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="textContNo1" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContSize1" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContSize1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblContType1" runat="server" CssClass="FormLabel" Text="Type"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContType1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblLineName1" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textLine1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblSealNo1" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textSelaNo1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblPayLoad1" runat="server" CssClass="FormLabel" Text="Pay Load"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textPayLoad1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td align="left">
                                <asp:Label ID="lblGrossWt1" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textGrossWt1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblNetWt1" runat="server" CssClass="FormLabel" Text="Net Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textNetWt1" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblOilSlipNo1" runat="server" CssClass="FormLabel" Text="Oil Slip No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="textOilSlipNo1" runat="server" CssClass="FormLabel" Text="Net Weight"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblport1" runat="server" CssClass="FormLabel" Text="Port"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="Textdport1" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table border="0" style="border-bottom: hidden; width: 380px; height: 400px;">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblInvoiceNo1" runat="server" CssClass="FormLabel" Text="(TO BE FILLED BY PARTY)"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyRefNo1" runat="server" CssClass="FormLabel" Text="Party Ref No."></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyAdvance1" runat="server" CssClass="FormLabel" Text="Party Advance"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartySealNo1" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblPartyGrossWt1" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblFactoryOut1" runat="server" CssClass="FormLabel" Text="Factory Site Reporting"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">
                                <asp:Label ID="textReporting1" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="lblOwnerRisk1" runat="server" CssClass="FormLabel" Text="Factory Site Release"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textRelease1" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label58" CssClass="FormLabel" runat="server" Text="VIA"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; font-size: 20px; height: 108px;">
            <tr>
                <td align="left" class="FormLabel" style="height: 150px;" valign="top">
                    <asp:Label ID="Label59" runat="server" Font-Bold="true" Text="FOR FACTORY STAMP & SIGNATURE"
                        CssClass="FormLabel"></asp:Label>
                </td>
                <td style="font-size: 20px; font-weight: bold" align="right" class="FormLabel" valign="top"
                    width="450px;">Authorised Signatory
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; font-weight: bold; text-align: center" class="FormLabel">DECLARATION
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; text-align: left" class="FormLabel">
                    <strong>Note: </strong>
                    <br />
                    Goods are Transported at Owners risk.<br />
                    Company will not be responsible for the damage of goods,leakage and breakage.<br />
                    Consignee is responsible for the correctness of GSTIN &amp; other details.
                    <br />
                    All Matter of disputes will be settled in DELHI Jurisdication only.
                </td>
            </tr>
        </table>
    </div>
    <div align="center" style="height: 1450px;">
        <table align="center" width="100%">
            <tr>
                <td height="25px" colspan="2" align="center">&nbsp;
                </td>
            </tr>
            <tr>
                <td height="25px" colspan="2" align="right">
                    <asp:Label ID="Label1" Font-Size="20px" ForeColor="Red" Font-Bold="true" CssClass="FormLabel"
                        runat="server" Text="Triplicate Copy"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" width="34%">
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" Width="120px" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" width="72%">
                    <table border="0" cellpadding="0" cellspacing="0" width="83%">
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label3" Font-Bold="true" ForeColor="Blue" Font-Size="30px" CssClass="FormLabelTitle"
                                    runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label71" Font-Bold="true" Font-Size="20px" CssClass="FormLabel" runat="server"
                                    Text="(Transport Contractors & Fleet Owner)"></asp:Label>
                            </td>
                            <td height="25px" align="center"></td>
                        </tr>
                        <tr>
                            <td height="25px" align="center">
                                <asp:Label ID="Label11" CssClass="FormLabel" Font-Size="20px" runat="server" Text="D-9/3, Okhla Industrial Area Phase-1 New Delhi"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">PAN NO.:
                                <asp:Label ID="LblPan2" runat="server"></asp:Label>, GSTN NO.:<asp:Label ID="LblStax2"
                                    runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center" class="FormLabel">Contact No.:8285148316,8750183111,8750189777,8750183777
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 20px; text-align: center; height: 15px;" class="FormLabel">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 208px;">
            <tr>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label15" Font-Bold="False" CssClass="FormLabel" runat="server" Text="Consignor "
                        Width="115px"></asp:Label>
                </td>
                <td width="450px" align="left" style="border-bottom: none; border-top: none;">
                    <asp:Label ID="textConsignor2" Width="90%" CssClass="FormTextBoxHead" Font-Bold="false"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-top: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label17" runat="server" Text="GR No" CssClass="FormLabel "></asp:Label>
                </td>
                <td align="left" style="border-top: none; border-bottom: none; border-right: none;">
                    <asp:Label ID="textGrNo2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label19" CssClass="FormLabel" runat="server" Text="Consignee " Width="115px"></asp:Label>
                    &nbsp;
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsignee2" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label21" runat="server" Text="Date" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textdate2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneeAddress1" CssClass="FormLabel" runat="server" Text="Address "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textConsigneeAddress1" Width="90%" Font-Bold="False" CssClass="FormTextBoxHead"
                        runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="lblConsigneGST1" CssClass="FormLabel" runat="server" Text="Party GSTIN "
                        Width="115px"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textParyGSTIN1" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label23" CssClass="FormLabel" runat="server" Text="Trailor/Truck No  "></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textTruck2" Width="145px" CssClass="FormTextBoxHead" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label25" runat="server" Text="Origin" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="TextFrom2" runat="server" Text="" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label27" CssClass="FormLabel" runat="server" Text="Driver Name"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="textDriverName2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label28" runat="server" Text="To" CssClass="FormLabel"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textTo2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label30" CssClass="FormLabel" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none;">
                    <asp:Label ID="LblDriverMobileNo2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label31" Width="65px" CssClass="FormLabel" Text="Handover" runat="server"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="textPort2" runat="server" CssClass="FormTextBoxHead"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="border-bottom: none; border-right: none; border-left: none;" align="left"
                    colspan="2">
                    <asp:Label ID="Label16" runat="server" CssClass="FormLabel" Text="Movement:"></asp:Label>
                    <asp:Label ID="Label18" runat="server" CssClass="FormLabel" Text="Empty Container Out For Stuffing"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none; border-left: none;">
                    <asp:Label ID="Label20" runat="server" CssClass="FormLabel" Text="Commodity"></asp:Label>
                </td>
                <td align="left" style="border-bottom: none; border-right: none;">
                    <asp:Label ID="txtCommodity2" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; height: 350px;">
            <tr>
                <td rowspan="8" valign="top" style="width: 535px;">
                    <table>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label35" runat="server" CssClass="FormLabel" Text="Jo No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="TextJoNo2" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label37" runat="server" CssClass="FormLabel" Text="Container No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td>
                                <asp:Label ID="textContNo2" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label39" runat="server" CssClass="FormLabel" Text="Size"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContSize2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label41" runat="server" CssClass="FormLabel" Text="Type"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textContType2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label43" runat="server" CssClass="FormLabel" Text="Line"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textLine2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label45" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textSelaNo2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label47" runat="server" CssClass="FormLabel" Text="Pay Load"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textPayLoad2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td align="left">
                                <asp:Label ID="Label49" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textGrossWt2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label51" runat="server" CssClass="FormLabel" Text="Net Weight"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="textNetWt2" runat="server" CssClass="FormLabel" Text="Conatiner No"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label53" runat="server" CssClass="FormLabel" Text="Oil Slip No"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="Label54" runat="server" CssClass="FormLabel" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label55" runat="server" CssClass="FormLabel" Text="Port"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td align="left">
                                <asp:Label ID="Textdport2" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table border="0" style="border-bottom: hidden; width: 380px; height: 400px;">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label57" runat="server" CssClass="FormLabel" Text="(TO BE FILLED BY PARTY)"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label60" runat="server" CssClass="FormLabel" Text="Party Ref No."></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label61" runat="server" CssClass="FormLabel" Text="Party Advance"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label62" runat="server" CssClass="FormLabel" Text="Seal No"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label63" runat="server" CssClass="FormLabel" Text="Gross Weight"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label64" runat="server" CssClass="FormLabel" Text="Factory Site Reporting"></asp:Label>
                            </td>
                            <td align="left">:
                            </td>
                            <td align="left">
                                <asp:Label ID="Label65" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label66" runat="server" CssClass="FormLabel" Text="Factory Site Release"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="Label67" runat="server" CssClass="FormLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">
                                <asp:Label ID="Label68" CssClass="FormLabel" runat="server" Text="VIA"></asp:Label>
                            </td>
                            <td>:
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style1">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="1px;" style="width: 1000px; font-size: 20px; height: 108px;">
            <tr>
                <td align="left" class="FormLabel" style="height: 150px;" valign="top">
                    <asp:Label ID="Label69" runat="server" Font-Bold="true" Text="FOR FACTORY STAMP & SIGNATURE"
                        CssClass="FormLabel"></asp:Label>
                </td>
                <td style="font-size: 20px; font-weight: bold" align="right" class="FormLabel" valign="top"
                    width="450px;">Authorised Signatory
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; font-weight: bold; text-align: center" class="FormLabel">DECLARATION
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 20px; text-align: left" class="FormLabel">
                    <strong>Note: </strong>
                    <br />
                    Goods are Transported at Owners risk.<br />
                    Company will not be responsible for the damage of goods,leakage and breakage.<br />
                    Consignee is responsible for the correctness of GSTIN &amp; other details.
                    <br />
                    All Matter of disputes will be settled in DELHI Jurisdication only.
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
