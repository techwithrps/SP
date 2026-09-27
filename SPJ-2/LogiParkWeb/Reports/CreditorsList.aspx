<%@ Page Title="eLOGiFreight:: Creditors List" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CreditorsList.aspx.vb" Inherits="Reports_CreditorsList"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var GridId = "<%=gvInvoiceReport.ClientID %>";
        var ScrollHeight = 400;
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
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="Creditors Details" Width="300px"
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
                        <%-- <td style="text-align: right">
                            <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textFromDate" runat="server" ToolTip="From Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textFromDate" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="textToDate" runat="server" ToolTip="To Date" CssClass="FormTextBoxDate">
                            </asp:TextBox>
                            <span class="mandatory" style="vertical-align: top;">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="textToDate" />
                        </td>--%>
                        <%--<td style="text-align: right">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>--%>
                        <td>
                            <%-- <asp:Button ID="btnDisplay" runat="server" Text="Outstanding Summary" CssClass="FormButton" />--%>
                            <%--<asp:Button ID="BtnAgeing" runat="server" Text="Ageing Report" CssClass="FormButton" />
                            <asp:Button ID="btnAll" runat="server" Text="All" CssClass="FormButton" />--%>
                            <asp:Button ID="BtnLine" runat="server" Text="Line" CssClass="FormButton" 
                                style="width: 38px" />
                            <asp:Button ID="BtnVendor" runat="server" Text="Rail" CssClass="FormButton" />
                             <asp:Button ID="BtnTrucker" runat="server" Text="Trucker" CssClass="FormButton" />
                             <asp:Button ID="BtnMaintenance" runat="server" Text="Maintenance" CssClass="FormButton" />
                             <asp:Button ID="btnCHA" runat="server" Text="CHA" CssClass="FormButton" />
                            <asp:Button ID="BtnAll" runat="server" Text="All" CssClass="FormButton" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                            <%--<asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />--%>
                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                            <asp:HiddenField ID="hdnButtonType" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 100%; overflow: auto;">
                    <table cellspacing="0" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        ShowFooter="True" runat="server">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="30px" HeaderStyle-CssClass="RepHead">
                                                <ItemStyle Font-Bold="true" Width="30px" CssClass="RepHead" />
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" Width="30px" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" Width="30px" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                    <asp:HiddenField ID="hdnCustomerId" runat="server" Value='<%# Eval("CUSTOMER_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Customer Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="250px"></asp:BoundField>
                                            <asp:BoundField HeaderText="JSB CARGO" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CARGO" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="JSB CONSULTANT" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CON" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="JSB MUMBAI" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="MUM" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Other" HeaderStyle-Width="100px" HeaderStyle-CssClass="RepHead">
                                                <ItemStyle BackColor="white" Width="100px" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtOther" Width="100px" Text='<%# Eval("OTHER") %>' Enabled="false"
                                                        onkeypress="kp_numeric();" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="TOTAL" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TOTAL" ItemStyle-Width="70px" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                             <asp:BoundField HeaderText="Over Due" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="OVER_DUE" ItemStyle-Width="70px" ItemStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="300px" HeaderStyle-CssClass="RepHead">
                                                <ItemStyle BackColor="white" Width="300px" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtComment" Width="300px" Text='<%# Eval("COMMENTT") %>' Enabled="false"
                                                        runat="server"></asp:TextBox>
                                                         <asp:HiddenField ID="hdnCustType" runat="server" Value='<%# Eval("CUSTOMER_TYPE") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <%--<tr>
            <td align="left" valign="top">
                <div style="width: 100%; overflow: auto;">
                    <table cellspacing="0" cellpadding="0" id="tblreport1" runat="server">
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblReport1" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate1" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <div style="overflow: auto;">
                                    <asp:GridView ID="GvAgeingWiseReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        ShowFooter="True" runat="server">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Customer Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="250px"></asp:BoundField>
                                            <asp:BoundField HeaderText="0-30" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE0T30" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="31-60" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE31T60" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="61-90" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE61TO90" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="91-120" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE91T120" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="121-150" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE121TO150" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="151-180" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE151T180" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText=">180" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGEABOVE180" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Unadjusted Amount" HeaderStyle-CssClass="GVHeadText"
                                                ControlStyle-CssClass="FormLabel" DataField="UN_ADJ" ItemStyle-Width="110px"
                                                ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="Total" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TOTAL" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>--%>
    </table>
</asp:Content>
