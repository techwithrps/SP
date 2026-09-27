<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="DSRReport.aspx.vb" Inherits="Reports_Fleet_DSRReport"
    Title="eLOGiFleet:: DSR Report" Theme="Forms" %>

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
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="DSR Report"
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
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" Width="90px" AutoComplete="off" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" Width="90px" AutoComplete="off" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                       <td style="text-align: left">
                            <asp:Label ID="Label3" runat="server" CssClass="FormLabel" Text="Customer"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <div style="height: 100px; overflow: auto; width: 100%; position:relative" class="FormLabel">
                            <span class="multi-check"><asp:CheckBox ID="chkAll" Text="Select All"  runat="server" OnCheckedChanged = "Check_UnCheckAll" AutoPostBack = "true" /></span>
                            <asp:CheckBoxList ID="lstCustomer" runat="server" ToolTip="Customer" Width="250px" style="border: 1px solid #CCC;"></asp:CheckBoxList>
                            </div>
                        </td>
                          <td>
                            <asp:Label ID="Label1" runat="server" CssClass="FormLabel" Text="Terminal Name"></asp:Label>
                        </td>
                        <td>
                            <div style="height: 100px; overflow: auto; width: 100%; position:relative" class="FormLabel">
                            <span class="multi-check"><asp:CheckBox ID="chkAllNew" Text="Select All"  runat="server" OnCheckedChanged = "Check_UnCheckAllTerMinal" AutoPostBack = "true" /></span>
                             <asp:CheckBoxList ID="lstTerminalName" runat="server" ToolTip="TerminalName" Width="150px" style="border: 1px solid #CCC;"></asp:CheckBoxList>
                         
                                </div>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblLine" runat="server" Text="Line" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstLine" runat="server" Width="250px" ToolTip="Customer" CssClass="ddlMedium">
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">&nbsp;</td>
                        <td style="text-align: left">&nbsp;</td>
                        <td style="text-align: right"></td>
                        <td style="text-align: left">&nbsp;</td>
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
                            <td colspan="34">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                       <%-- <tr class="RepheaderNew" style="height: 40px;">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr"
                                    Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblEGateOut" CssClass="FormLabel" runat="server" Font-Bold="True" Text="E Gate Out"
                                    Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblSline" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sline"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBookingNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Booking no"
                                    Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblCont" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="100px" Height="19px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblsize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont Size"
                                    Width="100px" Height="19px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont Type"
                                    Width="100px" Height="19px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Doc Type"
                                    Width="100px" Height="19px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="LblShipper" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Shipper Name" Width="130px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblLGateIn" CssClass="FormLabel" runat="server" Font-Bold="True" Text="L Gate In"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBLno" CssClass="FormLabel" runat="server" Font-Bold="True" Text="BL No"
                                    Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblSbill" CssClass="FormLabel" runat="server" Font-Bold="True" Text="S Bill"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSbillDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="S Bill Date" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbldestination" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Destination" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblHoDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="H O Date"
                                    Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblIcdPlace" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ICD Place"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblpol" CssClass="FormLabel" runat="server" Font-Bold="True" Text="POL"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRailout" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Railout"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTrainNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Train No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblwagonNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Wagon No"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblAtPort" CssClass="FormLabel" runat="server" Font-Bold="True" Text="At Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbl1stPlanUSL" CssClass="FormLabel" runat="server" Font-Bold="True" Text="1stPlanUSL"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblETD" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ETD"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFinalVessel" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Final Vessel"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblETD1" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ETD"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblstayatport" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Stay At Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTsPort" CssClass="FormLabel" runat="server" Font-Bold="True" Text="T S Port"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblETA" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ETA T S"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTSVessel" CssClass="FormLabel" runat="server" Font-Bold="True" Text="T S Vessel"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblETDTS" CssClass="FormLabel" runat="server" Font-Bold="True" Text="ETD T S"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblstayattp" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Stay At T P"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFinaleta" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Final ETA"
                                    Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblstatus" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Status"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGateout" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gate Out"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblemptygatein" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Empty Gate IN"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblfollowup" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Follow Up"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTransittime" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Transit Time"
                                    Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRemark" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Remarks"
                                    Width="100px"></asp:Label>
                            </td>



                        </tr>--%>
                        <tr>
                            <td  colspan="38">
                                <div style="height: 520px;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="true"  AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="40px" HeaderText="Sr No."></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD_OUT_DATE" HeaderText="E Gate Out" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE" HeaderText="S Line" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BOOKING_NO" HeaderText="Booking No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_NO" HeaderText="Cont No." />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CONT_SIZE" HeaderText="Cont Size" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRIP_TYPE" HeaderText="Cont Tytpe" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CUSTOMER" HeaderText="Shipper No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="ICD_IN_DATE" HeaderText="L Gate Date" />
                                             <asp:BoundField ItemStyle-Width="100px" DataField="EMPTYGATE_IN_DATE" HeaderText="Empty Gate Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PARTY_INV_NO" HeaderText="Invoice No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="BL_NO" HeaderText="BL No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SB_NO" HeaderText="S Bill" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SB_DATE" HeaderText="S Bill Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="PORT" HeaderText="Destination" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="LINE_HANDOVER_DATE" HeaderText="H O Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CFS" HeaderText="ICD Place" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="POL" HeaderText="POL" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_NO" HeaderText="Train No" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRAIN_OUT_DATE" HeaderText="Railout" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="PORT_ARRIVAL" HeaderText="At port" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CURRENT_VESSEL" HeaderText="Plan Vessel" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="REQUIRED_ETD" HeaderText="Plan ETD" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FINAL_VESSEL" HeaderText="Final Vessel" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="FINAL_ETD" HeaderText="Final ETD" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="TRANSIT_TIME" HeaderText="Stay At Port" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="TRANSHIPMENT_PORT" HeaderText="T S Port" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSHIPMENT_ETA" HeaderText="ETA T S" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSHIPMENT_VESSEL" HeaderText="T S Vessel" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSHIPMENT_ETD" HeaderText="Etd T S" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TSP" HeaderText="Stay at T P" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CURRENT_ETA" HeaderText="Final ETA" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="STATUS" HeaderText="Status" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="DISCHARGE_DATE" HeaderText="Discharge date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="GATE_OUT_DATE" HeaderText="Gate Out Date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="EMPTY_GATE_IN_DATE" HeaderText="Empty Gate In date" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="TRANSIT_TIME_FINAL" HeaderText="Transit Time" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="SOB_REMARK" HeaderText="Remarks" />
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
