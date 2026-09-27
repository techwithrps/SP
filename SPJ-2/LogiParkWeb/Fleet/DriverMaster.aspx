<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/DriverMaster.aspx.vb" Inherits="Fleet_DriverMaster" Title="eLOGiFleet :: Driver Master"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
     <script type="text/javascript">
         function ShowPopup() {
             $(function () {
                 //             $("[id*=btnInsuUpload]").live("click", function () {
                 var dlg = $("#dialog").dialog({
                     title: "Upload Document",
                     buttons: {
                         Upload: function () {
                             $(document.getElementById('<%= btnUpload.ClientID %>')).click();
                         },
                         Cancle: function () {
                             $(document.getElementById('<%= btncancle.ClientID %>')).click();
                         }
                     }
                 });
                 dlg.parent().appendTo(jQuery("form:first"));
                 return false;
             });

         };
    </script>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="vertical-align: top;
        border-style: none; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%; height: 490px">
                    <table style="width: 100%; border-style: none;" border="0" cellpadding="0">
                        <tr valign="top" style="margin-top: 0px;">
                            <td>
                                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Driver Master"
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
                        <tr class="UserControls" style="height: 400px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table border="0" cellpadding="0" style="border-style: none;">
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDriverName" runat="server" Text="Driver Name" CssClass="label"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textDriverName" runat="server" CssClass="textbox" ToolTip="Driver Name"
                                                    Width="170px" onblur="this.value=this.value.toUpperCase();"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                         <asp:HiddenField ID="hdnClick" runat="server" Value="" />
                                                                       
                                                                        <asp:HiddenField ID="hdnDL" runat="server" Value="" />
                                                                        
                                                                        <asp:HiddenField ID="hdnAddress" runat="server" Value="" />
                                 
                                                <asp:HiddenField ID="hdnDriverId" runat="server" Value="" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblVehicle" runat="server" CssClass="label" Text="Vehicle"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstVehicleNo" runat="server" Width="140px" CssClass="ddlMedium" ToolTip="Vehicle No">
                                                </asp:DropDownList>
                                                 <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td rowspan="5" valign="top">
                                            <asp:Image ID="ImgDriver" Width="135px" runat="server" Height="121px" 
                                                    CssClass="textbox" ImageUrl="~/Fleet/FleetImage/logo.png" />
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmailId" runat="server" CssClass="label" Text="Email-Id"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmailid" runat="server" Width="170px" CssClass="textbox"
                                                    ToolTip="Email-Id"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblBlood" runat="server" CssClass="label" Text="Blood Group"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownList ID="lstBloodGroup" runat="server" Width="70px" CssClass="ddlMedium">
                                                    <asp:ListItem Value="" Text="-Select-"></asp:ListItem>
                                                    <asp:ListItem Value="A+" Text="A+"></asp:ListItem>
                                                    <asp:ListItem Value="A-" Text="A-"></asp:ListItem>
                                                    <asp:ListItem Value="B+" Text="B+"></asp:ListItem>
                                                    <asp:ListItem Value="B-" Text="B-"></asp:ListItem>
                                                    <asp:ListItem Value="O+" Text="O+"></asp:ListItem>
                                                    <asp:ListItem Value="O-" Text="O-"></asp:ListItem>
                                                    <asp:ListItem Value="AB+" Text="AB+"></asp:ListItem>
                                                    <asp:ListItem Value="AB-" Text="AB-"></asp:ListItem>	
                                                </asp:DropDownList>
                                                &nbsp;
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNo" runat="server" MaxLength="10" Width="120px" CssClass="textbox"
                                                    ToolTip="Contact No" onkeypress="kp_integer()"></asp:TextBox>
                                                     <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblContactNoPersonal" runat="server" CssClass="label" Text="Personal Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textContactNoPersonal" runat="server" MaxLength="10" Width="140px"
                                                    CssClass="textbox" ToolTip="Contact No" onkeypress="kp_integer()"></asp:TextBox>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblMobileNo" runat="server" CssClass="label" Text="Mobile No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textMobileNo" runat="server" MaxLength="10" Width="120px" CssClass="textbox"
                                                    ToolTip="Mobile No" onkeypress="kp_integer()"></asp:TextBox>
                                                     <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblEmergency" runat="server" CssClass="label" Text="Emergency Contact No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textEmergency" runat="server" MaxLength="10" Width="140px"
                                                    CssClass="textbox" ToolTip="Contact No" onkeypress="kp_integer()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDlNO" runat="server" CssClass="label" Text="DL No"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textDlNO" runat="server" Width="120px" MaxLength="25" CssClass="textbox"
                                                    ToolTip="DL NO" onblur="this.value=this.value.toUpperCase();"></asp:TextBox>
                                                     <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            
                                            <td style="text-align: left">
                                                <asp:Label ID="lblJoining" runat="server" CssClass="label" Text="Joining Date"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textJoining" runat="server" Width="140px"  MaxLength="12" CssClass="textbox"
                                                    ToolTip="Joining Date"></asp:TextBox>
                                                     <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textJoining" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblDlRenewal" runat="server" CssClass="label" Text="DL Renewal Date"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRenewal" runat="server" Width="120px" MaxLength="12" CssClass="textbox"
                                                    ToolTip="DL Renewal"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textRenewal" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                 <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                             <td style="text-align: left">
                                                <asp:Label ID="lblSalary" runat="server" CssClass="label" Text="Salary"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textSalary" runat="server" onkeypress="kp_integer()" Width="120px" MaxLength="8" CssClass="textbox"
                                                    ToolTip="Salary"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblReference" runat="server" CssClass="label" Text="Guarantor/Ref."></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textRef" runat="server" TextMode="MultiLine" Width="200px" Height="35px" MaxLength="200" CssClass="textbox"
                                                    ToolTip="Gaurantor"></asp:TextBox>
                                               
                                                
                                            </td>
                                             <td style="text-align: left">
                                                <asp:Label ID="lblAddress" runat="server" CssClass="label" Text="Address"></asp:Label>&nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:TextBox ID="textAddress" runat="server" TextMode="MultiLine"  Width="200px" Height="35px" MaxLength="200" CssClass="textbox"
                                                    ToolTip="Address"></asp:TextBox>
                                                <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                             <td align="left" >
                                            
                                                <asp:FileUpload ID="fileDriverPic" runat="server" />

                                             <asp:HiddenField ID="hdnDriverPic" runat="server" Value="" />
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                                                                                                <asp:LinkButton ID="btnAddressUpload" runat="server" Width="64px" CssClass="FormLabel"
                                                                                                                                    Text="Address Upload" CommandArgument="1" OnClick="OnClickHandler"></asp:LinkButton>
                                                                                                                            </td>
                                                                                                                            <td>
                                                                                                                            </td>
                                                                                                                              <td>
                                                                                                                                <asp:LinkButton ID="btnDLUpload" runat="server" Width="64px" CssClass="FormLabel"
                                                                                                                                    Text="DL Upload" CommandArgument="2" OnClick="OnClickHandler"></asp:LinkButton>
                                                                                                                            </td>
                                                                                                                            </td>
                                                                                                                            <tr>
                                            <td align="left">
                                            <asp:CheckBox ID="ChkActive" runat="server" CssClass="FormCheckBox" Text="Active" />
                                            </td>

                                            </tr>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="RepScroling" class="RepScroling" style="height: 360px; width: 350px; border-left-color: Black;">
                                    <asp:TreeView ID="tvTreeView" runat="server" Style="font-family: Verdana; font-size: 12px"
                                        Width="144px">
                                    </asp:TreeView>
                                </div>
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
    <asp:GridView ID="gvDriverDtls" runat="server">
    </asp:GridView>
    </div>
     <div id="dialog" style="display: none">
        <asp:FileUpload ID="fileUpload" runat="server" multiple="true" class="multi" />
    </div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload" Style="display: none" CssClass="FormButton" />
    <asp:Button ID="btnCancle" runat="server" Text="Cancle" Style="display: none" />
</asp:Content>
