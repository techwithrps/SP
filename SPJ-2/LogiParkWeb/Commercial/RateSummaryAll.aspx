<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RateSummaryAll.aspx.vb" Inherits="Reports_Fleet_RateSummaryAll" Title="eLOGiFleet:: Rate Summary All"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
     <script type="text/javascript">
         var GridId = "<%=gvGRDetails.ClientID%>";
         var ScrollHeight = 300;
         window.onload = function () {
             var grid = document.getElementById(GridId);
             var gridWidth = grid.offsetWidth;
             var gridHeight = grid.offsetHeight;
             var headerCellWidths = new Array();
             for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
                 headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
             }
             grid.parentNode.appendChild(document.createElement("div"));
             var parentDiv = grid.parentNode;

             var table = document.createElement("table");
             for (i = 0; i < grid.attributes.length; i++) {
                 if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                     table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
                 }
             }
             table.style.cssText = grid.style.cssText;
             table.style.width = gridWidth + "px";
             table.appendChild(document.createElement("tbody"));
             table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
             var cells = table.getElementsByTagName("TH");

             var gridRow = grid.getElementsByTagName("TR")[0];
             for (var i = 0; i < cells.length; i++) {
                 var width;
                 if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                     width = headerCellWidths[i];
                 }
                 else {
                     width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
                 }
                 cells[i].style.width = parseInt(width - 3) + "px";
                 gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
             }
             parentDiv.removeChild(grid);

             var dummyHeader = document.createElement("div");
             dummyHeader.appendChild(table);
             parentDiv.appendChild(dummyHeader);
             var scrollableDiv = document.createElement("div");
             if (parseInt(gridHeight) > ScrollHeight) {
                 gridWidth = parseInt(gridWidth) + 17;
             }
             scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
             scrollableDiv.appendChild(grid);
             parentDiv.appendChild(scrollableDiv);
         }
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
                <asp:Label ID="lblScreenTitle" runat="server" Width="400px" Text="Rate Summary Report - All" CssClass="FormLabelTitle">
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
                        <tr>
                            <td>
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvGRDetails" ShowHeader="true" AlternatingRowStyle-CssClass="FormListBoxLarg"
                                        RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-Width="30px" HeaderText ="Sr." HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField ItemStyle-Width="350px" HeaderStyle-Width="350px" DataField="SERVICE_NAME"  HeaderText ="Service"  HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="100px" HeaderStyle-Width="350px" DataField="CUSTOMER_NAME"  HeaderText ="Customer"  HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="250px" HeaderStyle-Width="250px" DataField="LINE"  HeaderText ="Shipping Line"  HeaderStyle-CssClass="RepheaderNew"/>
                                            <asp:BoundField ItemStyle-Width="60px" HeaderStyle-Width="100px" DataField="RATE"  HeaderText ="Rate"  HeaderStyle-CssClass="RepheaderNew"/>
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
