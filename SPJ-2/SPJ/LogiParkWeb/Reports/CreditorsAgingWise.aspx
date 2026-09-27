<%@ Page Title="eLOGiFreight::Creditors List Age Wise" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="CreditorsAgingWise.aspx.vb" Inherits="Reports_CreditorsAgingWise"
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Creditors List Age Wise" Width="300px"
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
                            <asp:Label ID="Label8" Width="150" runat="server" Text="Purchase Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstPurchaseType" Width="200px" AutoPostBack="true" runat="server" ToolTip="Purchase From"
                                CssClass="FormListBoxSmall">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                     <asp:ListItem Value="C" Text="Customer"></asp:ListItem>
                                        <asp:ListItem Value="V" Text="Vendor"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCustomerName" Width="250px" runat="server" ToolTip="Customer Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                           <td style="text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Company Name " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstCompanyName" Width="100px" runat="server" ToolTip="Company Name"
                                CssClass="FormListBoxSmall">
                            </asp:DropDownList>
                        </td>
                           
                          <td style="text-align: right">
                            <asp:Label ID="Label3" runat="server" Text="Report Type" CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="lstReportType" Width="70px" runat="server" ToolTip="Report Type"
                                CssClass="FormListBoxSmall">
                                <asp:ListItem Value="A" Text="--All--"></asp:ListItem>
                                   <asp:ListItem Value="S" Text="Summary"></asp:ListItem>
                                       <asp:ListItem Value="D" Text="Details"></asp:ListItem>
                            </asp:DropDownList>

                        </td>


                    </tr>
                    <tr>
                    
                          <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Status As On " CssClass="FormLabel"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:textbox ID="txtDueDate" Width="120px" runat="server" ToolTip="Due Date"
                                CssClass="FormListBoxSmall">
                            </asp:textbox>
                                <span class="mandatory">*</span>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server"
                                TargetControlID="txtDueDate" />
                        </td>

                       
                     
                         <td colspan="2" style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text="Age From Days" CssClass="FormLabel"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAgeingFrom" Width="50px"></asp:TextBox>
                              <asp:Label ID="Label5" runat="server" Text="Age To Days" CssClass="FormLabel"></asp:Label>
                                          <asp:TextBox runat="server" ID="txtAgeingTo" Width="50px"></asp:TextBox>
                        </td>
                         <td colspan="2" align="left">
                            <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="FormButton" />
                            <asp:Button ID="btnExcel" runat="server" Text="Excel" CssClass="FormButton" />
                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="FormButton" />
                            <asp:Button ID="btnExit" runat="server" PostBackUrl="~/Home.aspx" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width: 100%; overflow: auto;">
                    <table cellspacing="0" style="height:200px;" cellpadding="0" id="tblReport" runat="server">
                        <tr>
                            <td colspan="12">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:150px;">
                            <td colspan="12" style="height:150px;">
                                <div style="height:150px">
                                    <asp:GridView ID="gvInvoiceReport" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
                                        ShowFooter="True" runat="server">
                                        <FooterStyle CssClass="RepHead" />
                                        <HeaderStyle CssClass="RepHead" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Customer Name" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="CUSTOMER_NAME" ItemStyle-Width="250px"></asp:BoundField>
                                          <%--  <asp:BoundField HeaderText="Total" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="Total" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>--%>
                                              <asp:BoundField HeaderText="Within Credit Period" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="WITHIN_CREDIT" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                              <asp:BoundField HeaderText="OverDue Period" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="OVER_DUE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Age" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="Due Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="DUE_DATE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                        </Columns>
                                        <AlternatingRowStyle CssClass="FormListBoxLarg"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                     
                    </table>

                        <table cellspacing="0" style="vertical-align:top;" cellpadding="0" id="tblDetails" runat="server">
                        <tr>
                            <td colspan="12">
                                <asp:Label ID="Label6"  style="vertical-align:top;"  CssClass="FormLabel" runat="server" Font-Bold="true" Text="Details Report Date: "></asp:Label><asp:Label
                                    ID="Label7" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr  style="vertical-align:top;" >
                            <td colspan="12"  style="vertical-align:top;" >
                                <div style="overflow: auto;">
                                    <asp:GridView ID="gvDetails" RowStyle-CssClass="FormListBoxLarg" AutoGenerateColumns="False"
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
                                               </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:BoundField ItemStyle-Width="30px" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="" HeaderText="Sr." />
                                            <asp:BoundField HeaderText="Bill No" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BILL_NO" ItemStyle-Width="120px"></asp:BoundField>
                                        <asp:BoundField HeaderText="Bill Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BILL_DATE" ItemStyle-Width="120px"></asp:BoundField>
                                                   <asp:BoundField HeaderText="BL No." HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="BL_NO" ItemStyle-Width="120px"></asp:BoundField>
                                                     <asp:BoundField HeaderText="Invoice Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="INVOICE_AMOUNT" ItemStyle-Width="120px"></asp:BoundField>
                                                   <asp:BoundField HeaderText="Within Credit Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="WITHIN_CREDIT" ItemStyle-Width="120px"></asp:BoundField>
                                                                   <asp:BoundField HeaderText="Over Due Amount" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="OVER_DUE" ItemStyle-Width="120px"></asp:BoundField>

                                            <asp:BoundField HeaderText="Age" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="AGE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right"></asp:BoundField>
                                            <asp:BoundField HeaderText="Due Date" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="DUE_DATE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Right">
                                            </asp:BoundField>
                                               <asp:BoundField HeaderText="Type" HeaderStyle-CssClass="GVHeadText" ControlStyle-CssClass="FormLabel"
                                                DataField="TYPE" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="left"></asp:BoundField>
                                         
                                              <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="300px" HeaderStyle-CssClass="RepHead">
                                                <ItemStyle BackColor="white" Width="300px" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtComment" Width="300px" Text='<%# Eval("CREDIT_REMARK") %>' Enabled="false"
                                                        runat="server"></asp:TextBox>
                                                          <asp:HiddenField ID="hdnBillNo" runat="server" Value='<%# Eval("BILL_NO") %>' />
                                                           <asp:HiddenField ID="hdnType" runat="server" Value='<%# Eval("TYPE") %>' />
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
    </table>
</asp:Content>
