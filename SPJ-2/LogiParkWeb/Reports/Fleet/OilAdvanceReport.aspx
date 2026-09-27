<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="OilAdvanceReport.aspx.vb" Inherits="Reports_Fleet_OilAdvanceReport"
    Title="eLOGiPark:: Oil Advance Report" Theme="Forms" %>

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
            <td valign="top" >
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Export Power On Off Report" CssClass="FormLabelTitle">
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
                            <asp:Label ID="Label1" runat="server" Text="Oil -Vendor" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstVendor" runat="server" ToolTip="To Date" CssClass="ddlMedium">
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
                        <tr>
                            <td colspan="7">
                                <asp:Label ID="lblDate" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Jo Details Report"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepheaderNew">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr"
                                    Width="31px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrSlipNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Oil"
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vehicle No" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrDriverName" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Driver Name" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount"
                                    Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblVendor" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Vendor"
                                    Width="200px"></asp:Label>
                            </td>
                             <td style="background-color: White; width: 15px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvOilAdvance" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ADVANCE" />
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="DRIVER_NAME" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="OIL_ADVANCE" ItemStyle-HorizontalAlign="Right" />
                                             <asp:BoundField ItemStyle-Width="200px" DataField="VENDOR" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblSpace" runat="server" Width="350px" CssClass="FormLabel "></asp:Label>
                                 <asp:Label ID="lblTotal1" runat="server" Text="Total" Width="50px" CssClass="FormLabel" Font-Bold="true"></asp:Label>
                                     <asp:Label ID="Label2" runat="server" Width="40px" CssClass="FormLabel "></asp:Label>
                                     <asp:Label ID="TextTotal" runat="server" CssClass="FormLabel "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
