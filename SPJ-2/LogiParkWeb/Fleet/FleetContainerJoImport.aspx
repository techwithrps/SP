<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetContainerJoImport.aspx.vb" Inherits="Fleet_FleetContainerJoImport"
    Title="eLOGiFreight :: Import Container Booking" Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/cont_validation.js">
     <script src="../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function CheckValue(id) {
            //            var strsbno = "_textGateInPackets";
            //            var test1 = id.getAttribute('Id').substring(id.getAttribute('Id').indexOf(strsbno) - 5, id.getAttribute('Id').indexOf(strsbno));
            //            //var tablename = 105;
            //            var tablename = test1.replace('c', '').replace('t', '').replace('l', '');
            //            var rowCount1 = document.getElementById("vehicle").getElementsByTagName("tr").length;
            //            var totalpkgs = 0
            //            var totalwt = 0;
            //            var totalgpkgs = 0
            //            var totalgwt = 0;
            //            var varStuffWt = 0;
            //            var balwt = 0;
            //            var textPackets = document.getElementById("ctl00_ContentPlaceHolder1_rcRepDetails_ctl01_textWeight");
            //            var textWeight = document.getElementById("ctl00_ContentPlaceHolder1_rcRepDetails_ctl01_textCargoWeight");
            //            var hdnPkgs = document.getElementById("ctl00_ContentPlaceHolder1_rcRepDetails_ctl01_hdnPkgs");
            //            var hdnWeight = document.getElementById("ctl00_ContentPlaceHolder1_rcRepDetails_ctl01_hdnWeight");
            //            balwt = textWeight.value;
            //            var balpkg = textPackets.value;
            //            for (var j = 0; j < rowCount1 - 1; j++) {

            if (tablename - 1 == j) {
                var avg = parseInt(balwt, 10) / parseInt(balpkg, 10);
                var textGateInPacket = document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInPackets");
                varStuffWt = parseFloat(avg) * parseFloat(textGateInPacket.value);
                document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInWeight").value = Math.round(varStuffWt, 2);
                if (parseInt(varStuffWt, 10) > parseInt(balwt, 10)) {
                    alert("Stuff Weight should be Less than Balance weight")
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInWeight").value = 0;
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatilse_ctl" + tablename + "_textGateInPackets").value = 0;
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInWeight").focus();
                    returnValue = false;
                }
                if (parseInt(textGateInPacket.value, 10) > parseInt(balpkg.value, 10)) {
                    alert("Stuff Package should be Less than Balance Package")
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatilse_ctl" + tablename + "_textGateInWeight").value = 0;
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInPackets").value = 0;
                    document.getElementById("ctl00_ContentPlaceHolder1_repBookingContDeatils_ctl" + tablename + "_textGateInPackets").focus();
                    returnValue = false;
                }
            }

        }

        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input[type=text][id*=textAllotMent]').dynDateTime({
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
    </script>
    <table width="100%" style="vertical-align: top;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table style="width: 100%">
                                        <tr style="height: 20px">
                                            <td>
                                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Import Container Booking"
                                                    CssClass="FormLabelTitle"> </asp:Label>
                                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                                    ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top">
                                                <table style="vertical-align: top">
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblGRNo" runat="server" CssClass="label" Text="JO No"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textGrNo" Width="90px" runat="server" AutoComplete="off" CssClass="textbox" Enabled="false"> </asp:TextBox>
                                                                        <asp:Button ID="btnsearchJo" runat="server" Text="GO" Visible="false" CssClass="FormButton" />
                                                                        <asp:HiddenField ID="hdnJoId" Value="" runat="server" />
                                                                        <asp:HiddenField ID="hdnLineId" Value="" runat="server" />
                                                                        <asp:HiddenField ID="hdnContId" Value="0" runat="server" />
                                                                        <asp:HiddenField ID="hdnMtycontJoId" Value="" runat="server" />
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblGrDate" runat="server" CssClass="label" Text="JO Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textGrDate" runat="server" Width="120px" CssClass="Rpttextbox" Enabled="false"> </asp:TextBox>
                                                                        &nbsp;
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textGrDate" />
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblDocType" runat="server" CssClass="label" Text="Jo Type"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lstDocType" runat="server" Width="100px" CssClass="ddlMedium">
                                                                            <asp:ListItem Text="---Select---" Value="0">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Import" Value="I">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Overseas" Value="O">
                                                                            </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblshipment" runat="server" CssClass="label" Text="Mode Of Shipment"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lstOfMode" runat="server" Width="120px" CssClass="ddlMedium">
                                                                            <asp:ListItem Text="---Select---" Value="0">
                                                                            </asp:ListItem>

                                                                            <asp:ListItem Text="AIR Import" Value="R">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Sea Import" Value="I">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="Re Export" Value="O">
                                                                            </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Shipper"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textConsignee" runat="server" Width="400px" CssClass="textbox"> </asp:TextBox>

                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstCustomer" runat="server" Width="400px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstTransportar" runat="server" Width="400px" CssClass="ddlMedium"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblLocation" runat="server" CssClass="label" Text="From Location"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstLocation" runat="server" CssClass="ddlMedium" Width="400px"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblFromLocation" runat="server" CssClass="label" Text="To Location"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstFromLocation" runat="server" Width="400px" CssClass="ddlMedium"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblToLocation" runat="server" CssClass="label" Text="Custom Station"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstToLocation" runat="server" CssClass="ddlMedium" Width="400px"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblCha" runat="server" CssClass="label" Text="Shipping Line"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstLine" runat="server" Width="400px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblCont" runat="server" CssClass="label"
                                                                            Text="No Of Cont"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textCont" Width="100px" AutoComplete="off" runat="server" MaxLength="2" CssClass="textbox"
                                                                            Enabled="false"> </asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblPOL" runat="server" CssClass="label" Text="POL"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstPOD" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                       
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblPOD" runat="server" CssClass="label" Text="POD"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstPOL" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblBoeNo" runat="server" CssClass="label" Text="BOE No"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textBoeNo" runat="server"  Width="120px" MaxLength="30" onkeypress="kp_numeric();" autocomplete="off"
                                                                            CssClass="textbox" Enabled="false"> </asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblBoeDate" runat="server" CssClass="label" Width="230px" Text="BOE Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textBoeDate" autocomplete="off" runat="server" Width="120px" CssClass="textbox"> </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textBoeDate" />
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblMasterBl" runat="server" CssClass="label" Text="MBL"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textMBL" autocomplete="off" runat="server" Width="120px" CssClass="textbox"> </asp:TextBox>

                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblMasterBlDate" runat="server" CssClass="label" Text="MBL Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textMBLDate" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            ToolTip="Validity"> </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textMBLDate" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblHouseBl" runat="server" CssClass="label" Text="HBL"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textHBL" autocomplete="off" runat="server" Width="120px" CssClass="textbox"> </asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblHBLDate" runat="server" CssClass="label" Text="HBL Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textHBLDate" autocomplete="off" runat="server" Width="120px" CssClass="textbox"> </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textHBLDate" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblShipperInvNo" runat="server" Width="200px" CssClass="label" Text="Party Inv No"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textShipperInvNo" runat="server" AutoComplete="off" Width="180px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblShipperInvDate" runat="server" CssClass="label" Text="Shipper Inv Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textShipperInvDate" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            ToolTip="Validity"> </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarTextETD" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textShipperInvDate" />
                                                                    </td>
                                                                </tr>

                                                                <%-- Start --%>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblFPOD" runat="server" CssClass="label" Text="FPOD"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lstFPOD" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                    </td>


                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblClr" runat="server" CssClass="label" Text="Clearance By"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="LstCHA" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblHod" runat="server" CssClass="label" Text="Handover Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textHod" Width="100px" AutoComplete="off" runat="server" MaxLength="10" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textHod" />
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblCommodity" runat="server" CssClass="label" Text="Commodity"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textCommodity" runat="server" Width="400px"  MaxLength="100" CssClass="textbox"> </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblGrossWt" runat="server" Width="200px" CssClass="label" Text="Gross Wt."></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textGrossWt" runat="server" onkeypress="kp_numeric();" AutoComplete="off" Width="180px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <%-- Added 16/02/2024 --%>
                                                                             <td style="text-align: left">
                                                                        <asp:Label ID="lblCbm" runat="server" Width="200px" CssClass="label" Text="CBM"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="txtCbm" runat="server" AutoComplete="off" onkeypress="kp_numeric();"  Width="180px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- End --%>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblPkgType" runat="server" CssClass="label" Text="Package Type"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lslPackageType" ItemStyle-Width="120px" Width="190px" runat="server" Text='<%# Eval("PACKAGE_TYPE_ID") %>'
                                                                            CssClass="ddlMedium" ToolTip="Package Type">
                                                                            <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="CNTS"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="CUBE"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="PLTS"></asp:ListItem>
                                                                            <asp:ListItem Value="4" Text="BGS"></asp:ListItem>
                                                                            <asp:ListItem Value="5" Text="DRMS"></asp:ListItem>
                                                                            <asp:ListItem Value="6" Text="PKG"></asp:ListItem>
																			<asp:ListItem Value="7" Text="Container"></asp:ListItem>
                                                                             <asp:ListItem Value="8" Text="KG"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="Label1" runat="server" CssClass="label" Text="No of PCS."></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="TextPacket" runat="server" Width="80px" CssClass="textbox"> </asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                      <td style="text-align: left">
                                                                        <asp:Label ID="Label2JObNo" runat="server" CssClass="label" Text="JOB NO"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="TextjobNO" autocomplete="off" runat="server" Width="150px" Enabled="false" CssClass="textbox"> </asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblJobdate" runat="server" CssClass="label" Text="JOB Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="ImporttextJobdate" runat="server" Width="120px" CssClass="textbox" Enabled="false"> </asp:TextBox>
                                                                        &nbsp;
                                                                        <ajaxToolkit:CalendarExtender ID="CalendartextJobdate" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="ImporttextJobdate" />
                                                                    </td>

                                                                </tr>
                                                                  <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Empty Location"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstEmptyLocation" runat="server" CssClass="ddlMedium" Width="200px"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                     <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblEmptyGateInDate" runat="server" CssClass="label" Text="Empty Handover Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textEmptyGateInDate" Width="100px" AutoComplete="off" runat="server" MaxLength="10" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textEmptyGateInDate" />
                                                                    </td>
                                                                </tr>
                                                                   <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblCWC" runat="server" Width="150px" CssClass="label" Text="CWC/Celebi/ICD Charges"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textCWC" runat="server" onkeypress="kp_numeric();" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- Added 16/02/2024 --%>
                                                                             <td style="text-align: left">
                                                                        <asp:Label ID="lblDoCharges" runat="server" Width="200px" CssClass="label" Text="Do Charges"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textDoCharges" runat="server" onkeypress="kp_numeric();"  AutoComplete="off"  Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- End --%>
                                                                </tr>
                                                                       <tr>
 <td style="text-align: left">
                                                                        <asp:Label ID="lblTPTCharges" runat="server" Width="150px" CssClass="label" Text="TPT Charges"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textTPTCharges" runat="server" onkeypress="kp_numeric();" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>

                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblSLine" runat="server" Width="150px" CssClass="label" Text="S/Line Payment"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textSLine" runat="server" AutoComplete="off" onkeypress="kp_numeric();" Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                    </td>
                                                                    <%-- End --%>
                                                                </tr>
                                                                   <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblCashEXP" runat="server" Width="150px" CssClass="label" Text="Cash Exp."></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textCashExp" runat="server" AutoComplete="off" onkeypress="kp_numeric();" Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- Added 16/02/2024 --%>
                                                                             <td style="text-align: left">
                                                                        <asp:Label ID="lblExp" runat="server" Width="200px" CssClass="label" Text="Other Exp."></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textOtherExp" runat="server" AutoComplete="off" onkeypress="kp_numeric();"  Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- End --%>
                                                                </tr>
                                                                   <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblExtraCharges" runat="server" Width="150px" CssClass="label" Text="Extra Charged to Customer"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textExtraCharges" runat="server" AutoComplete="off" onkeypress="kp_numeric();" Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- Added 16/02/2024 --%>
                                                                             <td style="text-align: left">
                                                                        <asp:Label ID="lblRebateCharges" runat="server" Width="200px" CssClass="label" Text="Rebate to Customer"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textRebateCharges" runat="server" AutoComplete="off" onkeypress="kp_numeric();"  Width="100px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <%-- End --%>
                                                                </tr>
                                                                  <tr>
                                                                     <td style="text-align: left">
                                                                        <asp:Label ID="lblRemarks" runat="server" Width="150px" CssClass="label" Text="Remarks"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textRemarks" runat="server" AutoComplete="off" Width="600px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                 
                                                                </tr>
                                                                <%-- End --%>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table id="tblCont" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                                                <tr>
                                                                    <td colspan="4" align="center">
                                                                        <table cellspacing="0">
                                                                            <tr>
                                                                                <td colspan="18" valign="top" align="center">
                                                                                    <div style="overflow: auto; height: 240px;">
                                                                                        <asp:Repeater ID="repBookingContDeatils" runat="server">
                                                                                            <HeaderTemplate>
                                                                                                <table id="cont" cellspacing="0">
                                                                                                    <tr class="RepheaderNew" align="center" style="height: 20px">
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblChk" Width="15px" CssClass="labelHeader" runat="server" Text=""></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblSrNo" Width="20px" CssClass="labelHeader" runat="server" Text="Sr."></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblBcdContNo" autocomplete="off" CssClass="labelHeader" Width="100px"
                                                                                                                runat="server" Text='Cont/AWB No<span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblSize" CssClass="labelHeader" Width="70px" runat="server" Text='Size <span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblBcdContType" CssClass="labelHeader" Width="50px" runat="server"
                                                                                                                Text='Type <span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblTemp" CssClass="labelHeader" Width="70px" runat="server" Text="LCL/FCL"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblTareWeight" CssClass="labelHeader" Width="60px" runat="server"
                                                                                                                Text="Tare Wt"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblGrossWeight" CssClass="labelHeader" Width="70px" runat="server"
                                                                                                                Text="Gross Wt"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="LblLoadWeight" CssClass="labelHeader" Width="70px" runat="server"
                                                                                                                Text="Pay Load"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblRemarks" CssClass="labelHeader" Width="180px" runat="server" Text="Remarks"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblAllotMentDate" CssClass="labelHeader" Width="120px" runat="server" Text='CFS Gate In Date<span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                            </HeaderTemplate>
                                                                                            <ItemTemplate>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkSelect" Width="20px" runat="server" ToolTip=" Cancel Container"></asp:CheckBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="lblSrNo" Width="20px" Enabled="false" CssClass="textbox" runat="server"
                                                                                                            Text=' <%#Container.ItemIndex + 1 %>'></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="100px" ID="textContNo" runat="server" Text='<%# Eval("ContNo") %>'
                                                                                                            MaxLength="11" onkeypress="this.value=this.value.toUpperCase();" onChange="if(container_validation(this.value)!= 'True') alert(container_validation(this.value));"
                                                                                                            ToolTip="Cont No">      
                                                                                                        </asp:TextBox>
                                                                                                        <asp:HiddenField ID="hdnContId" runat="server" Value='<%# Eval("MtyContId") %>' />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="71px" ID="lstSize" runat="server"
                                                                                                            Text='<%#Eval("ContSize") %>' ToolTip="Cont Size">
                                                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                                                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                                                            <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="50px" ID="lstType" runat="server"
                                                                                                            OnDataBinding="prepareContType" Text='<%#Eval("ContType") %>' ToolTip="Cont Type">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textBeNo" runat="server" Text='<%# Eval("BeNo") %>'
                                                                                                            MaxLength="3" ToolTip="LCL/FCL">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textTareWeight" runat="server" Text='<%# Eval("TareWt")%>'
                                                                                                            MaxLength="5" onkeypress="kp_numeric();"  OnTextChanged="ChkOilDtls" AutoPostBack="true" ToolTip="Tare Weight">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                   <%-- <td>
                                                                                                        <asp:TextBox class="textbox" Width="60px" ID="textWeight" OnTextChanged="ChkOilDtls"
                                                                                                            runat="server" Text='<%# Eval("Weight") %>' MaxLength="15" ToolTip="Gross Weight"
                                                                                                            AutoPostBack="true">
                                                                                                        </asp:TextBox>
                                                                                                    </td>--%>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textCargoWeight" Enabled="false" runat="server"
                                                                                                            Text='<%# Eval("CargoWt")%>' MaxLength="5" ToolTip="">
                                                                                                        </asp:TextBox>
                                                                                                    </td>

                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="180px" ID="textpayLoad" runat="server" Text='<%# Eval("Remarks") %>'
                                                                                                            MaxLength="200" ToolTip="Pay Load">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="180px" ID="textRemarks" runat="server" Text='<%# Eval("Remarks") %>'
                                                                                                            MaxLength="200" ToolTip="Remarks">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="120px" AutoComplete="off" ID="textAllotMent" runat="server" Text='<%# Eval("AllotmentDate")%>'
                                                                                                            MaxLength="10" ToolTip="">
                                                                                                        </asp:TextBox>
                                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderallot" Format="dd/MM/yyyy" runat="server"
                                                                                                            TargetControlID="textAllotMent" />
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
                                            </td>
                                            <td valign="top">
                                                <div id="RepScroling" class="tvScroling" style="height: 400px; width: 100%; border-left-color: Black;">
                                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                                        Width="144px">
                                                    </asp:TreeView>
                                                </div>
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
                                            <td align="center" width="100%">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnNewRows" runat="server" Text="AddRow" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnEditContDetail" runat="server" Text="Edit Cont Details" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false"
                                                    OnClientClick="this.disabled='true';this.value='Please wait...';" CssClass="FormButton" />
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" CssClass="FormButton" />
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
