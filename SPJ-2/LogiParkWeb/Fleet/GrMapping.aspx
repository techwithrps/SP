<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/GrMapping.aspx.vb" Inherits="Fleet_GrMapping" Title="eLOGiFleet :: GR Mapping"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script type="text/javascript">
        var ddlText, ddlText1, ddlValue, ddlValue1, ddl, ddl1, lblMesg;
        function CacheItems() {
            ddlText = new Array();
            ddlValue = new Array();
            ddlText1 = new Array();
            ddlValue1 = new Array();
            ddl = document.getElementById("<%=lstVehicleNo.ClientID %>");
            ddl1 = document.getElementById("<%=lstDriver.ClientID %>");
            for (var i = 0; i < ddl.options.length; i++) {
                ddlText[ddlText.length] = ddl.options[i].text;
                ddlValue[ddlValue.length] = ddl.options[i].value;
            }
            for (var j = 0; j < ddl1.options.length; j++) {
                ddlText1[ddlText1.length] = ddl1.options[j].text;
                ddlValue1[ddlValue1.length] = ddl.options[j].value;
            }
        }
        window.onload = CacheItems;

        function FilterItems(value) {
            ddl.options.length = 0;
            for (var i = 0; i < ddlText.length; i++) {
                if (ddlText[i].toLowerCase().indexOf(value) != -1) {
                    AddItem(ddlText[i], ddlValue[i]);
                }
            }

        }
        function FilterItemsDriver(value) {
            ddl1.options.length = 0;
            for (var j = 0; j < ddlText1.length; j++) {
                if (ddlText1[j].toLowerCase().indexOf(value) != -1) {
                    AddItem1(ddlText1[j], ddlValue1[j]);
                }
            }

        }

        function AddItem1(text, value) {
            var opt = document.createElement("option");
            opt.text = text;
            opt.value = value;
            ddl1.options.add(opt);
        }
        function AddItem(text, value) {
            var opt = document.createElement("option");
            opt.text = text;
            opt.value = value;
            ddl.options.add(opt);
        }
        function check(dodate) {
            var str1 = dodate.value.split('/');
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
                                } else {
                                    dodate.style.border = '1px solid #B3CBFF';
                                }
                            } else {
                                dodate.style.border = '1px solid #B3CBFF';
                            }
                        } else {
                            alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                            dodate.value = '';
                            dodate.style.border = '1px solid red';
                            dodate.focus();
                            return false;
                        }
                    } else {
                        dodate.style.border = '1px solid #B3CBFF';
                    }
                } else {
                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                    dodate.value = '';
                    dodate.style.border = '1px solid red';
                    dodate.focus();
                    return false;
                }
            } else {
                dodate.style.border = '1px solid #B3CBFF';
            }
        }
    </script>
    <table width="100%" style="vertical-align: top;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="GR Generation"
                                    CssClass="FormLabelTitle"> </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr />
                            </td>
                        </tr>
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContNo" runat="server" CssClass="label" Text="Cont No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:HiddenField ID="hdnCount" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnCountGr" runat="server" Value="0" />
                                                <asp:DropDownCheckBoxes ID="ddchkContainer" EnableViewState="true" runat="server"
                                                    CssClass="ddlMedium" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="ddchkContainer_SelectedIndexChanged">
                                                    <Style SelectBoxWidth="160" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="130" />
                                                </asp:DropDownCheckBoxes>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:TextBox ID="textContNo" Visible="false" runat="server" Width="90px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                                <asp:ImageButton ID="btnSearchCont" runat="server" Visible="false" Width="30px" Height="20px" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblSize" runat="server" CssClass="label" Text="Size/Type"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContSize" runat="server" Width="28px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                                &nbsp;
                                                <asp:TextBox ID="textType" runat="server" Width="54px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                                <asp:Label ID="lblWeight" runat="server" CssClass="label" Text="Weight"></asp:Label>
                                                <asp:TextBox ID="textWeight" runat="server" Width="72px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoNo" runat="server" CssClass="label" Text="Jo No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoNo" runat="server" Width="120px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                                <%-- <asp:DropDownCheckBoxes ID="ddchkCountry" runat="server" CssClass="ddlMedium" AddJQueryReference="True"
                                                    UseButtons="True" UseSelectAllNode="True">
                                                    <Style SelectBoxWidth="200" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                                    <Texts SelectBoxCaption="Select Container" />
                                                </asp:DropDownCheckBoxes>--%>
                                                <asp:HiddenField ID="hdnLocationId" runat="server" Value="0" />
                                                <asp:HiddenField ID="HdnContSize" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value="0" />
                                                 <asp:HiddenField ID="hdnVehicleNo" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnGrId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnAdvance" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnJoId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnCustomerId" runat="server" Value="0" />
                                                <asp:HiddenField ID="hdnTransporterId" runat="server" Value="0" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoDate" runat="server" CssClass="label" Text="Jo Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoDate" runat="server" Width="100px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblGRNo" runat="server" CssClass="label" Text="GR No"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textGrNo" Width="120px" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGrDate" runat="server" CssClass="label" Text="GR Date"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textGrDate" AutoComplete="off" runat="server" Width="100px" CssClass="Rpttextbox" 
                                                              ToolTip="Gr Date " onblur="check(this);">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="GrDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textGrDate"/>
                                                <asp:Label ID="LblCGRRef" CssClass="label" runat="server" Text="C.GR"></asp:Label>&nbsp;
                                                <asp:TextBox ID="textCGr" runat="server" Width="70px" CssClass="Rpttextbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignor"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textCustomer" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textConsignee" runat="server" Width="230px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblFromLocation" runat="server" CssClass="label" Text="From Location"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textFromLocation" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblToLocation" runat="server" CssClass="label" Text="To Location"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textToLocation" runat="server" Width="230px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTransportar" runat="server" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblLocation" runat="server" CssClass="label" Text="Handover Location"></asp:Label>
                                            </td>
                                            <td style="text-align: left" rowspan="2">
                                                <asp:TextBox ID="textLocation" runat="server" Width="230px" Height="35px" TextMode="MultiLine"
                                                    CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:HiddenField ID="hdnTripType" runat="server" />
                                                <asp:Label ID="lblTripType" runat="server" CssClass="label" Text="Doc Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTripType" runat="server" Width="120px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVehiclNo" runat="server" CssClass="label" Text="Vehicle No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstVehicleNo" runat="server" Width="125px" AutoPostBack="true"
                                                    CssClass="ddlMedium" ToolTip="VehicleNo">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="textFind" onkeyup="FilterItems(this.value)" runat="server" Width="50px"
                                                    CssClass="Rpttextbox">                                                   
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDriver" runat="server" CssClass="label" Text="Driver"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstDriver" runat="server" Width="220px" AutoPostBack="true"
                                                    CssClass="ddlMedium" ToolTip="VehicleNo">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="textFindDriver" onkeyup="FilterItemsDriver(this.value)" runat="server" Width="50px"
                                                    CssClass="Rpttextbox">                                                   
                                                </asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Driver Contact No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" Width="120px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblLicenseValidity" runat="server" CssClass="label" Text="License Validity"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textLicenseValidity" runat="server" Width="110px" CssClass="Rpttextbox"
                                                    Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPetrolPump" runat="server" CssClass="label" Text="Oil Vendor"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstVendorPetrol" runat="server" Width="220px" CssClass="ddlMedium"
                                                    ToolTip="Vendor" AutoPostBack="true">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblSilpNo" runat="server" CssClass="label" Text="Slip No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textSlipNo" runat="server" MaxLength="8" Width="100px" CssClass="textbox">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRemarks" runat="server" CssClass="label" Text="Remarks"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRemarks" runat="server" Width="215px" Height="30px" TextMode="MultiLine"
                                                    CssClass="textbox">
                                                </asp:TextBox>
                                            </td>
                                              <%--added by arjun negi on 7 jan 2025--%>
                                          <td style="text-align: left">
                                                <asp:Label ID="lblCommodity" runat="server" CssClass="label" Text="Commodity"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCommodity" runat="server" Width="125px"
                                                    CssClass="ddlMedium" ToolTip="Commodity">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td
                                        </tr>
                                        
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr style="text-align: center">
                                            <td colspan="4" class="RepHeadFleet">
                                                <asp:Label ID="lblAdvanceDtls" runat="server" CssClass="labelHeader" Text="Trip Advance Details"
                                                    Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblAdvance" runat="server" CssClass="label" Text="Cash(Rs)"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAdvance" onkeypress="kp_integer()" MaxLength="6" AutoPostBack="true"
                                                    runat="server" Width="110px" CssClass="textbox" Enabled="false" Text="0">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblOilAdvance" runat="server" CssClass="label" Text="Oil(Rs)"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textOilAdvance" onkeypress="kp_integer()" AutoPostBack="true" MaxLength="6"
                                                    runat="server" Width="110px" CssClass="textbox" Enabled="false" Text="0">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="HdnOil" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Balance(Rs)"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textBalance" onkeypress="kp_integer()" runat="server" Width="110px"
                                                    CssClass="Rpttextbox" Enabled="false" Text="0">
                                                </asp:TextBox>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblToTal" runat="server" CssClass="label" Text="Total(Rs)"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTotal" runat="server" Width="110px" CssClass="Rpttextbox" Enabled="false">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Other Advance"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstAdvance" runat="server" Width="110px" CssClass="ddlMedium">
                                                    <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Fooding" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Repo" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Others(Rs)"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textOthers" onkeypress="kp_integer()" MaxLength="6" runat="server"
                                                    Width="110px" CssClass="textbox" Enabled="false" Text="0">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="chkGrChecked" runat="server" CssClass="FormLabel" Text="GR Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="FormButton" />
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" CssClass="FormButton" />
                                                 <asp:Button ID="btnCancellation" runat="server" Text="Cancellation" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" CssClass="FormButton" />
                                               <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="FormButton" />
                                                <asp:Button ID="btnPrint" runat="server" Text="Print" Visible="false" CssClass="FormButton" />
                                                 <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                              <%--  <asp:Button ID="btnEditGR" runat="server" Text="Edit GR" CssClass="FormButton" Enabled="false" />
                                        --%>    </td>
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
     <asp:Button ID="btnsavejo" runat="server" Text="Yes" Style="display: none" />
    <asp:Button ID="btncancle" runat="server" Text="No" Style="display: none" />
</asp:Content>
