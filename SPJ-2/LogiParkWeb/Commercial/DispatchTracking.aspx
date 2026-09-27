<%@ Page Title="eLOGiFleet :: Vessel Planing Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="DispatchTracking.aspx.vb" Inherits="Commercial_DispatchTracking"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script src="../../Script/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Script/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../../Script/calendar-en.min.js" type="text/javascript"></script>
    <link href="../../css/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
            function DataSelect(ctrl) {
            if (ctrl.value !== '' && ctrl.value.length < 11) {
                const now = new Date();
                ctrl.value = ctrl.value + " " + now.format("HH:mm");
            }
        }
    </script>
    <script type="text/javascript">
        var GridId = "<%=gvtripPendencyList.ClientID %>";
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
                <asp:Label ID="lblScreenTitle" runat="server" Text="Dispatch Tracking" CssClass="FormLabelTitle"
                    Width="300px"> </asp:Label>
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
            <td>
                <table>
                    <tr>
                         <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Visible="false" />
                            <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />
                            <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="height: 100%; width: 100%; overflow: auto;">
                    <table cellspacing="1" id="tblReport" runat="server">
                        <tr>
                            <td colspan="8">
                                <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                    ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <div style="height: 100%; overflow: auto;">
                                    <asp:GridView ID="gvtripPendencyList" Font-Size="8pt" AutoGenerateColumns="False"
                                        runat="server">
                                        <RowStyle CssClass="FormLabel" BackColor="AntiqueWhite"></RowStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckedChanged" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="" HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew" />
                                                <asp:BoundField DataField="JOB_NO" HeaderText=" EDI Job No" ItemStyle-Width="120px" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            
                                               <asp:BoundField DataField="INVOICE_NO" ItemStyle-Width="120px" HeaderText="Invoice No"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                            <asp:BoundField DataField="INVOICE_DATE" ItemStyle-Width="120px" HeaderText="Invoice Date"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                              <asp:BoundField DataField="EINVOICE_DATE" ItemStyle-Width="120px" HeaderText="E-Invoice Date"
                                                HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                             <asp:TemplateField HeaderText="File send for Billing" HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                       <asp:HiddenField ID="hdnJobNo" runat="server" Value='<%# Eval("JOB_NO") %>' />
                                                    <asp:Label ID="lblFileSendBilling" Width="150px" runat="server"  Text='<%# Eval("SENDING_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="TextFileSendBilling"  Width="150px" runat="server"  Text='<%# Eval("SENDING_DATE") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="File send for Billing" onchange="DataSelect(this);">
                                                         </asp:TextBox>
                                                         <ajaxToolkit:CalendarExtender ID="clFileSendBilling" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="TextFileSendBilling" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="File received from Dispatch" ItemStyle-Width="200px"  HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFilereceived" runat="server"  Text='<%# Eval("FILE_REC_DISPATCH")%>'></asp:Label>
                                                    <asp:TextBox ID="textFilereceived" runat="server"  Text='<%# Eval("FILE_REC_DISPATCH") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="File received from Dispatch" onchange="DataSelect(this);">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="cltFilereceived" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="textFilereceived" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="File Send For Dispatch" ItemStyle-Width="200px"  HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSendingDispatch" runat="server"  Text='<%# Eval("SENDING_DISPATCH")%>'></asp:Label>
                                                    <asp:TextBox ID="textSendingDispatch" runat="server"  Text='<%# Eval("SENDING_DISPATCH") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="File Send For Dispatch" onchange="DataSelect(this);">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="cltSendingDispatch" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="textSendingDispatch" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="File received after bill finalized" ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFileRecDate" runat="server"  Text='<%# Eval("FILE_REC_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="textFileRecDate" runat="server" Text='<%# Eval("FILE_REC_DATE") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="File received after bill finalized" onchange="DataSelect(this);">
                                                    </asp:TextBox>
                                                     <ajaxToolkit:CalendarExtender ID="cltFileRecDate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="textFileRecDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Soft Copy Send to customer"  ItemStyle-Width="200px" HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSoftCopyDate" runat="server"  Text='<%# Eval("SOFT_COPY_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="textSoftCopyDate" runat="server"   Width="200px" Text='<%# Eval("SOFT_COPY_DATE") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="Soft Copy Date" onchange="DataSelect(this);">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="cltSoftCopyDate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="textSoftCopyDate" />
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Hard Copy Send to customer"  ItemStyle-Width="200px"  HeaderStyle-CssClass="RepheaderNew" >
                                                     <ItemStyle BackColor="LightGreen" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHardCopyDate" runat="server"  Text='<%# Eval("HARD_COPY_DATE")%>'></asp:Label>
                                                    <asp:TextBox ID="textHardCopyDate" runat="server"  Text='<%# Eval("HARD_COPY_DATE") %>' CssClass="textbox"
                                                        Visible="False" ToolTip="Hard Copy Send date and Time" onchange="DataSelect(this);">
                                                    </asp:TextBox>
                                             <ajaxToolkit:CalendarExtender ID="cltHardCopyDate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="textHardCopyDate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                                                  <ItemStyle BackColor="LightGreen" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Width="200px" Text='<%# Eval("DISPATCH_REMARKS")%>'></asp:Label>
                                                <asp:TextBox ID="TextRemarks" ReadOnly="false" Width="200px" runat="server" Text='<%# Eval("DISPATCH_REMARKS") %>'
                                                    CssClass="textbox" Visible="false" AutoComplete="off" ToolTip="Invoice No">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                              </Columns>
                                        <AlternatingRowStyle></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
