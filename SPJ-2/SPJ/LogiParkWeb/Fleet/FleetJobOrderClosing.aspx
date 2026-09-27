<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="~/Fleet/FleetJobOrderClosing.aspx.vb" Inherits="Fleet_FleetJobOrderClosing"
    Title="eLOGiFleet :: Job Order Closing" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../Script/validation.js">
    </script>
    <script type="text/javascript" language="javascript">

       
    </script>
    <table width="100%" style="vertical-align: top; height: 100%;">
        <tr style="margin-top: -1px;">
            <td valign="top">
                <div id="dvPage" style="vertical-align: top; overflow: auto; width: 100%;">
                    <table style="width: 100%;">
                        <tr style="height: 20px">
                            <td>
                                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="Fleet Job Order"
                                    CssClass="labelTitle">
                                </asp:Label>
                                <asp:Label ID="lblErrorMessage" CssClass="label" runat="server"></asp:Label>
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
                        <tr class="UserControls" style="height: 380px; margin-top: 0px;">
                            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                                <div id="dvControl" runat="server" style="width: 100%; border-style: none; vertical-align: top;">
                                    <table>
                                   
                      
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblJoType" runat="server" CssClass="label" Text="Jo Type"></asp:Label>
                            </td>
                            <td style="text-align: left">
                              
                                <asp:DropDownList ID="lstJoType" runat="server" Width="170px" CssClass="FormListBoxMedium"
                                      ToolTip="Jo Type">
                                     
                                </asp:DropDownList>
                                
                                <asp:HiddenField ID="hdnJoId" runat="server" Value="0" />
                                
                            </td>
                            
                            
                               <td style="text-align: left">
                                <asp:Label ID="lblVehiclNo" runat="server" CssClass="label" Text="Vehicle No"></asp:Label>
                            </td>
                             <td style="text-align: left">
                               <asp:DropDownList ID="lstVehicleNo" runat="server" Width="110px" AutoPostBack="true" CssClass="FormListBoxMedium"
                                      ToolTip="VehicleNo">    
                                </asp:DropDownList><asp:ImageButton ID="btnAddVehicleNo" runat="server" Visible="false" Width="30px" ImageUrl="~/Images/brnAddtop.png"
                                    Height="20px" />
                                 
                            </td>
                       
                               
                           
                            
                            
                                                    </tr>
                                                     <tr>
                           
                            
                            
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblJoNo" runat="server" CssClass="label" Text="Jo No"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textJoNo" Width="110px" runat="server" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblJoDate" runat="server" CssClass="label" Text="Jo Date"></asp:Label>
                            </td>
                             <td style="text-align: left">
                                <asp:TextBox ID="textJoDate" runat="server" Width="110px" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                      
                       <tr>
                       <td style="text-align: left">
                                <asp:Label ID="lblLocation" runat="server" CssClass="label" Text="Location"></asp:Label>
                            </td>
                             <td style="text-align: left">
                                <asp:TextBox ID="textLocation" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblSurveyBy" runat="server" CssClass="label" Text="Survey By"></asp:Label>
                            </td>
                             <td style="text-align: left">
                              
                                   <asp:TextBox ID="textSurveyBy" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                      
                       <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblDriver" runat="server" CssClass="label" Text="Driver"></asp:Label>
                            </td>
                             <td style="text-align: left">
                                <asp:DropDownList ID="lstDriver" runat="server" Width="110px" AutoPostBack="true" CssClass="FormListBoxMedium"
                                      ToolTip="VehicleNo">
                                      
                                </asp:DropDownList>
                            </td>
                             <td style="text-align: left">
                                <asp:Label ID="lblContactNo" runat="server" CssClass="label" Text="Driver Contact No"></asp:Label>
                            </td>
                             <td style="text-align: left">
                                <asp:TextBox ID="textContactNo" runat="server" Width="110px" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                       </tr>
                        <tr>
                      
                            <td style="text-align: left">
                                <asp:Label ID="lblLicenseValidity" runat="server" CssClass="label" Text="License Validity"></asp:Label>
                            </td>
                             <td style="text-align: left">
                              
                                   <asp:TextBox ID="textLicenseValidity" runat="server" Width="110px" CssClass="Rpttextbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblCloseDate" runat="server" CssClass="label" Text="Jo Close Date"></asp:Label>
                            </td>
                             <td style="text-align: left">
                                <asp:TextBox ID="textCloseDate" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                  <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textCloseDate" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                      
                       <tr>
                        <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblRemark" runat="server" CssClass="label" Text="Remark"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left">
                             <asp:TextBox ID="textNote" runat="server" Width="400px" CssClass="textbox"
                                                                ToolTip="Note">
                                                            </asp:TextBox>
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
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                              
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />
                                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                                <asp:ImageButton ID="btnSave" runat="server" Visible="false" ImageUrl="~/Images/btnSave.png"
                                    />
                                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
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
