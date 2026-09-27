<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MisTPT.aspx.vb" MasterPageFile="~/MasterPage.master"
    Inherits="Reports_Fleet_MisTPT" Title="eLOGiFleet :: Transport MIS" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    
    <script language="javascript" type="text/javascript">

    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Transport MIS" Width="400px" CssClass="FormLabelTitle">
                </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="3">
                <hr />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">
                            <asp:TextBox ID="textFromDate0" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="30px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="textFromDate0_CalendarExtender" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate0" />
                            *</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">
                            <asp:TextBox ID="textFromDate1" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="30px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="textFromDate1_CalendarExtender" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate1" />
                            *</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="ALL" CssClass="FormButton" />
                              <asp:Button ID="btnFuelExp" runat="server" Text="Fuel Exp" CssClass="FormButton" />
                            <asp:Button ID="btnMaintenance" runat="server" Text="Maintenance" CssClass="FormButton" />
                              <asp:Button ID="btnSalary" runat="server" Text="Salary" CssClass="FormButton" />
                                 <asp:Button ID="btnFooding" runat="server" Text="Fooding" CssClass="FormButton" />
                                      <asp:Button ID="btnTolls" runat="server" Text="Tolls" CssClass="FormButton" />
                                      <asp:Button ID="btnMisc" runat="server" Text="Misc" CssClass="FormButton" />
                                            <asp:Button ID="btnAccident" runat="server" Text="Accident" CssClass="FormButton" />
                            <asp:HiddenField ID="hdnServiceType" runat="server" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="21">
                                <div style="height: 350px; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                        <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="GR_NO" HeaderText="GR NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" HeaderText="VEHICLE NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="EQUIPMENT_TYPE" HeaderText="EQUIPMENT TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CONT_NO" HeaderText="CONT NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER" HeaderText="CUSTOMER"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="FROM LOCATION"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TOLOCATION" HeaderText="TO LOCATION"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="HANDOVER"  HeaderText="HANDOVER"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DOC_TYPE" HeaderText="DOC TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GATE_OUT_DATE" HeaderText="GATE OUT DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CASH" ItemStyle-HorizontalAlign="center" HeaderText="CASH">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="OIL" ItemStyle-HorizontalAlign="center" HeaderText="OIL">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MAINTAINANCE" ItemStyle-HorizontalAlign="center" HeaderText="MAINTAINANCE">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="MAINTAINANCEREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="MAINTAINANCE REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ACCIDENT" ItemStyle-HorizontalAlign="center" HeaderText="ACCIDENT">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="ACCIDENTREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="ACCIDENT REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FOODING" ItemStyle-HorizontalAlign="center" HeaderText="FOODING">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="FOODINGREMARKS" ItemStyle-HorizontalAlign="center"  HeaderText="FOODING REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SHORT_ADVANCE" ItemStyle-HorizontalAlign="center" HeaderText="SHORT ADVANCE">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="SHORTREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="SHORT REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CASH_BACK" ItemStyle-HorizontalAlign="center" HeaderText="CASH BACK">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="CASHBACKREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="CASHBACK REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRIP_EXP" ItemStyle-HorizontalAlign="center" HeaderText="TRIP EXP">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="TRIPREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="TRIP REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARKING_EXP" ItemStyle-HorizontalAlign="center" HeaderText="PARKING EXP">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="PARKINGREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="PARKING REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SALARY_ADVANCE" ItemStyle-HorizontalAlign="center" HeaderText="SALARY ADVANCE">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="SALARYADVANCEREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="SALARY ADVANCE REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="110px" DataField="SHIFTING_CHARGES" ItemStyle-HorizontalAlign="center" HeaderText="SHIFTING CHARGES">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="SHIFTINGCHARGEREMARKS" ItemStyle-HorizontalAlign="center"  HeaderText="SHIFTING CHARGE REMARKS">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MISC_EXP" ItemStyle-HorizontalAlign="center" HeaderText="MISC EXP">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="260px" DataField="MISCREMARKS" ItemStyle-HorizontalAlign="center" HeaderText="MISC REMARKS">
                                            </asp:BoundField>
                                                          <asp:BoundField ItemStyle-Width="260px" DataField="INVOICE_AMT" ItemStyle-HorizontalAlign="Right" HeaderText="Sales Tpt Invoice Amt">
                                            </asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TOTAL" ItemStyle-HorizontalAlign="center" HeaderText="TOTAL">
                                            </asp:BoundField>
                                       
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>

                                    <asp:GridView ID="gvMISService"  ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                        <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="GR_NO" HeaderText="GR NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" HeaderText="VEHICLE NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="60px" DataField="EQUIPMENT_TYPE" HeaderText="EQUIPMENT TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CONT_NO" HeaderText="CONT NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER" HeaderText="CUSTOMER"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="FROM LOCATION"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TOLOCATION" HeaderText="TO LOCATION"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="HANDOVER"  HeaderText="HANDOVER"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="DOC_TYPE" HeaderText="DOC TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GATE_OUT_DATE" HeaderText="GATE OUT DATE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CASH" ItemStyle-HorizontalAlign="center" HeaderText="CASH">
                                            </asp:BoundField>
                                               <asp:BoundField ItemStyle-Width="70px" DataField="AMOUNT" ItemStyle-HorizontalAlign="Right" HeaderText="Amount"></asp:BoundField>
                                          <asp:BoundField ItemStyle-Width="200px" DataField="REMARKS" ItemStyle-HorizontalAlign="left" HeaderText="Remarks"></asp:BoundField>
                                           
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>



                                </div>
                             
                                <asp:Label ID="Label2" runat="server" Width="1500px" CssClass="FormLabel "></asp:Label>
                                 <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="60px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                                     <asp:Label ID="Label1" runat="server" Width="10px" CssClass="FormLabel "></asp:Label>
                                     <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>

                                        <div>
                                
                                    <asp:GridView ID="gvActivity" ShowHeader="true" ShowFooter="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False" runat="server" FooterStyle-CssClass="RepheaderNew" HeaderStyle-CssClass="RepheaderNew">
                                        <RowStyle CssClass="FormListBoxLarg"></RowStyle>
                                        <Columns>
                                        <asp:BoundField ItemStyle-Width="25px" DataField="" HeaderText="Sr No"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="200px" DataField="ACTIVITY_NAME" HeaderText="Activity Name"></asp:BoundField>
                                                <asp:BoundField ItemStyle-Width="150px" DataField="ACTIVITY_DATE" HeaderText="Activity Date"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="AMOUNT" ItemStyle-HorizontalAlign="Right" HeaderText="Amount"></asp:BoundField>
                                            
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    
</asp:Content>
