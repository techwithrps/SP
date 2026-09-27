<%@ Page Title="eLOGiFleet :: EDI Update" Language="VB" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="EDIUpdate.aspx.vb" Inherits="Reports_Fleet_EDIUpdate"
    Theme="Forms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../Script/validation.js">
    </script>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript">

        function TabButton() {
            if (event.keyCode == 9) {
                event.returnValue = true;
            }
            else {
                event.returnValue = false;
            }
        }

        document.onkeydown = function () {
            switch (event.keyCode) {
                case 116: //F5 button
                    event.returnValue = false;
                    event.keyCode = 0;
                    return false;
                case 154: //ctrl + F5 button
                    event.returnValue = false;
                    event.keyCode = 0;
                    return false;
                //case 82: //R button
                //    if (event.ctrlKey) {
                //        event.returnValue = false;
                //        event.keyCode = 0;
                //        return false;
                //    }
                //case 123: //ctrl + R button
                //    if (event.ctrlKey) {
                //        event.returnValue = false;
                //        event.keyCode = 0;
                //        return false;
                //    }
            }
        }

        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };

        function ValidateDate(dt) {
            var str1 = dt.split('/');
            if (str1.length > 0) {
                var mm1 = str1[1];
                var dd1 = str1[0];
                var yy1 = str1[2];
                var today = new Date();
                var dd2 = today.getDate();
                var mm2 = today.getMonth() + 1;
                var yy2 = today.getFullYear();
                if (yy2 >= yy1) {
                    if (yy2 == yy1) {
                        if (mm2 >= mm1) {
                            if (mm2 === mm1) {
                                if (dd2 < dd1) {
                                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                                    dt.value = '';
                                    dt.style.border = '1px solid red';
                                    dt.focus();
                                    return false;
                                } else {
                                    dt.style.border = '1px solid #B3CBFF';
                                }
                            } else {
                                dt.style.border = '1px solid #B3CBFF';
                            }
                        } else {
                            alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                            dt.value = '';
                            dt.style.border = '1px solid red';
                            dt.focus();
                            return false;
                        }
                    } else {
                        dt.style.border = '1px solid #B3CBFF';
                    }
                } else {
                    alert('Please ensure that the entered Date is less than or equal to the Current Date.');
                    dt.value = '';
                    dt.style.border = '1px solid red';
                    dt.focus();
                    return false;
                }
            } else {
                dt.style.border = '1px solid #B3CBFF';
            }
        }


        $(function () {
            $("[id$=TextConsignee]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Reports/Fleet/EDIUpdate.aspx/GetConsignee")%>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hdnConsigneeId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

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
        //function verifyDate(sender, args) {
        //    var d = new Date();
        //    var d1 = new Date();
        //    d.setDate(d.getDate() - 120)
        //    d1.setDate(d1.getDate() + 1)
        //    if (sender._selectedDate < d) {
        //        alert("Date should be Today or Greater than 120 days before Today");
        //        sender._textbox.set_Value('')
        //    }
        //    if (sender._selectedDate > d1) {
        //        alert("Date should be not greater then Today");
        //        sender._textbox.set_Value('')
        //    }
        //}
    </script>
    <table style="width: 100%">
        <tr>
            <td valign="top" style="width: 400px;">
                <asp:Label ID="lblScreenTitle" runat="server" Text="EDI Update" CssClass="FormLabelTitle"
                    Width="300px"> </asp:Label>
            </td>
            <td valign="top">
                <asp:Label ID="lblErrorMessage" Font-Bold="false" runat="server" CssClass="FormLabel"></asp:Label>
            </td>
            <td width="120px" align="right">
                <asp:Label ID="lblmandatory" runat="server" CssClass="FormLabel" Text="* mandatory field"
                    ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdnClickCount" runat="server" />
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
                        <td>
                            <table border="0">
                                <tr>
                                    <td colspan="7" align="center">
                                        <asp:Label ID="lblFilter" runat="server" Text="SELECT & DISPLAY - FILTER" Width="250"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7" align="center" height="12px"></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="LblLine" runat="server" Text="Shipper Name " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="LstLine" runat="server" CssClass="ddlMedium" Width="190px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblShippingLine" runat="server" Text="Line " CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstShipping" runat="server" CssClass="ddlMedium" Width="190px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Label ID="lblCfs" runat="server" Text="CFS " CssClass="label"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="lstCFS" runat="server" CssClass="ddlMedium" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPod" runat="server" Text="POD" CssClass="label"> </asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="lstPod" runat="server" CssClass="ddlMedium" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnDisplay" runat="server" Text="Display" CssClass="FormButton" />
                                        <asp:Button ID="btnExport" Width="80px" runat="server" Text="Export" CssClass="FormButton" />

                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%"></td>
                        <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
                        <td style="width: 2%"></td>
                        <%-- <td>
                            <table border="0">
                                <tr>
                                    <td colspan="8" align="center">
                                        <asp:Label ID="lblUpdate" runat="server" Text="WRITE & SELECT - DRAG" Width="250px"
                                            class="FormLabelTitle"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" align="center" height="12px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="LblRequiredEtd" runat="server" Text="Required ETD" CssClass="label"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textRequiredETD" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="clOutDate" Format="dd/MM/yyyy" runat="server" TargetControlID="textRequiredETD" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblvesselName" runat="server" Text="Vessel" CssClass="label"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="textVessel" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblETA" runat="server" Text="ETA" CssClass="label"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="TextETA" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="clETA" Format="dd/MM/yyyy" runat="server" TargetControlID="TextETA" />
                                    </td>--%>
                        <td align="left">
                            <asp:Button ID="Button3" runat="server" Text="Update" CssClass="FormButton" Visible="false" />
                        </td>
                        <td align="left">
                            <asp:Button ID="Button4" runat="server" Text="Exit" CssClass="FormButton" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%"></td>
            <td style="border-right-style: dotted; border-right-color: inherit; border-right-width: medium;"></td>
            <td style="width: 2%"></td>

        </tr>
    </table>
    </td> </tr>
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
                        <td colspan="16">
                            <div style="height: 100%; overflow: auto; width: 3250px;">
                                <asp:GridView ID="gvtripPendencyList" AutoGenerateColumns="False" runat="server">
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
                                        <asp:TemplateField HeaderText="Sr." HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnMtyContId" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                                <asp:HiddenField ID="HdnContJOId" runat="server" Value='<%# Eval("CONT_JO_ID") %>' />
                                                <asp:HiddenField ID="hdnCFSId" runat="server" Value='<%# Eval("CFS_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="300PX" HeaderText="Shipper" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsignor" Width="300PX" runat="server" Text='<%# Eval("CONSIGNOR_NAME")%>'></asp:Label>
                                                <asp:DropDownList ID="TextConsignor" runat="server" Text='<%# Eval("CONSIGNOR_ID") %>'
                                                    CssClass="ddlMedium" Width="300px" Visible="false" ToolTip="CONSIGNOR" OnDataBinding="prepareCustomer">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField ItemStyle-Width="300PX" HeaderText="Consignee" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsignee" runat="server" Text='<%# Eval("SHIPPER_NAME")%>' Width="300PX"></asp:Label>
                                                <asp:TextBox ID="TextConsignee" runat="server" AutoComplete="off" Text='<%# Eval("SHIPPER_NAME") %>'
                                                    Width="300PX" CssClass="textbox" Visible="false" ToolTip="Consignee">
                                                </asp:TextBox>
                                                <asp:HiddenField ID="hdnConsigneeId" runat="server" />
                                                <asp:HiddenField ID="hdnMTY_CONT_ID" runat="server" Value='<%# Eval("MTY_CONT_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="300PX" HeaderText="Notify" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNotify" runat="server" Text='<%# Eval("NOTIFY_PARTY")%>' Width="300PX"></asp:Label>
                                                <asp:TextBox ID="TextNotify" runat="server" AutoComplete="off" Text='<%# Eval("NOTIFY_PARTY") %>'
                                                    Width="300PX" CssClass="textbox" Visible="false" ToolTip="Notify">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LINE" ItemStyle-Width="120px" HeaderText="LINE" HeaderStyle-CssClass="RepheaderNew"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Cont No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContNO" runat="server" Text='<%# Eval("CONT_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:BoundField DataField="ALLOTMENT_DATE" HeaderText="Allotment Date" HeaderStyle-CssClass="RepheaderNew">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CONT_TYPE" HeaderText="TYPE" HeaderStyle-CssClass="RepheaderNew">
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="CFS" HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                        </asp:BoundField>--%>
                                        <%--  <asp:BoundField DataField="GROSS_WT" HeaderText="Gross Wt." HeaderStyle-CssClass="RepheaderNew">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NET_WT" HeaderText="Net Wt." HeaderStyle-CssClass="RepheaderNew">
                                        </asp:BoundField>--%>
                                        <%--  <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="AntiqueWhite" />
                                            <ItemTemplate>--%>
                                        <%--   <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                <asp:DropDownList ID="Lstcfs" runat="server" value='<%# Eval("CFS_ID") %>' CssClass="RptFormListBoxSmall"
                                                    Visible="false" OnDataBinding="prepareTerminal" ToolTip="Cfs">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Cont Size" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("CONT_SIZE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cont Type" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%# Eval("CONT_TYPE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CFS" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCFS" runat="server" Text='<%# Eval("CFS")%>'></asp:Label>
                                                <%--  <asp:DropDownList ID="Lstcfs" ItemStyle-Width="120px" runat="server" value='<%# Eval("CFS_ID") %>' CssClass="RptFormListBoxSmall"
                                                    Visible="false" OnDataBinding="prepareTerminal" ToolTip="Cfs">
                                                </asp:DropDownList>
                                                --%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commodity Gross Wt." HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrossWt" runat="server" Text='<%# Eval("GROSS_WT")%>'></asp:Label>
                                                <asp:TextBox ID="TxtGrossWeight" AutoComplete="off" onkeypress="kp_numeric();" runat="server" Text='<%# Eval("GROSS_WT") %>' CssClass="textbox"
                                                    Visible="false" ToolTip="Gross Wt.">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commodity Net Wt." HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWeight" runat="server" Text='<%# Eval("NET_WT")%>'></asp:Label>
                                                <asp:TextBox ID="TextWeight" runat="server" AutoComplete="off" onkeypress="kp_numeric();" Text='<%# Eval("NET_WT") %>' CssClass="textbox"
                                                    Visible="false" ToolTip="Net Wt">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="REF Id" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("REF_ID")%>'></asp:Label>
                                                <asp:TextBox ID="textRefId" ReadOnly="false" runat="server" Text='<%# Eval("REF_ID") %>'
                                                    CssClass="textbox" Visible="false" AutoComplete="off" ToolTip="REF Id">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Health Cert.No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHealthNo" runat="server" Text='<%# Eval("HEALTH_CERTIFICATE_NO")%>'></asp:Label>
                                                <asp:TextBox ID="TextHeathNo" runat="server" AutoComplete="off" Text='<%# Eval("HEALTH_CERTIFICATE_NO") %>'
                                                    CssClass="textbox" Visible="false" ToolTip="Health Cert.No">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package Type" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="AntiqueWhite" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackageType" runat="server" Text='<%# Eval("PACKAGE_TYPE")%>'></asp:Label>
                                                <asp:DropDownList ID="lslPackageType" ItemStyle-Width="120px" runat="server" Text='<%# Eval("PACKAGE_TYPE_ID") %>'
                                                    CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Package Type">
                                                    <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="CNTS"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="CUBE"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="PLTS"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="BGS"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="DRMS"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="PKG"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="Container"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="KG"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of PCS." HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPacket" runat="server" Text='<%# Eval("CARTONS")%>'></asp:Label>
                                                <asp:TextBox ID="TextPacket" runat="server" AutoComplete="off" onkeypress="kp_numeric();" Text='<%# Eval("CARTONS") %>' CssClass="textbox"
                                                    Visible="false" ToolTip="Cartons">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commodity" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="AntiqueWhite" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommodityName" runat="server" Text='<%# Eval("COMMODITY_NAME")%>'></asp:Label>
                                                <asp:DropDownList ID="LstCommodityName" ItemStyle-Width="180px" runat="server" Text='<%# Eval("COMMODITY_ID") %>'
                                                    CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Package Type">
                                                    <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="BONELESS BUFFALO MEAT"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="FISH"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="GRAPES"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="ONION"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="BANANA"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="VEGETABLES"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="CHEMICALS"></asp:ListItem>
                                                    <asp:ListItem Value="8" Text="FRUITS"></asp:ListItem>
                                                    <asp:ListItem Value="9" Text="BUFFALO TALLOW"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="HOUSEHOLD ITEMS"></asp:ListItem>
                                                    <asp:ListItem Value="11" Text="SPICES"></asp:ListItem>
                                                    <asp:ListItem Value="12" Text="FROZEN FOODS"></asp:ListItem>
                                                    <asp:ListItem Value="13" Text="NON FROZEN FOODS"></asp:ListItem>
                                                    <asp:ListItem Value="14" Text="FARMA"></asp:ListItem>
                                                    <asp:ListItem Value="15" Text="SWEET CORN"></asp:ListItem>
                                                    <asp:ListItem Value="16" Text="GARMENTS"></asp:ListItem>
                                                    <asp:ListItem Value="17" Text="PET FOOD"></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="BUFFALO HORN"></asp:ListItem>
                                                    <asp:ListItem Value="19" Text="FROZEN BONELESS BUFFALO OFFAL"></asp:ListItem>
                                                    <asp:ListItem Value="20" Text="CHICKEN MEAT"></asp:ListItem>
                                                    <asp:ListItem Value="21" Text="FROZEN HALAL SHEEP MEAT"></asp:ListItem>
                                                    <asp:ListItem Value="22" Text="LEATHER"></asp:ListItem>
                                                    <asp:ListItem Value="23" Text="MILK"></asp:ListItem>
                                                    <asp:ListItem Value="24" Text="BUTTER"></asp:ListItem>
                                                    <asp:ListItem Value="25" Text="GHEE"></asp:ListItem>
                                                    <asp:ListItem Value="26" Text="CANDY"></asp:ListItem>
                                                    <asp:ListItem Value="27" Text="SWEET"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyInvocieNO" runat="server" Text='<%# Eval("INV_NO")%>'></asp:Label>
                                                <asp:TextBox ID="TextPartyInvoiceNO" ReadOnly="false" runat="server" Text='<%# Eval("INV_NO") %>'
                                                    CssClass="textbox" Visible="false" AutoComplete="off" ToolTip="Invoice No">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice Date" Visible="true" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyInvoiceDate" runat="server" Text='<%# Eval("PARTY_INV_DATE")%>'></asp:Label>
                                                <asp:TextBox ID="TextPartyInvoicedate" AutoComplete="off" runat="server" ReadOnly="false" Text='<%# Eval("PARTY_INV_DATE") %>'
                                                    CssClass="textbox" Visible="false" onKeyDown="TabButton();" onpaste="return false;"
                                                    ToolTip="Invoice Date">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clTextPartyInvoicedate" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="TextPartyInvoicedate" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SB No." HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSbNO" runat="server" Text='<%# Eval("SB_NO")%>'></asp:Label>
                                                <asp:TextBox ID="TextSbNo" AutoComplete="off" MaxLength="7" onkeypress="kp_phonenumber();" runat="server" Text='<%# Eval("SB_NO") %>' CssClass="textbox"
                                                    Visible="false" ToolTip="Sb no">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SB Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSbDate" runat="server" Text='<%# Eval("SB_DATE")%>'></asp:Label>
                                                <asp:TextBox ID="TextSbDate" runat="server" Text='<%# Eval("SB_DATE") %>' CssClass="textbox"
                                                    Visible="false" onKeyDown="TabButton();" AutoComplete="off" onpaste="return false;"
                                                    ToolTip="Sb Date">
                                                </asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="clRailOutdate1" Format="dd/MM/yyyy" runat="server"
                                                    TargetControlID="TextSbDate" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Consignment Type" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="#F7DC6F" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsignmentType" runat="server" Text='<%# Eval("CONSIGNMENT_TYPE")%>'></asp:Label>
                                                <asp:DropDownList ID="LstConsignmentType" runat="server" text='<%# Eval("CONSIGNMENT_TYPE_ID") %>'
                                                    CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Consignment Type">
                                                    <asp:ListItem Value="0" Text="SELECT"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="CNF"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="CIF"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="FOB"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="FORWARDING"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FOB Value" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFobValue" runat="server" Text='<%# Eval("FOB_VALUE_INR")%>'></asp:Label>
                                                <asp:TextBox ID="TextFobValue" runat="server" AutoComplete="off" Text='<%# Eval("FOB_VALUE_INR") %>'
                                                    CssClass="textbox" Visible="false" onkeypress="kp_numeric();" ToolTip="FOB Value">
                                                </asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="POD" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPort" runat="server" Text='<%# Eval("PORT")%>'></asp:Label>
                                                <asp:DropDownList ID="lstPod" ItemStyle-Width="200px" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                                                    OnDataBinding="preparePort" value='<%# Eval("POD_ID") %>' ToolTip="pod">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CHA" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCHA" runat="server" Text='<%# Eval("CHA")%>'></asp:Label>
                                                <asp:DropDownList ID="LstCHA" ItemStyle-Width="200px" runat="server" CssClass="RptFormListBoxSmall" Visible="false"
                                                    OnDataBinding="prepareCHA" Text='<%# Eval("CHA_ID") %>' ToolTip="CHA">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="JOB No" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobNo" ItemStyle-Width="120px" runat="server" Text='<%# Eval("JOB_NO")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="JOB Date" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobDate" ItemStyle-Width="120px" runat="server" Text='<%# Eval("JOB_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-CssClass="RepheaderNew">
                                            <ItemStyle BackColor="AntiqueWhite" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblReamrks" runat="server" Text='<%# Eval("REMARKS")%>'></asp:Label>
                                                <asp:DropDownList ID="LstRemarks" ItemStyle-Width="180px" runat="server"
                                                    CssClass="RptFormListBoxSmall" Visible="false" ToolTip="Package Type">
                                                     <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Invoice Pending"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="RFID Data Not Submitted"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="VHC Pending"></asp:ListItem>
                                                </asp:DropDownList>
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
    </table>
</asp:Content>
