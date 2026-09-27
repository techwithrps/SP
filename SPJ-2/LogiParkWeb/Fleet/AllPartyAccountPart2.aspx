<%@ Page Title="" Theme="Forms" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AllPartyAccountPart2.aspx.vb" Inherits="Fleet_AllPartyAccountPart2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tblReport" runat="server" width="100%">
        <tr style="height: 20px">
            <td>
                <asp:Label ID="lblScreenTitle" Width="400px" runat="server" Text="All Party Account Vikas" CssClass="FormLabelTitle"> </asp:Label>
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
            <td colspan="12">
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
                        <td>
                            <div style="height: 200px; width:1300px; overflow: auto;">
                                <asp:GridView ID="GridViewAllPartyPart1" runat="server" AutoGenerateColumns="False"  CssClass="GVHeadText"
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
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("ContNo") %>' CommandArgument='<%#Eval("ContNo") %>' CommandName="part2" CssClass="loginterminaltd"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="200px" HeaderText="Company">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipperName" runat="server" Text='<%#Eval("ShipperName")%>' CssClass="loginterminaltd"  Width="200px"  ItemStyle-HorizontalAlign="left"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-Width="200px"  HeaderText="Consingee">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsingeeName" runat="server" Text='<%#Eval("ConsingeeName") %>' CssClass="loginterminaltd" Width="200px"  ItemStyle-HorizontalAlign="left"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-Width="200px"  HeaderText="Notify Party">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNotifyParty" runat="server" Text='<%#Eval("NotifyParty") %>' CssClass="loginterminaltd" Width="200px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Lot">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLot" runat="server" Text='<%#Eval("Lot") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Health Crt No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHealthCertificateNo" runat="server" Text='<%#Eval("HealthCertificateNo") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Health Crt Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHealthCertificateDate" runat="server" Text='<%#Eval("HealthCertificateDate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-Width="50px" HeaderText="Self Excise">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSelfExcise" runat="server" Text='<%#Eval("SelfExcise") %>' CssClass="loginterminaltd"></asp:Label>
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
                                        <asp:TemplateField  HeaderText="Tare Wt">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTareWt" runat="server" Text='<%#Eval("TareWt") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField  ItemStyle-Width="50px" HeaderText="Shipment Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipmentType" runat="server" Text='<%#Eval("ShipmentType") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-Width="50px" HeaderText="FOB INR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFobValueInr" runat="server" Text='<%#Eval("FobValueInr") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField   ItemStyle-Width="50px" HeaderText="Ex Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExRate" runat="server" Text='<%#Eval("ExRate") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="FOB USD">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFobValueUsd" runat="server" Text='<%#Eval("FobValueUsd") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="CNF USD">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCnfUsd" runat="server" Text='<%#Eval("CnfUsd") %>' CssClass="loginterminaltd"></asp:Label>
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
                                         <asp:TemplateField HeaderText="Country">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Country") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Region">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRegion" runat="server" Text='<%#Eval("Region") %>' CssClass="loginterminaltd"></asp:Label>
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
                                        
                                         <asp:TemplateField HeaderText="CHA">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCha" runat="server" Text='<%#Eval("Cha") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="PDA Account">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPdaAccount" runat="server" Text='<%#Eval("PdaAccount") %>' CssClass="loginterminaltd"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField   ItemStyle-Width="50px" HeaderText="Booking No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookingNo" runat="server" Text='<%#Eval("BookingNo") %>' CssClass="loginterminaltd"></asp:Label>
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
                                <asp:Label ID="lblconsingee" runat="server" CssClass="label" Text="Consingee"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textConsingee" Width="200px" runat="server" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                                <asp:HiddenField ID="hdnContNo" runat="server" />
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblLot" runat="server" CssClass="label" Text="Lot"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textLot" runat="server" Width="110px" CssClass="textbox" ToolTip="Lot">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblhealthCertNo" runat="server" CssClass="label" Text="Health Certificate No"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textHealthCertNo" runat="server" Width="165px" CssClass="textbox" ToolTip="Health Certificate No">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblhealthCertDate" runat="server" CssClass="label" Text="Health Certificate Date"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="texthealthDate" runat="server" Width="110px" CssClass="textbox" ToolTip="Date">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="texthealthDate"></ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                        <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblExcSealingrpt" runat="server" CssClass="label" Text="Excise Sealing Report"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textExcSealingRpt" runat="server" Width="165px" CssClass="textbox" ToolTip="Excise Sealing Report">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Liner Invoice No"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textLInvoiceNo" runat="server" Width="165px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Liner Inv Date"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textLInvDate" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender5" TargetControlID="textLInvDate"></ajaxToolkit:CalendarExtender>
                            </td>
                           
                           
                            <td style="text-align: left">
                                <asp:Label ID="lblDate" runat="server" CssClass="label" Text="SB Date"></asp:Label>
                            </td>
                           
                           
                            <td style="text-align: left">
                                <asp:TextBox ID="textSbDate" runat="server" Width="110px" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="textSbDate"></ajaxToolkit:CalendarExtender>
                            </td>
                           
                           
                        </tr>
                        <tr>
                        <td style="text-align: left">
                                <asp:Label ID="lblcustomhandover" runat="server" CssClass="label" Text="Cutom HandOver Date"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textCustomHandOver" runat="server" Width="165px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="textCustomHandOver"></ajaxToolkit:CalendarExtender>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblLinehandover" runat="server" CssClass="label" Text="Line HandOver"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textLineHandOver" runat="server" Width="165px" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="textLineHandOver"></ajaxToolkit:CalendarExtender>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblSbillRcvd" runat="server" CssClass="label" Text="S-Bill Recd"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textSbillRcvd" runat="server" Width="165px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                           
                           
                            <td style="text-align: left">
                                <asp:Label ID="lblCartons" runat="server" CssClass="label" Text="Cartons"></asp:Label>
                            </td>
                           
                           
                            <td style="text-align: left">
                                <asp:TextBox ID="textCartons" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                           
                           
                        </tr>
                        <tr>
                            
                             <td style="text-align: left">
                                <asp:Label ID="lblNetwt" runat="server" CssClass="label" Text="Net Wt"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textNetWt" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblTareWeight" runat="server" CssClass="label" Text="Tare Weight"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textTareWeight" runat="server" Width="110px" CssClass="textbox" ToolTip="tarewiight">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblGrossWt" runat="server" CssClass="label" Text="Gross Wt"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textGrossWt" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false"></asp:TextBox>
                            </td>
                           

                            <td style="text-align: left">
                                <asp:Label ID="labelExRate" runat="server" CssClass="label" Text="Ex Rate"></asp:Label>
                             </td>
                           

                            <td style="text-align: left">
                                <asp:TextBox ID="textExRate" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                             </td>
                           

                        </tr>
                        <tr>
                        <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblShipmentType" runat="server" CssClass="label" Text="Shipment Type"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textShipmentType" runat="server" Width="165px" CssClass="textbox"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblForValueInr" runat="server" CssClass="label" Text="Value In INR"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textForValueInr" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                             <td style="text-align: left">
                                <asp:Label ID="lblFobInUsd" runat="server" CssClass="label" Text="Fob In USD"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textFobInUsd" runat="server" Width="110px" CssClass="textbox" Enabled="false">
                                </asp:TextBox>
                            </td>
                            

                           

                            

                            <td style="text-align: left">
                                <asp:Label ID="lblCnfInUsd" runat="server" CssClass="label" Text="CNF In Usd"></asp:Label>
                            </td>
                            

                           

                            

                            <td style="text-align: left">
                                <asp:TextBox ID="textCnfInUsd" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false">
                                </asp:TextBox>
                            </td>
                            

                           

                            

                        </tr>
                        <tr>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblCountry" runat="server" CssClass="label" Text="Country"></asp:Label>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:TextBox ID="textCountry" runat="server" Width="165px" CssClass="textbox"
                                    Enabled="false"></asp:TextBox>
                            </td>
                             <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblRegion" runat="server" CssClass="label" Text="Region"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textRegion" runat="server" Width="110px" CssClass="textbox" ToolTip="Region">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblCfs" runat="server" CssClass="label" Text="CFS"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textCfs" runat="server" Width="110px" CssClass="textbox" ToolTip="CFS">
                                </asp:TextBox>
                            </td>
                            
                            <td style="text-align: left">
                                <asp:Label ID="lblUnits" runat="server" CssClass="label" Text="Units"></asp:Label>
                            </td>
                            
                            <td style="text-align: left">
                                <asp:TextBox ID="textUnits" runat="server" Width="110px" CssClass="textbox"
                                    Enabled="false"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                        <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblCha" runat="server" CssClass="label" Text="CHA"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textCha" runat="server" Width="110px" CssClass="textbox" ToolTip="CHA">
                                </asp:TextBox>
                            </td>
                            <td style="text-align: left; vertical-align: top;">
                                <asp:Label ID="lblAccont" runat="server" CssClass="label" Text="Pda Account"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="textAccont" runat="server" Width="165px" CssClass="textbox"
                                    ToolTip="Pda Account">
                                </asp:TextBox>
                            </td>

                            <td style="text-align: left; vertical-align: top;">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
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

