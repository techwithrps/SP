<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="GrReportDetails.aspx.vb" Inherits="Reports_Fleet_GrReportDetails" Title="eLOGiFleet:: GR Details Report"
    Theme="Forms" %>

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
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="GR Details Report"
                    CssClass="FormLabelTitle">
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
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr."
                                    Width="30px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDocType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Doc Type"
                                    Width="70px"></asp:Label>
                            </td>
                            <td style="width: 69px">
                                <asp:Label ID="lblJoNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No"
                                    Width="60px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gr No"
                                    Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGrDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gr Date"
                                    Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vehicle No" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPort" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Port"
                                    Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblLine" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Line"
                                    Width="200px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCont" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="130px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                    Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTareWt" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Tare Wt"
                                    Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblGrossWt" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Gross Wt."
                                    Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPayload" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Payload"
                                    Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPickUp" CssClass="FormLabel" runat="server" Font-Bold="True" Text="From Location"
                                    Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFromLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To Location" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblToLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDoValidity" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Required Date" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer" Width="180px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblCreatedBy" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Created By" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblCreatedOn" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Gr Date" Width="100px"></asp:Label>
                            </td>
                            <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="21">
                                <div style="height: 300px; overflow: auto;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="70px" DataField="TRIP_TYPE" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="CONT_JO_NO" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="GR_NO" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="GR_DATE" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" />
                                            <asp:BoundField ItemStyle-Width="70px" DataField="PORT" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="LINE" />
                                            <asp:BoundField ItemStyle-Width="130px" DataField="CONT_NO" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="TARE_WEIGHT" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="WEIGHT" />
                                            <asp:BoundField ItemStyle-Width="50px" DataField="CARGO_WEIGHT" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="MTY_PICKUP" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="FROM_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="TO_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="DO_VALIDITY" />
                                            <asp:BoundField ItemStyle-Width="180px" DataField="CUSTOMER" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_BY" />
                                            <asp:BoundField ItemStyle-Width="100px" DataField="CREATED_ON" />
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
