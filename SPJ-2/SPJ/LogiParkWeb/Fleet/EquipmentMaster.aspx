<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/EquipmentMaster.aspx.vb" Inherits="Fleet_EquipmentMaster" Title="eLOGiFleet :: Equipment Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>

    <script type="text/javascript">
        function checkFileExtension(elem) {
            var filePath = elem.value;

            if (filePath.indexOf('.') == -1)
                return false;

            var validExtensions = new Array();
            var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

            validExtensions[0] = 'jpg';
            validExtensions[1] = 'jpeg';
            validExtensions[2] = 'png';
            validExtensions[3] = 'pdf';
            validExtensions[4] = 'doc';

            for (var i = 0; i < validExtensions.length; i++) {
                if (ext == validExtensions[i])
                    return true;
            }

            alert('The file extension ' + ext.toUpperCase() + ' is not allowed!');
            return false;
        }
    </script>

    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top; border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vehicle Master"
                                    CssClass="FormLabelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblmandatory" runat="server" CssClass="label" Text="* mandatory field"
                                    ForeColor="Red"></asp:Label>
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
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEquipmentNo" runat="server" Text="Vehicle No" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEquipmentNo" runat="server" Font-Bold="true" Font-Size="Medium"
                                                    CssClass="textbox" ToolTip="Vehicle No" Width="179px" MaxLength="15" onblur="this.value=this.value.toUpperCase();"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <asp:HiddenField ID="hdnEquipmentId" runat="server" Value="" />
                                                <asp:HiddenField ID="hdnVehiclePic" runat="server" Value="" />
                                            </td>
                                            <td rowspan="15" style="width: 10px;"></td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEuipmentType" runat="server" CssClass="label" Text="Vehicle Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstEuipmentType" runat="server" Width="126px" CssClass="ddlMedium"
                                                    ToolTip="Vehicle Type">
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblHpBy" runat="server" CssClass="label" Text="HP By"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstHpBy" runat="server" Width="125px" CssClass="ddlMedium"></asp:DropDownList>

                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblXlType" runat="server" CssClass="label" Text="XL Type"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textXlType" runat="server" Width="120px" CssClass="textbox"
                                                    ToolTip="XL Type" MaxLength="4"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPucrchageDate" runat="server" CssClass="label" Text="Purchase Date"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPucrchageDate" runat="server" Width="120px" CssClass="textbox"
                                                    ToolTip="Purchase Date" MaxLength="10"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="textPucrchageDate"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblInsuranceNo" runat="server" CssClass="label" Text="Insurance No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textInsuranceNo" runat="server" Width="120px" CssClass="textbox"
                                                    ToolTip="Insurance No" MaxLength="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblInsuranceVendor" runat="server" CssClass="label" Text="Insurance Vendor"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstInsurance" runat="server" Width="186px" CssClass="ddlMedium"
                                                    ToolTip="Insurance">
                                                    <asp:ListItem Text="---Select---" Value="0" />
                                                    <asp:ListItem Text="HDFC" Value="3" />
                                                    <asp:ListItem Text="ICICI Lomabrd" Value="1" />
                                                    <asp:ListItem Text="LIC" Value="2" />
                                                    <asp:ListItem Text="UIICL" Value="4" />
                                                    <asp:ListItem Text="NIICL" Value="5" />
                                                    <asp:ListItem Text="ORIENTAL" Value="6" />
                                                    <asp:ListItem Text="IFFCO-TOKIO" Value="7" />
                                                    <asp:ListItem Text="NATIONAL INSURANCE" Value="8" />
                                                    <asp:ListItem Text="UNIVERSAL SOMPO GENRAL INSURANCE" Value="9" />
                                                    <asp:ListItem Text="ROYAL SUNDRAM" Value="10" />
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Insurance Validity Date"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textInsuranceValidity" runat="server" Width="120px" MaxLength="10"
                                                    CssClass="textbox" ToolTip="Insurance Validity"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textInsuranceValidity"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEngNo" runat="server" CssClass="label" Text="Engine No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEngNo" runat="server" MaxLength="20" Width="120px" CssClass="textbox"
                                                    ToolTip="Engine No"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEngType" runat="server" CssClass="label" Text="Engine  Type"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEngType" runat="server" Width="120px" MaxLength="12" CssClass="textbox"
                                                    ToolTip="Engine type" onblur="this.value=this.value.toUpperCase();"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblChassisNo" runat="server" CssClass="label" Text="VIN/Chassis No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textChassisNo" runat="server" MaxLength="20" Width="120px" CssClass="textbox"
                                                    ToolTip="Chassis No" onblur="this.value=this.value.toUpperCase();"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblManufacturingYear" runat="server" CssClass="label" Text="Manufacturing Year"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textManufacturingYear" runat="server" Width="120px" MaxLength="4"
                                                    CssClass="textbox" ToolTip="Manufacturing Year" onkeypress="kp_integer()"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <%-- <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textManufacturingYear" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                --%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRegistrationDate" runat="server" CssClass="label" Text="Registration Date"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRegistrationDate" runat="server" Width="120px" MaxLength="10"
                                                    CssClass="textbox" ToolTip="Registration Date"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textRegistrationDate"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblManufacturer" runat="server" CssClass="label" Text="Manufacturer"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstManufacturer" runat="server" Width="186px" CssClass="ddlMedium"
                                                    ToolTip="Manufacturer">
                                                    <asp:ListItem Text="-------Select-------" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="TATA" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="ASHOK LEYLAND" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="EICHER" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblModel" runat="server" CssClass="label" Text="Model"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textModel" runat="server" Width="120px" MaxLength="12" CssClass="textbox"
                                                    ToolTip="Model"></asp:TextBox>
                                            </td>

                                            <td style="text-align: left">
                                                <asp:Label ID="lblCondition" runat="server" CssClass="label" Text="Owner"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstCondition" runat="server" Width="126px" CssClass="ddlMedium"
                                                    ToolTip="Owner">
                                                    <asp:ListItem Text="---Select---" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="Hired" Value="F"></asp:ListItem>
                                                    <asp:ListItem Text="Own" Value="G" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPermitFrom" runat="server" CssClass="label" Text="National Permit Valid To"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPermitFrom" runat="server" MaxLength="10" Width="120px" CssClass="textbox"
                                                    ToolTip="Permit Valid From"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="textPermitFrom"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPermitTo" runat="server" CssClass="label" Text="PermitAB Valid To"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textPermitTo" runat="server" MaxLength="10" Width="120px" CssClass="textbox"
                                                    ToolTip="Permit To"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="textPermitTo"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblTareWt" runat="server" CssClass="label" Text="Tare Weight(MT)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textTareWt" runat="server" Width="120px" MaxLength="3" CssClass="textbox"
                                                    ToolTip="Tare Wt"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblGrossWt" runat="server" CssClass="label" Text="Gross Weight(MT)"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textGrossWt" runat="server" Width="120px" MaxLength="3" CssClass="textbox"
                                                    ToolTip="Gross Wt"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>

                                        </tr>



                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblChangeableBed" runat="server" CssClass="label" Text="Changeable Bed"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstChangeableBed" runat="server" Width="127px" CssClass="ddlMedium"
                                                    ToolTip="Changeable Bed">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="NO" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblBedNo" runat="server" CssClass="label" Text="Bed No"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBedNo" runat="server" OnSelectedIndexChanged="TireDtls" Width="127px" CssClass="ddlMedium"
                                                    ToolTip="Bed No">
                                                </asp:DropDownList>

                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPollutionValidity" runat="server" CssClass="label" Text="Pollution Validity"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textpollutionValidity" runat="server" Width="120px" MaxLength="10" CssClass="textbox"
                                                    ToolTip="Pollution Validity"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="textpollutionValidity"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblRto" runat="server" CssClass="label" Text="RTO"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRto" runat="server" MaxLength="30" Width="120px" CssClass="textbox"
                                                    ToolTip="RTO"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="LblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="LstTransporter" runat="server" MaxLength="30" Width="120px" CssClass="ddlMedium"
                                                    ToolTip="RTO">
                                                </asp:DropDownList>

                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Fitness Validity"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textValidity" runat="server" MaxLength="10" Width="120px" CssClass="textbox"
                                                    ToolTip="Validity"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="textValidity"
                                                    Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>

                                                <asp:CheckBox ID="ChkActive" runat="server" CssClass="FormCheckBox" Text="Active" />
                                            </td>
                                        </tr>


                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lbl" runat="server" CssClass="label" Text="RC Document"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblRcDtls" runat="server" CssClass="label" Text=""></asp:Label>
                                                <asp:FileUpload ID="FileRc" runat="server" onchange="return checkFileExtension(this);" />

                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label4" runat="server" CssClass="label" Text="Insurance Document"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblInsuDtls" runat="server" CssClass="label" Text=""></asp:Label>
                                                <asp:FileUpload ID="FileInsurance" runat="server" onchange="return checkFileExtension(this);" />

                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblPermit" runat="server" CssClass="label" Text="National Permit"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblpermitAdtls" runat="server" CssClass="label" Text=""></asp:Label>
                                                <asp:FileUpload ID="FilePermitPartA" runat="server" onchange="return checkFileExtension(this);" />

                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Permit AB"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblPermitBDtls" runat="server" CssClass="label" Text=""></asp:Label>
                                                <asp:FileUpload ID="FilePermitB" runat="server" onchange="return checkFileExtension(this);" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Fitness Document"></asp:Label>&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblFitDtls" runat="server" CssClass="label" Text=""></asp:Label>
                                                <asp:FileUpload ID="fileVehicleFitness" runat="server" onchange="return checkFileExtension(this);" />

                                            </td>

                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td colspan="2"></td>

                                            <td colspan="2">

                                                <table id="tblBedDtls" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                                    <tr class="RepHeadFleet">
                                                        <td>
                                                            <asp:Label ID="lblTireSrNo" Width="70px" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Tire Sr No"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInstallDate" Width="115px" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Installation Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInstallLoc" Width="150px" Font-Bold="true" CssClass="labelHeader"
                                                                runat="server" Text="Installation Location"></asp:Label>
                                                        </td>
                                                        <td width="17px" style="background-color: White;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <div style="height: 100px; overflow: auto;">
                                                                <asp:GridView ID="gvTireDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                                                    RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                                                    <Columns>

                                                                        <asp:BoundField ItemStyle-Width="70px" DataField="TIRE_NO" />
                                                                        <asp:BoundField ItemStyle-Width="115px" DataField="INSTALLATION_DATE" />
                                                                        <asp:BoundField ItemStyle-Width="145px" DataField="INSTALL_LOCATION" />

                                                                    </Columns>
                                                                </asp:GridView>

                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 325px; width: 300px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 13px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                            <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <%--<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />--%>
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="FormButton" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                                <asp:Button ID="btnExcel" runat="server" Text="Exil Download" CssClass="FormButton" />
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
        <asp:GridView ID="gvEqpmntDtls" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
