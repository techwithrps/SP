<%@ Page Title=""  Theme="Forms" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AllPartyAccountpart3.aspx.vb" Inherits="Fleet_AllPartyAccountPart3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table id="tblReport" runat="server" width="100%">
        <tr style="height: 20px">
            <td>
                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="All Party Account Himanshu" CssClass="FormLabelTitle"> </asp:Label>
                <asp:Label ID="lblErrorMessage" CssClass="FormLabel" runat="server"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                         <td style="text-align: right">
                            <asp:Label ID="lblBLNose" runat="server" Text="BL No" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                           <asp:TextBox ID="txtBLNo" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox" MaxLength="50">
                            </asp:TextBox>
                       
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <%--<asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer" CssClass="ddlMedium">
                            </asp:DropDownList>--%>
                       <asp:TextBox ID="textCustomer" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox" MaxLength="50">
                            </asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblLocation" runat="server" Text="Location" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <%--<asp:DropDownList ID="lstLocation" runat="server" ToolTip="Location" CssClass="ddlMedium">
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="textLocation" runat="server" ToolTip="Location" Width="90px" CssClass="textbox" MaxLength="50">
                            </asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" OnClientClick="return DisplayValidation();" ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="28">
                <table cellspacing="0" id="tblAllPartyAccountPart2" runat="server" width="100%">
                     <%--<tr class="RepHead" style="border: solid;">
                       <td>
                            <asp:Label ID="lblchk" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Chk" Width="35px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSr" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr." Width="35px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblContNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="CONT NO" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShipperName" CssClass="FormLabel" runat="server" Font-Bold="True" Text="SHIPPER NAME" Width="130px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNotifyParty" CssClass="FormLabel" runat="server" Font-Bold="True" Text="NOTIFY PARTY" Width="250px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLinerInvNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="LINER INV NO" Width="115px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLinerInvDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="LINER INV DATE" Width="130px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBlno" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BL No" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPort" CssClass="FormLabel" runat="server" Font-Bold="True" Text="PORT" Width="100px"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="LINE" Width="100px"></asp:Label>
                        </td>
                        <td style="background-color: White; width: 15px;"></td>
                         <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    </tr>--%>
                    <tr>
                        <td align="left">
                            <div style="height: 150px; width:1300px; overflow: auto;">
                                <asp:GridView ID="GridViewAllPartyPart3" runat="server" AutoGenerateColumns="False"
                                    BackColor="AliceBlue" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CellSpacing="1">
                                   
                                    <HeaderStyle CssClass="RepHead" Font-Size="12px"/>
                                    <Columns>
                                        <%--<asp:TemplateField ItemStyle-Width="35px">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" ToolTip="Select Record"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField ItemStyle-Width="35px" HeaderText="Sr.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsrn" runat="server" CssClass="loginterminaltd"></asp:Label>
                                                <asp:HiddenField ID="hdnTackId" runat="server" Value='<%#Eval("TrackId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CONT NO">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("ContNo") %>' CommandArgument='<%#Eval("ContNo") %>' CommandName="part3" CssClass="loginterminaltd"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="150px" HeaderText="Shipper">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipperName" runat="server" Text='<%#Eval("ShipperName") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-Width="150px"  HeaderText="Consingee">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsingeeName" runat="server" Text='<%#Eval("ConsingeeName") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Liner Inv No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLinerInvNo" runat="server" Text='<%#Eval("LinerInvNo") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Liner Inv Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLinerInvDate" runat="server" Text='<%#Eval("LinerInvDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-Width="50px" HeaderText="SB No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSbNo" runat="server" Text='<%#Eval("SbNo") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-Width="50px" HeaderText="SB Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSbDate" runat="server" Text='<%#Eval("SbDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Cust Handover Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustomsHandoverDate" runat="server" Text='<%#Eval("CustomsHandoverDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Line Handover Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLineHandoverDate" runat="server" Text='<%#Eval("LineHandoverDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Sb Received">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSbReceived" runat="server" Text='<%#Eval("SbReceived") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField   ItemStyle-Width="50px" HeaderText="Cartons">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCartons" runat="server" Text='<%#Eval("Cartons") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Wt">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="GrossWt">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField  HeaderText="BILLING">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJsbBilling" runat="server" Text='<%#Eval("JsbBilling") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField  ItemStyle-Width="50px" HeaderText="Shipment Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipmentType" runat="server" Text='<%#Eval("ShipmentType") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Units">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUnits" runat="server" Text='<%#Eval("Units") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Port">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPort" runat="server" Text='<%#Eval("Port") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Line">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CFS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFS" runat="server" Text='<%#Eval("CFS") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField   ItemStyle-Width="50px" HeaderText="Booking No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingNo" runat="server" Text='<%#Eval("BookingNo") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                           <asp:TemplateField   ItemStyle-Width="50px" HeaderText="BL No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBlNo" runat="server" Text='<%#Eval("BlNo") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                           <asp:TemplateField   ItemStyle-Width="50px" HeaderText="FOLLOW UP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFollowUp" runat="server" Text='<%#Eval("FollowUp") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField   ItemStyle-Width="50px" HeaderText="SOB">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSob" runat="server" Text='<%#Eval("Sob") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                        <asp:TemplateField   ItemStyle-Width="50px" HeaderText="SAILED">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSailed" runat="server" Text='<%#Eval("Sailed") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField> 
                                         <asp:TemplateField ItemStyle-Width="150px"  HeaderText="BL STATUS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBlStatus" runat="server" Text='<%#Eval("BlStatus") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="OBL STATUS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOblStatus" runat="server" Text='<%#Eval("OblStatus") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="OBL RELEAS PARTY">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOblIssueDate" runat="server" Text='<%#Eval("OblIssueDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView>
                                        </div>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td colspan="10" align="left">&nbsp;</td>
                                        </tr>
                                        </table>
                                        </td>
                                        </tr>
                                        </table>
                                        <table style="width: 1266px">
        <tr class="UserControls" style="margin-top: 5px;">
            <td style="width: 100%; vertical-align: top;" align="center" colspan="2">
                <div id="Div1" runat="server" style="width: 100%; border-style: none; vertical-align: top; height: 236px;">
                    <table>
                        <tr>
                            
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblLinerBilling" runat="server" CssClass="label" Text="LINER BILLING"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textLinerBilling" Width="200px" runat="server" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                                <asp:HiddenField ID="hdnContNo" runat="server" />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblBlNo" runat="server" CssClass="label" Text="BL NUMBER"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textBlNo" runat="server" Width="200px" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblBLStatus" runat="server" CssClass="label" Text="BL STATUS"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textBlStatus" runat="server" Width="200px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblOblStatus" runat="server" CssClass="label" Text="OBL STATUS"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textOblStatus" runat="server" Width="200px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                           </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblFollowUp" runat="server" CssClass="label" Text="FOLLOW UP"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textFollowUp" runat="server" Width="200px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblOblReleased" runat="server" CssClass="label" Text="OBL RELEASED"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textOblReleased" runat="server" Width="200px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="textOblReleased"></ajaxToolkit:CalendarExtender>
                                </td>
                                <td style="text-align: left; vertical-align: top;">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left; vertical-align: top;">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">

                <%-- <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/btnAdd.png" />
                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/btnSearch.png" />--%>
                <asp:ImageButton ID="btnEdit" runat="server" Visible="false" ImageUrl="~/Images/btnEdit.png" />
                <asp:ImageButton ID="btnDelete" runat="server" Visible="false" ImageUrl="~/Images/btnDelete.png" />
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/btnSave.png" />
                <asp:ImageButton ID="btnCancel" runat="server" Visible="false" ImageUrl="~/Images/btnCancel.png" />
                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/Images/btnExit.png" />
            </td>
        </tr>
    </table>
     </asp:Content>

