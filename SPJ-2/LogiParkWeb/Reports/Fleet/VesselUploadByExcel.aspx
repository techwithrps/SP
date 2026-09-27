<%@ Page Title="eLOGiFleet :: Documentation Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="VesselUploadByExcel.aspx.vb" Inherits="Reports_Fleet_VesselUploadByExcel"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript">

        function whichButton(event) {
            if (event.button == 2)//RIGHT CLICK
            {
                alert("Not Allow Right Click!");
            }

        }
        function noCTRL(e) {
            var code = (document.all) ? event.keyCode : e.which;

            var msg = "Sorry, this functionality is disabled.";
            if (parseInt(code) == 17) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) == 8) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
            if (parseInt(code) == 46) //CTRL
            {
                alert(msg);
                window.event.returnValue = false;
            }
        }
        function verifyDate(sender, args) {
            var d = new Date();
            var d1 = new Date();
            d.setDate(d.getDate() - 30)
            d1.setDate(d1.getDate() + 1)
            if (sender._selectedDate < d) {
                alert("Date should be Today or Greater than 30 days before Today");
                sender._textbox.set_Value('')
            }
            if (sender._selectedDate > d1) {
                alert("Date should be not greater then Today");
                sender._textbox.set_Value('')
            }
        }


    </script>
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
                <asp:Label ID="lblScreenTitle" runat="server" Width="300" Text="Vessel Upload"
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
            <td>
                <table>
                    <tr>
                        <td align="left" valign="top">
                            <table>
                                <tr>
                                    <td align="left" valign="top">
                                        <table>
                                            <tr>
                                                <td style="text-align: right">
                                                    <asp:Label ID="lblFromDate" runat="server" Text="From Date " CssClass="FormLabel"></asp:Label>
                                                </td>
                                              <%--  <td style="text-align: left">
                                                    <asp:TextBox ID="txtICDOUtFrom" runat="server" ToolTip="From Date" AutoComplete="off" Width="90px" CssClass="textbox"
                                                        onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                                                    <span class="mandatory" style="vertical-align: top;">*</span>
                                                    <ajaxToolkit:CalendarExtender ID="clFromDate" Format="dd/MM/yyyy" runat="server"
                                                        TargetControlID="txtICDOUtFrom" />
                                                    <asp:Label ID="lblToDate" runat="server" Text="To Date " CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:TextBox ID="txtICDOutToDate" runat="server" ToolTip="To Date" AutoComplete="off" Width="90px" CssClass="textbox"
                                                        onkeypress="kp_date();" MaxLength="10"> </asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    <span class="mandatory" style="vertical-align: top;">*</span>
                                                    <ajaxToolkit:CalendarExtender ID="clToDate" Format="dd/MM/yyyy" runat="server" TargetControlID="txtICDOutToDate" />
                                                </td>--%>

                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label1" runat="server" Text="POL" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddlPOL" runat="server" ToolTip="POL" Width="150px" CssClass="ddlMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="Label2" runat="server" Text="POD" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddlPOD" runat="server" ToolTip="POD" Width="150px" CssClass="ddlMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="lblShipper" runat="server" Text="Customer Name" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddShipper" runat="server" ToolTip="Terminal Name" Width="150px" CssClass="ddlMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:Label ID="lblLine" runat="server" Text="Shipping Line" CssClass="FormLabel"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddlLine" runat="server" ToolTip="Shipping Line" Width="150px" CssClass="ddlMedium">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                                                    <asp:Button ID="btnExcel" runat="server" Text="Excel Download" Visible="false" CssClass="FormButton" />
                                                    <asp:Button ID="btnExport" Width="120px" runat="server" Text="Excel Download" CssClass="FormButton" />
                                                    <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="FormButton" />
                                                </td>
                                                <tr>
                                                    <td style="text-align: RIGHT">
                                                        <asp:Label ID="lblFile" runat="server" Text="Browse File" CssClass="label" Width="100px" Height="19px"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:FileUpload ID="fuFileLocation" Width="250" Visible="true" Enabled="true" runat="server" />
                                                    </td>
                                                    <td style="text-align: right">
                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="FormButton" />
                                                        <asp:HiddenField ID="hdnCheckUpload" runat="server" />
                                                        <asp:HiddenField ID="hdnFileId" runat="server" />
                                                        <asp:Button ID="btnDownload" runat="server" Text="Download" Visible="false" CssClass="FormButton" />

                                                    </td>
                                                    <td align="center" rowspan="3">
                                                        <asp:Button ID="btnupdate" runat="server" Text="Save" CssClass="FormButton" Visible="true" />
                                                    </td>
                                                    <td colspan="2" align="right">

                                                        <asp:LinkButton ID="linkDownload" runat="server" Width="120px" Text="Format Download" Visible="true" Font-Size="Smaller" />
                                                    </td>
                                                </tr>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <div style="height: 100%; width: 100%; overflow: auto;">
                                <table cellspacing="0" id="tblReport" runat="server">
                                    <tr>
                                        <td colspan="10">
                                            <asp:Label ID="lblReport" CssClass="FormLabel" runat="server" Font-Bold="true" Text="Report Date: "></asp:Label><asp:Label
                                                ID="lblReportDate" CssClass="FormLabel" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%-- <tr class="RepHead">
                            <td>
                                <asp:Label ID="lblrSerialNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Sr" Width="30px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrCustomerName" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Customer Name" Width="300px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrInvoiceNo" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice No." Width="130px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrInvoiceDate" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Invoice Date" Width="100px"></asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblrAmount" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Amount" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrIGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="IGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrCGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="CSGT" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrSGST" CssClass="FormLabel" runat="server" Font-Bold="True" Text="SGST" Width="50px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblrTotalAmt" CssClass="FormLabel" runat="server" Font-Bold="True" Text="Total" Width="100px"></asp:Label>
                            </td>

                            <td style="background-color: White; width: 15px;"></td>
                        </tr>--%>
                                    <tr>
                                        <td colspan="20">
                                            <div style="height: 100%; overflow: auto; width: 2140px;">
                                                <asp:GridView ID="gvInvoiceReport" ShowHeader="True" RowStyle-CssClass="FormListBoxLarg"
                                                    AutoGenerateColumns="false" runat="server">
                                                    <RowStyle CssClass="FormLabel" BackColor="LightGreen"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle Font-Bold="true" CssClass="RepheaderNew" />
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sr No" ControlStyle-Width="35px" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SR")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cont Jo No" ControlStyle-Width="80px" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContJoNo" runat="server" Text='<%# Eval("CONT_JO_NO")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-Width="300PX" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>

                                                                <asp:Label ID="lblConsignee" runat="server" Text='<%# Eval("SHIPPER")%>' Width="300PX"></asp:Label>
                                                                <asp:TextBox ID="TextConsignee" runat="server" Text='<%# Eval("SHIPPER") %>'
                                                                    Width="300PX" CssClass="textbox" Visible="false" ToolTip="Consignee">
                                                                </asp:TextBox>
                                                                <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                                <asp:HiddenField ID="HdnContJOId" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                                                                <asp:HiddenField ID="hdnPOL" runat="server" Value='<%# Eval("POL") %>' />
                                                                <asp:HiddenField ID="hdnPort" runat="server" Value='<%# Eval("PORT") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ICD Out Date" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIcdOutDate" Width="120px" runat="server" Text='<%# Eval("ICD_OUT_DATE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Line" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Transporter" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransporter" runat="server" Text='<%# Eval("TRANSPORTER")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Booking No." HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBookingNo" runat="server" Text='<%# Eval("BOOKING_NO")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Booking Date" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbllineHandover" Width="120px" runat="server" Text='<%# Eval("BOOKING_DATE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="AntiqueWhite" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="PORT" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="LightGreen" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblpod" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                                <asp:TextBox ID="txtpod" AutoComplete="OFF" runat="server" CssClass="textbox"
                                                                    Visible="false" BackColor="LightGreen" Text='<%# Eval("PORT") %>' Width="150px">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="LightGreen" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPOL" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                                                                <asp:TextBox ID="txtPOL" AutoComplete="OFF" runat="server" CssClass="textbox"
                                                                    Visible="false" BackColor="LightGreen" Text='<%# Eval("POL") %>' Width="150px">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%-- <asp:TemplateField HeaderText="PORT" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                                <asp:DropDownList ID="Lstpod" runat="server" CssClass="RptFormListBoxSmall" Visible="true"
                                                                   value='<%# Eval("POD_ID") %>' ToolTip="pod">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="POL" HeaderStyle-CssClass="RepheaderNew">
                                                             <ItemTemplate>
                                                                <asp:Label ID="lblPol" runat="server" Text='<%# Eval("POL")%>'></asp:Label>
                                                                <asp:DropDownList ID="Lstpol" runat="server" CssClass="RptFormListBoxSmall" Visible="true"
                                                                     value='<%# Eval("POL_ID") %>' ToolTip="POl">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Vessel Name" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemStyle BackColor="LightGreen" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFinalVessel" runat="server" Text='<%# Eval("VESSEL_NAME")%>'></asp:Label>
                                                                <asp:TextBox ID="TxtFinalVessel" AutoComplete="OFF" runat="server" CssClass="textbox"
                                                                    Visible="false" BackColor="LightGreen" Text='<%# Eval("VESSEL_NAME") %>' Width="150px">
                                                                </asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ETD" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblETD" runat="server" Text='<%# Eval("ETD_DATE")%>'></asp:Label>
                                                                <asp:TextBox ID="TxtRequiredEtd" runat="server" CssClass="textbox" Text='<%# Eval("ETD_DATE")%>'
                                                                    Width="100px" Visible="false" Enabled="False"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="clETD" Format="dd/MM/yyyy" runat="server" TargetControlID="TxtRequiredEtd" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SI CutofDate" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSiCut" runat="server" Width="130" Text='<%# Eval("SI_CUTOF_DATE")%>'></asp:Label>
                                                                <asp:TextBox ID="TxtSiCut" runat="server" AutoComplete="OFF" CssClass="textbox" Visible="false" onpaste="return false;"
                                                                    BackColor="LightGreen" Text='<%# Eval("SI_CUTOF_DATE") %>'>>
                                                                </asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="clTxtSiCut" Format="dd/MM/yyyy" runat="server"
                                                                    TargetControlID="TxtSiCut" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Port Cut Of Date" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPortCutOfDate" runat="server" Width="130" Text='<%# Eval("PORT_CUTOF_DATE")%>'></asp:Label>
                                                                <asp:TextBox ID="TextPortCutOfDate" AutoComplete="off" runat="server" Text='<%# Eval("PORT_CUTOF_DATE") %>'
                                                                    CssClass="textbox" Visible="false" onKeyDown="TabButton();" onpaste="return false;"
                                                                    ToolTip="Custom Handover">
                                                                </asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="clTextPortCutOfDate" Format="dd/MM/yyyy" runat="server"
                                                                    TargetControlID="TextPortCutOfDate" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ETA" HeaderStyle-CssClass="RepheaderNew">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblETA" runat="server" Width="130" Text='<%# Eval("ETA_DATE")%>'></asp:Label>
                                                                <asp:TextBox ID="TextETA" AutoComplete="off" runat="server" Text='<%# Eval("ETA_DATE") %>'
                                                                    CssClass="textbox" Visible="false" onKeyDown="TabButton();" onpaste="return false;"
                                                                    ToolTip="Custom Handover">
                                                                </asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="clTextETA" Format="dd/MM/yyyy" runat="server"
                                                                    TargetControlID="TextETA" />
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
                    <tr>
                        <td align="center">
                            <asp:ImageButton ID="ImgBtnUpdate" runat="server" ImageUrl="~/Images/btnUpdate.png"
                                Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
