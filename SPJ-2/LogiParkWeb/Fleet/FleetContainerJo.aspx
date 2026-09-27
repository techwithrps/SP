<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetContainerJo.aspx.vb" Inherits="Fleet_FleetContainerJo"
    Title="eLOGiFreight :: Container Booking" Theme="Forms" %>

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
                                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Container Booking"
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
                                                                        <asp:Button ID="btnsearchJo" runat="server" Text="Go" Visible="false" CssClass="FormButton" />
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
                                                                            <asp:ListItem Text="SEA Export" Value="S">
                                                                            </asp:ListItem>
                                                                            <asp:ListItem Text="AIR Export" Value="A">
                                                                            </asp:ListItem>
                                                                             <asp:ListItem Text="Sea Import" Value="I">
                                                                            </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignor"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lstCustomer" runat="server" Width="400px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:DropDownList ID="lstConsignee" runat="server" Width="400px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstTransportar" runat="server" Width="400px" CssClass="ddlMedium"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
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
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblToLocation" runat="server" CssClass="label" Text="Handover Location"></asp:Label>
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
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:Label ID="lblCont" runat="server" CssClass="label"
                                                                            Text="No Of Cont"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left; vertical-align: top;">
                                                                        <asp:TextBox ID="textCont" Width="100px" AutoComplete="off" runat="server" MaxLength="2" CssClass="textbox"
                                                                            Enabled="false"> </asp:TextBox>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblPOD" runat="server" CssClass="label" Text="POD"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstPOD" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblPOL" runat="server" CssClass="label" Text="POL"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:DropDownList ID="lstPOL" runat="server" Width="190px" CssClass="ddlMedium">
                                                                        </asp:DropDownList>
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblBookingNo" runat="server" CssClass="label" Text="Booking No"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="TxtBookingNo" runat="server" Width="120px" MaxLength="30" autocomplete="off"
                                                                            CssClass="textbox" Enabled="false"> </asp:TextBox>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="label" Width="250px" Text="Booking Date & Booking Re-Validity"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textStuffDate" autocomplete="off" runat="server" Width="120px" CssClass="textbox">
                                                                        </asp:TextBox>
                                                                        <asp:TextBox ID="textValidity" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            ToolTip="Validity">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textStuffDate" />
                                                                        <ajaxToolkit:CalendarExtender ID="CalendartextValidity" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textValidity" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblSicut" runat="server" CssClass="label" Text="SI cut of Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textSicut" autocomplete="off" runat="server" Width="120px" CssClass="textbox">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textSicut" />
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblPortCut" runat="server" CssClass="label" Text="Port cut of Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="TextPortCut" autocomplete="off" runat="server" Width="120px" CssClass="textbox">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textPortCut" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left">
                                                                        <asp:Label ID="lblVesselName" runat="server" Width="200px" CssClass="label" Text="Vessel Name & ETD Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textVesselName" runat="server" AutoComplete="off" Width="200px" CssClass="textbox"
                                                                            Enabled="false"></asp:TextBox>
                                                                        <asp:TextBox ID="TextETD" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                                            ToolTip="Validity">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarTextETD" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="TextETD" />
                                                                        <strong>
                                                                            <samp class="mandatory">
                                                                                *</samp></strong>
                                                                    </td>
                                                                </tr>
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
                                                                                                        <%-- <td align="center">
                                                                                                            <asp:Label ID="lblBookingNo" CssClass="labelHeader" Width="120px" runat="server"
                                                                                                                Text="Line Booking No"></asp:Label>
                                                                                                        </td>--%>
                                                                                                        <%-- <td align="center">
                                                                                                            <asp:Label ID="lblLine" CssClass="labelHeader" Width="250px" runat="server" Text="Line Name"></asp:Label>
                                                                                                        </td>--%>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblBcdContNo" autocomplete="off" CssClass="labelHeader" Width="100px"
                                                                                                                runat="server" Text='Cont No<span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblSize" CssClass="labelHeader" Width="70px" runat="server" Text='Size <span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblBcdContType" CssClass="labelHeader" Width="50px" runat="server"
                                                                                                                Text='Type <span class="mandatory"> *</span>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblTemp" CssClass="labelHeader" Width="70px" runat="server"
                                                                                                                     Text='Set Temp <span class="mandatory"> *</span>'></asp:Label>
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
                                                                                                            <asp:Label ID="lblRemarks" CssClass="labelHeader" Width="180px" runat="server" Text="Remarks/Old JO No"></asp:Label>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblAllotMentDate" CssClass="labelHeader" Width="120px" runat="server" Text='Allotment Date<span class="mandatory"> *</span>'></asp:Label>
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
                                                                                                            ToolTip="Cont No" OnTextChanged="checkContNo" AutoComplete="off" AutoPostBack="true">      
                                                                                                        </asp:TextBox>
                                                                                                        <asp:HiddenField ID="hdnContId" runat="server" Value='<%# Eval("MtyContId") %>' />
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="71px" ID="lstSize" Enabled="false" runat="server"
                                                                                                            Text='<%#Eval("ContSize") %>' ToolTip="Cont Size">
                                                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                                                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                                                            <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="50px" ID="lstType" Enabled="false" runat="server"
                                                                                                            OnDataBinding="prepareContType" Text='<%#Eval("ContType") %>' ToolTip="Cont Type">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textBeNo" runat="server" Text='<%# Eval("BeNo") %>'
                                                                                                            MaxLength="3" ToolTip="Set Tempature">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textTareWeight" runat="server" Text='<%# Eval("TareWt")%>'
                                                                                                            MaxLength="4" OnTextChanged="ChkOilDtls" AutoPostBack="true" ToolTip="Tare Weight">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="60px" ID="textWeight" OnTextChanged="ChkOilDtls"
                                                                                                            runat="server" Text='<%# Eval("Weight") %>' MaxLength="5" ToolTip="Gross Weight"
                                                                                                            AutoPostBack="true">
                                                                                                        </asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox class="textbox" Width="70px" ID="textCargoWeight" Enabled="false" runat="server"
                                                                                                            Text='<%# Eval("CargoWt")%>' MaxLength="5" ToolTip="">
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
                                                                                                    <%--  <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="75px" ID="lstInvFlagTpt" runat="server"
                                                                                                            Text='<%#Eval("InvoiceFlagTPT")%>' ToolTip="Invoice TPT">
                                                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="75px" ID="lstInvFlagFrt" runat="server"
                                                                                                            Text='<%#Eval("InvoiceFlagFRT")%>' ToolTip="Freight Freight">
                                                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList class="ddlMedium" Width="75px" ID="lstInvFlagCLR" runat="server"
                                                                                                            Text='<%#Eval("InvoiceFlagCLR")%>' ToolTip="Freight Clearence">
                                                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>--%>
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
                                            <td>
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
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnNewRows" runat="server" Text="AddRow" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnEditContDetail" runat="server" Text="Edit Cont Details" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false"
                                                    OnClientClick="this.disabled='true';this.value='Please wait...';" CssClass="FormButton" />
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
