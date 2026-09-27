<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DailyBookingDetails.aspx.vb" Inherits="Reports_Fleet_DailyBookingDetails"
    Title="eLOGiFleet:: Daily Booking Report" Theme="Forms" %>

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
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Daily Booking Report"
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
                            <asp:Label ID="lblTerminal" runat="server" Text="Terminal" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstTerminal" runat="server" ToolTip="Terminal" CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomer" runat="server" Text="Customer" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomer" runat="server" ToolTip="Customer" CssClass="ddlMedium">
                            </asp:DropDownList>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                        </td>
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
                                <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Doc Type"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMode" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Mode Type"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCont" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                    Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Type"
                                    Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblJoNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No"
                                    Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPickUp" CssClass="FormLabel" runat="server" Font-Bold="True" Text="From Location"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFromLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To Location" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblToLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover Location" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblConsignee" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Consignee Name" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Consignor Name" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTransporter" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Transporter" Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBeNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Booking No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBookingDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Booking Date" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSealNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Seal No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBe" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Set Temp."
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
                                <asp:Label ID="lblShiper" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gate Out Date"
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
                                <asp:Label ID="lblBufferOutDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Buffer Out Date"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblIcdInDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD In Date"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblCreatedBy" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Created By" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblCreatedOn" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Created On" Width="100px"></asp:Label>
                            </td>
                            <%-- <td style="background-color: White; width: 15px;">
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="33">
                                <div style="height: 400px;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Sr No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRIP_TYPE" HeaderText="Doc Type" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="MODE_TYPE" HeaderText="Mode Type" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont No." />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" HeaderText="Size" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_TYPE" HeaderText="Type" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_JO_NO" HeaderText="Jo No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="MTY_PICKUP" HeaderText="From Location" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FROM_LOCATION" HeaderText="To Location" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TO_LOCATION" HeaderText="Handover Location" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CONS" HeaderText="Consignee Name" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="LINE" HeaderText="LINE" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CUSTOMER" HeaderText="Consignor Name" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="VENDOR_NAME" HeaderText="Transporter" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="POD" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="STUFF_DATE" HeaderText="Booking Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SEAL_NO" HeaderText="Seal No" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="BE_NO" HeaderText="Set Temp." />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="GR_NO" HeaderText="GR No" />
                                            <asp:BoundField ItemStyle-Width="120px" DataField="VEHICLE_NO" HeaderText="Vehicle No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD_OUT_DATE" HeaderText="ICD Out Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_IN_DATE" HeaderText="Factory In Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FACTORY_OUT_DATE" HeaderText="Factory Out Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BUFFER_DATE" HeaderText="Buffer In Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BUFFER_OUT_DATE" HeaderText="Buffer Out Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD_IN_DATE" HeaderText="ICD In Date" />
                                            <%--      <asp:BoundField ItemStyle-Width="100px" DataField="LINE_HANDOVER_DATE" HeaderText="LIne Handover Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CUSTOMS_HANDOVER_DATE" HeaderText="Custom Handover Date" />
                                            --%>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" HeaderText="Created By" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_ON" HeaderText="Created On" />
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
