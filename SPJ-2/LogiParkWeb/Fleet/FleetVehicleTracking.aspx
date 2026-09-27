<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FleetVehicleTracking.aspx.vb" Inherits="Fleet_FleetVehicleTracking" Title="eLOGiFleet:: Vehicle Tracking"
    Theme="Forms" %>

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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Vehicle Tracking Report" Width="400px" CssClass="FormLabelTitle">
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
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" AutoComplete="off" CssClass="textbox"
                                Width="90px" onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="label"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" AutoComplete="off" Width="90px" CssClass="textbox"
                                onkeypress="kp_date();" MaxLength="10">
                            </asp:TextBox>
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
                    <table cellspacing="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="12">
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
                                <asp:Label ID="lblrSize" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Size"
                                    Width="40px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrGRNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="GR No"
                                    Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrGrDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="GR Date"
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Cont No."
                                    Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblContSize" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Cont Size" Width="60px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFromLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="From Location" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblToLocation" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="To Location" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblHandover" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Handover" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCustomer" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Customer" Width="200px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblICDoutDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="ICD Out Date" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblFactoryInDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Factory In Date" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblFactoryoutDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Factory Out Date" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblBufferInDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Buffer In Date" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblBufferoutDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Buffer Out Date" Width="110px"></asp:Label>
                            </td>
                             <td>
                                <asp:Label ID="lblICDInDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="ICD In Date" Width="110px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCloseDate" CssClass="FormLabel" runat="server" Font-Bold="True"
                                    Text="Trip Close Date" Width="150px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="20">
                                <div style="height: 310px; overflow: auto;">
                                    <asp:GridView ID="gvJODetails" ShowHeader="false" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="31px"></asp:BoundField>
                                            <asp:HyperLinkField DataTextField="VEHICLE_NO" DataNavigateUrlFormatString="GRMapping.aspx?GRID={0}&CONTJOID={1}"
                                                ItemStyle-Width="90px" DataNavigateUrlFields="GR_ID,CONT_JO_ID"></asp:HyperLinkField>
                                            <asp:BoundField ItemStyle-Width="40px" DataField="VH_TYPE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="40px" DataField="VH_SIZE"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="50px" DataField="GR_NO" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="GR_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="CONT_NO" />
                                            <asp:BoundField ItemStyle-Width="60px" DataField="CONT_SIZE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="FROM_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="TO_LOCATION" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="HANDOVER" />
                                            <asp:BoundField ItemStyle-Width="200px" DataField="CUSTOMER" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="ICD_OUT_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_IN_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="FACTORY_OUT_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="BUFFER_IN_DATE" />
                                            <asp:BoundField ItemStyle-Width="110px" DataField="BUFFER_OUT_DATE" />
                                               <asp:BoundField ItemStyle-Width="110px" DataField="ICD_IN_DATE" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="CLOSE_DATE" />
                                            <asp:TemplateField ItemStyle-Width="0px">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnInvoiceRefNo" runat="server" Value='<%# Eval("VEHICLE_NO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
