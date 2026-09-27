<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetVehicleJo.aspx.vb" Inherits="Fleet_FleetVehicleJo" Title="eLOGiFleet :: Vehicle Booking"
    Theme="Forms" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../Script/jquery-1.4.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../Script/wz_jsgraphics.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopup() {
            $(function () {
                $("#dialog").dialog({
                    title: "eLOGiFleet :: Vehicle Booking",
                    width: 450,
                    height: 200,
                    resizable: false,
                    buttons: {
                        Save: function () {
                            $(document.getElementById('<%= btnsavejo.ClientID %>')).click();
                        },
                        Cancel: function () {
                            $(document.getElementById('<%= btncancle.ClientID %>')).click();
                        }

                    }
                });
            });
        };
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Vehicle Booking" CssClass="FormLabelTitle"> </asp:Label>
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
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblGRNo" runat="server" CssClass="label" Text="JO No"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:TextBox ID="textGrNo" Width="120px" runat="server" CssClass="textbox" Enabled="false"> </asp:TextBox>
                                            <asp:ImageButton ID="btnsearchJo"   runat="server" Visible="false" Width="30px" Height="20px"  ImageUrl="~/Images/brnAddtop.png" />
                                          
                                            </td>
                                            <asp:HiddenField ID="hdnJoId" runat="server" />
                                            <td style="text-align: left">
                                             <asp:Label ID="lblGrDate" runat="server" CssClass="label" Text="JO Date"></asp:Label>
                                              
                                             </td>
                                            <td style="text-align: left">
                                                 <asp:TextBox ID="textGrDate" runat="server" Width="100px" CssClass="Rpttextbox" Enabled="false"> </asp:TextBox>
                                            </td>
                                        </tr>
                                         
                                        <tr>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblExporterShipper" runat="server" CssClass="label" Text="Consignor"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownlist ID="lstCustomer" runat="server" CssClass="ddlMedium" >
                                             </asp:DropDownlist>
                                              <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblConsignee" runat="server" CssClass="label" Text="Consignee"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                              <asp:DropDownList ID="lstConsignee" runat="server"  CssClass="ddlMedium"
                                                   >
                                             </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblDocType" runat="server" CssClass="label" Text="Jo Type"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownList ID="lstDocType" runat="server" CssClass="ddlMedium" >
                                                 <asp:ListItem Text="---Select---" Value="">
                                                </asp:ListItem>
                                             
                                                   <asp:ListItem Text="Domestic" Value="D">
                                                </asp:ListItem>
                                                <asp:ListItem Text="Export" Value="E">
                                                </asp:ListItem>
                                                  <asp:ListItem Text="Import" Value="I">
                                                </asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblLine1" runat="server" CssClass="label" Text="Line 1"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownlist ID="lstLine1" runat="server" CssClass="ddlMedium" >
                                              </asp:DropDownlist>
                                               <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                           <tr>
                                             <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblBillTo" runat="server" CssClass="label" Text="Bill To"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownlist ID="lstBillTo" runat="server" Width="95px"  CssClass="ddlMedium" >
                                                   <asp:ListItem Text="---Select---" Value="">
                                                </asp:ListItem>
                                             
                                                  <asp:ListItem Text="Account" Value="O">
                                                </asp:ListItem>
                                             
                                                <asp:ListItem Text="Consignee" Value="E">
                                                </asp:ListItem>
                                                 <asp:ListItem Text="Consignor" Value="R">
                                                </asp:ListItem>
                                                 <asp:ListItem Text="Line" Value="L">
                                                </asp:ListItem>
                                              </asp:DropDownlist>
                                               <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                                        </td>
                                                         <td style="text-align: left; vertical-align: top;">
                                                <asp:Label ID="lblOnAccount" runat="server" CssClass="label" Text="Account"></asp:Label>
                                            </td>
                                            <td style="text-align: left; vertical-align: top;">
                                                <asp:DropDownlist ID="lstOnAccount" runat="server" Width="130px" CssClass="ddlMedium" >
                                              </asp:DropDownlist>
                                              
                                           
                                        </tr>
                                          <tr>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblFromLocation" runat="server" CssClass="label" Text="To Location"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:DropDownlist ID="lstFromLocation" runat="server" CssClass="ddlMedium" Enabled="false">
                                              </asp:DropDownlist>
                                               <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblToLocation" runat="server" CssClass="label" Text="Hand Over Location"></asp:Label>
                                            </td>
                                            <td style="text-align: left" >
                                             <asp:DropDownList ID="lstToLocation" runat="server" 
                                                    CssClass="ddlMedium" Enabled="false">
                                             </asp:DropDownList>
                                              <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                        </tr>
                                 <tr>
                                  <td style="text-align: left">
                                                <asp:Label ID="lblTransporter" runat="server" CssClass="label" Text="Transporter"></asp:Label>
                                            </td>
                                            <td style="text-align: left" >
                                                <asp:DropDownlist ID="lstTransportar" runat="server"  CssClass="ddlMedium" Enabled="false">
                                              </asp:DropDownlist>
                                               <strong>
                                                    <samp class="mandatory">
                                                        *</samp></strong>
                                            </td>
                                            
                                 </tr>
                                       
                                       
                                   
                                        <tr>
                                            <td height="10px">
                                            </td>
                                        </tr>
                                             <tr>
                                           <td colspan="4" align="center">
                                           <table cellspacing="0">
                                           <tr class="RepheaderNew" align="center" width="200px" style="height:20px">

                            <td>
                                <asp:Label ID="lblSrNo" Width="40px" CssClass="labelHeader" runat="server" Text="Sr."></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBcdVehicleNo"  CssClass="labelHeader" Width="150px" runat="server" Text='Vehicle No<span class="mandatory"> *</span>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSize"  CssClass="labelHeader" Width="70px" runat="server" Text='Size <span class="mandatory"> *</span>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBcdContType"  CssClass="labelHeader" Width="70px" runat="server" Text='Type <span class="mandatory"> *</span>'></asp:Label>
                            </td>
                           
                         
                            <td style="width: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" valign="top" align="center">
                                <div style=" overflow: auto;">
                                    <asp:Repeater ID="repBookingContDeatils" runat="server">
                                        <HeaderTemplate>
                                            <table id="cont" cellspacing="0" style="margin-left: -4px; margin-right: -3px;">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                               
                                                <td>
                                                    <asp:TextBox ID="lblSrNo"  Width="30px" Enabled="false" CssClass="textbox"
                                                        runat="server" Text=' <%#Container.ItemIndex+1 %>'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="ddlMedium" Width="150px" OnSelectedIndexChanged="FILLDATA" Autopostback="True" ID="lstVehicleNo"  OnDataBinding="preparevehicle"  runat="server"
                                                        Text='<%# Eval("MtyContId") %>'   
                                                onblur="this.value=this.value.toUpperCase();"  ToolTip="Cont No">
                                                   </asp:DropDownList>
                                                    <asp:HiddenField ID="hdnContId" runat="server" Value='<%# Eval("MtyContId") %>' />
                                                </td>
                                                <td>
                                                    <asp:TextBox class="Rpttextbox" Width="71px" ID="textSize" runat="server"
                                                        Text='<%#Eval("ContSize") %>' ToolTip="Vehicle Size">
                                                        </asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="Rpttextbox" Width="71px" ID="textType" runat="server"
                                                      ToolTip="Vehicle Type"></asp:TextBox>
                                                </td>
                                                
                                               
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table></FooterTemplate>
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
                            <td colspan="2">
                                <div id="dvButton" style="vertical-align: bottom;">
                                    <table width="100%" border="0" cellspacing="0" style="vertical-align: bottom; height: 25px;
                                        background-repeat: no-repeat;">
                                        <tr style="margin-top: 0px;">
                                           <td align="center">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="FormButton" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                             <%--  <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                                <asp:ImageButton ID="btnCancellation" runat="server"  Visible="false" ImageUrl="~/Images/btnCancel.png" />   
                                                
                                                <asp:ImageButton ID="btnPrint" runat="server" Visible="false" ImageUrl="~/Images/btnPrint.png" /> </td>--%>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="FormButton" />
                                               <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                         
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
    <div id="dialog" style="display: none;">
        <table border="0" cellpadding="0" style="border-style: none;">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="lblCustomerName" runat="server" CssClass="FormLabelTitle" Width="350px"
                        Height="50" Text="Do you want to generate another Job Order ?"> </asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="btnsavejo" runat="server" Text="Yes" Style="display: none" />
    <asp:Button ID="btncancle" runat="server" Text="No" Style="display: none" />
</asp:Content>
