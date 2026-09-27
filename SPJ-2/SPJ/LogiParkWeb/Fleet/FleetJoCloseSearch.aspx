<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FleetJoCloseSearch.aspx.vb" Inherits="Fleet_FleetJoCloseSearch" Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script language="javascript" type="text/javascript">

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
                <asp:Label ID="lblScreenTitle" runat="server" Text="JOB ORDER SEARCH" CssClass="FormLabelTitle">
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
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
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
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textToDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblVehicleNo" runat="server" Text="Vehicle No" CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textVehicleNo" runat="server" ToolTip="Vehicle No" Width="100px"
                                CssClass="textbox" MaxLength="15">
                            </asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnDisplay" runat="server" ImageUrl="~/Images/btnDisplay.png" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="~/Images/btnExcelDownload.png" />
                            <asp:ImageButton ID="Button1" runat="server" PostBackUrl="~/Home.aspx" ImageUrl="~/Images/btnExit.png" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 420px; width: 100%; overflow: auto;">
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="RepHeadFleet">
                            <td>
                                <asp:Label ID="lblrSrNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr"
                                    Width="31px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrVehicleNo" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Vehicle No" Width="90px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblVehicleType" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Type" Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblJoNO" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo No"
                                    Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrJoDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblJoClosing" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Closing Date" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblJoType" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Jo Type"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LblWorkshop" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="WrokShop" Width="110px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvJODetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="31px"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="90px" DataField="VEHICLE_NO"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="40px" DataField="VH_TYPE"></asp:BoundField>
                                            <asp:HyperLinkField DataTextField="JO_NO" DataNavigateUrlFormatString="FleetMaintJOClose.aspx?JoId={0}"
                                                ItemStyle-Width="50px" DataNavigateUrlFields="JO_ID"></asp:HyperLinkField>
                                            <asp:BoundField ItemStyle-Width="110px" DataField="JO_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="CLOSE_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="JO_TYPE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="WORKSHOP" />
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
