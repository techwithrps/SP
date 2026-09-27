<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Empty/ImportTracking.aspx.vb" Inherits="Empty_ImportTracking" Title="eLOGiFreight :: Import Tracking"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/cont_validation.js">
    </script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <%-- <script type="text/javascript" language="javascript">

        function getAllDoNo() {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var DONo = document.getElementById("<%=textDONo.clientid%>").getAttribute("value");
                if (DONo != null && DONo != '') {
                    for (var j = 0; j < rowCount; j++) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDONo").getAttribute("value") == "") {
                            document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDONo").setAttribute("value", DONo);
                        }
                    }
                }
            }
        }
        function getAllDoDate() {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var DoDate = document.getElementById("<%=textDODate.clientid%>").getAttribute("value");
                var DoDateHour = document.getElementById("<%=textDODateHour.clientid%>").getAttribute("value");
                var DoDateMinutes = document.getElementById("<%=textDoDateMinutes.clientid%>").getAttribute("value");
                var DoDateTime = DoDate + " " + DoDateHour + ":" + DoDateMinutes
                if (DoDate != null && DoDate != '') {
                    for (var j = 0; j < rowCount; j++) {

                        if (document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDODate").getAttribute("value") == "") {
                            document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDODate").setAttribute("value", DoDateTime);
                        }
                    }
                }
            }
        }
        function getAllDoValidity() {
            if (document.getElementById("cont1") != null) {
                var rowCount = document.getElementById("cont1").getElementsByTagName("tr").length;
                var DoValidity = document.getElementById("<%=textDoValidity.clientid%>").getAttribute("value");
                var DoValidityHour = document.getElementById("<%=textDoValidityHour.clientid%>").getAttribute("value");
                var DoValidityMinutes = document.getElementById("<%=textDoValidityMinutes.clientid%>").getAttribute("value");
                var DoValidityDateTime = DoValidity + " " + DoValidityHour + ":" + DoValidityMinutes
                if (DoValidity != null && DoValidity != '') {
                    for (var j = 0; j < rowCount; j++) {
                        if (document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDoValidity").getAttribute("value") == "") {
                            document.getElementById("ctl00_ContentPlaceHolder1_rcContainers_ctl" + LPad((j + 1) + "", 2, "0") + "_textrDoValidity").setAttribute("value", DoValidityDateTime);
                        }
                    }
                }
            }
        }

        function check(dodate) {
            var str1 = dodate.getAttribute('value').split('/');
            if (str1 != '') {
                var mm1 = str1[1];
                var dd1 = str1[0];
                var yy1 = str1[2];
                var today = new Date();
                var dd2 = today.getDate();
                var mm2 = today.getMonth() + 1;
                var yy2 = today.getFullYear();
                if (yy2 >= yy1) {
                    if (yy2 == yy1) {
                        if (mm2 >= mm1) {
                            if (mm2 == mm1) {
                                if (dd2 < dd1) {
                                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                                    dodate.value = '';
                                    dodate.style.border = '1px solid red';
                                    dodate.focus();
                                    return false;
                                }
                                else {
                                    dodate.style.border = '1px solid #B3CBFF';
                                }
                            }
                            else {
                                dodate.style.border = '1px solid #B3CBFF';
                            }
                        }
                        else {
                            alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                            dodate.value = '';
                            dodate.style.border = '1px solid red';
                            dodate.focus();
                            return false;
                        }
                    }
                    else {
                        dodate.style.border = '1px solid #B3CBFF';
                    }
                }
                else {
                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                    dodate.value = '';
                    dodate.style.border = '1px solid red';
                    dodate.focus();
                    return false;
                }
            }
            else {
                dodate.style.border = '1px solid #B3CBFF';
            }
        }


        function checkDoValidity(doValidate) {
            var str1 = doValidate.getAttribute('value').split('/');
            if (str1 != '') {
                var mm1 = str1[1];
                var dd1 = str1[0];
                var yy1 = str1[2];
                var today = new Date();
                var dd2 = today.getDate();
                var mm2 = today.getMonth() + 1;
                var yy2 = today.getFullYear();
                if (yy2 <= yy1) {
                    if (yy2 == yy1) {
                        if (mm2 <= mm1) {
                            if (mm2 == mm1) {
                                if (dd2 > dd1) {
                                    alert('Please ensure that the entered Date is greater than or equal to the Current Date.');
                                    doValidate.value = '';
                                    doValidate.style.border = '1px solid red';
                                    doValidate.focus();
                                    return false;
                                }
                                else {
                                    doValidate.style.border = '1px solid #B3CBFF';
                                }
                            }
                            else {
                                doValidate.style.border = '1px solid #B3CBFF';
                            }
                        }
                        else {
                            alert('Please ensure that the entered Date is greater than or equal to the Current Date.');
                            doValidate.value = '';
                            doValidate.style.border = '1px solid red';
                            doValidate.focus();
                            return false;
                        }
                    }
                    else {
                        doValidate.style.border = '1px solid #B3CBFF';
                    }
                }
                else {
                    alert('Please ensure that the entered Date is greater than or equal to the Current Date.');
                    doValidate.value = '';
                    doValidate.style.border = '1px solid red';
                    doValidate.focus();
                    return false;
                }
            }
            else {
                doValidate.style.border = '1px solid #B3CBFF';
            }
        }
    </script>--%>
    <script type="text/javascript">

        var isSubmitted = false;

        function preventMultipleSubmissions() {

            if (!isSubmitted) {

                $('#<%=btnSave.ClientID %>').val('Submitting.. Plz Wait..');

                isSubmitted = true;

                return true;

            }

            else {

                return false;

            }

        }

    </script>
    <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
        <table style="width: 100%;">
            <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                    <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                        <table style="width: 100%">
                            <tr style="height: 20px">
                                <td>
                                    <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Import Tracking"
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
                                <td>
                                    <table>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblGRNo" runat="server" CssClass="label" Text="Tracking Id"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textGrNo" Width="90px" runat="server" AutoComplete="off" CssClass="textbox" Enabled="false"> </asp:TextBox>
                                                <asp:Button ID="btnsearchJo" runat="server" Text="Go" Visible="false" CssClass="FormButton" />
                                                <asp:HiddenField ID="hdnJoId" Value="" runat="server" />
                                                <asp:HiddenField ID="hdnGrId" Value="0" runat="server" />
                                                <asp:HiddenField ID="hdnContId" Value="0" runat="server" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGrDate" runat="server" CssClass="label" Text="Creation Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textGrDate" runat="server" Width="120px" CssClass="Rpttextbox" Enabled="false"> </asp:TextBox>
                                                &nbsp;
                                                <asp:Label ID="lblDocType" runat="server" CssClass="label" Text="Jo Type"></asp:Label>
                                                <asp:DropDownList ID="lstDocType" runat="server" Width="90px" CssClass="ddlMedium">
                                                    
                                                    <asp:ListItem Text="Import" Value="I">
                                                    </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignor"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownList ID="lstCustomer" runat="server" Width="280px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownList ID="lstConsignee" runat="server" Width="280px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        
                                       
                                        <tr>
                                            <td style="text-align: left">

                                                <asp:Label ID="lblLine" runat="server" CssClass="label" Text="Shipping Line"></asp:Label>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstLine" runat="server" Width="400px" CssClass="ddlMedium">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblStuffDate" runat="server" CssClass="label" Text="Booking No & Date & Booking Re-Validity "></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBookingNo" Width="100px" runat="server" AutoComplete="off" MaxLength="30" CssClass="textbox"
                                                    ToolTip="Line Booking Number"> </asp:TextBox>
                                                <asp:TextBox ID="textBookingDate" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                    ToolTip="Line Booking Date">
                                                </asp:TextBox>
                                                 <asp:TextBox ID="textValidity" runat="server" AutoComplete="off" Width="100px" CssClass="textbox"
                                                    ToolTip="Validity">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="BookingDate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textBookingDate" />
                                                 <ajaxToolkit:CalendarExtender ID="CalendartextValidity" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="textValidity" />
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
                                                <td style="text-align: left">
                                                <asp:Label ID="lblVesselName" runat="server" CssClass="label" Text="Vessel Name & ETD Date"></asp:Label>
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
                                            <%--<td style="text-align: left">
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:Label ID="lblCont40" runat="server" CssClass="label" Text="No Of Cont 40"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textCont40" runat="server" Width="100px" MaxLength="2" CssClass="textbox"
                                                    Enabled="false"> </asp:TextBox>
                                            </td>--%>
                                        </tr>
                                        <tr>
                                              <td style="text-align: left">
                                                                        <asp:Label ID="lblSicut" runat="server" CssClass="label" Text="SI cut of Date"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: left">
                                                                        <asp:TextBox ID="textSicut" autocomplete="off" runat="server" Width="120px" CssClass="textbox">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textSicut" />
                                                                    </td>
                                               <td style="text-align: left">
                                                                        <asp:Label ID="lblPortCut" runat="server" CssClass="label" Text="Port cut of date"></asp:Label>
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
                                                <asp:Label ID="lblContSize1" runat="server" CssClass="label" Text="SIZE"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList class="ddlMedium" Width="150px" ID="lstSize"
                                                    runat="server"
                                                    ToolTip="Cont Size">
                                                    <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                    <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContType1" runat="server" CssClass="label" Text="Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList Width="100px" ID="lstType" runat="server" class="ddlMedium"
                                                    ToolTip="Cont Type">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>

                                            <%-- <tr>
                                         <td style="text-align: left">
                                                <asp:Label ID="lblNoofContFiled" runat="server" CssClass="FormLabel" Text="No of Cont"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textNoofContFiled" runat="server" AutoPostBack="true" CssClass="FormTextBoxMedium"
                                                    onkeypress="kp_integer();" ToolTip="No of Cont" Width="100px">
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                                 </tr>--%>
                                            <%-- <tr>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblDONo" runat="server" CssClass="FormLabel" Text="DO No"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="textDONo" runat="server" Width="120px" CssClass="FormTextBoxSmall"
                                                        ToolTip="DO No" onChange="getAllDoNo();">
                                                    </asp:TextBox>
                                                    <span class="mandatory">*</span>
                                                    <asp:Button ID="btnSearchDO" Visible="false" runat="server" Text="Go" CssClass="FormButton"
                                                        OnClientClick="return igmSearchValidation();" />
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblDODate" runat="server" CssClass="FormLabel" Text="DO Date"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="textDODate" runat="server" CssClass="FormTextBoxDate" ToolTip="DO Date (DD/MM/YYYY)"
                                                        onblur="check(this);">
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="textDoDateHour" runat="server" CssClass="FormTextBoxTime" onkeypress="kp_integer();"
                                                        ToolTip="Hours" onblur="return Hours(this,'<%=lblErrorMessage.ClientID %>');">
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="textDoDateMinutes" runat="server" CssClass="FormTextBoxTime" ToolTip="Minutes"
                                                        onkeypress="kp_integer();" onblur="return valMinuts(this,'<%=lblErrorMessage.ClientID %>');"
                                                        onChange="getAllDoDate();"> 
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clDODate" Format="dd/MM/yyyy" runat="server" TargetControlID="textDODate">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <span class="mandatory">*</span>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblDoValidity" runat="server" CssClass="FormLabel" Text="DO Validity"></asp:Label>&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="textDoValidity" runat="server" CssClass="FormTextBoxDate" ToolTip="DO Validity (DD/MM/YYYY)"
                                                        onblur="checkDoValidity(this);">
                                                  
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="textDoValidityHour" runat="server" CssClass="FormTextBoxTime" ToolTip="Hours"
                                                        onkeypress="kp_integer();" onblur="return Hours(this,'<%=lblErrorMessage.ClientID %>');">
                                                    </asp:TextBox>
                                                    <asp:TextBox ID="textDoValidityMinutes" runat="server" CssClass="FormTextBoxTime"
                                                        ToolTip="Minutes" onkeypress="kp_integer();" onblur="return valMinuts(this,'<%=lblErrorMessage.ClientID %>');"
                                                        onChange="getAllDoValidity();">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="clDoValidDate" runat="server" Format="dd/MM/yyyy"
                                                        TargetControlID="textDoValidity">
                                                    </ajaxToolkit:CalendarExtender>
                                                    <span class="mandatory">*</span>
                                                </td>
                                            </tr>--%>
                                        </tr>
                                        <tr>
                                            <td height="10px"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

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
                                                                    <tr class="RepheaderNew" align="center" style="height: 20px; width: 200px;">
                                                                        <td align="center">
                                                                            <asp:Label ID="lblChk" Width="15px" CssClass="labelHeader" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblSrNo" Width="20px" CssClass="labelHeader" runat="server" Text="Sr."></asp:Label>
                                                                        </td>
                                                                        <%--<td align="center">
																			<asp:Label ID="lblBookingNo" CssClass="labelHeader" Width="120px" runat="server"
																				Text="Line Booking No"></asp:Label>
																		</td>

																		<td align="center">
																			<asp:Label ID="lblLine" CssClass="labelHeader" Width="120px" runat="server" Text="Line Name"></asp:Label>
																		</td>--%>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblBcdContNo" CssClass="labelHeader" Width="100px" runat="server"
                                                                                Text='Cont No<span class="mandatory"> *</span>'></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblSize" CssClass="labelHeader" Width="70px" runat="server" Text='Size <span class="mandatory"> *</span>'></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblBcdContType" CssClass="labelHeader" Width="50px" runat="server"
                                                                                Text='Type <span class="mandatory"> *</span>'></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label1" CssClass="labelHeader" Width="60px" runat="server" Text="Tare Wt"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label2" CssClass="labelHeader" Width="70px" runat="server" Text="Gross Wt"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="Label3" CssClass="labelHeader" Width="70px" runat="server" Text="Pay Load"></asp:Label>
                                                                        </td>
                                                                        <%-- <td align="center">
                                                                            <asp:Label ID="lblSealNo" CssClass="labelHeader" Width="70px" runat="server" Text="Line Seal"></asp:Label>
                                                                        </td>--%>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblTareWeight" CssClass="labelHeader" Width="100px" runat="server"
                                                                                Text="Vehicle/Rake No"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblGrossWeight" CssClass="labelHeader" Width="70px" runat="server"
                                                                                Text="LR No"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblAllot" CssClass="labelHeader" Width="120px" runat="server"
                                                                                Text="AllotMent Date"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="LblLoadWeight" CssClass="labelHeader" Width="90px" runat="server"
                                                                                Text="Out Date"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblGateinDate" CssClass="labelHeader" Width="90px" runat="server"
                                                                                Text="Gate In Date(ICD)"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblRemarks" CssClass="labelHeader" Width="180px" runat="server" Text="Remarks"></asp:Label>
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
                                                                    <%--<td>
																		<asp:TextBox class="textbox" Width="120px" ID="textBookingNo" runat="server" Text='<%# Eval("BookingNo") %>'
																			MaxLength="15" ToolTip="Booking No">
																		</asp:TextBox>
																	</td>

																	<td>
																		<asp:DropDownList class="ddlMedium" Width="120px" ID="lstLine" runat="server" OnDataBinding="prepareLine"
																			Text='<%#Eval("LineId") %>' ToolTip="Line">
																		<Z/asp:DropDownList>
																	</td>--%>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="100px" ID="textContNo" AutoComplete="off" runat="server" Text='<%# Eval("ContNo") %>'
                                                                            MaxLength="11" onkeypress="this.value=this.value.toUpperCase();" ToolTip="Cont No" onChange="if(container_validation(this.value)!= 'True') alert(container_validation(this.value));">      
                                                                        </asp:TextBox>
                                                                        <asp:HiddenField ID="hdnContId" runat="server" Value='<%# Eval("MtyContId") %>' />
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="ddlMedium" Width="71px" ID="lstSize" Enabled="false" runat="server" Text='<%#Eval("ContSize") %>'
                                                                            ToolTip="Cont Size">
                                                                            <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                                                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                                                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                                                            <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList class="ddlMedium" Width="50px" ID="lstType" Enabled="false" runat="server" OnDataBinding="prepareContType"
                                                                            Text='<%#Eval("ContType") %>' ToolTip="Cont Type">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="70px" ID="textTareWeight" runat="server" Text='<%# Eval("TareWt")%>'
                                                                            MaxLength="10" ToolTip="Tare Weight">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="60px" ID="textWeight" OnTextChanged="ChkOilDtls" runat="server" Text='<%# Eval("Weight") %>'
                                                                            MaxLength="5" ToolTip="Gross Weight" AutoPostBack="true">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="70px" ID="textCargoWeight" AutoComplete="off" runat="server" Enabled="false" Text='<%# Eval("CargoWt")%>'
                                                                            MaxLength="10" ToolTip="">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <%--    <td>
                                                                        <asp:TextBox ID="textrDONo" runat="server" Width="80px" CssClass="textbox"
                                                                            Text='<%# Eval("DoNo") %>' ToolTip="DO No">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textrDODate" runat="server" Width="110px" CssClass="textbox"
                                                                            Text='<%# Eval("DoDate") %>' ToolTip="DO Date (DD/MM/YYYY)">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="clDODate" Format="dd/MM/yyyy" runat="server" TargetControlID="textrDODate"></ajaxToolkit:CalendarExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="textrDoValidity" runat="server" Format="dd/MM/yyyy" Width="110px"
                                                                            CssClass="textbox" Text='<%# Eval("DoValidDate") %>' ToolTip="DO Validity (DD/MM/YYYY)">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="clDoValidity" Format="dd/MM/yyyy" runat="server" TargetControlID="textrDoValidity"></ajaxToolkit:CalendarExtender>
                                                                    </td>--%>
                                                                    <%-- <td>
                                                                        <asp:TextBox class="textbox" Width="70px" ID="textSealNo" AutoComplete="off" runat="server" Text='<%# Eval("SealNo") %>'
                                                                            MaxLength="12" ToolTip="Seal No">
                                                                        </asp:TextBox>
                                                                    </td>--%>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="100px" ID="textVehicleNo" AutoComplete="off" runat="server" Text='<%# Eval("VehicleNo")%>'
                                                                            MaxLength="10" ToolTip="Tare Weight">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="60px" ID="textGRNo" AutoComplete="off" runat="server" Text='<%# Eval("GRNo") %>'
                                                                            MaxLength="7" ToolTip="Gross Weight">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="120px" AutoComplete="off" ID="textAllotMent" runat="server" Text='<%# Eval("EXTRA3")%>'
                                                                            MaxLength="10" ToolTip="">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderallot" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textAllotMent" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="90px" AutoComplete="off" ID="textPickupDate" runat="server" Text='<%# Eval("PickupDate")%>'
                                                                            MaxLength="10" ToolTip="">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="PickupDate" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textPickupDate" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="90px" ID="textGateInDate" AutoComplete="off" runat="server" Text='<%# Eval("GateInDate")%>'
                                                                            MaxLength="10" ToolTip="">
                                                                        </asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="GateInDate" Format="dd/MM/yyyy" runat="server"
                                                                            TargetControlID="textGateInDate" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox class="textbox" Width="180px" ID="textRemarks" runat="server" Text='<%# Eval("Remarks") %>'
                                                                            MaxLength="200" ToolTip="Remarks">
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
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return preventMultipleSubmissions();" CssClass="FormButton" />
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
</asp:Content>
