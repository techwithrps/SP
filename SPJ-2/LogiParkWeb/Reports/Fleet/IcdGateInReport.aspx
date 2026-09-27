<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="IcdGateInReport.aspx.vb" Inherits="Reports_Fleet_IcdGateInReport"
    Title="eLOGiFleet:: Factory Gate In Report" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function DisplayValidation() {
            var result = false;
            if (validateData(document.getElementById('<%=textFromDate.clientId %>'),
            document.getElementById('<%=lblFromDate.clientId %>').innerHTML))
                if (validateData(document.getElementById('<%=textToDate.clientId %>'),
            document.getElementById('<%=lblToDate.clientId %>').innerHTML))
                    result = true;
                else
                    result = false;
            else
                result = false;
            return result;
        }
        function checktodate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that the To Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
        function checkfromdate(dodate) {
            var startDate = dodate.getAttribute('value');
            var currentTime = new Date()
            var month = currentTime.getMonth() + 1
            var day = currentTime.getDate()
            var year = currentTime.getFullYear()
            endDate = (day + "/" + month + "/" + year)
            startDate = Date.parse(startDate);
            endDate = Date.parse(endDate);

            if (startDate > endDate) {
                alert("Please ensure that From Date is less than or equal to the Current Date.");
                dodate.value = '';
                dodate.style.border = '1px solid red';
                dodate.focus();
                return false;
            }
            dodate.style.border = '1px solid #B3CBFF';
        }
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 300px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Icd Gate In Report"
                    CssClass="FormLabelTitle"> </asp:Label>
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
            <td align="left" valign="top">
                <table>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: right">
                            </td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel Download" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 300px; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew" style="height: 40px;">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr"
                                    Width="40px"></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label ID="lblCont" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size/Type"
                                    Width="100px"></asp:Label>
                            </td>
                          
                            <td>
                                <asp:Label ID="lblBookingNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Booking no"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Lblbookingdate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking Date" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblShipper" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Shipper Name" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblLine" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Line" Width="130px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblTransporter" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Transporter" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFromLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To Location" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFactoryLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Factory Location" Width="100px"></asp:Label>
                            </td>
                            
                            <td>
                                <asp:Label ID="lblHandover" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPol" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Pol" Width="130px"></asp:Label>
                            </td>
                           
                            <td>
                                <asp:Label ID="lblPod" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Pod"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVesselName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vessel Name" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEtddate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Etd date"
                                    Width="100px"></asp:Label>
                            </td>
                            
                          <td>
                                <asp:Label ID="lblGrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="GR No"
                                    Width="100px"></asp:Label>
                            </td>
                              <td>
                                <asp:Label ID="lblVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vehicle No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAllotmentdate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Allotment date"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIcdOut" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Icd Out "
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFactoryin" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory in Date"
                                    Width="100px"></asp:Label>
                            </td>
                           
                             <td>
                                <asp:Label ID="lblFactoryOut" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Factory Out Date"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBufferIndate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Buffer in Date "
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIcdGateInDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Icd Gate In Date"
                                    Width="100px"></asp:Label>
                            </td>
                             
                            
                        </tr>
                        <tr>
                            <td colspan="23">
                                <div style="height: 400px;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Sr No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont No." />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_SIZE" HeaderText="Size" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_DATE" HeaderText="Booking Date" />
                                             <asp:BoundField ItemStyle-Width="130px" DataField="EXPORTER" HeaderText="Exporter" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="LINE" HeaderText="LINE" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="VENDOR_NAME" HeaderText="Vendor Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="To Location" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_LOCATION" HeaderText="Factory Location" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CFS" HeaderText="Handover" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="POL" HeaderText="POL" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POD" HeaderText="POD" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ETD_DATE" HeaderText="Etd date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GR_NO" HeaderText="GR No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="VEHICLE_NO" HeaderText="Vehicle No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ALLOTMENT_DATE" HeaderText="Allotment Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GATE_OUT_DATE" HeaderText="ICD Out" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_IN" HeaderText="Factory In" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_OUT" HeaderText="Factory Out" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="BUFFER_DATE" HeaderText="Buffer In Date" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="ICD_IN_DATE" HeaderText="ICD In Date" />
                                        </Columns>
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
