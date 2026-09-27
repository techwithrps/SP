<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/VehicleMaster.aspx.vb" Inherits="Fleet_VehicleMaster"
    Title="eLOGiFleet :: Vehicle Master" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                   
                            <table style="width: 100%; border-style: none;">
                                <tr style="height: 20px;">
                                    <td>
                                        <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Vehicle Master"
                                            CssClass="FormLabelTitle"> </asp:Label>
                                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="FormLabel"></asp:Label>
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
                                <tr class="UserControls" style="height: 320px; margin-top: 0px;">
                                    <td style="width: 100%; vertical-align: top;" align="left" colspan="3">
                                        <div id="dvControl" runat="server" style="width: 100%; vertical-align: top;">
                                        <table>
                                        <tr>
                <td valign="middle" class="style2">
                    <table style="background-color: #FFFFFF">
                        
                       
                        <tr>
                        <td></td>
                        <td>
                        <div>
                        <table>
                     
                        <tr>
<td>
<asp:LinkButton ID="lnkEquipMentSummary" runat="server" CssClass="FormLabel" 
        OnClick="lnkEquipMentSummary_Click" >Equipment Summary</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkTireAndWheels" runat="server" OnClick="lnkTireAndWheels_Click" CssClass="FormLabel" >Tires and Wheels</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkParts" runat="server" OnClick="lnkParts_Click" CssClass="FormLabel" >Parts</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkFilter" runat="server" OnClick="lnkFilter_Click" CssClass="FormLabel" >Filters</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkDocuments" runat="server" OnClick="lnkDocuments_Click" CssClass="FormLabel" >Documnets</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkGrDtls" runat="server" OnClick="lnkGrDtls_Click" CssClass="FormLabel" >GR Details</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkLubeService" runat="server" OnClick="lnkLubeService_Click" CssClass="FormLabel" >Lube/Service</asp:LinkButton></td>
<td>
<asp:LinkButton ID="lnkRepairs" runat="server" OnClick="lnkRepairs_Click" CssClass="FormLabel" >Repairs</asp:LinkButton></td>
</tr>
                        </table>
                        </div>
                        </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                               <asp:MultiView ID="mvVehicleMster" runat="server">
<table width="100%" cellpadding="2" cellspacing="5">
<tr>
<td>
<asp:View ID="vEquipmentSummary" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblEquipmentId" runat="server" Text="Equipment Id" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="txtEquipmentId" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblEquipmentNo" runat="server" Text="Equipment No" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtEquipmentno" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td><asp:Label ID="lblEquipmentType" runat="server" Text="Equipment Type" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtEquipmentType" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblSrVinNo" runat="server" Text="SR / VIN No" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtSrVinNo" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblYear" runat="server" Text="Year" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtYear" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblModel" runat="server" Text="Model" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtModel" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="LblEngineNo" runat="server" Text="Engine NO" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtEngine" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblChangableBed" runat="server" Text="Changeable Bed" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:DropDownList ID="lstChangableBed" runat="server" Width="70px">

    <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="YES" Value="Y"></asp:ListItem>
 <asp:ListItem Text="NO" Value="N"></asp:ListItem>


    </asp:DropDownList> 
    </td>
</tr>
<tr>
<td>
<asp:Label ID="LblLicenseplatNo" runat="server" Text="License Plat No" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtLicensePlatNo" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>

<td>
<asp:Label ID="lblPurchaseOrderNo" runat="server" Text="Purchase Order No" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="txtPurchaseOrderNo" runat="server" MaxLength="20"    CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>
</tr>
<tr>
<td>
<asp:Label ID="lblFuelGasCardNo" runat="server" Text="Fuel / Gas Card No" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtFuelGasCardNo" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblCondition" runat="server" Text="Condition" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"><asp:DropDownList ID="lstCondition" runat="server" Width="100px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="EXCELLENT" Value="E"></asp:ListItem>
 <asp:ListItem Text="FAIR" Value="F"></asp:ListItem>
   <asp:ListItem Text="GOOD" Value="G"></asp:ListItem>
    </asp:DropDownList> </td>
</tr>
<tr>
<td>
<asp:Label ID="lblTareWt" runat="server" Text="Tare Wt." CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtTareWt" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>

<td><asp:Label ID="lblFuelTyepe" runat="server" Text="Fuel Type" CssClass="FormLabel"></asp:Label></td>
<td align="left"><asp:DropDownList ID="lstFuelType" runat="server" Width="70px">
 <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="DIESEL" Value="D"></asp:ListItem>
 <asp:ListItem Text="DIESEL2" Value="D2"></asp:ListItem>
   <asp:ListItem Text="GAS" Value="G"></asp:ListItem>
    </asp:DropDownList> </td>
</tr>
<tr>
<td>
<asp:Label ID="lblGrossWt" runat="server" Text="Gross Wt." CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="txtGrossWt" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>

<td>
<asp:Label ID="lblLocation" runat="server" Text="Location" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:DropDownList ID="lstTeminl" runat="server" Width="100px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
    </asp:DropDownList> </td>

</tr>
<tr>
<td colspan="5" align="center">
<div>
<table id="tblCont" runat="server" cellspacing="0" style="margin-left: 0px; padding: 0px;">
                                                <tr class="RepHead">
                                                   
                                                    <td>
                                                        <asp:Label ID="lblrKm" CssClass="FormLabel" runat="server" Width="70px" Text="KM">
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrOdometerKM" Width="100px" runat="server" CssClass="FormLabel" Text="ODOMETER"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrHour" CssClass="FormLabel" Width="70px" runat="server" Text="HOUR">
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrOdometerHour" CssClass="FormLabel" Width="100px" runat="server" Text="ODOMETER">
                                                        </asp:Label>
                                                    </td>
                                                   
                                                    
                                                    <td style="background-color: White; width: 15px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" valign="top" align="center">
                                                        <div class="RepScroling" style="height: 100px;">
                                                            <asp:Repeater ID="rcVehicleDtls" runat="server">
                                                                <HeaderTemplate>
                                                                    <table id="cont" cellspacing="0">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                       
                                                                        <td>
                                                                           
                                                                            <asp:TextBox CssClass="FormTextBoxSmall" Width="70px" ID="textKm" runat="server"
                                                                          ToolTip="KM" MaxLength="10"  >
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                              <asp:TextBox CssClass="FormTextBoxSmall" Width="100px" ID="textOdometerKm" runat="server"
                                                                          ToolTip="Odomete Reading" MaxLength="10" >
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        
                                                                        <td>
                                                                            <asp:TextBox CssClass="FormTextBoxSmall" Width="70px" ID="textHour" runat="server"
                                                                                  ToolTip="Hour" MaxLength="15"></asp:TextBox>
                                                                        </td>
                                                                       
                                                                        <td>
                                                                            <asp:TextBox CssClass="FormTextBoxNumSmall" Width="100px" ID="textOdometerHour" runat="server"
                                                                                 ToolTip="OdoMeter Hour"
                                                                                MaxLength="6">
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
</div>
</td>
</tr>

</table>
</div>
</asp:View>
</td>
<td valign="top">
<asp:View ID="vTireMaintenance" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblManufacture" runat="server" Text="Manufacturer" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textManufacturer" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblTireModel" runat="server" Text="Model" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textTireModel" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblTireSize" runat="server" Text="Size" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textTireSize" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblOdometerReading" runat="server" Text="OdoMeter Reading" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="TextOdoMeterReading" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblInstallLocation" runat="server" Text="Install Location" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"><asp:DropDownList ID="LstInstallLocation" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="Right Steering-I" Value="R-I"></asp:ListItem>
 <asp:ListItem Text="Right Steering-II" Value="R-II"></asp:ListItem>
 <asp:ListItem Text="Right Steering-III" Value="R-II"></asp:ListItem>
 <asp:ListItem Text="Right Steering-IV" Value="R-IV"></asp:ListItem>
 <asp:ListItem Text="Left Steering-I" Value="L-I"></asp:ListItem>
 <asp:ListItem Text="Left Steering-II" Value="L-II"></asp:ListItem>
 <asp:ListItem Text="Left Steering-III" Value="L-II"></asp:ListItem>
 <asp:ListItem Text="Left Steering-IV" Value="L-IV"></asp:ListItem>
 
    </asp:DropDownList>
 </td>

<td>
<asp:Label ID="lblSubLocation" runat="server" Text="Sub Location" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:DropDownList ID="lstTireSubLocation" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="Outer" Value="O"></asp:ListItem>
 <asp:ListItem Text="Inner" Value="I"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</div>
</asp:View>
</td>
<td valign="top">
<asp:View ID="vWheelMaintenance" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblWheelType" runat="server" Text="Wheel Type" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textWheelType" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblWheelSize" runat="server" Text="Size" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textWheelSize" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblWheelInstallDate" runat="server" Text="Install Date" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textWheelInstallDate" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblWheelOdoMeterReading" runat="server" Text="OdoMeter Reading" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textWheelOdoMeterReading" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblWheelInstallLocation" runat="server" Text="Install Location" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"><asp:DropDownList ID="lstWheelInstallLocation" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="Right Steering-I" Value="R-I"></asp:ListItem>
 <asp:ListItem Text="Right Steering-II" Value="R-II"></asp:ListItem>
 <asp:ListItem Text="Right Steering-III" Value="R-II"></asp:ListItem>
 <asp:ListItem Text="Right Steering-IV" Value="R-IV"></asp:ListItem>
 <asp:ListItem Text="Left Steering-I" Value="L-I"></asp:ListItem>
 <asp:ListItem Text="Left Steering-II" Value="L-II"></asp:ListItem>
 <asp:ListItem Text="Left Steering-III" Value="L-II"></asp:ListItem>
 <asp:ListItem Text="Left Steering-IV" Value="L-IV"></asp:ListItem>
 
    </asp:DropDownList>
 </td>

<td>
<asp:Label ID="lblWheelSubLocation" runat="server" Text="Sub Location" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:DropDownList ID="lstWheelSubLocation" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="Outer" Value="O"></asp:ListItem>
 <asp:ListItem Text="Inner" Value="I"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</div>
</asp:View>
</td>
<td valign="top">
<asp:View ID="vServicing" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblServiceType" runat="server" Text="Service Type" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:DropDownList ID="lstServiceType" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="3000 Miles Or 2 month" Value="S-I"></asp:ListItem>
 <asp:ListItem Text="9000 Miles Or 6 month" Value="S-II"></asp:ListItem>
 <asp:ListItem Text="24000 Miles Or 12  month" Value="S-III"></asp:ListItem>
 <asp:ListItem Text="100000 Miles or overhaul" Value="S-IV"></asp:ListItem>
    </asp:DropDownList>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblServiceDate" runat="server" Text="Service Date" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textServiceDate" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblServiceOdometerReading" runat="server" Text="OdoMeter Reading" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textServiceOdoMeterReading" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblServiceHour" runat="server" Text="Hour" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textServiceHour" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblServiceBy" runat="server" Text="Service By" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"><asp:DropDownList ID="lstServiceBy" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
 <asp:ListItem Text="Driver" Value="D"></asp:ListItem>
 <asp:ListItem Text="Fleet Technician" Value="F"></asp:ListItem>
 <asp:ListItem Text="Other" Value="O"></asp:ListItem>
 
    </asp:DropDownList>
 </td>
</tr>
<tr>
<td colspan="5">
<asp:CheckBoxList ID="chklstService" runat="server">
    </asp:CheckBoxList>
</td>
    
</tr>
</table>
</div>
</asp:View>
</td>
<td valign="top">
<asp:View ID="FuelLog" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblPetrolPump" runat="server" Text="Petrol Pump/Vendor" CssClass="FormLabel"></asp:Label>
</td>

<td align="left"><asp:DropDownList ID="lstPetrolPump" runat="server" Width="110px">
<asp:ListItem Text="---Select---" Value=""></asp:ListItem>
    </asp:DropDownList>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblBiginOdoMeter" runat="server" Text="Begin Odometer" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textBiginOdometer" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblCurrentOdometer" runat="server" Text="Current OdoMeter" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textCurrentOdodMeter" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>

<td>
<asp:Label ID="lblKm" runat="server" Text="Travel Dis.(Km)" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textDistanceKm" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblLiter" runat="server" Text="Liter" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="textLiter" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
 </td>

<td>
<asp:Label ID="lblCost" runat="server" Text="Cost" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textCost" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblAverage" runat="server" Text="Average" CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="textAverage" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
 </td>

<td>
<asp:Label ID="lblEntryDate" runat="server" Text="Cost" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textEntryDate" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblGrNo" runat="server" Text="GR No." CssClass="FormLabel"></asp:Label>
</td>
<td align="left">
<asp:TextBox ID="textGRNo" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
 </td>
</tr>
</table>
</div>
</asp:View>
</td>
<td valign="top">
<asp:View ID="vInsPection" runat="server">
<div>
<table>
<tr>
<td>
<asp:Label ID="lblInspectionDate" runat="server" Text="Wheel Type" CssClass="FormLabel"></asp:Label>
</td>
<td align="left"  >
<asp:TextBox ID="textInspectionDate" runat="server" MaxLength="20"   CssClass="FormTextBoxSmall"></asp:TextBox>
 </td>
<td style="width:10px" rowspan="8"> 
</td>
<td>
<asp:Label ID="lblitem" runat="server" Text="Size" CssClass="FormLabel"></asp:Label>
</td>
<td align="left" >
<asp:TextBox ID="textItem" runat="server" MaxLength="20"  CssClass="FormTextBoxSmall"></asp:TextBox> 
</td>
</tr>

</table>
</div>
</asp:View>
</td>

</tr>
</table>
</asp:MultiView>


                           
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
                                    <td colspan="2">
                                        <div id="dvButton" style="vertical-align: bottom;">
                                            <table width="100%" style="vertical-align: bottom; height: 25px; background-repeat: no-repeat;">
                                                <tr style="margin-top: 0px;">
                                                    <td align="center">
                                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
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
